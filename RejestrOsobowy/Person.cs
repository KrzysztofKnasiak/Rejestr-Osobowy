using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;


namespace RejestrOsobowy
{
    [Serializable]
    public class Person : IData
    {
        
         string name;
         string surname;
         int age;
         string gender;
         int postCode;
         string city;
         string street;
         int houseNumber;
         int flatNumber;


        
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }
        public int PostCode { get => postCode; set => postCode = value; }
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public int HouseNumber { get => houseNumber; set => houseNumber = value; }
        public int FlatNumber { get => flatNumber; set => flatNumber = value; }
        

        public List<Person> people = new List<Person>();

        public Person() 
        {
        }

        public Person(string name, string surname, int age, string gender, int postCode, string city, string street, int houseNumber)
        {

            this.name = name;
            this.surname = surname;
            this.age = age;
            this.gender = gender;
            this.postCode = postCode;
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;
            

        }

        public Person(string name, string surname, int age, string gender, int postCode, string city, string street, int houseNumber, int flatNumber) 
        {
            
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.gender = gender;
            this.postCode = postCode;
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;
            this.flatNumber = flatNumber;

        }

        public void AddPerson()
        {
            bool check = false;
            do
            {
                

                try
                {
                    Console.WriteLine("---- Dodawanie osoby do rejestru ----");
                    Console.WriteLine("Podaj imię:");
                    name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name) || name.Length >30)
                    {
                        throw new Exception("Pole imię nie może być puste oraz dłuższe niż 30 znaków.");
                    }
                    Console.WriteLine("Podaj nazwisko:");
                    surname = Console.ReadLine();
                    if (string.IsNullOrEmpty(surname) || surname.Length > 30)
                    {
                        throw new Exception("Pole nazwisko nie może być puste oraz dłuższe niż 30 znaków.");
                    }

                    if(people.Exists(x => x.name == name & x.surname == surname))
                    {
                        throw new Exception("Istnieje już osoba o takich danych w rejestrze, skontaktuj się z Administratorem w celu wyjaśnienia.");
                    }

                    Console.WriteLine("Podaj wiek:");
                    age = int.Parse(Console.ReadLine());
                    if (age > 150 || age < 1)
                    {

                        throw new Exception("Minimalny wiek to 1, maksymalny 150.");
                    }

                    Console.WriteLine("Podaj płeć:\nWprowadź: Kobieta | Mężczyzna");
                    gender = Console.ReadLine();
                    if (gender == "Kobieta" || gender == "Mężczyzna" || gender == "mężczyzna" || gender == "kobieta")
                    {

                    }
                    else
                    {

                        throw new Exception("Wprowadzone dane są niepoprawne.");
                    }

                    Console.WriteLine("Podaj kod pocztowy:\nWprowadź bez -.");
                    postCode = int.Parse(Console.ReadLine());
                    if (postCode.ToString().Length != 5)
                    {
                        throw new Exception("Wprowadzoe dane są niepoprawne, przekroczono liczbę znaków.");
                    }
                    Console.WriteLine("Podaj miasto:");
                    city = Console.ReadLine();
                    if (string.IsNullOrEmpty(city) || city.Length > 30)
                    {
                        throw new Exception("Pole miasto nie może być puste oraz dłuższe niż 30 znaków.");
                    }
                    Console.WriteLine("Podaj ulicę:");
                    street = Console.ReadLine();
                    if (string.IsNullOrEmpty(street) || street.Length > 30)
                    {
                        throw new Exception("Pole ulica nie może być puste oraz dłuższe niż 30 znaków.");
                    }
                    Console.WriteLine("Podaj numer domu:");
                    houseNumber = int.Parse(Console.ReadLine());
                    
                    if (houseNumber > 1000 || houseNumber < 0)
                    {
                        throw new Exception("Wprowadzone dane są niepoprawne, maksymalny numer to 1000.");
                    }
                    Console.WriteLine("Podaj numer mieszkania:\nWprowadź 0 jeżeli nie występuje.");
                    flatNumber = int.Parse(Console.ReadLine());
                    if (flatNumber > 1000 || flatNumber < 0)
                    {
                        throw new Exception("Wprowadzone dane są niepoprawne, maksymalny numer to 1000.");
                    }
                    if (flatNumber == 0)
                    {
                        people.Add(new Person(name, surname, age, gender, postCode, city, street, houseNumber));
                        Console.Clear();
                        Console.WriteLine("Osoba została dodana do rejestru, naciśnij dowolny przycisk aby kontynuować..");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        people.Add(new Person(name, surname, age, gender, postCode, city, street, houseNumber, flatNumber));
                        Console.Clear();
                        Console.WriteLine("Osoba została dodana do rejestru, naciśnij dowolny przycisk aby kontynuować..");
                        Console.ReadKey();
                        Console.Clear();
                        
                    }
                    check = true;
                }

               
                catch (Exception e)
                {

                    Console.Clear();
                    Console.WriteLine("Coś poszło nie tak: " + e.Message);
                    Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                    Console.ReadKey();
                    check = true;
                    Console.Clear();
                }
            }  while (check == false);

        }

        public void DeletePerson() 
        {
            int chose;
            DisplayData();
            Console.WriteLine("{0}.Powrót \n", people.Count+1);

            try
            {
                Console.WriteLine("Którą osobę usunąć z rejestru ?\nWybierz numer przypisany do osoby, którą chcesz usunąć.");
                chose = int.Parse(Console.ReadLine());
                if (chose == people.Count + 1)
                {

                }
                else
                {
                    Console.Clear();
                    people.RemoveAt(chose - 1);
                    Console.WriteLine("Osoba została usunięta, naciśnij dowolny przycisk aby kontynuować..");
                    Console.ReadKey();
                    Console.Clear();
                }
                
            }

            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Coś poszło nie tak: " + e.Message);
                Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                Console.ReadKey();
                Console.Clear();
            }
            
        }

        public void EditPerson()
        {
            //Pierwsza część menu 
            int chose;
            do
            {
                try
                {
                    
                    DisplayData();
                    Console.WriteLine("{0}.Powrót", people.Count + 1);
                    Console.WriteLine("Której osoby dane chcesz edytować ?");
                    chose = int.Parse(Console.ReadLine());
                    
                    if (chose == people.Count + 1)
                    {
                        break;
                    }

                    else if (chose > people.Count + 1)
                    {
                        throw new Exception("Wybrałeś niepoprawną wartość, pod tym indeksem nie widnieje żadna osoba.");
                       
                    }
                    else
                    {
                        break;
                    }
                   
                }
                catch(Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Coś poszło nie tak: "+e.Message );
                    Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (true);


            if (chose != people.Count+1)
            {
                bool wait = true;
                do
                {
                    
                    try
                    {


                        Console.Clear();
                        Console.WriteLine("Wybierz co chcesz edytować");
                        Console.WriteLine("1.Imię\n2.Nazwisko\n3.Wiek\n4.Płeć\n5.Kod pocztowy\n6.Miasto\n7.Ulia\n8.Numer domu\n9.Numer mieszkania\n0.Powrót");
                        char option = Console.ReadKey().KeyChar;
                        Console.Clear();

                        switch (option)
                        {
                            case '1':
                                {
                                    Console.WriteLine("Podaj nowe imię:");
                                    string newName = Console.ReadLine();
                                    if (string.IsNullOrEmpty(newName) || newName.Length > 30)
                                    {
                                        throw new Exception("Pole imię nie może być puste oraz dłuższe niż 30 znaków, spróbuj ponownie...");
                                    }
                                    people[chose - 1].name = newName;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            case '2':
                                {

                                    Console.WriteLine("Podaj nowe nazwisko:");
                                    string newSurname = Console.ReadLine();
                                    if (string.IsNullOrEmpty(newSurname) || newSurname.Length > 30)
                                    {
                                        throw new Exception("Pole imię nie może być puste oraz dłuższe niż 30 znaków, spróbuj ponownie...");
                                    }
                                    people[chose - 1].surname = newSurname;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }
                            case '3':
                                {

                                    Console.WriteLine("Podaj nowy wiek:");
                                    int newAge = int.Parse(Console.ReadLine());
                                    if (newAge > 150 || newAge < 1)
                                    {

                                        throw new Exception("Minimalny wiek to 1, maksymalny 150, spróbuj ponownie...");
                                    }
                                    people[chose - 1].age = newAge;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }
                            case '4':
                                {

                                    Console.WriteLine("Podaj nową płeć:");
                                    string newGender = Console.ReadLine();
                                    if (newGender == "Kobieta" || newGender == "Mężczyzna" || newGender == "mężczyzna" || newGender == "kobieta")
                                    {

                                    }
                                    else
                                    {

                                        throw new Exception("Wprowadzone dane są niepoprawne, spróbuj ponownie...");
                                    }
                                    people[chose - 1].gender = newGender;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }
                            case '5':
                                {

                                    Console.WriteLine("Podaj nowy kod pocztowy:\nWprowadź bez -.");
                                    int newPostCode = int.Parse(Console.ReadLine());
                                    if (newPostCode.ToString().Length != 5)
                                    {
                                        throw new Exception("Wprowadzoe dane są niepoprawne, przekroczono liczbę znaków.");
                                    }
                                    people[chose - 1].postCode = newPostCode;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }
                            case '6':
                                {

                                    Console.WriteLine("Podaj nowe miasto");
                                    string newCity = Console.ReadLine();
                                    if (string.IsNullOrEmpty(newCity) || newCity.Length > 30)
                                    {
                                        throw new Exception("Pole miasto nie może być puste oraz dłuższe niż 30 znaków.");
                                    }
                                    people[chose - 1].city = newCity;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }
                            case '7':
                                {

                                    Console.WriteLine("Podaj nową ulicę");
                                    string newStreet = Console.ReadLine();
                                    if (string.IsNullOrEmpty(newStreet) || newStreet.Length > 30)
                                    {
                                        throw new Exception("Pole ulica nie może być puste oraz dłuższe niż 30 znaków.");
                                    }
                                    people[chose - 1].street = newStreet;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }
                            case '8':
                                {

                                    Console.WriteLine("Podaj nowy numer domu");
                                    int newHouseNumber = int.Parse(Console.ReadLine());
                                    if (newHouseNumber > 1000 || newHouseNumber < 0)
                                    {
                                        throw new Exception("Wprowadzone dane są niepoprawne, maksymalny numer to 1000.");
                                    }
                                    people[chose - 1].houseNumber = newHouseNumber;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;

                                }
                            case '9':
                                {

                                    Console.WriteLine("Podaj nowy numer mieszkania\nWprowadź 0 jeżeli chcesz usunąć.");
                                    int newFlatNumber = int.Parse(Console.ReadLine());
                                    if (newFlatNumber > 1000 || newFlatNumber < 0)
                                    {
                                        throw new Exception("Wprowadzone dane są niepoprawne, maksymalny numer to 1000.");
                                    }
                                    people[chose - 1].flatNumber = newFlatNumber;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }

                            case '0':
                                {
                                    wait = false;
                                    break;
                                }



                           // default:
                                //break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine("Coś poszło nie tak: " + e.Message);
                        Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                
                } while (wait == true);
            }
            else 
            { 
            }
          

        }

        public void DisplayData()
        {
            
            int counter = 1;
            Console.WriteLine("------------ Lista osób: ------------");
            foreach(var P in people) 
            {
                if (P.flatNumber == 0) 
                {

                    Console.WriteLine("{2}. {0} {1} {3} lat {4}", P.name, P.surname, counter, P.age, P.gender);
                    string convertedPostCode = P.postCode.ToString();
                    Console.Write("   ");

                    for (int i = 0; i < 2; i++)
                    {
                        Console.Write(""+convertedPostCode[i]);

                    }

                    Console.Write("-");

                    for (int i = 2; i < 5; i++)
                    {
                        Console.Write(convertedPostCode[i]);

                    }

                    Console.WriteLine(" {0} \n   ul.{1} {2}",P.city, P.street, P.houseNumber);
                    

                    Console.WriteLine("--------------------------------------");
                    counter++;
                    
                }
                else
                {
                    Console.WriteLine("{2}. {0} {1} {3} lat {4}", P.name, P.surname, counter, P.age, P.gender);
                    string convertedPostCode = P.postCode.ToString();
                    Console.Write("   ");

                    for (int i = 0; i < 2; i++)
                    {
                        Console.Write("" + convertedPostCode[i]);

                    }

                    Console.Write("-");

                    for (int i = 2; i < 5; i++)
                    {
                        Console.Write(convertedPostCode[i]);

                    }

                    Console.WriteLine(" {0} \n   ul.{1} {2}/{3}", P.city, P.street, P.houseNumber,P.flatNumber);


                    Console.WriteLine("--------------------------------------");
                    counter++;

                }
               
            }
            

        }
       
        public void Search()
        {
            try
            {


                Console.WriteLine("Wprowadź frazę którą chcesz wyszukać w rejestrze:");
                int counter = 1;
                string sentence = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Wyniki wyszukiwania frazy: {0}",sentence);
                Console.WriteLine("--------------------------------------");
                foreach (Person P in people.FindAll(x => x.name.Contains(sentence) || x.surname.Contains(sentence) || x.age.ToString().Contains(sentence)
                || x.gender.Contains(sentence) || x.postCode.ToString().Contains(sentence) || x.city.Contains(sentence)
                || x.street.Contains(sentence) || x.houseNumber.ToString().Contains(sentence) || x.flatNumber.ToString().Contains(sentence)))
                {

                    if (P.flatNumber == 0)
                    {

                        Console.WriteLine("{2}. {0} {1} {3} lat {4}", P.name, P.surname, counter, P.age, P.gender);
                        string convertedPostCode = P.postCode.ToString();
                        Console.Write("   ");

                        for (int i = 0; i < 2; i++)
                        {
                            Console.Write("" + convertedPostCode[i]);

                        }

                        Console.Write("-");

                        for (int i = 2; i < 5; i++)
                        {
                            Console.Write(convertedPostCode[i]);

                        }

                        Console.WriteLine(" {0} \n   ul.{1} {2}", P.city, P.street, P.houseNumber);


                        Console.WriteLine("--------------------------------------");
                        counter++;

                    }
                    else
                    {
                        Console.WriteLine("{2}. {0} {1} {3} lat {4}", P.name, P.surname, counter, P.age, P.gender);
                        string convertedPostCode = P.postCode.ToString();
                        Console.Write("   ");

                        for (int i = 0; i < 2; i++)
                        {
                            Console.Write("" + convertedPostCode[i]);

                        }

                        Console.Write("-");

                        for (int i = 2; i < 5; i++)
                        {
                            Console.Write(convertedPostCode[i]);

                        }

                        Console.WriteLine(" {0} \n   ul.{1} {2}/{3}", P.city, P.street, P.houseNumber, P.flatNumber);


                        Console.WriteLine("--------------------------------------");
                        counter++;

                    }
                }

                if (counter == 1)
                {
                    Console.WriteLine("Nie znaleziono wyszukiwanej frazy w rejestrze.");
                    Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować...");
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
}
    }
}
