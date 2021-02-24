using System.Collections.Generic;
using System.Drawing;

namespace FireCard
{
    public enum SoilderTypes { rifleman, machine_gunner, grenade_launcher, BTR, BMP, TANK }
    public class Soldier
    {
        public Soldier()
        {
            Lines = new List<Line>();
            ReservedPosition = new Point(0, 0);
        }

        public Soldier(string name, SoilderTypes soilderType)
        {
            Name = name;
            SoilderType = soilderType;
            Lines = new List<Line>();
            ReservedPosition = new Point(0, 0);
        }

        public string Name { get; set; }
        public Point Position { get; set; }
        public SoilderTypes SoilderType { get; set; }
        public Point ReservedPosition { get; set; }
        public List<Line> Lines { get; set; }
        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Blue);
            Image image = Properties.Resources.RIFLEMAN;
            Image imageRes = Properties.Resources.RIFLEMAN;
            switch (SoilderType)
            {
                case SoilderTypes.rifleman:
                    image = Properties.Resources.RIFLEMAN;
                    imageRes = Properties.Resources.RIFLEMANr;
                    break;
                case SoilderTypes.machine_gunner:
                    image = Properties.Resources.MACHINE;
                    imageRes = Properties.Resources.MACHINEr;
                    break;
                case SoilderTypes.grenade_launcher:
                    image = Properties.Resources.GRENADER;
                    imageRes = Properties.Resources.GRENADERr;
                    break;
                case SoilderTypes.BTR:
                    image = Properties.Resources.BTR;
                    imageRes = Properties.Resources.BTRr;
                    break;
                case SoilderTypes.BMP:
                    image = Properties.Resources.BMP;
                    imageRes = Properties.Resources.BMPr;
                    break;
                case SoilderTypes.TANK:
                    image = Properties.Resources.TANK;
                    imageRes = Properties.Resources.TANKr;
                    break;
            }
            g.DrawImage(image, Position.X - 25, Position.Y - 25, 50, 60);
            if (ReservedPosition != new Point(0, 0))
            {
                g.DrawImage(imageRes, ReservedPosition.X - 25, ReservedPosition.Y - 25, 50, 60);
            }
            for (int i = 0; i < Lines.Count; i++)
            {
                if (i == 2) pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                Lines[i].Draw(g, pen);
            }
        }
    }
}