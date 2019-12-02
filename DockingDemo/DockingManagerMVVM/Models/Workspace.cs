using DockingAdapterMVVM;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockingManagerMVVM
{
    public class Workspace : NotificationObject, IDockElement
    {
        private string header;

        [ReadOnly(true)]
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }

        private DockState state;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public DockState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
    }
}
