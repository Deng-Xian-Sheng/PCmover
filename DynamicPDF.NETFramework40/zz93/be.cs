using System;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000045 RID: 69
	internal class be
	{
		// Token: 0x0600028A RID: 650 RVA: 0x0003DBEC File Offset: 0x0003CBEC
		internal be(string A_0, string A_1, bool A_2)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0003DC28 File Offset: 0x0003CC28
		internal virtual void n(DocumentWriter A_0)
		{
			A_0.WriteDictionaryOpen();
			A_0.WriteName(78);
			A_0.WriteText(this.a);
			if (this.b != null)
			{
				A_0.WriteName(70);
				A_0.WriteText(this.b);
			}
			if (this.c)
			{
				A_0.WriteName(72);
				A_0.ak(32);
				A_0.ap();
			}
		}

		// Token: 0x040001AB RID: 427
		private string a = string.Empty;

		// Token: 0x040001AC RID: 428
		private string b = null;

		// Token: 0x040001AD RID: 429
		private bool c = false;
	}
}
