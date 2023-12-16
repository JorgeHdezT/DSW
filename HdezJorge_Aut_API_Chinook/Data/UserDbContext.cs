using APIMusica_HdezJorge.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APIMusica_HdezJorge.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser>
    {
        public UserDbContext() { }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Crear roles
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            var passwordHasher = new PasswordHasher<IdentityUser>();

            // Crear usuarios
            List<IdentityUser> users = new List<IdentityUser>
            {
                new IdentityUser { UserName = "admin", PasswordHash = passwordHasher.HashPassword(null, "admin") },
                new IdentityUser { UserName = "manager", PasswordHash = passwordHasher.HashPassword(null, "manager") },
                new IdentityUser { UserName = "user", PasswordHash = passwordHasher.HashPassword(null, "user") }
            };
            modelBuilder.Entity<IdentityUser>().HasData(users);

            // Asignar roles a usuarios
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string> { UserId = users[0].Id, RoleId = roles[0].Id }); // Asignar rol "Admin" al usuario "admin"
            userRoles.Add(new IdentityUserRole<string> { UserId = users[1].Id, RoleId = roles[1].Id }); // Asignar rol "Manager" al usuario "manager"
            userRoles.Add(new IdentityUserRole<string> { UserId = users[2].Id, RoleId = roles[2].Id }); // Asignar rol "User" al usuario "user"
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}