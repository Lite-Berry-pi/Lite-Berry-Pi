using System;
using System.Collections.Generic;
using System.Text;
using Lite_Berry_Pi.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Lite_Berry_Pi.Models;
using Xunit;
using System.Threading.Tasks;

namespace Tests
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly LiteBerryDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new LiteBerryDbContext(
                new DbContextOptionsBuilder<LiteBerryDbContext>()
                .UseSqlite(_connection)
                .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        protected async Task<User> CreateAndSaveTestUser()
        {
            var user = new User { Name = "Test" };
            _db.User.Add(user);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, user.Id);
            return user;
        }

        protected async Task<Design> CreateAndSaveTestDesign()
        {
            var design = new Design { Title = "Test", DesignCoords = "test" };
            _db.Design.Add(design);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, design.Id);
            return design;
        }
    }
}
