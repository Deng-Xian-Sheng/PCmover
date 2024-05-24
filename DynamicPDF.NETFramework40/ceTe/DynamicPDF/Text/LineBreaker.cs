using System;
using zz93;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000863 RID: 2147
	public abstract class LineBreaker
	{
		// Token: 0x060056F2 RID: 22258 RVA: 0x002EB310 File Offset: 0x002EA310
		public virtual TextLineList GetLines(char[] text, float width, float height, Font font, float fontSize)
		{
			return this.GetLines(text, 0, text.Length, width, height, font, fontSize);
		}

		// Token: 0x060056F3 RID: 22259 RVA: 0x002EB334 File Offset: 0x002EA334
		public virtual TextLineList GetLines(char[] text, float width, Font font, float fontSize)
		{
			return this.GetLines(text, 0, text.Length, width, float.MaxValue, font, fontSize);
		}

		// Token: 0x060056F4 RID: 22260
		public abstract TextLineList GetLines(char[] text, int start, int length, float width, float height, Font font, float fontSize);

		// Token: 0x060056F5 RID: 22261 RVA: 0x002EB35C File Offset: 0x002EA35C
		internal virtual TextLineList jd(char[] A_0, int A_1, int A_2, float A_3, float A_4, Font A_5, float A_6, float A_7)
		{
			return null;
		}

		// Token: 0x060056F6 RID: 22262 RVA: 0x002EB370 File Offset: 0x002EA370
		public virtual TextLineList GetLines(char[] text, int start, int length, float width, Font font, float fontSize)
		{
			return this.GetLines(text, start, length, width, float.MaxValue, font, fontSize);
		}

		// Token: 0x060056F7 RID: 22263
		internal abstract TextLineList je(TextLineList A_0);

		// Token: 0x060056F8 RID: 22264 RVA: 0x002EB398 File Offset: 0x002EA398
		internal virtual TextLineList a(TextLineList A_0)
		{
			return new ac6(A_0);
		}

		// Token: 0x060056F9 RID: 22265 RVA: 0x002EB3B0 File Offset: 0x002EA3B0
		internal virtual TextLineList b(TextLineList A_0)
		{
			return new agb(A_0);
		}

		// Token: 0x17000881 RID: 2177
		// (get) Token: 0x060056FA RID: 22266 RVA: 0x002EB3C8 File Offset: 0x002EA3C8
		public static LineBreaker Latin
		{
			get
			{
				return LineBreaker.a;
			}
		}

		// Token: 0x17000882 RID: 2178
		// (get) Token: 0x060056FB RID: 22267 RVA: 0x002EB3E0 File Offset: 0x002EA3E0
		public static LineBreaker Universal
		{
			get
			{
				return LineBreaker.b;
			}
		}

		// Token: 0x17000883 RID: 2179
		// (get) Token: 0x060056FC RID: 22268 RVA: 0x002EB3F8 File Offset: 0x002EA3F8
		// (set) Token: 0x060056FD RID: 22269 RVA: 0x002EB40F File Offset: 0x002EA40F
		public static LineBreaker Default
		{
			get
			{
				return LineBreaker.c;
			}
			set
			{
				LineBreaker.c = value;
			}
		}

		// Token: 0x04002E49 RID: 11849
		private static LineBreaker a = new LatinLineBreaker();

		// Token: 0x04002E4A RID: 11850
		private static LineBreaker b = new UniversalLineBreaker();

		// Token: 0x04002E4B RID: 11851
		private static LineBreaker c = LineBreaker.a;
	}
}
