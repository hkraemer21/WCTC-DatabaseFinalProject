using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Players
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Players] ON");
            migrationBuilder.Sql("INSERT INTO [dbo].[Players] ([Id], [Name], [Health], [RoomId], [EquippedId]) VALUES (1, N'Leon Kennedy', 100, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Players] ([Id], [Name], [Health], [RoomId], [EquippedId]) VALUES (2, N'Claire Redfield', 100, NULL, NULL)");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Players] OFF");


            // Enemies
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Enemies] ON");
            migrationBuilder.Sql("INSERT INTO [dbo].[Enemies] ([Id], [Name], [Health], [AttackPower], [EnemyType], [RoomId], [StunThreshold]) VALUES (1, N'Mr. X', 1000, 25, N'Tyrant', NULL, 50)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Enemies] ([Id], [Name], [Health], [AttackPower], [EnemyType], [RoomId], [StunThreshold]) VALUES (2, N'Police Zombie', 100, 10, N'Zombie', NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Enemies] ([Id], [Name], [Health], [AttackPower], [EnemyType], [RoomId], [StunThreshold]) VALUES (3, N'Vest Zombie', 100, 10, N'Zombie', NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Enemies] ([Id], [Name], [Health], [AttackPower], [EnemyType], [RoomId], [StunThreshold]) VALUES (4, N'Lady Zombie', 100, 10, N'Zombie', NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Enemies] ([Id], [Name], [Health], [AttackPower], [EnemyType], [RoomId], [StunThreshold]) VALUES (5, N'Dude Zombie', 100, 10, N'Zombie', NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Enemies] ([Id], [Name], [Health], [AttackPower], [EnemyType], [RoomId], [StunThreshold]) VALUES (6, N'Police Zombie2', 100, 10, N'Zombie', NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Enemies] ([Id], [Name], [Health], [AttackPower], [EnemyType], [RoomId], [StunThreshold]) VALUES (7, N'RedShirt Zombie', 100, 10, N'Zombie', NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Enemies] ([Id], [Name], [Health], [AttackPower], [EnemyType], [RoomId], [StunThreshold]) VALUES (8, N'BlueShirt Zombie', 100, 10, N'Zombie', NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO [dbo].[Enemies] ([Id], [Name], [Health], [AttackPower], [EnemyType], [RoomId], [StunThreshold]) VALUES (9, N'Hall Licker', 100, 15, N'Licker', NULL, NULL)");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Enemies] OFF");


            // Items
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[Items] ON");
            migrationBuilder.Sql("INSERT INTO[dbo].[Items] ([Id], [Name], [Description], [Type], [RoomId], [InventoryId], [Healing], [WasUsed], [Damage], [DamageOverTime]) VALUES(1, N'Matilda', N'9mm handgun, Non-Standard Issue', N'Weapon', NULL, NULL, NULL, NULL, 25, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Items] ([Id], [Name], [Description], [Type], [RoomId], [InventoryId], [Healing], [WasUsed], [Damage], [DamageOverTime]) VALUES(2, N'SLS-60', N'Small 9mm handgun', N'Weapon', NULL, NULL, NULL, NULL, 25, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Items] ([Id], [Name], [Description], [Type], [RoomId], [InventoryId], [Healing], [WasUsed], [Damage], [DamageOverTime]) VALUES(3, N'W-870', N'20 gauge Shotgun', N'Weapon', NULL, NULL, NULL, NULL, 35, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Items] ([Id], [Name], [Description], [Type], [RoomId], [InventoryId], [Healing], [WasUsed], [Damage], [DamageOverTime]) VALUES(4, N'GM 79', N'Grenade Launcher', N'Weapon', NULL, NULL, NULL, NULL, 30, 5)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Items] ([Id], [Name], [Description], [Type], [RoomId], [InventoryId], [Healing], [WasUsed], [Damage], [DamageOverTime]) VALUES(5, N'Hand Grenade', N'Hand Grenade', N'Weapon', NULL, NULL, NULL, NULL, 50, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Items] ([Id], [Name], [Description], [Type], [RoomId], [InventoryId], [Healing], [WasUsed], [Damage], [DamageOverTime]) VALUES(6, N'First Aid Spray', N'Spray to heal injury', N'FirstAid', NULL, NULL, 70, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Items] ([Id], [Name], [Description], [Type], [RoomId], [InventoryId], [Healing], [WasUsed], [Damage], [DamageOverTime]) VALUES(7, N'Green Herb', N'An herb to boost your health', N'FirstAid', NULL, NULL, 50, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Items] ([Id], [Name], [Description], [Type], [RoomId], [InventoryId], [Healing], [WasUsed], [Damage], [DamageOverTime]) VALUES(8, N'Officer''s Notebook', N'A notebook covered in blood containing drawings of a Lion Statue, a Unicorn Statue, and a Maiden Statue with their respective codes.', N'KeyItem', NULL, NULL, NULL, 0, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Items] ([Id], [Name], [Description], [Type], [RoomId], [InventoryId], [Healing], [WasUsed], [Damage], [DamageOverTime]) VALUES(9, N'Armory Keycard', N'Keycard to open Armory locker', N'KeyItem', NULL, NULL, NULL, 0, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Items] ([Id], [Name], [Description], [Type], [RoomId], [InventoryId], [Healing], [WasUsed], [Damage], [DamageOverTime]) VALUES(10, N'Lion Medallion', N'Medallion with a Lion depicted', N'KeyItem', NULL, NULL, NULL, 0, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Items] ([Id], [Name], [Description], [Type], [RoomId], [InventoryId], [Healing], [WasUsed], [Damage], [DamageOverTime]) VALUES(11, N'Unicorn Medallion', N'Medallion with a unicorn depicted', N'KeyItem', NULL, NULL, NULL, 0, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Items] ([Id], [Name], [Description], [Type], [RoomId], [InventoryId], [Healing], [WasUsed], [Damage], [DamageOverTime]) VALUES(12, N'Maiden Medallion', N'Medallion with a Maiden depicted', N'KeyItem', NULL, NULL, NULL, 0, NULL, NULL)");
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[Items] OFF");


            // PlayerAbilities
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[PlayerAbilities] ON");
            migrationBuilder.Sql("INSERT INTO[dbo].[PlayerAbilities]([Id], [Name], [Description], [Damage], [Type]) VALUES(1, N'Stab', N'A swift knife move', 20, N'Stab')");
            migrationBuilder.Sql("INSERT INTO[dbo].[PlayerAbilities] ([Id], [Name], [Description], [Damage], [Type]) VALUES(2, N'Roundhouse Kick', N'A roundhouse kick', 20, N'Roundhouse')");
            migrationBuilder.Sql("INSERT INTO[dbo].[PlayerAbilities] ([Id], [Name], [Description], [Damage], [Type]) VALUES(3, N'Knee Kick', N'A kick to the knee', 20, N'KneeKick')");
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[PlayerAbilities] OFF");


            // EnemyAbilities
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[EnemyAbilities] ON");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyAbilities]([Id], [Name], [Description], [Damage], [Type]) VALUES(1, N'Fall', N'A faceplant to the ground', 20, N'Fall')");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyAbilities] ([Id], [Name], [Description], [Damage], [Type]) VALUES(2, N'Grapple', N'A grapple', 0, N'Grapple')");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyAbilities] ([Id], [Name], [Description], [Damage], [Type]) VALUES(3, N'Tongue Whip', N'A powerful flick of the tongue', 20, N'TongueWhip')");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyAbilities] ([Id], [Name], [Description], [Damage], [Type]) VALUES(4, N'Take a Knee', N'Taking a break', 0, N'TakeAKnee')");
            migrationBuilder.Sql("INSERT INTO[dbo].[EnemyAbilities] ([Id], [Name], [Description], [Damage], [Type]) VALUES(5, N'Finisher', N'An insta-kill', 2000, N'Finisher')");
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[EnemyAbilities] OFF");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DELETE FROM Players");
            migrationBuilder.Sql("DELETE FROM Enemies");
            migrationBuilder.Sql("DELETE FROM Items");
            migrationBuilder.Sql("DELETE FROM PlayerAbilities");
            migrationBuilder.Sql("DELETE FROM EnemyAbilities");

        }

    }
}
