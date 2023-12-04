using HernandezJorge_API_Ej2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HernandezJorge_API_Ej2.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser>
    {

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users {  get; set; }
        //El "seeder" para nuestros users. Que se creara en la nueva base de datos User.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder); //Necesario

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole{
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
             }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            var passwordHasher = new PasswordHasher<IdentityUser>();

            List<IdentityUser> users = new List<IdentityUser>
            {
                new IdentityUser { UserName = "usuario 1", Email = "ejemplo@ejemplo.com", PasswordHash = passwordHasher.HashPassword(null, "pass1")},
                new IdentityUser { UserName = "usuario 2", Email = "ejemplo2@ejemplo.com", PasswordHash = passwordHasher.HashPassword(null, "pass2")},
                new IdentityUser { UserName = "usuario 3", Email = "ejemplo3@ejemplo.com", PasswordHash = passwordHasher.HashPassword(null, "pass3")}
            };
            
            modelBuilder.Entity<IdentityUser>().HasData(users);

            List<IdentityUserRole<string>> UserRole = new List<IdentityUserRole<string>>();

            foreach (var user in users)
            {
                UserRole.Add(new IdentityUserRole<string>
                {
                    UserId =  user.Id,
                    RoleId = roles[0].Id //Le asigno el roleUser a todos los usuarios creados.
                });
            }

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(UserRole);

            base.OnModelCreating(modelBuilder); //Necesario otra vez.


        }
    }
}
