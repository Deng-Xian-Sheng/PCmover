using System;
using System.Runtime.InteropServices;
using Laplink.Tools.NativeMethods;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000002 RID: 2
	internal class RegFreeCOMObject : IDisposable
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
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

		// Token: 0x06000002 RID: 2 RVA: 0x00002124 File Offset: 0x00000324
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

		// Token: 0x06000003 RID: 3 RVA: 0x000021A4 File Offset: 0x000003A4
		private RegFreeCOMObject()
		{
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000021B8 File Offset: 0x000003B8
		public void Dispose()
		{
			object actCtxLock = RegFreeCOMObject.m_actCtxLock;
			lock (actCtxLock)
			{
				this.Dispose(true);
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002200 File Offset: 0x00000400
		protected virtual void Dispose(bool disposing)
		{
			if (this.m_hActCtx != IntPtr.Zero)
			{
				Kernel32.ReleaseActCtx(this.m_hActCtx);
				this.m_hActCtx = IntPtr.Zero;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000222C File Offset: 0x0000042C
		~RegFreeCOMObject()
		{
			this.Dispose(false);
		}

		// Token: 0x04000001 RID: 1
		private static object m_actCtxLock = new object();

		// Token: 0x04000002 RID: 2
		private IntPtr m_hActCtx = IntPtr.Zero;

		// Token: 0x0200000B RID: 11
		// (Invoke) Token: 0x0600003A RID: 58
		public delegate void Callback();
	}
}
