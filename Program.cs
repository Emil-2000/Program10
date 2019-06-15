using System;
using System.Linq;


namespace Program10
{
    class Program
    {
        static void Main(string[] args)
        {
            // загружаем данные в список
            MyList<DataSet> PolynomCoeff = LoadData("INPUT.TXT");
            Console.WriteLine("Данные из файла загружены.");
            Console.WriteLine("Всего в файле " + PolynomCoeff.Count + " корректных значений пар коэффициентов полинома и показателей степеней");
            MyList<double> X_Values = new MyList<double>();
            // запускаем цикл ввода
            Console.WriteLine("\nВведите значения X, для досрочного завершения ввода введите 0");
            for (int i = 0; i < PolynomCoeff.Count; i++)
            {
                Console.Write("Введите Х для " + i + " позиции: ");
                double X = CheckInputDouble();
                // выходим по значению 0
                if (X == 0)
                    break;
                X_Values.Add(X);
            }

            double P = 0;
            // рассчитываем полином
            for (int i = 0; i < X_Values.Count; i++)
            {
                P += PolynomCoeff[i].PolyMem(X_Values[i]);
            }
            Console.WriteLine("Значение полинома :" + P);
            Console.ReadLine();

        }

        /// <summary>
        /// Загружает данные из файла
        /// </summary>
        /// <param name="FileName">Имя файла</param>
        /// <returns></returns>
        static MyList<DataSet> LoadData(string FileName)
        {
            MyList<DataSet> result = new MyList<DataSet>();
            string line = "";
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(FileName);
                // считываем построчно
                while ((line = file.ReadLine()) != null)
                {
                    // разделим строку на подстроки, разделителем выступит пробел
                    string[] lines = line.Split(' ');
                    if (lines.Count() < 2)
                    {
                        Console.WriteLine("Ошибка формата файла!!!");
                        return result;
                    }
                    double ai = ConvertToDouble(lines[0]);
                    double i = ConvertToDouble(lines[1]);
                    // по условию задания надо игнорировать записи с ai=0
                    if (ai == 0)
                        continue;
                    result.Add(new DataSet(i, ai));
                }
                file.Close();
            }
            catch
            {
                Console.WriteLine("Ошибка чтения файла!!");
                throw new Exception("Ошибка чтения файла!!");
            }
            return result;
        }


        /// <summary>
        /// Метод контроля правильности ввода для double
        /// </summary>
        /// <returns>значение double</returns>
        static double ConvertToDouble(string value)
        {
            double result = 0;
            string inp = value;
            // если случайно поставили точку вместо запятой, заменим ее
            inp = inp.Replace(".", ",");
            // пробуем разобрать введенный 
            if (!Double.TryParse(inp, out result))
            {
                Console.WriteLine("Ошибка входных данных в файле ");
                throw new Exception("Invalid file format");
            }

            return result;
        }

        /// <summary>
        /// Метод контроля правильности ввода для double
        /// </summary>
        /// <returns>значение double</returns>
        static double CheckInputDouble()
        {
            double result = 0;
            do
            {
                string inp = Console.ReadLine();
                // если случайно поставили точку вместо запятой, заменим ее
                inp = inp.Replace(".", ",");
                // пробуем разобрать введенный 
                if (Double.TryParse(inp, out result))
                    break;
                Console.WriteLine("Ошибка ввода! Повторите ввод!!");
            }
            while (true);
            return result;
        }
    }
}
