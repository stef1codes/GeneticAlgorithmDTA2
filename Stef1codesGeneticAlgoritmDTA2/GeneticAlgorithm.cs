using StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator;
using StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Crossover;
using StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Elitisms;
using StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Mutation;
using StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Selection;
using System;
using System.Collections.Generic;
using System.Text;

namespace StefanSchmmeltzGeneticAlgoritmDTA2
{
    class GeneticAlgorithm
    {
      
        private Mutations mutation = new Mutations();
        private Elitism elitism    = new Elitism();
        private PrintData print    = new PrintData();
        public Seed BestSeed       = new Seed();
        internal List<Seed> Newpopulation = new List<Seed>();



        public GeneticAlgorithm(List<Seed> population, Fitness fitness, int iterations, ICrossover Crosseover, double crossoverProbability, (double chanceMutation, int min, int max) mutation, ISelection selection)
        {


            RunGA(population, iterations, Crosseover, crossoverProbability, fitness,  mutation, selection);
        }

       

        public Seed RunGA(List<Seed> population, int iterations, ICrossover Crossover, double crossoverProbability ,Fitness fitness,  (double chanceMutation, int min, int max) mutationRate, ISelection roulette)
        {
            //calculate the fitness
            fitness.CalculateFitness(population);
           
            for (int i = 0; i < iterations; i++)
            {
                // Roullet Wheel
                roulette.selection(population);

                //Crossover 
                Newpopulation = Crossover.CrossOver(population, crossoverProbability);
              
                // Mutation
                 mutation.Mutation(Newpopulation, mutationRate);
                 
                //calculate Fitness of the new  population
                 fitness.CalculateFitness(Newpopulation);
                
                //elitism
                 elitism.Elite(Newpopulation);

                //old population becomes new population
                population = Newpopulation;
               
                //print the SSE periteration
                print. printSSEperIteration(i,elitism);
               
            }
            print.printBestSSE(elitism);
            print.printDNA(elitism);
            BestSeed = elitism.best_seed;
            return elitism.best_seed;
        }
   
    }
}
