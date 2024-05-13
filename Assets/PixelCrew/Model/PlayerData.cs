using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelCrew.Model
{
    [Serializable]
    public class PlayerData
    {
        public int Coins;
        public int Hp;
        public bool IsArmed;
        public int AmountSwords;

        public PlayerData() { }
        public PlayerData(int coins, int hp, bool isArmed, int amountSwords)
        {
            Coins = coins;
            Hp = hp;
            IsArmed = isArmed;
            AmountSwords = amountSwords;
        }

        public PlayerData Clone()
        {
            return new PlayerData(Coins, Hp, IsArmed, AmountSwords);
        }

        

    }
}
