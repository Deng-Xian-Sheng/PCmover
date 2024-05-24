using System;
using System.Collections;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine.LayoutElements
{
	// Token: 0x0200096F RID: 2415
	public class SubReport : LayoutElement, alo, alp
	{
		// Token: 0x0600622A RID: 25130 RVA: 0x0036557C File Offset: 0x0036457C
		internal SubReport(alo A_0, alk A_1)
		{
			this.m = A_0;
			this.a = A_1.mu();
			this.b = A_1.g();
			this.c = A_1.a();
			this.d = A_1.b();
			this.e = A_1.c();
			this.p = A_1.h();
			this.q = A_1.i();
			this.r = A_1.j();
			this.s = A_1.k();
			this.k = new ain(this.a);
			A_0.b().DocumentLayout.a(this.k);
			this.u = true;
			this.h = new SubReportHeader(this, A_1.d());
			this.u = false;
			this.i = new DetailSubReportPart(A_1.f(), this);
			this.u = true;
			this.j = new SubReportFooter(this, A_1.e());
			A_0.b().DocumentLayout.a(A_1.mu(), this);
			A_0.a(this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.mu());
			}
			this.x = A_1.l();
		}

		// Token: 0x0600622B RID: 25131 RVA: 0x003656E9 File Offset: 0x003646E9
		internal override void nt(amj A_0, LayoutWriter A_1)
		{
			throw new Exception("This layout method cannot be called in this context.");
		}

		// Token: 0x0600622C RID: 25132 RVA: 0x003656F8 File Offset: 0x003646F8
		internal override void nu(aml A_0, LayoutWriter A_1)
		{
			if (!this.t)
			{
				this.a();
				this.t = true;
			}
			this.o = A_1;
			am1 am = new am1(this, this.g);
			am.a(this.f);
			am.c(A_1);
			if (am.e() != null)
			{
				A_0.a(am);
			}
			A_0.a().a(am);
		}

		// Token: 0x0600622D RID: 25133 RVA: 0x00365770 File Offset: 0x00364770
		internal void a(LayoutWriter A_0)
		{
			if (this.l != null && this.l.b() > 0)
			{
				this.l.b(A_0);
			}
		}

		// Token: 0x0600622E RID: 25134 RVA: 0x003657B0 File Offset: 0x003647B0
		private void a()
		{
			short num = 0;
			if (this.i.Elements != null && (this.i.AutoSplit || this.i.Elements.g()))
			{
				for (int i = 0; i < this.i.Elements.Count; i++)
				{
					if (this.i.Elements[i].n3())
					{
						for (int j = 0; j < this.i.Elements.Count; j++)
						{
							if (this.i.Elements[j].nv() && x5.d(this.i.Elements[i].ny(), this.i.Elements[j].nz()) && x5.a(this.i.Elements[i].nz(), this.i.Elements[j].nz()))
							{
								if (this.i.Elements[j].nw() == -32768)
								{
									LayoutElement layoutElement = this.i.Elements[j];
									short num2 = num;
									num = num2 + 1;
									layoutElement.nx(num2);
									this.g = true;
								}
								this.i.Elements[i].n4(this.i.Elements[j].nw());
							}
						}
					}
				}
			}
			and and = this.h();
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
						layoutElement2 = this.i.Elements[0];
					}
					else
					{
						if (!this.w.Contains(text))
						{
							throw new LayoutEngineException("The " + text + " reportelement does not exist in the detail of " + this.a);
						}
						layoutElement2 = this.m.b().DocumentLayout.GetLayoutElementById(text);
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
		}

		// Token: 0x17000ADE RID: 2782
		// (get) Token: 0x0600622F RID: 25135 RVA: 0x00365B20 File Offset: 0x00364B20
		public float Height
		{
			get
			{
				return this.h.Height + this.i.Height + this.j.Height;
			}
		}

		// Token: 0x17000ADF RID: 2783
		// (get) Token: 0x06006230 RID: 25136 RVA: 0x00365B58 File Offset: 0x00364B58
		// (set) Token: 0x06006231 RID: 25137 RVA: 0x00365B76 File Offset: 0x00364B76
		public float X
		{
			get
			{
				return x5.b(this.c);
			}
			set
			{
				this.c = x5.a(value);
			}
		}

		// Token: 0x06006232 RID: 25138 RVA: 0x00365B88 File Offset: 0x00364B88
		internal ain b()
		{
			return this.k;
		}

		// Token: 0x06006233 RID: 25139 RVA: 0x00365BA0 File Offset: 0x00364BA0
		internal void a(ain A_0)
		{
			this.k = A_0;
		}

		// Token: 0x17000AE0 RID: 2784
		// (get) Token: 0x06006234 RID: 25140 RVA: 0x00365BAC File Offset: 0x00364BAC
		// (set) Token: 0x06006235 RID: 25141 RVA: 0x00365BCA File Offset: 0x00364BCA
		public float Y
		{
			get
			{
				return x5.b(this.d);
			}
			set
			{
				this.d = x5.a(value);
			}
		}

		// Token: 0x17000AE1 RID: 2785
		// (get) Token: 0x06006236 RID: 25142 RVA: 0x00365BDC File Offset: 0x00364BDC
		// (set) Token: 0x06006237 RID: 25143 RVA: 0x00365BFA File Offset: 0x00364BFA
		public float Width
		{
			get
			{
				return x5.b(this.e);
			}
			set
			{
				this.e = x5.a(value);
			}
		}

		// Token: 0x06006238 RID: 25144 RVA: 0x00365C0C File Offset: 0x00364C0C
		internal string c()
		{
			return this.b;
		}

		// Token: 0x06006239 RID: 25145 RVA: 0x00365C24 File Offset: 0x00364C24
		internal override bool nv()
		{
			return true;
		}

		// Token: 0x0600623A RID: 25146 RVA: 0x00365C38 File Offset: 0x00364C38
		internal override x5 ny()
		{
			return this.d;
		}

		// Token: 0x0600623B RID: 25147 RVA: 0x00365C50 File Offset: 0x00364C50
		internal override x5 nz()
		{
			return x5.f(this.d, x5.a(this.Height));
		}

		// Token: 0x17000AE2 RID: 2786
		// (get) Token: 0x0600623C RID: 25148 RVA: 0x00365C7C File Offset: 0x00364C7C
		// (set) Token: 0x0600623D RID: 25149 RVA: 0x00365C94 File Offset: 0x00364C94
		public SubReportHeader Header
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x17000AE3 RID: 2787
		// (get) Token: 0x0600623E RID: 25150 RVA: 0x00365CA0 File Offset: 0x00364CA0
		// (set) Token: 0x0600623F RID: 25151 RVA: 0x00365CB8 File Offset: 0x00364CB8
		public SubReportFooter Footer
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		// Token: 0x17000AE4 RID: 2788
		// (get) Token: 0x06006240 RID: 25152 RVA: 0x00365CC4 File Offset: 0x00364CC4
		// (set) Token: 0x06006241 RID: 25153 RVA: 0x00365CDC File Offset: 0x00364CDC
		public DetailSubReportPart Detail
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x06006242 RID: 25154 RVA: 0x00365CE8 File Offset: 0x00364CE8
		ahs alo.d()
		{
			if (this.l == null)
			{
				this.l = new ahs();
			}
			return this.l;
		}

		// Token: 0x06006243 RID: 25155 RVA: 0x00365D20 File Offset: 0x00364D20
		string alo.e()
		{
			return this.a;
		}

		// Token: 0x06006244 RID: 25156 RVA: 0x00365D38 File Offset: 0x00364D38
		DocumentLayoutPart alo.f()
		{
			return this.m.b();
		}

		// Token: 0x06006245 RID: 25157 RVA: 0x00365D58 File Offset: 0x00364D58
		internal override short nw()
		{
			return this.f;
		}

		// Token: 0x06006246 RID: 25158 RVA: 0x00365D70 File Offset: 0x00364D70
		internal override void nx(short A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06006247 RID: 25159 RVA: 0x00365D7C File Offset: 0x00364D7C
		internal alo g()
		{
			return this.m;
		}

		// Token: 0x06006248 RID: 25160 RVA: 0x00365D94 File Offset: 0x00364D94
		internal and h()
		{
			if (this.n == null)
			{
				this.n = new and();
			}
			return this.n;
		}

		// Token: 0x06006249 RID: 25161 RVA: 0x00365DCC File Offset: 0x00364DCC
		internal LayoutWriter i()
		{
			return this.o;
		}

		// Token: 0x0600624A RID: 25162 RVA: 0x00365DE4 File Offset: 0x00364DE4
		int alp.j()
		{
			return this.p;
		}

		// Token: 0x0600624B RID: 25163 RVA: 0x00365DFC File Offset: 0x00364DFC
		x5 alp.k()
		{
			return this.q;
		}

		// Token: 0x0600624C RID: 25164 RVA: 0x00365E14 File Offset: 0x00364E14
		x5 alp.l()
		{
			return this.r;
		}

		// Token: 0x0600624D RID: 25165 RVA: 0x00365E2C File Offset: 0x00364E2C
		akq alp.m()
		{
			return this.s;
		}

		// Token: 0x0600624E RID: 25166 RVA: 0x00365E44 File Offset: 0x00364E44
		bool alp.n()
		{
			return this.i.AutoSplit;
		}

		// Token: 0x0600624F RID: 25167 RVA: 0x00365E64 File Offset: 0x00364E64
		internal override ushort n0()
		{
			return 65024;
		}

		// Token: 0x06006250 RID: 25168 RVA: 0x00365E7C File Offset: 0x00364E7C
		internal int o()
		{
			return this.p;
		}

		// Token: 0x06006251 RID: 25169 RVA: 0x00365E94 File Offset: 0x00364E94
		LayoutElementList alp.p()
		{
			return this.i.Elements;
		}

		// Token: 0x06006252 RID: 25170 RVA: 0x00365EB4 File Offset: 0x00364EB4
		bool alo.q()
		{
			return this.u;
		}

		// Token: 0x06006253 RID: 25171 RVA: 0x00365ECC File Offset: 0x00364ECC
		void alo.a(SubReport A_0)
		{
			SubReport.a(A_0, ref this.v);
		}

		// Token: 0x06006254 RID: 25172 RVA: 0x00365EDC File Offset: 0x00364EDC
		internal static void a(SubReport A_0, ref ArrayList A_1)
		{
			if (A_1 == null)
			{
				A_1 = new ArrayList(2);
			}
			A_1.Add(A_0);
		}

		// Token: 0x06006255 RID: 25173 RVA: 0x00365F0C File Offset: 0x00364F0C
		internal static void a(LayoutWriter A_0, ArrayList A_1)
		{
			if (A_1 != null)
			{
				foreach (object obj in A_1)
				{
					((SubReport)obj).a(A_0);
				}
			}
		}

		// Token: 0x06006256 RID: 25174 RVA: 0x00365F4C File Offset: 0x00364F4C
		internal ArrayList r()
		{
			return this.v;
		}

		// Token: 0x06006257 RID: 25175 RVA: 0x00365F64 File Offset: 0x00364F64
		internal ArrayList s()
		{
			return this.w;
		}

		// Token: 0x06006258 RID: 25176 RVA: 0x00365F7C File Offset: 0x00364F7C
		internal string t()
		{
			return this.a;
		}

		// Token: 0x06006259 RID: 25177 RVA: 0x00365F94 File Offset: 0x00364F94
		internal akg u()
		{
			return this.x;
		}

		// Token: 0x0400328B RID: 12939
		private string a;

		// Token: 0x0400328C RID: 12940
		private string b;

		// Token: 0x0400328D RID: 12941
		private x5 c;

		// Token: 0x0400328E RID: 12942
		private x5 d;

		// Token: 0x0400328F RID: 12943
		private x5 e;

		// Token: 0x04003290 RID: 12944
		private short f = short.MinValue;

		// Token: 0x04003291 RID: 12945
		private bool g;

		// Token: 0x04003292 RID: 12946
		private SubReportHeader h;

		// Token: 0x04003293 RID: 12947
		private DetailSubReportPart i;

		// Token: 0x04003294 RID: 12948
		private SubReportFooter j;

		// Token: 0x04003295 RID: 12949
		private ain k;

		// Token: 0x04003296 RID: 12950
		private ahs l;

		// Token: 0x04003297 RID: 12951
		private alo m;

		// Token: 0x04003298 RID: 12952
		private and n;

		// Token: 0x04003299 RID: 12953
		private LayoutWriter o;

		// Token: 0x0400329A RID: 12954
		private int p;

		// Token: 0x0400329B RID: 12955
		private x5 q;

		// Token: 0x0400329C RID: 12956
		private x5 r;

		// Token: 0x0400329D RID: 12957
		private akq s;

		// Token: 0x0400329E RID: 12958
		private bool t = false;

		// Token: 0x0400329F RID: 12959
		private bool u = true;

		// Token: 0x040032A0 RID: 12960
		private ArrayList v = null;

		// Token: 0x040032A1 RID: 12961
		private ArrayList w = new ArrayList(5);

		// Token: 0x040032A2 RID: 12962
		private akg x;
	}
}
