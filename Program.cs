namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the dimension of the matrix\n");
            Console.Write("Number of elements along the x-axis: ");
            /* Запрос ввода размерности по X 
             * и попытка распарсить это значение в int
             */
            var quantityX = Console.ReadLine();
            bool chekQuantityX = int.TryParse(quantityX, out int parseQuantityX);
            while (chekQuantityX == false)
            {
                Console.Write("Input error, please try again: ");
                quantityX = Console.ReadLine();
                chekQuantityX = int.TryParse(quantityX, out parseQuantityX);
            }
            Console.WriteLine();
            /* Запрос ввода размерности по Y 
             * и попытка распарсить это значение в int
             */
            Console.Write("Number of elements along the y - axis: ");
            var quantityY = Console.ReadLine(); // вводим число элементов по оси Х
            bool chekQuantityY = int.TryParse(quantityY, out int parseQuantityY);
            while (chekQuantityY == false)
            {
                Console.Write("Input error, please try again: ");
                quantityY = Console.ReadLine();
                chekQuantityY = int.TryParse(quantityY, out parseQuantityY);
            }
            Console.WriteLine();
            /* Объявление массива с указанными X,Y */
            int[,] ArrayXY = new int[parseQuantityX, parseQuantityY];
            /* Здесь запрашиваем значения по X */
            for (int countX = 0; countX < parseQuantityX; countX++)
            {
                /* Здесь запрашиваем значения по Y */
                for (int countY = 0; countY < parseQuantityY; countY++)
                {
                    /* ArrayXY[countX, countY] - вводим значения поэлементно */
                    Console.Write($"Input X{countX},Y{countY}: ");
                    ArrayXY[countX, countY] = int.Parse(Console.ReadLine());

                }
            }
            Console.WriteLine();
            /*Выводим сначала значения по X (строки) */
            for (int countX = 0; countX < ArrayXY.GetLength(0); countX++)
            {
                /*Выводим значения по Y (столбцы) */
                for (int countY = 0; countY < ArrayXY.GetLength(1); countY++)
                {
                    Console.Write($"{ArrayXY[countX, countY]}\t");

                }
                /* Перенос строки после каждой выведенной строки по X*/

                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(" 1 - подсчет положительных и отрицательных элементов");
            Console.WriteLine(" 2 - сортировка от меньшего к большему");
            Console.WriteLine(" 3 - сортировка от большего к меньшему");
            Console.WriteLine(" 4 - меняем строки местами");
            Console.Write("Введите знак операции: ");
            var OperationSymbol = Console.ReadLine();
            bool chekOperationSymbol = int.TryParse(OperationSymbol, out int parseOperationSymbol);
            while (chekOperationSymbol == false)
            {
                Console.Write("Ошибка повторите ввод ");
                OperationSymbol = Console.ReadLine();
                chekOperationSymbol = int.TryParse(OperationSymbol, out parseOperationSymbol);
            }
            switch (parseOperationSymbol)
            {
                case 1:
                    /* Подсчёт положиетльных и отрицательных элементов */
                    int positiveValues = 0;
                    int negativeValues = 0;
                    /* Так как нам нужно просто перебрать все эллементы массива, то можно использовать foreach*/
                    foreach (int elementMatrix in ArrayXY)
                    {
                        if (elementMatrix >= 0)
                        {
                            positiveValues++;
                        }
                        else
                        {
                            negativeValues++;

                        }
                    }
                    Console.WriteLine($"Positive values: {positiveValues} count.");
                    Console.WriteLine($"Negative values: {negativeValues} count.");
                    Console.WriteLine();
                    break;
                case 2:
                    {
                        //Сортировка масива от меньшего к большему
                        int tempMinToMax;
                        for (int first = 0; first < ArrayXY.GetLength(0); first++)
                        {
                            for (int second = 0; second < ArrayXY.GetLength(1) - 1; second++)
                            {
                                if (ArrayXY[first, second] > ArrayXY[first, second + 1])
                                {
                                    tempMinToMax = ArrayXY[first, second];
                                    ArrayXY[first, second] = ArrayXY[first, second + 1];
                                    ArrayXY[first, second + 1] = tempMinToMax;
                                }
                            }
                        }
                        for (int countX = 0; countX < ArrayXY.GetLength(0); countX++)
                        {
                            for (int countY = 0; countY < ArrayXY.GetLength(1); countY++)
                            {
                                Console.Write($"{ArrayXY[countX, countY]}\t");

                            }
                            Console.WriteLine();


                        }
                        Console.WriteLine();
                        break;
                    }
                case 3:
                    {
                        //Сортировка массива от большего к меньшему
                        int tempMaxToMin;
                        for (int first = 0; first < ArrayXY.GetLength(0); first++)
                        {
                            for (int second = 0; second < ArrayXY.GetLength(1) - 1; second++)
                            {
                                if (ArrayXY[first, second + 1] > ArrayXY[first, second])
                                {
                                    tempMaxToMin = ArrayXY[first, second + 1];
                                    ArrayXY[first, second + 1] = ArrayXY[first, second];
                                    ArrayXY[first, second] = tempMaxToMin;
                                }
                            }
                        }
                        for (int countX = 0; countX < ArrayXY.GetLength(0); countX++)
                        {
                            for (int countY = 0; countY < ArrayXY.GetLength(1); countY++)
                            {
                                Console.Write($"{ArrayXY[countX, countY]}\t");

                            }
                            Console.WriteLine();


                        }
                        break;
                    }
                case 4:
                    {
                        var reversArrayXY = new int[ArrayXY.GetLength(0),ArrayXY.GetLength(1)] ;
                        int i = 0;
                        for (int x =  ArrayXY.GetLength(0)-1;x>=0;  x--)
                        {
                            int j = 0;
                            for (int y = 0; y < ArrayXY.GetLength(1); y++)
                            {
                                reversArrayXY[i, j] = ArrayXY[x, y];
                                j++;  
                            }
                            i++;
                        }
                        ArrayXY = reversArrayXY;
                         for (int countX = 0; countX < ArrayXY.GetLength(0); countX++)
                         {
                            for (int countY = 0; countY < ArrayXY.GetLength(1); countY++)
                            {
                                Console.Write($"{ArrayXY[countX, countY]}\t");

                            }
                            Console.WriteLine();


                         }
                    
                    

                    }
                break;

                    }
                

                    

                    
        }
    }
}





