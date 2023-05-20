
namespace WorkshopIEnumerables.Logic
{
    public class HourGlass
    {
        public static void GenerateMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = i + 2 * j;
                }
            }
        }

        public static string ShowMatrix(int[,] matrix, int n)
        {
            var output = String.Empty;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    output += matrix[i, j] + "\t";
                }
                output += "\n";
            }
            return output;
        }

        public static void GenerateOtherMatrix(int[,] matrix, int[,] hourglassmatrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    hourglassmatrix[i, j] = -1;
                }
            }

            int medium = n / 2 + 1;
            for (int i = 0; i < medium; i++)
            {
                for (int j = i; j < n - i; j++)
                {
                    hourglassmatrix[i, j] = matrix[i, j];
                    hourglassmatrix[n - i - 1, j] = matrix[n - i - 1, j];
                }
            }
        }

        public static string ShowOtherMatrix(int[,] hourglassmatrix, int n)
        {
            var output = String.Empty;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (hourglassmatrix[i, j] == -1)
                    {
                        output += "\t";
                    }
                    else
                    {
                        output += hourglassmatrix[i, j] + "\t";
                    }
                }
                output += "\n";
            }
            return output;
        }
    }
}
