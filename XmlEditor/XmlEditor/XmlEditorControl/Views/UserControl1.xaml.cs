

namespace XmlEditor.XmlEditorControl.Views
{
    using System.Windows;
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
            if (xn.LocalName == "#text")
            {
                TextBox tb = new TextBox();
                tb.Text = xn.Value;
                sp.Children.Add(tb);
            }
            else
            {
                Grid g = new Grid();
                ColumnDefinition cd1 = new ColumnDefinition();
                cd1.Width = new System.Windows.GridLength(12);

                g.ColumnDefinitions.Add(cd1);
                g.ColumnDefinitions.Add(new ColumnDefinition());
                g.RowDefinitions.Add(new RowDefinition());
                g.RowDefinitions.Add(new RowDefinition());

                TextBlock collapseButton = new TextBlock();
                collapseButton.Text = "-";
                collapseButton.MouseUp += collapseButtonClick;
                
                //spn.Children.Add(collapseButton);
                
                collapseButton.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

                TextBlock blk = new TextBlock();
                blk.Text = xn.Name;
                blk.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                
                //spn.Children.Add(blk);

                g.Children.Add(collapseButton);
                g.Children.Add(blk);
                collapseButton.SetValue(Grid.ColumnProperty, 0);
                blk.SetValue(Grid.ColumnProperty, 1);

                sp.Children.Add(g);

                StackPanel spn = new StackPanel();
                //spn.Margin = new System.Windows.Thickness(4, 0, 0, 0);
                g.Children.Add(spn);
                spn.SetValue(Grid.ColumnProperty, 1);
                spn.SetValue(Grid.RowProperty, 1);


                foreach (XmlNode xnd in xn.ChildNodes)
                    NestedControlPlacement(spn, xnd);
            }
        }

        private void collapseButtonClick(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            if (tb.Text == "-")
            {
                tb.Text = "+";
                Grid g = (Grid)tb.Parent;
                g.RowDefinitions[1].MaxHeight = 0;
            }
            else
            {
                tb.Text = "-";
                Grid g = (Grid)tb.Parent;
                g.RowDefinitions[1].MaxHeight = double.PositiveInfinity;
            }
        }
    }
}
