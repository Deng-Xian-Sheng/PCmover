using System;
using System.ComponentModel;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x0200045F RID: 1119
	public abstract class TextLineList
	{
		// Token: 0x06002E45 RID: 11845 RVA: 0x001A4BDC File Offset: 0x001A3BDC
		internal TextLineList(char[] A_0, int A_1, int A_2, float A_3, float A_4, Font A_5, float A_6, bool A_7, float A_8)
		{
			this.c = A_0;
			this.d = A_1;
			this.e = A_1 + A_2 - 1;
			this.f = A_3;
			this.g = A_4;
			this.h = A_5;
			this.i = A_6;
			this.j = A_8;
			this.n = A_7;
		}

		// Token: 0x06002E46 RID: 11846 RVA: 0x001A4C98 File Offset: 0x001A3C98
		protected TextLineList(char[] text, int start, int length, float width, float height, Font font, float fontSize, bool initialLineIsNewParagraph)
		{
			this.c = text;
			this.d = start;
			this.e = start + length - 1;
			this.f = width;
			this.g = height;
			this.h = font;
			this.i = fontSize;
			this.j = font.GetDefaultLeading(fontSize);
			this.n = initialLineIsNewParagraph;
		}

		// Token: 0x06002E47 RID: 11847 RVA: 0x001A4D58 File Offset: 0x001A3D58
		protected TextLineList(int start, float width, float height, bool initialLineIsNewParagraph, TextLineList textLineList)
		{
			this.d = start;
			this.f = width;
			this.g = height;
			this.n = initialLineIsNewParagraph;
			this.c = textLineList.c;
			this.e = textLineList.e;
			this.h = textLineList.h;
			this.i = textLineList.i;
			this.j = textLineList.j;
			this.k = textLineList.k;
			this.l = textLineList.l;
			this.p = textLineList.p;
		}

		// Token: 0x06002E48 RID: 11848 RVA: 0x001A4E50 File Offset: 0x001A3E50
		internal TextLineList(TextLineList A_0)
		{
			this.d = A_0.d;
			this.f = A_0.f;
			this.g = A_0.g;
			this.n = A_0.n;
			this.c = A_0.c;
			this.e = A_0.e;
			this.h = A_0.h;
			this.i = A_0.i;
			this.j = A_0.j;
			this.k = A_0.k;
			this.l = A_0.l;
			this.p = A_0.p;
			this.v = A_0.v;
		}

		// Token: 0x06002E49 RID: 11849 RVA: 0x001A4F5C File Offset: 0x001A3F5C
		protected void SetLines(bool setAllLines)
		{
			bool flag = this.t;
			if (this.r || this.t)
			{
				this.InitializeLines(this.n);
				this.b = 0;
				this.m = this.h.GetBaseLine(this.i, this.j);
				TextLineList.LineCalculationMode mode = setAllLines ? TextLineList.LineCalculationMode.All : TextLineList.LineCalculationMode.ToHeight;
				this.s = this.CalculateLines(mode);
				this.r = false;
				this.t = false;
				if (this.g == 3.4028235E+38f)
				{
					this.o = this.b;
				}
				else
				{
					this.o = this.GetLineCount(0, this.g);
				}
				this.b();
			}
			else if (setAllLines && !this.s)
			{
				TextLineList.LineCalculationMode mode = setAllLines ? TextLineList.LineCalculationMode.All : TextLineList.LineCalculationMode.ToHeight;
				this.s = this.CalculateLines(mode);
				this.r = false;
			}
			this.t = flag;
		}

		// Token: 0x06002E4A RID: 11850 RVA: 0x001A5060 File Offset: 0x001A4060
		internal bool f()
		{
			return this.t;
		}

		// Token: 0x06002E4B RID: 11851 RVA: 0x001A5078 File Offset: 0x001A4078
		internal void b(bool A_0)
		{
			this.t = A_0;
		}

		// Token: 0x06002E4C RID: 11852 RVA: 0x001A5082 File Offset: 0x001A4082
		internal void g()
		{
			this.SetLines(false);
		}

		// Token: 0x06002E4D RID: 11853 RVA: 0x001A5090 File Offset: 0x001A4090
		internal virtual float i9(int A_0)
		{
			return this.a[A_0].GetWidth(this.FontSize);
		}

		// Token: 0x06002E4E RID: 11854
		protected abstract bool CalculateLines(TextLineList.LineCalculationMode mode);

		// Token: 0x06002E4F RID: 11855
		protected abstract void InitializeLines(bool newParagraph);

		// Token: 0x06002E50 RID: 11856
		public abstract TextLineList GetOverflow(float width, float height);

		// Token: 0x06002E51 RID: 11857 RVA: 0x001A50B8 File Offset: 0x001A40B8
		internal TextLineList a(float A_0)
		{
			return this.GetOverflow(this.f, A_0);
		}

		// Token: 0x06002E52 RID: 11858
		public abstract bool HasOverflow();

		// Token: 0x06002E53 RID: 11859
		public abstract string GetOverflowText();

		// Token: 0x06002E54 RID: 11860 RVA: 0x001A50D8 File Offset: 0x001A40D8
		public string GetText()
		{
			return new string(this.c, this.d, this.e - this.d + 1);
		}

		// Token: 0x06002E55 RID: 11861 RVA: 0x001A510A File Offset: 0x001A410A
		public void SetText(string text)
		{
			this.r = true;
			this.c = text.ToCharArray();
			this.d = 0;
			this.e = this.c.Length - 1;
		}

		// Token: 0x06002E56 RID: 11862 RVA: 0x001A5137 File Offset: 0x001A4137
		public void SetText(char[] text)
		{
			this.r = true;
			this.c = text;
			this.d = 0;
			this.e = this.c.Length - 1;
		}

		// Token: 0x06002E57 RID: 11863 RVA: 0x001A5160 File Offset: 0x001A4160
		private void b()
		{
			if (this.p)
			{
				if (!this.a[this.o - 1].HardReturn && this.o >= 2)
				{
					if (this.a[this.o - 1].NewParagraph)
					{
						this.o--;
					}
					else
					{
						if (this.o == this.b)
						{
							this.s = this.CalculateLines(TextLineList.LineCalculationMode.OneLine);
						}
						if (this.a[this.o].HardReturn)
						{
							if (this.a[this.o - 2].NewParagraph)
							{
								this.o -= 2;
							}
							else
							{
								this.o--;
							}
						}
					}
				}
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06002E58 RID: 11864 RVA: 0x001A5258 File Offset: 0x001A4258
		// (set) Token: 0x06002E59 RID: 11865 RVA: 0x001A5270 File Offset: 0x001A4270
		protected int Start
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

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06002E5A RID: 11866 RVA: 0x001A527C File Offset: 0x001A427C
		// (set) Token: 0x06002E5B RID: 11867 RVA: 0x001A5294 File Offset: 0x001A4294
		protected int End
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

		// Token: 0x06002E5C RID: 11868 RVA: 0x001A52A0 File Offset: 0x001A42A0
		protected void Add(TextLine line)
		{
			if (!this.u && this.b > 0)
			{
				this.u = line.NewParagraph;
			}
			this.a();
			this.a[this.b++] = line;
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06002E5D RID: 11869 RVA: 0x001A5300 File Offset: 0x001A4300
		protected int LineCount
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x06002E5E RID: 11870 RVA: 0x001A5318 File Offset: 0x001A4318
		internal void c(bool A_0)
		{
			this.r = A_0;
		}

		// Token: 0x06002E5F RID: 11871 RVA: 0x001A5324 File Offset: 0x001A4324
		internal bool h()
		{
			return this.v;
		}

		// Token: 0x06002E60 RID: 11872 RVA: 0x001A533C File Offset: 0x001A433C
		internal void d(bool A_0)
		{
			this.v = A_0;
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06002E61 RID: 11873 RVA: 0x001A5348 File Offset: 0x001A4348
		public int VisibleLineCount
		{
			get
			{
				this.SetLines(false);
				return this.o;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06002E62 RID: 11874 RVA: 0x001A5368 File Offset: 0x001A4368
		protected float BaseLine
		{
			get
			{
				return this.m;
			}
		}

		// Token: 0x170000CD RID: 205
		protected TextLine this[int index]
		{
			get
			{
				return this.a[index];
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06002E64 RID: 11876 RVA: 0x001A539C File Offset: 0x001A439C
		// (set) Token: 0x06002E65 RID: 11877 RVA: 0x001A53B4 File Offset: 0x001A43B4
		protected virtual char[] TextArray
		{
			get
			{
				return this.c;
			}
			set
			{
				this.r = true;
				this.c = value;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06002E66 RID: 11878 RVA: 0x001A53C8 File Offset: 0x001A43C8
		// (set) Token: 0x06002E67 RID: 11879 RVA: 0x001A53E0 File Offset: 0x001A43E0
		public float Width
		{
			get
			{
				return this.f;
			}
			set
			{
				this.r = true;
				this.f = value;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06002E68 RID: 11880 RVA: 0x001A53F4 File Offset: 0x001A43F4
		// (set) Token: 0x06002E69 RID: 11881 RVA: 0x001A540C File Offset: 0x001A440C
		public bool CleanParagraphBreaks
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

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06002E6A RID: 11882 RVA: 0x001A5418 File Offset: 0x001A4418
		// (set) Token: 0x06002E6B RID: 11883 RVA: 0x001A5430 File Offset: 0x001A4430
		public float Height
		{
			get
			{
				return this.g;
			}
			set
			{
				float num = this.g;
				this.g = value;
				if (this.b != 0)
				{
					if (this.r)
					{
						this.SetLines(false);
					}
					else if (this.g > num)
					{
						if (!this.s)
						{
							this.s = this.CalculateLines(TextLineList.LineCalculationMode.ToHeight);
						}
						this.o = this.GetLineCount(0, this.g);
						this.b();
					}
					else
					{
						this.o = this.GetLineCount(0, this.g);
						this.b();
					}
				}
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06002E6C RID: 11884 RVA: 0x001A54DC File Offset: 0x001A44DC
		// (set) Token: 0x06002E6D RID: 11885 RVA: 0x001A54F4 File Offset: 0x001A44F4
		public Font Font
		{
			get
			{
				return this.h;
			}
			set
			{
				this.r = true;
				this.h = value;
				if (this.q)
				{
					this.j = this.h.GetDefaultLeading(this.i);
				}
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06002E6E RID: 11886 RVA: 0x001A5534 File Offset: 0x001A4534
		// (set) Token: 0x06002E6F RID: 11887 RVA: 0x001A554C File Offset: 0x001A454C
		public float FontSize
		{
			get
			{
				return this.i;
			}
			set
			{
				this.r = true;
				this.i = value;
				if (this.q)
				{
					this.j = this.h.GetDefaultLeading(this.i);
				}
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06002E70 RID: 11888 RVA: 0x001A558C File Offset: 0x001A458C
		// (set) Token: 0x06002E71 RID: 11889 RVA: 0x001A55A4 File Offset: 0x001A45A4
		public float Leading
		{
			get
			{
				return this.j;
			}
			set
			{
				this.r = true;
				this.q = false;
				this.j = value;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06002E72 RID: 11890 RVA: 0x001A55BC File Offset: 0x001A45BC
		// (set) Token: 0x06002E73 RID: 11891 RVA: 0x001A55D4 File Offset: 0x001A45D4
		public bool AutoLeading
		{
			get
			{
				return this.q;
			}
			set
			{
				this.q = value;
				if (this.q)
				{
					this.r = true;
					this.j = this.h.GetDefaultLeading(this.i);
				}
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06002E74 RID: 11892 RVA: 0x001A5618 File Offset: 0x001A4618
		public int Count
		{
			get
			{
				this.SetLines(false);
				return this.b;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06002E75 RID: 11893 RVA: 0x001A5638 File Offset: 0x001A4638
		// (set) Token: 0x06002E76 RID: 11894 RVA: 0x001A5650 File Offset: 0x001A4650
		public float ParagraphIndent
		{
			get
			{
				return this.k;
			}
			set
			{
				this.r = true;
				this.k = value;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06002E77 RID: 11895 RVA: 0x001A5664 File Offset: 0x001A4664
		// (set) Token: 0x06002E78 RID: 11896 RVA: 0x001A567C File Offset: 0x001A467C
		public float ParagraphSpacing
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

		// Token: 0x06002E79 RID: 11897 RVA: 0x001A5688 File Offset: 0x001A4688
		internal TextLine[] i()
		{
			return this.a;
		}

		// Token: 0x06002E7A RID: 11898 RVA: 0x001A56A0 File Offset: 0x001A46A0
		private void a()
		{
			if (this.b >= this.a.Length)
			{
				TextLine[] array = new TextLine[this.a.Length * 4];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
		}

		// Token: 0x06002E7B RID: 11899 RVA: 0x001A56EC File Offset: 0x001A46EC
		public float GetRequiredHeight(int startLine)
		{
			this.SetLines(true);
			float result;
			if (!GlobalSettings.UseLegacyTextHeightCalculations)
			{
				result = this.a[this.b - 1].YOffset - this.a[startLine].YOffset + this.j + 0.001f - this.h.GetLineGap(this.i);
			}
			else
			{
				result = this.a[this.b - 1].YOffset - this.a[startLine].YOffset + this.j + 0.001f;
			}
			return result;
		}

		// Token: 0x06002E7C RID: 11900 RVA: 0x001A5784 File Offset: 0x001A4784
		internal int j()
		{
			int result;
			if (!this.p || this.o <= 1 || this.a[0].HardReturn)
			{
				result = 1;
			}
			else if (this.o == 2 || this.a[1].HardReturn)
			{
				result = 2;
			}
			else if (this.o >= 3 && this.a[2].HardReturn)
			{
				result = 3;
			}
			else
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x06002E7D RID: 11901 RVA: 0x001A5810 File Offset: 0x001A4810
		internal int k()
		{
			int result;
			if (this.o <= 1)
			{
				result = 0;
			}
			else
			{
				int num = this.o - 1;
				if (!this.p || this.a[num].HardReturn)
				{
					result = num;
				}
				else
				{
					num--;
					if (this.a[num].HardReturn)
					{
						result = num;
					}
					else
					{
						num--;
						if (this.a[num].HardReturn)
						{
							result = num;
						}
						else
						{
							result = num + 1;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06002E7E RID: 11902 RVA: 0x001A589C File Offset: 0x001A489C
		public float GetTextHeight(int lineCount)
		{
			this.SetLines(false);
			float result;
			if (!GlobalSettings.UseLegacyTextHeightCalculations)
			{
				result = this.a[lineCount - 1].YOffset - this.a[0].YOffset + this.j + 0.001f - this.h.GetLineGap(this.i);
			}
			else
			{
				result = this.a[lineCount - 1].YOffset - this.a[0].YOffset + this.j + 0.001f;
			}
			return result;
		}

		// Token: 0x06002E7F RID: 11903 RVA: 0x001A592C File Offset: 0x001A492C
		[Obsolete("This method is obsolete. Use GetMaximumWidth() method instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public float GetMaximunWidth()
		{
			this.SetLines(false);
			float num = 0f;
			for (int i = 0; i < this.o; i++)
			{
				float width = this.a[i].GetWidth(this.i);
				if (width > num)
				{
					num = width;
				}
			}
			return num + 0.001f;
		}

		// Token: 0x06002E80 RID: 11904 RVA: 0x001A5990 File Offset: 0x001A4990
		public float GetMaximumWidth()
		{
			this.SetLines(false);
			float num = 0f;
			for (int i = 0; i < this.o; i++)
			{
				float width = this.a[i].GetWidth(this.i);
				if (width > num)
				{
					num = width;
				}
			}
			return num + 0.001f;
		}

		// Token: 0x06002E81 RID: 11905 RVA: 0x001A59F4 File Offset: 0x001A49F4
		public float GetTextHeight()
		{
			this.SetLines(false);
			float result;
			if (!GlobalSettings.UseLegacyTextHeightCalculations)
			{
				result = this.a[this.o - 1].YOffset - this.a[0].YOffset + this.j + 0.001f - this.h.GetLineGap(this.i);
			}
			else
			{
				result = this.a[this.o - 1].YOffset - this.a[0].YOffset + this.j + 0.001f;
			}
			return result;
		}

		// Token: 0x06002E82 RID: 11906 RVA: 0x001A5A8C File Offset: 0x001A4A8C
		public int GetLineCount(int startLine, float height)
		{
			int result;
			if (height <= this.j)
			{
				result = 1;
			}
			else
			{
				this.SetLines(false);
				float yoffset = this.a[startLine].YOffset;
				int num;
				if (!GlobalSettings.UseLegacyTextHeightCalculations)
				{
					num = (int)((height + this.h.GetLineGap(this.i)) / this.j + 0.001f) + startLine - 1;
				}
				else
				{
					num = (int)(height / this.j + 0.001f) + startLine - 1;
				}
				int num2 = this.b - 1;
				if (num >= this.b)
				{
					num = num2;
				}
				if (this.ParagraphSpacing == 0f)
				{
					result = num - startLine + 1;
				}
				else if (this.ParagraphSpacing > 0f)
				{
					height -= this.m();
					while (this.a[num].YOffset - yoffset > height)
					{
						num--;
					}
					result = num - startLine + 1;
				}
				else
				{
					height -= this.m();
					while (num < num2 && this.a[num + 1].YOffset - yoffset <= height)
					{
						num++;
					}
					result = num - startLine + 1;
				}
			}
			return result;
		}

		// Token: 0x06002E83 RID: 11907 RVA: 0x001A5BD4 File Offset: 0x001A4BD4
		public virtual void Draw(OperatorWriter writer, float x, float y, TextAlign align, Color textColor, bool underline, bool rightToLeft)
		{
			this.SetLines(false);
			this.jb(writer, x, y, align, textColor, null, 0f, underline, 0, this.o, rightToLeft, false);
		}

		// Token: 0x06002E84 RID: 11908 RVA: 0x001A5C0C File Offset: 0x001A4C0C
		public virtual void Draw(OperatorWriter writer, float x, float y, TextAlign align, Color textColor, bool underline, int startLine, int lineCount, bool rightToLeft, bool strikeThrough)
		{
			this.jb(writer, x, y, align, textColor, null, 0f, underline, startLine, lineCount, rightToLeft, strikeThrough);
		}

		// Token: 0x06002E85 RID: 11909 RVA: 0x001A5C38 File Offset: 0x001A4C38
		internal virtual void ja(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, Color A_5, float A_6, bool A_7, bool A_8, bool A_9)
		{
			this.SetLines(false);
			this.jb(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7, 0, this.o, A_8, A_9);
		}

		// Token: 0x06002E86 RID: 11910 RVA: 0x001A5C70 File Offset: 0x001A4C70
		internal virtual void k2(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, Color A_5, float A_6, bool A_7, int A_8, int A_9, bool A_10, bool A_11, StructureElement A_12, AttributeTypeList A_13, AttributeClassList A_14, bool A_15)
		{
			if (A_5 != null && A_6 > 0f)
			{
				if (A_4 != null)
				{
					A_0.SetTextRenderingMode(TextRenderingMode.FillAndStroke);
					A_0.SetStrokeColor(A_5);
					A_0.SetFillColor(A_4);
				}
				else
				{
					A_0.SetTextRenderingMode(TextRenderingMode.Stroke);
					A_0.SetStrokeColor(A_5);
				}
				A_0.SetLineWidth(A_6);
				A_0.SetLineStyle(LineStyle.Solid);
			}
			else if (A_4 != null)
			{
				A_0.SetTextRenderingMode(TextRenderingMode.Fill);
				A_0.SetFillColor(A_4);
			}
			else
			{
				A_0.SetTextRenderingMode(TextRenderingMode.Invisible);
			}
			A_0.SetTextMode();
			A_0.SetFont(this.h, this.i);
			switch (A_3)
			{
			case TextAlign.Left:
				this.d(A_0, A_1, A_2, A_8, A_9, A_10, A_12, A_13, A_14, A_15);
				break;
			case TextAlign.Center:
				this.b(A_0, A_1, A_2, A_8, A_9, A_10, A_12, A_13, A_14, A_15);
				break;
			case TextAlign.Right:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, A_12, A_13, A_14, A_15);
				break;
			case TextAlign.Justify:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, false, A_12, A_13, A_14, A_15);
				break;
			case TextAlign.FullJustify:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, true, A_12, A_13, A_14, A_15);
				break;
			}
			if (A_7 && (A_4 != null || (A_6 > 0f && A_5 != null)))
			{
				this.a(A_0, A_4, A_5, A_6);
				this.a(A_0, A_1, this.b(A_2), A_3, A_4, A_8, A_9, A_10, this.h.d(this.i), A_5, true, A_6);
			}
			if (A_11 && (A_4 != null || (A_6 > 0f && A_5 != null)))
			{
				this.a(A_0, A_4, A_5, A_6);
				this.a(A_0, A_1, this.c(A_2), A_3, A_4, A_8, A_9, A_10, this.h.a(this.i), A_5, false, A_6);
			}
		}

		// Token: 0x06002E87 RID: 11911 RVA: 0x001A5EA0 File Offset: 0x001A4EA0
		internal virtual void jc(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, Color A_5, float A_6, bool A_7, bool A_8, bool A_9, StructureElement A_10, AttributeTypeList A_11, AttributeClassList A_12)
		{
			bool flag = false;
			if (A_5 != null && A_6 > 0f)
			{
				if (A_4 != null)
				{
					A_0.SetTextRenderingMode(TextRenderingMode.FillAndStroke);
					A_0.SetStrokeColor(A_5);
					A_0.SetFillColor(A_4);
				}
				else
				{
					A_0.SetTextRenderingMode(TextRenderingMode.Stroke);
					A_0.SetStrokeColor(A_5);
				}
				A_0.SetLineWidth(A_6);
				A_0.SetLineStyle(LineStyle.Solid);
			}
			else if (A_4 != null)
			{
				A_0.SetTextRenderingMode(TextRenderingMode.Fill);
				A_0.SetFillColor(A_4);
			}
			else
			{
				A_0.SetTextRenderingMode(TextRenderingMode.Invisible);
			}
			A_0.SetTextMode();
			A_0.SetFont(this.h, this.i);
			switch (A_3)
			{
			case TextAlign.Left:
				this.d(A_0, A_1, A_2, 0, this.o, A_8, A_10, A_11, A_12, false);
				break;
			case TextAlign.Center:
				this.b(A_0, A_1, A_2, 0, this.o, A_8, A_10, A_11, A_12, false);
				break;
			case TextAlign.Right:
				this.a(A_0, A_1, A_2, 0, this.o, A_8, A_10, A_11, A_12, false);
				break;
			case TextAlign.Justify:
				this.a(A_0, A_1, A_2, 0, this.o, A_8, false, A_10, A_11, A_12, false);
				break;
			case TextAlign.FullJustify:
				this.a(A_0, A_1, A_2, 0, this.o, A_8, true, A_10, A_11, A_12, false);
				break;
			}
			if (A_7 && (A_4 != null || (A_6 > 0f && A_5 != null)))
			{
				this.a(A_0, A_4, A_5, A_6);
				this.a(A_0, A_1, this.b(A_2), A_3, A_4, 0, this.o, A_8, this.h.d(this.i), A_5, true, A_6);
				flag = true;
			}
			if (A_9 && (A_4 != null || (A_6 > 0f && A_5 != null)))
			{
				this.a(A_0, A_4, A_5, A_6);
				this.a(A_0, A_1, this.c(A_2), A_3, A_4, 0, this.o, A_8, this.h.a(this.i), A_5, false, A_6);
				flag = true;
			}
			if (!flag)
			{
				A_0.z();
				A_0.Write_ET();
			}
		}

		// Token: 0x06002E88 RID: 11912 RVA: 0x001A60FC File Offset: 0x001A50FC
		internal static void a(TextLineList A_0, OperatorWriter A_1, float A_2, float A_3, int A_4, StructureElement A_5, AttributeTypeList A_6, AttributeClassList A_7, bool A_8)
		{
			A_1.DocumentWriter.i(A_1.DocumentWriter.ae() + 1);
			StructureElement structureElement;
			if (A_8)
			{
				if (A_4 == 0)
				{
					structureElement = new StructureElement((StandardTagType)A_5.TagType, false);
				}
				else
				{
					structureElement = new StructureElement(TagType.Paragraph, false);
				}
			}
			else
			{
				structureElement = new StructureElement((StandardTagType)A_5.TagType, false);
			}
			structureElement.b(A_5.u());
			structureElement.Parent = A_5;
			if (A_6 != null)
			{
				AttributeTypeList attributeTypeList = null;
				attributeTypeList = TextLineList.a(A_0, A_1, A_2, A_3, A_4, A_6, attributeTypeList);
				if (!A_0.a[A_4].NewParagraph)
				{
					if (attributeTypeList == null)
					{
						attributeTypeList = A_6.a();
					}
					AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
					attributeObject.SetTextIndent(0f);
					attributeTypeList.Add(attributeObject);
				}
				structureElement.a((attributeTypeList != null) ? attributeTypeList : A_6);
			}
			else if (!A_0.a[A_4].NewParagraph)
			{
				AttributeObject attributeObject = new AttributeObject(AttributeOwner.Layout);
				attributeObject.SetTextIndent(0f);
				AttributeTypeList attributeTypeList2 = new AttributeTypeList(1);
				attributeTypeList2.Add(attributeObject);
				structureElement.a(attributeTypeList2);
			}
			if (A_7 != null)
			{
				AttributeClassList attributeClassList = null;
				for (int i = 0; i < A_7.Count; i++)
				{
					AttributeTypeList attributeObjects = A_7[i].AttributeObjects;
					AttributeTypeList attributeTypeList = null;
					attributeTypeList = TextLineList.a(A_0, A_1, A_2, A_3, A_4, attributeObjects, attributeTypeList);
					if (attributeTypeList != null)
					{
						if (attributeClassList == null)
						{
							attributeClassList = A_7.a();
						}
						AttributeClass attributeClass = new AttributeClass(A_7[i].a() + A_1.DocumentWriter.ae());
						attributeClass.a(attributeTypeList);
						attributeClassList.a(i, attributeClass);
					}
				}
				structureElement.a((attributeClassList != null) ? attributeClassList : A_7);
			}
			structureElement.e((PageWriter)A_1, null);
		}

		// Token: 0x06002E89 RID: 11913 RVA: 0x001A6324 File Offset: 0x001A5324
		private static AttributeTypeList a(TextLineList A_0, OperatorWriter A_1, float A_2, float A_3, int A_4, AttributeTypeList A_5, AttributeTypeList A_6)
		{
			for (int i = 0; i < A_5.Count; i++)
			{
				AttributeObject attributeObject = (AttributeObject)A_5[i];
				if (attributeObject.d())
				{
					if ((attributeObject.b().Contains(Attribute.BBox) && attributeObject.b()[Attribute.BBox] == null) || (attributeObject.b().Contains(Attribute.Height) && attributeObject.b()[Attribute.Height] == null) || (attributeObject.b().Contains(Attribute.Width) && attributeObject.b()[Attribute.Width] == null))
					{
						if (A_6 == null)
						{
							A_6 = A_5.a();
						}
						int num = A_4 + 1;
						while (num < A_0.i().Length && A_0.i()[num] != null && !A_0.i()[num].NewParagraph)
						{
							num++;
						}
						AttributeObject attributeObject2 = attributeObject.c();
						A_6.a(i, attributeObject2);
						attributeObject2.a(A_2, A_3, (float)(num - A_4) * A_0.Leading, A_0, (PageWriter)A_1);
					}
				}
			}
			return A_6;
		}

		// Token: 0x06002E8A RID: 11914 RVA: 0x001A649C File Offset: 0x001A549C
		private void d(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, StructureElement A_6, AttributeTypeList A_7, AttributeClassList A_8, bool A_9)
		{
			A_0.SetLeading(this.j);
			if (this.k != 0f && !A_5)
			{
				this.c(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7, A_8, A_9);
			}
			else
			{
				float num = A_2 + this.m - this.j;
				A_0.Write_Tm(A_1, num);
				for (int i = A_3; i < A_3 + A_4; i++)
				{
					if (this.u && (this.a[i].NewParagraph || i == A_3))
					{
						TextLineList.a(this, A_0, A_1, num, i, A_6, A_7, A_8, A_9);
					}
					A_0.c(this.c, this.a[i].Start, this.a[i].Length, A_5);
					num += this.j;
					if (this.a[i].HardReturn)
					{
						if (this.u)
						{
							Tag.a((PageWriter)A_0);
						}
						num += this.l;
						if (this.l != 0f && i < this.a.Length)
						{
							A_0.Write_Tm(A_1, num);
						}
					}
				}
				if (this.u && !this.a[A_4 - 1].HardReturn)
				{
					Tag.a((PageWriter)A_0);
				}
			}
		}

		// Token: 0x06002E8B RID: 11915 RVA: 0x001A6628 File Offset: 0x001A5628
		private void c(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, StructureElement A_6, AttributeTypeList A_7, AttributeClassList A_8, bool A_9)
		{
			float num = A_2 + this.BaseLine - this.j;
			if (this.u)
			{
				TextLineList.a(this, A_0, A_1, num, A_3, A_6, A_7, A_8, A_9);
			}
			if (this.i()[A_3].NewParagraph)
			{
				A_0.Write_Tm(A_1 + this.ParagraphIndent, num);
			}
			else
			{
				A_0.Write_Tm(A_1, num);
			}
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (i != A_3)
				{
					if (this.i()[i].NewParagraph)
					{
						num += this.ParagraphSpacing;
						if (this.u)
						{
							Tag.a((PageWriter)A_0);
							TextLineList.a(this, A_0, A_1, num, i, A_6, A_7, A_8, A_9);
						}
						A_0.Write_Tm(A_1 + this.ParagraphIndent, num);
					}
					else
					{
						A_0.Write_Tm(A_1, num);
					}
				}
				if (this.i()[i].Length > 0)
				{
					A_0.c(this.c, this.a[i].Start, this.a[i].Length, A_5);
				}
				num += this.Leading;
			}
			if (this.u)
			{
				Tag.a((PageWriter)A_0);
			}
		}

		// Token: 0x06002E8C RID: 11916 RVA: 0x001A6794 File Offset: 0x001A5794
		private void b(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, StructureElement A_6, AttributeTypeList A_7, AttributeClassList A_8, bool A_9)
		{
			float num = A_2 + this.m;
			if (this.u)
			{
				TextLineList.a(this, A_0, A_1, num, A_3, A_6, A_7, A_8, A_9);
			}
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (this.a[i].NewParagraph)
				{
					if (this.u && i != A_3)
					{
						TextLineList.a(this, A_0, A_1, num, i, A_6, A_7, A_8, A_9);
					}
					if (A_5)
					{
						A_0.Write_Tm(A_1 + (-this.k + this.f - this.a[i].GetWidth(this.i)) / 2f, num);
					}
					else
					{
						A_0.Write_Tm(A_1 + (this.k + this.f - this.a[i].GetWidth(this.i)) / 2f, num);
					}
				}
				else
				{
					A_0.Write_Tm(A_1 + (this.f - this.a[i].GetWidth(this.i)) / 2f, num);
				}
				A_0.a(this.c, this.a[i].Start, this.a[i].Length, A_5);
				num += this.j;
				if (this.a[i].HardReturn)
				{
					if (this.u)
					{
						Tag.a((PageWriter)A_0);
					}
					num += this.l;
				}
			}
			if (this.u && !this.a[A_4 - 1].HardReturn)
			{
				Tag.a((PageWriter)A_0);
			}
		}

		// Token: 0x06002E8D RID: 11917 RVA: 0x001A6964 File Offset: 0x001A5964
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, StructureElement A_6, AttributeTypeList A_7, AttributeClassList A_8, bool A_9)
		{
			float num = A_2 + this.m;
			if (this.u)
			{
				TextLineList.a(this, A_0, A_1, num, A_3, A_6, A_7, A_8, A_9);
			}
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (this.a[i].NewParagraph)
				{
					if (this.u && i != A_3)
					{
						TextLineList.a(this, A_0, A_1, num, i, A_6, A_7, A_8, A_9);
					}
				}
				if (A_5 && this.a[i].NewParagraph)
				{
					A_0.Write_Tm(A_1 - this.k + this.f - this.a[i].GetWidth(this.i), num);
				}
				else
				{
					A_0.Write_Tm(A_1 + this.f - this.a[i].GetWidth(this.i), num);
				}
				A_0.a(this.c, this.a[i].Start, this.a[i].Length, A_5);
				num += this.j;
				if (this.a[i].HardReturn)
				{
					if (this.u)
					{
						Tag.a((PageWriter)A_0);
					}
					num += this.l;
				}
			}
			if (this.u && !this.a[A_4 - 1].HardReturn)
			{
				Tag.a((PageWriter)A_0);
			}
		}

		// Token: 0x06002E8E RID: 11918 RVA: 0x001A6B04 File Offset: 0x001A5B04
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, bool A_6, StructureElement A_7, AttributeTypeList A_8, AttributeClassList A_9, bool A_10)
		{
			float num = A_2 + this.BaseLine;
			if (this.u)
			{
				TextLineList.a(this, A_0, A_1, num, A_3, A_7, A_8, A_9, A_10);
			}
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (this.i()[i].Length > 0)
				{
					if (this.i()[i].SpaceCount == 0 && (!this.i()[i].HardReturn || (this.i()[i].HardReturn && A_6)))
					{
						if (i < A_4 - 1 || A_6 || (i == A_4 - 1 && !this.i()[i].HardReturn && !A_6))
						{
							if (this.i()[i].NewParagraph)
							{
								A_0.SetCharacterSpacing((this.Width - this.i()[i].GetWidth(this.FontSize) - this.ParagraphIndent) / (float)(this.i()[i].Length - 1));
							}
							else
							{
								A_0.SetCharacterSpacing((this.Width - this.i()[i].GetWidth(this.FontSize)) / (float)(this.i()[i].Length - 1));
							}
						}
						else
						{
							A_0.SetCharacterSpacing(0f);
						}
					}
					else
					{
						A_0.SetCharacterSpacing(0f);
					}
					if (this.i()[i].NewParagraph)
					{
						if (this.u && i != A_3)
						{
							TextLineList.a(this, A_0, A_1, num, i, A_7, A_8, A_9, A_10);
						}
						if (A_5 && !A_6 && this.i()[i].HardReturn)
						{
							A_0.Write_Tm(A_1 + (this.Width - this.ParagraphIndent - this.i()[i].GetWidth(this.FontSize)), num);
						}
						else if (!A_5)
						{
							A_0.Write_Tm(A_1 + this.ParagraphIndent, num);
						}
						else if (A_5 && this.i()[i].Length > 1)
						{
							A_0.Write_Tm(A_1, num);
						}
						else
						{
							A_0.Write_Tm(A_1 + (this.Width - this.ParagraphIndent - this.i()[i].GetWidth(this.FontSize)), num);
						}
					}
					else if (A_5 && !A_6 && this.i()[i].HardReturn)
					{
						A_0.Write_Tm(A_1 + (this.Width - this.i()[i].GetWidth(this.FontSize)), num);
					}
					else
					{
						A_0.Write_Tm(A_1, num);
					}
					if (this.i()[i].SpaceCount == 0)
					{
						A_0.a(this.c, this.a[i].Start, this.a[i].Length, A_5);
					}
					else if (this.i()[i].HardReturn && !A_6)
					{
						A_0.a(this.c, this.a[i].Start, this.a[i].Length, A_5);
					}
					else if (this.i()[i].NewParagraph)
					{
						A_0.a(this.c, this.a[i].Start, this.a[i].Length, (this.Width - this.ParagraphIndent - this.i()[i].GetWidth(this.FontSize)) / (float)this.i()[i].SpaceCount, A_5);
					}
					else
					{
						A_0.a(this.c, this.a[i].Start, this.a[i].Length, (this.Width - this.i()[i].GetWidth(this.FontSize)) / (float)this.i()[i].SpaceCount, A_5);
					}
				}
				num += this.Leading;
				if (this.i()[i].HardReturn)
				{
					if (this.u)
					{
						Tag.a((PageWriter)A_0);
					}
					num += this.ParagraphSpacing;
				}
			}
			A_0.SetCharacterSpacing(0f);
			if (this.u && !this.a[A_4 - 1].HardReturn)
			{
				Tag.a((PageWriter)A_0);
			}
		}

		// Token: 0x06002E8F RID: 11919 RVA: 0x001A6FBC File Offset: 0x001A5FBC
		internal void a(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, int A_5, int A_6, bool A_7, float A_8, Color A_9, bool A_10, float A_11)
		{
			if (!this.u)
			{
				A_0.z();
			}
			A_0.SetGraphicsMode();
			Artifact.a((PageWriter)A_0);
			if (A_11 > 0f)
			{
				if (A_9 != null && A_4 != null)
				{
					A_0.SetStrokeColor(A_9);
					A_0.SetFillColor(A_4);
				}
				else if (A_4 != null && A_9 == null)
				{
					A_0.SetStrokeColor(A_4);
				}
				else if (A_4 == null && A_9 != null)
				{
					A_0.SetStrokeColor(A_9);
				}
			}
			else if (A_4 != null)
			{
				A_0.SetStrokeColor(A_4);
			}
			A_0.SetLineCap(LineCap.Butt);
			switch (A_3)
			{
			case TextAlign.Left:
				this.c(A_0, A_1, A_2, A_5, A_6, A_7, A_8, A_9, A_11);
				break;
			case TextAlign.Center:
				this.b(A_0, A_1, A_2, A_5, A_6, A_7, A_8, A_9, A_11);
				break;
			case TextAlign.Right:
				this.a(A_0, A_1, A_2, A_5, A_6, A_7, A_8, A_9, A_11);
				break;
			case TextAlign.Justify:
				this.a(A_0, A_1, A_2, A_5, A_6, A_7, false, A_8, A_9, A_11);
				break;
			case TextAlign.FullJustify:
				this.a(A_0, A_1, A_2, A_5, A_6, A_7, true, A_8, A_9, A_11);
				break;
			}
			if (A_9 != null && A_11 > 0f)
			{
				if (A_4 != null)
				{
					A_0.Write_B();
				}
				else
				{
					A_0.Write_S();
				}
			}
			else if ((A_9 == null || A_11 <= 0f) && A_4 != null)
			{
				A_0.Write_S();
			}
			A_0.z();
		}

		// Token: 0x06002E90 RID: 11920 RVA: 0x001A7180 File Offset: 0x001A6180
		internal bool l()
		{
			return this.u;
		}

		// Token: 0x06002E91 RID: 11921 RVA: 0x001A7198 File Offset: 0x001A6198
		internal void e(bool A_0)
		{
			this.u = A_0;
		}

		// Token: 0x06002E92 RID: 11922 RVA: 0x001A71A4 File Offset: 0x001A61A4
		public virtual void Draw(OperatorWriter writer, float x, float y, TextAlign align, Color textColor, bool underline, int startLine, int lineCount, bool rightToLeft)
		{
			this.jb(writer, x, y, align, textColor, null, 0f, underline, startLine, lineCount, rightToLeft, false);
		}

		// Token: 0x06002E93 RID: 11923 RVA: 0x001A71D0 File Offset: 0x001A61D0
		internal virtual void jb(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, Color A_5, float A_6, bool A_7, int A_8, int A_9, bool A_10, bool A_11)
		{
			this.SetLines(false);
			if (A_5 != null && A_6 > 0f)
			{
				if (A_4 != null)
				{
					A_0.SetTextRenderingMode(TextRenderingMode.FillAndStroke);
					A_0.SetStrokeColor(A_5);
					A_0.SetFillColor(A_4);
				}
				else
				{
					A_0.SetTextRenderingMode(TextRenderingMode.Stroke);
					A_0.SetStrokeColor(A_5);
				}
				A_0.SetLineWidth(A_6);
				A_0.SetLineStyle(LineStyle.Solid);
			}
			else if (A_4 != null)
			{
				A_0.SetTextRenderingMode(TextRenderingMode.Fill);
				A_0.SetFillColor(A_4);
			}
			else
			{
				A_0.SetTextRenderingMode(TextRenderingMode.Invisible);
			}
			A_0.SetTextMode();
			A_0.SetFont(this.h, this.i);
			switch (A_3)
			{
			case TextAlign.Left:
				this.d(A_0, A_1, A_2, A_8, A_9, A_10);
				break;
			case TextAlign.Center:
				this.b(A_0, A_1, A_2, A_8, A_9, A_10);
				break;
			case TextAlign.Right:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10);
				break;
			case TextAlign.Justify:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, false);
				break;
			case TextAlign.FullJustify:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, true);
				break;
			}
			if (A_7 && (A_4 != null || (A_6 > 0f && A_5 != null)))
			{
				this.a(A_0, A_4, A_5, A_6);
				this.b(A_0, A_1, this.b(A_2), A_3, A_4, A_8, A_9, A_10, this.h.d(this.i), A_5, true, A_6);
			}
			if (A_11 && (A_4 != null || (A_6 > 0f && A_5 != null)))
			{
				this.a(A_0, A_4, A_5, A_6);
				this.b(A_0, A_1, this.c(A_2), A_3, A_4, 0, this.o, A_10, this.h.a(this.i), A_5, false, A_6);
			}
		}

		// Token: 0x06002E94 RID: 11924 RVA: 0x001A73E0 File Offset: 0x001A63E0
		private void d(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5)
		{
			A_0.SetLeading(this.j);
			if (this.k != 0f && !A_5)
			{
				this.c(A_0, A_1, A_2, A_3, A_4, A_5);
			}
			else
			{
				float num = A_2 + this.m - this.j;
				A_0.Write_Tm(A_1, num);
				for (int i = A_3; i < A_3 + A_4; i++)
				{
					A_0.Write_SQuote(this.c, this.a[i].Start, this.a[i].Length, A_5);
					num += this.j;
					if (this.a[i].HardReturn)
					{
						num += this.l;
						if (this.l != 0f && i < this.a.Length)
						{
							A_0.Write_Tm(A_1, num);
						}
					}
				}
			}
		}

		// Token: 0x06002E95 RID: 11925 RVA: 0x001A74E0 File Offset: 0x001A64E0
		private void c(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5)
		{
			float num = A_2 + this.BaseLine - this.j;
			if (this.i()[A_3].NewParagraph)
			{
				A_0.Write_Tm(A_1 + this.ParagraphIndent, num);
			}
			else
			{
				A_0.Write_Tm(A_1, num);
			}
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (i != A_3)
				{
					if (this.i()[i].NewParagraph)
					{
						num += this.ParagraphSpacing;
						A_0.Write_Tm(A_1 + this.ParagraphIndent, num);
					}
					else
					{
						A_0.Write_Tm(A_1, num);
					}
				}
				if (this.i()[i].Length > 0)
				{
					A_0.Write_SQuote(this.c, this.a[i].Start, this.a[i].Length, A_5);
				}
				num += this.Leading;
			}
		}

		// Token: 0x06002E96 RID: 11926 RVA: 0x001A75E0 File Offset: 0x001A65E0
		private void b(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5)
		{
			float num = A_2 + this.m;
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (this.a[i].NewParagraph)
				{
					if (A_5)
					{
						A_0.Write_Tm(A_1 + (-this.k + this.f - this.a[i].GetWidth(this.i)) / 2f, num);
					}
					else
					{
						A_0.Write_Tm(A_1 + (this.k + this.f - this.a[i].GetWidth(this.i)) / 2f, num);
					}
				}
				else
				{
					A_0.Write_Tm(A_1 + (this.f - this.a[i].GetWidth(this.i)) / 2f, num);
				}
				A_0.Write_Tj_(this.c, this.a[i].Start, this.a[i].Length, A_5);
				num += this.j;
				if (this.a[i].HardReturn)
				{
					num += this.l;
				}
			}
		}

		// Token: 0x06002E97 RID: 11927 RVA: 0x001A771C File Offset: 0x001A671C
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5)
		{
			float num = A_2 + this.m;
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (A_5 && this.a[i].NewParagraph)
				{
					A_0.Write_Tm(A_1 - this.k + this.f - this.a[i].GetWidth(this.i), num);
				}
				else
				{
					A_0.Write_Tm(A_1 + this.f - this.a[i].GetWidth(this.i), num);
				}
				A_0.Write_Tj_(this.c, this.a[i].Start, this.a[i].Length, A_5);
				num += this.j;
				if (this.a[i].HardReturn)
				{
					num += this.l;
				}
			}
		}

		// Token: 0x06002E98 RID: 11928 RVA: 0x001A7814 File Offset: 0x001A6814
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, bool A_6)
		{
			float num = A_2 + this.BaseLine;
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (this.i()[i].Length > 0)
				{
					if (this.i()[i].SpaceCount == 0 && (!this.i()[i].HardReturn || (this.i()[i].HardReturn && A_6)))
					{
						if (this.i()[i].Length > 1)
						{
							if (i < A_4 - 1 || A_6 || (i == A_4 - 1 && !this.i()[i].HardReturn && !A_6))
							{
								if (this.i()[i].NewParagraph)
								{
									A_0.SetCharacterSpacing((this.Width - this.i()[i].GetWidth(this.FontSize) - this.ParagraphIndent) / (float)(this.i()[i].Length - 1));
								}
								else
								{
									A_0.SetCharacterSpacing((this.Width - this.i()[i].GetWidth(this.FontSize)) / (float)(this.i()[i].Length - 1));
								}
							}
							else
							{
								A_0.SetCharacterSpacing(0f);
							}
						}
					}
					else
					{
						A_0.SetCharacterSpacing(0f);
					}
					if (this.i()[i].NewParagraph)
					{
						if (A_5 && !A_6 && this.i()[i].HardReturn)
						{
							A_0.Write_Tm(A_1 + (this.Width - this.ParagraphIndent - this.i()[i].GetWidth(this.FontSize)), num);
						}
						else if (!A_5)
						{
							A_0.Write_Tm(A_1 + this.ParagraphIndent, num);
						}
						else if (A_5 && this.i()[i].Length > 1)
						{
							A_0.Write_Tm(A_1, num);
						}
						else
						{
							A_0.Write_Tm(A_1 + (this.Width - this.ParagraphIndent - this.i()[i].GetWidth(this.FontSize)), num);
						}
					}
					else if (A_5 && !A_6 && this.i()[i].HardReturn)
					{
						A_0.Write_Tm(A_1 + (this.Width - this.i()[i].GetWidth(this.FontSize)), num);
					}
					else
					{
						A_0.Write_Tm(A_1, num);
					}
					if (this.i()[i].SpaceCount == 0)
					{
						A_0.Write_Tj_(this.c, this.a[i].Start, this.a[i].Length, A_5);
					}
					else if (this.i()[i].HardReturn && !A_6)
					{
						A_0.Write_Tj_(this.c, this.a[i].Start, this.a[i].Length, A_5);
					}
					else if (this.i()[i].NewParagraph)
					{
						A_0.Write_TJ(this.c, this.a[i].Start, this.a[i].Length, (this.Width - this.ParagraphIndent - this.i()[i].GetWidth(this.FontSize)) / (float)this.i()[i].SpaceCount, A_5);
					}
					else
					{
						A_0.Write_TJ(this.c, this.a[i].Start, this.a[i].Length, (this.Width - this.i()[i].GetWidth(this.FontSize)) / (float)this.i()[i].SpaceCount, A_5);
					}
				}
				num += this.Leading;
				if (this.i()[i].HardReturn)
				{
					num += this.ParagraphSpacing;
				}
			}
			A_0.SetCharacterSpacing(0f);
		}

		// Token: 0x06002E99 RID: 11929 RVA: 0x001A7C54 File Offset: 0x001A6C54
		internal float b(float A_0)
		{
			return A_0 + this.h.GetBaseLine(this.i, this.h.GetDefaultLeading(this.i)) - this.h.c(this.i);
		}

		// Token: 0x06002E9A RID: 11930 RVA: 0x001A7C9C File Offset: 0x001A6C9C
		internal float c(float A_0)
		{
			return A_0 + this.h.GetBaseLine(this.i, this.h.GetDefaultLeading(this.i)) - this.h.b(this.i);
		}

		// Token: 0x06002E9B RID: 11931 RVA: 0x001A7CE4 File Offset: 0x001A6CE4
		internal void a(OperatorWriter A_0, Color A_1, Color A_2, float A_3)
		{
			A_0.SetGraphicsMode();
			if (A_3 > 0f)
			{
				if (A_2 != null && A_1 != null)
				{
					A_0.SetStrokeColor(A_2);
					A_0.SetFillColor(A_1);
				}
				else if (A_1 != null && A_2 == null)
				{
					A_0.SetStrokeColor(A_1);
				}
				else if (A_1 == null && A_2 != null)
				{
					A_0.SetStrokeColor(A_2);
				}
			}
			else if (A_1 != null)
			{
				A_0.SetStrokeColor(A_1);
			}
			A_0.SetLineStyle(LineStyle.Solid);
			A_0.SetLineCap(LineCap.Butt);
		}

		// Token: 0x06002E9C RID: 11932 RVA: 0x001A7D8C File Offset: 0x001A6D8C
		internal void b(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, int A_5, int A_6, bool A_7, float A_8, Color A_9, bool A_10, float A_11)
		{
			switch (A_3)
			{
			case TextAlign.Left:
				this.c(A_0, A_1, A_2, A_5, A_6, A_7, A_8, A_9, A_11);
				break;
			case TextAlign.Center:
				this.b(A_0, A_1, A_2, A_5, A_6, A_7, A_8, A_9, A_11);
				break;
			case TextAlign.Right:
				this.a(A_0, A_1, A_2, A_5, A_6, A_7, A_8, A_9, A_11);
				break;
			case TextAlign.Justify:
				this.a(A_0, A_1, A_2, A_5, A_6, A_7, false, A_8, A_9, A_11);
				break;
			case TextAlign.FullJustify:
				this.a(A_0, A_1, A_2, A_5, A_6, A_7, true, A_8, A_9, A_11);
				break;
			}
			if (A_9 != null && A_11 > 0f)
			{
				if (A_4 != null)
				{
					A_0.Write_B();
				}
				else
				{
					A_0.Write_S();
				}
			}
			else if ((A_9 == null || A_11 <= 0f) && A_4 != null)
			{
				A_0.Write_S();
			}
		}

		// Token: 0x06002E9D RID: 11933 RVA: 0x001A7E94 File Offset: 0x001A6E94
		private void c(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, float A_6, Color A_7, float A_8)
		{
			float num = A_2;
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (this.a[i].Length > 0)
				{
					if (A_7 != null && A_8 > 0f)
					{
						if (this.a[i].NewParagraph && !A_5)
						{
							A_0.Write_re(A_1 + this.k, num, this.k + this.a[i].GetWidth(this.i), A_6);
						}
						else
						{
							A_0.Write_re(A_1, num, this.a[i].GetWidth(this.i), A_6);
						}
					}
					else
					{
						A_0.SetLineWidth(A_6);
						if (this.a[i].NewParagraph && !A_5)
						{
							A_0.Write_m_(A_1 + this.k, num);
							A_0.Write_l_(A_1 + this.k + this.a[i].GetWidth(this.i), num);
						}
						else
						{
							A_0.Write_m_(A_1, num);
							A_0.Write_l_(A_1 + this.a[i].GetWidth(this.i), num);
						}
					}
				}
				num += this.j;
				if (this.a[i].HardReturn)
				{
					num += this.l;
				}
			}
		}

		// Token: 0x06002E9E RID: 11934 RVA: 0x001A8014 File Offset: 0x001A7014
		private void b(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, float A_6, Color A_7, float A_8)
		{
			float num = A_2;
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (this.a[i].Length > 0)
				{
					if (A_7 != null && A_8 > 0f)
					{
						if (this.a[i].NewParagraph)
						{
							if (A_5)
							{
								A_0.Write_re(A_1 + (-this.k + this.f - this.a[i].GetWidth(this.i)) / 2f, num, this.a[i].GetWidth(this.i), A_6);
							}
							else
							{
								A_0.Write_re(A_1 + (this.k + this.f - this.a[i].GetWidth(this.i)) / 2f, num, this.a[i].GetWidth(this.i), A_6);
							}
						}
						else
						{
							A_0.Write_re(A_1 + (this.f - this.a[i].GetWidth(this.i)) / 2f, num, this.a[i].GetWidth(this.i), A_6);
						}
					}
					else
					{
						A_0.SetLineWidth(A_6);
						if (this.a[i].NewParagraph)
						{
							if (A_5)
							{
								A_0.Write_m_(A_1 + (-this.k + this.f - this.a[i].GetWidth(this.i)) / 2f, num);
								A_0.Write_l_(A_1 + (-this.k + this.f - this.a[i].GetWidth(this.i)) / 2f + this.a[i].GetWidth(this.i), num);
							}
							else
							{
								A_0.Write_m_(A_1 + (this.k + this.f - this.a[i].GetWidth(this.i)) / 2f, num);
								A_0.Write_l_(A_1 + (this.k + this.f - this.a[i].GetWidth(this.i)) / 2f + this.a[i].GetWidth(this.i), num);
							}
						}
						else
						{
							A_0.Write_m_(A_1 + (this.f - this.a[i].GetWidth(this.i)) / 2f, num);
							A_0.Write_l_(A_1 + (this.f - this.a[i].GetWidth(this.i)) / 2f + this.a[i].GetWidth(this.i), num);
						}
					}
				}
				num += this.j;
				if (this.a[i].HardReturn)
				{
					num += this.l;
				}
			}
		}

		// Token: 0x06002E9F RID: 11935 RVA: 0x001A832C File Offset: 0x001A732C
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, float A_6, Color A_7, float A_8)
		{
			float num = A_2;
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (A_7 != null && A_8 > 0f)
				{
					if (this.a[i].Length > 0)
					{
						if (A_5 && this.a[i].NewParagraph)
						{
							A_0.Write_re(A_1 - this.k + this.f - this.a[i].GetWidth(this.i), num, this.a[i].GetWidth(this.i), A_6);
						}
						else
						{
							A_0.Write_re(A_1 + this.f - this.a[i].GetWidth(this.i), num, this.a[i].GetWidth(this.i), A_6);
						}
					}
				}
				else if (this.a[i].Length > 0)
				{
					A_0.SetLineWidth(A_6);
					if (A_5 && this.a[i].NewParagraph)
					{
						A_0.Write_m_(A_1 - this.k + this.f - this.a[i].GetWidth(this.i), num);
						A_0.Write_l_(A_1 - this.k + this.f, num);
					}
					else
					{
						A_0.Write_m_(A_1 + this.f - this.a[i].GetWidth(this.i), num);
						A_0.Write_l_(A_1 + this.f, num);
					}
				}
				num += this.j;
				if (this.a[i].HardReturn)
				{
					num += this.l;
				}
			}
		}

		// Token: 0x06002EA0 RID: 11936 RVA: 0x001A851C File Offset: 0x001A751C
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, bool A_6, float A_7, Color A_8, float A_9)
		{
			float num = A_2;
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (A_8 != null && A_9 > 0f)
				{
					if (this.i()[i].Length > 0)
					{
						if (A_5)
						{
							if (this.a[i].NewParagraph)
							{
								if (this.a[i].HardReturn && !A_6)
								{
									A_0.Write_re(A_1 - this.k + this.f - this.a[i].GetWidth(this.i), num, -this.k + this.f, A_7);
								}
								else
								{
									A_0.Write_re(A_1, num, -this.k + this.f, A_7);
								}
							}
							else if (this.a[i].HardReturn && !A_6)
							{
								A_0.Write_re(A_1 + this.f - this.a[i].GetWidth(this.i), num, this.f, A_7);
							}
							else
							{
								A_0.Write_re(A_1, num, this.f, A_7);
							}
						}
						else if (this.a[i].NewParagraph)
						{
							if (this.a[i].HardReturn && !A_6)
							{
								A_0.Write_re(A_1 + this.k, num, this.a[i].GetWidth(this.i), A_7);
							}
							else
							{
								A_0.Write_re(A_1 + this.k, num, this.f, A_7);
							}
						}
						else if (this.a[i].HardReturn && !A_6)
						{
							A_0.Write_re(A_1, num, this.a[i].GetWidth(this.i), A_7);
						}
						else
						{
							A_0.Write_re(A_1, num, this.f, A_7);
						}
					}
				}
				else if (this.i()[i].Length > 0)
				{
					A_0.SetLineWidth(A_7);
					if (A_5)
					{
						if (this.a[i].NewParagraph)
						{
							if (this.a[i].HardReturn && !A_6)
							{
								A_0.Write_m_(A_1 - this.k + this.f - this.a[i].GetWidth(this.i), num);
								A_0.Write_l_(A_1 - this.k + this.f, num);
							}
							else
							{
								A_0.Write_m_(A_1, num);
								A_0.Write_l_(A_1 - this.k + this.f, num);
							}
						}
						else if (this.a[i].HardReturn && !A_6)
						{
							A_0.Write_m_(A_1 + this.f - this.a[i].GetWidth(this.i), num);
							A_0.Write_l_(A_1 + this.f, num);
						}
						else
						{
							A_0.Write_m_(A_1, num);
							A_0.Write_l_(A_1 + this.f, num);
						}
					}
					else if (this.a[i].NewParagraph)
					{
						A_0.Write_m_(A_1 + this.k, num);
						if (this.a[i].HardReturn && !A_6)
						{
							A_0.Write_l_(A_1 + this.k + this.a[i].GetWidth(this.i), num);
						}
						else
						{
							A_0.Write_l_(A_1 + this.f, num);
						}
					}
					else
					{
						A_0.Write_m_(A_1, num);
						if (this.a[i].HardReturn && !A_6)
						{
							A_0.Write_l_(A_1 + this.a[i].GetWidth(this.i), num);
						}
						else
						{
							A_0.Write_l_(A_1 + this.f, num);
						}
					}
				}
				num += this.j;
				if (this.a[i].HardReturn)
				{
					num += this.l;
				}
			}
		}

		// Token: 0x06002EA1 RID: 11937 RVA: 0x001A898C File Offset: 0x001A798C
		internal float m()
		{
			return GlobalSettings.UseLegacyTextHeightCalculations ? this.j : (this.j - this.Font.GetLineGap(this.FontSize));
		}

		// Token: 0x04001606 RID: 5638
		private TextLine[] a = new TextLine[1];

		// Token: 0x04001607 RID: 5639
		private int b = 0;

		// Token: 0x04001608 RID: 5640
		private char[] c;

		// Token: 0x04001609 RID: 5641
		private int d;

		// Token: 0x0400160A RID: 5642
		private int e;

		// Token: 0x0400160B RID: 5643
		private float f;

		// Token: 0x0400160C RID: 5644
		private float g;

		// Token: 0x0400160D RID: 5645
		private Font h;

		// Token: 0x0400160E RID: 5646
		private float i;

		// Token: 0x0400160F RID: 5647
		private float j;

		// Token: 0x04001610 RID: 5648
		private float k = 0f;

		// Token: 0x04001611 RID: 5649
		private float l = 0f;

		// Token: 0x04001612 RID: 5650
		private float m;

		// Token: 0x04001613 RID: 5651
		private bool n;

		// Token: 0x04001614 RID: 5652
		private int o = 0;

		// Token: 0x04001615 RID: 5653
		private bool p = false;

		// Token: 0x04001616 RID: 5654
		private bool q = true;

		// Token: 0x04001617 RID: 5655
		private bool r = true;

		// Token: 0x04001618 RID: 5656
		private bool s;

		// Token: 0x04001619 RID: 5657
		private bool t = false;

		// Token: 0x0400161A RID: 5658
		private bool u = false;

		// Token: 0x0400161B RID: 5659
		private bool v = false;

		// Token: 0x02000861 RID: 2145
		protected enum LineCalculationMode
		{
			// Token: 0x04002E44 RID: 11844
			OneLine,
			// Token: 0x04002E45 RID: 11845
			ToHeight,
			// Token: 0x04002E46 RID: 11846
			All
		}
	}
}
