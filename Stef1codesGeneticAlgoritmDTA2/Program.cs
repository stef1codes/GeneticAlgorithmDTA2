using Reader;
using StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator;
using StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Crossover;
using StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Selection;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace StefanSchmmeltzGeneticAlgoritmDTA2
{
    class Program
    {
        static void Main(string[] args)
        {
           var get = new DataReader();
            //fitness
            Fitness fitness = new Fitness(get.DataPregnant(), get.Data());// insert the data from DataReader for the population creation.
             //selection
            var highestFitness = 1;
            var lowestFitness = 2;
            ISelection roulette = new RouletteWheel();          
            ISelection ranking = new Ranking(highestFitness);

            //crossover
            var crossoverProbability = 0.6;
            ICrossover onePointCrosseover = new OnePointCrossover();
            ICrossover twoPointCrosseover = new TwoPointCrossover();
            //mutation
            var Mutation = (chanceMutation: 0.01, min: -1, max: 1);
            var RandomLimits   = (min: -1, max: 1);
            //population
            var populationSize  = 60;
            // create a new population
            var population = fitness.GenerateNewPopulation(populationSize, RandomLimits); 

            var ga = new GeneticAlgorithm(population, fitness, 100, onePointCrosseover, crossoverProbability, Mutation, roulette);
          
            System.Collections.Generic.List<double> predict = get.Data()[400];
            
            Console.WriteLine("prediction for value " + 400 + " : "+new Prediction().Predict(ga.BestSeed.DNA, predict));
            Console.ReadLine();
        }
    }


}
