using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATHRUN_PLAYERMAP.Domains
{
    public class Level
    {
        public string Map { get; }
        public Difficulty Difficulty { get; set; }
        
        public Level(string map, Difficulty difficulty)
        {
            Map = map;
            Difficulty = difficulty;
        }
    }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
}
