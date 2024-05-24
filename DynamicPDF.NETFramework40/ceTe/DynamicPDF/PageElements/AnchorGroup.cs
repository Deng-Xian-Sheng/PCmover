using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000719 RID: 1817
	public class AnchorGroup : Group
	{
		// Token: 0x0600483B RID: 18491 RVA: 0x00255C0A File Offset: 0x00254C0A
		public AnchorGroup(float width, float height, Align align, VAlign vAlign)
		{
			this.a = width;
			this.b = height;
			this.c = align;
			this.d = vAlign;
		}

		// Token: 0x0600483C RID: 18492 RVA: 0x00255C3C File Offset: 0x00254C3C
		public override void Draw(PageWriter writer)
		{
			if (base.HasPageElements())
			{
				float num;
				switch (this.c)
				{
				case Align.Left:
					num = 0f;
					if (this.e == AnchorTo.Edges)
					{
						num -= writer.Dimensions.LeftMargin;
					}
					goto IL_DE;
				case Align.Right:
					num = writer.Dimensions.Body.Width - this.a;
					if (this.e == AnchorTo.Edges)
					{
						num += writer.Dimensions.RightMargin;
					}
					goto IL_DE;
				}
				num = (writer.Dimensions.Body.Width - this.a) / 2f;
				if (this.e == AnchorTo.Edges)
				{
					num += (writer.Dimensions.RightMargin - writer.Dimensions.LeftMargin) / 2f;
				}
				IL_DE:
				float num2;
				switch (this.d)
				{
				case VAlign.Top:
					num2 = 0f;
					if (this.e == AnchorTo.Edges)
					{
						num2 -= writer.Dimensions.TopMargin;
					}
					goto IL_1AE;
				case VAlign.Bottom:
					num2 = writer.Dimensions.Body.Height - this.b;
					if (this.e == AnchorTo.Edges)
					{
						num2 += writer.Dimensions.BottomMargin;
					}
					goto IL_1AE;
				}
				num2 = (writer.Dimensions.Body.Height - this.b) / 2f;
				if (this.e == AnchorTo.Edges)
				{
					num2 += (writer.Dimensions.BottomMargin - writer.Dimensions.TopMargin) / 2f;
				}
				IL_1AE:
				writer.SetDimensionsShift(num, num2, this.a, this.b);
				base.Draw(writer);
				writer.ResetDimensions();
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x0600483D RID: 18493 RVA: 0x00255E1C File Offset: 0x00254E1C
		// (set) Token: 0x0600483E RID: 18494 RVA: 0x00255E34 File Offset: 0x00254E34
		public float Width
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

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x0600483F RID: 18495 RVA: 0x00255E40 File Offset: 0x00254E40
		// (set) Token: 0x06004840 RID: 18496 RVA: 0x00255E58 File Offset: 0x00254E58
		public float Height
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

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06004841 RID: 18497 RVA: 0x00255E64 File Offset: 0x00254E64
		// (set) Token: 0x06004842 RID: 18498 RVA: 0x00255E7C File Offset: 0x00254E7C
		public Align Align
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

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06004843 RID: 18499 RVA: 0x00255E88 File Offset: 0x00254E88
		// (set) Token: 0x06004844 RID: 18500 RVA: 0x00255EA0 File Offset: 0x00254EA0
		public VAlign VAlign
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

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06004845 RID: 18501 RVA: 0x00255EAC File Offset: 0x00254EAC
		// (set) Token: 0x06004846 RID: 18502 RVA: 0x00255EC4 File Offset: 0x00254EC4
		public AnchorTo AnchorTo
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

		// Token: 0x04002789 RID: 10121
		private new float a;

		// Token: 0x0400278A RID: 10122
		private float b;

		// Token: 0x0400278B RID: 10123
		private Align c;

		// Token: 0x0400278C RID: 10124
		private new VAlign d;

		// Token: 0x0400278D RID: 10125
		private AnchorTo e = AnchorTo.Margins;
	}
}
