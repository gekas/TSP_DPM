using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public double Loss { get; set; }

        [Browsable(false)]
        [XmlAttribute]
        public int HashCode { get; set; }

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
            Loss = (tour.GetCost() / BestKnownSolution) * (double)100 - 100;
            HashCode = GetHashCode();
        }

        public override int GetHashCode()
        {
            return Method.GetHashCode() + TSPProblem.GetHashCode() + Size + BestKnownSolution.GetHashCode()
                    + Distance.GetHashCode() + TimeElapsed.GetHashCode() + Loss.GetHashCode();
        }

        public object Clone()
        {
            return new MeasurementItem() { Method = this.Method, ResultTour = (Tour)this.ResultTour.Clone(), TimeElapsed = this.TimeElapsed };
        }
    }

    public class MeasurementItemBySizeComparer : IComparer<MeasurementItem>
    {
        public int Compare(MeasurementItem x, MeasurementItem y)
        {
            return x.Size.CompareTo(y.Size);
        }
    }
}
