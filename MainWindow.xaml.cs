using System.Diagnostics;
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
        DispatcherTimer timer = new DispatcherTimer();
        Game game;
        Settings settings_window;
        int score = 0;
        int height = 10;
        int width = 10;
        double speed = 1; 
        int border_thickness = 3;
        public MainWindow()
        {
            InitializeComponent();
            this.spielfeld_ = spielfeld;
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SnakeLogger.init("snake.log");
            settings_window = new Settings();
            felder_erstellen();
            
            SnakeLogger.logger.Debug($"Es wurden die Felder erzeugt");
            SnakeLogger.logger.Information("Window wurde erstellt");
            
            timer.Interval = TimeSpan.FromSeconds(0.5);
            game.Start(feld);
            timer.Tick += tick;
            timer.Start();
            SnakeLogger.logger.Debug("Timer wurde gestartet");
        }
        
        private void tick(object sender, EventArgs e)
        {
            if (game.Update(feld, score_label) == true)
            {
                OnClosed(EventArgs.Empty);
            }
        }

        //Die Folgende Funktion ist teilweise von Ollama Modell: gpt-oss:120-cloud
        //Promt:
        // Nein, wenn ich settings dort instanziiere kann ich Mainwindow zwar schließen aber der Prozess wird nicht beendet.
        // wenn ich Zeile 36 auskommentiere passiert das nicht

        //Seine Falsche Antwort

        //Weiterer Promt:
        //Es ist nicht der Dispatchertimer

        //Kommentar: was ich nicht wusste war, dass beim Instanziieren das Fenster "geöffnet" wird und somit sich das nicht schließen lassen kann
        protected override void OnClosed(EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void StackPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == (Key.Escape))
            {
                SnakeLogger.logger.Debug("Esc wurde gedrückt");
                settings_window = new Settings();
                timer.Stop();
                settings_window.ShowDialog();
                if (settings_window.ok == true)
                {
                    this.speed = settings_window.speed;
                    this.height = (int)settings_window.fieldHeight;
                    this.width = (int)settings_window.fieldWidth;
                    felder_erstellen();
                    timer.Interval = TimeSpan.FromSeconds(settings_window.speed);

                }
                timer.Start();
            }
            if (e.Key == (Key.W) && game.snake1.direction != Direction.Down)
            {
                game.snake1.ChangeDirection(Direction.Up);
            }
            else if (e.Key == (Key.A) && game.snake1.direction != Direction.Right)
            {
                game.snake1.ChangeDirection(Direction.Left);
            }
            else if (e.Key == (Key.S) && game.snake1.direction != Direction.Up)
            {
                game.snake1.ChangeDirection(Direction.Down);
            }
            else if (e.Key == (Key.D) && game.snake1.direction != Direction.Left)
            {
                game.snake1.ChangeDirection(Direction.Right);
            }
        }
        private void felder_erstellen()
        {
            feld.Children.Clear();
            SnakeLogger.logger.Debug($"Feld wurde gecleard: {feld.Children.Count}");
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Width = 40;
                    rect.Height = 40;
                    rect.Fill = Brushes.Black;
                    Canvas.SetLeft(rect, x * 40 + border_thickness * (x + 1));
                    Canvas.SetTop(rect, y * 40 + border_thickness * (y + 1));
                    feld.Height = (y + 1) * 40 + border_thickness * (y + 2);
                    feld.Width = (x + 1) * 40 + border_thickness * (x + 2);
                    feld.Children.Add(rect);
                }
            }
            SnakeLogger.logger.Debug($"Height/Width{height};{width}");
            game = new Game(settings_window, feld);
        }
    }
}