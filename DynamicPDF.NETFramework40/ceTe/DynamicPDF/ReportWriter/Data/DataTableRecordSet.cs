using System;
using System.Data;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.Data
{
	// Token: 0x020007FF RID: 2047
	public class DataTableRecordSet : RecordSet
	{
		// Token: 0x0600531B RID: 21275 RVA: 0x00290E0F File Offset: 0x0028FE0F
		public DataTableRecordSet(DataTable dataTable) : this(null, dataTable)
		{
		}

		// Token: 0x0600531C RID: 21276 RVA: 0x00290E1C File Offset: 0x0028FE1C
		public DataTableRecordSet(IDbConnection connection, DataTable dataTable)
		{
			this.a = connection;
			this.b = dataTable.Rows;
			this.f = (this.b.Count > 0);
		}

		// Token: 0x0600531D RID: 21277 RVA: 0x00290E6E File Offset: 0x0028FE6E
		internal override void d9()
		{
			this.d++;
			this.e++;
		}

		// Token: 0x0600531E RID: 21278 RVA: 0x00290E8D File Offset: 0x0028FE8D
		internal override void ea()
		{
			this.d--;
		}

		// Token: 0x0600531F RID: 21279 RVA: 0x00290EA0 File Offset: 0x0028FEA0
		internal override bool d8(LayoutWriter A_0)
		{
			bool result;
			if (this.e > this.d)
			{
				this.e--;
				result = this.f;
			}
			else
			{
				if (base.Query.d())
				{
					base.Query.e().a(A_0);
				}
				this.c++;
				this.f = (this.b.Count > this.c);
				result = this.f;
			}
			return result;
		}

		// Token: 0x1700077E RID: 1918
		public override object this[string fieldName]
		{
			get
			{
				object result;
				if (this.f)
				{
					result = this.b[this.c][fieldName];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x1700077F RID: 1919
		public override object this[int fieldIndex]
		{
			get
			{
				object result;
				if (this.f)
				{
					result = this.b[this.c][fieldIndex];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x06005322 RID: 21282 RVA: 0x00290FAC File Offset: 0x0028FFAC
		internal override void eb()
		{
			if (this.a != null)
			{
				this.a.Close();
			}
		}

		// Token: 0x17000780 RID: 1920
		// (get) Token: 0x06005323 RID: 21283 RVA: 0x00290FD4 File Offset: 0x0028FFD4
		public override bool HasData
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x17000781 RID: 1921
		// (get) Token: 0x06005324 RID: 21284 RVA: 0x00290FEC File Offset: 0x0028FFEC
		public IDbConnection Connection
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x04002C60 RID: 11360
		private new IDbConnection a;

		// Token: 0x04002C61 RID: 11361
		private DataRowCollection b;

		// Token: 0x04002C62 RID: 11362
		private int c = 0;

		// Token: 0x04002C63 RID: 11363
		private int d = 0;

		// Token: 0x04002C64 RID: 11364
		private int e = 0;

		// Token: 0x04002C65 RID: 11365
		private bool f;
	}
}
