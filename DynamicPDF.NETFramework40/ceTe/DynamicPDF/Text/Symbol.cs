using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000868 RID: 2152
	public class Symbol : Font
	{
		// Token: 0x06005745 RID: 22341 RVA: 0x002EC6E0 File Offset: 0x002EB6E0
		internal Symbol() : base(ceTe.DynamicPDF.Text.Symbol.a, -204L)
		{
		}

		// Token: 0x06005746 RID: 22342 RVA: 0x002EC6F8 File Offset: 0x002EB6F8
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(Font.a);
			writer.WriteName(Font.c);
			writer.WriteName(ceTe.DynamicPDF.Text.Symbol.b);
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06005747 RID: 22343 RVA: 0x002EC76C File Offset: 0x002EB76C
		public override short GetGlyphWidth(char glyph)
		{
			return ceTe.DynamicPDF.Text.Symbol.c[(int)ceTe.DynamicPDF.Text.Symbol.a.a(glyph)];
		}

		// Token: 0x17000891 RID: 2193
		// (get) Token: 0x06005748 RID: 22344 RVA: 0x002EC790 File Offset: 0x002EB790
		public override short Descender
		{
			get
			{
				return -220;
			}
		}

		// Token: 0x17000892 RID: 2194
		// (get) Token: 0x06005749 RID: 22345 RVA: 0x002EC7A8 File Offset: 0x002EB7A8
		public override short Ascender
		{
			get
			{
				return 900;
			}
		}

		// Token: 0x0600574A RID: 22346 RVA: 0x002EC7C0 File Offset: 0x002EB7C0
		internal override short bc()
		{
			return 50;
		}

		// Token: 0x0600574B RID: 22347 RVA: 0x002EC7D4 File Offset: 0x002EB7D4
		internal override short bd()
		{
			return 250;
		}

		// Token: 0x0600574C RID: 22348 RVA: 0x002EC7EC File Offset: 0x002EB7EC
		internal override short be()
		{
			return -74;
		}

		// Token: 0x0600574D RID: 22349 RVA: 0x002EC800 File Offset: 0x002EB800
		internal override short bf()
		{
			return 50;
		}

		// Token: 0x17000893 RID: 2195
		// (get) Token: 0x0600574E RID: 22350 RVA: 0x002EC814 File Offset: 0x002EB814
		public override short LineGap
		{
			get
			{
				return 30;
			}
		}

		// Token: 0x17000894 RID: 2196
		// (get) Token: 0x0600574F RID: 22351 RVA: 0x002EC828 File Offset: 0x002EB828
		public override int RequiredPdfObjects
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000895 RID: 2197
		// (get) Token: 0x06005750 RID: 22352 RVA: 0x002EC83C File Offset: 0x002EB83C
		public override string Name
		{
			get
			{
				return "Symbol";
			}
		}

		// Token: 0x17000896 RID: 2198
		// (get) Token: 0x06005751 RID: 22353 RVA: 0x002EC854 File Offset: 0x002EB854
		public override string FormFontName
		{
			get
			{
				return "Symb";
			}
		}

		// Token: 0x17000897 RID: 2199
		// (get) Token: 0x06005752 RID: 22354 RVA: 0x002EC86C File Offset: 0x002EB86C
		public override LineBreaker LineBreaker
		{
			get
			{
				return LineBreaker.Latin;
			}
		}

		// Token: 0x06005753 RID: 22355 RVA: 0x002EC884 File Offset: 0x002EB884
		internal override short bh()
		{
			return this.Ascender;
		}

		// Token: 0x06005754 RID: 22356 RVA: 0x002EC89C File Offset: 0x002EB89C
		internal override short bi()
		{
			return this.Descender;
		}

		// Token: 0x04002E63 RID: 11875
		private new static aeb a = new aeb();

		// Token: 0x04002E64 RID: 11876
		private new static byte[] b = new byte[]
		{
			83,
			121,
			109,
			98,
			111,
			108
		};

		// Token: 0x04002E65 RID: 11877
		private new static short[] c = new short[]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			250,
			333,
			713,
			500,
			549,
			833,
			778,
			439,
			333,
			333,
			500,
			549,
			250,
			549,
			250,
			278,
			500,
			500,
			500,
			500,
			500,
			500,
			500,
			500,
			500,
			500,
			278,
			278,
			549,
			549,
			549,
			444,
			549,
			722,
			667,
			722,
			612,
			611,
			763,
			603,
			722,
			333,
			631,
			722,
			686,
			889,
			722,
			722,
			768,
			741,
			556,
			592,
			611,
			690,
			439,
			768,
			645,
			795,
			611,
			333,
			863,
			333,
			658,
			500,
			500,
			631,
			549,
			549,
			494,
			439,
			521,
			411,
			603,
			329,
			603,
			549,
			549,
			576,
			521,
			549,
			549,
			521,
			549,
			603,
			439,
			576,
			713,
			686,
			493,
			686,
			494,
			480,
			200,
			480,
			549,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			750,
			620,
			247,
			549,
			167,
			713,
			500,
			753,
			753,
			753,
			753,
			1042,
			987,
			603,
			987,
			603,
			400,
			549,
			411,
			549,
			549,
			713,
			494,
			460,
			549,
			549,
			549,
			549,
			1000,
			603,
			1000,
			658,
			823,
			686,
			795,
			987,
			768,
			768,
			823,
			768,
			768,
			713,
			713,
			713,
			713,
			713,
			713,
			713,
			768,
			713,
			790,
			790,
			890,
			823,
			549,
			250,
			713,
			603,
			603,
			1042,
			987,
			603,
			987,
			603,
			494,
			329,
			790,
			790,
			786,
			713,
			384,
			384,
			384,
			384,
			384,
			384,
			494,
			494,
			494,
			494,
			0,
			329,
			274,
			686,
			686,
			686,
			384,
			384,
			384,
			384,
			384,
			384,
			494,
			494,
			494,
			0
		};
	}
}
