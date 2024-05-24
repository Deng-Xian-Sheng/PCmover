using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007C6 RID: 1990
	public class IndexedYAxis : YAxis
	{
		// Token: 0x06005132 RID: 20786 RVA: 0x002871F2 File Offset: 0x002861F2
		public IndexedYAxis() : this(0f)
		{
		}

		// Token: 0x06005133 RID: 20787 RVA: 0x00287202 File Offset: 0x00286202
		public IndexedYAxis(float offset) : base(offset)
		{
			this.h = new IndexedYAxisLabelList();
		}

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x06005134 RID: 20788 RVA: 0x00287228 File Offset: 0x00286228
		public int Min
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x06005135 RID: 20789 RVA: 0x00287240 File Offset: 0x00286240
		// (set) Token: 0x06005136 RID: 20790 RVA: 0x00287258 File Offset: 0x00286258
		public int Max
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

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x06005137 RID: 20791 RVA: 0x00287264 File Offset: 0x00286264
		public IndexedYAxisLabelList Labels
		{
			get
			{
				return (IndexedYAxisLabelList)this.h;
			}
		}

		// Token: 0x170006F0 RID: 1776
		// (get) Token: 0x06005138 RID: 20792 RVA: 0x00287284 File Offset: 0x00286284
		// (set) Token: 0x06005139 RID: 20793 RVA: 0x0028729C File Offset: 0x0028629C
		public float AxisPaddingInterval
		{
			get
			{
				return base.s();
			}
			set
			{
				base.b(value);
			}
		}

		// Token: 0x0600513A RID: 20794 RVA: 0x002872A8 File Offset: 0x002862A8
		internal override void iw()
		{
			this.b();
			if (this.h.Visible)
			{
				if (this.h.AutoLabels)
				{
					if (this.m < this.l)
					{
						throw new GeneratorException("Axis Minimum value can't be greater than axis maximum value");
					}
					IndexedYAxisLabelList indexedYAxisLabelList = new IndexedYAxisLabelList();
					if (this.g <= 0f)
					{
						throw new GeneratorException("Interval should be greater than zero");
					}
					if (this.g > 0f && this.g < 1f)
					{
						this.g = 1f;
					}
					for (int i = (int)this.l; i <= (int)this.m; i += (int)base.t())
					{
						indexedYAxisLabelList.Add(new IndexedYAxisLabel(i.ToString(), i));
					}
					base.b(indexedYAxisLabelList);
				}
				else
				{
					base.y();
				}
			}
		}

		// Token: 0x0600513B RID: 20795 RVA: 0x002873AC File Offset: 0x002863AC
		internal override void iv(XYSeries A_0)
		{
			if (A_0 is StackedSeries)
			{
				((StackedSeries)A_0).c();
				((StackedSeries)A_0).d();
			}
			if (this.l > A_0.iz())
			{
				this.l = (float)((int)A_0.iz());
			}
			if (this.m < A_0.ig())
			{
				this.m = (float)((int)A_0.ig());
			}
		}

		// Token: 0x0600513C RID: 20796 RVA: 0x0028742C File Offset: 0x0028642C
		private void b()
		{
			if (this.m == -3.4028235E+38f && this.l == 3.4028235E+38f)
			{
				this.m = 5f;
				this.l = 0f;
			}
			if (this.b != this.a)
			{
				this.m = (float)this.b;
				this.l = (float)this.a;
				if (!this.p)
				{
					this.g = 1f;
				}
			}
			else
			{
				this.a();
				if (!this.p)
				{
					this.g = 1f;
				}
			}
		}

		// Token: 0x0600513D RID: 20797 RVA: 0x002874DC File Offset: 0x002864DC
		private void a()
		{
			for (int i = 0; i < this.h.Count; i++)
			{
				IndexedYAxisLabel indexedYAxisLabel = (IndexedYAxisLabel)this.h.a(i);
				if ((float)indexedYAxisLabel.Value > this.m)
				{
					this.m = (float)indexedYAxisLabel.Value;
				}
			}
		}

		// Token: 0x04002B7B RID: 11131
		private new int a = -1;

		// Token: 0x04002B7C RID: 11132
		private new int b = -1;
	}
}
