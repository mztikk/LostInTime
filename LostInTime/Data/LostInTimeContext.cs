using System;
using LostInTime.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LostInTime.Data
{
    public class LostInTimeContext : DbContext, IDesignTimeDbContextFactory<LostInTimeContext>
    {
        public LostInTimeContext()
        {

        }

        public LostInTimeContext(DbContextOptions<LostInTimeContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<TemplateGroup> TemplateGroups { get; set; }

        public LostInTimeContext CreateDbContext(string[] args)
        {
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            string dbPath = System.IO.Path.Join(path, "lostintime.db");
            DbContextOptionsBuilder<LostInTimeContext> optionsBuilder = new();
            _ = optionsBuilder.UseSqlite($"Data Source={dbPath}");

            return new(optionsBuilder.Options);
        }
    }
}
