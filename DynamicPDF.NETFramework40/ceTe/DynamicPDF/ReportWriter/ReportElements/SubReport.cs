using System;
using System.Collections;
using ceTe.DynamicPDF.ReportWriter.Data;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.ReportElements
{
	// Token: 0x02000851 RID: 2129
	public class SubReport : ReportElement, rm, xc
	{
		// Token: 0x06005631 RID: 22065 RVA: 0x00299BC0 File Offset: 0x00298BC0
		internal SubReport(rm A_0, wn A_1)
		{
			this.l = A_0;
			this.a = A_1.f0();
			this.b = A_1.a();
			this.c = A_1.c();
			this.d = A_1.d();
			this.o = A_1.h();
			this.p = A_1.i();
			this.q = A_1.j();
			this.r = A_1.k();
			if (A_1.b() != null)
			{
				this.j = A_1.b().f1();
				A_0.b().DocumentLayout.a(this.j);
			}
			this.t = true;
			this.g = new SubReportHeader(this, A_1.e());
			this.t = false;
			this.h = new DetailSubReportPart(A_1.g(), this);
			this.t = true;
			this.i = new SubReportFooter(this, A_1.f());
			A_0.b().DocumentLayout.a(A_1.f0(), this);
			A_0.a(this);
			if (!A_0.c())
			{
				Report.a(A_0, A_1.f0());
			}
		}

		// Token: 0x06005632 RID: 22066 RVA: 0x00299D24 File Offset: 0x00298D24
		internal override void fi(xf A_0, LayoutWriter A_1)
		{
			throw new Exception("This layout method cannot be called in this context.");
		}

		// Token: 0x06005633 RID: 22067 RVA: 0x00299D34 File Offset: 0x00298D34
		internal override void gi(xh A_0, LayoutWriter A_1)
		{
			if (!this.s)
			{
				this.a();
				this.s = true;
			}
			this.n = A_1;
			xs xs = new xs(this, this.f);
			xs.a(this.e);
			xs.c(A_1);
			if (xs.e() != null)
			{
				A_0.a(xs);
			}
			A_0.a().a(xs);
		}

		// Token: 0x06005634 RID: 22068 RVA: 0x00299DAC File Offset: 0x00298DAC
		internal void a(LayoutWriter A_0)
		{
			if (this.k != null && this.k.b() > 0)
			{
				this.k.b(A_0);
			}
		}

		// Token: 0x06005635 RID: 22069 RVA: 0x00299DEC File Offset: 0x00298DEC
		private void a()
		{
			short num = 0;
			if (this.h.Elements != null && (this.h.AutoSplit || this.h.Elements.g()))
			{
				for (int i = 0; i < this.h.Elements.Count; i++)
				{
					if (this.h.Elements[i].gp())
					{
						for (int j = 0; j < this.h.Elements.Count; j++)
						{
							if (this.h.Elements[j].gj() && x5.d(this.h.Elements[i].gm(), this.h.Elements[j].gn()) && x5.a(this.h.Elements[i].gn(), this.h.Elements[j].gn()))
							{
								if (this.h.Elements[j].gk() == -32768)
								{
									ReportElement reportElement = this.h.Elements[j];
									short num2 = num;
									num = num2 + 1;
									reportElement.gl(num2);
									this.f = true;
								}
								this.h.Elements[i].gq(this.h.Elements[j].gk());
							}
						}
					}
				}
			}
			xw xw = this.f();
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
						reportElement2 = this.h.Elements[0];
					}
					else
					{
						if (!this.v.Contains(text))
						{
							throw new ReportWriterException("The " + text + " reportelement does not exist in the detail of " + this.a);
						}
						reportElement2 = this.l.b().DocumentLayout.GetReportElementById(text);
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
		}

		// Token: 0x17000853 RID: 2131
		// (get) Token: 0x06005636 RID: 22070 RVA: 0x0029A15C File Offset: 0x0029915C
		public float Height
		{
			get
			{
				return this.g.Height + this.h.Height + this.i.Height;
			}
		}

		// Token: 0x17000854 RID: 2132
		// (get) Token: 0x06005637 RID: 22071 RVA: 0x0029A194 File Offset: 0x00299194
		// (set) Token: 0x06005638 RID: 22072 RVA: 0x0029A1B2 File Offset: 0x002991B2
		public float X
		{
			get
			{
				return x5.b(this.b);
			}
			set
			{
				this.b = x5.a(value);
			}
		}

		// Token: 0x17000855 RID: 2133
		// (get) Token: 0x06005639 RID: 22073 RVA: 0x0029A1C4 File Offset: 0x002991C4
		// (set) Token: 0x0600563A RID: 22074 RVA: 0x0029A1DC File Offset: 0x002991DC
		public Query Query
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

		// Token: 0x17000856 RID: 2134
		// (get) Token: 0x0600563B RID: 22075 RVA: 0x0029A1E8 File Offset: 0x002991E8
		// (set) Token: 0x0600563C RID: 22076 RVA: 0x0029A206 File Offset: 0x00299206
		public float Y
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

		// Token: 0x17000857 RID: 2135
		// (get) Token: 0x0600563D RID: 22077 RVA: 0x0029A218 File Offset: 0x00299218
		// (set) Token: 0x0600563E RID: 22078 RVA: 0x0029A236 File Offset: 0x00299236
		public float Width
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

		// Token: 0x0600563F RID: 22079 RVA: 0x0029A248 File Offset: 0x00299248
		internal override bool gj()
		{
			return true;
		}

		// Token: 0x06005640 RID: 22080 RVA: 0x0029A25C File Offset: 0x0029925C
		internal override x5 gm()
		{
			return this.c;
		}

		// Token: 0x06005641 RID: 22081 RVA: 0x0029A274 File Offset: 0x00299274
		internal override x5 gn()
		{
			return x5.f(this.c, x5.a(this.Height));
		}

		// Token: 0x17000858 RID: 2136
		// (get) Token: 0x06005642 RID: 22082 RVA: 0x0029A2A0 File Offset: 0x002992A0
		// (set) Token: 0x06005643 RID: 22083 RVA: 0x0029A2B8 File Offset: 0x002992B8
		public SubReportHeader Header
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x17000859 RID: 2137
		// (get) Token: 0x06005644 RID: 22084 RVA: 0x0029A2C4 File Offset: 0x002992C4
		// (set) Token: 0x06005645 RID: 22085 RVA: 0x0029A2DC File Offset: 0x002992DC
		public SubReportFooter Footer
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

		// Token: 0x1700085A RID: 2138
		// (get) Token: 0x06005646 RID: 22086 RVA: 0x0029A2E8 File Offset: 0x002992E8
		// (set) Token: 0x06005647 RID: 22087 RVA: 0x0029A300 File Offset: 0x00299300
		public DetailSubReportPart Detail
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

		// Token: 0x06005648 RID: 22088 RVA: 0x0029A30C File Offset: 0x0029930C
		sz rm.b()
		{
			if (this.k == null)
			{
				this.k = new sz();
			}
			return this.k;
		}

		// Token: 0x06005649 RID: 22089 RVA: 0x0029A344 File Offset: 0x00299344
		string rm.c()
		{
			return this.a;
		}

		// Token: 0x0600564A RID: 22090 RVA: 0x0029A35C File Offset: 0x0029935C
		DocumentLayoutPart rm.d()
		{
			return this.l.b();
		}

		// Token: 0x0600564B RID: 22091 RVA: 0x0029A37C File Offset: 0x0029937C
		internal override short gk()
		{
			return this.e;
		}

		// Token: 0x0600564C RID: 22092 RVA: 0x0029A394 File Offset: 0x00299394
		internal override void gl(short A_0)
		{
			this.e = A_0;
		}

		// Token: 0x0600564D RID: 22093 RVA: 0x0029A3A0 File Offset: 0x002993A0
		internal rm e()
		{
			return this.l;
		}

		// Token: 0x0600564E RID: 22094 RVA: 0x0029A3B8 File Offset: 0x002993B8
		internal xw f()
		{
			if (this.m == null)
			{
				this.m = new xw();
			}
			return this.m;
		}

		// Token: 0x0600564F RID: 22095 RVA: 0x0029A3F0 File Offset: 0x002993F0
		internal LayoutWriter g()
		{
			return this.n;
		}

		// Token: 0x06005650 RID: 22096 RVA: 0x0029A408 File Offset: 0x00299408
		int xc.h()
		{
			return this.o;
		}

		// Token: 0x06005651 RID: 22097 RVA: 0x0029A420 File Offset: 0x00299420
		x5 xc.i()
		{
			return this.p;
		}

		// Token: 0x06005652 RID: 22098 RVA: 0x0029A438 File Offset: 0x00299438
		x5 xc.j()
		{
			return this.q;
		}

		// Token: 0x06005653 RID: 22099 RVA: 0x0029A450 File Offset: 0x00299450
		rk xc.k()
		{
			return this.r;
		}

		// Token: 0x06005654 RID: 22100 RVA: 0x0029A468 File Offset: 0x00299468
		bool xc.l()
		{
			return this.h.AutoSplit;
		}

		// Token: 0x06005655 RID: 22101 RVA: 0x0029A488 File Offset: 0x00299488
		internal override ushort fk()
		{
			return 65024;
		}

		// Token: 0x06005656 RID: 22102 RVA: 0x0029A4A0 File Offset: 0x002994A0
		internal int m()
		{
			return this.o;
		}

		// Token: 0x06005657 RID: 22103 RVA: 0x0029A4B8 File Offset: 0x002994B8
		ReportElementList xc.n()
		{
			return this.h.Elements;
		}

		// Token: 0x06005658 RID: 22104 RVA: 0x0029A4D8 File Offset: 0x002994D8
		bool rm.o()
		{
			return this.t;
		}

		// Token: 0x06005659 RID: 22105 RVA: 0x0029A4F0 File Offset: 0x002994F0
		void rm.a(SubReport A_0)
		{
			SubReport.a(A_0, ref this.u);
		}

		// Token: 0x0600565A RID: 22106 RVA: 0x0029A500 File Offset: 0x00299500
		internal static void a(SubReport A_0, ref ArrayList A_1)
		{
			if (A_1 == null)
			{
				A_1 = new ArrayList(2);
			}
			A_1.Add(A_0);
		}

		// Token: 0x0600565B RID: 22107 RVA: 0x0029A530 File Offset: 0x00299530
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

		// Token: 0x0600565C RID: 22108 RVA: 0x0029A570 File Offset: 0x00299570
		internal ArrayList p()
		{
			return this.u;
		}

		// Token: 0x0600565D RID: 22109 RVA: 0x0029A588 File Offset: 0x00299588
		internal ArrayList q()
		{
			return this.v;
		}

		// Token: 0x0600565E RID: 22110 RVA: 0x0029A5A0 File Offset: 0x002995A0
		internal string r()
		{
			return this.a;
		}

		// Token: 0x04002DF0 RID: 11760
		private string a;

		// Token: 0x04002DF1 RID: 11761
		private x5 b;

		// Token: 0x04002DF2 RID: 11762
		private x5 c;

		// Token: 0x04002DF3 RID: 11763
		private x5 d;

		// Token: 0x04002DF4 RID: 11764
		private short e = short.MinValue;

		// Token: 0x04002DF5 RID: 11765
		private bool f;

		// Token: 0x04002DF6 RID: 11766
		private SubReportHeader g;

		// Token: 0x04002DF7 RID: 11767
		private DetailSubReportPart h;

		// Token: 0x04002DF8 RID: 11768
		private SubReportFooter i;

		// Token: 0x04002DF9 RID: 11769
		private Query j;

		// Token: 0x04002DFA RID: 11770
		private sz k;

		// Token: 0x04002DFB RID: 11771
		private rm l;

		// Token: 0x04002DFC RID: 11772
		private xw m;

		// Token: 0x04002DFD RID: 11773
		private LayoutWriter n;

		// Token: 0x04002DFE RID: 11774
		private int o;

		// Token: 0x04002DFF RID: 11775
		private x5 p;

		// Token: 0x04002E00 RID: 11776
		private x5 q;

		// Token: 0x04002E01 RID: 11777
		private rk r;

		// Token: 0x04002E02 RID: 11778
		private bool s = false;

		// Token: 0x04002E03 RID: 11779
		private bool t = true;

		// Token: 0x04002E04 RID: 11780
		private ArrayList u = null;

		// Token: 0x04002E05 RID: 11781
		private ArrayList v = new ArrayList(5);
	}
}
