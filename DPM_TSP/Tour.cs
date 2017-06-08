using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DPM_TSP
{
    public class Tour : ICloneable
    {
        [JsonProperty(Required = Required.Always)]
        public string TSPName { get; set; }
        public double BestKnownSolution { get; set; }
        public List<City> Path { get; set; }

        public int Size { get { return Path.Count; } }

        /// <summary>
        /// Parameterless ctor for serialization.
        /// </summary>
        public Tour()
        { }

        public Tour(List<City> cities)
        {
            Path = cities;
        }

        public void SetCity(int position, City city)
        {
            Path[position] = city;
        }

        public City GetCity(int position)
        {
            return Path[position];
        }

        public void SetCities(List<City> cities)
        {
            Path = cities;
        }

        public double GetCost(List<City> cities)
        {
            double routeCost = 0;

            for (int i = 0; i < cities.Count; i++)
            {
                var fromCity = cities[i];
                var destinationCity = i + 1 < cities.Count
                    ? cities[i + 1]
                    : cities[0];

                routeCost += fromCity.CostTo(destinationCity);
            }

            return routeCost;
        }

        public double GetCost()
        {
            return GetCost(Path);
        }

        public City this[int i]
        {
            get { return Path[i]; }
            set { Path[i] = value; }
        }


        public object Clone()
        {
            return new Tour(this.Path.Select(c => new City(c)).ToList()) { TSPName = this.TSPName, BestKnownSolution = this.BestKnownSolution };
        }
    }
}
