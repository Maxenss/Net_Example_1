using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_Example_1
{
    class Matrix
    {
        #region Поля
        readonly int N;
        private double[,] matrix;
        #endregion

        #region Конструкторы
        public Matrix(int N)
        {
            matrix = new double[N, N];
            this.N = N;
        }

        public Matrix(double[,] matrix)
        {
            this.matrix = (double[,])matrix.Clone();
            N = matrix.GetLength(0);
        }

        public Matrix()
        {
        }
        #endregion

        #region Деструктор
        ~Matrix()
        {
            Console.WriteLine("Было весело :)");
        }
        #endregion

        #region Методы
        // Метод для вывода матрицы
        public void Show()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        // Метод для проверки, является ли матрица единичной
        public bool IsIdentity()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] != 1) return false;
                }
            }
            return true;
        }

        // Метод для изменения элемента матрицы
        public bool setMatrixElement(int row, int column, double var)
        {
            if (row >= this.N || column >= this.N) return false;

            matrix[row, column] = var;
            return true;
        }

        // Метод для получения элемента матрицы
        public double getMatrixElement(int row, int column)
        {
            return matrix[row, column];
        }

        // Метод для умножения матрицы на число
        public static Matrix MatrixMultiple(Matrix a, double num)
        {
            Matrix resMatrix = new Matrix(a.N);

            for (int i = 0; i < resMatrix.N; i++)
            {
                for (int j = 0; j < resMatrix.N; j++)
                {
                    resMatrix.matrix[i, j] = a.matrix[i, j] * num;
                }
            }
            return resMatrix;
        }

        // Метод для проверки, явл. ли матрица обратная
        public static bool IsInverseMatrix(Matrix a, Matrix b)
        {
            a = a * b;

            for (int i = 0; i < a.N; i++)
            {
                if (a.matrix[i, i] != 1) return false;

                for (int j = 0; j < a.N; j++)
                {
                    if (i == j) continue;

                    if (a.matrix[i, j] != 0)
                        return false;
                }
            }

            return true;
        }
        #endregion

        #region Перегрузки операторов
        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix resMatrix = new Matrix(a.N);

            for (int i = 0; i < resMatrix.N; i++)
            {
                for (int j = 0; j < resMatrix.N; j++)
                {
                    resMatrix.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                }
            }
            return resMatrix;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix resMatrix = new Matrix(a.N);

            for (int i = 0; i < resMatrix.N; i++)
            {
                for (int j = 0; j < resMatrix.N; j++)
                {
                    resMatrix.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                }
            }
            return resMatrix;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix resMatrix = new Matrix(a.N);

            for (int i = 0; i < resMatrix.N; i++)
            {
                for (int j = 0; j < resMatrix.N; j++)
                {
                    for (int r = 0; r < resMatrix.N; r++)
                    {
                        resMatrix.matrix[i, j] += a.matrix[i, r] * b.matrix[r, i];
                    }
                }
            }

            return resMatrix;
        }
        #endregion
    }
}
