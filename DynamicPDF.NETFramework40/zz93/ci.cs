using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000072 RID: 114
	internal class ci
	{
		// Token: 0x060004AE RID: 1198 RVA: 0x0004EA63 File Offset: 0x0004DA63
		internal ci(ArrayList A_0, ArrayList A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x0004EA8C File Offset: 0x0004DA8C
		internal void b(DocumentWriter A_0)
		{
			if (this.a != null)
			{
				A_0.WriteName(ci.c);
				A_0.WriteDictionaryOpen();
				this.a(A_0);
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x0004EACC File Offset: 0x0004DACC
		private void a(DocumentWriter A_0)
		{
			int num = 0;
			foreach (object obj in this.a)
			{
				abg abg = (abg)obj;
				A_0.WriteName(this.b[num].ToString());
				abg.a(A_0);
				num++;
			}
		}

		// Token: 0x040002C1 RID: 705
		private ArrayList a = null;

		// Token: 0x040002C2 RID: 706
		private ArrayList b = null;

		// Token: 0x040002C3 RID: 707
		private static byte[] c = new byte[]
		{
			88,
			79,
			98,
			106,
			101,
			99,
			116
		};
	}
}
