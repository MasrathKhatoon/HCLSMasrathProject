using HclsPro.Models;
using Microsoft.EntityFrameworkCore;

namespace HclsPro.DBContext
{
    public class HCLSDBContext :DbContext
    {
        public HCLSDBContext(DbContextOptions<HCLSDBContext> options): base(options) { }
        public DbSet<AdminTypes> AdminTypes { get; set; }
        public DbSet<Admin> Admin {  get; set; }
        
    }
}
