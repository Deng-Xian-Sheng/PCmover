using System;
using System.IO;
using System.Text;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x02000423 RID: 1059
	internal class abl
	{
		// Token: 0x06002C0E RID: 11278 RVA: 0x00194F40 File Offset: 0x00193F40
		internal abl(aba A_0, ab6 A_1, PdfDocument A_2)
		{
			this.z = A_2;
			this.m = (abj)A_1.h6();
			for (abk abk = this.m.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 277248371)
				{
					if (num <= 226870118)
					{
						if (num <= 5479461)
						{
							if (num != 3283879)
							{
								if (num == 5479461)
								{
									abk.a(false);
								}
							}
							else
							{
								this.j = (ab7)abk.c().h6();
								abk.a(false);
							}
						}
						else if (num != 19867219)
						{
							if (num != 26072939)
							{
								if (num == 226870118)
								{
									this.v = (abj)abk.c().h6();
									abk.a(false);
								}
							}
							else
							{
								this.b = abk.c();
								abk.a(false);
							}
						}
						else
						{
							this.d = (abj)abk.c().h6();
							abk.a(false);
						}
					}
					else if (num <= 243718515)
					{
						if (num != 227890501)
						{
							if (num == 243718515)
							{
								this.n = (abj)abk.c().h6();
								this.a(this.n);
								this.c(this.n);
								abk.a(false);
							}
						}
						else
						{
							if (abk.c().hy() == ag9.j)
							{
								this.k = (ab6)abk.c();
							}
							abk.a(false);
						}
					}
					else if (num != 265658970)
					{
						if (num != 277119080)
						{
							if (num == 277248371)
							{
								this.a = (abj)abk.c().h6();
								abk.a(false);
							}
						}
						else
						{
							this.h = abk.c();
							abk.a(false);
						}
					}
					else
					{
						this.c = abk.c();
						abk.a(false);
					}
				}
				else if (num <= 667615218)
				{
					if (num <= 379004679)
					{
						if (num != 278342515)
						{
							if (num == 379004679)
							{
								abk.a(false);
								abu abu = (abu)abk.c().h6();
								this.y = abu.j7(A_0);
							}
						}
						else
						{
							abk.a(false);
						}
					}
					else if (num != 483011505)
					{
						if (num != 543969483)
						{
							if (num == 667615218)
							{
								if (abk.c().hy() == ag9.j)
								{
									abd abd = abk.c().h6();
									if (abd != null)
									{
										if (abd.hy() == ag9.g)
										{
											this.u = (abj)abd;
										}
									}
									abk.a(false);
								}
							}
						}
						else
						{
							this.aa = (abj)abk.c().h6();
							this.z.CollectionType = CollectionType.Package;
							this.c();
						}
					}
					else if (abk.c().hy() == ag9.a)
					{
						this.x = ((abf)abk.c()).a();
					}
				}
				else if (num <= 822878847)
				{
					if (num != 739295343)
					{
						if (num == 822878847)
						{
							this.e = (abj)abk.c().h6();
							abk.a(false);
						}
					}
					else
					{
						this.i = abk.c();
						abk.a(false);
					}
				}
				else if (num != 828408888)
				{
					if (num != 1005800483)
					{
						if (num == 1067067637)
						{
							this.q = (abj)abk.c().h6();
							this.b(this.q);
							abk.a(false);
						}
					}
					else
					{
						this.l = (abe)abk.c().h6();
						abk.a(false);
					}
				}
				else
				{
					this.g = abk.c();
					abk.a(false);
				}
			}
		}

		// Token: 0x06002C0F RID: 11279 RVA: 0x00195484 File Offset: 0x00194484
		private void c()
		{
			for (abk abk = this.aa.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 5937527)
				{
					abu a_ = (abu)abk.c().h6();
					this.a(a_);
					break;
				}
			}
		}

		// Token: 0x06002C10 RID: 11280 RVA: 0x001954EC File Offset: 0x001944EC
		private void a(abu A_0)
		{
			if (A_0.j8() == 3)
			{
				this.z.CollectionType = CollectionType.AdobePortfolio;
			}
		}

		// Token: 0x06002C11 RID: 11281 RVA: 0x0019551C File Offset: 0x0019451C
		private void c(abj A_0)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 555917758)
				{
					this.p = (abj)abk.c().h6();
					break;
				}
			}
		}

		// Token: 0x06002C12 RID: 11282 RVA: 0x0019557C File Offset: 0x0019457C
		internal void a(aba A_0)
		{
			if (this.n != null)
			{
				for (abk abk = this.n.l(); abk != null; abk = abk.d())
				{
					if (abk.a().j8() == 555917758)
					{
						if (this.p != null)
						{
							this.a(this.p, A_0);
							break;
						}
					}
				}
			}
		}

		// Token: 0x06002C13 RID: 11283 RVA: 0x001955F4 File Offset: 0x001945F4
		internal abj d()
		{
			return this.u;
		}

		// Token: 0x06002C14 RID: 11284 RVA: 0x0019560C File Offset: 0x0019460C
		internal abj e()
		{
			return this.v;
		}

		// Token: 0x06002C15 RID: 11285 RVA: 0x00195624 File Offset: 0x00194624
		internal bool f()
		{
			return this.w;
		}

		// Token: 0x06002C16 RID: 11286 RVA: 0x0019563C File Offset: 0x0019463C
		internal abj g()
		{
			return this.n;
		}

		// Token: 0x06002C17 RID: 11287 RVA: 0x00195654 File Offset: 0x00194654
		private void a(abj A_0, aba A_1)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 243718515)
				{
					this.a(abk, A_1);
				}
				else if (abk.a().j8() == 3053875)
				{
					this.b(abk, A_1);
				}
			}
		}

		// Token: 0x06002C18 RID: 11288 RVA: 0x001956CC File Offset: 0x001946CC
		private void b(abk A_0, aba A_1)
		{
			abe abe = (abe)A_0.c().h6();
			if (abe != null)
			{
				for (int i = 0; i < abe.a(); i++)
				{
					if (abe.a(i) != null)
					{
						abj abj = (abj)abe.a(i).h6();
						for (abk abk = abj.l(); abk != null; abk = abk.d())
						{
							if (abk.a().j8() == 243718515)
							{
								this.a(abk, A_1);
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x06002C19 RID: 11289 RVA: 0x00195780 File Offset: 0x00194780
		private void a(abk A_0, aba A_1)
		{
			abe abe = (abe)A_0.c().h6();
			if (abe != null)
			{
				for (int i = 0; i < abe.a(); i += 2)
				{
					if (abe.a(i) != null)
					{
						Attachment item = new Attachment(abe.a(i + 1), A_1);
						this.z.e().Add(item);
					}
				}
			}
		}

		// Token: 0x06002C1A RID: 11290 RVA: 0x001957F4 File Offset: 0x001947F4
		internal void a(Document A_0, int A_1, int A_2)
		{
			if (this.u != null)
			{
				if (A_0.j() == null)
				{
					A_0.a(new r2());
				}
				this.a(A_0);
				A_0.j().a(this.u, A_1, A_2);
			}
			else
			{
				this.a(A_0);
			}
		}

		// Token: 0x06002C1B RID: 11291 RVA: 0x00195858 File Offset: 0x00194858
		internal string h()
		{
			string result = null;
			if (this.k != null)
			{
				abg abg = this.k.b().m().b((long)this.k.c());
				aba aba = this.k.b().f().k8();
				abd abd = abg.i();
				if (aba != null)
				{
					aba.lr();
				}
				using (new MemoryStream())
				{
					byte[] bytes = ((afj)abd).j4();
					result = Encoding.UTF8.GetString(bytes);
				}
			}
			return result;
		}

		// Token: 0x06002C1C RID: 11292 RVA: 0x00195920 File Offset: 0x00194920
		private void a(Document A_0)
		{
			abk abk = null;
			if (this.v != null)
			{
				for (abk abk2 = this.v.l(); abk2 != null; abk2 = abk2.d())
				{
					int num = abk2.a().j8();
					if (num != 226962113)
					{
						if (num != 332726550)
						{
							if (num == 665046161)
							{
								if (((abf)abk2.c()).a() && A_0.j() != null)
								{
									A_0.j().ac = true;
								}
							}
						}
						else if (((abf)abk2.c()).a())
						{
							A_0.c(true);
						}
					}
					else
					{
						string text = "";
						bool flag = false;
						if (abk2.c().hy() == ag9.a)
						{
							flag = ((abf)abk2.c()).a();
						}
						else
						{
							text = ((abu)abk2.c()).j9();
						}
						if (!flag || text == "false")
						{
							A_0.b(false);
						}
						abk = abk2;
					}
				}
				A_0.d(true);
			}
			if (abk == null)
			{
				A_0.b(false);
			}
		}

		// Token: 0x06002C1D RID: 11293 RVA: 0x00195A80 File Offset: 0x00194A80
		private void b(abj A_0)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 4)
				{
					if (num != 3944947)
					{
						if (num == 6284092)
						{
							this.t = (abe)abk.c().h6();
						}
					}
					else
					{
						this.s = (abe)abk.c().h6();
						abk.a(false);
					}
				}
				else
				{
					this.r = (abj)abk.c().h6();
					abk.a(false);
				}
			}
		}

		// Token: 0x06002C1E RID: 11294 RVA: 0x00195B2C File Offset: 0x00194B2C
		internal void a(MergeDocument A_0)
		{
			if (this.r != null)
			{
				@do @do = A_0.c().b();
				@do.a(this.r);
			}
			if (this.s != null)
			{
				A_0.c().a().a(this.s);
			}
			if (this.t != null)
			{
				@do do2 = new @do();
				do2.f(this.t);
				A_0.c().a(do2);
			}
		}

		// Token: 0x06002C1F RID: 11295 RVA: 0x00195BB8 File Offset: 0x00194BB8
		private void a(abj A_0)
		{
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				if (abk.a().j8() == 692974695)
				{
					this.o = (abj)abk.c().h6();
					abk.a(false);
					break;
				}
				if (abk.a().j8() == 555917758)
				{
					this.ab = (abj)abk.c().h6();
					abk.a(false);
				}
			}
		}

		// Token: 0x06002C20 RID: 11296 RVA: 0x00195C5C File Offset: 0x00194C5C
		internal void b(MergeDocument A_0)
		{
			if (this.o != null)
			{
				A_0.JavaScripts.b(this.o);
			}
		}

		// Token: 0x06002C21 RID: 11297 RVA: 0x00195C8C File Offset: 0x00194C8C
		internal void c(MergeDocument A_0)
		{
			if (this.ab != null)
			{
				A_0.EmbeddedFiles.b(this.ab);
			}
		}

		// Token: 0x06002C22 RID: 11298 RVA: 0x00195CBC File Offset: 0x00194CBC
		internal void d(MergeDocument A_0)
		{
			A_0.a(this.m);
			A_0.b(this.n);
			if (this.j != null)
			{
				A_0.Language = this.j.kf();
			}
		}

		// Token: 0x06002C23 RID: 11299 RVA: 0x00195D04 File Offset: 0x00194D04
		internal void e(MergeDocument A_0)
		{
			if (this.g != null)
			{
				A_0.InitialPageLayout = this.a();
			}
			else
			{
				A_0.e(false);
			}
			A_0.InitialPageMode = this.b();
			if (this.d != null)
			{
				A_0.ViewerPreferences.a(this.d);
			}
			if (this.y != -1)
			{
				if (A_0.PdfVersion < (PdfVersion)this.y)
				{
					A_0.PdfVersion = (PdfVersion)this.y;
				}
			}
		}

		// Token: 0x06002C24 RID: 11300 RVA: 0x00195D93 File Offset: 0x00194D93
		internal void f(MergeDocument A_0)
		{
			A_0.a(this.i);
		}

		// Token: 0x06002C25 RID: 11301 RVA: 0x00195DA4 File Offset: 0x00194DA4
		internal void g(MergeDocument A_0)
		{
			if (this.k != null)
			{
				abj abj = (abj)this.k.h6();
				if (abj != null)
				{
					abk abk = abj.l();
					int num = 0;
					while (abk != null)
					{
						int num2 = abk.a().j8();
						if (num2 == 211216860)
						{
							num = ((abw)abk.c().h6()).kd();
						}
						abk = abk.d();
					}
					if (num != 0)
					{
						A_0.a(this.k);
					}
				}
			}
		}

		// Token: 0x06002C26 RID: 11302 RVA: 0x00195E43 File Offset: 0x00194E43
		internal void a(MergeDocument A_0, ab7 A_1, ab7 A_2)
		{
			A_0.a(A_1, A_2, this.l);
		}

		// Token: 0x06002C27 RID: 11303 RVA: 0x00195E58 File Offset: 0x00194E58
		internal void a(MergeDocument A_0, int A_1, int A_2)
		{
			if (this.e != null)
			{
				if (this.f == null)
				{
					this.f = new ab0(this.e);
				}
				this.f.a(A_0, A_1, A_2);
			}
		}

		// Token: 0x06002C28 RID: 11304 RVA: 0x00195EA8 File Offset: 0x00194EA8
		private PageMode b()
		{
			PageMode result;
			if (this.h == null)
			{
				result = PageMode.ShowNone;
			}
			else
			{
				int num = ((abu)this.h).j8();
				if (num <= 365844490)
				{
					if (num == 353930651)
					{
						return PageMode.ShowThumbnails;
					}
					if (num == 365843395)
					{
						return PageMode.ShowOptionalContent;
					}
					if (num == 365844490)
					{
						return PageMode.ShowNone;
					}
				}
				else
				{
					if (num == 561825891)
					{
						return PageMode.ShowOutlines;
					}
					if (num == 568231786)
					{
						return PageMode.ShowAttachments;
					}
					if (num == 622629501)
					{
						return PageMode.FullScreen;
					}
				}
				result = PageMode.ShowNone;
			}
			return result;
		}

		// Token: 0x06002C29 RID: 11305 RVA: 0x00195F34 File Offset: 0x00194F34
		private PageLayout a()
		{
			PageLayout result;
			if (this.g == null)
			{
				result = PageLayout.SinglePage;
			}
			else
			{
				int num = ((abu)this.g).j8();
				if (num <= 860607602)
				{
					if (num == 252251009)
					{
						return PageLayout.OneColumn;
					}
					if (num == 860503411)
					{
						return PageLayout.TwoPageLeft;
					}
					if (num == 860607602)
					{
						return PageLayout.TwoPageRight;
					}
				}
				else
				{
					if (num == 920973321)
					{
						return PageLayout.SinglePage;
					}
					if (num == 940208855)
					{
						return PageLayout.TwoColumnLeft;
					}
					if (num == 950948169)
					{
						return PageLayout.TwoColumnRight;
					}
				}
				result = PageLayout.SinglePage;
			}
			return result;
		}

		// Token: 0x06002C2A RID: 11306 RVA: 0x00195FC0 File Offset: 0x00194FC0
		internal abj i()
		{
			return this.a;
		}

		// Token: 0x06002C2B RID: 11307 RVA: 0x00195FD8 File Offset: 0x00194FD8
		internal abd j()
		{
			return this.c;
		}

		// Token: 0x06002C2C RID: 11308 RVA: 0x00195FF0 File Offset: 0x00194FF0
		internal abd k()
		{
			return this.b;
		}

		// Token: 0x06002C2D RID: 11309 RVA: 0x00196008 File Offset: 0x00195008
		internal bool l()
		{
			return this.x;
		}

		// Token: 0x040014B2 RID: 5298
		private abj a = null;

		// Token: 0x040014B3 RID: 5299
		private abd b = null;

		// Token: 0x040014B4 RID: 5300
		private abd c = null;

		// Token: 0x040014B5 RID: 5301
		private abj d = null;

		// Token: 0x040014B6 RID: 5302
		private abj e = null;

		// Token: 0x040014B7 RID: 5303
		private ab0 f = null;

		// Token: 0x040014B8 RID: 5304
		private abd g = null;

		// Token: 0x040014B9 RID: 5305
		private abd h = null;

		// Token: 0x040014BA RID: 5306
		private abd i = null;

		// Token: 0x040014BB RID: 5307
		private ab7 j = null;

		// Token: 0x040014BC RID: 5308
		private ab6 k = null;

		// Token: 0x040014BD RID: 5309
		private abe l = null;

		// Token: 0x040014BE RID: 5310
		private abj m;

		// Token: 0x040014BF RID: 5311
		private abj n = null;

		// Token: 0x040014C0 RID: 5312
		private abj o = null;

		// Token: 0x040014C1 RID: 5313
		private abj p = null;

		// Token: 0x040014C2 RID: 5314
		private abj q = null;

		// Token: 0x040014C3 RID: 5315
		private abj r = null;

		// Token: 0x040014C4 RID: 5316
		private abe s = null;

		// Token: 0x040014C5 RID: 5317
		private abe t = null;

		// Token: 0x040014C6 RID: 5318
		private abj u = null;

		// Token: 0x040014C7 RID: 5319
		private abj v = null;

		// Token: 0x040014C8 RID: 5320
		private bool w = false;

		// Token: 0x040014C9 RID: 5321
		private bool x;

		// Token: 0x040014CA RID: 5322
		private int y = -1;

		// Token: 0x040014CB RID: 5323
		private PdfDocument z;

		// Token: 0x040014CC RID: 5324
		private abj aa = null;

		// Token: 0x040014CD RID: 5325
		private abj ab = null;
	}
}
