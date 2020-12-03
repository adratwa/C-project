using System;

namespace Cwiczenia1JD
{
    class Program
    {
       
        static void Zad1()
        {
            //zadanie1
            decimal liczbaDecimal;
            float liczbaFloat;
            Console.Write("Podaj liczbę decimal: ");

            //jak metoda albo właściwość nie jest prywatna to z dużych liter

            string s = Console.ReadLine();
            //dostaje coś i musze to sparsować
            //dekolaruje wczeniej zmienną i potem daje wskaźnik na te zmianna
            decimal.TryParse(s, out liczbaDecimal);

            //drugi sposob (lepszy)
            Console.Write("Podaj liczbę float: ");
            s = Console.ReadLine();
            // dodatkowo try catch
            /*
            try
            {
                liczbaFloat = float.Parse(s);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("zła liczba");
            }
            */
            liczbaFloat = float.Parse(s);
            //int na long short na long moge, ale jesli jest stratna jak 
            //w przypadku ponizej to trzeba rzutować

            double suma = (double)liczbaDecimal + liczbaFloat;

            double iloraz = (double)liczbaDecimal / liczbaFloat;

            Console.WriteLine("Suma = " + Math.Round(suma)); //zamienia sume na string'a
            Console.WriteLine("{0}/{1} = {:F2}", liczbaDecimal, liczbaFloat, iloraz);
        }

        static void zad2()
        {
            uint liczba; //dotatnia liczba calkowita
            Console.WriteLine("Podaj liczbę");
            string s = Console.ReadLine();
            uint.TryParse(s, out liczba);
            int reszta = 0;
            do
            {
                reszta = (int)liczba % 10; //lepiej nie kombinować z typami
                liczba /= 10;
            } while (reszta != 3 || liczba > 0);
            if (reszta == 3)
                Console.WriteLine("Liczba ma cyfre 3");
            else
                Console.WriteLine("liczba nie ma 3");
        }

        static void zad2a()
        {
            uint liczba; //dotatnia liczba calkowita
            Console.WriteLine("Podaj liczbę");
            string s = Console.ReadLine();
            if (s.Contains("3"))
                Console.WriteLine("Liczba ma cyfre 3");
            else
                Console.WriteLine("nie zawiera cyfry 3");
        }

        static string Zad3(string ciag) //funckja
        {
            char separator = ' ';
            foreach (char c in ciag)
                if (!Char.IsLetter(c))
                {
                    separator = c;
                    break;
                }
            string[] podziel = ciag.Split(separator);
            return podziel[1] + separator + podziel[0];
        }


        //musimy zwrocic cos
        static int Zad4(int liczba)
        {
            int cyfra = 0;
            int suma;
            int start = liczba;
            do
            {
                suma = 0;
                do
                {
                    cyfra = start % 10;
                    suma += cyfra;
                    liczba /= 10;
                } while (liczba > 0);
                start = suma;
            } while (start > 9);
            return start;
        }

        static string Zad5a(string tekst)
        {
            string wynik = "";
            char poprzednia = tekst[0];
            int licznik = 0;
            foreach (char znak in tekst)
            {
                if (znak == poprzednia)
                {
                    licznik++;
                }
                else
                {
                    wynik += poprzednia;
                    wynik += licznik;
                    licznik = 1;
                    poprzednia = znak;
                }

            }
            wynik += poprzednia;
            wynik += licznik;

            return wynik;

        }

        static string Zad5(string tekst)
        {
            //foreach -> trzeba podac cokolwiek co jest iterowalne
            char poprzedni = ' ';
            int licznik = 0;
            string wynik = "";
            foreach (char znak in tekst)
            {
                if (znak == poprzedni)
                    licznik++;
                else if (poprzedni != ' ')
                {
                    wynik += poprzedni;
                    wynik += licznik;
                    licznik = 1;
                }
                poprzedni = znak;
            }
            if (licznik > 1)
            {
                wynik += poprzedni;
                wynik += licznik;
            }
            return wynik;

        }

        //zadanie 6
        //sortowanie babelkowe, skopiowane z jakiejs strony
        //tablica.length to wlasciwosc nie metoda

        static int[] BubbleSort(int[] tab)
        {
            int[] tablica = tab.Clone() as int []; // jak chce sklonowac, inny zapis mozna z nawiasami
            //obiekt to ogolny twor, wszystko jest obiektem
            //tylko typy prostte przekazywane sa prez wartosc
            //pozostale typt przekazywane sa przez referencje
            //nie trzeba tej pierwszej linijki
            //klon intepretuje interfejs i ten interfejs zwraca obiekt ??
            //wszystko co bedxziemy klonowac poprawnie zwraca nam obiekt
            //musze to zrzutowac na to co chce
            int n = tablica.Length;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (tablica[i] > tablica[i + 1])
                    {
                        int tmp = tablica[i];
                        tablica[i] = tablica[i + 1];
                        tablica[i + 1] = tmp;
                    }
                }
                n--;
            }
            while (n > 1);
            return tablica;
        }

        //zeruje pierwszy element
        //w tym drugim przypadku, pierwszy usunelam robimy kopie
        // i dzialamy na tej kopii
        static int[] ZerujPierwszy(int[] tab)
        {
            int[] kopia = new int[tab.Length];
            Array.Copy(tab, kopia, tab.Length);
            tab[0] = 0;
            return tab;
        }

        //algorytm org
        static void Trojkat(int nMax)
        {
            int[][] c;
            c = new int[nMax][];
            for (int n = 0; n < c.Length; n++)
                c[n] = new int[n + 1];
            for (int n = 0; n < c.Length;n++)
            {
                c[n][0] = c[n][n] = 1;
                for (int k = 1; k < n; k++)
                    c[n][k] = c[n - 1][k - 1] + c[n - 1][k];
            }
         
        }

        static int NWD(int a, int b)
        {
            if (b != 0)
                return NWD(b, a % b);
            return a;
           //ciag fibonacciego nie efektywna rekurencja, ale w silni tak
        }

        static void Zad9()
        {
            DateTime dzisiaj = DateTime.Today;
            //new to konstruktor w ten sposob tworzymy nowy obiekt
            DateTime koniecRoku = new DateTime(dzisiaj.Year, 12, 31);
            Console.WriteLine((koniecRoku - dzisiaj).TotalDays);
        }
        
        //wszystko nie prywatne z duzych liter
        //jesli zadeklarujemy ze funkcja zwraca vos to musimy to zapisac

        // void -> metoda niczego nie zwraca czyli klasyczna procedura
        // static -> nie trzeba tworzyć obiektu żeby wywołać
        static void Main()
        {
            //Zad1();
            /*
            console
            rozpocznij _ > uruchamia i zamyka od razu
            Console.WriteLine("Hello World");
            Console.ReadLine();
            Console.ReadKey(); odczytuje pojedynczy klawisz
            ctrl + c + k komentowanie
            ctrl + c + u  uncomment
            nie stosujemy float tylko double
            decimal -> typ poczwórnej precyzji
             */

            //Console.WriteLine(Zad3("szafa_taboret"));

            //tablice
            //zad2();
            //int[] tab = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            //ZerujPierwszy(tab);
            ////obiekty i tablice sa przekazywane przez referencje
            ////nadmazuje moj zerowy element
            ////jak chce zeby zostawil moj elemnt to musze stworzyc kopie
            //foreach (int i in tab)
            //    Console.Write(i + " ");
            //int[] tab2 = BubbleSort(tab);
            //foreach (int i in tab)
            //    Console.Write(i + " ");
            //Console.WriteLine("Posortowana tab2: ");
            //foreach (int i in tab2)
            //    Console.Write((i + " "));
            //Console.WriteLine();
            ////Console.WriteLine(Zad5a("kkkk3"));
            Console.WriteLine(Zad11("kk5555"));
           
        }
    }
}
