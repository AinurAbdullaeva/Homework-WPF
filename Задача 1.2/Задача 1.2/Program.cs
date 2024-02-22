using System.IO;

public class Goal {
    public double dist_x, height, wideth;
    public Goal() {
        StreamReader gp = new StreamReader("gp.txt");
        dist_x = Convert.ToDouble(gp.ReadLine());
        height = Convert.ToDouble(gp.ReadLine());
        wideth= Convert.ToDouble(gp.ReadLine());
        gp.Close();
    }
}
public class Bird : Goal{
    
    double x, y, t, alph, v0, t_max, x_max;
    double g = 9.8;
    public Bird() {
        StreamReader ab = new StreamReader("ab.txt");
   
        t= Convert.ToDouble(ab.ReadLine());
        alph= (Math.PI / 180)*Convert.ToDouble(ab.ReadLine());
        v0= Convert.ToDouble(ab.ReadLine());
        ab.Close();
        t_max = 2 * v0 * Math.Sin(alph) / g;
        x_max = t_max * v0 * Math.Cos(alph);

    }
    public double Count_x(double t)
    {
        double x = v0 * t * Math.Cos(alph);
        return x;
    }
    public double Count_y( double t)
    {
        double y = Math.Abs(v0 * t * Math.Sin(alph) - (g * t * t) / 2);
        return y;
    }
    public  void Count_coord()
    {
        
        x = v0 * t * Math.Cos(alph);
        y = v0 * t * Math.Sin(alph) - (g * t * t) / 2;
        if (t > t_max)
        {
            Console.WriteLine("Тело уже упало");
            x = x_max;
            y = 0;
        }
        Console.WriteLine("x:{0} y{1} ", x, y);
    }
    public void Win() {
        Goal pig= new Goal();
        if (x_max < dist_x)
        {
            Console.WriteLine("Тело не долетело до препяствия");
            Count_coord();
        }
        else
        {
            double t_p = dist_x / (v0 * Math.Cos((Math.PI / 180) * alph));
            double t_pp = (dist_x + wideth) / (v0 * Math.Cos((Math.PI / 180) * alph));//момент времени когда тело достигнет
            double y_p = Count_y(t_p);
            if (y_p <= height && y_p > 0)
            {
                // Вычисляем координаты и скорость с промежутком в 0.5с

                for (double tmpt = 0; tmpt < t; tmpt += 0.5)
                {

                    double x = Count_x(tmpt);
                    Console.WriteLine("x:{0}", x);

                    double y = Count_y(tmpt);
                    Console.WriteLine("y:{0}", y);

                    if (x >= dist_x)
                    {
                        Console.WriteLine("Тело врезалось в препятствие");
                        Console.WriteLine("x:{0}", x);
                        Console.WriteLine("y:{0}", y);
                        break;
                    }
                }
            }
            else if (y_p>height && (Count_y(t_pp)<=height))
            {
                for (double tmpt = 0; tmpt < t; tmpt += 0.5)
                {
                    double x = Count_x(tmpt);
                    Console.WriteLine("x:{0}", x);
                    double y = Count_y(tmpt);
                    Console.WriteLine("y:{0}", y);

                    if (y == height) {
                        Console.WriteLine("Тело врезалось в препятствие");
                        Console.WriteLine("x:{0}", x);
                        Console.WriteLine("y:{0}", y);
                    }
                }
            }
            else  Console.WriteLine("Тело прелетело через препятсвие");


        }
    }
}
public class Programm { 
    public static void Main(string[] args)
    {
        Bird Bomb = new Bird();
        Bomb.Win();
    }

}

