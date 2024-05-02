using System.Windows;
using WpfAppVmeste.ViewModel;

namespace WpfAppVmeste
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}