using System.Windows;
using Skillz.ViewModel;

namespace Skillz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HighscoreViewModel _model;

        public MainWindow()
        {
            InitializeComponent();
            _model = new HighscoreViewModel();
            _model.Username = "Ryada_tv";

            DataContext = _model;
        }
    }
}
