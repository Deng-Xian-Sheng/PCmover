using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements.Charting
{
	// Token: 0x020007AA RID: 1962
	public class Marker
	{
		// Token: 0x06004F64 RID: 20324 RVA: 0x0027B57A File Offset: 0x0027A57A
		internal Marker(float A_0)
		{
			this.k = ' ';
			this.i = null;
			this.j = A_0;
		}

		// Token: 0x06004F65 RID: 20325 RVA: 0x0027B5A2 File Offset: 0x0027A5A2
		internal void a(char A_0)
		{
			this.k = A_0;
		}

		// Token: 0x06004F66 RID: 20326 RVA: 0x0027B5AC File Offset: 0x0027A5AC
		public static Marker GetCircle(float size)
		{
			Marker.a = new Marker(size);
			Marker.a.a('A');
			return Marker.a;
		}

		// Token: 0x06004F67 RID: 20327 RVA: 0x0027B5DC File Offset: 0x0027A5DC
		public static Marker GetSquare(float size)
		{
			Marker.b = new Marker(size);
			Marker.b.a('B');
			return Marker.b;
		}

		// Token: 0x06004F68 RID: 20328 RVA: 0x0027B60C File Offset: 0x0027A60C
		public static Marker GetTriangle(float size)
		{
			Marker.c = new Marker(size);
			Marker.c.a('F');
			return Marker.c;
		}

		// Token: 0x06004F69 RID: 20329 RVA: 0x0027B63C File Offset: 0x0027A63C
		public static Marker GetDiamond(float size)
		{
			Marker.d = new Marker(size);
			Marker.d.a('G');
			return Marker.d;
		}

		// Token: 0x06004F6A RID: 20330 RVA: 0x0027B66C File Offset: 0x0027A66C
		public static Marker GetCross(float size)
		{
			Marker.f = new Marker(size);
			Marker.f.a('D');
			return Marker.f;
		}

		// Token: 0x06004F6B RID: 20331 RVA: 0x0027B69C File Offset: 0x0027A69C
		public static Marker GetPlus(float size)
		{
			Marker.e = new Marker(size);
			Marker.e.a('C');
			return Marker.e;
		}

		// Token: 0x06004F6C RID: 20332 RVA: 0x0027B6CC File Offset: 0x0027A6CC
		public static Marker GetDash(float size)
		{
			Marker.g = new Marker(size);
			Marker.g.a('H');
			return Marker.g;
		}

		// Token: 0x06004F6D RID: 20333 RVA: 0x0027B6FC File Offset: 0x0027A6FC
		public static Marker GetAsterisk(float size)
		{
			Marker.h = new Marker(size);
			Marker.h.a('E');
			return Marker.h;
		}

		// Token: 0x17000684 RID: 1668
		// (get) Token: 0x06004F6E RID: 20334 RVA: 0x0027B72C File Offset: 0x0027A72C
		// (set) Token: 0x06004F6F RID: 20335 RVA: 0x0027B744 File Offset: 0x0027A744
		public Color Color
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

		// Token: 0x17000685 RID: 1669
		// (get) Token: 0x06004F70 RID: 20336 RVA: 0x0027B750 File Offset: 0x0027A750
		// (set) Token: 0x06004F71 RID: 20337 RVA: 0x0027B768 File Offset: 0x0027A768
		public float Size
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

		// Token: 0x06004F72 RID: 20338 RVA: 0x0027B774 File Offset: 0x0027A774
		internal void a(PageWriter A_0, float A_1, float A_2)
		{
			switch (this.k)
			{
			case 'A':
				this.b(A_0, A_1, A_2);
				break;
			case 'B':
				this.c(A_0, A_1, A_2);
				break;
			case 'C':
				this.g(A_0, A_1, A_2);
				break;
			case 'D':
				this.f(A_0, A_1, A_2);
				break;
			case 'E':
				this.i(A_0, A_1, A_2);
				break;
			case 'F':
				this.d(A_0, A_1, A_2);
				break;
			case 'G':
				this.e(A_0, A_1, A_2);
				break;
			case 'H':
				this.h(A_0, A_1, A_2);
				break;
			}
		}

		// Token: 0x06004F73 RID: 20339 RVA: 0x0027B814 File Offset: 0x0027A814
		internal void b(PageWriter A_0, float A_1, float A_2)
		{
			A_0.SetGraphicsMode();
			A_0.SetFillColor(this.i);
			float num = 0.5522848f;
			A_0.Write_m_(A_1, A_2 - this.j / 2f);
			A_0.Write_c(A_1 + this.j / 2f * num, A_2 - this.j / 2f, A_1 + this.j / 2f, A_2 - this.j / 2f * num, A_1 + this.j / 2f, A_2);
			A_0.Write_c(A_1 + this.j / 2f, A_2 + this.j / 2f * num, A_1 + this.j / 2f * num, A_2 + this.j / 2f, A_1, A_2 + this.j / 2f);
			A_0.Write_c(A_1 - this.j / 2f * num, A_2 + this.j / 2f, A_1 - this.j / 2f, A_2 + this.j / 2f * num, A_1 - this.j / 2f, A_2);
			A_0.Write_c(A_1 - this.j / 2f, A_2 - this.j / 2f * num, A_1 - this.j / 2f * num, A_2 - this.j / 2f, A_1, A_2 - this.j / 2f);
			A_0.Write_f();
		}

		// Token: 0x06004F74 RID: 20340 RVA: 0x0027B9A4 File Offset: 0x0027A9A4
		internal void c(PageWriter A_0, float A_1, float A_2)
		{
			A_0.SetGraphicsMode();
			A_0.SetFillColor(this.i);
			A_0.Write_re(A_1 - this.j / 2f, A_2 - this.j / 2f, this.j, this.j);
			A_0.Write_f();
		}

		// Token: 0x06004F75 RID: 20341 RVA: 0x0027B9FC File Offset: 0x0027A9FC
		internal void d(PageWriter A_0, float A_1, float A_2)
		{
			A_0.SetGraphicsMode();
			A_0.SetFillColor(this.i);
			float num = this.j * 0.8660254f;
			float num2 = num / 3f * 2f;
			float num3 = num / 3f;
			A_0.Write_m_(A_1 - this.j / 2f, A_2 + num3);
			A_0.Write_l_(A_1, A_2 - num2);
			A_0.Write_l_(A_1 + this.j / 2f, A_2 + num3);
			A_0.Write_l_(A_1 - this.j / 2f, A_2 + num3);
			A_0.Write_f();
		}

		// Token: 0x06004F76 RID: 20342 RVA: 0x0027BA9C File Offset: 0x0027AA9C
		internal void e(PageWriter A_0, float A_1, float A_2)
		{
			A_0.SetGraphicsMode();
			A_0.SetFillColor(this.i);
			A_0.Write_m_(A_1, A_2 - this.j / 2f);
			A_0.Write_l_(A_1 + this.j / 2f, A_2);
			A_0.Write_l_(A_1, A_2 + this.j / 2f);
			A_0.Write_l_(A_1 - this.j / 2f, A_2);
			A_0.Write_l_(A_1, A_2 - this.j / 2f);
			A_0.Write_f();
		}

		// Token: 0x06004F77 RID: 20343 RVA: 0x0027BB34 File Offset: 0x0027AB34
		internal void f(PageWriter A_0, float A_1, float A_2)
		{
			A_0.SetGraphicsMode();
			A_0.SetStrokeColor(this.i);
			float num = this.j / 1.4142135f;
			A_0.Write_m_(A_1 - num / 2f, A_2 + num / 2f);
			A_0.Write_l_(A_1 + num / 2f, A_2 - num / 2f);
			A_0.Write_m_(A_1 - num / 2f, A_2 - num / 2f);
			A_0.Write_l_(A_1 + num / 2f, A_2 + num / 2f);
			A_0.Write_S();
		}

		// Token: 0x06004F78 RID: 20344 RVA: 0x0027BBD0 File Offset: 0x0027ABD0
		internal void g(PageWriter A_0, float A_1, float A_2)
		{
			A_0.SetGraphicsMode();
			A_0.SetStrokeColor(this.i);
			A_0.Write_m_(A_1, A_2 - this.j / 2f);
			A_0.Write_l_(A_1, A_2 + this.j / 2f);
			A_0.Write_m_(A_1 - this.j / 2f, A_2);
			A_0.Write_l_(A_1 + this.j / 2f, A_2);
			A_0.Write_S();
		}

		// Token: 0x06004F79 RID: 20345 RVA: 0x0027BC54 File Offset: 0x0027AC54
		internal void h(PageWriter A_0, float A_1, float A_2)
		{
			A_0.SetGraphicsMode();
			A_0.SetStrokeColor(this.i);
			A_0.Write_m_(A_1 + this.j / 2f, A_2);
			A_0.Write_l_(A_1 - this.j / 2f, A_2);
			A_0.Write_S();
		}

		// Token: 0x06004F7A RID: 20346 RVA: 0x0027BCAC File Offset: 0x0027ACAC
		internal void i(PageWriter A_0, float A_1, float A_2)
		{
			A_0.SetGraphicsMode();
			A_0.SetStrokeColor(this.i);
			float num = this.j / 1.4142135f;
			A_0.Write_m_(A_1 - num / 2f, A_2 + num / 2f);
			A_0.Write_l_(A_1 + num / 2f, A_2 - num / 2f);
			A_0.Write_m_(A_1 - num / 2f, A_2 - num / 2f);
			A_0.Write_l_(A_1 + num / 2f, A_2 + num / 2f);
			A_0.Write_m_(A_1, A_2 + num / 2f);
			A_0.Write_l_(A_1, A_2 - num / 2f);
			A_0.Write_S();
		}

		// Token: 0x04002AE6 RID: 10982
		private static Marker a;

		// Token: 0x04002AE7 RID: 10983
		private static Marker b;

		// Token: 0x04002AE8 RID: 10984
		private static Marker c;

		// Token: 0x04002AE9 RID: 10985
		private static Marker d;

		// Token: 0x04002AEA RID: 10986
		private static Marker e;

		// Token: 0x04002AEB RID: 10987
		private static Marker f;

		// Token: 0x04002AEC RID: 10988
		private static Marker g;

		// Token: 0x04002AED RID: 10989
		private static Marker h;

		// Token: 0x04002AEE RID: 10990
		private Color i = null;

		// Token: 0x04002AEF RID: 10991
		private float j;

		// Token: 0x04002AF0 RID: 10992
		private char k;
	}
}
