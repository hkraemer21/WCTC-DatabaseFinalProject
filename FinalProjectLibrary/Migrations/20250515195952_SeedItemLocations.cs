using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedItemLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = 5 WHERE [Id] = 3");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = 5 WHERE [Id] = 4");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = 3 WHERE [Id] = 5");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = 1 WHERE [Id] = 6");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = 11 WHERE [Id] = 7");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [Description] = N'A notebook covered in blood. Wonder what is written inside.', [RoomId] = 17 WHERE [Id] = 8");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = 8 WHERE [Id] = 9");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = 2 WHERE [Id] = 10");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = 13 WHERE [Id] = 11");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = 10 WHERE [Id] = 12");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = NULL WHERE [Id] = 3");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = NULL WHERE [Id] = 4");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = NULL WHERE [Id] = 5");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = NULL WHERE [Id] = 6");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = NULL WHERE [Id] = 7");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [Description] = NULL, [RoomId] = NULL WHERE [Id] = 8");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = NULL WHERE [Id] = 9");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = NULL WHERE [Id] = 10");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = NULL WHERE [Id] = 11");
            migrationBuilder.Sql("UPDATE [dbo].[Items] SET [RoomId] = NULL WHERE [Id] = 12");
        }

    }
}
