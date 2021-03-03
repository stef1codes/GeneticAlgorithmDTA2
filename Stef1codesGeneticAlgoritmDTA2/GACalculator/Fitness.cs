using System;
using System.Collections.Generic;

namespace StefanSchmmeltzGeneticAlgoritmDTA2
{
    class Fitness 
    {
        private readonly List<double> pregdata;
        private readonly List<List<double>> alldata;

       

        public Fitness(List<double> pregdata, List<List<double>> alldata)
        {
            this.pregdata = pregdata;
            this.alldata = alldata;
        }




        public List<Seed> GenerateNewPopulation(int populationSize, (int min, int max) randomLimit)
        {
         List<Seed> Population = new List<Seed>();

            for (int seed = 0; seed < populationSize; seed++)
            {
                var genes = new List<double>();
                for (int gene = 0; gene < 20; gene++)
                {
                    Random random = new Random();
                   // genes.Add(GetRandomNumber((randomLimit.max - randomLimit.min), randomLimit.min));
                    genes.Add(random.NextDouble() * (randomLimit.max - randomLimit.min) + randomLimit.min);
                   
                }
                Population.Add(new Seed(genes));
            }
            return Population;
        }


        public void CalculateFitness(List<Seed> population)
        {
            for (int i = 0; i < population.Count; i++)
            {
                Seed seed = population[i];
                List<double> DNA = seed.DNA;
                double SSE = 0;
                for (int j = 0; j < alldata.Count; j++)
                {
                    List<double> PA = alldata[j];
                    double prediction = 0;
                    for (int k = 0; k < DNA.Count; k++)
                    {
                        prediction += DNA[k] * PA[k];
                    }
                    SSE += Math.Pow((pregdata[j] - prediction), 2.0);
                }
                seed.SSE = SSE;
            }

        }



        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
