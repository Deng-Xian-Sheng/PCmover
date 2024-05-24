using System;
using zz93;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000864 RID: 2148
	public class LatinLineBreaker : LineBreaker
	{
		// Token: 0x06005700 RID: 22272 RVA: 0x002EB440 File Offset: 0x002EA440
		public override TextLineList GetLines(char[] text, int start, int length, float width, float height, Font font, float fontSize)
		{
			TextLineList result;
			if (font is OpenTypeFont && ((OpenTypeFont)font).UseCharacterShaping)
			{
				result = new agb(text, start, length, width, height, font, fontSize);
			}
			else
			{
				result = new LatinTextLineList(text, start, length, width, height, font, fontSize);
			}
			return result;
		}

		// Token: 0x06005701 RID: 22273 RVA: 0x002EB498 File Offset: 0x002EA498
		internal override TextLineList jd(char[] A_0, int A_1, int A_2, float A_3, float A_4, Font A_5, float A_6, float A_7)
		{
			TextLineList result;
			if (A_5 is OpenTypeFont && ((OpenTypeFont)A_5).UseCharacterShaping)
			{
				result = new agb(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7);
			}
			else
			{
				result = new LatinTextLineList(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7);
			}
			return result;
		}

		// Token: 0x06005702 RID: 22274 RVA: 0x002EB4F4 File Offset: 0x002EA4F4
		internal override TextLineList je(TextLineList A_0)
		{
			TextLineList result;
			if (A_0.Font is OpenTypeFont && ((OpenTypeFont)A_0.Font).UseCharacterShaping)
			{
				result = new agb(A_0);
			}
			else
			{
				result = new LatinTextLineList(A_0);
			}
			return result;
		}
	}
}
