

namespace XmlEditor.XmlEditorControl.Views
{
    using System.Windows.Controls;
    using System.Xml;
    using XmlEditor.XmlEditorControl.ViewModels;

    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            DataContext = new XmlFileViewModel();

        }

}
