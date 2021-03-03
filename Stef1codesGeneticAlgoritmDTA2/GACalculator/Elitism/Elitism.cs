using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Elitisms
{
    class Elitism
    {
        public Seed best_seed { get;  set; }

        public void Elite(List<Seed> newpopulation)
        {
            Seed new_best_seed = newpopulation.OrderBy(seed => seed.SSE).First();
            if(best_seed == null)
            {
                best_seed = new_best_seed;
            }
            else if(best_seed.SSE > new_best_seed.SSE)
            {
                best_seed = new_best_seed;
            }else
            {
                ReplaceWorstWithBest(newpopulation, best_seed);
            }
           

        }

        private void ReplaceWorstWithBest(List<Seed> newpopulation, Seed best_seed)
        {
            Seed worst_seed = newpopulation.OrderByDescending(seed => seed.SSE).First();
            int worst_SSE = newpopulation.IndexOf(worst_seed);
            newpopulation[worst_SSE] = best_seed;

        }
    }
}
