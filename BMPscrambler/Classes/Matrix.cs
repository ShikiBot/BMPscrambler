using System;

namespace BMPscrambler.Classes
{
    class Matrix
    {
        private int[,] array;
        readonly int row, column, length;

        public int Row { get { return row; } }
        public int Column { get { return column; } }
        public int Length { get { return length; } }
        public int[,] Array { get { return array; } set { array = Array; } }


        public Matrix(int row, int column)
        {
            this.row = row;
            this.column = column;
            length = row * column;
            array = new int[row, column];
        }

        public Matrix(int[,] matrix)
        {
            row = matrix.GetLength(0);
            column = matrix.GetLength(1);
            length = matrix.Length;
            array = matrix;
        }

        public bool IsIdentityMatrix()
        {
            if (array == null || column != row) return false;
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                    if ((i != j && array[i, j] != 0) || (i == j && array[i, j] != 1))
                        return false;
            return true;
        }

        public int[] ToInt32()
        {
            int[] ret = new int[Column * Row];
            for (int i = 0; i < Column; i++)
                for (int j = 0; j < Row; j++)
                    ret[i * Column + j] = Array[i, j];
            return ret;
        }

        public int[,] GetArray(int start, int len)
        {
            int[,] arr = new int[1, len];
            for (int i = 0; i < len; i++)
                arr[0, i] = Array[((start + i) / Column) % Column, (start + i) % Column];
            return arr;
        }

        public void SetArray(Matrix matrix, int start)
        {
            for (int i = 0; i < matrix.Column; i++)
                array[start / Column, (start + i) % Column] = matrix.Array[0, i];
        }

        public Matrix Transpose()
        {
            Matrix m = new Matrix(column, row);
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                    m.array[j, i] = array[i, j];
            return m;
        }

        public Matrix Inverse()
        {
            int det = Determinant();
            if (det == 0) throw new Exception("Матрица вырождена");
            Matrix m = new Matrix(row, column);
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                    m.array[i, j] = Cofactor(array, i, j);
            return m;
        }

        public Matrix InverseByMod(int revDet, int abc)
        {
            int det = Determinant();
            if (det == 0) throw new Exception("Матрица вырождена");
            Matrix m = this.Inverse();
            m %= abc;
            m *= revDet;
            m %= abc;
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                    m.array[i, j] = m.array[i, j] < 0 ? abc + m.array[i, j] : m.array[i, j];
            return m.Transpose();
        }

        public int Determinant()
        {
            if (column != row) throw new Exception("Расчет определителя невозможен");
            return DetGaus(array);
        }

        private int DetGaus(int[,] c)
        {
            double det = 1;
            const double EPS = 1E-9;
            int n = c.GetLength(0);
            int[,] a = (int[,])c.Clone();
            for (int i = 0; i < n; ++i)
            {
                int k = i;
                for (int j = i + 1; j < n; ++j)
                    if (Math.Abs(a[j, i]) > Math.Abs(a[k, i]))
                        k = j;
                if (Math.Abs(a[k, i]) < EPS)
                {
                    det = 0;
                    break;
                }
                for (int x = 0; x < n; x++)
                {
                    int buf = a[i, x];
                    a[i, x] = a[k, x];
                    a[k, x] = buf;
                }
                if (i != k) det = -det;
                det *= a[i, i];
                for (int j = i + 1; j < n; ++j)
                    a[i, j] /= a[i, i];
                for (int j = 0; j < n; ++j)
                    if ((j != i) && (Math.Abs(a[j, i]) > EPS))
                        for (k = i + 1; k < n; ++k)
                            a[j, k] -= a[i, k] * a[j, i];
            }
            return (int)Math.Round(det);
        }

        public int Cofactor(int[,] array, int row, int column)
        {
            return Convert.ToInt32(Math.Pow(-1, column + row)) * DetGaus(Minor(array, row, column));
        }

        public int[,] Minor(int[,] array, int row, int column)
        {
            int n = (int)Math.Sqrt(array.Length);
            int[,] minor = new int[n - 1, n - 1];
            int _i = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == row) continue;
                int _j = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == column) continue;
                    minor[_i, _j] = array[i, j];
                    _j++;
                }
                _i++;
            }
            return minor;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.column != m2.row) throw new Exception("Умножение невозможно");
            Matrix m = new Matrix(m1.row, m2.column);
            for (int i = 0; i < m1.row; i++)
            {
                for (int j = 0; j < m2.column; j++)
                {
                    m.array[i, j] = 0;
                    for (int k = 0; k < m1.column; k++)
                        m.array[i, j] += m1.array[i, k] * m2.array[k, j];
                }
            }
            return m;
        }

        public static Matrix operator %(Matrix m1, int mod)
        {
            Matrix m = new Matrix(m1.row, m1.column);
            for (int i = 0; i < m1.row; i++)
                for (int j = 0; j < m1.column; j++)
                    m.array[i, j] = (int)m1.array[i, j] % mod;
            return m;
        }

        public static Matrix operator *(Matrix m1, int a)
        {
            Matrix m = new Matrix(m1.row, m1.column);
            for (int i = 0; i < m1.row; i++)
                for (int j = 0; j < m1.column; j++)
                    m.array[i, j] = (int)m1.array[i, j] * a;
            return m;
        }
    }
}
