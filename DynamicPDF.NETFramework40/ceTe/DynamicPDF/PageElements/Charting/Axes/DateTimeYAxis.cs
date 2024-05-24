using System;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007BE RID: 1982
	public class DateTimeYAxis : YAxis
	{
		// Token: 0x060050F8 RID: 20728 RVA: 0x00285C4A File Offset: 0x00284C4A
		public DateTimeYAxis() : this(0f)
		{
		}

		// Token: 0x060050F9 RID: 20729 RVA: 0x00285C5A File Offset: 0x00284C5A
		public DateTimeYAxis(float offset) : base(offset)
		{
			this.h = new DateTimeYAxisLabelList();
			this.d = acj.a();
		}

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x060050FA RID: 20730 RVA: 0x00285C9C File Offset: 0x00284C9C
		// (set) Token: 0x060050FB RID: 20731 RVA: 0x00285CB4 File Offset: 0x00284CB4
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

		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x060050FC RID: 20732 RVA: 0x00285CC0 File Offset: 0x00284CC0
		// (set) Token: 0x060050FD RID: 20733 RVA: 0x00285CD8 File Offset: 0x00284CD8
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

		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x060050FE RID: 20734 RVA: 0x00285CE4 File Offset: 0x00284CE4
		// (set) Token: 0x060050FF RID: 20735 RVA: 0x00285CFD File Offset: 0x00284CFD
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

		// Token: 0x170006E3 RID: 1763
		// (get) Token: 0x06005100 RID: 20736 RVA: 0x00285D0C File Offset: 0x00284D0C
		// (set) Token: 0x06005101 RID: 20737 RVA: 0x00285D24 File Offset: 0x00284D24
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

		// Token: 0x170006E4 RID: 1764
		// (get) Token: 0x06005102 RID: 20738 RVA: 0x00285D30 File Offset: 0x00284D30
		// (set) Token: 0x06005103 RID: 20739 RVA: 0x00285D48 File Offset: 0x00284D48
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

		// Token: 0x06005104 RID: 20740 RVA: 0x00285D54 File Offset: 0x00284D54
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

		// Token: 0x170006E5 RID: 1765
		// (get) Token: 0x06005105 RID: 20741 RVA: 0x00285E5C File Offset: 0x00284E5C
		public DateTimeYAxisLabelList Labels
		{
			get
			{
				return (DateTimeYAxisLabelList)this.h;
			}
		}

		// Token: 0x06005106 RID: 20742 RVA: 0x00285E7C File Offset: 0x00284E7C
		internal acj d()
		{
			return this.d;
		}

		// Token: 0x06005107 RID: 20743 RVA: 0x00285E94 File Offset: 0x00284E94
		internal override void iw()
		{
			if (this.n == DateTime.MinValue && this.o == DateTime.MinValue)
			{
				this.n = DateTime.Now;
				DateTime now = DateTime.Now;
				now.AddDays(-4.0);
				this.o = now;
			}
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

		// Token: 0x06005108 RID: 20744 RVA: 0x0028601C File Offset: 0x0028501C
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
			if (this.h.Visible)
			{
				this.a();
				if (this.h.AutoLabels)
				{
					DateTimeYAxisLabelList dateTimeYAxisLabelList = new DateTimeYAxisLabelList();
					int num3 = num2;
					DateTime dateTime = this.o;
					while (dateTime <= this.n)
					{
						DateTimeYAxisLabel dateTimeYAxisLabel;
						if (base.LabelFormat != null)
						{
							dateTimeYAxisLabel = new DateTimeYAxisLabel(dateTime.ToString(this.i), dateTime);
						}
						else
						{
							dateTimeYAxisLabel = new DateTimeYAxisLabel(num3.ToString(), dateTime);
						}
						if (this.c == DateTimeType.Year)
						{
							dateTime = dateTime.AddYears((int)this.g);
						}
						if (this.c == DateTimeType.Month)
						{
							dateTime = dateTime.AddMonths((int)this.g);
						}
						if (this.c == DateTimeType.Day)
						{
							dateTime = dateTime.AddDays((double)((int)this.g));
						}
						if (this.c == DateTimeType.Hour)
						{
							dateTime = dateTime.AddHours((double)((int)this.g));
						}
						if (this.c == DateTimeType.Minute)
						{
							dateTime = dateTime.AddMinutes((double)((int)this.g));
						}
						if (this.c == DateTimeType.Second)
						{
							dateTime = dateTime.AddSeconds((double)((int)this.g));
						}
						dateTimeYAxisLabelList.Add(dateTimeYAxisLabel);
						dateTimeYAxisLabel.a(num3);
						num3 += (int)this.g;
					}
					this.m = (float)num3 - this.g;
					base.b(dateTimeYAxisLabelList);
				}
				else
				{
					base.y();
				}
			}
		}

		// Token: 0x06005109 RID: 20745 RVA: 0x002865B4 File Offset: 0x002855B4
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
					DateTimeYAxisLabel dateTimeYAxisLabel = (DateTimeYAxisLabel)this.h.a(i);
					if (this.o == DateTime.MinValue)
					{
						this.o = dateTimeYAxisLabel.Value;
					}
					if (this.n == DateTime.MinValue)
					{
						this.n = dateTimeYAxisLabel.Value;
					}
					if (dateTimeYAxisLabel.Value < this.o)
					{
						this.o = dateTimeYAxisLabel.Value;
					}
					if (dateTimeYAxisLabel.Value > this.n)
					{
						this.n = dateTimeYAxisLabel.Value;
					}
				}
			}
		}

		// Token: 0x0600510A RID: 20746 RVA: 0x002866C0 File Offset: 0x002856C0
		private void a()
		{
			for (int i = 0; i < this.h.Count; i++)
			{
				DateTimeYAxisLabel dateTimeYAxisLabel = (DateTimeYAxisLabel)this.h.a(i);
				if (!dateTimeYAxisLabel.f())
				{
					int a_ = (int)this.d.a(dateTimeYAxisLabel.Value, this.o, this.c);
					dateTimeYAxisLabel.a(a_);
				}
			}
		}

		// Token: 0x04002B72 RID: 11122
		private new DateTime a = DateTime.MinValue;

		// Token: 0x04002B73 RID: 11123
		private new DateTime b = DateTime.MinValue;

		// Token: 0x04002B74 RID: 11124
		private new DateTimeType c = DateTimeType.Undefined;

		// Token: 0x04002B75 RID: 11125
		private new acj d;
	}
}
