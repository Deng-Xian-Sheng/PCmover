using System;
using System.IO;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000417 RID: 1047
	internal abstract class aa9
	{
		// Token: 0x06002BAC RID: 11180 RVA: 0x00193A07 File Offset: 0x00192A07
		internal aa9()
		{
		}

		// Token: 0x06002BAD RID: 11181 RVA: 0x00193A1C File Offset: 0x00192A1C
		internal PdfDocument f()
		{
			return this.a;
		}

		// Token: 0x06002BAE RID: 11182 RVA: 0x00193A34 File Offset: 0x00192A34
		internal void a(PdfDocument A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002BAF RID: 11183
		internal abstract aba k8();

		// Token: 0x06002BB0 RID: 11184 RVA: 0x00193A40 File Offset: 0x00192A40
		internal static aa9 a(Stream A_0)
		{
			aa9 result;
			if (A_0.Length <= 65536L)
			{
				byte[] array = new byte[A_0.Length];
				A_0.Read(array, 0, array.Length);
				result = new agr(array);
			}
			else
			{
				result = new agp(A_0);
			}
			return result;
		}

		// Token: 0x06002BB1 RID: 11185 RVA: 0x00193A90 File Offset: 0x00192A90
		internal static aa9 a(string A_0)
		{
			FileInfo fileInfo = new FileInfo(A_0);
			aa9 result;
			if (fileInfo.Length <= 65536L)
			{
				byte[] a_ = File.ReadAllBytes(fileInfo.FullName);
				result = new agr(a_);
			}
			else
			{
				result = new agq(fileInfo);
			}
			return result;
		}

		// Token: 0x06002BB2 RID: 11186 RVA: 0x00193AD7 File Offset: 0x00192AD7
		internal virtual void la()
		{
		}

		// Token: 0x04001496 RID: 5270
		private PdfDocument a = null;
	}
}
