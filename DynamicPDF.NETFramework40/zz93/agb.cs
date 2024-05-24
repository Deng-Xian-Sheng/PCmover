using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x020004D2 RID: 1234
	internal class agb : TextLineList
	{
		// Token: 0x06003265 RID: 12901 RVA: 0x001BF950 File Offset: 0x001BE950
		internal agb(TextLineList A_0) : base(A_0)
		{
		}

		// Token: 0x06003266 RID: 12902 RVA: 0x001BF9A8 File Offset: 0x001BE9A8
		internal agb(char[] A_0, int A_1, int A_2, float A_3, float A_4, Font A_5, float A_6) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, agb.r)
		{
		}

		// Token: 0x06003267 RID: 12903 RVA: 0x001BFA10 File Offset: 0x001BEA10
		internal agb(char[] A_0, int A_1, int A_2, float A_3, float A_4, Font A_5, float A_6, float A_7) : base(A_0, A_1, A_2, A_3, A_4, A_5, A_6, agb.r, A_7)
		{
		}

		// Token: 0x06003268 RID: 12904 RVA: 0x001BFA78 File Offset: 0x001BEA78
		internal agb(int A_0, float A_1, float A_2, bool A_3, TextLineList A_4) : base(A_0, A_1, A_2, A_3, A_4)
		{
		}

		// Token: 0x06003269 RID: 12905 RVA: 0x001BFAD4 File Offset: 0x001BEAD4
		internal override void jb(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, Color A_5, float A_6, bool A_7, int A_8, int A_9, bool A_10, bool A_11)
		{
			this.q = A_10;
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

		// Token: 0x0600326A RID: 12906 RVA: 0x001BFCEC File Offset: 0x001BECEC
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
					A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, 0f);
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

		// Token: 0x0600326B RID: 12907 RVA: 0x001BFDE8 File Offset: 0x001BEDE8
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
					A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, this.q, 0f);
				}
				num += base.Leading;
			}
		}

		// Token: 0x0600326C RID: 12908 RVA: 0x001BFEEC File Offset: 0x001BEEEC
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
					A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, 0f);
				}
				num += base.Leading;
				if (base.i()[i].HardReturn)
				{
					num += base.ParagraphSpacing;
				}
			}
		}

		// Token: 0x0600326D RID: 12909 RVA: 0x001C0048 File Offset: 0x001BF048
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
					A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, 0f);
				}
				num += base.Leading;
				if (base.i()[i].HardReturn)
				{
					num += base.ParagraphSpacing;
				}
			}
		}

		// Token: 0x0600326E RID: 12910 RVA: 0x001C015C File Offset: 0x001BF15C
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
						A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, 0f);
					}
					else if (base.i()[i].HardReturn && !A_6)
					{
						A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, 0f);
					}
					else if (base.i()[i].NewParagraph)
					{
						A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, (base.Width - base.ParagraphIndent - base.i()[i].GetWidth(base.FontSize)) / (float)base.i()[i].SpaceCount);
					}
					else
					{
						A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, (base.Width - base.i()[i].GetWidth(base.FontSize)) / (float)base.i()[i].SpaceCount);
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

		// Token: 0x0600326F RID: 12911 RVA: 0x001C058C File Offset: 0x001BF58C
		internal override void jc(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, Color A_5, float A_6, bool A_7, bool A_8, bool A_9, StructureElement A_10, AttributeTypeList A_11, AttributeClassList A_12)
		{
			this.a(A_0, A_1, A_2, A_3, A_4, A_5, A_6, A_7, 0, base.VisibleLineCount, A_8, A_9, A_10, A_11, A_12);
		}

		// Token: 0x06003270 RID: 12912 RVA: 0x001C05C0 File Offset: 0x001BF5C0
		internal override void k2(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, Color A_5, float A_6, bool A_7, int A_8, int A_9, bool A_10, bool A_11, StructureElement A_12, AttributeTypeList A_13, AttributeClassList A_14, bool A_15)
		{
			this.q = A_10;
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
				this.c(A_0, A_1, A_2, A_8, A_9, A_10, A_12, A_13, A_14, A_15);
				break;
			case TextAlign.Center:
				this.b(A_0, A_1, A_2, A_8, A_9, A_10, A_12, A_13, A_14, A_15);
				break;
			case TextAlign.Right:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, A_12, A_13, A_14, A_15);
				break;
			case TextAlign.Justify:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, false, A_12, A_13, A_14, A_15);
				break;
			case TextAlign.FullJustify:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, true, A_12, A_13, A_14, A_15);
				break;
			}
			if (A_7 && (A_4 != null || (A_6 > 0f && A_5 != null)))
			{
				base.a(A_0, A_4, A_5, A_6);
				base.a(A_0, A_1, base.b(A_2), A_3, A_4, A_8, A_9, A_10, base.Font.d(base.FontSize), A_5, true, A_6);
			}
			if (A_11 && (A_4 != null || (A_6 > 0f && A_5 != null)))
			{
				base.a(A_0, A_4, A_5, A_6);
				base.a(A_0, A_1, base.c(A_2), A_3, A_4, 0, base.VisibleLineCount, A_10, base.Font.a(base.FontSize), A_5, false, A_6);
			}
		}

		// Token: 0x06003271 RID: 12913 RVA: 0x001C07FC File Offset: 0x001BF7FC
		private void a(OperatorWriter A_0, float A_1, float A_2, TextAlign A_3, Color A_4, Color A_5, float A_6, bool A_7, int A_8, int A_9, bool A_10, bool A_11, StructureElement A_12, AttributeTypeList A_13, AttributeClassList A_14)
		{
			this.q = A_10;
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
				this.c(A_0, A_1, A_2, A_8, A_9, A_10, A_12, A_13, A_14, false);
				break;
			case TextAlign.Center:
				this.b(A_0, A_1, A_2, A_8, A_9, A_10, A_12, A_13, A_14, false);
				break;
			case TextAlign.Right:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, A_12, A_13, A_14, false);
				break;
			case TextAlign.Justify:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, false, A_12, A_13, A_14, false);
				break;
			case TextAlign.FullJustify:
				this.a(A_0, A_1, A_2, A_8, A_9, A_10, true, A_12, A_13, A_14, false);
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

		// Token: 0x06003272 RID: 12914 RVA: 0x001C0A4C File Offset: 0x001BFA4C
		private void c(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, StructureElement A_6, AttributeTypeList A_7, AttributeClassList A_8, bool A_9)
		{
			A_0.SetLeading(base.Leading);
			if (base.ParagraphIndent != 0f && !A_5)
			{
				this.a(A_0, A_1, A_2, A_3, A_4, A_6, A_7, A_8, A_9);
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
							TextLineList.a(this, A_0, A_1, num, i, A_6, A_7, A_8, A_9);
						}
						A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, 0f);
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

		// Token: 0x06003273 RID: 12915 RVA: 0x001C0BEC File Offset: 0x001BFBEC
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, StructureElement A_5, AttributeTypeList A_6, AttributeClassList A_7, bool A_8)
		{
			float num = A_2 + base.BaseLine;
			if (base.l())
			{
				TextLineList.a(this, A_0, A_1, num, A_3, A_5, A_6, A_7, A_8);
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
							TextLineList.a(this, A_0, A_1, num, i, A_5, A_6, A_7, A_8);
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
					A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, this.q, 0f);
				}
				num += base.Leading;
			}
			if (base.l())
			{
				Tag.a((PageWriter)A_0);
			}
		}

		// Token: 0x06003274 RID: 12916 RVA: 0x001C0D5C File Offset: 0x001BFD5C
		private void b(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, StructureElement A_6, AttributeTypeList A_7, AttributeClassList A_8, bool A_9)
		{
			float num = A_2 + base.BaseLine;
			if (base.l())
			{
				TextLineList.a(this, A_0, A_1, num, A_3, A_6, A_7, A_8, A_9);
			}
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (base.i()[i].NewParagraph)
				{
					if (base.l() && i != A_3)
					{
						TextLineList.a(this, A_0, A_1, num, i, A_6, A_7, A_8, A_9);
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
					A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, 0f);
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

		// Token: 0x06003275 RID: 12917 RVA: 0x001C0F50 File Offset: 0x001BFF50
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, StructureElement A_6, AttributeTypeList A_7, AttributeClassList A_8, bool A_9)
		{
			float num = A_2 + base.BaseLine;
			if (base.l())
			{
				TextLineList.a(this, A_0, A_1, num, A_3, A_6, A_7, A_8, A_9);
			}
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				if (base.i()[i].NewParagraph)
				{
					if (base.l() && i != A_3)
					{
						TextLineList.a(this, A_0, A_1, num, i, A_6, A_7, A_8, A_9);
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
					A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, 0f);
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

		// Token: 0x06003276 RID: 12918 RVA: 0x001C1110 File Offset: 0x001C0110
		private void a(OperatorWriter A_0, float A_1, float A_2, int A_3, int A_4, bool A_5, bool A_6, StructureElement A_7, AttributeTypeList A_8, AttributeClassList A_9, bool A_10)
		{
			float num = A_2 + base.BaseLine;
			if (base.l())
			{
				TextLineList.a(this, A_0, A_1, num, A_3, A_7, A_8, A_9, A_10);
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
							TextLineList.a(this, A_0, A_1, num, i, A_7, A_8, A_9, A_10);
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
						A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, 0f);
					}
					else if (base.i()[i].HardReturn && !A_6)
					{
						A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, 0f);
					}
					else if (base.i()[i].NewParagraph)
					{
						A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, (base.Width - base.ParagraphIndent - base.i()[i].GetWidth(base.FontSize)) / (float)base.i()[i].SpaceCount);
					}
					else
					{
						A_0.a(this.u, base.i()[i].Start, base.i()[i].Length, A_5, (base.Width - base.i()[i].GetWidth(base.FontSize)) / (float)base.i()[i].SpaceCount);
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

		// Token: 0x06003277 RID: 12919 RVA: 0x001C15D4 File Offset: 0x001C05D4
		protected override bool CalculateLines(TextLineList.LineCalculationMode mode)
		{
			if (this.u == null)
			{
				this.u = ((r5)base.Font.Encoder).a(base.TextArray, base.Start, base.End - base.Start + 1, true);
				if (this.u.b() != null && this.u.b().Count > 0)
				{
					foreach (agf agf in this.u.b())
					{
						this.u.a(agf.a(), agf.b() - agf.a() + 1);
					}
				}
				this.t = this.u.a() - 1;
			}
			this.s = base.Start;
			switch (mode)
			{
			case TextLineList.LineCalculationMode.OneLine:
			{
				int num = base.LineCount + 1;
				while (this.s <= this.t && base.LineCount < num)
				{
					this.d();
					this.a();
				}
				if (this.s > this.t)
				{
					this.e();
				}
				break;
			}
			case TextLineList.LineCalculationMode.ToHeight:
			{
				float num2 = base.Height - base.m() + 0.001f;
				while (this.s <= this.t && (this.n <= num2 || base.LineCount == 0))
				{
					this.d();
					this.a();
				}
				if (this.s > this.t)
				{
					this.e();
				}
				break;
			}
			case TextLineList.LineCalculationMode.All:
				while (this.s <= this.t)
				{
					this.d();
					this.a();
				}
				this.e();
				break;
			}
			return this.p;
		}

		// Token: 0x06003278 RID: 12920 RVA: 0x001C1818 File Offset: 0x001C0818
		protected override void InitializeLines(bool newParagraph)
		{
			this.o = newParagraph;
			this.j = base.Start;
			float num = 1000f / base.FontSize;
			this.a = (int)(base.Width * num);
			this.b = (int)(base.ParagraphIndent * num);
			this.c = (int)base.Font.GetGlyphWidth(' ');
			this.d = (int)base.Font.GetGlyphWidth('\u3000');
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

		// Token: 0x06003279 RID: 12921 RVA: 0x001C18FC File Offset: 0x001C08FC
		public override TextLineList GetOverflow(float width, float height)
		{
			base.SetLines(false);
			TextLineList result;
			if (base.LineCount == base.VisibleLineCount)
			{
				if (this.s > this.t)
				{
					result = null;
				}
				else
				{
					result = new agb(this.j, width, height, this.o, this)
					{
						u = this.u,
						t = this.t
					};
				}
			}
			else
			{
				result = new agb(base[base.VisibleLineCount].Start, width, height, base[base.VisibleLineCount].NewParagraph, this)
				{
					u = this.u,
					t = this.t
				};
			}
			return result;
		}

		// Token: 0x0600327A RID: 12922 RVA: 0x001C19BC File Offset: 0x001C09BC
		public override bool HasOverflow()
		{
			base.SetLines(false);
			return base.LineCount != base.VisibleLineCount || this.s <= this.t;
		}

		// Token: 0x0600327B RID: 12923 RVA: 0x001C1A02 File Offset: 0x001C0A02
		public override string GetOverflowText()
		{
			throw new GeneratorException("This method is not supported when character shapping is enabled.");
		}

		// Token: 0x0600327C RID: 12924 RVA: 0x001C1A10 File Offset: 0x001C0A10
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

		// Token: 0x0600327D RID: 12925 RVA: 0x001C1AB8 File Offset: 0x001C0AB8
		private void d()
		{
			bool flag = false;
			char c = this.u.b(this.u.a(this.s++).a());
			while ((c > '\0' && c <= ' ') || c == '\u3000')
			{
				char c2 = c;
				switch (c2)
				{
				case '\t':
					goto IL_69;
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
					goto IL_100;
				case '\r':
					this.c();
					flag = true;
					break;
				default:
					if (c2 == ' ')
					{
						goto IL_69;
					}
					if (c2 != '\u3000')
					{
						goto IL_100;
					}
					this.e++;
					this.f++;
					this.g += this.d;
					flag = false;
					break;
				}
				IL_104:
				if (this.s == this.t)
				{
					this.s++;
					break;
				}
				if (this.s <= this.t)
				{
					c = this.u.b(this.u.a(this.s++).a());
					continue;
				}
				return;
				IL_69:
				this.e++;
				this.f++;
				this.g += this.c;
				flag = false;
				goto IL_104;
				IL_100:
				flag = false;
				goto IL_104;
			}
			this.s--;
		}

		// Token: 0x0600327E RID: 12926 RVA: 0x001C1C68 File Offset: 0x001C0C68
		private void c()
		{
			this.k += this.h + this.f;
			this.l += this.i + this.g;
			base.Add(new TextLine(this.j, this.k, this.l, this.n, this.e, this.o, true, false));
			this.j = this.s;
			this.e = 0;
			this.f = 0;
			this.g = 0;
			this.k = 0;
			this.l = 0;
			this.m = this.a - this.b;
			this.n += base.Leading + base.ParagraphSpacing;
			this.o = true;
		}

		// Token: 0x0600327F RID: 12927 RVA: 0x001C1D40 File Offset: 0x001C0D40
		private void b()
		{
			base.Add(new TextLine(this.j, this.k, this.l, this.n, this.e - this.f, this.o, false, false));
			this.j = this.s - this.h;
			this.e = 0;
			this.f = 0;
			this.g = 0;
			this.k = 0;
			this.l = 0;
			this.m = this.a;
			this.n += base.Leading;
			this.o = false;
		}

		// Token: 0x06003280 RID: 12928 RVA: 0x001C1DE4 File Offset: 0x001C0DE4
		private void a()
		{
			if (this.s <= this.t)
			{
				char c = this.u.b(this.u.a(this.s).a());
				while ((c == '\0' || c > ' ') && c != '\u3000')
				{
					int num;
					if (!this.q)
					{
						if (this.s - this.j > 0 && this.s < this.u.a())
						{
							num = (int)base.Font.jf(this.u.a(this.s)) + this.u.a(this.s).e();
						}
						else
						{
							num = (int)base.Font.jf(this.u.a(this.s));
						}
					}
					else if (this.s < this.u.a() - 1)
					{
						num = (int)base.Font.jf(this.u.a(this.s)) + this.u.a(this.s).e();
					}
					else
					{
						num = (int)base.Font.jf(this.u.a(this.s));
					}
					if (this.h != 0 && this.i + num > this.m)
					{
						if (this.k != 0)
						{
							this.b();
						}
						this.k = this.h;
						this.l = this.i;
						this.h = 0;
						this.i = 0;
					}
					this.s++;
					this.h++;
					this.i += num;
					if (this.s > this.t)
					{
						break;
					}
					if (this.b(c))
					{
						break;
					}
					if (this.a(c))
					{
						if (this.s == 1 && !this.b(this.u.b(this.u.a(this.s).a())))
						{
							break;
						}
						if (this.s > 1 && !this.c(this.u.b(this.u.a(this.s - 2).a())) && !this.b(this.u.b(this.u.a(this.s).a())))
						{
							break;
						}
					}
					c = this.u.b(this.u.a(this.s).a());
				}
				if ((c > '\0' && c <= ' ') || c == '\u3000')
				{
					if (!this.q)
					{
						if (c != '\n' && c != '\r')
						{
							if (this.s - this.j > 0 && this.s < this.u.a())
							{
								this.i += this.u.a(this.s).e();
							}
						}
					}
					else if (this.s < this.u.a() - 1)
					{
						this.i += this.u.a(this.s).e();
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

		// Token: 0x06003281 RID: 12929 RVA: 0x001C2270 File Offset: 0x001C1270
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

		// Token: 0x06003282 RID: 12930 RVA: 0x001C249C File Offset: 0x001C149C
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

		// Token: 0x06003283 RID: 12931 RVA: 0x001C2824 File Offset: 0x001C1824
		private bool a(char A_0)
		{
			return A_0 >= '⺀' && (A_0 <= '힯' || (A_0 >= '豈' && A_0 <= '﫿'));
		}

		// Token: 0x04001793 RID: 6035
		private new int a;

		// Token: 0x04001794 RID: 6036
		private new int b;

		// Token: 0x04001795 RID: 6037
		private new int c;

		// Token: 0x04001796 RID: 6038
		private int d;

		// Token: 0x04001797 RID: 6039
		private int e = 0;

		// Token: 0x04001798 RID: 6040
		private int f = 0;

		// Token: 0x04001799 RID: 6041
		private new int g = 0;

		// Token: 0x0400179A RID: 6042
		private int h = 0;

		// Token: 0x0400179B RID: 6043
		private int i = 0;

		// Token: 0x0400179C RID: 6044
		private new int j = 0;

		// Token: 0x0400179D RID: 6045
		private new int k = 0;

		// Token: 0x0400179E RID: 6046
		private int l;

		// Token: 0x0400179F RID: 6047
		private int m;

		// Token: 0x040017A0 RID: 6048
		private float n;

		// Token: 0x040017A1 RID: 6049
		private bool o;

		// Token: 0x040017A2 RID: 6050
		private bool p;

		// Token: 0x040017A3 RID: 6051
		private bool q = false;

		// Token: 0x040017A4 RID: 6052
		private static bool r = true;

		// Token: 0x040017A5 RID: 6053
		private int s;

		// Token: 0x040017A6 RID: 6054
		private int t;

		// Token: 0x040017A7 RID: 6055
		private agd u = null;
	}
}
