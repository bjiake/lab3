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
 * Операции сравнения: >, < > = , < = , = = , ! = 
 */
using System;
namespace OperationOverload
{
    class Vector
    {
        // Координаты точки в трехмерном пространстве
        public int x, y, z;

        // конструктор
        public Vector(int x = 0, int y = 0, int z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        //Перегружаем операцию сравнения <
        public static Vector operator <(Vector v1, Vector v2)
        {
            if (v1 < v2)
            {
                return v1;
            }
            else
            {
                return v2;
            }
        }
        //Перегружаем операцию сравнения >
        public static Vector operator >(Vector v1, Vector v2)
        {   
            if(v1 < v2)
            {
                return v2;
            }
            else
            {
                return v1;
            }
        }
        // Перегружаем унарную операцию true
        public static bool operator true(Vector op)
        {
            if ((op.x > 0) && (op.y > 0) && (op.z > 0))
                return true; // все координаты больше нуля
            else
                return false;
        }
        // Перегружаем унарную операцию false
        public static bool operator false(Vector op)
        {
            if ((op.x < 0) && (op.y < 0) && (op.z < 0))
                return true; // все координаты меньше нуля
            else
                return false;
        }
        // Перегружаем бинарную операцию + (сложение векторов)
        public static Vector operator +(Vector v1, Vector v2)
        {
            Vector v = new Vector();
            v.x = v1.x + v2.x;
            v.y = v1.y + v2.y;
            v.z = v1.z + v2.z;
            return v;
        }
        // Перегружаем бинарную операцию * (умножение векторов)
        public static Vector operator *(Vector v1, Vector v2)
        {
            Vector v = new Vector();
            v.x = v1.x * v2.x;
            v.y = v1.y * v2.y;
            v.z = v1.z * v2.z;
            return v;
        }
        public void printV(string s)
        {
            Console.WriteLine(s + x + " " + y + " " + z);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector V1 = new Vector(3, 4, 5);
            Vector V2 = new Vector(-3, -4, 5);

            V1.printV("Координаты первого вектора: ");
            V2.printV("Координаты второго вектора: ");

            Vector V3 = V1 + V2;    // ПЕРЕГРУЗКА! +
            V3.printV("Координаты суммы векторов: ");

            V3 = V1 * V2;           // ПЕРЕГРУЗКА! *
            V3.printV("Координаты умножения векторов векторов: ");

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

            //Перегрузка >, <
            V3 = V1 < V2;
            V3.printV("V2 больше");
            V3 = V1 > V2;
            Console.ReadLine();
        }
    }
}