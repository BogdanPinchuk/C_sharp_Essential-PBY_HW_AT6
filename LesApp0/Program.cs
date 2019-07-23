using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення гаража авто
            Car[] cars = new Car[]
            {
                // http://www.mercedes-benz.kiev.ua/cars/models/gls-class/suv/info/tehnicheskie-harakteristik/modeli.html
                new Car(100, 100)
                {
                    Name = "Mercedes-Benz",
                    Model = "GLS AMG Внедорожник",
                    Color = ConsoleColor.Gray
                },
                // http://www.mercedes-benz.kiev.ua/cars/models/gla-class/suv/info/tehnicheskie-harakteristiki/modeli.html
                new Car(50, 50)
                {
                    Name = "Mercedes-Benz",
                    Model = "GLA AMG SUV",
                    Color = ConsoleColor.Gray
                },
                // http://www.mercedes-benz.kiev.ua/cars/models/gle-class/coupe/info/tehnicheskie-harakteristik/modeli.html
                new Car(93, 93)
                {
                    Name = "Mercedes-Benz",
                    Model = "GLE AMG Купе",
                    Color = ConsoleColor.Gray
                },
                // http://www.mercedes-benz.kiev.ua/cars/models/glc-class/coupe/info/tehnicheskie-harakteristik/modeli.html
                new Car(50, 50)
                {
                    Name = "Mercedes-Benz",
                    Model = "GLC AMG Купе",
                    Color = ConsoleColor.Gray
                }
            };

            // створення заправочної станції
            GasStation station = new GasStation();

            #region Testing cars
            // прапор, який перевіряє чи не пустий бак хоч в когось
            bool tankNotEmpty;

            // поїздка
            do
            {
                // чи десь закінчився бензин
                tankNotEmpty = true;

                for (int i = 0; i < cars.Length; i++)
                {
                    ShowInfo(cars[i].ToString(), ConsoleColor.Green);
                    cars[i].Move();
                    ShowInfo("\n" + new string('#', 25), ConsoleColor.Blue);
                    if (cars[i].Tank == 0)
                    {
                        tankNotEmpty &= false;
                    }
                }
            } while (tankNotEmpty);

            // скористаємося тією самою змінною tankNotEmpty, 
            // але в цілях чи хтось заправився повним баком

            // заправка
            do
            {
                // чи всі заправилися повністю
                tankNotEmpty = true;

                for (int i = 0; i < cars.Length; i++)
                {
                    ShowInfo(cars[i].ToString(), ConsoleColor.Green);
                    station.GoInGasStation(ref cars[i]);
                    ShowInfo("\n" + new string('#', 25), ConsoleColor.Yellow);
                    if (cars[i].Tank < cars[i].MaxVolume)
                    {
                        tankNotEmpty &= false;
                    }
                }
            } while (!tankNotEmpty);
            #endregion

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }

        private static void ShowInfo(string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}
