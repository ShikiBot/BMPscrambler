using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMPscrambler.Classes
{
    public class Matrix
    {

        long[,] array;
        readonly int row, column, length;

        public int Row { get { return row; } }
        public int Column { get { return column; } }
        public int Length { get { return length; } }
        public long[,] Array { get { return array; } set { array = Array; } }


        public Matrix(int row, int column)
        {
            this.row = row;
            this.column = column;
            length = row * column;
            array = new long[row, column];
        }        

        public Matrix(long[,] matrix)
        {
            row = matrix.GetLength(0);
            column = matrix.GetLength(1);
            length = matrix.Length;
            array = matrix;
        }

        public Matrix(long[] matrix, int column)
        {
            row = matrix.Length % column == 0 ? matrix.Length / column : (matrix.Length + (column - matrix.Length % column)) / column;

            this.column = column;
            length = matrix.Length;
            array = new long[row, column];
            for (int i = 0; i < length; i++)
                array[i / column, i % column] = matrix[i];
        }

        ~Matrix() { }

        public bool IsIdentityMatrix()
        {
            if (array == null || column != row)
                return false;
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                    if ((i != j && array[i, j] != 0) || (i == j && array[i, j] != 1))
                        return false;
            return true;
        }

        public long[] GetRow(int row)
        {
            if (this.row <= row)
                throw new ArgumentException();

            long[] row_res = new long[column];
            for (int i = 0; i < column; i++)
            {
                row_res[i] = array[row, i];
            }

            return row_res;
        }

        public void SetRow(Matrix matrix, int row)
        {
            if (this.row <= row)
                throw new ArgumentException();

            for (int i = 0; i < column; i++)
            {
                array[row, i] = matrix.GetRow(0) [i];
            }
        }

        public Matrix Transpose()
        {
            Matrix m = new Matrix(column, row);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    m.array[j, i] = array[i, j];
                }
            }
            return m;
        }

        public void TransposeMyself()
        {
            Array = Transpose().array;
        }

        public Matrix Inverse()
        {
            long det = Determinant();
            if (det == 0)
            {
                throw new Exception("Матрица вырождена");
            }

            Matrix m = new Matrix(row, column);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    m.array[i, j] = Cofactor(array, i, j);
                }
            }

            return m;
        }

        public Matrix InverseByMod(long revDet, long abc)
        {
            long det = Determinant();
            if (det == 0)
            {
                throw new Exception("Матрица вырождена");
            }

            Matrix m = this.Inverse();

            m %= abc;
            m *= revDet;
            m %= abc;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    m.array[i, j] = m.array[i, j] < 0 ? abc + m.array[i, j] : m.array[i, j];
                }
            }
            return m.Transpose();
        }

        public long Determinant()
        {
            if (column != row)
            {
                throw new Exception("Расчет определителя невозможен");
            }
            return Determinant(array);
        }

        private long Determinant(long[,] array)
        {
            int n = (int)Math.Sqrt(array.Length);

            if (n == 1)
            {
                return array[0, 0];
            }

            long det = 0;

            for (int k = 0; k < n; k++)
            {
                det += array[0, k] * Cofactor(array, 0, k);
            }

            return det;
        }

        public long Cofactor(long[,] array, int row, int column)
        {
            return Convert.ToInt32(Math.Pow(-1, column + row)) * Determinant(Minor(array, row, column));
        }

        public long[,] Minor(long[,] array, int row, int column)
        {
            int n = (int)Math.Sqrt(array.Length);
            long[,] minor = new long[n - 1, n - 1];

            int _i = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == row)
                {
                    continue;
                }
                int _j = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == column)
                    {
                        continue;
                    }
                    minor[_i, _j] = array[i, j];
                    _j++;
                }
                _i++;
            }
            return minor;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.row != m2.row || m1.column != m2.column)
            {
                throw new Exception("Сложение невозможно");
            }

            Matrix m = new Matrix(m1.row, m1.column);

            for (int i = 0; i < m1.row; i++)
            {
                for (int j = 0; j < m1.column; j++)
                {
                    m.array[i, j] = m1.array[i, j] + m2.array[i, j];
                }
            }

            return m;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.row != m2.row || m1.column != m2.column)
            {
                throw new Exception("Вычитание невозможно");
            }

            Matrix m = new Matrix(m1.row, m1.column);

            for (int i = 0; i < m1.row; i++)
            {
                for (int j = 0; j < m1.column; j++)
                {
                    m.array[i, j] = m1.array[i, j] - m2.array[i, j];
                }
            }

            return m;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.column != m2.row)
            {
                throw new Exception("Умножение невозможно");
            }

            Matrix m = new Matrix(m1.row, m2.column);

            for (int i = 0; i < m1.row; i++)
            {
                for (int j = 0; j < m2.column; j++)
                {
                    m.array[i, j] = 0;

                    for (int k = 0; k < m1.column; k++)
                    {
                        m.array[i, j] += m1.array[i, k] * m2.array[k, j];
                    }
                }
            }

            return m;
        }

        public static Matrix operator %(Matrix m1, long mod)
        {
            Matrix m = new Matrix(m1.row, m1.column);

            for (int i = 0; i < m1.row; i++)
            {
                for (int j = 0; j < m1.column; j++)
                {
                    m.array[i, j] = (int)m1.array[i, j] % mod;
                }
            }

            return m;
        }

        public static Matrix operator *(Matrix m1, long a)
        {
            Matrix m = new Matrix(m1.row, m1.column);

            for (int i = 0; i < m1.row; i++)
            {
                for (int j = 0; j < m1.column; j++)
                {
                    m.array[i, j] = (int)m1.array[i, j] * a;
                }
            }

            return m;
        }

        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    str += array[i, j] + "\t";
                }
                str += "\n";
            }

            return str;
        }
    }
}
