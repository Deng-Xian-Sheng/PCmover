using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000949 RID: 2377
	[ComVisible(true)]
	public struct HandleRef
	{
		// Token: 0x060060A0 RID: 24736 RVA: 0x0014C975 File Offset: 0x0014AB75
		public HandleRef(object wrapper, IntPtr handle)
		{
			this.m_wrapper = wrapper;
			this.m_handle = handle;
		}

		// Token: 0x170010FB RID: 4347
		// (get) Token: 0x060060A1 RID: 24737 RVA: 0x0014C985 File Offset: 0x0014AB85
		public object Wrapper
		{
			get
			{
				return this.m_wrapper;
			}
		}

		// Token: 0x170010FC RID: 4348
		// (get) Token: 0x060060A2 RID: 24738 RVA: 0x0014C98D File Offset: 0x0014AB8D
		public IntPtr Handle
		{
			get
			{
				return this.m_handle;
			}
		}

		// Token: 0x060060A3 RID: 24739 RVA: 0x0014C995 File Offset: 0x0014AB95
		public static explicit operator IntPtr(HandleRef value)
		{
			return value.m_handle;
		}

		// Token: 0x060060A4 RID: 24740 RVA: 0x0014C99D File Offset: 0x0014AB9D
		public static IntPtr ToIntPtr(HandleRef value)
		{
			return value.m_handle;
		}

		// Token: 0x04002B4B RID: 11083
		internal object m_wrapper;

		// Token: 0x04002B4C RID: 11084
		internal IntPtr m_handle;
	}
}
