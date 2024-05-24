using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000242 RID: 578
	[ComVisible(true)]
	public sealed class KeySizes
	{
		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x060020A6 RID: 8358 RVA: 0x0007283F File Offset: 0x00070A3F
		public int MinSize
		{
			get
			{
				return this.m_minSize;
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x060020A7 RID: 8359 RVA: 0x00072847 File Offset: 0x00070A47
		public int MaxSize
		{
			get
			{
				return this.m_maxSize;
			}
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x060020A8 RID: 8360 RVA: 0x0007284F File Offset: 0x00070A4F
		public int SkipSize
		{
			get
			{
				return this.m_skipSize;
			}
		}

		// Token: 0x060020A9 RID: 8361 RVA: 0x00072857 File Offset: 0x00070A57
		public KeySizes(int minSize, int maxSize, int skipSize)
		{
			this.m_minSize = minSize;
			this.m_maxSize = maxSize;
			this.m_skipSize = skipSize;
		}

		// Token: 0x04000BDE RID: 3038
		private int m_minSize;

		// Token: 0x04000BDF RID: 3039
		private int m_maxSize;

		// Token: 0x04000BE0 RID: 3040
		private int m_skipSize;
	}
}
