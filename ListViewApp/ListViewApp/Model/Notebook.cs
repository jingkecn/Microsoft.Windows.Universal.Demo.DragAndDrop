using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ListViewApp.Annotations;

namespace ListViewApp.Model
{
    public partial class Notebook
    {
        private Note _selectedNote;
        private static int Count { get; set; }

        public string Language { get; set; } = "en";
        public string Title { get; set; } = $"My Notebook - {++Count}";

        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();

        public Note SelectedNote
        {
            get => _selectedNote ?? (_selectedNote = Notes.Count == 0 ? null : Notes.First());
            set
            {
                _selectedNote = value;
                OnPropertyChanged(nameof(SelectedNote));
            }
        }

        public string Information => $"Title = {Title},\tLanguage = {Language}";

        public override string ToString()
        {
            return $"{base.ToString()}.{GetHashCode()}:\t{Information}";
        }
    }

    public partial class Notebook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class Notebook
    {
        public static readonly Notebook Default = new Notebook
        {
            Title = "Default Notebook"
        };

        public static readonly Notebook MyNotebookEn = new Notebook
        {
            Title = "My Notebook",
            Language = "en"
        };

        public static readonly Notebook MyNotebookZh = new Notebook
        {
            Title = "我的筆記簿",
            Language = "zh"
        };
    }
}