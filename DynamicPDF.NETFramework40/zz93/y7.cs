using System;

namespace zz93
{
	// Token: 0x020003C4 RID: 964
	internal abstract class y7
	{
		// Token: 0x060028AF RID: 10415 RVA: 0x00178C54 File Offset: 0x00177C54
		static y7()
		{
			for (int i = 0; i < 256; i++)
			{
				y7.a[i] = new byte[]
				{
					(byte)i
				};
			}
		}

		// Token: 0x060028B0 RID: 10416 RVA: 0x00178C9C File Offset: 0x00177C9C
		internal static byte[][] a()
		{
			byte[][] array = new byte[4096][];
			y7.a.CopyTo(array, 0);
			return array;
		}

		// Token: 0x060028B1 RID: 10417
		internal abstract void g6(byte[] A_0, int A_1);

		// Token: 0x0400122C RID: 4652
		private static byte[][] a = new byte[256][];
	}
}
