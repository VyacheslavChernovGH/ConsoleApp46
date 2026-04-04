using ConsoleApp46.Models;
using System;

namespace ConsoleApp46.Services
{
    public class BattleService
    {
        private LevelManager _levelManager;

        public BattleService(LevelManager levelManager)
        {
            _levelManager = levelManager;
        }

        /// <summary>
        /// Проводит битву между персонажем и врагом. В процессе битвы персонаж и враг наносят друг другу урон, и это продолжается до тех пор, пока у одного из них не закончится здоровье.
        /// По окончании битвы, если персонаж побеждает, он получает случайное количество монет, иначе выводится сообщение о поражении.
        /// </summary>
        /// <param name="hero">Персонаж, участвующий в битве.</param>
        /// <param name="map">Массив, представляющий карту игры.</param>
        public void StartBattle(Person hero, char[,] map)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Person enemy = new Person(_levelManager.levelWorld * 10);
            while (enemy.HP > 0 && hero.HP > 0)
            {
                Console.WriteLine("Для битвы нажмите Q");
                Console.WriteLine($"Твои HP:{hero.HP}");
                Console.WriteLine($"Вражеские HP:{enemy.HP}");
                Console.WriteLine($"Твоя текущая сила = {hero.Strength}");
                ConsoleKey key;
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Q:
                        Console.WriteLine();
                        Random rnd = new Random();
                        int shot = rnd.Next(10);
                        enemy.HP -= shot + hero.Strength;
                        Console.WriteLine($"Урон врага:{shot}");
                        int shot1 = rnd.Next(10);
                        hero.HP -= shot1 + _levelManager.levelWorld * 5;
                        Console.WriteLine($"Твой урон:{shot1}");

                        if (enemy.HP < hero.HP)
                        {
                            hero.Coin += rnd.Next(100);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Поражение");
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Проводит битву между персонажем и гоблином.
        /// </summary>
        /// <param name="hero">Персонаж, участвующий в битве.</param>
        /// <param name="map">Массив, представляющий карту игры.</param>
        public void StartGoblinBattle(Person hero, char[,] map)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Person enemy = new Person(_levelManager.levelWorld * 100);
            while (enemy.HP > 0 && hero.HP > 0)
            {
                Console.WriteLine("Для битвы нажмите Q");
                Console.WriteLine($"Твои HP:{hero.HP}");
                Console.WriteLine($"Вражеские HP:{enemy.HP}");
                Console.WriteLine($"Твоя текущая сила = {hero.Strength}");
                ConsoleKey key;
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Q:
                        Console.WriteLine();
                        Random rnd = new Random();
                        int shot = rnd.Next(10);
                        enemy.HP -= shot + hero.Strength;
                        Console.WriteLine($"Урон врага:{shot}");
                        int shot1 = rnd.Next(10);
                        hero.HP -= shot1 + _levelManager.levelWorld * 5;
                        Console.WriteLine($"Твой урон:{shot1}");

                        if (enemy.HP < hero.HP)
                        {
                            hero.HP += 20;
                            hero.Coin += 200;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Поражение");
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Проводит битву между персонажем и ведьмой.
        /// </summary>
        /// <param name="hero">Персонаж, участвующий в битве.</param>
        /// <param name="map">Массив, представляющий карту игры.</param>
        public void StartWitchBattle(Person hero, char[,] map)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Person enemy = new Person(_levelManager.levelWorld * 20);
            while (enemy.HP > 0 && hero.HP > 0)
            {
                Console.WriteLine("Для битвы нажмите Q");
                Console.WriteLine($"Твои HP:{hero.HP}");
                Console.WriteLine($"Вражеские HP:{enemy.HP}");
                Console.WriteLine($"Твоя текущая сила = {hero.Strength}");
                ConsoleKey key;
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Q:
                        Console.WriteLine();
                        Random rnd = new Random();
                        int shot = rnd.Next(10);
                        enemy.HP -= shot + hero.Strength;
                        Console.WriteLine($"Урон врага:{shot}");
                        int shot1 = rnd.Next(10);
                        hero.HP -= shot1 + _levelManager.levelWorld * 5;
                        Console.WriteLine($"Твой урон:{shot1}");

                        if (enemy.HP < hero.HP)
                        {
                            hero.Coin += rnd.Next(200);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Поражение");
                        }
                        break;
                }
            }
        }
    }
}