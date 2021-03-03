using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator.Crossover
{
    class TwoPointCrossover : ICrossover
    {
        double[] parent1, parent2;

        public List<Seed> CrossOver(List<Seed> selectedSeeds, double crossoverProbability)
        {

            List<Seed> children = new List<Seed>();
            for (int i = 0; i < selectedSeeds.Count; i += 2)
            {
                //parents
                parent1 = selectedSeeds[i].DNA.ToArray();
                parent2 = selectedSeeds[i + 1].DNA.ToArray();

                Random r = new Random();
                var random = r.NextDouble() * (1 - 0) + 0;
                //if the random value is inferior to the crossobverprobability then mix the the data of the parentt
                if (random < crossoverProbability)
                {
                    var lengthSeed = selectedSeeds.Select(x => x.DNA).First().Count;

                    int cutpoint1 = Convert.ToInt32((lengthSeed )) * 1/3;
                    int cutpoint2 = Convert.ToInt32((lengthSeed )) * 2/3;
                    // first take the genes from the cuttingpoint to the end of the list for both parents,
                    // after that,take the genes from the  start unto the cuttingpoint  for both parents.
                    //finally create a new chromosome by concating the left genes of the parent1 with the right genes of parent2 and vise versa.
                    ParentsBreedingResults(parent1, parent2, cutpoint1, cutpoint2, children);
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

        private void ParentsBreedingResults(double[] parent1, double[] parent2, int cutpoint, int cutpoint2,  List<Seed> children)
        {
            var p1left_cutleft  = parent1[..cutpoint];         //  1/3 part of the list
            var p1left_cutmid   = parent1[cutpoint..cutpoint2];// 2/3 part of the list
            var p1left_cutright = parent1[cutpoint2..];        // 3/3 part of the list

            var p2left_cutleft  = parent2[..cutpoint];         //  1/3 part of the list
            var p2left_cutmid   = parent2[cutpoint..cutpoint2];//  2/3 part of the list
            var p2left_cutright = parent2[cutpoint2..];        //  3/3 part of the list

            // create new list by taking the mid part of parent two and concating it with the left and right part of parent one. parent two vice versa.
            var child1 = p1left_cutleft.Concat(p2left_cutmid).Concat(p1left_cutright).ToList(); 
            var child2 = p2left_cutleft.Concat(p1left_cutmid).Concat(p2left_cutright).ToList(); 

              children.Add(new Seed(new List<double>(child1)));
              children.Add(new Seed(new List<double>(child2)));

        }
        private void AddParentsToNewPopulation(List<Seed> parents, int position, List<Seed> children)
        {

            var parent1_ = parents[position];
            var parent2_ = parents[position + 1];
            children.Add(parent1_);
            children.Add(parent2_);

        }

        private List<Seed> addToNewPopulation(List<Seed> children)
        {
            List<Seed> population_ = new List<Seed>();
            for (int k = 0; k < children.Count; k++)
            {
                population_.Add(children[k]);
            }
            return population_;
        }

    }
}
