using ContactMVCProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactMVCProject.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ContactModel> Contacts { get; set; }
    }
}
