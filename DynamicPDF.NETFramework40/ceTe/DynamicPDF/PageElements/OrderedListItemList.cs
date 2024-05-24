using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000739 RID: 1849
	public class OrderedListItemList : ListItemList
	{
		// Token: 0x06004A5C RID: 19036 RVA: 0x0025F71D File Offset: 0x0025E71D
		internal OrderedListItemList(OrderedSubList A_0) : base(A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06004A5D RID: 19037 RVA: 0x0025F730 File Offset: 0x0025E730
		internal void a(PageWriter A_0, float A_1, float A_2, string A_3, ListItem A_4)
		{
			A_0.SetTextMode();
			if (A_0.Document.Tag != null)
			{
				DocumentWriter documentWriter = A_0.DocumentWriter;
				documentWriter.i(documentWriter.ae() + 1);
				A_4.BulletTag.f(A_0, A_4, A_1, A_2);
			}
			Color textOutlineColor = A_4.TextOutlineColor;
			float textOutlineWidth = A_4.TextOutlineWidth;
			Color textColor = A_4.TextColor;
			if (textOutlineColor != null && textOutlineWidth > 0f)
			{
				if (textColor != null)
				{
					A_0.SetTextRenderingMode(TextRenderingMode.FillAndStroke);
					A_0.SetStrokeColor(textOutlineColor);
					A_0.SetFillColor(textColor);
				}
				else
				{
					A_0.SetTextRenderingMode(TextRenderingMode.Stroke);
					A_0.SetStrokeColor(textOutlineColor);
				}
				A_0.SetLineWidth(textOutlineWidth);
			}
			else if (textColor != null)
			{
				A_0.SetTextRenderingMode(TextRenderingMode.Fill);
				A_0.SetFillColor(textColor);
			}
			else
			{
				A_0.SetTextRenderingMode(TextRenderingMode.Invisible);
			}
			if (A_4.BulletSize == 0f)
			{
				this.b = A_4.FontSize;
			}
			else
			{
				this.b = A_4.BulletSize;
			}
			A_0.SetFont(A_4.Font, this.b);
			switch (A_4.BulletAlign)
			{
			case Align.Center:
				if (!A_4.RightToLeft)
				{
					A_1 = A_1 + A_4.BulletAreaWidth / 2f - A_4.Font.GetTextWidth(A_3, this.b) / 2f;
				}
				else
				{
					A_1 = A_1 - A_4.BulletAreaWidth / 2f + A_4.Font.GetTextWidth(A_3, this.b) / 2f;
				}
				break;
			case Align.Right:
				if (!A_4.RightToLeft)
				{
					A_1 = A_1 + A_4.BulletAreaWidth - A_4.Font.GetTextWidth(A_3, this.b);
				}
				else
				{
					A_1 = A_1 - A_4.BulletAreaWidth + A_4.Font.GetTextWidth(A_3, this.b);
				}
				break;
			}
			float y = A_2 + A_4.Font.GetBaseLine(A_4.FontSize, A_4.Leading);
			if (A_4.RightToLeft)
			{
				A_1 = A_1 + A_4.LeftIndent + A_4.RightIndent + A_4.h();
				A_0.Write_Tm(A_1 - A_4.Font.GetTextWidth(A_3, this.b), y);
			}
			else
			{
				A_0.Write_Tm(A_1, y);
			}
			A_0.b(A_3.ToCharArray(), 0, A_3.Length, A_4.RightToLeft);
			if (A_0.Document.Tag != null)
			{
				Tag.a(A_0);
			}
		}

		// Token: 0x06004A5E RID: 19038 RVA: 0x0025F9EC File Offset: 0x0025E9EC
		internal override float i8(PageWriter A_0, float A_1, float A_2, ae7 A_3, float A_4)
		{
			ae6 ae = new ae6(this.a.c());
			int num = 0;
			int num2 = 0;
			ae7 a_ = A_3;
			if (A_3 != null)
			{
				object obj = A_3.e();
				if (obj != null)
				{
					num = (int)obj;
					ae.s(num);
				}
				a_ = A_3.f();
				if (A_3.a() - 2 == A_3.b())
				{
					num2 = (int)A_3.c();
				}
			}
			int i = num;
			while (i <= base.Count - 1)
			{
				ListItem listItem = base[i];
				if (A_3 != null)
				{
					if (A_3.b() < A_3.a() - 2)
					{
						num2 = -1;
					}
					else if (A_3.a() - 1 == A_3.b())
					{
						num2 = 0;
					}
				}
				if (A_0.Document.Tag != null)
				{
					bool a_2 = listItem.aa() == 1 && listItem.Leading + listItem.u() + listItem.s() > A_4 && num2 == 0;
					base.a(A_0, listItem, A_1, A_2, a_2);
				}
				float num3 = listItem.a(a_);
				if (num3 < A_4 || (A_4 == base.b() && listItem.ad() == 1))
				{
					string a_3 = this.a.BulletPrefix + new string(ae.a()) + this.a.BulletSuffix;
					if (num2 == 0)
					{
						if (this.a.c() != NumberingStyle.None)
						{
							this.a(A_0, A_1, A_2 + listItem.u(), a_3, listItem);
						}
					}
					A_2 = listItem.a(A_0, A_1, A_2, A_4, A_3);
					A_4 -= num3;
					i++;
				}
				else
				{
					if (listItem.aa() > 1 && listItem.Leading + listItem.u() > A_4 && num2 == 0 && (A_4 != base.b() || base.b() < 0f))
					{
						break;
					}
					if (listItem.aa() == 1 && listItem.Leading + listItem.u() + listItem.s() > A_4 && num2 == 0 && (A_4 != base.b() || base.b() < 0f))
					{
						break;
					}
					if (num2 > 0 && listItem.Leading > A_4 && (A_4 != base.b() || base.b() < 0f))
					{
						break;
					}
					if (num2 == 0)
					{
						if (this.a.c() != NumberingStyle.None)
						{
							string a_3 = this.a.BulletPrefix + new string(ae.a()) + this.a.BulletSuffix;
							this.a(A_0, A_1, A_2 + listItem.u(), a_3, listItem);
						}
					}
					listItem.a(base.b());
					A_2 = listItem.a(A_0, A_1, A_2, A_4, A_3);
					break;
				}
			}
			return A_2;
		}

		// Token: 0x04002868 RID: 10344
		private new OrderedSubList a;

		// Token: 0x04002869 RID: 10345
		private float b;
	}
}
