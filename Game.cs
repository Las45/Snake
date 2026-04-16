using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Snake
{
    public class Game
    {
        public SnakeUC snake1;
        public SnakeUC snake2;
        private Food food;
        private Settings settings;
        private int score1;
        private int score2;

        public Game(Settings settings, Canvas feld)
        {
            this.settings = settings;
            snake1 = new SnakeUC(settings.initialLength, feld);
            food = new Food(settings.fieldWidth,settings.fieldHeight, feld);
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

        }
        public void LoadFromJson(string path)
        {

        }
    }
}
