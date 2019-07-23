using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Нерейковий транспортний засіб
    /// </summary>
    abstract class NonRailVehicle
    {
        /// <summary>
        /// Рівевнь заповнення баку пальним
        /// </summary>
        protected int tank;
        /// <summary>
        /// Максимальний розмір баку
        /// </summary>
        protected int maxVolume;
        /// <summary>
        /// Випадкові числа, творені тут, 
        /// так як при створенні в методі видаються однакові результати
        /// </summary>
        private Random rnd = new Random();

        /// <summary>
        /// Назва
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// Модель
        /// </summary>
        public virtual string Model { get; set; }
        /// <summary>
        /// Колір транспорту
        /// </summary>
        public virtual ConsoleColor Color { get; set; }
        /// <summary>
        /// Пальне в баку
        /// </summary>
        public virtual int Tank { get { return tank; } }
        /// <summary>
        /// Об'єм бака
        /// </summary>
        public virtual int MaxVolume { get { return maxVolume; } }

        /// <summary>
        /// Рух транспорту
        /// </summary>
        public abstract void Move();
        /// <summary>
        /// Витрати палива за одну поїздку
        /// </summary>
        /// <returns></returns>
        public int SpendFuel()
        {
            // мінімальні і максимальні витрати
            int minSpend = maxVolume / 4,   // мінімальна витрати - чверть баку 
                maxSpend = maxVolume;

            // випадкові значення витрат (+1 щоб було включене останнє значеня)
            int spendFuel = rnd.Next(minSpend, maxSpend + 1);

            // визначення витрати, якщо витрати більши за залишок в баку
            // то змінюємо на те що в баку лишилось
            if (spendFuel > tank)
            {
                spendFuel = tank;
            }

            return spendFuel;
        }

        /// <summary>
        ///  Процес який відкриває доступ до баку
        /// </summary>
        /// <param name="gas">Пальне</param>
        public abstract void FillProcess(int gas, GasStation station);

        public override string ToString()
        {
            return $"\n\tАвто: {Name} {Model}";
        }

    }
}
