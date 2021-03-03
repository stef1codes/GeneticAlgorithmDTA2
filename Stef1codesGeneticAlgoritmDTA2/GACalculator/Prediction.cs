using System;
using System.Collections.Generic;
using System.Text;

namespace StefanSchmmeltzGeneticAlgoritmDTA2.GACalculator
{
    class Prediction
    {

        public double Predict(List<double> coefficients,List<double> P)
        {
            double prediction = 0;
            for (int i = 0; i < coefficients.Count; i++)
            {
                prediction += coefficients[i] * P[i];
            }

            return prediction;
        }
    }
}
