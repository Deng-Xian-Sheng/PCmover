using System;

namespace ceTe.DynamicPDF.ReportWriter.Data
{
	// Token: 0x02000807 RID: 2055
	public class RecordSetStack
	{
		// Token: 0x06005346 RID: 21318 RVA: 0x0029143E File Offset: 0x0029043E
		internal RecordSetStack()
		{
		}

		// Token: 0x06005347 RID: 21319 RVA: 0x0029145C File Offset: 0x0029045C
		internal void a(RecordSet A_0)
		{
			this.b++;
			if (this.a.Length == this.b)
			{
				RecordSet[] array = new RecordSet[this.a.Length * 2];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			this.a[this.b] = A_0;
		}

		// Token: 0x17000787 RID: 1927
		public RecordSet this[string id]
		{
			get
			{
				if (this.b > 0)
				{
					if (this.a[this.b - 1].Id == id)
					{
						return this.a[this.b - 1];
					}
					if (this.a[this.b].Id == id)
					{
						return this.a[this.b];
					}
					for (int i = this.b - 2; i >= 0; i--)
					{
						if (this.a[i].Id == id)
						{
							return this.a[i];
						}
					}
				}
				for (int i = this.b; i >= 0; i--)
				{
					if (this.a[i].Id == id)
					{
						return this.a[i];
					}
				}
				return null;
			}
		}

		// Token: 0x06005349 RID: 21321 RVA: 0x002915D4 File Offset: 0x002905D4
		internal void a()
		{
			this.b--;
		}

		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x0600534A RID: 21322 RVA: 0x002915E8 File Offset: 0x002905E8
		public RecordSet Current
		{
			get
			{
				return this.a[this.b];
			}
		}

		// Token: 0x0600534B RID: 21323 RVA: 0x00291608 File Offset: 0x00290608
		internal RecordSet a(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x04002CAF RID: 11439
		private RecordSet[] a = new RecordSet[1];

		// Token: 0x04002CB0 RID: 11440
		private int b = -1;
	}
}
