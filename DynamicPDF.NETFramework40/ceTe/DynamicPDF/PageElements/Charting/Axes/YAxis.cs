using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007BD RID: 1981
	public abstract class YAxis : Axis
	{
		// Token: 0x060050D0 RID: 20688 RVA: 0x00284187 File Offset: 0x00283187
		internal YAxis()
		{
		}

		// Token: 0x060050D1 RID: 20689 RVA: 0x002841B2 File Offset: 0x002831B2
		internal YAxis(float A_0) : base(A_0)
		{
			this.h = new TitleList(null);
		}

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x060050D2 RID: 20690 RVA: 0x002841EC File Offset: 0x002831EC
		// (set) Token: 0x060050D3 RID: 20691 RVA: 0x00284204 File Offset: 0x00283204
		public YAxisAnchorType AnchorType
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

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x060050D4 RID: 20692 RVA: 0x00284210 File Offset: 0x00283210
		// (set) Token: 0x060050D5 RID: 20693 RVA: 0x00284228 File Offset: 0x00283228
		public YAxisLabelPosition LabelPosition
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

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x060050D6 RID: 20694 RVA: 0x00284234 File Offset: 0x00283234
		// (set) Token: 0x060050D7 RID: 20695 RVA: 0x0028424C File Offset: 0x0028324C
		public YAxisGridLines MajorGridLines
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

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x060050D8 RID: 20696 RVA: 0x00284258 File Offset: 0x00283258
		// (set) Token: 0x060050D9 RID: 20697 RVA: 0x00284270 File Offset: 0x00283270
		public YAxisGridLines MinorGridLines
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

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x060050DA RID: 20698 RVA: 0x0028427C File Offset: 0x0028327C
		// (set) Token: 0x060050DB RID: 20699 RVA: 0x00284294 File Offset: 0x00283294
		public YAxisTickMarks MajorTickMarks
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
				if (this.f != null && this.f.Length <= 0f)
				{
					this.f.Length = 4f;
				}
			}
		}

		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x060050DC RID: 20700 RVA: 0x002842DC File Offset: 0x002832DC
		// (set) Token: 0x060050DD RID: 20701 RVA: 0x002842F4 File Offset: 0x002832F4
		public YAxisTickMarks MinorTickMarks
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
				if (this.g != null && this.g.Length <= 0f)
				{
					this.g.Length = 2f;
				}
			}
		}

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x060050DE RID: 20702 RVA: 0x0028433C File Offset: 0x0028333C
		public TitleList Titles
		{
			get
			{
				return this.h;
			}
		}

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x060050DF RID: 20703 RVA: 0x00284354 File Offset: 0x00283354
		// (set) Token: 0x060050E0 RID: 20704 RVA: 0x0028436C File Offset: 0x0028336C
		public YAxisTitlePosition TitlePosition
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

		// Token: 0x060050E1 RID: 20705 RVA: 0x00284378 File Offset: 0x00283378
		internal new float g()
		{
			return this.i;
		}

		// Token: 0x060050E2 RID: 20706 RVA: 0x00284390 File Offset: 0x00283390
		internal new float h()
		{
			return this.l;
		}

		// Token: 0x060050E3 RID: 20707 RVA: 0x002843A8 File Offset: 0x002833A8
		internal float b(YAxisAnchorType A_0)
		{
			float result;
			if (this.f != null)
			{
				result = this.f.a(A_0);
			}
			else if (this.g != null)
			{
				result = this.g.a(A_0);
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x060050E4 RID: 20708 RVA: 0x002843F8 File Offset: 0x002833F8
		internal new void i()
		{
			if (this.m > this.l)
			{
				this.i = base.u().Height / ((this.m - this.l) / this.g + base.s() * 2f);
				this.j = (int)((this.m - this.l) / this.g) + 1;
				if (this.l < 0f)
				{
					this.l = Math.Abs(this.l) / this.g;
				}
			}
			else if (this.m == this.l)
			{
				this.i = base.u().Height;
				this.j = 1;
			}
		}

		// Token: 0x060050E5 RID: 20709 RVA: 0x002844D0 File Offset: 0x002834D0
		internal new int j()
		{
			return this.j;
		}

		// Token: 0x060050E6 RID: 20710 RVA: 0x002844E8 File Offset: 0x002834E8
		internal void k()
		{
			if (this.f == null)
			{
				this.f = new YAxisTickMarks();
				this.f.Length = 4f;
				this.f.Visible = base.Visible;
			}
		}

		// Token: 0x060050E7 RID: 20711 RVA: 0x00284538 File Offset: 0x00283538
		internal new void l()
		{
			if (this.g == null)
			{
				this.g = new YAxisTickMarks();
				this.g.Length = 2f;
				this.g.Visible = base.Visible;
			}
		}

		// Token: 0x060050E8 RID: 20712 RVA: 0x00284588 File Offset: 0x00283588
		internal void a(PageWriter A_0)
		{
			if (this.d != null && this.d.Visible)
			{
				this.d.a(A_0, base.u(), this, this.j, ack.a);
			}
			if (this.e != null && this.e.Visible)
			{
				this.e.a(A_0, base.u(), this, this.j, ack.b);
			}
		}

		// Token: 0x060050E9 RID: 20713 RVA: 0x00284608 File Offset: 0x00283608
		internal void b(PageWriter A_0)
		{
			if (base.Visible)
			{
				A_0.SetGraphicsMode();
				A_0.SetLineWidth(base.LineWidth);
				A_0.SetStrokeColor(base.LineColor);
				A_0.SetLineStyle(base.LineStyle);
				A_0.SetLineCap(LineCap.Butt);
				if (base.LineStyle != LineStyle.None)
				{
					if (this.a == YAxisAnchorType.Left)
					{
						A_0.Write_m_(base.u().X + base.Offset, base.u().Y + base.u().Height);
						A_0.Write_l_(base.u().X + base.Offset, base.u().Y);
					}
					else if (this.a == YAxisAnchorType.Right)
					{
						A_0.Write_m_(base.u().X + base.u().Width + base.Offset, base.u().Y + base.u().Height);
						A_0.Write_l_(base.u().X + base.u().Width + base.Offset, base.u().Y);
					}
					else if (this.a == YAxisAnchorType.Floating)
					{
						A_0.Write_m_(base.u().X + base.u().i().h() * base.u().i().g() + base.Offset * (base.u().i().g() / base.u().i().t()) + base.u().i().g() * base.u().i().s(), base.u().Y + base.u().Height);
						A_0.Write_l_(base.u().X + base.u().i().h() * base.u().i().g() + base.Offset * (base.u().i().g() / base.u().i().t()) + base.u().i().g() * base.u().i().s(), base.u().Y);
					}
					A_0.Write_S();
				}
			}
			if (this.f != null && this.f.Visible)
			{
				this.f.a(A_0, base.u(), this, this.j, ack.a);
			}
			if (this.g != null && this.g.Visible)
			{
				this.g.a(A_0, base.u(), this, this.j, ack.b);
			}
		}

		// Token: 0x060050EA RID: 20714 RVA: 0x00284910 File Offset: 0x00283910
		internal void c(PageWriter A_0)
		{
			if (this.h.Visible)
			{
				this.f();
				YAxisLabelList yaxisLabelList = (YAxisLabelList)this.h;
				yaxisLabelList.a(A_0, base.u(), this);
			}
			if (this.h != null)
			{
				this.h.a(A_0, base.u(), this);
			}
		}

		// Token: 0x060050EB RID: 20715 RVA: 0x00284978 File Offset: 0x00283978
		private void f()
		{
			if (this.b == YAxisLabelPosition.LeftOfYAxis && this.a == YAxisAnchorType.Right)
			{
				this.k = this.a(YAxisAnchorType.Left);
			}
			else if (this.b == YAxisLabelPosition.RightOfYAxis && (this.a == YAxisAnchorType.Left || this.a == YAxisAnchorType.Floating))
			{
				this.k = this.a(YAxisAnchorType.Right);
			}
			else if (this.b == YAxisLabelPosition.LeftOfYAxis && this.a == YAxisAnchorType.Floating)
			{
				this.k = this.a(YAxisAnchorType.Left);
			}
			else if (this.b == YAxisLabelPosition.RightOfPlotArea && this.a == YAxisAnchorType.Floating)
			{
				if (this.c())
				{
					this.e();
				}
				else
				{
					this.k = 0f;
				}
			}
			else if (this.b == YAxisLabelPosition.Automatic || this.b == YAxisLabelPosition.LeftOfPlotArea)
			{
				if (this.a == YAxisAnchorType.Floating)
				{
					if (this.b())
					{
						this.k = this.a(YAxisAnchorType.Left);
					}
					else if (this.a(this.a(YAxisAnchorType.Left)) > 0f)
					{
						this.k = this.a(this.a(YAxisAnchorType.Left));
					}
					else
					{
						this.k = 0f;
					}
				}
				else if (this.a == YAxisAnchorType.Left)
				{
					this.e();
				}
			}
			else
			{
				this.e();
			}
		}

		// Token: 0x060050EC RID: 20716 RVA: 0x00284B14 File Offset: 0x00283B14
		private void e()
		{
			if (this.f != null && this.f.Visible)
			{
				if (this.f.Length <= 0f)
				{
					this.f.Length = 4f;
				}
				this.k = this.f.a(this.a);
			}
			if (this.g != null && this.g.Visible)
			{
				if (this.g.Length <= 0f)
				{
					this.g.Length = 2f;
				}
				if (this.k < this.g.a(this.a))
				{
					this.k = this.g.a(this.a);
				}
			}
			if (this.k != 0f && this.a != YAxisAnchorType.Floating)
			{
				if (this.b != YAxisLabelPosition.LeftOfYAxis && this.b != YAxisLabelPosition.RightOfYAxis)
				{
					this.d();
				}
			}
		}

		// Token: 0x060050ED RID: 20717 RVA: 0x00284C40 File Offset: 0x00283C40
		private float a(YAxisAnchorType A_0)
		{
			float num = 0f;
			if (this.f != null && this.f.Visible)
			{
				num = this.f.a(A_0);
			}
			if (this.g != null && this.g.Visible)
			{
				if (num < this.g.a(A_0))
				{
					num = this.g.a(A_0);
				}
			}
			return num;
		}

		// Token: 0x060050EE RID: 20718 RVA: 0x00284CC8 File Offset: 0x00283CC8
		private void d()
		{
			if (Math.Abs(base.Offset) >= this.k && Math.Abs(base.Offset) > 0f)
			{
				this.k = 0f;
			}
			else if (Math.Abs(base.Offset) < this.k && Math.Abs(base.Offset) > 0f)
			{
				this.k -= Math.Abs(base.Offset);
			}
		}

		// Token: 0x060050EF RID: 20719 RVA: 0x00284D5C File Offset: 0x00283D5C
		internal new float m()
		{
			float result = 0f;
			float num = 0f;
			if (this.h.Visible)
			{
				num = this.h.i() + base.LabelOffset;
			}
			this.e();
			switch (this.b)
			{
			case YAxisLabelPosition.LeftOfPlotArea:
				switch (this.a)
				{
				case YAxisAnchorType.Left:
					result = num + this.k;
					break;
				case YAxisAnchorType.Right:
					result = num;
					break;
				case YAxisAnchorType.Floating:
					if (this.b())
					{
						result = num + this.a(YAxisAnchorType.Left);
					}
					else
					{
						result = num + this.a(this.a(YAxisAnchorType.Left));
					}
					break;
				}
				break;
			case YAxisLabelPosition.RightOfPlotArea:
				switch (this.a)
				{
				case YAxisAnchorType.Left:
					result = this.k;
					break;
				case YAxisAnchorType.Floating:
					if (this.b())
					{
						result = this.a(YAxisAnchorType.Left);
					}
					else
					{
						result = this.a(this.a(YAxisAnchorType.Left));
					}
					break;
				}
				break;
			case YAxisLabelPosition.LeftOfYAxis:
				switch (this.a)
				{
				case YAxisAnchorType.Left:
					this.m = num + this.a(YAxisAnchorType.Left);
					if (Math.Abs(base.Offset) == 0f)
					{
						result = num + this.k;
					}
					else if (Math.Abs(base.Offset) <= num + this.k)
					{
						result = num + this.k - Math.Abs(base.Offset);
					}
					break;
				case YAxisAnchorType.Right:
					if (this.c == YAxisTitlePosition.LeftOfYAxis)
					{
						this.m = num + this.a(YAxisAnchorType.Left);
					}
					break;
				case YAxisAnchorType.Floating:
					this.m = num + this.a(YAxisAnchorType.Left);
					if (this.b())
					{
						result = num + this.a(YAxisAnchorType.Left);
					}
					else
					{
						result = this.a(num + this.a(YAxisAnchorType.Left));
					}
					break;
				}
				break;
			case YAxisLabelPosition.RightOfYAxis:
				switch (this.a)
				{
				case YAxisAnchorType.Left:
					if (this.c == YAxisTitlePosition.RightOfYAxis)
					{
						this.m = num + this.a(YAxisAnchorType.Right);
					}
					if (Math.Abs(base.Offset) == 0f)
					{
						result = this.k;
					}
					else if (Math.Abs(base.Offset) <= this.k)
					{
						result = this.k - Math.Abs(base.Offset);
					}
					break;
				case YAxisAnchorType.Floating:
					if (this.c == YAxisTitlePosition.RightOfYAxis)
					{
						this.m = num + this.a(YAxisAnchorType.Right);
					}
					if (this.b())
					{
						result = this.a(YAxisAnchorType.Left);
					}
					else
					{
						result = this.a(this.a(YAxisAnchorType.Left));
					}
					break;
				}
				break;
			case YAxisLabelPosition.Automatic:
				switch (this.a)
				{
				case YAxisAnchorType.Left:
					result = num + this.k;
					break;
				case YAxisAnchorType.Floating:
					if (this.b())
					{
						result = num + this.a(YAxisAnchorType.Left);
					}
					else if (this.a(this.a(YAxisAnchorType.Left)) > 0f)
					{
						result = num + this.a(this.a(YAxisAnchorType.Left));
					}
					else
					{
						result = num;
					}
					break;
				}
				break;
			}
			return result;
		}

		// Token: 0x060050F0 RID: 20720 RVA: 0x002850B4 File Offset: 0x002840B4
		internal new float n()
		{
			float result = 0f;
			float num = 0f;
			if (this.h != null)
			{
				for (int i = 0; i < this.h.Count; i++)
				{
					Title title = this.h[i];
					title.a(base.u().Chart);
					num += title.a();
				}
				switch (this.c)
				{
				case YAxisTitlePosition.LeftOfPlotArea:
					result = num;
					break;
				case YAxisTitlePosition.LeftOfYAxis:
					switch (this.a)
					{
					case YAxisAnchorType.Left:
						if (this.b == YAxisLabelPosition.LeftOfYAxis)
						{
							if (base.Offset == 0f)
							{
								result = num;
							}
							else if (base.Offset > 0f)
							{
								if (this.m() > 0f)
								{
									result = num;
								}
								else if (base.Offset >= this.m && base.Offset <= this.m + num)
								{
									result = this.m + num - base.Offset;
								}
							}
						}
						else
						{
							float num2 = this.m();
							if (base.Offset == 0f)
							{
								result = num;
								this.m = num2;
							}
							else if (base.Offset > 0f)
							{
								this.m = this.a(YAxisAnchorType.Left);
								if (base.Offset <= this.m + num && this.m + num - base.Offset > num2)
								{
									result = num + this.m - base.Offset - num2;
								}
							}
						}
						break;
					case YAxisAnchorType.Right:
						if (this.b == YAxisLabelPosition.Automatic || this.b == YAxisLabelPosition.RightOfPlotArea)
						{
							this.m = this.a(YAxisAnchorType.Left);
						}
						break;
					case YAxisAnchorType.Floating:
						if (this.b == YAxisLabelPosition.LeftOfYAxis)
						{
							if (this.b())
							{
								result = num;
							}
							else if (base.Offset > 0f)
							{
								if (this.m() > 0f)
								{
									result = num;
								}
								else if (this.a() >= this.m && this.a() <= this.m + num)
								{
									result = this.m + num - this.a();
								}
							}
						}
						else
						{
							float num2 = this.m();
							if (this.b())
							{
								result = num;
								this.m = num2;
							}
							else if (this.a(num + this.a(YAxisAnchorType.Left)) > num2)
							{
								result = this.a(num + this.a(YAxisAnchorType.Left)) - num2;
								this.m = this.a(YAxisAnchorType.Left);
							}
							else if (this.a(num + this.a(YAxisAnchorType.Left)) < num2 || this.a(num + this.a(YAxisAnchorType.Left)) == 0f)
							{
								this.m = this.a(YAxisAnchorType.Left);
							}
						}
						break;
					}
					break;
				case YAxisTitlePosition.RightOfYAxis:
					switch (this.a)
					{
					case YAxisAnchorType.Left:
					case YAxisAnchorType.Floating:
						if (this.b != YAxisLabelPosition.RightOfYAxis)
						{
							this.m = this.a(YAxisAnchorType.Right);
						}
						break;
					}
					break;
				case YAxisTitlePosition.Automatic:
					switch (this.a)
					{
					case YAxisAnchorType.Left:
					case YAxisAnchorType.Floating:
						result = num;
						break;
					}
					break;
				}
			}
			return result;
		}

		// Token: 0x060050F1 RID: 20721 RVA: 0x002854A0 File Offset: 0x002844A0
		internal new float o()
		{
			float result = 0f;
			float num = 0f;
			if (this.h.Visible)
			{
				num = this.h.i() + base.LabelOffset;
			}
			if (this.a == YAxisAnchorType.Right)
			{
				if (this.g != null && this.f.Position == YAxisTickMarksPosition.Automatic)
				{
					this.f.Position = YAxisTickMarksPosition.Right;
				}
				if (this.g != null && this.g.Position == YAxisTickMarksPosition.Automatic)
				{
					this.g.Position = YAxisTickMarksPosition.Right;
				}
			}
			this.e();
			switch (this.b)
			{
			case YAxisLabelPosition.LeftOfPlotArea:
				switch (this.a)
				{
				case YAxisAnchorType.Right:
					result = this.k;
					break;
				case YAxisAnchorType.Floating:
					if (this.c())
					{
						result = this.k;
					}
					break;
				}
				break;
			case YAxisLabelPosition.RightOfPlotArea:
				switch (this.a)
				{
				case YAxisAnchorType.Left:
					result = num;
					break;
				case YAxisAnchorType.Right:
					result = num + this.k;
					break;
				case YAxisAnchorType.Floating:
					if (this.c())
					{
						result = num + this.k;
					}
					else
					{
						result = num;
					}
					break;
				}
				break;
			case YAxisLabelPosition.LeftOfYAxis:
				switch (this.a)
				{
				case YAxisAnchorType.Right:
					if (Math.Abs(base.Offset) == 0f)
					{
						result = this.k;
					}
					else if (Math.Abs(base.Offset) <= this.k)
					{
						result = this.k - Math.Abs(base.Offset);
					}
					break;
				case YAxisAnchorType.Floating:
					if (this.c())
					{
						result = this.k;
					}
					break;
				}
				break;
			case YAxisLabelPosition.RightOfYAxis:
				switch (this.a)
				{
				case YAxisAnchorType.Right:
					if (this.c == YAxisTitlePosition.RightOfYAxis)
					{
						this.m = num + this.a(YAxisAnchorType.Right);
					}
					if (Math.Abs(base.Offset) == 0f)
					{
						result = num + this.k;
					}
					else if (Math.Abs(base.Offset) <= num + this.k)
					{
						result = num + this.k - Math.Abs(base.Offset);
					}
					break;
				case YAxisAnchorType.Floating:
					if (this.c())
					{
						result = num + this.k;
					}
					break;
				}
				break;
			case YAxisLabelPosition.Automatic:
				switch (this.a)
				{
				case YAxisAnchorType.Right:
					result = num + this.k;
					break;
				case YAxisAnchorType.Floating:
					if (this.c())
					{
						result = this.k;
					}
					break;
				}
				break;
			}
			return result;
		}

		// Token: 0x060050F2 RID: 20722 RVA: 0x00285784 File Offset: 0x00284784
		internal new float p()
		{
			float result = 0f;
			float num = 0f;
			if (this.h != null)
			{
				for (int i = 0; i < this.h.Count; i++)
				{
					Title title = this.h[i];
					num += title.a();
				}
				switch (this.c)
				{
				case YAxisTitlePosition.RightOfPlotArea:
					result = num;
					break;
				case YAxisTitlePosition.LeftOfYAxis:
				{
					YAxisAnchorType yaxisAnchorType = this.a;
					if (yaxisAnchorType == YAxisAnchorType.Right)
					{
						if (this.b != YAxisLabelPosition.LeftOfYAxis)
						{
							this.m = this.a(YAxisAnchorType.Left);
						}
					}
					break;
				}
				case YAxisTitlePosition.RightOfYAxis:
				{
					YAxisAnchorType yaxisAnchorType = this.a;
					if (yaxisAnchorType == YAxisAnchorType.Right)
					{
						if (this.b == YAxisLabelPosition.RightOfYAxis)
						{
							if (base.Offset == 0f)
							{
								result = num;
							}
							else if (Math.Abs(base.Offset) > 0f)
							{
								if (this.o() > 0f)
								{
									result = num;
								}
								else if (Math.Abs(base.Offset) >= this.m && Math.Abs(base.Offset) <= this.m + num)
								{
									result = this.m + num - Math.Abs(base.Offset);
								}
							}
						}
						else
						{
							float num2 = this.o();
							if (base.Offset == 0f)
							{
								result = num;
								this.m = num2;
							}
							else if (Math.Abs(base.Offset) > 0f)
							{
								this.m = this.a(YAxisAnchorType.Right);
								if (Math.Abs(base.Offset) <= this.m + num && this.m + num - Math.Abs(base.Offset) > num2)
								{
									result = num + this.m - Math.Abs(base.Offset) - num2;
								}
							}
						}
					}
					break;
				}
				case YAxisTitlePosition.Automatic:
				{
					YAxisAnchorType yaxisAnchorType = this.a;
					if (yaxisAnchorType == YAxisAnchorType.Right)
					{
						result = num;
					}
					break;
				}
				}
			}
			return result;
		}

		// Token: 0x060050F3 RID: 20723 RVA: 0x002859D8 File Offset: 0x002849D8
		internal float q()
		{
			return this.m;
		}

		// Token: 0x060050F4 RID: 20724 RVA: 0x002859F0 File Offset: 0x002849F0
		private bool c()
		{
			return (int)base.u().Width == (int)(base.u().i().h() * base.u().i().g() + base.u().i().g() * base.u().i().s() + base.Offset * base.u().i().g() / base.u().i().t());
		}

		// Token: 0x060050F5 RID: 20725 RVA: 0x00285A8C File Offset: 0x00284A8C
		private bool b()
		{
			return (int)base.u().X == (int)(base.u().X + base.u().i().h() * base.u().i().g() + base.u().i().g() * base.u().i().s() + base.Offset * base.u().i().g() / base.u().i().t());
		}

		// Token: 0x060050F6 RID: 20726 RVA: 0x00285B34 File Offset: 0x00284B34
		private float a(float A_0)
		{
			float num = base.u().i().h() * base.u().i().g() + base.u().i().g() * base.u().i().s() + base.Offset * base.u().i().g() / base.u().i().t();
			float result;
			if (A_0 > num)
			{
				result = A_0 - num;
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x060050F7 RID: 20727 RVA: 0x00285BCC File Offset: 0x00284BCC
		private float a()
		{
			return base.u().i().h() * base.u().i().g() + base.u().i().g() * base.u().i().s() + base.Offset * base.u().i().g() / base.u().i().t();
		}

		// Token: 0x04002B65 RID: 11109
		private YAxisAnchorType a = YAxisAnchorType.Left;

		// Token: 0x04002B66 RID: 11110
		private new YAxisLabelPosition b = YAxisLabelPosition.Automatic;

		// Token: 0x04002B67 RID: 11111
		private YAxisTitlePosition c = YAxisTitlePosition.Automatic;

		// Token: 0x04002B68 RID: 11112
		private new YAxisGridLines d;

		// Token: 0x04002B69 RID: 11113
		private YAxisGridLines e;

		// Token: 0x04002B6A RID: 11114
		private YAxisTickMarks f;

		// Token: 0x04002B6B RID: 11115
		private new YAxisTickMarks g;

		// Token: 0x04002B6C RID: 11116
		private new TitleList h;

		// Token: 0x04002B6D RID: 11117
		private new float i = 0f;

		// Token: 0x04002B6E RID: 11118
		private new int j;

		// Token: 0x04002B6F RID: 11119
		private float k;

		// Token: 0x04002B70 RID: 11120
		private new float l;

		// Token: 0x04002B71 RID: 11121
		private new float m;
	}
}
