using System;
using static TypeCastingDemo.Staff;

namespace TypeCastingDemo
{
    /// <summary>
    /// Комплексное число
    /// </summary>
    /// <inheritdoc/>
    public sealed class Complex : IEquatable<Complex>
    {
        /// <summary>
        /// Вещественная часть комплексного числа.
        /// </summary>
        private readonly double real;

        /// <summary>
        /// Мнимая часть комплексного числа.
        /// </summary>
        private readonly double imaginary;

        /// <summary>
        /// Конструктор комплексного числа
        /// </summary>
        /// <param name="re">Вещественная часть</param>
        /// <param name="im">Мнимая часть</param>
        public Complex(double re = 0, double im = 0)
        {
            real = re;
            imaginary = im;
        }

        public Complex(Complex arg)
        {
            real = arg.real;
            imaginary = arg.imaginary;
        }

        public double Modulo => 
            Math.Sqrt(real * real + imaginary * imaginary);

        public override string ToString() => 
            $"<{real}; {imaginary}>";

        // неявное приведение типов
        public static implicit operator Complex(double value) => 
            new Complex(value);

        // явное приведение типов
        public static explicit operator double(Complex value) => 
            value.real;

        public static bool operator ==(Complex lha, Complex rha)
        {
            if (ReferenceEquals(lha, rha))
                return true;

            if (ReferenceEquals(lha, null) || ReferenceEquals(rha, null))
                return false;

            return IsNear(lha.real, rha.real) 
                   && IsNear(lha.imaginary, rha.imaginary);
        }

        public static bool operator !=(Complex lha, Complex rha) => 
            !(lha == rha);

        public bool Equals(Complex other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return IsNear(Modulo, other.Modulo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as Complex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (real.GetHashCode() * 397) ^ imaginary.GetHashCode();
            }
        }


        public static bool operator >=(Complex lha, Complex rha) => 
            lha.Modulo >= rha.Modulo;

        public static bool operator <=(Complex lha, Complex rha) => 
            lha.Modulo <= rha.Modulo;

        public static bool operator >(Complex lha, Complex rha) => 
            !(lha <= rha);

        public static bool operator <(Complex lha, Complex rha) => 
            !(lha >= rha);

        public static Complex operator +(Complex lha, Complex rha) => 
            new Complex(lha.real + rha.real, lha.imaginary + rha.imaginary);

        public static Complex operator +(Complex arg) =>
            arg;

        public static Complex operator -(Complex arg) => 
            new Complex(-arg.real, -arg.imaginary);

        public static Complex operator -(Complex lha, Complex rha) =>
            lha + -rha;

        public static Complex operator *(Complex lha, Complex rha) =>
            new Complex(
                lha.real * rha.real - lha.imaginary * rha.imaginary,
                lha.real * rha.imaginary + rha.real * lha.imaginary);

        public static Complex operator *(Complex lha, double rha) =>
            new Complex(lha.real * rha, lha.imaginary * rha);

        public static Complex operator *(double lha, Complex rha) =>
            rha * lha;

    }
}