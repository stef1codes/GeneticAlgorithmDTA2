using StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Elitisms;
using System;
using System.Collections.Generic;
using System.Text;

namespace StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator
{
    class PrintData
    {

        //private Elitism e = new Elitism();


        public void printBestSSE(Elitism e)
        {
            Console.WriteLine(" | The individual with the best SSE: " + e.best_seed.SSE);
            Console.WriteLine(" _______________________________________________________________");
        }

        public void printDNA(Elitism e)
        {
            int i = 0;
            Console.WriteLine("DNA of best seed");
            e.best_seed.DNA.ForEach(dna => {

                Console.WriteLine("[" + i + "] >>> " + dna);

                i++;
            });
        }
        public void printSSEperIteration(int iteration, Elitism e)
        {
            Console.WriteLine(" | SSE of Iteration " + iteration + ": " + e.best_seed.SSE);
            Console.WriteLine(" __________________");

        }
    }
}
