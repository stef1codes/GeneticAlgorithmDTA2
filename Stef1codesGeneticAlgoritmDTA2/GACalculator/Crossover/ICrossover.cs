using System;
using System.Collections.Generic;
using System.Text;

namespace StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Crossover
{
    interface ICrossover
    {
        List<Seed> CrossOver(List<Seed> selectedSeeds,  double crossoverProbability);
    }
}
