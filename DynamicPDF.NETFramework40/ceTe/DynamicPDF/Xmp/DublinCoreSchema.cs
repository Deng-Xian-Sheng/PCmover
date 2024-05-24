using System;
using zz93;

namespace ceTe.DynamicPDF.Xmp
{
	// Token: 0x02000918 RID: 2328
	public class DublinCoreSchema : XmpSchema
	{
		// Token: 0x06005EE0 RID: 24288 RVA: 0x0035B296 File Offset: 0x0035A296
		internal DublinCoreSchema()
		{
		}

		// Token: 0x170009F2 RID: 2546
		// (get) Token: 0x06005EE1 RID: 24289 RVA: 0x0035B2B4 File Offset: 0x0035A2B4
		public XmpArray Contributors
		{
			get
			{
				if (this.a == null)
				{
					this.a = new XmpArray(ae9.b);
				}
				return this.a;
			}
		}

		// Token: 0x170009F3 RID: 2547
		// (get) Token: 0x06005EE2 RID: 24290 RVA: 0x0035B2EC File Offset: 0x0035A2EC
		// (set) Token: 0x06005EE3 RID: 24291 RVA: 0x0035B304 File Offset: 0x0035A304
		public string Coverage
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x170009F4 RID: 2548
		// (get) Token: 0x06005EE4 RID: 24292 RVA: 0x0035B310 File Offset: 0x0035A310
		public XmpArray Creators
		{
			get
			{
				if (this.c == null)
				{
					this.c = new XmpArray(ae9.a);
				}
				return this.c;
			}
		}

		// Token: 0x170009F5 RID: 2549
		// (get) Token: 0x06005EE5 RID: 24293 RVA: 0x0035B348 File Offset: 0x0035A348
		public XmpArray Date
		{
			get
			{
				if (this.d == null)
				{
					this.d = new XmpArray(ae9.a);
				}
				return this.d;
			}
		}

		// Token: 0x170009F6 RID: 2550
		// (get) Token: 0x06005EE6 RID: 24294 RVA: 0x0035B380 File Offset: 0x0035A380
		public XmpLangAltList Description
		{
			get
			{
				if (this.e == null)
				{
					this.e = new XmpLangAltList();
				}
				return this.e;
			}
		}

		// Token: 0x170009F7 RID: 2551
		// (get) Token: 0x06005EE7 RID: 24295 RVA: 0x0035B3B8 File Offset: 0x0035A3B8
		// (set) Token: 0x06005EE8 RID: 24296 RVA: 0x0035B3D0 File Offset: 0x0035A3D0
		public string Identifier
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

		// Token: 0x170009F8 RID: 2552
		// (get) Token: 0x06005EE9 RID: 24297 RVA: 0x0035B3DC File Offset: 0x0035A3DC
		public XmpArray Publisher
		{
			get
			{
				if (this.h == null)
				{
					this.h = new XmpArray(ae9.b);
				}
				return this.h;
			}
		}

		// Token: 0x170009F9 RID: 2553
		// (get) Token: 0x06005EEA RID: 24298 RVA: 0x0035B414 File Offset: 0x0035A414
		public XmpArray Relation
		{
			get
			{
				if (this.i == null)
				{
					this.i = new XmpArray(ae9.b);
				}
				return this.i;
			}
		}

		// Token: 0x170009FA RID: 2554
		// (get) Token: 0x06005EEB RID: 24299 RVA: 0x0035B44C File Offset: 0x0035A44C
		public XmpLangAltList Rights
		{
			get
			{
				if (this.j == null)
				{
					this.j = new XmpLangAltList();
				}
				return this.j;
			}
		}

		// Token: 0x170009FB RID: 2555
		// (get) Token: 0x06005EEC RID: 24300 RVA: 0x0035B484 File Offset: 0x0035A484
		// (set) Token: 0x06005EED RID: 24301 RVA: 0x0035B49C File Offset: 0x0035A49C
		public string Source
		{
			get
			{
				return this.k;
			}
			set
			{
				this.k = value;
			}
		}

		// Token: 0x170009FC RID: 2556
		// (get) Token: 0x06005EEE RID: 24302 RVA: 0x0035B4A8 File Offset: 0x0035A4A8
		public XmpArray Subject
		{
			get
			{
				if (this.l == null)
				{
					this.l = new XmpArray(ae9.b);
				}
				return this.l;
			}
		}

		// Token: 0x170009FD RID: 2557
		// (get) Token: 0x06005EEF RID: 24303 RVA: 0x0035B4E0 File Offset: 0x0035A4E0
		public XmpLangAltList Title
		{
			get
			{
				if (this.m == null)
				{
					this.m = new XmpLangAltList();
				}
				return this.m;
			}
		}

		// Token: 0x170009FE RID: 2558
		// (get) Token: 0x06005EF0 RID: 24304 RVA: 0x0035B518 File Offset: 0x0035A518
		public XmpArray Type
		{
			get
			{
				if (this.n == null)
				{
					this.n = new XmpArray(ae9.b);
				}
				return this.n;
			}
		}

		// Token: 0x170009FF RID: 2559
		// (get) Token: 0x06005EF1 RID: 24305 RVA: 0x0035B550 File Offset: 0x0035A550
		// (set) Token: 0x06005EF2 RID: 24306 RVA: 0x0035B568 File Offset: 0x0035A568
		public bool ImportKeywords
		{
			get
			{
				return this.o;
			}
			set
			{
				this.o = value;
			}
		}

		// Token: 0x06005EF3 RID: 24307 RVA: 0x0035B574 File Offset: 0x0035A574
		protected internal override void Draw(XmpWriter xwriter)
		{
			xwriter.BeginDescription("http://purl.org/dc/elements/1.1/", "dc", " ");
			if (this.a != null)
			{
				xwriter.Draw("\t\t<dc:contributor>\n");
				this.a.j1(xwriter);
				xwriter.Draw("\t\t</dc:contributor>\n");
			}
			if (this.b != null)
			{
				xwriter.Draw("\t\t<dc:coverage>" + x7.a(this.b) + "</dc:coverage>\n");
			}
			if (xwriter.Author != null && xwriter.Author != string.Empty)
			{
				this.Creators.Add(xwriter.Author);
			}
			if (this.c != null)
			{
				xwriter.Draw("\t\t<dc:creator>\n");
				this.c.j1(xwriter);
				xwriter.Draw("\t\t</dc:creator>\n");
			}
			if (this.d != null)
			{
				xwriter.Draw("\t\t<dc:date>\n");
				this.d.j1(xwriter);
				xwriter.Draw("\t\t</dc:date>\n");
			}
			if (this.e != null)
			{
				xwriter.Draw("\t\t<dc:description>\n");
				this.e.j1(xwriter);
				xwriter.Draw("\t\t</dc:description>\n");
			}
			xwriter.Draw("\t\t<dc:format>" + this.f + "</dc:format>\n");
			if (this.g != null)
			{
				xwriter.Draw("\t\t<dc:identifier>" + x7.a(this.g) + "</dc:identifier>\n");
			}
			if (this.h != null)
			{
				xwriter.Draw("\t\t<dc:publisher>\n");
				this.h.j1(xwriter);
				xwriter.Draw("\t\t</dc:publisher>\n");
			}
			if (this.i != null)
			{
				xwriter.Draw("\t\t<dc:relation>\n");
				this.i.j1(xwriter);
				xwriter.Draw("\t\t</dc:relation>\n");
			}
			if (this.j != null)
			{
				xwriter.Draw("\t\t<dc:rights>\n");
				this.j.j1(xwriter);
				xwriter.Draw("\t\t</dc:rights>\n");
			}
			if (this.k != null)
			{
				xwriter.Draw("\t\t<dc:source>" + x7.a(this.k) + "</dc:source>\n");
			}
			if (this.o && xwriter.Keywords != null)
			{
				string[] array = xwriter.Keywords.Split(",".ToCharArray());
				if (this.l != null)
				{
					foreach (string text in array)
					{
						this.l.Add(text.Trim());
					}
				}
				else
				{
					this.l = new XmpArray(ae9.b);
					foreach (string text in array)
					{
						this.l.Add(text.Trim());
					}
				}
			}
			if (this.l != null)
			{
				xwriter.Draw("\t\t<dc:subject>\n");
				this.l.j1(xwriter);
				xwriter.Draw("\t\t</dc:subject>\n");
			}
			if (this.m != null)
			{
				xwriter.Draw("\t\t<dc:title>\n");
				this.m.j1(xwriter);
				xwriter.Draw("\t\t</dc:title>\n");
			}
			if (this.n != null)
			{
				xwriter.Draw("\t\t<dc:type>\n");
				this.n.j1(xwriter);
				xwriter.Draw("\t\t</dc:type>\n");
			}
			xwriter.EndDescription();
		}

		// Token: 0x040030C9 RID: 12489
		private XmpArray a;

		// Token: 0x040030CA RID: 12490
		private string b;

		// Token: 0x040030CB RID: 12491
		private XmpArray c;

		// Token: 0x040030CC RID: 12492
		private XmpArray d;

		// Token: 0x040030CD RID: 12493
		private XmpLangAltList e;

		// Token: 0x040030CE RID: 12494
		private readonly string f = "application/pdf";

		// Token: 0x040030CF RID: 12495
		private string g;

		// Token: 0x040030D0 RID: 12496
		private XmpArray h;

		// Token: 0x040030D1 RID: 12497
		private XmpArray i;

		// Token: 0x040030D2 RID: 12498
		private XmpLangAltList j;

		// Token: 0x040030D3 RID: 12499
		private string k;

		// Token: 0x040030D4 RID: 12500
		private XmpArray l;

		// Token: 0x040030D5 RID: 12501
		private XmpLangAltList m;

		// Token: 0x040030D6 RID: 12502
		private XmpArray n;

		// Token: 0x040030D7 RID: 12503
		private bool o = true;
	}
}
