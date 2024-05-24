using System;
using System.Collections;
using System.Collections.Specialized;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;
using ceTe.DynamicPDF.ReportWriter.IO;
using ceTe.DynamicPDF.ReportWriter.ReportElements;

namespace zz93
{
	// Token: 0x0200038C RID: 908
	internal class xs : PageElement, ru
	{
		// Token: 0x060026BC RID: 9916 RVA: 0x001661C4 File Offset: 0x001651C4
		internal xs(SubReport A_0, bool A_1)
		{
			this.a = A_0;
			this.j = x5.a(A_0.X);
			this.k = x5.a(A_0.Y);
			this.g = A_0.gk();
			this.h = A_1;
			this.f = x5.a(A_0.Height);
		}

		// Token: 0x060026BD RID: 9917 RVA: 0x00166288 File Offset: 0x00165288
		internal xs(x5 A_0, SubReport A_1, x5 A_2)
		{
			this.a = A_1;
			this.j = x5.a(A_1.X);
			this.k = A_0;
			this.e = x5.f(A_2, x5.a(A_1.Header.Height + A_1.Footer.Height));
			this.g = A_1.gk();
		}

		// Token: 0x060026BE RID: 9918 RVA: 0x00166350 File Offset: 0x00165350
		internal xs(xs A_0)
		{
			this.j = A_0.j;
			this.k = A_0.k;
			this.a = A_0.a;
			this.e = A_0.e;
			this.h = A_0.h;
			this.g = A_0.g;
			if (A_0.p != null)
			{
				this.p = A_0.p.f8(true);
			}
			this.n = A_0.n;
			this.o = A_0.o;
			this.d = A_0.d.f8(true);
			this.l = A_0.g();
			this.i = A_0.h();
			this.b = A_0.b;
			this.c = A_0.c;
			this.q = A_0.q;
			this.r = A_0.r;
			this.f = A_0.f;
			this.m = A_0.m;
		}

		// Token: 0x060026BF RID: 9919 RVA: 0x001664B8 File Offset: 0x001654B8
		internal void c(LayoutWriter A_0)
		{
			AlternateRow a_ = A_0.e4();
			A_0.e5(AlternateRow.Odd);
			if (this.a.Query == null || this.a.Query is GroupByQuery)
			{
				this.b(A_0);
			}
			else
			{
				this.d(A_0);
			}
			A_0.e5(a_);
		}

		// Token: 0x060026C0 RID: 9920 RVA: 0x00166520 File Offset: 0x00165520
		internal void d(LayoutWriter A_0)
		{
			RecordSet recordSet = this.a.Query.e(A_0);
			A_0.RecordSets.a(recordSet);
			this.b = new xu(A_0, this.a.Header);
			this.c = new xt(A_0, this.a.Footer);
			if (recordSet.HasData)
			{
				this.d = new xd(this.a);
				int num = -1;
				do
				{
					xh xh = this.a.Detail.a(A_0);
					xh.gd(++num);
					this.d.a(xh);
					A_0.e3();
					SubReport.a(A_0, this.a.p());
				}
				while (A_0.RecordSets.Current.d8(A_0));
			}
			this.a.Query.a(A_0, A_0.RecordSets.Current);
			A_0.RecordSets.a();
			this.a(A_0);
		}

		// Token: 0x060026C1 RID: 9921 RVA: 0x0016662C File Offset: 0x0016562C
		internal void b()
		{
			if (this.d != null)
			{
				for (xh xh = (xh)this.d.e(); xh != null; xh = (xh)xh.e())
				{
					xh.c();
					this.e = x5.f(this.e, xh.d());
				}
			}
		}

		// Token: 0x060026C2 RID: 9922 RVA: 0x00166698 File Offset: 0x00165698
		private void b(LayoutWriter A_0)
		{
			RecordSet recordSet;
			if (this.a.Query != null)
			{
				recordSet = this.a.Query.e(A_0);
			}
			else
			{
				recordSet = A_0.RecordSets.Current;
			}
			this.b = new xu(A_0, this.a.Header);
			this.c = new xt(A_0, this.a.Footer);
			this.d = new xd(this.a);
			object a_ = "";
			if (this.a.Query != null)
			{
				a_ = ((GroupByQuery)this.a.Query).a().a().es(A_0);
			}
			bool a_2 = this.a.e() is SubReport && ((SubReport)this.a.e()).Query is GroupByQuery;
			recordSet.d9();
			int num = -1;
			do
			{
				xh xh = this.a.Detail.a(A_0);
				xh.gd(++num);
				this.d.a(xh);
				A_0.e3();
				SubReport.a(A_0, this.a.p());
			}
			while (this.a(A_0, a_, a_2));
			recordSet.ea();
			this.a(A_0);
		}

		// Token: 0x060026C3 RID: 9923 RVA: 0x00166800 File Offset: 0x00165800
		private bool a(LayoutWriter A_0, object A_1, bool A_2)
		{
			bool result;
			if (A_2)
			{
				result = this.a(A_0, A_1);
			}
			else
			{
				bool flag = A_0.RecordSets.Current.d8(A_0);
				if (flag)
				{
					object obj = "";
					if (this.a.Query != null)
					{
						obj = ((GroupByQuery)this.a.Query).a().a().es(A_0);
					}
					result = ((A_1 == null && obj != null) || (obj == null && A_1 != null) || (A_1 != null && A_1.Equals(obj)));
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x060026C4 RID: 9924 RVA: 0x0016689C File Offset: 0x0016589C
		private bool a(LayoutWriter A_0, object A_1)
		{
			bool result;
			if (((GroupByQuery)this.a.Query).c())
			{
				((GroupByQuery)this.a.Query).b(false);
				A_0.RecordSets.Current.d8(A_0);
				result = false;
			}
			else if (((GroupByQuery)this.a.Query).b())
			{
				A_0.RecordSets.Current.d8(A_0);
				result = true;
			}
			else
			{
				ArrayList arrayList = new ArrayList(2);
				ArrayList arrayList2 = new ArrayList(2);
				rm rm = this.a;
				while (rm is SubReport && ((SubReport)rm).Query is GroupByQuery)
				{
					SubReport subReport = (SubReport)rm;
					if (subReport.Query != null)
					{
						arrayList.Add(((GroupByQuery)subReport.Query).a().a().es(A_0));
					}
					else
					{
						arrayList.Add("");
					}
					((GroupByQuery)subReport.Query).a(true);
					arrayList2.Add(rm);
					rm = subReport.e();
				}
				((GroupByQuery)((SubReport)arrayList2[0]).Query).a(false);
				bool flag = A_0.RecordSets.Current.d8(A_0);
				if (flag)
				{
					bool flag2 = true;
					for (int i = arrayList.Count - 1; i >= 0; i--)
					{
						SubReport subReport = (SubReport)arrayList2[i];
						if (flag2)
						{
							object obj = "";
							if (subReport.Query != null)
							{
								obj = ((GroupByQuery)subReport.Query).a().a().es(A_0);
							}
							A_1 = arrayList[i];
							flag2 = ((A_1 == null && obj != null) || (obj == null && A_1 != null) || (A_1 != null && A_1.Equals(obj)));
						}
						((GroupByQuery)subReport.Query).b(!flag2);
					}
					((GroupByQuery)((SubReport)arrayList2[0]).Query).b(false);
					result = flag2;
				}
				else
				{
					for (int i = arrayList.Count - 1; i >= 0; i--)
					{
						SubReport subReport = (SubReport)arrayList2[i];
						((GroupByQuery)subReport.Query).b(true);
					}
					((GroupByQuery)((SubReport)arrayList2[0]).Query).b(false);
					result = false;
				}
			}
			return result;
		}

		// Token: 0x060026C5 RID: 9925 RVA: 0x00166B64 File Offset: 0x00165B64
		private void a(LayoutWriter A_0)
		{
			xw xw = this.a.f();
			if (xw.d().b() != 0)
			{
				HybridDictionary hybridDictionary = new HybridDictionary();
				for (sz.a a = xw.d().a(); a != null; a = a.b)
				{
					hybridDictionary.Add(a.a, A_0.e1().a(a.a));
					A_0.e1().b(a.a);
				}
				vc vc = new vc();
				vc.a(this.a.f().f());
				this.a.f().a(null);
				vc.a(hybridDictionary);
				this.l = vc;
			}
		}

		// Token: 0x060026C6 RID: 9926 RVA: 0x00166C30 File Offset: 0x00165C30
		public override void Draw(PageWriter writer)
		{
			if (this.d != null)
			{
				StructureElement structureElement = writer.k();
				StructureElement structureElement2 = new StructureElement(new NamedTagType(this.a.r(), TagType.Division));
				structureElement2.Parent = structureElement;
				writer.a(structureElement2);
				this.a(this.a.g(), writer);
				x5 a_ = this.k;
				if (this.b != null)
				{
					writer.SetDimensionsShift(x5.b(this.j), x5.b(a_), 0f, 0f);
					this.b.a(this, writer);
					writer.ResetDimensions();
				}
				if (writer.Document.Tag != null)
				{
					writer.a(new StructureElement(new NamedTagType(this.a.Detail.Id, TagType.Section))
					{
						Parent = writer.k()
					});
				}
				a_ = this.d.f7(writer, this.j, x5.f(a_, x5.a(this.a.Header.Height)));
				if (writer.Document.Tag != null)
				{
					writer.a(structureElement2);
				}
				if (this.c != null)
				{
					writer.SetDimensionsShift(x5.b(this.j), x5.b(a_), 0f, 0f);
					this.c.a(this, writer);
					writer.ResetDimensions();
				}
				if (writer.Document.Tag != null)
				{
					writer.a(structureElement);
				}
			}
		}

		// Token: 0x060026C7 RID: 9927 RVA: 0x00166DE8 File Offset: 0x00165DE8
		internal void a(LayoutWriter A_0, PageWriter A_1)
		{
			if (this.g() != null)
			{
				Page a_ = null;
				if (A_1 != null)
				{
					a_ = A_1.Page;
				}
				HybridDictionary hybridDictionary = this.g().b();
				xw xw = this.f().f();
				xw.d().a(hybridDictionary, a_);
				for (sz.a a = xw.d().a(); a != null; a = a.b)
				{
					A_0.e1().a(a.a, (s1)hybridDictionary[a.a]);
				}
				this.g().a().a(A_0, true);
			}
		}

		// Token: 0x060026C8 RID: 9928 RVA: 0x00166EA0 File Offset: 0x00165EA0
		internal ArrayList c()
		{
			return this.n;
		}

		// Token: 0x060026C9 RID: 9929 RVA: 0x00166EB8 File Offset: 0x00165EB8
		internal int d()
		{
			return this.o;
		}

		// Token: 0x060026CA RID: 9930 RVA: 0x00166ED0 File Offset: 0x00165ED0
		internal override void ca(x5 A_0)
		{
			this.k = x5.e(this.k, A_0);
		}

		// Token: 0x060026CB RID: 9931 RVA: 0x00166EE8 File Offset: 0x00165EE8
		internal override x5 b7()
		{
			return this.k;
		}

		// Token: 0x060026CC RID: 9932 RVA: 0x00166F00 File Offset: 0x00165F00
		internal override x5 b8()
		{
			return x5.f(this.k, this.e);
		}

		// Token: 0x060026CD RID: 9933 RVA: 0x00166F24 File Offset: 0x00165F24
		internal xd e()
		{
			return this.d;
		}

		// Token: 0x060026CE RID: 9934 RVA: 0x00166F3C File Offset: 0x00165F3C
		internal void a(xd A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060026CF RID: 9935 RVA: 0x00166F46 File Offset: 0x00165F46
		internal void a(xu A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060026D0 RID: 9936 RVA: 0x00166F50 File Offset: 0x00165F50
		internal void a(xt A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060026D1 RID: 9937 RVA: 0x00166F5C File Offset: 0x00165F5C
		internal override short fd()
		{
			return this.g;
		}

		// Token: 0x060026D2 RID: 9938 RVA: 0x00166F74 File Offset: 0x00165F74
		internal void a(short A_0)
		{
			this.g = A_0;
		}

		// Token: 0x060026D3 RID: 9939 RVA: 0x00166F80 File Offset: 0x00165F80
		internal SubReport f()
		{
			return this.a;
		}

		// Token: 0x060026D4 RID: 9940 RVA: 0x00166F98 File Offset: 0x00165F98
		void ru.a(acm A_0)
		{
			if (this.d != null)
			{
				if (this.n != null)
				{
					this.e = x5.f(this.e, x5.a(this.a.Header.Height + this.a.Footer.Height));
					A_0.a(this.b7(), x5.f(this.b7(), this.f), x5.e(this.e, this.f));
				}
				else
				{
					this.e = x5.f(this.e, x5.a(this.a.Header.Height + this.a.Footer.Height));
					A_0.a(x5.a(this.a.Y), x5.f(x5.a(this.a.Y), x5.a(this.a.Height)), x5.e(this.e, this.f));
				}
			}
			else
			{
				A_0.a(x5.a(this.a.Y), x5.f(x5.a(this.a.Y), x5.a(this.a.Height)), x5.d(x5.a(this.a.Height)));
			}
		}

		// Token: 0x060026D5 RID: 9941 RVA: 0x00167116 File Offset: 0x00166116
		internal override void b5(dv A_0)
		{
			this.k = x5.f(this.k, A_0.a(this.k));
		}

		// Token: 0x060026D6 RID: 9942 RVA: 0x00167138 File Offset: 0x00166138
		internal override x5 fa(x5 A_0)
		{
			x5 result;
			if (this.a.m() > 1 && !this.m && (this.n == null || this.n.Count == 0))
			{
				result = w0.d;
			}
			else
			{
				x5 x = x5.c();
				if (this.b != null)
				{
					x = x5.f(x, x5.a(this.a.Header.Height));
				}
				if (this.c != null)
				{
					x = x5.f(x, x5.a(this.a.Footer.Height));
				}
				x5 x2 = x5.e(A_0, x);
				if (this.a.m() > 1 && this.n != null && this.n.Count > 0 && this.o > 0)
				{
					if (x5.c(((xe)this.n[this.o]).c(), x2))
					{
						if (this.m)
						{
							this.m = false;
						}
						result = w0.d;
					}
					else
					{
						result = w0.e;
					}
				}
				else
				{
					result = this.a(x2);
				}
			}
			return result;
		}

		// Token: 0x060026D7 RID: 9943 RVA: 0x00167280 File Offset: 0x00166280
		private x5 a(x5 A_0)
		{
			x5 result;
			if (x5.b(A_0, x5.c()))
			{
				if (this.m)
				{
					this.m = false;
				}
				result = w0.d;
			}
			else if (this.d.e() == null)
			{
				result = w0.e;
			}
			else if (x5.c(A_0, this.d.e().d()))
			{
				result = w0.e;
			}
			else if (this.a.Detail.AutoSplit || this.m)
			{
				xg a_ = this.d.e();
				w3 w = new w3();
				ArrayList a_2 = new ArrayList();
				rp.a(w, A_0, a_);
				rp rp = new rp(A_0);
				rp.a(w, A_0, false, null, a_2, this.h);
				if (w.a == null)
				{
					if (this.m)
					{
						this.m = false;
					}
					result = w0.d;
				}
				else
				{
					result = w0.e;
				}
			}
			else
			{
				if (this.m)
				{
					this.m = false;
				}
				result = w0.d;
			}
			return result;
		}

		// Token: 0x060026D8 RID: 9944 RVA: 0x001673D0 File Offset: 0x001663D0
		internal override PageElement fb(x5 A_0)
		{
			if (this.p != null)
			{
				this.p = null;
			}
			x5 x = x5.a(0f);
			xu a_ = this.b;
			xt a_2 = this.c;
			if (this.b != null)
			{
				A_0 = x5.e(A_0, x5.a(this.a.Header.Height));
			}
			if (this.c != null)
			{
				A_0 = x5.e(A_0, x5.a(this.a.Footer.Height));
			}
			w0 w = new w0(A_0, this.a, true);
			xd xd = new xd(this.a);
			PageElement result;
			if (this.a.m() <= 1 || this.m)
			{
				w.a(this.d, ref xd, this.h, this.a, this.m);
				if (this.m)
				{
					this.m = false;
				}
				if (this.d.e() == null)
				{
					this.d = xd;
					result = this;
				}
				else
				{
					for (xg xg = xd.e(); xg != null; xg = xg.e())
					{
						x = x5.f(x, xg.d());
					}
					if (xd.e() != null)
					{
						xs xs = new xs(x5.c(), this.a, x);
						xs.a(a_);
						xs.a(a_2);
						xs.a(xd);
						xs.h = this.h;
						xs.a(this.g);
						xs.i = true;
						this.i = true;
						xs.l = this.l;
						if (this.q)
						{
							xs.q = false;
						}
						else
						{
							xs.q = this.q;
						}
						xs.r = this.r;
						this.r = false;
						this.e = x5.a(this.a.Header.Height + this.a.Footer.Height);
						for (xg xg = this.d.e(); xg != null; xg = xg.e())
						{
							this.e = x5.f(this.e, xg.d());
						}
						result = xs;
					}
					else
					{
						result = null;
					}
				}
			}
			else if (this.n.Count != this.o + 1 && this.o < this.n.Count)
			{
				this.o++;
				xs xs2 = new xs(x5.c(), this.a, this.a());
				xs2.n = this.n;
				xs2.o = this.o;
				xs2.d = (xe)this.n[this.o];
				xs2.b = this.b;
				xs2.c = this.c;
				xs2.h = this.h;
				xs2.g = this.g;
				xs2.l = this.l;
				xs2.i = true;
				this.i = true;
				if (this.q)
				{
					xs2.q = false;
				}
				else
				{
					xs2.q = this.q;
				}
				xs2.r = this.r;
				this.r = false;
				this.e = x5.a(this.a.Header.Height + this.a.Footer.Height);
				this.e = x5.f(this.e, ((xe)this.d).c());
				if (xs2.d != null && xs2.d.e() != null)
				{
					result = xs2;
				}
				else
				{
					result = null;
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060026D9 RID: 9945 RVA: 0x00167818 File Offset: 0x00166818
		private x5 a()
		{
			x5 a_ = x5.a(this.a.Header.Height + this.a.Footer.Height);
			x5 x = x5.c();
			for (int i = this.o; i < this.n.Count; i++)
			{
				x = x5.f(x, ((xe)this.n[i]).c());
				if (i != this.o)
				{
					x = x5.f(x, a_);
				}
			}
			return x;
		}

		// Token: 0x060026DA RID: 9946 RVA: 0x001678B0 File Offset: 0x001668B0
		internal void a(LayoutWriter A_0, Page A_1)
		{
			xw xw = this.f().f();
			bool flag = this.f().Detail.Elements.e();
			xg xg = this.d.e();
			if (xw.d().b() != 0)
			{
				HybridDictionary hybridDictionary = this.l.b();
				while (xg != null)
				{
					if (xg.gh() || flag)
					{
						for (xx xx = xg.h(); xx != null; xx = xx.b())
						{
							sz sz = (sz)xw.g()[xx.a().fd()];
							if (sz != null)
							{
								sz.a(xg.gc(), hybridDictionary);
							}
							if (flag && xx.a().cb() == 239)
							{
								((xs)xx.a()).a(A_0, A_1);
							}
						}
						xg = xg.e();
					}
					else
					{
						xw.d().a(xg.gc(), hybridDictionary);
						xg = xg.e();
					}
				}
				for (sz.a a = xw.d().a(); a != null; a = a.b)
				{
					((s1)hybridDictionary[a.a]).fu(A_1);
				}
				if (!this.i)
				{
					this.a(A_0, null);
					this.l = null;
				}
			}
			else
			{
				while (xg != null)
				{
					for (xx xx = xg.h(); xx != null; xx = xx.b())
					{
						sz sz = (sz)xw.g()[xx.a().fd()];
						if (sz != null)
						{
							sz.a(A_0, xg.gc());
						}
						if (flag && xx.a().cb() == 239)
						{
							((xs)xx.a()).a(A_0, A_1);
						}
					}
					xg = xg.e();
				}
			}
		}

		// Token: 0x060026DB RID: 9947 RVA: 0x00167B30 File Offset: 0x00166B30
		internal vc g()
		{
			return this.l;
		}

		// Token: 0x060026DC RID: 9948 RVA: 0x00167B48 File Offset: 0x00166B48
		internal bool h()
		{
			return this.i;
		}

		// Token: 0x060026DD RID: 9949 RVA: 0x00167B60 File Offset: 0x00166B60
		internal override PageElement fc()
		{
			return new xs(this);
		}

		// Token: 0x060026DE RID: 9950 RVA: 0x00167B78 File Offset: 0x00166B78
		internal override bool gg()
		{
			return ((xc)this.a).e() != null && ((xc)this.a).e().e();
		}

		// Token: 0x060026DF RID: 9951 RVA: 0x00167BB0 File Offset: 0x00166BB0
		internal void a(bool A_0)
		{
			this.m = A_0;
		}

		// Token: 0x060026E0 RID: 9952 RVA: 0x00167BBC File Offset: 0x00166BBC
		internal bool b(bool A_0)
		{
			bool result;
			if (A_0 && this.o != 0)
			{
				this.p = null;
				this.d = ((xe)this.n[this.o]).a().f();
				this.n = null;
				this.o = 0;
				result = true;
			}
			else
			{
				result = (this.n == null || this.n.Count == 0 || (this.n != null && this.n.Count > 0 && this.o == 0));
			}
			return result;
		}

		// Token: 0x060026E1 RID: 9953 RVA: 0x00167C6C File Offset: 0x00166C6C
		internal bool f(x5 A_0, x5 A_1, bool A_2)
		{
			if (this.n != null && this.n.Count > 0 && this.o == 0 && this.p != null)
			{
				this.d = this.p;
			}
			this.p = this.d.f();
			A_0 = x5.e(A_0, x5.a(this.a.Header.Height + this.a.Footer.Height));
			A_1 = x5.e(A_1, x5.a(this.a.Header.Height + this.a.Footer.Height));
			if (x5.h(this.a(A_0), w0.d))
			{
				A_0 = A_1;
				if (x5.h(this.a(A_0), w0.d))
				{
					this.n = null;
					this.d = this.p;
					this.p = null;
					return false;
				}
			}
			this.n = new ArrayList();
			this.o = 0;
			this.a(this.a, A_0, A_1, A_2);
			bool result;
			if (this.n.Count == 0)
			{
				this.n = null;
				this.d = this.p;
				this.p = null;
				result = false;
			}
			else
			{
				this.d = (xe)this.n[0];
				x5 a_ = ((xe)this.n[0]).c();
				for (int i = 1; i < this.n.Count; i++)
				{
					a_ = x5.f(a_, x5.f(((xe)this.n[i]).c(), x5.a(this.a.Header.Height + this.a.Footer.Height)));
				}
				this.f = this.e;
				this.e = a_;
				result = true;
			}
			return result;
		}

		// Token: 0x060026E2 RID: 9954 RVA: 0x00167E80 File Offset: 0x00166E80
		private void a(xc A_0, x5 A_1, x5 A_2, bool A_3)
		{
			if (this.a.Detail.AutoSplit)
			{
				rk rk = A_0.f();
				if (rk != rk.a)
				{
					if (rk != rk.b)
					{
						if (rk == rk.c)
						{
							this.c(A_1, A_2, A_3);
						}
					}
					else
					{
						this.d(A_1, A_2, A_3);
					}
				}
				else
				{
					this.a(A_1, A_2, A_3);
				}
			}
			else
			{
				rk rk = A_0.f();
				if (rk != rk.a)
				{
					if (rk != rk.b)
					{
						if (rk == rk.c)
						{
							this.b(A_1, A_2, A_3);
						}
					}
					else
					{
						this.e(A_1, A_2, A_3);
					}
				}
				else
				{
					this.a(A_1, A_2, A_3);
				}
			}
		}

		// Token: 0x060026E3 RID: 9955 RVA: 0x00167F3C File Offset: 0x00166F3C
		private void e(x5 A_0, x5 A_1, bool A_2)
		{
			ro ro = new ro(A_0, this.a, true);
			xe xe = new xe(this.d.e(), this.a);
			xe xe2 = null;
			x5 a_ = x5.c();
			xe a_2 = null;
			if (A_2)
			{
				a_2 = xe.b();
			}
			bool flag = ro.a(xe, ref xe2, ref a_);
			if (!x5.c(xe.d(), A_0))
			{
				if (A_2)
				{
					xe.a(a_2);
				}
				if (!flag)
				{
					ro = new ro(A_1, this.a, true);
				}
				while (!flag)
				{
					a_ = x5.c();
					this.n.Add(xe);
					xe = xe2;
					if (A_2)
					{
						a_2 = xe.b();
					}
					flag = ro.a(xe, ref xe2, ref a_);
					if (A_2)
					{
						xe.a(a_2);
					}
				}
				this.n.Add(xe);
				ro.a(xe, a_);
			}
		}

		// Token: 0x060026E4 RID: 9956 RVA: 0x00168048 File Offset: 0x00167048
		private void d(x5 A_0, x5 A_1, bool A_2)
		{
			ro ro = new ro(A_0, this.a, true);
			xe xe = new xe(this.d.e(), this.a);
			xe xe2 = null;
			xe xe3 = null;
			xe3 = this.a(xe, A_0);
			if (A_2 && xe3 == null)
			{
				xe3 = xe.b();
			}
			bool flag = ro.a(xe, ref xe2, this.h, true);
			if (A_2)
			{
				xe.a(xe3);
			}
			if (!x5.c(xe.d(), A_0))
			{
				if (!flag)
				{
					ro = new ro(A_1, this.a, true);
				}
				while (!flag)
				{
					this.n.Add(xe);
					xe = xe2;
					xe3 = this.a(xe, A_1);
					if (A_2 && xe3 == null)
					{
						xe3 = xe.b();
					}
					flag = ro.a(xe, ref xe2, this.h, true);
					if (A_2)
					{
						xe.a(xe3);
					}
				}
				if (xe3 != null)
				{
					xd a_ = null;
					if (A_2)
					{
						a_ = xe3.b();
					}
					ro.a(ref xe3, this.h);
					if (xe3 != null)
					{
						if (A_2)
						{
							xe3.a(a_);
						}
						this.n.Add(xe3);
					}
					else
					{
						this.n.Add(xe);
					}
				}
				else
				{
					this.n.Add(xe);
				}
			}
		}

		// Token: 0x060026E5 RID: 9957 RVA: 0x001681D8 File Offset: 0x001671D8
		private void c(x5 A_0, x5 A_1, bool A_2)
		{
			ro ro = new ro(A_0, this.a, true);
			xe xe = new xe(this.d.e(), this.a);
			xe xe2 = null;
			xe a_ = null;
			if (A_2)
			{
				a_ = xe.b();
			}
			bool flag = ro.b(xe, ref xe2, this.h);
			if (!x5.c(xe.d(), A_0))
			{
				if (A_2)
				{
					xe.a(a_);
				}
				if (!flag)
				{
					ro = new ro(A_1, this.a, true);
				}
				while (!flag)
				{
					this.n.Add(xe);
					xe = xe2;
					if (A_2)
					{
						a_ = xe.b();
					}
					flag = ro.b(xe, ref xe2, this.h);
					if (A_2)
					{
						xe.a(a_);
					}
				}
				this.n.Add(xe);
			}
		}

		// Token: 0x060026E6 RID: 9958 RVA: 0x001682D4 File Offset: 0x001672D4
		private void b(x5 A_0, x5 A_1, bool A_2)
		{
			ro ro = new ro(A_0, this.a, true);
			xe xe = new xe(this.d.e(), this.a);
			xe xe2 = null;
			xe a_ = null;
			if (A_2)
			{
				a_ = xe.b();
			}
			bool flag = ro.a(xe, ref xe2, this.h);
			if (!x5.c(xe.d(), A_0))
			{
				if (A_2)
				{
					xe.a(a_);
				}
				if (!flag)
				{
					ro = new ro(A_1, this.a, true);
				}
				while (!flag)
				{
					this.n.Add(xe);
					xe = xe2;
					if (A_2)
					{
						a_ = xe.b();
					}
					flag = ro.a(xe, ref xe2, this.h);
					if (A_2)
					{
						xe.a(a_);
					}
				}
				this.n.Add(xe);
			}
		}

		// Token: 0x060026E7 RID: 9959 RVA: 0x001683D0 File Offset: 0x001673D0
		private void a(x5 A_0, x5 A_1, bool A_2)
		{
			ro ro = new ro(A_0, this.a, true);
			xe xe = new xe(this.d.e(), this.a);
			xe xe2 = null;
			xe a_ = null;
			if (A_2)
			{
				a_ = xe.b();
			}
			bool flag = ro.a(xe, ref xe2);
			if (!x5.c(xe.d(), A_0) || !x5.d(A_0, A_1))
			{
				if (A_2)
				{
					xe.a(a_);
				}
				if (!flag)
				{
					ro = new ro(A_1, this.a, true);
				}
				while (!flag)
				{
					this.n.Add(xe);
					xe = xe2;
					if (A_2)
					{
						a_ = xe.b();
					}
					flag = ro.a(xe, ref xe2);
					if (A_2)
					{
						xe.a(a_);
					}
				}
				this.n.Add(xe);
			}
		}

		// Token: 0x060026E8 RID: 9960 RVA: 0x001684CC File Offset: 0x001674CC
		private xe a(xe A_0, x5 A_1)
		{
			x5 a_ = x5.c();
			x5 a_2 = x5.b(A_1, this.a.m() * 2);
			xg xg = A_0.e();
			while (xg != null && x5.d(a_, a_2))
			{
				a_ = x5.f(a_, xg.d());
				xg = xg.e();
			}
			xe result;
			if (xg == null)
			{
				result = A_0.b();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060026E9 RID: 9961 RVA: 0x00168544 File Offset: 0x00167544
		internal bool i()
		{
			return this.q;
		}

		// Token: 0x060026EA RID: 9962 RVA: 0x0016855C File Offset: 0x0016755C
		internal bool j()
		{
			return this.r;
		}

		// Token: 0x060026EB RID: 9963 RVA: 0x00168574 File Offset: 0x00167574
		internal override byte cb()
		{
			return 239;
		}

		// Token: 0x040010D5 RID: 4309
		private new SubReport a;

		// Token: 0x040010D6 RID: 4310
		private xu b = null;

		// Token: 0x040010D7 RID: 4311
		private xt c = null;

		// Token: 0x040010D8 RID: 4312
		private new xd d;

		// Token: 0x040010D9 RID: 4313
		private x5 e;

		// Token: 0x040010DA RID: 4314
		private x5 f = x5.c();

		// Token: 0x040010DB RID: 4315
		private short g = short.MinValue;

		// Token: 0x040010DC RID: 4316
		private bool h = false;

		// Token: 0x040010DD RID: 4317
		private bool i = false;

		// Token: 0x040010DE RID: 4318
		private x5 j;

		// Token: 0x040010DF RID: 4319
		private x5 k;

		// Token: 0x040010E0 RID: 4320
		private vc l = null;

		// Token: 0x040010E1 RID: 4321
		private bool m = false;

		// Token: 0x040010E2 RID: 4322
		private ArrayList n = null;

		// Token: 0x040010E3 RID: 4323
		private new int o = 0;

		// Token: 0x040010E4 RID: 4324
		private xd p;

		// Token: 0x040010E5 RID: 4325
		private bool q = true;

		// Token: 0x040010E6 RID: 4326
		private bool r = true;
	}
}
