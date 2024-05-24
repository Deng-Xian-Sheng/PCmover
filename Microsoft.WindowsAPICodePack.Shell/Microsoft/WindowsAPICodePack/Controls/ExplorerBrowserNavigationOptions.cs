using System;
using Microsoft.WindowsAPICodePack.Controls.WindowsForms;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x0200003A RID: 58
	public class ExplorerBrowserNavigationOptions
	{
		// Token: 0x0600024E RID: 590 RVA: 0x0000A738 File Offset: 0x00008938
		internal ExplorerBrowserNavigationOptions(ExplorerBrowser eb)
		{
			this.eb = eb;
			this.PaneVisibility = new ExplorerBrowserPaneVisibility();
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600024F RID: 591 RVA: 0x0000A758 File Offset: 0x00008958
		// (set) Token: 0x06000250 RID: 592 RVA: 0x0000A798 File Offset: 0x00008998
		public ExplorerBrowserNavigateOptions Flags
		{
			get
			{
				ExplorerBrowserOptions explorerBrowserOptions = (ExplorerBrowserOptions)0;
				ExplorerBrowserNavigateOptions result;
				if (this.eb.explorerBrowserControl != null)
				{
					this.eb.explorerBrowserControl.GetOptions(out explorerBrowserOptions);
					result = (ExplorerBrowserNavigateOptions)explorerBrowserOptions;
				}
				else
				{
					result = (ExplorerBrowserNavigateOptions)explorerBrowserOptions;
				}
				return result;
			}
			set
			{
				if (this.eb.explorerBrowserControl != null)
				{
					this.eb.explorerBrowserControl.SetOptions((ExplorerBrowserOptions)(value | (ExplorerBrowserNavigateOptions)2));
				}
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000251 RID: 593 RVA: 0x0000A7D0 File Offset: 0x000089D0
		// (set) Token: 0x06000252 RID: 594 RVA: 0x0000A7E9 File Offset: 0x000089E9
		public bool NavigateOnce
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserNavigateOptions.NavigateOnce);
			}
			set
			{
				this.SetFlag(ExplorerBrowserNavigateOptions.NavigateOnce, value);
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000253 RID: 595 RVA: 0x0000A7F8 File Offset: 0x000089F8
		// (set) Token: 0x06000254 RID: 596 RVA: 0x0000A811 File Offset: 0x00008A11
		public bool AlwaysNavigate
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserNavigateOptions.AlwaysNavigate);
			}
			set
			{
				this.SetFlag(ExplorerBrowserNavigateOptions.AlwaysNavigate, value);
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000A820 File Offset: 0x00008A20
		private bool IsFlagSet(ExplorerBrowserNavigateOptions flag)
		{
			return (this.Flags & flag) != (ExplorerBrowserNavigateOptions)0;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000A840 File Offset: 0x00008A40
		private void SetFlag(ExplorerBrowserNavigateOptions flag, bool value)
		{
			if (value)
			{
				this.Flags |= flag;
			}
			else
			{
				this.Flags &= ~flag;
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000257 RID: 599 RVA: 0x0000A87C File Offset: 0x00008A7C
		// (set) Token: 0x06000258 RID: 600 RVA: 0x0000A893 File Offset: 0x00008A93
		public ExplorerBrowserPaneVisibility PaneVisibility { get; private set; }

		// Token: 0x040000D4 RID: 212
		private ExplorerBrowser eb;
	}
}
