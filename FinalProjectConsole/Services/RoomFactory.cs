using FinalProjectLibrary.Data;

namespace FinalProject.Services
{
    public class RoomFactory
    {
        private readonly GameContext _context;
        public RoomFactory(GameContext context)
        {
            _context = context;

        }
        public void InitializeRooms()
        {

            // grab the rooms from the database
            var mainHall = _context.Rooms.FirstOrDefault(r => r.Id == 1);
            var mainHall2F = _context.Rooms.FirstOrDefault(r => r.Id == 2);
            var westOffice = _context.Rooms.FirstOrDefault(r => r.Id == 3);
            var westHallway = _context.Rooms.FirstOrDefault(r => r.Id == 4);
            var safetyDepo = _context.Rooms.FirstOrDefault(r => r.Id == 5);
            var west2fLanding = _context.Rooms.FirstOrDefault(r => r.Id == 6);
            var west3fLanding = _context.Rooms.FirstOrDefault(r => r.Id == 7);
            var west3fOffice = _context.Rooms.FirstOrDefault(r => r.Id == 8);
            var west3fHall = _context.Rooms.FirstOrDefault(r => r.Id == 9);
            var westStorage = _context.Rooms.FirstOrDefault(r => r.Id == 10);
            var libraryCatwalk = _context.Rooms.FirstOrDefault(r => r.Id == 11);
            var library = _context.Rooms.FirstOrDefault(r => r.Id == 12);
            var lounge = _context.Rooms.FirstOrDefault(r => r.Id == 13);
            var eastOffice = _context.Rooms.FirstOrDefault(r => r.Id == 14);
            var eastHallway = _context.Rooms.FirstOrDefault(r => r.Id == 15);
            var eastHallwayCont = _context.Rooms.FirstOrDefault(r => r.Id == 16);
            var watchmansRoom = _context.Rooms.FirstOrDefault(r => r.Id == 17);
            var safeRoom = _context.Rooms.FirstOrDefault(r => r.Id == 18);

            // set the room properties
            mainHall.Items = _context.Items.Where(i => i.RoomId == mainHall.Id).ToList();
            mainHall.Enemies = _context.Enemies.Where(e => e.RoomId == mainHall.Id).ToList();

            mainHall2F.Items = _context.Items.Where(i => i.RoomId == mainHall2F.Id).ToList();
            mainHall2F.Enemies = _context.Enemies.Where(e => e.RoomId == mainHall2F.Id).ToList();

            westOffice.Items = _context.Items.Where(i => i.RoomId == westOffice.Id).ToList();
            westOffice.Enemies = _context.Enemies.Where(e => e.RoomId == westOffice.Id).ToList();

            westHallway.Items = _context.Items.Where(i => i.RoomId == westHallway.Id).ToList();
            westHallway.Enemies = _context.Enemies.Where(e => e.RoomId == westHallway.Id).ToList();

            safetyDepo.Items = _context.Items.Where(i => i.RoomId == safetyDepo.Id).ToList();
            safetyDepo.Enemies = _context.Enemies.Where(e => e.RoomId == safetyDepo.Id).ToList();

            west2fLanding.Items = _context.Items.Where(i => i.RoomId == west2fLanding.Id).ToList();
            west2fLanding.Enemies = _context.Enemies.Where(e => e.RoomId == west2fLanding.Id).ToList();

            west3fLanding.Items = _context.Items.Where(i => i.RoomId == west3fLanding.Id).ToList();
            west3fLanding.Enemies = _context.Enemies.Where(e => e.RoomId == west3fLanding.Id).ToList();

            west3fOffice.Items = _context.Items.Where(i => i.RoomId == west3fOffice.Id).ToList();
            west3fOffice.Enemies = _context.Enemies.Where(e => e.RoomId == west3fOffice.Id).ToList();

            west3fHall.Items = _context.Items.Where(i => i.RoomId == west3fHall.Id).ToList();
            west3fHall.Enemies = _context.Enemies.Where(e => e.RoomId == west3fHall.Id).ToList();

            westStorage.Items = _context.Items.Where(i => i.RoomId == westStorage.Id).ToList();
            westStorage.Enemies = _context.Enemies.Where(e => e.RoomId == westStorage.Id).ToList();

            libraryCatwalk.Items = _context.Items.Where(i => i.RoomId == libraryCatwalk.Id).ToList();
            libraryCatwalk.Enemies = _context.Enemies.Where(e => e.RoomId == libraryCatwalk.Id).ToList();

            library.Items = _context.Items.Where(i => i.RoomId == library.Id).ToList();
            library.Enemies = _context.Enemies.Where(e => e.RoomId == library.Id).ToList();

            lounge.Items = _context.Items.Where(i => i.RoomId == lounge.Id).ToList();
            lounge.Enemies = _context.Enemies.Where(e => e.RoomId == lounge.Id).ToList();

            eastOffice.Items = _context.Items.Where(i => i.RoomId == eastOffice.Id).ToList();
            eastOffice.Enemies = _context.Enemies.Where(e => e.RoomId == eastOffice.Id).ToList();

            eastHallway.Items = _context.Items.Where(i => i.RoomId == eastHallway.Id).ToList();
            eastHallway.Enemies = _context.Enemies.Where(e => e.RoomId == eastHallway.Id).ToList();

            eastHallwayCont.Items = _context.Items.Where(i => i.RoomId == eastHallwayCont.Id).ToList();
            eastHallwayCont.Enemies = _context.Enemies.Where(e => e.RoomId == eastHallwayCont.Id).ToList();

            watchmansRoom.Items = _context.Items.Where(i => i.RoomId == watchmansRoom.Id).ToList();
            watchmansRoom.Enemies = _context.Enemies.Where(e => e.RoomId == watchmansRoom.Id).ToList();

            safeRoom.Items = _context.Items.Where(i => i.RoomId == safeRoom.Id).ToList();
            safeRoom.Enemies = _context.Enemies.Where(e => e.RoomId == safeRoom.Id).ToList();

            

        }

    }
}
