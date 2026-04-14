using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
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
            SnakeLogger.logger.Information($"Settings wurden in Game übernommen");
        }

        public void Start(Canvas feld)
        {
            snake1.Move();
            SnakeLogger.logger.Debug("Snake1 wurde hinzugefügt");
        }

        public void Update()
        {
            snake1.Move();
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
