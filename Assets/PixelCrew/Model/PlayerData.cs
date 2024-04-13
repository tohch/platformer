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
        public int Coins { get => _coins; set => _coins = value; }
        public int Hp { get => _hp; set => _hp = value; }
        public bool IsArmed { get => _isArmed; set => _isArmed = value; }

        private int _coins;
        private int _hp;
        private bool _isArmed;

        public PlayerData() { }
        public PlayerData(int coins, int hp, bool isArmed)
        {
            Coins = coins;
            Hp = hp;
            IsArmed = isArmed;
        }

        public PlayerData Clone()
        {
            return new PlayerData(_coins, _hp, _isArmed);
        }

        

    }
}
