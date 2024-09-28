using PixelCrew.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelCrew.Model.Models
{
    public class PerksModel : IDisposable
    {
        private readonly PlayerData _data;
        public PerksModel(PlayerData data)
        {
            _data = data;
        }

        public void Dispose()
        {
        }
    }
}
