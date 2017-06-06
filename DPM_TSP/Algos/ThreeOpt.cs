using System.Drawing;

namespace DPM_TSP.Algos
{
    public class ThreeOpt : OptimisationMethod
    {
        private enum OptCase { opt3_case_0, opt3_case_1, opt3_case_2, opt3_case_3, opt3_case_4, opt3_case_5, opt3_case_6, opt3_case_7 };

        public override Tour DoOptimisation(Tour inTour)
        {
            OptCase[] optCases = new OptCase[] { OptCase.opt3_case_6, OptCase.opt3_case_7 };

            var tour = (Tour)inTour.Clone();

            bool locallyOptimal = false;
            int N = tour.Size;

            double gainExpected;

            while (!locallyOptimal)
            {
                locallyOptimal = true;

                for (int counter_1 = 0; counter_1 <= N - 1; counter_1++)
                {
                    int i = counter_1; // first cut after i

                    var X1 = tour[i];
                    var X2 = tour[(i + 1) % N];

                    for (int counter_2 = 1; counter_2 <= N - 3; counter_2++)
                    {
                        int j = (i + counter_2) % N; // second cut after j

                        var Y1 = tour[j];
                        var Y2 = tour[(j + 1) % N];

                        for (int counter_3 = counter_2 + 1; counter_3 <= N - 1; counter_3++)
                        {
                            int k = (i + counter_3) % N; // third cut after k

                            var Z1 = tour[k];
                            var Z2 = tour[(k + 1) % N];

                            for (int optCaseIdx = 0; optCaseIdx < optCases.Length; optCaseIdx++)
                            {
                                gainExpected = GainFrom3Opt(X1, X2, Y1, Y2, Z1, Z2, optCases[optCaseIdx]);
                               // ExecutionProcess.AddStep($"Calculate gain for {X1.Name} - {X2.Name}, {Y1.Name} - {Y2.Name}, {Z1.Name} - {Z2.Name}. Gain = {gainExpected}", ExecutionProcess.StepType.CalculateGain);

                                if (gainExpected > 0)
                                {
                                    Make3OptMove(tour, i, j, k, optCases[optCaseIdx]);
                                    ExecutionProcess.AddStep($"3-opt move for {X1.Name} - {X2.Name}, {Y1.Name} - {Y2.Name}, {Z1.Name} - {Z2.Name}. Gain = {gainExpected}", Color.Green, ExecutionProcess.StepType.Move);
                                    locallyOptimal = false;
                                }

                                if (!locallyOptimal) break;
                            }
                            if (!locallyOptimal) break;
                        }
                        if (!locallyOptimal) break;
                    }
                    if (!locallyOptimal) break;
                }
            }

            return tour;
        }

        private double GainFrom3Opt(City X1, City X2, City Y1, City Y2, City Z1, City Z2, OptCase optCase)
        {
            double del_Length = 0;
            double add_Length = 0;

            if (optCase == OptCase.opt3_case_0)
            {
                return 0;
            }

            // 2-OPT MOVES
            // move equal to a single 2-opt move
            if (optCase == OptCase.opt3_case_1)
            {       // a'bc;  2-opt (i,k)
                del_Length = X1.CostTo(X2) + Z1.CostTo(Z2);
                add_Length = X1.CostTo(Z1) + X2.CostTo(Z2);
            }
            else if (optCase == OptCase.opt3_case_2)
            { // abc';  2-opt (j,k)
                del_Length = Y1.CostTo(Y2) + Z1.CostTo(Z2);
                add_Length = Y1.CostTo(Z1) + Y2.CostTo(Z2);
            }
            else if (optCase == OptCase.opt3_case_3)
            { // ab'c;  2-opt (i,j)
                del_Length = X1.CostTo(X2) + Y1.CostTo(Y2);
                add_Length = X1.CostTo(Y1) + X2.CostTo(Y2);
            }

            // PURE 3-OPT MOVES
            // NOTE: all 3 edges to be removed, so the same formula for del_Length
            // A) move equal to two subsequent 2-opt moves, asymmetric
            else if (optCase == OptCase.opt3_case_4)
            { // ab'c'
                del_Length = X1.CostTo(X2) + Y1.CostTo(Y2) + Z1.CostTo(Z2);
                add_Length = X1.CostTo(Y1) + X2.CostTo(Z1) + Y2.CostTo(Z2);
            }
            else if (optCase == OptCase.opt3_case_5)
            { // a'b'c
                del_Length = X1.CostTo(X2) + Y1.CostTo(Y2) + Z1.CostTo(Z2);
                add_Length = X1.CostTo(Z1) + Y2.CostTo(X2) + Y1.CostTo(Z2);
            }
            else if (optCase == OptCase.opt3_case_6)
            { // a'bc'
                del_Length = X1.CostTo(X2) + Y1.CostTo(Y2) + Z1.CostTo(Z2);
                add_Length = X1.CostTo(Y2) + Z1.CostTo(Y1) + X2.CostTo(Z2);
            }
            // B) move equal to three subsequent 2-opt moves, symmetric
            else if (optCase == OptCase.opt3_case_7)
            { // a'b'c' (=acb)
                del_Length = X1.CostTo(X2) + Y1.CostTo(Y2) + Z1.CostTo(Z2);
                add_Length = X1.CostTo(Y2) + Z1.CostTo(X2) + Y1.CostTo(Z2);
            }

            double result = del_Length - add_Length;
            return result;
        }

        private void Make3OptMove(Tour tour, int i, int j, int k, OptCase optCase)
        {
            int N = tour.Size;

            // 2-OPT MOVES
            // one of the three links is removed and added again
            if (optCase == OptCase.opt3_case_1)
            {       // a'bc;  2-opt (i,k)
                TwoOpt.ReverseSegment(tour, (k + 1) % N, i);
            }
            else if (optCase == OptCase.opt3_case_2)
            { // abc';  2-opt (j,k)
                TwoOpt.ReverseSegment(tour, (j + 1) % N, k);
            }
            else if (optCase == OptCase.opt3_case_3)
            { // ab'c;  2-opt (i,j)
                TwoOpt.ReverseSegment(tour, (i + 1) % N, j);
            }

            // PURE 3-OPT MOVES
            // all three links are removed, then other links between cities added
            // A) moves equal to two subsequent 2-opt moves, asymmetric:
            else if (optCase == OptCase.opt3_case_4)
            { // ab'c'
                TwoOpt.ReverseSegment(tour, (j + 1) % N, k);
                TwoOpt.ReverseSegment(tour, (i + 1) % N, j);
            }
            else if (optCase == OptCase.opt3_case_5)
            { // a'b'c
                TwoOpt.ReverseSegment(tour, (k + 1) % N, i);
                TwoOpt.ReverseSegment(tour, (i + 1) % N, j);
            }
            else if (optCase == OptCase.opt3_case_6)
            { // a'bc'
                TwoOpt.ReverseSegment(tour, (k + 1) % N, i);
                TwoOpt.ReverseSegment(tour, (j + 1) % N, k);
            }
            // B) move equal to three subsequent 2-opt moves, symmetric
            else if (optCase == OptCase.opt3_case_7)
            { // a'b'c' (=acb)
                TwoOpt.ReverseSegment(tour, (k + 1) % N, i);
                TwoOpt.ReverseSegment(tour, (i + 1) % N, j);
                TwoOpt.ReverseSegment(tour, (j + 1) % N, k);
            }
        }
    }
}
