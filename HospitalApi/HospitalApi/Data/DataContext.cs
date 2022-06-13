using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Apointment>  Apointment{ get; set; }
    }
}
