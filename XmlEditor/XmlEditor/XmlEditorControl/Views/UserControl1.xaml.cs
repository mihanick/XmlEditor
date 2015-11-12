

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

            // http://stackoverflow.com/questions/6250240/how-to-add-a-scrollbar-to-a-stackpanel
            ScrollViewer sv = new ScrollViewer();
            StackPanel sp = new StackPanel();
            sv.Content = sp;
            this.Content = sv;
            foreach (XmlNode i in ((XmlFileViewModel)DataContext).XmlFile.xdoc.ChildNodes)
            {
                NestedControlPlacement(sp, i);
            }
        }

        private void NestedControlPlacement(StackPanel sp, XmlNode xn)
        {
            StackPanel spn = new StackPanel();
            spn.Margin = new System.Windows.Thickness(4,0,0,0);
            sp.Children.Add(spn);

            if (xn.LocalName == "#text")
            {
                TextBox tb = new TextBox();
                tb.Text = xn.Value;
                spn.Children.Add(tb);
            }
            else
            {
                TextBlock blk = new TextBlock();
                blk.Text = xn.Name;
                spn.Children.Add(blk);

                foreach (XmlNode xnd in xn.ChildNodes)
                    NestedControlPlacement(spn, xnd);
            }
        }
    }
}
