using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedEnemyLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("UPDATE [dbo].[Enemies] SET [RoomId] = 14 WHERE [Id] = 1");
            migrationBuilder.Sql("UPDATE [dbo].[Enemies] SET [RoomId] = 3 WHERE [Id] = 2");
            migrationBuilder.Sql("UPDATE [dbo].[Enemies] SET [RoomId] = 4 WHERE [Id] = 3");
            migrationBuilder.Sql("UPDATE [dbo].[Enemies] SET [RoomId] = 12 WHERE [Id] = 4");
            migrationBuilder.Sql("UPDATE [dbo].[Enemies] SET [RoomId] = 6 WHERE [Id] = 7");
            migrationBuilder.Sql("UPDATE [dbo].[Enemies] SET [Name] = N'Licker', [RoomId] = 10 WHERE [Id] = 9");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("UPDATE [dbo].[Enemies] SET [RoomId] = NULL WHERE [Id] = 1");
            migrationBuilder.Sql("UPDATE [dbo].[Enemies] SET [RoomId] = NULL WHERE [Id] = 2");
            migrationBuilder.Sql("UPDATE [dbo].[Enemies] SET [RoomId] = NULL WHERE [Id] = 3");
            migrationBuilder.Sql("UPDATE [dbo].[Enemies] SET [RoomId] = NULL WHERE [Id] = 4");
            migrationBuilder.Sql("UPDATE [dbo].[Enemies] SET [RoomId] = NULL WHERE [Id] = 7");
            migrationBuilder.Sql("UPDATE [dbo].[Enemies] SET [Name] = N'Hall Licker', [RoomId] = NULL WHERE [Id] = 9");

        }

    }
}
