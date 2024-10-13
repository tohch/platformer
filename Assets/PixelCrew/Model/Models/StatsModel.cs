﻿using PixelCrew.Model.Data;
using PixelCrew.Model.Data.Properties;
using PixelCrew.Model.Definitions;
using PixelCrew.Model.Definitions.Player;
using PixelCrew.Utils.Disposables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelCrew.Model.Models
{
    public class StatsModel : IDisposable
    {
        private readonly PlayerData _data;

        public event Action OnChanged;

        public readonly ObservableProperty<StatId> InterfaceSelectedStat = new ObservableProperty<StatId>();

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        public StatsModel(PlayerData data)
        {
            _data = data;
            _trash.Retain(InterfaceSelectedStat.Subscribe((x, y) => OnChanged?.Invoke()));
        }

        public IDisposable Subscribe(Action call) 
        {
            OnChanged += call;
            return new ActionDisposable(() => OnChanged -= call);
        }

        public void LevelUp(StatId id)
        {
            var def = DefsFacade.I.Player.GetStat(id);
            var nextLevel = GetCurrentLevel(id) + 1;
            if (def.Levels.Length >= nextLevel) return;
            var price = def.Levels[nextLevel].Price;
            if (!_data.Inventory.IsEnough(price)) return;

            _data.Inventory.Remove(price.ItemId, price.Count);
            _data.Levels.LevelUp(id);

            OnChanged?.Invoke();
        }

        public float GetCurrentValue(StatId id)
        {
            return GetCurrentLevelDef(id).Value;
        }

        public StatLevelDef GetCurrentLevelDef(StatId id)
        {
            var def = DefsFacade.I.Player.GetStat(id);
            return def.Levels[GetCurrentLevel(id)];
        }

        public int GetCurrentLevel(StatId id) => _data.Levels.GetLevel(id);

        public void Dispose()
        {
            _trash.Dispose();
        }
    }
}
