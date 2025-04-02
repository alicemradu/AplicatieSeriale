using SQLite;
using TVSeriesProiect.Models;

namespace TVSeriesProiect.Services
{
    public class DataService
    {
        SQLiteAsyncConnection sqlConnection;
        public async Task bdInitialization()
        {
            if (sqlConnection == null)
            {
                sqlConnection = new SQLiteAsyncConnection(
                    Path.Combine(FileSystem.AppDataDirectory,
                    "tvserie.db"));

                await sqlConnection.CreateTableAsync<TVSerie>();
            }
        }

        public async Task<long> Insert(TVSerie tvserie)
        {
            await bdInitialization();
            return await sqlConnection.InsertAsync(tvserie);
        }

        public async Task<long> InsertTVSeriesList(List<TVSerie> tvseriesList)
        {
            await bdInitialization();
            return await sqlConnection.InsertAllAsync(tvseriesList);
        }
        public async Task<List<TVSerie>> GetAllTVSeries()
        {
            await bdInitialization();
            return await sqlConnection.QueryAsync<TVSerie>("SELECT * FROM tvserie");
        }

        public async Task<List<TVSerie>> GetAllTVSeriesByActor(string actor)
        {
            await bdInitialization();
            return await sqlConnection.QueryAsync<TVSerie>("SELECT * FROM tvserie WHERE actors LIKE '%' || ? || '%'", actor);
        }

        public async Task DeleteAll()
        {
            await bdInitialization();
            await sqlConnection.DeleteAllAsync<TVSerie>();
        }
    }
}
