using FinalProjectLibrary.Models.Abilities.EnemyAbilities;
using FinalProjectLibrary.Models.Abilities.PlayerAbilities;
using FinalProjectLibrary.Models.Characters.Enemy;
using FinalProjectLibrary.Models.Characters.Players;
using FinalProjectLibrary.Models.Equipments;
using FinalProjectLibrary.Models.Equipments.Items;
using FinalProjectLibrary.Models.Rooms;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectLibrary.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<EnemyAbility> EnemyAbilities { get; set; }
        public DbSet<PlayerAbility> PlayerAbilities { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Item> Items { get; set; }


        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<EnemyAbility>()
                .HasDiscriminator<string>("Type")
                .HasValue<Grapple>("Grapple")
                .HasValue<TongueWhip>("TongueWhip")
                .HasValue<Fall>("Fall")
                .HasValue<TakeAKnee>("TakeAKnee")
                .HasValue<Finisher>("Finisher");

            modelBuilder.Entity<PlayerAbility>()
                .HasDiscriminator<string>("Type")
                .HasValue<Stab>("Stab")
                .HasValue<KneeKick>("KneeKick")
                .HasValue<Roundhouse>("Roundhouse");

            modelBuilder.Entity<Enemy>()
                .HasDiscriminator<string>("EnemyType")
                .HasValue<Zombie> ("Zombie")
                .HasValue<Licker>("Licker")
                .HasValue<Tyrant>("Tyrant");

            modelBuilder.Entity<Room>()
                .HasMany(r => r.Players)
                .WithOne(c => c.Room)
                .HasForeignKey(c => c.RoomId);

            modelBuilder.Entity<Room>()
                .HasMany(r => r.Enemies)
                .WithOne(c => c.Room)
                .HasForeignKey(c => c.RoomId);

            modelBuilder.Entity<Room>()
                .HasMany(r => r.Items)
                .WithOne(i => i.Room)
                .HasForeignKey(i => i.RoomId);

            modelBuilder.Entity<Item>()
                .HasDiscriminator<string>("Type")
                .HasValue<Weapon>("Weapon")
                .HasValue<KeyItem>("KeyItem")
                .HasValue<FirstAid>("FirstAid");

            ConfigureInventory(modelBuilder);
            ConfigureRoomDirections(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public void ConfigureInventory(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Inventory)
                .WithOne(i => i.Player)
                .HasForeignKey<Inventory>(i => i.PlayerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Inventory>()
                .HasIndex(i => i.PlayerId)
                .IsUnique();

            modelBuilder.Entity<Inventory>()
                .HasMany(i => i.Items)
                .WithOne(it => it.Inventory)
                .HasForeignKey(it => it.InventoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Room)
                .WithMany(r => r.Items)
                .HasForeignKey(i => i.RoomId)
                .OnDelete(DeleteBehavior.SetNull);


        }

        private void ConfigureRoomDirections(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasOne(r => r.North)
                .WithMany()
                .HasForeignKey(r => r.NorthId);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.South)
                .WithMany()
                .HasForeignKey(r => r.SouthId);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.East)
                .WithMany()
                .HasForeignKey(r => r.EastId);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.West)
                .WithMany()
                .HasForeignKey(r => r.WestId);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Up)
                .WithMany()
                .HasForeignKey(r => r.UpId);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.Down)
                .WithMany()
                .HasForeignKey(r => r.DownId);
        }

    }
}
