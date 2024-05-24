using System;
using System.Collections;

namespace ceTe.DynamicPDF.PageElements.Charting.Axes
{
	// Token: 0x020007B6 RID: 1974
	public abstract class AxisLabelList
	{
		// Token: 0x06005058 RID: 20568 RVA: 0x0027FF46 File Offset: 0x0027EF46
		internal AxisLabelList()
		{
		}

		// Token: 0x06005059 RID: 20569 RVA: 0x0027FF74 File Offset: 0x0027EF74
		internal void a(AxisLabel A_0)
		{
			if (this.a != null)
			{
				this.a.Add(A_0);
			}
			else
			{
				this.a = new ArrayList();
				this.a.Add(A_0);
			}
		}

		// Token: 0x170006C0 RID: 1728
		// (get) Token: 0x0600505A RID: 20570 RVA: 0x0027FFB8 File Offset: 0x0027EFB8
		// (set) Token: 0x0600505B RID: 20571 RVA: 0x0027FFD0 File Offset: 0x0027EFD0
		public Font Font
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

		// Token: 0x0600505C RID: 20572 RVA: 0x0027FFDC File Offset: 0x0027EFDC
		internal float c()
		{
			return this.j;
		}

		// Token: 0x0600505D RID: 20573 RVA: 0x0027FFF4 File Offset: 0x0027EFF4
		internal void b(float A_0)
		{
			this.j = A_0;
			if (this.Count > 0)
			{
				for (int i = 0; i < this.Count; i++)
				{
					AxisLabel axisLabel = (AxisLabel)this.a[i];
					axisLabel.b(A_0);
				}
			}
		}

		// Token: 0x170006C1 RID: 1729
		// (get) Token: 0x0600505E RID: 20574 RVA: 0x0028004C File Offset: 0x0027F04C
		// (set) Token: 0x0600505F RID: 20575 RVA: 0x00280064 File Offset: 0x0027F064
		public float FontSize
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

		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x06005060 RID: 20576 RVA: 0x00280070 File Offset: 0x0027F070
		// (set) Token: 0x06005061 RID: 20577 RVA: 0x00280088 File Offset: 0x0027F088
		public Color TextColor
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

		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x06005062 RID: 20578 RVA: 0x00280094 File Offset: 0x0027F094
		// (set) Token: 0x06005063 RID: 20579 RVA: 0x002800AC File Offset: 0x0027F0AC
		public bool AutoLabels
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

		// Token: 0x06005064 RID: 20580 RVA: 0x002800B8 File Offset: 0x0027F0B8
		internal AxisLabel a(int A_0)
		{
			AxisLabel result;
			if (A_0 < this.Count)
			{
				result = (AxisLabel)this.a[A_0];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x06005065 RID: 20581 RVA: 0x002800F0 File Offset: 0x0027F0F0
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

		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x06005066 RID: 20582 RVA: 0x00280120 File Offset: 0x0027F120
		// (set) Token: 0x06005067 RID: 20583 RVA: 0x00280138 File Offset: 0x0027F138
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

		// Token: 0x06005068 RID: 20584 RVA: 0x00280144 File Offset: 0x0027F144
		internal float d()
		{
			return this.g;
		}

		// Token: 0x06005069 RID: 20585 RVA: 0x0028015C File Offset: 0x0027F15C
		internal void c(float A_0)
		{
			this.g = A_0;
		}

		// Token: 0x0600506A RID: 20586 RVA: 0x00280168 File Offset: 0x0027F168
		internal float e()
		{
			return this.h;
		}

		// Token: 0x0600506B RID: 20587 RVA: 0x00280180 File Offset: 0x0027F180
		internal void d(float A_0)
		{
			this.h = A_0;
		}

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x0600506C RID: 20588 RVA: 0x0028018C File Offset: 0x0027F18C
		// (set) Token: 0x0600506D RID: 20589 RVA: 0x002801A4 File Offset: 0x0027F1A4
		public bool WrapText
		{
			get
			{
				return this.k;
			}
			set
			{
				this.k = value;
			}
		}

		// Token: 0x170006C7 RID: 1735
		// (set) Token: 0x0600506E RID: 20590 RVA: 0x002801AE File Offset: 0x0027F1AE
		public float MaximumLabelWidth
		{
			set
			{
				this.l = value;
			}
		}

		// Token: 0x0600506F RID: 20591 RVA: 0x002801B8 File Offset: 0x0027F1B8
		internal float f()
		{
			return this.l;
		}

		// Token: 0x06005070 RID: 20592 RVA: 0x002801D0 File Offset: 0x0027F1D0
		internal Axis g()
		{
			return this.i;
		}

		// Token: 0x06005071 RID: 20593 RVA: 0x002801E8 File Offset: 0x0027F1E8
		internal void a(Axis A_0)
		{
			this.i = A_0;
		}

		// Token: 0x06005072 RID: 20594 RVA: 0x002801F4 File Offset: 0x0027F1F4
		internal ArrayList h()
		{
			return this.a;
		}

		// Token: 0x06005073 RID: 20595 RVA: 0x0028020C File Offset: 0x0027F20C
		internal void a(ArrayList A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06005074 RID: 20596 RVA: 0x00280218 File Offset: 0x0027F218
		internal string b(int A_0)
		{
			for (int i = 0; i < this.Count; i++)
			{
				AxisLabel axisLabel = (AxisLabel)this.a[i];
				float num = this.d(axisLabel);
				if (num != -3.4028235E+38f && A_0 == (int)num)
				{
					return axisLabel.Text.Trim();
				}
			}
			return " ";
		}

		// Token: 0x06005075 RID: 20597 RVA: 0x00280290 File Offset: 0x0027F290
		internal float i()
		{
			float num = 0f;
			for (int i = 0; i < this.Count; i++)
			{
				AxisLabel axisLabel = (AxisLabel)this.a[i];
				axisLabel.b(this.h);
				axisLabel.c(this.g);
				if (this.h <= 0f || this.g <= 0f)
				{
					float num2 = this.d(axisLabel);
					if (num2 != -3.4028235E+38f && num < axisLabel.a(this.k, this.l))
					{
						num = axisLabel.a(this.k, this.l);
					}
				}
			}
			float result;
			if (this.h > 0f)
			{
				result = this.h;
			}
			else
			{
				result = num;
			}
			return result;
		}

		// Token: 0x06005076 RID: 20598 RVA: 0x0028038C File Offset: 0x0027F38C
		internal float j()
		{
			float result = 0f;
			if (this.Count != 0 && this.i.s() == 0f)
			{
				for (int i = this.Count - 1; i >= 0; i--)
				{
					AxisLabel axisLabel = (AxisLabel)this.a[i];
					if (this.c(axisLabel) == this.i.w())
					{
						result = axisLabel.d();
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06005077 RID: 20599 RVA: 0x00280428 File Offset: 0x0027F428
		internal virtual float ix()
		{
			float result = 0f;
			if (this.Count != 0 && this.i.s() == 0f)
			{
				for (int i = 0; i < this.Count; i++)
				{
					AxisLabel axisLabel = (AxisLabel)this.a[i];
					if (this.b(axisLabel) == this.i.v())
					{
						result = axisLabel.d();
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x06005078 RID: 20600 RVA: 0x002804BC File Offset: 0x0027F4BC
		internal float b(AxisLabel A_0)
		{
			float result = float.MinValue;
			if (A_0 is IndexedXAxisLabel)
			{
				result = (float)((IndexedXAxisLabel)A_0).Value;
			}
			else if (A_0 is IndexedYAxisLabel)
			{
				result = (float)((IndexedYAxisLabel)A_0).Value;
			}
			else if (A_0 is DateTimeXAxisLabel)
			{
				result = (float)((DateTimeXAxisLabel)A_0).a();
			}
			else if (A_0 is DateTimeYAxisLabel)
			{
				result = (float)((DateTimeYAxisLabel)A_0).a();
			}
			else if (A_0 is NumericXAxisLabel)
			{
				result = ((NumericXAxisLabel)A_0).Value;
			}
			else if (A_0 is NumericYAxisLabel)
			{
				result = ((NumericYAxisLabel)A_0).Value;
			}
			else if (A_0 is PercentageXAxisLabel)
			{
				result = ((PercentageXAxisLabel)A_0).Value;
			}
			else if (A_0 is PercentageYAxisLabel)
			{
				result = ((PercentageYAxisLabel)A_0).Value;
			}
			return result;
		}

		// Token: 0x06005079 RID: 20601 RVA: 0x002805D0 File Offset: 0x0027F5D0
		internal float c(AxisLabel A_0)
		{
			float result = float.MinValue;
			if (A_0 is IndexedXAxisLabel)
			{
				result = (float)((IndexedXAxisLabel)A_0).Value;
			}
			else if (A_0 is IndexedYAxisLabel)
			{
				result = (float)((IndexedYAxisLabel)A_0).Value;
			}
			else if (A_0 is DateTimeXAxisLabel)
			{
				result = (float)((DateTimeXAxisLabel)A_0).a();
			}
			else if (A_0 is DateTimeYAxisLabel)
			{
				result = (float)((DateTimeYAxisLabel)A_0).a();
			}
			else if (A_0 is NumericXAxisLabel)
			{
				result = ((NumericXAxisLabel)A_0).Value;
			}
			else if (A_0 is NumericYAxisLabel)
			{
				result = ((NumericYAxisLabel)A_0).Value;
			}
			else if (A_0 is PercentageXAxisLabel)
			{
				result = ((PercentageXAxisLabel)A_0).Value;
			}
			else if (A_0 is PercentageYAxisLabel)
			{
				result = ((PercentageYAxisLabel)A_0).Value;
			}
			return result;
		}

		// Token: 0x0600507A RID: 20602 RVA: 0x002806E4 File Offset: 0x0027F6E4
		internal float d(AxisLabel A_0)
		{
			float result = float.MinValue;
			if (A_0 is IndexedYAxisLabel)
			{
				float num = (float)((IndexedYAxisLabel)A_0).Value;
				if (num >= this.i.v() && num <= this.i.w())
				{
					result = (float)((int)((num - this.i.v()) / this.i.t()));
				}
			}
			else if (A_0 is DateTimeYAxisLabel)
			{
				float num = (float)((DateTimeYAxisLabel)A_0).a();
				if (num >= this.i.v() && num <= this.i.w())
				{
					result = (float)((int)((num - this.i.v()) / this.i.t()));
				}
			}
			else if (A_0 is NumericYAxisLabel)
			{
				float num = ((NumericYAxisLabel)A_0).Value;
				if ((num >= this.i.v() && num <= this.i.w()) || num.Equals(this.i.w()))
				{
					result = (num - this.i.v()) / this.i.t();
				}
			}
			else if (A_0 is PercentageYAxisLabel)
			{
				float num = ((PercentageYAxisLabel)A_0).Value;
				if (num >= this.i.v() && num <= this.i.w())
				{
					result = (num - this.i.v()) / this.i.t();
				}
			}
			if (A_0 is IndexedXAxisLabel)
			{
				float num = (float)((IndexedXAxisLabel)A_0).Value;
				if (this.i != null && num >= this.i.v() && num <= this.i.w())
				{
					result = (float)((int)((num - this.i.v()) / this.i.t()));
				}
			}
			else if (A_0 is DateTimeXAxisLabel)
			{
				float num = (float)((DateTimeXAxisLabel)A_0).a();
				if (num >= this.i.v() && num <= this.i.w())
				{
					result = (float)((int)((num - this.i.v()) / this.i.t()));
				}
			}
			else if (A_0 is NumericXAxisLabel)
			{
				float num = ((NumericXAxisLabel)A_0).Value;
				if ((num >= this.i.v() && num <= this.i.w()) || num.Equals(this.i.w()))
				{
					result = (num - this.i.v()) / this.i.t();
				}
			}
			else if (A_0 is PercentageXAxisLabel)
			{
				float num = ((PercentageXAxisLabel)A_0).Value;
				if (num >= this.i.v() && num <= this.i.w())
				{
					result = (num - this.i.v()) / this.i.t();
				}
			}
			return result;
		}

		// Token: 0x04002B42 RID: 11074
		private ArrayList a;

		// Token: 0x04002B43 RID: 11075
		private Font b;

		// Token: 0x04002B44 RID: 11076
		private float c;

		// Token: 0x04002B45 RID: 11077
		private Color d;

		// Token: 0x04002B46 RID: 11078
		private bool e = true;

		// Token: 0x04002B47 RID: 11079
		private bool f = true;

		// Token: 0x04002B48 RID: 11080
		private float g;

		// Token: 0x04002B49 RID: 11081
		private float h;

		// Token: 0x04002B4A RID: 11082
		private Axis i;

		// Token: 0x04002B4B RID: 11083
		private float j;

		// Token: 0x04002B4C RID: 11084
		private bool k = true;

		// Token: 0x04002B4D RID: 11085
		private float l = float.MinValue;
	}
}
