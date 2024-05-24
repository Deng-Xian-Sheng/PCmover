using System;
using System.Drawing;
using Microsoft.WindowsAPICodePack.Shell;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x0200018A RID: 394
	public sealed class ThumbnailToolBarButton : IDisposable
	{
		// Token: 0x1400003A RID: 58
		// (add) Token: 0x06000F71 RID: 3953 RVA: 0x00036FBC File Offset: 0x000351BC
		// (remove) Token: 0x06000F72 RID: 3954 RVA: 0x00036FF8 File Offset: 0x000351F8
		public event EventHandler<ThumbnailButtonClickedEventArgs> Click;

		// Token: 0x06000F73 RID: 3955 RVA: 0x00037034 File Offset: 0x00035234
		public ThumbnailToolBarButton(Icon icon, string tooltip)
		{
			this.internalUpdate = true;
			this.Id = ThumbnailToolBarButton.nextId;
			if (ThumbnailToolBarButton.nextId == 2147483647U)
			{
				ThumbnailToolBarButton.nextId = 101U;
			}
			else
			{
				ThumbnailToolBarButton.nextId += 1U;
			}
			this.Icon = icon;
			this.Tooltip = tooltip;
			this.Enabled = true;
			this.win32ThumbButton = default(ThumbButton);
			this.internalUpdate = false;
		}

		// Token: 0x17000886 RID: 2182
		// (get) Token: 0x06000F74 RID: 3956 RVA: 0x000370CC File Offset: 0x000352CC
		// (set) Token: 0x06000F75 RID: 3957 RVA: 0x000370E3 File Offset: 0x000352E3
		internal uint Id { get; set; }

		// Token: 0x17000887 RID: 2183
		// (get) Token: 0x06000F76 RID: 3958 RVA: 0x000370EC File Offset: 0x000352EC
		// (set) Token: 0x06000F77 RID: 3959 RVA: 0x00037104 File Offset: 0x00035304
		public Icon Icon
		{
			get
			{
				return this.icon;
			}
			set
			{
				if (this.icon != value)
				{
					this.icon = value;
					this.UpdateThumbnailButton();
				}
			}
		}

		// Token: 0x17000888 RID: 2184
		// (get) Token: 0x06000F78 RID: 3960 RVA: 0x00037130 File Offset: 0x00035330
		// (set) Token: 0x06000F79 RID: 3961 RVA: 0x00037148 File Offset: 0x00035348
		public string Tooltip
		{
			get
			{
				return this.tooltip;
			}
			set
			{
				if (this.tooltip != value)
				{
					this.tooltip = value;
					this.UpdateThumbnailButton();
				}
			}
		}

		// Token: 0x17000889 RID: 2185
		// (get) Token: 0x06000F7A RID: 3962 RVA: 0x0003717C File Offset: 0x0003537C
		// (set) Token: 0x06000F7B RID: 3963 RVA: 0x0003719C File Offset: 0x0003539C
		public bool Visible
		{
			get
			{
				return (this.Flags & ThumbButtonOptions.Hidden) == ThumbButtonOptions.Enabled;
			}
			set
			{
				if (this.visible != value)
				{
					this.visible = value;
					if (value)
					{
						this.Flags &= ~ThumbButtonOptions.Hidden;
					}
					else
					{
						this.Flags |= ThumbButtonOptions.Hidden;
					}
					this.UpdateThumbnailButton();
				}
			}
		}

		// Token: 0x1700088A RID: 2186
		// (get) Token: 0x06000F7C RID: 3964 RVA: 0x000371F4 File Offset: 0x000353F4
		// (set) Token: 0x06000F7D RID: 3965 RVA: 0x00037214 File Offset: 0x00035414
		public bool Enabled
		{
			get
			{
				return (this.Flags & ThumbButtonOptions.Disabled) == ThumbButtonOptions.Enabled;
			}
			set
			{
				if (value != this.enabled)
				{
					this.enabled = value;
					if (value)
					{
						this.Flags &= ~ThumbButtonOptions.Disabled;
					}
					else
					{
						this.Flags |= ThumbButtonOptions.Disabled;
					}
					this.UpdateThumbnailButton();
				}
			}
		}

		// Token: 0x1700088B RID: 2187
		// (get) Token: 0x06000F7E RID: 3966 RVA: 0x0003726C File Offset: 0x0003546C
		// (set) Token: 0x06000F7F RID: 3967 RVA: 0x0003728C File Offset: 0x0003548C
		public bool DismissOnClick
		{
			get
			{
				return (this.Flags & ThumbButtonOptions.DismissOnClick) == ThumbButtonOptions.Enabled;
			}
			set
			{
				if (value != this.dismissOnClick)
				{
					this.dismissOnClick = value;
					if (value)
					{
						this.Flags |= ThumbButtonOptions.DismissOnClick;
					}
					else
					{
						this.Flags &= ~ThumbButtonOptions.DismissOnClick;
					}
					this.UpdateThumbnailButton();
				}
			}
		}

		// Token: 0x1700088C RID: 2188
		// (get) Token: 0x06000F80 RID: 3968 RVA: 0x000372E4 File Offset: 0x000354E4
		// (set) Token: 0x06000F81 RID: 3969 RVA: 0x00037304 File Offset: 0x00035504
		public bool IsInteractive
		{
			get
			{
				return (this.Flags & ThumbButtonOptions.NonInteractive) == ThumbButtonOptions.Enabled;
			}
			set
			{
				if (value != this.isInteractive)
				{
					this.isInteractive = value;
					if (value)
					{
						this.Flags &= ~ThumbButtonOptions.NonInteractive;
					}
					else
					{
						this.Flags |= ThumbButtonOptions.NonInteractive;
					}
					this.UpdateThumbnailButton();
				}
			}
		}

		// Token: 0x1700088D RID: 2189
		// (get) Token: 0x06000F82 RID: 3970 RVA: 0x00037360 File Offset: 0x00035560
		// (set) Token: 0x06000F83 RID: 3971 RVA: 0x00037377 File Offset: 0x00035577
		internal ThumbButtonOptions Flags { get; set; }

		// Token: 0x1700088E RID: 2190
		// (get) Token: 0x06000F84 RID: 3972 RVA: 0x00037380 File Offset: 0x00035580
		internal ThumbButton Win32ThumbButton
		{
			get
			{
				this.win32ThumbButton.Id = this.Id;
				this.win32ThumbButton.Tip = this.Tooltip;
				this.win32ThumbButton.Icon = ((this.Icon != null) ? this.Icon.Handle : IntPtr.Zero);
				this.win32ThumbButton.Flags = this.Flags;
				this.win32ThumbButton.Mask = ThumbButtonMask.THB_FLAGS;
				if (this.Tooltip != null)
				{
					this.win32ThumbButton.Mask = (this.win32ThumbButton.Mask | ThumbButtonMask.Tooltip);
				}
				if (this.Icon != null)
				{
					this.win32ThumbButton.Mask = (this.win32ThumbButton.Mask | ThumbButtonMask.Icon);
				}
				return this.win32ThumbButton;
			}
		}

		// Token: 0x06000F85 RID: 3973 RVA: 0x00037444 File Offset: 0x00035644
		internal void FireClick(TaskbarWindow taskbarWindow)
		{
			if (this.Click != null && taskbarWindow != null)
			{
				if (taskbarWindow.UserWindowHandle != IntPtr.Zero)
				{
					this.Click(this, new ThumbnailButtonClickedEventArgs(taskbarWindow.UserWindowHandle, this));
				}
				else if (taskbarWindow.WindowsControl != null)
				{
					this.Click(this, new ThumbnailButtonClickedEventArgs(taskbarWindow.WindowsControl, this));
				}
			}
		}

		// Token: 0x1700088F RID: 2191
		// (get) Token: 0x06000F86 RID: 3974 RVA: 0x000374C4 File Offset: 0x000356C4
		// (set) Token: 0x06000F87 RID: 3975 RVA: 0x000374DB File Offset: 0x000356DB
		internal IntPtr WindowHandle { get; set; }

		// Token: 0x17000890 RID: 2192
		// (get) Token: 0x06000F88 RID: 3976 RVA: 0x000374E4 File Offset: 0x000356E4
		// (set) Token: 0x06000F89 RID: 3977 RVA: 0x000374FB File Offset: 0x000356FB
		internal bool AddedToTaskbar { get; set; }

		// Token: 0x06000F8A RID: 3978 RVA: 0x00037504 File Offset: 0x00035704
		internal void UpdateThumbnailButton()
		{
			if (!this.internalUpdate && this.AddedToTaskbar)
			{
				ThumbButton[] pButtons = new ThumbButton[]
				{
					this.Win32ThumbButton
				};
				HResult result = TaskbarList.Instance.ThumbBarUpdateButtons(this.WindowHandle, 1U, pButtons);
				if (!CoreErrorHelper.Succeeded(result))
				{
					throw new ShellException(result);
				}
			}
		}

		// Token: 0x06000F8B RID: 3979 RVA: 0x0003756C File Offset: 0x0003576C
		~ThumbnailToolBarButton()
		{
			this.Dispose(false);
		}

		// Token: 0x06000F8C RID: 3980 RVA: 0x000375A0 File Offset: 0x000357A0
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000F8D RID: 3981 RVA: 0x000375B4 File Offset: 0x000357B4
		public void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Icon.Dispose();
				this.tooltip = null;
			}
		}

		// Token: 0x04000683 RID: 1667
		private static uint nextId = 101U;

		// Token: 0x04000684 RID: 1668
		private ThumbButton win32ThumbButton;

		// Token: 0x04000686 RID: 1670
		private bool internalUpdate = false;

		// Token: 0x04000687 RID: 1671
		private Icon icon;

		// Token: 0x04000688 RID: 1672
		private string tooltip;

		// Token: 0x04000689 RID: 1673
		private bool visible = true;

		// Token: 0x0400068A RID: 1674
		private bool enabled = true;

		// Token: 0x0400068B RID: 1675
		private bool dismissOnClick;

		// Token: 0x0400068C RID: 1676
		private bool isInteractive = true;
	}
}
