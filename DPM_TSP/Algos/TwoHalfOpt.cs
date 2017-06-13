namespace DPM_TSP.Algos
{
    public class TwoHalfOpt : TwoOpt
    {
        public override Tour DoOptimisation(Tour inTour)
        {
            var tour = (Tour)inTour.Clone();
            int N = tour.Size;
            bool locallyOptimal = false;

            while (!locallyOptimal)
            {
                locallyOptimal = true;

                for(int counter_1 = 0; counter_1 <= N - 3; counter_1++)
                {
                    int i = counter_1;
                    var X1 = tour[i];
                    var X2 = tour[(i + 1) % N];

                    for(int counter_2 = counter_1 + 2; counter_2 <= N - 1; counter_2++)
                    {
                        int j = counter_2;
                        var Y1 = tour[j];
                        var Y2 = tour[(j + 1) % N];

                        var gain = GainFrom2Opt(X1, X2, Y1, Y2);
                       // ExecutionProcess.AddStep($"Calculate 2-opt node shift gain for {X1.Name} - {X2.Name}, {Y1.Name} - {Y2.Name}. Gain = {gain}", ExecutionProcess.StepType.CalculateGain);

                        if (gain > 0)
                        {
                            Make2OptMove(tour, i ,j);
                            ExecutionProcess.AddStep($"2-Opt move for {X1.Name} - {X2.Name}, {Y1.Name} - {Y2.Name}. Gain = {gain}", System.Drawing.Color.Green, ExecutionProcess.StepType.Move);

                            locallyOptimal = false;
                            break;
                        }
                        else
                        {
                            var V0 = tour[(i + 2) % N];
                            if (V0 != Y1) {
                                var gainFromNodeShift = GainFromNodeShift(X1, X2, V0, Y1, Y2);
                                //ExecutionProcess.AddStep($"Calculate node shift gain for {X1.Name} - {X2.Name},  V0 = {V0.Name}, {Y1.Name} - {Y2.Name}. Gain = {gainFromNodeShift}", ExecutionProcess.StepType.CalculateGain);

                                if (gainFromNodeShift > 0)
                                {
                                    MakeNodeShiftMove(tour, (i+1)%N, j);
                                    ExecutionProcess.AddStep($"Node Shift for {X1.Name} - {X2.Name},  V0 = {V0.Name}, {Y1.Name} - {Y2.Name}. Gain = {gainFromNodeShift}", System.Drawing.Color.Green, ExecutionProcess.StepType.Move);

                                    locallyOptimal = false;
                                    break;
                                }
                            }
                            else {
                                V0 = tour[(N + j - 1) % N];

                                if(V0 != X2)
                                {
                                    var gainFromNodeShift = GainFromNodeShift(V0, Y1, Y2, X1, X2);
                                    //ExecutionProcess.AddStep($"Calculate node shift gain for V0 = {V0.Name}, {Y1.Name} - {Y2.Name} {X1.Name} - {X2.Name}. Gain = {gainFromNodeShift}", ExecutionProcess.StepType.CalculateGain);

                                    if (gainFromNodeShift > 0)
                                    {
                                        MakeNodeShiftMove(tour, i, j);
                                        ExecutionProcess.AddStep($"Node Shift for V0 = {V0.Name}, {Y1.Name} - {Y2.Name} {X1.Name} - {X2.Name}. Gain = {gainFromNodeShift}", System.Drawing.Color.Green, ExecutionProcess.StepType.Move);

                                        locallyOptimal = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    if (!locallyOptimal) break;
                }
            }

            return tour;

        }

        // Gain of tour length which can be obtained by performing Node Shift
        // City V0 would be moved from its current position, between X1
        // and X2, to position between cities Y1 and Y2.
        // Assumes: X1!=Y1 (the same as: V0!=Y2);
        //  V0==successor(X1); X2==successor(V0); Y2==successor(Y1)
        private double GainFromNodeShift(City X1, City V0, City X2, City Y1, City Y2)
        {
            var del_Length = X1.CostTo(V0) + V0.CostTo(X2) + Y1.CostTo(Y2);
            var add_Length = X1.CostTo(X2) + Y1.CostTo(V0) + V0.CostTo(Y2);

            return del_Length - add_Length;
        }

        // Performs given Node Shift move
        // Shifts the city t[i] from its current position to position
        // after current city t[j], i.e. between cities t[j] and t[j+1].
        // This is a special, simple case of segment shift, thus a special
        // case of 3-opt move.
        private void MakeNodeShiftMove(Tour tour, int i ,int j)
        {
            int N = tour.Size;

            int shiftSize = (j - i + 1 + N) % N;

            City X0 = tour[i];
            int left = i;
            int right;

            for (int counter = 1; counter <= shiftSize; counter++)
            {
                right = (left + 1) % N;
                tour[left] = tour[right];
                left = right;
            }

            tour[j] = X0;
        }
    }
}
