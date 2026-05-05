using System;
using System.Collections.Generic;
using System.Text;

namespace UntitledTycoonGame.src.Game.Simulation
{
    public struct Job
    {

        public Job(string n, int min, int max)
        {
            name = n;
            minIncome = min;
            maxIncome = max;
        }

        public string name { get; set; }
        public int minIncome { get; set; }
        public int maxIncome { get; set; }

    }
}
