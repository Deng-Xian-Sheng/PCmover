using System;
using System.Reflection;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x020005A8 RID: 1448
	[DefaultMember("Item")]
	internal class al3
	{
		// Token: 0x0600398B RID: 14731 RVA: 0x001EFC2C File Offset: 0x001EEC2C
		internal al3()
		{
		}

		// Token: 0x0600398C RID: 14732 RVA: 0x001EFC44 File Offset: 0x001EEC44
		internal void a(ahp A_0)
		{
			if (this.a.Length == this.b)
			{
				ahp[] array = new ahp[this.a.Length * 3];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			this.a[this.b++] = A_0;
		}

		// Token: 0x0600398D RID: 14733 RVA: 0x001EFCAC File Offset: 0x001EECAC
		internal void a(LayoutWriter A_0, alq A_1, char[] A_2)
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].lu(A_0, A_1, A_2);
			}
		}

		// Token: 0x0600398E RID: 14734 RVA: 0x001EFCE4 File Offset: 0x001EECE4
		internal void a(LayoutWriter A_0, akk A_1, alq A_2, char[] A_3)
		{
			int a_ = A_2.b();
			for (int i = 0; i < this.b; i++)
			{
				if (this.a[i].nd())
				{
					A_2.a(i);
					this.a[i].lv(A_0, A_1, A_2, A_3);
				}
			}
			A_2.a(a_);
		}

		// Token: 0x0600398F RID: 14735 RVA: 0x001EFD4C File Offset: 0x001EED4C
		internal void b(LayoutWriter A_0, alq A_1, char[] A_2)
		{
			for (int i = 0; i < this.b; i++)
			{
				if (!this.a[i].nd())
				{
					this.a[i].lu(A_0, A_1, A_2);
				}
				else
				{
					A_1.a(A_1.b() + 1);
				}
			}
		}

		// Token: 0x06003990 RID: 14736 RVA: 0x001EFDA8 File Offset: 0x001EEDA8
		internal int a()
		{
			return this.b;
		}

		// Token: 0x06003991 RID: 14737 RVA: 0x001EFDC0 File Offset: 0x001EEDC0
		internal ahp a(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x04001B6D RID: 7021
		private ahp[] a = new ahp[3];

		// Token: 0x04001B6E RID: 7022
		private int b;
	}
}
