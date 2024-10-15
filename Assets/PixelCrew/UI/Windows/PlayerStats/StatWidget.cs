﻿using PixelCrew.Model;
using PixelCrew.Model.Definitions;
using PixelCrew.Model.Definitions.Localization;
using PixelCrew.Model.Definitions.Player;
using PixelCrew.UI.Widgets;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrew.UI.Windows.PlayerStats
{
    public class StatWidget : MonoBehaviour, IItemRenderer<StatDef>
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Text _name;
        [SerializeField] private Text _currentValue;
        [SerializeField] private Text _increaseValue;
        [SerializeField] private ProgressBarWidget _progress;
        [SerializeField] private GameObject _selector;

        private GameSession _session;
        private StatDef _data;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            UpdateView();
        }

        public void SetData(StatDef data, int index)
        {
            _data = data;
            if (_session != null)
                UpdateView();
        }

        private void UpdateView()
        {
            var statsModel = _session.StatsModel;
            
            _icon.sprite = _data.Icon;
            _name.text = LocalizationManager.I.Localize(_data.Name);
            _currentValue.text = _session.StatsModel.GetValue(_data.ID).ToString(CultureInfo.InvariantCulture);

            var currentLevel = statsModel.GetCurrentLevel(_data.ID);
            var nextLevel = currentLevel + 1;
            var increaseValue = statsModel.GetValue(_data.ID, nextLevel);
            _increaseValue.text = increaseValue.ToString(CultureInfo.InvariantCulture);
            _increaseValue.gameObject.SetActive(increaseValue > 0);

            var maxLevels = DefsFacade.I.Player.GetStat(_data.ID).Levels.Length;
            _progress.SetProgress(currentLevel / (float)maxLevels);

            _selector.SetActive(statsModel.InterfaceSelectedStat.Value == _data.ID);
        }

        public void OnSelect()
        {
            _session.StatsModel.InterfaceSelectedStat.Value = _data.ID;
        }
    }
}
