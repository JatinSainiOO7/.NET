using System;


namespace Maths.Class
{
    public class Matrix
    {
        public int Rows { get; }
        public int Cols { get; }
        public double[,] Data { get; }

        // -------- CONSTRUCTOR --------
        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Data = new double[rows, cols];
        }

        // -------- PRINT MATRIX --------
        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                    Console.Write($"{Data[i, j],6} ");
                Console.WriteLine();
            }
        }

        // -------- FILL MATRIX (USER INPUT) --------
        public void FillFromInput()
        {
            Console.WriteLine("Enter matrix values:");

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write($"[{i},{j}]: ");
                    Data[i, j] = double.Parse(Console.ReadLine() ?? "0");
                }
            }
        }

        // -------- ADD MATRIX --------
        public static Matrix Add(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                throw new ArgumentException("Matrix sizes must match");

            Matrix result = new Matrix(a.Rows, a.Cols);

            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    result.Data[i, j] = a.Data[i, j] + b.Data[i, j];

            return result;
        }

        // -------- SUBTRACT MATRIX --------
        public static Matrix Subtract(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
                throw new ArgumentException("Matrix sizes must match");

            Matrix result = new Matrix(a.Rows, a.Cols);

            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Cols; j++)
                    result.Data[i, j] = a.Data[i, j] - b.Data[i, j];

            return result;
        }

        // -------- MULTIPLY MATRIX --------
        public static Matrix Multiply(Matrix a, Matrix b)
        {
            if (a.Cols != b.Rows)
                throw new ArgumentException("Invalid matrix size for multiplication");

            Matrix result = new Matrix(a.Rows, b.Cols);

            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < b.Cols; j++)
                    for (int k = 0; k < a.Cols; k++)
                        result.Data[i, j] += a.Data[i, k] * b.Data[k, j];

            return result;
        }

        // -------- TRANSPOSE --------
        public Matrix Transpose()
        {
            Matrix t = new Matrix(Cols, Rows);

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    t.Data[j, i] = Data[i, j];

            return t;
        }

        // -------- SCALAR MULTIPLICATION --------
        public Matrix MultiplyByScalar(double s)
        {
            Matrix result = new Matrix(Rows, Cols);

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    result.Data[i, j] = Data[i, j] * s;

            return result;
        }

        // -------- IDENTITY MATRIX --------
        public static Matrix Identity(int size)
        {
            Matrix id = new Matrix(size, size);

            for (int i = 0; i < size; i++)
                id.Data[i, i] = 1;

            return id;
        }
    }
}
