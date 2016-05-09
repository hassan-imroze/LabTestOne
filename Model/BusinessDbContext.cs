using System;
using System.Data.Entity;
using System.Linq;

namespace Model
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext() : base("DefaultConnection")
        {
        }


        public override int SaveChanges()
        {
            var dbEntityEntries = ChangeTracker.Entries().Where(x => x.Entity is Entity);
            foreach (var entry in dbEntityEntries)
            {
                var entity = (Entity)entry.Entity;
                entity.Modified = DateTime.Now;
            }

            return base.SaveChanges();
        }

        public static BusinessDbContext Create()
        {
            return new BusinessDbContext();
        }

        //tables 
        public DbSet<ServiceFee> ServiceFees { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<PaidServiceFee> PaidServiceFee { get; set; }
    }
}