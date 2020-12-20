using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DZ_OOP_6
{
    abstract class Figure
    {
        public string Name { get; set; }
        public abstract double CalculateSquare();
        public abstract double CalculatePerimeter();
    }
    //Прямоугольник
    class Rectangle : Figure
    {
        private double length;
        private double width;

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value > 0)
                {
                    length = value;
                }
                else
                {
                    throw new Exception("Значение длины должно быть больше 0.");
                }
            }
        }
        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value > 0)
                {
                    width = value;
                }
                else
                {
                    throw new Exception("Значение ширины должно быть больше 0.");
                }
            }
        }
        public Rectangle()
        {
            Name = "Прямоугольник";
        }

        public override double CalculateSquare()
        {
            return Math.Round(length * width, 2);
        }

        public override double CalculatePerimeter()
        {
            return Math.Round(2 * (length + width), 2);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Rectangle r = (Rectangle)obj;
                return (width == r.Width) && (length == r.Length);
            }
        }

        public override string ToString()
        {
            return $"Фигура: {Name}; Длина: {Length}; Ширина: {Width}.";
        }
    }
    //Круг
    class Circle : Figure
    {
        private double radius;

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value > 0)
                {
                    radius = value;
                }
                else
                {
                    throw new Exception("Значение радиуса должно быть больше 0.");
                }
            }
        }
        public Circle()
        {
            Name = "Круг";
        }

        public override double CalculateSquare()
        {
            return Math.Round(Math.PI * Math.Pow(radius, 2), 2);
        }

        public override double CalculatePerimeter()
        {
            return Math.Round(2 * Math.PI * radius, 2);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Circle r = (Circle)obj;
                return (radius == r.Radius);
            }
        }

        public override string ToString()
        {
            return $"Фигура: {Name}; Радиус: {Radius}.";
        }
    }
    //Трапеция
    class Trapezoid : Figure
    {
        private double upperBase;
        private double lowerBase;
        private double height;
        private double leftAngle;
        private double rightAngle;

        public double UpperBase
        {
            get
            {
                return upperBase;
            }
            set
            {
                if (value > 0)
                {
                    upperBase = value;
                }
                else
                {
                    throw new Exception("Значение верхнего основания должно быть больше 0.");
                }
            }
        }
        public double LowerBase
        {
            get
            {
                return lowerBase;
            }
            set
            {
                if (value > 0)
                {
                    lowerBase = value;
                }
                else
                {
                    throw new Exception("Значение нижнего основания должно быть больше 0.");
                }
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    throw new Exception("Значение высоты должно быть больше 0.");
                }
            }
        }
        public double LeftAngle
        {
            get
            {
                return leftAngle;
            }
            set
            {
                if (value > 0 && value < 180)
                {
                    leftAngle = value;
                }
                else
                {
                    throw new Exception("Значение высоты должно быть больше 0 и меньше 180");
                }
            }
        }
        public double RightAngle
        {
            get
            {
                return rightAngle;
            }
            set
            {
                if (value > 0 && value < 180)
                {
                    rightAngle = value;
                }
                else
                {
                    throw new Exception("Значение высоты должно быть больше 0 и меньше 180");
                }
            }
        }
        public Trapezoid()
        {
            Name = "Трапеция";
        }

        public override double CalculateSquare()
        {
            return Math.Round((upperBase + lowerBase) * height / 2, 2);
        }

        public override double CalculatePerimeter()
        {
            return Math.Round(upperBase + lowerBase + height * (1 / Math.Sin(Math.PI * leftAngle / 180) + 1 / Math.Sin(Math.PI * rightAngle / 180)), 2);
        }

        public override string ToString()
        {
            return $"Фигура: {Name}; Верх.осн.: {UpperBase}; Нижн.осн.: {LowerBase}; Высота: {Height}; Левый угол: {LeftAngle}°; Правый угол: {RightAngle}°.";
        }
    }

    public partial class MainWindow : Window
    {
        List<Figure> figures = new List<Figure>
        {
            new Rectangle { Length = 3, Width = 5},
            new Circle { Radius = 5},
            new Trapezoid { UpperBase = 2, LowerBase = 5, Height = 3, LeftAngle = 90, RightAngle = 45},
            new Rectangle { Length = 5.75, Width = 15.25},
            new Circle { Radius = 3.5},
            new Trapezoid { UpperBase = 2, LowerBase = 8, Height = 3, LeftAngle = 45, RightAngle = 45},
            new Rectangle { Length = 8.14, Width = 8.5},
            new Circle { Radius = 13},
            new Trapezoid { UpperBase = 3, LowerBase = 7, Height = 2, LeftAngle = 45, RightAngle = 45},
        };

        public void UpdateFiguresList()
        {
            int i = 0;
            FiguresTB.Clear();
            foreach (var figure in figures)
            {
                FiguresTB.Text += $"{++i}. " + figure.ToString() + "\r\n";
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            UpdateFiguresList();
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var figure = figures.ElementAt(int.Parse(CalculateIndexTB.Text)-1);
                SquareTB.Text = figure.CalculateSquare().ToString();
                PerimeterTB.Text = figure.CalculatePerimeter().ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Тип данных не совпадает с предполагаемыми.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст:\r\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddFigureBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CircleRB.IsChecked == true)
                {
                    figures.Add(new Circle { Radius = double.Parse(RadiusOrBase1TB.Text) });
                }
                else if (RectangleRB.IsChecked == true)
                {
                    figures.Add(new Rectangle { Length = double.Parse(RadiusOrBase1TB.Text), Width = double.Parse(Base2TB.Text) });
                }
                else if (TrapezoidRB.IsChecked == true)
                {
                    figures.Add(new Trapezoid { UpperBase = double.Parse(RadiusOrBase1TB.Text), LowerBase = double.Parse(Base2TB.Text), LeftAngle = double.Parse(LeftAngleTB.Text), RightAngle = double.Parse(RightAngleTB.Text), Height = double.Parse(HeightTB.Text) });
                }
                else
                {
                    throw new Exception("Не была выбрана фигура!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Тип данных не совпадает с предполагаемыми.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст:\r\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            UpdateFiguresList();
        }

        private void ShowCircleData(object sender, RoutedEventArgs e)
        {
            RadiusLb.Visibility = Visibility.Visible;
            LengthLb.Visibility = Visibility.Hidden;
            WidthLb.Visibility = Visibility.Hidden;
            UpperBaseLb.Visibility = Visibility.Hidden;
            LowerBaseLb.Visibility = Visibility.Hidden;
            LeftAngleLb.Visibility = Visibility.Hidden;
            RightAngleLb.Visibility = Visibility.Hidden;
            HeightLb.Visibility = Visibility.Hidden;

            HeightTB.Visibility = Visibility.Hidden;
            Base2TB.Visibility = Visibility.Hidden;
            LeftAngleTB.Visibility = Visibility.Hidden;
            RightAngleTB.Visibility = Visibility.Hidden;
        }

        private void ShowRectangleData(object sender, RoutedEventArgs e)
        {
            RadiusLb.Visibility = Visibility.Hidden;
            LengthLb.Visibility = Visibility.Visible;
            WidthLb.Visibility = Visibility.Visible;
            UpperBaseLb.Visibility = Visibility.Hidden;
            LowerBaseLb.Visibility = Visibility.Hidden;
            LeftAngleLb.Visibility = Visibility.Hidden;
            RightAngleLb.Visibility = Visibility.Hidden;
            HeightLb.Visibility = Visibility.Hidden;

            HeightTB.Visibility = Visibility.Hidden;
            Base2TB.Visibility = Visibility.Visible;
            LeftAngleTB.Visibility = Visibility.Hidden;
            RightAngleTB.Visibility = Visibility.Hidden;
        }

        private void ShowTrapezoidData(object sender, RoutedEventArgs e)
        {
            RadiusLb.Visibility = Visibility.Hidden;
            LengthLb.Visibility = Visibility.Hidden;
            WidthLb.Visibility = Visibility.Hidden;
            UpperBaseLb.Visibility = Visibility.Visible;
            LowerBaseLb.Visibility = Visibility.Visible;
            LeftAngleLb.Visibility = Visibility.Visible;
            RightAngleLb.Visibility = Visibility.Visible;
            HeightLb.Visibility = Visibility.Visible;

            HeightTB.Visibility = Visibility.Visible;
            Base2TB.Visibility = Visibility.Visible;
            LeftAngleTB.Visibility = Visibility.Visible;
            RightAngleTB.Visibility = Visibility.Visible;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                figures.RemoveAt(int.Parse(CalculateIndexTB.Text) - 1);
            }
            catch (FormatException)
            {
                MessageBox.Show("Тип данных не совпадает с предполагаемыми.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Текст:\r\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            UpdateFiguresList();
        }
    }
}
