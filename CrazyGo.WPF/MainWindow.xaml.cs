using System.Windows;

namespace CrazyGo.WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GobanViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            CrazyGo.WPF.ViewModel.GobanViewModel gobanViewModelObject = new CrazyGo.WPF.ViewModel.GobanViewModel();
            gobanViewModelObject.LoadGoban();
            GobanViewControl.DataContext = gobanViewModelObject;
        }

    }
}
