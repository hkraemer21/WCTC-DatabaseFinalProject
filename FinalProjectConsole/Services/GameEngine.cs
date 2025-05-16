using ConsoleRpg.Helpers;
using FinalProject.Helpers;
using FinalProject.Menu;
using FinalProjectLibrary.Data;
using FinalProjectLibrary.Models.Abilities.EnemyAbilities;
using FinalProjectLibrary.Models.Abilities.PlayerAbilities;
using FinalProjectLibrary.Models.Characters.Enemy;
using FinalProjectLibrary.Models.Characters.Players;
using FinalProjectLibrary.Models.Rooms;

namespace FinalProject.Services
{
    public class GameEngine 
    {

        private readonly GameContext _context;
        private readonly MenuManager _menuManager;
        private readonly AdminMenu _adminMenu;
        private readonly OutputManager _outputManager;
        private readonly PlayerFactory _playerFactory;
        private readonly RoomFactory _roomFactory;
        private Boolean _isRunning = true;

        private Player _player;

        public GameEngine(GameContext context, MenuManager menuManager, OutputManager outputManager, AdminMenu adminMenu, 
            PlayerFactory playerFactory, RoomFactory roomFactory)
        {
            _menuManager = menuManager;
            _outputManager = outputManager;
            _context = context;
            _adminMenu = adminMenu;
            _playerFactory = playerFactory;
            _roomFactory = roomFactory;
        }

        public void Run()
        {
            if (_menuManager.ShowMainMenu())
            {
                SetupGame();
            }

            Thread.Sleep(500);
        }

        private void MainMenu()
        {
            _outputManager.Clear();
            _outputManager.WriteLine("Welcome to the Raccoon City Police Station!", ConsoleColor.Yellow);
            _outputManager.WriteLine("1. Enter the RPD", ConsoleColor.Cyan);
            _outputManager.WriteLine("2. Admin Menu", ConsoleColor.Cyan);
            _outputManager.WriteLine("3. Exit", ConsoleColor.Cyan);
            _outputManager.Display();
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    GameLoop();
                    break;
                case "2":
                    _adminMenu.Run();
                    MainMenu();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    _outputManager.WriteLine("Invalid selection. Please choose 1, 2, or 3.", ConsoleColor.Red);
                    MainMenu();
                    break;

            }
        }

        private void SetupGame()
        {
            _outputManager.Clear();
            _outputManager.WriteLine($"Which Character would you like to play as?", ConsoleColor.Cyan);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            var players = _context.Players.ToList();
            foreach (var player in players)
            {
                _outputManager.WriteLine($"{player.Id}. {player.Name}", ConsoleColor.Cyan);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            }

            _outputManager.Display();

            var input = Console.ReadLine();
            if (int.TryParse(input, out int playerId))
            {
                _player = _context.Players.FirstOrDefault(p => p.Id == playerId);
                if (_player == null)
                {
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                    _outputManager.WriteLine("Invalid character selection. Please try again.", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                    SetupGame();
                    return;
                }
            }
            else
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                SetupGame();
                return;
            }
            _outputManager.WriteLine($"\n{_player.Name} has entered the game.", ConsoleColor.Green);
            _outputManager.Display();

            _playerFactory.InitializePlayer(_player);
            _roomFactory.InitializeRooms();
            _outputManager.WriteLine($"\n--------------------------\n", ConsoleColor.Magenta);
            Thread.Sleep(1000);

            MainMenu();
        }


        private void GameLoop()
        {

            while (_isRunning)
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Magenta);
                _outputManager.Display();
                _player.Room.GetRoomDescription(_player);
                _player.Room.GetAdjacentRooms();
                _outputManager.WriteLine($"--------------------------", ConsoleColor.Magenta);
                _outputManager.WriteLine("Choose an action: a, n, s, e, w, u, d, l, i", ConsoleColor.Gray);
                _outputManager.WriteLine("(0 to exit game)", ConsoleColor.Cyan);

                _outputManager.Display();

                var input = Console.ReadLine();

                switch (input)
                {
                    case "a":
                        Attack();
                        break;
                    case "n":
                        Move("n");
                        break;
                    case "s":
                        Move("s");
                        break;
                    case "e":
                        Move("e");
                        break;
                    case "w":
                        Move("w");
                        break;
                    case "u":
                        Move("u");
                        break;
                    case "d":
                        Move("d");
                        break;
                    case "l":
                        _player.Room.LootRoom(_player);
                        break;
                    case "i":
                        _player.Room.InteractWithRoom(_player);
                        break;
                    case "0":
                        _outputManager.WriteLine("Exiting game...", ConsoleColor.Red);
                        _outputManager.Display();
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                if (_player.Room.Name == "Safe Room")
                {
                    _player.Room.GetRoomDescription(_player);
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Magenta);
                    _outputManager.WriteLine($"\n{_player.Name} uses the ink ribbon in the typewriter on the desk. " +
                        $"Then, they enter the elevator and head down into the darkness.\n", ConsoleColor.Green);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
                    _isRunning = false;
                }

            }
        }

        private void Attack()
        {
            if (_player.Room.Enemies.Count > 0 && _player.Room.Enemies != null)
            {

                _outputManager.WriteLine($"\nWhich enemy do you want to attack?", ConsoleColor.Red);
                _outputManager.Display();

                foreach (var enemy in _player.Room.Enemies)
                {
                    
                    _outputManager.WriteLine($"{enemy.Id}: {enemy.Name}", ConsoleColor.Red);
                    
                }
                _outputManager.Display();

                var input = Console.ReadLine();
                if (int.TryParse(input, out int enemyId))
                {

                    var enemy = _player.Room.Enemies.FirstOrDefault(e => e.Id == enemyId);
                    if (enemy != null)
                    {

                        while (_player.Health > 0 && enemy.Health > 0)
                        {
                            _outputManager.WriteLine($"\nWhich attack do you want to do?");
                            _outputManager.WriteLine($"0. Basic");
                            _outputManager.Display();

                            var ability = _player.PlayerAbilities.ToList();
                            foreach (var attack in ability)
                            {
                                _outputManager.WriteLine($"{attack.Id}: {attack.Name}");
                            }

                            _outputManager.Display();
                            var attackInput = Console.ReadLine();
                            if (attackInput != null)
                            {
                                if (int.TryParse(attackInput, out int attackId))
                                {
                                    if (attackId == 0)
                                    {
                                        _player.Attack(enemy);
                                    }
                                    else
                                    {
                                        var abilityToUse = _player.PlayerAbilities.FirstOrDefault(a => a.Id == attackId);
                                        if (abilityToUse != null)
                                        {
                                            _player.UseAbility(abilityToUse, enemy);
                                        }
                                        else
                                        {
                                            _outputManager.WriteLine("\nInvalid ability selection. Please try again.\n", ConsoleColor.Red);
                                        }
                                    }
                                }
                                else
                                {
                                    _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                                }

                            }

                            if (enemy.EnemyAbilities != null && enemy.EnemyAbilities.Any())
                            {
                                var random = new Random();
                                int choice = random.Next(1, 3);
                                if (choice == 1)
                                {
                                    enemy.Attack(_player);
                                }
                                else
                                {
                                    var abilitiesList = enemy.EnemyAbilities.ToList();
                                    int index = random.Next(abilitiesList.Count);
                                    var chosenAbility = abilitiesList[index];

                                    if (chosenAbility is not Finisher)
                                    {
                                        if (enemy is Zombie zombie)
                                        {

                                            if (chosenAbility is Fall)
                                            {
                                                zombie.UseAbility(chosenAbility, _player);
                                            }
                                            else if (chosenAbility is Grapple)
                                            {
                                                zombie.UseAbility(chosenAbility, _player);

                                                var stabAbility = _player.PlayerAbilities.FirstOrDefault(a => a is Stab);
                                                if (stabAbility != null)
                                                {                                              
                                                    _player.UseAbility(stabAbility, enemy);
                                                }
                                                else
                                                {
                                                    var finisherAbility = abilitiesList.FirstOrDefault(a => a is Finisher);
                                                    if (finisherAbility != null)
                                                    {
                                                        zombie.UseAbility(finisherAbility, _player);
                                                    }
                                                    
                                                }


                                            }

                                        } else if (enemy is Licker licker)
                                        {

                                            if (chosenAbility is TongueWhip)
                                            {
                                                licker.UseAbility(chosenAbility, _player);
                                            }
                                            else if (chosenAbility is Grapple)
                                            {
                                                licker.UseAbility(chosenAbility, _player);

                                                var stabAbility = _player.PlayerAbilities.FirstOrDefault(a => a is Stab);
                                                if (stabAbility != null)
                                                {
                                                    _player.UseAbility(stabAbility, enemy);
                                                }
                                                else
                                                {
                                                    var finisherAbility = abilitiesList.FirstOrDefault(a => a is Finisher);
                                                    licker.UseAbility(finisherAbility, _player);
                                                    if (finisherAbility != null)
                                                    {
                                                        licker.UseAbility(finisherAbility, _player);
                                                    }
                                                }


                                            }

                                        } else if (enemy is Tyrant tyrant)
                                        {
                                            tyrant.CantKill();

                                            if (chosenAbility is TakeAKnee)
                                            {
                                                tyrant.UseAbility(chosenAbility, _player);
                                                tyrant.UnkillableReset();
                                            }
                                            else if (chosenAbility is Grapple)
                                            {
                                                tyrant.UseAbility(chosenAbility, _player);

                                                var stabAbility = _player.PlayerAbilities.FirstOrDefault(a => a is Stab);
                                                if (stabAbility != null)
                                                {
                                                    _player.UseAbility(stabAbility, enemy);
                                                }
                                                else
                                                {
                                                    var finisherAbility = abilitiesList.FirstOrDefault(a => a is Finisher);
                                                    tyrant.UseAbility(finisherAbility, _player);
                                                    if (finisherAbility != null)
                                                    {
                                                        tyrant.UseAbility(finisherAbility, _player);
                                                    }
                                                }


                                            }

                                        }
                                    } 
                                    else
                                    {
                                        index = random.Next(abilitiesList.Count);
                                        chosenAbility = abilitiesList[index];

                                        if (enemy is Zombie zombie)
                                        {

                                            if (chosenAbility is Fall)
                                            {
                                                zombie.UseAbility(chosenAbility, _player);
                                            }
                                            else if (chosenAbility is Grapple)
                                            {

                                            }

                                        }
                                    }

                                }
                            }
                            else
                            {
                                enemy.Attack(_player);
                            }

                        }

                    }
                    else
                    {
                        _outputManager.WriteLine("\nInvalid enemy selection. Please try again.\n", ConsoleColor.Red);
                        _outputManager.Display();
                    }
                }
                else
                {
                    _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                    _outputManager.Display();
                }

            }
            else
            {
                _outputManager.WriteLine("\nThere are no enemies to attack.\n", ConsoleColor.Red);
            }

        }

        private Boolean Move(string direction)
        {
            Room nextRoom = _player.Room.GetNextRoom(direction);
            if (nextRoom != null)
            {
                if (nextRoom.IsLocked)
                {
                    _outputManager.WriteLine("\nThree circular divets made for medallions adorn the base of the Lady Statue. " +
                        "There must be something that fits inside.\n", ConsoleColor.Red);
                    return false;
                }
                else
                {
                    _player.Room.RemoveCharacter(_player);
                    _player.Room = nextRoom;
                    _player.Room.AddCharacter(_player);
                    _player.Room.Enter(_player);
                    return true;
                }
            }
            else
            {
                _outputManager.WriteLine("\nYou can't go that way.\n", ConsoleColor.Red);
                return false;
            }

        }



    }
}
