using System.Drawing;
using System;

namespace FireCard
{
    [Serializable]
    public class Thing
    {
        public static string newItemName;
        public static double newItemDirection;
        public static bool idAdding = false;
        public static double newItemHighth;

        public Thing()
        {

        }

        public Thing(Point position, string name, string direction, string higth)
        {
            Position = position;
            Name = name;
            Direction = direction;
            Highth = higth;

        }

        public Point Position { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }

        public string Highth { get; set; }

        public void Draw(Graphics g, int index)
        {
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, new Point(Position.X + 45, Position.Y), new Point(Position.X - 45, Position.Y));
            g.DrawLine(pen, new Point(Position.X, Position.Y + 35), new Point(Position.X, Position.Y - 35));
            g.DrawString($"Ор№{index + 1}", new Font("Times New Roman", 10.0f), new SolidBrush(Color.Black), new Point(Position.X - 43, Position.Y - 15));
            g.DrawString(Name, new Font("Times New Roman", 10.0f), new SolidBrush(Color.Black), new Point(Position.X, Position.Y - 15));
            g.DrawString(Direction + "m", new Font("Times New Roman", 10.0f), new SolidBrush(Color.Black), new Point(Position.X, Position.Y));
            g.DrawString(Highth + "m", new Font("Times New Roman", 10.0f), new SolidBrush(Color.Black), new Point(Position.X-43, Position.Y));
        }
    }
}