using DockingAdapterMVVM;
using Microsoft.Win32;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DockingManagerMVVM
{
    public class ViewModel : NotificationObject
    {
        private ObservableCollection<IDockElement> documents;

        public ObservableCollection<IDockElement> Documents
        {
            get { return documents; }
            set { documents = value; }
        }

        private ObservableCollection<Workspace> workspaces;

        public ObservableCollection<Workspace> Workspaces
        {
            get { return workspaces; }
            set { workspaces = value; }
        }

        private Document activeDocument;

        public Document ActiveDocument
        {
            get { return activeDocument; }
            set { activeDocument = value; RaisePropertyChanged("ActiveDocument"); }
        }

        private PropertiesViewModel propertiesViewModel;

        public PropertiesViewModel PropertiesViewModel
        {
            get { return propertiesViewModel; }
            set { propertiesViewModel = value; }
        }

        private DocumentsViewModel documentsViewModel;

        public DocumentsViewModel DocumentsViewModel
        {
            get { return documentsViewModel; }
            set { documentsViewModel = value; }
        }


        public ViewModel()
        {
            Workspaces = new ObservableCollection<Workspace>();

            string exepath = Assembly.GetExecutingAssembly().Location;

            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                Workspaces.Add(new Document() { Path = Path.GetDirectoryName(exepath) + @"\Samples\Sample 1.txt", Header = "Sample 1.txt" });
                Workspaces.Add(new Document() { Header = "Sample 2.txt", Path = Path.GetDirectoryName(exepath) + @"\Samples\Sample 2.txt" });
                Workspaces.Add(new Document() { Header = "Sample 3.txt", Path = Path.GetDirectoryName(exepath) + @"\Samples\Sample 3.txt" });
            }

            PropertiesViewModel = new DockingManagerMVVM.PropertiesViewModel() { ViewModel = this };
            DocumentsViewModel = new DockingManagerMVVM.DocumentsViewModel() { ViewModel = this };

            Workspaces.Add(DocumentsViewModel);
            Workspaces.Add(PropertiesViewModel);
        }

        private void OpenDocument()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt";
            if (dialog.ShowDialog().Value)
            {
                Document document = new Document() { Path = dialog.FileName, Header = dialog.SafeFileName };
                Workspaces.Add(document);
                ActiveDocument = document;
                DocumentsViewModel.RaiseDocumentsPropertyChanged();
            }
        }

        private void Exit()
        {
            Application.Current.MainWindow.Close();
        }

        private DelegateCommand<object> openDocumentCommand;

        public DelegateCommand<object> OpenDocumentCommand
        {
            get
            {
                if (openDocumentCommand == null)
                {
                    openDocumentCommand = new DelegateCommand<object>(param => OpenDocument());
                }
                return openDocumentCommand;
            }
        }

        private DelegateCommand<object> closeCommand;

        public DelegateCommand<object> CloseCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new DelegateCommand<object>(param => Exit());
                }
                return closeCommand;
            }
        }
    }
}
