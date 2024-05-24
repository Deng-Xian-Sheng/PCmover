using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using CefSharp.Structs;

namespace CefSharp.OffScreen
{
	// Token: 0x02000002 RID: 2
	public class BitmapBuffer
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public int NumberOfBytes { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00000261
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00000269
		public int Width { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00000272
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000207A File Offset: 0x0000027A
		public int Height { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002083 File Offset: 0x00000283
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000208B File Offset: 0x0000028B
		public Rect DirtyRect { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002094 File Offset: 0x00000294
		// (set) Token: 0x0600000A RID: 10 RVA: 0x0000209C File Offset: 0x0000029C
		public object BitmapLock { get; private set; }

		// Token: 0x0600000B RID: 11 RVA: 0x000020A5 File Offset: 0x000002A5
		public BitmapBuffer(object bitmapLock)
		{
			this.BitmapLock = bitmapLock;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000020B4 File Offset: 0x000002B4
		public byte[] Buffer
		{
			get
			{
				return this.buffer;
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020BC File Offset: 0x000002BC
		private void ResizeBuffer(int width, int height)
		{
			if (this.buffer == null || width != this.Width || height != this.Height)
			{
				this.NumberOfBytes = width * height * 4;
				this.buffer = new byte[this.NumberOfBytes];
				this.Width = width;
				this.Height = height;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002110 File Offset: 0x00000310
		public void UpdateBuffer(int width, int height, IntPtr buffer, Rect dirtyRect)
		{
			object bitmapLock = this.BitmapLock;
			lock (bitmapLock)
			{
				this.DirtyRect = dirtyRect;
				this.ResizeBuffer(width, height);
				Marshal.Copy(buffer, this.buffer, 0, this.NumberOfBytes);
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002170 File Offset: 0x00000370
		public Bitmap CreateBitmap()
		{
			object bitmapLock = this.BitmapLock;
			Bitmap result;
			lock (bitmapLock)
			{
				if (this.Width == 0 || this.Height == 0 || this.buffer.Length == 0)
				{
					result = null;
				}
				else
				{
					Bitmap bitmap = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppPArgb);
					BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, this.Width, this.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
					Marshal.Copy(this.Buffer, 0, bitmapData.Scan0, this.NumberOfBytes);
					bitmap.UnlockBits(bitmapData);
					result = bitmap;
				}
			}
			return result;
		}

		// Token: 0x04000001 RID: 1
		private const int BytesPerPixel = 4;

		// Token: 0x04000002 RID: 2
		private const PixelFormat Format = PixelFormat.Format32bppPArgb;

		// Token: 0x04000003 RID: 3
		private byte[] buffer;
	}
}
