using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM_TSP
{
    class MeasurementManager
    {
        public List<MeasurementItem> Items { get; set; } = new List<MeasurementItem>();
    }

    class MeasurementItem : ICloneable
    {
        [DisplayName("Метод оптимізації")]
        public string Method { get; set; }
        [DisplayName("Проблема")]
        public string TSPProblem { get { return ResultTour.TSPName; } }

        [DisplayName("К-сть міст")]
        public int Size { get { return ResultTour.Size; } }

        [DisplayName("Відоме рішення")]
        public double BestKnownSolution { get { return ResultTour.BestKnownSolution; } }
        [Browsable(false)]
        public Tour ResultTour { get; set; }
        public double Distance { get { return ResultTour.GetCost(); } }
        [DisplayName("Час (ms)")]
        public int TimeElapsed { get; set; }

        [DisplayName("Похибка (%)")]
        public string Loss { get {return ((ResultTour.GetCost() / BestKnownSolution) * (double)100 - 100).ToString("0.00"); } }

        public object Clone()
        {
            return new MeasurementItem() { Method = this.Method, ResultTour = (Tour)this.ResultTour.Clone(), TimeElapsed = this.TimeElapsed };
        }
    }
}
