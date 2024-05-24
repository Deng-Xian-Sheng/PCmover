using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000091 RID: 145
	internal abstract class c8
	{
		// Token: 0x0600071C RID: 1820 RVA: 0x00061FB7 File Offset: 0x00060FB7
		internal c8(abd A_0)
		{
			this.a = A_0;
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x00061FCC File Offset: 0x00060FCC
		internal abd c()
		{
			return this.a;
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x00061FE4 File Offset: 0x00060FE4
		internal virtual Resource h3()
		{
			return null;
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x00061FF8 File Offset: 0x00060FF8
		internal virtual abp hx()
		{
			return null;
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x0006200C File Offset: 0x0006100C
		internal virtual PdfPage h8()
		{
			return null;
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00062020 File Offset: 0x00061020
		internal virtual ag6 h7()
		{
			return null;
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00062034 File Offset: 0x00061034
		internal virtual afj lt()
		{
			return null;
		}

		// Token: 0x06000723 RID: 1827
		internal abstract void bw(DocumentWriter A_0);

		// Token: 0x06000724 RID: 1828 RVA: 0x00062047 File Offset: 0x00061047
		internal virtual void bv(DocumentWriter A_0)
		{
		}

		// Token: 0x040003C9 RID: 969
		private abd a;
	}
}
