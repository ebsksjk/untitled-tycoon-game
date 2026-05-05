using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using UntitledTycoonGame.Views;

namespace UntitledTycoonGame.src.Game.Simulation
{
    internal class City
    {
        public Citizen[] citizens;


        private string jobPath = "src\\Assets\\Data\\jobs.json";
        private string namePath = "src\\Assets\\Data\\names.json";

        private string outputFile = "city.txt";

        private string[] causesOfDeath = new string[] { "Natural Causes", "Accident", "Disease", "Suicide", "Homicide" };
        private string[] pronouns = new string[] { "He/Him", "She/Her", "They/Them", "Xe/Xem" };

        public City(int population)
        {
            citizens = new Citizen[population];

            Job[] parsedJobs = JsonSerializer.Deserialize<Job[]>(File.ReadAllText(jobPath));
            Name parsedNames = JsonSerializer.Deserialize<Name>(File.ReadAllText(namePath));

            if (parsedJobs == null || parsedJobs.Length == 0) { 
                throw new Exception("Failed to parse jobs from JSON files.");
            }

            if(parsedNames.surnames == null || parsedNames.surnames.Length == 0 || parsedNames.forenames == null || parsedNames.forenames.Length == 0)
            {
                throw new Exception("Failed to parse names from JSON files.");
            }

            for (int i = 0; i < population; i++)
            {
                string name = (parsedNames.forenames[new Random().Next(0, parsedNames.forenames.Length)] +
                    ' ' + parsedNames.surnames[new Random().Next(0, parsedNames.surnames.Length)]);
                

                //current age
                int age = new Random().Next(1, 120);

                bool acceptAge = false;
                while (!acceptAge)
                {
                    age = new Random().Next(1, 120);
                    if (age > 67)
                    {
                        if (new Random().Next(0, 4) == 1)
                        {
                            acceptAge = true;
                        }
                    }else
                    {
                        acceptAge = true;
                    }
                }
               

                //TODO: match this line to in game time and make it more accurate
                DateTime birthDate = DateTime.Now.AddYears(-age);

                Job job;

                if (age > 24 && age < 67)
                {
                    if (new Random().Next(0, 3) == 1)
                    {
                        if (new Random().Next(0, 9) == 1)
                        {
                            job = new Job("Homeless", 0, 200);
                        } else if (new Random().Next(0, 9) == 1)
                        {
                            job = new Job("Drug Dealer", 3000, 4000);
                        }
                        else if (new Random().Next(0, 9) == 1)
                        {
                            job = new Job("Criminal", 4000, 5000);
                        } else
                        {
                            job = new Job("Unemployed", 500, 1000);
                        }
                    } else
                    {
                        job = parsedJobs[new Random().Next(0, parsedJobs.Length)];
                    }
                } else if (age <= 16)
                {
                    job = new Job("Student", 0, 50);
                } else if(age > 16 && age < 25)
                {
                    job = new Job("Apprentice", 550, 1000);
                } else if(age > 67)
                {
                    job = new Job("Retired", 600, 1000);
                } else
                {
                    job = parsedJobs[new Random().Next(0, parsedJobs.Length)];
                }
            

                citizens[i] = new Citizen(name, job, birthDate, age, causesOfDeath[new Random().Next(0, causesOfDeath.Length)], pronouns[new Random().Next(0, pronouns.Length)]);

                //Console.WriteLine($"Created citizen: {name}, Job: {job.name}, Birth Date: {birthDate.ToShortDateString()}, Age: {age}");

                
            }

            //write to file
            var writer = new StreamWriter(outputFile, append: false);
            foreach (var citizen in citizens)
            {
                writer.WriteLine($"{citizen.name} ({citizen.pronouns})\n\tJob: {citizen.job.name} (Income: {citizen.currentIncome})\n\tBirth Date: {citizen.birthDate.ToShortDateString()} (age: {(DateTime.Now.Year - citizen.birthDate.Year)})\n\tDeath Date: {citizen.deathDate.ToShortDateString()} (died aged {citizen.deathDate.Year - citizen.birthDate.Year} by {citizen.causeOfDeath})\n\n");
            }
            
        }

    }
}
