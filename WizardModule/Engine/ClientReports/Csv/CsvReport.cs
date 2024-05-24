using System;
using System.IO;
using System.Linq;
using System.Text;

namespace WizardModule.Engine.ClientReports.Csv
{
	// Token: 0x020000C8 RID: 200
	public class CsvReport : ClientReport
	{
		// Token: 0x06001059 RID: 4185 RVA: 0x0002A8B4 File Offset: 0x00028AB4
		public CsvReport(IClientReportParameters parameters) : base(parameters)
		{
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x0002A8C0 File Offset: 0x00028AC0
		public override bool GenerateReport()
		{
			string text = base.AppendExtension(this._reportData.FileName, ".csv");
			if (!base.CreateFolderForFile(text))
			{
				this._ts.TraceInformation("CreateFolderForFile(\"" + text + "\") failed");
				return false;
			}
			bool flag = true;
			this._sw = null;
			try
			{
				if (this._reportData.Append && File.Exists(text))
				{
					this._sw = new StreamWriter(text, true, Encoding.UTF8);
				}
				else
				{
					this._sw = new StreamWriter(text, false, Encoding.UTF8);
					flag = this.AddCsvHeaders();
				}
				if (flag)
				{
					flag = this.AddCsvContent();
				}
				this._sw.Close();
			}
			catch (Exception ex)
			{
				this._ts.TraceException(ex, "GenerateReport");
				flag = false;
			}
			if (this._sw != null)
			{
				this._sw.Dispose();
				this._sw = null;
			}
			return flag;
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x0002A9B0 File Offset: 0x00028BB0
		protected virtual bool AddCsvHeaders()
		{
			this._ts.TraceCaller("Unimplemented", "AddCsvHeaders");
			return false;
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x0002A9C8 File Offset: 0x00028BC8
		protected virtual bool AddCsvContent()
		{
			this._ts.TraceCaller("Unimplemented", "AddCsvContent");
			return false;
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x0002A9E0 File Offset: 0x00028BE0
		protected string CsvQuote(string value)
		{
			if (!value.Any((char x) => x == ',' || x == '"' || x == '\r' || x == '\n'))
			{
				return value;
			}
			value = value.Replace("\"", "\"\"");
			return string.Format("\"{0}\"", value);
		}

		// Token: 0x0600105E RID: 4190 RVA: 0x0002AA33 File Offset: 0x00028C33
		protected void StartLine()
		{
			this._line = new StringBuilder();
		}

		// Token: 0x0600105F RID: 4191 RVA: 0x0002AA40 File Offset: 0x00028C40
		protected void StoreLine()
		{
			if (this._line != null)
			{
				this._sw.WriteLine(this._line.ToString());
				this._line = null;
			}
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x0002AA68 File Offset: 0x00028C68
		protected void AppendToCsvLine(object o)
		{
			if (this._line == null)
			{
				this.StartLine();
			}
			if (this._line.Length > 0)
			{
				this._line.Append(",");
			}
			if (o != null)
			{
				this._line.Append(this.CsvQuote(o.ToString()));
			}
		}

		// Token: 0x04000583 RID: 1411
		protected StringBuilder _line;

		// Token: 0x04000584 RID: 1412
		protected StreamWriter _sw;
	}
}
