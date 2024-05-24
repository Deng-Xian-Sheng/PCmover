using System;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x020002D3 RID: 723
	internal class sv
	{
		// Token: 0x060020A5 RID: 8357 RVA: 0x00141000 File Offset: 0x00140000
		internal sv(string A_0) : this(A_0.ToCharArray(), 0, A_0.Length)
		{
		}

		// Token: 0x060020A6 RID: 8358 RVA: 0x00141018 File Offset: 0x00140018
		internal sv(char[] A_0, int A_1, int A_2)
		{
			this.c = A_1;
			this.b = new w5(A_0, A_1, A_2);
			this.a = this.b.j();
		}

		// Token: 0x060020A7 RID: 8359 RVA: 0x0014104C File Offset: 0x0014004C
		internal bool a(LayoutWriter A_0)
		{
			return this.a.ee(A_0);
		}

		// Token: 0x060020A8 RID: 8360 RVA: 0x0014106C File Offset: 0x0014006C
		internal q7 a()
		{
			return this.a;
		}

		// Token: 0x060020A9 RID: 8361 RVA: 0x00141084 File Offset: 0x00140084
		internal string b()
		{
			return this.b.b(this.c);
		}

		// Token: 0x04000E53 RID: 3667
		private q7 a;

		// Token: 0x04000E54 RID: 3668
		private w5 b;

		// Token: 0x04000E55 RID: 3669
		private int c;
	}
}
