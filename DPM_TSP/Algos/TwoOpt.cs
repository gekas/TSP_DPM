namespace DPM_TSP.Algos
{
    class TwoOpt : OptimisationMethod
    {
        public override Tour DoOptimisation(Tour tour)
        {
            bool locallyOptimal = false;
            int N = tour.Path.Count;

            var newTour = (Tour)tour.Clone();

            while (!locallyOptimal)
            {
                locallyOptimal = true;

                for (int counter_1 = 0; counter_1 <= N - 3; counter_1++)
                {
                    int i = counter_1;
                    var X1 = newTour[i];
                    var X2 = newTour[(i + 1) % N];
                    int conter_2_Limit = i == 0 ? N - 2
                                                : N - 1;

                    for (int counter_2 = i + 2; counter_2 <= conter_2_Limit; counter_2++)
                    {
                        int j = counter_2;
                        var Y1 = newTour[j];
                        var Y2 = newTour[(j + 1) % N];

                        double gain = GainFrom2Opt(X1, X2, Y1, Y2);
                       // ExecutionProcess.AddStep($"Calculate gain for {X1.Name} - {X2.Name}, {Y1.Name} - {Y2.Name}. Gain = {gain}", ExecutionProcess.StepType.CalculateGain);
                        if (gain > 0)
                        {
                            Make2OptMove(newTour, i, j);
                            ExecutionProcess.AddStep($"2-Opt move for {X1.Name} - {X2.Name}, {Y1.Name} - {Y2.Name}. Gain = {gain}", System.Drawing.Color.Green, ExecutionProcess.StepType.Move);

                            locallyOptimal = false;
                            break;
                        }
                    }

                    if (!locallyOptimal) break;
                }
            }

            return newTour;
        }

        public static double GainFrom2Opt(City X1, City X2, City Y1, City Y2)
        {
            double del_length = X1.CostTo(X2) + Y1.CostTo(Y2);
            double add_length = X1.CostTo(Y1) + X2.CostTo(Y2);

            return del_length - add_length;
        }

        public static void Make2OptMove(Tour tour, int i, int j)
        {
            ReverseSegment(tour, (i + 1) % tour.Size, j);
        }
    }
}
