using System;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Controls.WindowsForms;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls
{
	// Token: 0x0200002C RID: 44
	public class ExplorerBrowserContentOptions
	{
		// Token: 0x060001EB RID: 491 RVA: 0x0000972B File Offset: 0x0000792B
		internal ExplorerBrowserContentOptions(ExplorerBrowser eb)
		{
			this.eb = eb;
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00009748 File Offset: 0x00007948
		// (set) Token: 0x060001ED RID: 493 RVA: 0x00009768 File Offset: 0x00007968
		public ExplorerBrowserViewMode ViewMode
		{
			get
			{
				return (ExplorerBrowserViewMode)this.folderSettings.ViewMode;
			}
			set
			{
				this.folderSettings.ViewMode = (FolderViewMode)value;
				if (this.eb.explorerBrowserControl != null)
				{
					this.eb.explorerBrowserControl.SetFolderSettings(this.folderSettings);
				}
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001EE RID: 494 RVA: 0x000097B0 File Offset: 0x000079B0
		// (set) Token: 0x060001EF RID: 495 RVA: 0x000097D0 File Offset: 0x000079D0
		public ExplorerBrowserContentSectionOptions Flags
		{
			get
			{
				return (ExplorerBrowserContentSectionOptions)this.folderSettings.Options;
			}
			set
			{
				this.folderSettings.Options = (FolderOptions)(value | (ExplorerBrowserContentSectionOptions)1073741824 | (ExplorerBrowserContentSectionOptions)65536);
				if (this.eb.explorerBrowserControl != null)
				{
					this.eb.explorerBrowserControl.SetFolderSettings(this.folderSettings);
				}
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00009824 File Offset: 0x00007A24
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x00009841 File Offset: 0x00007A41
		public bool AlignLeft
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserContentSectionOptions.AlignLeft);
			}
			set
			{
				this.SetFlag(ExplorerBrowserContentSectionOptions.AlignLeft, value);
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x00009854 File Offset: 0x00007A54
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x0000986D File Offset: 0x00007A6D
		public bool AutoArrange
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserContentSectionOptions.AutoArrange);
			}
			set
			{
				this.SetFlag(ExplorerBrowserContentSectionOptions.AutoArrange, value);
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x0000987C File Offset: 0x00007A7C
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x00009899 File Offset: 0x00007A99
		public bool CheckSelect
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserContentSectionOptions.CheckSelect);
			}
			set
			{
				this.SetFlag(ExplorerBrowserContentSectionOptions.CheckSelect, value);
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x000098AC File Offset: 0x00007AAC
		// (set) Token: 0x060001F7 RID: 503 RVA: 0x000098C9 File Offset: 0x00007AC9
		public bool ExtendedTiles
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserContentSectionOptions.ExtendedTiles);
			}
			set
			{
				this.SetFlag(ExplorerBrowserContentSectionOptions.ExtendedTiles, value);
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x000098DC File Offset: 0x00007ADC
		// (set) Token: 0x060001F9 RID: 505 RVA: 0x000098F9 File Offset: 0x00007AF9
		public bool FullRowSelect
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserContentSectionOptions.FullRowSelect);
			}
			set
			{
				this.SetFlag(ExplorerBrowserContentSectionOptions.FullRowSelect, value);
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001FA RID: 506 RVA: 0x0000990C File Offset: 0x00007B0C
		// (set) Token: 0x060001FB RID: 507 RVA: 0x00009929 File Offset: 0x00007B29
		public bool HideFileNames
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserContentSectionOptions.HideFileNames);
			}
			set
			{
				this.SetFlag(ExplorerBrowserContentSectionOptions.HideFileNames, value);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001FC RID: 508 RVA: 0x0000993C File Offset: 0x00007B3C
		// (set) Token: 0x060001FD RID: 509 RVA: 0x00009959 File Offset: 0x00007B59
		public bool NoBrowserViewState
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserContentSectionOptions.NoBrowserViewState);
			}
			set
			{
				this.SetFlag(ExplorerBrowserContentSectionOptions.NoBrowserViewState, value);
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001FE RID: 510 RVA: 0x0000996C File Offset: 0x00007B6C
		// (set) Token: 0x060001FF RID: 511 RVA: 0x00009989 File Offset: 0x00007B89
		public bool NoColumnHeader
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserContentSectionOptions.NoColumnHeader);
			}
			set
			{
				this.SetFlag(ExplorerBrowserContentSectionOptions.NoColumnHeader, value);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000200 RID: 512 RVA: 0x0000999C File Offset: 0x00007B9C
		// (set) Token: 0x06000201 RID: 513 RVA: 0x000099B9 File Offset: 0x00007BB9
		public bool NoHeaderInAllViews
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserContentSectionOptions.NoHeaderInAllViews);
			}
			set
			{
				this.SetFlag(ExplorerBrowserContentSectionOptions.NoHeaderInAllViews, value);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000202 RID: 514 RVA: 0x000099CC File Offset: 0x00007BCC
		// (set) Token: 0x06000203 RID: 515 RVA: 0x000099E9 File Offset: 0x00007BE9
		public bool NoIcons
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserContentSectionOptions.NoIcons);
			}
			set
			{
				this.SetFlag(ExplorerBrowserContentSectionOptions.NoIcons, value);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000204 RID: 516 RVA: 0x000099FC File Offset: 0x00007BFC
		// (set) Token: 0x06000205 RID: 517 RVA: 0x00009A19 File Offset: 0x00007C19
		public bool NoSubfolders
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserContentSectionOptions.NoSubfolders);
			}
			set
			{
				this.SetFlag(ExplorerBrowserContentSectionOptions.NoSubfolders, value);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000206 RID: 518 RVA: 0x00009A2C File Offset: 0x00007C2C
		// (set) Token: 0x06000207 RID: 519 RVA: 0x00009A49 File Offset: 0x00007C49
		public bool SingleClickActivate
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserContentSectionOptions.SingleClickActivate);
			}
			set
			{
				this.SetFlag(ExplorerBrowserContentSectionOptions.SingleClickActivate, value);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000208 RID: 520 RVA: 0x00009A5C File Offset: 0x00007C5C
		// (set) Token: 0x06000209 RID: 521 RVA: 0x00009A76 File Offset: 0x00007C76
		public bool SingleSelection
		{
			get
			{
				return this.IsFlagSet(ExplorerBrowserContentSectionOptions.SingleSelection);
			}
			set
			{
				this.SetFlag(ExplorerBrowserContentSectionOptions.SingleSelection, value);
			}
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00009A84 File Offset: 0x00007C84
		private bool IsFlagSet(ExplorerBrowserContentSectionOptions flag)
		{
			return (this.folderSettings.Options & (FolderOptions)flag) != (FolderOptions)0;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00009AAC File Offset: 0x00007CAC
		private void SetFlag(ExplorerBrowserContentSectionOptions flag, bool value)
		{
			if (value)
			{
				this.folderSettings.Options |= (FolderOptions)flag;
			}
			else
			{
				this.folderSettings.Options = (this.folderSettings.Options & (FolderOptions)(~(FolderOptions)flag));
			}
			if (this.eb.explorerBrowserControl != null)
			{
				this.eb.explorerBrowserControl.SetFolderSettings(this.folderSettings);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00009B1C File Offset: 0x00007D1C
		// (set) Token: 0x0600020D RID: 525 RVA: 0x00009B90 File Offset: 0x00007D90
		public int ThumbnailSize
		{
			get
			{
				int result = 0;
				IFolderView2 folderView = this.eb.GetFolderView2();
				if (folderView != null)
				{
					try
					{
						int num = 0;
						HResult viewModeAndIconSize = folderView.GetViewModeAndIconSize(out num, out result);
						if (viewModeAndIconSize != HResult.Ok)
						{
							throw new CommonControlException(LocalizedMessages.ExplorerBrowserIconSize, viewModeAndIconSize);
						}
					}
					finally
					{
						Marshal.ReleaseComObject(folderView);
						folderView = null;
					}
				}
				return result;
			}
			set
			{
				IFolderView2 folderView = this.eb.GetFolderView2();
				if (folderView != null)
				{
					try
					{
						int uViewMode = 0;
						int num = 0;
						HResult hresult = folderView.GetViewModeAndIconSize(out uViewMode, out num);
						if (hresult != HResult.Ok)
						{
							throw new CommonControlException(LocalizedMessages.ExplorerBrowserIconSize, hresult);
						}
						hresult = folderView.SetViewModeAndIconSize(uViewMode, value);
						if (hresult != HResult.Ok)
						{
							throw new CommonControlException(LocalizedMessages.ExplorerBrowserIconSize, hresult);
						}
					}
					finally
					{
						Marshal.ReleaseComObject(folderView);
						folderView = null;
					}
				}
			}
		}

		// Token: 0x04000093 RID: 147
		private ExplorerBrowser eb;

		// Token: 0x04000094 RID: 148
		internal FolderSettings folderSettings = new FolderSettings();
	}
}
