using System;
using System.Collections.Generic;
using System.Linq;

namespace MachineLearning.Technics
{
    public class MultipleAttributeValueTheory
    {
        private const double Euler = 2.718281828;
        private readonly double _alpha;
        private readonly List<Attribute> _listAttr;

        public MultipleAttributeValueTheory(double[,] values, double alpha = 0.5)
        {
            _alpha = alpha;
            _listAttr = new List<Attribute>();
            int totalAttrs = values.Length / values.GetLength(1);
            for (int i = 0; i < totalAttrs; i++)
            {
                double[] valuesAttr = new double[values.GetLength(1)];
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    valuesAttr[j] = values[i, j];
                }
                Attribute attr = new Attribute();
                attr.SetValueAttribute(valuesAttr);
                attr.SetMainAttribute(0);
                _listAttr.Add(attr);
            }
            SetFactors();
        }

        public double Preference()
        {
            double sum = 0;
            foreach (var attr in _listAttr)
            {
                switch (attr.FunctionAttr)
                {
                    case Function.Linear:
                        sum += MeanNormalizationLinear(attr) * attr.Factor;
                        break;
                    case Function.Exponential:
                        sum += MeanNormalizationQuadratic(MeanNormalizationLinear(attr)) * attr.Factor;
                        break;
                    default:
                        sum += MeanNormalizationLinear(attr) * attr.Factor;
                        break;
                }
            }
            return sum;
        }

        public void SetMainAttribute(int[] indexs)
        {
            for (int i = 0; i < _listAttr.Count; i++)
                _listAttr[i].SetMainAttribute(indexs[i] - 1);
        }

        public void SetFunctions(Function[] function)
        {
            for (int i = 0; i < _listAttr.Count; i++)
                _listAttr[i].FunctionAttr = function[i];
        }

        public double[] GetValuesAttributes()
        {
            var listValues = new List<double>();
            _listAttr.ForEach(k => listValues.Add(k.Value));
            return listValues.ToArray();
        }

        private void SetFactors()
        {
            var maxValue = _listAttr.Select(k => k.GetAllValues().Max()).Max();
            foreach (Attribute attr in _listAttr)
                attr.Factor = attr.GetAllValues().Max()/maxValue;
        }

        private double MeanNormalizationLinear(Attribute attribute)
        {
            return (attribute.Value - attribute.MinValue) / (attribute.MaxValue - attribute.MinValue);
        }

        private double MeanNormalizationQuadratic(double value)
        {
            return (Math.Pow(Euler, _alpha * value) - 1) / (Math.Pow(Euler, _alpha) - 1);
        }
    }

    public class Attribute
    {
        private List<double> _values;
        public Function FunctionAttr { get; set; }
        public double Factor { get; set; }
        public double Value { get; private set; }
        public double MaxValue { get; private set; }
        public double MinValue { get; private set; }

        public Attribute(int amount = 3)
        {
            _values = new List<double>();
            Random r = new Random();
            for (int i = 0; i < amount; i++)
                _values.Add(r.NextDouble());

            Value = _values[0];
            
            System.Threading.Thread.Sleep(100);
        }

        public void SetMainAttribute(int index)
        {
            Value = _values[index];
        }

        public void SetValueAttribute(double[] values)
        {
            for (int i = 0; i < _values.Count; i++)
                _values[i] = values[i];

            Value = _values[0];
            MaxValue = _values.Max();
            MinValue = _values.Min();
        }

        public List<double> GetAllValues()
        {
            return _values;
        }
    }

    public enum Function
    {
        Linear,
        Exponential
    }
}
