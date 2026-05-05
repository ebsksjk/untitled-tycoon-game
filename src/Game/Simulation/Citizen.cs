using System;
using System.Collections.Generic;
using System.Text;

namespace UntitledTycoonGame.src.Game.Simulation
{
    internal class Citizen
    {


        public Job job;
        public string name;
        public string pronouns;
        public DateTime birthDate;
        public DateTime deathDate;
        public int currentIncome;
        public string causeOfDeath;

        public Citizen(string n, Job j, DateTime birth, int age, string COD, string pronouns)
        {

            int totalAge = new Random().Next(age, 120);

            name = n;
            job = j;
            birthDate = birth;
            deathDate = birth.AddYears(totalAge);
            currentIncome = new Random().Next(j.minIncome, j.maxIncome);
            causeOfDeath = COD;
            this.pronouns = pronouns;
        }
    }
}
