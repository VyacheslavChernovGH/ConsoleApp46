using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp46.Models;

namespace ConsoleApp46.Views
{
    public class GameView
    {
        /// <summary>
        /// Отображает игровую карту в консоли, используя символы для различных объектов на карте (например, игрока, препятствий, монстров и т. д.).
        /// </summary>
        /// <param name="map">Двумерный массив символов, представляющий игровую карту.</param>
        public void DisplayMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == '0')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(map[i, j] + " ");
                        Console.ResetColor();
                    }
                    else if (map[i, j] == (char)1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("E ");
                        Console.ResetColor();
                    }
                    else if (map[i, j] == (char)3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("H ");
                        Console.ResetColor();
                    }
                    else if (map[i, j] == '%')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("G ");
                        Console.ResetColor();
                    }
                    else if (map[i, j] == '♀')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("W ");
                        Console.ResetColor();
                    }
                    else if (map[i, j] == (char)19)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("F ");
                        Console.ResetColor();
                    }
                    else if (map[i, j] == (char)0177)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("# ");
                        Console.ResetColor();
                    }
                    else if (map[i, j] == (char)2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("@ ");
                        Console.ResetColor();
                    }
                    else if (map[i, j] == '?')
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("? ");
                        Console.ResetColor();
                    }
                    else if (map[i, j] == 'T')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("T ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(map[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Выводит информацию о персонаже в консоль, включая имя, текущее здоровье, максимальное здоровье, количество монет и уровень мира.
        /// </summary>
        /// <param name="hero">Персонаж, информацию о котором нужно вывести.</param>
        /// <param name="levelWorld">Текущий уровень мира.</param>
        public void DisplayCharacter(Person hero, int levelWorld)
        {
            Console.WriteLine($"Имя героя = {hero.NamePerson}");
            Console.WriteLine($"Здоровье = {hero.HP}");
            Console.WriteLine($"MAX Здоровье = {hero.MaxHP}");
            Console.WriteLine($"Денег = {hero.Coin}");
            Console.WriteLine($"Уровень мира = {levelWorld}");
        }
    }
}