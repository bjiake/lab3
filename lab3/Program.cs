/*Патерн
class Client
{
    void Operation()
    {
        Prototype prototype = new ConcretePrototype1(1);
        Prototype clone = prototype.Clone();
        prototype = new ConcretePrototype2(2);
        clone = prototype.Clone();
    }
}

abstract class Prototype
{
    public int Id { get; private set; }
    public Prototype(int id)
    {
        this.Id = id;
    }
    public abstract Prototype Clone();
}

class ConcretePrototype1 : Prototype
{
    public ConcretePrototype1(int id)
        : base(id)
    { }
    public override Prototype Clone()
    {
        return new ConcretePrototype1(Id);
    }
}

class ConcretePrototype2 : Prototype
{
    public ConcretePrototype2(int id)
        : base(id)
    { }
    public override Prototype Clone()
    {
        return new ConcretePrototype2(Id);
    }
}
*/

/*гайд по перегрузке
 * Вместо op подставляется перегружаемая операция, например + или  /,  
 * а возвращаемый_тип обозначает конкретный тип значения, возвращаемого 
 * указанной операцией. Это значение может быть любого типа, но зачастую 
 * оно указывается такого же типа, как и у класса, для которого перегружается 
 * операция. Такая корреляция упрощает применение перегружаемых операций в 
 * выражениях. Для унарных операций операнд обозначает передаваемый операнд, 
 * а для бинарных операций то же самое обозначают операнд1 и операнд2. 
 * Заметим, что операторные методы должны иметь оба спецификатора типа — public и static.
// Форма перегрузки унарной операции
public static возвращаемый_тип operator op (тип_параметра операнд)
{
    // операторы
}

// Форма перегрузки бинарной операции
public static возвращаемый_тип operator op (тип_параметра1 операнд1,
тип_параметра2 операнд2)
{
    // операторы
}
*/
/*все что надо: приведения типов, нахождение детерминанта,обратная матрица

 * Унарные операции: +, false, true
 * Бинарные операции: +, *
 * Операции сравнения: >, < , > = , < = , = = , ! = 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace OperationOverload
{
    class Vector
    {
        public int x, y, z;// Координаты точки в трехмерном пространстве


        public Vector(int x = 0, int y = 0, int z = 0)// конструктор
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector operator <=(Vector v1, Vector v2)//Перегружаем операцию сравнения <=
        {
            Vector v = new();
            if (v1.x + v1.y + v1.z <= v2.x + v2.y + v2.z) { v = v1; }
            else { v = v2; }
            return v;
        }

        public static Vector operator >=(Vector v1, Vector v2)//Перегружаем операцию сравнения >=
        {
            Vector v = new();
            if (v1.x + v1.y + v1.z >= v2.x + v2.y + v2.z) { v = v1; }
            else { v = v2; }
            return v;
        }

        public static Vector operator ==(Vector v1, Vector v2)//Перегрузка сравнения ==
        {
            Vector v = new();
            if (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z) { v.x = 1; }
            else { v.x = 0; }
            return v;
        }

        public static Vector operator !=(Vector v1, Vector v2)//Перегрузка сравнения !=
        {
            Vector v = new();
            if (v1.x != v2.x && v1.y != v2.y && v1.z != v2.z) { v.x = 1; }
            else { v.x = 0; }
            return v;
        }

        public static Vector operator <(Vector v1, Vector v2)//Перегружаем операцию сравнения <
        {
            Vector v = new();
            if (v1.x + v1.y + v1.z < v2.x + v2.y + v2.z) { v = v1; }
            else { v = v2; }
            return v;
        }

        public static Vector operator >(Vector v1, Vector v2)//Перегружаем операцию сравнения >
        {
            Vector v = new();
            if (v1.x + v1.y + v1.z > v2.x + v2.y + v2.z) { v = v1; }
            else { v = v2; }
            return v;
        }

        public static bool operator true(Vector op)// Перегружаем унарную операцию true
        {
            if ((op.x > 0) && (op.y > 0) && (op.z > 0))
                return true; // все координаты больше нуля
            else
                return false;
        }

        public static bool operator false(Vector op)// Перегружаем унарную операцию false
        {
            if ((op.x < 0) && (op.y < 0) && (op.z < 0))
                return true; // все координаты меньше нуля
            else
                return false;
        }

        public static Vector operator +(Vector v1, Vector v2)// Перегружаем бинарную операцию + (сложение векторов)
        {
            Vector v = new Vector();
            v.x = v1.x + v2.x;
            v.y = v1.y + v2.y;
            v.z = v1.z + v2.z;
            return v;
        }

        public static Vector operator *(Vector v1, Vector v2)// Перегружаем бинарную операцию * (умножение векторов)
        {
            Vector v = new Vector();
            v.x = v1.x * v2.x;
            v.y = v1.y * v2.y;
            v.z = v1.z * v2.z;
            return v;
        }
        public void printV(string stroke, string stroke2)//Вывод
        {
            Console.WriteLine(stroke + x + " " + y + " " + z + " " + stroke2);
        }

        public override bool Equals(object obj)//Equals
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()//GetHashCode
        {
            throw new NotImplementedException();
        }

        public override string ToString()//ToString
        {
            return base.ToString();
        }
    }

    interface MainMatrix
    {
        static int Size { get; set; }
        protected static void FillMatrix(ref SquareMatrix matrix, int Size)
        {
            Random rand = new Random();

            matrix.Matrix = new int[Size, Size];

            for (int ColIndex = 0; ColIndex < Size; ++ColIndex)
            {
                for (int RowIndex = 0; RowIndex < Size; ++RowIndex)
                {
                    matrix.Matrix[ColIndex, RowIndex] = rand.Next(0, 9);
                }
            }
        }
        protected static void PrintOperations(
            SquareMatrix FirstMatrix,
            SquareMatrix SecondMatrix,
            string Operation,
            SquareMatrix Result,
            int size
        )
        {
            for (int ColIndex = 0; ColIndex < size; ++ColIndex)
            {
                for (int RowIndex = 0; RowIndex < size; ++RowIndex)
                {
                    Console.Write("{0,4}", FirstMatrix.Matrix[ColIndex, RowIndex]);
                }

                if (ColIndex == (int)size / 2)
                {
                    Console.Write("{0,4}", Operation);
                }
                else
                {
                    Console.Write("{0,4}", "");
                }

                for (int RowIndex = 0; RowIndex < size; ++RowIndex)
                {
                    Console.Write("{0,4}", SecondMatrix.Matrix[ColIndex, RowIndex]);
                }

                if (ColIndex == (int)size / 2)
                {
                    Console.Write("{0,4}", "=");
                }
                else
                {
                    Console.Write("{0,4}", "");
                }

                for (int RowIndex = 0; RowIndex < size; ++RowIndex)
                {
                    Console.Write("{0,4}", Result.Matrix[ColIndex, RowIndex]);
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
        protected static void PrintOperations(
           SquareMatrix FirstMatrix,
           SquareMatrix SecondMatrix,
           string Operation,
           bool Result,
           int size
       )
        {
            for (int ColIndex = 0; ColIndex < size; ++ColIndex)
            {
                Console.Write("|");
                for (int RowIndex = 0; RowIndex < size; ++RowIndex)
                {
                    Console.Write("{0,4}", FirstMatrix.Matrix[ColIndex, RowIndex]);
                }

                if (ColIndex == (int)size / 2)
                {
                    Console.Write("{0,4}", Operation);
                }
                else
                {
                    Console.Write("{0,4}", "");
                }

                for (int RowIndex = 0; RowIndex < size; ++RowIndex)
                {
                    Console.Write("{0,4}", SecondMatrix.Matrix[ColIndex, RowIndex]);
                }

                Console.Write("{0,4}", "|");

                if (ColIndex == (int)size / 2)
                {
                    Console.Write("{0,2}", "=");
                    Console.Write("{0,6}", Result);
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
        protected static void PrintOperations(int[,] MainMatrix, int Result, string Operation)
        {
            int MatrixSize = MainMatrix.GetLength(0);
            if (Operation == "FindDeterminant")
            {
                for (int ColIndex = 0; ColIndex < MatrixSize; ++ColIndex)
                {
                    if (ColIndex == (int)MatrixSize / 2)
                    {
                        Console.Write("{0,10}", "|A|(det) =");
                    }
                    else
                    {
                        Console.Write("{0,10}", "");
                    }
                    Console.Write("|");
                    for (int RowIndex = 0; RowIndex < MatrixSize; ++RowIndex)
                    {
                        Console.Write("{0,4}", MainMatrix[ColIndex, RowIndex]);
                    }
                    Console.Write("{0,4}", "|");

                    if (ColIndex == (int)MatrixSize / 2)
                    {
                        Console.Write($" = {Result}");
                    }

                    Console.WriteLine();
                }
            }
        }
        protected static void PrintOperations(int[,] MainMatrix, int[,] SecondMatrix, string Operation)
        {
            int MatrixSize = MainMatrix.GetLength(0);
            if (Operation == "FindTranspose")
            {
                for (int ColIndex = 0; ColIndex < MatrixSize; ++ColIndex)
                {
                    if (ColIndex == (int)MatrixSize / 2)
                    {
                        Console.Write("{0,4}", "A =");
                    }
                    else
                    {
                        Console.Write("{0,4}", "");
                    }
                    Console.Write("|");
                    for (int RowIndex = 0; RowIndex < MatrixSize; ++RowIndex)
                    {
                        Console.Write("{0,4}", MainMatrix[ColIndex, RowIndex]);
                    }
                    Console.Write("{0,4}", "|");

                    if (ColIndex == (int)MatrixSize / 2)
                    {
                        Console.Write("{0,17}", "; Transpose(A) = ");
                    }
                    else
                    {
                        Console.Write("{0,17}", "");
                    }
                    Console.Write("|");
                    for (int RowIndex = 0; RowIndex < MatrixSize; ++RowIndex)
                    {
                        Console.Write("{0,4}", SecondMatrix[ColIndex, RowIndex]);
                    }

                    Console.Write("{0,4}", "|");
                    Console.WriteLine();
                }
            }
            else if (Operation == "FindMinor")
            {
                for (int ColIndex = 0; ColIndex < MatrixSize; ++ColIndex)
                {
                    if (ColIndex == (int)MatrixSize / 2)
                    {
                        Console.Write("{0,4}", "A =");
                    }
                    else
                    {
                        Console.Write("{0,4}", "");
                    }
                    Console.Write("|");
                    for (int RowIndex = 0; RowIndex < MatrixSize; ++RowIndex)
                    {
                        Console.Write("{0,4}", MainMatrix[ColIndex, RowIndex]);
                    }
                    Console.Write("{0,4}", "|");

                    if (ColIndex == (int)MatrixSize / 2)
                    {
                        Console.Write("{0,13}", "; Minor(A) = ");
                    }
                    else
                    {
                        Console.Write("{0,13}", "");
                    }
                    Console.Write("|");
                    for (int RowIndex = 0; RowIndex < MatrixSize; ++RowIndex)
                    {
                        Console.Write("{0,4}", SecondMatrix[ColIndex, RowIndex]);
                    }

                    Console.Write("{0,4}", "|");
                    Console.WriteLine();
                }
            }
        }
        protected static void PrintOperations(int[,] MainMatrix, Double[,] Inverse, string Operation)
        {

            int MatrixSize = MainMatrix.GetLength(0);
            if (Operation == "FindInverseMatrix")
            {

                for (int ColIndex = 0; ColIndex < MatrixSize; ++ColIndex)
                {
                    if (ColIndex == (int)MatrixSize / 2)
                    {
                        Console.Write("{0,4}", "A =");
                    }
                    else
                    {
                        Console.Write("{0,4}", "");
                    }
                    Console.Write("|");
                    for (int RowIndex = 0; RowIndex < MatrixSize; ++RowIndex)
                    {
                        Console.Write("{0,4}", MainMatrix[ColIndex, RowIndex]);
                    }
                    Console.Write("{0,4}", "|");

                    if (ColIndex == (int)MatrixSize / 2)
                    {
                        Console.Write("{0,16}", "; Inverse(A) = ");
                    }
                    else
                    {
                        Console.Write("{0,16}", "");
                    }
                    Console.Write("|");
                    for (int RowIndex = 0; RowIndex < MatrixSize; ++RowIndex)
                    {
                        Console.Write("{0,6}", Inverse[ColIndex, RowIndex]);
                    }
                    Console.Write("{0,2}", "|");
                    Console.WriteLine();
                }
            }
        }
    }

    public class SquareMatrix : MainMatrix
    {
        private static int size { get; set; }

        public static int Size
        {
            get { return size; }
            set
            {
                if (value < 1)
                {
                    size = 1;
                }
                else
                {
                    size = value;
                }
            }
        }

        public int[,] Matrix;

        public static void FillAuto(SquareMatrix matrix)
        {
            MainMatrix.FillMatrix(ref matrix, Size);
        }
        private static int Determinant3x3(int[,] MainMatrix)
        {
            int det = default;
            int a = MainMatrix[0, 0],
                b = MainMatrix[0, 1],
                c = MainMatrix[0, 2],
                d = MainMatrix[1, 0],
                e = MainMatrix[1, 1],
                f = MainMatrix[1, 2],
                g = MainMatrix[2, 0],
                h = MainMatrix[2, 1],
                i = MainMatrix[2, 2];

            det = a * (e * i - f * h) - b * (d * i - f * g) + c * (d * h - e * g);
            return det;
        }
        public int[,] Matrix;

        public static void FillAuto(SquareMatrix matrix)
        {
            MainMatrix.FillMatrix(ref matrix, Size);
        }

        public SquareMatrix DeepCopy()
        {
            SquareMatrix clone = (SquareMatrix)this.MemberwiseClone();
            return clone;
        }
        /*Мусор, но пусть будет
        private static int Determinant3x3(int[,] MainMatrix)
        {
            int det = default;
            int a = MainMatrix[0, 0],
                b = MainMatrix[0, 1],
                c = MainMatrix[0, 2],
                d = MainMatrix[1, 0],
                e = MainMatrix[1, 1],
                f = MainMatrix[1, 2],
                g = MainMatrix[2, 0],
                h = MainMatrix[2, 1],
                i = MainMatrix[2, 2];

            det = a * (e * i - f * h) - b * (d * i - f * g) + c * (d * h - e * g);
            return det;
        }
        */
        private static int DeterminantOver3(int[,] MainMatrix)
        {
            /*
			a  b  c
			d  e  f 
			g  h  i
			
			|A| = a(ei − fh) − b(di − fg) + c(dh − eg)
			
			*/
            if (MainMatrix.GetLength(0) == 3)
            {
                return Determinant3x3(MainMatrix);
            }

            int DetSize = MainMatrix.GetLength(0) - 1,
                det = 0,
                RowIndex = 0,
                ColIndex = 0,
                MatIndex = MainMatrix.GetLength(0);

            int[,] DetMatrix = new int[DetSize, DetSize];

            for (int FirstColInd = 0; FirstColInd < MatIndex; ++FirstColInd)
            {
                for (int MatrixColumn = 1; MatrixColumn < MatIndex; ++MatrixColumn)
                {
                    for (int MatrixRow = 0; MatrixRow < MatIndex; ++MatrixRow)
                    {
                        if (MatrixRow == FirstColInd)
                        {
                            continue;
                        }
                        else
                        {
                            DetMatrix[ColIndex, RowIndex++] = MainMatrix[MatrixColumn, MatrixRow];
                        }
                    }
                    RowIndex = 0;
                    ++ColIndex;
                }
                ColIndex = 0;
                RowIndex = 0;
                if (FirstColInd % 2 == 0)
                {
                    det += MainMatrix[0, FirstColInd] * DeterminantOver3(DetMatrix);
                }
                else if (FirstColInd % 2 == 1)
                {
                    det -= MainMatrix[0, FirstColInd] * DeterminantOver3(DetMatrix);
                }

                DetMatrix = new int[DetSize, DetSize];
            }
            return det;
        }

        public static int FindDeterminant(int[,] MainMatrix, bool Print = true)
        {
            int det = default;
            int MatrixSize = MainMatrix.GetLength(0);
            if (MatrixSize == 2)
            {
                det = MainMatrix[0, 0] * MainMatrix[1, 1] - MainMatrix[1, 0] * MainMatrix[0, 1];
            }
            else if (MatrixSize == 3)
            {
                det = Determinant3x3(MainMatrix);
            }
            else if (MatrixSize > 3)
            {
                det = DeterminantOver3(MainMatrix);
            }
            if (Print)
            {
                MainMatrix.PrintOperations(MainMatrix, det, "FindDeterminant");
            }
            return det;


        }

        public static int[,] FindTranspose(int[,] MainMatrix, bool Print = true)
        {
            int MatrixSize = MainMatrix.GetLength(0);
            int[,] Transpose = new int[MatrixSize, MatrixSize];

            for (int i = 0; i < MatrixSize; ++i)
            {
                for (int j = 0; j < MatrixSize; ++j)
                {
                    Transpose[i, j] = MainMatrix[j, i];
                }
            }

            if (Print)
            {
                MainMatrix.PrintOperations(MainMatrix, Transpose, "FindTranspose");
            }

            return Transpose;
        }

        private static int[,] MinorOf3x3(int[,] MainMatrix)
        {
            /*
				| a11 a12 a13 | 
			A =	| a21 a22 a23 | 
				| a31 a32 a33 | 
			
						| a22 a23 | 
			a11 = M11 =	| a32 a33 | = a22*a33 - a23*a32
			*/
            int MatrixSize = MainMatrix.GetLength(0);

            int a11 = MainMatrix[0, 0],
                a12 = MainMatrix[0, 1],
                a13 = MainMatrix[0, 2],
                a21 = MainMatrix[1, 0],
                a22 = MainMatrix[1, 1],
                a23 = MainMatrix[1, 2],
                a31 = MainMatrix[2, 0],
                a32 = MainMatrix[2, 1],
                a33 = MainMatrix[2, 2];

            int M11 = a22 * a33 - a23 * a32,
                M12 = a21 * a33 - a23 * a31,
                M13 = a21 * a32 - a22 * a31,
                M21 = a12 * a33 - a13 * a32,
                M22 = a11 * a33 - a13 * a31,
                M23 = a11 * a32 - a12 * a31,
                M31 = a12 * a23 - a13 * a22,
                M32 = a11 * a23 - a13 * a21,
                M33 = a11 * a22 - a12 * a21;

            int[,] MinorMatrix = { { M11, M12, M13 }, { M21, M22, M23 }, { M31, M32, M33 } };

            return MinorMatrix;
        }

        private static int[,] MinorOf4x4(int[,] MainMatrix)
        {

            /*
				| a11 a12 a13 | 
			A =	| a21 a22 a23 | 
				| a31 a32 a33 | 
			
						| a22 a23 | 
			a11 = M11 =	| a32 a33 | = a22*a33 - a23*a32
			*/
            int MatrixSize = MainMatrix.GetLength(0);
            int[,] MinorMatrix = new int[MatrixSize, MatrixSize];


            return MinorMatrix;
        }
        public static int[,] FindMinor(int[,] MainMatrix, bool Print = true)
        {
            int MatrixSize = MainMatrix.GetLength(0);
            int[,] Minor = new int[MatrixSize, MatrixSize];

            if (MatrixSize == 2)
            {
                Minor[0, 0] = MainMatrix[1, 1];
                Minor[0, 1] = MainMatrix[1, 0];
                Minor[1, 0] = MainMatrix[0, 1];
                Minor[1, 1] = MainMatrix[0, 0];
            }
            else if (MatrixSize == 3)
            {
                Minor = MinorOf3x3(MainMatrix);
            }
            else if (MatrixSize > 3)
            {
                throw new IndexOutOfRangeException();
            }
            if (Print)
            {
                MainMatrix.PrintOperations(MainMatrix, Minor, "FindMinor");
            }
            return Minor;
        }
        public static double[,] FindInverseMatrix(int[,] MainMatrix, bool Print = true)
        {
            int MatrixSize = MainMatrix.GetLength(0);
            double[,] Inverse = new double[MatrixSize, MatrixSize];
            int[,] Transpose = FindTranspose(MainMatrix, Print: false);
            int Determinant = FindDeterminant(MainMatrix, Print: false);
            double rr = Math.Round(1 / Convert.ToDouble(Determinant), 2);

            for (int ColIndex = 0; ColIndex < MatrixSize; ++ColIndex)
            {
                for (int RowIndex = 0; RowIndex < MatrixSize; ++RowIndex)
                {
                    Inverse[ColIndex, RowIndex] = Math.Round(Convert.ToDouble(Transpose[ColIndex, RowIndex]) * rr, 2);
                }
            }
            if (Print)
            {
                MainMatrix.PrintOperations(MainMatrix, Inverse, "FindInverseMatrix");
            }

            return Inverse;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector V1 = new Vector(3, 4, 5);
            Vector V2 = new Vector(-3, -4, 5);

            V1.printV("Координаты первого вектора: ", " ");
            V2.printV("Координаты второго вектора: ", " ");

            Vector V3 = V1 + V2;    // ПЕРЕГРУЗКА! +
            V3.printV("Координаты суммы векторов: ", " ");

            V3 = V1 * V2;           // ПЕРЕГРУЗКА! *
            V3.printV("Координаты умножения векторов векторов: ", " ");

            //Перегрузка false, true
            if (V1)
            {
                Console.WriteLine("Точка V1 истинна.");
            }
            else
            {
                Console.WriteLine("Точка V1 ложна.");
            }
            if (V2)
            {
                Console.WriteLine("Точка V2 истинна.");
            }
            else
            {
                Console.WriteLine("Точка V2 ложна.");
            }

            V3 = V1 < V2; //Перегрузка >
            V3.printV("Вектор: ", "Меньше");

            V3 = V1 > V2;//Перегрузка <
            V3.printV("Вектор: ", "Больше");

            V3 = V1 >= V2;//Перегрузка >=
            V3.printV("Вектор: ", "Больше, либо равен");

            V3 = V1 <= V2;//Перегрузка <=
            V3.printV("Вектор: ", "Меньше, либо равен");

            V3 = V1 == V2;//Перегрузка ==
            if (V3.x == 1) { Console.WriteLine("Вектора равны"); }
            else { Console.WriteLine("Вектора не равны"); }

            V3 = V1 != V2;//Перегрузка !=
            if (V3.x == 0) { Console.WriteLine("Вектора равны"); }
            else { Console.WriteLine("Вектора не равны"); }

            Console.ReadLine();
        }
    }
    
}