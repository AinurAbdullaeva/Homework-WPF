using System;
using System.Windows;
using System.Windows.Controls; //тут находятся классы для  классических элементов управления
using System.Windows.Input;
using System.Windows.Media;
namespace WPF2
{
    public class ClickTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ClickTheButton());
        }
        public ClickTheButton()
        {
            Title = "Run"; //название окна
            Button btn = new Button(); //этим классом представлена кнопка со свойством Content и событием Click
            btn.Content = "Run!";  //свойству Content объекта Button задается текстовая строка
            btn.Click += ButtonOnClick;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            Content = btn; //сам объект Button задаётся свойству Content объекта Window
            
        }
        void Okno() { MessageBox.Show("Тело врезалось в препятсвие"); }
        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            Bird Bomb = new Bird("ab.txt");
            Bomb.Info += Okno;
            Bomb.Win();
        }
    }
}