using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007A5 RID: 1957
	public abstract class GridLines
	{
		// Token: 0x06004EF9 RID: 20217 RVA: 0x00279524 File Offset: 0x00278524
		internal GridLines()
		{
		}

		// Token: 0x06004EFA RID: 20218 RVA: 0x0027954C File Offset: 0x0027854C
		internal GridLines(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x06004EFB RID: 20219 RVA: 0x0027957C File Offset: 0x0027857C
		// (set) Token: 0x06004EFC RID: 20220 RVA: 0x00279594 File Offset: 0x00278594
		public float Interval
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

		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x06004EFD RID: 20221 RVA: 0x002795A0 File Offset: 0x002785A0
		// (set) Token: 0x06004EFE RID: 20222 RVA: 0x002795B8 File Offset: 0x002785B8
		public LineStyle LineStyle
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

		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x06004EFF RID: 20223 RVA: 0x002795C4 File Offset: 0x002785C4
		// (set) Token: 0x06004F00 RID: 20224 RVA: 0x002795DC File Offset: 0x002785DC
		public float Width
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

		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x06004F01 RID: 20225 RVA: 0x002795E8 File Offset: 0x002785E8
		// (set) Token: 0x06004F02 RID: 20226 RVA: 0x00279600 File Offset: 0x00278600
		public Color Color
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

		// Token: 0x1700065E RID: 1630
		// (get) Token: 0x06004F03 RID: 20227 RVA: 0x0027960C File Offset: 0x0027860C
		// (set) Token: 0x06004F04 RID: 20228 RVA: 0x00279624 File Offset: 0x00278624
		public bool Visible
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

		// Token: 0x06004F05 RID: 20229 RVA: 0x0027962E File Offset: 0x0027862E
		internal void a(PageWriter A_0)
		{
			A_0.SetGraphicsMode();
			A_0.SetLineWidth(this.c);
			A_0.SetStrokeColor(this.d);
			A_0.SetLineStyle(this.b);
			A_0.SetLineCap(LineCap.Butt);
		}

		// Token: 0x06004F06 RID: 20230 RVA: 0x00279667 File Offset: 0x00278667
		internal void a(PageWriter A_0, float A_1, float A_2, float A_3, float A_4)
		{
			A_0.Write_m_(A_1, A_2);
			A_0.Write_l_(A_3, A_4);
		}

		// Token: 0x04002ABC RID: 10940
		private float a = -1f;

		// Token: 0x04002ABD RID: 10941
		private LineStyle b;

		// Token: 0x04002ABE RID: 10942
		private float c = 0.5f;

		// Token: 0x04002ABF RID: 10943
		private Color d;

		// Token: 0x04002AC0 RID: 10944
		private bool e = true;
	}
}
