using System;
using zz93;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000872 RID: 2162
	public class UniversalLineBreaker : LineBreaker
	{
		// Token: 0x060057C6 RID: 22470 RVA: 0x0033050C File Offset: 0x0032F50C
		public override TextLineList GetLines(char[] text, int start, int length, float width, float height, Font font, float fontSize)
		{
			TextLineList result;
			if (font is OpenTypeFont && ((OpenTypeFont)font).UseCharacterShaping)
			{
				result = new agb(text, start, length, width, height, font, fontSize);
			}
			else
			{
				result = new UniversalTextLineList(text, start, length, width, height, font, fontSize);
			}
			return result;
		}

		// Token: 0x060057C7 RID: 22471 RVA: 0x00330564 File Offset: 0x0032F564
		internal override TextLineList jd(char[] A_0, int A_1, int A_2, float A_3, float A_4, Font A_5, float A_6, float A_7)
		{
			TextLineList result;
			if (A_5 is OpenTypeFont && ((OpenTypeFont)A_5).UseCharacterShaping)
			{
				result = new agb(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7);
			}
			else
			{
				result = new UniversalTextLineList(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7);
			}
			return result;
		}

		// Token: 0x060057C8 RID: 22472 RVA: 0x003305C0 File Offset: 0x0032F5C0
		internal override TextLineList je(TextLineList A_0)
		{
			TextLineList result;
			if (A_0.Font is OpenTypeFont && ((OpenTypeFont)A_0.Font).UseCharacterShaping)
			{
				result = new agb(A_0);
			}
			else
			{
				result = new UniversalTextLineList(A_0);
			}
			return result;
		}
	}
}
