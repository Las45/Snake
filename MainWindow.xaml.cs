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
using System.Windows.Threading;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas spielfeld_;
        public MainWindow()
        {
            InitializeComponent();
            this.spielfeld_ = spielfeld;
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SnakeLogger.init("snake.log");
            SnakeLogger.logger.Information("Window wurde erstellt");
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(25);
            timer.Tick += tick;
            timer.Start();
        }
        
        private void tick(object sender, EventArgs e)
        {
            if(Keyboard.IsKeyDown(Key.Escape))
            {
                settings window = new settings();
                window.ShowDialog();
            }
        }
    }
}