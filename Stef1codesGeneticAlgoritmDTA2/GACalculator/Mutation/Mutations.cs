using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Mutation
{
    class Mutations 
    {

        internal void Mutation(List<Seed> newpopulation, (double chanceMutation, double min, double max) mutationRate)
        {
            for (int seed = 0; seed < newpopulation.Count; seed++)
            {
                for (int gene = 0; gene < newpopulation[0].DNA.Count; gene++)
                {
                    Random random = new Random();
                    if (random.NextDouble() <= mutationRate.chanceMutation)
                    {
                        newpopulation[seed].DNA[gene] = random.NextDouble() * (mutationRate.max - mutationRate.min) + mutationRate.min; 
                    }
                }

            }


        }

      
    }
}
