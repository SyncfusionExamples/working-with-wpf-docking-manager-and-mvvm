using DockingAdapterMVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockingManagerMVVM
{
    public class Document : Workspace
    {
        private string path;

        [ReadOnly(true)]
        public string Path
        {
            get { return path; }
            set { path = value; RaisePropertyChanged("Path"); }
        }

        private string text;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text
        {
            get { return text; }
            set { text = value; RaisePropertyChanged("Text"); }
        }

        private int words;

        [ReadOnly(true)]
        public int Words
        {
            get { return words; }
            set { words = value; RaisePropertyChanged("Words"); }
        }

        public Document()
        {
            State = DockState.Document;
            this.PropertyChanged += Document_PropertyChanged;
        }

        void Document_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Path")
            {
                Text = File.ReadAllText(Path);
                CalculateLinesAndWords(Text);
            }
        }

        private void CalculateLinesAndWords(string fileText)
        {
            int pos = 0;
            bool word = false;

            while (pos < fileText.Length)
            {
                if (Char.IsWhiteSpace(fileText[pos]))
                {
                    if (word)
                    {
                        ++Words;
                        word = false;
                    }
                }
                else
                {
                    if (!word)
                    {
                        word = true;
                    }
                }

                ++pos;
            }

            if (word)
            {
                ++Words;
            }
        }
    }
}
