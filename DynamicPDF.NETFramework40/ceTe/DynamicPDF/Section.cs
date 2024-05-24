using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006AF RID: 1711
	public class Section
	{
		// Token: 0x060041D4 RID: 16852 RVA: 0x00225F43 File Offset: 0x00224F43
		internal Section()
		{
			this.a = 0;
			this.b = NumberingStyle.None;
			this.c = string.Empty;
			this.e = null;
			this.d = 1;
		}

		// Token: 0x060041D5 RID: 16853 RVA: 0x00225F83 File Offset: 0x00224F83
		internal Section(int A_0, NumberingStyle A_1, string A_2, Template A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.e = A_3;
			this.d = 1;
		}

		// Token: 0x060041D6 RID: 16854 RVA: 0x00225FC0 File Offset: 0x00224FC0
		internal Section(int A_0, NumberingStyle A_1, string A_2, int A_3)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.d = A_3;
			this.e = null;
		}

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x060041D7 RID: 16855 RVA: 0x00226000 File Offset: 0x00225000
		// (set) Token: 0x060041D8 RID: 16856 RVA: 0x00226018 File Offset: 0x00225018
		public NumberingStyle NumberingStyle
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

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x060041D9 RID: 16857 RVA: 0x00226024 File Offset: 0x00225024
		// (set) Token: 0x060041DA RID: 16858 RVA: 0x0022603C File Offset: 0x0022503C
		public string Prefix
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

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x060041DB RID: 16859 RVA: 0x00226048 File Offset: 0x00225048
		// (set) Token: 0x060041DC RID: 16860 RVA: 0x00226060 File Offset: 0x00225060
		public int StartingPageNumber
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

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x060041DD RID: 16861 RVA: 0x0022606C File Offset: 0x0022506C
		public int PageIndex
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x060041DE RID: 16862 RVA: 0x00226084 File Offset: 0x00225084
		// (set) Token: 0x060041DF RID: 16863 RVA: 0x0022609C File Offset: 0x0022509C
		public Template Template
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

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x060041E0 RID: 16864 RVA: 0x002260A8 File Offset: 0x002250A8
		// (set) Token: 0x060041E1 RID: 16865 RVA: 0x002260C0 File Offset: 0x002250C0
		public Template StampTemplate
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

		// Token: 0x060041E2 RID: 16866 RVA: 0x002260CC File Offset: 0x002250CC
		internal int a()
		{
			return this.g;
		}

		// Token: 0x060041E3 RID: 16867 RVA: 0x002260E4 File Offset: 0x002250E4
		internal void a(int A_0)
		{
			this.g = A_0;
		}

		// Token: 0x060041E4 RID: 16868 RVA: 0x002260F0 File Offset: 0x002250F0
		internal void a(DocumentWriter A_0)
		{
			A_0.WriteNumber(this.a);
			A_0.WriteDictionaryOpen();
			switch (this.b)
			{
			case NumberingStyle.Numeric:
				A_0.WriteName(83);
				A_0.WriteName(68);
				break;
			case NumberingStyle.AlphabeticLowerCase:
				A_0.WriteName(83);
				A_0.WriteName(97);
				break;
			case NumberingStyle.AlphabeticUpperCase:
				A_0.WriteName(83);
				A_0.WriteName(65);
				break;
			case NumberingStyle.RomanLowerCase:
				A_0.WriteName(83);
				A_0.WriteName(114);
				break;
			case NumberingStyle.RomanUpperCase:
				A_0.WriteName(83);
				A_0.WriteName(82);
				break;
			}
			if (this.c != string.Empty)
			{
				A_0.WriteName(80);
				A_0.WriteText(this.c);
			}
			if (this.d > 1)
			{
				A_0.WriteName(Section.h);
				A_0.WriteNumber(this.d);
			}
			A_0.WriteDictionaryClose();
		}

		// Token: 0x04002496 RID: 9366
		private int a;

		// Token: 0x04002497 RID: 9367
		private NumberingStyle b;

		// Token: 0x04002498 RID: 9368
		private string c;

		// Token: 0x04002499 RID: 9369
		private int d;

		// Token: 0x0400249A RID: 9370
		private Template e;

		// Token: 0x0400249B RID: 9371
		private Template f = null;

		// Token: 0x0400249C RID: 9372
		private int g = -1;

		// Token: 0x0400249D RID: 9373
		private static byte[] h = new byte[]
		{
			83,
			116
		};
	}
}
