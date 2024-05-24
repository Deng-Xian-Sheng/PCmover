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
	// Token: 0x02000017 RID: 23
	public class ShellThumbnail
	{
		// Token: 0x060000B8 RID: 184 RVA: 0x00004AB4 File Offset: 0x00002CB4
		internal ShellThumbnail(ShellObject shellObject)
		{
			if (shellObject == null || shellObject.NativeShellItem == null)
			{
				throw new ArgumentNullException("shellObject");
			}
			this.shellItemNative = shellObject.NativeShellItem;
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00004B24 File Offset: 0x00002D24
		// (set) Token: 0x060000BA RID: 186 RVA: 0x00004B3C File Offset: 0x00002D3C
		public System.Windows.Size CurrentSize
		{
			get
			{
				return this.currentSize;
			}
			set
			{
				if (value.Height == 0.0 || value.Width == 0.0)
				{
					throw new ArgumentOutOfRangeException("value", LocalizedMessages.ShellThumbnailSizeCannotBe0);
				}
				System.Windows.Size size = (this.FormatOption == ShellThumbnailFormatOption.IconOnly) ? DefaultIconSize.Maximum : DefaultThumbnailSize.Maximum;
				if (value.Height > size.Height || value.Width > size.Width)
				{
					throw new ArgumentOutOfRangeException("value", string.Format(CultureInfo.InvariantCulture, LocalizedMessages.ShellThumbnailCurrentSizeRange, new object[]
					{
						size.ToString()
					}));
				}
				this.currentSize = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000BB RID: 187 RVA: 0x00004C08 File Offset: 0x00002E08
		public Bitmap Bitmap
		{
			get
			{
				return this.GetBitmap(this.CurrentSize);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00004C28 File Offset: 0x00002E28
		public BitmapSource BitmapSource
		{
			get
			{
				return this.GetBitmapSource(this.CurrentSize);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00004C48 File Offset: 0x00002E48
		public Icon Icon
		{
			get
			{
				return Icon.FromHandle(this.Bitmap.GetHicon());
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00004C6C File Offset: 0x00002E6C
		public Bitmap SmallBitmap
		{
			get
			{
				return this.GetBitmap(DefaultIconSize.Small, DefaultThumbnailSize.Small);
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00004C90 File Offset: 0x00002E90
		public BitmapSource SmallBitmapSource
		{
			get
			{
				return this.GetBitmapSource(DefaultIconSize.Small, DefaultThumbnailSize.Small);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00004CB4 File Offset: 0x00002EB4
		public Icon SmallIcon
		{
			get
			{
				return Icon.FromHandle(this.SmallBitmap.GetHicon());
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00004CD8 File Offset: 0x00002ED8
		public Bitmap MediumBitmap
		{
			get
			{
				return this.GetBitmap(DefaultIconSize.Medium, DefaultThumbnailSize.Medium);
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00004CFC File Offset: 0x00002EFC
		public BitmapSource MediumBitmapSource
		{
			get
			{
				return this.GetBitmapSource(DefaultIconSize.Medium, DefaultThumbnailSize.Medium);
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00004D20 File Offset: 0x00002F20
		public Icon MediumIcon
		{
			get
			{
				return Icon.FromHandle(this.MediumBitmap.GetHicon());
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00004D44 File Offset: 0x00002F44
		public Bitmap LargeBitmap
		{
			get
			{
				return this.GetBitmap(DefaultIconSize.Large, DefaultThumbnailSize.Large);
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00004D68 File Offset: 0x00002F68
		public BitmapSource LargeBitmapSource
		{
			get
			{
				return this.GetBitmapSource(DefaultIconSize.Large, DefaultThumbnailSize.Large);
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00004D8C File Offset: 0x00002F8C
		public Icon LargeIcon
		{
			get
			{
				return Icon.FromHandle(this.LargeBitmap.GetHicon());
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x00004DB0 File Offset: 0x00002FB0
		public Bitmap ExtraLargeBitmap
		{
			get
			{
				return this.GetBitmap(DefaultIconSize.ExtraLarge, DefaultThumbnailSize.ExtraLarge);
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00004DD4 File Offset: 0x00002FD4
		public BitmapSource ExtraLargeBitmapSource
		{
			get
			{
				return this.GetBitmapSource(DefaultIconSize.ExtraLarge, DefaultThumbnailSize.ExtraLarge);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00004DF8 File Offset: 0x00002FF8
		public Icon ExtraLargeIcon
		{
			get
			{
				return Icon.FromHandle(this.ExtraLargeBitmap.GetHicon());
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000CA RID: 202 RVA: 0x00004E1C File Offset: 0x0000301C
		// (set) Token: 0x060000CB RID: 203 RVA: 0x00004E33 File Offset: 0x00003033
		public ShellThumbnailRetrievalOption RetrievalOption { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000CC RID: 204 RVA: 0x00004E3C File Offset: 0x0000303C
		// (set) Token: 0x060000CD RID: 205 RVA: 0x00004E54 File Offset: 0x00003054
		public ShellThumbnailFormatOption FormatOption
		{
			get
			{
				return this.formatOption;
			}
			set
			{
				this.formatOption = value;
				if (this.FormatOption == ShellThumbnailFormatOption.IconOnly && (this.CurrentSize.Height > DefaultIconSize.Maximum.Height || this.CurrentSize.Width > DefaultIconSize.Maximum.Width))
				{
					this.CurrentSize = DefaultIconSize.Maximum;
				}
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000CE RID: 206 RVA: 0x00004ECC File Offset: 0x000030CC
		// (set) Token: 0x060000CF RID: 207 RVA: 0x00004EE3 File Offset: 0x000030E3
		public bool AllowBiggerSize { get; set; }

		// Token: 0x060000D0 RID: 208 RVA: 0x00004EEC File Offset: 0x000030EC
		private ShellNativeMethods.SIIGBF CalculateFlags()
		{
			ShellNativeMethods.SIIGBF siigbf = ShellNativeMethods.SIIGBF.ResizeToFit;
			if (this.AllowBiggerSize)
			{
				siigbf |= ShellNativeMethods.SIIGBF.BiggerSizeOk;
			}
			if (this.RetrievalOption == ShellThumbnailRetrievalOption.CacheOnly)
			{
				siigbf |= ShellNativeMethods.SIIGBF.InCacheOnly;
			}
			else if (this.RetrievalOption == ShellThumbnailRetrievalOption.MemoryOnly)
			{
				siigbf |= ShellNativeMethods.SIIGBF.MemoryOnly;
			}
			if (this.FormatOption == ShellThumbnailFormatOption.IconOnly)
			{
				siigbf |= ShellNativeMethods.SIIGBF.IconOnly;
			}
			else if (this.FormatOption == ShellThumbnailFormatOption.ThumbnailOnly)
			{
				siigbf |= ShellNativeMethods.SIIGBF.ThumbnailOnly;
			}
			return siigbf;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004F74 File Offset: 0x00003174
		private IntPtr GetHBitmap(System.Windows.Size size)
		{
			IntPtr zero = IntPtr.Zero;
			CoreNativeMethods.Size size2 = default(CoreNativeMethods.Size);
			size2.Width = Convert.ToInt32(size.Width);
			size2.Height = Convert.ToInt32(size.Height);
			HResult image = ((IShellItemImageFactory)this.shellItemNative).GetImage(size2, this.CalculateFlags(), out zero);
			if (image == HResult.Ok)
			{
				return zero;
			}
			if (image == (HResult)(-2147175936) && this.FormatOption == ShellThumbnailFormatOption.ThumbnailOnly)
			{
				throw new InvalidOperationException(LocalizedMessages.ShellThumbnailDoesNotHaveThumbnail, Marshal.GetExceptionForHR((int)image));
			}
			if (image == (HResult)(-2147221164))
			{
				throw new NotSupportedException(LocalizedMessages.ShellThumbnailNoHandler, Marshal.GetExceptionForHR((int)image));
			}
			throw new ShellException(image);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00005040 File Offset: 0x00003240
		private Bitmap GetBitmap(System.Windows.Size iconOnlySize, System.Windows.Size thumbnailSize)
		{
			return this.GetBitmap((this.FormatOption == ShellThumbnailFormatOption.IconOnly) ? iconOnlySize : thumbnailSize);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00005068 File Offset: 0x00003268
		private Bitmap GetBitmap(System.Windows.Size size)
		{
			IntPtr hbitmap = this.GetHBitmap(size);
			Bitmap result = Image.FromHbitmap(hbitmap);
			ShellNativeMethods.DeleteObject(hbitmap);
			return result;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00005094 File Offset: 0x00003294
		private BitmapSource GetBitmapSource(System.Windows.Size iconOnlySize, System.Windows.Size thumbnailSize)
		{
			return this.GetBitmapSource((this.FormatOption == ShellThumbnailFormatOption.IconOnly) ? iconOnlySize : thumbnailSize);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000050BC File Offset: 0x000032BC
		private BitmapSource GetBitmapSource(System.Windows.Size size)
		{
			IntPtr hbitmap = this.GetHBitmap(size);
			BitmapSource result = Imaging.CreateBitmapSourceFromHBitmap(hbitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
			ShellNativeMethods.DeleteObject(hbitmap);
			return result;
		}

		// Token: 0x04000029 RID: 41
		private IShellItem shellItemNative;

		// Token: 0x0400002A RID: 42
		private System.Windows.Size currentSize = new System.Windows.Size(256.0, 256.0);

		// Token: 0x0400002B RID: 43
		private ShellThumbnailFormatOption formatOption = ShellThumbnailFormatOption.Default;
	}
}
