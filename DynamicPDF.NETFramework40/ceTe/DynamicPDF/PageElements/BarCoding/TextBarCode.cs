using System;
using System.Collections.Generic;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x02000750 RID: 1872
	public abstract class TextBarCode : BarCode
	{
		// Token: 0x06004C3A RID: 19514 RVA: 0x0026B24C File Offset: 0x0026A24C
		protected TextBarCode(string value, float x, float y, float height, float xDimension) : this(value, x, y, height, xDimension, true, Font.Helvetica, 12f)
		{
		}

		// Token: 0x06004C3B RID: 19515 RVA: 0x0026B274 File Offset: 0x0026A274
		protected TextBarCode(string value, float x, float y, float height, float xDimension, bool showText) : this(value, x, y, height, xDimension, showText, Font.Helvetica, 12f)
		{
		}

		// Token: 0x06004C3C RID: 19516 RVA: 0x0026B29D File Offset: 0x0026A29D
		protected TextBarCode(string value, float x, float y, float height, float xDimension, bool showText, Font font, float fontSize) : base(value, x, y, height, xDimension)
		{
			this.a = showText;
			this.b = font;
			this.c = fontSize;
		}

		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x06004C3D RID: 19517 RVA: 0x0026B2DC File Offset: 0x0026A2DC
		// (set) Token: 0x06004C3E RID: 19518 RVA: 0x0026B2F4 File Offset: 0x0026A2F4
		public bool ShowText
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

		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x06004C3F RID: 19519 RVA: 0x0026B300 File Offset: 0x0026A300
		// (set) Token: 0x06004C40 RID: 19520 RVA: 0x0026B318 File Offset: 0x0026A318
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

		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x06004C41 RID: 19521 RVA: 0x0026B324 File Offset: 0x0026A324
		// (set) Token: 0x06004C42 RID: 19522 RVA: 0x0026B33C File Offset: 0x0026A33C
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

		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x06004C43 RID: 19523 RVA: 0x0026B348 File Offset: 0x0026A348
		// (set) Token: 0x06004C44 RID: 19524 RVA: 0x0026B360 File Offset: 0x0026A360
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

		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x06004C45 RID: 19525 RVA: 0x0026B36C File Offset: 0x0026A36C
		// (set) Token: 0x06004C46 RID: 19526 RVA: 0x0026B384 File Offset: 0x0026A384
		public Align TextAlign
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

		// Token: 0x06004C47 RID: 19527 RVA: 0x0026B390 File Offset: 0x0026A390
		internal float a(string A_0, float A_1, out TextLineList A_2)
		{
			A_2 = this.Font.GetTextLines(A_0.ToCharArray(), A_1, this.FontSize);
			return A_2.GetRequiredHeight(0);
		}

		// Token: 0x06004C48 RID: 19528 RVA: 0x0026B3C4 File Offset: 0x0026A3C4
		internal float a(char[] A_0, float A_1, out TextLineList A_2)
		{
			A_2 = this.Font.GetTextLines(A_0, A_1, this.FontSize);
			return A_2.GetRequiredHeight(0);
		}

		// Token: 0x06004C49 RID: 19529 RVA: 0x0026B3F4 File Offset: 0x0026A3F4
		internal float a(string A_0, float A_1, out List<string> A_2, out float A_3)
		{
			A_2 = BarCode.b(A_0);
			List<string> list = new List<string>();
			float result;
			if (this.ShowText)
			{
				float num = 0f;
				A_3 = BarCode.a(this.FontSize, this.Font);
				this.a(A_2, ref list, A_0, A_3, A_1, ref num);
				if (num == 0f)
				{
					num = A_3;
				}
				A_2 = list;
				result = num;
			}
			else
			{
				A_3 = 0f;
				result = 0f;
			}
			return result;
		}

		// Token: 0x06004C4A RID: 19530 RVA: 0x0026B478 File Offset: 0x0026A478
		internal void a(PageWriter A_0, TextLineList A_1, float A_2)
		{
			A_0.SetTextMode();
			A_1.g();
			switch (this.TextAlign)
			{
			case Align.Left:
				A_1.Draw(A_0, this.X, A_2, ceTe.DynamicPDF.TextAlign.Left, this.TextColor, false, false);
				break;
			case Align.Center:
				A_1.Draw(A_0, this.X, A_2, ceTe.DynamicPDF.TextAlign.Center, this.TextColor, false, false);
				break;
			case Align.Right:
				A_1.Draw(A_0, this.X, A_2, ceTe.DynamicPDF.TextAlign.Right, this.TextColor, false, false);
				break;
			default:
				A_1.Draw(A_0, this.X, A_2, ceTe.DynamicPDF.TextAlign.Justify, this.TextColor, false, false);
				break;
			}
		}

		// Token: 0x06004C4B RID: 19531 RVA: 0x0026B518 File Offset: 0x0026A518
		private void a(List<string> A_0, ref List<string> A_1, string A_2, float A_3, float A_4, ref float A_5)
		{
			int index = A_0.Count - 1;
			List<string> list = new List<string>();
			float textWidth;
			do
			{
				textWidth = this.Font.GetTextWidth(A_2, this.FontSize);
				if (textWidth > A_4)
				{
					list.Insert(0, A_0[index]);
					A_2 = A_2.Replace(A_0[index--], "");
				}
			}
			while (textWidth > A_4);
			if (A_2.Length == 0)
			{
				A_2 = A_0[0];
				list.RemoveAt(0);
			}
			A_1.Add(A_2);
			A_5 += A_3;
			if (list.Count > 0)
			{
				A_2 = "";
				for (int i = 0; i < list.Count; i++)
				{
					A_2 += list[i];
				}
				this.a(list, ref A_1, A_2, A_3, A_4, ref A_5);
			}
		}

		// Token: 0x06004C4C RID: 19532 RVA: 0x0026B614 File Offset: 0x0026A614
		private void a(ref List<string> A_0, string A_1, float A_2, float A_3, ref float A_4)
		{
			int num = A_1.Length;
			float textWidth;
			do
			{
				textWidth = this.Font.GetTextWidth(A_1.Substring(0, num), this.FontSize);
				num--;
			}
			while (textWidth > A_3);
			num++;
			A_0.Add(A_1.Substring(0, num));
			A_4 += A_2;
			A_1 = A_1.Substring(num);
			if (!string.IsNullOrEmpty(A_1))
			{
				this.a(ref A_0, A_1, A_2, A_3, ref A_4);
			}
		}

		// Token: 0x0400292A RID: 10538
		private new bool a;

		// Token: 0x0400292B RID: 10539
		private new Font b;

		// Token: 0x0400292C RID: 10540
		private float c;

		// Token: 0x0400292D RID: 10541
		private new Color d = Grayscale.Black;

		// Token: 0x0400292E RID: 10542
		private Align e = Align.Center;
	}
}
