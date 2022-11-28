using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp9
{
    class Program
    {
        static int TransTemp;
        static int RowsTemp;
        static int n = 3;
        static int[,] arr = new int[n * n, n * n]; 
        static string rowChar = "";
        static string lin = "#----------+---------+---------";
        static string futer = "#----------+---------+---------";
        static int pint_numDa = 0;//красит 0
        static int Level;//кол-во 0
        static int[] ArrOne = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        //Судоку. Зробити три різні види складності.
        //Додати конструктор судоку.(користувач сам вводить своє судоку)
        //В конструкторі обов’язково перевіряти валідність створеного судоку.

        static void Check_1x_ArrayNaPovtor_Blok3x3(int[] arr_one)
        {

            for (int i = 0; i < n * n; i++)
            {
                int i2 = 0;
                int fr = ArrOne[i];

                for (int j = 0; j < n * n; j++)
                {

                    if (ArrOne[j] != 0 && fr == ArrOne[j])
                    {
                        i2++;
                    }
                }

                if (i2 == 2)
                {
                    Console.WriteLine("Помилка в блоці !!!");
                    break;
                }
            }
        }

        static void Check_1x_ArrayNaPovtor_Line(int[] arr_one)
        {

            for (int i = 0; i < n * n; i++)
            {
                int fr = ArrOne[i];
                int i2 = 0;
                for (int j = 0; j < n * n; j++)
                {
                    if (ArrOne[j] != 0 && fr == ArrOne[j])
                    {
                        i2++;
                    }
                }
                if (i2 == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Помилка в лінії !!!");

                    /////////Отрисовка проблемной линии
                    foreach (int t in ArrOne)
                    {
                        Console.Write($"{t}");
                    }
                    
                    break;
                }
            }
            
        }

        static void Check_1x_ArrayNaPovtor_Coloms(int[] arr_one)
        {

            for (int i = 0; i < n * n; i++)
            {
                int fr = ArrOne[i];
                int i2 = 0;
                for (int j = 0; j < n * n; j++)
                {
                    if (ArrOne[j] != 0 && fr == ArrOne[j])
                    {
                        i2++;
                    }
                }
                if (i2 == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Помилка в стовпці !!!");

                    /////////Отрисовка проблемной линии
                    foreach (int t in ArrOne)
                    {
                        Console.Write($"{t}");
                    }
                    break;
                }
            }

        }

        static void Valid_chekedBox(int[,] arr_chek)
        {

            for (int width = 0; width < 9; width = width + 3)
            {

                for (int Length = 0; Length < 9; Length += 3)
                {

                    int a = 0;//індекс

                    for (int CurrentWidth = width; CurrentWidth < width + 3; CurrentWidth++)
                    {

                        for (int CurrentLenght = Length; CurrentLenght < Length + 3; CurrentLenght++)
                        {
                            if (a <= 8)
                            {
                                ArrOne[a] = arr[CurrentWidth, CurrentLenght];
                                a++;

                            }

                        }

                    }

                    Check_1x_ArrayNaPovtor_Blok3x3(ArrOne);

                }

            }

            //лінії
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int a = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (a <= 8)
                    {
                        ArrOne[a] = arr[i, j];
                        a++;
                    }

                }
                Check_1x_ArrayNaPovtor_Line(ArrOne);

            }


            Transponder();//смена местами столбцы и линии

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int a = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (a <= 8)
                    {
                        ArrOne[a] = arr[i, j];
                        a++;
                    }

                }
                Check_1x_ArrayNaPovtor_Coloms(ArrOne);
            }
            Transponder();

        }

        private static void Transponder()
        {
            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < i; j++)
                {

                    TransTemp = arr[i, j];
                    arr[i, j] = arr[j, i];
                    arr[j, i] = TransTemp;

                }
            }
        }


        static void Drawing(int[,] arr_sample, int pint_num)
        {
            int iter = 0;

            Console.WriteLine(rowChar);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("   0  1  2   3  4  5   6  7  8");

            //Ось Y
            for (int y = 0; y < n * n; y++)
            {
                //Console.ForegroundColor = ConsoleColor.Red;

                if (y % 3 == 0 && y != 0)
                {
                    Console.ResetColor();
                    Console.WriteLine(lin);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                // Ось X
                for (int x = 0; x < n * n; x++)
                {
                    // Создание навигации по матрице 
                    if (x == 0)
                    {
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write($"{iter}");
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    // Закрашивание 
                    if (arr[y, x] == pint_num && x != 0)
                    {
                        //Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    // Reset color after "|"
                    if (x % 3 == 0)
                    {
                        Console.ResetColor();
                        Console.Write("|");
                        // Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                   // Проверка после основной маркировки по осям X Y

                   if (arr[y, x] != pint_num)
                   {
                        Console.ResetColor();
                   }

                   // ###################################################

                    Console.Write($" {arr[y, x]} ");
                }
                Console.WriteLine();
                iter++;
            }

            Console.ResetColor();
            Console.WriteLine(futer);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("  Вітаємо Вас у консольній грі \"Судоку\"! Ця гра є доволі відомою японською головоломкою з числами.");
            Console.WriteLine("Вам буде надано поле 9х9, котре розділене на менші квадрати (блоки) розмірністю 3х3 клітинки.");
            Console.WriteLine("  Основними правилами гри є:");
            Console.WriteLine("- заповленння кожної клітники числами тільки від 1 до 9; ");
            Console.WriteLine("- кожна цифра має зустріцатися лише 1 раз у стовпці, рядку та блоці.");
            Console.WriteLine();
            Console.WriteLine("А тепер оберіть рівень складності гри або ж створіть її власноруч.");
            Console.WriteLine("\n 1-легкий рівень; \n 2- нормальний рівень; \n 3-складний рівень; \n 4- створення \"Судоку\" власноруч ");

            string enterNum = Console.ReadLine();

            int playersnum = Convert.ToInt32(enterNum);

            switch (playersnum)
            {
                case 1:
                    Console.WriteLine("Ви обрали легкий рівень \"Судоку\"");
                    Random ran1 = new Random();
                    Level= 40;//кол-во 0
                    break;
                case 2:
                    Random ran2 = new Random();
                    Level = 50;
                    Console.WriteLine("Ви обрали нормальний рівень \"Судоку\"");
                    break;
                case 3:
                    Random ran3 = new Random();
                    Level = 60;
                    Console.WriteLine("Ви обрали складний рівень \"Судоку\"");
                    break;
                case 4:
                    Console.WriteLine("Ви обрали створення власної гри \"Судоку\"");
                    break;

            }

            Random ran = new Random();


            int[,] ArrTrue = new int[n * n, n * n];

            for (int i = 0; i < n * n; i++)
            {
                for (int j = 0; j < n * n; j++)
                {
                    if (playersnum == 1 || playersnum == 2 || playersnum == 3)
                    {
                        arr[i, j] = (i * n + i / n + j) % (n * n) + 1;
                    }
                    if(playersnum==4)
                    {
                        arr[i, j] = 0;
                    }
                }
            }

            //#########################(Main)##################################

            Transponder();

            swap_rows_line();

            swap_colums_line();

            swap_rows_area();

            swap_colums_area();

            Random_span();

            Console.WriteLine();

            while (true)
            {
                Game_Logics();//проверка игры
                Valid_chekedBox(arr);
            }

            //#############################################################

            void Transponder()
            {
                Console.WriteLine(rowChar);
                for (int i = 0; i < n * n; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        TransTemp = arr[i, j];
                        arr[i, j] = arr[j, i];
                        arr[j, i] = TransTemp;
                    }
                }
            }

            void swap_rows_line()
            {
                Console.WriteLine(rowChar);

                for (int i = 0; i < n * n; i++)
                {
                    for (int j = 0; j < n * n; j++)
                    {
                        if (i == 0)
                        {
                            RowsTemp = arr[i, j];
                            arr[i, j] = arr[i + 2, j];
                            arr[i + 2, j] = RowsTemp;
                        }
                    }
                }
            }

            void swap_colums_line()
            {
                Console.WriteLine(rowChar);

                for (int i = 0; i < n * n; i++)
                {
                    for (int j = 0; j < n * n; j++)
                    {
                        if (j == n + 3 || j == n * n)
                        {
                            RowsTemp = arr[i, j];
                            arr[i, j] = arr[i, j + 2];
                            arr[i, j + 2] = RowsTemp;
                        }
                    }
                }
            }

            void swap_rows_area()
            {
                Console.WriteLine(rowChar);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n * n; j++)
                    {
                        RowsTemp = arr[i, j];
                        arr[i, j] = arr[i + 3, j];
                        arr[i + 3, j] = RowsTemp;
                    }

                }

            }

            void swap_colums_area()
            {
                Console.WriteLine(rowChar);

                for (int i = 0; i < n * n; i++)
                {
                    for (int j = 3; j < n * n; j++)
                    {
                        if (j == 3 || j == 4 || j == 5)
                        {
                            RowsTemp = arr[i, j];
                            arr[i, j] = arr[i, j + 3];
                            arr[i, j + 3] = RowsTemp;
                        }
                    }

                }

            }

            void Random_span()
            {
                int g = 0;
                Drawing(ArrTrue, pint_numDa);
                for (int i = 0; i < n * n; i++)
                {
                    for (int j = 0; j < n * n; j++)
                    {
                        ArrTrue[i, j] = arr[i, j];
                    }
                }
                while (g != Level)
                {
                    int randNum_1 = ran.Next(0, 9);
                    int randNum_2 = ran.Next(0, 9);

                    arr[randNum_1, randNum_2] = 0;
                    g++;
                }
                Drawing(arr, pint_numDa);
            }

            void Game_Logics()
            {
                try
                {
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Num_X : ");

                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                int Num_Y = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();

                Console.WriteLine("Num_Y : ");

                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                int Num_X = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();

                Console.WriteLine("Write your num : ");
                Console.ResetColor();

                int Num_My = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();
                    

                    if (playersnum == 1 || playersnum == 2 || playersnum == 3 && Num_My == ArrTrue[Num_Y, Num_X])
                    {
                        arr[Num_Y, Num_X] = Num_My;

                    }
                    
                    else if (playersnum == 4) 
                    {
                        arr[Num_Y, Num_X] = Num_My;

                    }
                    if(Num_My != ArrTrue[Num_Y, Num_X])
                    {
                        Console.WriteLine("Спробуйте ще раз.");
                    }
                    
                    Drawing(arr, pint_numDa);

                }
                catch {Console.WriteLine("Упс, Ви помилилися)");}
            }
        }
    }
}


