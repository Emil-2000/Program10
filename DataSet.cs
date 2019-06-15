using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program10
{
    /// <summary>
    /// Класс включающий в себя элемент полинома, хранящий коэффициент и степень 
    /// Имеет метод для возврата значения элемента полинома при заданном x
    /// </summary>
    class DataSet
    {


        /// <summary>
        /// Показатель степени полинома
        /// </summary>
        public double i;
        
        /// <summary>
        /// Коэффициент полинома
        /// </summary>
        public double ai;

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public DataSet()
        {
            i = 0;
            ai = 0;
        }

        /// <summary>
        /// Конструткор с параметрами
        /// </summary>
        /// <param name="i"></param>
        /// <param name="ai"></param>
        public DataSet(double i, double ai)
        {
            this.i = i;
            this.ai = ai;
        }

        /// <summary>
        /// Вычисляет значение элемента полинома по заданным параметрам
        /// </summary>
        /// <param name="x">Значение х для которого необходимо рассчитать член полинома</param>
        /// <returns></returns>
        public double PolyMem(double x)
        {
            return Math.Pow(x, i) * ai;
        }

        /// <summary>
        /// переопределние метода ToString()
        /// для удобства отладки и отображения
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ai.ToString() +"  " + i.ToString();
        }
    }
}
