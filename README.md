# Machine Learning
Machine Learning is a subarea of Artificial Intelligence focused on building algorithms that can learn how to make predictions from patterns in information.
This is a project that contains several techniques of data forecast.

### [Linear Regression](https://en.wikipedia.org/wiki/Linear_regression)
```
double[] input = new double[] { -2, -1, 1, 4 };
double[] output = new double[] { -3, -1, 2, 3 };
LinearRegression linearRegression = new LinearRegression();
linearRegression.Training(input, output);
linearRegression.Run(0.5d);
```
### [Multiple Linear Regression](https://en.wikipedia.org/wiki/General_linear_model#Multiple_linear_regression)
```
double[,] inputTrain = { { 2d, 3d }, { 2.5d, 2d }, { 1.8d, 4d } };
double[] outputTrain = { 5d, 6d, 4d };
MultipleLinearRegression mlr = new MultipleLinearRegression(inputTrain.GetLength(1), 0.5d);
mlr.Training(inputTrain, outputTrain);
mlr.Run(new[] { 2.6d, 2.1d });
```
### [Perceptron](https://en.wikipedia.org/wiki/Perceptron)
```
double[,] inputAnd = new double[,] { { 1, 0 }, { 1, 1 }, { 0, 1 }, { 0, 0 } };
int[] outputAnd = new int[] { 0, 1, 0, 0 };
Perceptron p1 = new Perceptron();
p1.Training(inputAnd, outputAnd);
p1.Run(new double[,] { { 1, 0 } });
```
### [Multilayer Perceptron](https://en.wikipedia.org/wiki/Multilayer_perceptron)
The first argument of the constructor represents the total values of the input layer, the second argument represents the total of neorons of the hidden layer, and the last represents the total of the output layer.
```
double[,] inputAnd = new double[,] { { 1, 1 }, { 1, 0 }, { 0, 0 }, { 0, 1 } };
double[] outputAnd = new double[] { 1, 1, 0, 1 };
MultilayerPerceptron mlp = new MultilayerPerceptron(2, 5, 1);
mlp.Training(inputAnd, outputAnd);
mlp.Run(new double[] { 0, 1 });
```
