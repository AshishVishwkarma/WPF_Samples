using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Diagnostics;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += RuntimeSkinning;
            PrintLogicalTree(0, this);
        }

        void RuntimeSkinning(object sender, RoutedEventArgs e)
        {
            SkinChanger.AddHandler(RadioButton.CheckedEvent, new RoutedEventHandler(OnSkinChanged));
        }

        void PrintLogicalTree(int depth, object obj)
        {
            // In VS output window (CTRL+ALT+O)
            Debug.WriteLine(new String(' ', depth) + obj);

            if (!(obj is DependencyObject)) return;

            foreach (object child in LogicalTreeHelper.GetChildren(obj as DependencyObject))
                PrintLogicalTree(depth + 1, child);
        }

        void PrintVisualTree(int depth, DependencyObject obj)
        {
            Debug.WriteLine(new string(' ', depth) + obj);

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); ++i)
                PrintVisualTree(depth + 1, VisualTreeHelper.GetChild(obj, i));
        }

        private void OnSkinChanged(object sender, RoutedEventArgs e)
        {
            string name = (e.OriginalSource as RadioButton).Name;
            
            //if (name == "NoSkin") return;

            ResourceDictionary skin =
                Application.LoadComponent(new Uri("Skins/ResourceDictionary_" + name + ".xaml", UriKind.RelativeOrAbsolute)) as ResourceDictionary;
            //Application.LoadComponent(new Uri("/WpfSkinSample;component/Skins/ResourceDictionary_" + name + ".xaml", UriKind.Relative)) as ResourceDictionary;

            SkinableGrid.Resources.MergedDictionaries.Add(skin);

            e.Handled = true;
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            //static bool changeText = true;

            if (changeText)
            {
                Text1.Text = "Hello World!";
                Label1.Content = "Hello World!";
            }
            else
            {
                Text1.Text = "TextBlock";
                Label1.Content = "Label";
            }

            changeText = !changeText;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            PrintVisualTree(0, this);
        }

        private bool changeText = true;
    }
}
