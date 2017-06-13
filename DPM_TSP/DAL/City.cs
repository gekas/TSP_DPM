using System;

namespace DPM_TSP
{
    public class City
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public City()
        { }

        public City(City c)
        {
            Name = c.Name;
            X = c.X;
            Y = c.Y;
        }

        public double CostTo(City n)
        {
            return Math.Ceiling(Math.Sqrt((this.X - n.X) * (this.X - n.X) + (this.Y - n.Y) * (this.Y - n.Y)));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
