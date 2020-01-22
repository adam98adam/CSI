﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSI
{
    class Vector
    {
        private double[] fields;

        public int Length;

        public Vector(int size)
        {
            this.fields = new double[size];
            this.Length = size;
        }

        public Vector(double[] array)
        {
            this.fields = array;
            this.Length = fields.Length;
        }

        public double this[int row]
        {
            get => GetValue(row);
            set => SetValue(row, value);
        }

        private double GetValue(int row)
        {
            return fields[row];
        }

        private void SetValue(int row, double value)
        {
            fields[row] = value;
        }

        public static Vector operator +(Vector a) => a;

        public static Vector operator -(Vector a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = -a[i];
            }
            return a;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            if (a.Length != b.Length)
            {
                throw new System.ArgumentException("Próba dodania wektorów o różnych rozmiarach");
            }
            Vector c = new Vector(a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                c[i] = a[i] + b[i];
            }
            return c;
        }

        public static Vector operator -(Vector a, Vector b) => a + (-b);

        public void Abs()
        {
            for (int i = 0; i < Length; i++)
            {
                this[i] = Math.Abs(this[i]);
            }
        }

        public double GetNorm()
        {
            double sum = 0;
            for (int i = 0; i < this.Length; i++)
            {
                sum += Math.Pow(this[i], 2);
            }
            return Math.Sqrt(sum);
        }

        public void SwapRows(int rowOne, int rowTwo)
        {
            double temp = this[rowOne];
            this[rowOne] = this[rowTwo];
            this[rowTwo] = temp;
        }

        public void CopyValuesFrom(Vector other)
        {
            for (int i = 0; i < other.Length; i++)
            {
                this[i] = other[i];
            }
        }

        public override string ToString()
        {
            string vectorString = "[";
            foreach (var value in this.fields)
            {
                vectorString += Math.Round(value, 3) + ", ";
            }
            vectorString += "\b\b]\n";

            return vectorString;
        }

        public Vector Clone()
        {
            Vector clone = new Vector(Length);
            for (int i = 0; i < Length; i++)
            {
                clone[i] = this[i];
            }
            return clone;
        }
    }
}
