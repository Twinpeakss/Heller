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

namespace HellerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Layout MainLayout { get; set; }

        JsonSerializeModel Model { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MainLayout = new Layout(BasePanel, WidthSplitter, HeightSplitter);

        }   


        public void VerticalSplitter(object sender, RoutedEventArgs e)
        {
            MainLayout.VerticalSplitter();
        }


        public void HorizontalSplitter(object sender, RoutedEventArgs e) 
        {
            MainLayout.HorizontalSplitter();        
        }

        public void ToJson(object sender, RoutedEventArgs e) 
        {
        
        
        }



        public void GoBack(object senser, RoutedEventArgs e)
        {
            MainLayout.BackwardSplitter();
            
           
        }

    }
}
