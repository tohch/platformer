using PixelCrew.Model;
using PixelCrew.Model.Definitions.Player;
using UnityEngine;

namespace PixelCrew.Components.WeaponModifier
{
    public class CriticalDamageChanceCalculator : MonoBehaviour
    {
        public static int GetCriticalDamageChance()
        {
            var session = FindObjectOfType<GameSession>();
            var deltaChance = (int)session.StatsModel.GetValue(StatId.CriticalDamageChance);
            var range = (int)session.StatsModel.GetLevelDef(StatId.CriticalDamageChance).Value * 2;
            var random = Random.Range(1, range);
            return (random < deltaChance) ? 2 : 1;
        }
    }
}
