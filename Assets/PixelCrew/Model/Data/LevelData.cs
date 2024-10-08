using PixelCrew.Model.Definitions.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Model.Data
{
    [Serializable]
    public class LevelData
    {
        [SerializeField] private LevelProgress[] _progress;

        public int GetLevel(StatId id)
        {
            var progress = _progress.FirstOrDefault(x => x.Id == id);
            return progress?.Level ?? 0;
        }
    }

    [Serializable]
    public class LevelProgress
    {
        public StatId Id;
        public int Level;
    }
}
