using System.Drawing;

namespace DPM_TSP.Algos
{
    class OrOpt : OptimisationMethod
    {
        public override Tour DoOptimisation(Tour inTour)
        {
            var tour = (Tour)inTour.Clone();
            int N = tour.Size;

            bool locallyOptimal = false;

            while (!locallyOptimal)
            {
                locallyOptimal = true;

                for (int segmentLen = 3; segmentLen >= 1; segmentLen--)
                {
                    for (int pos = 0; pos <= N - 1; pos++)
                    {
                        int i = pos;
                        var X1 = tour[i];
                        var X2 = tour[(i + 1) % N];

                        int j = (i + segmentLen) % N;
                        var Y1 = tour[j];
                        var Y2 = tour[(j + 1) % N];

                        for (int shift = segmentLen + 1; shift <= N - 1; shift++)
                        {
                            int k = (i + shift) % N;
                            var Z1 = tour[k];
                            var Z2 = tour[(k + 1) % N];

                            double gain = GainFromSegmentShift(X1, X2, Y1, Y2, Z1, Z2);
                           // ExecutionProcess.AddStep($"Calculate gain for {X1.Name} - {X2.Name}, {Y1.Name} - {Y2.Name}, {Z1.Name} - {Z2.Name}. Gain = {gain}", ExecutionProcess.StepType.CalculateGain);
                            if (gain > 0)
                            {
                                int segmentSize = (j - i + N) % N;
                                if (tour.Path.Count < i +1+ segmentSize) break; 

                                MakeSegmentShiftMove(tour, i, j, k);
                                ExecutionProcess.AddStep($"Segment Shift for {X1.Name} - {X2.Name}, {Y1.Name} - {Y2.Name}, {Z1.Name} - {Z2.Name}. Gain = {gain}", Color.Green, ExecutionProcess.StepType.Move);

                                locallyOptimal = false;

                                break;
                            }
                        }

                        if (!locallyOptimal) break;
                    }
                }
            }

            return tour;
        }

        private double GainFromSegmentShift(City X1, City X2, City Y1, City Y2, City Z1, City Z2)
        {
            var del_length = X1.CostTo(X2) + Y1.CostTo(Y2) + Z1.CostTo(Z2);
            var add_length = X1.CostTo(Y2) + Z1.CostTo(X2) + Y1.CostTo(Z2);

            return del_length - add_length;
        }

        private void MakeSegmentShiftMove(Tour tour, int i, int j, int k)
        {
            SegmentShift(tour, i, j, k);
        }

        // Shifts the segment of tour:
        // cities from t[i+1] to t[j] from their current position to position
        // after current city t[k], that is between cities t[k] and t[k+1].
        // Assumes:  k, k+1 are not within the segment [i+1..j]
        private void SegmentShift(Tour tour, int i, int j, int k)
        {
            int N = tour.Size;
            int segmentSize = (j - i + N) % N;

            var segmentCopy = tour.Path.GetRange(i+1, segmentSize); // i+1
            tour.Path.RemoveRange(i + 1, segmentSize);

            int idxToPaste;
            if (i > k) idxToPaste = k + 1;
            else idxToPaste = k - segmentSize + 1;

            tour.Path.InsertRange(idxToPaste, segmentCopy);
        }
    }
}
