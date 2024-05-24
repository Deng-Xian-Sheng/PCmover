using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007B7 RID: 1975
	public abstract class XAxis : Axis
	{
		// Token: 0x0600507B RID: 20603 RVA: 0x00280A40 File Offset: 0x0027FA40
		internal XAxis()
		{
		}

		// Token: 0x0600507C RID: 20604 RVA: 0x00280A60 File Offset: 0x0027FA60
		internal XAxis(float A_0) : base(A_0)
		{
			this.h = new TitleList(null);
		}

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x0600507D RID: 20605 RVA: 0x00280A90 File Offset: 0x0027FA90
		// (set) Token: 0x0600507E RID: 20606 RVA: 0x00280AA8 File Offset: 0x0027FAA8
		public XAxisAnchorType AnchorType
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

		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x0600507F RID: 20607 RVA: 0x00280AB4 File Offset: 0x0027FAB4
		// (set) Token: 0x06005080 RID: 20608 RVA: 0x00280ACC File Offset: 0x0027FACC
		public XAxisLabelPosition LabelPosition
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

		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x06005081 RID: 20609 RVA: 0x00280AD8 File Offset: 0x0027FAD8
		// (set) Token: 0x06005082 RID: 20610 RVA: 0x00280AF0 File Offset: 0x0027FAF0
		public XAxisGridLines MajorGridLines
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

		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x06005083 RID: 20611 RVA: 0x00280AFC File Offset: 0x0027FAFC
		// (set) Token: 0x06005084 RID: 20612 RVA: 0x00280B14 File Offset: 0x0027FB14
		public XAxisGridLines MinorGridLines
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

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x06005085 RID: 20613 RVA: 0x00280B20 File Offset: 0x0027FB20
		// (set) Token: 0x06005086 RID: 20614 RVA: 0x00280B38 File Offset: 0x0027FB38
		public XAxisTickMarks MajorTickMarks
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

		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x06005087 RID: 20615 RVA: 0x00280B80 File Offset: 0x0027FB80
		// (set) Token: 0x06005088 RID: 20616 RVA: 0x00280B98 File Offset: 0x0027FB98
		public XAxisTickMarks MinorTickMarks
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

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x06005089 RID: 20617 RVA: 0x00280BE0 File Offset: 0x0027FBE0
		public TitleList Titles
		{
			get
			{
				return this.h;
			}
		}

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x0600508A RID: 20618 RVA: 0x00280BF8 File Offset: 0x0027FBF8
		// (set) Token: 0x0600508B RID: 20619 RVA: 0x00280C10 File Offset: 0x0027FC10
		public XAxisTitlePosition TitlePosition
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

		// Token: 0x0600508C RID: 20620 RVA: 0x00280C1C File Offset: 0x0027FC1C
		internal new float g()
		{
			return this.i;
		}

		// Token: 0x0600508D RID: 20621 RVA: 0x00280C34 File Offset: 0x0027FC34
		internal new float h()
		{
			return this.l;
		}

		// Token: 0x0600508E RID: 20622 RVA: 0x00280C4C File Offset: 0x0027FC4C
		internal new void i()
		{
			if (this.m > this.l)
			{
				this.i = base.u().Width / ((this.m - this.l) / this.g + base.s() * 2f);
				this.j = 1 + (int)((this.m - this.l) / this.g);
				if (this.l < 0f)
				{
					this.l = Math.Abs(this.l) / this.g;
				}
			}
			else if (this.m == this.l)
			{
				this.i = base.u().Width;
				this.j = 1;
			}
		}

		// Token: 0x0600508F RID: 20623 RVA: 0x00280D24 File Offset: 0x0027FD24
		internal new int j()
		{
			return this.j;
		}

		// Token: 0x06005090 RID: 20624 RVA: 0x00280D3C File Offset: 0x0027FD3C
		internal void k()
		{
			if (this.f == null)
			{
				this.f = new XAxisTickMarks();
				this.f.Length = 4f;
				this.f.Visible = base.Visible;
			}
		}

		// Token: 0x06005091 RID: 20625 RVA: 0x00280D8C File Offset: 0x0027FD8C
		internal new void l()
		{
			if (this.g == null)
			{
				this.g = new XAxisTickMarks();
				this.g.Length = 2f;
				this.g.Visible = base.Visible;
			}
		}

		// Token: 0x06005092 RID: 20626 RVA: 0x00280DDC File Offset: 0x0027FDDC
		internal float b(XAxisAnchorType A_0)
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

		// Token: 0x06005093 RID: 20627 RVA: 0x00280E2C File Offset: 0x0027FE2C
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

		// Token: 0x06005094 RID: 20628 RVA: 0x00280EAC File Offset: 0x0027FEAC
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
					if (this.a == XAxisAnchorType.Bottom)
					{
						A_0.Write_m_(base.u().X - base.u().YAxes.d(), base.u().Y + base.u().Height - base.Offset);
						A_0.Write_l_(base.u().X + base.u().Width + base.u().YAxes.e(), base.u().Y + base.u().Height - base.Offset);
					}
					else if (this.a == XAxisAnchorType.Top)
					{
						A_0.Write_m_(base.u().X - base.u().YAxes.d(), base.u().Y - base.Offset);
						A_0.Write_l_(base.u().X + base.u().Width + base.u().YAxes.e(), base.u().Y - base.Offset);
					}
					else if (this.a == XAxisAnchorType.Floating)
					{
						A_0.Write_m_(base.u().X - base.u().YAxes.d(), base.u().Y + base.u().Height - base.u().j().h() * base.u().j().g() - base.u().j().g() * base.u().j().s() - base.Offset * (base.u().j().g() / base.u().j().t()));
						A_0.Write_l_(base.u().X + base.u().Width + base.u().YAxes.e(), base.u().Y + base.u().Height - base.u().j().h() * base.u().j().g() - base.u().j().g() * base.u().j().s() - base.Offset * (base.u().j().g() / base.u().j().t()));
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

		// Token: 0x06005095 RID: 20629 RVA: 0x00281238 File Offset: 0x00280238
		internal void c(PageWriter A_0)
		{
			if (this.h.Visible)
			{
				this.f();
				XAxisLabelList xaxisLabelList = (XAxisLabelList)this.h;
				xaxisLabelList.a(A_0, base.u(), this);
			}
			if (this.h != null)
			{
				this.h.a(A_0, base.u(), this);
			}
		}

		// Token: 0x06005096 RID: 20630 RVA: 0x002812A0 File Offset: 0x002802A0
		private void f()
		{
			if (this.b == XAxisLabelPosition.BelowXAxis && this.a == XAxisAnchorType.Top)
			{
				this.k = this.a(XAxisAnchorType.Bottom);
			}
			else if (this.b == XAxisLabelPosition.AboveXAxis && (this.a == XAxisAnchorType.Bottom || this.a == XAxisAnchorType.Floating))
			{
				this.k = this.a(XAxisAnchorType.Top);
			}
			else if (this.b == XAxisLabelPosition.AbovePlotArea && this.a == XAxisAnchorType.Floating)
			{
				if (this.a())
				{
					this.k = this.a(XAxisAnchorType.Top);
				}
				else
				{
					this.k = 0f;
				}
			}
			else if (this.b == XAxisLabelPosition.BelowPlotArea || this.b == XAxisLabelPosition.Automatic)
			{
				if (this.a == XAxisAnchorType.Floating)
				{
					if (this.c())
					{
						this.k = this.a(XAxisAnchorType.Floating);
					}
					else if (this.a(this.a(XAxisAnchorType.Floating)) > 0f)
					{
						this.k = this.a(this.a(XAxisAnchorType.Floating));
					}
					else
					{
						this.k = 0f;
					}
				}
				else if (this.a == XAxisAnchorType.Bottom)
				{
					this.e();
				}
			}
			else if (this.b == XAxisLabelPosition.Automatic && this.a == XAxisAnchorType.Bottom)
			{
				this.e();
			}
			else if (this.b == XAxisLabelPosition.Automatic && this.a == XAxisAnchorType.Top)
			{
				this.e();
			}
			else if (this.b == XAxisLabelPosition.AbovePlotArea && this.a == XAxisAnchorType.Top)
			{
				this.e();
			}
			else
			{
				this.k = this.a(this.a);
			}
		}

		// Token: 0x06005097 RID: 20631 RVA: 0x0028149C File Offset: 0x0028049C
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
			if (this.k != 0f && this.b != XAxisLabelPosition.AboveXAxis && this.b != XAxisLabelPosition.BelowXAxis)
			{
				this.d();
			}
		}

		// Token: 0x06005098 RID: 20632 RVA: 0x002815B4 File Offset: 0x002805B4
		private float a(XAxisAnchorType A_0)
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

		// Token: 0x06005099 RID: 20633 RVA: 0x0028163C File Offset: 0x0028063C
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

		// Token: 0x0600509A RID: 20634 RVA: 0x002816D0 File Offset: 0x002806D0
		internal new float m()
		{
			float result = 0f;
			float num = 0f;
			if (this.h.Visible)
			{
				XAxisLabelList xaxisLabelList = (XAxisLabelList)this.h;
				num = xaxisLabelList.a(this.i) + base.LabelOffset;
			}
			if (this.a == XAxisAnchorType.Top)
			{
				if (this.f != null)
				{
					if (this.f.Position == XAxisTickMarksPosition.Automatic)
					{
						this.f.Position = XAxisTickMarksPosition.Above;
					}
				}
				if (this.g != null)
				{
					if (this.g.Position == XAxisTickMarksPosition.Automatic)
					{
						this.g.Position = XAxisTickMarksPosition.Above;
					}
				}
			}
			this.e();
			switch (this.b)
			{
			case XAxisLabelPosition.BelowPlotArea:
				switch (this.a)
				{
				case XAxisAnchorType.Top:
					result = this.k;
					break;
				case XAxisAnchorType.Floating:
					if (this.a())
					{
						result = this.a(XAxisAnchorType.Top);
					}
					break;
				}
				break;
			case XAxisLabelPosition.AbovePlotArea:
				switch (this.a)
				{
				case XAxisAnchorType.Bottom:
					result = num;
					break;
				case XAxisAnchorType.Top:
					result = num + this.k;
					break;
				case XAxisAnchorType.Floating:
					if (this.a())
					{
						result = num + this.a(XAxisAnchorType.Top);
					}
					else
					{
						result = num;
					}
					break;
				}
				break;
			case XAxisLabelPosition.BelowXAxis:
				switch (this.a)
				{
				case XAxisAnchorType.Top:
					if (Math.Abs(base.Offset) == 0f)
					{
						result = this.k;
					}
					else if (Math.Abs(base.Offset) <= this.k)
					{
						result = this.k - Math.Abs(base.Offset);
					}
					break;
				case XAxisAnchorType.Floating:
					if (this.a())
					{
						result = this.a(XAxisAnchorType.Top);
					}
					break;
				}
				break;
			case XAxisLabelPosition.AboveXAxis:
				switch (this.a)
				{
				case XAxisAnchorType.Top:
					if (this.c == XAxisTitlePosition.AboveXAxis)
					{
						this.m = num + this.a(XAxisAnchorType.Top);
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
				case XAxisAnchorType.Floating:
					if (this.a())
					{
						result = num + this.a(XAxisAnchorType.Top);
					}
					break;
				}
				break;
			case XAxisLabelPosition.Automatic:
				switch (this.a)
				{
				case XAxisAnchorType.Top:
					result = num + this.k;
					break;
				case XAxisAnchorType.Floating:
					if (this.a())
					{
						result = this.a(XAxisAnchorType.Top);
					}
					break;
				}
				break;
			}
			return result;
		}

		// Token: 0x0600509B RID: 20635 RVA: 0x002819EC File Offset: 0x002809EC
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
				case XAxisTitlePosition.AbovePlotArea:
					result = num;
					break;
				case XAxisTitlePosition.BelowXAxis:
				{
					XAxisAnchorType xaxisAnchorType = this.a;
					if (xaxisAnchorType == XAxisAnchorType.Top)
					{
						this.m = this.a(XAxisAnchorType.Bottom);
					}
					break;
				}
				case XAxisTitlePosition.AboveXAxis:
				{
					XAxisAnchorType xaxisAnchorType = this.a;
					if (xaxisAnchorType == XAxisAnchorType.Top)
					{
						if (this.b == XAxisLabelPosition.AboveXAxis)
						{
							if (base.Offset == 0f)
							{
								result = num;
							}
							else if (Math.Abs(base.Offset) > 0f)
							{
								if (this.m() > 0f)
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
							float num2 = this.m();
							if (base.Offset == 0f)
							{
								result = num;
								this.m = num2;
							}
							else if (Math.Abs(base.Offset) > 0f)
							{
								this.m = this.a(XAxisAnchorType.Top);
								if (Math.Abs(base.Offset) <= this.m + num && this.m + num - Math.Abs(base.Offset) > num2)
								{
									result = num + this.m - Math.Abs(base.Offset) - num2;
								}
							}
						}
					}
					break;
				}
				case XAxisTitlePosition.Automatic:
				{
					XAxisAnchorType xaxisAnchorType = this.a;
					if (xaxisAnchorType == XAxisAnchorType.Top)
					{
						result = num;
					}
					break;
				}
				}
			}
			return result;
		}

		// Token: 0x0600509C RID: 20636 RVA: 0x00281C44 File Offset: 0x00280C44
		internal new float o()
		{
			float result = 0f;
			float num = 0f;
			if (this.h.Visible)
			{
				XAxisLabelList xaxisLabelList = (XAxisLabelList)this.h;
				num = xaxisLabelList.a(this.i) + base.LabelOffset;
			}
			this.e();
			switch (this.b)
			{
			case XAxisLabelPosition.BelowPlotArea:
				switch (this.a)
				{
				case XAxisAnchorType.Bottom:
					result = num + this.k;
					break;
				case XAxisAnchorType.Top:
					result = num;
					break;
				case XAxisAnchorType.Floating:
					if (this.c())
					{
						result = num + this.a(XAxisAnchorType.Floating);
					}
					else
					{
						result = num + this.a(this.a(XAxisAnchorType.Floating));
					}
					break;
				}
				break;
			case XAxisLabelPosition.AbovePlotArea:
				switch (this.a)
				{
				case XAxisAnchorType.Bottom:
					result = this.k;
					break;
				case XAxisAnchorType.Floating:
					if (this.c())
					{
						result = this.a(XAxisAnchorType.Floating);
					}
					break;
				}
				break;
			case XAxisLabelPosition.BelowXAxis:
				switch (this.a)
				{
				case XAxisAnchorType.Bottom:
					this.m = num + this.a(XAxisAnchorType.Bottom);
					if (base.Offset == 0f)
					{
						result = num + this.k;
					}
					else if (base.Offset <= num + this.k)
					{
						result = num + this.k - base.Offset;
					}
					break;
				case XAxisAnchorType.Top:
					if (this.c == XAxisTitlePosition.BelowXAxis)
					{
						this.m = num + this.a(XAxisAnchorType.Bottom);
					}
					break;
				case XAxisAnchorType.Floating:
					this.m = num + this.a(XAxisAnchorType.Floating);
					if (this.c())
					{
						result = num + this.a(XAxisAnchorType.Floating);
					}
					else
					{
						result = this.a(num + this.a(XAxisAnchorType.Floating));
					}
					break;
				}
				break;
			case XAxisLabelPosition.AboveXAxis:
				switch (this.a)
				{
				case XAxisAnchorType.Bottom:
					if (this.c == XAxisTitlePosition.AboveXAxis)
					{
						this.m = num + this.a(XAxisAnchorType.Top);
					}
					if (base.Offset == 0f)
					{
						result = this.k;
					}
					else if (base.Offset <= this.k)
					{
						result = this.k - base.Offset;
					}
					break;
				case XAxisAnchorType.Floating:
					if (this.c == XAxisTitlePosition.AboveXAxis)
					{
						this.m = num + this.a(XAxisAnchorType.Top);
					}
					if (this.c())
					{
						result = this.a(XAxisAnchorType.Floating);
					}
					break;
				}
				break;
			case XAxisLabelPosition.Automatic:
				switch (this.a)
				{
				case XAxisAnchorType.Bottom:
					result = num + this.k;
					break;
				case XAxisAnchorType.Floating:
					if (this.c())
					{
						result = num + this.a(XAxisAnchorType.Floating);
					}
					else if (this.a(this.a(XAxisAnchorType.Floating)) > 0f)
					{
						result = num + this.a(this.a(XAxisAnchorType.Floating));
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

		// Token: 0x0600509D RID: 20637 RVA: 0x00281F88 File Offset: 0x00280F88
		internal new float p()
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
				case XAxisTitlePosition.BelowPlotArea:
					result = num;
					break;
				case XAxisTitlePosition.BelowXAxis:
					switch (this.a)
					{
					case XAxisAnchorType.Bottom:
						if (this.b == XAxisLabelPosition.BelowXAxis)
						{
							if (base.Offset == 0f)
							{
								result = num;
							}
							else if (base.Offset > 0f)
							{
								if (this.o() > 0f)
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
							float num2 = this.o();
							if (base.Offset == 0f)
							{
								result = num;
								this.m = num2;
							}
							else if (base.Offset > 0f)
							{
								this.m = this.a(XAxisAnchorType.Bottom);
								if (base.Offset <= this.m + num && this.m + num - base.Offset > num2)
								{
									result = num + this.m - base.Offset - num2;
								}
							}
						}
						break;
					case XAxisAnchorType.Top:
						if (this.b == XAxisLabelPosition.Automatic || this.b == XAxisLabelPosition.AbovePlotArea)
						{
							this.m = this.a(XAxisAnchorType.Bottom);
						}
						break;
					case XAxisAnchorType.Floating:
						if (this.b == XAxisLabelPosition.BelowXAxis)
						{
							if (this.c())
							{
								result = num;
							}
							else if (base.Offset > 0f)
							{
								if (this.o() > 0f)
								{
									result = num;
								}
								else if (this.b() >= this.m && this.b() <= this.m + num)
								{
									result = this.m + num - this.b();
								}
							}
						}
						else
						{
							float num2 = this.o();
							if (this.c())
							{
								result = num;
								this.m = num2;
							}
							else if (this.a(num + this.a(XAxisAnchorType.Floating)) > num2)
							{
								result = this.a(num + this.a(XAxisAnchorType.Floating)) - num2;
								this.m = this.a(XAxisAnchorType.Floating);
							}
							else if (this.a(num + this.a(XAxisAnchorType.Floating)) < num2 || this.a(num + this.a(XAxisAnchorType.Floating)) == 0f)
							{
								this.m = this.a(XAxisAnchorType.Floating);
							}
						}
						break;
					}
					break;
				case XAxisTitlePosition.AboveXAxis:
					switch (this.a)
					{
					case XAxisAnchorType.Bottom:
					case XAxisAnchorType.Floating:
						if (this.b != XAxisLabelPosition.AboveXAxis)
						{
							this.m = this.a(XAxisAnchorType.Top);
						}
						break;
					}
					break;
				case XAxisTitlePosition.Automatic:
					switch (this.a)
					{
					case XAxisAnchorType.Bottom:
					case XAxisAnchorType.Floating:
						result = num;
						break;
					}
					break;
				}
			}
			return result;
		}

		// Token: 0x0600509E RID: 20638 RVA: 0x00282374 File Offset: 0x00281374
		internal float q()
		{
			return this.m;
		}

		// Token: 0x0600509F RID: 20639 RVA: 0x0028238C File Offset: 0x0028138C
		private bool c()
		{
			return (int)(base.u().Y + base.u().Height) == (int)(base.u().Y + base.u().Height - base.u().j().h() * base.u().j().g() - base.u().j().g() * base.u().j().s() - base.Offset * base.u().j().g() / base.u().j().t());
		}

		// Token: 0x060050A0 RID: 20640 RVA: 0x0028244C File Offset: 0x0028144C
		private float a(float A_0)
		{
			float num = base.u().j().h() * base.u().j().g() + base.u().j().g() * base.u().j().s() + base.Offset * base.u().j().g() / base.u().j().t();
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

		// Token: 0x060050A1 RID: 20641 RVA: 0x002824E4 File Offset: 0x002814E4
		private float b()
		{
			return base.u().j().h() * base.u().j().g() + base.u().j().g() * base.u().j().s() + base.Offset * base.u().j().g() / base.u().j().t();
		}

		// Token: 0x060050A2 RID: 20642 RVA: 0x00282564 File Offset: 0x00281564
		private bool a()
		{
			return (int)base.u().Y == (int)(base.u().Y + base.u().Height - base.u().j().h() * base.u().j().g() - base.u().j().g() * base.u().j().s() - base.Offset * base.u().j().g() / base.u().j().t());
		}

		// Token: 0x04002B4E RID: 11086
		private XAxisAnchorType a = XAxisAnchorType.Bottom;

		// Token: 0x04002B4F RID: 11087
		private new XAxisLabelPosition b = XAxisLabelPosition.Automatic;

		// Token: 0x04002B50 RID: 11088
		private XAxisTitlePosition c = XAxisTitlePosition.Automatic;

		// Token: 0x04002B51 RID: 11089
		private new XAxisGridLines d;

		// Token: 0x04002B52 RID: 11090
		private XAxisGridLines e;

		// Token: 0x04002B53 RID: 11091
		private XAxisTickMarks f;

		// Token: 0x04002B54 RID: 11092
		private new XAxisTickMarks g;

		// Token: 0x04002B55 RID: 11093
		private new TitleList h;

		// Token: 0x04002B56 RID: 11094
		private new float i;

		// Token: 0x04002B57 RID: 11095
		private new int j;

		// Token: 0x04002B58 RID: 11096
		private float k;

		// Token: 0x04002B59 RID: 11097
		private new float l;

		// Token: 0x04002B5A RID: 11098
		private new float m;
	}
}
