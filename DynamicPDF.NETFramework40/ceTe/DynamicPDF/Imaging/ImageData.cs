using System;
using System.IO;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF.Imaging
{
	// Token: 0x02000875 RID: 2165
	public abstract class ImageData : Resource
	{
		// Token: 0x06005809 RID: 22537 RVA: 0x00332438 File Offset: 0x00331438
		public static ImageData GetImage(string filePath)
		{
			string text = System.IO.Path.GetExtension(filePath).ToLower();
			if (text.Length > 2)
			{
				text = text.Substring(1, text.Length - 1);
				ImageData result;
				if (PngImageData.IsValid(text))
				{
					result = new PngImageData(filePath);
				}
				else if (JpegImageData.IsValid(text))
				{
					result = new JpegImageData(filePath);
				}
				else if (GifImageData.IsValid(text))
				{
					result = new GifImageData(filePath);
				}
				else if (TiffFile.IsValid(text))
				{
					result = new TiffFile(filePath).FirstImage;
				}
				else if (Jpeg2000ImageData.IsValid(text))
				{
					result = new Jpeg2000ImageData(filePath);
				}
				else
				{
					result = new BitmapImageData(filePath);
				}
				return result;
			}
			throw new GeneratorException("Invalid file extension.");
		}

		// Token: 0x0600580A RID: 22538 RVA: 0x00332500 File Offset: 0x00331500
		public static ImageData GetImage(Stream stream)
		{
			byte[] array = new byte[16];
			if (stream.Position != 0L)
			{
				stream.Seek(0L, SeekOrigin.Begin);
			}
			stream.Read(array, 0, 16);
			stream.Seek(0L, SeekOrigin.Begin);
			ImageData result;
			if (PngImageData.IsValid(array))
			{
				result = new PngImageData(stream);
			}
			else if (JpegImageData.IsValid(array))
			{
				result = new JpegImageData(stream);
			}
			else if (GifImageData.IsValid(array))
			{
				result = new GifImageData(stream);
			}
			else if (TiffFile.IsValid(array))
			{
				result = new TiffFile(stream).FirstImage;
			}
			else if (Jpeg2000ImageData.IsValid(array))
			{
				result = new Jpeg2000ImageData(stream);
			}
			else
			{
				result = new BitmapImageData(stream);
			}
			return result;
		}

		// Token: 0x0600580B RID: 22539 RVA: 0x003325C0 File Offset: 0x003315C0
		public static ImageData GetImage(byte[] data)
		{
			byte[] array = new byte[16];
			Array.Copy(data, array, 16);
			MemoryStream stream = new MemoryStream(data);
			ImageData result;
			if (PngImageData.IsValid(array))
			{
				result = new PngImageData(stream);
			}
			else if (JpegImageData.IsValid(array))
			{
				result = new JpegImageData(stream);
			}
			else if (GifImageData.IsValid(array))
			{
				result = new GifImageData(stream);
			}
			else if (TiffFile.IsValid(array))
			{
				result = new TiffFile(stream).FirstImage;
			}
			else if (Jpeg2000ImageData.IsValid(array))
			{
				result = new Jpeg2000ImageData(stream);
			}
			else
			{
				result = new BitmapImageData(stream);
			}
			return result;
		}

		// Token: 0x170008B8 RID: 2232
		// (get) Token: 0x0600580C RID: 22540
		public abstract int Width { get; }

		// Token: 0x170008B9 RID: 2233
		// (get) Token: 0x0600580D RID: 22541
		public abstract int Height { get; }

		// Token: 0x170008BA RID: 2234
		// (get) Token: 0x0600580E RID: 22542
		public abstract float ScaleX { get; }

		// Token: 0x170008BB RID: 2235
		// (get) Token: 0x0600580F RID: 22543
		public abstract float ScaleY { get; }

		// Token: 0x170008BC RID: 2236
		// (get) Token: 0x06005810 RID: 22544 RVA: 0x00332664 File Offset: 0x00331664
		public float HorizontalDpi
		{
			get
			{
				return 72f / this.ScaleX;
			}
		}

		// Token: 0x170008BD RID: 2237
		// (get) Token: 0x06005811 RID: 22545 RVA: 0x00332684 File Offset: 0x00331684
		public float VerticalDpi
		{
			get
			{
				return 72f / this.ScaleY;
			}
		}

		// Token: 0x06005812 RID: 22546 RVA: 0x003326A4 File Offset: 0x003316A4
		public float GetPointWidth()
		{
			return (float)this.Width * this.ScaleX;
		}

		// Token: 0x06005813 RID: 22547 RVA: 0x003326C4 File Offset: 0x003316C4
		public float GetPointHeight()
		{
			return (float)this.Height * this.ScaleY;
		}

		// Token: 0x06005814 RID: 22548 RVA: 0x003326E4 File Offset: 0x003316E4
		public Page GetPage(float margins)
		{
			return new Page(this.GetPointWidth() + margins * 2f, this.GetPointHeight() + margins * 2f, margins)
			{
				Elements = 
				{
					new BackgroundImage(this)
				}
			};
		}

		// Token: 0x06005815 RID: 22549 RVA: 0x0033272C File Offset: 0x0033172C
		public Page GetPage()
		{
			return new Page(this.GetPointWidth(), this.GetPointHeight(), 0f)
			{
				Elements = 
				{
					new BackgroundImage(this)
				}
			};
		}

		// Token: 0x06005816 RID: 22550 RVA: 0x00332768 File Offset: 0x00331768
		public virtual void Draw(OperatorWriter writer, float pdfX, float pdfY, float width, float height)
		{
			writer.SetGraphicsMode();
			writer.Write_q_(false);
			writer.Write_cm(width, 0f, 0f, height, pdfX, pdfY);
			writer.Write_Do(this);
			writer.Write_Q(false);
		}

		// Token: 0x170008BE RID: 2238
		// (get) Token: 0x06005817 RID: 22551 RVA: 0x003327A4 File Offset: 0x003317A4
		// (set) Token: 0x06005818 RID: 22552 RVA: 0x003327BC File Offset: 0x003317BC
		public bool Interpolate
		{
			get
			{
				return this.n;
			}
			set
			{
				this.n = value;
			}
		}

		// Token: 0x06005819 RID: 22553 RVA: 0x003327C8 File Offset: 0x003317C8
		internal virtual byte[] gs()
		{
			return null;
		}

		// Token: 0x170008BF RID: 2239
		// (get) Token: 0x0600581A RID: 22554 RVA: 0x003327DC File Offset: 0x003317DC
		public override ResourceType ResourceType
		{
			get
			{
				return ResourceType.XObject;
			}
		}

		// Token: 0x04002EBA RID: 11962
		internal new static byte[] a = new byte[]
		{
			73,
			110,
			116,
			101,
			114,
			112,
			111,
			108,
			97,
			116,
			101
		};

		// Token: 0x04002EBB RID: 11963
		internal new static byte[] b = new byte[]
		{
			87,
			105,
			100,
			116,
			104
		};

		// Token: 0x04002EBC RID: 11964
		internal new static byte[] c = new byte[]
		{
			72,
			101,
			105,
			103,
			104,
			116
		};

		// Token: 0x04002EBD RID: 11965
		internal new static byte[] d = new byte[]
		{
			66,
			105,
			116,
			115,
			80,
			101,
			114,
			67,
			111,
			109,
			112,
			111,
			110,
			101,
			110,
			116
		};

		// Token: 0x04002EBE RID: 11966
		internal new static byte[] e = new byte[]
		{
			67,
			111,
			108,
			111,
			114,
			83,
			112,
			97,
			99,
			101
		};

		// Token: 0x04002EBF RID: 11967
		internal new static byte[] f = new byte[]
		{
			68,
			101,
			118,
			105,
			99,
			101,
			71,
			114,
			97,
			121
		};

		// Token: 0x04002EC0 RID: 11968
		internal new static byte[] g = new byte[]
		{
			68,
			101,
			118,
			105,
			99,
			101,
			82,
			71,
			66
		};

		// Token: 0x04002EC1 RID: 11969
		internal new static byte[] h = new byte[]
		{
			77,
			97,
			115,
			107
		};

		// Token: 0x04002EC2 RID: 11970
		internal new static byte[] i = new byte[]
		{
			73,
			110,
			100,
			101,
			120,
			101,
			100
		};

		// Token: 0x04002EC3 RID: 11971
		internal static byte[] j = new byte[]
		{
			68,
			101,
			99,
			111,
			100,
			101,
			80,
			97,
			114,
			109,
			115
		};

		// Token: 0x04002EC4 RID: 11972
		internal static byte[] k = new byte[]
		{
			68,
			101,
			118,
			105,
			99,
			101,
			67,
			77,
			89,
			75
		};

		// Token: 0x04002EC5 RID: 11973
		internal static byte[] l = new byte[]
		{
			83,
			77,
			97,
			115,
			107
		};

		// Token: 0x04002EC6 RID: 11974
		internal static byte[] m = new byte[]
		{
			73,
			67,
			67,
			66,
			97,
			115,
			101,
			100
		};

		// Token: 0x04002EC7 RID: 11975
		private bool n = false;
	}
}
