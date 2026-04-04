using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp46.Models;
using ConsoleApp46.Views;

namespace ConsoleApp46.Services
{
    public class LevelManager
    {
        public int levelWorld = 1;
        private int _immortalityDuration = GameConstants.StartImmortalityDuration;
        private int _criticalBonus = GameConstants.StartCriticalBonus;
        private int _lotteryBonus = GameConstants.StartLotteryBonus;
        private Random _random = new Random();
        private MapGenerator _mapGenerator;
        private GameView _gameView;

        public LevelManager(MapGenerator mapGenerator, GameView gameView)
        {
            _mapGenerator = mapGenerator;
            _gameView = gameView;
        }

        /// <summary>
        /// Проверяет условия победы на карте.
        /// </summary>
        /// <param name="map">Массив, представляющий карту игры.</param>
        /// <returns>True, если все враги побеждены, иначе False.</returns>
        public bool CheckWin(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == (char)1 || map[i, j] == '0')
                    {
                        return false;
                    }
                }
            }

            map[10, 10] = '0';
            return true;
        }

        /// <summary>
        /// Увеличивает максимальное здоровье персонажа на 10 единиц и восстанавливает его текущее здоровье на 10% от нового максимального значения.
        /// </summary>
        /// <param name="hero">Персонаж, которому нужно увеличить здоровье.</param>
        /// <param name="map">Массив, представляющий карту игры.</param>
        public void ProcessHeart(Person hero, char[,] map)
        {
            Console.Clear();
            hero.MaxHP += GameConstants.HeartHPIncrease;
            hero.HP += hero.MaxHP / 10;
        }

        /// <summary>
        /// Перемещает персонажа на новый уровень, увеличивает количество монет персонажа на 100 и восстанавливает его здоровье до максимального значения.
        /// </summary>
        /// <param name="hero">Персонаж, который перемещается на новый уровень.</param>
        /// <param name="map">Массив, представляющий карту игры.</param>
        public void ProcessPortal(Person hero, char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == (char)3)
                    {
                        hero.Coin += GameConstants.PortalRewardCoins;
                    }
                }
            }
            hero.HP = hero.MaxHP;
            _mapGenerator.levelWorld = levelWorld;
            _mapGenerator.GenerateArray(map);
        }

        /// <summary>
        /// Позволяет персонажу улучшить свою силу за определенную стоимость. При успешном улучшении силы за счет расхода монет, сила персонажа увеличивается на 2 единицы.
        /// </summary>
        /// <param name="hero">Персонаж, который хочет улучшить свою силу.</param>
        public void ProcessForge(Person hero)
        {
            Console.WriteLine("Выберите действие");
            Console.WriteLine("1. Улучшить силу на 2");
            Console.WriteLine("Для выхода нажмите Enter");
            Console.WriteLine($"Оставшиеся деньги {hero.Coin}");
            Random rnd = new Random();
            int g1 = rnd.Next(100);

            if (g1 > 0 && g1 < 2)
            {
                hero.Coin += _lotteryBonus;
                Console.WriteLine($"Вы выиграли в лотерею {_lotteryBonus} монет!");
            }

            ConsoleKey key;
            bool upgraded = false;

            while (true)
            {
                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Enter)
                {
                    break;
                }

                if (key == ConsoleKey.NumPad1 || key == ConsoleKey.D1)
                {
                    if (hero.Coin >= 250)  
                    {
                        hero.Strength += 2;
                        hero.Coin -= 250;
                        Console.WriteLine($"Сила увеличена на 2, Текущая сила = {hero.Strength}");
                        Console.WriteLine($"Оставшиеся деньги {hero.Coin}");
                        upgraded = true;
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно денег!");
                        break; 
                    }
                }
            }

            if (upgraded)
            {

            }
        }

        /// <summary>
        /// Реализует пассивные способности персонажа во время игры. Этот метод может предоставлять различные бонусы, такие как временное бессмертие, увеличение критического урона и другие, в зависимости от случайных событий.
        /// </summary>
        /// <param name="hero">Персонаж, который получает бонусы от пассивных способностей.</param>
        /// <param name="map">Массив, представляющий карту игры.</param>
        public async void ApplyPassiveAbilities(Person hero, char[,] map)
        {
            if (hero.HP < GameConstants.ImmortalityThreshold)
            {
                hero.HP = GameConstants.ImmortalityGrantHP;
                await Task.Delay(TimeSpan.FromSeconds(_immortalityDuration));
                hero.HP = hero.HP - GameConstants.ImmortalityGrantHP;
            }
            Random rnd = new Random();
            int g = rnd.Next(100);
            if (g > 1 && g < 5) 
            {
                hero.Strength += _criticalBonus;
            }
        }

        /// <summary>
        /// Выполняет обработку специального события, случайным образом выбирая одно из трех возможных улучшений: увеличение выигрыша в лотерее, увеличение времени бессмертия или увеличение критического урона. 
        /// </summary>
        /// <param name="hero">Персонаж, чьи характеристики могут быть улучшены.</param>
        /// <param name="map">Двумерный массив символов, представляющий игровую карту (не используется в данном методе).</param>
        public void UpgradePassiveAbilities(Person hero, char[,] map)
        {
            ConsoleKey key;
            Random rnd = new Random();
            int f = rnd.Next(3);
            if (f < 1)
            {
                _lotteryBonus += GameConstants.LotteryUpgradeAmount;
                while ((key = Console.ReadKey().Key) != ConsoleKey.Enter)
                {
                    Console.WriteLine("Выигрыш в лотерее увеличился на 10");
                }
            }
            if (f > 0 && f < 2)
            {
                _immortalityDuration += GameConstants.ImmortalityUpgradeAmount;
                while ((key = Console.ReadKey().Key) != ConsoleKey.Enter)
                {
                    Console.WriteLine("Время бессмертия увеличилось на 1");
                }
            }
            if (f > 1)
            {
                _criticalBonus += GameConstants.CriticalUpgradeAmount;
                while ((key = Console.ReadKey().Key) != ConsoleKey.Enter)
                {
                    Console.WriteLine("Критический урон увеличился на 1");
                }
            }
        }
    }
}