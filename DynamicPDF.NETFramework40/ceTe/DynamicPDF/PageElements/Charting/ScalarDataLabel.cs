using System;
using System.ComponentModel;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007AD RID: 1965
	public class ScalarDataLabel
	{
		// Token: 0x06004FAA RID: 20394 RVA: 0x0027C836 File Offset: 0x0027B836
		public ScalarDataLabel(bool showValue)
		{
			this.d = showValue;
		}

		// Token: 0x06004FAB RID: 20395 RVA: 0x0027C869 File Offset: 0x0027B869
		public ScalarDataLabel(bool showValue, bool showElement)
		{
			this.d = showValue;
			this.f = showElement;
		}

		// Token: 0x06004FAC RID: 20396 RVA: 0x0027C8A4 File Offset: 0x0027B8A4
		public ScalarDataLabel(bool showValue, bool showPercentage, bool showElement)
		{
			this.d = showValue;
			this.e = showPercentage;
			this.f = showElement;
		}

		// Token: 0x06004FAD RID: 20397 RVA: 0x0027C8F0 File Offset: 0x0027B8F0
		public ScalarDataLabel(Font font, float fontSize, Color color, bool showValue)
		{
			this.a = font;
			this.b = fontSize;
			this.c = color;
			this.d = showValue;
		}

		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x06004FAE RID: 20398 RVA: 0x0027C944 File Offset: 0x0027B944
		// (set) Token: 0x06004FAF RID: 20399 RVA: 0x0027C95C File Offset: 0x0027B95C
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

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x06004FB0 RID: 20400 RVA: 0x0027C968 File Offset: 0x0027B968
		// (set) Token: 0x06004FB1 RID: 20401 RVA: 0x0027C980 File Offset: 0x0027B980
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

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x06004FB2 RID: 20402 RVA: 0x0027C98C File Offset: 0x0027B98C
		// (set) Token: 0x06004FB3 RID: 20403 RVA: 0x0027C9A4 File Offset: 0x0027B9A4
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

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x06004FB4 RID: 20404 RVA: 0x0027C9B0 File Offset: 0x0027B9B0
		// (set) Token: 0x06004FB5 RID: 20405 RVA: 0x0027C9C8 File Offset: 0x0027B9C8
		public string Suffix
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

		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x06004FB6 RID: 20406 RVA: 0x0027C9D4 File Offset: 0x0027B9D4
		// (set) Token: 0x06004FB7 RID: 20407 RVA: 0x0027C9EC File Offset: 0x0027B9EC
		public string Prefix
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

		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x06004FB8 RID: 20408 RVA: 0x0027C9F8 File Offset: 0x0027B9F8
		// (set) Token: 0x06004FB9 RID: 20409 RVA: 0x0027CA10 File Offset: 0x0027BA10
		[Obsolete("This property is obsolete. Use Separator property instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string Seperator
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

		// Token: 0x1700069A RID: 1690
		// (get) Token: 0x06004FBA RID: 20410 RVA: 0x0027CA1C File Offset: 0x0027BA1C
		// (set) Token: 0x06004FBB RID: 20411 RVA: 0x0027CA34 File Offset: 0x0027BA34
		public string Separator
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

		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x06004FBC RID: 20412 RVA: 0x0027CA40 File Offset: 0x0027BA40
		// (set) Token: 0x06004FBD RID: 20413 RVA: 0x0027CA58 File Offset: 0x0027BA58
		public bool ShowValue
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

		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x06004FBE RID: 20414 RVA: 0x0027CA64 File Offset: 0x0027BA64
		// (set) Token: 0x06004FBF RID: 20415 RVA: 0x0027CA7C File Offset: 0x0027BA7C
		public bool ShowPercentage
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

		// Token: 0x1700069D RID: 1693
		// (get) Token: 0x06004FC0 RID: 20416 RVA: 0x0027CA88 File Offset: 0x0027BA88
		// (set) Token: 0x06004FC1 RID: 20417 RVA: 0x0027CAA0 File Offset: 0x0027BAA0
		public bool ShowElement
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

		// Token: 0x06004FC2 RID: 20418 RVA: 0x0027CAAC File Offset: 0x0027BAAC
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

		// Token: 0x06004FC3 RID: 20419 RVA: 0x0027CB10 File Offset: 0x0027BB10
		internal void a(PageWriter A_0, float A_1, float A_2, TextLineList A_3)
		{
			A_3.ja(A_0, A_1, A_2, TextAlign.Center, this.Color, null, 0f, false, false, false);
		}

		// Token: 0x04002B08 RID: 11016
		private Font a;

		// Token: 0x04002B09 RID: 11017
		private float b;

		// Token: 0x04002B0A RID: 11018
		private Color c;

		// Token: 0x04002B0B RID: 11019
		private bool d;

		// Token: 0x04002B0C RID: 11020
		private bool e;

		// Token: 0x04002B0D RID: 11021
		private bool f;

		// Token: 0x04002B0E RID: 11022
		private string g = "";

		// Token: 0x04002B0F RID: 11023
		private string h = "";

		// Token: 0x04002B10 RID: 11024
		private string i = ",";
	}
}
