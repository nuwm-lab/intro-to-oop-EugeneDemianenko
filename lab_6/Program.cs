﻿abstract class GeometricFigure
{
   public abstract bool IsPointInside(double x, double y);
}

class Figure : GeometricFigure
{
   public override bool IsPointInside(double x, double y)
   {
       return false;
   }
}

class Line : Figure
{
   protected double a0, a1, a2;

   public Line()
   {
       a0 = a1 = a2 = 0;
   }

   public Line(double a0, double a1, double a2)
   {
       this.a0 = a0;
       this.a1 = a1;
       this.a2 = a2;
   }

   public override bool IsPointInside(double x, double y)
   {
       return Math.Abs(a1 * x + a2 * y + a0) < 0.0001;
   }
}

class Hyperplane : Line
{
   private double a3, a4;

   public Hyperplane() : base()
   {
       a3 = a4 = 0;
   }

   public Hyperplane(double a0, double a1, double a2, double a3, double a4) : base(a0, a1, a2)
   {
       this.a3 = a3;
       this.a4 = a4;
   }

   public override bool IsPointInside(double x, double y)
   {
       return Math.Abs(a1 * x + a2 * y + a3 * x + a4 * y + a0) < 0.0001;
   }
}

class Program
{
   static void Main(string[] args)
   {
       Console.OutputEncoding = System.Text.Encoding.UTF8;

       Console.WriteLine("Виберіть фігуру (1 - Лінія, 2 - Гіперплощина):");
       int userChoice = Convert.ToInt32(Console.ReadLine());

       GeometricFigure figure;

       if (userChoice == 1)
       {
           Console.WriteLine("Ви вибрали лінію.");
           Console.WriteLine("Введіть коефіцієнти для лінії (a0, a1, a2):");
           double a0 = Convert.ToDouble(Console.ReadLine());
           double a1 = Convert.ToDouble(Console.ReadLine());
           double a2 = Convert.ToDouble(Console.ReadLine());

           figure = new Line(a0, a1, a2);
       }
       else if (userChoice == 2)
       {
           Console.WriteLine("Ви вибрали гіперплощину.");
           Console.WriteLine("Введіть коефіцієнти для гіперплощини (a0, a1, a2, a3, a4):");
           double a0 = Convert.ToDouble(Console.ReadLine());
           double a1 = Convert.ToDouble(Console.ReadLine());
           double a2 = Convert.ToDouble(Console.ReadLine());
           double a3 = Convert.ToDouble(Console.ReadLine());
           double a4 = Convert.ToDouble(Console.ReadLine());

           figure = new Hyperplane(a0, a1, a2, a3, a4);
       }
       else
       {
           Console.WriteLine("Неправильний вибір.");
           return;
       }

       Console.WriteLine("Введіть точку для перевірки (x, y):");
       double x = Convert.ToDouble(Console.ReadLine());
       double y = Convert.ToDouble(Console.ReadLine());

       if (figure.IsPointInside(x, y))
           Console.WriteLine("Точка належить фігурі.");
       else
           Console.WriteLine("Точка не належить фігурі.");
   }
}
