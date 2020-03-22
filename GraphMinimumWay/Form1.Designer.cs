namespace GraphMinimumWay
{
    partial class Form1
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
			this.verdexList = new System.Windows.Forms.ListBox();
			this.label = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.drawVerdex = new System.Windows.Forms.Button();
			this.getMinimum = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.toClear = new System.Windows.Forms.Button();
			this.drawEdge = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// verdexList
			// 
			this.verdexList.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.verdexList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.verdexList.FormattingEnabled = true;
			this.verdexList.ItemHeight = 16;
			this.verdexList.Location = new System.Drawing.Point(615, 79);
			this.verdexList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.verdexList.Name = "verdexList";
			this.verdexList.Size = new System.Drawing.Size(202, 194);
			this.verdexList.TabIndex = 5;
			this.verdexList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.verdexList_MouseClick);
			this.verdexList.SelectedIndexChanged += new System.EventHandler(this.verdexList_SelectedIndexChanged);
			// 
			// label
			// 
			this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label.AutoSize = true;
			this.label.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label.Location = new System.Drawing.Point(620, 31);
			this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(171, 40);
			this.label.TabIndex = 8;
			this.label.Text = "кратчайшие пути \r\nиз начальной вершины";
			this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(260, 170);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(107, 22);
			this.textBox1.TabIndex = 9;
			this.textBox1.Text = "введите вес";
			this.textBox1.Visible = false;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
			this.textBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDown);
			// 
			// drawVerdex
			// 
			this.drawVerdex.FlatAppearance.BorderSize = 0;
			this.drawVerdex.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.drawVerdex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.drawVerdex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.drawVerdex.Image = global::GraphMinimumWay.Properties.Resources.vertex;
			this.drawVerdex.Location = new System.Drawing.Point(29, 100);
			this.drawVerdex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.drawVerdex.Name = "drawVerdex";
			this.drawVerdex.Size = new System.Drawing.Size(53, 49);
			this.drawVerdex.TabIndex = 7;
			this.drawVerdex.UseVisualStyleBackColor = true;
			this.drawVerdex.Click += new System.EventHandler(this.drawVerdex_Click);
			this.drawVerdex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawVerdex_MouseDown);
			this.drawVerdex.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawVerdex_MouseUp);
			// 
			// getMinimum
			// 
			this.getMinimum.FlatAppearance.BorderSize = 0;
			this.getMinimum.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.getMinimum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.getMinimum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.getMinimum.Image = global::GraphMinimumWay.Properties.Resources.iknowdaway;
			this.getMinimum.Location = new System.Drawing.Point(615, 297);
			this.getMinimum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.getMinimum.Name = "getMinimum";
			this.getMinimum.Size = new System.Drawing.Size(203, 42);
			this.getMinimum.TabIndex = 6;
			this.getMinimum.UseVisualStyleBackColor = true;
			this.getMinimum.Click += new System.EventHandler(this.getMinimum_Click);
			this.getMinimum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.getMinimum_MouseDown);
			this.getMinimum.MouseUp += new System.Windows.Forms.MouseEventHandler(this.getMinimum_MouseUp);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox1.Location = new System.Drawing.Point(123, 31);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(467, 308);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
			// 
			// toClear
			// 
			this.toClear.FlatAppearance.BorderSize = 0;
			this.toClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.toClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.toClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.toClear.Image = global::GraphMinimumWay.Properties.Resources.clear;
			this.toClear.Location = new System.Drawing.Point(29, 213);
			this.toClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.toClear.Name = "toClear";
			this.toClear.Size = new System.Drawing.Size(53, 49);
			this.toClear.TabIndex = 3;
			this.toClear.UseVisualStyleBackColor = true;
			this.toClear.Click += new System.EventHandler(this.toClear_Click);
			this.toClear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toClear_MouseDown);
			this.toClear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toClear_MouseUp);
			// 
			// drawEdge
			// 
			this.drawEdge.FlatAppearance.BorderSize = 0;
			this.drawEdge.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.drawEdge.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.drawEdge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.drawEdge.Image = global::GraphMinimumWay.Properties.Resources.edge;
			this.drawEdge.Location = new System.Drawing.Point(29, 156);
			this.drawEdge.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.drawEdge.Name = "drawEdge";
			this.drawEdge.Size = new System.Drawing.Size(53, 49);
			this.drawEdge.TabIndex = 1;
			this.drawEdge.UseVisualStyleBackColor = true;
			this.drawEdge.Click += new System.EventHandler(this.drawEdge_Click);
			this.drawEdge.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawEdge_MouseDown);
			this.drawEdge.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawEdge_MouseUp);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(843, 373);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label);
			this.Controls.Add(this.drawVerdex);
			this.Controls.Add(this.getMinimum);
			this.Controls.Add(this.verdexList);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.toClear);
			this.Controls.Add(this.drawEdge);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximumSize = new System.Drawing.Size(861, 420);
			this.Name = "Form1";
			this.Text = "Dijkstra";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button toClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox verdexList;
        private System.Windows.Forms.Button getMinimum;
        private System.Windows.Forms.Button drawVerdex;
        private System.Windows.Forms.Button drawEdge;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBox1;
    }
}

