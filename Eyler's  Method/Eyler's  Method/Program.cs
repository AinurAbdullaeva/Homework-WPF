using System.IO;

public class Goal
{
    public double dist_x, height, wideth;
    public Goal()
    {
        StreamReader gp = new StreamReader("gp.txt");
        dist_x = Convert.ToDouble(gp.ReadLine());
        height = Convert.ToDouble(gp.ReadLine());
        wideth = Convert.ToDouble(gp.ReadLine());
        gp.Close();
    }
}
public class Bird : Goal
{

    double x, y, t, alph, v0, m;
    double g = 9.8;
    const double k= 0.3;
    public delegate void Message();
    public event Message Info;
    double [] coord_x = new double [20];
    double [] coord_y = new double[20];
    double [] count_vx = new double[20];
    double[] count_vy = new double[20];
    public Bird(string file)
    {
        StreamReader ab = new StreamReader(file);

        t = Convert.ToDouble(ab.ReadLine());
        alph = (Math.PI / 180) * Convert.ToDouble(ab.ReadLine());
        v0 = Convert.ToDouble(ab.ReadLine());
        m = Convert.ToDouble(ab.ReadLine());
        ab.Close();
        coord_x[0] = 0;
        coord_y[0] = 0;
        double vx = v0 * Math.Cos(alph);
        double vy=v0*Math.Sin(alph);
        count_vx[0] = vx;
        count_vy[0] = vy;
       /* t_max = 2 * v0 * Math.Sin(alph) / g;
        x_max = t_max * v0 * Math.Cos(alph);*/

    }
    public void Count_x(double dt,  int i)
    {
        coord_x[i] = coord_x[i - 1] + count_vx[i - 1] * dt;
        //Console.WriteLine(coord_x[i]);
    }
    public void Count_y(double dt,  int i)
    {
        coord_y[i] = coord_y[i - 1] + count_vy[i - 1] * dt;
        //Console.WriteLine(coord_y[i]);
    }
    public void Count_vx(double dt, int i)
    {
        count_vx[i] = count_vx[i - 1]-dt*k* count_vx[i - 1]/m;

    }
    public void Count_vy(double dt, int i)
    {
        count_vy[i] = count_vy[i - 1] - dt * (g + k * count_vy[i - 1] / m);
    }
    public void Messages()
    {
        Console.WriteLine("Тело врезалось в препятствие");
    }

    public void Win()
    {
        Goal pig = new Goal();
        Info += Messages;
        double step = t / 20;
        double temp = step;
        for (int i = 1; i < 10; i++)
        {
            Count_vy(temp, i);
            Count_vx(temp, i);
            Count_x(temp, i);
            Count_y(temp, i);
           
            if (coord_y[i] <= 0) {
                Console.WriteLine("Тело уже упало");
                break;
            }
            else if ((dist_x <= coord_x[i] && coord_x[i] <= (dist_x + wideth)) && coord_y[i] <= height)
            {
                Info();
                break;
            }
            else
            {
                Console.WriteLine("Тело прелетело через препятсвие");
                break;
            }
            temp += step;





        }
    }
}
public class Programm
{
    public static void Main(string[] args)
    {
        Bird Bomb = new Bird("ab.txt");
        Bomb.Win();
    }

}


