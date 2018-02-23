using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ListViewApp.Annotations;
using ListViewApp.Model;

namespace ListViewApp.ViewModel
{
    public partial class NotebookViewModel
    {
        private Note _selectedNote;

        public NotebookViewModel()
        {
            Notes.Add(Note.ChinaNoteEn);
            Notes.Add(Note.ChinaNoteZh);
            Notes.Add(Note.FranceNoteEn);
            Notes.Add(Note.FranceNoteZh);
            Notes.Add(Note.MyScriptNoteDefault);
        }

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
    }

    public partial class NotebookViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}