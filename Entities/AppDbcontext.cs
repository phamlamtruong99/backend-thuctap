using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebTT.Entities
{
    public class AppDbcontext : DbContext
    {
        public virtual DbSet<token> token { get; set; }
        public virtual DbSet<chuas> chuas { get; set; }
        public virtual DbSet<phattudaotrangs> phattudaotrangs { get; set; }
        public virtual DbSet<dondangkys> dondangkys { get; set; }
        public virtual DbSet<phattu> phattus { get; set; }
        public virtual DbSet<kieuthanhviens> kieuthanhviens { get; set; }
        public virtual DbSet<daotrangs> daotrangs { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server =DESKTOP-9U33V76\\SQLEXPRESS ; Database = Webtt1 ; Integrated Security = True;TrustServerCertificate=True");
        }
    }
}
