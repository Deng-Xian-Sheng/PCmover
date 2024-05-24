using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.Threading;
using ceTe.DynamicPDF.ReportWriter.Data;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter
{
	// Token: 0x02000814 RID: 2068
	public class DocumentLayout
	{
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x060053A3 RID: 21411 RVA: 0x00292518 File Offset: 0x00291518
		// (remove) Token: 0x060053A4 RID: 21412 RVA: 0x00292554 File Offset: 0x00291554
		public event DocumentLayoutEventHandler DocumentLayingOut
		{
			add
			{
				DocumentLayoutEventHandler documentLayoutEventHandler = this.p;
				DocumentLayoutEventHandler documentLayoutEventHandler2;
				do
				{
					documentLayoutEventHandler2 = documentLayoutEventHandler;
					DocumentLayoutEventHandler value2 = (DocumentLayoutEventHandler)Delegate.Combine(documentLayoutEventHandler2, value);
					documentLayoutEventHandler = Interlocked.CompareExchange<DocumentLayoutEventHandler>(ref this.p, value2, documentLayoutEventHandler2);
				}
				while (documentLayoutEventHandler != documentLayoutEventHandler2);
			}
			remove
			{
				DocumentLayoutEventHandler documentLayoutEventHandler = this.p;
				DocumentLayoutEventHandler documentLayoutEventHandler2;
				do
				{
					documentLayoutEventHandler2 = documentLayoutEventHandler;
					DocumentLayoutEventHandler value2 = (DocumentLayoutEventHandler)Delegate.Remove(documentLayoutEventHandler2, value);
					documentLayoutEventHandler = Interlocked.CompareExchange<DocumentLayoutEventHandler>(ref this.p, value2, documentLayoutEventHandler2);
				}
				while (documentLayoutEventHandler != documentLayoutEventHandler2);
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060053A5 RID: 21413 RVA: 0x00292590 File Offset: 0x00291590
		// (remove) Token: 0x060053A6 RID: 21414 RVA: 0x002925CC File Offset: 0x002915CC
		public event DocumentLayoutEventHandler DocumentLaidOut
		{
			add
			{
				DocumentLayoutEventHandler documentLayoutEventHandler = this.q;
				DocumentLayoutEventHandler documentLayoutEventHandler2;
				do
				{
					documentLayoutEventHandler2 = documentLayoutEventHandler;
					DocumentLayoutEventHandler value2 = (DocumentLayoutEventHandler)Delegate.Combine(documentLayoutEventHandler2, value);
					documentLayoutEventHandler = Interlocked.CompareExchange<DocumentLayoutEventHandler>(ref this.q, value2, documentLayoutEventHandler2);
				}
				while (documentLayoutEventHandler != documentLayoutEventHandler2);
			}
			remove
			{
				DocumentLayoutEventHandler documentLayoutEventHandler = this.q;
				DocumentLayoutEventHandler documentLayoutEventHandler2;
				do
				{
					documentLayoutEventHandler2 = documentLayoutEventHandler;
					DocumentLayoutEventHandler value2 = (DocumentLayoutEventHandler)Delegate.Remove(documentLayoutEventHandler2, value);
					documentLayoutEventHandler = Interlocked.CompareExchange<DocumentLayoutEventHandler>(ref this.q, value2, documentLayoutEventHandler2);
				}
				while (documentLayoutEventHandler != documentLayoutEventHandler2);
			}
		}

		// Token: 0x060053A7 RID: 21415 RVA: 0x00292608 File Offset: 0x00291608
		public DocumentLayout(string filePath) : this(new DplxFile(filePath))
		{
		}

		// Token: 0x060053A8 RID: 21416 RVA: 0x0029261C File Offset: 0x0029161C
		public DocumentLayout(DplxFile dplx)
		{
			this.c = dplx.f();
			this.d = dplx.g();
			this.e = dplx.h();
			this.f = dplx.i();
			this.g = dplx.j();
			this.h = dplx.k();
			vv vv = dplx.e();
			if (vv != null)
			{
				this.i = vv.f1();
				this.a(this.i);
			}
			this.j = new DocumentLayoutPartList(this, dplx.d().a());
			dplx.d().a(this.j);
		}

		// Token: 0x060053A9 RID: 21417 RVA: 0x00292704 File Offset: 0x00291704
		internal void a(Query A_0)
		{
			try
			{
				this.m.Add(A_0.Id, A_0);
			}
			catch (Exception)
			{
				if (A_0.Id == null || A_0.Id.Length < 1)
				{
					throw new DplxParseException("Null ID Used. All queries within the DPLX file must have a valid ID.");
				}
				throw new DplxParseException("Duplicate ID Used. The ID " + A_0.Id + " can only be used once within the DPLX file.");
			}
		}

		// Token: 0x060053AA RID: 21418 RVA: 0x00292788 File Offset: 0x00291788
		internal void a(string A_0, object A_1)
		{
			try
			{
				this.m.Add(A_0, A_1);
			}
			catch (Exception)
			{
				throw new DplxParseException("Duplicate ID Used. The ID " + A_0 + " can only be used once within the DPLX file.");
			}
		}

		// Token: 0x060053AB RID: 21419 RVA: 0x002927D4 File Offset: 0x002917D4
		public object GetElementById(string id)
		{
			return this.m[id];
		}

		// Token: 0x060053AC RID: 21420 RVA: 0x002927F4 File Offset: 0x002917F4
		public ReportElement GetReportElementById(string id)
		{
			return (ReportElement)this.m[id];
		}

		// Token: 0x060053AD RID: 21421 RVA: 0x00292818 File Offset: 0x00291818
		public ReportPart GetReportPartById(string id)
		{
			return (ReportPart)this.m[id];
		}

		// Token: 0x060053AE RID: 21422 RVA: 0x0029283C File Offset: 0x0029183C
		public Query GetQueryById(string id)
		{
			return (Query)this.m[id];
		}

		// Token: 0x060053AF RID: 21423 RVA: 0x00292860 File Offset: 0x00291860
		internal rm a(string A_0)
		{
			return (rm)this.m[A_0];
		}

		// Token: 0x060053B0 RID: 21424 RVA: 0x00292884 File Offset: 0x00291884
		public Document Run()
		{
			return this.Run(null);
		}

		// Token: 0x060053B1 RID: 21425 RVA: 0x002928A0 File Offset: 0x002918A0
		public Document Run(ParameterDictionary parameters)
		{
			Document document = new Document();
			document.Title = this.f;
			document.Author = this.d;
			document.Subject = this.g;
			document.Keywords = this.e;
			this.Run(parameters, document);
			return document;
		}

		// Token: 0x060053B2 RID: 21426 RVA: 0x002928F6 File Offset: 0x002918F6
		public void Run(Document document)
		{
			this.Run(null, document);
		}

		// Token: 0x060053B3 RID: 21427 RVA: 0x00292904 File Offset: 0x00291904
		public void Run(ParameterDictionary parameters, Document document)
		{
			if (document.Tag == null && this.h)
			{
				document.Tag = new TagOptions();
			}
			document.RequireLicense(33);
			wu wu = new wu(document, this, parameters);
			if (this.p != null)
			{
				this.p(this, new DocumentLayoutEventArgs(wu));
			}
			wu.e0();
			if (this.q != null)
			{
				this.q(this, new DocumentLayoutEventArgs(wu));
			}
		}

		// Token: 0x17000798 RID: 1944
		// (get) Token: 0x060053B4 RID: 21428 RVA: 0x00292990 File Offset: 0x00291990
		// (set) Token: 0x060053B5 RID: 21429 RVA: 0x002929A8 File Offset: 0x002919A8
		public IFormatProvider FormatProvider
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

		// Token: 0x17000799 RID: 1945
		// (get) Token: 0x060053B6 RID: 21430 RVA: 0x002929B4 File Offset: 0x002919B4
		// (set) Token: 0x060053B7 RID: 21431 RVA: 0x002929CC File Offset: 0x002919CC
		public DocumentLayoutPartList LayoutParts
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

		// Token: 0x1700079A RID: 1946
		// (get) Token: 0x060053B8 RID: 21432 RVA: 0x002929D8 File Offset: 0x002919D8
		// (set) Token: 0x060053B9 RID: 21433 RVA: 0x002929F0 File Offset: 0x002919F0
		public string BasePhysicalPath
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
			}
		}

		// Token: 0x1700079B RID: 1947
		// (get) Token: 0x060053BA RID: 21434 RVA: 0x002929FC File Offset: 0x002919FC
		public static ParameterDictionary AppSettings
		{
			get
			{
				return DocumentLayout.a;
			}
		}

		// Token: 0x1700079C RID: 1948
		// (get) Token: 0x060053BB RID: 21435 RVA: 0x00292A14 File Offset: 0x00291A14
		public static ParameterDictionary ConnectionStrings
		{
			get
			{
				return DocumentLayout.b;
			}
		}

		// Token: 0x1700079D RID: 1949
		// (get) Token: 0x060053BC RID: 21436 RVA: 0x00292A2C File Offset: 0x00291A2C
		public FontList Fonts
		{
			get
			{
				if (this.n == null)
				{
					this.n = new FontList();
				}
				return this.n;
			}
		}

		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x060053BD RID: 21437 RVA: 0x00292A60 File Offset: 0x00291A60
		public FontFamilyList FontFamilies
		{
			get
			{
				if (this.o == null)
				{
					this.o = new FontFamilyList();
				}
				return this.o;
			}
		}

		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x060053BE RID: 21438 RVA: 0x00292A94 File Offset: 0x00291A94
		// (set) Token: 0x060053BF RID: 21439 RVA: 0x00292AAC File Offset: 0x00291AAC
		public string Id
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x170007A0 RID: 1952
		// (get) Token: 0x060053C0 RID: 21440 RVA: 0x00292AB8 File Offset: 0x00291AB8
		// (set) Token: 0x060053C1 RID: 21441 RVA: 0x00292AD0 File Offset: 0x00291AD0
		public string Author
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x060053C2 RID: 21442 RVA: 0x00292ADC File Offset: 0x00291ADC
		// (set) Token: 0x060053C3 RID: 21443 RVA: 0x00292AF4 File Offset: 0x00291AF4
		public string Keywords
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x060053C4 RID: 21444 RVA: 0x00292B00 File Offset: 0x00291B00
		// (set) Token: 0x060053C5 RID: 21445 RVA: 0x00292B18 File Offset: 0x00291B18
		public string Title
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x060053C6 RID: 21446 RVA: 0x00292B24 File Offset: 0x00291B24
		// (set) Token: 0x060053C7 RID: 21447 RVA: 0x00292B3C File Offset: 0x00291B3C
		public string Subject
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

		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x060053C8 RID: 21448 RVA: 0x00292B48 File Offset: 0x00291B48
		// (set) Token: 0x060053C9 RID: 21449 RVA: 0x00292B60 File Offset: 0x00291B60
		public bool Tag
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

		// Token: 0x060053CA RID: 21450 RVA: 0x00292B6C File Offset: 0x00291B6C
		internal Query a()
		{
			return this.i;
		}

		// Token: 0x04002CD0 RID: 11472
		private static ParameterDictionary a = new ParameterDictionary(ConfigurationManager.AppSettings);

		// Token: 0x04002CD1 RID: 11473
		private static ParameterDictionary b = new ParameterDictionary(ConfigurationManager.ConnectionStrings);

		// Token: 0x04002CD2 RID: 11474
		private string c;

		// Token: 0x04002CD3 RID: 11475
		private string d;

		// Token: 0x04002CD4 RID: 11476
		private string e;

		// Token: 0x04002CD5 RID: 11477
		private string f;

		// Token: 0x04002CD6 RID: 11478
		private string g;

		// Token: 0x04002CD7 RID: 11479
		private bool h = false;

		// Token: 0x04002CD8 RID: 11480
		private Query i = null;

		// Token: 0x04002CD9 RID: 11481
		private DocumentLayoutPartList j;

		// Token: 0x04002CDA RID: 11482
		private IFormatProvider k = CultureInfo.CurrentCulture;

		// Token: 0x04002CDB RID: 11483
		private string l;

		// Token: 0x04002CDC RID: 11484
		private Hashtable m = new Hashtable();

		// Token: 0x04002CDD RID: 11485
		private FontList n = null;

		// Token: 0x04002CDE RID: 11486
		private FontFamilyList o = null;

		// Token: 0x04002CDF RID: 11487
		private DocumentLayoutEventHandler p;

		// Token: 0x04002CE0 RID: 11488
		private DocumentLayoutEventHandler q;
	}
}
