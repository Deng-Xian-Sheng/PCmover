using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000745 RID: 1861
	public class TransparencyGroup : Group
	{
		// Token: 0x06004BA7 RID: 19367 RVA: 0x002652EC File Offset: 0x002642EC
		public TransparencyGroup(float alpha) : this(alpha, BlendMode.Normal)
		{
		}

		// Token: 0x06004BA8 RID: 19368 RVA: 0x002652F9 File Offset: 0x002642F9
		public TransparencyGroup(float alpha, BlendMode blendMode)
		{
			this.a = alpha;
			this.b = alpha;
			this.c = blendMode;
		}

		// Token: 0x06004BA9 RID: 19369 RVA: 0x00265320 File Offset: 0x00264320
		public override void Draw(PageWriter writer)
		{
			writer.Write_q_(true);
			writer.Write_gs(new TransparencyGroup.a(this.a, this.b, this.c));
			base.Draw(writer);
			writer.Write_Q(true);
		}

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x06004BAA RID: 19370 RVA: 0x0026535C File Offset: 0x0026435C
		// (set) Token: 0x06004BAB RID: 19371 RVA: 0x00265374 File Offset: 0x00264374
		public float StrokeAlpha
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x06004BAC RID: 19372 RVA: 0x00265380 File Offset: 0x00264380
		// (set) Token: 0x06004BAD RID: 19373 RVA: 0x00265398 File Offset: 0x00264398
		public float FillAlpha
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x06004BAE RID: 19374 RVA: 0x002653A4 File Offset: 0x002643A4
		// (set) Token: 0x06004BAF RID: 19375 RVA: 0x002653BC File Offset: 0x002643BC
		public BlendMode BlendMode
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x040028D2 RID: 10450
		private new float a;

		// Token: 0x040028D3 RID: 10451
		private float b;

		// Token: 0x040028D4 RID: 10452
		private BlendMode c = BlendMode.Normal;

		// Token: 0x040028D5 RID: 10453
		private new static byte[] d = new byte[]
		{
			99,
			97
		};

		// Token: 0x040028D6 RID: 10454
		private static byte[] e = new byte[]
		{
			67,
			65
		};

		// Token: 0x040028D7 RID: 10455
		private static byte[] f = new byte[]
		{
			69,
			120,
			116,
			71,
			83,
			116,
			97,
			116,
			101
		};

		// Token: 0x040028D8 RID: 10456
		private static byte[] g = new byte[]
		{
			66,
			77
		};

		// Token: 0x040028D9 RID: 10457
		private static byte[] h = new byte[]
		{
			65,
			73,
			83
		};

		// Token: 0x02000746 RID: 1862
		internal new class a : Resource
		{
			// Token: 0x06004BB1 RID: 19377 RVA: 0x00265447 File Offset: 0x00264447
			internal a(float A_0, float A_1, BlendMode A_2)
			{
				this.a = A_0;
				this.b = A_1;
				this.c = A_2;
			}

			// Token: 0x06004BB2 RID: 19378 RVA: 0x00265484 File Offset: 0x00264484
			public override int get_RequiredPdfObjects()
			{
				return 1;
			}

			// Token: 0x06004BB3 RID: 19379 RVA: 0x00265498 File Offset: 0x00264498
			public override void Draw(DocumentWriter writer)
			{
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				writer.WriteName(Resource.a);
				writer.WriteName(TransparencyGroup.f);
				writer.WriteName(TransparencyGroup.d);
				writer.WriteNumber(this.b);
				writer.WriteName(TransparencyGroup.e);
				writer.WriteNumber(this.a);
				writer.WriteName(TransparencyGroup.g);
				writer.WriteName(this.c.ToString());
				writer.WriteName(TransparencyGroup.h);
				writer.WriteBoolean(false);
				writer.WriteDictionaryClose();
				writer.WriteEndObject();
			}

			// Token: 0x040028DA RID: 10458
			private new float a = 1f;

			// Token: 0x040028DB RID: 10459
			private new float b = 1f;

			// Token: 0x040028DC RID: 10460
			private new BlendMode c = BlendMode.Normal;
		}
	}
}
