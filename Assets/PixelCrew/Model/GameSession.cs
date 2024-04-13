﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        public PlayerData Data 
        {
            get => _data;
            set => _data = value;
        }

        private void Awake()
        {
            if (IsSessionExit())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
            }
        }

        private bool IsSessionExit()
        {
            var sessions = FindObjectsOfType<GameSession>();
            foreach(var gameSession in sessions)
            {
                if (gameSession != this)
                    return true;
            }
            return false;
        }
    }
}
