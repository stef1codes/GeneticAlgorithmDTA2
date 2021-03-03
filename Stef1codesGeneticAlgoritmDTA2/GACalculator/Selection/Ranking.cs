using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Selection
{
    class Ranking: ISelection
    {
        private readonly int fitness;

        public  Ranking( int fitness)
        {
            this.fitness = fitness;
        }

        public void selection(List<Seed> population)
        {
            List<Seed> newpopulation = new List<Seed>();
            // the sum of all the genes in the seed are summed and put in a list.
            List<double> ListSumSeed = new List<double>();
            ListSumSeed = fitness == 1
                ? (population.Select(seed => seed.DNA.Select(x => x).Sum())).OrderBy(x => x).ToList()
                : (population.Select(seed => seed.DNA.Select(x => x).Sum())).OrderByDescending(x => x).ToList();

            //total sum of all probabilty seeds
            int sumProbSeeds = 0;

            // create a list of cumulative probabilties
            List<Tuple<double, double>> cumulativeList = new List<Tuple<double, double>>();

            // Add the values to the cumulativeList
            for (int i = 1; i < ListSumSeed.Count+1; i++)
            {
                if (i == 1)
                {
                    cumulativeList.Add(new Tuple<double, double>(0, i));
                }
                else
                {
                    cumulativeList.Add(new Tuple<double, double>(cumulativeList[i-2].Item1 + i, cumulativeList[i-2].Item2 + i ));
                }
                sumProbSeeds = sumProbSeeds  + i;
            }


            // create a new population with the chosen seeds
            for (int i = 0; i < population.Count; i++)
            {
                // random range from 0 to the sum of probability seeds
                Random random = new Random();
                double rd = random.NextDouble() * (sumProbSeeds - 0) + 0;


                for (int j = 0; j < cumulativeList.Count; j++)
                {
                    //if the random value is in between  the first value and second value of the cumulative seed, add this seed to the new population
                    if (cumulativeList[j].Item1 <= rd && rd < cumulativeList[j].Item2)
                    {
                        newpopulation.Add(population[j]);
                    }
                }

            }
            //the new population of seeds replaces the old population of seeds
            population = newpopulation;

        }
    }
}
