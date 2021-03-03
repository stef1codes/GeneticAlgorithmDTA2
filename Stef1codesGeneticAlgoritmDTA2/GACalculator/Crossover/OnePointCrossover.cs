using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Crossover
{
    class OnePointCrossover : ICrossover
    {
        double[] parent1, parent2;

        public List<Seed> CrossOver(List<Seed> selectedSeeds,  double crossoverProbability)
        {
            
            List <Seed> children = new List<Seed>();
            for (int i = 0; i < selectedSeeds.Count; i+=2)
            {
                //parents
                parent1 = selectedSeeds[i].DNA.ToArray();
                parent2 = selectedSeeds[i+1].DNA.ToArray();

                Random r = new Random();
                var random =  r.NextDouble() * (1 - 0) + 0;
                //if the random value is inferior to the crossobverprobability then mix the the data of the parentt
                if (random < crossoverProbability)
                { 
                    var lengthSeed = selectedSeeds.Select(x => x.DNA).First().Count;
                   
                    int cutpoint = Convert.ToInt32(lengthSeed * (1 - random));
                    // first take the genes from the cuttingpoint to the end of the list for both parents,
                    // after that,take the genes from the  start unto the cuttingpoint  for both parents.
                    //finally create a new chromosome by concating the left genes of the parent1 with the right genes of parent2 and vise versa.
                     ParentsBreedingResults(parent1, parent2, cutpoint, children);
                }
                else
                {
                    //if the random value is superior to the crossobverprobability then dont let the parent create a new breed, but pass the parents to the new population
                     AddParentsToNewPopulation(selectedSeeds, i, children);
                }
                //add the childrens chromosome and the chromosome of the parents to the new population list
                 
                
            }

            return addToNewPopulation(children);
        }

        private void ParentsBreedingResults(double[] parent1, double[] parent2, int cutpoint, List<Seed> children)
        {
            
            var p1left = parent1[cutpoint..];
            var p2left = parent2[cutpoint..];

            var p1right = parent1[..cutpoint];
            var p2right = parent2[..cutpoint];

            var child1 = p1left.Concat(p2right).ToList();
            var child2 = p1right.Concat(p2left).ToList();

            children.Add(new Seed(new List<double>(child1)));
            children.Add(new Seed(new List<double>(child2)));
            
        }
         private void AddParentsToNewPopulation(List<Seed> parents, int position, List<Seed> children)
        {
           
            var parent1_ = parents[position];
            var parent2_ = parents[position+1];
            children.Add(parent1_);
            children.Add(parent2_);
           
        }

        private List<Seed> addToNewPopulation(List<Seed> children)
        {
            List<Seed> population_ = new List<Seed>();
            for (int k = 0; k < children.Count; k++){
                population_.Add(children[k]);
            }
            return population_;
        }

      
       
    }
}
