using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIMusica_HernandezJorge.Migrations
{
    public partial class UserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2b3076b-af2d-4108-a98c-480cdedc8aa5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "363437cc-199c-4938-9494-19f02b81e669", "88e4217c-e4ab-4d6d-9192-462a55b7da7b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "363437cc-199c-4938-9494-19f02b81e669", "aba6ac9d-aced-486e-8618-2e41293fb5de" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "363437cc-199c-4938-9494-19f02b81e669", "daf1732c-0c22-4718-a615-e599e69c98c2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "363437cc-199c-4938-9494-19f02b81e669");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88e4217c-e4ab-4d6d-9192-462a55b7da7b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aba6ac9d-aced-486e-8618-2e41293fb5de");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "daf1732c-0c22-4718-a615-e599e69c98c2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66ce73ba-9859-4f50-a46f-bb129e49ce67", "815f5c49-ac17-4b45-a256-5b6efe87a036", "User", "USER" },
                    { "de1d3ce6-9f9f-41c7-97f1-ef7d2d1dc1f6", "0597c883-317a-4f8a-9cbf-2f64fcd58e7f", "Admin", "ADMIN" },
                    { "fe126c42-7053-4db4-b772-5d719c7fda61", "0bb5278e-ceaf-4874-aaa5-02d46c6b13fd", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1fbfc671-9df3-43a1-8a41-fdd4eba5b546", 0, "cdf7694c-b3ad-412a-a3a2-4e773508a4bb", null, false, false, null, null, null, "AQAAAAEAACcQAAAAEC6uWzKvLGN3ifNsa2UC/eB4E1vncBQzKQo4siKy+XZcdGtf2hi/EdEnq+JK/PLInw==", null, false, "0cbc8e30-1377-4a24-98c8-0cdea44f7a36", false, "user" },
                    { "687554fe-830d-4e22-8582-aef4d1121e04", 0, "953551fc-c31c-4012-a974-750de90b203d", null, false, false, null, null, null, "AQAAAAEAACcQAAAAEDZU9uMN6R19J2845r2mVKqh4BgLX1i65iP7w0B+dMWprJOHZDk5MitoWu7FvFF+lQ==", null, false, "45adf56f-2b29-40a6-98a9-937251613e0e", false, "admin" },
                    { "b2453144-99e7-48f1-ae2c-37913cfb8f2d", 0, "8ed1217d-2322-4948-b9f8-72f5eaf89948", null, false, false, null, null, null, "AQAAAAEAACcQAAAAEDRWfn4Nve5ZQLL2tjIqXtnU5JDRSxBqm4XABES7+FOnnC/5gKKaUOgc17lkjIAp1Q==", null, false, "983cf919-9f5d-4a81-89ed-27e9eb71788c", false, "manager" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "66ce73ba-9859-4f50-a46f-bb129e49ce67", "1fbfc671-9df3-43a1-8a41-fdd4eba5b546" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "de1d3ce6-9f9f-41c7-97f1-ef7d2d1dc1f6", "687554fe-830d-4e22-8582-aef4d1121e04" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fe126c42-7053-4db4-b772-5d719c7fda61", "b2453144-99e7-48f1-ae2c-37913cfb8f2d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "66ce73ba-9859-4f50-a46f-bb129e49ce67", "1fbfc671-9df3-43a1-8a41-fdd4eba5b546" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "de1d3ce6-9f9f-41c7-97f1-ef7d2d1dc1f6", "687554fe-830d-4e22-8582-aef4d1121e04" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fe126c42-7053-4db4-b772-5d719c7fda61", "b2453144-99e7-48f1-ae2c-37913cfb8f2d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66ce73ba-9859-4f50-a46f-bb129e49ce67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de1d3ce6-9f9f-41c7-97f1-ef7d2d1dc1f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe126c42-7053-4db4-b772-5d719c7fda61");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1fbfc671-9df3-43a1-8a41-fdd4eba5b546");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "687554fe-830d-4e22-8582-aef4d1121e04");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2453144-99e7-48f1-ae2c-37913cfb8f2d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "363437cc-199c-4938-9494-19f02b81e669", "38e62d4f-9c89-4f2b-a117-de8d2fe3570f", "User", "USER" },
                    { "c2b3076b-af2d-4108-a98c-480cdedc8aa5", "d6c61cab-954b-4d68-9f4d-18932a0520c9", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "88e4217c-e4ab-4d6d-9192-462a55b7da7b", 0, "ae55691e-2965-4929-aceb-9c86284458a8", null, false, false, null, null, null, "AQAAAAEAACcQAAAAEH6pS5ocR0rq6g/Gf+Tr24/t2US2T2F55UDb6WPy/Cw2wF9dxN3TUcdATV5amaP7qQ==", null, false, "729fb5b8-47da-4b2c-ad31-a0eeb53730de", false, "usuario 3" },
                    { "aba6ac9d-aced-486e-8618-2e41293fb5de", 0, "c51787d1-0aa5-48a7-a826-effca4548c54", null, false, false, null, null, null, "AQAAAAEAACcQAAAAEAd9r3TnN6sKerdPwPsP1UOJ40BOrUHYDU1M+2EVUNMHwy50VzBUlacqhpmdvj0t/w==", null, false, "0412767d-1b93-429b-89cb-037f24b252c4", false, "usuario 1" },
                    { "daf1732c-0c22-4718-a615-e599e69c98c2", 0, "687f0dd1-80be-4ec1-afb2-60b18b6c8eab", null, false, false, null, null, null, "AQAAAAEAACcQAAAAEGCPZjB7S1bshjyFqREFo5BsqzqDtuDkVYIYssZxoSZPn6k/x44gJOytWYSAfhgvYw==", null, false, "4d71c168-1c2e-4075-a27c-5401f0d7207a", false, "usuario 2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "363437cc-199c-4938-9494-19f02b81e669", "88e4217c-e4ab-4d6d-9192-462a55b7da7b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "363437cc-199c-4938-9494-19f02b81e669", "aba6ac9d-aced-486e-8618-2e41293fb5de" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "363437cc-199c-4938-9494-19f02b81e669", "daf1732c-0c22-4718-a615-e599e69c98c2" });
        }
    }
}
