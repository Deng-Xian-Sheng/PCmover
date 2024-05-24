using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;
using ceTe.DynamicPDF.ReportWriter.IO;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x0200036E RID: 878
	internal class w1 : LayoutWriter
	{
		// Token: 0x06002566 RID: 9574 RVA: 0x0015E0F8 File Offset: 0x0015D0F8
		internal w1(Report A_0, wu A_1)
		{
			this.d = A_0;
			this.h = A_1;
			this.j = new StructureElement(new NamedTagType(A_0.Id, TagType.Part));
		}

		// Token: 0x06002567 RID: 9575 RVA: 0x0015E164 File Offset: 0x0015D164
		internal override wu ez()
		{
			return this.h;
		}

		// Token: 0x06002568 RID: 9576 RVA: 0x0015E17C File Offset: 0x0015D17C
		internal override void e0()
		{
			RecordSet a_ = this.d.Query.e(this);
			this.RecordSets.a(a_);
			this.a = new xp(this, this.d.Header);
			this.b = new xo(this, this.d.Footer);
			this.e = this.d.d().Body.Height - this.d.Footer.Height;
			this.f = x5.a(this.e - this.d.Header.Height);
			short num = 0;
			bool a_2 = false;
			bool flag = this.d.Detail.Elements.g();
			if (this.d.Detail.AutoSplit || flag)
			{
				for (int i = 0; i < this.d.Detail.Elements.Count; i++)
				{
					if (this.d.Detail.Elements[i].gp())
					{
						for (int j = 0; j < this.d.Detail.Elements.Count; j++)
						{
							if (this.d.Detail.Elements[j].gj() && x5.d(this.d.Detail.Elements[i].gm(), this.d.Detail.Elements[j].gn()) && x5.a(this.d.Detail.Elements[i].gn(), this.d.Detail.Elements[j].gn()))
							{
								if (this.d.Detail.Elements[j].gk() == -32768)
								{
									ReportElement reportElement = this.d.Detail.Elements[j];
									short num2 = num;
									num = num2 + 1;
									reportElement.gl(num2);
									a_2 = true;
								}
								this.d.Detail.Elements[i].gq(this.d.Detail.Elements[j].gk());
							}
						}
					}
				}
				xw xw = this.d.f();
				if (xw != null && xw.e())
				{
					sz sz = xw.d();
					sz.a a = sz.a();
					while (a != null)
					{
						string text = a.a.c();
						ReportElement reportElement2;
						if (text == null || text == string.Empty)
						{
							reportElement2 = this.d.Detail.Elements[0];
						}
						else
						{
							if (!this.d.p().Contains(text))
							{
								throw new ReportWriterException("The " + text + " reportelement does not exist in the detail of " + this.d.Id);
							}
							reportElement2 = this.d.DocumentLayout.GetReportElementById(text);
						}
						if (reportElement2.gk() == -32768)
						{
							ReportElement reportElement3 = reportElement2;
							short num3 = num;
							num = num3 + 1;
							reportElement3.gl(num3);
						}
						if (xw.g().Contains(reportElement2.gk()))
						{
							sz sz2 = (sz)xw.g()[reportElement2.gk()];
							sz2.a(a.a);
							a = a.b;
						}
						else
						{
							sz sz2 = new sz();
							sz2.a(a.a);
							xw.g().Add(reportElement2.gk(), sz2);
							a = a.b;
						}
					}
				}
				for (int i = 0; i < this.d.Detail.Elements.Count; i++)
				{
					if (this.d.Detail.Elements[i].fk() == 61443)
					{
						NoSplitZone noSplitZone = (NoSplitZone)this.d.Detail.Elements[i];
						if (x5.c(noSplitZone.gm(), x5.a()) && x5.c(noSplitZone.gn(), x5.a()))
						{
							for (int j = 0; j < this.d.Detail.Elements.Count; j++)
							{
								if (j != i && this.d.Detail.Elements[j].fk() == 61443)
								{
									NoSplitZone noSplitZone2 = (NoSplitZone)this.d.Detail.Elements[j];
									if (x5.c(noSplitZone2.gm(), x5.a()) && x5.c(noSplitZone2.gn(), x5.a()))
									{
										if (x5.c(noSplitZone.gn(), noSplitZone2.gm()) && x5.d(noSplitZone.gm(), noSplitZone2.gm()))
										{
											noSplitZone.b(noSplitZone2.gn());
											noSplitZone2.a(x5.a());
											noSplitZone2.b(x5.a());
											break;
										}
										if (x5.c(noSplitZone2.gn(), noSplitZone.gm()) && x5.d(noSplitZone2.gm(), noSplitZone.gm()))
										{
											noSplitZone.a(noSplitZone2.gm());
											noSplitZone2.a(x5.a());
											noSplitZone2.b(x5.a());
											break;
										}
									}
								}
							}
						}
					}
				}
				for (int i = 0; i < this.d.Detail.Elements.Count; i++)
				{
					if (this.d.Detail.Elements[i].fk() == 61443)
					{
						NoSplitZone noSplitZone = (NoSplitZone)this.d.Detail.Elements[i];
						if (x5.c(noSplitZone.gm(), x5.a()) && x5.c(noSplitZone.gn(), x5.a()))
						{
							for (int j = 0; j < this.d.Detail.Elements.Count; j++)
							{
								if (j != i && this.d.Detail.Elements[j].fj())
								{
									if (x5.b(this.d.Detail.Elements[j].gm(), noSplitZone.gm()) && x5.a(this.d.Detail.Elements[j].gn(), noSplitZone.gn()))
									{
										if (this.d.Detail.Elements[j].gk() == -32768)
										{
											ReportElement reportElement4 = this.d.Detail.Elements[j];
											short num4 = num;
											num = num4 + 1;
											reportElement4.gl(num4);
										}
										this.d.Detail.Elements[i].go(this.d.Detail.Elements[j].gk(), wx.d);
									}
									else if (x5.d(this.d.Detail.Elements[j].gm(), noSplitZone.gm()) && x5.c(this.d.Detail.Elements[j].gn(), noSplitZone.gm()))
									{
										if (this.d.Detail.Elements[j].gk() == -32768)
										{
											ReportElement reportElement5 = this.d.Detail.Elements[j];
											short num5 = num;
											num = num5 + 1;
											reportElement5.gl(num5);
										}
										this.d.Detail.Elements[i].go(this.d.Detail.Elements[j].gk(), wx.c);
									}
									else if (x5.a(this.d.Detail.Elements[j].gm(), noSplitZone.gm()) && x5.b(this.d.Detail.Elements[j].gn(), noSplitZone.gn()))
									{
										if (this.d.Detail.Elements[j].gk() == -32768)
										{
											ReportElement reportElement6 = this.d.Detail.Elements[j];
											short num6 = num;
											num = num6 + 1;
											reportElement6.gl(num6);
										}
										this.d.Detail.Elements[i].go(this.d.Detail.Elements[j].gk(), wx.b);
									}
									else if (x5.d(this.d.Detail.Elements[j].gm(), noSplitZone.gn()) && x5.c(this.d.Detail.Elements[j].gn(), noSplitZone.gn()))
									{
										if (this.d.Detail.Elements[j].gk() == -32768)
										{
											ReportElement reportElement7 = this.d.Detail.Elements[j];
											short num7 = num;
											num = num7 + 1;
											reportElement7.gl(num7);
										}
										this.d.Detail.Elements[i].go(this.d.Detail.Elements[j].gk(), wx.a);
									}
								}
							}
						}
					}
				}
			}
			this.c = new xd(this.d);
			int num8 = -1;
			do
			{
				xh xh = this.d.Detail.a(this);
				xh.gd(++num8);
				this.c.a(xh);
				this.e3();
				SubReport.a(this, this.d.o());
			}
			while (this.RecordSets.Current.d8(this));
			if (this.d.n() != null)
			{
				this.i = new xv(this, this.d.n());
			}
			sz sz3 = this.d.c();
			if (sz3 != null && sz3.b() > 0)
			{
				sz3.b(this);
			}
			if (this.e2() != null)
			{
				this.e2().a(this, false);
			}
			if (this.d.o() != null)
			{
				ws.a(this.c);
			}
			for (xh xh2 = (xh)this.c.e(); xh2 != null; xh2 = (xh)xh2.e())
			{
				xh2.c();
			}
			w0 w = new w0(this.f, this.d, false);
			w.a(this.c, this.d, this.h, this, a_2, flag);
			if (this.d.f() != null)
			{
				PageList pages = this.h.Document.Pages;
				for (int k = 0; k < pages.Count; k++)
				{
					if (!(pages[k] is rt))
					{
						((xq)pages[k]).a(this.h);
					}
				}
			}
			this.d.Query.a(this, this.RecordSets.Current);
			this.RecordSets.a();
		}

		// Token: 0x06002569 RID: 9577 RVA: 0x0015EF30 File Offset: 0x0015DF30
		internal override tl e1()
		{
			return this.h.e1();
		}

		// Token: 0x0600256A RID: 9578 RVA: 0x0015EF50 File Offset: 0x0015DF50
		internal override tm e2()
		{
			return this.h.e2();
		}

		// Token: 0x0600256B RID: 9579 RVA: 0x0015EF70 File Offset: 0x0015DF70
		internal StructureElement a()
		{
			return this.j;
		}

		// Token: 0x0600256C RID: 9580 RVA: 0x0015EF88 File Offset: 0x0015DF88
		public override RecordSetStack get_RecordSets()
		{
			return this.h.RecordSets;
		}

		// Token: 0x0600256D RID: 9581 RVA: 0x0015EFA8 File Offset: 0x0015DFA8
		public override Document get_Document()
		{
			return this.h.Document;
		}

		// Token: 0x0600256E RID: 9582 RVA: 0x0015EFC8 File Offset: 0x0015DFC8
		public override ParameterDictionary get_Parameters()
		{
			return this.h.Parameters;
		}

		// Token: 0x0600256F RID: 9583 RVA: 0x0015EFE8 File Offset: 0x0015DFE8
		public override DocumentLayout get_DocumentLayout()
		{
			return this.h.DocumentLayout;
		}

		// Token: 0x06002570 RID: 9584 RVA: 0x0015F008 File Offset: 0x0015E008
		internal float b()
		{
			return this.e;
		}

		// Token: 0x06002571 RID: 9585 RVA: 0x0015F020 File Offset: 0x0015E020
		internal Report c()
		{
			return this.d;
		}

		// Token: 0x06002572 RID: 9586 RVA: 0x0015F038 File Offset: 0x0015E038
		internal xp d()
		{
			return this.a;
		}

		// Token: 0x06002573 RID: 9587 RVA: 0x0015F050 File Offset: 0x0015E050
		internal xo e()
		{
			return this.b;
		}

		// Token: 0x06002574 RID: 9588 RVA: 0x0015F068 File Offset: 0x0015E068
		internal override void e3()
		{
			if (this.g == AlternateRow.Odd)
			{
				this.g = AlternateRow.Even;
			}
			else
			{
				this.g = AlternateRow.Odd;
			}
		}

		// Token: 0x06002575 RID: 9589 RVA: 0x0015F09C File Offset: 0x0015E09C
		internal override AlternateRow e4()
		{
			return this.g;
		}

		// Token: 0x06002576 RID: 9590 RVA: 0x0015F0B4 File Offset: 0x0015E0B4
		internal override void e5(AlternateRow A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06002577 RID: 9591 RVA: 0x0015F0C0 File Offset: 0x0015E0C0
		internal override float e6()
		{
			return this.d.d().Body.Width;
		}

		// Token: 0x06002578 RID: 9592 RVA: 0x0015F0E8 File Offset: 0x0015E0E8
		internal override xv e7()
		{
			return this.i;
		}

		// Token: 0x0400107A RID: 4218
		private xp a = null;

		// Token: 0x0400107B RID: 4219
		private xo b = null;

		// Token: 0x0400107C RID: 4220
		private xd c = null;

		// Token: 0x0400107D RID: 4221
		private Report d;

		// Token: 0x0400107E RID: 4222
		private float e;

		// Token: 0x0400107F RID: 4223
		private x5 f;

		// Token: 0x04001080 RID: 4224
		private AlternateRow g = AlternateRow.Odd;

		// Token: 0x04001081 RID: 4225
		private wu h;

		// Token: 0x04001082 RID: 4226
		private xv i = null;

		// Token: 0x04001083 RID: 4227
		private StructureElement j = null;
	}
}
