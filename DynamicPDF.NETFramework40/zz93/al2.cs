using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.Data;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x020005A7 RID: 1447
	internal class al2 : LayoutWriter
	{
		// Token: 0x06003978 RID: 14712 RVA: 0x001EEBF0 File Offset: 0x001EDBF0
		internal al2(Report A_0, alr A_1)
		{
			this.d = A_0;
			this.h = A_1;
			this.j = new StructureElement(new NamedTagType(A_0.Id, TagType.Part));
		}

		// Token: 0x06003979 RID: 14713 RVA: 0x001EEC5C File Offset: 0x001EDC5C
		internal override alr nc()
		{
			return this.h;
		}

		// Token: 0x0600397A RID: 14714 RVA: 0x001EEC74 File Offset: 0x001EDC74
		internal override void m3()
		{
			this.Data.a(this.d.Id, this.d.b(), this);
			this.a = new amy(this, this.d.Header);
			this.b = new amx(this, this.d.Footer);
			this.e = this.d.e().Body.Height - this.d.Footer.Height;
			this.f = x5.a(this.e - this.d.Header.Height);
			short num = 0;
			bool a_ = false;
			bool flag = this.d.Detail.Elements.g();
			if (this.d.Detail.AutoSplit || flag)
			{
				for (int i = 0; i < this.d.Detail.Elements.Count; i++)
				{
					if (this.d.Detail.Elements[i].n3())
					{
						for (int j = 0; j < this.d.Detail.Elements.Count; j++)
						{
							if (this.d.Detail.Elements[j].nv() && x5.d(this.d.Detail.Elements[i].ny(), this.d.Detail.Elements[j].nz()) && x5.a(this.d.Detail.Elements[i].nz(), this.d.Detail.Elements[j].nz()))
							{
								if (this.d.Detail.Elements[j].nw() == -32768)
								{
									LayoutElement layoutElement = this.d.Detail.Elements[j];
									short num2 = num;
									num = num2 + 1;
									layoutElement.nx(num2);
									a_ = true;
								}
								this.d.Detail.Elements[i].n4(this.d.Detail.Elements[j].nw());
							}
						}
					}
				}
				and and = this.d.h();
				if (and != null && and.e())
				{
					ahs ahs = and.d();
					ahs.a a = ahs.a();
					while (a != null)
					{
						string text = a.a.c();
						LayoutElement layoutElement2;
						if (text == null || text == string.Empty)
						{
							layoutElement2 = this.d.Detail.Elements[0];
						}
						else
						{
							if (!this.d.r().Contains(text))
							{
								throw new LayoutEngineException("The " + text + " reportelement does not exist in the detail of " + this.d.Id);
							}
							layoutElement2 = this.d.DocumentLayout.GetLayoutElementById(text);
						}
						if (layoutElement2.nw() == -32768)
						{
							LayoutElement layoutElement3 = layoutElement2;
							short num3 = num;
							num = num3 + 1;
							layoutElement3.nx(num3);
						}
						if (and.g().Contains(layoutElement2.nw()))
						{
							ahs ahs2 = (ahs)and.g()[layoutElement2.nw()];
							ahs2.a(a.a);
							a = a.b;
						}
						else
						{
							ahs ahs2 = new ahs();
							ahs2.a(a.a);
							and.g().Add(layoutElement2.nw(), ahs2);
							a = a.b;
						}
					}
				}
				for (int i = 0; i < this.d.Detail.Elements.Count; i++)
				{
					if (this.d.Detail.Elements[i].n0() == 61443)
					{
						NoSplitZone noSplitZone = (NoSplitZone)this.d.Detail.Elements[i];
						if (x5.c(noSplitZone.ny(), x5.a()) && x5.c(noSplitZone.nz(), x5.a()))
						{
							for (int j = 0; j < this.d.Detail.Elements.Count; j++)
							{
								if (j != i && this.d.Detail.Elements[j].n0() == 61443)
								{
									NoSplitZone noSplitZone2 = (NoSplitZone)this.d.Detail.Elements[j];
									if (x5.c(noSplitZone2.ny(), x5.a()) && x5.c(noSplitZone2.nz(), x5.a()))
									{
										if (x5.c(noSplitZone.nz(), noSplitZone2.ny()) && x5.d(noSplitZone.ny(), noSplitZone2.ny()))
										{
											noSplitZone.b(noSplitZone2.nz());
											noSplitZone2.a(x5.a());
											noSplitZone2.b(x5.a());
											break;
										}
										if (x5.c(noSplitZone2.nz(), noSplitZone.ny()) && x5.d(noSplitZone2.ny(), noSplitZone.ny()))
										{
											noSplitZone.a(noSplitZone2.ny());
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
					if (this.d.Detail.Elements[i].n0() == 61443)
					{
						NoSplitZone noSplitZone = (NoSplitZone)this.d.Detail.Elements[i];
						if (x5.c(noSplitZone.ny(), x5.a()) && x5.c(noSplitZone.nz(), x5.a()))
						{
							for (int j = 0; j < this.d.Detail.Elements.Count; j++)
							{
								if (j != i && this.d.Detail.Elements[j].n2())
								{
									if (x5.b(this.d.Detail.Elements[j].ny(), noSplitZone.ny()) && x5.a(this.d.Detail.Elements[j].nz(), noSplitZone.nz()))
									{
										if (this.d.Detail.Elements[j].nw() == -32768)
										{
											LayoutElement layoutElement4 = this.d.Detail.Elements[j];
											short num4 = num;
											num = num4 + 1;
											layoutElement4.nx(num4);
										}
										this.d.Detail.Elements[i].n1(this.d.Detail.Elements[j].nw(), alv.d);
									}
									else if (x5.d(this.d.Detail.Elements[j].ny(), noSplitZone.ny()) && x5.c(this.d.Detail.Elements[j].nz(), noSplitZone.ny()))
									{
										if (this.d.Detail.Elements[j].nw() == -32768)
										{
											LayoutElement layoutElement5 = this.d.Detail.Elements[j];
											short num5 = num;
											num = num5 + 1;
											layoutElement5.nx(num5);
										}
										this.d.Detail.Elements[i].n1(this.d.Detail.Elements[j].nw(), alv.c);
									}
									else if (x5.a(this.d.Detail.Elements[j].ny(), noSplitZone.ny()) && x5.b(this.d.Detail.Elements[j].nz(), noSplitZone.nz()))
									{
										if (this.d.Detail.Elements[j].nw() == -32768)
										{
											LayoutElement layoutElement6 = this.d.Detail.Elements[j];
											short num6 = num;
											num = num6 + 1;
											layoutElement6.nx(num6);
										}
										this.d.Detail.Elements[i].n1(this.d.Detail.Elements[j].nw(), alv.b);
									}
									else if (x5.d(this.d.Detail.Elements[j].ny(), noSplitZone.nz()) && x5.c(this.d.Detail.Elements[j].nz(), noSplitZone.nz()))
									{
										if (this.d.Detail.Elements[j].nw() == -32768)
										{
											LayoutElement layoutElement7 = this.d.Detail.Elements[j];
											short num7 = num;
											num = num7 + 1;
											layoutElement7.nx(num7);
										}
										this.d.Detail.Elements[i].n1(this.d.Detail.Elements[j].nw(), alv.a);
									}
								}
							}
						}
					}
				}
			}
			this.c = new amg(this.d);
			int num8 = -1;
			if (this.Data.c() == null)
			{
				aml aml = this.d.Detail.a(this);
				aml.no(num8 + 1);
				this.c.a(aml);
				this.m9();
				SubReport.a(this, this.d.q());
			}
			else
			{
				do
				{
					aml aml = this.d.Detail.a(this);
					aml.no(++num8);
					this.c.a(aml);
					this.m9();
					SubReport.a(this, this.d.q());
				}
				while (this.Data.c().mp(this));
			}
			if (this.d.p() != null)
			{
				this.i = new am5(this, this.d.p());
			}
			ahs ahs3 = this.d.d();
			if (ahs3 != null && ahs3.b() > 0)
			{
				ahs3.b(this);
			}
			if (this.m5() != null)
			{
				this.m5().a(this, false);
			}
			if (this.d.q() != null)
			{
				aln.a(this.c);
			}
			for (aml aml2 = (aml)this.c.e(); aml2 != null; aml2 = (aml)aml2.e())
			{
				aml2.c();
			}
			al1 al = new al1(this.f, this.d, false);
			al.a(this.c, this.d, this.h, this, a_, flag);
			if (this.d.h() != null)
			{
				PageList pages = this.h.Document.Pages;
				for (int k = 0; k < pages.Count; k++)
				{
					if (!(pages[k] is amq))
					{
						((amz)pages[k]).a(this.h);
					}
				}
			}
			this.Data.d();
		}

		// Token: 0x0600397B RID: 14715 RVA: 0x001EFA5C File Offset: 0x001EEA5C
		internal override aie m4()
		{
			return this.h.m4();
		}

		// Token: 0x0600397C RID: 14716 RVA: 0x001EFA7C File Offset: 0x001EEA7C
		internal override aig m5()
		{
			return this.h.m5();
		}

		// Token: 0x0600397D RID: 14717 RVA: 0x001EFA9C File Offset: 0x001EEA9C
		internal StructureElement a()
		{
			return this.j;
		}

		// Token: 0x0600397E RID: 14718 RVA: 0x001EFAB4 File Offset: 0x001EEAB4
		public override DataProviderStack get_Data()
		{
			return this.h.Data;
		}

		// Token: 0x0600397F RID: 14719 RVA: 0x001EFAD4 File Offset: 0x001EEAD4
		public override Document get_Document()
		{
			return this.h.Document;
		}

		// Token: 0x06003980 RID: 14720 RVA: 0x001EFAF4 File Offset: 0x001EEAF4
		internal override anf m6()
		{
			return this.h.m6();
		}

		// Token: 0x06003981 RID: 14721 RVA: 0x001EFB14 File Offset: 0x001EEB14
		public override DocumentLayout get_DocumentLayout()
		{
			return this.h.DocumentLayout;
		}

		// Token: 0x06003982 RID: 14722 RVA: 0x001EFB34 File Offset: 0x001EEB34
		internal float b()
		{
			return this.e;
		}

		// Token: 0x06003983 RID: 14723 RVA: 0x001EFB4C File Offset: 0x001EEB4C
		internal Report c()
		{
			return this.d;
		}

		// Token: 0x06003984 RID: 14724 RVA: 0x001EFB64 File Offset: 0x001EEB64
		internal amy d()
		{
			return this.a;
		}

		// Token: 0x06003985 RID: 14725 RVA: 0x001EFB7C File Offset: 0x001EEB7C
		internal amx e()
		{
			return this.b;
		}

		// Token: 0x06003986 RID: 14726 RVA: 0x001EFB94 File Offset: 0x001EEB94
		internal override void m9()
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

		// Token: 0x06003987 RID: 14727 RVA: 0x001EFBC8 File Offset: 0x001EEBC8
		internal override AlternateRow m7()
		{
			return this.g;
		}

		// Token: 0x06003988 RID: 14728 RVA: 0x001EFBE0 File Offset: 0x001EEBE0
		internal override void m8(AlternateRow A_0)
		{
			this.g = A_0;
		}

		// Token: 0x06003989 RID: 14729 RVA: 0x001EFBEC File Offset: 0x001EEBEC
		internal override float na()
		{
			return this.d.e().Body.Width;
		}

		// Token: 0x0600398A RID: 14730 RVA: 0x001EFC14 File Offset: 0x001EEC14
		internal override am5 nb()
		{
			return this.i;
		}

		// Token: 0x04001B63 RID: 7011
		private amy a = null;

		// Token: 0x04001B64 RID: 7012
		private amx b = null;

		// Token: 0x04001B65 RID: 7013
		private amg c = null;

		// Token: 0x04001B66 RID: 7014
		private Report d;

		// Token: 0x04001B67 RID: 7015
		private float e;

		// Token: 0x04001B68 RID: 7016
		private x5 f;

		// Token: 0x04001B69 RID: 7017
		private AlternateRow g = AlternateRow.Odd;

		// Token: 0x04001B6A RID: 7018
		private alr h;

		// Token: 0x04001B6B RID: 7019
		private am5 i = null;

		// Token: 0x04001B6C RID: 7020
		private StructureElement j = null;
	}
}
