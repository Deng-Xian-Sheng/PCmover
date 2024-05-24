using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007AF RID: 1967
	public abstract class TickMarks
	{
		// Token: 0x06004FC4 RID: 20420 RVA: 0x0027CB39 File Offset: 0x0027BB39
		internal TickMarks()
		{
		}

		// Token: 0x06004FC5 RID: 20421 RVA: 0x0027CB6C File Offset: 0x0027BB6C
		internal TickMarks(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x06004FC6 RID: 20422 RVA: 0x0027CBA8 File Offset: 0x0027BBA8
		// (set) Token: 0x06004FC7 RID: 20423 RVA: 0x0027CBC0 File Offset: 0x0027BBC0
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

		// Token: 0x1700069F RID: 1695
		// (get) Token: 0x06004FC8 RID: 20424 RVA: 0x0027CBCC File Offset: 0x0027BBCC
		// (set) Token: 0x06004FC9 RID: 20425 RVA: 0x0027CBE4 File Offset: 0x0027BBE4
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

		// Token: 0x170006A0 RID: 1696
		// (get) Token: 0x06004FCA RID: 20426 RVA: 0x0027CBF0 File Offset: 0x0027BBF0
		// (set) Token: 0x06004FCB RID: 20427 RVA: 0x0027CC08 File Offset: 0x0027BC08
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

		// Token: 0x170006A1 RID: 1697
		// (get) Token: 0x06004FCC RID: 20428 RVA: 0x0027CC14 File Offset: 0x0027BC14
		// (set) Token: 0x06004FCD RID: 20429 RVA: 0x0027CC2C File Offset: 0x0027BC2C
		public Color Color
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

		// Token: 0x170006A2 RID: 1698
		// (get) Token: 0x06004FCE RID: 20430 RVA: 0x0027CC38 File Offset: 0x0027BC38
		// (set) Token: 0x06004FCF RID: 20431 RVA: 0x0027CC50 File Offset: 0x0027BC50
		public float Length
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

		// Token: 0x170006A3 RID: 1699
		// (get) Token: 0x06004FD0 RID: 20432 RVA: 0x0027CC5C File Offset: 0x0027BC5C
		// (set) Token: 0x06004FD1 RID: 20433 RVA: 0x0027CC74 File Offset: 0x0027BC74
		public bool Visible
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

		// Token: 0x06004FD2 RID: 20434 RVA: 0x0027CC7E File Offset: 0x0027BC7E
		internal void a(PageWriter A_0)
		{
			A_0.SetGraphicsMode();
			A_0.SetLineWidth(this.c);
			A_0.SetStrokeColor(this.e);
			A_0.SetLineStyle(this.b);
			A_0.SetLineCap(LineCap.Butt);
		}

		// Token: 0x06004FD3 RID: 20435 RVA: 0x0027CCB7 File Offset: 0x0027BCB7
		internal void a(PageWriter A_0, float A_1, float A_2, float A_3, float A_4)
		{
			A_0.Write_m_(A_1, A_2);
			A_0.Write_l_(A_3, A_4);
		}

		// Token: 0x04002B15 RID: 11029
		private float a = -1f;

		// Token: 0x04002B16 RID: 11030
		private LineStyle b;

		// Token: 0x04002B17 RID: 11031
		private float c = -1f;

		// Token: 0x04002B18 RID: 11032
		private float d = -1f;

		// Token: 0x04002B19 RID: 11033
		private Color e;

		// Token: 0x04002B1A RID: 11034
		private bool f = true;
	}
}
