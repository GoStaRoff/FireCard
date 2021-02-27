using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace FireCard
{
    public enum TypeSoilders { first, second, third }
    public class Map
    {
        public List<TempPoint> TempPoints { get; set; }
        public Point Enemy { get; set; }
        [JsonIgnore]
        public Bitmap EnemyPict { get; set; }

        public string EnemyPictSer
        {
            get
            { // serialize
                ImageConverter converter = new ImageConverter();
                return Convert.ToBase64String((byte[])converter.ConvertTo(EnemyPict, typeof(byte[])));
            }
            set
            { // deserialize
                var bytes = Convert.FromBase64String(value);
                using (var ms = new MemoryStream(bytes))
                    EnemyPict = new Bitmap(Bitmap.FromStream(ms));
            }
        }
        [JsonIgnore]
        public Bitmap ZonaVPict { get; set; }

        public string zonaVSer
        {
            get
            { // serialize
                ImageConverter converter = new ImageConverter();
                return Convert.ToBase64String((byte[])converter.ConvertTo(ZonaVPict, typeof(byte[])));
            }
            set
            { // deserialize
                var bytes = Convert.FromBase64String(value);
                using (var ms = new MemoryStream(bytes))
                    ZonaVPict = new Bitmap(Bitmap.FromStream(ms));
            }
        }
        public Point Position { get; set; }
        public bool isMapEnabled { get; set; }
        public static string[] Direction { get; set; }
        public List<Soldier> DrawedSoilders { get; set; }
        public List<Thing> Things { get; set; }
        public List<List<Soldier>> Soldiers { get; set; }
        public Point FireArea { get; set; }
        public List<List<Point>> Baricade { get; set; }
        public static TypeSoilders typeSoilders { get; set; }
        public List<MapThing > MapThings { get; set; }
        public Map(List<TempPoint> tempPoints, Point enemy,Bitmap enemyPict, Bitmap zonaVPict, Point position
            ,bool isMapEnabled,List<Soldier> drawedSoilders, string[] direction, List<Thing> things, List<List<Soldier>> soldiers, Point fireArea, List<MapThing> mapThings,
            List<List<Point>> Baricade, TypeSoilders _typeSoilders)
        {
            TempPoints = tempPoints;
            Enemy = enemy;
            Position = position;
            Direction = direction;
            Things = things;
            Soldiers = soldiers;
            FireArea = fireArea;
            MapThings = mapThings;
            typeSoilders = _typeSoilders;
            ZonaVPict = zonaVPict;
            this.isMapEnabled = isMapEnabled;
            EnemyPict = enemyPict;
            DrawedSoilders = drawedSoilders;
            this.Baricade = Baricade;
        }
        public Map()
        {
            Soldiers = new List<List<Soldier>>()
            {
                new List<Soldier>{
                    new Soldier("Командир відділення", SoilderTypes.rifleman),
                    new Soldier("Навідник-Оператор", SoilderTypes.rifleman),
                    new Soldier("Механік-водій", SoilderTypes.rifleman),
                    new Soldier("Старший стрілець", SoilderTypes.rifleman),
                    new Soldier("Гранатометник", SoilderTypes.grenade_launcher),
                    new Soldier("Стрілець-помічник", SoilderTypes.rifleman),
                    new Soldier("Кулеметник", SoilderTypes.machine_gunner),
                    new Soldier("Кулеметник", SoilderTypes.machine_gunner),
                    new Soldier("Снайпер", SoilderTypes.rifleman),
                    new Soldier("БМП", SoilderTypes.BMP)
                },
                new List<Soldier>{
                    new Soldier("Командир відділення", SoilderTypes.rifleman),
                    new Soldier("Навідник-Оператор", SoilderTypes.rifleman),
                    new Soldier("Механік-водій", SoilderTypes.rifleman),
                    new Soldier("Старший стрілець", SoilderTypes.rifleman),
                    new Soldier("Гранатометник", SoilderTypes.grenade_launcher),
                    new Soldier("Стрілець-помічник", SoilderTypes.rifleman),
                    new Soldier("Навідник", SoilderTypes.machine_gunner),
                    new Soldier("Номер обслуги", SoilderTypes.machine_gunner),
                    new Soldier("Снайпер", SoilderTypes.rifleman),
                    new Soldier("БМП", SoilderTypes.BMP)
                },
                new List<Soldier>{
                    new Soldier("Командир відділення", SoilderTypes.rifleman),
                    new Soldier("Навідник-Оператор", SoilderTypes.rifleman),
                    new Soldier("Механік-водій", SoilderTypes.rifleman),
                    new Soldier("Старший стрілець", SoilderTypes.rifleman),
                    new Soldier("Гранатометник", SoilderTypes.grenade_launcher),
                    new Soldier("Стрілець-помічник", SoilderTypes.rifleman),
                    new Soldier("Кулеметник", SoilderTypes.machine_gunner),
                    new Soldier("Кулеметник", SoilderTypes.machine_gunner),
                    new Soldier("Стрілець-санітар", SoilderTypes.rifleman),
                    new Soldier("БМП", SoilderTypes.BMP)
                },
            };

            Things = new List<Thing>();
            Enemy = new Point(0, 0);
            TempPoints = new List<TempPoint>();
            Position = new Point(0, 425);
            Baricade = new List<List<Point>>()
            {
                new List<Point>(),
                new List<Point>(),
                new List<Point>()
            };
            DrawedSoilders = new List<Soldier>();
            MapThings = new List<MapThing>();

        }

       

        public void Draw(Graphics g)
        {
            SolidBrush myBrush;
            for (int i = 0; i < MapThings.Count; i++)
            {
                switch (MapThings[i].tThype)
                {
                    case thingType.grass:
                         myBrush = new SolidBrush(Color.FromArgb(255, 0, 255, 0));
                        g.FillRectangle(myBrush, new Rectangle(MapThings[i].Position.X - 35, MapThings[i].Position.Y - 35, 70, 70));
                        break;
                    case thingType.water:
                         myBrush = new SolidBrush(Color.FromArgb(255, 30, 144, 255));
                        g.FillRectangle(myBrush, new Rectangle(MapThings[i].Position.X - 35, MapThings[i].Position.Y - 35, 70, 70));
                        break;
                    case thingType.road:
                         myBrush = new SolidBrush(Color.FromArgb(128, 0, 255, 0));
                        g.FillRectangle(myBrush, new Rectangle(MapThings[i].Position.X - 35, MapThings[i].Position.Y - 35, 70, 70));
                        break;
                    case thingType.river:
                         myBrush = new SolidBrush(Color.FromArgb(128, 0, 255, 0));
                        g.FillRectangle(myBrush, new Rectangle(MapThings[i].Position.X - 35, MapThings[i].Position.Y - 35, 70, 70));
                        break;
                    default:
                        break;
                }
            }
            if (isMapEnabled)
            {
                g.DrawImage(Properties.Resources.fon4, 0, 0);
            }
            for (int i = 0; i < Things.Count; i++)
            {
                Things[i].Draw(g, i);
            }
            if (Enemy != (new Point(0, 0)))
            {
                g.DrawImage(EnemyPict, Enemy.X - 45, Enemy.Y - 70, 90, 120);
            }
            for (int i = 0; i < TempPoints.Count; i++)
            {
                TempPoints[i].Draw(g);
            }
            g.DrawImage(Properties.Resources.okop, Position);
            for (int i = 0; i < DrawedSoilders.Count; i++)
            {
                DrawedSoilders[i].Draw(g);
            }
            if (FireArea != new Point(0, 0))
            {
                g.DrawImage(ZonaVPict, FireArea.X - 40, FireArea.Y - 14, 80, 28);
            }
            Pen pen = new Pen(Color.Green);
            pen.Width = 3;
            Bitmap baricadeImg = Properties.Resources.Baricade1;
            for (int i = 0; i < Baricade.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        baricadeImg = Properties.Resources.Baricade1;
                        break;
                    case 1:
                        baricadeImg = Properties.Resources.Baricade2;
                        break;
                    case 2:
                        baricadeImg = Properties.Resources.Baricade3;
                        break;
                }
                if (Baricade[i].Count > 1)
                {
                    for (int j = 1; j < Baricade[i].Count; j++)
                    {
                        g.DrawImage(baricadeImg, Baricade[i][j - 1].X - 7, Baricade[i][j - 1].Y - 7, 14, 14);
                        g.DrawLine(pen, Baricade[i][j - 1], Baricade[i][j]);
                    }
                    g.DrawImage(baricadeImg, Baricade[i][Baricade[i].Count - 1].X - 7, Baricade[i][Baricade[i].Count - 1].Y - 7, 14, 14);
                }
                else if (Baricade[i].Count == 1)
                {
                    g.DrawImage(baricadeImg, Baricade[i][0].X - 7, Baricade[i][0].Y - 7, 14, 14);
                }
            }
            g.DrawImage(Properties.Resources.napryam, 30, 25, 20, 90);

           
            
        }
        public override string ToString()
        {
            string res = String.Empty;
            for (int i = 0; i < DrawedSoilders.Count; i++)
            {
                res += $" ---- {DrawedSoilders[i].Name} : зайняти позицію на координаті {DrawedSoilders[i].Position} та обороняти позицію відділення. ";
                if (DrawedSoilders[i].ReservedPosition != new Point(0, 0))
                {
                    res += $"Запасна позиція поруч на координаті {DrawedSoilders[i].ReservedPosition}. ";
                }
                res += "Смуги вогню : " + Environment.NewLine;
                double sum = Double.MaxValue;
                int thing_index = -1;
                for (int j = 0; j < DrawedSoilders[i].Lines.Count; j++)
                {
                    res += $"{j+1}) ";
                    sum = Double.MaxValue;
                    for (int k = 0; k < Things.Count; k++)
                    {
                        double temp = Math.Sqrt(Math.Pow(Things[k].Position.X - DrawedSoilders[i].Lines[j].EndPoint.X, 2) +
                                           Math.Pow(Things[k].Position.Y - DrawedSoilders[i].Lines[j].EndPoint.Y, 2));
                        if (sum > temp)
                        {
                            sum = temp;
                            thing_index = k;
                        }
                    }
                    res += $"{Math.Round(sum)} метрів ";
                    if (DrawedSoilders[i].Lines[j].EndPoint.X >= Things[thing_index].Position.X)
                    {
                        res += $"правруч орієнтира №{thing_index + 1} ";
                    }
                    else
                    {
                        res += $"ліворуч орієнтира №{thing_index + 1} ";
                    }
                    res += Environment.NewLine;
                }
                res += Environment.NewLine;
            }

            return res;
        }
    }
}