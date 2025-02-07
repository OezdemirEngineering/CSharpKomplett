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

namespace MyFistWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        Output.Text = "BUtton geclickt";

        if (UsernameInput.Text == "admin" && PasswordInput.Text == "admin")
        {
            Output.Text = "Login erfolgreich";
            DashbooardView.Visibility = Visibility.Visible;
            LoginView.Visibility = Visibility.Collapsed;
        }
        else
        {
            Output.Text = "Login fehlgeschlagen";
        }
    }

    private void LogoutButton_Click(object sender, RoutedEventArgs e)
    {
        DashbooardView.Visibility = Visibility.Collapsed;
        LoginView.Visibility = Visibility.Visible;
    }
}