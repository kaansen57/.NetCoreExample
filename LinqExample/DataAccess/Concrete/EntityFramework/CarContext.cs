using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //context nesnesi , proje classlarını ve db tablolalarını ilişkilendirir.
    public class CarContext :DbContext
    {
        //Bu metot ile hangi veritabanıyla ilişkili olduğunun ayarlarını yapıyoruz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //trusted_connection şifresiz veritabanına bağlanmayı sağlar.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Cars;Trusted_Connection=true");
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserJWT> UsersJWT { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

    }
}
