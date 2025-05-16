using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoomDirections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [UpId] = 2, [WestId] = 3, [EastId] = 15, [DownId] = 18 WHERE [Id] = 1");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [DownId] = 1, [WestId] = 12 WHERE [Id] = 2");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [EastId] = 1, [NorthId] = 4 WHERE [Id] = 3");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [SouthId] = 3, [NorthId] = 5, [UpId] = 6 WHERE [Id] = 4");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [SouthId] = 4 WHERE [Id] = 5");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [DownId] = 5, [UpId] = 7 WHERE [Id] = 6");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [DownId] = 6, [WestId] = 8 WHERE [Id] = 7");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [EastId] = 7, [WestId] = 9 WHERE [Id] = 8");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [EastId] = 8, [SouthId] = 10 WHERE [Id] = 9");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [NorthId] = 9, [EastId] = 11 WHERE [Id] = 10");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [WestId] = 10, [DownId] = 12 WHERE [Id] = 11");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [UpId] = 11, [WestId] = 2, [SouthId] = 13 WHERE [Id] = 12");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [NorthId] = 12 WHERE [Id] = 13");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [WestId] = 15, [EastId] = 16 WHERE [Id] = 14");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [WestId] = 1, [EastId] = 14 WHERE [Id] = 15");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [WestId] = 14, [NorthId] = 17 WHERE [Id] = 16");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [SouthId] = 16 WHERE [Id] = 17");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [UpId] = 1 WHERE [Id] = 18");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [UpId] = NULL, [WestId] = NULL, [EastId] = NULL [DownId] = NULL WHERE [Id] = 1");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [DownId] = NULL, [WestId] = NULL WHERE [Id] = 2");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [EastId] = NULL, [NorthId] = NULL WHERE [Id] = 3");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [SouthId] = NULL, [NorthId] = NULL, [UpId] = NULL WHERE [Id] = 4");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [SouthId] = NULL WHERE [Id] = 5");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [DownId] = NULL, [UpId] = NULL WHERE [Id] = 6");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [DownId] = NULL, [WestId] = NULL WHERE [Id] = 7");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [EastId] = NULL, [WestId] = NULL WHERE [Id] = 8");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [EastId] = NULL, [SouthId] = NULL WHERE [Id] = 9");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [NorthId] = NULL, [EastId] = NULL WHERE [Id] = 10");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [WestId] = NULL, [DownId] = NULL WHERE [Id] = 11");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [UpId] = NULL, [WestId] = NULL, [SouthId] = NULL WHERE [Id] = 12");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [NorthId] = NULL WHERE [Id] = 13");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [WestId] = NULL, [EastId] = NULL WHERE [Id] = 14");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [WestId] = NULL, [EastId] = NULL WHERE [Id] = 15");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [WestId] = NULL, [NorthId] = NULL WHERE [Id] = 16");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [SouthId] = NULL WHERE [Id] = 17");
            migrationBuilder.Sql("UPDATE [dbo].[Rooms] SET [UpId] = NULL WHERE [Id] = 18");

        }

    }
}
