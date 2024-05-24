using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006F4 RID: 1780
	public class ImportedPageContents : Resource
	{
		// Token: 0x060044AA RID: 17578 RVA: 0x00235988 File Offset: 0x00234988
		public ImportedPageContents(string filePath, int pageNumber) : this(new PdfDocument(filePath).GetPage(pageNumber), PageBoundary.CropBox)
		{
		}

		// Token: 0x060044AB RID: 17579 RVA: 0x002359A0 File Offset: 0x002349A0
		public ImportedPageContents(PdfPage pdfPage) : this(pdfPage, PageBoundary.CropBox)
		{
		}

		// Token: 0x060044AC RID: 17580 RVA: 0x002359AD File Offset: 0x002349AD
		public ImportedPageContents(string filePath, int pageNumber, PageBoundary pageBoundary) : this(new PdfDocument(filePath).GetPage(pageNumber), pageBoundary)
		{
		}

		// Token: 0x060044AD RID: 17581 RVA: 0x002359C8 File Offset: 0x002349C8
		public ImportedPageContents(PdfPage pdfPage, PageBoundary pageBoundary)
		{
			this.c = pdfPage;
			this.SetBoundaries(pageBoundary);
		}

		// Token: 0x060044AE RID: 17582 RVA: 0x00235A19 File Offset: 0x00234A19
		public void SetBoundaries(PageBoundary pageBoundary)
		{
			this.d = this.c.i().a(pageBoundary);
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x060044AF RID: 17583 RVA: 0x00235A34 File Offset: 0x00234A34
		public override int RequiredPdfObjects
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x060044B0 RID: 17584 RVA: 0x00235A48 File Offset: 0x00234A48
		public override ResourceType ResourceType
		{
			get
			{
				return ResourceType.XObject;
			}
		}

		// Token: 0x060044B1 RID: 17585 RVA: 0x00235A5C File Offset: 0x00234A5C
		public override void Draw(DocumentWriter writer)
		{
			byte[] array = this.c.d().b();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.g);
			writer.WriteName(Resource.b);
			writer.WriteName(Resource.f);
			writer.WriteName(ImportedPageContents.a);
			writer.WriteArrayOpen();
			writer.WriteNumber(this.a());
			writer.WriteNumber(this.e());
			writer.WriteNumber(this.c());
			writer.WriteNumber(this.f());
			writer.WriteArrayClose();
			if (this.c.k() != null)
			{
				writer.WriteName(ImportedPageContents.b);
				this.c.k().a(writer, null);
			}
			if (array != null)
			{
				writer.WriteName(Resource.c);
				writer.WriteName(Resource.d);
				writer.WriteName(Resource.e);
				writer.ai(array.Length);
				writer.WriteDictionaryClose();
				writer.WriteStream(array, 0, array.Length);
			}
			if (array == null)
			{
				writer.WriteDictionaryClose();
			}
			writer.WriteEndObject();
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x060044B2 RID: 17586 RVA: 0x00235BA0 File Offset: 0x00234BA0
		// (set) Token: 0x060044B3 RID: 17587 RVA: 0x00235BB8 File Offset: 0x00234BB8
		public float ClipLeft
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x060044B4 RID: 17588 RVA: 0x00235BC4 File Offset: 0x00234BC4
		// (set) Token: 0x060044B5 RID: 17589 RVA: 0x00235BDC File Offset: 0x00234BDC
		public float ClipRight
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x060044B6 RID: 17590 RVA: 0x00235BE8 File Offset: 0x00234BE8
		// (set) Token: 0x060044B7 RID: 17591 RVA: 0x00235C00 File Offset: 0x00234C00
		public float ClipTop
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x060044B8 RID: 17592 RVA: 0x00235C0C File Offset: 0x00234C0C
		// (set) Token: 0x060044B9 RID: 17593 RVA: 0x00235C24 File Offset: 0x00234C24
		public float ClipBottom
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x060044BA RID: 17594 RVA: 0x00235C30 File Offset: 0x00234C30
		internal new float a()
		{
			return this.d.Left + this.ClipLeft;
		}

		// Token: 0x060044BB RID: 17595 RVA: 0x00235C54 File Offset: 0x00234C54
		internal new float c()
		{
			return this.d.Right - this.ClipRight;
		}

		// Token: 0x060044BC RID: 17596 RVA: 0x00235C78 File Offset: 0x00234C78
		internal new float e()
		{
			return this.d.Bottom - this.ClipTop;
		}

		// Token: 0x060044BD RID: 17597 RVA: 0x00235C9C File Offset: 0x00234C9C
		internal new float f()
		{
			return this.d.Top + this.ClipBottom;
		}

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x060044BE RID: 17598 RVA: 0x00235CC0 File Offset: 0x00234CC0
		public float Width
		{
			get
			{
				return this.c() - this.a();
			}
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x060044BF RID: 17599 RVA: 0x00235CE0 File Offset: 0x00234CE0
		public float Height
		{
			get
			{
				return this.e() - this.f();
			}
		}

		// Token: 0x060044C0 RID: 17600 RVA: 0x00235D00 File Offset: 0x00234D00
		internal new Dimensions i()
		{
			return this.d;
		}

		// Token: 0x060044C1 RID: 17601 RVA: 0x00235D18 File Offset: 0x00234D18
		internal PdfPage j()
		{
			return this.c;
		}

		// Token: 0x04002646 RID: 9798
		private new static byte[] a = new byte[]
		{
			66,
			66,
			111,
			120
		};

		// Token: 0x04002647 RID: 9799
		private new static byte[] b = new byte[]
		{
			82,
			101,
			115,
			111,
			117,
			114,
			99,
			101,
			115
		};

		// Token: 0x04002648 RID: 9800
		private new PdfPage c;

		// Token: 0x04002649 RID: 9801
		private new Dimensions d;

		// Token: 0x0400264A RID: 9802
		private new float e = 0f;

		// Token: 0x0400264B RID: 9803
		private new float f = 0f;

		// Token: 0x0400264C RID: 9804
		private new float g = 0f;

		// Token: 0x0400264D RID: 9805
		private new float h = 0f;
	}
}
