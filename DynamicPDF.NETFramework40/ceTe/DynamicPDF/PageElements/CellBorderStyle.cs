using System;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000709 RID: 1801
	public class CellBorderStyle
	{
		// Token: 0x060046EF RID: 18159 RVA: 0x0024569E File Offset: 0x0024469E
		internal CellBorderStyle(Border A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060046F0 RID: 18160 RVA: 0x002456CC File Offset: 0x002446CC
		internal CellBorderStyle(CellBorderStyle A_0, CellBorderStyle A_1, Border A_2)
		{
			this.d = A_2;
			if (A_0.a == null)
			{
				this.a = A_1.a;
			}
			else
			{
				this.a = A_0.a;
			}
			if (A_0.b == null)
			{
				this.b = A_1.b;
			}
			else
			{
				this.b = A_0.b;
			}
			if (A_0.c == null)
			{
				this.c = A_1.c;
			}
			else
			{
				this.c = A_0.c;
			}
		}

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x060046F1 RID: 18161 RVA: 0x00245780 File Offset: 0x00244780
		// (set) Token: 0x060046F2 RID: 18162 RVA: 0x002457B8 File Offset: 0x002447B8
		public float? Width
		{
			get
			{
				float? width;
				if (this.a != null)
				{
					width = this.a;
				}
				else
				{
					width = this.d.Width;
				}
				return width;
			}
			set
			{
				this.a = value;
				this.d.a().a(true);
				this.d.a().c(true);
				this.d.a().a(null);
			}
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x060046F3 RID: 18163 RVA: 0x002457F8 File Offset: 0x002447F8
		// (set) Token: 0x060046F4 RID: 18164 RVA: 0x0024582B File Offset: 0x0024482B
		public Color Color
		{
			get
			{
				Color color;
				if (this.b != null)
				{
					color = this.b;
				}
				else
				{
					color = this.d.Color;
				}
				return color;
			}
			set
			{
				this.b = value;
				this.d.a().a(null);
			}
		}

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x060046F5 RID: 18165 RVA: 0x00245848 File Offset: 0x00244848
		// (set) Token: 0x060046F6 RID: 18166 RVA: 0x0024587B File Offset: 0x0024487B
		public LineStyle LineStyle
		{
			get
			{
				LineStyle lineStyle;
				if (this.c != null)
				{
					lineStyle = this.c;
				}
				else
				{
					lineStyle = this.d.LineStyle;
				}
				return lineStyle;
			}
			set
			{
				this.c = value;
				this.d.a().a(null);
			}
		}

		// Token: 0x060046F7 RID: 18167 RVA: 0x00245898 File Offset: 0x00244898
		internal CellBorderStyle a(Border A_0)
		{
			return new CellBorderStyle(A_0)
			{
				a = this.a,
				b = this.b,
				c = this.c
			};
		}

		// Token: 0x060046F8 RID: 18168 RVA: 0x002458D8 File Offset: 0x002448D8
		internal void a(CellBorderStyle A_0)
		{
			if (this.a == null)
			{
				this.a = A_0.a;
			}
			if (this.b == null)
			{
				this.b = A_0.b;
			}
			if (this.c == null)
			{
				this.c = A_0.c;
			}
		}

		// Token: 0x060046F9 RID: 18169 RVA: 0x00245940 File Offset: 0x00244940
		internal float a()
		{
			float result;
			if (this.Width == null)
			{
				result = 0f;
			}
			else
			{
				result = this.Width.Value;
			}
			return result;
		}

		// Token: 0x060046FA RID: 18170 RVA: 0x0024597C File Offset: 0x0024497C
		internal RgbColor b()
		{
			RgbColor result;
			if (this.Color == null)
			{
				result = null;
			}
			else
			{
				result = this.Color.m();
			}
			return result;
		}

		// Token: 0x060046FB RID: 18171 RVA: 0x002459B0 File Offset: 0x002449B0
		internal string c()
		{
			string result;
			if (this.LineStyle == null)
			{
				result = BorderStyleAttribute.None.ToString();
			}
			else
			{
				result = this.LineStyle.a().ToString();
			}
			return result;
		}

		// Token: 0x04002710 RID: 10000
		private float? a = null;

		// Token: 0x04002711 RID: 10001
		private Color b = null;

		// Token: 0x04002712 RID: 10002
		private LineStyle c = null;

		// Token: 0x04002713 RID: 10003
		private Border d;
	}
}
