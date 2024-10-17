namespace Lib_14
{
    public class ClassSumUnder8
    {
        /// <summary>
        /// ����� ��� ������������ ��������� ������� � �������� ��������� ������� ������ 8 
        /// </summary>
        /// <param name="array"> ������ ����� �������� �� ��������� </param>
        /// <returns></returns>
        public static int SumUnder8(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j] < 8)
                    {
                        sum += array[i, j];
                    }
            }
            return sum;
        }
    }
}

