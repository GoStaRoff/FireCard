using FireCard.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace FireCard
{
    enum State { r1, r2, r3, r4, r5, r6, final, erause, move, reserved, paint }
    public partial class Form1 : Form
    {
        Graphics g;
        State previousState;
        State state;
        Map myMap;
        int checker = -1;
        bool IsClicked = false;
        List<Button> buttons;
        int choosed_soilder = -1;
        int x;
        int y;
        int soilder_index = 0;
        int lineCounter = 1;
        int choosed_liner = -1;
        int choosed_baricade = -1;
        string mapThing = String.Empty;
        public Form1()
        {
            InitializeComponent();
            state = State.r1;
            myMap = new Map();
            buttons = new List<Button>()
            {
                ready1,ready2,ready3,ready4,ready5,ready6,
                person1,person3,person5,person7,person9,person10,
                enemy1,enemy2,enemy3,
                baricade1,baricade2,baricade3,
                fire1,fire2,fire3,fire4,fire5,fire6,
                paint0,paint1,paint2,paint3,paint4,paint5,paint6,paint7,paint8,
                tDraw1,tDraw2,tDraw3,tDraw4,tDraw5,tDraw6
            };
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].Name.Contains("person") || buttons[i].Name.Contains("enemy") || buttons[i].Name.Contains("baricade") || buttons[i].Name.Contains("fire"))
                {
                    buttons[i].Visible = false;
                }
                if (!buttons[i].Name.Equals("ready1"))
                {
                    buttons[i].Enabled = false;
                }
            }
            g = map.CreateGraphics();
            posLabel.Visible = false;
        }

        private void hideThings_Click(object sender, EventArgs e)
        {
            if (hideThings.Checked)
            {
                hideThings.Checked = false;
                inventory.Visible = true;
            }
            else
            {
                hideThings.Checked = true;
                inventory.Visible = false;
            }
        }

        private void hidePeople_Click(object sender, EventArgs e)
        {
            if (hidePeople.Checked)
            {
                hidePeople.Checked = false;
                persons.Visible = true;
            }
            else
            {
                hidePeople.Checked = true;
                persons.Visible = false;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mark_Click(object sender, EventArgs e)
        {
            if (state != State.erause && state != State.move && state != State.final)
            {
                previousState = state;
            }
            string mark = ((Button)sender).Name;
            Cursor myCursor;
            switch (mark)
            {
                case "erauseB":
                    state = State.erause;
                    myCursor = Cursors.No;
                    break;
                case "moveB":
                    state = State.move;
                    myCursor = Cursors.Arrow;
                    break;
                default:
                    myCursor = Cursors.Cross;
                    break;

            }
            map.Cursor = myCursor;
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttons[i].Name.Contains("ready") && buttons[i].Enabled)
                {
                    buttons[i].Text = "Продовжити";
                }
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Order order = new Order(myMap);
            order.Show();
        }

        private void create_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Create createWindow = new Create(this);
            createWindow.FormClosed += Create_FormClosed;
            createWindow.Show();
        }

        private void Create_FormClosed(object sender, FormClosedEventArgs e)
        {
            state = State.r1;
            myMap = new Map();
            Enabled = true;
            direction.Text = Map.Direction[0];
            antiDirection.Text = Map.Direction[1];
            UpdateMap();
            switch (Map.typeSoilders)
            {
                case TypeSoilders.first:
                    soilder_index = 0;
                    break;
                case TypeSoilders.second:
                    soilder_index = 1;
                    break;
                case TypeSoilders.third:
                    soilder_index = 2;
                    break;
            }

        }

        private void map_Paint(object sender, PaintEventArgs e)
        {
            //UpdateMap();
        }

        void UpdateMap()
        {
            if (onMap.Checked)
            {
                myMap.isMapEnabled = true;
            }
            else
            {
                myMap.isMapEnabled = false;
            }
            g.Clear(Color.AliceBlue);
            myMap.Draw(g);
        }

        private void map_MouseClick(object sender, MouseEventArgs e)
        {
            int mousePosition = -1;
            switch (state)
            {
                case State.r1:
                    x = e.X;
                    y = e.Y;
                    this.Enabled = false;
                    newItem item = new newItem(this);
                    item.Show();
                    item.FormClosed += newItem_FormClosed;
                    break;
                case State.r2:
                    mousePosition = CheckPoints(e);
                    for (int i = 0; i < myMap.TempPoints.Count; i++)
                    {
                        if (i == mousePosition)
                        {
                            myMap.TempPoints[i].PointColor = Color.Red;
                            myMap.Enemy = myMap.TempPoints[i].Position;
                        }
                        else
                        {
                            myMap.TempPoints[i].PointColor = Color.LightGreen;
                        }
                    }
                    break;
                case State.r3:
                    if (choosed_soilder != -1)
                    {
                        mousePosition = CheckPoints(e);
                        if (mousePosition != -1)
                        {
                            myMap.Soldiers[soilder_index][choosed_soilder].Position = myMap.TempPoints[mousePosition].Position;
                            myMap.DrawedSoilders.Add(myMap.Soldiers[soilder_index][choosed_soilder]);
                            myMap.Soldiers[soilder_index].RemoveAt(choosed_soilder);
                            choosed_soilder = -1;
                            myMap.TempPoints.RemoveAt(mousePosition);
                            state = State.reserved;
                            MessageBox.Show("Оберіть запасну позицію або іншого військового");
                        }
                        else if (mousePosition == -1 && e.Y > 489)
                        {
                            myMap.Soldiers[soilder_index][choosed_soilder].Position = new Point(e.X, e.Y);
                            myMap.DrawedSoilders.Add(myMap.Soldiers[soilder_index][choosed_soilder]);
                            myMap.Soldiers[soilder_index].RemoveAt(choosed_soilder);
                            choosed_soilder = -1;
                            state = State.reserved;
                            MessageBox.Show("Оберіть запасну позицію або іншого військового");
                        }
                        else
                        {
                            MessageBox.Show("Оберіть окоп поза позицією");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Оберіть іншого військовослужбовця");
                        return;
                    }
                    break;
                case State.reserved:
                    mousePosition = CheckPoints(e);
                    if (mousePosition != -1)
                    {
                        myMap.DrawedSoilders[myMap.DrawedSoilders.Count - 1].ReservedPosition = myMap.TempPoints[mousePosition].Position;
                        myMap.TempPoints.RemoveAt(mousePosition);
                        state = State.r3;
                    }
                    else if (mousePosition == -1 && e.Y > 489)
                    {
                        myMap.DrawedSoilders[myMap.DrawedSoilders.Count - 1].ReservedPosition = new Point(e.X, e.Y);
                        state = State.r3;
                    }
                    else
                    {
                        MessageBox.Show("Оберіть окоп поза позицією");
                    }
                    break;
                case State.r4:
                    myMap.FireArea = new Point(e.X, e.Y);
                    break;
                case State.r5:
                    myMap.Baricade[choosed_baricade].Add(new Point(e.X, e.Y));
                    break;
                case State.r6:
                    if (lineCounter == 1)
                    {
                        choosed_liner = CheckLiner(e);
                        if (choosed_liner == -1)
                        {
                            return;
                        }
                        if (myMap.DrawedSoilders[choosed_liner].Lines.Count == 3)
                        {
                            MessageBox.Show("Не може бути більше смуг вогню");
                            return;
                        }
                        myMap.DrawedSoilders[choosed_liner].Lines.Add(new Line(myMap.DrawedSoilders[choosed_liner].Position));
                        lineCounter++;
                    }
                    else if (lineCounter == 2)
                    {
                        for (int i = 0; i < myMap.DrawedSoilders[choosed_liner].Lines.Count; i++)
                        {
                            if (myMap.DrawedSoilders[choosed_liner].Lines[i].EndPoint == new Point(0, 0))
                            {
                                myMap.DrawedSoilders[choosed_liner].Lines[i].EndPoint = new Point(e.X, e.Y);
                            }
                        }
                        lineCounter = 1;
                    }
                    else
                    {
                        return;
                    }
                    break;
                case State.final:
                    break;
                case State.erause:
                    Check_Mouse(e, out int temp);
                    if (temp == -1) return;
                    myMap.Things.Remove(myMap.Things[temp]);
                    break;
                case State.paint:
                    switch (mapThing)
                    {
                        case "grass":
                            myMap.MapThings.Add(new MapThing(thingType.grass, new Point(e.X, e.Y)));
                            break;
                        case "water":
                            myMap.MapThings.Add(new MapThing(thingType.water, new Point(e.X, e.Y)));
                            break;
                        case "road":
                            myMap.MapThings.Add(new MapThing(thingType.road, new Point(e.X, e.Y)));
                            break;
                        case "river":
                            myMap.MapThings.Add(new MapThing(thingType.river, new Point(e.X, e.Y)));
                            break;
                    }
                    break;
                case State.move:
                    break;
            }
            UpdateMap();
        }

        private void newItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            if (Thing.idAdding)
            {
                myMap.Things.Add(new Thing(new Point(x, y), Thing.newItemName, Thing.newItemDirection.ToString(),Thing.newItemHighth.ToString()));
                Thing.idAdding = false;
            }
            UpdateMap();
        }

        private void Check_Mouse(MouseEventArgs e, out int temp)       //Getting temp for our choosed object
        {
            int temps = -1;
            for (int i = 0; i < myMap.Things.Count; i++)
            {
                if ((e.X < myMap.Things[i].Position.X + 20) && (e.X + 20 > myMap.Things[i].Position.X))
                {
                    if ((e.Y < myMap.Things[i].Position.Y + 20) && (e.Y + 20 > myMap.Things[i].Position.Y))
                    {
                        temps = i;
                    }
                }
            }
            temp = temps;
        }

        private int CheckPoints(MouseEventArgs e)
        {
            int temps = -1;
            for (int i = 0; i < myMap.TempPoints.Count; i++)
            {
                if ((e.X < myMap.TempPoints[i].Position.X + 20) && (e.X + 20 > myMap.TempPoints[i].Position.X))
                {
                    if ((e.Y < myMap.TempPoints[i].Position.Y + 20) && (e.Y + 20 > myMap.TempPoints[i].Position.Y))
                    {
                        temps = i;
                    }
                }
            }
            return temps;
        }

        private int CheckLiner(MouseEventArgs e)
        {
            int temps = -1;
            for (int i = 0; i < myMap.DrawedSoilders.Count; i++)
            {
                if ((e.X < myMap.DrawedSoilders[i].Position.X + 20) && (e.X + 20 > myMap.DrawedSoilders[i].Position.X))
                {
                    if ((e.Y < myMap.DrawedSoilders[i].Position.Y + 20) && (e.Y + 20 > myMap.DrawedSoilders[i].Position.Y))
                    {
                        temps = i;
                    }
                }
            }
            return temps;
        }

        private void map_MouseUp(object sender, MouseEventArgs e)
        {
            if (state == State.move)
            {
                IsClicked = false;
                checker = -1;
            }
        }

        private void map_MouseDown(object sender, MouseEventArgs e)
        {
            if (state == State.move)
            {
                Check_Mouse(e, out checker);
                IsClicked = true;
            }
        }

        private void map_MouseMove(object sender, MouseEventArgs e)
        {

            if (state == State.move)
            {
                if (IsClicked && checker >= 0)
                {
                    myMap.Things[checker].Position = new Point(e.X, e.Y);
                }
            }
            Position.Text = $"Position : {e.X} {e.Y}";
        }

        private void ready(object sender, EventArgs e)
        {
            map.Cursor = Cursors.Arrow;
            Button button = (Button)sender;
            Console.WriteLine(button.Name);
            if (button.Text.Equals("Продовжити"))
            {
                button.Text = "Готово";
                state = previousState;
                return;
            }
            switch (button.Name)
            {
                case "ready1":
                    //if(mymap.things.count == 0)
                    //{
                    //    messagebox.show("поставте хоча б 1 орієнтир");
                    //    return;
                    //}
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (!buttons[i].Name.Equals("ready2"))
                        {
                            buttons[i].Enabled = false;
                        }
                        else
                        {
                            buttons[i].Enabled = true;
                        }
                        if (buttons[i].Name.Contains("enemy"))
                        {
                            buttons[i].Visible = true;
                            buttons[i].Enabled = true;
                        }
                    }
                    myMap.TempPoints = new List<TempPoint>
                    {
                        new TempPoint(new Point(87,68), Color.LightGreen),
                        new TempPoint(new Point(353,68), Color.LightGreen),
                        new TempPoint(new Point(630,68), Color.LightGreen)
                    };
                    state = State.r2;
                    enemy1.PerformClick();
                    break;
                case "ready2":
                    //if (myMap.Enemy.position == (new Point(0,0)))
                    //{
                    //    MessageBox.Show("Оберіть позицію противника");
                    //    return;
                    //}
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (buttons[i].Name.Contains("enemy"))
                        {
                            buttons[i].Visible = false;
                            buttons[i].Enabled = false;
                        }
                        if (buttons[i].Name.Contains("person"))
                        {
                            buttons[i].Visible = true;
                        }
                        if (buttons[i].Name.Equals("ready2") || buttons[i].Name.Equals("ready1") || buttons[i].Name.Equals("ready5") || buttons[i].Name.Equals("ready6") || buttons[i].Name.Equals("ready4") || buttons[i].Name.Equals("cancel"))
                        {
                            buttons[i].Enabled = false;
                        }
                        else
                        {
                            buttons[i].Enabled = true;
                        }
                    }
                    myMap.TempPoints = new List<TempPoint>
                    {
                        new TempPoint(new Point(195,487), Color.LightGreen), //191,482
                        new TempPoint(new Point(255,460), Color.LightGreen),//250,455
                        new TempPoint(new Point(305,461), Color.LightGreen),//299,453
                        new TempPoint(new Point(360,475), Color.LightGreen),//354,470
                        new TempPoint(new Point(410,475), Color.LightGreen),//403,472
                        new TempPoint(new Point(472,455), Color.LightGreen),//467,451
                        new TempPoint(new Point(520,485), Color.LightGreen)//515,482
                    };
                    posLabel.Visible = true;
                    state = State.r3;
                    break;
                case "ready3":
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (buttons[i].Name.Contains("person"))
                        {
                            buttons[i].Visible = false;
                        }
                        if (!buttons[i].Name.Equals("ready4"))
                        {
                            buttons[i].Enabled = false;
                        }
                        else
                        {
                            buttons[i].Enabled = true;
                        }
                        if (buttons[i].Name.Contains("fire"))
                        {
                            buttons[i].Enabled = true;
                            buttons[i].Visible = true;
                        }
                    }
                    myMap.TempPoints = new List<TempPoint> { };
                    state = State.r4;
                    fire1.PerformClick();
                    break;
                case "ready4":
                    //if(myMap.FireArea == (new Point(0, 0)))
                    //{
                    //    MessageBox.Show("Поставте ділянку зосередженого вогню");
                    //    return;
                    //}
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (!buttons[i].Name.Equals("ready5"))
                        {
                            buttons[i].Enabled = false;
                        }
                        else
                        {
                            buttons[i].Enabled = true;
                        }
                        if (buttons[i].Name.Contains("baricade"))
                        {
                            buttons[i].Enabled = true;
                            buttons[i].Visible = true;
                        }
                        if (buttons[i].Name.Contains("fire"))
                        {
                            buttons[i].Enabled = false;
                            buttons[i].Visible = false;
                        }
                    }
                    state = State.r5;
                    baricade1.PerformClick();
                    break;
                case "ready5":
                    //if (myMap.Baricade.Count < 2)
                    //{
                    //    MessageBox.Show("Позначте інженерні загородження");
                    //    return;
                    //}
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (!buttons[i].Name.Equals("ready6"))
                        {
                            buttons[i].Enabled = false;
                        }
                        else
                        {
                            buttons[i].Enabled = true;
                        }
                        if (buttons[i].Name.Contains("baricade"))
                        {
                            buttons[i].Enabled = false;
                            buttons[i].Visible = false;
                        }
                    }
                    for (int i = 0; i < myMap.DrawedSoilders.Count; i++)
                    {
                        myMap.TempPoints.Add(new TempPoint(new Point(myMap.DrawedSoilders[i].Position.X - 5, myMap.DrawedSoilders[i].Position.Y)));
                    }
                    state = State.r6;
                    break;
                case "ready6":
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (!buttons[i].Name.Equals("cancel"))
                        {
                            buttons[i].Enabled = false;
                        }
                        else
                        {
                            buttons[i].Enabled = true;
                        }
                    }
                    state = State.final;
                    break;
                case "cancel":
                    ready1.Enabled = true;
                    state = State.r1;
                    myMap = new Map();
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (!buttons[i].Name.Contains("ready"))
                        {
                            buttons[i].Visible = false;
                        }
                        if (!buttons[i].Name.Equals("ready1"))
                        {
                            buttons[i].Enabled = false;
                        }
                    }
                    posLabel.Visible = false;
                    break;
            }
            UpdateMap();
        }

        private void person_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "person1":
                    ChoosePerson(SoilderTypes.BMP, ref button);
                    state = State.r3;
                    break;
                case "person3":
                    ChoosePerson(SoilderTypes.rifleman, ref button);
                    state = State.r3;
                    break;
                case "person5":
                    ChoosePerson(SoilderTypes.machine_gunner, ref button);
                    state = State.r3;
                    break;
                case "person7":
                    ChoosePerson(SoilderTypes.grenade_launcher, ref button);
                    state = State.r3;
                    break;
                case "person9":
                    MessageBox.Show("Обрано БТР");
                    state = State.r3;
                    break;
                case "person10":
                    MessageBox.Show("Обрано ТАНК");
                    state = State.r3;
                    break;
                case "enemy1":
                    myMap.EnemyPict = Resources.Ataka1;
                    break;
                case "enemy2":
                    myMap.EnemyPict = Resources.Ataka2; //
                    break;
                case "enemy3":
                    myMap.EnemyPict = Resources.Ataka3; //
                    break;
                case "baricade1":
                    choosed_baricade = 0;
                    break;
                case "baricade2":
                    choosed_baricade = 1;
                    break;
                case "baricade3":
                    choosed_baricade = 2;
                    break;
                case "fire1":
                    myMap.ZonaVPict = Resources._123;
                    break;
                case "fire2":
                    myMap.ZonaVPict = Resources._132;
                    break;
                case "fire3":
                    myMap.ZonaVPict = Resources._213;
                    break;
                case "fire4":
                    myMap.ZonaVPict = Resources._231;
                    break;
                case "fire5":
                    myMap.ZonaVPict = Resources._312;
                    break;
                case "fire6":
                    myMap.ZonaVPict = Resources._321;
                    break;
                case "tDraw1":
                    mapThing = "grass";
                    break;
                case "tDraw2":
                    mapThing = "water";
                    break;
                case "tDraw3":
                    mapThing = "road";
                    break;
                case "tDraw4":
                    mapThing = "river";
                    break;

            }
        }

        void ChoosePerson(SoilderTypes type, ref Button button)
        {
            bool isEmpty = true;
            for (int i = 0; i < myMap.Soldiers[soilder_index].Count; i++)
            {
                if (myMap.Soldiers[soilder_index][i].SoilderType == type)
                {
                    MessageBox.Show($"Обрано {myMap.Soldiers[soilder_index][i].Name}");
                    choosed_soilder = i;
                    isEmpty = false;
                    return;
                }
            }
            if (isEmpty)
            {
                button.Enabled = false;
            }
        }

        private void oriTable_Click(object sender, EventArgs e)
        {
            oriTable table = new oriTable(myMap);
            table.Show();
        }

        private void exportMap_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(700, 900);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                myMap.Draw(gr);
            }
            bmp.Save("map.jpg"); ;
            MessageBox.Show("Карта збережена в " + Application.ExecutablePath);
        }

        private void description_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FireCard (Alpha v.0.15)");
        }

        private void creators_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developers:\n" +
                "Litvin Oleksandr\n" +
                "Virsta Anastasya\n" +
                "Binkovsky Dmutro\n" +
                "Valentun Kit");
        }

        private void onMap_Click(object sender, EventArgs e)
        {
            UpdateMap();
        }

        private void onPaintModeClick(object sender, EventArgs e)
        {
            if (onPaintMode.Checked)
            {
                previousState = state;
                state = State.paint;
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (buttons[i].Name.Contains("ready") && buttons[i].Enabled)
                    {
                        buttons[i].Text = "Продовжити";
                        buttons[i].Enabled = false;
                    }
                    if (buttons[i].Name.Contains("tDraw"))
                    {
                        buttons[i].Visible = true;
                        buttons[i].Enabled = true;
                    }
                
                }
            }
            else
            {
                state = previousState;
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (buttons[i].Text.Contains("Продовжити"))
                    {
                        buttons[i].Text = "Готово";
                        buttons[i].Enabled = true;
                    }
                    if (buttons[i].Name.Contains("tDraw"))
                    {
                        buttons[i].Visible = false;
                    }
                }
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Map));

            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, myMap);
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Map));
            Map newPerson = new Map();
            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    newPerson = (Map)formatter.Deserialize(fs);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString()) ;
                }
            }
            myMap = newPerson;

        }
    }
}
