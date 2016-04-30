using System;
using System.Collections.Generic;
using System.Linq;

namespace MachineLearning.Technics
{
    public class MultipleAttributeValueTheory
    {
        public List<Attribute> Attributes { get; set; }

        public MultipleAttributeValueTheory()
        {
            Attributes = new List<Attribute>();
        }

        public MultipleAttributeValueTheory(double[,] attributes)
        {
            Attributes = new List<Attribute>();
            int totalAttrs = attributes.Length / attributes.GetLength(1);
            for (int i = 0; i < totalAttrs; i++)
            {
                double[] valuesAttr = new double[attributes.GetLength(1)];
                for (int j = 0; j < attributes.GetLength(1); j++)
                {
                    valuesAttr[j] = attributes[i, j];
                }
                Attribute attr = new Attribute(valuesAttr.Length);
                attr.SetValueAttribute(valuesAttr);
                Attributes.Add(attr);
            }
            SetFactor();
        }

        private void SetFactor()
        {
            if (Attributes.Any())
            {
                var maxValue = Attributes.Sum(k => k.GetAllValues().Max());
                foreach (Attribute attr in Attributes)
                    attr.Factor = attr.GetAllValues().Max() / maxValue;
            }
            else
                throw new Exception();
        }

        public double[] Preference()
        {
            if (Attributes.Any())
            {
                int amount = Attributes[0].GetAllValues().Count;
                double[] result = new double[Attributes.First().GetAllValues().Count];
                for (int i = 0; i < amount; i++)
                    result[i] = Attributes.Sum(t => t.GetValue(i) * t.Factor);

                return result;
            }
            else
                return null;
        }
    }

    public class Attribute
    {
        private readonly List<double> _values;
        public double Factor { get; set; }
        public double MaxValue { get; private set; }
        public double MinValue { get; private set; }

        public Attribute(int amount = 4)
        {
            _values = new List<double>();
            Random r = new Random();
            for (int i = 0; i < amount; i++)
                _values.Add(r.NextDouble());
        }

        public void SetValueAttribute(double[] values)
        {
            for (int i = 0; i < _values.Count; i++)
                _values[i] = values[i];

            MaxValue = _values.Max();
            MinValue = _values.Min();
        }

        public List<double> GetAllValues()
        {
            return _values;
        }

        public double GetValue(int index)
        {
            return _values[index];
        }
    }
}
