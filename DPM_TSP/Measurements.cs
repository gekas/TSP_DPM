using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DPM_TSP
{
    public class MeasurementManager
    {
        public List<MeasurementItem> Items { get; set; } = new List<MeasurementItem>();
    }

    [Serializable]
    public class MeasurementItem : ICloneable
    {
        [DisplayName("Метод оптимізації")]
        public string Method { get; set; }

        [DisplayName("Проблема")]
        public string TSPProblem { get; set; }

        [DisplayName("К-сть міст")]
        public int Size { get; set; }

        [DisplayName("Відоме рішення")]
        public double BestKnownSolution { get; set; }

        public double Distance { get; set; }

        [DisplayName("Час (ms)")]
        public double TimeElapsed { get; set; }

        [DisplayName("Похибка (%)")]
        public string Loss { get; set; }

        [XmlIgnore]
        [Browsable(false)]
        public Tour ResultTour { get { return tour; } set { FillResults(value); } }

        private Tour tour;

        private void FillResults(Tour newTour)
        {
            tour = newTour;
            TSPProblem = tour.TSPName;
            Size = tour.Size;
            BestKnownSolution = tour.BestKnownSolution;
            Distance = tour.GetCost();
            Loss = ((tour.GetCost() / BestKnownSolution) * (double)100 - 100).ToString("0.00");
        }

        public object Clone()
        {
            return new MeasurementItem() { Method = this.Method, ResultTour = (Tour)this.ResultTour.Clone(), TimeElapsed = this.TimeElapsed };
        }
    }
}
