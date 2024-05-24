using System;
using System.Collections;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007A2 RID: 1954
	public abstract class Axis
	{
		// Token: 0x06004EA6 RID: 20134 RVA: 0x002766D0 File Offset: 0x002756D0
		internal Axis()
		{
		}

		// Token: 0x06004EA7 RID: 20135 RVA: 0x00276764 File Offset: 0x00275764
		internal Axis(float A_0)
		{
			this.j = A_0;
		}

		// Token: 0x06004EA8 RID: 20136 RVA: 0x00276800 File Offset: 0x00275800
		internal AxisLabelList r()
		{
			return this.h;
		}

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x06004EA9 RID: 20137 RVA: 0x00276818 File Offset: 0x00275818
		// (set) Token: 0x06004EAA RID: 20138 RVA: 0x00276830 File Offset: 0x00275830
		public float Offset
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x06004EAB RID: 20139 RVA: 0x0027683C File Offset: 0x0027583C
		// (set) Token: 0x06004EAC RID: 20140 RVA: 0x00276854 File Offset: 0x00275854
		public Color LineColor
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

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x06004EAD RID: 20141 RVA: 0x00276860 File Offset: 0x00275860
		// (set) Token: 0x06004EAE RID: 20142 RVA: 0x00276878 File Offset: 0x00275878
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

		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x06004EAF RID: 20143 RVA: 0x00276884 File Offset: 0x00275884
		// (set) Token: 0x06004EB0 RID: 20144 RVA: 0x0027689C File Offset: 0x0027589C
		public float LineWidth
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

		// Token: 0x06004EB1 RID: 20145
		internal abstract void iv(XYSeries A_0);

		// Token: 0x06004EB2 RID: 20146 RVA: 0x002768A8 File Offset: 0x002758A8
		internal float s()
		{
			return this.d;
		}

		// Token: 0x06004EB3 RID: 20147 RVA: 0x002768C0 File Offset: 0x002758C0
		internal void b(float A_0)
		{
			this.d = A_0;
		}

		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x06004EB4 RID: 20148 RVA: 0x002768CC File Offset: 0x002758CC
		// (set) Token: 0x06004EB5 RID: 20149 RVA: 0x002768E4 File Offset: 0x002758E4
		public float LabelOffset
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

		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x06004EB6 RID: 20150 RVA: 0x002768F0 File Offset: 0x002758F0
		// (set) Token: 0x06004EB7 RID: 20151 RVA: 0x00276908 File Offset: 0x00275908
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

		// Token: 0x06004EB8 RID: 20152 RVA: 0x00276914 File Offset: 0x00275914
		internal float t()
		{
			return this.g;
		}

		// Token: 0x06004EB9 RID: 20153 RVA: 0x0027692C File Offset: 0x0027592C
		internal void c(float A_0)
		{
			this.g = A_0;
			this.p = true;
		}

		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x06004EBA RID: 20154 RVA: 0x00276940 File Offset: 0x00275940
		// (set) Token: 0x06004EBB RID: 20155 RVA: 0x00276958 File Offset: 0x00275958
		public string LabelFormat
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x06004EBC RID: 20156
		internal abstract void iw();

		// Token: 0x06004EBD RID: 20157 RVA: 0x00276964 File Offset: 0x00275964
		internal PlotArea u()
		{
			return this.k;
		}

		// Token: 0x06004EBE RID: 20158 RVA: 0x0027697C File Offset: 0x0027597C
		internal void a(PlotArea A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06004EBF RID: 20159 RVA: 0x00276988 File Offset: 0x00275988
		internal float v()
		{
			return this.l;
		}

		// Token: 0x06004EC0 RID: 20160 RVA: 0x002769A0 File Offset: 0x002759A0
		internal float w()
		{
			return this.m;
		}

		// Token: 0x06004EC1 RID: 20161 RVA: 0x002769B8 File Offset: 0x002759B8
		internal void x()
		{
			if (this.d == 0f)
			{
				this.d = 0.5f;
			}
		}

		// Token: 0x06004EC2 RID: 20162 RVA: 0x002769E8 File Offset: 0x002759E8
		internal void d(float A_0)
		{
			int num = 0;
			float num2 = A_0;
			if (A_0 > 0f && A_0 < 1f)
			{
				A_0 *= (float)((int)Math.Pow(10.0, (double)A_0.ToString("#.#######").Substring(A_0.ToString("#.#######").IndexOf('.') + 1).Length));
			}
			if (A_0 > 0f)
			{
				num = Convert.ToString(Math.Round((double)A_0)).Length;
			}
			float num3 = (float)Math.Pow(10.0, (double)(num - 1));
			float num4 = 5f * (float)Math.Pow(10.0, (double)(num - 2));
			float num5 = 2f * (float)Math.Pow(10.0, (double)(num - 2));
			float num6 = Math.Abs(A_0 / num3 - 10f);
			float num7 = Math.Abs(A_0 / num4 - 10f);
			float num8 = Math.Abs(A_0 / num5 - 10f);
			float num9 = Math.Min(Math.Min(num6, num7), num8);
			if (num9 == num6)
			{
				this.g = num3;
			}
			else if (num9 == num7)
			{
				this.g = num4;
			}
			else if (num9 == num8)
			{
				this.g = num5;
			}
			if (num2 > 0f && num2 < 1f)
			{
				this.g /= (float)Math.Pow(10.0, (double)num2.ToString("#.#######").Substring(num2.ToString("#.#######").IndexOf('.') + 1).Length);
			}
		}

		// Token: 0x06004EC3 RID: 20163 RVA: 0x00276BB4 File Offset: 0x00275BB4
		internal void b(AxisLabelList A_0)
		{
			this.y();
			this.a(A_0);
			ArrayList arrayList = new ArrayList();
			bool flag = false;
			for (int i = 0; i < this.h.Count; i++)
			{
				AxisLabel axisLabel = this.h.a(i);
				for (int j = 0; j < A_0.Count; j++)
				{
					AxisLabel axisLabel2 = A_0.a(j);
					flag = this.a(axisLabel, axisLabel2);
					if (!axisLabel.f() && flag)
					{
						axisLabel2.Text = axisLabel.Text;
						axisLabel2.Font = axisLabel.Font;
						axisLabel2.FontSize = axisLabel.FontSize;
						axisLabel2.TextColor = axisLabel.TextColor;
						axisLabel2.a(axisLabel.f());
					}
					if (flag)
					{
						break;
					}
				}
				if (!axisLabel.f() && !flag)
				{
					arrayList.Add(axisLabel);
				}
			}
			for (int j = 0; j < arrayList.Count; j++)
			{
				AxisLabel axisLabel = (AxisLabel)arrayList[j];
				if (!A_0.h().Contains(axisLabel))
				{
					A_0.h().Add(axisLabel);
				}
			}
			if (A_0 is XAxisLabelList)
			{
				XAxisLabelList xaxisLabelList = (XAxisLabelList)A_0;
				XAxisLabelList xaxisLabelList2 = (XAxisLabelList)this.h;
				xaxisLabelList.Angle = xaxisLabelList2.Angle;
			}
			A_0.b(this.h.c());
			A_0.WrapText = this.h.WrapText;
			A_0.MaximumLabelWidth = this.h.f();
			this.h = A_0;
		}

		// Token: 0x06004EC4 RID: 20164 RVA: 0x00276D88 File Offset: 0x00275D88
		internal void y()
		{
			this.h.a(this);
			if (this.h.TextColor == null)
			{
				this.h.TextColor = this.k.Chart.TextColor;
			}
			if (this.h.Font == null)
			{
				this.h.Font = this.k.Chart.Font;
			}
			if (this.h.FontSize <= 0f)
			{
				this.h.FontSize = this.k.Chart.FontSize;
			}
			ArrayList arrayList = new ArrayList();
			for (int i = 0; i < this.h.Count; i++)
			{
				AxisLabel axisLabel = this.h.a(i);
				if (!axisLabel.f())
				{
					if (axisLabel.Font == null)
					{
						axisLabel.Font = this.h.Font;
					}
					if (axisLabel.FontSize <= 0f)
					{
						axisLabel.FontSize = this.h.FontSize;
					}
					if (axisLabel.TextColor == null)
					{
						axisLabel.TextColor = this.h.TextColor;
					}
					arrayList.Add(axisLabel);
				}
			}
			if (arrayList.Count != 0)
			{
				this.h.a(arrayList);
			}
		}

		// Token: 0x06004EC5 RID: 20165 RVA: 0x00276F04 File Offset: 0x00275F04
		private void a(AxisLabelList A_0)
		{
			A_0.a(this);
			if (A_0.TextColor == null)
			{
				A_0.TextColor = this.h.TextColor;
			}
			if (A_0.Font == null)
			{
				A_0.Font = this.h.Font;
			}
			if (A_0.FontSize <= 0f)
			{
				A_0.FontSize = this.h.FontSize;
			}
			A_0.d(this.h.e());
			A_0.c(this.h.d());
			for (int i = 0; i < A_0.Count; i++)
			{
				AxisLabel axisLabel = A_0.a(i);
				axisLabel.Font = A_0.Font;
				axisLabel.FontSize = A_0.FontSize;
				axisLabel.TextColor = A_0.TextColor;
				axisLabel.a(true);
			}
		}

		// Token: 0x06004EC6 RID: 20166 RVA: 0x00276FF8 File Offset: 0x00275FF8
		private bool a(AxisLabel A_0, AxisLabel A_1)
		{
			bool result = false;
			if (A_0 is NumericYAxisLabel && A_1 is NumericYAxisLabel)
			{
				if (((NumericYAxisLabel)A_0).Value == ((NumericYAxisLabel)A_1).Value)
				{
					result = true;
				}
			}
			else if (A_0 is NumericXAxisLabel && A_1 is NumericXAxisLabel)
			{
				if (((NumericXAxisLabel)A_0).Value == ((NumericXAxisLabel)A_1).Value)
				{
					result = true;
				}
			}
			else if (A_0 is DateTimeXAxisLabel && A_1 is DateTimeXAxisLabel)
			{
				int num = ((DateTimeXAxisLabel)A_1).a();
				int num2 = ((DateTimeXAxisLabel)A_0).a();
				if (num2 == num && ((DateTimeXAxisLabel)A_1).Value.Equals(((DateTimeXAxisLabel)A_0).Value))
				{
					result = true;
				}
				else if ((float)(num2 - num) < this.g && ((DateTimeXAxisLabel)A_1).Value.Equals(((DateTimeXAxisLabel)A_0).Value))
				{
					result = true;
				}
			}
			else if (A_0 is DateTimeYAxisLabel && A_1 is DateTimeYAxisLabel)
			{
				int num = ((DateTimeYAxisLabel)A_1).a();
				int num2 = ((DateTimeYAxisLabel)A_0).a();
				if (num2 == num && ((DateTimeYAxisLabel)A_1).Value.Equals(((DateTimeYAxisLabel)A_0).Value))
				{
					result = true;
				}
				else if ((float)(num2 - num) < this.g && ((DateTimeYAxisLabel)A_1).Value.Equals(((DateTimeYAxisLabel)A_0).Value))
				{
					result = true;
				}
			}
			else if (A_0 is PercentageXAxisLabel && A_1 is PercentageXAxisLabel)
			{
				if (((PercentageXAxisLabel)A_0).Value == ((PercentageXAxisLabel)A_1).Value)
				{
					result = true;
				}
			}
			else if (A_0 is PercentageYAxisLabel && A_1 is PercentageYAxisLabel)
			{
				if (((PercentageYAxisLabel)A_0).Value == ((PercentageYAxisLabel)A_1).Value)
				{
					result = true;
				}
			}
			else if (A_0 is IndexedXAxisLabel && A_1 is IndexedXAxisLabel)
			{
				int value = ((IndexedXAxisLabel)A_0).Value;
				int value2 = ((IndexedXAxisLabel)A_1).Value;
				if (value == value2)
				{
					result = true;
				}
				else if ((float)(value - value2) < this.g)
				{
					result = true;
				}
			}
			else if (A_0 is IndexedYAxisLabel && A_1 is IndexedYAxisLabel)
			{
				int value = ((IndexedYAxisLabel)A_0).Value;
				int value2 = ((IndexedYAxisLabel)A_1).Value;
				if (value == value2)
				{
					result = true;
				}
				else if ((float)(value - value2) < this.g)
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x04002A8D RID: 10893
		private Color a = Grayscale.Black;

		// Token: 0x04002A8E RID: 10894
		private LineStyle b = LineStyle.Solid;

		// Token: 0x04002A8F RID: 10895
		private float c = 1f;

		// Token: 0x04002A90 RID: 10896
		private float d = 0f;

		// Token: 0x04002A91 RID: 10897
		private float e;

		// Token: 0x04002A92 RID: 10898
		private bool f = true;

		// Token: 0x04002A93 RID: 10899
		internal float g = 0f;

		// Token: 0x04002A94 RID: 10900
		internal AxisLabelList h;

		// Token: 0x04002A95 RID: 10901
		internal string i;

		// Token: 0x04002A96 RID: 10902
		internal float j = 0f;

		// Token: 0x04002A97 RID: 10903
		private PlotArea k;

		// Token: 0x04002A98 RID: 10904
		internal float l = float.MaxValue;

		// Token: 0x04002A99 RID: 10905
		internal float m = float.MinValue;

		// Token: 0x04002A9A RID: 10906
		internal DateTime n = DateTime.MinValue;

		// Token: 0x04002A9B RID: 10907
		internal DateTime o = DateTime.MinValue;

		// Token: 0x04002A9C RID: 10908
		internal bool p = false;
	}
}
