using System.Collections.Generic;

namespace DPM_TSP.Algos
{
    public class NN : ConstructiveMethod
    {
        public override Tour GetTour(List<City> cities)
        {
            var cityFrom = cities[0];
            var path = new List<City>() { cityFrom };

            for(int i = 0; i<cities.Count; i++)
            {
                double minLength = int.MaxValue;
                City closestPoint = null;

                for(int j = 1; j < cities.Count; j++)
                {
                    if (cities[j] == cityFrom || path.Contains(cities[j])) continue;

                    var currentCost = cityFrom.CostTo(cities[j]);

                    if(currentCost < minLength)
                    {
                        minLength = currentCost;
                        closestPoint = cities[j];
                    }
                }

                cityFrom = closestPoint;

                if (closestPoint != null) path.Add(closestPoint);
              //  else path.Add(cities[0]);
            }

            return new Tour(path);
        }
    }
}
