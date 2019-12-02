using DockingAdapterMVVM;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockingManagerMVVM
{
    public class PaneViewModel : Workspace
    {
        public PaneViewModel()
        {
            State = DockState.Dock;
        }

        private ViewModel viewModel;

        public ViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }

    }
}
