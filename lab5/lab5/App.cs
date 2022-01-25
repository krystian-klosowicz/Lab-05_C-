using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{

    public  class SomeClass
    {
        public void CanThrowException()
        {
            if (new Random().Next(5) == 0)
                throw new Exception();
        }

    }


    public class Student:ICloneable
    {
        private string imie;
        private string nazwisko;
        private int wiek;

        public Student(string imie, string nazwisko, int wiek)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.wiek = wiek;
        }

        public Student()
        {
        }

        public override string ToString()
        {
            return imie + " " + nazwisko + " " + wiek;
        }

        public void kopiuj_studenta(Student s1, Student s2)
        {
            try
            {
                s2.imie = s1.imie;
                s2.nazwisko =s1.nazwisko;
                s2.wiek = s1.wiek;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Brak paramaetru lub parametr null");
                Console.WriteLine(ex.StackTrace);
            }
        }

        public Student kopiuj_studenta2()
        {
            try
            {
                return (Student)MemberwiseClone();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wyjatek ex");
                return null;
            }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }


    class App
    {

       static int napis(string n)
        {
            return n.Length;
        }
        static void zad1()
        {
            try
            {
                napis(null);
            }
            catch (NullReferenceException e)

            {
                Console.WriteLine(e.StackTrace);
                throw new Exception("can not be null");
            }
        }

        static void zad2()
        {
            Random random = new Random();
            switch(random.Next(1, 4))
            {
                case 1:
                    {
                        try
                        {
                            throw new Exception();
                        }catch(Exception e)
                        {
                            Console.WriteLine("Exception 1");
                            Console.WriteLine(e.StackTrace);
                        }
                        break;
                    }

                case 2:
                    {
                        try
                        {
                            throw new Exception();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception 2");
                            Console.WriteLine(e.StackTrace);
                        }
                        break;
                    }

                case 3:
                    {
                        try
                        {
                            throw new Exception();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception 3");
                            Console.WriteLine(e.StackTrace);
                        }
                        break;
                    }
            }
        }

        static void zad3()
        {
            try
            {
                throw new Exception2();
            }
            catch (Exception1 e)
            {
                //jak nie wylapie pierwszego to wylapie drugi
                Console.WriteLine("nic");
                Console.WriteLine(e.StackTrace);
                throw new Exception2();
                


            }
            catch (Exception2 e)
            {
                Console.WriteLine("Mozna jak najbardziej");
                Console.WriteLine(e.StackTrace);
            }





        }

        public static void zad4()
        {

            SomeClass someClassObj = new SomeClass();
            //prosty licznik zaczynajacy od 1
            int licznik = 1;
            try
            {
                //jesli funkcja CanThrowException wylosuje 0 to wyrzuci wyjatek
                //moze wyrzucic po kazdym kolejnym wywolaniu funkcji lub nie wyrzucic wcale
                someClassObj.CanThrowException();
                licznik++;
                someClassObj.CanThrowException();
                licznik++;
                someClassObj.CanThrowException();
                licznik++;
                someClassObj.CanThrowException();
                licznik++;
                someClassObj.CanThrowException();
                Console.WriteLine("Brak wyjątku");
            }
            catch (Exception e)
            {
                Console.WriteLine("Wyjatek: " + licznik);
                Console.WriteLine(e.StackTrace);

            }

        }

        
        public static void Main(string[] args)
        {
            //Zadanie1
            // NullReferenceException
            //zad1();
            //zad2();
            //zad3();
            //zad4();
            //Zadanie 5
            Student student1 = new Student("Kamil", "Stoch", 33);
            Student nowy_student = new Student();

            Console.WriteLine("Przed skopiowaniem: " + nowy_student.ToString());
            nowy_student.kopiuj_studenta(student1, nowy_student);
            Console.WriteLine("Po skopiowaniu: " + nowy_student.ToString());
            //Zadanie 6
            Student nowy_student2 = new Student();
            
            Console.WriteLine("Zadanko 6");
            Console.WriteLine("nowy_student2 przed: " + nowy_student2.ToString());
            nowy_student2 = nowy_student.kopiuj_studenta2();
            Console.WriteLine("nowy_student2 po: " + nowy_student2.ToString());


        }
    }

    


}
