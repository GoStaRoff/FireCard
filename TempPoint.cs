using System;
using System.Drawing;

namespace FireCard
{
    [Serializable]
    public class TempPoint
    {
        public TempPoint()
        {

        }

        public TempPoint(Point position)
        {
            Position = position;
            PointColor = Color.Red;
        }

        public TempPoint(Point position, Color pointColor)
        {
            Position = position;
            PointColor = pointColor;
        }

        public TempPoint(Point position, Color pointColor, string name) : this(position, pointColor)
        {
            Name = name;
        }

        public Point Position { get; set; }
        public Color PointColor { get; set; }
        public String Name { get; set; }

        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(PointColor), Position.X, Position.Y, 10, 10);
        }
    }
}