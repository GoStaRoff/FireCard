using System.Drawing;

namespace FireCard
{
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

        public Point Position { get; set; }
        public Color PointColor { get; set; }

        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(PointColor), Position.X, Position.Y, 10, 10);
        }
    }
}