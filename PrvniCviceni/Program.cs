namespace PrvniCviceni
{
    internal class Program
    {
        // {} - Alt gr (pravý alt) + b / n
        // [] - Alt gr (pravý alt) + f / g
        // $ - levý alt + num36

        // Komentář - text, který není vykonán jako kód, slouží pro vysvětlení kódu
        /* Komentář - Pomocí těchto znaku můžete zakomentovat větší blok kódu */
        // Jednořádkový komentář - začíná dvěma lomítky //
        // Pomocí komentářů můžete deaktivovat části kódu (nebudou vykonány)

        // Hlavní metoda aplikace
        // static - metoda je statická a patří ke třídě, ne k instanci třídy
        // void - metoda nevrací žádnou hodnotu
        // Main - název metody, hlavní metoda aplikace (při spuštění aplikace se spustí tato metoda)
        static void Main(string[] args)
        {
            // Deklarace proměnné
            /*
             Syntaxe:
                      Datový typ nazev = hodnota;
                      int         nazev_promenne = 5;
             1. Datový typ - určuje jaký typ dat bude proměnná
                Datové typy:
                - int (integer) - celé číslo    
                - double - desetinné číslo (velmi přesné číslo)
                - string - text
                - bool (boolean) - pravda/nepravda (true/false)
                - float - desetinné číslo (méně přesné než double)
                - (List) - seznam hodnot deklarujeme jinak, než běžné proměnné
            2. Název proměnné - název, kterým se na proměnnou odkazujeme

            3. Hodnota - hodnota, kterou proměnná obsahuje

             */
            int a = 5; // int - integer - celé číslo
            int b = 2; // Proměnná má název b a hodnotu 2

            // Výpočet mocniny pomocí metody Math.Pow
            // Math - třída, která obsahuje matematické metody a konstanty
            // Pow - metoda, která vypočítá mocninu (první parametr je základ, druhý je exponent)
            // Do proměnné vysledek uložíme výsledek výpočtu
            double vysledek = Math.Pow(a, b);


            // Výpis do konzole
            // Console - třída, která obsahuje metody pro práci s konzolí
            // WriteLine - metoda, která vypíše text do konzole a přejde na další řádek
            // Do Závorek píšeme výstup z aplikace, nezapomeňte na středník na konci řádku
            Console.WriteLine("Aplikace pro mocnění");
            //^ - levý alt + num94

            // Runyní výpis s použitím interpolace řetězců
            // Interpolace řetězců - umožňuje vkládat hodnoty proměnných do textu pomocí {}
            // Začínáme znakem $ před uvozovkami
            // V {} píšeme název proměnné, jejíž hodnotu chceme vložit do textu nebo rovnou příkaz či operaci
            Console.WriteLine($"Mocnina {a} na {b} = {vysledek}");

            // Příklad s použitím metody Math.Pow přímo v interpolaci
            Console.WriteLine($"Mocnina {a} na {b} = {Math.Pow(a, b)}");

            // Deklarace a použití proměnné typu string
            string jmeno = "Honza";
            Console.WriteLine(jmeno);

            // Deklarace proměnné pro List (seznam) jmen
            /*                                0       1         2         3         */
            var list = new List<string>() { "Pepa", "Karel", "Mirek", "Kryštof"};
            // var - kompilátor sám určí datový typ proměnné (Dynamické typování)
            // list - název proměnné
            // List - třída, která reprezentuje seznam hodnot
            // new List<string>() - vytvoření nové instance seznamu, který bude obsahovat hodnoty typu string
            // { "Pepa", "Karel", "Mirek", "Kryštof"} - inicializace seznamu s počátečními hodnotami (oddělujeme čárkou)
            // Přístup k jednotlivým hodnotám v seznamu pomocí indexu (pozice v seznamu, začíná od 0)
            // Délka seznamu pomocí vlastnosti Count - počet hodnot v seznamu

            // Výpis seznamu do konzole
            // String.Join - metoda, která spojí hodnoty seznamu do jednoho řetězce, oddělené zadaným znakem (v tomto případě čárkou)
            // Pokud bychom použili pouze list, vypíše se typ seznamu, ne jeho obsah
            Console.WriteLine($"Seznam jmen: {String.Join(",", list)}");
            Console.WriteLine($"Jméno na pozici 1 = {list[1]}");

            //string jmena = $"Seznam jmen: {String.Join(",", list)}";

            // list.Add() - metoda, která přidá novou hodnotu na konec seznamu
            list.Add("Jirka");

            // Uložení výpisu do proměnné a opětovný výpis do konzole
            string jmena = $"Seznam jmen: {String.Join(",", list)}";
            Console.WriteLine(jmena);

            // list.RemoveAt() - metoda, která odstraní hodnotu na zadané pozici (indexu)
            list.RemoveAt(0);
            jmena = $"Seznam jmen: {String.Join(",", list)}"; // Aktualizace proměnné s výpisem
            Console.WriteLine(jmena);

            // list.Remove() - metoda, která odstraní zadanou hodnotu podle názvu (první výskyt)
            list.Remove("Karel");
            jmena = $"Seznam jmen: {String.Join(",", list)}";
            Console.WriteLine(jmena);

            // new Student() - vytvoření nové instance třídy Student
            // Student - třída, která reprezentuje studenta (je vytvořené dále v kódu)
            // s1, s2, s3, s4 - názvy proměnných, které budou obsahovat jednotlivé instance třídy Student (tkz. objekty)
            // Konstruktor třídy Student - metoda, která se volá při vytvoření nové instance třídy a inicializuje její vlastnosti
            // Parametry konstruktoru jsou jméno, příjmení a věk studenta (to je to,co píšeme do závorek)

            var s1 = new Student("Jan", "Novák", 20);
            var s2 = new Student("Petr", "Svoboda", 22);
            var s3 = new Student("Karel", "Černý", 19);
            var s4 = new Student("Mirek", "Procházka", 21);

            // Každá proměnná (s1, s2, s3, s4) obsahuje jinou instanci třídy Student s vlastními hodnotami

            // Přístup k vlastnostem objektu pomocí tečkové notace
            // Vlastnosti jsou definované ve třídě Student (jmeno, prijmeni, vek)
            // Vlastnosti jsou veřejné (public), takže k nim můžeme přistupovat z hlavní metody
            // Výpis jednotlivých vlastností do konzole
            // Našeptáváč - po napsání tečky se zobrazí seznam dostupných vlastností a metod pro daný objekt (pozor které jsou veřejné a které ne a hlavně které chcete použít)
            Console.WriteLine(s1.jmeno);
            Console.WriteLine(s2.jmeno);
            Console.WriteLine(s1.prijmeni);


            // Vytvoření seznamu studentů a přidání jednotlivých studentů do seznamu
            // new List<Student>() - vytvoření nové instance seznamu, který bude obsahovat hodnoty typu Student (objekty třídy Student)
            var liststud = new List<Student>() { };

            // Přidání jednotlivých studentů do seznamu pomocí metody Add
            liststud.Add(s1);
            liststud.Add(s2);
            liststud.Add(s3);
            liststud.Add(s4);

            // Výpis seznamu studentů do konzole pomocí cyklu foreach
            // foreach - cyklus, který prochází všechny hodnoty v seznamu (defualtně od začátku (od 0) do konce (do délky pole)
            // student - název proměnné, která bude obsahovat aktuální hodnotu ze seznamu při každé iteraci cyklu
            // Jednoduše řečeno - pro každý objekt (student) v seznamu (liststud) proveď následující blok kódu
            // in liststud - určuje, ze seznamu liststud (který obsahuje objekty třídy Student) se budou brát hodnoty do proměnné student

            // student sebere z první pozice (index 0) objekt s1, vykoná blok kódu, pak sebere z druhé pozice (index 1) objekt s2, vykoná blok kódu, atd. až do konce seznamu
            foreach (var student in liststud)
            {
                Console.WriteLine($"Student: {student.jmeno} {student.prijmeni}, věk: {student.vek}"); // Výpis vlastností aktuálního studenta
            }

            // new List<Student>() s inicializací - vytvoření seznamu studentů přímo s hodnotami
            var SeznamStudentu = new List<Student>()
            {
                // new Student() - vytvoření nové instance třídy Student s parametry
                // Přidání jednotlivých studentů přímo do seznamu při jeho vytvoření
                // Každý objekt je oddělen čárkou a přidáváme je mezi {}. Nezapomeňte na středník na konci řádku
                new Student("Mirek", "Procházka", 21),
                new Student("Karel", "Černý", 19),
                new Student("Petr", "Svoboda", 22),
                new Student("Jan", "Novák", 20),
                new Student("Anna", "Malá", 18),
                new Student("Eva", "Bílá", 23)    
            }; // Zde je ten středník :)

            // Výpis počtu studentů v seznamu pomocí vlastnosti Count (Vypíše délku listu)
            Console.WriteLine($"Počet studentů: {SeznamStudentu.Count}");

            // s1.Popis() - volání metody Popis() na objektu s1
            // Metoda Popis() je definovaná ve třídě Student a vrací řetězec s popisem studenta
            Console.WriteLine(s1.Popis());
        }
    }

    // Definice třídy Student
    // class - klíčové slovo pro definici třídy
    // Student - název třídy (konvence je psát názvy tříd s velkým počátečním písmenem)
    // Třída je šablona pro vytváření objektů (instancí třídy)
    public class Student
    {
        //Prázdný konstruktor
        /*
            public Student() { }
            
            Pokud bychom chtěli mít možnost vytvořit instanci třídy Student bez zadání parametrů, museli bychom přidat prázdný konstruktor.
            V mainu bychom pak volali například:

                var s5 = new Student();
                s5.jmeno = "Lukáš";
                s5.prijmeni = "Novotný";
                s5.vek = 18;

            Zde jsme vytvořili nového studenta s5 a následně jsme mu přiřadili hodnoty vlastnostem jmeno, prijmeni a vek (U prázdného konstruktoru jsme jej museli vytvořit ručně).
        */

        // Vlastnosti třídy Student
        // public - vlastnost je veřejná a je přístupná z hlavní metody
        // string - datový typ vlastnosti (text)
        // int - datový typ vlastnosti (celé číslo)
        // jmeno, prijmeni, vek - názvy vlastností
        public string jmeno;
        public string prijmeni;
        public int vek;

        // Konstruktor třídy Student s parametry
        // Konstruktor je metoda, která se volá při vytvoření nové instance třídy a inicializuje její vlastnosti
        // Parametry konstruktoru jsou jméno, příjmení a věk studenta
        // Student(string Jmeno, string Prijmeni, int Vek) - definice konstruktoru s parametry a jejich datovými typy

        public Student(string Jmeno, string Prijmeni, int Vek)
        {
            // Inicializace vlastností třídy hodnotami z parametrů
            // this - odkaz na aktuální instanci třídy (objekt), používáme jej k rozlišení mezi vlastností a parametrem, pokud mají stejný název
            this.jmeno = Jmeno;
            this.prijmeni = Prijmeni;
            this.vek = Vek;
        }

        // Metoda Popis - vrací řetězec s popisem studenta
        // public - metoda je veřejná a je přístupná z hlavní metody
        // string - datový typ návratové hodnoty metody (text)
        // Popis() - název metody, bez parametrů (v závorkách by byly parametry, pokud by nějaké byly)

        public string Popis()
        {
            // return - klíčové slovo, které vrací hodnotu z metody
            return $"Student: {jmeno} {prijmeni}, věk: {vek}";
        }

        // Alternativní zápis metody Popis pomocí výrazu lambda (=>)
        public string JinyZapisPopis() => $"Student: {jmeno} {prijmeni}, věk: {vek}";
    }
}
