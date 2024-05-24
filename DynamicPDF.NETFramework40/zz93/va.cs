using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200032B RID: 811
	internal class va : q8
	{
		// Token: 0x0600232F RID: 9007 RVA: 0x0014F368 File Offset: 0x0014E368
		internal va(string A_0, w5 A_1)
		{
			this.b = A_0;
			A_1.a(A_1.e() + 1);
			A_1.q();
			if (A_1.c() == '"')
			{
				A_1.a(A_1.e() + 1);
				int num = A_1.e();
				A_1.r();
				this.a = new string(A_1.d(), num, A_1.e() - num);
				A_1.a(A_1.e() + 1);
				A_1.q();
				if (A_1.c() != ']')
				{
					throw new DplxParseException("Invalid RecordSet indexer detected.");
				}
				A_1.a(A_1.e() + 1);
			}
			else
			{
				if (A_1.c() == ']')
				{
					throw new DplxParseException("Invalid NetAppSettings variable detected.");
				}
				int num = A_1.e();
				A_1.s();
				try
				{
					this.c = int.Parse(new string(A_1.d(), num, A_1.e() - num));
				}
				catch
				{
					throw new DplxParseException("Invalid field number entered for RecordSet indexer.");
				}
				A_1.a(A_1.e() + 1);
			}
		}

		// Token: 0x06002330 RID: 9008 RVA: 0x0014F4A8 File Offset: 0x0014E4A8
		internal override void ec(LayoutWriter A_0, wt A_1, char[] A_2)
		{
			RecordSet recordSet = A_0.RecordSets[this.b];
			if (recordSet == null)
			{
				throw new ReportWriterException("The " + this.b + " recordSet does not exist.");
			}
			if (this.a != null)
			{
				A_1.a(recordSet[this.a].ToString());
			}
			else
			{
				A_1.a(recordSet[this.c].ToString());
			}
		}

		// Token: 0x06002331 RID: 9009 RVA: 0x0014F534 File Offset: 0x0014E534
		internal override bool eq(LayoutWriter A_0)
		{
			return this.es(A_0) == null;
		}

		// Token: 0x06002332 RID: 9010 RVA: 0x0014F550 File Offset: 0x0014E550
		internal override bool er(LayoutWriter A_0, vi A_1)
		{
			return A_1.b() == null;
		}

		// Token: 0x06002333 RID: 9011 RVA: 0x0014F56C File Offset: 0x0014E56C
		internal override object es(LayoutWriter A_0)
		{
			RecordSet recordSet = A_0.RecordSets[this.b];
			if (recordSet == null)
			{
				throw new ReportWriterException("The " + this.b + " recordSet does not exist.");
			}
			object result;
			if (this.a != null)
			{
				result = recordSet[this.a];
			}
			else
			{
				result = recordSet[this.c];
			}
			return result;
		}

		// Token: 0x06002334 RID: 9012 RVA: 0x0014F5E0 File Offset: 0x0014E5E0
		internal override object et(LayoutWriter A_0, vi A_1)
		{
			return A_1.b();
		}

		// Token: 0x06002335 RID: 9013 RVA: 0x0014F5F8 File Offset: 0x0014E5F8
		internal override void eu(LayoutWriter A_0, vi A_1, PageElement A_2)
		{
			A_1.a(this.es(A_0));
		}

		// Token: 0x04000F15 RID: 3861
		private new string a;

		// Token: 0x04000F16 RID: 3862
		private new string b;

		// Token: 0x04000F17 RID: 3863
		private new int c = -1;
	}
}
