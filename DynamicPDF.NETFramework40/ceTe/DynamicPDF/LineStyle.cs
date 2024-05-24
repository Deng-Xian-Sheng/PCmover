using System;
using System.Globalization;
using System.Text;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006A0 RID: 1696
	public class LineStyle
	{
		// Token: 0x0600406F RID: 16495 RVA: 0x00221BE9 File Offset: 0x00220BE9
		static LineStyle()
		{
			LineStyle.g.NumberDecimalSeparator = ".";
		}

		// Token: 0x06004070 RID: 16496 RVA: 0x00221C08 File Offset: 0x00220C08
		public LineStyle(float[] dashArray, float dashPhase)
		{
			string text = "[";
			for (int i = 0; i < dashArray.Length; i++)
			{
				text = text + dashArray[i].ToString("0.00", LineStyle.g) + " ";
			}
			text = text + "] " + dashPhase.ToString("0.00", LineStyle.g) + " d\n";
			this.h = Encoding.ASCII.GetBytes(text);
		}

		// Token: 0x06004071 RID: 16497 RVA: 0x00221C92 File Offset: 0x00220C92
		public LineStyle(float[] dashArray) : this(dashArray, 0f)
		{
		}

		// Token: 0x06004072 RID: 16498 RVA: 0x00221CA4 File Offset: 0x00220CA4
		protected LineStyle(string lineStyle)
		{
			string s = "[" + lineStyle + "] 0 d\n";
			this.h = Encoding.ASCII.GetBytes(s);
		}

		// Token: 0x06004073 RID: 16499 RVA: 0x00221CDC File Offset: 0x00220CDC
		internal void a(OperatorWriter A_0)
		{
			A_0.Write(this.h);
		}

		// Token: 0x06004074 RID: 16500 RVA: 0x00221CEC File Offset: 0x00220CEC
		internal BorderStyleAttribute a()
		{
			BorderStyleAttribute result;
			if (LineStyle.a != null && LineStyle.a == this)
			{
				result = BorderStyleAttribute.Solid;
			}
			else if (LineStyle.b != null && LineStyle.b == this)
			{
				result = BorderStyleAttribute.Dotted;
			}
			else if (LineStyle.c != null && LineStyle.c == this)
			{
				result = BorderStyleAttribute.Dashed;
			}
			else if (LineStyle.d != null && LineStyle.d == this)
			{
				result = BorderStyleAttribute.Dashed;
			}
			else if (LineStyle.e != null && LineStyle.e == this)
			{
				result = BorderStyleAttribute.Dashed;
			}
			else if (LineStyle.f != null && LineStyle.f == this)
			{
				result = BorderStyleAttribute.None;
			}
			else
			{
				result = BorderStyleAttribute.Solid;
			}
			return result;
		}

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06004075 RID: 16501 RVA: 0x00221DB8 File Offset: 0x00220DB8
		public static LineStyle Solid
		{
			get
			{
				if (LineStyle.a == null)
				{
					LineStyle.a = new LineStyle("");
				}
				return LineStyle.a;
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06004076 RID: 16502 RVA: 0x00221DF0 File Offset: 0x00220DF0
		public static LineStyle Dots
		{
			get
			{
				if (LineStyle.b == null)
				{
					LineStyle.b = new LineStyle("1 1");
				}
				return LineStyle.b;
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06004077 RID: 16503 RVA: 0x00221E28 File Offset: 0x00220E28
		public static LineStyle DashSmall
		{
			get
			{
				if (LineStyle.c == null)
				{
					LineStyle.c = new LineStyle("2 2");
				}
				return LineStyle.c;
			}
		}

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06004078 RID: 16504 RVA: 0x00221E60 File Offset: 0x00220E60
		public static LineStyle Dash
		{
			get
			{
				if (LineStyle.d == null)
				{
					LineStyle.d = new LineStyle("3 3");
				}
				return LineStyle.d;
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06004079 RID: 16505 RVA: 0x00221E98 File Offset: 0x00220E98
		public static LineStyle DashLarge
		{
			get
			{
				if (LineStyle.e == null)
				{
					LineStyle.e = new LineStyle("4 4");
				}
				return LineStyle.e;
			}
		}

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x0600407A RID: 16506 RVA: 0x00221ED0 File Offset: 0x00220ED0
		public static LineStyle None
		{
			get
			{
				if (LineStyle.f == null)
				{
					LineStyle.f = new LineStyle("0 1");
				}
				return LineStyle.f;
			}
		}

		// Token: 0x040023B9 RID: 9145
		private static LineStyle a;

		// Token: 0x040023BA RID: 9146
		private static LineStyle b;

		// Token: 0x040023BB RID: 9147
		private static LineStyle c;

		// Token: 0x040023BC RID: 9148
		private static LineStyle d;

		// Token: 0x040023BD RID: 9149
		private static LineStyle e;

		// Token: 0x040023BE RID: 9150
		private static LineStyle f;

		// Token: 0x040023BF RID: 9151
		private static NumberFormatInfo g = new NumberFormatInfo();

		// Token: 0x040023C0 RID: 9152
		private byte[] h;
	}
}
