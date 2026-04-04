using ConsoleApp46.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    /// <summary>
    /// Тесты для класса MapGenerator
    /// </summary>
    [TestClass]
    public class MapGeneratorTests
    {
        private MapGenerator? _mapGenerator;

        [TestInitialize]
        public void Setup()
        {
            _mapGenerator = new MapGenerator();
        }

        /// <summary>
        /// Тест метода GenerateArray: проверка корректности размера карты
        /// </summary>
        [TestMethod]
        public void GenerateArray_MapSizeIsCorrect()
        {
            Assert.IsNotNull(_mapGenerator, "MapGenerator не должен быть null");
            char[,] map = new char[25, 25];

            _mapGenerator.GenerateArray(map);

            Assert.AreEqual(25, map.GetLength(0), "Количество строк карты должно быть 25");
            Assert.AreEqual(25, map.GetLength(1), "Количество столбцов карты должно быть 25");
        }

        /// <summary>
        /// Тест метода GenerateArray: проверка допустимости всех символов на карте
        /// </summary>
        [TestMethod]
        public void GenerateArray_AllSymbolsAreValid()
        {
            Assert.IsNotNull(_mapGenerator, "MapGenerator не должен быть null");
            char[,] map = new char[25, 25];

            char[] validSymbols = { '.', (char)1, (char)3, '?', '%', '♀', (char)19, (char)0177, 'T', '0', (char)2 };

            _mapGenerator.GenerateArray(map);

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    bool isValid = Array.IndexOf(validSymbols, map[i, j]) >= 0;
                    Assert.IsTrue(isValid, $"Недопустимый символ '{map[i, j]}' на позиции ({i},{j})");
                }
            }
        }

        /// <summary>
        /// Тест метода GenerateArray: проверка появления кузницы на 2 уровне
        /// </summary>
        [TestMethod]
        public void GenerateArray_ForgePlacedOnSecondLevel()
        {
            Assert.IsNotNull(_mapGenerator, "MapGenerator не должен быть null");

            _mapGenerator.levelWorld = 2;
            char[,] map = new char[25, 25];
            bool forgeFound = false;

            _mapGenerator.GenerateArray(map);

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == (char)19)
                    {
                        forgeFound = true;
                        break;
                    }
                }
            }
            Assert.IsTrue(forgeFound, "На 2 уровне мира на карте должна быть размещена кузница (символ (char)19)");
        }
    }
}