﻿using PixelCrew.Model;
using PixelCrew.Model.Definitions;
using PixelCrew.Model.Definitions.Player;
using PixelCrew.UI.Widgets;
using PixelCrew.Utils.Disposables;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrew.UI.Windows.PlayerStats
{
    public class PlayerStatsWindow : AnimatedWindow
    {
        [SerializeField] private Transform _statsContainer;
        [SerializeField] private StatWidget _prefab;

        [SerializeField] private Button _upgradeButton;
        [SerializeField] private ItemWidget _price;

        private DataGroup<StatDef, StatWidget> _dataGroup;

        private GameSession _session;
        private readonly CompositeDisposable _trash = new CompositeDisposable();

        protected override void Start()
        {
            base.Start();

            _dataGroup = new DataGroup<StatDef, StatWidget>(_prefab, _statsContainer);

            _session = GameSession.Instance;

            _session.StatsModel.InterfaceSelectedStat.Value = DefsFacade.I.Player.Stats[0].ID;
            _trash.Retain(_session.StatsModel.Subscribe(OnStatsChanged));
            _trash.Retain(_upgradeButton.onClick.Subscribe(OnUpgrade));

            OnStatsChanged();
        }

        private void OnUpgrade()
        {
            var selected = _session.StatsModel.InterfaceSelectedStat.Value;
            _session.StatsModel.LevelUp(selected);
        }

        private void OnStatsChanged()
        {
            var stats = DefsFacade.I.Player.Stats;
            _dataGroup.SetData(stats);

            var selected = _session.StatsModel.InterfaceSelectedStat.Value;
            var nextLevel = _session.StatsModel.GetCurrentLevel(selected) + 1;
            var def = _session.StatsModel.GetLevelDef(selected, nextLevel);
            _price.SetData(def.Price);

            _price.gameObject.SetActive(def.Price.Count != 0);
            _upgradeButton.gameObject.SetActive(def.Price.Count != 0);
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
