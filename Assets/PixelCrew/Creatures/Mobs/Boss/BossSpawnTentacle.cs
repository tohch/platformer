using PixelCrew.Components.GoBased;
using PixelCrew.Creatures.Mobs.Boss.Tentacles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Creatures.Mobs.Boss
{
    public class BossSpawnTentacle : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var tentacle = FindObjectsOfType<TentacleAI>();
            var spawner = animator.GetComponent<LineProjectileSpawner>();
            if (tentacle.Length < spawner.BurstCount)
                spawner.LaunchProjectiles();
        }
    }
}
