using System;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000873 RID: 2163
	public class UniversalTextLineList : TextLineList
	{
		// Token: 0x060057CA RID: 22474 RVA: 0x00330614 File Offset: 0x0032F614
		public UniversalTextLineList(char[] text, int start, int length, float width, float height, Font font, float fontSize) : base(text, start, length, width, height, font, fontSize, UniversalTextLineList.r)
		{
		}

		// Token: 0x060057CB RID: 22475 RVA: 0x00330674 File Offset: 0x0032F674
		internal UniversalTextLineList(char[] A_0, int A_1, int A_2, float A_3, float A_4, Font A_5, float A_6, float A_7) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, UniversalTextLineList.r, A_7)
		{
		}

		// Token: 0x060057CC RID: 22476 RVA: 0x003306D4 File Offset: 0x0032F6D4
		private UniversalTextLineList(int A_0, float A_1, float A_2, bool A_3, TextLineList A_4) : base(A_0, A_1, A_2, A_3, A_4)
		{
		}

		// Token: 0x060057CD RID: 22477 RVA: 0x0033072C File Offset: 0x0032F72C
		internal UniversalTextLineList(TextLineList A_0) : base(A_0)
		{
		}

		// Token: 0x060057CE RID: 22478 RVA: 0x0033077C File Offset: 0x0032F77C
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

		// Token: 0x060057CF RID: 22479 RVA: 0x0033081C File Offset: 0x0032F81C
		public override bool HasOverflow()
		{
			base.SetLines(false);
			return base.LineCount != base.VisibleLineCount || this.e <= base.End;
		}

		// Token: 0x060057D0 RID: 22480 RVA: 0x00330864 File Offset: 0x0032F864
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
					result = new UniversalTextLineList(this.k, width, height, this.p, this);
				}
			}
			else
			{
				result = new UniversalTextLineList(base[base.VisibleLineCount].Start, width, height, base[base.VisibleLineCount].NewParagraph, this);
			}
			return result;
		}

		// Token: 0x060057D1 RID: 22481 RVA: 0x003308F0 File Offset: 0x0032F8F0
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

		// Token: 0x060057D2 RID: 22482 RVA: 0x003309E0 File Offset: 0x0032F9E0
		protected override bool CalculateLines(TextLineList.LineCalculationMode mode)
		{
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

		// Token: 0x060057D3 RID: 22483 RVA: 0x00330B18 File Offset: 0x0032FB18
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

		// Token: 0x060057D4 RID: 22484 RVA: 0x00330BC0 File Offset: 0x0032FBC0
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

		// Token: 0x060057D5 RID: 22485 RVA: 0x00330D44 File Offset: 0x0032FD44
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

		// Token: 0x060057D6 RID: 22486 RVA: 0x00330E1C File Offset: 0x0032FE1C
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

		// Token: 0x060057D7 RID: 22487 RVA: 0x00330EC0 File Offset: 0x0032FEC0
		private void a()
		{
			if (this.e <= base.End)
			{
				char c = this.TextArray[this.e];
				while (c > ' ' && c != '\u3000')
				{
					int glyphWidth = (int)base.Font.GetGlyphWidth(c);
					if (this.i != 0 && this.j + glyphWidth > this.n)
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
					this.j += glyphWidth;
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

		// Token: 0x060057D8 RID: 22488 RVA: 0x00331108 File Offset: 0x00330108
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

		// Token: 0x060057D9 RID: 22489 RVA: 0x00331334 File Offset: 0x00330334
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

		// Token: 0x060057DA RID: 22490 RVA: 0x003316BC File Offset: 0x003306BC
		private bool a(char A_0)
		{
			return A_0 >= '⺀' && (A_0 <= '힯' || (A_0 >= '豈' && A_0 <= '﫿'));
		}

		// Token: 0x04002E9E RID: 11934
		private new int a;

		// Token: 0x04002E9F RID: 11935
		private new int b;

		// Token: 0x04002EA0 RID: 11936
		private new int c;

		// Token: 0x04002EA1 RID: 11937
		private int d;

		// Token: 0x04002EA2 RID: 11938
		private int e = 0;

		// Token: 0x04002EA3 RID: 11939
		private int f = 0;

		// Token: 0x04002EA4 RID: 11940
		private new int g = 0;

		// Token: 0x04002EA5 RID: 11941
		private int h = 0;

		// Token: 0x04002EA6 RID: 11942
		private int i = 0;

		// Token: 0x04002EA7 RID: 11943
		private new int j = 0;

		// Token: 0x04002EA8 RID: 11944
		private new int k = 0;

		// Token: 0x04002EA9 RID: 11945
		private int l = 0;

		// Token: 0x04002EAA RID: 11946
		private int m;

		// Token: 0x04002EAB RID: 11947
		private int n;

		// Token: 0x04002EAC RID: 11948
		private float o;

		// Token: 0x04002EAD RID: 11949
		private bool p;

		// Token: 0x04002EAE RID: 11950
		private bool q;

		// Token: 0x04002EAF RID: 11951
		private static bool r = true;
	}
}
