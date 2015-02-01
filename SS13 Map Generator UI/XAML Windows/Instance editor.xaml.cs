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
using System.Windows.Shapes;
using SS13MapGen_Shared;
using System.IO;

namespace SS13_Map_Generator_UI
{
    /// <summary>
    /// Interaction logic for Instance_editor.xaml
    /// </summary>
    public partial class Instance_editor : Window
    {

        public Instance_editor()//Okay MAYBE I should divide this, MAYBE, just maybe.
        {
            InitializeComponent();
            loadedInstances.reloadInstances();
            
            if (loadedInstances.loadedAreas.Count == 0 || loadedInstances.loadedTOMs.Count == 0)//We have no ATOMS loaded.
            {
                if (loadedInstances.loadedAreas.Count == 0)//Even after reloading we still don't have any areas, ask the user to load the preset.
                {
                    MessageBoxResult result = MessageBox.Show("No area instances could be loaded, would you like me to load the preset?", "SS13 Map Generator UI", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (result == MessageBoxResult.Yes)
                    {
                        File.Copy("Preset/area preset.xml", "Data/instances/area preset.xml", true);//Copy it, else it might be modified, and since this is the preset you can't gitignore it.
                        Config.areaXMLFiles.Add("Data/instances/area preset.xml");
                    }
                }
                if (loadedInstances.loadedAreas.Count == 0)//Even after reloading we still don't have any instances, ask the user to load the preset.
                {
                    MessageBoxResult result = MessageBox.Show("No TOM Instances could be loaded, would you like me to load the preset?", "SS13 Map Generator UI", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (result == MessageBoxResult.Yes)
                    {
                        File.Copy("Preset/TOM preset.xml", "Data/instances/TOM preset.xml", true);//Copy it, else it might be modified, and since this is the preset you can't gitignore it.
                        Config.instanceXMLFiles.Add("Data/instances/TOM preset.xml");
                    }
                }

                loadedInstances.reloadInstances();
            }
            area_Instance_Grid.ItemsSource = loadedInstances.loadedAreas;
            TOM_Instance_Grid.ItemsSource = loadedInstances.loadedTOMs;
        
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        
           
    }
}
