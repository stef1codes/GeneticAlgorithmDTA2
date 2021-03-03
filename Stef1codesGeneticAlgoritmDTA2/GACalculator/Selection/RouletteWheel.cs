using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Selection
{
    class RouletteWheel :ISelection
    {
     
        public void selection(List<Seed> population)
        {
            List<Seed> newpopulation = new List<Seed>();
            
            // the sum of all the genes in the seed are summed and put in a list.
            List<double> ListSumSeed = (population.Select(seed => seed.DNA.Select(x => x).Sum())).ToList();
           
            //make values positive
            var lowestValue = ListSumSeed.OrderBy(x => x).First();
            ListSumSeed = ListSumSeed.Select(x => Math.Abs(lowestValue) + 1 + x).ToList();
           
            //total sum of all seeds
            double sumOfAllSeeds = ListSumSeed.Sum(x => x);

            // probabilty of each seed
            List<double> ListProbSumSeed = ListSumSeed.Select(seed => (sumOfAllSeeds / seed)).ToList();

            //total sum of all probabilty seeds
            double sumProbSeeds = ListProbSumSeed.Sum(x => x);
            
            // create a list of cumulative probabilties
            List<Tuple<double, double>> cumulativeList = new List<Tuple<double, double>>();
            // Add the values to the cumulativeList
            for (int i = 0; i < ListProbSumSeed.Count; i++)
            {
                if (i == 0)
                {
                    cumulativeList.Add(new Tuple<double, double>(0, ListProbSumSeed[i]));
                }
                else
                {
                    cumulativeList.Add(new Tuple<double, double>(cumulativeList[i-1].Item2,  (cumulativeList[i - 1].Item2 +  ListProbSumSeed[i])));
                }

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
