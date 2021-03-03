using System;
using System.Collections.Generic;
using System.Text;

namespace StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Selection
{
    interface ISelection
    {
        void selection(List<Seed> population);
        
    }
}
