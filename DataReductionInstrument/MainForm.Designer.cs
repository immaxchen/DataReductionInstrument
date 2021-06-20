/*
 * Created by SharpDevelop.
 * User: USER
 * Date: 2021/6/19
 * Time: 上午 11:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DataReductionInstrument
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.Button buttonPreRow;
		private System.Windows.Forms.Button buttonPreCol;
		private System.Windows.Forms.Button buttonIncCol;
		private System.Windows.Forms.Button buttonExcCol;
		private System.Windows.Forms.Button buttonIncLbl;
		private System.Windows.Forms.Button buttonExcLbl;
		private System.Windows.Forms.Button buttonIncVal;
		private System.Windows.Forms.Button buttonExcVal;
		private System.Windows.Forms.Button buttonPlus;
		private System.Windows.Forms.Button buttonDiff;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.CheckBox checkBoxCase;
		private System.Windows.Forms.CheckBox checkBoxTranspose;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonOpen = new System.Windows.Forms.Button();
			this.buttonPreRow = new System.Windows.Forms.Button();
			this.buttonPreCol = new System.Windows.Forms.Button();
			this.buttonIncCol = new System.Windows.Forms.Button();
			this.buttonExcCol = new System.Windows.Forms.Button();
			this.buttonIncLbl = new System.Windows.Forms.Button();
			this.buttonExcLbl = new System.Windows.Forms.Button();
			this.buttonIncVal = new System.Windows.Forms.Button();
			this.buttonExcVal = new System.Windows.Forms.Button();
			this.buttonPlus = new System.Windows.Forms.Button();
			this.buttonDiff = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.checkBoxCase = new System.Windows.Forms.CheckBox();
			this.checkBoxTranspose = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// buttonOpen
			// 
			this.buttonOpen.Location = new System.Drawing.Point(12, 12);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(194, 42);
			this.buttonOpen.TabIndex = 0;
			this.buttonOpen.Text = "Open";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler(this.ButtonOpenClick);
			// 
			// buttonPreRow
			// 
			this.buttonPreRow.Location = new System.Drawing.Point(12, 82);
			this.buttonPreRow.Name = "buttonPreRow";
			this.buttonPreRow.Size = new System.Drawing.Size(30, 21);
			this.buttonPreRow.TabIndex = 1;
			this.buttonPreRow.Text = "👁";
			this.buttonPreRow.UseVisualStyleBackColor = true;
			this.buttonPreRow.Click += new System.EventHandler(this.ButtonPreRowClick);
			// 
			// buttonPreCol
			// 
			this.buttonPreCol.Location = new System.Drawing.Point(109, 61);
			this.buttonPreCol.Name = "buttonPreCol";
			this.buttonPreCol.Size = new System.Drawing.Size(30, 21);
			this.buttonPreCol.TabIndex = 2;
			this.buttonPreCol.Text = "👁";
			this.buttonPreCol.UseVisualStyleBackColor = true;
			this.buttonPreCol.Click += new System.EventHandler(this.ButtonPreColClick);
			// 
			// buttonIncCol
			// 
			this.buttonIncCol.Location = new System.Drawing.Point(146, 61);
			this.buttonIncCol.Name = "buttonIncCol";
			this.buttonIncCol.Size = new System.Drawing.Size(60, 42);
			this.buttonIncCol.TabIndex = 3;
			this.buttonIncCol.Text = "Inc. Col";
			this.buttonIncCol.UseVisualStyleBackColor = true;
			this.buttonIncCol.Click += new System.EventHandler(this.ButtonIncColClick);
			// 
			// buttonExcCol
			// 
			this.buttonExcCol.Location = new System.Drawing.Point(212, 61);
			this.buttonExcCol.Name = "buttonExcCol";
			this.buttonExcCol.Size = new System.Drawing.Size(60, 42);
			this.buttonExcCol.TabIndex = 4;
			this.buttonExcCol.Text = "Exc. Col";
			this.buttonExcCol.UseVisualStyleBackColor = true;
			this.buttonExcCol.Click += new System.EventHandler(this.ButtonExcColClick);
			// 
			// buttonIncLbl
			// 
			this.buttonIncLbl.Location = new System.Drawing.Point(13, 109);
			this.buttonIncLbl.Name = "buttonIncLbl";
			this.buttonIncLbl.Size = new System.Drawing.Size(60, 42);
			this.buttonIncLbl.TabIndex = 5;
			this.buttonIncLbl.Text = "Inc. Lbl";
			this.buttonIncLbl.UseVisualStyleBackColor = true;
			this.buttonIncLbl.Click += new System.EventHandler(this.ButtonIncLblClick);
			// 
			// buttonExcLbl
			// 
			this.buttonExcLbl.Location = new System.Drawing.Point(79, 109);
			this.buttonExcLbl.Name = "buttonExcLbl";
			this.buttonExcLbl.Size = new System.Drawing.Size(60, 42);
			this.buttonExcLbl.TabIndex = 6;
			this.buttonExcLbl.Text = "Exc. Lbl";
			this.buttonExcLbl.UseVisualStyleBackColor = true;
			this.buttonExcLbl.Click += new System.EventHandler(this.ButtonExcLblClick);
			// 
			// buttonIncVal
			// 
			this.buttonIncVal.Location = new System.Drawing.Point(13, 157);
			this.buttonIncVal.Name = "buttonIncVal";
			this.buttonIncVal.Size = new System.Drawing.Size(60, 42);
			this.buttonIncVal.TabIndex = 7;
			this.buttonIncVal.Text = "Inc. Val";
			this.buttonIncVal.UseVisualStyleBackColor = true;
			this.buttonIncVal.Click += new System.EventHandler(this.ButtonIncValClick);
			// 
			// buttonExcVal
			// 
			this.buttonExcVal.Location = new System.Drawing.Point(79, 157);
			this.buttonExcVal.Name = "buttonExcVal";
			this.buttonExcVal.Size = new System.Drawing.Size(60, 42);
			this.buttonExcVal.TabIndex = 8;
			this.buttonExcVal.Text = "Exc. Val";
			this.buttonExcVal.UseVisualStyleBackColor = true;
			this.buttonExcVal.Click += new System.EventHandler(this.ButtonExcValClick);
			// 
			// buttonPlus
			// 
			this.buttonPlus.Location = new System.Drawing.Point(176, 144);
			this.buttonPlus.Name = "buttonPlus";
			this.buttonPlus.Size = new System.Drawing.Size(30, 21);
			this.buttonPlus.TabIndex = 9;
			this.buttonPlus.Text = "+";
			this.buttonPlus.UseVisualStyleBackColor = true;
			this.buttonPlus.Click += new System.EventHandler(this.ButtonPlusClick);
			// 
			// buttonDiff
			// 
			this.buttonDiff.Location = new System.Drawing.Point(212, 144);
			this.buttonDiff.Name = "buttonDiff";
			this.buttonDiff.Size = new System.Drawing.Size(30, 21);
			this.buttonDiff.TabIndex = 10;
			this.buttonDiff.Text = "-";
			this.buttonDiff.UseVisualStyleBackColor = true;
			this.buttonDiff.Click += new System.EventHandler(this.ButtonDiffClick);
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(78, 207);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(194, 42);
			this.buttonSave.TabIndex = 11;
			this.buttonSave.Text = "Save As";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// checkBoxCase
			// 
			this.checkBoxCase.Location = new System.Drawing.Point(227, 12);
			this.checkBoxCase.Name = "checkBoxCase";
			this.checkBoxCase.Size = new System.Drawing.Size(30, 42);
			this.checkBoxCase.TabIndex = 12;
			this.checkBoxCase.Text = "C";
			this.checkBoxCase.UseVisualStyleBackColor = true;
			// 
			// checkBoxTranspose
			// 
			this.checkBoxTranspose.Location = new System.Drawing.Point(28, 207);
			this.checkBoxTranspose.Name = "checkBoxTranspose";
			this.checkBoxTranspose.Size = new System.Drawing.Size(30, 42);
			this.checkBoxTranspose.TabIndex = 13;
			this.checkBoxTranspose.Text = "T";
			this.checkBoxTranspose.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.checkBoxTranspose);
			this.Controls.Add(this.checkBoxCase);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.buttonDiff);
			this.Controls.Add(this.buttonPlus);
			this.Controls.Add(this.buttonExcVal);
			this.Controls.Add(this.buttonIncVal);
			this.Controls.Add(this.buttonExcLbl);
			this.Controls.Add(this.buttonIncLbl);
			this.Controls.Add(this.buttonExcCol);
			this.Controls.Add(this.buttonIncCol);
			this.Controls.Add(this.buttonPreCol);
			this.Controls.Add(this.buttonPreRow);
			this.Controls.Add(this.buttonOpen);
			this.Name = "MainForm";
			this.Text = "DataReductionInstrument";
			this.ResumeLayout(false);

		}
	}
}
