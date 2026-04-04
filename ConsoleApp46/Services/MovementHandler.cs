using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp46.Views;

namespace ConsoleApp46.Services
{
    internal class MovementHandler
    {
        private GameView _gameView;
        private LevelManager _levelManager;

        public MovementHandler(GameView gameView, LevelManager levelManager)
        {
            _gameView = gameView;
            _levelManager = levelManager;
        }

        /// <summary>
        /// Производит перемещение игровой карты вверх, сдвигая содержимое всех строк на одну клетку вверх, и обновляет отображение карты в консоли.
        /// </summary>
        /// <param name="map">Двумерный массив символов, представляющий игровую карту.</param>
        public void MoveUp(char[,] map)
        {
            char[] temp = new char[map.GetLength(0)];

            for (int i = (map.GetLength(0) - 1); i >= 0; i--)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == (map.GetLength(0) - 1))
                    {
                        temp[j] = map[i, j];
                    }
                    else if (i == 0)
                    {
                        map[i, j] = temp[j];
                    }
                    if (i != 0)
                    {
                        map[i, j] = map[i - 1, j];
                    }
                    if (i == (map.GetLength(0) - 1) / 2 && j == (map.GetLength(1) - 1) / 2)
                    {
                        map[i, j] = (char)2;
                    }
                    if (i == (map.GetLength(0) - 1) / 2 && j == (map.GetLength(1) - 1) / 2)
                    {
                        map[i + 1, j] = '.';
                    }
                }
            }

            _gameView.DisplayMap(map);
            _levelManager.CheckWin(map);
        }

        /// <summary>
        /// Производит перемещение игровой карты вниз, сдвигая содержимое всех строк на одну клетку вниз, и обновляет отображение карты в консоли.
        /// </summary>
        /// <param name="map">Двумерный массив символов, представляющий игровую карту.</param>
        public void MoveDown(char[,] map)
        {
            char[] temp = new char[map.GetLength(0)];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        temp[j] = map[i, j];
                    }
                    else if (i == (map.GetLength(0) - 1))
                    {
                        map[i, j] = temp[j];
                    }
                    if (i != (map.GetLength(0) - 1))
                    {
                        map[i, j] = map[i + 1, j];
                    }

                    if (i == (map.GetLength(0) - 1) / 2 && j == (map.GetLength(1) - 1) / 2)
                    {
                        map[i, j] = (char)2;
                    }
                    if (i == (map.GetLength(0) - 1) / 2 && j == (map.GetLength(1) - 1) / 2)
                    {
                        map[i - 1, j] = '.';
                    }
                }
            }
            _gameView.DisplayMap(map);
            _levelManager.CheckWin(map);
        }

        /// <summary>
        /// Производит перемещение игровой карты влево, сдвигая содержимое всех строк на одну клетку влево, и обновляет отображение карты в консоли.
        /// </summary>
        /// <param name="map">Двумерный массив символов, представляющий игровую карту.</param>
        public void MoveLeft(char[,] map)
        {
            char[] temp = new char[map.GetLength(1)];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = (map.GetLength(1) - 1); j >= 0; j--)
                {
                    if (j == (map.GetLength(1) - 1))
                    {
                        temp[i] = map[i, j];
                    }
                    else if (j == 0)
                    {
                        map[i, j] = temp[i];
                    }
                    if (j != 0)
                    {
                        map[i, j] = map[i, j - 1];
                    }
                    if (i == (map.GetLength(0) - 1) / 2 && j == (map.GetLength(1) - 1) / 2)
                    {
                        map[i, j] = (char)2;
                    }
                    if (i == (map.GetLength(0) - 1) / 2 && j == (map.GetLength(1) - 1) / 2)
                    {
                        map[i, j + 1] = '.';
                    }
                }
            }
            _gameView.DisplayMap(map);
            _levelManager.CheckWin(map);
        }

        /// <summary>
        /// Производит перемещение игровой карты вправо, сдвигая содержимое всех строк на одну клетку вправо, и обновляет отображение карты в консоли.
        /// </summary>
        /// <param name="map">Двумерный массив символов, представляющий игровую карту.</param>
        public void MoveRight(char[,] map)
        {
            char[] temp = new char[map.GetLength(1)];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        temp[i] = map[i, j];
                    }
                    else if (j == (map.GetLength(1) - 1))
                    {
                        map[i, j] = temp[i];
                    }
                    if (j != (map.GetLength(1) - 1))
                    {
                        map[i, j] = map[i, j + 1];
                    }
                    if (i == (map.GetLength(0) - 1) / 2 && j == (map.GetLength(1) - 1) / 2)
                    {
                        map[i, j] = (char)2;
                    }
                    if (i == (map.GetLength(0) - 1) / 2 && j == (map.GetLength(1) - 1) / 2)
                    {
                        map[i, j - 1] = '.';
                    }
                }
            }

            _gameView.DisplayMap(map);
            _levelManager.CheckWin(map);
        }
    }
}