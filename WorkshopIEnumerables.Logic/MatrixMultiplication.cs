namespace WorkshopIEnumerables.Logic
{
       public class MatrixMultiplication
       {
            public static void MakeMatrixA(List<List<int>> matrixA, int m, int n)
            {
                for (int i = 0; i < m; i++)
                {
                    matrixA.Add(new List<int>());
                    for (int j = 0; j < n; j++)
                    {
                        matrixA[i].Add((i + 1) * j);
                    }
                }
            }

            public static void MakeMatrixB(List<List<int>> matrixB, int n, int p)
            {
                for (int i = 0; i < n; i++)
                {
                    matrixB.Add(new List<int>());
                    for (int j = 0; j < p; j++)
                    {
                        matrixB[i].Add((j + 1) * i);
                    }
                }
            }

            public static string ShowMatrix(List<List<int>> matrix, int rows, int columns)
            {
                var output = String.Empty;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        output += matrix[i][j] + " ";
                    }
                    output += "\n";
                }
                return output;
            }

            public static List<List<int>> Multiplication(List<List<int>> matrix1, List<List<int>> matrix2)
            {
                int rows1 = matrix1.Count;
                int cols1 = matrix1[0].Count;
                int rows2 = matrix2.Count;
                int cols2 = matrix2[0].Count;
                if (cols1 != rows2)
                {
                    throw new Exception("Matrices are not compatible for multiplication.");
                }
                List<List<int>> product = new List<List<int>>();
                for (int i = 0; i < rows1; i++)
                {
                    product.Add(new List<int>());
                    for (int j = 0; j < cols2; j++)
                    {
                        product[i].Add(0);
                        for (int k = 0; k < cols1; k++)
                        {
                            product[i][j] += matrix1[i][k] * matrix2[k][j];
                        }
                    }
                }
                return product;
            }
       }
}