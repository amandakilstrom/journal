using Microsoft.EntityFrameworkCore;
using Journal.Api.Models;

namespace Journal.Api.Data
{
    public class JournalDb : DbContext
    {
        public JournalDb(DbContextOptions<JournalDb> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}