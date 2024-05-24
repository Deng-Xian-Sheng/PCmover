using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020001D8 RID: 472
	public abstract class Action
	{
		// Token: 0x06001424 RID: 5156 RVA: 0x000E0894 File Offset: 0x000DF894
		internal int c()
		{
			return this.e;
		}

		// Token: 0x06001425 RID: 5157 RVA: 0x000E08AC File Offset: 0x000DF8AC
		internal void a(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06001426 RID: 5158
		public abstract void Draw(DocumentWriter writer);

		// Token: 0x04000987 RID: 2439
		internal static byte[] a = new byte[]
		{
			84,
			121,
			112,
			101
		};

		// Token: 0x04000988 RID: 2440
		internal static byte b = 65;

		// Token: 0x04000989 RID: 2441
		internal static byte c = 83;

		// Token: 0x0400098A RID: 2442
		internal static byte[] d = new byte[]
		{
			78,
			101,
			120,
			116
		};

		// Token: 0x0400098B RID: 2443
		private int e = 0;
	}
}
