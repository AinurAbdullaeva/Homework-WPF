using System;
public class Program
{ 
    public static double Count_x(double alph, double v0, double t)
    {
        double x = v0 * t * Math.Cos(alph);
        return x;
    }
    public static double Count_y(double alph, double v0, double t, double g)
    {
        double y = Math.Abs(v0 * t * Math.Sin(alph) - (g * t * t) / 2);
        return y;
    }
    public static void Count_coord(double alph, double v0, double t)
    {

        double g = 9.8;
        double x, y;
        double t_max, x_max;
        t_max = 2 * v0 * Math.Sin(alph) / g;
        x_max = t_max * v0 * Math.Cos(alph);
        x = v0 * t * Math.Cos(alph);
        y = v0 * t * Math.Sin(alph) - (g * t * t) / 2;
        if (t > t_max)
        {
            Console.WriteLine("Тело уже упало" );
            x = x_max;
            y = 0;
        }
        Console.WriteLine("x:{0} y{1} ",x,y);
    }
    public static void Main()
    {
        double alph, v0, t, hp, sp, t_p;
        double g = 9.8;
        Console.WriteLine("Введите угол в градусах");
        alph =Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите скорость в метрах в секунду");
        v0 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите время в секундах");
        t= Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите расстояние до препятствия ");
        sp = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите высоту препятствия ");
        hp = Convert.ToDouble(Console.ReadLine());
        double t_max = 2 * v0 * Math.Sin((Math.PI / 180) * alph) / g;
        double x_max = Count_x((Math.PI / 180) * alph, v0, t_max);
        if (x_max < sp)
        {
            Console.WriteLine ("Тело не долетело до препяствия");
            Count_coord((Math.PI / 180) * alph, v0, t);
        }
        else
        {
            t_p = sp / (v0 * Math.Cos((Math.PI / 180) * alph)); //момент времени когда тело будет находитьпрепятствия
            double y_p = Count_y((Math.PI / 180) * alph, v0, t_p, g);
            if (y_p <= hp && y_p > 0)
            {
                // Вычисляем координаты и скорость с промежутком в 0.5с

                for (double tmpt = 0; tmpt < t; tmpt += 0.5)
                {

                    double x = Count_x(alph, v0, tmpt);
                    Console.WriteLine("x:{0}", x);

                    double y = Count_y(alph, v0, tmpt, g);
                    Console.WriteLine("y:{0}", y);

                    if (x >= sp)
                    {
                        Console.WriteLine("Тело врезалось в препятствие");
                        Console.WriteLine("x:{0}", x);
                        Console.WriteLine("y:{0}", y);
                        break;
                    }
                }
            }
        }




    }

}


