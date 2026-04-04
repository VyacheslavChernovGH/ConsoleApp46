using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46.Services
{
    internal static class GameConstants
    {
        public const int MapSize = 25;

        public const int StartMaxHP = 100;
        public const int StartHP = 100;
        public const int StartStrength = 0;
        public const int StartCoins = 0;

        public const int StartImmortalityDuration = 10;
        public const int StartCriticalBonus = 2;
        public const int StartLotteryBonus = 100;

        public const int StandardEnemyMultiplier = 10;
        public const int GoblinEnemyMultiplier = 100;
        public const int WitchEnemyMultiplier = 20;
        public const int DamageRandomMax = 10;
        public const int EnemyDamageBaseMultiplier = 5;

        public const int GoblinRewardHP = 20;
        public const int GoblinRewardCoins = 200;

        public const int HeartHPIncrease = 10;
 
        public const int PortalRewardCoins = 100;

        public const int ForgeCost = 250;
        public const int ForgeStrengthIncrease = 2;

        public const int ImmortalityThreshold = 10;
        public const int ImmortalityGrantHP = 10000;
        public const int CriticalChanceMin = 1;
        public const int CriticalChanceMax = 5;
        public const int LotteryChanceMin = 0;
        public const int LotteryChanceMax = 2;

        public const int LotteryUpgradeAmount = 10;
        public const int ImmortalityUpgradeAmount = 1;
        public const int CriticalUpgradeAmount = 1;
    }
}