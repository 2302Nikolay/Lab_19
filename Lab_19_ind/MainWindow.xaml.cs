using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Lab_19_ind
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int N = 10;
            try
            {
                N = Convert.ToInt32(FigureCount.Text);
            }
            catch
            {
                this.Title = "Только целое число!";
            }
            GenerateShapes(N);
        }

        private void GenerateShapes(int N)
        {
            Random rndShapeType = new Random(DateTime.Now.Millisecond);
            Random rndStyle = new Random(DateTime.Now.Second);
            Random rndPosition = new Random(DateTime.Now.Minute);
            Random rndSize = new Random(DateTime.Now.Minute);

            for (int i = 0; i < N; i++)
            {
                Shape currentShape;
                int shapeType = rndShapeType.Next(0, 2);
                if (shapeType == 0)
                    currentShape = new Ellipse();
                else
                    currentShape = new Rectangle();

                int shapeStyle = rndStyle.Next(0, 4) + 1;
                string styleName = "style" + shapeStyle.ToString();
                Style currentStyle = (Style)this.FindResource(styleName);
                currentShape.Style = currentStyle;

                currentShape.Width = rndSize.Next(10, 200);
                currentShape.Height = rndSize.Next(10, 100);

                MainCanvas.Children.Add(currentShape);
                Canvas.SetLeft(currentShape, rndPosition.Next(5, 750));
                Canvas.SetTop(currentShape, rndPosition.Next(5, 370));

            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
