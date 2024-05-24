using System;
using System.Security;

namespace System.Reflection
{
	// Token: 0x020005FA RID: 1530
	[Serializable]
	internal struct ConstArray
	{
		// Token: 0x17000A9D RID: 2717
		// (get) Token: 0x06004674 RID: 18036 RVA: 0x001028D3 File Offset: 0x00100AD3
		public IntPtr Signature
		{
			get
			{
				return this.m_constArray;
			}
		}

		// Token: 0x17000A9E RID: 2718
		// (get) Token: 0x06004675 RID: 18037 RVA: 0x001028DB File Offset: 0x00100ADB
		public int Length
		{
			get
			{
				return this.m_length;
			}
		}

		// Token: 0x17000A9F RID: 2719
		public unsafe byte this[int index]
		{
			[SecuritySafeCritical]
			get
			{
				if (index < 0 || index >= this.m_length)
				{
					throw new IndexOutOfRangeException();
				}
				return ((byte*)this.m_constArray.ToPointer())[index];
			}
		}

		// Token: 0x04001D46 RID: 7494
		internal int m_length;

		// Token: 0x04001D47 RID: 7495
		internal IntPtr m_constArray;
	}
}
