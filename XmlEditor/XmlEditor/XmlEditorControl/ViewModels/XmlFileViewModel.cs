namespace XmlEditor.XmlEditorControl.ViewModels
{
    using System.Windows.Input;
    using XmlEditor.XmlEditorControl.Commands;
    using XmlEditor.XmlEditorControl.Models;

    class XmlFileViewModel
    {
        public XmlFileViewModel()
        {
            this.xmlFile = new XmlFile(@"c:\1.xml");
            this.UpdateCommand = new UpdateXmlFileCommand(this);
        }

        internal XmlFile xmlFile;

        public XmlFile XmlFile
        {
            get
            {
                return this.xmlFile;
            }
        }

        public ICommand UpdateCommand
        {
            get;
            private set;
        }

        public bool CanUpdate
        {
            get
            {
                if (xmlFile == null)
                    return false;
                return true;
                //!string.IsNullOrWhiteSpace(xmlFile.RootName);
            }
        }

        public void SaveChanges()
        {
            xmlFile.Save();
        }
    }
}
