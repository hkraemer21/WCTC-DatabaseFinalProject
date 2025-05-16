using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectLibrary.Migrations
{
    /// <inheritdoc />
    public partial class SeedRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[Rooms] ON");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(1, N'Main Hall', N'Main Hall of the RPD, complete with a grand staircase and massive statue of a woman holding a flag.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(2, N'Main Hall 2F Landing', N'Second floor landing of the Main Hall with a Lion statue perched just at the top of the stairs.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(3, N'West Office', N'A large office room filled with several desks and a banner reading -Welcome Leon- hanging from the ceiling.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(4, N'West Hallway', N'An L-shaped hallway with a door to the Safety Deposit Room and a staircase up to the second floor.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(5, N'Safety Deposit Room', N'A room filled with lockers opened by a keypad console. At the back of the room is an armory locker opened only with a keycard.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(6, N'West 2F Landing', N'Second floor landing with one locked door and more stairs leading up to another level.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(7, N'West 3F Landing', N'Third floor landing with a massive hold in the wall leading to a small office.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(8, N'West 3F Small Office', N'Small office with a gaping hole in one wall and a door in another', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(9, N'West 3F Hallway', N'An L-shaped hallway with windows lining the walls and a door around the bend.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(10, N'West Storage Room', N'A storage room filled with old paintings and shelves. At the far end is a massive statue of a Maiden.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(11, N'Library 2F Catwalk', N'A catwalk above the library with shelves lining the walls and a staircase to the first level of the Library', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(12, N'Library', N'A room lined with shelves upon shelves filled with books and a staircase to the Library 2F Catwalk and two separate doors.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(13, N'Lounge', N'A small room with a white marble floor and white walls. A massive statue of a unicorn sits proudly to the left of the door.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(14, N'East Office', N'A large office with several desks, one of which containing a keycard on its surface. A door sits in the wall directly opposite.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(15, N'East Hallway', N'A hallway with items blocking what looks to be a bend in it.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(16, N'East Hallway Cont.', N'A hallway with items blocking what appears to be a bend. A window in the wall reveals the Watchman''s Room.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(17, N'Watchman''s Room', N'Small room with two desks,  a journal perched on the surface of one. A police officer severed in half rests on the ground beside a metal door shutter.', 0, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Rooms] ([Id], [Name], [Description], [IsLocked], [NorthId], [SouthId], [EastId], [WestId], [UpId], [DownId]) VALUES(18, N'Safe Room', N'A small, octagonal room with a desk containing a typewriter and some ink ribbons. To the right is an elevator leading to the depths of the Raccoon City Police Department.', 1, NULL, NULL, NULL, NULL, NULL, NULL)");
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[Rooms] OFF");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Rooms");
        }

    }
}
