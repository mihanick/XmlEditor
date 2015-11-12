using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlEditor.XmlEditorControl.Models
{
    public class XmlFile : INotifyPropertyChanged
    {
        public string Path { get; set; }

        public XmlDocument xdoc;

        public XmlFile(string path)
        {
            xdoc = new XmlDocument();
            xdoc.Load(path);
            this.Path = path;
            this.rootName = this.xdoc.SelectSingleNode("//Project").Name;
        }

        private string rootName;
        public string RootName
        {
            get
            {
                return rootName;
            }
            set
            {
                this.rootName = value;
                OnPropertyChanged("RootName");
            }
        }

        internal void Save()
        {
            this.xdoc.SelectSingleNode("//Project").Value = this.RootName;
            this.xdoc.Save(this.Path);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
