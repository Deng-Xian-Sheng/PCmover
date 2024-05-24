using System;
using System.Collections.Generic;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002D1 RID: 721
	internal sealed class SetOfValueComparer : IComparer<ReadOnlyMemory<byte>>
	{
		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x0600256C RID: 9580 RVA: 0x00088C2F File Offset: 0x00086E2F
		internal static SetOfValueComparer Instance
		{
			get
			{
				return SetOfValueComparer._instance;
			}
		}

		// Token: 0x0600256D RID: 9581 RVA: 0x00088C36 File Offset: 0x00086E36
		public int Compare(ReadOnlyMemory<byte> x, ReadOnlyMemory<byte> y)
		{
			return SetOfValueComparer.Compare(x.Span, y.Span);
		}

		// Token: 0x0600256E RID: 9582 RVA: 0x00088C4C File Offset: 0x00086E4C
		internal static int Compare(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y)
		{
			int num = Math.Min(x.Length, y.Length);
			for (int i = 0; i < num; i++)
			{
				int num2 = (int)x[i];
				byte b = y[i];
				int num3 = num2 - (int)b;
				if (num3 != 0)
				{
					return num3;
				}
			}
			return x.Length - y.Length;
		}

		// Token: 0x04000E1B RID: 3611
		private static SetOfValueComparer _instance = new SetOfValueComparer();
	}
}
