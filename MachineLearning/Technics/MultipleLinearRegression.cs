using System;
using System.Linq;

namespace MachineLearning.Technics
{
    public class MultipleLinearRegression
    {
        private readonly double[] _weight;
        private readonly double _error;
        private readonly double _learningRate;

        public double[] Weight => _weight;

        public MultipleLinearRegression(int input, double error = 0.5d, double learningRate = 0.15d)
        {
            _weight = new double[input + 1];
            _error = error;
            _learningRate = learningRate;
            RandonWeight();
        }

        public double Run(double[] input)
        {
            double value = _weight[0] * 1;
            for (int i = 0; i < input.Length; i++)
            {
                value += _weight[i + 1] * input[i];
            }
            return value;
        }

        public void Training(double[,] inputs, double[] outputs)
        {
            Gradient(inputs, outputs);
        }

        private double Cost(double[,] input, double[] output)
        {
            int numberTrain = input.Length / input.GetLength(1);
            double valueInitial = 1d / (2d * numberTrain);
            double valueSum = 0d;
            
            for (int i = 0; i < numberTrain; i++)
            {
                double value = _weight[0] * 1;
                for (int j = 0; j < (input.GetLength(1)); j++)
                    value += _weight[j + 1] * input[i, j];

                valueSum += ((value - output[i]) * (value - output[i]));
            }

            return valueInitial * valueSum;
        }

        private double Gradient(double[,] input, double[] output)
        {
            double cost = Cost(input, output);
            double[] weightTemp = new double[_weight.Length];
            int numberTrain = input.Length / input.GetLength(1);

            while (cost > _error)
            {
                for (int i = 0; i < numberTrain; i++)
                {
                    for (int j = 0; j < _weight.Length; j++)
                    {
                        double value = _weight[0] * 1;
                        for (int k = 0; k < input.GetLength(1); k++)
                            value += _weight[k + 1] * input[i, k];

                        double valueSum;
                        if (j == 0)
                            valueSum = (value - output[i]) * 1;
                        else
                            valueSum = (value - output[i]) * input[i, j - 1];

                        weightTemp[j] = _weight[j] - ((_learningRate * (1d / numberTrain)) * valueSum);
                    }
                    Array.Copy(weightTemp, _weight, weightTemp.Length);
                }
                cost = Cost(input, output);
            }
            return cost;
        }

        private void RandonWeight()
        {
            Random r = new Random();
            for (int i = 0; i < _weight.Length; i++)
            {
                _weight[i] = r.NextDouble();
            }
        }
    }
}
