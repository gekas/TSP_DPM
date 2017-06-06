using System;

namespace DPM_TSP.Algos
{
    public abstract class OptimisationMethod : ITSPSolver
    {
        public ExecutionProcess ExecutionProcess { get; set; }

        public abstract Tour DoOptimisation(Tour inTour);

        public OptimisationMethod()
        {
            this.ExecutionProcess = new ExecutionProcess();
        }

        public static void ReverseSegment(Tour tour, int startIndex, int endIndex)
        {
            int N = tour.Size;

            int inversionSize = (int)Math.Floor(((N + endIndex - startIndex + 1) % N) / (double)2);

            int left = startIndex;
            int right = endIndex;

            for (int i = 0; i < inversionSize; i++)
            {
                var leftTmp = tour[left];
                tour[left] = tour[right];
                tour[right] = leftTmp;

                left = (left + 1) % N;
                right = (N + right - 1) % N;
            }
        }
    }
}
