﻿using System;
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
                if (EnemyPict != null)
                {
                    using (var ms = new MemoryStream(bytes))
                        EnemyPict = new Bitmap(Bitmap.FromStream(ms));
                }
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
                if (EnemyPict != null)
                {
                    using (var ms = new MemoryStream(bytes))
                        ZonaVPict = new Bitmap(Bitmap.FromStream(ms));
                }
            }
        }
        public Point Position { get; set; }
        public static bool BTR { get; set; }
        public static bool TANK { get; set; }
        public bool isMapEnabled { get; set; }
        public static string[] Direction { get; set; }
        public List<Soldier> DrawedSoilders { get; set; }
        public List<Thing> Things { get; set; }
        public List<List<Soldier>> Soldiers { get; set; }
        public Point FireArea { get; set; }
        public List<List<List<Point>>> Baricade { get; set; }
        public static TypeSoilders typeSoilders { get; set; }
        public List<MapThing> MapThings { get; set; }
        public Map(List<TempPoint> tempPoints, Point enemy, Bitmap enemyPict, Bitmap zonaVPict, Point position
            , bool isMapEnabled, List<Soldier> drawedSoilders, string[] direction, List<Thing> things, List<List<Soldier>> soldiers, Point fireArea, List<MapThing> mapThings,
            List<List<List<Point>>> Baricade, TypeSoilders _typeSoilders)
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
            Baricade = new List<List<List<Point>>>()
            {
                new List<List<Point>>(),
                new List<List<Point>>(),
                new List<List<Point>>()
            };
            DrawedSoilders = new List<Soldier>();
            MapThings = new List<MapThing>();

        }
        public void Draw(Graphics g)
        {
            for (int i = 0; i < MapThings.Count; i++)
            {
                switch (MapThings[i].tThype)
                {
                    case thingType.water:
                        g.DrawImage(Properties.Resources.water, MapThings[i].Position.X - 30, MapThings[i].Position.Y - 25, 60, 50);
                        break;
                    case thingType.house:
                        g.DrawImage(Properties.Resources.house, MapThings[i].Position.X - 20, MapThings[i].Position.Y - 15, 40, 30);
                        break;
                    case thingType.vishka:
                        g.DrawImage(Properties.Resources.vishka, MapThings[i].Position.X - 10, MapThings[i].Position.Y - 20, 20, 40);
                        break;
                    case thingType.virubka:
                        g.DrawImage(Properties.Resources.virubka, MapThings[i].Position.X - 25, MapThings[i].Position.Y - 15, 50, 25);
                        break;
                    case thingType.tree:
                        g.DrawImage(Properties.Resources.tree, MapThings[i].Position.X - 10, MapThings[i].Position.Y - 20, 20, 40);
                        break;
                    case thingType.sad:
                        g.DrawImage(Properties.Resources.sad, MapThings[i].Position.X - 25, MapThings[i].Position.Y - 15, 50, 25);
                        break;
                    case thingType.pamyatnik:
                        g.DrawImage(Properties.Resources.pamyatnik, MapThings[i].Position.X - 15, MapThings[i].Position.Y - 15, 30, 30);
                        break;
                    case thingType.kuschi:
                        g.DrawImage(Properties.Resources.kuschi, MapThings[i].Position.X - 20, MapThings[i].Position.Y - 15, 40, 25);
                        break;
                    case thingType.kurgan:
                        g.DrawImage(Properties.Resources.kurgan, MapThings[i].Position.X - 15, MapThings[i].Position.Y - 15, 30, 30);
                        break;
                    case thingType.kamni:
                        g.DrawImage(Properties.Resources.kamni, MapThings[i].Position.X - 20, MapThings[i].Position.Y - 15, 40, 25);
                        break;
                    case thingType.cerkva:
                        g.DrawImage(Properties.Resources.cerkva, MapThings[i].Position.X - 15, MapThings[i].Position.Y - 15, 30, 30);
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
                try { g.DrawImage(EnemyPict, Enemy.X - 45, Enemy.Y - 70, 90, 120); } catch { }
                
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
                try { g.DrawImage(ZonaVPict, FireArea.X - 40, FireArea.Y - 14, 80, 28); } catch { }
                
            }
            Pen greenPen = new Pen(Color.Green);
            greenPen.Width = 3;
            Pen blackPen = new Pen(Color.Black);
            greenPen.Width = 3;
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
                for (int j = 0; j < Baricade[i].Count; j++)
                {
                    
                    if (Baricade[i][j].Count > 1)
                    {
                        if (i != 0)
                        {
                            for (int l = 1; l < Baricade[i][j].Count; l++)
                            {
                                if (l == 1)
                                {
                                    g.DrawImage(baricadeImg, Baricade[i][j][l - 1].X - 7, Baricade[i][j][l - 1].Y - 7, 14, 14);
                                    g.DrawLine(blackPen, new Point(Baricade[i][j][l - 1].X - 30, Baricade[i][j][l - 1].Y + 15), new Point(Baricade[i][j][l].X, Baricade[i][j][l].Y + 15));
                                    g.DrawLine(blackPen, new Point(Baricade[i][j][l - 1].X - 30, Baricade[i][j][l - 1].Y - 15), new Point(Baricade[i][j][l].X, Baricade[i][j][l].Y - 15));
                                    g.DrawLine(blackPen, new Point(Baricade[i][j][l - 1].X - 30, Baricade[i][j][l - 1].Y - 15), new Point(Baricade[i][j][l - 1].X - 30, Baricade[i][j][l - 1].Y + 15));
                                }
                                else if (l == Baricade[i][j].Count - 1)
                                {
                                    g.DrawImage(baricadeImg, Baricade[i][j][l - 1].X - 7, Baricade[i][j][l - 1].Y - 7, 14, 14);
                                    g.DrawLine(blackPen, new Point(Baricade[i][j][l - 1].X, Baricade[i][j][l - 1].Y + 15), new Point(Baricade[i][j][l].X + 30, Baricade[i][j][l].Y + 15));
                                    g.DrawLine(blackPen, new Point(Baricade[i][j][l - 1].X, Baricade[i][j][l - 1].Y - 15), new Point(Baricade[i][j][l].X + 30, Baricade[i][j][l].Y - 15));
                                    g.DrawLine(blackPen, new Point(Baricade[i][j][l].X + 30, Baricade[i][j][l].Y + 15), new Point(Baricade[i][j][l].X + 30, Baricade[i][j][l].Y - 15));
                                }
                                else
                                {
                                    g.DrawImage(baricadeImg, Baricade[i][j][l - 1].X - 7, Baricade[i][j][l - 1].Y - 7, 14, 14);
                                    g.DrawLine(blackPen, new Point(Baricade[i][j][l - 1].X, Baricade[i][j][l - 1].Y + 15), new Point(Baricade[i][j][l].X, Baricade[i][j][l].Y + 15));
                                    g.DrawLine(blackPen, new Point(Baricade[i][j][l - 1].X, Baricade[i][j][l - 1].Y - 15), new Point(Baricade[i][j][l].X, Baricade[i][j][l].Y - 15));
                                }
                            }
                        }
                        else
                        {
                            for (int l = 1; l < Baricade[i][j].Count; l++)
                            {
                                g.DrawImage(baricadeImg, Baricade[i][j][l - 1].X - 7, Baricade[i][j][l - 1].Y - 7, 14, 14);
                                g.DrawLine(greenPen, Baricade[i][j][l - 1], Baricade[i][j][l]);
                            }
                        }
                        g.DrawImage(baricadeImg, Baricade[i][j][Baricade[i][j].Count - 1].X - 7, Baricade[i][j][Baricade[i][j].Count - 1].Y - 7, 14, 14);
                    }

                    else if (Baricade[i][j].Count == 1)
                    {
                        g.DrawImage(baricadeImg, Baricade[i][j][0].X - 7, Baricade[i][j][0].Y - 7, 14, 14);
                    }
                }
                g.DrawImage(Properties.Resources.napryam, 30, 25, 20, 90);
            }
        }
        public override string ToString()
        {
            string res = String.Empty;
            double sum = Double.MaxValue;
            int thing_index = -1;
            for (int i = 0; i < DrawedSoilders.Count; i++)
            {
                res += $" ---- {DrawedSoilders[i].Name} : зайняти позицію ";
                String position = String.Empty;
                for (int j = 0; j < Constants.namedPoints.Count; j++)
                {
                    if (DrawedSoilders[i].Position.X == Constants.namedPoints[j].Position.X && DrawedSoilders[i].Position.Y == Constants.namedPoints[j].Position.Y)
                    {
                        position = $"в \"{Constants.namedPoints[j].Name}\"";
                        break;
                    }
                    else
                    {

                        double temp = Math.Sqrt(Math.Pow(DrawedSoilders[i].Position.X - Constants.namedPoints[j].Position.X, 2) +
                                           Math.Pow(DrawedSoilders[i].Position.Y - Constants.namedPoints[j].Position.Y, 2));
                        if (sum > temp)
                        {
                            sum = temp;
                            thing_index = j;
                        }

                        position = $"позаду \"{Constants.namedPoints[thing_index].Name}\" на відстані {Math.Round(sum)}м";
                    }
                }
                res += position + " та обороняти позицію відділення. ";
                if (DrawedSoilders[i].ReservedPosition != new Point(0, 0))
                {
                    res += $"Запасна позиція ";
                    String reservedPosition = String.Empty;
                    for (int j = 0; j < Constants.namedPoints.Count; j++)
                    {
                        if (DrawedSoilders[i].ReservedPosition.X == Constants.namedPoints[j].Position.X && DrawedSoilders[i].ReservedPosition.Y == Constants.namedPoints[j].Position.Y)
                        {
                            reservedPosition = $"в \"{Constants.namedPoints[j].Name}\". ";
                            break;
                        }
                        else
                        {

                            double temp = Math.Sqrt(Math.Pow(DrawedSoilders[i].ReservedPosition.X - Constants.namedPoints[j].Position.X, 2) +
                                               Math.Pow(DrawedSoilders[i].ReservedPosition.Y - Constants.namedPoints[j].Position.Y, 2));
                            if (sum > temp)
                            {
                                sum = temp;
                                thing_index = j;
                            }

                            reservedPosition = $"позаду \"{Constants.namedPoints[thing_index].Name}\" на відстані {Math.Round(sum)}м. ";
                        }
                    }
                    res += reservedPosition;
                }
                res += "Смуги вогню : " + Environment.NewLine;
                sum = Double.MaxValue;
                thing_index = -1;
                for (int j = 0; j < DrawedSoilders[i].Lines.Count; j++)
                {
                    res += $"{j + 1}) ";
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