using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Charting.Series
{
	// Token: 0x020008C3 RID: 2243
	public class PieSeries : SeriesBase
	{
		// Token: 0x06005BBD RID: 23485 RVA: 0x0033FF79 File Offset: 0x0033EF79
		public PieSeries() : this(null, 0f, null, null)
		{
		}

		// Token: 0x06005BBE RID: 23486 RVA: 0x0033FF8C File Offset: 0x0033EF8C
		public PieSeries(SeriesLabel seriesLabel) : this(seriesLabel, 0f, null, null)
		{
		}

		// Token: 0x06005BBF RID: 23487 RVA: 0x0033FF9F File Offset: 0x0033EF9F
		public PieSeries(Legend legend) : this(null, 0f, null, legend)
		{
		}

		// Token: 0x06005BC0 RID: 23488 RVA: 0x0033FFB2 File Offset: 0x0033EFB2
		public PieSeries(float borderWidth, Color borderColor) : this(null, borderWidth, borderColor, null)
		{
		}

		// Token: 0x06005BC1 RID: 23489 RVA: 0x0033FFC1 File Offset: 0x0033EFC1
		public PieSeries(float borderWidth, Color borderColor, Legend legend) : this(null, borderWidth, borderColor, legend)
		{
		}

		// Token: 0x06005BC2 RID: 23490 RVA: 0x0033FFD0 File Offset: 0x0033EFD0
		public PieSeries(SeriesLabel seriesLabel, float borderWidth, Color borderColor, Legend legend)
		{
			this.n = seriesLabel;
			base.DrawBehindAxis = true;
			if (legend != null)
			{
				base.Legend = legend;
			}
			this.d = borderWidth;
			this.e = borderColor;
			this.a = new PieSeriesElementList(this);
		}

		// Token: 0x17000971 RID: 2417
		// (get) Token: 0x06005BC3 RID: 23491 RVA: 0x003400A0 File Offset: 0x0033F0A0
		public PieSeriesElementList Elements
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000972 RID: 2418
		// (get) Token: 0x06005BC4 RID: 23492 RVA: 0x003400B8 File Offset: 0x0033F0B8
		// (set) Token: 0x06005BC5 RID: 23493 RVA: 0x003400D0 File Offset: 0x0033F0D0
		public float BorderWidth
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

		// Token: 0x17000973 RID: 2419
		// (get) Token: 0x06005BC6 RID: 23494 RVA: 0x003400DC File Offset: 0x0033F0DC
		// (set) Token: 0x06005BC7 RID: 23495 RVA: 0x003400F4 File Offset: 0x0033F0F4
		public Color BorderColor
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

		// Token: 0x17000974 RID: 2420
		// (get) Token: 0x06005BC8 RID: 23496 RVA: 0x00340100 File Offset: 0x0033F100
		// (set) Token: 0x06005BC9 RID: 23497 RVA: 0x00340118 File Offset: 0x0033F118
		public SeriesLabel Label
		{
			get
			{
				return this.n;
			}
			set
			{
				this.n = value;
			}
		}

		// Token: 0x17000975 RID: 2421
		// (get) Token: 0x06005BCA RID: 23498 RVA: 0x00340124 File Offset: 0x0033F124
		// (set) Token: 0x06005BCB RID: 23499 RVA: 0x0034013C File Offset: 0x0033F13C
		public ScalarDataLabel DataLabel
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

		// Token: 0x17000976 RID: 2422
		// (get) Token: 0x06005BCC RID: 23500 RVA: 0x00340148 File Offset: 0x0033F148
		// (set) Token: 0x06005BCD RID: 23501 RVA: 0x00340160 File Offset: 0x0033F160
		public ScalarDataLabelPosition DataLabelPosition
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

		// Token: 0x17000977 RID: 2423
		// (get) Token: 0x06005BCE RID: 23502 RVA: 0x0034016C File Offset: 0x0033F16C
		// (set) Token: 0x06005BCF RID: 23503 RVA: 0x00340184 File Offset: 0x0033F184
		public float XOffset
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x17000978 RID: 2424
		// (get) Token: 0x06005BD0 RID: 23504 RVA: 0x00340190 File Offset: 0x0033F190
		// (set) Token: 0x06005BD1 RID: 23505 RVA: 0x003401A8 File Offset: 0x0033F1A8
		public float YOffset
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x17000979 RID: 2425
		// (get) Token: 0x06005BD2 RID: 23506 RVA: 0x003401B4 File Offset: 0x0033F1B4
		// (set) Token: 0x06005BD3 RID: 23507 RVA: 0x003401CC File Offset: 0x0033F1CC
		public float Radius
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
				this.r = true;
			}
		}

		// Token: 0x06005BD4 RID: 23508 RVA: 0x003401E0 File Offset: 0x0033F1E0
		internal bool a()
		{
			return this.r;
		}

		// Token: 0x1700097A RID: 2426
		// (get) Token: 0x06005BD5 RID: 23509 RVA: 0x003401F8 File Offset: 0x0033F1F8
		// (set) Token: 0x06005BD6 RID: 23510 RVA: 0x00340210 File Offset: 0x0033F210
		public float StartAngle
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

		// Token: 0x06005BD7 RID: 23511 RVA: 0x0034021A File Offset: 0x0033F21A
		public void SetArea(float x, float y, float width, float height)
		{
			this.j = x;
			this.k = y;
			this.l = width;
			this.m = height;
		}

		// Token: 0x1700097B RID: 2427
		// (get) Token: 0x06005BD8 RID: 23512 RVA: 0x0034023C File Offset: 0x0033F23C
		public float X
		{
			get
			{
				return this.j;
			}
		}

		// Token: 0x1700097C RID: 2428
		// (get) Token: 0x06005BD9 RID: 23513 RVA: 0x00340254 File Offset: 0x0033F254
		public float Y
		{
			get
			{
				return this.k;
			}
		}

		// Token: 0x1700097D RID: 2429
		// (get) Token: 0x06005BDA RID: 23514 RVA: 0x0034026C File Offset: 0x0033F26C
		public float Width
		{
			get
			{
				return this.l;
			}
		}

		// Token: 0x1700097E RID: 2430
		// (get) Token: 0x06005BDB RID: 23515 RVA: 0x00340284 File Offset: 0x0033F284
		public float Height
		{
			get
			{
				return this.m;
			}
		}

		// Token: 0x1700097F RID: 2431
		// (get) Token: 0x06005BDC RID: 23516 RVA: 0x0034029C File Offset: 0x0033F29C
		// (set) Token: 0x06005BDD RID: 23517 RVA: 0x003402B4 File Offset: 0x0033F2B4
		public string ValueFormat
		{
			get
			{
				return this.o;
			}
			set
			{
				this.o = value;
			}
		}

		// Token: 0x17000980 RID: 2432
		// (get) Token: 0x06005BDE RID: 23518 RVA: 0x003402C0 File Offset: 0x0033F2C0
		// (set) Token: 0x06005BDF RID: 23519 RVA: 0x003402D8 File Offset: 0x0033F2D8
		public string PercentageFormat
		{
			get
			{
				return this.p;
			}
			set
			{
				this.p = value;
			}
		}

		// Token: 0x06005BE0 RID: 23520 RVA: 0x003402E2 File Offset: 0x0033F2E2
		internal void a(int A_0)
		{
			this.q = A_0;
		}

		// Token: 0x06005BE1 RID: 23521 RVA: 0x003402EC File Offset: 0x0033F2EC
		internal void b(float A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06005BE2 RID: 23522 RVA: 0x003402F8 File Offset: 0x0033F2F8
		internal bool b()
		{
			return this.r;
		}

		// Token: 0x06005BE3 RID: 23523 RVA: 0x00340310 File Offset: 0x0033F310
		internal void c()
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = base.PlotArea.Series.a();
			if (this.j == -1f || this.k == -1f || this.l == -1f || this.m == -1f)
			{
				this.a(num3);
				if (num3 == 2f)
				{
					if (base.PlotArea.Width >= base.PlotArea.Height)
					{
						num = this.l * (float)this.q;
					}
					else
					{
						num2 = this.m * (float)this.q;
					}
				}
				else if (base.PlotArea.Width >= base.PlotArea.Height)
				{
					if ((float)this.q < num3 / 2f)
					{
						num = this.l * (float)this.q;
					}
					else
					{
						num = this.l * (float)(this.q % (int)Math.Ceiling((double)(num3 / 2f)));
						num2 = this.m * 1f;
					}
				}
				else if ((float)this.q < num3 / 2f)
				{
					num2 = this.m * (float)this.q;
				}
				else
				{
					num = this.l * 1f;
					num2 = this.m * (float)(this.q % (int)Math.Ceiling((double)(num3 / 2f)));
				}
				this.j = base.PlotArea.X + num;
				this.k = base.PlotArea.Y + num2;
			}
			if (this.g != -1f || this.h != -1f)
			{
				if (this.i == -1f)
				{
					if (this.m / 2f < this.l / 2f)
					{
						this.Radius = this.m / 2f - 5f;
					}
					else
					{
						this.Radius = this.l / 2f - 5f;
					}
				}
			}
			if (this.g == -1f)
			{
				this.g = this.j + this.l / 2f;
			}
			if (this.h == -1f)
			{
				this.h = this.k + this.m / 2f;
			}
			if (this.n != null && this.n.Text != null)
			{
				this.n.a(base.PlotArea.Chart);
			}
			float num4 = this.g;
			if (this.i == -1f)
			{
				if (this.c == ScalarDataLabelPosition.OutsideWithConnectors)
				{
					float num5 = this.m;
					if (this.n != null && this.n.Text != null)
					{
						this.m -= this.n.a(this.l);
					}
					if (this.m / 2f < this.l / 2f)
					{
						this.i = this.m / 2f - 5f;
					}
					else
					{
						this.i = this.l / 2f - 5f;
					}
					this.a.d();
					this.a.h();
					if (this.a.j())
					{
						this.a.i();
						this.a.e();
						float val = this.a.f();
						float val2 = this.a.g();
						float num6 = Math.Max(val2, val);
						float a_ = num4 + (this.i + 10f + num6 / 2f) * (float)Math.Cos(3.141592653589793);
						float a_2 = num4 + (this.i + 10f + num6 / 2f) * (float)Math.Cos(0.0);
						this.a.a(a_, a_2);
					}
					this.m = num5;
				}
				else
				{
					float num5 = this.m;
					if (this.n != null && this.n.Text != null)
					{
						this.m -= this.n.a(this.l);
					}
					if (this.m / 2f < this.l / 2f)
					{
						this.i = this.m / 2f - 5f;
					}
					else
					{
						this.i = this.l / 2f - 5f;
					}
					this.a.d();
					this.m = num5;
				}
			}
			else if (this.c == ScalarDataLabelPosition.OutsideWithConnectors)
			{
				this.a.d();
				this.a.h();
				if (this.a.j())
				{
					this.a.i();
					this.a.e();
				}
				float a_ = num4 + (this.i + 10f) * (float)Math.Cos(3.141592653589793);
				float a_2 = num4 + (this.i + 10f) * (float)Math.Cos(0.0);
				this.a.a(a_, a_2);
			}
		}

		// Token: 0x06005BE4 RID: 23524 RVA: 0x00340924 File Offset: 0x0033F924
		private void a(float A_0)
		{
			float num;
			float num2;
			if (A_0 == 1f)
			{
				num = 1f;
				num2 = 1f;
			}
			else if (A_0 == 2f)
			{
				if (base.PlotArea.Width >= base.PlotArea.Height)
				{
					num = 1f / A_0;
					num2 = 1f;
				}
				else
				{
					num = 1f;
					num2 = 1f / A_0;
				}
			}
			else if (base.PlotArea.Width >= base.PlotArea.Height)
			{
				if (A_0 % 2f == 0f)
				{
					num = 1f / (A_0 / 2f);
				}
				else
				{
					num = 1f / (float)((int)A_0 / 2 + 1);
				}
				num2 = 0.5f;
			}
			else
			{
				num = 0.5f;
				if (A_0 % 2f == 0f)
				{
					num2 = 1f / (A_0 / 2f);
				}
				else
				{
					num2 = 1f / (float)((int)A_0 / 2 + 1);
				}
			}
			this.l = base.PlotArea.Width * num;
			this.m = base.PlotArea.Height * num2;
		}

		// Token: 0x06005BE5 RID: 23525 RVA: 0x00340A64 File Offset: 0x0033FA64
		internal override void ic(PageWriter A_0)
		{
			this.a.a(A_0);
		}

		// Token: 0x06005BE6 RID: 23526 RVA: 0x00340A74 File Offset: 0x0033FA74
		internal override void ib(PageWriter A_0)
		{
			this.a.b(A_0);
			if (this.n != null && this.n.Text != null)
			{
				this.n.a(A_0, this.j, this.k, this.l, this.m);
			}
		}

		// Token: 0x04002FB8 RID: 12216
		private new PieSeriesElementList a;

		// Token: 0x04002FB9 RID: 12217
		private ScalarDataLabel b;

		// Token: 0x04002FBA RID: 12218
		private ScalarDataLabelPosition c = ScalarDataLabelPosition.Outside;

		// Token: 0x04002FBB RID: 12219
		private float d;

		// Token: 0x04002FBC RID: 12220
		private Color e;

		// Token: 0x04002FBD RID: 12221
		private float f = 0f;

		// Token: 0x04002FBE RID: 12222
		private float g = -1f;

		// Token: 0x04002FBF RID: 12223
		private float h = -1f;

		// Token: 0x04002FC0 RID: 12224
		private float i = -1f;

		// Token: 0x04002FC1 RID: 12225
		private float j = -1f;

		// Token: 0x04002FC2 RID: 12226
		private float k = -1f;

		// Token: 0x04002FC3 RID: 12227
		private float l = -1f;

		// Token: 0x04002FC4 RID: 12228
		private float m = -1f;

		// Token: 0x04002FC5 RID: 12229
		private SeriesLabel n;

		// Token: 0x04002FC6 RID: 12230
		private string o = "#.##";

		// Token: 0x04002FC7 RID: 12231
		private string p = "#.##%";

		// Token: 0x04002FC8 RID: 12232
		private int q;

		// Token: 0x04002FC9 RID: 12233
		private bool r = false;
	}
}
