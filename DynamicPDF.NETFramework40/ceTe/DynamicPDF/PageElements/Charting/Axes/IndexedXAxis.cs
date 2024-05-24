using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007C3 RID: 1987
	public class IndexedXAxis : XAxis
	{
		// Token: 0x0600511F RID: 20767 RVA: 0x00286DAF File Offset: 0x00285DAF
		public IndexedXAxis() : this(0f)
		{
		}

		// Token: 0x06005120 RID: 20768 RVA: 0x00286DBF File Offset: 0x00285DBF
		public IndexedXAxis(float offset) : base(offset)
		{
			this.h = new IndexedXAxisLabelList();
		}

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x06005121 RID: 20769 RVA: 0x00286DE4 File Offset: 0x00285DE4
		public int Min
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x06005122 RID: 20770 RVA: 0x00286DFC File Offset: 0x00285DFC
		// (set) Token: 0x06005123 RID: 20771 RVA: 0x00286E14 File Offset: 0x00285E14
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

		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x06005124 RID: 20772 RVA: 0x00286E20 File Offset: 0x00285E20
		// (set) Token: 0x06005125 RID: 20773 RVA: 0x00286E38 File Offset: 0x00285E38
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

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x06005126 RID: 20774 RVA: 0x00286E44 File Offset: 0x00285E44
		public IndexedXAxisLabelList Labels
		{
			get
			{
				return (IndexedXAxisLabelList)this.h;
			}
		}

		// Token: 0x06005127 RID: 20775 RVA: 0x00286E64 File Offset: 0x00285E64
		internal override void iw()
		{
			this.b();
			if (base.r().Visible)
			{
				if (base.r().AutoLabels)
				{
					if (this.m < this.l)
					{
						throw new GeneratorException("Axis Minimum value can't be greater than axis maximum value");
					}
					IndexedXAxisLabelList indexedXAxisLabelList = new IndexedXAxisLabelList();
					if (this.g <= 0f)
					{
						throw new GeneratorException("Interval should be greater than zero");
					}
					if (this.g > 0f && this.g < 1f)
					{
						this.g = 1f;
					}
					else if (this.g > 1f)
					{
						this.g = (float)Math.Round((double)this.g);
					}
					for (int i = (int)this.l; i <= (int)this.m; i += (int)this.g)
					{
						indexedXAxisLabelList.Add(new IndexedXAxisLabel(i.ToString(), i));
					}
					base.b(indexedXAxisLabelList);
				}
				else
				{
					base.y();
				}
			}
		}

		// Token: 0x06005128 RID: 20776 RVA: 0x00286F90 File Offset: 0x00285F90
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

		// Token: 0x06005129 RID: 20777 RVA: 0x00287010 File Offset: 0x00286010
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

		// Token: 0x0600512A RID: 20778 RVA: 0x002870C0 File Offset: 0x002860C0
		private void a()
		{
			for (int i = 0; i < this.h.Count; i++)
			{
				IndexedXAxisLabel indexedXAxisLabel = (IndexedXAxisLabel)this.h.a(i);
				if ((float)indexedXAxisLabel.Value > this.m)
				{
					this.m = (float)indexedXAxisLabel.Value;
				}
			}
		}

		// Token: 0x04002B78 RID: 11128
		private new int a = -1;

		// Token: 0x04002B79 RID: 11129
		private new int b = -1;
	}
}
