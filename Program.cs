using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public class Fighter {
            public string Name { get; private set; }
            public int Health { get; set; }
            public int DamagePerAttack { get; private set; }
            public Fighter(string name, int health, int damage)
            {
                this.Name = name;
                this.Health = health;
                this.DamagePerAttack = damage;
            }
        }

        // Написать метод, который определяет победителя схватки двух бойцов.
        // Схватка происходит следующим образом: случайным образом определяется 
        // первый нападающий, после чего он наносит удар.
        // Далее бойцы наносят удары по очереди. В результате удара у бойца отнимается 
        // столько жизней, какой силой удара обладает нападающий.
        // Проигравшим считается тот, у кого уровень жизней меньше или равно 0.

        // метод
        public static void WhoWinner(params Fighter[] fighters)
        {
            // Создаём объект для генерации чисел
            Random rnd = new Random();
            // Получаем случайное число (в диапазоне от 0 до 1 включительно)
            int who_fights = rnd.Next(0, 2);
            int whom_fights = who_fights == 0 ? 1 : 0;

            if (fighters[0].Health <= 0 || fighters[1].Health <= 0)
                return;

            while (fighters[0].Health > 0 && fighters[1].Health > 0)
            {
                // у бойца whom_fights отнимается столько жизней, какой силой удара обладает нападающий who_fights
                fighters[whom_fights].Health -= fighters[who_fights].DamagePerAttack;
                // меняем игрока, который нападает
                who_fights = whom_fights;
                whom_fights = who_fights == 0 ? 1 : 0;
            }
            // вывод победителя
            Console.WriteLine(fighters[whom_fights].Name + " выиграл!!!");
        }

        static void Main(string[] args)
        {
            // тестируем
            Fighter f1 = new Fighter("Julia", 51, 17);
            Fighter f2 = new Fighter("Helen", 50, 17);
            WhoWinner(f1, f2);
            //Console.ReadKey();
        }
    }
}
