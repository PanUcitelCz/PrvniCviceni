namespace PrvniCviceni
{
    internal class Program
    {
        // {} - Alt gr (pravý alt) + b / n
        static void Main(string[] args)
        {
            int a = 5;
            int b = 2;

            double vysledek = Math.Pow(a, b);

            Console.WriteLine("Aplikace pro mocnění");
            //^ - levý alt + num94
            Console.WriteLine($"Mocnina {a} na {b} = {vysledek}");

            string jmeno = "Honza";
            Console.WriteLine(jmeno);

            /*                                0       1         2         3         */
            var list = new List<string>() { "Pepa", "Karel", "Mirek", "Kryštof"};

            Console.WriteLine($"Seznam jmen: {String.Join(",", list)}");
            Console.WriteLine($"Jméno na pozici 1 = {list[1]}");

            //string jmena = $"Seznam jmen: {String.Join(",", list)}";

            list.Add("Jirka");

            string jmena = $"Seznam jmen: {String.Join(",", list)}";

            Console.WriteLine(jmena);

            list.RemoveAt(0);
            jmena = $"Seznam jmen: {String.Join(",", list)}";
            Console.WriteLine(jmena);

            list.Remove("Karel");
            jmena = $"Seznam jmen: {String.Join(",", list)}";
            Console.WriteLine(jmena);


            var s1 = new Student("Jan", "Novák", 20);
            var s2 = new Student("Petr", "Svoboda", 22);
            var s3 = new Student("Karel", "Černý", 19);
            var s4 = new Student("Mirek", "Procházka", 21);

            Console.WriteLine(s1.jmeno);
            Console.WriteLine(s2.jmeno);
            Console.WriteLine(s1.prijmeni);
            
            var liststud = new List<Student>() { };

            liststud.Add(s1);
            liststud.Add(s2);
            liststud.Add(s3);
            liststud.Add(s4);

            foreach (var student in liststud)
            {
                Console.WriteLine($"Student: {student.jmeno} {student.prijmeni}, věk: {student.vek}");
            }

            var SeznamStudentu = new List<Student>()
            {
                new Student("Mirek", "Procházka", 21),
                new Student("Karel", "Černý", 19),
                new Student("Petr", "Svoboda", 22),
                new Student("Jan", "Novák", 20),
                new Student("Anna", "Malá", 18),
                new Student("Eva", "Bílá", 23)    
            };

            Console.WriteLine($"Počet studentů: {SeznamStudentu.Count}");
            Console.WriteLine(s1.Popis());
        }
    }

    public class Student
    {
        //Prázdný konstruktor
        /*public Student() { }
        */

        public string jmeno;
        public string prijmeni;
        public int vek;

        public Student(string Jmeno, string Prijmeni, int Vek)
        {
            this.jmeno = Jmeno;
            this.prijmeni = Prijmeni;
            this.vek = Vek;
        }
        public string Popis()
        {
            return $"Student: {jmeno} {prijmeni}, věk: {vek}";
        }

        public string JinyZapisPopis() => $"Student: {jmeno} {prijmeni}, věk: {vek}";
    }
}
