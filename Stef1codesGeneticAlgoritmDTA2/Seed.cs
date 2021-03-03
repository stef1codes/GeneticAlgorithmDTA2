using System;
using System.Collections.Generic;
using System.Text;

namespace StefanSchmmeltzGeneticAlgoritmDTA2
{
    class Seed
    {
        public Seed(List<double> _data)
        {
            DNA = _data;
        }
        public Seed(){ }
        public List<double> DNA { get ;  set; }
        public double SSE { get;  set; }
    }
}
