using System;
using System.Collections;
using System.Globalization;
using System.Threading;
using ceTe.DynamicPDF.LayoutEngine.Data;
using zz93;

namespace ceTe.DynamicPDF.LayoutEngine
{
	// Token: 0x02000925 RID: 2341
	public class DocumentLayout
	{
		// Token: 0x14000020 RID: 32
		// (add) Token: 0x06005F42 RID: 24386 RVA: 0x0035CFC8 File Offset: 0x0035BFC8
		// (remove) Token: 0x06005F43 RID: 24387 RVA: 0x0035D004 File Offset: 0x0035C004
		public event ReportDataRequiredEventHandler ReportDataRequired
		{
			add
			{
				ReportDataRequiredEventHandler reportDataRequiredEventHandler = this.o;
				ReportDataRequiredEventHandler reportDataRequiredEventHandler2;
				do
				{
					reportDataRequiredEventHandler2 = reportDataRequiredEventHandler;
					ReportDataRequiredEventHandler value2 = (ReportDataRequiredEventHandler)Delegate.Combine(reportDataRequiredEventHandler2, value);
					reportDataRequiredEventHandler = Interlocked.CompareExchange<ReportDataRequiredEventHandler>(ref this.o, value2, reportDataRequiredEventHandler2);
				}
				while (reportDataRequiredEventHandler != reportDataRequiredEventHandler2);
			}
			remove
			{
				ReportDataRequiredEventHandler reportDataRequiredEventHandler = this.o;
				ReportDataRequiredEventHandler reportDataRequiredEventHandler2;
				do
				{
					reportDataRequiredEventHandler2 = reportDataRequiredEventHandler;
					ReportDataRequiredEventHandler value2 = (ReportDataRequiredEventHandler)Delegate.Remove(reportDataRequiredEventHandler2, value);
					reportDataRequiredEventHandler = Interlocked.CompareExchange<ReportDataRequiredEventHandler>(ref this.o, value2, reportDataRequiredEventHandler2);
				}
				while (reportDataRequiredEventHandler != reportDataRequiredEventHandler2);
			}
		}

		// Token: 0x06005F44 RID: 24388 RVA: 0x0035D040 File Offset: 0x0035C040
		internal ReportData a(string A_0, string A_1, LayoutWriter A_2)
		{
			ReportData result;
			if (this.o != null)
			{
				ReportDataRequiredEventArgs reportDataRequiredEventArgs = new ReportDataRequiredEventArgs(A_0, A_1, A_2.Data);
				this.o(this, reportDataRequiredEventArgs);
				result = reportDataRequiredEventArgs.ReportData;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06005F45 RID: 24389 RVA: 0x0035D086 File Offset: 0x0035C086
		public DocumentLayout(string filePath) : this(new DlexFile(filePath))
		{
		}

		// Token: 0x06005F46 RID: 24390 RVA: 0x0035D098 File Offset: 0x0035C098
		public DocumentLayout(DlexFile dlex)
		{
			this.b = dlex.e();
			this.c = dlex.f();
			this.d = dlex.g();
			this.e = dlex.h();
			this.f = dlex.i();
			this.g = dlex.j();
			this.h = new ain(this.b);
			this.a(this.h);
			this.i = new DocumentLayoutPartList(this, dlex.d().a());
			dlex.d().a(this.i);
		}

		// Token: 0x06005F47 RID: 24391 RVA: 0x0035D170 File Offset: 0x0035C170
		internal void a(ain A_0)
		{
			try
			{
				this.l.Add(A_0.d(), A_0);
			}
			catch (Exception)
			{
				if (A_0.d() == null || A_0.d().Length < 1)
				{
					throw new DlexParseException("Null ID Used. All queries within the DPLX file must have a valid ID.");
				}
				throw new DlexParseException("Duplicate ID Used. The ID " + A_0.d() + " can only be used once within the DPLX file.");
			}
		}

		// Token: 0x06005F48 RID: 24392 RVA: 0x0035D1F4 File Offset: 0x0035C1F4
		internal void a(string A_0, object A_1)
		{
			try
			{
				this.l.Add(A_0, A_1);
			}
			catch (Exception)
			{
				throw new DlexParseException("Duplicate ID Used. The ID " + A_0 + " can only be used once within the DLEX file.");
			}
		}

		// Token: 0x06005F49 RID: 24393 RVA: 0x0035D240 File Offset: 0x0035C240
		public object GetElementById(string id)
		{
			return this.l[id];
		}

		// Token: 0x06005F4A RID: 24394 RVA: 0x0035D260 File Offset: 0x0035C260
		public LayoutElement GetLayoutElementById(string id)
		{
			return (LayoutElement)this.l[id];
		}

		// Token: 0x06005F4B RID: 24395 RVA: 0x0035D284 File Offset: 0x0035C284
		public ReportPart GetReportPartById(string id)
		{
			return (ReportPart)this.l[id];
		}

		// Token: 0x06005F4C RID: 24396 RVA: 0x0035D2A8 File Offset: 0x0035C2A8
		internal ain a(string A_0)
		{
			return (ain)this.l[A_0 + "^ForQuery"];
		}

		// Token: 0x06005F4D RID: 24397 RVA: 0x0035D2D8 File Offset: 0x0035C2D8
		internal alo b(string A_0)
		{
			return (alo)this.l[A_0];
		}

		// Token: 0x06005F4E RID: 24398 RVA: 0x0035D2FC File Offset: 0x0035C2FC
		public Document Layout(LayoutData layoutData)
		{
			Document document = new Document();
			document.Title = this.e;
			document.Author = this.c;
			document.Subject = this.f;
			document.Keywords = this.d;
			this.Layout(layoutData, document);
			return document;
		}

		// Token: 0x06005F4F RID: 24399 RVA: 0x0035D354 File Offset: 0x0035C354
		public void Layout(LayoutData layoutData, Document document)
		{
			if (document.Tag == null && this.g)
			{
				document.Tag = new TagOptions();
			}
			document.RequireLicense(32);
			alr alr = new alr(document, this, layoutData);
			alr.m3();
		}

		// Token: 0x17000A14 RID: 2580
		// (get) Token: 0x06005F50 RID: 24400 RVA: 0x0035D3A0 File Offset: 0x0035C3A0
		// (set) Token: 0x06005F51 RID: 24401 RVA: 0x0035D3B8 File Offset: 0x0035C3B8
		public IFormatProvider FormatProvider
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

		// Token: 0x17000A15 RID: 2581
		// (get) Token: 0x06005F52 RID: 24402 RVA: 0x0035D3C4 File Offset: 0x0035C3C4
		// (set) Token: 0x06005F53 RID: 24403 RVA: 0x0035D3DC File Offset: 0x0035C3DC
		public DocumentLayoutPartList LayoutParts
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

		// Token: 0x17000A16 RID: 2582
		// (get) Token: 0x06005F54 RID: 24404 RVA: 0x0035D3E8 File Offset: 0x0035C3E8
		// (set) Token: 0x06005F55 RID: 24405 RVA: 0x0035D400 File Offset: 0x0035C400
		public string BasePhysicalPath
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

		// Token: 0x17000A17 RID: 2583
		// (get) Token: 0x06005F56 RID: 24406 RVA: 0x0035D40C File Offset: 0x0035C40C
		public FontList Fonts
		{
			get
			{
				if (this.m == null)
				{
					this.m = new FontList();
				}
				return this.m;
			}
		}

		// Token: 0x17000A18 RID: 2584
		// (get) Token: 0x06005F57 RID: 24407 RVA: 0x0035D440 File Offset: 0x0035C440
		public FontFamilyList FontFamilies
		{
			get
			{
				if (this.n == null)
				{
					this.n = new FontFamilyList();
				}
				return this.n;
			}
		}

		// Token: 0x17000A19 RID: 2585
		// (get) Token: 0x06005F58 RID: 24408 RVA: 0x0035D474 File Offset: 0x0035C474
		// (set) Token: 0x06005F59 RID: 24409 RVA: 0x0035D48C File Offset: 0x0035C48C
		public string Id
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

		// Token: 0x17000A1A RID: 2586
		// (get) Token: 0x06005F5A RID: 24410 RVA: 0x0035D498 File Offset: 0x0035C498
		// (set) Token: 0x06005F5B RID: 24411 RVA: 0x0035D4B0 File Offset: 0x0035C4B0
		public string Author
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

		// Token: 0x17000A1B RID: 2587
		// (get) Token: 0x06005F5C RID: 24412 RVA: 0x0035D4BC File Offset: 0x0035C4BC
		// (set) Token: 0x06005F5D RID: 24413 RVA: 0x0035D4D4 File Offset: 0x0035C4D4
		public string Keywords
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

		// Token: 0x17000A1C RID: 2588
		// (get) Token: 0x06005F5E RID: 24414 RVA: 0x0035D4E0 File Offset: 0x0035C4E0
		// (set) Token: 0x06005F5F RID: 24415 RVA: 0x0035D4F8 File Offset: 0x0035C4F8
		public string Title
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

		// Token: 0x17000A1D RID: 2589
		// (get) Token: 0x06005F60 RID: 24416 RVA: 0x0035D504 File Offset: 0x0035C504
		// (set) Token: 0x06005F61 RID: 24417 RVA: 0x0035D51C File Offset: 0x0035C51C
		public string Subject
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

		// Token: 0x17000A1E RID: 2590
		// (get) Token: 0x06005F62 RID: 24418 RVA: 0x0035D528 File Offset: 0x0035C528
		// (set) Token: 0x06005F63 RID: 24419 RVA: 0x0035D540 File Offset: 0x0035C540
		public bool Tag
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

		// Token: 0x06005F64 RID: 24420 RVA: 0x0035D54C File Offset: 0x0035C54C
		internal ain a()
		{
			return this.h;
		}

		// Token: 0x04003109 RID: 12553
		internal const string a = "^ForQuery";

		// Token: 0x0400310A RID: 12554
		private string b;

		// Token: 0x0400310B RID: 12555
		private string c;

		// Token: 0x0400310C RID: 12556
		private string d;

		// Token: 0x0400310D RID: 12557
		private string e;

		// Token: 0x0400310E RID: 12558
		private string f;

		// Token: 0x0400310F RID: 12559
		private bool g = false;

		// Token: 0x04003110 RID: 12560
		private ain h = null;

		// Token: 0x04003111 RID: 12561
		private DocumentLayoutPartList i;

		// Token: 0x04003112 RID: 12562
		private IFormatProvider j = CultureInfo.CurrentCulture;

		// Token: 0x04003113 RID: 12563
		private string k;

		// Token: 0x04003114 RID: 12564
		private Hashtable l = new Hashtable();

		// Token: 0x04003115 RID: 12565
		private FontList m = null;

		// Token: 0x04003116 RID: 12566
		private FontFamilyList n = null;

		// Token: 0x04003117 RID: 12567
		private ReportDataRequiredEventHandler o;
	}
}
