using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Controls;
using Microsoft.WindowsAPICodePack.Controls.WindowsForms;

namespace MS.WindowsAPICodePack.Internal
{
	// Token: 0x02000030 RID: 48
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class ExplorerBrowserViewEvents : IDisposable
	{
		// Token: 0x06000219 RID: 537 RVA: 0x00009CB8 File Offset: 0x00007EB8
		public ExplorerBrowserViewEvents() : this(null)
		{
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00009CC4 File Offset: 0x00007EC4
		internal ExplorerBrowserViewEvents(ExplorerBrowser parent)
		{
			this.parent = parent;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00009D04 File Offset: 0x00007F04
		internal void ConnectToView(IShellView psv)
		{
			this.DisconnectFromView();
			HResult hresult = psv.GetItemObject(ShellViewGetItemObject.Background, ref this.IID_IDispatch, out this.viewDispatch);
			if (hresult == HResult.Ok)
			{
				hresult = ExplorerBrowserNativeMethods.ConnectToConnectionPoint(this, ref this.IID_DShellFolderViewEvents, true, this.viewDispatch, ref this.viewConnectionPointCookie, ref this.nullPtr);
				if (hresult != HResult.Ok)
				{
					Marshal.ReleaseComObject(this.viewDispatch);
				}
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00009D70 File Offset: 0x00007F70
		internal void DisconnectFromView()
		{
			if (this.viewDispatch != null)
			{
				ExplorerBrowserNativeMethods.ConnectToConnectionPoint(IntPtr.Zero, ref this.IID_DShellFolderViewEvents, false, this.viewDispatch, ref this.viewConnectionPointCookie, ref this.nullPtr);
				Marshal.ReleaseComObject(this.viewDispatch);
				this.viewDispatch = null;
				this.viewConnectionPointCookie = 0U;
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00009DD0 File Offset: 0x00007FD0
		[DispId(200)]
		public void ViewSelectionChanged()
		{
			this.parent.FireSelectionChanged();
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00009DDF File Offset: 0x00007FDF
		[DispId(207)]
		public void ViewContentsChanged()
		{
			this.parent.FireContentChanged();
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00009DEE File Offset: 0x00007FEE
		[DispId(201)]
		public void ViewFileListEnumDone()
		{
			this.parent.FireContentEnumerationComplete();
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00009DFD File Offset: 0x00007FFD
		[DispId(220)]
		public void ViewSelectedItemChanged()
		{
			this.parent.FireSelectedItemChanged();
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00009E0C File Offset: 0x0000800C
		~ExplorerBrowserViewEvents()
		{
			this.Dispose(false);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00009E40 File Offset: 0x00008040
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00009E54 File Offset: 0x00008054
		protected virtual void Dispose(bool disposed)
		{
			if (disposed)
			{
				this.DisconnectFromView();
			}
		}

		// Token: 0x04000099 RID: 153
		private uint viewConnectionPointCookie;

		// Token: 0x0400009A RID: 154
		private object viewDispatch;

		// Token: 0x0400009B RID: 155
		private IntPtr nullPtr = IntPtr.Zero;

		// Token: 0x0400009C RID: 156
		private Guid IID_DShellFolderViewEvents = new Guid("62112AA2-EBE4-11cf-A5FB-0020AFE7292D");

		// Token: 0x0400009D RID: 157
		private Guid IID_IDispatch = new Guid("00020400-0000-0000-C000-000000000046");

		// Token: 0x0400009E RID: 158
		private ExplorerBrowser parent;
	}
}
