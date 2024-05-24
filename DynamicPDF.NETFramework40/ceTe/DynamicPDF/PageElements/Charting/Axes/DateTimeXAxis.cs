using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007B8 RID: 1976
	public class DateTimeXAxis : XAxis
	{
		// Token: 0x060050A3 RID: 20643 RVA: 0x00282615 File Offset: 0x00281615
		public DateTimeXAxis() : this(0f)
		{
		}

		// Token: 0x060050A4 RID: 20644 RVA: 0x00282625 File Offset: 0x00281625
		public DateTimeXAxis(float offset) : base(offset)
		{
			this.h = new DateTimeXAxisLabelList();
			this.d = acj.a();
		}

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x060050A5 RID: 20645 RVA: 0x00282664 File Offset: 0x00281664
		// (set) Token: 0x060050A6 RID: 20646 RVA: 0x0028267C File Offset: 0x0028167C
		public DateTime Min
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

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x060050A7 RID: 20647 RVA: 0x00282688 File Offset: 0x00281688
		// (set) Token: 0x060050A8 RID: 20648 RVA: 0x002826A0 File Offset: 0x002816A0
		public DateTime Max
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

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x060050A9 RID: 20649 RVA: 0x002826AC File Offset: 0x002816AC
		// (set) Token: 0x060050AA RID: 20650 RVA: 0x002826C5 File Offset: 0x002816C5
		public int Interval
		{
			get
			{
				return (int)base.t();
			}
			set
			{
				base.c((float)value);
			}
		}

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x060050AB RID: 20651 RVA: 0x002826D4 File Offset: 0x002816D4
		// (set) Token: 0x060050AC RID: 20652 RVA: 0x002826EC File Offset: 0x002816EC
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

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x060050AD RID: 20653 RVA: 0x002826F8 File Offset: 0x002816F8
		// (set) Token: 0x060050AE RID: 20654 RVA: 0x00282710 File Offset: 0x00281710
		public DateTimeType DateTimeType
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

		// Token: 0x060050AF RID: 20655 RVA: 0x0028271C File Offset: 0x0028171C
		internal override void iv(XYSeries A_0)
		{
			if (A_0 is StackedSeries)
			{
				((StackedSeries)A_0).e();
				((StackedSeries)A_0).f();
			}
			if (this.o == DateTime.MinValue)
			{
				this.o = A_0.ij();
			}
			else if (!A_0.ij().Equals(null) && 0 < DateTime.Compare(A_0.ij(), this.o))
			{
				this.o = A_0.ij();
			}
			if (this.n == DateTime.MinValue)
			{
				this.n = A_0.ih();
			}
			else if (!A_0.ih().Equals(null) && 0 > DateTime.Compare(A_0.ih(), this.n))
			{
				this.n = A_0.ih();
			}
		}

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x060050B0 RID: 20656 RVA: 0x00282824 File Offset: 0x00281824
		public DateTimeXAxisLabelList Labels
		{
			get
			{
				return (DateTimeXAxisLabelList)this.h;
			}
		}

		// Token: 0x060050B1 RID: 20657 RVA: 0x00282844 File Offset: 0x00281844
		internal acj d()
		{
			return this.d;
		}

		// Token: 0x060050B2 RID: 20658 RVA: 0x0028285C File Offset: 0x0028185C
		internal override void iw()
		{
			this.b();
			if (this.o != DateTime.MinValue && this.n != DateTime.MinValue)
			{
				if (this.o > this.n)
				{
					throw new GeneratorException("Axis Minimum value can't be greater than axis maximum value");
				}
				if (this.n.Equals(this.o))
				{
					throw new GeneratorException("fixedMinDate and fixedMaxDate should not be equal.");
				}
				if (this.c == DateTimeType.Undefined)
				{
					this.c = this.d.a(this.n, this.o);
				}
				if (this.c == DateTimeType.Undefined)
				{
					throw new GeneratorException("Specify correct DateTimeType.");
				}
				this.c();
			}
			else if (this.g == 0f)
			{
				if (this.m - this.l <= 10f)
				{
					this.g = 1f;
				}
				else
				{
					base.d(this.m - this.l);
				}
			}
		}

		// Token: 0x060050B3 RID: 20659 RVA: 0x0028298C File Offset: 0x0028198C
		private void c()
		{
			int num = 0;
			int num2 = 0;
			if (this.c == DateTimeType.Year)
			{
				num = this.n.Year;
				num2 = this.o.Year;
			}
			else if (this.c == DateTimeType.Month)
			{
				num = this.n.Month;
				num2 = this.o.Month;
				if (this.n.Year > this.o.Year)
				{
					num = num2 + (int)this.d.a(this.n, this.o, this.c);
				}
			}
			else if (this.c == DateTimeType.Day)
			{
				num = this.n.Day;
				num2 = this.o.Day;
				if (this.n.Month > this.o.Month || this.n.Year > this.o.Year)
				{
					num = num2 + (int)this.d.a(this.n, this.o, this.c);
				}
			}
			else if (this.c == DateTimeType.Hour)
			{
				num = this.n.Hour;
				num2 = this.o.Hour;
				if (this.n.Day > this.o.Day || this.n.Month > this.o.Month || this.n.Year > this.o.Year)
				{
					num = num2 + (int)this.d.a(this.n, this.o, this.c);
				}
			}
			else if (this.c == DateTimeType.Minute)
			{
				num = this.n.Minute;
				num2 = this.o.Minute;
				if (this.n.Hour > this.o.Hour || this.n.Day > this.o.Day || this.n.Month > this.o.Month || this.n.Year > this.o.Year)
				{
					num = num2 + (int)this.d.a(this.n, this.o, this.c);
				}
			}
			else if (this.c == DateTimeType.Second)
			{
				num = this.n.Second;
				num2 = this.o.Second;
				if (this.n.Minute > this.o.Minute || this.n.Hour > this.o.Hour || this.n.Day > this.o.Day || this.n.Month > this.o.Month || this.n.Year > this.o.Year)
				{
					num = num2 + (int)this.d.a(this.n, this.o, this.c);
				}
			}
			if (this.g == 0f)
			{
				if (num - num2 <= 10)
				{
					this.g = 1f;
				}
				else
				{
					base.d((float)(num - num2));
				}
			}
			this.m = (float)num;
			this.l = (float)num2;
			DateTime dateTime = new DateTime(this.o.Ticks);
			if (this.h.Visible)
			{
				this.a();
				if (this.h.AutoLabels)
				{
					DateTimeXAxisLabelList dateTimeXAxisLabelList = new DateTimeXAxisLabelList();
					int num3 = num2;
					DateTime dateTime2 = this.o;
					while (dateTime2 <= this.n)
					{
						DateTimeXAxisLabel dateTimeXAxisLabel;
						if (base.LabelFormat != null)
						{
							dateTimeXAxisLabel = new DateTimeXAxisLabel(dateTime2.ToString(this.i), dateTime2);
						}
						else
						{
							dateTimeXAxisLabel = new DateTimeXAxisLabel(num3.ToString(), dateTime2);
						}
						if (this.c == DateTimeType.Year)
						{
							dateTime2 = dateTime2.AddYears((int)this.g);
						}
						if (this.c == DateTimeType.Month)
						{
							dateTime2 = dateTime2.AddMonths((int)this.g);
						}
						if (this.c == DateTimeType.Day)
						{
							dateTime2 = dateTime2.AddDays((double)((int)this.g));
						}
						if (this.c == DateTimeType.Hour)
						{
							dateTime2 = dateTime2.AddHours((double)((int)this.g));
						}
						if (this.c == DateTimeType.Minute)
						{
							dateTime2 = dateTime2.AddMinutes((double)((int)this.g));
						}
						if (this.c == DateTimeType.Second)
						{
							dateTime2 = dateTime2.AddSeconds((double)((int)this.g));
						}
						dateTimeXAxisLabelList.Add(dateTimeXAxisLabel);
						dateTimeXAxisLabel.a(num3);
						num3 += (int)this.g;
					}
					this.m = (float)num3 - this.g;
					base.b(dateTimeXAxisLabelList);
				}
				else
				{
					base.y();
				}
			}
		}

		// Token: 0x060050B4 RID: 20660 RVA: 0x00282F38 File Offset: 0x00281F38
		private void b()
		{
			if (this.a != this.b)
			{
				this.o = this.a;
				this.n = this.b;
			}
			else
			{
				for (int i = 0; i < this.h.Count; i++)
				{
					DateTimeXAxisLabel dateTimeXAxisLabel = (DateTimeXAxisLabel)this.h.a(i);
					if (this.o == DateTime.MinValue)
					{
						this.o = dateTimeXAxisLabel.Value;
					}
					if (this.n == DateTime.MinValue)
					{
						this.n = dateTimeXAxisLabel.Value;
					}
					if (dateTimeXAxisLabel.Value.CompareTo(this.o) < 0)
					{
						this.o = dateTimeXAxisLabel.Value;
					}
					if (dateTimeXAxisLabel.Value.CompareTo(this.n) > 0)
					{
						this.n = dateTimeXAxisLabel.Value;
					}
				}
			}
		}

		// Token: 0x060050B5 RID: 20661 RVA: 0x00283050 File Offset: 0x00282050
		private void a()
		{
			for (int i = 0; i < this.h.Count; i++)
			{
				DateTimeXAxisLabel dateTimeXAxisLabel = (DateTimeXAxisLabel)this.h.a(i);
				if (!dateTimeXAxisLabel.f())
				{
					int a_ = (int)this.d.a(dateTimeXAxisLabel.Value, this.o, this.c);
					dateTimeXAxisLabel.a(a_);
				}
			}
		}

		// Token: 0x04002B5B RID: 11099
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002B5C RID: 11100
		private new DateTime b = DateTime.MinValue;

		// Token: 0x04002B5D RID: 11101
		private new DateTimeType c = DateTimeType.Undefined;

		// Token: 0x04002B5E RID: 11102
		private new acj d;
	}
}
