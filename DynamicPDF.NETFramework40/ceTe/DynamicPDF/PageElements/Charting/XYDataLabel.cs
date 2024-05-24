using System;
using System.ComponentModel;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x02000796 RID: 1942
	public abstract class XYDataLabel
	{
		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x06004E59 RID: 20057 RVA: 0x00275790 File Offset: 0x00274790
		// (set) Token: 0x06004E5A RID: 20058 RVA: 0x002757A8 File Offset: 0x002747A8
		public Font Font
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

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x06004E5B RID: 20059 RVA: 0x002757B4 File Offset: 0x002747B4
		// (set) Token: 0x06004E5C RID: 20060 RVA: 0x002757CC File Offset: 0x002747CC
		public float FontSize
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

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x06004E5D RID: 20061 RVA: 0x002757D8 File Offset: 0x002747D8
		// (set) Token: 0x06004E5E RID: 20062 RVA: 0x002757F0 File Offset: 0x002747F0
		public float Width
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

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x06004E5F RID: 20063 RVA: 0x002757FC File Offset: 0x002747FC
		// (set) Token: 0x06004E60 RID: 20064 RVA: 0x00275814 File Offset: 0x00274814
		public DataLabelAlign Align
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
			}
		}

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x06004E61 RID: 20065 RVA: 0x00275820 File Offset: 0x00274820
		// (set) Token: 0x06004E62 RID: 20066 RVA: 0x00275838 File Offset: 0x00274838
		public DataLabelPosition Position
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

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x06004E63 RID: 20067 RVA: 0x00275844 File Offset: 0x00274844
		// (set) Token: 0x06004E64 RID: 20068 RVA: 0x0027585C File Offset: 0x0027485C
		public float Padding
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

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x06004E65 RID: 20069 RVA: 0x00275868 File Offset: 0x00274868
		// (set) Token: 0x06004E66 RID: 20070 RVA: 0x00275880 File Offset: 0x00274880
		public float Angle
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

		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x06004E67 RID: 20071 RVA: 0x0027588C File Offset: 0x0027488C
		// (set) Token: 0x06004E68 RID: 20072 RVA: 0x002758A4 File Offset: 0x002748A4
		public bool WrapText
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

		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x06004E69 RID: 20073 RVA: 0x002758B0 File Offset: 0x002748B0
		// (set) Token: 0x06004E6A RID: 20074 RVA: 0x002758C8 File Offset: 0x002748C8
		public Color Color
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

		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x06004E6B RID: 20075 RVA: 0x002758D4 File Offset: 0x002748D4
		// (set) Token: 0x06004E6C RID: 20076 RVA: 0x002758EC File Offset: 0x002748EC
		public string Suffix
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

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x06004E6D RID: 20077 RVA: 0x002758F8 File Offset: 0x002748F8
		// (set) Token: 0x06004E6E RID: 20078 RVA: 0x00275910 File Offset: 0x00274910
		public string Prefix
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

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x06004E6F RID: 20079 RVA: 0x0027591C File Offset: 0x0027491C
		// (set) Token: 0x06004E70 RID: 20080 RVA: 0x00275934 File Offset: 0x00274934
		[Obsolete("This property is obsolete. Use Separator property instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string Seperator
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

		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x06004E71 RID: 20081 RVA: 0x00275940 File Offset: 0x00274940
		// (set) Token: 0x06004E72 RID: 20082 RVA: 0x00275958 File Offset: 0x00274958
		public string Separator
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

		// Token: 0x06004E73 RID: 20083 RVA: 0x00275964 File Offset: 0x00274964
		internal void a(Chart A_0)
		{
			if (this.c == null)
			{
				this.c = A_0.TextColor;
			}
			if (this.a == null)
			{
				this.a = A_0.Font;
			}
			if (this.b <= 0f)
			{
				this.b = A_0.FontSize;
			}
		}

		// Token: 0x06004E74 RID: 20084 RVA: 0x002759C8 File Offset: 0x002749C8
		internal void a(PageWriter A_0, float A_1, float A_2, string A_3, bool A_4, bool A_5, bool A_6, DataLabelLocation A_7)
		{
			char[] text = A_3.ToCharArray(0, A_3.Length);
			float textWidth;
			if (this.k == 0f)
			{
				textWidth = this.a.GetTextWidth(text, this.b);
			}
			else
			{
				textWidth = this.k;
			}
			TextLineList textLines = this.a.GetTextLines(text, textWidth, this.b);
			if (!this.j)
			{
				textLines.Height = textLines.GetTextHeight(1);
			}
			float textHeight = textLines.GetTextHeight();
			float num = this.i;
			DataLabelPosition dataLabelPosition = this.g;
			if (num < -360f || num > 360f)
			{
				num %= 360f;
			}
			if (num < 0f)
			{
				num += 360f;
			}
			float num2 = A_2;
			float num3 = A_1;
			if (this.g == DataLabelPosition.Auto)
			{
				if (A_5)
				{
					dataLabelPosition = DataLabelPosition.Center;
				}
				else if (num == 0f)
				{
					if (A_4)
					{
						dataLabelPosition = DataLabelPosition.Right;
					}
					else
					{
						dataLabelPosition = DataLabelPosition.Above;
					}
				}
				else if ((num > 0f && this.i <= 90f) || (num > 270f && num <= 360f))
				{
					dataLabelPosition = DataLabelPosition.Right;
				}
				else if (num > 90f && num <= 180f)
				{
					dataLabelPosition = DataLabelPosition.Left;
					num += 180f;
				}
				else if (num > 180f && num <= 270f)
				{
					dataLabelPosition = DataLabelPosition.Left;
					num -= 180f;
				}
			}
			switch (dataLabelPosition)
			{
			case DataLabelPosition.Left:
				if (A_4)
				{
					num3 += this.h;
					A_0.SetDimensionsSimpleRotate(num3, num2, num);
					num3 -= textWidth;
					num2 -= textHeight / 2f;
				}
				else
				{
					num2 = A_2 - this.h;
					A_0.SetDimensionsSimpleRotate(num3, num2, num);
					num3 -= textWidth;
					num2 -= textHeight / 2f;
				}
				break;
			case DataLabelPosition.Right:
				if (A_4)
				{
					num3 += this.h;
					A_0.SetDimensionsSimpleRotate(num3, num2, num);
					num2 -= textHeight / 2f;
				}
				else
				{
					num2 = A_2 - this.h;
					A_0.SetDimensionsSimpleRotate(num3, num2, num);
					num2 -= textHeight / 2f;
				}
				break;
			case DataLabelPosition.Above:
				if (A_4)
				{
					num3 += this.h;
					A_0.SetDimensionsSimpleRotate(num3, num2, num);
					num3 -= textWidth / 2f;
					num2 -= textHeight;
				}
				else
				{
					A_0.SetDimensionsSimpleRotate(num3, num2, num);
					num3 -= textWidth / 2f;
					if (A_7 == DataLabelLocation.Middle)
					{
						num2 -= textHeight / 2f;
					}
					else if (A_6)
					{
						num2 += this.h;
					}
					else
					{
						num2 -= this.h;
						num2 -= textHeight;
					}
				}
				break;
			case DataLabelPosition.Below:
				if (A_4)
				{
					num3 += this.h;
					A_0.SetDimensionsSimpleRotate(num3, num2, num);
					num3 -= textWidth / 2f;
				}
				else
				{
					num2 = A_2 - this.h;
					A_0.SetDimensionsSimpleRotate(num3, num2, num);
					num3 -= textWidth / 2f;
				}
				break;
			default:
				if (A_4)
				{
					A_0.SetDimensionsSimpleRotate(num3, num2, num);
					num2 -= textHeight / 2f;
					num3 -= textWidth / 2f;
				}
				else
				{
					A_0.SetDimensionsSimpleRotate(num3, num2, num);
					num2 -= textHeight / 2f;
					num3 -= textWidth / 2f;
				}
				break;
			}
			TextAlign a_ = this.a(this.g);
			textLines.ja(A_0, num3, num2, a_, this.c, null, 0f, false, false, false);
			A_0.ResetDimensions();
		}

		// Token: 0x06004E75 RID: 20085 RVA: 0x00275E14 File Offset: 0x00274E14
		private TextAlign a(DataLabelPosition A_0)
		{
			switch (this.l)
			{
			case DataLabelAlign.Left:
				return TextAlign.Left;
			case DataLabelAlign.Center:
				return TextAlign.Center;
			case DataLabelAlign.Right:
				return TextAlign.Right;
			case DataLabelAlign.Justify:
				return TextAlign.Justify;
			case DataLabelAlign.Auto:
				if (A_0 == DataLabelPosition.Above || A_0 == DataLabelPosition.Below || A_0 == DataLabelPosition.Center)
				{
					return TextAlign.Center;
				}
				if (A_0 == DataLabelPosition.Left)
				{
					return TextAlign.Right;
				}
				if (A_0 == DataLabelPosition.Right)
				{
					return TextAlign.Left;
				}
				break;
			}
			return TextAlign.Left;
		}

		// Token: 0x06004E76 RID: 20086 RVA: 0x00275E98 File Offset: 0x00274E98
		internal void a(PageWriter A_0, float A_1, float A_2, string A_3)
		{
			char[] text = A_3.ToCharArray(0, A_3.Length);
			float textWidth;
			if (this.k == 0f)
			{
				textWidth = this.a.GetTextWidth(text, this.b);
			}
			else
			{
				textWidth = this.k;
			}
			TextLineList textLines = this.a.GetTextLines(text, textWidth, this.b);
			if (!this.j)
			{
				textLines.Height = textLines.GetTextHeight(1);
			}
			float textHeight = textLines.GetTextHeight();
			float num = this.h;
			DataLabelPosition dataLabelPosition = this.g;
			double num2 = 3.141592653589793;
			float num3 = this.i;
			if (num3 < -360f || num3 > 360f)
			{
				num3 %= 360f;
			}
			if (num3 < 0f)
			{
				num3 += 360f;
			}
			if (this.g == DataLabelPosition.Auto)
			{
				if (num3 == 0f)
				{
					dataLabelPosition = DataLabelPosition.Above;
				}
				else if ((num3 > 0f && this.i <= 90f) || (num3 > 270f && num3 <= 360f))
				{
					dataLabelPosition = DataLabelPosition.Right;
				}
				else if (num3 > 90f && num3 <= 180f)
				{
					dataLabelPosition = DataLabelPosition.Left;
					num3 += 180f;
				}
				else if (num3 > 180f && num3 <= 270f)
				{
					dataLabelPosition = DataLabelPosition.Left;
					num3 -= 180f;
				}
			}
			if (this.g != DataLabelPosition.Center)
			{
				float num4 = num3;
				switch (dataLabelPosition)
				{
				case DataLabelPosition.Left:
					num4 += 180f;
					break;
				case DataLabelPosition.Above:
					num4 += 270f;
					break;
				case DataLabelPosition.Below:
					num4 += 90f;
					break;
				}
				double num5 = (double)A_1 + (double)num * Math.Cos((double)num4 * (num2 / 180.0));
				double num6 = (double)A_2 + (double)num * Math.Sin((double)num4 * (num2 / 180.0));
				float num7 = num4 + 90f;
				double num8 = 0.0;
				double num9 = 0.0;
				if (dataLabelPosition == DataLabelPosition.Above || dataLabelPosition == DataLabelPosition.Below)
				{
					num8 = Math.Cos((double)num7 * num2 / 180.0) * (double)textWidth / 2.0;
					num9 = Math.Sin((double)num7 * num2 / 180.0) * (double)textWidth / 2.0;
				}
				else if (dataLabelPosition == DataLabelPosition.Left || dataLabelPosition == DataLabelPosition.Right)
				{
					num8 = Math.Cos((double)num7 * num2 / 180.0) * (double)textHeight / 2.0;
					num9 = Math.Sin((double)num7 * num2 / 180.0) * (double)textHeight / 2.0;
				}
				A_1 = (float)(num5 - num8);
				A_2 = (float)(num6 - num9);
				if (this.g == DataLabelPosition.Auto)
				{
					A_0.SetDimensionsSimpleRotate(A_1, A_2, num3);
				}
				else
				{
					A_0.SetDimensionsSimpleRotate(A_1, A_2, this.i);
				}
				switch (dataLabelPosition)
				{
				case DataLabelPosition.Left:
					A_1 -= textWidth;
					A_2 -= textHeight;
					break;
				case DataLabelPosition.Above:
					A_2 -= textHeight;
					break;
				case DataLabelPosition.Below:
					A_1 -= textWidth;
					break;
				}
				TextAlign a_ = this.a(dataLabelPosition);
				textLines.ja(A_0, A_1, A_2, a_, this.c, null, 0f, false, false, false);
				A_0.ResetDimensions();
			}
			else
			{
				A_0.SetDimensionsSimpleRotate(A_1, A_2, num3);
				A_1 -= textWidth / 2f;
				A_2 -= textHeight / 2f;
				TextAlign a_ = this.a(this.g);
				textLines.ja(A_0, A_1, A_2, a_, this.c, null, 0f, false, false, false);
				A_0.ResetDimensions();
			}
		}

		// Token: 0x04002A57 RID: 10839
		private Font a;

		// Token: 0x04002A58 RID: 10840
		private float b;

		// Token: 0x04002A59 RID: 10841
		private Color c;

		// Token: 0x04002A5A RID: 10842
		private string d = "";

		// Token: 0x04002A5B RID: 10843
		private string e = "";

		// Token: 0x04002A5C RID: 10844
		private string f = ",";

		// Token: 0x04002A5D RID: 10845
		private DataLabelPosition g = DataLabelPosition.Auto;

		// Token: 0x04002A5E RID: 10846
		private float h = 10f;

		// Token: 0x04002A5F RID: 10847
		private float i = 0f;

		// Token: 0x04002A60 RID: 10848
		private bool j = true;

		// Token: 0x04002A61 RID: 10849
		private float k = 0f;

		// Token: 0x04002A62 RID: 10850
		private DataLabelAlign l = DataLabelAlign.Auto;
	}
}
