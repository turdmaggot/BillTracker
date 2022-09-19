using SQLite;
using BillTracker.Models;

namespace BillTracker.Services
{
    public class SQLiteRepository
    {
        private static readonly string dbFileName = "billtracker.db";
        private static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbFileName);

        private SQLiteAsyncConnection _con;

        private async Task Init()
        {
            if (_con != null)
                return;

            _con = new SQLiteAsyncConnection(dbPath);
            await CreateTables();
        }

        private async Task CreateTables()
        {
            await _con.CreateTableAsync<Biller>();
            await _con.CreateTableAsync<Bill>();
        }

        /// <summary>
        /// Adds a new biller into the SQLiteDB.
        /// </summary>
        /// <param name="billerName">Name of the biller (e.g. BDO Mastercard).</param>
        /// <param name="billerReferenceNo">Can be the account or card number of the bill.</param>
        /// <param name="billerType">Is this a Credit Card, Utility? You tell me.</param>
        /// <returns></returns>
        public async Task<int> AddBiller(string billerName, string billerReferenceNo, string billerType)
        {
            await Init();

            var billerToAdd = new Biller {
                BillerName = billerName,
                BillerReferenceNo = billerReferenceNo,
                BillerType = billerType,
                DateAdded = DateTime.Now
            };

            return await _con.InsertAsync(billerToAdd);
        }

        public async Task<List<Biller>> GetAllBillers()
        {
            await Init();
            return await _con.Table<Biller>().ToListAsync();
        }

    }
}
