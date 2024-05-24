using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000581 RID: 1409
	internal class ak2 : akt
	{
		// Token: 0x060037B8 RID: 14264 RVA: 0x001E11B8 File Offset: 0x001E01B8
		internal ak2(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 121954641)
				{
					if (num <= 2660)
					{
						switch (num)
						{
						case 56:
							this.f = x5.a(A_0.ar());
							break;
						case 57:
							this.g = x5.a(A_0.ar());
							break;
						default:
							if (num != 2660)
							{
								goto IL_165;
							}
							this.a = A_0.a7();
							break;
						}
					}
					else if (num != 23405387)
					{
						if (num != 121954641)
						{
							goto IL_165;
						}
						this.h = A_0.av();
					}
					else
					{
						this.i = A_0.av();
					}
				}
				else if (num <= 680958428)
				{
					if (num != 565869349)
					{
						if (num != 680958428)
						{
							goto IL_165;
						}
						this.d = x5.a(A_0.ar());
					}
					else
					{
						this.b = A_0.ar();
					}
				}
				else if (num != 906414665)
				{
					if (num != 933645608)
					{
						goto IL_165;
					}
					this.e = x5.a(A_0.ar());
				}
				else
				{
					this.j = A_0.aq();
				}
				continue;
				IL_165:
				throw new DlexParseException("A formattedRecordArea element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				if (A_0.x() == 134982453)
				{
					this.d(A_0);
					A_0.aa();
				}
				if (A_0.x() == 13786676)
				{
					this.c = A_0.ax();
					A_0.aa();
				}
				A_0.aa();
			}
			ceTe.DynamicPDF.LayoutEngine.FontFamilyList fontFamilyList = A_0.ap();
			this.l = fontFamilyList.a();
		}

		// Token: 0x060037B9 RID: 14265 RVA: 0x001E13C0 File Offset: 0x001E03C0
		internal override LayoutElement mt(alo A_0)
		{
			return new FormattedRecordArea(A_0, this);
		}

		// Token: 0x060037BA RID: 14266 RVA: 0x001E13DC File Offset: 0x001E03DC
		private void d(ald A_0)
		{
			A_0.aa();
			if (A_0.y())
			{
				throw new DlexParseException("A formattedRecordArea element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				if (A_0.x() == 10156980)
				{
					this.c(A_0);
					A_0.aa();
				}
				if (A_0.x() == 11705253)
				{
					this.b(A_0);
					A_0.aa();
				}
				if (A_0.x() == 810366031)
				{
					this.a(A_0);
					A_0.aa();
				}
				A_0.aa();
			}
		}

		// Token: 0x060037BB RID: 14267 RVA: 0x001E1494 File Offset: 0x001E0494
		private void c(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 10098917)
				{
					if (num != 0)
					{
						if (num != 10098917)
						{
							goto IL_87;
						}
						this.k.Font.Face = A_0.ao();
					}
					else
					{
						A_0.aa();
					}
				}
				else if (num != 13541029)
				{
					if (num != 599706610)
					{
						goto IL_87;
					}
					this.k.Font.Color = A_0.ad();
				}
				else
				{
					this.k.Font.Size = A_0.ar();
				}
				continue;
				IL_87:
				throw new DlexParseException("A formattedRecordArea font element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060037BC RID: 14268 RVA: 0x001E155C File Offset: 0x001E055C
		private void b(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num != 0)
				{
					if (num != 34297724)
					{
						if (num != 748032654)
						{
							throw new DlexParseException("A formattedRecordArea line element contains an invalid attribute.");
						}
						this.k.Line.Leading = A_0.ar();
					}
					else
					{
						this.k.Line.LeadingType = A_0.ae();
					}
				}
				else
				{
					A_0.aa();
				}
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060037BD RID: 14269 RVA: 0x001E15F4 File Offset: 0x001E05F4
		private void a(ald A_0)
		{
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 492701743)
				{
					if (num <= 33830589)
					{
						if (num != 0)
						{
							if (num != 33830589)
							{
								goto IL_165;
							}
							this.k.Paragraph.LeftIndent = A_0.ar();
						}
						else
						{
							A_0.aa();
						}
					}
					else if (num != 492621098)
					{
						if (num != 492701743)
						{
							goto IL_165;
						}
						this.k.Paragraph.SpacingAfter = A_0.ar();
					}
					else
					{
						this.k.Paragraph.SpacingBefore = A_0.ar();
					}
				}
				else if (num <= 700074330)
				{
					if (num != 565352942)
					{
						if (num != 700074330)
						{
							goto IL_165;
						}
						this.k.Paragraph.Indent = A_0.ar();
					}
					else
					{
						this.k.Paragraph.Align = A_0.ai();
					}
				}
				else if (num != 734020888)
				{
					if (num != 858022136)
					{
						if (num != 991703918)
						{
							goto IL_165;
						}
						this.k.Paragraph.RightIndent = A_0.ar();
					}
					else
					{
						this.k.Paragraph.AllowOrphanLines = !A_0.av();
					}
				}
				else
				{
					this.k.Paragraph.PreserveWhiteSpace = A_0.av();
				}
				continue;
				IL_165:
				throw new DlexParseException("A formattedRecordArea paragraph element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060037BE RID: 14270 RVA: 0x001E179C File Offset: 0x001E079C
		internal override string mu()
		{
			return this.a;
		}

		// Token: 0x060037BF RID: 14271 RVA: 0x001E17B4 File Offset: 0x001E07B4
		internal float a()
		{
			return this.b;
		}

		// Token: 0x060037C0 RID: 14272 RVA: 0x001E17CC File Offset: 0x001E07CC
		internal air b()
		{
			return this.c;
		}

		// Token: 0x060037C1 RID: 14273 RVA: 0x001E17E4 File Offset: 0x001E07E4
		internal bool c()
		{
			return this.h;
		}

		// Token: 0x060037C2 RID: 14274 RVA: 0x001E17FC File Offset: 0x001E07FC
		internal bool d()
		{
			return this.i;
		}

		// Token: 0x060037C3 RID: 14275 RVA: 0x001E1814 File Offset: 0x001E0814
		internal x5 e()
		{
			return this.f;
		}

		// Token: 0x060037C4 RID: 14276 RVA: 0x001E182C File Offset: 0x001E082C
		internal x5 f()
		{
			return this.g;
		}

		// Token: 0x060037C5 RID: 14277 RVA: 0x001E1844 File Offset: 0x001E0844
		internal x5 g()
		{
			return this.e;
		}

		// Token: 0x060037C6 RID: 14278 RVA: 0x001E185C File Offset: 0x001E085C
		internal x5 h()
		{
			return this.d;
		}

		// Token: 0x060037C7 RID: 14279 RVA: 0x001E1874 File Offset: 0x001E0874
		internal FormattedTextAreaStyle i()
		{
			return this.k;
		}

		// Token: 0x060037C8 RID: 14280 RVA: 0x001E188C File Offset: 0x001E088C
		internal VAlign j()
		{
			return this.j;
		}

		// Token: 0x060037C9 RID: 14281 RVA: 0x001E18A4 File Offset: 0x001E08A4
		internal ceTe.DynamicPDF.Text.FontFamilyList k()
		{
			return this.l;
		}

		// Token: 0x04001A69 RID: 6761
		private string a;

		// Token: 0x04001A6A RID: 6762
		private float b;

		// Token: 0x04001A6B RID: 6763
		private air c;

		// Token: 0x04001A6C RID: 6764
		private x5 d;

		// Token: 0x04001A6D RID: 6765
		private x5 e;

		// Token: 0x04001A6E RID: 6766
		private x5 f;

		// Token: 0x04001A6F RID: 6767
		private x5 g;

		// Token: 0x04001A70 RID: 6768
		private bool h = false;

		// Token: 0x04001A71 RID: 6769
		private bool i = false;

		// Token: 0x04001A72 RID: 6770
		private VAlign j = VAlign.Top;

		// Token: 0x04001A73 RID: 6771
		private FormattedTextAreaStyle k = new FormattedTextAreaStyle(FontFamily.Helvetica, 12f, true);

		// Token: 0x04001A74 RID: 6772
		private ceTe.DynamicPDF.Text.FontFamilyList l = new ceTe.DynamicPDF.Text.FontFamilyList();
	}
}
