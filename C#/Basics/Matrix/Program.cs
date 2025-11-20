using System;
//using Maths.Class;

namespace Maths.Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== MATRIX OPERATIONS MENU =====");
                Console.WriteLine("1. Add Two Matrices");
                Console.WriteLine("2. Subtract Two Matrices");
                Console.WriteLine("3. Multiply Two Matrices");
                Console.WriteLine("4. Transpose a Matrix");
                Console.WriteLine("5. Scalar Multiply");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine() ?? "0");

                switch (choice)
                {
                    case 1:
                        AddMatrices();
                        break;

                    case 2:
                        SubtractMatrices();
                        break;

                    case 3:
                        MultiplyMatrices();
                        break;

                    case 4:
                        TransposeMatrix();
                        break;

                    case 5:
                        ScalarMultiply();
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        // -----------------------------
        // FUNCTIONS FOR SWITCH OPTIONS
        // -----------------------------

        static void AddMatrices()
        {
            Console.WriteLine("\nEnter size of matrices:");
            Console.Write("Rows: ");
            int r = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Cols: ");
            int c = int.Parse(Console.ReadLine() ?? "0");

            Matrix A = new Matrix(r, c);
            Matrix B = new Matrix(r, c);

            Console.WriteLine("\nEnter Matrix A:");
            A.FillFromInput();

            Console.WriteLine("\nEnter Matrix B:");
            B.FillFromInput();

            Matrix result = Matrix.Add(A, B);

            Console.WriteLine("\n--- Result (A + B) ---");
            result.Print();
        }

        static void SubtractMatrices()
        {
            Console.WriteLine("\nEnter size of matrices:");
            Console.Write("Rows: ");
            int r = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Cols: ");
            int c = int.Parse(Console.ReadLine() ?? "0");

            Matrix A = new Matrix(r, c);
            Matrix B = new Matrix(r, c);

            Console.WriteLine("\nEnter Matrix A:");
            A.FillFromInput();

            Console.WriteLine("\nEnter Matrix B:");
            B.FillFromInput();

            Matrix result = Matrix.Subtract(A, B);

            Console.WriteLine("\n--- Result (A - B) ---");
            result.Print();
        }

        static void MultiplyMatrices()
        {
            Console.WriteLine("\nEnter size of Matrix A:");
            Console.Write("Rows: ");
            int r1 = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Cols: ");
            int c1 = int.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("\nEnter size of Matrix B:");
            Console.Write("Rows: ");
            int r2 = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Cols: ");
            int c2 = int.Parse(Console.ReadLine() ?? "0");

            Matrix A = new Matrix(r1, c1);
            Matrix B = new Matrix(r2, c2);

            Console.WriteLine("\nEnter Matrix A:");
            A.FillFromInput();

            Console.WriteLine("\nEnter Matrix B:");
            B.FillFromInput();

            Matrix result = Matrix.Multiply(A, B);

            Console.WriteLine("\n--- Result (A × B) ---");
            result.Print();
        }

        static void TransposeMatrix()
        {
            Console.WriteLine("\nEnter size of Matrix:");
            Console.Write("Rows: ");
            int r = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Cols: ");
            int c = int.Parse(Console.ReadLine() ?? "0");

            Matrix A = new Matrix(r, c);
            Console.WriteLine("\nEnter Matrix:");
            A.FillFromInput();

            Matrix result = A.Transpose();

            Console.WriteLine("\n--- Transpose ---");
            result.Print();
        }

        static void ScalarMultiply()
        {
            Console.WriteLine("\nEnter size of matrix:");
            Console.Write("Rows: ");
            int r = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Cols: ");
            int c = int.Parse(Console.ReadLine() ?? "0");

            Matrix A = new Matrix(r, c);
            Console.WriteLine("\nEnter Matrix:");
            A.FillFromInput();

            Console.Write("\nEnter scalar value: ");
            double s = double.Parse(Console.ReadLine() ?? "1");

            Matrix result = A.MultiplyByScalar(s);

            Console.WriteLine("\n--- Result (Scalar × Matrix) ---");
            result.Print();
        }
    }
}

