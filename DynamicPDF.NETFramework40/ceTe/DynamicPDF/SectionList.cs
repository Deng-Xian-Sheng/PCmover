using System;
using System.Collections;
using System.Reflection;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006B0 RID: 1712
	[DefaultMember("Item")]
	public class SectionList
	{
		// Token: 0x060041E6 RID: 16870 RVA: 0x00226220 File Offset: 0x00225220
		internal SectionList(Document A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060041E7 RID: 16871 RVA: 0x00226234 File Offset: 0x00225234
		public Section Begin()
		{
			return this.Begin(NumberingStyle.Numeric, string.Empty, null);
		}

		// Token: 0x060041E8 RID: 16872 RVA: 0x00226254 File Offset: 0x00225254
		public Section Begin(NumberingStyle numberingStyle)
		{
			return this.Begin(numberingStyle, string.Empty, null);
		}

		// Token: 0x060041E9 RID: 16873 RVA: 0x00226274 File Offset: 0x00225274
		public Section Begin(string prefix)
		{
			return this.Begin(NumberingStyle.Numeric, prefix, null);
		}

		// Token: 0x060041EA RID: 16874 RVA: 0x00226290 File Offset: 0x00225290
		public Section Begin(Template template)
		{
			return this.Begin(NumberingStyle.Numeric, string.Empty, template);
		}

		// Token: 0x060041EB RID: 16875 RVA: 0x002262B0 File Offset: 0x002252B0
		public Section Begin(NumberingStyle numberingStyle, string prefix)
		{
			return this.Begin(numberingStyle, prefix, null);
		}

		// Token: 0x060041EC RID: 16876 RVA: 0x002262CC File Offset: 0x002252CC
		public Section Begin(NumberingStyle numberingStyle, Template template)
		{
			return this.Begin(numberingStyle, string.Empty, template);
		}

		// Token: 0x060041ED RID: 16877 RVA: 0x002262EC File Offset: 0x002252EC
		public Section Begin(string prefix, Template template)
		{
			return this.Begin(NumberingStyle.Numeric, prefix, template);
		}

		// Token: 0x060041EE RID: 16878 RVA: 0x00226308 File Offset: 0x00225308
		public Section Begin(NumberingStyle numberingStyle, string prefix, Template template)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
				if (this.b.Pages.Count > 0)
				{
					this.c = new Section();
					this.a.Add(this.c);
				}
			}
			if (this.c != null)
			{
				this.b(this.b.Pages.Count);
			}
			this.c = new Section(this.b.Pages.Count, numberingStyle, prefix, template);
			this.a.Add(this.c);
			return this.c;
		}

		// Token: 0x060041EF RID: 16879 RVA: 0x002263CC File Offset: 0x002253CC
		internal void a(int A_0, Section A_1)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
				if (this.b.Pages.Count > 0)
				{
					this.c = new Section();
					this.a.Add(this.c);
				}
			}
			if (this.c != null)
			{
				this.b(A_0);
			}
			this.c = A_1;
			this.a.Add(this.c);
		}

		// Token: 0x060041F0 RID: 16880 RVA: 0x00226460 File Offset: 0x00225460
		internal Section a(int A_0)
		{
			return (Section)this.a[A_0];
		}

		// Token: 0x060041F1 RID: 16881 RVA: 0x00226484 File Offset: 0x00225484
		internal Section a()
		{
			return this.c;
		}

		// Token: 0x060041F2 RID: 16882 RVA: 0x0022649C File Offset: 0x0022549C
		internal int b()
		{
			return (this.a == null) ? 0 : this.a.Count;
		}

		// Token: 0x060041F3 RID: 16883 RVA: 0x002264C5 File Offset: 0x002254C5
		internal void b(int A_0)
		{
			this.c.a(A_0 - this.c.PageIndex);
		}

		// Token: 0x060041F4 RID: 16884 RVA: 0x002264E4 File Offset: 0x002254E4
		internal void a(DocumentWriter A_0)
		{
			if (this.a != null)
			{
				A_0.WriteName(SectionList.d);
				A_0.WriteDictionaryOpen();
				A_0.WriteName(SectionList.e);
				A_0.WriteArrayOpen();
				foreach (object obj in this.a)
				{
					Section section = (Section)obj;
					section.a(A_0);
				}
				A_0.WriteArrayClose();
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x0400249E RID: 9374
		private ArrayList a;

		// Token: 0x0400249F RID: 9375
		private Document b;

		// Token: 0x040024A0 RID: 9376
		private Section c;

		// Token: 0x040024A1 RID: 9377
		private static byte[] d = new byte[]
		{
			80,
			97,
			103,
			101,
			76,
			97,
			98,
			101,
			108,
			115
		};

		// Token: 0x040024A2 RID: 9378
		private static byte[] e = new byte[]
		{
			78,
			117,
			109,
			115
		};
	}
}
