using System;
using System.Reflection;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x0200036F RID: 879
	[DefaultMember("Item")]
	internal class w2
	{
		// Token: 0x06002579 RID: 9593 RVA: 0x0015F100 File Offset: 0x0015E100
		internal w2()
		{
		}

		// Token: 0x0600257A RID: 9594 RVA: 0x0015F118 File Offset: 0x0015E118
		internal void a(q6 A_0)
		{
			if (this.a.Length == this.b)
			{
				q6[] array = new q6[this.a.Length * 3];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			this.a[this.b++] = A_0;
		}

		// Token: 0x0600257B RID: 9595 RVA: 0x0015F180 File Offset: 0x0015E180
		internal void a(LayoutWriter A_0, wt A_1, char[] A_2)
		{
			for (int i = 0; i < this.b; i++)
			{
				this.a[i].ec(A_0, A_1, A_2);
			}
		}

		// Token: 0x0600257C RID: 9596 RVA: 0x0015F1B8 File Offset: 0x0015E1B8
		internal void a(LayoutWriter A_0, vi A_1, wt A_2, char[] A_3)
		{
			int a_ = A_2.b();
			for (int i = 0; i < this.b; i++)
			{
				if (this.a[i].e8())
				{
					A_2.a(i);
					this.a[i].ed(A_0, A_1, A_2, A_3);
				}
			}
			A_2.a(a_);
		}

		// Token: 0x0600257D RID: 9597 RVA: 0x0015F220 File Offset: 0x0015E220
		internal void b(LayoutWriter A_0, wt A_1, char[] A_2)
		{
			for (int i = 0; i < this.b; i++)
			{
				if (!this.a[i].e8())
				{
					this.a[i].ec(A_0, A_1, A_2);
				}
				else
				{
					A_1.a(A_1.b() + 1);
				}
			}
		}

		// Token: 0x0600257E RID: 9598 RVA: 0x0015F27C File Offset: 0x0015E27C
		internal int a()
		{
			return this.b;
		}

		// Token: 0x0600257F RID: 9599 RVA: 0x0015F294 File Offset: 0x0015E294
		internal q6 a(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x04001084 RID: 4228
		private q6[] a = new q6[3];

		// Token: 0x04001085 RID: 4229
		private int b;
	}
}
