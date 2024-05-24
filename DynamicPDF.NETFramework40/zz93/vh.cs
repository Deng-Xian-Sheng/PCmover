using System;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000332 RID: 818
	internal class vh
	{
		// Token: 0x0600235A RID: 9050 RVA: 0x00150648 File Offset: 0x0014F648
		internal vh(wb A_0)
		{
			this.a = new vg[A_0.a()];
			for (wa wa = A_0.b(); wa != null; wa = wa.a())
			{
				this.a[this.b++] = new vg(wa);
			}
		}

		// Token: 0x0600235B RID: 9051 RVA: 0x001506B4 File Offset: 0x0014F6B4
		internal void a(LayoutWriter A_0, SqlCommand A_1)
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].a(A_0, A_1);
			}
		}

		// Token: 0x0600235C RID: 9052 RVA: 0x001506EC File Offset: 0x0014F6EC
		internal void a(LayoutWriter A_0, OracleCommand A_1)
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].a(A_0, A_1);
			}
		}

		// Token: 0x0600235D RID: 9053 RVA: 0x00150724 File Offset: 0x0014F724
		internal void a(LayoutWriter A_0, OleDbCommand A_1)
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].a(A_0, A_1);
			}
		}

		// Token: 0x0600235E RID: 9054 RVA: 0x0015075C File Offset: 0x0014F75C
		internal void a(LayoutWriter A_0, OdbcCommand A_1)
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].a(A_0, A_1);
			}
		}

		// Token: 0x04000F2D RID: 3885
		private vg[] a;

		// Token: 0x04000F2E RID: 3886
		private int b = 0;
	}
}
