using Microsoft.Win32;
using PlatformaObliczeniowa.CzytanieDanychZPliku;
using PlatformaObliczeniowa.UkladyRownan;
using PlatformaObliczeniowa.ViewModele.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformaObliczeniowa.ViewModele
{
    /// <summary>
    /// Klasa ViewModelu dla widoku metody rozwiązywania
    /// układu równań metodą eliminacji Gaussa
    /// </summary>
    class VM_MetodaEliminacjiGaussa : BaseViewModel
    {
        private MetodaEliminacjiGaussa ukladRownan;

        public VM_MetodaEliminacjiGaussa()
        { }

        #region Polecenia

        // Polecenia będziemy pisać według schematu:
        // 1. prywatne pole typu RelayCommand
        // 2. publiczna właściwość typu RelayCommand 
        //    udostępniająca odpowiednie pole (patrz punkt 1),
        //    wewnątz geta tworzymy odpowiedni obiekt
        //    na podstawie odpowiedniej metody (patrz punkt 3)
        // 3. definicja metody uruchamianej w poleceniu



        private RelayCommand wczytajMacierzAZPliku;
        public RelayCommand WczytajMacierzAZPliku
        {
            get
            {
                if(wczytajMacierzAZPliku == null)
                {
                    wczytajMacierzAZPliku = new RelayCommand(arg => { pobierzMacierzAZPliku(); }, arg => true);
                }
                return wczytajMacierzAZPliku;
            }
        }

        private void pobierzMacierzAZPliku()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                if (ukladRownan == null)
                {
                    string nazwaPliku = openFileDialog.FileName;
                    // W przypadku, gdy w pliku zapisana jest macierz prostokątna,
                    // wówczas w układzie równań tworzona jest macierz kwadratowa
                    // (wymagania metody) wymiaru max(lbWierszy, lbKolumn).
                    // Nie podane elementy traktowane będą jako zera.
                    int rozmiarUkladu = Math.Max(CzytajDaneUkladuRownan.CzytajMacierzA(nazwaPliku).GetLength(0),
                        CzytajDaneUkladuRownan.CzytajMacierzA(nazwaPliku).GetLength(1));
                    ukladRownan = new MetodaEliminacjiGaussa(rozmiarUkladu);
                    ukladRownan.PobierzA(CzytajDaneUkladuRownan.CzytajMacierzA(nazwaPliku));
                    Console.WriteLine("dddd");
                }
                else
                {
                    //TODO: usunąć niepotrzebne tablice A,b. Zmienić rozmiar układu, wczytać macierzA.
                }
            }
        }

        #endregion
    }
}
