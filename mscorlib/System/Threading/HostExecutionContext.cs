using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x020004FA RID: 1274
	public class HostExecutionContext : IDisposable
	{
		// Token: 0x17000918 RID: 2328
		// (get) Token: 0x06003C38 RID: 15416 RVA: 0x000E3EAD File Offset: 0x000E20AD
		// (set) Token: 0x06003C39 RID: 15417 RVA: 0x000E3EB5 File Offset: 0x000E20B5
		protected internal object State
		{
			get
			{
				return this.state;
			}
			set
			{
				this.state = value;
			}
		}

		// Token: 0x06003C3A RID: 15418 RVA: 0x000E3EBE File Offset: 0x000E20BE
		public HostExecutionContext()
		{
		}

		// Token: 0x06003C3B RID: 15419 RVA: 0x000E3EC6 File Offset: 0x000E20C6
		public HostExecutionContext(object state)
		{
			this.state = state;
		}

		// Token: 0x06003C3C RID: 15420 RVA: 0x000E3ED8 File Offset: 0x000E20D8
		[SecuritySafeCritical]
		public virtual HostExecutionContext CreateCopy()
		{
			object obj = this.state;
			if (this.state is IUnknownSafeHandle)
			{
				obj = ((IUnknownSafeHandle)this.state).Clone();
			}
			return new HostExecutionContext(this.state);
		}

		// Token: 0x06003C3D RID: 15421 RVA: 0x000E3F15 File Offset: 0x000E2115
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06003C3E RID: 15422 RVA: 0x000E3F24 File Offset: 0x000E2124
		public virtual void Dispose(bool disposing)
		{
		}

		// Token: 0x04001994 RID: 6548
		private object state;
	}
}
