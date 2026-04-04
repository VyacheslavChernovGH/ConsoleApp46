using ConsoleApp46.Models;
using ConsoleApp46.Services;
using ConsoleApp46.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    /// <summary>
    /// Тесты для класса LevelManager
    /// </summary>
    [TestClass]
    public class LevelManagerTests
    {
        private MapGenerator? _mapGenerator;
        private GameView? _gameView;
        private LevelManager? _levelManager;
        private Person? _hero;

        [TestInitialize]
        public void Setup()
        {
            _mapGenerator = new MapGenerator();
            _gameView = new GameView();
            _levelManager = new LevelManager(_mapGenerator, _gameView);
            _hero = new Person(100, "TestHero");
        }
                          
        /// <summary>
        /// Тест метода CheckWin: карта без врагов и порталов
        /// </summary>
        [TestMethod]
        public void CheckWin_NoEnemiesOrPortals_ReturnsTrue()
        {
            Assert.IsNotNull(_levelManager, "LevelManager не должен быть null");

            char[,] map = new char[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    map[i, j] = '.';
                }
            }

            bool result = _levelManager.CheckWin(map);

            Assert.IsTrue(result, "При отсутствии врагов и порталов метод должен вернуть true");
        }

        /// <summary>
        /// Тест метода CheckWin: наличие врага на карте
        /// </summary>
        [TestMethod]
        public void CheckWin_EnemyExists_ReturnsFalse()
        {
            Assert.IsNotNull(_levelManager, "LevelManager не должен быть null");

            char[,] map = new char[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    map[i, j] = '.';
                }
            }
            map[7, 7] = (char)1;

            bool result = _levelManager.CheckWin(map);

            Assert.IsFalse(result, "При наличии врага на карте метод должен вернуть false");
        }

        /// <summary>
        /// Тест метода CheckWin: наличие портала на карте
        /// </summary>
        [TestMethod]
        public void CheckWin_PortalExists_ReturnsFalse()
        {

            Assert.IsNotNull(_levelManager, "LevelManager не должен быть null");

            char[,] map = new char[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    map[i, j] = '.';
                }
            }
            map[7, 7] = '0'; 

            bool result = _levelManager.CheckWin(map);

            Assert.IsFalse(result, "При наличии портала на карте метод должен вернуть false");
        }
    }
}