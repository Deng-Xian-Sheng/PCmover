using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000566 RID: 1382
	internal class ake : ait
	{
		// Token: 0x06003729 RID: 14121 RVA: 0x001DDD84 File Offset: 0x001DCD84
		internal ake(string A_0, al5 A_1)
		{
			this.b = A_0;
			A_1.a(A_1.d() + 1);
			A_1.p();
			if (A_1.b() == '"')
			{
				A_1.a(A_1.d() + 1);
				int num = A_1.d();
				A_1.q();
				this.a = new string(A_1.c(), num, A_1.d() - num);
				A_1.a(A_1.d() + 1);
				A_1.p();
				if (A_1.b() != ']')
				{
					throw new DlexParseException("Invalid RecordSet indexer detected.");
				}
				A_1.a(A_1.d() + 1);
			}
			else
			{
				if (A_1.b() == ']')
				{
					throw new DlexParseException("Invalid NetAppSettings variable detected.");
				}
				int num = A_1.d();
				A_1.r();
				try
				{
					this.c = int.Parse(new string(A_1.c(), num, A_1.d() - num));
				}
				catch
				{
					throw new DlexParseException("Invalid field number entered for RecordSet indexer.");
				}
				A_1.a(A_1.d() + 1);
			}
		}

		// Token: 0x0600372A RID: 14122 RVA: 0x001DDEC4 File Offset: 0x001DCEC4
		internal override void lu(LayoutWriter A_0, alq A_1, char[] A_2)
		{
			throw new LayoutEngineException("Data privider indexers are not supported.");
		}

		// Token: 0x0600372B RID: 14123 RVA: 0x001DDED4 File Offset: 0x001DCED4
		internal override bool l4(LayoutWriter A_0)
		{
			return this.ma(A_0) == null;
		}

		// Token: 0x0600372C RID: 14124 RVA: 0x001DDEF0 File Offset: 0x001DCEF0
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return A_1.b() == null;
		}

		// Token: 0x0600372D RID: 14125 RVA: 0x001DDF0B File Offset: 0x001DCF0B
		internal override object ma(LayoutWriter A_0)
		{
			throw new LayoutEngineException("Data privider indexers are not supported.");
		}

		// Token: 0x0600372E RID: 14126 RVA: 0x001DDF18 File Offset: 0x001DCF18
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			return A_1.b();
		}

		// Token: 0x0600372F RID: 14127 RVA: 0x001DDF30 File Offset: 0x001DCF30
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			A_1.a(this.ma(A_0));
		}

		// Token: 0x04001A13 RID: 6675
		private new string a;

		// Token: 0x04001A14 RID: 6676
		private new string b;

		// Token: 0x04001A15 RID: 6677
		private new int c = -1;
	}
}
