using System;
using System.Collections;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007B1 RID: 1969
	public class TitleList
	{
		// Token: 0x06004FF4 RID: 20468 RVA: 0x0027DE5F File Offset: 0x0027CE5F
		internal TitleList(Chart A_0)
		{
			this.b = A_0;
			this.a = new ArrayList();
		}

		// Token: 0x06004FF5 RID: 20469 RVA: 0x0027DE7C File Offset: 0x0027CE7C
		internal void a(Chart A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06004FF6 RID: 20470 RVA: 0x0027DE88 File Offset: 0x0027CE88
		public void Add(Title title)
		{
			this.a.Add(title);
			if (this.b != null && title != null && this.b != null)
			{
				title.a(this.b);
			}
		}

		// Token: 0x170006AB RID: 1707
		public Title this[int index]
		{
			get
			{
				return (Title)this.a[index];
			}
		}

		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x06004FF8 RID: 20472 RVA: 0x0027DEF8 File Offset: 0x0027CEF8
		public int Count
		{
			get
			{
				return this.a.Count;
			}
		}

		// Token: 0x06004FF9 RID: 20473 RVA: 0x0027DF18 File Offset: 0x0027CF18
		internal void a(PageWriter A_0, PlotArea A_1, YAxis A_2)
		{
			float num = 0f;
			switch (A_2.TitlePosition)
			{
			case YAxisTitlePosition.LeftOfPlotArea:
				for (int i = this.a.Count - 1; i >= 0; i--)
				{
					Title title = (Title)this.a[i];
					title.a(A_0, A_1, A_2, num);
					num += title.a();
				}
				break;
			case YAxisTitlePosition.RightOfPlotArea:
				for (int i = 0; i < this.a.Count; i++)
				{
					Title title = (Title)this.a[i];
					title.a(A_0, A_1, A_2, num);
					num += title.a();
				}
				break;
			case YAxisTitlePosition.LeftOfYAxis:
				for (int i = this.a.Count - 1; i >= 0; i--)
				{
					Title title = (Title)this.a[i];
					title.a(A_0, A_1, A_2, num);
					num += title.a();
				}
				break;
			case YAxisTitlePosition.RightOfYAxis:
				for (int i = 0; i < this.a.Count; i++)
				{
					Title title = (Title)this.a[i];
					title.a(A_0, A_1, A_2, num);
					num += title.a();
				}
				break;
			case YAxisTitlePosition.Automatic:
				if (A_2.AnchorType == YAxisAnchorType.Floating || A_2.AnchorType == YAxisAnchorType.Left)
				{
					for (int i = this.a.Count - 1; i >= 0; i--)
					{
						Title title = (Title)this.a[i];
						title.a(A_0, A_1, A_2, num);
						num += title.a();
					}
				}
				else
				{
					for (int i = 0; i < this.a.Count; i++)
					{
						Title title = (Title)this.a[i];
						title.a(A_0, A_1, A_2, num);
						num += title.a();
					}
				}
				break;
			}
		}

		// Token: 0x06004FFA RID: 20474 RVA: 0x0027E134 File Offset: 0x0027D134
		internal void a(PageWriter A_0, PlotArea A_1, XAxis A_2)
		{
			float num = 0f;
			switch (A_2.TitlePosition)
			{
			case XAxisTitlePosition.BelowPlotArea:
				for (int i = 0; i < this.a.Count; i++)
				{
					Title title = (Title)this.a[i];
					title.a(A_0, A_1, A_2, num);
					num += title.a();
				}
				break;
			case XAxisTitlePosition.AbovePlotArea:
				for (int i = this.a.Count - 1; i >= 0; i--)
				{
					Title title = (Title)this.a[i];
					title.a(A_0, A_1, A_2, num);
					num += title.a();
				}
				break;
			case XAxisTitlePosition.BelowXAxis:
				for (int i = 0; i < this.a.Count; i++)
				{
					Title title = (Title)this.a[i];
					title.a(A_0, A_1, A_2, num);
					num += title.a();
				}
				break;
			case XAxisTitlePosition.AboveXAxis:
				for (int i = this.a.Count - 1; i >= 0; i--)
				{
					Title title = (Title)this.a[i];
					title.a(A_0, A_1, A_2, num);
					num += title.a();
				}
				break;
			case XAxisTitlePosition.Automatic:
				if (A_2.AnchorType == XAxisAnchorType.Bottom || A_2.AnchorType == XAxisAnchorType.Floating)
				{
					for (int i = 0; i < this.a.Count; i++)
					{
						Title title = (Title)this.a[i];
						title.a(A_0, A_1, A_2, num);
						num += title.a();
					}
				}
				else
				{
					for (int i = this.a.Count - 1; i >= 0; i--)
					{
						Title title = (Title)this.a[i];
						title.a(A_0, A_1, A_2, num);
						num += title.a();
					}
				}
				break;
			}
		}

		// Token: 0x06004FFB RID: 20475 RVA: 0x0027E350 File Offset: 0x0027D350
		internal void a(PageWriter A_0, PlotArea A_1, acl A_2, float A_3)
		{
			float num = 0f;
			for (int i = this.a.Count - 1; i >= 0; i--)
			{
				Title title = (Title)this.a[i];
				title.a(A_0, A_1, A_2, A_3, num);
				num += title.a();
			}
		}

		// Token: 0x06004FFC RID: 20476 RVA: 0x0027E3B0 File Offset: 0x0027D3B0
		internal void b(PageWriter A_0, PlotArea A_1, acl A_2, float A_3)
		{
			float num = 0f;
			for (int i = 0; i < this.a.Count; i++)
			{
				Title title = (Title)this.a[i];
				title.a(A_0, A_1, A_2, A_3, num);
				num += title.a();
			}
		}

		// Token: 0x06004FFD RID: 20477 RVA: 0x0027E408 File Offset: 0x0027D408
		internal float a()
		{
			float num = 0f;
			for (int i = 0; i < this.a.Count; i++)
			{
				Title title = (Title)this.a[i];
				num += title.a();
			}
			return num;
		}

		// Token: 0x06004FFE RID: 20478 RVA: 0x0027E45C File Offset: 0x0027D45C
		internal void a(PageWriter A_0, acl A_1)
		{
			float num = 0f;
			bool a_ = true;
			switch (A_1)
			{
			case acl.e:
				for (int i = 0; i < this.a.Count; i++)
				{
					Title title = (Title)this.a[i];
					title.a(A_0, this.b, A_1, num, a_);
					a_ = false;
					num += title.a();
				}
				break;
			case acl.f:
				for (int i = this.a.Count - 1; i >= 0; i--)
				{
					Title title = (Title)this.a[i];
					title.a(A_0, this.b, A_1, num, a_);
					a_ = false;
					num += title.a();
				}
				break;
			}
		}

		// Token: 0x04002B28 RID: 11048
		private ArrayList a;

		// Token: 0x04002B29 RID: 11049
		private Chart b;
	}
}
