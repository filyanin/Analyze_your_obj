
namespace Analyse_your_obj
{
    partial class OBJ_Analyser
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Accuracy = new System.Windows.Forms.GroupBox();
            this.VerticalAccuracyLabel = new System.Windows.Forms.Label();
            this.HorizontalAccuracyLabel = new System.Windows.Forms.Label();
            this.StartSearchHorizontalAndVerticalButton = new System.Windows.Forms.Button();
            this.DeletingGroup = new System.Windows.Forms.GroupBox();
            this.ExtremeDeletingRadioButton = new System.Windows.Forms.RadioButton();
            this.CountOfDeletingCiclesLabel = new System.Windows.Forms.Label();
            this.StartDeletingButton = new System.Windows.Forms.Button();
            this.DeepDeletingRadioButton = new System.Windows.Forms.RadioButton();
            this.LiteDeletingRadioButton = new System.Windows.Forms.RadioButton();
            this.AddingGroup = new System.Windows.Forms.GroupBox();
            this.VerticalTrianglesAddingLabel = new System.Windows.Forms.Label();
            this.HorizontalAddingLabel = new System.Windows.Forms.Label();
            this.VerticalCountOfAddingLabel = new System.Windows.Forms.Label();
            this.VerticalAccuracyAddingLabel = new System.Windows.Forms.Label();
            this.HorizontalAccuracyAddingLabel = new System.Windows.Forms.Label();
            this.HorizontalCountOfAddingLabel = new System.Windows.Forms.Label();
            this.StartAddingButton = new System.Windows.Forms.Button();
            this.open_file = new System.Windows.Forms.Button();
            this.information = new System.Windows.Forms.GroupBox();
            this.CountOfOtherTrianglesLabels = new System.Windows.Forms.Label();
            this.CountOfHorizontalTrianglesLabel = new System.Windows.Forms.Label();
            this.CountOfVerticalTrianglesLabel = new System.Windows.Forms.Label();
            this.CountOfTrianglesLabel = new System.Windows.Forms.Label();
            this.CountOfNormalLabel = new System.Windows.Forms.Label();
            this.CountOfPointLabel = new System.Windows.Forms.Label();
            this.SearchAndSaveSurfacesButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ProcessTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.HorizontalSearchAccuracyBox = new System.Windows.Forms.TextBox();
            this.VerticalSearchAccuracyBox = new System.Windows.Forms.TextBox();
            this.IgnoreNumberBox = new System.Windows.Forms.TextBox();
            this.CountOfDeletingCiclesBox = new System.Windows.Forms.TextBox();
            this.CountOfHorizontalAddingCiclesBox = new System.Windows.Forms.TextBox();
            this.HorizontalAccuracyAddingBox = new System.Windows.Forms.TextBox();
            this.VerticalAccuracyAddingBox = new System.Windows.Forms.TextBox();
            this.CountVerticalAddingBox = new System.Windows.Forms.TextBox();
            this.Accuracy.SuspendLayout();
            this.DeletingGroup.SuspendLayout();
            this.AddingGroup.SuspendLayout();
            this.information.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Accuracy
            // 
            this.Accuracy.Controls.Add(this.VerticalSearchAccuracyBox);
            this.Accuracy.Controls.Add(this.HorizontalSearchAccuracyBox);
            this.Accuracy.Controls.Add(this.VerticalAccuracyLabel);
            this.Accuracy.Controls.Add(this.HorizontalAccuracyLabel);
            this.Accuracy.Controls.Add(this.StartSearchHorizontalAndVerticalButton);
            this.Accuracy.Location = new System.Drawing.Point(12, 125);
            this.Accuracy.Name = "Accuracy";
            this.Accuracy.Size = new System.Drawing.Size(284, 197);
            this.Accuracy.TabIndex = 0;
            this.Accuracy.TabStop = false;
            this.Accuracy.Text = "Поиск поверхностей";
            // 
            // VerticalAccuracyLabel
            // 
            this.VerticalAccuracyLabel.AutoSize = true;
            this.VerticalAccuracyLabel.Location = new System.Drawing.Point(16, 89);
            this.VerticalAccuracyLabel.Name = "VerticalAccuracyLabel";
            this.VerticalAccuracyLabel.Size = new System.Drawing.Size(204, 13);
            this.VerticalAccuracyLabel.TabIndex = 12;
            this.VerticalAccuracyLabel.Text = "Вертикальная пороговая погрешность";
            // 
            // HorizontalAccuracyLabel
            // 
            this.HorizontalAccuracyLabel.AutoSize = true;
            this.HorizontalAccuracyLabel.Location = new System.Drawing.Point(16, 22);
            this.HorizontalAccuracyLabel.Name = "HorizontalAccuracyLabel";
            this.HorizontalAccuracyLabel.Size = new System.Drawing.Size(215, 13);
            this.HorizontalAccuracyLabel.TabIndex = 11;
            this.HorizontalAccuracyLabel.Text = "Горизонтальная пороговая погрешность";
            // 
            // StartSearchHorizontalAndVerticalButton
            // 
            this.StartSearchHorizontalAndVerticalButton.Location = new System.Drawing.Point(16, 168);
            this.StartSearchHorizontalAndVerticalButton.Name = "StartSearchHorizontalAndVerticalButton";
            this.StartSearchHorizontalAndVerticalButton.Size = new System.Drawing.Size(204, 23);
            this.StartSearchHorizontalAndVerticalButton.TabIndex = 10;
            this.StartSearchHorizontalAndVerticalButton.Text = "Начать поиск";
            this.StartSearchHorizontalAndVerticalButton.UseVisualStyleBackColor = true;
            // 
            // DeletingGroup
            // 
            this.DeletingGroup.Controls.Add(this.CountOfDeletingCiclesBox);
            this.DeletingGroup.Controls.Add(this.ExtremeDeletingRadioButton);
            this.DeletingGroup.Controls.Add(this.CountOfDeletingCiclesLabel);
            this.DeletingGroup.Controls.Add(this.StartDeletingButton);
            this.DeletingGroup.Controls.Add(this.DeepDeletingRadioButton);
            this.DeletingGroup.Controls.Add(this.LiteDeletingRadioButton);
            this.DeletingGroup.Location = new System.Drawing.Point(637, 125);
            this.DeletingGroup.Name = "DeletingGroup";
            this.DeletingGroup.Size = new System.Drawing.Size(335, 162);
            this.DeletingGroup.TabIndex = 1;
            this.DeletingGroup.TabStop = false;
            this.DeletingGroup.Text = "Удаление";
            // 
            // ExtremeDeletingRadioButton
            // 
            this.ExtremeDeletingRadioButton.AutoSize = true;
            this.ExtremeDeletingRadioButton.Location = new System.Drawing.Point(192, 22);
            this.ExtremeDeletingRadioButton.Name = "ExtremeDeletingRadioButton";
            this.ExtremeDeletingRadioButton.Size = new System.Drawing.Size(105, 17);
            this.ExtremeDeletingRadioButton.TabIndex = 11;
            this.ExtremeDeletingRadioButton.Text = "Экстримальное";
            this.ExtremeDeletingRadioButton.UseVisualStyleBackColor = true;
            // 
            // CountOfDeletingCiclesLabel
            // 
            this.CountOfDeletingCiclesLabel.AutoSize = true;
            this.CountOfDeletingCiclesLabel.Location = new System.Drawing.Point(7, 51);
            this.CountOfDeletingCiclesLabel.Name = "CountOfDeletingCiclesLabel";
            this.CountOfDeletingCiclesLabel.Size = new System.Drawing.Size(155, 13);
            this.CountOfDeletingCiclesLabel.TabIndex = 10;
            this.CountOfDeletingCiclesLabel.Text = "Количество циклов удаления";
            // 
            // StartDeletingButton
            // 
            this.StartDeletingButton.Location = new System.Drawing.Point(29, 130);
            this.StartDeletingButton.Name = "StartDeletingButton";
            this.StartDeletingButton.Size = new System.Drawing.Size(253, 23);
            this.StartDeletingButton.TabIndex = 9;
            this.StartDeletingButton.Text = "Начать удаление";
            this.StartDeletingButton.UseVisualStyleBackColor = true;
            // 
            // DeepDeletingRadioButton
            // 
            this.DeepDeletingRadioButton.AutoSize = true;
            this.DeepDeletingRadioButton.Location = new System.Drawing.Point(115, 22);
            this.DeepDeletingRadioButton.Name = "DeepDeletingRadioButton";
            this.DeepDeletingRadioButton.Size = new System.Drawing.Size(72, 17);
            this.DeepDeletingRadioButton.TabIndex = 1;
            this.DeepDeletingRadioButton.Text = "Глубокое";
            this.DeepDeletingRadioButton.UseVisualStyleBackColor = true;
            // 
            // LiteDeletingRadioButton
            // 
            this.LiteDeletingRadioButton.AutoSize = true;
            this.LiteDeletingRadioButton.Checked = true;
            this.LiteDeletingRadioButton.Location = new System.Drawing.Point(6, 22);
            this.LiteDeletingRadioButton.Name = "LiteDeletingRadioButton";
            this.LiteDeletingRadioButton.Size = new System.Drawing.Size(103, 17);
            this.LiteDeletingRadioButton.TabIndex = 0;
            this.LiteDeletingRadioButton.TabStop = true;
            this.LiteDeletingRadioButton.Text = "Поверхностное";
            this.LiteDeletingRadioButton.UseVisualStyleBackColor = true;
            this.LiteDeletingRadioButton.CheckedChanged += new System.EventHandler(this.LiteDeletingRadioButton_CheckedChanged);
            // 
            // AddingGroup
            // 
            this.AddingGroup.Controls.Add(this.CountVerticalAddingBox);
            this.AddingGroup.Controls.Add(this.VerticalAccuracyAddingBox);
            this.AddingGroup.Controls.Add(this.HorizontalAccuracyAddingBox);
            this.AddingGroup.Controls.Add(this.CountOfHorizontalAddingCiclesBox);
            this.AddingGroup.Controls.Add(this.VerticalTrianglesAddingLabel);
            this.AddingGroup.Controls.Add(this.HorizontalAddingLabel);
            this.AddingGroup.Controls.Add(this.VerticalCountOfAddingLabel);
            this.AddingGroup.Controls.Add(this.VerticalAccuracyAddingLabel);
            this.AddingGroup.Controls.Add(this.HorizontalAccuracyAddingLabel);
            this.AddingGroup.Controls.Add(this.HorizontalCountOfAddingLabel);
            this.AddingGroup.Controls.Add(this.StartAddingButton);
            this.AddingGroup.Location = new System.Drawing.Point(637, 293);
            this.AddingGroup.Name = "AddingGroup";
            this.AddingGroup.Size = new System.Drawing.Size(335, 245);
            this.AddingGroup.TabIndex = 2;
            this.AddingGroup.TabStop = false;
            this.AddingGroup.Text = "Добавление";
            // 
            // VerticalTrianglesAddingLabel
            // 
            this.VerticalTrianglesAddingLabel.AutoSize = true;
            this.VerticalTrianglesAddingLabel.Location = new System.Drawing.Point(7, 114);
            this.VerticalTrianglesAddingLabel.Name = "VerticalTrianglesAddingLabel";
            this.VerticalTrianglesAddingLabel.Size = new System.Drawing.Size(153, 13);
            this.VerticalTrianglesAddingLabel.TabIndex = 16;
            this.VerticalTrianglesAddingLabel.Text = "Вертикальные треугольники";
            // 
            // HorizontalAddingLabel
            // 
            this.HorizontalAddingLabel.AutoSize = true;
            this.HorizontalAddingLabel.Location = new System.Drawing.Point(7, 16);
            this.HorizontalAddingLabel.Name = "HorizontalAddingLabel";
            this.HorizontalAddingLabel.Size = new System.Drawing.Size(164, 13);
            this.HorizontalAddingLabel.TabIndex = 15;
            this.HorizontalAddingLabel.Text = "Горизонтальные треугольники";
            // 
            // VerticalCountOfAddingLabel
            // 
            this.VerticalCountOfAddingLabel.AutoSize = true;
            this.VerticalCountOfAddingLabel.Location = new System.Drawing.Point(7, 130);
            this.VerticalCountOfAddingLabel.Name = "VerticalCountOfAddingLabel";
            this.VerticalCountOfAddingLabel.Size = new System.Drawing.Size(116, 13);
            this.VerticalCountOfAddingLabel.TabIndex = 14;
            this.VerticalCountOfAddingLabel.Text = "Количество проходов";
            // 
            // VerticalAccuracyAddingLabel
            // 
            this.VerticalAccuracyAddingLabel.AutoSize = true;
            this.VerticalAccuracyAddingLabel.Location = new System.Drawing.Point(163, 130);
            this.VerticalAccuracyAddingLabel.Name = "VerticalAccuracyAddingLabel";
            this.VerticalAccuracyAddingLabel.Size = new System.Drawing.Size(110, 13);
            this.VerticalAccuracyAddingLabel.TabIndex = 13;
            this.VerticalAccuracyAddingLabel.Text = "Пороговая точность";
            this.VerticalAccuracyAddingLabel.Click += new System.EventHandler(this.VerticalAccuracyAddingLabel_Click);
            // 
            // HorizontalAccuracyAddingLabel
            // 
            this.HorizontalAccuracyAddingLabel.AutoSize = true;
            this.HorizontalAccuracyAddingLabel.Location = new System.Drawing.Point(163, 40);
            this.HorizontalAccuracyAddingLabel.Name = "HorizontalAccuracyAddingLabel";
            this.HorizontalAccuracyAddingLabel.Size = new System.Drawing.Size(110, 13);
            this.HorizontalAccuracyAddingLabel.TabIndex = 12;
            this.HorizontalAccuracyAddingLabel.Text = "Пороговая точность";
            this.HorizontalAccuracyAddingLabel.Click += new System.EventHandler(this.HorizontalAccuracyAddingLabel_Click);
            // 
            // HorizontalCountOfAddingLabel
            // 
            this.HorizontalCountOfAddingLabel.AutoSize = true;
            this.HorizontalCountOfAddingLabel.Location = new System.Drawing.Point(7, 40);
            this.HorizontalCountOfAddingLabel.Name = "HorizontalCountOfAddingLabel";
            this.HorizontalCountOfAddingLabel.Size = new System.Drawing.Size(116, 13);
            this.HorizontalCountOfAddingLabel.TabIndex = 11;
            this.HorizontalCountOfAddingLabel.Text = "Количество проходов";
            // 
            // StartAddingButton
            // 
            this.StartAddingButton.Location = new System.Drawing.Point(29, 206);
            this.StartAddingButton.Name = "StartAddingButton";
            this.StartAddingButton.Size = new System.Drawing.Size(253, 23);
            this.StartAddingButton.TabIndex = 10;
            this.StartAddingButton.Text = "Начать восстановление текcтуры";
            this.StartAddingButton.UseVisualStyleBackColor = true;
            // 
            // open_file
            // 
            this.open_file.Location = new System.Drawing.Point(12, 12);
            this.open_file.Name = "open_file";
            this.open_file.Size = new System.Drawing.Size(960, 23);
            this.open_file.TabIndex = 3;
            this.open_file.Text = "Открыть файл";
            this.open_file.UseVisualStyleBackColor = true;
            // 
            // information
            // 
            this.information.Controls.Add(this.CountOfOtherTrianglesLabels);
            this.information.Controls.Add(this.CountOfHorizontalTrianglesLabel);
            this.information.Controls.Add(this.CountOfVerticalTrianglesLabel);
            this.information.Controls.Add(this.CountOfTrianglesLabel);
            this.information.Controls.Add(this.CountOfNormalLabel);
            this.information.Controls.Add(this.CountOfPointLabel);
            this.information.Location = new System.Drawing.Point(13, 41);
            this.information.Name = "information";
            this.information.Size = new System.Drawing.Size(959, 78);
            this.information.TabIndex = 4;
            this.information.TabStop = false;
            this.information.Text = "Информация о файле";
            // 
            // CountOfOtherTrianglesLabels
            // 
            this.CountOfOtherTrianglesLabels.AutoSize = true;
            this.CountOfOtherTrianglesLabels.Location = new System.Drawing.Point(672, 51);
            this.CountOfOtherTrianglesLabels.Name = "CountOfOtherTrianglesLabels";
            this.CountOfOtherTrianglesLabels.Size = new System.Drawing.Size(115, 13);
            this.CountOfOtherTrianglesLabels.TabIndex = 5;
            this.CountOfOtherTrianglesLabels.Text = "Иных треугольников:";
            // 
            // CountOfHorizontalTrianglesLabel
            // 
            this.CountOfHorizontalTrianglesLabel.AutoSize = true;
            this.CountOfHorizontalTrianglesLabel.Location = new System.Drawing.Point(18, 51);
            this.CountOfHorizontalTrianglesLabel.Name = "CountOfHorizontalTrianglesLabel";
            this.CountOfHorizontalTrianglesLabel.Size = new System.Drawing.Size(172, 13);
            this.CountOfHorizontalTrianglesLabel.TabIndex = 4;
            this.CountOfHorizontalTrianglesLabel.Text = "Горизонтальных треугольников:";
            // 
            // CountOfVerticalTrianglesLabel
            // 
            this.CountOfVerticalTrianglesLabel.AutoSize = true;
            this.CountOfVerticalTrianglesLabel.Location = new System.Drawing.Point(348, 51);
            this.CountOfVerticalTrianglesLabel.Name = "CountOfVerticalTrianglesLabel";
            this.CountOfVerticalTrianglesLabel.Size = new System.Drawing.Size(161, 13);
            this.CountOfVerticalTrianglesLabel.TabIndex = 3;
            this.CountOfVerticalTrianglesLabel.Text = "Вертикальных треугольников:";
            // 
            // CountOfTrianglesLabel
            // 
            this.CountOfTrianglesLabel.AutoSize = true;
            this.CountOfTrianglesLabel.Location = new System.Drawing.Point(672, 20);
            this.CountOfTrianglesLabel.Name = "CountOfTrianglesLabel";
            this.CountOfTrianglesLabel.Size = new System.Drawing.Size(147, 13);
            this.CountOfTrianglesLabel.TabIndex = 2;
            this.CountOfTrianglesLabel.Text = "Количество треугольников:";
            this.CountOfTrianglesLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // CountOfNormalLabel
            // 
            this.CountOfNormalLabel.AutoSize = true;
            this.CountOfNormalLabel.Location = new System.Drawing.Point(348, 20);
            this.CountOfNormalLabel.Name = "CountOfNormalLabel";
            this.CountOfNormalLabel.Size = new System.Drawing.Size(125, 13);
            this.CountOfNormalLabel.TabIndex = 1;
            this.CountOfNormalLabel.Text = "Количество нормалей: ";
            // 
            // CountOfPointLabel
            // 
            this.CountOfPointLabel.AutoSize = true;
            this.CountOfPointLabel.Location = new System.Drawing.Point(18, 20);
            this.CountOfPointLabel.Name = "CountOfPointLabel";
            this.CountOfPointLabel.Size = new System.Drawing.Size(103, 13);
            this.CountOfPointLabel.TabIndex = 0;
            this.CountOfPointLabel.Text = "Количество точек: ";
            // 
            // SearchAndSaveSurfacesButton
            // 
            this.SearchAndSaveSurfacesButton.Location = new System.Drawing.Point(16, 170);
            this.SearchAndSaveSurfacesButton.Name = "SearchAndSaveSurfacesButton";
            this.SearchAndSaveSurfacesButton.Size = new System.Drawing.Size(232, 24);
            this.SearchAndSaveSurfacesButton.TabIndex = 5;
            this.SearchAndSaveSurfacesButton.Text = "Выделить и сохранить поверхности";
            this.SearchAndSaveSurfacesButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // ProcessTextBox
            // 
            this.ProcessTextBox.Location = new System.Drawing.Point(302, 125);
            this.ProcessTextBox.Multiline = true;
            this.ProcessTextBox.Name = "ProcessTextBox";
            this.ProcessTextBox.ReadOnly = true;
            this.ProcessTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ProcessTextBox.Size = new System.Drawing.Size(329, 413);
            this.ProcessTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Уровень отсечения маленьких поверхностей";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IgnoreNumberBox);
            this.groupBox1.Controls.Add(this.SearchAndSaveSurfacesButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 210);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сохранение";
            // 
            // HorizontalSearchAccuracyBox
            // 
            this.HorizontalSearchAccuracyBox.Location = new System.Drawing.Point(74, 51);
            this.HorizontalSearchAccuracyBox.Name = "HorizontalSearchAccuracyBox";
            this.HorizontalSearchAccuracyBox.Size = new System.Drawing.Size(100, 20);
            this.HorizontalSearchAccuracyBox.TabIndex = 13;
            // 
            // VerticalSearchAccuracyBox
            // 
            this.VerticalSearchAccuracyBox.Location = new System.Drawing.Point(74, 132);
            this.VerticalSearchAccuracyBox.Name = "VerticalSearchAccuracyBox";
            this.VerticalSearchAccuracyBox.Size = new System.Drawing.Size(100, 20);
            this.VerticalSearchAccuracyBox.TabIndex = 14;
            // 
            // IgnoreNumberBox
            // 
            this.IgnoreNumberBox.Location = new System.Drawing.Point(74, 49);
            this.IgnoreNumberBox.Name = "IgnoreNumberBox";
            this.IgnoreNumberBox.Size = new System.Drawing.Size(100, 20);
            this.IgnoreNumberBox.TabIndex = 15;
            // 
            // CountOfDeletingCiclesBox
            // 
            this.CountOfDeletingCiclesBox.Location = new System.Drawing.Point(95, 86);
            this.CountOfDeletingCiclesBox.Name = "CountOfDeletingCiclesBox";
            this.CountOfDeletingCiclesBox.Size = new System.Drawing.Size(100, 20);
            this.CountOfDeletingCiclesBox.TabIndex = 14;
            // 
            // CountOfHorizontalAddingCiclesBox
            // 
            this.CountOfHorizontalAddingCiclesBox.Location = new System.Drawing.Point(10, 71);
            this.CountOfHorizontalAddingCiclesBox.Name = "CountOfHorizontalAddingCiclesBox";
            this.CountOfHorizontalAddingCiclesBox.Size = new System.Drawing.Size(100, 20);
            this.CountOfHorizontalAddingCiclesBox.TabIndex = 17;
            // 
            // HorizontalAccuracyAddingBox
            // 
            this.HorizontalAccuracyAddingBox.Location = new System.Drawing.Point(166, 71);
            this.HorizontalAccuracyAddingBox.Name = "HorizontalAccuracyAddingBox";
            this.HorizontalAccuracyAddingBox.Size = new System.Drawing.Size(100, 20);
            this.HorizontalAccuracyAddingBox.TabIndex = 18;
            // 
            // VerticalAccuracyAddingBox
            // 
            this.VerticalAccuracyAddingBox.Location = new System.Drawing.Point(166, 168);
            this.VerticalAccuracyAddingBox.Name = "VerticalAccuracyAddingBox";
            this.VerticalAccuracyAddingBox.Size = new System.Drawing.Size(100, 20);
            this.VerticalAccuracyAddingBox.TabIndex = 19;
            // 
            // CountVerticalAddingBox
            // 
            this.CountVerticalAddingBox.Location = new System.Drawing.Point(10, 168);
            this.CountVerticalAddingBox.Name = "CountVerticalAddingBox";
            this.CountVerticalAddingBox.Size = new System.Drawing.Size(100, 20);
            this.CountVerticalAddingBox.TabIndex = 20;
            // 
            // OBJ_Analyser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 550);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ProcessTextBox);
            this.Controls.Add(this.information);
            this.Controls.Add(this.open_file);
            this.Controls.Add(this.AddingGroup);
            this.Controls.Add(this.DeletingGroup);
            this.Controls.Add(this.Accuracy);
            this.Name = "OBJ_Analyser";
            this.Text = "OBJ_Analyzer";
            this.Load += new System.EventHandler(this.OBJ_Analyser_Load);
            this.Accuracy.ResumeLayout(false);
            this.Accuracy.PerformLayout();
            this.DeletingGroup.ResumeLayout(false);
            this.DeletingGroup.PerformLayout();
            this.AddingGroup.ResumeLayout(false);
            this.AddingGroup.PerformLayout();
            this.information.ResumeLayout(false);
            this.information.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Accuracy;
        private System.Windows.Forms.GroupBox DeletingGroup;
        private System.Windows.Forms.GroupBox AddingGroup;
        private System.Windows.Forms.Button open_file;
        private System.Windows.Forms.GroupBox information;
        private System.Windows.Forms.RadioButton LiteDeletingRadioButton;
        private System.Windows.Forms.RadioButton DeepDeletingRadioButton;
        private System.Windows.Forms.Button StartSearchHorizontalAndVerticalButton;
        private System.Windows.Forms.Label CountOfDeletingCiclesLabel;
        private System.Windows.Forms.Button StartDeletingButton;
        private System.Windows.Forms.Button StartAddingButton;
        private System.Windows.Forms.Label HorizontalAccuracyLabel;
        private System.Windows.Forms.Label VerticalAccuracyLabel;
        private System.Windows.Forms.Label HorizontalCountOfAddingLabel;
        private System.Windows.Forms.Label HorizontalAccuracyAddingLabel;
        private System.Windows.Forms.Label VerticalCountOfAddingLabel;
        private System.Windows.Forms.Label VerticalAccuracyAddingLabel;
        private System.Windows.Forms.Label VerticalTrianglesAddingLabel;
        private System.Windows.Forms.Label HorizontalAddingLabel;
        private System.Windows.Forms.Button SearchAndSaveSurfacesButton;
        private System.Windows.Forms.RadioButton ExtremeDeletingRadioButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox ProcessTextBox;
        private System.Windows.Forms.Label CountOfHorizontalTrianglesLabel;
        private System.Windows.Forms.Label CountOfVerticalTrianglesLabel;
        private System.Windows.Forms.Label CountOfTrianglesLabel;
        private System.Windows.Forms.Label CountOfNormalLabel;
        private System.Windows.Forms.Label CountOfPointLabel;
        private System.Windows.Forms.Label CountOfOtherTrianglesLabels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox VerticalSearchAccuracyBox;
        private System.Windows.Forms.TextBox HorizontalSearchAccuracyBox;
        private System.Windows.Forms.TextBox CountOfDeletingCiclesBox;
        private System.Windows.Forms.TextBox CountVerticalAddingBox;
        private System.Windows.Forms.TextBox VerticalAccuracyAddingBox;
        private System.Windows.Forms.TextBox HorizontalAccuracyAddingBox;
        private System.Windows.Forms.TextBox CountOfHorizontalAddingCiclesBox;
        private System.Windows.Forms.TextBox IgnoreNumberBox;
    }
}

