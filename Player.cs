using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koursach_Tri_v_Ryad
{
    class Player
    {
        public string name { get; set; }
        public int score { get; set; }

        public Player (string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public string getName()
        {
            return name;
        }

        public void setScore(int score)
        {
            this.score = score;
        }
    }
}
