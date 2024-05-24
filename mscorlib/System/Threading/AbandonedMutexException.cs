using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Threading
{
	// Token: 0x020004E3 RID: 1251
	[ComVisible(false)]
	[__DynamicallyInvokable]
	[Serializable]
	public class AbandonedMutexException : SystemException
	{
		// Token: 0x06003B68 RID: 15208 RVA: 0x000E226B File Offset: 0x000E046B
		[__DynamicallyInvokable]
		public AbandonedMutexException() : base(Environment.GetResourceString("Threading.AbandonedMutexException"))
		{
			base.SetErrorCode(-2146233043);
		}

		// Token: 0x06003B69 RID: 15209 RVA: 0x000E228F File Offset: 0x000E048F
		[__DynamicallyInvokable]
		public AbandonedMutexException(string message) : base(message)
		{
			base.SetErrorCode(-2146233043);
		}

		// Token: 0x06003B6A RID: 15210 RVA: 0x000E22AA File Offset: 0x000E04AA
		[__DynamicallyInvokable]
		public AbandonedMutexException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233043);
		}

		// Token: 0x06003B6B RID: 15211 RVA: 0x000E22C6 File Offset: 0x000E04C6
		[__DynamicallyInvokable]
		public AbandonedMutexException(int location, WaitHandle handle) : base(Environment.GetResourceString("Threading.AbandonedMutexException"))
		{
			base.SetErrorCode(-2146233043);
			this.SetupException(location, handle);
		}

		// Token: 0x06003B6C RID: 15212 RVA: 0x000E22F2 File Offset: 0x000E04F2
		[__DynamicallyInvokable]
		public AbandonedMutexException(string message, int location, WaitHandle handle) : base(message)
		{
			base.SetErrorCode(-2146233043);
			this.SetupException(location, handle);
		}

		// Token: 0x06003B6D RID: 15213 RVA: 0x000E2315 File Offset: 0x000E0515
		[__DynamicallyInvokable]
		public AbandonedMutexException(string message, Exception inner, int location, WaitHandle handle) : base(message, inner)
		{
			base.SetErrorCode(-2146233043);
			this.SetupException(location, handle);
		}

		// Token: 0x06003B6E RID: 15214 RVA: 0x000E233A File Offset: 0x000E053A
		private void SetupException(int location, WaitHandle handle)
		{
			this.m_MutexIndex = location;
			if (handle != null)
			{
				this.m_Mutex = (handle as Mutex);
			}
		}

		// Token: 0x06003B6F RID: 15215 RVA: 0x000E2352 File Offset: 0x000E0552
		protected AbandonedMutexException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x170008FF RID: 2303
		// (get) Token: 0x06003B70 RID: 15216 RVA: 0x000E2363 File Offset: 0x000E0563
		[__DynamicallyInvokable]
		public Mutex Mutex
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_Mutex;
			}
		}

		// Token: 0x17000900 RID: 2304
		// (get) Token: 0x06003B71 RID: 15217 RVA: 0x000E236B File Offset: 0x000E056B
		[__DynamicallyInvokable]
		public int MutexIndex
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_MutexIndex;
			}
		}

		// Token: 0x0400195D RID: 6493
		private int m_MutexIndex = -1;

		// Token: 0x0400195E RID: 6494
		private Mutex m_Mutex;
	}
}
