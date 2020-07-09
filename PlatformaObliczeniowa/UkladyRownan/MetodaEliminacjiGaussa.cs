using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformaObliczeniowa.UkladyRownan
{
    // założenia: 
    // * liczba równań jest równa liczbie niewiadomych
    // * układ równań posiada dokładnie jedno rozwiązanie => detA != 0
    class MetodaEliminacjiGaussa : IMetodaRozwiazywaniaUkladuRownan
    {
        #region Pola

        private int liczbaRownan;
        private int liczbaNiewiadomych;
        private double[,] macierzA;
        private double[] wektorB;
        private double[] wektorRozwiazanX;
        private bool czyUkladJestOznaczony = false;

        #endregion

        #region Konstruktor

        public MetodaEliminacjiGaussa(int n)
        {
            liczbaNiewiadomych = n;
            liczbaRownan = n;
            macierzA = new double[n, n];
            wektorB = new double[n];
            wektorRozwiazanX = new double[n];
        }

        public MetodaEliminacjiGaussa(int n, double[,] A, double[] b) : this(n)
        {
            for (int i = 0; i < n; i++)
            {
                wektorB[i] = b[i];
                for (int j = 0; j < n; j++)
                    macierzA[i, j] = A[i, j];
            }
        }

        #endregion

        #region Implementacja interfejsu IMetodaRozwiazywaniaUkladuRownan

        public void PobierzA(double[,] A)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                    macierzA[i, j] = A[i, j];
            }
        }

        public void PobierzB(double[] b)
        {
            for (int i = 0; i < liczbaRownan; i++)
                wektorB[i] = b[i];
        }

        public void RozwiazUklad()
        {
            //TODO: implementacja rozwiązania
            throw new NotImplementedException();
        }

        public double[] ZwrocX()
        {
            return wektorRozwiazanX;
        }

        public string WypiszX()
        {
            StringBuilder wynik = new StringBuilder("[ ");
            for (int i = 0; i < liczbaNiewiadomych; i++)
            {
                wynik.Append(wektorRozwiazanX[i]);
                wynik.Append(" ");
            }
            wynik.Append("]");
            return wynik.ToString();
        }

        #endregion

        #region Metody pomocnicze

        private void doprowadzUkladDoPostaciTrojkatnej()
        { 
            //TODO: Implementacja eliminacji Gaussa
        }

        private bool sprawdzZalozeniaUkladu()
        { 
            //TODO: sprawdzenie warunku detA != 0 
            return false; 
        }

        #endregion
    }
}
