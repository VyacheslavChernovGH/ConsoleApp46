using ConsoleApp46.Controllers;
using ConsoleApp46.Models;
using System;
using System.Text;

namespace ConsoleApp46
{
    class Program
    {
        /// <summary>
        /// Основной метод программы. Запускает игру и обрабатывает действия игрока в игре. 
        /// Выводит сообщения в консоль, запрашивает ввод игрока и обрабатывает его, основываясь на нажатых клавишах.
        /// </summary>
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("Введите никнейм:");
            Person player = new Person(name: Console.ReadLine());
            GameController gameController = new GameController(player);
            gameController.Run();
        }
    }
}