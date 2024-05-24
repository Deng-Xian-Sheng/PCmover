using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200063B RID: 1595
	public class Annotation : Resource
	{
		// Token: 0x06003BA9 RID: 15273 RVA: 0x001FCCFC File Offset: 0x001FBCFC
		public Annotation(float left, float top, float right, float bottom, IAnnotation iAnnotation)
		{
			this.a = left;
			this.b = right;
			this.c = top;
			this.d = bottom;
			this.e = iAnnotation;
		}

		// Token: 0x06003BAA RID: 15274 RVA: 0x001FCD4C File Offset: 0x001FBD4C
		internal Annotation(float A_0, float A_1, float A_2, float A_3, Watermark A_4)
		{
			this.a = A_0;
			this.b = A_2;
			this.c = A_1;
			this.d = A_3;
			this.e = A_4;
			this.k = A_4;
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06003BAB RID: 15275 RVA: 0x001FCDA4 File Offset: 0x001FBDA4
		public override int RequiredPdfObjects
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06003BAC RID: 15276 RVA: 0x001FCDB8 File Offset: 0x001FBDB8
		public override ResourceType ResourceType
		{
			get
			{
				return ResourceType.Annotation;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06003BAD RID: 15277 RVA: 0x001FCDCC File Offset: 0x001FBDCC
		public float Left
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06003BAE RID: 15278 RVA: 0x001FCDE4 File Offset: 0x001FBDE4
		public float Right
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06003BAF RID: 15279 RVA: 0x001FCDFC File Offset: 0x001FBDFC
		public float Top
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06003BB0 RID: 15280 RVA: 0x001FCE14 File Offset: 0x001FBE14
		public float Bottom
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x06003BB1 RID: 15281 RVA: 0x001FCE2C File Offset: 0x001FBE2C
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Annotation.f);
			if (this.k != null)
			{
				this.k.kj(this.b, this.c);
			}
			this.e.DrawAnnotation(writer);
			if (writer.Document.Tag != null && this.j != null)
			{
				((StructureElement)this.j).a(writer, this.h);
			}
			writer.WriteName(Annotation.g);
			writer.WriteArrayOpen();
			writer.WriteNumber(this.a);
			writer.WriteNumber(this.c);
			writer.WriteNumber(this.b);
			writer.WriteNumber(this.d);
			writer.WriteArrayClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06003BB2 RID: 15282 RVA: 0x001FCF28 File Offset: 0x001FBF28
		internal override int b()
		{
			return this.h;
		}

		// Token: 0x06003BB3 RID: 15283 RVA: 0x001FCF40 File Offset: 0x001FBF40
		internal override void c(int A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06003BB4 RID: 15284 RVA: 0x001FCF4C File Offset: 0x001FBF4C
		internal override bool d()
		{
			return this.i;
		}

		// Token: 0x06003BB5 RID: 15285 RVA: 0x001FCF64 File Offset: 0x001FBF64
		internal new void a(bool A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06003BB6 RID: 15286 RVA: 0x001FCF70 File Offset: 0x001FBF70
		internal new Tag a()
		{
			return this.j;
		}

		// Token: 0x06003BB7 RID: 15287 RVA: 0x001FCF88 File Offset: 0x001FBF88
		internal new void a(Tag A_0)
		{
			this.j = A_0;
		}

		// Token: 0x0400209C RID: 8348
		private new float a;

		// Token: 0x0400209D RID: 8349
		private new float b;

		// Token: 0x0400209E RID: 8350
		private new float c;

		// Token: 0x0400209F RID: 8351
		private new float d;

		// Token: 0x040020A0 RID: 8352
		private new IAnnotation e;

		// Token: 0x040020A1 RID: 8353
		private new static byte[] f = new byte[]
		{
			65,
			110,
			110,
			111,
			116
		};

		// Token: 0x040020A2 RID: 8354
		private new static byte[] g = new byte[]
		{
			82,
			101,
			99,
			116
		};

		// Token: 0x040020A3 RID: 8355
		private new int h = -1;

		// Token: 0x040020A4 RID: 8356
		private new bool i = true;

		// Token: 0x040020A5 RID: 8357
		private Tag j = null;

		// Token: 0x040020A6 RID: 8358
		private Watermark k;
	}
}
