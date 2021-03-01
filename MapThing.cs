using System;
using System.Drawing;

namespace FireCard
{
    public enum thingType { garden, house , rip, river}
    [Serializable]
    public class MapThing
    {
        public MapThing()
        {
        }

        public MapThing(thingType tThype, Point position)
        {
            this.tThype = tThype;
            Position = position;
        }

        public thingType tThype { get; set; }
        public  Point Position { get; set; }
    }
}