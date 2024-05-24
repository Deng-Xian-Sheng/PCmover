using System;
using System.Data;

namespace ceTe.DynamicPDF.LayoutEngine.Data
{
	// Token: 0x02000944 RID: 2372
	public class DataTableReportData : ReportData
	{
		// Token: 0x06006042 RID: 24642 RVA: 0x00360394 File Offset: 0x0035F394
		public DataTableReportData(DataTable dataTable) : this(null, dataTable)
		{
		}

		// Token: 0x06006043 RID: 24643 RVA: 0x003603A4 File Offset: 0x0035F3A4
		public DataTableReportData(IDbConnection connection, DataTable dataTable)
		{
			this.a = connection;
			this.b = dataTable.Rows;
			this.c = dataTable.Columns;
			this.g = (this.b.Count > 0);
		}

		// Token: 0x06006044 RID: 24644 RVA: 0x00360402 File Offset: 0x0035F402
		internal override void mn()
		{
			this.e++;
			this.f++;
		}

		// Token: 0x06006045 RID: 24645 RVA: 0x00360421 File Offset: 0x0035F421
		internal override void mo()
		{
			this.e--;
		}

		// Token: 0x06006046 RID: 24646 RVA: 0x00360434 File Offset: 0x0035F434
		internal override bool mp(LayoutWriter A_0)
		{
			bool result;
			if (this.f > this.e)
			{
				this.f--;
				result = this.g;
			}
			else
			{
				if (base.a().a())
				{
					base.a().b().a(A_0);
				}
				this.d++;
				this.g = (this.b.Count > this.d);
				result = this.g;
			}
			return result;
		}

		// Token: 0x17000A49 RID: 2633
		public override object this[string fieldName]
		{
			get
			{
				object result;
				if (this.g)
				{
					result = this.b[this.d][fieldName];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x06006048 RID: 24648 RVA: 0x00360504 File Offset: 0x0035F504
		internal override bool mq(string A_0)
		{
			return this.c.Contains(A_0);
		}

		// Token: 0x06006049 RID: 24649 RVA: 0x00360524 File Offset: 0x0035F524
		internal override void mr()
		{
			if (this.a != null)
			{
				this.a.Close();
			}
		}

		// Token: 0x17000A4A RID: 2634
		// (get) Token: 0x0600604A RID: 24650 RVA: 0x0036054C File Offset: 0x0035F54C
		public override bool HasData
		{
			get
			{
				return this.g;
			}
		}

		// Token: 0x17000A4B RID: 2635
		// (get) Token: 0x0600604B RID: 24651 RVA: 0x00360564 File Offset: 0x0035F564
		public IDbConnection Connection
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x04003188 RID: 12680
		private new IDbConnection a;

		// Token: 0x04003189 RID: 12681
		private DataRowCollection b;

		// Token: 0x0400318A RID: 12682
		private DataColumnCollection c;

		// Token: 0x0400318B RID: 12683
		private int d = 0;

		// Token: 0x0400318C RID: 12684
		private int e = 0;

		// Token: 0x0400318D RID: 12685
		private int f = 0;

		// Token: 0x0400318E RID: 12686
		private bool g;
	}
}
