using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Canvas2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            var Rectangle = new Rectangle() 
            {
                Width = 100,
                Height = 100,
                Fill = Brushes.Blue,
                Visibility = Visibility.Visible 
            };


            
            Canvas.SetLeft(Rectangle, 300);
            Canvas.SetTop(Rectangle, 300);



        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}