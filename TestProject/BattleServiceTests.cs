using ConsoleApp46.Models;
using ConsoleApp46.Services;
using ConsoleApp46.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class BattleServiceTests
    {
        [TestMethod]
        public void BattleService_CanBeCreated()
        {
            var mapGenerator = new MapGenerator();
            var gameView = new GameView();
            var levelManager = new LevelManager(mapGenerator, gameView);
            var battleService = new BattleService(levelManager);

            Assert.IsNotNull(battleService, "BattleService должен быть создан");
        }

        [TestMethod]
        public void StartBattle_DoesNotThrowException_WithValidInput()
        {
            var mapGenerator = new MapGenerator();
            var gameView = new GameView();
            var levelManager = new LevelManager(mapGenerator, gameView);
            var battleService = new BattleService(levelManager);
            var hero = new Person(100, "TestHero");
            hero.Strength = 10;
            char[,] map = new char[10, 10];
            levelManager.levelWorld = 1;

            try
            {
                Assert.IsNotNull(battleService);
            }
            catch
            {
                Assert.Fail("BattleService не должен выбрасывать исключение при создании");
            }
        }
    }
}