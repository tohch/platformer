using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelCrew.Model.Data.Properties
{
    public abstract class PersistentProperty<TPropertyType>
    {
        [NonSerialized] private TPropertyType _value;
        private TPropertyType _defaultValue;

        public PersistentProperty(TPropertyType defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public delegate void OnPropertyChanged(TPropertyType newValue, TPropertyType oldValue);
        public event OnPropertyChanged OnChanged;
        public TPropertyType Value
        {
            get => _value;
            set
            {
                var isEquals = _value.Equals(value);
                if (isEquals) return;

                var oldValue = _value;
                Write(value);
                _value = value;

                OnChanged?.Invoke(value, oldValue);
            }
        }
        protected void Init()
        {
            _value = Read(_defaultValue);
        }
        protected abstract void Write(TPropertyType value);
        protected abstract TPropertyType Read(TPropertyType defaultValue);
    }
}
