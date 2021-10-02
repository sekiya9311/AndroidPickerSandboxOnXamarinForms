using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AndroidPickerSandbox
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _selectedIndex = -1;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (_selectedIndex == value) return;
                _selectedIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public string SelectedItem => Items.ElementAtOrDefault(SelectedIndex) ?? "";
        
        private List<string> _items = new();
        public List<string> Items
        {
            get => _items;
            set
            {
                if (_items.SequenceEqual(value)) return;
                _items = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            Items = Enumerable.Range(0, 10).Select(i => i.ToString()).ToList();
            SelectedIndex = -1;
        }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}