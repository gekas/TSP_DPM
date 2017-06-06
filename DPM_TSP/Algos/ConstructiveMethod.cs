using System.Collections.Generic;

namespace DPM_TSP.Algos
{
    public abstract class ConstructiveMethod : ITSPSolver
    {
        public abstract Tour GetTour(List<City> cities);
    }
}
