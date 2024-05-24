using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Xmp;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006F6 RID: 1782
	public class MergeDocument : Document
	{
		// Token: 0x060044E3 RID: 17635 RVA: 0x00236338 File Offset: 0x00235338
		public MergeDocument()
		{
			base.RequireLicense(4);
		}

		// Token: 0x060044E4 RID: 17636 RVA: 0x00236360 File Offset: 0x00235360
		public MergeDocument(string filePath) : this(new PdfDocument(filePath), MergeOptions.All)
		{
		}

		// Token: 0x060044E5 RID: 17637 RVA: 0x00236376 File Offset: 0x00235376
		public MergeDocument(PdfDocument pdfDocument) : this(pdfDocument, MergeOptions.All)
		{
		}

		// Token: 0x060044E6 RID: 17638 RVA: 0x00236387 File Offset: 0x00235387
		public MergeDocument(string filePath, MergeOptions options) : this(new PdfDocument(filePath), options)
		{
		}

		// Token: 0x060044E7 RID: 17639 RVA: 0x00236399 File Offset: 0x00235399
		public MergeDocument(PdfDocument pdfDocument, MergeOptions options)
		{
			base.RequireLicense(4);
			this.a(pdfDocument, MergeDocument.a(options, this, pdfDocument), true);
		}

		// Token: 0x060044E8 RID: 17640 RVA: 0x002363D2 File Offset: 0x002353D2
		public MergeDocument(string filePath, int startPage, int pageCount) : this(new PdfDocument(filePath), startPage, pageCount, MergeOptions.All)
		{
		}

		// Token: 0x060044E9 RID: 17641 RVA: 0x002363EA File Offset: 0x002353EA
		public MergeDocument(PdfDocument pdfDocument, int startPage, int pageCount) : this(pdfDocument, startPage, pageCount, MergeOptions.All)
		{
		}

		// Token: 0x060044EA RID: 17642 RVA: 0x002363FD File Offset: 0x002353FD
		public MergeDocument(string filePath, int startPage, int pageCount, MergeOptions options) : this(new PdfDocument(filePath), startPage, pageCount, options)
		{
		}

		// Token: 0x060044EB RID: 17643 RVA: 0x00236412 File Offset: 0x00235412
		public MergeDocument(PdfDocument pdfDocument, int startPage, int pageCount, MergeOptions options)
		{
			base.RequireLicense(4);
			this.a(startPage, pageCount, MergeDocument.a(options, this, pdfDocument));
		}

		// Token: 0x060044EC RID: 17644 RVA: 0x0023644C File Offset: 0x0023544C
		public AppendedPage[] Append(string filePath)
		{
			return this.Append(new PdfDocument(filePath), MergeOptions.Append);
		}

		// Token: 0x060044ED RID: 17645 RVA: 0x00236470 File Offset: 0x00235470
		public AppendedPage[] Append(PdfDocument pdfDocument)
		{
			return this.a(1, pdfDocument.Pages.Count, MergeDocument.a(MergeOptions.Append, this, pdfDocument));
		}

		// Token: 0x060044EE RID: 17646 RVA: 0x002364A0 File Offset: 0x002354A0
		public AppendedPage[] Append(string filePath, MergeOptions options)
		{
			PdfDocument pdfDocument = new PdfDocument(filePath);
			return this.a(pdfDocument, MergeDocument.a(options, this, pdfDocument), false);
		}

		// Token: 0x060044EF RID: 17647 RVA: 0x002364CC File Offset: 0x002354CC
		public AppendedPage[] Append(PdfDocument pdfDocument, MergeOptions options)
		{
			return this.a(1, pdfDocument.Pages.Count, MergeDocument.a(options, this, pdfDocument));
		}

		// Token: 0x060044F0 RID: 17648 RVA: 0x002364F8 File Offset: 0x002354F8
		public AppendedPage[] Append(string filePath, int startPage, int pageCount)
		{
			return this.Append(new PdfDocument(filePath), startPage, pageCount, MergeOptions.Append);
		}

		// Token: 0x060044F1 RID: 17649 RVA: 0x00236520 File Offset: 0x00235520
		public AppendedPage[] Append(PdfDocument pdfDocument, int startPage, int pageCount)
		{
			return this.a(startPage, pageCount, MergeDocument.a(MergeOptions.Append, this, pdfDocument));
		}

		// Token: 0x060044F2 RID: 17650 RVA: 0x00236548 File Offset: 0x00235548
		public AppendedPage[] Append(string filePath, int startPage, int pageCount, MergeOptions options)
		{
			PdfDocument a_ = new PdfDocument(filePath);
			return this.a(startPage, pageCount, MergeDocument.a(options, this, a_));
		}

		// Token: 0x060044F3 RID: 17651 RVA: 0x00236574 File Offset: 0x00235574
		public AppendedPage[] Append(PdfDocument pdfDocument, int startPage, int pageCount, MergeOptions options)
		{
			return this.a(startPage, pageCount, MergeDocument.a(options, this, pdfDocument));
		}

		// Token: 0x060044F4 RID: 17652 RVA: 0x00236598 File Offset: 0x00235598
		private new AppendedPage[] a(PdfDocument A_0, abb A_1, bool A_2)
		{
			return this.a(1, A_0.Pages.Count, A_1);
		}

		// Token: 0x060044F5 RID: 17653 RVA: 0x002365C0 File Offset: 0x002355C0
		private new AppendedPage[] a(int A_0, int A_1, abb A_2)
		{
			return A_2.a(A_0, A_1);
		}

		// Token: 0x060044F6 RID: 17654 RVA: 0x002365DC File Offset: 0x002355DC
		internal new static abb a(MergeOptions A_0, MergeDocument A_1, PdfDocument A_2)
		{
			return A_0.a(A_1, A_2);
		}

		// Token: 0x060044F7 RID: 17655 RVA: 0x002365F8 File Offset: 0x002355F8
		public static MergeDocument Merge(string firstDocumentFilePath, string secondDocumentFilePath)
		{
			return MergeDocument.Merge(new PdfDocument(firstDocumentFilePath), MergeOptions.All, new PdfDocument(secondDocumentFilePath), MergeOptions.Append);
		}

		// Token: 0x060044F8 RID: 17656 RVA: 0x00236628 File Offset: 0x00235628
		public static MergeDocument Merge(PdfDocument firstDocument, PdfDocument secondDocument)
		{
			return MergeDocument.Merge(firstDocument, MergeOptions.All, secondDocument, MergeOptions.Append);
		}

		// Token: 0x060044F9 RID: 17657 RVA: 0x0023664C File Offset: 0x0023564C
		public static MergeDocument Merge(string firstDocumentFilePath, MergeOptions firstDocumentOptions, string secondDocumentFilePath, MergeOptions secondDocumentOptions)
		{
			return MergeDocument.Merge(new PdfDocument(firstDocumentFilePath), firstDocumentOptions, new PdfDocument(secondDocumentFilePath), secondDocumentOptions);
		}

		// Token: 0x060044FA RID: 17658 RVA: 0x00236674 File Offset: 0x00235674
		public static MergeDocument Merge(PdfDocument firstDocument, MergeOptions firstDocumentOptions, PdfDocument secondDocument, MergeOptions secondDocumentOptions)
		{
			MergeDocument mergeDocument = new MergeDocument(firstDocument, firstDocumentOptions);
			mergeDocument.Append(secondDocument, secondDocumentOptions);
			return mergeDocument;
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x060044FB RID: 17659 RVA: 0x00236698 File Offset: 0x00235698
		// (set) Token: 0x060044FC RID: 17660 RVA: 0x002366B0 File Offset: 0x002356B0
		public override int InitialPage
		{
			get
			{
				return base.InitialPage;
			}
			set
			{
				this.a = null;
				base.InitialPage = value;
			}
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x060044FD RID: 17661 RVA: 0x002366C4 File Offset: 0x002356C4
		// (set) Token: 0x060044FE RID: 17662 RVA: 0x002366DC File Offset: 0x002356DC
		public override PageZoom InitialPageZoom
		{
			get
			{
				return base.InitialPageZoom;
			}
			set
			{
				this.a = null;
				base.InitialPageZoom = value;
			}
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x060044FF RID: 17663 RVA: 0x002366F0 File Offset: 0x002356F0
		// (set) Token: 0x06004500 RID: 17664 RVA: 0x00236708 File Offset: 0x00235708
		public override XmpMetadata XmpMetadata
		{
			get
			{
				return base.XmpMetadata;
			}
			set
			{
				this.b = null;
				base.XmpMetadata = value;
			}
		}

		// Token: 0x06004501 RID: 17665 RVA: 0x0023671C File Offset: 0x0023571C
		protected override void DrawRootEntries(DocumentWriter writer)
		{
			base.DrawRootEntries(writer);
			if (this.c != null)
			{
				this.c.b(writer);
			}
		}

		// Token: 0x06004502 RID: 17666 RVA: 0x0023674C File Offset: 0x0023574C
		internal override void hv(DocumentWriter A_0)
		{
			if (this.b != null)
			{
				A_0.WriteName(Document.f);
				A_0.WriteReference(new ca(this.b, this));
			}
			else
			{
				base.hv(A_0);
			}
		}

		// Token: 0x06004503 RID: 17667 RVA: 0x00236794 File Offset: 0x00235794
		internal new void a(abd A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06004504 RID: 17668 RVA: 0x0023679E File Offset: 0x0023579E
		internal new void a(abj A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06004505 RID: 17669 RVA: 0x002367A8 File Offset: 0x002357A8
		internal new void a(ab6 A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06004506 RID: 17670 RVA: 0x002367B4 File Offset: 0x002357B4
		internal override void hw(DocumentWriter A_0)
		{
			if (this.a == null)
			{
				base.hw(A_0);
			}
			else
			{
				this.a.hz(A_0);
			}
		}

		// Token: 0x04002656 RID: 9814
		private new abd a = null;

		// Token: 0x04002657 RID: 9815
		private ab6 b = null;

		// Token: 0x04002658 RID: 9816
		private abj c = null;
	}
}
