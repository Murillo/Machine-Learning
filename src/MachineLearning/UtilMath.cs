using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MachineLearning
{
    public static class UtilMath
    {
        public static double[] MeanNormalizationStandardization(this double[] values)
        {
            double[] valuesTemp = new double[values.Length];
            for (int i = 0; i < values.Length; i++)
                valuesTemp[i] = (values[i] - (values.Aggregate((a, b) => a + b) / values.Length)) / (values.Max() - values.Min());

            return valuesTemp;
        }

        public static double[,] MeanNormalizationStandardization(this double[,] values)
        {
            int amountTrain = values.Length / values.GetLength(1);
            int amountValues = values.GetLength(1);
            double[,] valuesTemp = new double[amountTrain, amountValues];
            for (int i = 0; i < amountTrain; i++)
            {
                double[] valuesForMean = new double[amountValues];
                for (int j = 0; j < amountValues; j++)
                    valuesForMean[j] = values[i, j];

                for (int j = 0; j < amountValues; j++)
                    valuesTemp[i, j] = (values[i, j] - (valuesForMean.Aggregate((a, b) => a + b) / valuesForMean.Length)) / (valuesForMean.Max() - valuesForMean.Min());
            }
            return valuesTemp;
        }
    }
}
