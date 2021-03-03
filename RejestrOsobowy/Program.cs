using System;
using System.IO;
using System.Xml.Serialization;


namespace RejestrOsobowy
{
    
    class Program
    {
        static Person p = new Person();
        static void Main(string[] args)
        {
            LoadXML();
            Menu();
            
        }

        public static void Menu() 
        {
            do
            {
               
                Console.Clear();
                Console.WriteLine("--- Rejestr osobowy ---");
                Console.WriteLine("1.Wyświetl listę osób\n2.Dodaj osobę\n3.Przeszukaj rejestr\n4.Edytuj dane\n5.Usuń osobę\n6.Zapisz i zakończ");
                char option = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (option)
                {
                    case '1':
                        {
                            p.DisplayData();
                            Console.WriteLine("Naciśnij dowolny przycisk aby wrócić do menu...");
                            Console.ReadKey();

                            break;
                        }
                    case '2':
                        {
                            p.AddPerson();
                            break;
                        }
                    case '3':
                        {
                            p.Search();
                            break;
                        }
                    case '4':
                        {
                            p.EditPerson();
                            break;
                        }
                    case '5':
                        {
                            p.DeletePerson();
                            break;
                        }
                    case '6':
                        {
                            SaveXML();
                            break;
                        }




                    default:
                        break;
                }
            }
            while (true);


        }

        

        public static void LoadXML() 
        {
            try
            {
                Stream FileRe = new FileStream("SAVE.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer read = new XmlSerializer(typeof(Person));
                p = (Person)read.Deserialize(FileRe);
                FileRe.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SaveXML() 
        {
            try
            {
                Console.WriteLine("Zapisywanie danych i zamykanie aplikacji ...");
                Stream FileWr = new FileStream("SAVE.xml", FileMode.Create);
                XmlSerializer save = new XmlSerializer(typeof(Person));
                save.Serialize(FileWr, p);
                FileWr.Close();
                Environment.Exit(0);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
          

        }
    }
}
