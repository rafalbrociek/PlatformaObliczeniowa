using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformaObliczeniowa.CzytanieDanychZPliku
{
    public static class CzytajDaneUkladuRownan
    {
        /// <summary>
        /// Funkcja zwraca macierz prostokątną (współczynników układu równań)
        /// czytając macierz z pliku. Zakładamy odpowiedni format danych tzn.
        /// a11 a12 a13
        /// a21 a22 a23
        /// a31 a32 a33
        /// w przypadku, gdy odczyt się nie powiedzie funkcja zwraca null.
        /// Zakładamy ponadto, że liczby ułamkowe jako separatora używają kropki
        /// </summary>
        /// <param name="sciezkaDoPliku">ścieżka do pliku txt z danymi</param>
        /// <returns></returns>
        public static double[,] CzytajMacierzA(string sciezkaDoPliku)
        {
            List<string> wiersze = new List<string>();
            int liczbaWierszy = 0;
            int liczbaKolumn = 0;
            double[,] macierzA;

            // przeliczenie ile jest wierszy w pliku (liczba równań)
            // oraz zapisanie kolejnych wierszy w liście wiersze
            try
            {
                var fileStream = new FileStream(sciezkaDoPliku, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string wiersz;
                    while ((wiersz = streamReader.ReadLine()) != null)
                    {
                        // sprawdzamy, ile w danym wierszu jest liczb
                        string[] elementyWWierszu = wiersz.Split(' ');
                        // jako liczbę kolumn (niewaidomych) przyjmujemy liczbę elementów w najdłuższym wierszu
                        if (elementyWWierszu.Length > liczbaKolumn)
                            liczbaKolumn = elementyWWierszu.Length;
                        wiersze.Add(wiersz);
                        liczbaWierszy++;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            

            macierzA = new double[liczbaWierszy, liczbaKolumn];

            // wpisanie odpowiednich wartości do macierzyA
            for(int i=0; i<liczbaWierszy; i++)
            {
                string[] wiersz = wiersze[i].Split(' ');
                for (int j = 0; j < wiersz.Length; j++)
                    double.TryParse(wiersz[j], NumberStyles.Number, CultureInfo.InvariantCulture, out macierzA[i, j]);
            }

            return macierzA;
        }

        /// <summary>
        /// Funkcja zwraca wektor wyrazów wolnych układu równań
        /// czytając wektor z pliku. Zakładamy odpowiedni format danych tzn.
        /// b1
        /// b2
        /// b3
        /// w przypadku, gdy odczyt się nie powiedzie funkcja zwraca null.
        /// Zakładamy ponadto, że liczby ułamkowe jako separatora używają kropki
        /// </summary>
        /// <param name="sciezkaDoPliku">ścieżka do pliku txt z danymi</param>
        /// <returns></returns>
        public static double[] czytajWektorB(string sciezkaDoPliku)
        {
            List<string> wiersze = new List<string>();
            double[] wektorB;
            int liczbaWierszy = 0;

            // przeliczenie ile jest wierszy w pliku (liczba równań)
            // oraz zapisanie kolejnych wierszy w liście wiersze
            try
            {
                var fileStream = new FileStream(sciezkaDoPliku, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string wiersz;
                    while ((wiersz = streamReader.ReadLine()) != null)
                    {
                        wiersze.Add(wiersz);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            liczbaWierszy = wiersze.Count;
            wektorB = new double[liczbaWierszy];

            // wpisanie odpowiednich wartości do wektorB
            for (int i = 0; i < liczbaWierszy; i++)
            {
                double.TryParse(wiersze[i], NumberStyles.Number, CultureInfo.InvariantCulture, out wektorB[i]);
            }

            return wektorB;
        }
    }
}
