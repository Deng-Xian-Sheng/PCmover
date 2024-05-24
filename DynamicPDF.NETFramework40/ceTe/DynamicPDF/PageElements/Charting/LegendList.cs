using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007A9 RID: 1961
	public class LegendList
	{
		// Token: 0x06004F55 RID: 20309 RVA: 0x0027B189 File Offset: 0x0027A189
		internal LegendList(Chart A_0)
		{
			this.b = A_0;
			this.a = new ArrayList();
		}

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x06004F56 RID: 20310 RVA: 0x0027B1BC File Offset: 0x0027A1BC
		// (set) Token: 0x06004F57 RID: 20311 RVA: 0x0027B1D4 File Offset: 0x0027A1D4
		public LegendPlacement Placement
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

		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x06004F58 RID: 20312 RVA: 0x0027B1E0 File Offset: 0x0027A1E0
		// (set) Token: 0x06004F59 RID: 20313 RVA: 0x0027B1F8 File Offset: 0x0027A1F8
		public LayOut Layout
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

		// Token: 0x17000681 RID: 1665
		// (get) Token: 0x06004F5A RID: 20314 RVA: 0x0027B204 File Offset: 0x0027A204
		// (set) Token: 0x06004F5B RID: 20315 RVA: 0x0027B21C File Offset: 0x0027A21C
		public LayOut LabelsLayout
		{
			get
			{
				return this.e;
			}
			set
			{
				if (this.a != null)
				{
					for (int i = 0; i < this.a.Count; i++)
					{
						Legend legend = (Legend)this.a[i];
						legend.a(value);
					}
				}
				this.e = value;
			}
		}

		// Token: 0x06004F5C RID: 20316 RVA: 0x0027B274 File Offset: 0x0027A274
		internal void a(Legend A_0)
		{
			if (A_0.X == -1f)
			{
				A_0.X = this.b.X;
			}
			if (A_0.Y == -1f)
			{
				A_0.Y = this.b.Y;
			}
			if (A_0.Width == -1f)
			{
				A_0.Width = A_0.RequiredWidth;
			}
			if (A_0.Height == -1f)
			{
				A_0.b(A_0.RequiredHeight);
			}
		}

		// Token: 0x06004F5D RID: 20317 RVA: 0x0027B310 File Offset: 0x0027A310
		public Legend Add(float x, float y, float width, float height)
		{
			Legend a_ = new Legend(x, y, width, height, this.b);
			return this.b(a_);
		}

		// Token: 0x06004F5E RID: 20318 RVA: 0x0027B33C File Offset: 0x0027A33C
		public Legend Add()
		{
			Legend a_ = new Legend(this.b);
			return this.b(a_);
		}

		// Token: 0x06004F5F RID: 20319 RVA: 0x0027B364 File Offset: 0x0027A364
		internal Legend b(Legend A_0)
		{
			A_0.a(this.e);
			if (this.a != null)
			{
				this.a.Add(A_0);
			}
			else
			{
				this.a = new ArrayList();
				this.a.Add(A_0);
			}
			return A_0;
		}

		// Token: 0x17000682 RID: 1666
		public Legend this[int index]
		{
			get
			{
				Legend result;
				if (index <= this.a.Count)
				{
					result = (Legend)this.a[index];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x06004F61 RID: 20321 RVA: 0x0027B3F8 File Offset: 0x0027A3F8
		public int Count
		{
			get
			{
				int result;
				if (this.a != null)
				{
					result = this.a.Count;
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x06004F62 RID: 20322 RVA: 0x0027B428 File Offset: 0x0027A428
		internal int a()
		{
			int num = 0;
			for (int i = 0; i < this.a.Count; i++)
			{
				Legend legend = (Legend)this.a[i];
				if (legend.Visible && legend.b() > 0)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06004F63 RID: 20323 RVA: 0x0027B490 File Offset: 0x0027A490
		internal void a(PageWriter A_0)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				Legend legend = (Legend)this.a[i];
				if (legend.b() > 0)
				{
					if (legend.X == -1f || legend.Y == -1f || legend.Width == -1f || legend.Height == -1f)
					{
						this.a(legend);
					}
					if (legend.BackgroundColor == null)
					{
						legend.BackgroundColor = this.b.BackgroundColor;
					}
					if (legend.BorderColor == null)
					{
						legend.BorderColor = this.b.BorderColor;
					}
					legend.a(A_0);
				}
			}
		}

		// Token: 0x04002AE1 RID: 10977
		private ArrayList a;

		// Token: 0x04002AE2 RID: 10978
		private Chart b;

		// Token: 0x04002AE3 RID: 10979
		private LegendPlacement c = LegendPlacement.RightCenter;

		// Token: 0x04002AE4 RID: 10980
		private LayOut d = LayOut.Vertical;

		// Token: 0x04002AE5 RID: 10981
		private LayOut e = LayOut.Vertical;
	}
}
