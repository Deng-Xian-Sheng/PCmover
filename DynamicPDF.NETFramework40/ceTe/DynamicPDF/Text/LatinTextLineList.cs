using System;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000865 RID: 2149
	public class LatinTextLineList : TextLineList
	{
		// Token: 0x06005704 RID: 22276 RVA: 0x002EB548 File Offset: 0x002EA548
		public LatinTextLineList(char[] text, int start, int length, float width, float height, Font font, float fontSize) : base(text, start, length, width, height, font, fontSize, LatinTextLineList.q)
		{
		}

		// Token: 0x06005705 RID: 22277 RVA: 0x002EB5A8 File Offset: 0x002EA5A8
		internal LatinTextLineList(char[] A_0, int A_1, int A_2, float A_3, float A_4, Font A_5, float A_6, float A_7) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, LatinTextLineList.q, A_7)
		{
		}

		// Token: 0x06005706 RID: 22278 RVA: 0x002EB608 File Offset: 0x002EA608
		private LatinTextLineList(int A_0, float A_1, float A_2, bool A_3, TextLineList A_4) : base(A_0, A_1, A_2, A_3, A_4)
		{
		}

		// Token: 0x06005707 RID: 22279 RVA: 0x002EB660 File Offset: 0x002EA660
		internal LatinTextLineList(TextLineList A_0) : base(A_0)
		{
		}

		// Token: 0x06005708 RID: 22280 RVA: 0x002EB6B0 File Offset: 0x002EA6B0
		public override string GetOverflowText()
		{
			base.SetLines(false);
			string result;
			if (base.LineCount == base.VisibleLineCount)
			{
				if (this.p)
				{
					result = string.Empty;
				}
				else
				{
					result = new string(base.TextArray, this.j, base.End - this.j + 1);
				}
			}
			else
			{
				result = new string(base.TextArray, base[base.VisibleLineCount].Start, base.End - base[base.VisibleLineCount].Start + 1);
			}
			return result;
		}

		// Token: 0x06005709 RID: 22281 RVA: 0x002EB750 File Offset: 0x002EA750
		public override bool HasOverflow()
		{
			base.SetLines(false);
			return base.LineCount != base.VisibleLineCount || this.d <= base.End;
		}

		// Token: 0x0600570A RID: 22282 RVA: 0x002EB798 File Offset: 0x002EA798
		public override TextLineList GetOverflow(float width, float height)
		{
			base.SetLines(false);
			TextLineList result;
			if (base.LineCount == base.VisibleLineCount)
			{
				if (this.d > base.End)
				{
					result = null;
				}
				else
				{
					result = new LatinTextLineList(this.j, width, height, this.o, this);
				}
			}
			else
			{
				result = new LatinTextLineList(base[base.VisibleLineCount].Start, width, height, base[base.VisibleLineCount].NewParagraph, this);
			}
			return result;
		}

		// Token: 0x0600570B RID: 22283 RVA: 0x002EB824 File Offset: 0x002EA824
		protected override void InitializeLines(bool newParagraph)
		{
			this.o = newParagraph;
			this.j = base.Start;
			this.d = base.Start;
			float num = 1000f / base.FontSize;
			this.a = (int)(base.Width * num);
			this.b = (int)(base.ParagraphIndent * num);
			this.c = (int)base.Font.GetGlyphWidth(' ');
			this.l = 0;
			this.n = 0f;
			if (newParagraph)
			{
				this.m = this.a - this.b;
			}
			else
			{
				this.m = this.a;
			}
			this.p = false;
			this.e = 0;
			this.f = 0;
			this.g = 0;
			this.h = 0;
			this.i = 0;
			this.k = 0;
		}

		// Token: 0x0600570C RID: 22284 RVA: 0x002EB8FC File Offset: 0x002EA8FC
		protected override bool CalculateLines(TextLineList.LineCalculationMode mode)
		{
			switch (mode)
			{
			case TextLineList.LineCalculationMode.OneLine:
			{
				int num = base.LineCount + 1;
				while (this.d <= base.End && base.LineCount < num)
				{
					this.d();
					this.a();
				}
				if (this.d > base.End)
				{
					this.e();
				}
				break;
			}
			case TextLineList.LineCalculationMode.ToHeight:
			{
				float num2 = base.Height - base.m() + 0.001f;
				while (this.d <= base.End && (this.n <= num2 || base.LineCount == 0))
				{
					this.d();
					this.a();
				}
				if (this.d > base.End)
				{
					this.e();
				}
				break;
			}
			case TextLineList.LineCalculationMode.All:
				while (this.d <= base.End)
				{
					this.d();
					this.a();
				}
				this.e();
				break;
			}
			return this.p;
		}

		// Token: 0x0600570D RID: 22285 RVA: 0x002EBA34 File Offset: 0x002EAA34
		private void e()
		{
			this.k += this.h + this.f;
			this.l += this.i + this.g;
			this.f = 0;
			this.g = 0;
			if (!this.p)
			{
				this.b();
				if (base.LineCount == 0)
				{
					base.Add(new TextLine(0, 0, 0, 0f, 0, true, false, false));
				}
				base[base.LineCount - 1].HardReturn = true;
				this.p = true;
			}
		}

		// Token: 0x0600570E RID: 22286 RVA: 0x002EBADC File Offset: 0x002EAADC
		private void d()
		{
			bool flag = false;
			char c = this.TextArray[this.d++];
			while (c <= ' ')
			{
				char c2 = c;
				switch (c2)
				{
				case '\t':
					goto IL_4A;
				case '\n':
					if (!flag)
					{
						this.c();
						flag = false;
					}
					else
					{
						this.j++;
					}
					break;
				case '\v':
				case '\f':
					goto IL_AE;
				case '\r':
					this.c();
					flag = true;
					break;
				default:
					if (c2 != ' ')
					{
						goto IL_AE;
					}
					goto IL_4A;
				}
				IL_B2:
				if (this.d == base.End)
				{
					this.d++;
					break;
				}
				if (this.d <= base.End)
				{
					c = this.TextArray[this.d++];
					continue;
				}
				return;
				IL_4A:
				this.e++;
				this.f++;
				this.g += this.c;
				flag = false;
				goto IL_B2;
				IL_AE:
				flag = false;
				goto IL_B2;
			}
			this.d--;
		}

		// Token: 0x0600570F RID: 22287 RVA: 0x002EBC18 File Offset: 0x002EAC18
		private void c()
		{
			this.k += this.h + this.f;
			this.l += this.i + this.g;
			base.Add(new TextLine(this.j, this.k, this.l, this.n, this.e, this.o, true, false));
			this.j = this.d;
			this.e = 0;
			this.f = 0;
			this.g = 0;
			this.k = 0;
			this.l = 0;
			this.m = this.a - this.b;
			this.n += base.Leading + base.ParagraphSpacing;
			this.o = true;
		}

		// Token: 0x06005710 RID: 22288 RVA: 0x002EBCF0 File Offset: 0x002EACF0
		private void b()
		{
			base.Add(new TextLine(this.j, this.k, this.l, this.n, this.e - this.f, this.o, false, false));
			this.j = this.d - this.h;
			this.e = 0;
			this.f = 0;
			this.g = 0;
			this.k = 0;
			this.l = 0;
			this.m = this.a;
			this.n += base.Leading;
			this.o = false;
		}

		// Token: 0x06005711 RID: 22289 RVA: 0x002EBD94 File Offset: 0x002EAD94
		private void a()
		{
			if (this.d <= base.End)
			{
				for (char c = this.TextArray[this.d]; c > ' '; c = this.TextArray[this.d])
				{
					int glyphWidth = (int)base.Font.GetGlyphWidth(c);
					if (this.h != 0 && this.i + glyphWidth + this.g > this.m)
					{
						if (this.k != 0)
						{
							this.b();
						}
						this.k = this.h + this.f;
						this.l = this.i + this.g;
						this.h = 0;
						this.i = 0;
						this.f = 0;
						this.g = 0;
					}
					this.d++;
					this.h++;
					this.i += glyphWidth;
					if (c == '-')
					{
						break;
					}
					if (this.d > base.End)
					{
						break;
					}
				}
				if (this.i + this.g + this.l <= this.m)
				{
					this.k += this.h + this.f;
					this.l += this.i + this.g;
				}
				else
				{
					if (this.k > 0)
					{
						this.b();
					}
					this.k = this.h;
					this.l = this.i;
				}
				this.f = 0;
				this.h = 0;
				this.i = 0;
				this.g = 0;
			}
		}

		// Token: 0x04002E4C RID: 11852
		private new int a;

		// Token: 0x04002E4D RID: 11853
		private new int b;

		// Token: 0x04002E4E RID: 11854
		private new int c;

		// Token: 0x04002E4F RID: 11855
		private int d = 0;

		// Token: 0x04002E50 RID: 11856
		private int e = 0;

		// Token: 0x04002E51 RID: 11857
		private int f = 0;

		// Token: 0x04002E52 RID: 11858
		private new int g = 0;

		// Token: 0x04002E53 RID: 11859
		private int h = 0;

		// Token: 0x04002E54 RID: 11860
		private int i = 0;

		// Token: 0x04002E55 RID: 11861
		private new int j = 0;

		// Token: 0x04002E56 RID: 11862
		private new int k = 0;

		// Token: 0x04002E57 RID: 11863
		private int l;

		// Token: 0x04002E58 RID: 11864
		private int m;

		// Token: 0x04002E59 RID: 11865
		private float n;

		// Token: 0x04002E5A RID: 11866
		private bool o;

		// Token: 0x04002E5B RID: 11867
		private bool p;

		// Token: 0x04002E5C RID: 11868
		private static bool q = true;
	}
}
