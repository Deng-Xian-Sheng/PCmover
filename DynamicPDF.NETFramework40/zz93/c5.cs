using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x0200008D RID: 141
	internal class c5 : StructureElement
	{
		// Token: 0x060006B4 RID: 1716 RVA: 0x0005D794 File Offset: 0x0005C794
		internal c5(abj A_0, int A_1)
		{
			this.a = A_0;
			this.n = A_1;
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x0005D81C File Offset: 0x0005C81C
		public override void Draw(DocumentWriter writer)
		{
			if (this.a != null)
			{
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				if (!this.l)
				{
					writer.WriteName(c5.o);
					writer.WriteName(c5.p);
				}
				this.a.b(writer);
				if (this.b)
				{
					writer.WriteName(StructureElement.d);
					writer.WriteReferenceShallow((base.Parent == null) ? (writer.Document.j().k() + this.n + 1) : Convert.ToInt32(writer.Document.j().f()[base.Parent]));
				}
				if (this.e != null)
				{
					if (this.e.c() < 0)
					{
						writer.WriteName(StructureElement.e);
						writer.WriteNull();
					}
					else if (this.e.a() != null)
					{
						PdfPage pdfPage = this.e.a().h();
						if (pdfPage != null)
						{
							int num = writer.b(pdfPage);
							if (num >= 0)
							{
								writer.WriteName(StructureElement.e);
								this.f().hz(writer);
								for (int i = 0; i < writer.Document.Pages.Count; i++)
								{
									if (num == writer.GetPageObject(i + 1))
									{
										this.i = i;
										break;
									}
								}
							}
						}
					}
				}
				if (this.c != null)
				{
					if (this.c.Count == 1 && base.n().b() == 0)
					{
						if (this.c[0] != null)
						{
							if (((cu)this.c[0]).a7())
							{
								writer.WriteName(StructureElement.h);
								((cu)this.c[0]).a9(writer, this.i);
							}
							if (!((cu)this.c[0]).ba() && !((cu)this.c[0]).bn() && writer.Document.Pages[((cu)this.c[0]).a5()].f() >= 0)
							{
								writer.Document.j().a(writer.Document.Pages[((cu)this.c[0]).a5()].f(), ((cx)this.c[0]).a(), this);
							}
						}
					}
					else if (base.n() != null && base.n().b() > 0 && this.c.Count > 0)
					{
						writer.WriteName(StructureElement.h);
						writer.WriteArrayOpen();
						int num2 = 0;
						int num3 = 0;
						while (num2 < base.n().b() && num3 < this.c.Count)
						{
							if (this.c[num3] != null)
							{
								if (base.n().a(num2).d() < ((cu)this.c[num3]).d())
								{
									base.n().a(num2).a9(writer, this.i);
									num2++;
								}
								else
								{
									if (((cu)this.c[num3]).a7())
									{
										((cu)this.c[num3]).a9(writer, this.i);
									}
									if (!((cu)this.c[num3]).ba() && !((cu)this.c[num3]).bn() && writer.Document.Pages[((cu)this.c[num3]).a5()].f() >= 0)
									{
										writer.Document.j().a(writer.Document.Pages[((cu)this.c[num3]).a5()].f(), ((cx)this.c[num3]).a(), this);
									}
									num3++;
								}
							}
							else
							{
								num3++;
							}
						}
						for (int j = num2; j < base.n().b(); j++)
						{
							base.n().a(j).a9(writer, this.i);
						}
						for (int i = num3; i < this.c.Count; i++)
						{
							if (((cu)this.c[i]).a7())
							{
								((cu)this.c[i]).a9(writer, this.i);
							}
							if (!((cu)this.c[i]).ba() && !((cu)this.c[i]).bn() && writer.Document.Pages[((cu)this.c[i]).a5()].f() >= 0)
							{
								writer.Document.j().a(writer.Document.Pages[((cu)this.c[i]).a5()].f(), ((cx)this.c[i]).a(), this);
							}
						}
						writer.WriteArrayClose();
					}
					else if (this.c.Count > 0)
					{
						writer.WriteName(StructureElement.h);
						writer.WriteArrayOpen();
						this.a(writer);
						writer.WriteArrayClose();
					}
				}
				else if (base.n() != null)
				{
					writer.WriteName(StructureElement.h);
					if (base.n().b() == 1)
					{
						base.n().a(0).a9(writer, this.i);
					}
					else
					{
						writer.WriteArrayOpen();
						for (int j = 0; j < base.n().b(); j++)
						{
							base.n().a(j).a9(writer, this.i);
						}
						writer.WriteArrayClose();
					}
				}
				writer.WriteDictionaryClose();
				writer.WriteEndObject();
			}
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x0005DF8C File Offset: 0x0005CF8C
		private new void a(DocumentWriter A_0)
		{
			for (int i = 0; i < this.c.Count; i++)
			{
				if (((cu)this.c[i]).a7())
				{
					((cu)this.c[i]).a9(A_0, this.i);
				}
				if (!((cu)this.c[i]).ba() && !((cu)this.c[i]).bn() && A_0.Document.Pages[((cu)this.c[i]).a5()].f() >= 0)
				{
					A_0.Document.j().a(A_0.Document.Pages[((cu)this.c[i]).a5()].f(), ((cx)this.c[i]).a(), this);
				}
			}
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x0005E0B0 File Offset: 0x0005D0B0
		internal new string a()
		{
			return this.m;
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x0005E0C8 File Offset: 0x0005D0C8
		internal new bool a(StructureElement A_0, int[] A_1, int A_2, int A_3, r2 A_4)
		{
			if (A_0 != null)
			{
				base.Parent = A_0;
			}
			for (abk abk = this.a.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 16)
				{
					if (num != 1)
					{
						if (num != 11)
						{
							if (num == 16)
							{
								this.b = true;
								abk.a(false);
							}
						}
						else
						{
							this.d = abk.c();
							abk.a(false);
						}
					}
					else if (A_4.ac && !A_4.j())
					{
						this.j = r2.a(abk.c());
					}
				}
				else if (num != 19)
				{
					if (num != 580)
					{
						if (num == 1063)
						{
							if (abk.c().hy() == ag9.j)
							{
								this.e = (ab6)abk.c();
							}
							if (this.e != null)
							{
								if (this.e.c() > 0 && this.e.a() != null)
								{
									if (this.e.a().h() != null)
									{
										if (!this.e.a().h().m())
										{
											this.e.a().h().l();
										}
										if (this.e.a().h().c() != -1)
										{
											if (this.f == null)
											{
												this.f = new int[2];
											}
											this.f[this.g++] = this.e.a().h().c();
										}
									}
								}
							}
							abk.a(false);
						}
					}
					else if (abk.c().hy() == ag9.c)
					{
						base.Identifier = ((ab7)abk.c()).kf();
					}
					else if (abk.c().hy() == ag9.j && abk.c().h6().hy() == ag9.c)
					{
						base.Identifier = ((ab7)abk.c().h6()).kf();
					}
				}
				else
				{
					if (abk.c().hy() == ag9.d)
					{
						this.m = ((abu)abk.c()).j9();
					}
					if (this.m != null && this.m.Equals("Document"))
					{
						abk.a(false);
						this.l = false;
					}
				}
			}
			if (this.e != null && this.e.c() > 0 && this.e.a() != null && this.e.a().e() != null)
			{
				int num2 = this.e.a().h().e();
				if (num2 < A_2 - 1 || num2 >= A_3 + A_2 - 1)
				{
					this.h = false;
				}
			}
			return this.h;
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x0005E43C File Offset: 0x0005D43C
		internal new int[] c()
		{
			return this.f;
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x0005E454 File Offset: 0x0005D454
		internal new void a(int[] A_0)
		{
			this.f = A_0;
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0005E460 File Offset: 0x0005D460
		internal new abd e()
		{
			return this.d;
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x0005E478 File Offset: 0x0005D478
		internal new ab6 f()
		{
			return this.e;
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0005E490 File Offset: 0x0005D490
		internal new void a(object A_0)
		{
			if (this.c == null)
			{
				this.c = new ArrayList();
			}
			this.c.Add(A_0);
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x0005E4C8 File Offset: 0x0005D4C8
		internal override void bp(Resource A_0, int A_1)
		{
			if (this.c != null)
			{
				foreach (object obj in this.c)
				{
					cu cu = (cu)obj;
					if (cu != null)
					{
						if (cu.ba())
						{
							if (((cw)cu).a() == null && ((cw)cu).bm(A_1))
							{
								((cw)cu).a(A_0);
								((cw)cu).a8(true);
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x0005E594 File Offset: 0x0005D594
		internal override bool bq()
		{
			bool result = true;
			if (this.c != null)
			{
				if (this.c.Count == 1)
				{
					if (this.c[0] == null && (base.n() == null || (base.n() != null && base.n().b() >= 0)))
					{
						return false;
					}
					if (!((cu)this.c[0]).a7())
					{
						return true;
					}
				}
				for (int i = 0; i < this.c.Count; i++)
				{
					if (this.c[i] != null && ((cu)this.c[i]).a7())
					{
						result = false;
					}
				}
			}
			else if (base.n() == null || (base.n() != null && base.n().b() >= 0))
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x0005E6B4 File Offset: 0x0005D6B4
		internal override bool br()
		{
			return base.n() == null || (base.n() != null && base.n().b() <= 0);
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0005E6F8 File Offset: 0x0005D6F8
		internal override void bs(StructureElement A_0)
		{
			for (int i = 0; i < base.n().b(); i++)
			{
				if (base.n().a(i) != null && !base.n().a(i).bb() && ((cy)base.n().a(i)).a() == A_0)
				{
					base.n().b(base.n().a(i));
				}
			}
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x0005E780 File Offset: 0x0005D780
		internal override bool bt()
		{
			return this.h;
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x0005E798 File Offset: 0x0005D798
		internal new bool i()
		{
			return this.j;
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x0005E7B0 File Offset: 0x0005D7B0
		internal override bool bu()
		{
			if (this.c != null)
			{
				for (int i = 0; i < this.c.Count; i++)
				{
					if (((cu)this.c[i]).bb())
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x0005E810 File Offset: 0x0005D810
		internal int j()
		{
			return this.k;
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0005E828 File Offset: 0x0005D828
		internal new void a(int A_0)
		{
			this.k = A_0;
		}

		// Token: 0x04000392 RID: 914
		private new abj a = null;

		// Token: 0x04000393 RID: 915
		private new bool b = false;

		// Token: 0x04000394 RID: 916
		private new ArrayList c = null;

		// Token: 0x04000395 RID: 917
		private new abd d = null;

		// Token: 0x04000396 RID: 918
		private new ab6 e = null;

		// Token: 0x04000397 RID: 919
		private new int[] f = null;

		// Token: 0x04000398 RID: 920
		private new int g = 0;

		// Token: 0x04000399 RID: 921
		private new bool h = true;

		// Token: 0x0400039A RID: 922
		private new int i = -1;

		// Token: 0x0400039B RID: 923
		private bool j = false;

		// Token: 0x0400039C RID: 924
		private int k = -1;

		// Token: 0x0400039D RID: 925
		private bool l = true;

		// Token: 0x0400039E RID: 926
		private string m = null;

		// Token: 0x0400039F RID: 927
		private int n = 0;

		// Token: 0x040003A0 RID: 928
		private static byte o = 83;

		// Token: 0x040003A1 RID: 929
		private static byte[] p = new byte[]
		{
			80,
			97,
			114,
			116
		};
	}
}
