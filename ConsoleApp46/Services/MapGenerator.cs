using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46.Services
{
    public class MapGenerator
    {
        private static Random _random = new Random();
        public int levelWorld = 1;

        /// <summary>
        /// Генерирует случайную игровую карту, заполняя переданный двумерный массив символами, представляющими различные объекты на карте (например, игрока, препятствия, монстров и т. д.).
        /// </summary>
        /// <param name="map">Двумерный массив символов, представляющий игровую карту, в который будет записана сгенерированная карта.</param>
        public void GenerateArray(char[,] map)
        {
            Random rnd = new Random();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    int count = rnd.Next(100);

                    map[i, j] = '.';
                    if (count < 2)
                    {
                        map[i, j] = (char)1;
                    }
                    if (count >= 98)
                    {
                        map[i, j] = (char)3;
                    }
                    if (count >= 30 && count < 33)
                    {
                        map[i, j] = '?';
                    }
                    if (count >= 33 && count < 35)
                    {
                        map[i, j] = '%';
                    }
                    if (count >= 35 && count < 37)
                    {
                        map[i, j] = '♀';
                    }
                    if (count >= 5 && count < 30)
                    {
                        int X = i;
                        int Y = j;
                        for (int t = 0; t < 10; t++)
                        {
                            if (X < map.GetLength(0) && Y < map.GetLength(1))
                            {
                                map[X, Y] = (char)0177;
                            }
                            X++;
                            Y++;
                            if (X > map.GetLength(0) - 1 || Y > map.GetLength(1) - 1)
                                break;
                        }
                    }
                    if (count >= 80 && count < 85)
                    {
                        map[i, j] = 'T';
                    }
                }
            }

            if (levelWorld > 1)
            {
                int forgeRow = map.GetLength(0) / 4;
                int forgeCol = map.GetLength(1) / 2;

                if (map[forgeRow, forgeCol] != (char)0177 && map[forgeRow, forgeCol] != 'T')
                {
                    map[forgeRow, forgeCol] = (char)19;
                }
                else
                {
                    bool placed = false;
                    for (int offset = 1; offset < 5; offset++)
                    {
                        if (forgeRow + offset < map.GetLength(0) &&
                            map[forgeRow + offset, forgeCol] != (char)0177 &&
                            map[forgeRow + offset, forgeCol] != 'T')
                        {
                            map[forgeRow + offset, forgeCol] = (char)19;
                            placed = true;
                            break;
                        }
                        if (forgeRow - offset >= 0 &&
                            map[forgeRow - offset, forgeCol] != (char)0177 &&
                            map[forgeRow - offset, forgeCol] != 'T')
                        {
                            map[forgeRow - offset, forgeCol] = (char)19;
                            placed = true;
                            break;
                        }
                        if (forgeCol + offset < map.GetLength(1) &&
                            map[forgeRow, forgeCol + offset] != (char)0177 &&
                            map[forgeRow, forgeCol + offset] != 'T')
                        {
                            map[forgeRow, forgeCol + offset] = (char)19;
                            placed = true;
                            break;
                        }
                        if (forgeCol - offset >= 0 &&
                            map[forgeRow, forgeCol - offset] != (char)0177 &&
                            map[forgeRow, forgeCol - offset] != 'T')
                        {
                            map[forgeRow, forgeCol - offset] = (char)19;
                            placed = true;
                            break;
                        }
                    }

                    if (!placed)
                    {
                        for (int i = 0; i < map.GetLength(0); i++)
                        {
                            for (int j = 0; j < map.GetLength(1); j++)
                            {
                                if (map[i, j] == '.')
                                {
                                    map[i, j] = (char)19;
                                    placed = true;
                                    break;
                                }
                            }
                            if (placed) break;
                        }
                    }
                }
            }
        }
    }
}