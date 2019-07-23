using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Автозаправка
    /// </summary>
    class GasStation
    {
        /// <summary>
        /// Випадкові числа
        /// </summary>
        private Random rnd = new Random();
        private Car car = null;

        /// <summary>
        /// Заїзд на станцію (використання патерну singleton)
        /// </summary>
        /// <param name="car">Авто</param>
        public void GoInGasStation(ref Car car)
        {
            if (car.Tank == car.MaxVolume)
            {
                Console.WriteLine($"\tБак повний, заправка непотрібна.");
                return;
            }

            if (this.car == null)
            {
                this.car = car;
            }
            else if (!this.car.Equals(car))
            {
                // перевірка машини, якщо це не та що зайняла колонку то нехай чекає
                Console.WriteLine("\n\tЗаправочна колонка зайнята, зачекайте будь ласка.");
                return;
            }

            // заправка авто яке попало до колонки
            FillCar(ref car);

            // перевірка чи авто заправлено повністю
            // якщо так то звільняємо колонку
            if (car.Tank == car.MaxVolume)
            {
                this.car = null;
            }
        }

        /// <summary>
        /// Заправка авто
        /// </summary>
        /// <param name="car">Авто</param>
        private void FillCar(ref Car car)
        {
            // перевірка чи це не рейковий транспортний засіб
            // хоча воно і так наслідується, можливо будуть інші
            // типи транспорту і наслідування іншими інтерфейсами
            // і даний метод прийматиме транспорт через інтерфейс (IVehicle vehicle)
            if (!(car is NonRailVehicle))
            {
                Console.WriteLine("Такий транспортний засіб заправити не можливо");
                return;
            }

            if (car.MaxVolume - car.Tank == 0)
            {
                Console.WriteLine($"\tБак повний, заправка непотрібна.");
                return;
            }

            Console.WriteLine($"\n\tПального в баку до заправки: {car.Tank}");
            int fuel = FillFuel(car);
            Console.WriteLine($"\tЗалито пального за один раз: {fuel}");
            car.FillProcess(fuel, this);
            Console.WriteLine($"\tПального в баку після заправки: {car.Tank}");
            if (car.Tank == car.MaxVolume)
            {
                Console.WriteLine($"\tБак заповнено повністю.");
            }
        }

        /// <summary>
        /// Заправка палива за один заїзд на станцію
        /// </summary>
        /// <param name="car">Авто</param>
        /// <returns></returns>
        private int FillFuel(Car car)
        {
            // мінімальна і максимально можлива заправка 
            int minFill = 1,
                maxFill = car.MaxVolume;

            // випадкове значення залитого об'єму пального в бак
            int fuel = rnd.Next(minFill, maxFill + 1);

            // визначення скільки необхідно заправити
            if (fuel > car.MaxVolume - car.Tank)
            {
                fuel = car.MaxVolume - car.Tank;
            }

            return fuel;
        }

    }
}
