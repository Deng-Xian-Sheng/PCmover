using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200069A RID: 1690
	public class ExtendedPageDimensions : PageDimensions
	{
		// Token: 0x06004023 RID: 16419 RVA: 0x00220A23 File Offset: 0x0021FA23
		public ExtendedPageDimensions(Dimensions edge, Dimensions body) : this(edge, edge.a(), edge.a(), edge.a(), body, body.a())
		{
		}

		// Token: 0x06004024 RID: 16420 RVA: 0x00220A48 File Offset: 0x0021FA48
		public ExtendedPageDimensions(Dimensions edge, Dimensions bleedBox, Dimensions trimBox, Dimensions body) : this(edge, edge.a(), bleedBox, trimBox, body, body.a())
		{
		}

		// Token: 0x06004025 RID: 16421 RVA: 0x00220A65 File Offset: 0x0021FA65
		public ExtendedPageDimensions(Dimensions mediaBox, Dimensions cropBox, Dimensions bleedBox, Dimensions trimBox, Dimensions artBox) : this(mediaBox, cropBox, bleedBox, trimBox, artBox, artBox.a())
		{
		}

		// Token: 0x06004026 RID: 16422 RVA: 0x00220A80 File Offset: 0x0021FA80
		public ExtendedPageDimensions(Dimensions mediaBox, Dimensions cropBox, Dimensions bleedBox, Dimensions trimBox, Dimensions artBox, Dimensions body) : base(cropBox, body)
		{
			if (mediaBox == null)
			{
				mediaBox = new Dimensions(0f, 0f, 0f, 0f);
			}
			this.a = mediaBox;
			if (bleedBox == null)
			{
				bleedBox = new Dimensions(0f, 0f, 0f, 0f);
			}
			this.b = bleedBox;
			if (trimBox == null)
			{
				trimBox = new Dimensions(0f, 0f, 0f, 0f);
			}
			this.c = trimBox;
			if (artBox == null)
			{
				artBox = new Dimensions(0f, 0f, 0f, 0f);
			}
			this.d = artBox;
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06004027 RID: 16423 RVA: 0x00220B60 File Offset: 0x0021FB60
		public Dimensions CropBox
		{
			get
			{
				return base.Edge;
			}
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06004028 RID: 16424 RVA: 0x00220B78 File Offset: 0x0021FB78
		public Dimensions ArtBox
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06004029 RID: 16425 RVA: 0x00220B90 File Offset: 0x0021FB90
		public Dimensions MediaBox
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x0600402A RID: 16426 RVA: 0x00220BA8 File Offset: 0x0021FBA8
		public Dimensions BleedBox
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x0600402B RID: 16427 RVA: 0x00220BC0 File Offset: 0x0021FBC0
		public Dimensions TrimBox
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x0600402C RID: 16428 RVA: 0x00220BD8 File Offset: 0x0021FBD8
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteName(ExtendedPageDimensions.e);
			writer.WriteArrayOpen();
			writer.WriteNumber(this.MediaBox.Left);
			writer.WriteNumber(this.MediaBox.Top);
			writer.WriteNumber(this.MediaBox.Right);
			writer.WriteNumber(this.MediaBox.Bottom);
			writer.WriteArrayClose();
			if (!this.MediaBox.Equals(this.CropBox))
			{
				writer.WriteName(ExtendedPageDimensions.f);
				writer.WriteArrayOpen();
				writer.WriteNumber(base.Edge.Left);
				writer.WriteNumber(base.Edge.Top);
				writer.WriteNumber(base.Edge.Right);
				writer.WriteNumber(base.Edge.Bottom);
				writer.WriteArrayClose();
			}
			if (!this.CropBox.Equals(this.BleedBox))
			{
				writer.WriteName(ExtendedPageDimensions.g);
				writer.WriteArrayOpen();
				writer.WriteNumber(this.BleedBox.Left);
				writer.WriteNumber(this.BleedBox.Top);
				writer.WriteNumber(this.BleedBox.Right);
				writer.WriteNumber(this.BleedBox.Bottom);
				writer.WriteArrayClose();
			}
			if (!this.CropBox.Equals(this.TrimBox))
			{
				writer.WriteName(ExtendedPageDimensions.h);
				writer.WriteArrayOpen();
				writer.WriteNumber(this.TrimBox.Left);
				writer.WriteNumber(this.TrimBox.Top);
				writer.WriteNumber(this.TrimBox.Right);
				writer.WriteNumber(this.TrimBox.Bottom);
				writer.WriteArrayClose();
			}
			if (!this.CropBox.Equals(this.ArtBox))
			{
				writer.WriteName(ExtendedPageDimensions.i);
				writer.WriteArrayOpen();
				writer.WriteNumber(this.ArtBox.Left);
				writer.WriteNumber(this.ArtBox.Top);
				writer.WriteNumber(this.ArtBox.Right);
				writer.WriteNumber(this.ArtBox.Bottom);
				writer.WriteArrayClose();
			}
			if (!this.CropBox.Equals(base.Body))
			{
				writer.WriteName(ExtendedPageDimensions.j);
				writer.WriteArrayOpen();
				writer.WriteNumber(base.Body.Left);
				writer.WriteNumber(base.Body.Top);
				writer.WriteNumber(base.Body.Right);
				writer.WriteNumber(base.Body.Bottom);
				writer.WriteArrayClose();
			}
		}

		// Token: 0x0600402D RID: 16429 RVA: 0x00220EA8 File Offset: 0x0021FEA8
		public override float GetPdfY(float y)
		{
			return base.Edge.Bottom + base.Edge.Top - base.Body.Top - y;
		}

		// Token: 0x04002395 RID: 9109
		private Dimensions a;

		// Token: 0x04002396 RID: 9110
		private Dimensions b;

		// Token: 0x04002397 RID: 9111
		private Dimensions c;

		// Token: 0x04002398 RID: 9112
		private Dimensions d;

		// Token: 0x04002399 RID: 9113
		private static byte[] e = new byte[]
		{
			77,
			101,
			100,
			105,
			97,
			66,
			111,
			120
		};

		// Token: 0x0400239A RID: 9114
		private static byte[] f = new byte[]
		{
			67,
			114,
			111,
			112,
			66,
			111,
			120
		};

		// Token: 0x0400239B RID: 9115
		private static byte[] g = new byte[]
		{
			66,
			108,
			101,
			101,
			100,
			66,
			111,
			120
		};

		// Token: 0x0400239C RID: 9116
		private static byte[] h = new byte[]
		{
			84,
			114,
			105,
			109,
			66,
			111,
			120
		};

		// Token: 0x0400239D RID: 9117
		private static byte[] i = new byte[]
		{
			65,
			114,
			116,
			66,
			111,
			120
		};

		// Token: 0x0400239E RID: 9118
		private static byte[] j = new byte[]
		{
			68,
			80,
			68,
			70,
			66,
			111,
			100,
			121,
			66,
			111,
			120
		};
	}
}
