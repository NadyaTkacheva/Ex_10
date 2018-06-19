using System;

namespace Task_10
{/// <summary>
/// класс для однонаправленного списка
/// </summary>
    class Point
    {
        public int data;//информационное поле
        public Point next;//адресное поле

        public Point(int d)//конструктор с параметрами
        {
            data = d;
            next = null;
        }
        public Point()//конструктор без параметра
        {
            data = 0;
            next = null;
        }
        //перегрузка для вывода
        public override string ToString()
        {
            return data + " ";
        }

    }
    class Program
    {/// <summary>
    /// создание списка вручную
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
        static Point MakeListToEnd(int size)
        {
            if (size == 0) return null;

            Console.WriteLine("Введите элементы типа string ");
            Console.WriteLine("Введите 1 элемент ");
            int info = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Элемент {0} добавлен...", info);
            Point beg = new Point (info);
            Point r = beg;
            for (int i = 1; i < size; i++)
            {
                Console.WriteLine("Введите {0} элемент", i + 1);
                info = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Элемент {0} добавлен...", info);
                Point p = new Point(info);
                r.next = p;
                r = p;
            }
            Console.Clear();
            return beg;
        }
        /// <summary>
        /// проверка на ввод
        /// </summary>
        /// <returns></returns>
        static int Input()
        {
            int a = 0;
            bool ok;
            do
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    ok = true;

                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Введите целое число");
                    ok = false;
                }
            } while (!ok);
            return a;
        }
 /// <summary>
 /// создание списка с ДСЧ
 /// </summary>
 /// <param name="size"></param>
 /// <returns></returns>
        static Point MakeListToEndRandom(int size)
        {
            Random rnd = new Random();
            if (size == 0) return null;

            Point beg = new Point(rnd.Next(-100, 100));
            Point r = beg;
            for (int i = 1; i < size; i++)
            {               
                Point p = new Point(rnd.Next(-100, 100));
                r.next = p;
                r = p;
            }
            Console.Clear();
            return beg;

        }
        /// <summary>
        /// проверка последовательности на упорядоченность по убыванию
        /// </summary>
        /// <param name="beg"></param>
       public static void CkeckPoint( Point beg)
        {
            Point p = beg;
            bool ok = true;
           
            while (p.next!= null&&ok==true)
            {
                if (p.data > p.next.data)
                    ok = false;
                p = p.next;
            }
            if (ok == false)
            {
                Console.WriteLine("Получена новая последовательность (инвертированная). ");
                ShowList(Reverse(beg));
            }
            else
            {
                Console.WriteLine("Последовательность осталась без изменений. ");
                ShowList(beg);
            }

        }
        /// <summary>
        /// инвертирование списка
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static Point Reverse(Point root)
        {
            Point prev = null;
            Point curr = root;
            while (curr != null)
            {
                var next = curr.next;

                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }

        /// <summary>
        /// вывод списка
        /// </summary>
        /// <param name="beg"></param>
        static void ShowList(Point beg)
        {
            //проверка наличия элементов в списке
            if (beg == null)
            {
                Console.WriteLine("Элементов в списке нет.");
                return;
            }
            Point p = beg;           
            while (p != null)
            {
                Console.Write(p);
                p = p.next;//переход к следующему элементу
            }
            Console.WriteLine();
        }
        /// <summary>
        /// меню
        /// </summary>
        static void Choice()
        {
            Point beg = new Point();
            int userChoice = 0;
            Console.WriteLine("Введите кол-во элементов последовательности (n): ");
            int size = Input();
            
            do
            {
                Console.WriteLine("Выберите, как ввести числа:\n1.ДСЧ\n2.Вручную");
                userChoice = Input();
                if (userChoice > 2 || userChoice < 1)
                    Console.WriteLine("Ошибка! Введите число от 1 до 2");
            } while (userChoice > 3 || userChoice < 1);
            if (userChoice == 1)
            {
                beg = MakeListToEndRandom(size);
                Console.WriteLine("Исходная последовательность: ");
                ShowList(beg);
                CkeckPoint(beg);
            }
            else
            { beg = MakeListToEnd(size);
                Console.WriteLine("Исходная последовательность: ");
                ShowList(beg);
                CkeckPoint(beg);
            }
            
        }
        static void Main(string[] args)
        {
            Choice();
            Console.ReadKey();
        }
    }
}
