using DPM_TSP.Algos;
using DPM_TSP.Extensions;
using DPM_TSP.Utils;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DPM_TSP
{
    public enum OptMethods
    {
        TwoOpt,
        TwoHalfOpt,
        ThreeOpt,
        OrOpt
    };

    public partial class MainForm : Form
    {
        private MeasurementManager mng;

        private Tour nnTour;

        TwoOpt twoOptSolver;
        TwoHalfOpt twoHalfOptSolver;
        ThreeOpt threeOptSolver;
        OrOpt orOptSolver;

        Series nnSerie;
        Series srTwoOpt;
        Series srTwoHalfOpt;
        Series srThreeOpt;
        Series srOrOpt;

        public MainForm()
        {
            InitializeComponent();
            crtNN.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            crtNN.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
            crtNN.ChartAreas[0].AxisX.LineColor = Color.Silver;
            crtNN.ChartAreas[0].AxisY.LineColor = Color.Silver;
            crtResult.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            crtResult.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
            crtResult.ChartAreas[0].AxisX.LineColor = Color.Silver;
            crtResult.ChartAreas[0].AxisY.LineColor = Color.Silver;

            mng = new MeasurementManager();

            nnSerie = new Series("NN") { ChartType = SeriesChartType.Line, MarkerStyle = MarkerStyle.Circle, BorderWidth = 2 };

            srTwoOpt = new Series("2-Opt") { ChartType = SeriesChartType.Line, MarkerStyle = MarkerStyle.Circle, BorderWidth = 2 };
            srTwoHalfOpt = new Series("2.5-Opt") { ChartType = SeriesChartType.Line, MarkerStyle = MarkerStyle.Circle, BorderWidth = 2 };
            srThreeOpt = new Series("3-Opt") { ChartType = SeriesChartType.Line, MarkerStyle = MarkerStyle.Circle, BorderWidth = 2 };
            srOrOpt = new Series("Or-Opt") { ChartType = SeriesChartType.Line, MarkerStyle = MarkerStyle.Circle, BorderWidth = 2 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvResults.DataSource = mng.Items;
        }

        private void DoOptimisation(Tour tour)
        {
            if (cbxTwoOpt.Checked)
            {
                var resultMeasurement = ExecuteMeasurements(twoOptSolver = new TwoOpt(), nnTour, "2-Opt");

                tcMCharts.TabPages.Add(tpTwoOpt);
                foreach (var item in resultMeasurement.ResultTour.Path) srTwoOpt.Points.Add(new DataPoint(item.X, item.Y) { Label = item.Name });
                srTwoOpt.Points.Add(new DataPoint(resultMeasurement.ResultTour.Path[0].X, resultMeasurement.ResultTour.Path[0].Y));
            }
            if (cbxTwoHalfOpt.Checked)
            {
                var resultMeasurement = ExecuteMeasurements(twoHalfOptSolver = new TwoHalfOpt(), nnTour, "2.5-Opt");

                tcMCharts.TabPages.Add(tpTwoHalfOpt);
                foreach (var item in resultMeasurement.ResultTour.Path) srTwoHalfOpt.Points.Add(new DataPoint(item.X, item.Y) { Label = item.Name });
                srTwoHalfOpt.Points.Add(new DataPoint(resultMeasurement.ResultTour.Path[0].X, resultMeasurement.ResultTour.Path[0].Y));

            }
            if (cbxThreeOpt.Checked)
            {
                var resultMeasurement = ExecuteMeasurements(threeOptSolver = new ThreeOpt(), nnTour, "3-Opt");

                tcMCharts.TabPages.Add(tpThreeOpt);
                foreach (var item in resultMeasurement.ResultTour.Path) srThreeOpt.Points.Add(new DataPoint(item.X, item.Y) { Label = item.Name });
                srThreeOpt.Points.Add(new DataPoint(resultMeasurement.ResultTour.Path[0].X, resultMeasurement.ResultTour.Path[0].Y));
            }
            if (cbxOrOpt.Checked)
            {
                var resultMeasurement = ExecuteMeasurements(orOptSolver = new OrOpt(), nnTour, "Or-Opt");

                tcMCharts.TabPages.Add(tpOrOpt);
                foreach (var item in resultMeasurement.ResultTour.Path) srOrOpt.Points.Add(new DataPoint(item.X, item.Y) { Label = item.Name });
                srOrOpt.Points.Add(new DataPoint(resultMeasurement.ResultTour.Path[0].X, resultMeasurement.ResultTour.Path[0].Y));
            }

            FillResultsTable(mng);
        }

        private MeasurementItem ExecuteMeasurements(OptimisationMethod optMethod, Tour initialTour, string methodName)
        {
            MeasurementItem resultMeasurement = null;
            for (int i = 0; i < nudRepeats.Value; i++)
            {
                resultMeasurement = GetMeasurement(optMethod, initialTour, methodName);
                mng.Items.Add((MeasurementItem)resultMeasurement.Clone());
            }

            return resultMeasurement;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            ClearCharts();
            foreach (var item in nnTour.Path) nnSerie.Points.Add(new DataPoint(item.X, item.Y) { Label = item.Name });
            nnSerie.Points.Add(new DataPoint(nnTour.Path[0].X, nnTour.Path[0].Y));
            crtNN.Series.Clear();
            crtNN.Series.Add(nnSerie);

            DoOptimisation(nnTour);
            tcMCharts_SelectedIndexChanged(sender, e);
            FillCommonResults();
        }

        private MeasurementItem GetMeasurement(OptimisationMethod method, Tour tourToOptimise, string displayMethodName)
        {
            Tour resultTour = null;
            var executionTime = Task<int>.Factory.StartNew(() =>
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                resultTour = method.DoOptimisation(tourToOptimise);
                sw.Stop();
                return sw.Elapsed.Milliseconds;
            }).Result;

            return new MeasurementItem { Method = displayMethodName, TimeElapsed = executionTime, ResultTour = resultTour };
        }

        private void FillResultsTable(MeasurementManager mng)
        {
            dgvResults.DataSource = null;
            dgvResults.DataSource = new BindingList<MeasurementItem>(mng.Items);
        }

        private void ClearCharts()
        {
            nnSerie.Points.Clear();
            srTwoOpt.Points.Clear();
            srTwoHalfOpt.Points.Clear();
            srThreeOpt.Points.Clear();
            srOrOpt.Points.Clear();

            tcMCharts.TabPages.Clear();
        }

        private void tcMCharts_SelectedIndexChanged(object sender, EventArgs e)
        {
            crtResult.Series.Clear();

            if (tcMCharts.SelectedTab == tpTwoOpt)
            {
                crtResult.Series.Add(srTwoOpt);
                FillExecutionSteps(twoOptSolver.ExecutionProcess);
            }
            else if (tcMCharts.SelectedTab == tpTwoHalfOpt)
            {
                crtResult.Series.Add(srTwoHalfOpt);
                FillExecutionSteps(twoHalfOptSolver.ExecutionProcess);
            }
            else if (tcMCharts.SelectedTab == tpThreeOpt)
            {
                crtResult.Series.Add(srThreeOpt);
                FillExecutionSteps(threeOptSolver.ExecutionProcess);
            }
            else if (tcMCharts.SelectedTab == tpOrOpt)
            {
                crtResult.Series.Add(srOrOpt);
                FillExecutionSteps(orOptSolver.ExecutionProcess);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var selectedFile = openFileDialog.FileName;
                var deserializedTour = DataLoader.GetDataFromFile(selectedFile);

                var nn = new NN();
                nnTour = nn.GetTour(deserializedTour.Path);
                nnTour.TSPName = deserializedTour.TSPName;
                nnTour.BestKnownSolution = deserializedTour.BestKnownSolution;
                tbInitialLength.Text = nnTour.GetCost().ToString();

                foreach (var item in nnTour.Path) nnSerie.Points.Add(new DataPoint(item.X, item.Y) { Label = item.Name });
                nnSerie.Points.Add(new DataPoint(nnTour.Path[0].X, nnTour.Path[0].Y));
                crtNN.Series.Clear();
                crtNN.Series.Add(nnSerie);

                tbTSPName.Text = nnTour.TSPName;
                tbBestSolution.Text = nnTour.BestKnownSolution.ToString();
                tbProblemSize.Text = nnTour.Size.ToString();
                btnExecute.Enabled = true;
                tcMCharts.Enabled = true;
            }
        }

        private void FillCommonResults()
        {
            dgvCommonResults.Rows.Clear();
            AddCommonResult("2-Opt");
            AddCommonResult("2.5-Opt");
            AddCommonResult("3-Opt");
            AddCommonResult("Or-Opt");
        }

        private void AddCommonResult(string methodName)
        {
            var methodMeasurementsCount = mng.Items.Where(i => i.Method == methodName).Count();

            if (methodMeasurementsCount > 0)
            {
                var rowTwoOptIdx = dgvCommonResults.Rows.Add();
                dgvCommonResults.Rows[rowTwoOptIdx].Cells["cAlgoName"].Value = methodName;
                dgvCommonResults.Rows[rowTwoOptIdx].Cells["сMCount"].Value = methodMeasurementsCount;
                dgvCommonResults.Rows[rowTwoOptIdx].Cells["cMin"].Value = mng.Items.Where(i => i.Method == methodName).Min(i => i.TimeElapsed);
                dgvCommonResults.Rows[rowTwoOptIdx].Cells["cAvg"].Value = mng.Items.Where(i => i.Method == methodName).Average(i => i.TimeElapsed).ToString("0.#");
                dgvCommonResults.Rows[rowTwoOptIdx].Cells["cMax"].Value = mng.Items.Where(i => i.Method == methodName).Max(i => i.TimeElapsed);
                dgvCommonResults.Rows[rowTwoOptIdx].Cells["cError"].Value = mng.Items.Where(i => i.Method == methodName).LastOrDefault()?.Loss + "%";
            }
        }

        private void FillExecutionSteps(ExecutionProcess process)
        {
            if (cbxLogging.Checked)
            {
                rtbExecutionSteps.Clear();

                var moves = process.Steps.Where(s => s.Type == ExecutionProcess.StepType.Move);
                foreach (var step in moves)
                {
                    rtbExecutionSteps.AppendText($"{step.Time}: {step.Text}\n", step.Color);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            mng.Items.Clear();
            FillResultsTable(mng);
            FillCommonResults();
        }
    }
}
