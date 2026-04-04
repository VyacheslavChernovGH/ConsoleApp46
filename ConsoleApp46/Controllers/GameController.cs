using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp46.Models;
using ConsoleApp46.Services;
using ConsoleApp46.Views;

namespace ConsoleApp46.Controllers
{
    internal class GameController
    {
        private Person _player;
        private MapGenerator _mapGenerator;
        private GameView _gameView;
        private MovementHandler _movementHandler;
        private LevelManager _levelManager;
        private EventProcessor _eventProcessor;
        private char[,] _map;

        public GameController(Person player)
        {
            _player = player;
            _gameView = new GameView();
            _mapGenerator = new MapGenerator();
            _levelManager = new LevelManager(_mapGenerator, _gameView);
            _movementHandler = new MovementHandler(_gameView, _levelManager);
            BattleService _battleService = new BattleService(_levelManager);
            _eventProcessor = new EventProcessor(_battleService, _levelManager);
            _map = new char[GameConstants.MapSize, GameConstants.MapSize];
        }

        public void Run()
        {
            _mapGenerator.GenerateArray(_map);
            _gameView.DisplayMap(_map);
            _gameView.DisplayCharacter(_player, _levelManager.levelWorld);

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (_eventProcessor.ProcessInteraction(_player, _map, -1, 0))
                        {
                            Console.Clear();
                            _movementHandler.MoveUp(_map);
                            _gameView.DisplayCharacter(_player, _levelManager.levelWorld);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (_eventProcessor.ProcessInteraction(_player, _map, 1, 0))
                        {
                            Console.Clear();
                            _movementHandler.MoveDown(_map);
                            _gameView.DisplayCharacter(_player, _levelManager.levelWorld);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (_eventProcessor.ProcessInteraction(_player, _map, 0, -1))
                        {
                            Console.Clear();
                            _movementHandler.MoveLeft(_map);
                            _gameView.DisplayCharacter(_player, _levelManager.levelWorld);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (_eventProcessor.ProcessInteraction(_player, _map, 0, 1))
                        {
                            Console.Clear();
                            _movementHandler.MoveRight(_map);
                            _gameView.DisplayCharacter(_player, _levelManager.levelWorld);
                        }
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}