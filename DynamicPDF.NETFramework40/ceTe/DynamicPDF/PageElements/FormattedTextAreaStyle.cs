using System;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000728 RID: 1832
	public class FormattedTextAreaStyle
	{
		// Token: 0x06004920 RID: 18720 RVA: 0x002592D4 File Offset: 0x002582D4
		public FormattedTextAreaStyle(FontFamily fontFamily, float fontSize, bool preserveWhiteSpace)
		{
			this.Bold = false;
			this.Italic = false;
			this.Underline = false;
			this.TextRise = 0f;
			this.Font = new FormattedTextAreaStyle.FontStyle(fontFamily, fontSize, Grayscale.Black);
			this.Paragraph = new FormattedTextAreaStyle.ParagraphStyle(0f, 0f, 0f, 0f, 0f, TextAlign.Left, false, preserveWhiteSpace);
			this.Line = new FormattedTextAreaStyle.LineStyle(fontFamily.Regular.GetDescender(fontSize) + fontSize, LineLeadingType.Auto);
		}

		// Token: 0x06004921 RID: 18721 RVA: 0x00259360 File Offset: 0x00258360
		internal FormattedTextAreaStyle(FormattedTextAreaStyle A_0)
		{
			this.Bold = A_0.Bold;
			this.Italic = A_0.Italic;
			this.Underline = A_0.Underline;
			this.TextRise = A_0.TextRise;
			this.Font = A_0.Font;
			this.Paragraph = A_0.Paragraph;
			this.Line = A_0.Line;
		}

		// Token: 0x06004922 RID: 18722 RVA: 0x002593CC File Offset: 0x002583CC
		public override bool Equals(object obj)
		{
			return obj is FormattedTextAreaStyle && this.Bold == ((FormattedTextAreaStyle)obj).Bold && this.Italic == ((FormattedTextAreaStyle)obj).Italic && this.Underline == ((FormattedTextAreaStyle)obj).Underline && this.TextRise == ((FormattedTextAreaStyle)obj).TextRise && this.Font.Equals(((FormattedTextAreaStyle)obj).Font) && this.Line.Equals(((FormattedTextAreaStyle)obj).Line) && this.Paragraph.Equals(((FormattedTextAreaStyle)obj).Paragraph);
		}

		// Token: 0x06004923 RID: 18723 RVA: 0x002594A8 File Offset: 0x002584A8
		public override int GetHashCode()
		{
			return this.Bold.GetHashCode() ^ this.Italic.GetHashCode() ^ this.Underline.GetHashCode() ^ this.TextRise.GetHashCode() ^ this.Font.GetHashCode() ^ this.Line.GetHashCode() ^ this.Paragraph.GetHashCode();
		}

		// Token: 0x06004924 RID: 18724 RVA: 0x00259520 File Offset: 0x00258520
		public Font GetFont()
		{
			Font result;
			if (this.Bold)
			{
				if (this.Italic)
				{
					result = this.Font.Face.BoldItalic;
				}
				else
				{
					result = this.Font.Face.Bold;
				}
			}
			else if (this.Italic)
			{
				result = this.Font.Face.Italic;
			}
			else
			{
				result = this.Font.Face.Regular;
			}
			return result;
		}

		// Token: 0x040027DF RID: 10207
		public bool Bold;

		// Token: 0x040027E0 RID: 10208
		public bool Italic;

		// Token: 0x040027E1 RID: 10209
		public bool Underline;

		// Token: 0x040027E2 RID: 10210
		public FormattedTextAreaStyle.ParagraphStyle Paragraph;

		// Token: 0x040027E3 RID: 10211
		public FormattedTextAreaStyle.FontStyle Font;

		// Token: 0x040027E4 RID: 10212
		public FormattedTextAreaStyle.LineStyle Line;

		// Token: 0x040027E5 RID: 10213
		public float TextRise;

		// Token: 0x02000729 RID: 1833
		public struct ParagraphStyle
		{
			// Token: 0x06004925 RID: 18725 RVA: 0x002595A4 File Offset: 0x002585A4
			internal ParagraphStyle(float A_0, float A_1, float A_2, float A_3, float A_4, TextAlign A_5, bool A_6, bool A_7)
			{
				this.SpacingBefore = A_0;
				this.SpacingAfter = A_1;
				this.Indent = A_2;
				this.LeftIndent = A_3;
				this.RightIndent = A_4;
				this.Align = A_5;
				this.AllowOrphanLines = A_6;
				this.PreserveWhiteSpace = A_7;
			}

			// Token: 0x06004926 RID: 18726 RVA: 0x002595E4 File Offset: 0x002585E4
			public override bool Equals(object obj)
			{
				return obj is FormattedTextAreaStyle.ParagraphStyle && this.SpacingBefore == ((FormattedTextAreaStyle.ParagraphStyle)obj).SpacingBefore && this.SpacingAfter == ((FormattedTextAreaStyle.ParagraphStyle)obj).SpacingAfter && this.Indent == ((FormattedTextAreaStyle.ParagraphStyle)obj).Indent && this.LeftIndent == ((FormattedTextAreaStyle.ParagraphStyle)obj).LeftIndent && this.RightIndent == ((FormattedTextAreaStyle.ParagraphStyle)obj).RightIndent && this.Align == ((FormattedTextAreaStyle.ParagraphStyle)obj).Align && this.AllowOrphanLines == ((FormattedTextAreaStyle.ParagraphStyle)obj).AllowOrphanLines && this.PreserveWhiteSpace == ((FormattedTextAreaStyle.ParagraphStyle)obj).PreserveWhiteSpace;
			}

			// Token: 0x06004927 RID: 18727 RVA: 0x002596A0 File Offset: 0x002586A0
			public override int GetHashCode()
			{
				return this.SpacingBefore.GetHashCode() ^ this.SpacingAfter.GetHashCode() ^ this.Indent.GetHashCode() ^ this.LeftIndent.GetHashCode() ^ this.RightIndent.GetHashCode() ^ this.Align.GetHashCode() ^ this.AllowOrphanLines.GetHashCode() ^ this.PreserveWhiteSpace.GetHashCode();
			}

			// Token: 0x040027E6 RID: 10214
			public float SpacingBefore;

			// Token: 0x040027E7 RID: 10215
			public float SpacingAfter;

			// Token: 0x040027E8 RID: 10216
			public float Indent;

			// Token: 0x040027E9 RID: 10217
			public float LeftIndent;

			// Token: 0x040027EA RID: 10218
			public float RightIndent;

			// Token: 0x040027EB RID: 10219
			public TextAlign Align;

			// Token: 0x040027EC RID: 10220
			public bool AllowOrphanLines;

			// Token: 0x040027ED RID: 10221
			public bool PreserveWhiteSpace;
		}

		// Token: 0x0200072A RID: 1834
		public struct LineStyle
		{
			// Token: 0x06004928 RID: 18728 RVA: 0x00259716 File Offset: 0x00258716
			internal LineStyle(float A_0, LineLeadingType A_1)
			{
				this.Leading = A_0;
				this.LeadingType = A_1;
			}

			// Token: 0x06004929 RID: 18729 RVA: 0x00259728 File Offset: 0x00258728
			public override bool Equals(object obj)
			{
				return obj is FormattedTextAreaStyle.LineStyle && this.Leading == ((FormattedTextAreaStyle.LineStyle)obj).Leading && this.LeadingType == ((FormattedTextAreaStyle.LineStyle)obj).LeadingType;
			}

			// Token: 0x0600492A RID: 18730 RVA: 0x0025976C File Offset: 0x0025876C
			public override int GetHashCode()
			{
				return this.Leading.GetHashCode() ^ this.LeadingType.GetHashCode();
			}

			// Token: 0x040027EE RID: 10222
			public float Leading;

			// Token: 0x040027EF RID: 10223
			public LineLeadingType LeadingType;
		}

		// Token: 0x0200072B RID: 1835
		public struct FontStyle
		{
			// Token: 0x0600492B RID: 18731 RVA: 0x0025979A File Offset: 0x0025879A
			internal FontStyle(FontFamily A_0, float A_1, Color A_2)
			{
				this.Face = A_0;
				this.Size = A_1;
				this.Color = A_2;
			}

			// Token: 0x0600492C RID: 18732 RVA: 0x002597B4 File Offset: 0x002587B4
			public override bool Equals(object obj)
			{
				return obj is FormattedTextAreaStyle.FontStyle && this.Face == ((FormattedTextAreaStyle.FontStyle)obj).Face && this.Size == ((FormattedTextAreaStyle.FontStyle)obj).Size && this.Color.Equals(((FormattedTextAreaStyle.FontStyle)obj).Color);
			}

			// Token: 0x0600492D RID: 18733 RVA: 0x00259810 File Offset: 0x00258810
			public override int GetHashCode()
			{
				return this.Face.GetHashCode() ^ this.Size.GetHashCode() ^ this.Color.GetHashCode();
			}

			// Token: 0x040027F0 RID: 10224
			public FontFamily Face;

			// Token: 0x040027F1 RID: 10225
			public float Size;

			// Token: 0x040027F2 RID: 10226
			public Color Color;
		}
	}
}
