using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.ReportElements;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000346 RID: 838
	internal class vz : vr
	{
		// Token: 0x060023C2 RID: 9154 RVA: 0x00152A0C File Offset: 0x00151A0C
		internal vz(wd A_0)
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
							this.a = A_0.a8();
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
				throw new DplxParseException("A formattedRecordArea element contains an invalid attribute.");
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
			ceTe.DynamicPDF.ReportWriter.FontFamilyList fontFamilyList = A_0.ap();
			this.l = fontFamilyList.a();
		}

		// Token: 0x060023C3 RID: 9155 RVA: 0x00152C14 File Offset: 0x00151C14
		internal override ReportElement fz(rm A_0)
		{
			return new FormattedRecordArea(A_0, this);
		}

		// Token: 0x060023C4 RID: 9156 RVA: 0x00152C30 File Offset: 0x00151C30
		private void d(wd A_0)
		{
			A_0.aa();
			if (A_0.y())
			{
				throw new DplxParseException("A formattedRecordArea element contains an invalid attribute.");
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

		// Token: 0x060023C5 RID: 9157 RVA: 0x00152CE8 File Offset: 0x00151CE8
		private void c(wd A_0)
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
				throw new DplxParseException("A formattedRecordArea font element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060023C6 RID: 9158 RVA: 0x00152DB0 File Offset: 0x00151DB0
		private void b(wd A_0)
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
							throw new DplxParseException("A formattedRecordArea line element contains an invalid attribute.");
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

		// Token: 0x060023C7 RID: 9159 RVA: 0x00152E48 File Offset: 0x00151E48
		private void a(wd A_0)
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
				throw new DplxParseException("A formattedRecordArea paragraph element contains an invalid attribute.");
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x060023C8 RID: 9160 RVA: 0x00152FF0 File Offset: 0x00151FF0
		internal override string f0()
		{
			return this.a;
		}

		// Token: 0x060023C9 RID: 9161 RVA: 0x00153008 File Offset: 0x00152008
		internal float a()
		{
			return this.b;
		}

		// Token: 0x060023CA RID: 9162 RVA: 0x00153020 File Offset: 0x00152020
		internal tu b()
		{
			return this.c;
		}

		// Token: 0x060023CB RID: 9163 RVA: 0x00153038 File Offset: 0x00152038
		internal bool c()
		{
			return this.h;
		}

		// Token: 0x060023CC RID: 9164 RVA: 0x00153050 File Offset: 0x00152050
		internal bool d()
		{
			return this.i;
		}

		// Token: 0x060023CD RID: 9165 RVA: 0x00153068 File Offset: 0x00152068
		internal x5 e()
		{
			return this.f;
		}

		// Token: 0x060023CE RID: 9166 RVA: 0x00153080 File Offset: 0x00152080
		internal x5 f()
		{
			return this.g;
		}

		// Token: 0x060023CF RID: 9167 RVA: 0x00153098 File Offset: 0x00152098
		internal x5 g()
		{
			return this.e;
		}

		// Token: 0x060023D0 RID: 9168 RVA: 0x001530B0 File Offset: 0x001520B0
		internal x5 h()
		{
			return this.d;
		}

		// Token: 0x060023D1 RID: 9169 RVA: 0x001530C8 File Offset: 0x001520C8
		internal FormattedTextAreaStyle i()
		{
			return this.k;
		}

		// Token: 0x060023D2 RID: 9170 RVA: 0x001530E0 File Offset: 0x001520E0
		internal VAlign j()
		{
			return this.j;
		}

		// Token: 0x060023D3 RID: 9171 RVA: 0x001530F8 File Offset: 0x001520F8
		internal ceTe.DynamicPDF.Text.FontFamilyList k()
		{
			return this.l;
		}

		// Token: 0x04000F68 RID: 3944
		private string a;

		// Token: 0x04000F69 RID: 3945
		private float b;

		// Token: 0x04000F6A RID: 3946
		private tu c;

		// Token: 0x04000F6B RID: 3947
		private x5 d;

		// Token: 0x04000F6C RID: 3948
		private x5 e;

		// Token: 0x04000F6D RID: 3949
		private x5 f;

		// Token: 0x04000F6E RID: 3950
		private x5 g;

		// Token: 0x04000F6F RID: 3951
		private bool h = false;

		// Token: 0x04000F70 RID: 3952
		private bool i = false;

		// Token: 0x04000F71 RID: 3953
		private VAlign j = VAlign.Top;

		// Token: 0x04000F72 RID: 3954
		private FormattedTextAreaStyle k = new FormattedTextAreaStyle(FontFamily.Helvetica, 12f, true);

		// Token: 0x04000F73 RID: 3955
		private ceTe.DynamicPDF.Text.FontFamilyList l = new ceTe.DynamicPDF.Text.FontFamilyList();
	}
}
