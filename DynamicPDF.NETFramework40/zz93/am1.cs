using System;
using System.Collections;
using System.Collections.Specialized;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x020005CA RID: 1482
	internal class am1 : PageElement, ru
	{
		// Token: 0x06003A9B RID: 15003 RVA: 0x001F6FE8 File Offset: 0x001F5FE8
		internal am1(SubReport A_0, bool A_1)
		{
			this.a = A_0;
			this.k = x5.a(A_0.X);
			this.l = x5.a(A_0.Y);
			this.h = A_0.nw();
			this.i = A_1;
			this.g = x5.a(A_0.Height);
			this.e = A_0.u();
		}

		// Token: 0x06003A9C RID: 15004 RVA: 0x001F70B8 File Offset: 0x001F60B8
		internal am1(x5 A_0, SubReport A_1, x5 A_2)
		{
			this.a = A_1;
			this.k = x5.a(A_1.X);
			this.l = A_0;
			this.f = x5.f(A_2, x5.a(A_1.Header.Height + A_1.Footer.Height));
			this.h = A_1.nw();
		}

		// Token: 0x06003A9D RID: 15005 RVA: 0x001F7180 File Offset: 0x001F6180
		internal am1(am1 A_0)
		{
			this.k = A_0.k;
			this.l = A_0.l;
			this.a = A_0.a;
			this.f = A_0.f;
			this.i = A_0.i;
			this.h = A_0.h;
			if (A_0.q != null)
			{
				this.q = A_0.q.nj(true);
			}
			this.o = A_0.o;
			this.p = A_0.p;
			this.d = A_0.d.nj(true);
			this.m = A_0.g();
			this.j = A_0.h();
			this.b = A_0.b;
			this.c = A_0.c;
			this.r = A_0.r;
			this.s = A_0.s;
			this.g = A_0.g;
			this.n = A_0.n;
		}

		// Token: 0x06003A9E RID: 15006 RVA: 0x001F72E8 File Offset: 0x001F62E8
		internal void c(LayoutWriter A_0)
		{
			AlternateRow a_ = A_0.m7();
			A_0.m8(AlternateRow.Odd);
			if (this.a.u() != null)
			{
				this.b(A_0);
			}
			else
			{
				this.d(A_0);
			}
			A_0.m8(a_);
		}

		// Token: 0x06003A9F RID: 15007 RVA: 0x001F7338 File Offset: 0x001F6338
		internal void d(LayoutWriter A_0)
		{
			A_0.Data.a(this.a.t(), this.a.c(), A_0);
			this.b = new am3(A_0, this.a.Header);
			this.c = new am2(A_0, this.a.Footer);
			if (A_0.Data.c().HasData)
			{
				this.d = new amg(this.a);
				int num = -1;
				do
				{
					aml aml = this.a.Detail.a(A_0);
					aml.no(++num);
					this.d.a(aml);
					A_0.m9();
					SubReport.a(A_0, this.a.r());
				}
				while (A_0.Data.c().mp(A_0));
			}
			A_0.Data.d();
			this.a(A_0);
		}

		// Token: 0x06003AA0 RID: 15008 RVA: 0x001F7434 File Offset: 0x001F6434
		internal void b()
		{
			if (this.d != null)
			{
				for (aml aml = (aml)this.d.e(); aml != null; aml = (aml)aml.e())
				{
					aml.c();
					this.f = x5.f(this.f, aml.d());
				}
			}
		}

		// Token: 0x06003AA1 RID: 15009 RVA: 0x001F74A0 File Offset: 0x001F64A0
		private void b(LayoutWriter A_0)
		{
			this.b = new am3(A_0, this.a.Header);
			this.c = new am2(A_0, this.a.Footer);
			if (A_0.Data.c().HasData)
			{
				A_0.Data.c().mn();
				this.d = new amg(this.a);
				int num = -1;
				do
				{
					aml aml = this.a.Detail.a(A_0);
					aml.no(++num);
					this.d.a(aml);
					A_0.m9();
					SubReport.a(A_0, this.a.r());
				}
				while (this.a(A_0, this.a.u().a().ma(A_0)));
			}
			A_0.Data.c().mo();
			this.a(A_0);
		}

		// Token: 0x06003AA2 RID: 15010 RVA: 0x001F759C File Offset: 0x001F659C
		private bool a(LayoutWriter A_0, object A_1)
		{
			if (this.a.b() != null && this.a.b().a())
			{
				this.a.b().b().a(A_0);
			}
			bool flag = A_0.Data.c().mp(A_0);
			bool result;
			if (flag)
			{
				object obj = "";
				if (this.a.b() != null)
				{
					obj = this.a.u().a().ma(A_0);
				}
				result = ((A_1 == null && obj != null) || (obj == null && A_1 != null) || (A_1 != null && A_1.Equals(obj)));
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06003AA3 RID: 15011 RVA: 0x001F7660 File Offset: 0x001F6660
		private void a(LayoutWriter A_0)
		{
			and and = this.a.h();
			if (and.d().b() != 0)
			{
				HybridDictionary hybridDictionary = new HybridDictionary();
				for (ahs.a a = and.d().a(); a != null; a = a.b)
				{
					hybridDictionary.Add(a.a, A_0.m4().a(a.a));
					A_0.m4().b(a.a);
				}
				akf akf = new akf();
				akf.a(this.a.h().f());
				this.a.h().a(null);
				akf.a(hybridDictionary);
				this.m = akf;
			}
		}

		// Token: 0x06003AA4 RID: 15012 RVA: 0x001F772C File Offset: 0x001F672C
		public override void Draw(PageWriter writer)
		{
			if (this.d != null)
			{
				StructureElement structureElement = writer.k();
				StructureElement structureElement2 = new StructureElement(new NamedTagType(this.a.t(), TagType.Division));
				structureElement2.Parent = structureElement;
				writer.a(structureElement2);
				this.a(this.a.i(), writer);
				x5 a_ = this.l;
				if (this.b != null)
				{
					writer.SetDimensionsShift(x5.b(this.k), x5.b(a_), 0f, 0f);
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
				a_ = this.d.ni(writer, this.k, x5.f(a_, x5.a(this.a.Header.Height)));
				if (writer.Document.Tag != null)
				{
					writer.a(structureElement2);
				}
				if (this.c != null)
				{
					writer.SetDimensionsShift(x5.b(this.k), x5.b(a_), 0f, 0f);
					this.c.a(this, writer);
					writer.ResetDimensions();
				}
				if (writer.Document.Tag != null)
				{
					writer.a(structureElement);
				}
			}
		}

		// Token: 0x06003AA5 RID: 15013 RVA: 0x001F78E4 File Offset: 0x001F68E4
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
				and and = this.f().h();
				and.d().a(hybridDictionary, a_);
				for (ahs.a a = and.d().a(); a != null; a = a.b)
				{
					A_0.m4().a(a.a, (ahu)hybridDictionary[a.a]);
				}
				this.g().a().a(A_0, true);
			}
		}

		// Token: 0x06003AA6 RID: 15014 RVA: 0x001F799C File Offset: 0x001F699C
		internal ArrayList c()
		{
			return this.o;
		}

		// Token: 0x06003AA7 RID: 15015 RVA: 0x001F79B4 File Offset: 0x001F69B4
		internal int d()
		{
			return this.p;
		}

		// Token: 0x06003AA8 RID: 15016 RVA: 0x001F79CC File Offset: 0x001F69CC
		internal override void ca(x5 A_0)
		{
			this.l = x5.e(this.l, A_0);
		}

		// Token: 0x06003AA9 RID: 15017 RVA: 0x001F79E4 File Offset: 0x001F69E4
		internal override x5 b7()
		{
			return this.l;
		}

		// Token: 0x06003AAA RID: 15018 RVA: 0x001F79FC File Offset: 0x001F69FC
		internal override x5 b8()
		{
			return x5.f(this.l, this.f);
		}

		// Token: 0x06003AAB RID: 15019 RVA: 0x001F7A20 File Offset: 0x001F6A20
		internal amg e()
		{
			return this.d;
		}

		// Token: 0x06003AAC RID: 15020 RVA: 0x001F7A38 File Offset: 0x001F6A38
		internal void a(amg A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06003AAD RID: 15021 RVA: 0x001F7A42 File Offset: 0x001F6A42
		internal void a(am3 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06003AAE RID: 15022 RVA: 0x001F7A4C File Offset: 0x001F6A4C
		internal void a(am2 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06003AAF RID: 15023 RVA: 0x001F7A58 File Offset: 0x001F6A58
		internal override short fd()
		{
			return this.h;
		}

		// Token: 0x06003AB0 RID: 15024 RVA: 0x001F7A70 File Offset: 0x001F6A70
		internal void a(short A_0)
		{
			this.h = A_0;
		}

		// Token: 0x06003AB1 RID: 15025 RVA: 0x001F7A7C File Offset: 0x001F6A7C
		internal SubReport f()
		{
			return this.a;
		}

		// Token: 0x06003AB2 RID: 15026 RVA: 0x001F7A94 File Offset: 0x001F6A94
		void ru.a(acm A_0)
		{
			if (this.d != null)
			{
				if (this.o != null)
				{
					this.f = x5.f(this.f, x5.a(this.a.Header.Height + this.a.Footer.Height));
					A_0.a(this.b7(), x5.f(this.b7(), this.g), x5.e(this.f, this.g));
				}
				else
				{
					this.f = x5.f(this.f, x5.a(this.a.Header.Height + this.a.Footer.Height));
					A_0.a(x5.a(this.a.Y), x5.f(x5.a(this.a.Y), x5.a(this.a.Height)), x5.e(this.f, this.g));
				}
			}
			else
			{
				A_0.a(x5.a(this.a.Y), x5.f(x5.a(this.a.Y), x5.a(this.a.Height)), x5.d(x5.a(this.a.Height)));
			}
		}

		// Token: 0x06003AB3 RID: 15027 RVA: 0x001F7C12 File Offset: 0x001F6C12
		internal override void b5(dv A_0)
		{
			this.l = x5.f(this.l, A_0.a(this.l));
		}

		// Token: 0x06003AB4 RID: 15028 RVA: 0x001F7C34 File Offset: 0x001F6C34
		internal override x5 fa(x5 A_0)
		{
			x5 result;
			if (this.a.o() > 1 && !this.n && (this.o == null || this.o.Count == 0))
			{
				result = al1.d;
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
				if (this.a.o() > 1 && this.o != null && this.o.Count > 0 && this.p > 0)
				{
					if (x5.c(((amh)this.o[this.p]).c(), x2))
					{
						if (this.n)
						{
							this.n = false;
						}
						result = al1.d;
					}
					else
					{
						result = al1.e;
					}
				}
				else
				{
					result = this.a(x2);
				}
			}
			return result;
		}

		// Token: 0x06003AB5 RID: 15029 RVA: 0x001F7D7C File Offset: 0x001F6D7C
		private x5 a(x5 A_0)
		{
			x5 result;
			if (x5.b(A_0, x5.c()))
			{
				if (this.n)
				{
					this.n = false;
				}
				result = al1.d;
			}
			else if (this.d.e() == null)
			{
				result = al1.e;
			}
			else if (x5.c(A_0, this.d.e().d()))
			{
				result = al1.e;
			}
			else if (this.a.Detail.AutoSplit || this.n)
			{
				amk a_ = this.d.e();
				alx alx = new alx();
				ArrayList a_2 = new ArrayList();
				al0.a(alx, A_0, a_);
				al0 al = new al0(A_0);
				al.a(alx, A_0, false, null, a_2, this.i);
				if (alx.a == null)
				{
					if (this.n)
					{
						this.n = false;
					}
					result = al1.d;
				}
				else
				{
					result = al1.e;
				}
			}
			else
			{
				if (this.n)
				{
					this.n = false;
				}
				result = al1.d;
			}
			return result;
		}

		// Token: 0x06003AB6 RID: 15030 RVA: 0x001F7ECC File Offset: 0x001F6ECC
		internal override PageElement fb(x5 A_0)
		{
			if (this.q != null)
			{
				this.q = null;
			}
			x5 x = x5.a(0f);
			am3 a_ = this.b;
			am2 a_2 = this.c;
			if (this.b != null)
			{
				A_0 = x5.e(A_0, x5.a(this.a.Header.Height));
			}
			if (this.c != null)
			{
				A_0 = x5.e(A_0, x5.a(this.a.Footer.Height));
			}
			al1 al = new al1(A_0, this.a, true);
			amg amg = new amg(this.a);
			PageElement result;
			if (this.a.o() <= 1 || this.n)
			{
				al.a(this.d, ref amg, this.i, this.a, this.n);
				if (this.n)
				{
					this.n = false;
				}
				if (this.d.e() == null)
				{
					this.d = amg;
					result = this;
				}
				else
				{
					for (amk amk = amg.e(); amk != null; amk = amk.e())
					{
						x = x5.f(x, amk.d());
					}
					if (amg.e() != null)
					{
						am1 am = new am1(x5.c(), this.a, x);
						am.a(a_);
						am.a(a_2);
						am.a(amg);
						am.i = this.i;
						am.a(this.h);
						am.j = true;
						this.j = true;
						am.m = this.m;
						if (this.r)
						{
							am.r = false;
						}
						else
						{
							am.r = this.r;
						}
						am.s = this.s;
						this.s = false;
						this.f = x5.a(this.a.Header.Height + this.a.Footer.Height);
						for (amk amk = this.d.e(); amk != null; amk = amk.e())
						{
							this.f = x5.f(this.f, amk.d());
						}
						result = am;
					}
					else
					{
						result = null;
					}
				}
			}
			else if (this.o.Count != this.p + 1 && this.p < this.o.Count)
			{
				this.p++;
				am1 am2 = new am1(x5.c(), this.a, this.a());
				am2.o = this.o;
				am2.p = this.p;
				am2.d = (amh)this.o[this.p];
				am2.b = this.b;
				am2.c = this.c;
				am2.i = this.i;
				am2.h = this.h;
				am2.m = this.m;
				am2.j = true;
				this.j = true;
				if (this.r)
				{
					am2.r = false;
				}
				else
				{
					am2.r = this.r;
				}
				am2.s = this.s;
				this.s = false;
				this.f = x5.a(this.a.Header.Height + this.a.Footer.Height);
				this.f = x5.f(this.f, ((amh)this.d).c());
				if (am2.d != null && am2.d.e() != null)
				{
					result = am2;
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

		// Token: 0x06003AB7 RID: 15031 RVA: 0x001F8314 File Offset: 0x001F7314
		private x5 a()
		{
			x5 a_ = x5.a(this.a.Header.Height + this.a.Footer.Height);
			x5 x = x5.c();
			for (int i = this.p; i < this.o.Count; i++)
			{
				x = x5.f(x, ((amh)this.o[i]).c());
				if (i != this.p)
				{
					x = x5.f(x, a_);
				}
			}
			return x;
		}

		// Token: 0x06003AB8 RID: 15032 RVA: 0x001F83AC File Offset: 0x001F73AC
		internal void a(LayoutWriter A_0, Page A_1)
		{
			and and = this.f().h();
			bool flag = this.f().Detail.Elements.e();
			amk amk = this.d.e();
			if (and.d().b() != 0)
			{
				HybridDictionary hybridDictionary = this.m.b();
				while (amk != null)
				{
					if (amk.ns() || flag)
					{
						for (am6 am = amk.h(); am != null; am = am.b())
						{
							ahs ahs = (ahs)and.g()[am.a().fd()];
							if (ahs != null)
							{
								ahs.a(amk.nn(), hybridDictionary);
							}
							if (flag && am.a().cb() == 239)
							{
								((am1)am.a()).a(A_0, A_1);
							}
						}
						amk = amk.e();
					}
					else
					{
						and.d().a(amk.nn(), hybridDictionary);
						amk = amk.e();
					}
				}
				for (ahs.a a = and.d().a(); a != null; a = a.b)
				{
					((ahu)hybridDictionary[a.a]).mk(A_1);
				}
				if (!this.j)
				{
					this.a(A_0, null);
					this.m = null;
				}
			}
			else
			{
				while (amk != null)
				{
					for (am6 am = amk.h(); am != null; am = am.b())
					{
						ahs ahs = (ahs)and.g()[am.a().fd()];
						if (ahs != null)
						{
							ahs.a(A_0, amk.nn());
						}
						if (flag && am.a().cb() == 239)
						{
							((am1)am.a()).a(A_0, A_1);
						}
					}
					amk = amk.e();
				}
			}
		}

		// Token: 0x06003AB9 RID: 15033 RVA: 0x001F862C File Offset: 0x001F762C
		internal akf g()
		{
			return this.m;
		}

		// Token: 0x06003ABA RID: 15034 RVA: 0x001F8644 File Offset: 0x001F7644
		internal bool h()
		{
			return this.j;
		}

		// Token: 0x06003ABB RID: 15035 RVA: 0x001F865C File Offset: 0x001F765C
		internal override PageElement fc()
		{
			return new am1(this);
		}

		// Token: 0x06003ABC RID: 15036 RVA: 0x001F8674 File Offset: 0x001F7674
		internal override bool gg()
		{
			return ((alp)this.a).e() != null && ((alp)this.a).e().e();
		}

		// Token: 0x06003ABD RID: 15037 RVA: 0x001F86AC File Offset: 0x001F76AC
		internal void a(bool A_0)
		{
			this.n = A_0;
		}

		// Token: 0x06003ABE RID: 15038 RVA: 0x001F86B8 File Offset: 0x001F76B8
		internal bool b(bool A_0)
		{
			bool result;
			if (A_0 && this.p != 0)
			{
				this.q = null;
				this.d = ((amh)this.o[this.p]).a().f();
				this.o = null;
				this.p = 0;
				result = true;
			}
			else
			{
				result = (this.o == null || this.o.Count == 0 || (this.o != null && this.o.Count > 0 && this.p == 0));
			}
			return result;
		}

		// Token: 0x06003ABF RID: 15039 RVA: 0x001F8768 File Offset: 0x001F7768
		internal bool f(x5 A_0, x5 A_1, bool A_2)
		{
			if (this.o != null && this.o.Count > 0 && this.p == 0 && this.q != null)
			{
				this.d = this.q;
			}
			this.q = this.d.f();
			A_0 = x5.e(A_0, x5.a(this.a.Header.Height + this.a.Footer.Height));
			A_1 = x5.e(A_1, x5.a(this.a.Header.Height + this.a.Footer.Height));
			if (x5.h(this.a(A_0), al1.d))
			{
				A_0 = A_1;
				if (x5.h(this.a(A_0), al1.d))
				{
					this.o = null;
					this.d = this.q;
					this.q = null;
					return false;
				}
			}
			this.o = new ArrayList();
			this.p = 0;
			this.a(this.a, A_0, A_1, A_2);
			bool result;
			if (this.o.Count == 0)
			{
				this.o = null;
				this.d = this.q;
				this.q = null;
				result = false;
			}
			else
			{
				this.d = (amh)this.o[0];
				x5 a_ = ((amh)this.o[0]).c();
				for (int i = 1; i < this.o.Count; i++)
				{
					a_ = x5.f(a_, x5.f(((amh)this.o[i]).c(), x5.a(this.a.Header.Height + this.a.Footer.Height)));
				}
				this.g = this.f;
				this.f = a_;
				result = true;
			}
			return result;
		}

		// Token: 0x06003AC0 RID: 15040 RVA: 0x001F897C File Offset: 0x001F797C
		private void a(alp A_0, x5 A_1, x5 A_2, bool A_3)
		{
			if (this.a.Detail.AutoSplit)
			{
				akq akq = A_0.f();
				if (akq != akq.a)
				{
					if (akq != akq.b)
					{
						if (akq == akq.c)
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
				akq akq = A_0.f();
				if (akq != akq.a)
				{
					if (akq != akq.b)
					{
						if (akq == akq.c)
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

		// Token: 0x06003AC1 RID: 15041 RVA: 0x001F8A38 File Offset: 0x001F7A38
		private void e(x5 A_0, x5 A_1, bool A_2)
		{
			alz alz = new alz(A_0, this.a, true);
			amh amh = new amh(this.d.e(), this.a);
			amh amh2 = null;
			x5 a_ = x5.c();
			amh a_2 = null;
			if (A_2)
			{
				a_2 = amh.b();
			}
			bool flag = alz.a(amh, ref amh2, ref a_);
			if (!x5.c(amh.d(), A_0))
			{
				if (A_2)
				{
					amh.a(a_2);
				}
				if (!flag)
				{
					alz = new alz(A_1, this.a, true);
				}
				while (!flag)
				{
					a_ = x5.c();
					this.o.Add(amh);
					amh = amh2;
					if (A_2)
					{
						a_2 = amh.b();
					}
					flag = alz.a(amh, ref amh2, ref a_);
					if (A_2)
					{
						amh.a(a_2);
					}
				}
				this.o.Add(amh);
				alz.a(amh, a_);
			}
		}

		// Token: 0x06003AC2 RID: 15042 RVA: 0x001F8B44 File Offset: 0x001F7B44
		private void d(x5 A_0, x5 A_1, bool A_2)
		{
			alz alz = new alz(A_0, this.a, true);
			amh amh = new amh(this.d.e(), this.a);
			amh amh2 = null;
			amh amh3 = null;
			amh3 = this.a(amh, A_0);
			if (A_2 && amh3 == null)
			{
				amh3 = amh.b();
			}
			bool flag = alz.a(amh, ref amh2, this.i, true);
			if (A_2)
			{
				amh.a(amh3);
			}
			if (!x5.c(amh.d(), A_0))
			{
				if (!flag)
				{
					alz = new alz(A_1, this.a, true);
				}
				while (!flag)
				{
					this.o.Add(amh);
					amh = amh2;
					amh3 = this.a(amh, A_1);
					if (A_2 && amh3 == null)
					{
						amh3 = amh.b();
					}
					flag = alz.a(amh, ref amh2, this.i, true);
					if (A_2)
					{
						amh.a(amh3);
					}
				}
				if (amh3 != null)
				{
					amg a_ = null;
					if (A_2)
					{
						a_ = amh3.b();
					}
					alz.a(ref amh3, this.i);
					if (amh3 != null)
					{
						if (A_2)
						{
							amh3.a(a_);
						}
						this.o.Add(amh3);
					}
					else
					{
						this.o.Add(amh);
					}
				}
				else
				{
					this.o.Add(amh);
				}
			}
		}

		// Token: 0x06003AC3 RID: 15043 RVA: 0x001F8CD4 File Offset: 0x001F7CD4
		private void c(x5 A_0, x5 A_1, bool A_2)
		{
			alz alz = new alz(A_0, this.a, true);
			amh amh = new amh(this.d.e(), this.a);
			amh amh2 = null;
			amh a_ = null;
			if (A_2)
			{
				a_ = amh.b();
			}
			bool flag = alz.b(amh, ref amh2, this.i);
			if (!x5.c(amh.d(), A_0))
			{
				if (A_2)
				{
					amh.a(a_);
				}
				if (!flag)
				{
					alz = new alz(A_1, this.a, true);
				}
				while (!flag)
				{
					this.o.Add(amh);
					amh = amh2;
					if (A_2)
					{
						a_ = amh.b();
					}
					flag = alz.b(amh, ref amh2, this.i);
					if (A_2)
					{
						amh.a(a_);
					}
				}
				this.o.Add(amh);
			}
		}

		// Token: 0x06003AC4 RID: 15044 RVA: 0x001F8DD0 File Offset: 0x001F7DD0
		private void b(x5 A_0, x5 A_1, bool A_2)
		{
			alz alz = new alz(A_0, this.a, true);
			amh amh = new amh(this.d.e(), this.a);
			amh amh2 = null;
			amh a_ = null;
			if (A_2)
			{
				a_ = amh.b();
			}
			bool flag = alz.a(amh, ref amh2, this.i);
			if (!x5.c(amh.d(), A_0))
			{
				if (A_2)
				{
					amh.a(a_);
				}
				if (!flag)
				{
					alz = new alz(A_1, this.a, true);
				}
				while (!flag)
				{
					this.o.Add(amh);
					amh = amh2;
					if (A_2)
					{
						a_ = amh.b();
					}
					flag = alz.a(amh, ref amh2, this.i);
					if (A_2)
					{
						amh.a(a_);
					}
				}
				this.o.Add(amh);
			}
		}

		// Token: 0x06003AC5 RID: 15045 RVA: 0x001F8ECC File Offset: 0x001F7ECC
		private void a(x5 A_0, x5 A_1, bool A_2)
		{
			alz alz = new alz(A_0, this.a, true);
			amh amh = new amh(this.d.e(), this.a);
			amh amh2 = null;
			amh a_ = null;
			if (A_2)
			{
				a_ = amh.b();
			}
			bool flag = alz.a(amh, ref amh2);
			if (!x5.c(amh.d(), A_0) || !x5.d(A_0, A_1))
			{
				if (A_2)
				{
					amh.a(a_);
				}
				if (!flag)
				{
					alz = new alz(A_1, this.a, true);
				}
				while (!flag)
				{
					this.o.Add(amh);
					amh = amh2;
					if (A_2)
					{
						a_ = amh.b();
					}
					flag = alz.a(amh, ref amh2);
					if (A_2)
					{
						amh.a(a_);
					}
				}
				this.o.Add(amh);
			}
		}

		// Token: 0x06003AC6 RID: 15046 RVA: 0x001F8FC8 File Offset: 0x001F7FC8
		private amh a(amh A_0, x5 A_1)
		{
			x5 a_ = x5.c();
			x5 a_2 = x5.b(A_1, this.a.o() * 2);
			amk amk = A_0.e();
			while (amk != null && x5.d(a_, a_2))
			{
				a_ = x5.f(a_, amk.d());
				amk = amk.e();
			}
			amh result;
			if (amk == null)
			{
				result = A_0.b();
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06003AC7 RID: 15047 RVA: 0x001F9040 File Offset: 0x001F8040
		internal bool i()
		{
			return this.r;
		}

		// Token: 0x06003AC8 RID: 15048 RVA: 0x001F9058 File Offset: 0x001F8058
		internal bool j()
		{
			return this.s;
		}

		// Token: 0x06003AC9 RID: 15049 RVA: 0x001F9070 File Offset: 0x001F8070
		internal override byte cb()
		{
			return 239;
		}

		// Token: 0x04001BAE RID: 7086
		private new SubReport a;

		// Token: 0x04001BAF RID: 7087
		private am3 b = null;

		// Token: 0x04001BB0 RID: 7088
		private am2 c = null;

		// Token: 0x04001BB1 RID: 7089
		private new amg d;

		// Token: 0x04001BB2 RID: 7090
		private akg e;

		// Token: 0x04001BB3 RID: 7091
		private x5 f;

		// Token: 0x04001BB4 RID: 7092
		private x5 g = x5.c();

		// Token: 0x04001BB5 RID: 7093
		private short h = short.MinValue;

		// Token: 0x04001BB6 RID: 7094
		private bool i = false;

		// Token: 0x04001BB7 RID: 7095
		private bool j = false;

		// Token: 0x04001BB8 RID: 7096
		private x5 k;

		// Token: 0x04001BB9 RID: 7097
		private x5 l;

		// Token: 0x04001BBA RID: 7098
		private akf m = null;

		// Token: 0x04001BBB RID: 7099
		private bool n = false;

		// Token: 0x04001BBC RID: 7100
		private new ArrayList o = null;

		// Token: 0x04001BBD RID: 7101
		private int p = 0;

		// Token: 0x04001BBE RID: 7102
		private amg q;

		// Token: 0x04001BBF RID: 7103
		private bool r = true;

		// Token: 0x04001BC0 RID: 7104
		private bool s = true;
	}
}
