using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Linear Regression

            Console.WriteLine("Linear Regression");
            double[] input = new double[] { -2, -1, 1, 4 };
            double[] output = new double[] { -3, -1, 2, 3 };
            LinearRegression linearRegression = new LinearRegression();
            linearRegression.Training(input, output);
            Console.WriteLine("Result: " + Math.Round(linearRegression.Run(0.5d),2));
            Console.WriteLine("Coefficient Determination: " + Math.Round(linearRegression.CoefficientDetermination,2));
            Console.WriteLine("--------------------------");

            #endregion

            #region Multiple Linear Regression

            double[,] inputTrain = { { 2d, 3d }, { 2.5d, 2d }, { 1.8d, 4d } };
            double[] outputTrain = { 5d, 6d, 4d };
            MultipleLinearRegression mlr = new MultipleLinearRegression(inputTrain.GetLength(1), 0.5d);
            mlr.Training(inputTrain, outputTrain);
            Console.WriteLine("Multiple Linear Regression");
            Console.WriteLine("Result: " + Math.Round(mlr.Run(new[] { 2.6d, 2.1d }), 2));
            Console.WriteLine("--------------------------");

            #endregion

            #region Perceptron

            Console.WriteLine("Perceptron");

            #region AND Gate
            double[,] inputAnd = new double[,] { { 1, 0 }, { 1, 1 }, { 0, 1 }, { 0, 0 } };
            int[] outputAnd = new int[] { 0, 1, 0, 0 };

            Perceptron p1 = new Perceptron();
            p1.Training(inputAnd, outputAnd);
            
            Console.WriteLine("AND Gate");
            Console.WriteLine("Iteration of training: " + p1.Iteration);
            Console.WriteLine("Test 1: " + p1.Run(new double[,] { { 1, 0 } }));
            Console.WriteLine("Test 2: " + p1.Run(new double[,] { { 1, 1 } }));
            #endregion

            #region OR Gate
            double[,] inputOr = new double[,] { { 1, 0 }, { 1, 1 }, { 0, 1 }, { 0, 0 } };
            int[] outputOr = new int[] { 1, 1, 1, 0 };

            Perceptron p2 = new Perceptron();
            p2.Training(inputOr, outputOr);
            Console.WriteLine("OR Gate");
            Console.WriteLine("Iteration of training: " + p2.Iteration);
            Console.WriteLine("Test 1: " + p2.Run(new double[,] { { 0, 1 } }));
            Console.WriteLine("Test 2: " + p2.Run(new double[,] { { 0, 0 } }));
            #endregion
            
            Console.WriteLine("--------------------------");

            #endregion

            #region Multilayer Parceptron
            Console.WriteLine("Multilayer Parceptron");
            MultilayerPerceptron mlp = new MultilayerPerceptron(2, 5, 1);
            mlp.Training(new double[,] { { 1, 1 }, { 1, 0 }, { 0, 0 }, { 0, 1 } }, new double[] { 1, 1, 0, 1 });
            Console.WriteLine("OR Gate: " + Math.Round(mlp.Run(new double[] { 0, 1 }).FirstOrDefault(), 1));
            Console.WriteLine("--------------------------");
            #endregion

            Console.ReadKey();
        }
    }
}
