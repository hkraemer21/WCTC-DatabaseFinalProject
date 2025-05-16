using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedEnemyAbilities : Migration
    {
        /// <inheritdoc />

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Tyrant
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(1, 2)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(1, 4)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(1, 5)");

            // Zombies
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(2, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(2, 2)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(2, 5)");

            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(3, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(3, 2)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(3, 5)");

            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(4, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(4, 2)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(4, 5)");

            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(5, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(5, 2)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(5, 5)");

            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(6, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(6, 2)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(6, 5)");

            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(7, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(7, 2)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(7, 5)");

            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(8, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(8, 2)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(8, 5)");

            // Licker
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(9, 2)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(9, 3)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(9, 5)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyEnemyAbility] ([EnemiesId], [EnemyAbilitiesId]) VALUES(NULL, NULL)");

        }

    }
}
