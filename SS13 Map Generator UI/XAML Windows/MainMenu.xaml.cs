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
using SS13MapGen_Shared;


namespace SS13_Map_Generator_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Config.reloadConfig();//This is the application start, if this doesn't get called then I dunno.
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Instance_editor instanceEditor = new Instance_editor();
            instanceEditor.Show();
        }
    }
}
