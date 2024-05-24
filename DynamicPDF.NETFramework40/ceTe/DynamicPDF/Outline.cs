using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000406 RID: 1030
	public class Outline
	{
		// Token: 0x06002B21 RID: 11041 RVA: 0x0018ECEC File Offset: 0x0018DCEC
		internal Outline(string A_0, Action A_1)
		{
			this.h = A_0;
			this.g = A_1;
		}

		// Token: 0x06002B22 RID: 11042 RVA: 0x0018ED58 File Offset: 0x0018DD58
		protected Outline(bool expanded, TextStyle style, Action action)
		{
			this.h = string.Empty;
			this.a = expanded;
			this.e = style;
			this.g = action;
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06002B23 RID: 11043 RVA: 0x0018EDD4 File Offset: 0x0018DDD4
		// (set) Token: 0x06002B24 RID: 11044 RVA: 0x0018EDEC File Offset: 0x0018DDEC
		public virtual string Text
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

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06002B25 RID: 11045 RVA: 0x0018EDF8 File Offset: 0x0018DDF8
		// (set) Token: 0x06002B26 RID: 11046 RVA: 0x0018EE10 File Offset: 0x0018DE10
		public TextStyle Style
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

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06002B27 RID: 11047 RVA: 0x0018EE1C File Offset: 0x0018DE1C
		// (set) Token: 0x06002B28 RID: 11048 RVA: 0x0018EE34 File Offset: 0x0018DE34
		public virtual RgbColor Color
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

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06002B29 RID: 11049 RVA: 0x0018EE40 File Offset: 0x0018DE40
		public OutlineList Parent
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06002B2A RID: 11050 RVA: 0x0018EE58 File Offset: 0x0018DE58
		public OutlineList ChildOutlines
		{
			get
			{
				if (this.b == null)
				{
					this.b = new OutlineList();
				}
				return this.b;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06002B2B RID: 11051 RVA: 0x0018EE8C File Offset: 0x0018DE8C
		// (set) Token: 0x06002B2C RID: 11052 RVA: 0x0018EEA4 File Offset: 0x0018DEA4
		public bool Expanded
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

		// Token: 0x06002B2D RID: 11053 RVA: 0x0018EEB0 File Offset: 0x0018DEB0
		internal int a()
		{
			return this.i;
		}

		// Token: 0x06002B2E RID: 11054 RVA: 0x0018EEC8 File Offset: 0x0018DEC8
		internal virtual void ho(DocumentWriter A_0)
		{
			A_0.WriteName(Outline.r);
			A_0.WriteText(this.h);
		}

		// Token: 0x06002B2F RID: 11055 RVA: 0x0018EEE4 File Offset: 0x0018DEE4
		internal virtual void hp(DocumentWriter A_0)
		{
			if (this.f != null)
			{
				A_0.WriteName(67);
				this.f.gr(A_0);
			}
		}

		// Token: 0x06002B30 RID: 11056 RVA: 0x0018EF18 File Offset: 0x0018DF18
		internal void a(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			this.ho(A_0);
			this.hp(A_0);
			if (this.e != TextStyle.Regular)
			{
				A_0.WriteName(70);
				A_0.WriteNumber((int)this.e);
			}
			A_0.WriteName(Outline.l);
			A_0.WriteReference(this.c.b());
			if (this.d != 0)
			{
				A_0.WriteName(Outline.m);
				A_0.WriteReference(this.c[this.d - 1].a());
			}
			if (this.d != this.c.Count - 1)
			{
				A_0.WriteName(Outline.n);
				A_0.WriteReference(this.c[this.d + 1].a());
			}
			if (this.b != null && this.b.Count > 0)
			{
				A_0.WriteName(Outline.o);
				A_0.WriteReference(this.b[0].a());
				A_0.WriteName(Outline.p);
				A_0.WriteReference(this.b[this.b.Count - 1].a());
				if (this.a)
				{
					A_0.WriteName(Outline.q);
					A_0.WriteNumber(this.b());
				}
				else
				{
					A_0.WriteName(Outline.q);
					A_0.WriteNumber(-this.b());
				}
			}
			else
			{
				A_0.WriteName(Outline.q);
				A_0.WriteNumber0();
			}
			if (this.g != null)
			{
				if (this.g.c() != 750795497 && this.g.c() != 514009796 && this.g.c() != 237062808)
				{
					A_0.WriteName(65);
				}
				this.g.Draw(A_0);
			}
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
			if (this.b != null)
			{
				this.b.a(A_0);
			}
		}

		// Token: 0x06002B31 RID: 11057 RVA: 0x0018F16C File Offset: 0x0018E16C
		internal void a(ref int A_0)
		{
			this.i = ++A_0;
			if (this.b != null)
			{
				this.b.a(ref A_0);
			}
		}

		// Token: 0x06002B32 RID: 11058 RVA: 0x0018F1A4 File Offset: 0x0018E1A4
		internal void a(b3 A_0)
		{
			zz zz = A_0.p().a(this.i);
			zz.a(zz.k() - 1);
			if (this.a && this.b != null)
			{
				this.b.a(A_0);
			}
		}

		// Token: 0x06002B33 RID: 11059 RVA: 0x0018F1FA File Offset: 0x0018E1FA
		internal void a(OutlineList A_0, int A_1)
		{
			this.c = A_0;
			this.d = A_1;
		}

		// Token: 0x06002B34 RID: 11060 RVA: 0x0018F20C File Offset: 0x0018E20C
		internal int b()
		{
			int result;
			if (this.b == null)
			{
				result = 0;
			}
			else
			{
				if (!this.k)
				{
					this.j = this.b.Count + this.b.c();
					this.k = true;
				}
				result = this.j;
			}
			return result;
		}

		// Token: 0x040013D2 RID: 5074
		private bool a = true;

		// Token: 0x040013D3 RID: 5075
		private OutlineList b = null;

		// Token: 0x040013D4 RID: 5076
		private OutlineList c = null;

		// Token: 0x040013D5 RID: 5077
		private int d = 0;

		// Token: 0x040013D6 RID: 5078
		private TextStyle e = TextStyle.Regular;

		// Token: 0x040013D7 RID: 5079
		private RgbColor f = null;

		// Token: 0x040013D8 RID: 5080
		private Action g = null;

		// Token: 0x040013D9 RID: 5081
		private string h;

		// Token: 0x040013DA RID: 5082
		private int i = 0;

		// Token: 0x040013DB RID: 5083
		private int j = 0;

		// Token: 0x040013DC RID: 5084
		private bool k = false;

		// Token: 0x040013DD RID: 5085
		private static byte[] l = new byte[]
		{
			80,
			97,
			114,
			101,
			110,
			116
		};

		// Token: 0x040013DE RID: 5086
		private static byte[] m = new byte[]
		{
			80,
			114,
			101,
			118
		};

		// Token: 0x040013DF RID: 5087
		private static byte[] n = new byte[]
		{
			78,
			101,
			120,
			116
		};

		// Token: 0x040013E0 RID: 5088
		private static byte[] o = new byte[]
		{
			70,
			105,
			114,
			115,
			116
		};

		// Token: 0x040013E1 RID: 5089
		private static byte[] p = new byte[]
		{
			76,
			97,
			115,
			116
		};

		// Token: 0x040013E2 RID: 5090
		private static byte[] q = new byte[]
		{
			67,
			111,
			117,
			110,
			116
		};

		// Token: 0x040013E3 RID: 5091
		internal static byte[] r = new byte[]
		{
			84,
			105,
			116,
			108,
			101
		};
	}
}
