using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_Example_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] m1 = {
                { 1, 2, 2 },
                { 0, 3, 1 },
                { 1, 0, 0 }
            };
            double[,] m2 = {
                { 0, 0, 1 },
                { -0.25, 0.5, 0.25 },
                { 0.75, -0.5, -0.7 }
            };


            Matrix A = new Matrix(m1);
            Matrix B = new Matrix(m2);
            Matrix D;

            Console.WriteLine("Matrix A :");
            A.Show();
            Console.WriteLine();

            Console.WriteLine("Matrix B :");
            B.Show();
            Console.WriteLine();

            Console.WriteLine("Matrix 3 * A : ");
            D = Matrix.MatrixMultiple(A, 3);
            D.Show();
            Console.WriteLine();

            Console.WriteLine("Matrix 3 * A * B : ");
            D = D * B;
            D.Show();
            Console.WriteLine();

            Console.WriteLine("Matrix (3 * A * B) + (A-B) * A : ");
            D = D + (A - B) * A;
            D.Show();
            Console.WriteLine();

            if (Matrix.IsInverseMatrix(B, A))
                Console.WriteLine("The matrix A is the inverse of the matrix B");
            else
                Console.WriteLine("The matrix A is not the inverse of the matrix B");


            Console.ReadKey();
        }
    }
}
