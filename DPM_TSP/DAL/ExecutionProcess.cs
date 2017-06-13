using System;
using System.Collections.Generic;
using System.Drawing;

namespace DPM_TSP
{
    public class ExecutionProcess
    {
        public enum StepType { CalculateGain, Move };
        public List<ExecutionStep> Steps { get; set; }

        public ExecutionStep this[int id]
        {
            get { return Steps[id]; }
            set { Steps[id] = value; }
        }

        public ExecutionProcess()
        {
            Steps = new List<ExecutionStep>();
        }

        public void AddStep(string text, Color color, StepType stepType)
        {
            Steps.Add(new ExecutionStep() { Text = text, Color = color, Type = stepType });
        }

        public void AddStep(string text, StepType stepType)
        {
            Steps.Add(new ExecutionStep() { Text = text, Color = Color.Black, Type = stepType });
        }

        public class ExecutionStep
        {
            public StepType Type { get; set; }
            public DateTime Time { get; set; }
            public string Text { get; set; }
            public Color Color { get; set; }

            public ExecutionStep()
            {
                Time = DateTime.Now;
            }
        }
    }
}
