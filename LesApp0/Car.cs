using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Автомобіль
    /// </summary>
    class Car : NonRailVehicle
    {
        /// <summary>
        /// Назва
        /// </summary>
        public override string Name { get; set; }
        /// <summary>
        /// Модель
        /// </summary>
        public override string Model { get; set; }
        /// <summary>
        /// Колір транспорту
        /// </summary>
        public override ConsoleColor Color { get; set; }
        /// <summary>
        /// Рівень пального в баку
        /// </summary>
        public override int Tank { get { return tank; } }
        /// <summary>
        /// Об'єм бака
        /// </summary>
        public override int MaxVolume { get { return maxVolume; } }

        /// <summary>
        /// Конструктор, який створює авто
        /// </summary>
        /// <param name="tank">Наявне паливо в баку</param>
        /// <param name="maxVolume">Максимальний об'єм баку</param>
        public Car(int tank, int maxVolume)
        {
            this.tank = tank;
            this.maxVolume = maxVolume;
        }


        /// <summary>
        /// Рух транспорту
        /// </summary>
        public override void Move()
        {
            if (tank == 0)
            {
                Console.WriteLine($"\tБак пустий, поїздка неможлива.");
                return;
            }

            Console.WriteLine($"\n\tПального в баку до руху: {tank}");
            int spendFuel = SpendFuel();
            Console.WriteLine($"\tВитрачено пального за поїздку: {spendFuel}");
            tank -= spendFuel;
            Console.WriteLine($"\tПального в баку після поїздки: {tank}");
            if (tank == 0)
            {
                Console.WriteLine($"\tПальне в баку закінчилось.");
            }
        }

        /// <summary>
        /// Процес який відкриває доступ до баку
        /// </summary>
        /// <param name="gas">Пальне</param>
        public override void FillProcess(int gas, GasStation station)
        {
            // перевірка чи це та станція на якій можна заправитись
            // на майбутнє розширення, наприклад вона газова, потрібно дизель чи бензин
            if (!(station is GasStation))
            {
                Console.WriteLine("Дана заправка не підходить для такого транспорту.");
                return;
            }

            // заправка
            tank += gas;
        }

    }
}
