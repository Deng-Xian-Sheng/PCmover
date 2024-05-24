using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Imaging
{
	// Token: 0x02000876 RID: 2166
	public class BitmapImageData : ImageData
	{
		// Token: 0x0600581C RID: 22556 RVA: 0x00332924 File Offset: 0x00331924
		public BitmapImageData(string filePath)
		{
			Bitmap bitmap = new Bitmap(filePath);
			this.g(bitmap);
			bitmap.Dispose();
		}

		// Token: 0x0600581D RID: 22557 RVA: 0x00332957 File Offset: 0x00331957
		public BitmapImageData(Stream stream) : this(new Bitmap(stream))
		{
		}

		// Token: 0x0600581E RID: 22558 RVA: 0x00332968 File Offset: 0x00331968
		public BitmapImageData(Bitmap bitmap)
		{
			this.g(bitmap);
		}

		// Token: 0x170008C0 RID: 2240
		// (get) Token: 0x0600581F RID: 22559 RVA: 0x00332984 File Offset: 0x00331984
		public override int RequiredPdfObjects
		{
			get
			{
				return this.e;
			}
		}

		// Token: 0x170008C1 RID: 2241
		// (get) Token: 0x06005820 RID: 22560 RVA: 0x0033299C File Offset: 0x0033199C
		public override int Width
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170008C2 RID: 2242
		// (get) Token: 0x06005821 RID: 22561 RVA: 0x003329B4 File Offset: 0x003319B4
		public override int Height
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x170008C3 RID: 2243
		// (get) Token: 0x06005822 RID: 22562 RVA: 0x003329CC File Offset: 0x003319CC
		public override float ScaleX
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x170008C4 RID: 2244
		// (get) Token: 0x06005823 RID: 22563 RVA: 0x003329E4 File Offset: 0x003319E4
		public override float ScaleY
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x06005824 RID: 22564 RVA: 0x003329FC File Offset: 0x003319FC
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.g);
			writer.WriteName(Resource.b);
			writer.WriteName(Resource.h);
			if (base.Interpolate)
			{
				writer.WriteName(ImageData.a);
				writer.WriteBoolean(true);
			}
			writer.WriteName(ImageData.b);
			writer.WriteNumber(this.a);
			writer.WriteName(ImageData.c);
			writer.WriteNumber(this.b);
			writer.WriteName(ImageData.d);
			writer.WriteNumber(this.f);
			if (this.g == 1)
			{
				if (this.j == null)
				{
					writer.WriteName(ImageData.e);
					writer.WriteName(ImageData.f);
				}
				else
				{
					writer.WriteName(ImageData.e);
					writer.WriteArrayOpen();
					writer.WriteName(ImageData.i);
					writer.WriteName(ImageData.g);
					writer.WriteNumber(this.j.Length / 3 - 1);
					writer.WriteReference(writer.GetObjectNumber(1));
					writer.WriteArrayClose();
				}
			}
			else if (this.j == null)
			{
				writer.WriteName(ImageData.e);
				writer.WriteName(ImageData.g);
				if (this.i != null)
				{
					writer.WriteName(ImageData.l);
					writer.WriteReference(writer.GetObjectNumber(1));
				}
			}
			else
			{
				writer.WriteName(ImageData.e);
				writer.WriteArrayOpen();
				writer.WriteName(ImageData.i);
				writer.WriteName(ImageData.g);
				writer.WriteNumber(this.j.Length / 3 - 1);
				writer.WriteReference(writer.GetObjectNumber(1));
				writer.WriteArrayClose();
			}
			writer.WriteName(Resource.c);
			writer.WriteArrayOpen();
			writer.WriteName(Resource.d);
			writer.WriteArrayClose();
			writer.WriteName(Resource.e);
			writer.ai(this.h.Length);
			writer.WriteDictionaryClose();
			writer.WriteStream(this.h, this.h.Length);
			writer.WriteEndObject();
			if (this.j != null)
			{
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				writer.WriteName(Resource.e);
				writer.ai(this.j.Length);
				writer.WriteDictionaryClose();
				writer.WriteStream(this.j, this.j.Length);
				writer.WriteEndObject();
			}
			if (this.i != null)
			{
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				writer.WriteName(Resource.a);
				writer.WriteName(Resource.g);
				writer.WriteName(Resource.b);
				writer.WriteName(Resource.h);
				writer.WriteName(ImageData.a);
				writer.WriteBoolean(true);
				writer.WriteName(ImageData.b);
				writer.WriteNumber(this.a);
				writer.WriteName(ImageData.c);
				writer.WriteNumber(this.b);
				writer.WriteName(ImageData.d);
				writer.WriteNumber(8);
				writer.WriteName(ImageData.e);
				writer.WriteName(ImageData.f);
				writer.WriteName(Resource.c);
				writer.WriteArrayOpen();
				writer.WriteName(Resource.d);
				writer.WriteArrayClose();
				writer.WriteName(Resource.e);
				writer.ai(this.i.Length);
				writer.WriteDictionaryClose();
				writer.WriteStream(this.i, this.i.Length);
				writer.WriteEndObject();
			}
		}

		// Token: 0x06005825 RID: 22565 RVA: 0x00332DE4 File Offset: 0x00331DE4
		private new void g(Bitmap A_0)
		{
			this.a = A_0.Width;
			this.b = A_0.Height;
			this.c = 72f / A_0.HorizontalResolution;
			this.d = 72f / A_0.VerticalResolution;
			PixelFormat pixelFormat = A_0.PixelFormat;
			if (pixelFormat <= PixelFormat.Format8bppIndexed)
			{
				if (pixelFormat == PixelFormat.Format1bppIndexed)
				{
					this.f(A_0);
					return;
				}
				if (pixelFormat == PixelFormat.Format4bppIndexed)
				{
					this.e(A_0);
					return;
				}
				if (pixelFormat == PixelFormat.Format8bppIndexed)
				{
					this.d(A_0);
					return;
				}
			}
			else
			{
				if (pixelFormat != PixelFormat.Format16bppGrayScale)
				{
					if (pixelFormat != PixelFormat.Format32bppArgb)
					{
						if (pixelFormat != PixelFormat.Format64bppArgb)
						{
							goto IL_B6;
						}
					}
					this.a(A_0);
					return;
				}
				this.c(A_0);
				return;
			}
			IL_B6:
			this.b(A_0);
		}

		// Token: 0x06005826 RID: 22566 RVA: 0x00332EB4 File Offset: 0x00331EB4
		[SecuritySafeCritical]
		private new void f(Bitmap A_0)
		{
			this.g = 1;
			this.f = 1;
			int num = this.a / 8;
			if (this.a % 8 != 0)
			{
				num++;
			}
			BitmapData bitmapData = A_0.LockBits(new Rectangle(0, 0, this.a, this.b), ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);
			IntPtr scan = bitmapData.Scan0;
			this.h = new byte[num * this.b];
			if (bitmapData.Stride == num)
			{
				Marshal.Copy(scan, this.h, 0, this.h.Length);
			}
			else
			{
				byte[] array = new byte[bitmapData.Stride * this.b];
				Marshal.Copy(scan, array, 0, array.Length);
				for (int i = 0; i < this.b; i++)
				{
					Array.Copy(array, bitmapData.Stride * i, this.h, num * i, num);
				}
			}
			A_0.UnlockBits(bitmapData);
			this.c();
			this.a(A_0.Palette);
		}

		// Token: 0x06005827 RID: 22567 RVA: 0x00332FCC File Offset: 0x00331FCC
		[SecuritySafeCritical]
		private new void e(Bitmap A_0)
		{
			this.g = 3;
			this.f = 4;
			int num = this.a / 2 + this.a % 2;
			BitmapData bitmapData = A_0.LockBits(new Rectangle(0, 0, this.a, this.b), ImageLockMode.ReadOnly, PixelFormat.Format4bppIndexed);
			IntPtr scan = bitmapData.Scan0;
			this.h = new byte[num * this.b];
			if (bitmapData.Stride == num)
			{
				Marshal.Copy(scan, this.h, 0, this.h.Length);
			}
			else
			{
				byte[] array = new byte[bitmapData.Stride * this.b];
				Marshal.Copy(scan, array, 0, array.Length);
				for (int i = 0; i < this.b; i++)
				{
					Array.Copy(array, bitmapData.Stride * i, this.h, num * i, num);
				}
			}
			A_0.UnlockBits(bitmapData);
			this.c();
			this.a(A_0.Palette);
		}

		// Token: 0x06005828 RID: 22568 RVA: 0x003330D8 File Offset: 0x003320D8
		[SecuritySafeCritical]
		private new void d(Bitmap A_0)
		{
			this.g = 3;
			this.f = 8;
			BitmapData bitmapData = A_0.LockBits(new Rectangle(0, 0, this.a, this.b), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
			IntPtr scan = bitmapData.Scan0;
			this.h = new byte[this.a * this.b];
			if (bitmapData.Stride == this.a)
			{
				Marshal.Copy(scan, this.h, 0, this.h.Length);
			}
			else
			{
				byte[] array = new byte[bitmapData.Stride * this.b];
				Marshal.Copy(scan, array, 0, array.Length);
				for (int i = 0; i < this.b; i++)
				{
					Array.Copy(array, bitmapData.Stride * i, this.h, this.a * i, this.a);
				}
			}
			A_0.UnlockBits(bitmapData);
			this.c();
			this.a(A_0.Palette);
		}

		// Token: 0x06005829 RID: 22569 RVA: 0x003331E0 File Offset: 0x003321E0
		private new void a(ColorPalette A_0)
		{
			this.j = new byte[A_0.Entries.Length * 3];
			int num = 0;
			foreach (Color color in A_0.Entries)
			{
				this.j[num++] = color.R;
				this.j[num++] = color.G;
				this.j[num++] = color.B;
			}
			this.e = 2;
		}

		// Token: 0x0600582A RID: 22570 RVA: 0x00333270 File Offset: 0x00332270
		[SecuritySafeCritical]
		private new void c(Bitmap A_0)
		{
			this.g = 1;
			this.f = 8;
			BitmapData bitmapData = A_0.LockBits(new Rectangle(0, 0, this.a, this.b), ImageLockMode.ReadOnly, PixelFormat.Format16bppGrayScale);
			IntPtr scan = bitmapData.Scan0;
			byte[] array = new byte[this.a * 2 * this.b];
			if (bitmapData.Stride == this.a * 2)
			{
				Marshal.Copy(scan, array, 0, array.Length);
			}
			else
			{
				byte[] array2 = new byte[bitmapData.Stride * this.b];
				Marshal.Copy(scan, array2, 0, array2.Length);
				for (int i = 0; i < this.b; i++)
				{
					Array.Copy(array2, bitmapData.Stride * i, array, this.a * i * 2, this.a * 2);
				}
			}
			A_0.UnlockBits(bitmapData);
			this.h = new byte[array.Length / 2];
			for (int j = 0; j < this.h.Length; j++)
			{
				this.h[j] = array[j * 2];
			}
			this.c();
		}

		// Token: 0x0600582B RID: 22571 RVA: 0x003333A0 File Offset: 0x003323A0
		[SecuritySafeCritical]
		private new void b(Bitmap A_0)
		{
			this.g = 3;
			this.f = 8;
			BitmapData bitmapData = A_0.LockBits(new Rectangle(0, 0, this.a, this.b), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
			IntPtr scan = bitmapData.Scan0;
			this.h = new byte[this.a * 3 * this.b];
			if (bitmapData.Stride == this.a * 3)
			{
				Marshal.Copy(scan, this.h, 0, this.h.Length);
			}
			else
			{
				byte[] array = new byte[bitmapData.Stride * this.b];
				Marshal.Copy(scan, array, 0, array.Length);
				for (int i = 0; i < this.b; i++)
				{
					Array.Copy(array, bitmapData.Stride * i, this.h, this.a * i * 3, this.a * 3);
				}
			}
			A_0.UnlockBits(bitmapData);
			for (int j = 0; j < this.h.Length; j += 3)
			{
				byte b = this.h[j];
				this.h[j] = this.h[j + 2];
				this.h[j + 2] = b;
			}
			this.c();
		}

		// Token: 0x0600582C RID: 22572 RVA: 0x003334EC File Offset: 0x003324EC
		[SecuritySafeCritical]
		private new void a(Bitmap A_0)
		{
			this.g = 3;
			this.f = 8;
			this.e = 2;
			BitmapData bitmapData = A_0.LockBits(new Rectangle(0, 0, this.a, this.b), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			IntPtr scan = bitmapData.Scan0;
			byte[] array = new byte[this.a * this.b * 4];
			this.h = new byte[this.a * this.b * 3];
			this.i = new byte[this.a * this.b];
			if (bitmapData.Stride == this.a * 4)
			{
				Marshal.Copy(scan, array, 0, array.Length);
			}
			else
			{
				byte[] array2 = new byte[bitmapData.Stride * this.b];
				Marshal.Copy(scan, array2, 0, array2.Length);
				for (int i = 0; i < this.b; i++)
				{
					Array.Copy(array2, bitmapData.Stride * i, this.h, this.a * i * 4, this.a * 4);
				}
			}
			A_0.UnlockBits(bitmapData);
			int num = 0;
			int num2 = 0;
			for (int j = 0; j < array.Length; j += 4)
			{
				this.h[num++] = array[j + 2];
				this.h[num++] = array[j + 1];
				this.h[num++] = array[j];
				this.i[num2++] = array[j + 3];
			}
			this.c();
			this.a();
		}

		// Token: 0x0600582D RID: 22573 RVA: 0x00333694 File Offset: 0x00332694
		private new void c()
		{
			y0 y = new y0();
			y.b(this.h, 0, this.h.Length);
			y.b();
			byte[] array = new byte[(int)((float)this.h.Length * 1.002f + 12f)];
			int num = y.a(array);
			this.h = new byte[num];
			Array.Copy(array, 0, this.h, 0, num);
		}

		// Token: 0x0600582E RID: 22574 RVA: 0x00333708 File Offset: 0x00332708
		private new void a()
		{
			y0 y = new y0();
			y.b(this.i, 0, this.i.Length);
			y.b();
			byte[] array = new byte[(int)((float)this.i.Length * 1.002f + 12f)];
			int num = y.a(array);
			this.i = new byte[num];
			Array.Copy(array, 0, this.i, 0, num);
		}

		// Token: 0x0600582F RID: 22575 RVA: 0x0033377C File Offset: 0x0033277C
		internal override byte[] gs()
		{
			return this.h;
		}

		// Token: 0x04002EC8 RID: 11976
		private new int a;

		// Token: 0x04002EC9 RID: 11977
		private new int b;

		// Token: 0x04002ECA RID: 11978
		private new float c;

		// Token: 0x04002ECB RID: 11979
		private new float d;

		// Token: 0x04002ECC RID: 11980
		private new int e = 1;

		// Token: 0x04002ECD RID: 11981
		private new int f;

		// Token: 0x04002ECE RID: 11982
		private new int g;

		// Token: 0x04002ECF RID: 11983
		private new byte[] h;

		// Token: 0x04002ED0 RID: 11984
		private new byte[] i;

		// Token: 0x04002ED1 RID: 11985
		private new byte[] j;
	}
}
