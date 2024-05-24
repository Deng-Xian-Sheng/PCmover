using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000733 RID: 1843
	public class ListItem : IListProperties
	{
		// Token: 0x060049C9 RID: 18889 RVA: 0x0025BB64 File Offset: 0x0025AB64
		internal ListItem(float A_0, float A_1, IListProperties A_2, string A_3)
		{
			this.t = A_2;
			this.i = A_1;
			this.al = A_1;
			this.o = A_2.BulletAlign;
			this.a = A_2.Font;
			this.b = A_2.FontSize;
			this.l = A_2.Leading;
			this.n = A_2.LeftIndent;
			this.r = A_2.ParagraphIndent;
			this.m = A_2.RightIndent;
			this.s = A_2.TextAlign;
			this.d = A_2.TextColor;
			this.e = A_2.TextOutlineColor;
			this.f = A_2.TextOutlineWidth;
			this.u = A_2.StrikeThrough;
			this.p = A_2.Level;
			this.k = A_2.RightToLeft;
			this.v = A_2.ListItemTopMargin;
			this.w = A_2.ListItemBottomMargin;
			this.x = A_2.BulletSize;
			this.z = A_2.BulletSuffix;
			this.y = A_2.BulletPrefix;
			this.aa = A_2.BulletType;
			this.q = A_2.BulletAreaWidth;
			this.h = A_0 - this.m - this.n;
			this.g = this.a.GetTextLines(A_3.ToCharArray(), this.h, this.i, this.b);
			this.g.Leading = this.l;
			this.g.ParagraphIndent = this.r;
		}

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x060049CA RID: 18890 RVA: 0x0025BD54 File Offset: 0x0025AD54
		// (set) Token: 0x060049CB RID: 18891 RVA: 0x0025BD6C File Offset: 0x0025AD6C
		public Font Font
		{
			get
			{
				return this.a;
			}
			set
			{
				this.g.Font = value;
				if (value is OpenTypeFont && ((OpenTypeFont)value).UseCharacterShaping)
				{
					this.g = value.a(this.g);
				}
				this.a = value;
			}
		}

		// Token: 0x060049CC RID: 18892 RVA: 0x0025BDC0 File Offset: 0x0025ADC0
		Font IListProperties.a()
		{
			return this.a;
		}

		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x060049CD RID: 18893 RVA: 0x0025BDD8 File Offset: 0x0025ADD8
		// (set) Token: 0x060049CE RID: 18894 RVA: 0x0025BDF0 File Offset: 0x0025ADF0
		public float FontSize
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
				this.g.FontSize = value;
				this.g.Leading = this.a.GetDefaultLeading(value);
				this.Leading = this.a.GetDefaultLeading(value);
			}
		}

		// Token: 0x060049CF RID: 18895 RVA: 0x0025BE40 File Offset: 0x0025AE40
		float IListProperties.b()
		{
			return this.b;
		}

		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x060049D1 RID: 18897 RVA: 0x0025BE64 File Offset: 0x0025AE64
		// (set) Token: 0x060049D0 RID: 18896 RVA: 0x0025BE58 File Offset: 0x0025AE58
		public bool RightToLeft
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

		// Token: 0x060049D2 RID: 18898 RVA: 0x0025BE7C File Offset: 0x0025AE7C
		bool IListProperties.c()
		{
			return this.k;
		}

		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x060049D3 RID: 18899 RVA: 0x0025BE94 File Offset: 0x0025AE94
		// (set) Token: 0x060049D4 RID: 18900 RVA: 0x0025BEAC File Offset: 0x0025AEAC
		public bool Underline
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

		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x060049D5 RID: 18901 RVA: 0x0025BEB8 File Offset: 0x0025AEB8
		// (set) Token: 0x060049D6 RID: 18902 RVA: 0x0025BED0 File Offset: 0x0025AED0
		public bool StrikeThrough
		{
			get
			{
				return this.u;
			}
			set
			{
				this.u = value;
			}
		}

		// Token: 0x060049D7 RID: 18903 RVA: 0x0025BEDC File Offset: 0x0025AEDC
		bool IListProperties.d()
		{
			return this.u;
		}

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x060049D8 RID: 18904 RVA: 0x0025BEF4 File Offset: 0x0025AEF4
		// (set) Token: 0x060049D9 RID: 18905 RVA: 0x0025BF0C File Offset: 0x0025AF0C
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

		// Token: 0x060049DA RID: 18906 RVA: 0x0025BF18 File Offset: 0x0025AF18
		Color IListProperties.e()
		{
			return this.d;
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060049DB RID: 18907 RVA: 0x0025BF30 File Offset: 0x0025AF30
		// (set) Token: 0x060049DC RID: 18908 RVA: 0x0025BF48 File Offset: 0x0025AF48
		public Color TextOutlineColor
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

		// Token: 0x060049DD RID: 18909 RVA: 0x0025BF54 File Offset: 0x0025AF54
		Color IListProperties.f()
		{
			return this.e;
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x060049DE RID: 18910 RVA: 0x0025BF6C File Offset: 0x0025AF6C
		// (set) Token: 0x060049DF RID: 18911 RVA: 0x0025BF84 File Offset: 0x0025AF84
		public float TextOutlineWidth
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

		// Token: 0x060049E0 RID: 18912 RVA: 0x0025BF90 File Offset: 0x0025AF90
		float IListProperties.g()
		{
			return this.TextOutlineWidth;
		}

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x060049E1 RID: 18913 RVA: 0x0025BFA8 File Offset: 0x0025AFA8
		// (set) Token: 0x060049E2 RID: 18914 RVA: 0x0025BFC5 File Offset: 0x0025AFC5
		public string Text
		{
			get
			{
				return this.g.GetText();
			}
			set
			{
				this.g.SetText(value);
			}
		}

		// Token: 0x060049E3 RID: 18915 RVA: 0x0025BFD8 File Offset: 0x0025AFD8
		internal float h()
		{
			return this.h;
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x060049E4 RID: 18916 RVA: 0x0025BFF0 File Offset: 0x0025AFF0
		// (set) Token: 0x060049E5 RID: 18917 RVA: 0x0025C008 File Offset: 0x0025B008
		public float Leading
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
				this.g.Leading = value;
			}
		}

		// Token: 0x060049E6 RID: 18918 RVA: 0x0025C020 File Offset: 0x0025B020
		float IListProperties.i()
		{
			return this.l;
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x060049E7 RID: 18919 RVA: 0x0025C038 File Offset: 0x0025B038
		// (set) Token: 0x060049E8 RID: 18920 RVA: 0x0025C050 File Offset: 0x0025B050
		public float RightIndent
		{
			get
			{
				return this.m;
			}
			set
			{
				float num = value - this.m;
				if (num < 0f)
				{
					num *= -1f;
					this.g.Width = this.g.Width + num;
				}
				else
				{
					this.g.Width = this.g.Width - num;
				}
				this.m = value;
			}
		}

		// Token: 0x060049E9 RID: 18921 RVA: 0x0025C0BC File Offset: 0x0025B0BC
		float IListProperties.j()
		{
			return this.m;
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x060049EA RID: 18922 RVA: 0x0025C0D4 File Offset: 0x0025B0D4
		// (set) Token: 0x060049EB RID: 18923 RVA: 0x0025C0EC File Offset: 0x0025B0EC
		public float LeftIndent
		{
			get
			{
				return this.n;
			}
			set
			{
				float num = value - this.n;
				if (num < 0f)
				{
					num *= -1f;
					this.g.Width = this.g.Width + num;
				}
				else
				{
					this.g.Width = this.g.Width - num;
				}
				this.n = value;
			}
		}

		// Token: 0x060049EC RID: 18924 RVA: 0x0025C158 File Offset: 0x0025B158
		float IListProperties.k()
		{
			return this.n;
		}

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x060049ED RID: 18925 RVA: 0x0025C170 File Offset: 0x0025B170
		// (set) Token: 0x060049EE RID: 18926 RVA: 0x0025C188 File Offset: 0x0025B188
		public Align BulletAlign
		{
			get
			{
				return this.o;
			}
			set
			{
				this.o = value;
			}
		}

		// Token: 0x060049EF RID: 18927 RVA: 0x0025C194 File Offset: 0x0025B194
		Align IListProperties.l()
		{
			return this.o;
		}

		// Token: 0x060049F0 RID: 18928 RVA: 0x0025C1AC File Offset: 0x0025B1AC
		int IListProperties.m()
		{
			return this.p;
		}

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x060049F1 RID: 18929 RVA: 0x0025C1C4 File Offset: 0x0025B1C4
		// (set) Token: 0x060049F2 RID: 18930 RVA: 0x0025C1DC File Offset: 0x0025B1DC
		public float BulletAreaWidth
		{
			get
			{
				return this.q;
			}
			set
			{
				this.q = value;
			}
		}

		// Token: 0x060049F3 RID: 18931 RVA: 0x0025C1E8 File Offset: 0x0025B1E8
		float IListProperties.n()
		{
			return this.q;
		}

		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x060049F4 RID: 18932 RVA: 0x0025C200 File Offset: 0x0025B200
		// (set) Token: 0x060049F5 RID: 18933 RVA: 0x0025C218 File Offset: 0x0025B218
		public TextAlign TextAlign
		{
			get
			{
				return this.s;
			}
			set
			{
				this.s = value;
			}
		}

		// Token: 0x060049F6 RID: 18934 RVA: 0x0025C224 File Offset: 0x0025B224
		TextAlign IListProperties.o()
		{
			return this.s;
		}

		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x060049F7 RID: 18935 RVA: 0x0025C23C File Offset: 0x0025B23C
		// (set) Token: 0x060049F8 RID: 18936 RVA: 0x0025C254 File Offset: 0x0025B254
		public float BulletSize
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = value;
			}
		}

		// Token: 0x060049F9 RID: 18937 RVA: 0x0025C260 File Offset: 0x0025B260
		float IListProperties.p()
		{
			return this.x;
		}

		// Token: 0x060049FA RID: 18938 RVA: 0x0025C278 File Offset: 0x0025B278
		float IListProperties.q()
		{
			return this.w;
		}

		// Token: 0x060049FB RID: 18939 RVA: 0x0025C290 File Offset: 0x0025B290
		internal void a(bool A_0)
		{
			this.ao = A_0;
		}

		// Token: 0x060049FC RID: 18940 RVA: 0x0025C29C File Offset: 0x0025B29C
		internal bool r()
		{
			return this.ao;
		}

		// Token: 0x060049FD RID: 18941 RVA: 0x0025C2B4 File Offset: 0x0025B2B4
		internal float s()
		{
			return this.w;
		}

		// Token: 0x060049FE RID: 18942 RVA: 0x0025C2CC File Offset: 0x0025B2CC
		float IListProperties.t()
		{
			return this.v;
		}

		// Token: 0x060049FF RID: 18943 RVA: 0x0025C2E4 File Offset: 0x0025B2E4
		internal float u()
		{
			return this.v;
		}

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x06004A00 RID: 18944 RVA: 0x0025C2FC File Offset: 0x0025B2FC
		// (set) Token: 0x06004A01 RID: 18945 RVA: 0x0025C314 File Offset: 0x0025B314
		public float ParagraphIndent
		{
			get
			{
				return this.r;
			}
			set
			{
				this.r = value;
				this.g.ParagraphIndent = value;
			}
		}

		// Token: 0x06004A02 RID: 18946 RVA: 0x0025C32C File Offset: 0x0025B32C
		float IListProperties.v()
		{
			return this.r;
		}

		// Token: 0x06004A03 RID: 18947 RVA: 0x0025C344 File Offset: 0x0025B344
		string IListProperties.w()
		{
			return this.y;
		}

		// Token: 0x06004A04 RID: 18948 RVA: 0x0025C35C File Offset: 0x0025B35C
		string IListProperties.x()
		{
			return this.z;
		}

		// Token: 0x06004A05 RID: 18949 RVA: 0x0025C374 File Offset: 0x0025B374
		NumberingStyle IListProperties.y()
		{
			return this.aa;
		}

		// Token: 0x06004A06 RID: 18950 RVA: 0x0025C38C File Offset: 0x0025B38C
		internal float a(ae7 A_0)
		{
			this.an = 0;
			float num = 0f;
			int num2 = 0;
			if (A_0 != null)
			{
				if (A_0.a() - 2 == A_0.b())
				{
					object obj = A_0.e();
					if (obj != null)
					{
						num2 = (int)obj;
					}
					if (!GlobalSettings.UseLegacyTextHeightCalculations && !this.ao)
					{
						if (num2 > 0)
						{
							num = num + this.g.GetRequiredHeight(num2) + this.w + this.a.GetLineGap(this.b);
						}
						else
						{
							num = num + this.g.GetRequiredHeight(num2) + this.w + this.v + this.a.GetLineGap(this.b);
						}
					}
					else if (num2 > 0)
					{
						num = num + this.g.GetRequiredHeight(num2) + this.w;
					}
					else
					{
						num = num + this.g.GetRequiredHeight(num2) + this.w + this.v;
					}
					this.an += this.g.Count - num2;
					if (this.j != null && this.j.Count > 0)
					{
						num += this.j.a(A_0);
						this.an += this.j.c();
					}
				}
				else if (A_0.b() < A_0.a() - 2)
				{
					num = this.j.a(A_0);
					this.an += this.j.c();
				}
				else if (A_0.b() == A_0.a() - 1)
				{
					if (!GlobalSettings.UseLegacyTextHeightCalculations && !this.ao)
					{
						num = num + this.g.GetRequiredHeight(num2) + this.w + this.v + this.a.GetLineGap(this.b);
					}
					else
					{
						num = num + this.g.GetRequiredHeight(num2) + this.w + this.v;
					}
					this.an += this.g.Count - num2;
					if (this.j != null && this.j.Count > 0)
					{
						num += this.j.a(A_0);
						this.an += this.j.c();
					}
				}
			}
			else
			{
				if (!GlobalSettings.UseLegacyTextHeightCalculations && !this.ao)
				{
					num = num + this.g.GetRequiredHeight(num2) + this.w + this.v + this.a.GetLineGap(this.b);
				}
				else
				{
					num = num + this.g.GetRequiredHeight(num2) + this.w + this.v;
				}
				this.an += this.g.Count - num2;
				if (this.j != null && this.j.Count > 0)
				{
					num += this.j.a(A_0);
					this.an += this.j.c();
				}
			}
			return num;
		}

		// Token: 0x06004A07 RID: 18951 RVA: 0x0025C72C File Offset: 0x0025B72C
		internal float z()
		{
			return this.g.GetRequiredHeight(0);
		}

		// Token: 0x06004A08 RID: 18952 RVA: 0x0025C754 File Offset: 0x0025B754
		internal int aa()
		{
			return this.g.Count;
		}

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x06004A09 RID: 18953 RVA: 0x0025C774 File Offset: 0x0025B774
		public SubListList SubLists
		{
			get
			{
				SubListList result;
				if (this.j == null)
				{
					if (this.k)
					{
						result = (this.j = new SubListList(this.h + this.n, this.i, this, this.k));
					}
					else
					{
						result = (this.j = new SubListList(this.h + this.m, this.i, this, this.k));
					}
				}
				else
				{
					result = this.j;
				}
				return result;
			}
		}

		// Token: 0x06004A0A RID: 18954 RVA: 0x0025C800 File Offset: 0x0025B800
		internal float ab()
		{
			return this.al;
		}

		// Token: 0x06004A0B RID: 18955 RVA: 0x0025C818 File Offset: 0x0025B818
		internal void a(float A_0)
		{
			this.al = A_0;
		}

		// Token: 0x06004A0C RID: 18956 RVA: 0x0025C824 File Offset: 0x0025B824
		internal ae7 ac()
		{
			return this.am;
		}

		// Token: 0x06004A0D RID: 18957 RVA: 0x0025C83C File Offset: 0x0025B83C
		internal int ad()
		{
			return this.an;
		}

		// Token: 0x06004A0E RID: 18958 RVA: 0x0025C854 File Offset: 0x0025B854
		internal ListItem ae()
		{
			ListItem result;
			if (this.j == null)
			{
				result = this;
			}
			else
			{
				result = this.j.a();
			}
			return result;
		}

		// Token: 0x06004A0F RID: 18959 RVA: 0x0025C888 File Offset: 0x0025B888
		internal float a(PageWriter A_0, float A_1, float A_2, float A_3, ae7 A_4)
		{
			AttributeTypeList a_ = null;
			AttributeClassList a_2 = null;
			bool flag = false;
			if (A_0.Document.Tag != null)
			{
				if (this.ListItemTag.g())
				{
					((StructureElement)this.ListItemTag).a(A_0, this, A_1 + this.n, A_2, A_0.Document.j(), true, false);
					DocumentWriter documentWriter = A_0.DocumentWriter;
					documentWriter.i(documentWriter.ae() + 1);
					this.g.g();
					if (this.g.l())
					{
						((StructureElement)this.BodyTag).a(A_0, this, A_1 + this.n, A_2, A_0.Document.j(), false, false);
						a_ = ((StructureElement)this.BodyTag).s();
						a_2 = ((StructureElement)this.BodyTag).t();
					}
				}
			}
			if (A_4 != null)
			{
				if (A_4.b() == A_4.a() - 1)
				{
					float num;
					if (!GlobalSettings.UseLegacyTextHeightCalculations && !this.ao)
					{
						num = this.g.GetRequiredHeight(0) + this.w + this.v + this.a.GetLineGap(this.b);
					}
					else
					{
						num = this.g.GetRequiredHeight(0) + this.w + this.v;
					}
					if (num < A_3)
					{
						A_2 += this.v;
						if (A_0.Document.Tag != null)
						{
							if (!this.g.l() || !this.BodyTag.g())
							{
								this.BodyTag.f(A_0, this, A_1 + this.n, A_2);
								this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
								flag = true;
							}
							else
							{
								this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
							}
						}
						else
						{
							this.g.jb(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u);
						}
						if (flag || (A_0.Document.Tag != null && !this.g.l() && !this.StrikeThrough && !this.Underline))
						{
							Tag.a(A_0);
						}
						A_3 -= num;
						A_2 = A_2 + num - this.v;
						if (this.j != null)
						{
							this.j.a(this.al);
							A_2 = this.j.a(A_0, A_1, A_2, A_3, A_4);
						}
					}
					else
					{
						A_2 += this.v;
						A_3 -= this.v;
						int num2 = this.g.GetLineCount(0, A_3);
						if (num2 == this.g.Count)
						{
							num2--;
						}
						if (A_0.Document.Tag != null)
						{
							if (!this.g.l() || !this.BodyTag.g())
							{
								this.BodyTag.f(A_0, this, A_1 + this.n, A_2);
								this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, num2, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
								flag = true;
							}
							else
							{
								this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
							}
						}
						else
						{
							this.g.jb(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, num2, this.k, this.u);
						}
						if (flag || (A_0.Document.Tag != null && !this.g.l() && !this.StrikeThrough && !this.Underline))
						{
							Tag.a(A_0);
						}
					}
				}
				else if (A_4.a() - 2 == A_4.b())
				{
					int num3 = 0;
					object obj = A_4.e();
					if (obj != null)
					{
						num3 = (int)obj;
					}
					if (num3 == 0)
					{
						float num;
						if (!GlobalSettings.UseLegacyTextHeightCalculations && !this.ao)
						{
							num = this.g.GetRequiredHeight(num3) + this.w + this.v + this.a.GetLineGap(this.b);
						}
						else
						{
							num = this.g.GetRequiredHeight(num3) + this.w + this.v;
						}
						if (num < A_3 || (this.i == this.ab() && num3 == this.g.Count - 1))
						{
							A_2 += this.v;
							if (A_0.Document.Tag != null)
							{
								if (!this.g.l() || !this.BodyTag.g())
								{
									this.BodyTag.f(A_0, this, A_1 + this.n, A_2);
									this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
									flag = true;
								}
								else
								{
									this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
								}
							}
							else
							{
								this.g.jb(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u);
							}
							if (flag || (A_0.Document.Tag != null && !this.g.l() && !this.StrikeThrough && !this.Underline))
							{
								Tag.a(A_0);
							}
							A_3 -= num;
							A_2 = A_2 + num - this.v;
							if (this.j != null && this.j.Count > 0)
							{
								this.j.a(this.al);
								A_2 = this.j.a(A_0, A_1, A_2, A_3, A_4);
							}
						}
						else
						{
							A_2 += this.v;
							A_3 -= this.v;
							int num2 = this.g.GetLineCount(0, A_3);
							if (num2 == this.g.Count)
							{
								num2--;
							}
							if (A_0.Document.Tag != null)
							{
								if (!this.g.l() || !this.BodyTag.g())
								{
									this.BodyTag.f(A_0, this, A_1 + this.n, A_2);
									this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, num2, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
									flag = true;
								}
								else
								{
									this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
								}
							}
							else
							{
								this.g.jb(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, num2, this.k, this.u);
							}
							if (flag || (A_0.Document.Tag != null && !this.g.l() && !this.StrikeThrough && !this.Underline))
							{
								Tag.a(A_0);
							}
						}
					}
					else
					{
						float num;
						if (!GlobalSettings.UseLegacyTextHeightCalculations && !this.ao)
						{
							num = this.g.GetRequiredHeight(num3) + this.w + this.a.GetLineGap(this.b);
						}
						else
						{
							num = this.g.GetRequiredHeight(num3) + this.w;
						}
						if (num < A_3 || (this.al == A_3 && num3 == this.g.Count - 1))
						{
							if (A_0.Document.Tag != null)
							{
								if (!this.g.l() || !this.BodyTag.g())
								{
									this.BodyTag.f(A_0, this, A_1 + this.n, A_2);
									this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, num3, this.g.Count - num3, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
									flag = true;
								}
								else
								{
									this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
								}
							}
							else
							{
								this.g.jb(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, num3, this.g.Count - num3, this.k, this.u);
							}
							if (flag || (A_0.Document.Tag != null && !this.g.l() && !this.StrikeThrough && !this.Underline))
							{
								Tag.a(A_0);
							}
							A_3 -= num;
							A_2 += num;
							if (this.j != null && this.j.Count > 0)
							{
								this.j.a(this.al);
								A_2 = this.j.a(A_0, A_1, A_2, A_3, A_4);
							}
						}
						else
						{
							int num2 = this.g.GetLineCount(num3, A_3);
							if (num2 + num3 == this.g.Count)
							{
								num2--;
							}
							if (A_0.Document.Tag != null)
							{
								if (!this.g.l() || !this.BodyTag.g())
								{
									this.BodyTag.f(A_0, this, A_1 + this.n, A_2);
									this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, num3, num2, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
									flag = true;
								}
								else
								{
									this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
								}
							}
							else
							{
								this.g.jb(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, num3, num2, this.k, this.u);
							}
							if (flag || (A_0.Document.Tag != null && !this.g.l() && !this.StrikeThrough && !this.Underline))
							{
								Tag.a(A_0);
							}
						}
					}
				}
				else if (A_4.b() < A_4.a() - 2)
				{
					this.j.a(this.al);
					A_2 = this.j.a(A_0, A_1, A_2, A_3, A_4);
				}
			}
			else
			{
				float num;
				if (!GlobalSettings.UseLegacyTextHeightCalculations && !this.ao)
				{
					num = this.g.GetRequiredHeight(0) + this.w + this.v + this.a.GetLineGap(this.b);
				}
				else
				{
					num = this.g.GetRequiredHeight(0) + this.w + this.v;
				}
				if (num < A_3 || (this.al == A_3 && this.g.Count == 1))
				{
					A_2 += this.v;
					if (A_0.Document.Tag != null)
					{
						if (!this.g.l() || !this.BodyTag.g())
						{
							this.BodyTag.f(A_0, this, A_1 + this.n, A_2);
							this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
							flag = true;
						}
						else
						{
							this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
						}
					}
					else
					{
						this.g.jb(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u);
					}
					if (flag || (A_0.Document.Tag != null && !this.g.l() && !this.StrikeThrough && !this.Underline))
					{
						Tag.a(A_0);
					}
					A_3 -= num;
					A_2 = A_2 + num - this.v;
					if (this.j != null && this.j.Count > 0)
					{
						this.j.a(this.al);
						A_2 = this.j.a(A_0, A_1, A_2, A_3, A_4);
					}
				}
				else
				{
					A_2 += this.v;
					A_3 -= this.v;
					int num2 = this.g.GetLineCount(0, A_3);
					if (num2 == this.g.Count)
					{
						num2--;
					}
					if (A_0.Document.Tag != null)
					{
						if (!this.g.l() || !this.BodyTag.g())
						{
							this.BodyTag.f(A_0, this, A_1 + this.n, A_2);
							this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, num2, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
							flag = true;
						}
						else
						{
							this.g.k2(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, this.g.Count, this.k, this.u, (StructureElement)this.BodyTag, a_, a_2, true);
						}
					}
					else
					{
						this.g.jb(A_0, A_1 + this.n, A_2, this.s, this.d, this.e, this.f, this.c, 0, num2, this.k, this.u);
					}
					if (flag || (A_0.Document.Tag != null && !this.g.l() && !this.StrikeThrough && !this.Underline))
					{
						Tag.a(A_0);
					}
				}
			}
			return A_2;
		}

		// Token: 0x06004A10 RID: 18960 RVA: 0x0025DBF0 File Offset: 0x0025CBF0
		internal void a(ae7 A_0, ae7 A_1, float A_2)
		{
			this.am = A_1;
			bool flag = false;
			if (A_0 != null)
			{
				if (A_0.b() == A_0.a() - 1)
				{
					float num = this.g.GetRequiredHeight(0) + this.w + this.v;
					if ((this.aa() > 1 && this.Leading + this.v > A_2) || (this.aa() == 1 && this.Leading + this.v + this.w > A_2))
					{
						A_1.a(0);
						return;
					}
					if (num < A_2)
					{
						A_2 -= num;
						if (this.j != null)
						{
							this.j.a(A_0, A_1, A_2);
							flag = true;
						}
					}
					else
					{
						A_2 -= this.v;
						int num2 = this.g.GetLineCount(0, A_2);
						if (num2 == this.g.Count)
						{
							num2--;
						}
						A_1.a(num2);
					}
				}
				else if (A_0.a() - 2 == A_0.b())
				{
					object obj = A_0.e();
					int num3 = (int)obj;
					if (num3 == 0)
					{
						if (((this.aa() > 1 && this.Leading + this.v > A_2) || (this.aa() == 1 && this.Leading + this.v + this.w > A_2)) && A_1.a() > A_0.a())
						{
							A_1.a(0);
							return;
						}
						float num = this.g.GetRequiredHeight(num3) + this.w + this.v;
						if (num < A_2 || (this.al == A_2 && (this.g.Count == 1 || num3 == this.g.Count - 1)))
						{
							A_2 -= num;
							if (this.j != null)
							{
								this.j.a(A_0, A_1, A_2);
								flag = true;
							}
						}
						else
						{
							A_2 -= this.v;
							int num2 = this.g.GetLineCount(0, A_2);
							if (num2 == this.g.Count)
							{
								num2--;
							}
							A_1.a(num2);
						}
					}
					else
					{
						if (this.Leading > A_2 && this.al > A_2)
						{
							A_1.a(num3);
							return;
						}
						float num = this.g.GetRequiredHeight(num3) + this.w;
						if (num < A_2 || (this.al == A_2 && (this.g.Count == 1 || num3 == this.g.Count - 1)))
						{
							A_2 -= num;
							if (this.j != null)
							{
								this.j.a(A_0, A_1, A_2);
								flag = true;
							}
						}
						else
						{
							int num2 = this.g.GetLineCount(num3, A_2);
							if (num2 + num3 == this.g.Count)
							{
								num2--;
							}
							A_1.a(num2 + num3);
						}
					}
				}
				else if (A_0.b() < A_0.a() - 2)
				{
					this.j.a(A_0, A_1, A_2);
					A_1 = this.j.b();
				}
			}
			else
			{
				if ((this.aa() == 1 && this.g.Leading + this.v + this.w > A_2) || (this.aa() > 1 && this.g.Leading + this.v > A_2 && A_2 < ((SubList)this.t).m()))
				{
					A_1.a(0);
					return;
				}
				float num = this.g.GetRequiredHeight(0) + this.w + this.v;
				if (num < A_2 || (A_1.a() == 1 && this.g.Count == 1))
				{
					A_2 -= num;
					if (this.j != null)
					{
						this.j.a(A_0, A_1, A_2);
						flag = true;
					}
				}
				else
				{
					A_2 -= this.v;
					int num2 = this.g.GetLineCount(0, A_2);
					if (num2 == this.g.Count)
					{
						num2--;
					}
					A_1.a(num2);
				}
			}
			if (this.j != null && flag)
			{
				this.am = this.j.b();
			}
		}

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x06004A11 RID: 18961 RVA: 0x0025E130 File Offset: 0x0025D130
		// (set) Token: 0x06004A12 RID: 18962 RVA: 0x0025E148 File Offset: 0x0025D148
		public Tag Tag
		{
			get
			{
				return this.ab;
			}
			set
			{
				this.ab = value;
				((StructureElement)this.ab).a(false);
			}
		}

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x06004A13 RID: 18963 RVA: 0x0025E164 File Offset: 0x0025D164
		// (set) Token: 0x06004A14 RID: 18964 RVA: 0x0025E17C File Offset: 0x0025D17C
		public int TagOrder
		{
			get
			{
				return this.ac;
			}
			set
			{
				this.ac = value;
			}
		}

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x06004A15 RID: 18965 RVA: 0x0025E188 File Offset: 0x0025D188
		// (set) Token: 0x06004A16 RID: 18966 RVA: 0x0025E1A0 File Offset: 0x0025D1A0
		public Tag BulletTag
		{
			get
			{
				return this.ad;
			}
			set
			{
				this.ad = value;
			}
		}

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x06004A17 RID: 18967 RVA: 0x0025E1AC File Offset: 0x0025D1AC
		// (set) Token: 0x06004A18 RID: 18968 RVA: 0x0025E1C4 File Offset: 0x0025D1C4
		public int BulletTagOrder
		{
			get
			{
				return this.ae;
			}
			set
			{
				this.ae = value;
			}
		}

		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x06004A19 RID: 18969 RVA: 0x0025E1D0 File Offset: 0x0025D1D0
		// (set) Token: 0x06004A1A RID: 18970 RVA: 0x0025E1E8 File Offset: 0x0025D1E8
		public Tag BodyTag
		{
			get
			{
				return this.af;
			}
			set
			{
				this.af = value;
			}
		}

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x06004A1B RID: 18971 RVA: 0x0025E1F4 File Offset: 0x0025D1F4
		// (set) Token: 0x06004A1C RID: 18972 RVA: 0x0025E20C File Offset: 0x0025D20C
		public int BodyTagOrder
		{
			get
			{
				return this.ag;
			}
			set
			{
				this.ag = value;
			}
		}

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x06004A1D RID: 18973 RVA: 0x0025E218 File Offset: 0x0025D218
		// (set) Token: 0x06004A1E RID: 18974 RVA: 0x0025E230 File Offset: 0x0025D230
		public Tag ListItemTag
		{
			get
			{
				return this.ah;
			}
			set
			{
				this.ah = value;
			}
		}

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x06004A1F RID: 18975 RVA: 0x0025E23C File Offset: 0x0025D23C
		// (set) Token: 0x06004A20 RID: 18976 RVA: 0x0025E254 File Offset: 0x0025D254
		public int ListItemTagOrder
		{
			get
			{
				return this.ai;
			}
			set
			{
				this.ai = value;
			}
		}

		// Token: 0x06004A21 RID: 18977 RVA: 0x0025E260 File Offset: 0x0025D260
		internal Tag af()
		{
			return this.aj;
		}

		// Token: 0x06004A22 RID: 18978 RVA: 0x0025E278 File Offset: 0x0025D278
		internal void a(Tag A_0)
		{
			this.aj = A_0;
		}

		// Token: 0x06004A23 RID: 18979 RVA: 0x0025E284 File Offset: 0x0025D284
		internal bool ag()
		{
			return this.ak;
		}

		// Token: 0x06004A24 RID: 18980 RVA: 0x0025E29C File Offset: 0x0025D29C
		internal void b(bool A_0)
		{
			this.ak = A_0;
		}

		// Token: 0x06004A25 RID: 18981 RVA: 0x0025E2A8 File Offset: 0x0025D2A8
		internal TextLineList ah()
		{
			return this.g;
		}

		// Token: 0x06004A26 RID: 18982 RVA: 0x0025E2C0 File Offset: 0x0025D2C0
		internal IListProperties ai()
		{
			return this.t;
		}

		// Token: 0x04002810 RID: 10256
		private Font a;

		// Token: 0x04002811 RID: 10257
		private float b;

		// Token: 0x04002812 RID: 10258
		private bool c;

		// Token: 0x04002813 RID: 10259
		private Color d;

		// Token: 0x04002814 RID: 10260
		private Color e;

		// Token: 0x04002815 RID: 10261
		private float f = 1f;

		// Token: 0x04002816 RID: 10262
		private TextLineList g = null;

		// Token: 0x04002817 RID: 10263
		private float h;

		// Token: 0x04002818 RID: 10264
		private float i;

		// Token: 0x04002819 RID: 10265
		private SubListList j = null;

		// Token: 0x0400281A RID: 10266
		private bool k;

		// Token: 0x0400281B RID: 10267
		private float l;

		// Token: 0x0400281C RID: 10268
		private float m;

		// Token: 0x0400281D RID: 10269
		private float n;

		// Token: 0x0400281E RID: 10270
		private Align o;

		// Token: 0x0400281F RID: 10271
		private int p;

		// Token: 0x04002820 RID: 10272
		private float q;

		// Token: 0x04002821 RID: 10273
		private float r;

		// Token: 0x04002822 RID: 10274
		private TextAlign s;

		// Token: 0x04002823 RID: 10275
		private IListProperties t;

		// Token: 0x04002824 RID: 10276
		private bool u;

		// Token: 0x04002825 RID: 10277
		private float v;

		// Token: 0x04002826 RID: 10278
		private float w;

		// Token: 0x04002827 RID: 10279
		private float x;

		// Token: 0x04002828 RID: 10280
		private string y = "";

		// Token: 0x04002829 RID: 10281
		private string z = "";

		// Token: 0x0400282A RID: 10282
		private NumberingStyle aa;

		// Token: 0x0400282B RID: 10283
		private Tag ab;

		// Token: 0x0400282C RID: 10284
		private int ac = 0;

		// Token: 0x0400282D RID: 10285
		private Tag ad;

		// Token: 0x0400282E RID: 10286
		private int ae = 0;

		// Token: 0x0400282F RID: 10287
		private Tag af;

		// Token: 0x04002830 RID: 10288
		private int ag = 0;

		// Token: 0x04002831 RID: 10289
		private Tag ah;

		// Token: 0x04002832 RID: 10290
		private int ai;

		// Token: 0x04002833 RID: 10291
		private Tag aj;

		// Token: 0x04002834 RID: 10292
		private bool ak = false;

		// Token: 0x04002835 RID: 10293
		private float al = 0f;

		// Token: 0x04002836 RID: 10294
		private ae7 am;

		// Token: 0x04002837 RID: 10295
		private int an = 0;

		// Token: 0x04002838 RID: 10296
		private bool ao = false;
	}
}
