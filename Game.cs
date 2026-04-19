using System.IO;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{
    public class Game
    {
        public SnakeUC snake1 { get; set; }
        public SnakeUC snake2 {  get; set; }
        public Food food {  get; set; }
        private Settings settings {  get; set; }
        public int score1 {  get; set; }
        public int score2 {  get; set; }

        public Game()
        {
          
        }
        public Game(Settings settings, Canvas feld)
        {
            this.settings = settings;
            snake1 = new SnakeUC(settings.initialLength, feld);
            food = new Food(settings.fieldWidth,settings.fieldHeight, feld, snake1.bodySegments);
            SnakeLogger.logger.Information($"Settings wurden in Game übernommen");
        }

        public void Start(Canvas feld)
        {
            snake1.Move();
            food.Respawn(feld);
            SnakeLogger.logger.Debug("Snake1 wurde hinzugefügt");
        }

        public bool Update(Canvas feld, Label score)
        {
            snake1.Move();
            if (snake1.ChekcCollision(settings.fieldHeight, settings.fieldWidth, food.GetPosition()).Item1 == true)
            {
                return true;
            }
            else if(snake1.ChekcCollision(settings.fieldHeight, settings.fieldWidth, food.GetPosition()).Item2 == true)
            {
                SnakeLogger.logger.Debug("Apfel wurde gegessen");
                score1++;
                snake1.Grow(feld);
                food.Respawn(feld);
            }
            score.Content = $"Score: {score1}";
            return false;
        }

        public void Pause()
        {

        }

        public void Reset()
        {

        }

        public void SaveToJson(string path)
        {
            SnakeLogger.logger.Debug("Speichern");
            List<int[]> koords = new List<int[]>();
            koords.Add([food.x, food.y]);
            koords.Add([food.fieldWith, food.fieldHeight]);
            foreach (BodySegment segment in snake1.bodySegments)
            {
                koords.Add([segment.x, segment.y]);
            }
            string save = JsonSerializer.Serialize(koords);
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.Write(save);
                SnakeLogger.logger.Debug($"Gespeichert: {save}");
            }
        }
        public void LoadFromJson(string path, Canvas feld)
        {
            string json = File.ReadAllText(path);

            List<int[]> koods = JsonSerializer.Deserialize<List<int[]>>(json);

            food.x = koods[0][0];
            food.y = koods[0][1];
            food.fieldWith = koods[1][0];
            food.fieldHeight = koods[1][1];
            feld.Children.Clear();
            snake1.bodySegments.Clear();
            feld.Children.Clear();
            feld.Children.Clear();
            SnakeLogger.logger.Debug($"Feld wurde gecleard: {feld.Children.Count}");
            int border_thickness = 3;
            for (int y = 0; y < food.fieldHeight; y++)
            {
                for (int x = 0; x < food.fieldWith; x++)
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
            SnakeLogger.logger.Debug($"Height/Width{food.fieldHeight};{food.fieldWith}");
            Canvas.SetLeft(food, food.x * 43 - 40);
            Canvas.SetTop(food, food.y * 43 - 40);
            feld.Children.Add(food);
            for (int i = 2; i<koods.Count(); i++)
            {
                snake1.bodySegments.Add(new BodySegment(koods[i][0], koods[i][1]));
                Canvas.SetLeft(snake1.bodySegments[i - 2], snake1.bodySegments[i - 2].x * 43 - 40);
                Canvas.SetTop(snake1.bodySegments[i - 2], snake1.bodySegments[i - 2].y * 43 - 40);
                feld.Children.Add(snake1.bodySegments[i-2]);
            }
            score1 = koods.Count()-3;
        }

    }
}
