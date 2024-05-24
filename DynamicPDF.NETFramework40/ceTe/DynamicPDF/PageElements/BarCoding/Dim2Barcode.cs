using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000753 RID: 1875
	public abstract class Dim2Barcode : TaggablePageElement, ICoordinate
	{
		// Token: 0x06004C57 RID: 19543 RVA: 0x0026B9CC File Offset: 0x0026A9CC
		internal Dim2Barcode(float A_0, float A_1)
		{
			base.d(3);
			this.b = A_0;
			this.c = A_1;
		}

		// Token: 0x06004C58 RID: 19544
		public abstract override void Draw(PageWriter writer);

		// Token: 0x06004C59 RID: 19545
		public abstract float GetSymbolWidth();

		// Token: 0x06004C5A RID: 19546
		public abstract float GetSymbolHeight();

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x06004C5B RID: 19547 RVA: 0x0026BA20 File Offset: 0x0026AA20
		// (set) Token: 0x06004C5C RID: 19548 RVA: 0x0026BA38 File Offset: 0x0026AA38
		public int PixelsPerXDimension
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

		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x06004C5D RID: 19549 RVA: 0x0026BA44 File Offset: 0x0026AA44
		// (set) Token: 0x06004C5E RID: 19550 RVA: 0x0026BA5C File Offset: 0x0026AA5C
		public Color Color
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

		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x06004C5F RID: 19551 RVA: 0x0026BA68 File Offset: 0x0026AA68
		// (set) Token: 0x06004C60 RID: 19552 RVA: 0x0026BA80 File Offset: 0x0026AA80
		public float X
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

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x06004C61 RID: 19553 RVA: 0x0026BA8C File Offset: 0x0026AA8C
		// (set) Token: 0x06004C62 RID: 19554 RVA: 0x0026BAA4 File Offset: 0x0026AAA4
		public float Y
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

		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06004C63 RID: 19555 RVA: 0x0026BAB0 File Offset: 0x0026AAB0
		// (set) Token: 0x06004C64 RID: 19556 RVA: 0x0026BAC8 File Offset: 0x0026AAC8
		public float Angle
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x06004C65 RID: 19557 RVA: 0x0026BAD4 File Offset: 0x0026AAD4
		// (set) Token: 0x06004C66 RID: 19558 RVA: 0x0026BAEC File Offset: 0x0026AAEC
		public float XDimension
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

		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x06004C67 RID: 19559 RVA: 0x0026BAF8 File Offset: 0x0026AAF8
		// (set) Token: 0x06004C68 RID: 19560 RVA: 0x0026BB16 File Offset: 0x0026AB16
		public float XDimensionsPerInch
		{
			get
			{
				return 72f / this.e;
			}
			set
			{
				this.e = 72f / value;
			}
		}

		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x06004C69 RID: 19561 RVA: 0x0026BB28 File Offset: 0x0026AB28
		// (set) Token: 0x06004C6A RID: 19562 RVA: 0x0026BB46 File Offset: 0x0026AB46
		public float XDimensionsPerCentiMeter
		{
			get
			{
				return 28.346457f / this.e;
			}
			set
			{
				this.e = 28.346457f / value;
			}
		}

		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x06004C6B RID: 19563 RVA: 0x0026BB58 File Offset: 0x0026AB58
		// (set) Token: 0x06004C6C RID: 19564 RVA: 0x0026BB76 File Offset: 0x0026AB76
		public float XDimensionMils
		{
			get
			{
				return this.e * 13.888889f;
			}
			set
			{
				this.e = value / 13.888889f;
			}
		}

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x06004C6D RID: 19565 RVA: 0x0026BB88 File Offset: 0x0026AB88
		// (set) Token: 0x06004C6E RID: 19566 RVA: 0x0026BBA6 File Offset: 0x0026ABA6
		public float XDimensionMilliMeters
		{
			get
			{
				return this.e * 0.35277778f;
			}
			set
			{
				this.e = value / 0.35277778f;
			}
		}

		// Token: 0x06004C6F RID: 19567 RVA: 0x0026BBB8 File Offset: 0x0026ABB8
		internal void e(PageWriter A_0)
		{
			if (this.Tag == null)
			{
				this.Tag = new StructureElement(TagType.Figure, true);
				((StructureElement)this.Tag).Order = this.TagOrder;
			}
			this.Tag.e(A_0, this);
		}

		// Token: 0x06004C70 RID: 19568 RVA: 0x0026BC10 File Offset: 0x0026AC10
		internal override byte cb()
		{
			return 33;
		}

		// Token: 0x04002938 RID: 10552
		private new Color a = Grayscale.Black;

		// Token: 0x04002939 RID: 10553
		private float b = 0f;

		// Token: 0x0400293A RID: 10554
		private float c = 0f;

		// Token: 0x0400293B RID: 10555
		private new float d;

		// Token: 0x0400293C RID: 10556
		private float e;

		// Token: 0x0400293D RID: 10557
		private int f = 3;
	}
}
