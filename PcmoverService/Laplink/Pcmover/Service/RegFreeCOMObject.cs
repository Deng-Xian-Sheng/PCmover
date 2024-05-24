using System;
using System.Runtime.InteropServices;
using Laplink.Tools.NativeMethods;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200001D RID: 29
	internal class RegFreeCOMObject : IDisposable
	{
		// Token: 0x060001CB RID: 459 RVA: 0x0000ED34 File Offset: 0x0000CF34
		public RegFreeCOMObject(string name, string assemblyDirectory, out uint dwError)
		{
			dwError = 0U;
			object actCtxLock = RegFreeCOMObject.m_actCtxLock;
			lock (actCtxLock)
			{
				Kernel32.ACTCTX actctx = new Kernel32.ACTCTX
				{
					cbSize = (uint)Marshal.SizeOf(typeof(Kernel32.ACTCTX)),
					dwFlags = (Kernel32.ACTCTX_FLAGS.ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID | Kernel32.ACTCTX_FLAGS.ACTCTX_FLAG_RESOURCE_NAME_VALID),
					lpSource = name,
					lpAssemblyDirectory = assemblyDirectory,
					lpResourceName = (IntPtr)2,
					hModule = IntPtr.Zero
				};
				this.m_hActCtx = Kernel32.CreateActCtx(ref actctx);
				if (this.m_hActCtx == (IntPtr)(-1))
				{
					dwError = (uint)Marshal.GetLastWin32Error();
					this.m_hActCtx = IntPtr.Zero;
				}
			}
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000EE08 File Offset: 0x0000D008
		public void CallInContext(RegFreeCOMObject.Callback code)
		{
			object actCtxLock = RegFreeCOMObject.m_actCtxLock;
			lock (actCtxLock)
			{
				if (this.m_hActCtx == IntPtr.Zero)
				{
					throw new ObjectDisposedException("RegFreeCOMObject");
				}
				IntPtr lpCookie;
				Kernel32.ActivateActCtx(this.m_hActCtx, out lpCookie);
				try
				{
					code();
				}
				finally
				{
					Kernel32.DeactivateActCtx(0U, lpCookie);
				}
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000EE88 File Offset: 0x0000D088
		private RegFreeCOMObject()
		{
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000EE9C File Offset: 0x0000D09C
		public void Dispose()
		{
			object actCtxLock = RegFreeCOMObject.m_actCtxLock;
			lock (actCtxLock)
			{
				this.Dispose(true);
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000EEE4 File Offset: 0x0000D0E4
		protected virtual void Dispose(bool disposing)
		{
			if (this.m_hActCtx != IntPtr.Zero)
			{
				Kernel32.ReleaseActCtx(this.m_hActCtx);
				this.m_hActCtx = IntPtr.Zero;
			}
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x0000EF10 File Offset: 0x0000D110
		~RegFreeCOMObject()
		{
			this.Dispose(false);
		}

		// Token: 0x0400007B RID: 123
		private static object m_actCtxLock = new object();

		// Token: 0x0400007C RID: 124
		private IntPtr m_hActCtx = IntPtr.Zero;

		// Token: 0x02000118 RID: 280
		// (Invoke) Token: 0x06000587 RID: 1415
		public delegate void Callback();
	}
}
