using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000658 RID: 1624
	public class DocumentReaderEvents
	{
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06003D75 RID: 15733 RVA: 0x002155B8 File Offset: 0x002145B8
		// (set) Token: 0x06003D76 RID: 15734 RVA: 0x002155D0 File Offset: 0x002145D0
		public JavaScriptAction WillClose
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

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06003D77 RID: 15735 RVA: 0x002155DC File Offset: 0x002145DC
		// (set) Token: 0x06003D78 RID: 15736 RVA: 0x002155F4 File Offset: 0x002145F4
		public JavaScriptAction WillSave
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

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06003D79 RID: 15737 RVA: 0x00215600 File Offset: 0x00214600
		// (set) Token: 0x06003D7A RID: 15738 RVA: 0x00215618 File Offset: 0x00214618
		public JavaScriptAction DidSave
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

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06003D7B RID: 15739 RVA: 0x00215624 File Offset: 0x00214624
		// (set) Token: 0x06003D7C RID: 15740 RVA: 0x0021563C File Offset: 0x0021463C
		public JavaScriptAction WillPrint
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06003D7D RID: 15741 RVA: 0x00215648 File Offset: 0x00214648
		// (set) Token: 0x06003D7E RID: 15742 RVA: 0x00215660 File Offset: 0x00214660
		public JavaScriptAction DidPrint
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

		// Token: 0x06003D7F RID: 15743 RVA: 0x0021566C File Offset: 0x0021466C
		internal void a(DocumentWriter A_0)
		{
			bool flag = false;
			bool flag2 = false;
			if (this.d != null)
			{
				A_0.WriteName(DocumentReaderEvents.k);
				A_0.WriteDictionaryOpen();
				flag = true;
				flag2 = true;
				A_0.WriteName(DocumentReaderEvents.g);
				A_0.WriteReferenceUnique(new JavaScriptResource(this.d));
			}
			if (this.e != null)
			{
				if (!flag)
				{
					A_0.WriteName(DocumentReaderEvents.k);
					flag = true;
				}
				if (!flag2)
				{
					A_0.WriteDictionaryOpen();
					flag2 = true;
				}
				A_0.WriteName(DocumentReaderEvents.h);
				A_0.WriteReferenceUnique(new JavaScriptResource(this.e));
			}
			if (this.a != null)
			{
				if (!flag)
				{
					A_0.WriteName(DocumentReaderEvents.k);
					flag = true;
				}
				if (!flag2)
				{
					A_0.WriteDictionaryOpen();
					flag2 = true;
				}
				A_0.WriteName(DocumentReaderEvents.i);
				A_0.WriteReferenceUnique(new JavaScriptResource(this.a));
			}
			if (this.b != null)
			{
				if (!flag)
				{
					A_0.WriteName(DocumentReaderEvents.k);
					flag = true;
				}
				if (!flag2)
				{
					A_0.WriteDictionaryOpen();
					flag2 = true;
				}
				A_0.WriteName(DocumentReaderEvents.j);
				A_0.WriteReferenceUnique(new JavaScriptResource(this.b));
			}
			if (this.c != null)
			{
				if (!flag)
				{
					A_0.WriteName(DocumentReaderEvents.k);
				}
				if (!flag2)
				{
					A_0.WriteDictionaryOpen();
					flag2 = true;
				}
				A_0.WriteName(DocumentReaderEvents.f);
				A_0.WriteReferenceUnique(new JavaScriptResource(this.c));
			}
			if (flag2)
			{
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x0400211A RID: 8474
		private JavaScriptAction a;

		// Token: 0x0400211B RID: 8475
		private JavaScriptAction b;

		// Token: 0x0400211C RID: 8476
		private JavaScriptAction c;

		// Token: 0x0400211D RID: 8477
		private JavaScriptAction d;

		// Token: 0x0400211E RID: 8478
		private JavaScriptAction e;

		// Token: 0x0400211F RID: 8479
		private static byte[] f = new byte[]
		{
			87,
			67
		};

		// Token: 0x04002120 RID: 8480
		private static byte[] g = new byte[]
		{
			87,
			83
		};

		// Token: 0x04002121 RID: 8481
		private static byte[] h = new byte[]
		{
			68,
			83
		};

		// Token: 0x04002122 RID: 8482
		private static byte[] i = new byte[]
		{
			87,
			80
		};

		// Token: 0x04002123 RID: 8483
		private static byte[] j = new byte[]
		{
			68,
			80
		};

		// Token: 0x04002124 RID: 8484
		private static byte[] k = new byte[]
		{
			65,
			65
		};
	}
}
