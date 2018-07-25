using System;
using System.Collections.Generic;
using System.Text;
using BlackJack.DataAccessLayer.Iterfaces;
using BlackJack.EntitiesLayer.Enums;
using BlackJack.EntitiesLayer.Models;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BlackJack.DataAccessLayer.DapperRepositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IDbConnection db = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = '|DataDirectory|\\MyDB.mdf'; Integrated Security = True");

        public  Task DeletePlayer(int id)
        {
            db.Open();
            return db.ExecuteAsync("DELETE FROM Players WHERE Id=@Id", new { Id = id });
        }

        public Task<Player> GetPlayerById(int id)
        {
            db.Open();
            return db.QueryFirstOrDefaultAsync<Player>("Select * From Players WHERE Id=@Id", new { Id = id });
        }

        public Task<IEnumerable<Player>> GetPlayers()
        {
            db.Open();
            return db.QueryAsync<Player>("SELECT * FROM Players");
        }

        public Task InsertPlayer(Player player)
        {
            string sql = "INSERT INTO Players (Name, Points, RoleId) Values(@Name, @Points, @RoleId);";
            db.Open();
            return db.ExecuteAsync(sql, new { Name = player.Name, Points = player.Points, RoleId = (int)player.Role });
        }

        public Task Save()
        {
            db.Open();
            return db.ExecuteAsync("COMMIT;");
        }

        public Task UpdatePlayer(Player player)
        {
            string sql = "UPDATE Players SET Name=@Name, Points=@Points, RoleId=@RoleId WHERE Id=@Id;";
            db.Open();
            return db.ExecuteAsync(sql, new { Name = player.Name, Points = player.Points, RoleId = (int)player.Role, Id = player.Id });
        }
    }
}

