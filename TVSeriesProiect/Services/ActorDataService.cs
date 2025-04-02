using SQLite;
using TVSeriesProiect.Models;

namespace TVSeriesProiect.Services
{
    public class ActorDataService
    {
        SQLiteAsyncConnection sqlConnection;
        public async Task bdInitialization() //initializare db
        {

            if (sqlConnection == null)
            {
                sqlConnection = new SQLiteAsyncConnection(
                    Path.Combine(FileSystem.AppDataDirectory,
                "actor.db"));

                await sqlConnection.CreateTableAsync<Actor>();
            }
        }

        public async Task<long> Insert(Actor actor)
        {
            await bdInitialization();
            return await sqlConnection.InsertAsync(actor);
        }

        public async Task<long> InsertActorsList(List<Actor> actorsList)
        {
            await bdInitialization();
            return await sqlConnection.InsertAllAsync(actorsList);
        }

        public async Task<List<Actor>> GetAllActors()
        {
            await bdInitialization();
            return await sqlConnection.QueryAsync<Actor>("SELECT * FROM actor");
        }

        public async Task<List<Actor>> GetAllActorsByName(string name)
        {
            await bdInitialization();
            return await sqlConnection.QueryAsync<Actor>(
                "SELECT * FROM actor WHERE name = ? ORDER BY numberOfTVSeriesInTop DESC", name);
        }

        public async Task DeleteAll()
        {
            await bdInitialization();
            await sqlConnection.DeleteAllAsync<Actor>();
        }
    }
}

