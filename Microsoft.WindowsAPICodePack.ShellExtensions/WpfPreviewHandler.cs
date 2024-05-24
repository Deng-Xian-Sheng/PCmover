using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.ShellExtensions.Interop;
using Microsoft.WindowsAPICodePack.ShellExtensions.Resources;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
	// Token: 0x0200000F RID: 15
	public abstract class WpfPreviewHandler : PreviewHandler, IDisposable
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00002CD4 File Offset: 0x00000ED4
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002CEB File Offset: 0x00000EEB
		public UserControl Control { get; protected set; }

		// Token: 0x06000053 RID: 83 RVA: 0x00002CF4 File Offset: 0x00000EF4
		protected void ThrowIfNoControl()
		{
			if (this.Control == null)
			{
				throw new InvalidOperationException(LocalizedMessages.PreviewHandlerControlNotInitialized);
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002D20 File Offset: 0x00000F20
		protected void UpdatePlacement()
		{
			if (this._source != null)
			{
				HandlerNativeMethods.SetParent(this._source.Handle, this._parentHandle);
				HandlerNativeMethods.SetWindowPos(this._source.Handle, new IntPtr(0), 0, 0, Math.Abs(this._bounds.Left - this._bounds.Right), Math.Abs(this._bounds.Top - this._bounds.Bottom), SetWindowPositionOptions.ShowWindow);
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002DA7 File Offset: 0x00000FA7
		protected override void SetParentHandle(IntPtr handle)
		{
			this._parentHandle = handle;
			this.UpdatePlacement();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002DB8 File Offset: 0x00000FB8
		protected override void Initialize()
		{
			if (this._source == null)
			{
				this.ThrowIfNoControl();
				this._source = new HwndSource(new HwndSourceParameters
				{
					WindowStyle = 1409286144,
					ParentWindow = this._parentHandle,
					Width = Math.Abs(this._bounds.Left - this._bounds.Right),
					Height = Math.Abs(this._bounds.Top - this._bounds.Bottom)
				});
				this._source.CompositionTarget.BackgroundColor = Brushes.WhiteSmoke.Color;
				this._source.RootVisual = (Visual)this.Control.Content;
			}
			this.UpdatePlacement();
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002E98 File Offset: 0x00001098
		protected override IntPtr Handle
		{
			get
			{
				if (this._source == null)
				{
					throw new InvalidOperationException(LocalizedMessages.WpfPreviewHandlerNoHandle);
				}
				return this._source.Handle;
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00002ED2 File Offset: 0x000010D2
		protected override void UpdateBounds(NativeRect bounds)
		{
			this._bounds = bounds;
			this.UpdatePlacement();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002EE4 File Offset: 0x000010E4
		protected override void HandleInitializeException(Exception caughtException)
		{
			if (caughtException != null)
			{
				TextBox content = new TextBox
				{
					IsReadOnly = true,
					MaxLines = 20,
					Text = caughtException.ToString()
				};
				this.Control = new UserControl
				{
					Content = content
				};
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002F3C File Offset: 0x0000113C
		protected override void SetFocus()
		{
			this.Control.Focus();
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00002F4C File Offset: 0x0000114C
		protected override void SetBackground(int argb)
		{
			this.Control.Background = new SolidColorBrush(Color.FromArgb((byte)(argb >> 24 & 255), (byte)(argb >> 16 & 255), (byte)(argb >> 8 & 255), (byte)(argb & 255)));
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00002F98 File Offset: 0x00001198
		protected override void SetForeground(int argb)
		{
			this.Control.Foreground = new SolidColorBrush(Color.FromArgb((byte)(argb >> 24 & 255), (byte)(argb >> 16 & 255), (byte)(argb >> 8 & 255), (byte)(argb & 255)));
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002FE4 File Offset: 0x000011E4
		protected override void SetFont(LogFont font)
		{
			if (font == null)
			{
				throw new ArgumentNullException("font");
			}
			this.Control.FontFamily = new FontFamily(font.FaceName);
			this.Control.FontSize = (double)font.Height;
			this.Control.FontWeight = ((font.Weight > 0 && font.Weight < 1000) ? FontWeight.FromOpenTypeWeight(font.Weight) : FontWeights.Normal);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003068 File Offset: 0x00001268
		~WpfPreviewHandler()
		{
			this.Dispose(false);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000309C File Offset: 0x0000129C
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000030B0 File Offset: 0x000012B0
		protected virtual void Dispose(bool disposing)
		{
			if (disposing && this._source != null)
			{
				this._source.Dispose();
			}
		}

		// Token: 0x0400000A RID: 10
		private HwndSource _source = null;

		// Token: 0x0400000B RID: 11
		private IntPtr _parentHandle = IntPtr.Zero;

		// Token: 0x0400000C RID: 12
		private NativeRect _bounds;
	}
}
