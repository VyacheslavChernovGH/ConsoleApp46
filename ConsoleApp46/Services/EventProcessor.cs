using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp46.Models;

namespace ConsoleApp46.Services
{
    internal class EventProcessor
    {
        private BattleService _battleService;
        private LevelManager _levelManager;

        public EventProcessor(BattleService battleService, LevelManager levelManager)
        {
            _battleService = battleService;
            _levelManager = levelManager;
        }

        /// <summary>
        /// Обрабатывает событие, возникающее при перемещении персонажа по игровой карте. Метод определяет тип события, которое происходит при перемещении на определенную клетку, и выполняет соответствующие действия в зависимости от этого типа события.
        /// </summary>
        /// <param name="hero">Персонаж, выполняющий перемещение.</param>
        /// <param name="map">Массив, представляющий карту игры.</param>
        /// <param name="deltaRow">Смещение по вертикали при перемещении (отрицательное значение для движения вверх, положительное для движения вниз).</param>
        /// <param name="deltaCol">Смещение по горизонтали при перемещении (отрицательное значение для движения влево, положительное для движения вправо).</param>
        /// <returns>
        /// Значение true, если перемещение возможно и было успешно выполнено.
        /// Значение false, если перемещение невозможно из-за препятствия или других ограничений.
        /// </returns>
        public bool ProcessInteraction(Person hero, char[,] map, int deltaRow = 0, int deltaCol = 0)
        {
            char key = map[((map.GetLength(0) - 1) / 2) + deltaRow, ((map.GetLength(1) - 1) / 2) + deltaCol];

            switch (key)
            {
                case (char)1:
                    _battleService.StartBattle(hero, map);
                    _levelManager.ApplyPassiveAbilities(hero, map);
                    break;
                case '%':
                    _battleService.StartGoblinBattle(hero, map);
                    _levelManager.ApplyPassiveAbilities(hero, map);
                    break;
                case '♀':
                    _battleService.StartWitchBattle(hero, map);
                    _levelManager.ApplyPassiveAbilities(hero, map);
                    break;
                case (char)3:
                    _levelManager.ProcessHeart(hero, map);
                    break;
                case '0':
                    _levelManager.levelWorld++;
                    _levelManager.ProcessPortal(hero, map);
                    break;
                case (char)19:
                    _levelManager.ProcessForge(hero);
                    break;
                case '?':
                    _levelManager.UpgradePassiveAbilities(hero, map);
                    break;
                case (char)0177:
                    return false;
                case 'T':
                    return false;
                default:
                    break;
            }
            return true;
        }
    }
}