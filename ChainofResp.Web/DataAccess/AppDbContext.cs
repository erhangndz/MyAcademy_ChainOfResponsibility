using ChainofResp.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChainofResp.Web.DataAccess
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=ChainOfRespDb;integrated security=true;trustServerCertificate=true");
        }



        public DbSet<CustomerProcess> CustomerProcesses { get; set; }


    }
}
