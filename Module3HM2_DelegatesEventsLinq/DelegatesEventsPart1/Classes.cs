using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsPart1
{
    public static class ClassShow
    {
        public delegate void Show(bool value);
        public static double Multiply(double numberA, double numberB) => numberA * numberB;
    }

    public class ClassResult
    {

        private double _result;

        public delegate bool ResultDel(double value);

        public ResultDel Calc(Func<double,double,double> multiple, double numberA, double numberB)
        {
            multiple = ClassShow.Multiply;
            _result = multiple(numberA, numberB);
            return Result;
        }

        public bool Result(double value)
        {
            return _result % value == 0;
        }
        
    }
}
