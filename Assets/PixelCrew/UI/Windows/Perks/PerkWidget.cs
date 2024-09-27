using PixelCrew.UI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.UI.Windows.Perks
{
    public class PerkWidget : MonoBehaviour, IItemRenderer<string>
    {
        [SerializeField] private GameObject _icon;
        [SerializeField] private GameObject _isLocked;
        [SerializeField] private GameObject _isUsed;
        [SerializeField] private GameObject _isSelected;
        public void SetData(string data, int index)
        {
            throw new NotImplementedException();
        }

        public void OnSelected()
        {

        }
    }
}
