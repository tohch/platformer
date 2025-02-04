﻿using PixelCrew.Components.GoBased;
using PixelCrew.Creatures.Mobs.Boss;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassNextStageState : StateMachineBehaviour
{
    [ColorUsage(true, true)][SerializeField] 
    private Color _stageColor;
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var spawner = animator.GetComponent<CircularProjectileSpawner>();
        spawner.Stage++;

        var changeLight = animator.GetComponent<ChangeLightComponent>();
        changeLight.SetColor(_stageColor);
    }

}
