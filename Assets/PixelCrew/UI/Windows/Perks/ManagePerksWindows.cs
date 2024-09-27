using PixelCrew.UI.Widgets;
using PixelCrew.Utils.Disposables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrew.UI.Windows.Perks
{
    public class ManagePerksWindows : AnimatedWindow
    {
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _useButton;
        [SerializeField] private ItemWidget _price;
        [SerializeField] private Text _info;
        [SerializeField] private Transform _perksContainer;

        private PredefinedDataGroup<string, PerkWidget> _dataGroup;
        private readonly CompositeDisposable _trash = new CompositeDisposable();

        protected override void Start()
        {
            base.Start();

            _dataGroup = new PredefinedDataGroup<string, PerkWidget>(_perksContainer);

        }
    }
}
