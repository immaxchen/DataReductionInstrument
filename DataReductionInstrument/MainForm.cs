/*
 * Created by SharpDevelop.
 * User: USER
 * Date: 2021/6/19
 * Time: 上午 11:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace DataReductionInstrument
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		string filePath;
		string strIncCol;
		string strExcCol;
		string strIncLbl;
		string strExcLbl;
		string strIncVal;
		string strExcVal;
		string[] colnames;
		bool[] colSelector;
		bool[] rowSelector;
		bool opDiff;
		bool multOp;
		string[] keepColNames;
		int previewLines;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			keepColNames = ConfigurationManager.AppSettings["KeepColNames"].Split(',');
			previewLines = Convert.ToInt32(ConfigurationManager.AppSettings["PreviewLines"]);
		}
		
		void ButtonOpenClick(object sender, EventArgs e)
		{
			using (var openFileDialog = new OpenFileDialog()) {
				openFileDialog.InitialDirectory = Application.StartupPath;
				openFileDialog.Filter = "csv files (*.csv)|*.csv";
				openFileDialog.RestoreDirectory = true;
				
				if (openFileDialog.ShowDialog() == DialogResult.OK) {
					filePath = openFileDialog.FileName;
				}
			}
			
			colnames = File.ReadLines(filePath).First().Split(',');
			colSelector = new bool[colnames.Length];
			rowSelector = new bool[File.ReadLines(filePath).Count()];
		}
		
		Regex GetIncRegex(string s)
		{
			s = string.IsNullOrEmpty(s) ? "(?=)" : s;
			return checkBoxCase.Checked ? new Regex(s, RegexOptions.Compiled) : new Regex(s, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		}
		
		Regex GetExcRegex(string s)
		{
			s = string.IsNullOrEmpty(s) ? "(?!)" : s;
			return checkBoxCase.Checked ? new Regex(s, RegexOptions.Compiled) : new Regex(s, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		}
		
		void SetFontBold(Control btn, bool bold)
		{
			btn.Font = new Font(btn.Font, bold ? FontStyle.Bold : FontStyle.Regular);
		}
		
		void ButtonIncColClick(object sender, EventArgs e)
		{
			strIncCol = Interaction.InputBox("Inclusive regex for column name");
			SetFontBold(buttonIncCol, !string.IsNullOrEmpty(strIncCol));
		}
		
		void ButtonExcColClick(object sender, EventArgs e)
		{
			strExcCol = Interaction.InputBox("Exclusive regex for column name");
			SetFontBold(buttonExcCol, !string.IsNullOrEmpty(strExcCol));
		}
		
		bool[] _GetColSelector()
		{
			if (string.IsNullOrEmpty(strIncCol) && string.IsNullOrEmpty(strExcCol))
			if (multOp)
				return new bool[colSelector.Length];
			else
				return Enumerable.Repeat(true, colSelector.Length).ToArray();
			var incRe = GetIncRegex(strIncCol);
			var excRe = GetExcRegex(strExcCol);
			return colnames.Select(o => incRe.IsMatch(o) && !excRe.IsMatch(o)).ToArray();
		}
		
		bool[] GetColSelector()
		{
			var selector = opDiff ? _GetColSelector().Select((o, i) => !o && colSelector[i]).ToArray() : _GetColSelector().Select((o, i) => o || colSelector[i]).ToArray();
			return selector.Select((o, i) => keepColNames.Contains(colnames[i]) || o).ToArray();
		}
		
		void ButtonPreColClick(object sender, EventArgs e)
		{
			var selector = GetColSelector();
			var selected = colnames.Where((o, i) => selector[i]).ToArray();
			if (selected.Length > previewLines * 2)
				MessageBox.Show(string.Join("\r\n", selected.Take(previewLines).Concat(new string[]{ "..." }).Concat(selected.Skip(selected.Length - previewLines)).ToArray()), "Selected columns");
			else
				MessageBox.Show(string.Join("\r\n", selected), "Selected columns");
		}
		
		void ButtonIncLblClick(object sender, EventArgs e)
		{
			strIncLbl = Interaction.InputBox("Inclusive regex for data label");
			SetFontBold(buttonIncLbl, !string.IsNullOrEmpty(strIncLbl));
		}
		
		void ButtonExcLblClick(object sender, EventArgs e)
		{
			strExcLbl = Interaction.InputBox("Exclusive regex for data label");
			SetFontBold(buttonExcLbl, !string.IsNullOrEmpty(strExcLbl));
		}
		
		void ButtonIncValClick(object sender, EventArgs e)
		{
			strIncVal = Interaction.InputBox("Inclusive regex for data value");
			SetFontBold(buttonIncVal, !string.IsNullOrEmpty(strIncVal));
		}
		
		void ButtonExcValClick(object sender, EventArgs e)
		{
			strExcVal = Interaction.InputBox("Exclusive regex for data value");
			SetFontBold(buttonExcVal, !string.IsNullOrEmpty(strExcVal));
		}
		
		bool[] GetLblSelector()
		{
			var incRe = GetIncRegex(strIncLbl);
			var excRe = GetExcRegex(strExcLbl);
			return colnames.Select(o => incRe.IsMatch(o) && !excRe.IsMatch(o)).ToArray();
		}
		
		bool[] _GetRowSelector()
		{
			if (string.IsNullOrEmpty(strIncVal) && string.IsNullOrEmpty(strExcVal))
			if (multOp)
				return new bool[rowSelector.Length];
			else
				return Enumerable.Repeat(true, rowSelector.Length).ToArray();
			var lblSelector = GetLblSelector();
			var incRe = GetIncRegex(strIncVal);
			var excRe = GetExcRegex(strExcVal);
			return File.ReadLines(filePath).Select(s => s.Split(',').Where((o, i) => lblSelector[i]).Any(o => incRe.IsMatch(o) && !excRe.IsMatch(o))).ToArray();
		}
		
		bool[] GetRowSelector()
		{
			var selector = opDiff ? _GetRowSelector().Select((o, i) => !o && rowSelector[i]).ToArray() : _GetRowSelector().Select((o, i) => o || rowSelector[i]).ToArray();
			selector[0] = true;
			return selector;
		}
		
		void ButtonPreRowClick(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(strIncLbl) || !string.IsNullOrEmpty(strExcLbl) || !string.IsNullOrEmpty(strIncVal) || !string.IsNullOrEmpty(strExcVal)) {
				var _selector = GetLblSelector();
				var _selected = colnames.Where((o, i) => _selector[i]).ToArray();
				if (_selected.Length > previewLines * 2)
					MessageBox.Show(string.Join("\r\n", _selected.Take(previewLines).Concat(new string[]{ "..." }).Concat(_selected.Skip(_selected.Length - previewLines)).ToArray()), "Selected data labels");
				else
					MessageBox.Show(string.Join("\r\n", _selected), "Selected data labels");
			}
			var selector = GetRowSelector();
			var selected = selector.Count(o => o);
			MessageBox.Show(string.Format("{0} out of {1} rows selected", selected - 1, selector.Length - 1), "Selected rows");
		}
		
		void ResetControls()
		{
			strIncCol = null;
			strExcCol = null;
			strIncLbl = null;
			strExcLbl = null;
			strIncVal = null;
			strExcVal = null;
			SetFontBold(buttonIncCol, false);
			SetFontBold(buttonExcCol, false);
			SetFontBold(buttonIncLbl, false);
			SetFontBold(buttonExcLbl, false);
			SetFontBold(buttonIncVal, false);
			SetFontBold(buttonExcVal, false);
			SetFontBold(buttonPlus, false);
			SetFontBold(buttonDiff, false);
		}
		
		void ButtonPlusClick(object sender, EventArgs e)
		{
			colSelector = GetColSelector();
			rowSelector = GetRowSelector();
			ResetControls();
			multOp = true;
			opDiff = false;
			SetFontBold(buttonPlus, true);
		}
		
		void ButtonDiffClick(object sender, EventArgs e)
		{
			colSelector = GetColSelector();
			rowSelector = GetRowSelector();
			ResetControls();
			multOp = true;
			opDiff = true;
			SetFontBold(buttonDiff, true);
		}
		
		void SaveNormalForm(string savePath)
		{
			var _colSelector = GetColSelector();
			var _rowSelector = GetRowSelector();
			
			using (var sw = new StreamWriter(savePath)) {
				File.ReadLines(filePath).Where((o, i) => _rowSelector[i]).Select(s => {
					sw.WriteLine(string.Join(",", s.Split(',').Where((o, i) => _colSelector[i]).ToArray()));
					return true;
				}).ToArray();
			}
		}
		
		void SaveTransposed(string savePath)
		{
			var _colSelector = GetColSelector();
			var _rowSelector = GetRowSelector();
			
			var data = File.ReadLines(filePath).Where((o, i) => _rowSelector[i]).Select(s => s.Split(',').Where((o, i) => _colSelector[i]).ToArray()).ToArray();
			
			using (var sw = new StreamWriter(savePath)) {
				var ncol = data.Max(o => o.Length);
				for (int i = 0; i < ncol; i++)
					sw.WriteLine(string.Join(",", data.Select(o => i < o.Length ? o[i] : "").ToArray()));
			}
		}
		
		void ButtonSaveClick(object sender, EventArgs e)
		{
			using (var saveFileDialog = new SaveFileDialog()) {
				saveFileDialog.InitialDirectory = Application.StartupPath;
				saveFileDialog.Filter = "csv files (*.csv)|*.csv";
				saveFileDialog.RestoreDirectory = true;
				
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				if (!checkBoxTranspose.Checked)
					SaveNormalForm(saveFileDialog.FileName);
				else
					SaveTransposed(saveFileDialog.FileName);
			}
		}
	}
}
