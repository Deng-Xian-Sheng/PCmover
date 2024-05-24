using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004B1 RID: 1201
	internal class afe
	{
		// Token: 0x06003186 RID: 12678 RVA: 0x001BBB8B File Offset: 0x001BAB8B
		internal afe(abj A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06003187 RID: 12679 RVA: 0x001BBBA4 File Offset: 0x001BABA4
		internal void a(DocumentWriter A_0)
		{
			A_0.WriteName(afe.a);
			A_0.WriteDictionaryOpen();
			this.b.b(A_0);
			A_0.WriteDictionaryClose();
		}

		// Token: 0x0400171A RID: 5914
		private static byte[] a = new byte[]
		{
			71,
			114,
			111,
			117,
			112
		};

		// Token: 0x0400171B RID: 5915
		private abj b = null;
	}
}
