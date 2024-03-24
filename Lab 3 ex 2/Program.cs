using System;

namespace EvidentaStudenti
{
    public class Student
    {
        private int[] note;

        public int IdStudent { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        public string NumeComplet
        {
            get { return $"{Nume} {Prenume}"; }
        }

        public void SetNote(int[] _note)
        {
            note = new int[_note.Length];
            _note.CopyTo(note, 0);
        }

        public int[] GetNote()
        {
            return (int[])note.Clone();
        }

        public Student()
        {
            Nume = Prenume = string.Empty;
        }

        public Student(int idStudent, string nume, string prenume)
        {
            IdStudent = idStudent;
            Nume = nume;
            Prenume = prenume;
        }

        public string Info()
        {
            string info = $"Id:{IdStudent,-5} Nume:{Nume ?? " NECUNOSCUT ",-15} Prenume:{Prenume ?? " NECUNOSCUT ",-15}";

            return info;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Citirea numărului de studenți de la tastatură
            Console.Write("Introduceți numarul de studenti: ");
            int numarStudenti = Convert.ToInt32(Console.ReadLine());

            // Inițializarea vectorului de obiecte Student
            Student[] studenti = new Student[numarStudenti];

            // Citirea datelor de la tastatură pentru fiecare student și salvarea lor în vector
            for (int i = 0; i < numarStudenti; i++)
            {
                Console.WriteLine($"\nIntroduceti datele pentru studentul #{i + 1}:");
                Console.Write("Nume: ");
                string nume = Console.ReadLine();
                Console.Write("Prenume: ");
                string prenume = Console.ReadLine();
                // Putem citi și alte date sau nota, în funcție de necesități

                // Crearea obiectului Student și salvarea în vector
                studenti[i] = new Student(i + 1, nume, prenume);
            }

            // Afișarea datelor din vectorul de obiecte Student
            Console.WriteLine("\nLista de studenti:");
            foreach (var student in studenti)
            {
                Console.WriteLine($"ID: {student.IdStudent}, Nume complet: {student.NumeComplet}");
            }

            // Căutarea după nume complet în vectorul de obiecte Student
            Console.Write("\nIntroduceti numele complet al studentului căutat: ");
            string numeCautat = Console.ReadLine();
            bool gasit = false;
            foreach (var student in studenti)
            {
                if (student.NumeComplet.Equals(numeCautat, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Studentul cu numele complet '{numeCautat}' a fost gasit!");
                    gasit = true;
                    break;
                }
            }
            if (!gasit)
            {
                Console.WriteLine($"Nu a fost găsit niciun student cu numele complet '{numeCautat}'.");
            }
        }
    }
}
