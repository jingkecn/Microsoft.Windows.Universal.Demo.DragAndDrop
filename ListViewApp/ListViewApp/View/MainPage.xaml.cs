using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ListViewApp.Model;
using ListViewApp.ViewModel;
using Microsoft.Toolkit.Uwp.UI.Controls;

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
        ///     When a note is dragged entering the notebook.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotebookExpander_OnDragEnter(object sender, DragEventArgs e)
        {
            Debug.WriteLine($"\n{sender}.{sender.GetHashCode()}.OnDragEnter");
            if (!((sender as Expander)?.DataContext is Notebook notebook))
                return;
            Debug.WriteLine($"\ttarget = {notebook}");
            if (!(e.Data.Properties["SourceNotebook"] is Notebook sourceNotebook))
                return;
            if (notebook == sourceNotebook)
                return;
            e.AcceptedOperation = DataPackageOperation.Move;
        }

        /// <summary>
        ///     When a note is dragged ouver the notebook.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotebookExpander_OnDragOver(object sender, DragEventArgs e)
        {
            Debug.WriteLine($"\n{sender}.{sender.GetHashCode()}.OnDragOver");
            if (!((sender as Expander)?.DataContext is Notebook notebook))
                return;
            Debug.WriteLine($"\ttarget = {notebook}");
            if (!(e.Data.Properties["SourceNotebook"] is Notebook sourceNotebook))
                return;
            if (notebook == sourceNotebook)
                return;
            e.AcceptedOperation = DataPackageOperation.Move;
        }

        /// <summary>
        ///     When a note is dropped onto the notebook.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotebookExpander_OnDrop(object sender, DragEventArgs e)
        {
            Debug.WriteLine($"\n{sender}.{sender.GetHashCode()}.OnDrop");
            if (!((sender as Expander)?.DataContext is Notebook notebook))
                return;
            Debug.WriteLine($"\ttarget = {notebook}");
            if (!(e.Data.Properties["Notes"] is IList<object> items))
                return;
            items.Cast<Note>().ToList().ForEach(note => notebook.Notes.Add(note));
        }

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

        /// <summary>
        ///     When on a note drag start dragging, package the necessary data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoteListView_OnDragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            Debug.WriteLine($"\n{sender}.{sender.GetHashCode()}.OnDragItemsStarting");
            if (!((sender as ListView)?.DataContext is Notebook notebook))
                return;
            Debug.WriteLine($"\tsource = {notebook}");
            e.Data.Properties.Add("SourceNotebook", notebook);
            e.Data.Properties.Add("Notes", e.Items);
        }

        /// <summary>
        ///     When on a note drag completed, remove it from the note list in the notebook.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NoteListView_OnDragItemsCompleted(ListViewBase sender, DragItemsCompletedEventArgs args)
        {
            Debug.WriteLine($"\n{sender}.{sender.GetHashCode()}.OnDragItemsCompleted");
            if (args.DropResult != DataPackageOperation.Move)
                return;
            if (!((sender as ListView)?.DataContext is Notebook notebook))
                return;
            Debug.WriteLine($"\tsource = {notebook}");
            args.Items?.Cast<Note>().ToList().ForEach(note => notebook.Notes.Remove(note));
        }
    }
}