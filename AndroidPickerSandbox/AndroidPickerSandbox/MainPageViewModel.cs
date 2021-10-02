using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AndroidPickerSandbox
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _selectedItem = "";
        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem == value) return;
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

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
            SelectedItem = Items.First();
        }
        
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}