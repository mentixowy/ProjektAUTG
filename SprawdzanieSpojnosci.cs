namespace Grafy
{
    public class SprawdzanieSpojnosci
    {
        private int[] spojnosc;
        
        public bool sprawdzSpojnosc(int ile,int [,] VertexMatrix)
        {
            spojnosc   = new int[ile];
            for (int i = 0; i < ile; i++)
            {
                spojnosc[i] = 0;
            }
            for (int i = 0; i < ile; i++)
            {
                for (int j = 0; j < ile; j++)
                {
                    if(VertexMatrix[i, j] == 1)
                    {
                        spojnosc[j] = 1;
                    }
                }
            }
            bool czySpojny = true;
            for (int i = 0; i < spojnosc.Length; i++)
            {
                if (spojnosc[i] == 0) czySpojny = false;
            }

            return czySpojny;
        }
    }
}