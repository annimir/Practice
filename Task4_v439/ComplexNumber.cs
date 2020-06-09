using System;

namespace Task4_v439
{
    class ComplexNumber
    {
        public struct Complex
        {
            public double re;
            public double im;
        }

        // Печать комплексного числа
        static void Print(Complex complex)
        {
            if (complex.re < 0)
            {
                Console.WriteLine(complex.re + "-" + complex.im + "i");
            }
            else
            {
                Console.WriteLine(complex.re + "+" + complex.im + "i");
            }
        }

        // Умножение комплексного на целое
        static void UmComplex(Complex complex, out Complex complex1, int k)
        {
            complex1.re = complex.re * k;
            complex1.im = complex.im * k;
        }

        // Деление комплексного на целое
        static void DelComplex(Complex complex, out Complex complex1, int k)
        {
            complex1.re = complex.re / k;
            complex1.im = complex.im / k;
        }

        // Вычитание из комплексного целого
        static void VchComplex(ref Complex complex, int k)
        {
            complex.re = complex.re - k;
        }

        // Сложение комплексных
        static void Summa(ref Complex complex,Complex complex1)
        {
            complex.re = complex.re + complex1.re;
            complex.im = complex.im + complex1.im;
        }

        // Разность комплексных
        static void Razn(ref Complex complex, Complex complex1)
        {
            complex.re = complex.re - complex1.re;
            complex.im = complex.im - complex1.im;
        }

        // Умножение комплексных
        static void Proizved(out Complex complex, Complex complex1, Complex complex2)
        {
            complex.re = complex1.re * complex2.re - complex1.im * complex2.im;
            complex.im = complex1.im * complex2.re + complex1.re * complex2.im;
        }

        // Ввод комплексного числа
        static Complex complexInput()
        {
            Complex complex = new Complex();
            Console.WriteLine("Введите действительную часть комплексного числа:");
            complex.re = numberInput();
            Console.WriteLine("Введите мнимую часть комплексного числа:");
            complex.im = numberInput();

            return complex;
        }

        // Ввод действительного числа
        static double numberInput()
        {
            double number;
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка. Вы не верно ввели число. Повторите ввод");
            }
            return number;
        }

        static void Main(string[] args)
        {          
            Console.WriteLine("ВВедите комплексное число u");
            Complex u = complexInput();

            Console.WriteLine("ВВедите комплексное число v");
            Complex v = complexInput();

            Console.WriteLine("ВВедите комплексное число w");
            Complex w = complexInput();

            Complex u1 = new Complex();
            Complex u2 = new Complex();
            Complex w1 = new Complex();
            Complex r = new Complex();

            UmComplex(u, out u1, 3);
            DelComplex(w, out w1, 2);
            Proizved(out r, u1, u2);
            Summa(ref r, w);
            Razn(ref r, u2);
            UmComplex(u, out u2, 2);
            Summa(ref r, u2);
            VchComplex(ref r, 7);

            Console.Write("2u+(3u*w/2+w-u)-7=");
            Print(r);
        }
    }
}
