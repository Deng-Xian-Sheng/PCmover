using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200011E RID: 286
	public class StockIcon : IDisposable
	{
		// Token: 0x06000C85 RID: 3205 RVA: 0x0002F7EC File Offset: 0x0002D9EC
		public StockIcon(StockIconIdentifier id)
		{
			this.identifier = id;
			this.invalidateIcon = true;
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x0002F828 File Offset: 0x0002DA28
		public StockIcon(StockIconIdentifier id, StockIconSize size, bool isLinkOverlay, bool isSelected)
		{
			this.identifier = id;
			this.linkOverlay = isLinkOverlay;
			this.selected = isSelected;
			this.currentSize = size;
			this.invalidateIcon = true;
		}

		// Token: 0x170007BA RID: 1978
		// (get) Token: 0x06000C87 RID: 3207 RVA: 0x0002F884 File Offset: 0x0002DA84
		// (set) Token: 0x06000C88 RID: 3208 RVA: 0x0002F89C File Offset: 0x0002DA9C
		public bool Selected
		{
			get
			{
				return this.selected;
			}
			set
			{
				this.selected = value;
				this.invalidateIcon = true;
			}
		}

		// Token: 0x170007BB RID: 1979
		// (get) Token: 0x06000C89 RID: 3209 RVA: 0x0002F8B0 File Offset: 0x0002DAB0
		// (set) Token: 0x06000C8A RID: 3210 RVA: 0x0002F8C8 File Offset: 0x0002DAC8
		public bool LinkOverlay
		{
			get
			{
				return this.linkOverlay;
			}
			set
			{
				this.linkOverlay = value;
				this.invalidateIcon = true;
			}
		}

		// Token: 0x170007BC RID: 1980
		// (get) Token: 0x06000C8B RID: 3211 RVA: 0x0002F8DC File Offset: 0x0002DADC
		// (set) Token: 0x06000C8C RID: 3212 RVA: 0x0002F8F4 File Offset: 0x0002DAF4
		public StockIconSize CurrentSize
		{
			get
			{
				return this.currentSize;
			}
			set
			{
				this.currentSize = value;
				this.invalidateIcon = true;
			}
		}

		// Token: 0x170007BD RID: 1981
		// (get) Token: 0x06000C8D RID: 3213 RVA: 0x0002F908 File Offset: 0x0002DB08
		// (set) Token: 0x06000C8E RID: 3214 RVA: 0x0002F920 File Offset: 0x0002DB20
		public StockIconIdentifier Identifier
		{
			get
			{
				return this.identifier;
			}
			set
			{
				this.identifier = value;
				this.invalidateIcon = true;
			}
		}

		// Token: 0x170007BE RID: 1982
		// (get) Token: 0x06000C8F RID: 3215 RVA: 0x0002F934 File Offset: 0x0002DB34
		public Bitmap Bitmap
		{
			get
			{
				this.UpdateHIcon();
				return (this.hIcon != IntPtr.Zero) ? Bitmap.FromHicon(this.hIcon) : null;
			}
		}

		// Token: 0x170007BF RID: 1983
		// (get) Token: 0x06000C90 RID: 3216 RVA: 0x0002F970 File Offset: 0x0002DB70
		public BitmapSource BitmapSource
		{
			get
			{
				this.UpdateHIcon();
				return (this.hIcon != IntPtr.Zero) ? Imaging.CreateBitmapSourceFromHIcon(this.hIcon, Int32Rect.Empty, null) : null;
			}
		}

		// Token: 0x170007C0 RID: 1984
		// (get) Token: 0x06000C91 RID: 3217 RVA: 0x0002F9B0 File Offset: 0x0002DBB0
		public Icon Icon
		{
			get
			{
				this.UpdateHIcon();
				return (this.hIcon != IntPtr.Zero) ? Icon.FromHandle(this.hIcon) : null;
			}
		}

		// Token: 0x06000C92 RID: 3218 RVA: 0x0002F9EC File Offset: 0x0002DBEC
		private void UpdateHIcon()
		{
			if (this.invalidateIcon)
			{
				if (this.hIcon != IntPtr.Zero)
				{
					CoreNativeMethods.DestroyIcon(this.hIcon);
				}
				this.hIcon = this.GetHIcon();
				this.invalidateIcon = false;
			}
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x0002FA40 File Offset: 0x0002DC40
		private IntPtr GetHIcon()
		{
			StockIconsNativeMethods.StockIconOptions stockIconOptions = StockIconsNativeMethods.StockIconOptions.Handle;
			if (this.CurrentSize == StockIconSize.Small)
			{
				stockIconOptions |= StockIconsNativeMethods.StockIconOptions.Small;
			}
			else if (this.CurrentSize == StockIconSize.ShellSize)
			{
				stockIconOptions |= StockIconsNativeMethods.StockIconOptions.ShellSize;
			}
			else
			{
				stockIconOptions = stockIconOptions;
			}
			if (this.Selected)
			{
				stockIconOptions |= StockIconsNativeMethods.StockIconOptions.Selected;
			}
			if (this.LinkOverlay)
			{
				stockIconOptions |= StockIconsNativeMethods.StockIconOptions.LinkOverlay;
			}
			StockIconsNativeMethods.StockIconInfo stockIconInfo = default(StockIconsNativeMethods.StockIconInfo);
			stockIconInfo.StuctureSize = (uint)Marshal.SizeOf(typeof(StockIconsNativeMethods.StockIconInfo));
			HResult hresult = StockIconsNativeMethods.SHGetStockIconInfo(this.identifier, stockIconOptions, ref stockIconInfo);
			IntPtr result;
			if (hresult != HResult.Ok)
			{
				if (hresult == HResult.InvalidArguments)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, LocalizedMessages.StockIconInvalidGuid, new object[]
					{
						this.identifier
					}));
				}
				result = IntPtr.Zero;
			}
			else
			{
				result = stockIconInfo.Handle;
			}
			return result;
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x0002FB4C File Offset: 0x0002DD4C
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
			if (this.hIcon != IntPtr.Zero)
			{
				CoreNativeMethods.DestroyIcon(this.hIcon);
			}
		}

		// Token: 0x06000C95 RID: 3221 RVA: 0x0002FB87 File Offset: 0x0002DD87
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x0002FB9C File Offset: 0x0002DD9C
		~StockIcon()
		{
			this.Dispose(false);
		}

		// Token: 0x04000482 RID: 1154
		private StockIconIdentifier identifier = StockIconIdentifier.Application;

		// Token: 0x04000483 RID: 1155
		private StockIconSize currentSize = StockIconSize.Large;

		// Token: 0x04000484 RID: 1156
		private bool linkOverlay;

		// Token: 0x04000485 RID: 1157
		private bool selected;

		// Token: 0x04000486 RID: 1158
		private bool invalidateIcon = true;

		// Token: 0x04000487 RID: 1159
		private IntPtr hIcon = IntPtr.Zero;
	}
}
