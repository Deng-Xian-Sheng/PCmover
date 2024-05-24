using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x0200045E RID: 1118
	internal class ac6 : TextLineList
	{
		// Token: 0x06002E20 RID: 11808 RVA: 0x001A183C File Offset: 0x001A083C
		private ac6(int A_0, float A_1, float A_2, bool A_3, TextLineList A_4) : base(A_0, A_1, A_2, A_3, A_4)
		{
		}

		// Token: 0x06002E21 RID: 11809 RVA: 0x001A1898 File Offset: 0x001A0898
		internal ac6(TextLineList A_0) : base(A_0)
		{
		}

		// Token: 0x06002E22 RID: 11810 RVA: 0x001A18F0 File Offset: 0x001A08F0
		internal override float i9(int A_0)
		{
			int length = base.i()[A_0].Length;
			int start = base.i()[A_0].Start;
			float num = 0f;
			float num2 = base.Font.a(this.TextArray, start, length, base.FontSize);
			int num3 = start + length;
			for (int i = start; i < num3 - 1; i++)
			{
				int num4 = (int)this.s[i];
				num += (float)num4;
			}
			num = num * base.FontSize / 1000f;
			return num2 - num;
		}

		// Token: 0x06002E23 RID: 11811 RVA: 0x001A1988 File Offset: 0x001A0988
		protected override char[] get_TextArray()
		{
			return base.TextArray;
		}

		// Token: 0x06002E24 RID: 11812 RVA: 0x001A19A0 File Offset: 0x001A09A0
		protected override void set_TextArray(char[] value)
		{
			base.TextArray = value;
			this.s = null;
		}

		// Token: 0x06002E25 RID: 11813 RVA: 0x001A19B4 File Offset: 0x001A09B4
		public override string GetOverflowText()
		{
			base.SetLines(false);
			string result;
			if (base.LineCount == base.VisibleLineCount)
			{
				if (this.q)
				{
					result = string.Empty;
				}
				else
				{
					result = new string(base.TextArray, this.k, base.End - this.k + 1);
				}
			}
			else
			{
				result = new string(base.TextArray, base[base.VisibleLineCount].Start, base.End - base[base.VisibleLineCount].Start + 1);
			}
			return result;
		}

		// Token: 0x06002E26 RID: 11814 RVA: 0x001A1A54 File Offset: 0x001A0A54
		public override bool HasOverflow()
		{
			base.SetLines(false);
			return base.LineCount != base.VisibleLineCount || this.e <= base.End;
		}

		// Token: 0x06002E27 RID: 11815 RVA: 0x001A1A9C File Offset: 0x001A0A9C
		public override TextLineList GetOverflow(float width, float height)
		{
			base.SetLines(false);
			TextLineList result;
			if (base.LineCount == base.VisibleLineCount)
			{
				if (this.e > base.End)
				{
					result = null;
				}
				else
				{
					result = new ac6(this.k, width, height, this.p, this)
					{
						s = this.s
					};
				}
			}
			else
			{
				result = new ac6(base[base.VisibleLineCount].Start, width, height, base[base.VisibleLineCount].NewParagraph, this)
				{
					s = this.s
				};
			}
			return result;
		}

		// Token: 0x06002E28 RID: 11816 RVA: 0x001A1B44 File Offset: 0x001A0B44
		protected override void InitializeLines(bool newParagraph)
		{
			this.p = newParagraph;
			this.k = base.Start;
			this.e = base.Start;
			float num = 1000f / base.FontSize;
			this.a = (int)(base.Width * num);
			this.b = (int)(base.ParagraphIndent * num);
			this.c = (int)base.Font.GetGlyphWidth(' ');
			this.d = (int)base.Font.GetGlyphWidth('\u3000');
			this.m = 0;
			this.o = 0f;
			if (newParagraph)
			{
				this.n = this.a - this.b;
			}
			else
			{
				this.n = this.a;
			}
			this.q = false;
			this.f = 0;
			this.g = 0;
			this.h = 0;
			this.i = 0;
			this.j = 0;
			this.l = 0;
		}

		// Token: 0x06002E29 RID: 11817 RVA: 0x001A1C34 File Offset: 0x001A0C34
		protected override bool CalculateLines(TextLineList.LineCalculationMode mode)
		{
			if (this.s == null)
			{
				this.a(this.r);
			}
			switch (mode)
			{
			case TextLineList.LineCalculationMode.OneLine:
			{
				int num = base.LineCount + 1;
				while (this.e <= base.End && base.LineCount < num)
				{
					this.d();
					this.a();
				}
				if (this.e > base.End)
				{
					this.e();
				}
				break;
			}
			case TextLineList.LineCalculationMode.ToHeight:
			{
				float num2 = base.Height - base.m() + 0.001f;
				while (this.e <= base.End && (this.o <= num2 || base.LineCount == 0))
				{
					this.d();
					this.a();
				}
				if (this.e > base.End)
				{
					this.e();
				}
				break;
			}
			case TextLineList.LineCalculationMode.All:
				while (this.e <= base.End)
				{
					this.d();
					this.a();
				}
				this.e();
				break;
			}
			return this.q;
		}

		// Token: 0x06002E2A RID: 11818 RVA: 0x001A1D80 File Offset: 0x001A0D80
		private void e()
		{
			this.l += this.i + this.g;
			this.m += this.j + this.h;
			this.g = 0;
			this.h = 0;
			if (!this.q)
			{
				this.b();
				if (base.LineCount == 0)
				{
					base.Add(new TextLine(0, 0, 0, 0f, 0, true, false, false));
				}
				base[base.LineCount - 1].HardReturn = true;
				this.q = true;
			}
		}

		// Token: 0x06002E2B RID: 11819 RVA: 0x001A1E28 File Offset: 0x001A0E28
		private void d()
		{
			bool flag = false;
			char c = this.TextArray[this.e++];
			while (c <= ' ' || c == '\u3000')
			{
				char c2 = c;
				switch (c2)
				{
				case '\t':
					goto IL_55;
				case '\n':
					if (!flag)
					{
						this.c();
						flag = false;
					}
					else
					{
						this.k++;
					}
					break;
				case '\v':
				case '\f':
					goto IL_EC;
				case '\r':
					this.c();
					flag = true;
					break;
				default:
					if (c2 == ' ')
					{
						goto IL_55;
					}
					if (c2 != '\u3000')
					{
						goto IL_EC;
					}
					this.f++;
					this.g++;
					this.h += this.d;
					flag = false;
					break;
				}
				IL_F0:
				if (this.e == base.End)
				{
					this.e++;
					break;
				}
				if (this.e <= base.End)
				{
					c = this.TextArray[this.e++];
					continue;
				}
				return;
				IL_55:
				this.f++;
				this.g++;
				this.h += this.c;
				flag = false;
				goto IL_F0;
				IL_EC:
				flag = false;
				goto IL_F0;
			}
			this.e--;
		}

		// Token: 0x06002E2C RID: 11820 RVA: 0x001A1FAC File Offset: 0x001A0FAC
		private void c()
		{
			this.l += this.i + this.g;
			this.m += this.j + this.h;
			base.Add(new TextLine(this.k, this.l, this.m, this.o, this.f, this.p, true, false));
			this.k = this.e;
			this.f = 0;
			this.g = 0;
			this.h = 0;
			this.l = 0;
			this.m = 0;
			this.n = this.a - this.b;
			this.o += base.Leading + base.ParagraphSpacing;
			this.p = true;
		}

		// Token: 0x06002E2D RID: 11821 RVA: 0x001A2084 File Offset: 0x001A1084
		private void b()
		{
			base.Add(new TextLine(this.k, this.l, this.m, this.o, this.f - this.g, this.p, false, false));
			this.k = this.e - this.i;
			this.f = 0;
			this.g = 0;
			this.h = 0;
			this.l = 0;
			this.m = 0;
			this.n = this.a;
			this.o += base.Leading;
			this.p = false;
		}

		// Token: 0x06002E2E RID: 11822 RVA: 0x001A2128 File Offset: 0x001A1128
		private void a()
		{
			if (this.e <= base.End)
			{
				char c = this.TextArray[this.e];
				while (c > ' ' && c != '\u3000')
				{
					int num;
					if (!this.r)
					{
						if (this.e - this.k > 0 && this.e < this.TextArray.Length)
						{
							num = (int)(base.Font.GetGlyphWidth(c) - this.s[this.e - 1]);
						}
						else
						{
							num = (int)base.Font.GetGlyphWidth(c);
						}
					}
					else if (this.e < this.TextArray.Length - 1)
					{
						num = (int)(base.Font.GetGlyphWidth(c) - this.s[this.e]);
					}
					else
					{
						num = (int)base.Font.GetGlyphWidth(c);
					}
					if (this.i != 0 && this.j + num > this.n)
					{
						if (this.l != 0)
						{
							this.b();
						}
						this.l = this.i;
						this.m = this.j;
						this.i = 0;
						this.j = 0;
					}
					this.e++;
					this.i++;
					this.j += num;
					if (this.e > base.End)
					{
						break;
					}
					if (this.b(c))
					{
						break;
					}
					if (this.a(c))
					{
						if (this.e == 1 && !this.b(base.TextArray[this.e]))
						{
							break;
						}
						if (this.e > 1 && !this.c(base.TextArray[this.e - 2]) && !this.b(base.TextArray[this.e]))
						{
							break;
						}
					}
					c = this.TextArray[this.e];
				}
				if (c <= ' ' || c == '\u3000')
				{
					if (!this.r)
					{
						if (c != '\n' && c != '\r')
						{
							if (this.e - this.k > 0 && this.e < this.TextArray.Length)
							{
								this.j -= (int)this.s[this.e - 1];
							}
						}
					}
					else if (this.e < this.TextArray.Length - 1)
					{
						this.j -= (int)this.s[this.e];
					}
				}
				if (this.j + this.h + this.m <= this.n)
				{
					this.l += this.i + this.g;
					this.m += this.j + this.h;
				}
				else
				{
					if (this.l > 0)
					{
						this.b();
					}
					this.l = this.i;
					this.m = this.j;
				}
				this.g = 0;
				this.i = 0;
				this.j = 0;
				this.h = 0;
			}
		}

		// Token: 0x06002E2F RID: 11823 RVA: 0x001A24D4 File Offset: 0x001A14D4
		private bool c(char A_0)
		{
			if (A_0 <= '【')
			{
				if (A_0 <= '¥')
				{
					if (A_0 <= '(')
					{
						if (A_0 == '$')
						{
							return true;
						}
						if (A_0 == '(')
						{
							return true;
						}
					}
					else
					{
						if (A_0 == '[')
						{
							return true;
						}
						if (A_0 == '{')
						{
							return true;
						}
						switch (A_0)
						{
						case '£':
							return true;
						case '¥':
							return true;
						}
					}
				}
				else if (A_0 <= '‟')
				{
					switch (A_0)
					{
					case '‘':
						return true;
					case '’':
					case '‚':
						break;
					case '‛':
						return true;
					case '“':
						return true;
					default:
						if (A_0 == '‟')
						{
							return true;
						}
						break;
					}
				}
				else
				{
					if (A_0 == '€')
					{
						return true;
					}
					if (A_0 == '№')
					{
						return true;
					}
					switch (A_0)
					{
					case '〈':
						return true;
					case '《':
						return true;
					case '「':
						return true;
					case '『':
						return true;
					case '【':
						return true;
					}
				}
			}
			else if (A_0 <= '＜')
			{
				if (A_0 <= '〝')
				{
					switch (A_0)
					{
					case '〔':
						return true;
					case '〕':
					case '〗':
					case '〙':
						break;
					case '〖':
						return true;
					case '〘':
						return true;
					case '〚':
						return true;
					default:
						if (A_0 == '〝')
						{
							return true;
						}
						break;
					}
				}
				else
				{
					if (A_0 == '＄')
					{
						return true;
					}
					if (A_0 == '（')
					{
						return true;
					}
					if (A_0 == '＜')
					{
						return true;
					}
				}
			}
			else if (A_0 <= '｟')
			{
				if (A_0 == '［')
				{
					return true;
				}
				if (A_0 == '｟')
				{
					return true;
				}
			}
			else
			{
				if (A_0 == '｢')
				{
					return true;
				}
				if (A_0 == '￡')
				{
					return true;
				}
				switch (A_0)
				{
				case '￥':
					return true;
				case '￦':
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002E30 RID: 11824 RVA: 0x001A2700 File Offset: 0x001A1700
		private bool b(char A_0)
		{
			if (A_0 <= '…')
			{
				if (A_0 <= ']')
				{
					if (A_0 <= '.')
					{
						if (A_0 == '!')
						{
							return true;
						}
						if (A_0 == '%')
						{
							return true;
						}
						switch (A_0)
						{
						case ')':
							return true;
						case ',':
							return true;
						case '-':
							return true;
						case '.':
							return true;
						}
					}
					else
					{
						switch (A_0)
						{
						case ':':
							return true;
						case ';':
							return true;
						default:
							if (A_0 == '?')
							{
								return true;
							}
							if (A_0 == ']')
							{
								return true;
							}
							break;
						}
					}
				}
				else if (A_0 <= '°')
				{
					if (A_0 == '}')
					{
						return true;
					}
					if (A_0 == '¢')
					{
						return true;
					}
					if (A_0 == '°')
					{
						return true;
					}
				}
				else
				{
					if (A_0 == '—')
					{
						return true;
					}
					switch (A_0)
					{
					case '’':
						return true;
					case '‚':
						return true;
					case '‛':
					case '“':
						break;
					case '”':
						return true;
					case '„':
						return true;
					default:
						switch (A_0)
						{
						case '․':
							return true;
						case '‥':
							return true;
						case '…':
							return true;
						}
						break;
					}
				}
			}
			else if (A_0 <= '！')
			{
				if (A_0 <= '】')
				{
					switch (A_0)
					{
					case '‰':
						return true;
					case '‱':
						return true;
					case '′':
						return true;
					case '″':
						return true;
					default:
						switch (A_0)
						{
						case '、':
							return true;
						case '。':
							return true;
						default:
							switch (A_0)
							{
							case '〉':
								return true;
							case '》':
								return true;
							case '」':
								return true;
							case '』':
								return true;
							case '】':
								return true;
							}
							break;
						}
						break;
					}
				}
				else
				{
					switch (A_0)
					{
					case '〕':
						return true;
					case '〖':
					case '〘':
					case '〚':
					case '〜':
					case '〝':
						break;
					case '〗':
						return true;
					case '〙':
						return true;
					case '〛':
						return true;
					case '〞':
						return true;
					case '〟':
						return true;
					default:
						if (A_0 == '・')
						{
							return true;
						}
						if (A_0 == '！')
						{
							return true;
						}
						break;
					}
				}
			}
			else if (A_0 <= '？')
			{
				if (A_0 == '％')
				{
					return true;
				}
				switch (A_0)
				{
				case '）':
					return true;
				case '＊':
				case '＋':
					break;
				case '，':
					return true;
				case '－':
					return true;
				case '．':
					return true;
				default:
					switch (A_0)
					{
					case '＞':
						return true;
					case '？':
						return true;
					}
					break;
				}
			}
			else
			{
				if (A_0 == '］')
				{
					return true;
				}
				switch (A_0)
				{
				case '｝':
					return true;
				case '～':
				case '｟':
				case '｢':
					break;
				case '｠':
					return true;
				case '｡':
					return true;
				case '｣':
					return true;
				case '､':
					return true;
				case '･':
					return true;
				default:
					if (A_0 == '￠')
					{
						return true;
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x06002E31 RID: 11825 RVA: 0x001A2A88 File Offset: 0x001A1A88
		private bool a(char A_0)
		{
			return A_0 >= '⺀' && (A_0 <= '힯' || (A_0 >= '豈' && A_0 <= '﫿'));
		}

		// Token: 0x06002E32 RID: 11826 RVA: 0x001A2AE4 File Offset: 0x001A1AE4
		internal override void ja(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, Color A_5, float A_6, bool A_7, bool A_8, bool A_9)
		{
			this.jb(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7, 0, base.VisibleLineCount, A_8, A_9);
		}

		// Token: 0x06002E33 RID: 11827 RVA: 0x001A2B14 File Offset: 0x001A1B14
		internal override void jb(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, Color A_5, float A_6, bool A_7, int A_8, int A_9, bool A_10, bool A_11)
		{
			this.r = A_10;
			base.SetLines(false);
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
			A_0.SetFont(base.Font, base.FontSize);
			switch (A_3)
			{
			case TextAlign.Left:
				this.c(A_0, A_1, A_2, A_8, A_9, A_10);
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
				base.a(A_0, A_4, A_5, A_6);
				base.b(A_0, A_1, base.b(A_2), A_3, A_4, A_8, A_9, A_10, base.Font.d(base.FontSize), A_5, true, A_6);
			}
			if (A_11 && (A_4 != null || (A_6 > 0f && A_5 != null)))
			{
				base.a(A_0, A_4, A_5, A_6);
				base.b(A_0, A_1, base.c(A_2), A_3, A_4, 0, base.VisibleLineCount, A_10, base.Font.a(base.FontSize), A_5, false, A_6);
			}
		}

		// Token: 0x06002E34 RID: 11828 RVA: 0x001A2D2C File Offset: 0x001A1D2C
		internal override void jc(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, Color A_5, float A_6, bool A_7, bool A_8, bool A_9, StructureElement A_10, AttributeTypeList A_11, AttributeClassList A_12)
		{
			this.a(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7, 0, base.VisibleLineCount, A_8, A_9, A_10, A_11, A_12);
		}

		// Token: 0x06002E35 RID: 11829 RVA: 0x001A2D60 File Offset: 0x001A1D60
		internal void a(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, Color A_5, float A_6, bool A_7, int A_8, int A_9, bool A_10, bool A_11, StructureElement A_12, AttributeTypeList A_13, AttributeClassList A_14)
		{
			this.r = A_10;
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
			A_0.SetFont(base.Font, base.FontSize);
			switch (A_3)
			{
			case TextAlign.Left:
				this.c(A_0, A_1, A_2, A_8, A_9, A_10, A_12, A_13, A_14);
				break;
			case TextAlign.Center:
				this.b(A_0, A_1, A_2, A_8, A_9, A_10, A_12, A_13, A_14);
				break;
			case TextAlign.Right:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, A_12, A_13, A_14);
				break;
			case TextAlign.Justify:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, false, A_12, A_13, A_14);
				break;
			case TextAlign.FullJustify:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, true, A_12, A_13, A_14);
				break;
			}
			if (A_7 && (A_4 != null || (A_6 > 0f && A_5 != null)))
			{
				base.a(A_0, A_4, A_5, A_6);
				base.a(A_0, A_1, base.b(A_2), A_3, A_4, A_8, A_9, A_10, base.Font.d(base.FontSize), A_5, true, A_6);
				flag = true;
			}
			if (A_11 && (A_4 != null || (A_6 > 0f && A_5 != null)))
			{
				base.a(A_0, A_4, A_5, A_6);
				base.a(A_0, A_1, base.c(A_2), A_3, A_4, 0, base.VisibleLineCount, A_10, base.Font.a(base.FontSize), A_5, false, A_6);
				flag = true;
			}
			if (!flag)
			{
				A_0.z();
				A_0.Write_ET();
			}
		}

		// Token: 0x06002E36 RID: 11830 RVA: 0x001A2FA8 File Offset: 0x001A1FA8
		private void c(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, StructureElement A_6, AttributeTypeList A_7, AttributeClassList A_8)
		{
			A_0.SetLeading(base.Leading);
			if (base.ParagraphIndent != 0f && !A_5)
			{
				this.a(A_0, A_1, A_2, A_3, A_4, A_6, A_7, A_8);
			}
			else
			{
				float num = A_2 + base.BaseLine;
				for (int i = A_3; i < A_3 + A_4; i++)
				{
					A_0.Write_Tm(A_1, num);
					if (base.i()[i].Length > 0)
					{
						if (base.l() && (base.i()[i].NewParagraph || i == A_3))
						{
							TextLineList.a(this, A_0, A_1, num, i, A_6, A_7, A_8, false);
						}
						this.a(A_0, i);
					}
					num += base.Leading;
					if (base.i()[i].HardReturn)
					{
						if (base.l())
						{
							Tag.a((PageWriter)A_0);
						}
						num += base.ParagraphSpacing;
						if (base.ParagraphSpacing != 0f && i < base.i().Length)
						{
							A_0.Write_Tm(A_1, num);
						}
					}
				}
				if (base.l() && !base.i()[A_4 - 1].HardReturn)
				{
					Tag.a((PageWriter)A_0);
				}
			}
		}

		// Token: 0x06002E37 RID: 11831 RVA: 0x001A3120 File Offset: 0x001A2120
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, StructureElement A_5, AttributeTypeList A_6, AttributeClassList A_7)
		{
			float num = A_2 + base.BaseLine;
			if (base.l())
			{
				TextLineList.a(this, A_0, A_1, num, A_3, A_5, A_6, A_7, false);
			}
			if (base.i()[A_3].NewParagraph)
			{
				A_0.Write_Tm(A_1 + base.ParagraphIndent, num);
			}
			else
			{
				A_0.Write_Tm(A_1, num);
			}
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (i != A_3)
				{
					if (base.i()[i].NewParagraph)
					{
						num += base.ParagraphSpacing;
						if (base.l())
						{
							Tag.a((PageWriter)A_0);
							TextLineList.a(this, A_0, A_1, num, i, A_5, A_6, A_7, false);
						}
						A_0.Write_Tm(A_1 + base.ParagraphIndent, num);
					}
					else
					{
						A_0.Write_Tm(A_1, num);
					}
				}
				if (base.i()[i].Length > 0)
				{
					this.a(A_0, i);
				}
				num += base.Leading;
			}
			if (base.l())
			{
				Tag.a((PageWriter)A_0);
			}
		}

		// Token: 0x06002E38 RID: 11832 RVA: 0x001A3260 File Offset: 0x001A2260
		private void b(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, StructureElement A_6, AttributeTypeList A_7, AttributeClassList A_8)
		{
			float num = A_2 + base.BaseLine;
			if (base.l())
			{
				TextLineList.a(this, A_0, A_1, num, A_3, A_6, A_7, A_8, false);
			}
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (base.i()[i].NewParagraph)
				{
					if (base.l() && i != A_3)
					{
						TextLineList.a(this, A_0, A_1, num, i, A_6, A_7, A_8, false);
					}
					if (A_5)
					{
						A_0.Write_Tm(A_1 + (-base.ParagraphIndent + base.Width - base.i()[i].GetWidth(base.FontSize)) / 2f, num);
					}
					else
					{
						A_0.Write_Tm(A_1 + (base.ParagraphIndent + base.Width - base.i()[i].GetWidth(base.FontSize)) / 2f, num);
					}
				}
				else
				{
					A_0.Write_Tm(A_1 + (base.Width - base.i()[i].GetWidth(base.FontSize)) / 2f, num);
				}
				if (base.i()[i].Length > 0)
				{
					this.a(A_0, i);
				}
				num += base.Leading;
				if (base.i()[i].HardReturn)
				{
					if (base.l())
					{
						Tag.a((PageWriter)A_0);
					}
					num += base.ParagraphSpacing;
				}
			}
			if (base.l() && !base.i()[A_4 - 1].HardReturn)
			{
				Tag.a((PageWriter)A_0);
			}
		}

		// Token: 0x06002E39 RID: 11833 RVA: 0x001A3428 File Offset: 0x001A2428
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, StructureElement A_6, AttributeTypeList A_7, AttributeClassList A_8)
		{
			float num = A_2 + base.BaseLine;
			if (base.l())
			{
				TextLineList.a(this, A_0, A_1, num, A_3, A_6, A_7, A_8, false);
			}
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (base.i()[i].NewParagraph)
				{
					if (base.l() && i != A_3)
					{
						TextLineList.a(this, A_0, A_1, num, i, A_6, A_7, A_8, false);
					}
				}
				if (A_5 && base.i()[i].NewParagraph)
				{
					A_0.Write_Tm(A_1 - base.ParagraphIndent + base.Width - base.i()[i].GetWidth(base.FontSize), num);
				}
				else
				{
					A_0.Write_Tm(A_1 + base.Width - base.i()[i].GetWidth(base.FontSize), num);
				}
				if (base.i()[i].Length > 0)
				{
					this.a(A_0, i);
				}
				num += base.Leading;
				if (base.i()[i].HardReturn)
				{
					if (base.l())
					{
						Tag.a((PageWriter)A_0);
					}
					num += base.ParagraphSpacing;
				}
			}
			if (base.l() && !base.i()[A_4 - 1].HardReturn)
			{
				Tag.a((PageWriter)A_0);
			}
		}

		// Token: 0x06002E3A RID: 11834 RVA: 0x001A35BC File Offset: 0x001A25BC
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, bool A_6, StructureElement A_7, AttributeTypeList A_8, AttributeClassList A_9)
		{
			float num = A_2 + base.BaseLine;
			if (base.l())
			{
				TextLineList.a(this, A_0, A_1, num, A_3, A_7, A_8, A_9, false);
			}
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (base.i()[i].Length > 0)
				{
					if (base.i()[i].SpaceCount == 0 && (!base.i()[i].HardReturn || (base.i()[i].HardReturn && A_6)))
					{
						if (i < A_4 - 1 || A_6 || (i == A_4 - 1 && !base.i()[i].HardReturn && !A_6))
						{
							if (base.i()[i].NewParagraph)
							{
								A_0.SetCharacterSpacing((base.Width - base.i()[i].GetWidth(base.FontSize) - base.ParagraphIndent) / (float)(base.i()[i].Length - 1));
							}
							else
							{
								A_0.SetCharacterSpacing((base.Width - base.i()[i].GetWidth(base.FontSize)) / (float)(base.i()[i].Length - 1));
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
					if (base.i()[i].NewParagraph)
					{
						if (base.l() && i != A_3)
						{
							TextLineList.a(this, A_0, A_1, num, i, A_7, A_8, A_9, false);
						}
						if (A_5 && !A_6 && base.i()[i].HardReturn)
						{
							A_0.Write_Tm(A_1 + (base.Width - base.ParagraphIndent - base.i()[i].GetWidth(base.FontSize)), num);
						}
						else if (!A_5)
						{
							A_0.Write_Tm(A_1 + base.ParagraphIndent, num);
						}
						else if (A_5 && base.i()[i].Length > 1)
						{
							A_0.Write_Tm(A_1, num);
						}
						else
						{
							A_0.Write_Tm(A_1 + (base.Width - base.ParagraphIndent - base.i()[i].GetWidth(base.FontSize)), num);
						}
					}
					else if (A_5 && !A_6 && base.i()[i].HardReturn)
					{
						A_0.Write_Tm(A_1 + (base.Width - base.i()[i].GetWidth(base.FontSize)), num);
					}
					else
					{
						A_0.Write_Tm(A_1, num);
					}
					if (base.i()[i].SpaceCount == 0)
					{
						this.a(A_0, i, 0f);
					}
					else if (base.i()[i].HardReturn && !A_6)
					{
						this.a(A_0, i, 0f);
					}
					else if (base.i()[i].NewParagraph)
					{
						this.a(A_0, i, (base.Width - base.ParagraphIndent - base.i()[i].GetWidth(base.FontSize)) / (float)base.i()[i].SpaceCount);
					}
					else
					{
						this.a(A_0, i, (base.Width - base.i()[i].GetWidth(base.FontSize)) / (float)base.i()[i].SpaceCount);
					}
				}
				num += base.Leading;
				if (base.i()[i].HardReturn)
				{
					if (base.l())
					{
						Tag.a((PageWriter)A_0);
					}
					num += base.ParagraphSpacing;
				}
			}
			A_0.SetCharacterSpacing(0f);
			if (base.l() && !base.i()[A_4 - 1].HardReturn)
			{
				Tag.a((PageWriter)A_0);
			}
		}

		// Token: 0x06002E3B RID: 11835 RVA: 0x001A39FC File Offset: 0x001A29FC
		public KerningValues a(bool A_0)
		{
			this.r = A_0;
			if (this.s == null)
			{
				this.s = new short[base.TextArray.Length - 1];
				if (A_0)
				{
					for (int i = base.TextArray.Length - 2; i >= 0; i--)
					{
						this.s[i] = (short)base.Font.GetKernValue(base.TextArray[i + 1], base.TextArray[i]);
					}
				}
				else
				{
					for (int i = 1; i < this.TextArray.Length; i++)
					{
						this.s[i - 1] = (short)base.Font.GetKernValue(base.TextArray[i - 1], base.TextArray[i]);
					}
				}
			}
			return new KerningValues(base.TextArray, this.s);
		}

		// Token: 0x06002E3C RID: 11836 RVA: 0x001A3AE4 File Offset: 0x001A2AE4
		private void c(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5)
		{
			A_0.SetLeading(base.Leading);
			if (base.ParagraphIndent != 0f && !A_5)
			{
				this.a(A_0, A_1, A_2, A_3, A_4);
			}
			else
			{
				float num = A_2 + base.BaseLine;
				for (int i = A_3; i < A_3 + A_4; i++)
				{
					A_0.Write_Tm(A_1, num);
					if (base.i()[i].Length > 0)
					{
						this.b(A_0, i);
					}
					num += base.Leading;
					if (base.i()[i].HardReturn)
					{
						num += base.ParagraphSpacing;
						if (base.ParagraphSpacing != 0f && i < base.i().Length)
						{
							A_0.Write_Tm(A_1, num);
						}
					}
				}
			}
		}

		// Token: 0x06002E3D RID: 11837 RVA: 0x001A3BD0 File Offset: 0x001A2BD0
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4)
		{
			float num = A_2 + base.BaseLine;
			if (base.i()[A_3].NewParagraph)
			{
				A_0.Write_Tm(A_1 + base.ParagraphIndent, num);
			}
			else
			{
				A_0.Write_Tm(A_1, num);
			}
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (i != A_3)
				{
					if (base.i()[i].NewParagraph)
					{
						num += base.ParagraphSpacing;
						A_0.Write_Tm(A_1 + base.ParagraphIndent, num);
					}
					else
					{
						A_0.Write_Tm(A_1, num);
					}
				}
				if (base.i()[i].Length > 0)
				{
					this.b(A_0, i);
				}
				num += base.Leading;
			}
		}

		// Token: 0x06002E3E RID: 11838 RVA: 0x001A3CA8 File Offset: 0x001A2CA8
		private void b(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5)
		{
			float num = A_2 + base.BaseLine;
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (base.i()[i].NewParagraph)
				{
					if (A_5)
					{
						A_0.Write_Tm(A_1 + (-base.ParagraphIndent + base.Width - base.i()[i].GetWidth(base.FontSize)) / 2f, num);
					}
					else
					{
						A_0.Write_Tm(A_1 + (base.ParagraphIndent + base.Width - base.i()[i].GetWidth(base.FontSize)) / 2f, num);
					}
				}
				else
				{
					A_0.Write_Tm(A_1 + (base.Width - base.i()[i].GetWidth(base.FontSize)) / 2f, num);
				}
				if (base.i()[i].Length > 0)
				{
					this.b(A_0, i);
				}
				num += base.Leading;
				if (base.i()[i].HardReturn)
				{
					num += base.ParagraphSpacing;
				}
			}
		}

		// Token: 0x06002E3F RID: 11839 RVA: 0x001A3DDC File Offset: 0x001A2DDC
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5)
		{
			float num = A_2 + base.BaseLine;
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (A_5 && base.i()[i].NewParagraph)
				{
					A_0.Write_Tm(A_1 - base.ParagraphIndent + base.Width - base.i()[i].GetWidth(base.FontSize), num);
				}
				else
				{
					A_0.Write_Tm(A_1 + base.Width - base.i()[i].GetWidth(base.FontSize), num);
				}
				if (base.i()[i].Length > 0)
				{
					this.b(A_0, i);
				}
				num += base.Leading;
				if (base.i()[i].HardReturn)
				{
					num += base.ParagraphSpacing;
				}
			}
		}

		// Token: 0x06002E40 RID: 11840 RVA: 0x001A3ECC File Offset: 0x001A2ECC
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, bool A_6)
		{
			float num = A_2 + base.BaseLine;
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (base.i()[i].Length > 0)
				{
					if (base.i()[i].SpaceCount == 0 && (!base.i()[i].HardReturn || (base.i()[i].HardReturn && A_6)))
					{
						if (i < A_4 - 1 || A_6 || (i == A_4 - 1 && !base.i()[i].HardReturn && !A_6))
						{
							if (base.i()[i].NewParagraph)
							{
								A_0.SetCharacterSpacing((base.Width - base.i()[i].GetWidth(base.FontSize) - base.ParagraphIndent) / (float)(base.i()[i].Length - 1));
							}
							else
							{
								A_0.SetCharacterSpacing((base.Width - base.i()[i].GetWidth(base.FontSize)) / (float)(base.i()[i].Length - 1));
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
					if (base.i()[i].NewParagraph)
					{
						if (A_5 && !A_6 && base.i()[i].HardReturn)
						{
							A_0.Write_Tm(A_1 + (base.Width - base.ParagraphIndent - base.i()[i].GetWidth(base.FontSize)), num);
						}
						else if (!A_5)
						{
							A_0.Write_Tm(A_1 + base.ParagraphIndent, num);
						}
						else if (A_5 && base.i()[i].Length > 1)
						{
							A_0.Write_Tm(A_1, num);
						}
						else
						{
							A_0.Write_Tm(A_1 + (base.Width - base.ParagraphIndent - base.i()[i].GetWidth(base.FontSize)), num);
						}
					}
					else if (A_5 && !A_6 && base.i()[i].HardReturn)
					{
						A_0.Write_Tm(A_1 + (base.Width - base.i()[i].GetWidth(base.FontSize)), num);
					}
					else
					{
						A_0.Write_Tm(A_1, num);
					}
					if (base.i()[i].SpaceCount == 0)
					{
						this.b(A_0, i, 0f);
					}
					else if (base.i()[i].HardReturn && !A_6)
					{
						this.b(A_0, i, 0f);
					}
					else if (base.i()[i].NewParagraph)
					{
						this.b(A_0, i, (base.Width - base.ParagraphIndent - base.i()[i].GetWidth(base.FontSize)) / (float)base.i()[i].SpaceCount);
					}
					else
					{
						this.b(A_0, i, (base.Width - base.i()[i].GetWidth(base.FontSize)) / (float)base.i()[i].SpaceCount);
					}
				}
				num += base.Leading;
				if (base.i()[i].HardReturn)
				{
					num += base.ParagraphSpacing;
				}
			}
			A_0.SetCharacterSpacing(0f);
		}

		// Token: 0x06002E41 RID: 11841 RVA: 0x001A427C File Offset: 0x001A327C
		private void b(OperatorWriter A_0, int A_1)
		{
			int num = 0;
			int num2 = -1;
			A_0.Write_TJ_Open();
			if (!this.r)
			{
				int num3 = base.i()[A_1].Start + base.i()[A_1].Length;
				for (int i = base.i()[A_1].Start; i < num3 - 1; i++)
				{
					int num4 = (int)this.s[i];
					if (num2 == -1)
					{
						num2 = i;
					}
					num++;
					if (num4 != 0)
					{
						if (num > 0)
						{
							A_0.Write_TJ_Text(this.TextArray, num2, num, this.r);
							num2 = -1;
							num = 0;
						}
						if (this.TextArray[i] == ' ')
						{
							A_0.Write_TJ_SpaceLength(num4);
						}
						else
						{
							A_0.Write_TJ_SpaceLength(num4);
						}
					}
				}
				num++;
				if (num2 == -1)
				{
					num2 = num3 - 1;
				}
			}
			else
			{
				int num3 = base.i()[A_1].Start + base.i()[A_1].Length - 1;
				for (int i = num3; i >= base.i()[A_1].Start + 1; i--)
				{
					int num4 = (int)this.s[i - 1];
					if (num2 == -1)
					{
						num2 = i;
					}
					num++;
					if (num4 != 0)
					{
						if (num > 0)
						{
							A_0.Write_TJ_Text(this.TextArray, num2 - (num - 1), num, this.r);
							num2 = -1;
							num = 0;
						}
						A_0.Write_TJ_SpaceLength(num4);
					}
				}
				num++;
				if (num2 == -1)
				{
					num2 = base.i()[A_1].Start;
				}
			}
			if (num > 0)
			{
				int startIndex = this.r ? (num2 - (num - 1)) : num2;
				A_0.Write_TJ_Text(this.TextArray, startIndex, num, this.r);
			}
			A_0.Write_TJ_Close();
		}

		// Token: 0x06002E42 RID: 11842 RVA: 0x001A4498 File Offset: 0x001A3498
		private void a(OperatorWriter A_0, int A_1)
		{
			int num = 0;
			int num2 = -1;
			A_0.Write_TJ_Open();
			if (!this.r)
			{
				int num3 = base.i()[A_1].Start + base.i()[A_1].Length;
				if (this.TextArray.Length > num3 && this.TextArray[num3] == ' ')
				{
					num3++;
				}
				for (int i = base.i()[A_1].Start; i < num3 - 1; i++)
				{
					int num4 = (int)this.s[i];
					if (num2 == -1)
					{
						num2 = i;
					}
					num++;
					if (num4 != 0)
					{
						if (num > 0)
						{
							A_0.Write_TJ_Text(this.TextArray, num2, num, this.r);
							num2 = -1;
							num = 0;
						}
						if (this.TextArray[i] == ' ')
						{
							A_0.Write_TJ_SpaceLength(num4);
						}
						else
						{
							A_0.Write_TJ_SpaceLength(num4);
						}
					}
				}
				num++;
				if (num2 == -1)
				{
					num2 = num3 - 1;
				}
			}
			else
			{
				int num3 = base.i()[A_1].Start + base.i()[A_1].Length - 1;
				if (this.TextArray.Length > num3 && this.TextArray[num3] == ' ')
				{
					num3++;
				}
				for (int i = num3; i >= base.i()[A_1].Start + 1; i--)
				{
					int num4 = (int)this.s[i - 1];
					if (num2 == -1)
					{
						num2 = i;
					}
					num++;
					if (num4 != 0)
					{
						if (num > 0)
						{
							A_0.Write_TJ_Text(this.TextArray, num2 - (num - 1), num, this.r);
							num2 = -1;
							num = 0;
						}
						A_0.Write_TJ_SpaceLength(num4);
					}
				}
				num++;
				if (num2 == -1)
				{
					num2 = base.i()[A_1].Start;
				}
			}
			if (num > 0)
			{
				int startIndex = this.r ? (num2 - (num - 1)) : num2;
				A_0.Write_TJ_Text(this.TextArray, startIndex, num, this.r);
			}
			A_0.Write_TJ_Close();
		}

		// Token: 0x06002E43 RID: 11843 RVA: 0x001A4704 File Offset: 0x001A3704
		private void b(OperatorWriter A_0, int A_1, float A_2)
		{
			int num = 0;
			int num2 = -1;
			int num3 = (int)(-A_2 * 1000f / base.FontSize);
			A_0.Write_TJ_Open();
			if (!this.r)
			{
				int num4 = base.i()[A_1].Start + base.i()[A_1].Length;
				for (int i = base.i()[A_1].Start; i < num4 - 1; i++)
				{
					int num5 = (int)this.s[i];
					if (this.TextArray[i] == ' ')
					{
						num5 += num3;
					}
					if (num2 == -1)
					{
						num2 = i;
					}
					num++;
					if (num5 != 0)
					{
						if (num > 0)
						{
							A_0.Write_TJ_Text(this.TextArray, num2, num, this.r);
							num2 = -1;
							num = 0;
						}
						A_0.Write_TJ_SpaceLength(num5);
					}
				}
				num++;
				if (num2 == -1)
				{
					num2 = num4 - 1;
				}
			}
			else
			{
				int num4 = base.i()[A_1].Start + base.i()[A_1].Length - 1;
				for (int i = num4; i >= base.i()[A_1].Start + 1; i--)
				{
					int num5 = (int)this.s[i - 1];
					if (this.TextArray[i] == ' ')
					{
						num5 += num3;
					}
					if (num2 == -1)
					{
						num2 = i;
					}
					num++;
					if (num5 != 0)
					{
						if (num > 0)
						{
							A_0.Write_TJ_Text(this.TextArray, num2 - (num - 1), num, this.r);
							num2 = -1;
							num = 0;
						}
						A_0.Write_TJ_SpaceLength(num5);
					}
				}
				num++;
				if (num2 == -1)
				{
					num2 = base.i()[A_1].Start;
				}
			}
			if (num > 0)
			{
				A_0.Write_TJ_Text(this.TextArray, this.r ? (num2 - (num - 1)) : num2, num, this.r);
			}
			A_0.Write_TJ_Close();
		}

		// Token: 0x06002E44 RID: 11844 RVA: 0x001A4948 File Offset: 0x001A3948
		private void a(OperatorWriter A_0, int A_1, float A_2)
		{
			int num = 0;
			int num2 = -1;
			int num3 = (int)(-A_2 * 1000f / base.FontSize);
			A_0.Write_TJ_Open();
			if (!this.r)
			{
				int num4 = base.i()[A_1].Start + base.i()[A_1].Length;
				if (this.TextArray.Length > num4 && this.TextArray[num4] == ' ')
				{
					num4++;
				}
				for (int i = base.i()[A_1].Start; i < num4 - 1; i++)
				{
					int num5 = (int)this.s[i];
					if (this.TextArray[i] == ' ')
					{
						num5 += num3;
					}
					if (num2 == -1)
					{
						num2 = i;
					}
					num++;
					if (num5 != 0)
					{
						if (num > 0)
						{
							A_0.Write_TJ_Text(this.TextArray, num2, num, this.r);
							num2 = -1;
							num = 0;
						}
						A_0.Write_TJ_SpaceLength(num5);
					}
				}
				num++;
				if (num2 == -1)
				{
					num2 = num4 - 1;
				}
			}
			else
			{
				int num4 = base.i()[A_1].Start + base.i()[A_1].Length - 1;
				if (this.TextArray.Length > num4 && this.TextArray[num4] == ' ')
				{
					num4++;
				}
				for (int i = num4; i >= base.i()[A_1].Start + 1; i--)
				{
					int num5 = (int)this.s[i - 1];
					if (this.TextArray[i] == ' ')
					{
						num5 += num3;
					}
					if (num2 == -1)
					{
						num2 = i;
					}
					num++;
					if (num5 != 0)
					{
						if (num > 0)
						{
							A_0.Write_TJ_Text(this.TextArray, num2 - (num - 1), num, this.r);
							num2 = -1;
							num = 0;
						}
						A_0.Write_TJ_SpaceLength(num5);
					}
				}
				num++;
				if (num2 == -1)
				{
					num2 = base.i()[A_1].Start;
				}
			}
			if (num > 0)
			{
				A_0.Write_TJ_Text(this.TextArray, this.r ? (num2 - (num - 1)) : num2, num, this.r);
			}
			A_0.Write_TJ_Close();
		}

		// Token: 0x040015F3 RID: 5619
		private new int a;

		// Token: 0x040015F4 RID: 5620
		private new int b;

		// Token: 0x040015F5 RID: 5621
		private new int c;

		// Token: 0x040015F6 RID: 5622
		private int d;

		// Token: 0x040015F7 RID: 5623
		private int e = 0;

		// Token: 0x040015F8 RID: 5624
		private int f = 0;

		// Token: 0x040015F9 RID: 5625
		private new int g = 0;

		// Token: 0x040015FA RID: 5626
		private int h = 0;

		// Token: 0x040015FB RID: 5627
		private int i = 0;

		// Token: 0x040015FC RID: 5628
		private new int j = 0;

		// Token: 0x040015FD RID: 5629
		private new int k = 0;

		// Token: 0x040015FE RID: 5630
		private int l = 0;

		// Token: 0x040015FF RID: 5631
		private int m;

		// Token: 0x04001600 RID: 5632
		private int n;

		// Token: 0x04001601 RID: 5633
		private float o;

		// Token: 0x04001602 RID: 5634
		private bool p;

		// Token: 0x04001603 RID: 5635
		private bool q;

		// Token: 0x04001604 RID: 5636
		private bool r = false;

		// Token: 0x04001605 RID: 5637
		private short[] s;
	}
}
