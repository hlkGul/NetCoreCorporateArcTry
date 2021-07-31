using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context Db tabloları ile classları iliskilendirmek
    public class NorthwindContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = localhost,1433;Database = Northwind;User Id = sa; Password = Az500g90+ ;MultipleActiveResultSets=True; ");
        }
        //bu yapıyı windows makinelerde kullanacagız.ayrı klasörleme yapılabilirdi
        //protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb;Database = Northwind;Trusted_Connection=true ");
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
