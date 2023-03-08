using System;
using LostInTime.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LostInTime
{
    public class CharacterContext : DbContext, IDesignTimeDbContextFactory<CharacterContext>
    {
        public CharacterContext()
        {
            
        }

        public CharacterContext(DbContextOptions<CharacterContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }

        public CharacterContext CreateDbContext(string[] args)
        {
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            string dbPath = System.IO.Path.Join(path, "lostintime.db");
            DbContextOptionsBuilder<CharacterContext> optionsBuilder = new();
            _ = optionsBuilder.UseSqlite($"Data Source={dbPath}");

            return new(optionsBuilder.Options);
        }
    }
}
