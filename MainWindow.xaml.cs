using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GenrativeWpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random _random = new();

        public MainWindow()
        {
            InitializeComponent();

            //GenerateArt();
        }

        //private void GenerateArt()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Ellipse ellipse = new Ellipse
        //        {
        //            Width = _random.Next(10, 100),
        //            Height = _random.Next(10, 100),
        //            Fill = new SolidColorBrush(Color.FromRgb(
        //                (byte)_random.Next(256),
        //                (byte)_random.Next(256),
        //                (byte)_random.Next(256)))
        //        };

        //        Canvas.SetLeft(ellipse, _random.Next((int)ArtCanvas.ActualWidth));
        //        Canvas.SetTop(ellipse, _random.Next((int)ArtCanvas.ActualHeight));

        //        ArtCanvas.Children.Add(ellipse);
        //    }
        //}

        //private void OnCanvasLoaded(object sender, RoutedEventArgs e)
        //{
        //    string axiom = "F";
        //    string rules = "F->FF+[+F-F-F]-[-F+F+F]";
        //    string result = GenerateLSystem(axiom, rules, 4);
        //    DrawLSystem(LSystemCanvas, result, 300, 300, 25, 25);
        //}

        private void OnFractalCanvasLoaded(object sender, RoutedEventArgs e)
        {
            DrawFractal(FractalCanvas, 300, 300, 200, 5);
        }

        private void DrawFractal(Canvas canvas, double x, double y, double size, int depth)
        {
            if (depth == 0) return;

            Ellipse ellipse = new Ellipse
            {
                Width = size,
                Height = size,
                Stroke = Brushes.Black
            };
            Canvas.SetLeft(ellipse, x - size / 2);
            Canvas.SetTop(ellipse, y - size / 2);
            canvas.Children.Add(ellipse);

            double newSize = size / 2;
            DrawFractal(canvas, x - newSize, y, newSize, depth - 1);
            DrawFractal(canvas, x + newSize, y, newSize, depth - 1);
            DrawFractal(canvas, x, y - newSize, newSize, depth - 1);
            DrawFractal(canvas, x, y + newSize, newSize, depth - 1);
        }


        private void DrawLSystem(Canvas lSystemCanvas, string result, int i, int i1, int i2, int i3)
        {
            //throw new NotImplementedException();
        }

        private string GenerateLSystem(string axiom, string rules, int iterations)
        {
            string result = axiom;
            for (int i = 0; i < iterations; i++)
            {
                result = result.Replace("F", rules);
            }
            return result;
        }
    }
}