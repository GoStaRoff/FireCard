using System;
using System.Drawing;

namespace FireCard
{
    public enum thingType {
        tree,
        virubka,
        vishka,
        water,
        sad,
        pamyatnik,
        kuschi,
        kurgan,
        kamni,
        cerkva,
        house
    }
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