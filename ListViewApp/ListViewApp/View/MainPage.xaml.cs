using System.Linq;
using Windows.UI.Xaml.Controls;
using ListViewApp.Model;
using ListViewApp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ListViewApp.View
{
    /// <inheritdoc cref="Page" />
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        private NotebookViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
        }

        private NotebookViewModel ViewModel => _viewModel ?? (_viewModel = DataContext as NotebookViewModel);

        /// <summary>
        ///     When on a note clicked, select the notebook to which it belongs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel?.Notebooks.ToList().ForEach(notebook =>
            {
                if (notebook.Notes.Contains(e.ClickedItem as Note))
                    ViewModel.SelectedNotebook = notebook;
            });
        }
    }
}