using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Xmp
{
	// Token: 0x02000921 RID: 2337
	public class XmpMetadata : Resource
	{
		// Token: 0x06005F19 RID: 24345 RVA: 0x0035C3D0 File Offset: 0x0035B3D0
		public XmpMetadata()
		{
			this.a();
		}

		// Token: 0x06005F1A RID: 24346 RVA: 0x0035C3F8 File Offset: 0x0035B3F8
		internal new ArrayList c()
		{
			return this.a;
		}

		// Token: 0x06005F1B RID: 24347 RVA: 0x0035C410 File Offset: 0x0035B410
		internal new void a(CustomPropertyList A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06005F1C RID: 24348 RVA: 0x0035C41C File Offset: 0x0035B41C
		internal new PdfAStandard? e()
		{
			return this.g;
		}

		// Token: 0x17000A0A RID: 2570
		// (get) Token: 0x06005F1D RID: 24349 RVA: 0x0035C434 File Offset: 0x0035B434
		public DublinCoreSchema DublinCore
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x17000A0B RID: 2571
		// (get) Token: 0x06005F1E RID: 24350 RVA: 0x0035C44C File Offset: 0x0035B44C
		public BasicSchema BasicSchema
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x06005F1F RID: 24351 RVA: 0x0035C464 File Offset: 0x0035B464
		public void AddSchema(XmpSchema schema)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
			}
			this.a.Add(schema);
			if (schema.j0())
			{
				PdfASchema pdfASchema = (PdfASchema)schema;
				this.f = true;
				this.g = new PdfAStandard?(pdfASchema.a());
			}
		}

		// Token: 0x06005F20 RID: 24352 RVA: 0x0035C4C8 File Offset: 0x0035B4C8
		public override void Draw(DocumentWriter writer)
		{
			XmpWriter xmpWriter = new XmpWriter(writer);
			xmpWriter.f();
			if (this.a != null)
			{
				for (int i = 0; i < this.a.Count; i++)
				{
					((XmpSchema)this.a[i]).Draw(xmpWriter);
				}
			}
			this.b.Draw(xmpWriter);
			this.c.Draw(xmpWriter);
			this.d.Draw(xmpWriter);
			if (this.e != null && !this.f)
			{
				this.e.a(xmpWriter);
			}
			xmpWriter.g();
			xmpWriter.Draw(writer);
		}

		// Token: 0x17000A0C RID: 2572
		// (get) Token: 0x06005F21 RID: 24353 RVA: 0x0035C580 File Offset: 0x0035B580
		public override int RequiredPdfObjects
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06005F22 RID: 24354 RVA: 0x0035C593 File Offset: 0x0035B593
		private new void a()
		{
			this.b = new DublinCoreSchema();
			this.c = new BasicSchema();
			this.d = new ae8();
		}

		// Token: 0x040030EE RID: 12526
		private new ArrayList a;

		// Token: 0x040030EF RID: 12527
		private new DublinCoreSchema b;

		// Token: 0x040030F0 RID: 12528
		private new BasicSchema c;

		// Token: 0x040030F1 RID: 12529
		private new ae8 d;

		// Token: 0x040030F2 RID: 12530
		private new CustomPropertyList e;

		// Token: 0x040030F3 RID: 12531
		private new bool f = false;

		// Token: 0x040030F4 RID: 12532
		private new PdfAStandard? g = null;
	}
}
