using System;
using System.Windows;
using System.Windows.Controls; //тут находятся классы для  классических элементов управления
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
namespace WPF2
{
    public class ClickTheButton : Window
    {
        TextBox ang;
        TextBox v;
        TextBox t;
        TextBox m;
        double vv;
        TextBlock coord;
        Bird Bomb;
       [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ClickTheButton());
        }
        public ClickTheButton()
        {
            Title = "Run"; //название окна
            Button btn = new Button();
            Canvas model=new Canvas();
            Label la = new Label();
            la.Content = "Угол:";
            Label lv=new Label();
            lv.Content = "Скорость:";
            Label lt= new Label();
            lt.Content = "Время:";
            Label lm= new Label();
            lm.Content = "Масса";
            StackPanel sp = new StackPanel();
            sp.Children.Add(btn);
            sp.Children.Add(la);
            ang = new TextBox();
            sp.Children.Add(ang);
            sp.Children.Add(lv);
            v = new TextBox(); 
            sp.Children.Add(v);
            t=new TextBox();
            sp.Children.Add(lt);
            sp.Children.Add(t);
            m=new TextBox();
            sp.Children.Add(lm);
            sp.Children.Add(m);
            coord = new TextBlock();
            sp.Children.Add(coord); 
            sp.Children.Add(model);
            //этим классом представлена кнопка со свойством Content и событием Click
            btn.Content = "Run!";  //свойству Content объекта Button задается текстовая строка
            btn.Click += ButtonOnClick;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            Content = sp; //сам объект Button задаётся свойству Content объекта Window
            
        }
        void Okno1() { MessageBox.Show("Тело врезалось в препятсвие");
            coord.Text = (Bomb.coord_x[Bomb.n - 1]).ToString()+" "+ (Bomb.coord_y[Bomb.n-1]).ToString();
        }
        void Okno2() { MessageBox.Show("Тело уже упало");
            coord.Text = (Bomb.coord_x[Bomb.n-1]).ToString() + " " + (Bomb.coord_y[Bomb.n-1]).ToString();
        }
        void Okno3() { MessageBox.Show("Тело перелетело через препятствие");
            coord.Text = (Bomb.coord_x[Bomb.n-1]).ToString() + " " + (Bomb.coord_y[Bomb.n-1]).ToString();
        }
        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            double velocity = Convert.ToDouble(v.Text);
            double time = Convert.ToDouble(t.Text);
            double mass=Convert.ToDouble(m.Text); 
            double angle=Convert.ToDouble(ang.Text);    
            Bomb = new Bird(time,velocity,mass,angle);
            Bomb.Info1 += Okno1;
            Bomb.Info2 += Okno2;
            Bomb.Info3 += Okno3;    
            
            Bomb.Win();
            Polyline trajectory = new Polyline();
            PointCollection myPointCollection = new PointCollection();
            trajectory.Points = myPointCollection;
            for (int i = 0; i < Bomb.n; i++) {
                System.Windows.Point Point = new System.Windows.Point(Bomb.coord_x[i], Bomb.coord_y[i]);
                myPointCollection.Add(Point);
            }
            Win.model.Children.Add(trajectory);
        }
    }
}   