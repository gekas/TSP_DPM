namespace DPM_TSP
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.crtNN = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tcMCharts = new System.Windows.Forms.TabControl();
            this.tpTwoOpt = new System.Windows.Forms.TabPage();
            this.tpTwoHalfOpt = new System.Windows.Forms.TabPage();
            this.tpThreeOpt = new System.Windows.Forms.TabPage();
            this.tpOrOpt = new System.Windows.Forms.TabPage();
            this.crtResult = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbProblemSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nudRepeats = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBestSolution = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTSPName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tbInitialLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.gbMethods = new System.Windows.Forms.GroupBox();
            this.cbxOrOpt = new System.Windows.Forms.CheckBox();
            this.cbxThreeOpt = new System.Windows.Forms.CheckBox();
            this.cbxTwoHalfOpt = new System.Windows.Forms.CheckBox();
            this.cbxTwoOpt = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvCommonResults = new System.Windows.Forms.DataGridView();
            this.cAlgoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сMCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAvg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbExecutionSteps = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxLogging = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.crtNN)).BeginInit();
            this.tcMCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtResult)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeats)).BeginInit();
            this.gbMethods.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommonResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // crtNN
            // 
            this.crtNN.BackColor = System.Drawing.Color.Silver;
            this.crtNN.BorderlineColor = System.Drawing.Color.Gray;
            this.crtNN.BorderSkin.BorderColor = System.Drawing.Color.Gray;
            chartArea3.Name = "ChartArea1";
            this.crtNN.ChartAreas.Add(chartArea3);
            this.crtNN.Location = new System.Drawing.Point(278, 34);
            this.crtNN.Name = "crtNN";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.EmptyPointStyle.BorderWidth = 5;
            series3.Name = "NN";
            this.crtNN.Series.Add(series3);
            this.crtNN.Size = new System.Drawing.Size(767, 676);
            this.crtNN.TabIndex = 0;
            this.crtNN.Text = "crtNN";
            // 
            // tcMCharts
            // 
            this.tcMCharts.Controls.Add(this.tpTwoOpt);
            this.tcMCharts.Controls.Add(this.tpTwoHalfOpt);
            this.tcMCharts.Controls.Add(this.tpThreeOpt);
            this.tcMCharts.Controls.Add(this.tpOrOpt);
            this.tcMCharts.Enabled = false;
            this.tcMCharts.Location = new System.Drawing.Point(1047, 12);
            this.tcMCharts.Name = "tcMCharts";
            this.tcMCharts.SelectedIndex = 0;
            this.tcMCharts.Size = new System.Drawing.Size(864, 24);
            this.tcMCharts.TabIndex = 1;
            this.tcMCharts.SelectedIndexChanged += new System.EventHandler(this.tcMCharts_SelectedIndexChanged);
            // 
            // tpTwoOpt
            // 
            this.tpTwoOpt.Location = new System.Drawing.Point(4, 22);
            this.tpTwoOpt.Name = "tpTwoOpt";
            this.tpTwoOpt.Padding = new System.Windows.Forms.Padding(3);
            this.tpTwoOpt.Size = new System.Drawing.Size(856, 0);
            this.tpTwoOpt.TabIndex = 0;
            this.tpTwoOpt.Text = "2-Opt";
            this.tpTwoOpt.UseVisualStyleBackColor = true;
            // 
            // tpTwoHalfOpt
            // 
            this.tpTwoHalfOpt.Location = new System.Drawing.Point(4, 22);
            this.tpTwoHalfOpt.Name = "tpTwoHalfOpt";
            this.tpTwoHalfOpt.Padding = new System.Windows.Forms.Padding(3);
            this.tpTwoHalfOpt.Size = new System.Drawing.Size(856, 0);
            this.tpTwoHalfOpt.TabIndex = 1;
            this.tpTwoHalfOpt.Text = "2.5-Opt";
            this.tpTwoHalfOpt.UseVisualStyleBackColor = true;
            // 
            // tpThreeOpt
            // 
            this.tpThreeOpt.Location = new System.Drawing.Point(4, 22);
            this.tpThreeOpt.Name = "tpThreeOpt";
            this.tpThreeOpt.Size = new System.Drawing.Size(856, 0);
            this.tpThreeOpt.TabIndex = 2;
            this.tpThreeOpt.Text = "3-Opt";
            this.tpThreeOpt.UseVisualStyleBackColor = true;
            // 
            // tpOrOpt
            // 
            this.tpOrOpt.Location = new System.Drawing.Point(4, 22);
            this.tpOrOpt.Name = "tpOrOpt";
            this.tpOrOpt.Size = new System.Drawing.Size(856, 0);
            this.tpOrOpt.TabIndex = 3;
            this.tpOrOpt.Text = "Or-Opt";
            this.tpOrOpt.UseVisualStyleBackColor = true;
            // 
            // crtResult
            // 
            this.crtResult.BackColor = System.Drawing.Color.Silver;
            chartArea4.Name = "ChartArea1";
            this.crtResult.ChartAreas.Add(chartArea4);
            this.crtResult.Location = new System.Drawing.Point(1051, 34);
            this.crtResult.Name = "crtResult";
            series4.ChartArea = "ChartArea1";
            series4.Name = "Series1";
            this.crtResult.Series.Add(series4);
            this.crtResult.Size = new System.Drawing.Size(856, 676);
            this.crtResult.TabIndex = 5;
            this.crtResult.Text = "crtSolution";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbProblemSize);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.nudRepeats);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbBestSolution);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbTSPName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.tbInitialLength);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExecute);
            this.panel1.Controls.Add(this.gbMethods);
            this.panel1.Location = new System.Drawing.Point(12, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 340);
            this.panel1.TabIndex = 21;
            // 
            // tbProblemSize
            // 
            this.tbProblemSize.Location = new System.Drawing.Point(110, 66);
            this.tbProblemSize.Name = "tbProblemSize";
            this.tbProblemSize.ReadOnly = true;
            this.tbProblemSize.Size = new System.Drawing.Size(100, 20);
            this.tbProblemSize.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Розмір проблеми";
            // 
            // nudRepeats
            // 
            this.nudRepeats.Location = new System.Drawing.Point(110, 281);
            this.nudRepeats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRepeats.Name = "nudRepeats";
            this.nudRepeats.Size = new System.Drawing.Size(100, 20);
            this.nudRepeats.TabIndex = 29;
            this.nudRepeats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Кількість замірів";
            // 
            // tbBestSolution
            // 
            this.tbBestSolution.Location = new System.Drawing.Point(110, 90);
            this.tbBestSolution.Name = "tbBestSolution";
            this.tbBestSolution.ReadOnly = true;
            this.tbBestSolution.Size = new System.Drawing.Size(100, 20);
            this.tbBestSolution.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Відоме рішення";
            // 
            // tbTSPName
            // 
            this.tbTSPName.Location = new System.Drawing.Point(110, 42);
            this.tbTSPName.Name = "tbTSPName";
            this.tbTSPName.ReadOnly = true;
            this.tbTSPName.Size = new System.Drawing.Size(100, 20);
            this.tbTSPName.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Назва проблеми";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(8, 7);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(89, 23);
            this.btnLoad.TabIndex = 23;
            this.btnLoad.Text = "Завантажити";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tbInitialLength
            // 
            this.tbInitialLength.Location = new System.Drawing.Point(12, 142);
            this.tbInitialLength.Name = "tbInitialLength";
            this.tbInitialLength.ReadOnly = true;
            this.tbInitialLength.Size = new System.Drawing.Size(100, 20);
            this.tbInitialLength.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Довжина за методом найближчого сусіда";
            // 
            // btnExecute
            // 
            this.btnExecute.Enabled = false;
            this.btnExecute.Location = new System.Drawing.Point(12, 310);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(88, 23);
            this.btnExecute.TabIndex = 20;
            this.btnExecute.Text = "Оптимізувати";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // gbMethods
            // 
            this.gbMethods.Controls.Add(this.cbxOrOpt);
            this.gbMethods.Controls.Add(this.cbxThreeOpt);
            this.gbMethods.Controls.Add(this.cbxTwoHalfOpt);
            this.gbMethods.Controls.Add(this.cbxTwoOpt);
            this.gbMethods.Location = new System.Drawing.Point(11, 169);
            this.gbMethods.Name = "gbMethods";
            this.gbMethods.Size = new System.Drawing.Size(137, 100);
            this.gbMethods.TabIndex = 19;
            this.gbMethods.TabStop = false;
            this.gbMethods.Text = "Методи";
            // 
            // cbxOrOpt
            // 
            this.cbxOrOpt.AutoSize = true;
            this.cbxOrOpt.Location = new System.Drawing.Point(7, 72);
            this.cbxOrOpt.Name = "cbxOrOpt";
            this.cbxOrOpt.Size = new System.Drawing.Size(57, 17);
            this.cbxOrOpt.TabIndex = 3;
            this.cbxOrOpt.Text = "Or-Opt";
            this.cbxOrOpt.UseVisualStyleBackColor = true;
            // 
            // cbxThreeOpt
            // 
            this.cbxThreeOpt.AutoSize = true;
            this.cbxThreeOpt.Location = new System.Drawing.Point(7, 55);
            this.cbxThreeOpt.Name = "cbxThreeOpt";
            this.cbxThreeOpt.Size = new System.Drawing.Size(52, 17);
            this.cbxThreeOpt.TabIndex = 2;
            this.cbxThreeOpt.Text = "3-Opt";
            this.cbxThreeOpt.UseVisualStyleBackColor = true;
            // 
            // cbxTwoHalfOpt
            // 
            this.cbxTwoHalfOpt.AutoSize = true;
            this.cbxTwoHalfOpt.Location = new System.Drawing.Point(7, 37);
            this.cbxTwoHalfOpt.Name = "cbxTwoHalfOpt";
            this.cbxTwoHalfOpt.Size = new System.Drawing.Size(61, 17);
            this.cbxTwoHalfOpt.TabIndex = 1;
            this.cbxTwoHalfOpt.Text = "2.5-Opt";
            this.cbxTwoHalfOpt.UseVisualStyleBackColor = true;
            // 
            // cbxTwoOpt
            // 
            this.cbxTwoOpt.AutoSize = true;
            this.cbxTwoOpt.Location = new System.Drawing.Point(7, 20);
            this.cbxTwoOpt.Name = "cbxTwoOpt";
            this.cbxTwoOpt.Size = new System.Drawing.Size(52, 17);
            this.cbxTwoOpt.TabIndex = 0;
            this.cbxTwoOpt.Text = "2-Opt";
            this.cbxTwoOpt.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.dgvCommonResults);
            this.groupBox1.Controls.Add(this.dgvResults);
            this.groupBox1.Location = new System.Drawing.Point(12, 719);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1131, 276);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Результати";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(13, 31);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Відчистити";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dgvCommonResults
            // 
            this.dgvCommonResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommonResults.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCommonResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommonResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cAlgoName,
            this.сMCount,
            this.cMin,
            this.cAvg,
            this.cMax,
            this.cError});
            this.dgvCommonResults.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCommonResults.Location = new System.Drawing.Point(13, 62);
            this.dgvCommonResults.Name = "dgvCommonResults";
            this.dgvCommonResults.ReadOnly = true;
            this.dgvCommonResults.RowHeadersVisible = false;
            this.dgvCommonResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommonResults.Size = new System.Drawing.Size(446, 202);
            this.dgvCommonResults.TabIndex = 21;
            // 
            // cAlgoName
            // 
            this.cAlgoName.HeaderText = "Алгоритм";
            this.cAlgoName.Name = "cAlgoName";
            this.cAlgoName.ReadOnly = true;
            // 
            // сMCount
            // 
            this.сMCount.HeaderText = "Кількість замірів";
            this.сMCount.Name = "сMCount";
            this.сMCount.ReadOnly = true;
            // 
            // cMin
            // 
            this.cMin.HeaderText = "Мінімум (мс)";
            this.cMin.Name = "cMin";
            this.cMin.ReadOnly = true;
            // 
            // cAvg
            // 
            this.cAvg.HeaderText = "Середнє (мс)";
            this.cAvg.Name = "cAvg";
            this.cAvg.ReadOnly = true;
            // 
            // cMax
            // 
            this.cMax.HeaderText = "Максимум (мс)";
            this.cMax.Name = "cMax";
            this.cMax.ReadOnly = true;
            // 
            // cError
            // 
            this.cError.HeaderText = "Похибка (%)";
            this.cError.Name = "cError";
            this.cError.ReadOnly = true;
            // 
            // dgvResults
            // 
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.GridColor = System.Drawing.SystemColors.Control;
            this.dgvResults.Location = new System.Drawing.Point(480, 62);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(639, 202);
            this.dgvResults.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxLogging);
            this.groupBox2.Controls.Add(this.rtbExecutionSteps);
            this.groupBox2.Location = new System.Drawing.Point(1162, 719);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(745, 276);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Логування";
            // 
            // rtbExecutionSteps
            // 
            this.rtbExecutionSteps.Location = new System.Drawing.Point(14, 62);
            this.rtbExecutionSteps.Name = "rtbExecutionSteps";
            this.rtbExecutionSteps.Size = new System.Drawing.Size(719, 202);
            this.rtbExecutionSteps.TabIndex = 21;
            this.rtbExecutionSteps.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Location = new System.Drawing.Point(12, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 369);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Навігація";
            // 
            // cbxLogging
            // 
            this.cbxLogging.AutoSize = true;
            this.cbxLogging.Location = new System.Drawing.Point(14, 31);
            this.cbxLogging.Name = "cbxLogging";
            this.cbxLogging.Size = new System.Drawing.Size(73, 17);
            this.cbxLogging.TabIndex = 22;
            this.cbxLogging.Text = "Логувати";
            this.cbxLogging.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1011);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crtResult);
            this.Controls.Add(this.tcMCharts);
            this.Controls.Add(this.crtNN);
            this.Name = "MainForm";
            this.Text = "STSP - solver";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.crtNN)).EndInit();
            this.tcMCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.crtResult)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRepeats)).EndInit();
            this.gbMethods.ResumeLayout(false);
            this.gbMethods.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommonResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtNN;
        private System.Windows.Forms.TabControl tcMCharts;
        private System.Windows.Forms.TabPage tpTwoOpt;
        private System.Windows.Forms.TabPage tpTwoHalfOpt;
        private System.Windows.Forms.TabPage tpThreeOpt;
        private System.Windows.Forms.TabPage tpOrOpt;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtResult;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbProblemSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudRepeats;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbBestSolution;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTSPName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox tbInitialLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.GroupBox gbMethods;
        private System.Windows.Forms.CheckBox cbxOrOpt;
        private System.Windows.Forms.CheckBox cbxThreeOpt;
        private System.Windows.Forms.CheckBox cbxTwoHalfOpt;
        private System.Windows.Forms.CheckBox cbxTwoOpt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvCommonResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAlgoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn сMCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAvg;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn cError;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbExecutionSteps;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbxLogging;
    }
}

