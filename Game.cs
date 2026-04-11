using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Game
    {
        private SnakeUC sanake1;
        private SnakeUC sanake2;
        private Food food;
        private Settings settings;
        private int score1;
        private int score2;

        public Game(Settings settings)
        {
            this.settings = settings;
            SnakeLogger.logger.Information($"Settings wurden in Game übernommen");
        }

        public void Start()
        {

        }

        public void Update()
        {

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
