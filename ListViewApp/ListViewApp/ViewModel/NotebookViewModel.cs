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
        private Notebook _selectedNotebook;

        public NotebookViewModel()
        {
            Notebook.Default.Notes.Add(Note.MyScriptNoteDefault);
            Notebooks.Add(Notebook.Default);
            Notebook.MyNotebookEn.Notes.Add(Note.ChinaNoteEn);
            Notebook.MyNotebookEn.Notes.Add(Note.FranceNoteEn);
            Notebooks.Add(Notebook.MyNotebookEn);
            Notebook.MyNotebookZh.Notes.Add(Note.ChinaNoteZh);
            Notebook.MyNotebookZh.Notes.Add(Note.FranceNoteZh);
            Notebooks.Add(Notebook.MyNotebookZh);
        }

        public ObservableCollection<Notebook> Notebooks { get; } = new ObservableCollection<Notebook>();

        public Notebook SelectedNotebook
        {
            get => _selectedNotebook ?? (_selectedNotebook = Notebooks.Count == 0 ? null : Notebooks.First());
            set
            {
                _selectedNotebook = value;
                OnPropertyChanged(nameof(SelectedNotebook));
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