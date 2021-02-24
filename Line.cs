using System.Collections.Generic;
using System.Drawing;

namespace FireCard
{
    public class Line
    {
        public Line()
        {
            StartPoint = new Point(0, 0);
            EndPoint = new Point(0, 0);
        }

        public Line(Point startPoint)
        {
            StartPoint = startPoint;
            EndPoint = new Point(0, 0);
        }

        public Line(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public void Draw(Graphics g, Pen pen)
        {
            if (StartPoint != (new Point(0, 0)) && EndPoint != (new Point(0, 0)))
            {
                g.DrawLine(pen, StartPoint, EndPoint);
                Point[] points = new Point[3];
                points[0].X = EndPoint.X;
                points[0].Y = EndPoint.Y - 15;
                points[1].X = EndPoint.X - 5;
                points[1].Y = EndPoint.Y;
                points[2].X = EndPoint.X + 5;
                points[2].Y = EndPoint.Y;

                using (SolidBrush fillvar = new SolidBrush(Color.FromArgb(100, Color.Blue)))
                {
                    g.FillPolygon(fillvar, points);
                }
            }
        }
    }
}