using System;

namespace zz93
{
	// Token: 0x0200056C RID: 1388
	internal class akk
	{
		// Token: 0x0600374C RID: 14156 RVA: 0x001DEAE2 File Offset: 0x001DDAE2
		internal akk()
		{
		}

		// Token: 0x0600374D RID: 14157 RVA: 0x001DEAFC File Offset: 0x001DDAFC
		internal void a(object A_0)
		{
			if (this.b == null)
			{
				this.a = (this.b = new akk.a(A_0));
			}
			else
			{
				this.b = (this.b.b = new akk.a(A_0));
			}
		}

		// Token: 0x0600374E RID: 14158 RVA: 0x001DEB4F File Offset: 0x001DDB4F
		internal void a()
		{
			this.b = this.a;
		}

		// Token: 0x0600374F RID: 14159 RVA: 0x001DEB60 File Offset: 0x001DDB60
		internal object b()
		{
			object result = this.b.a;
			this.b = this.b.b;
			return result;
		}

		// Token: 0x06003750 RID: 14160 RVA: 0x001DEB90 File Offset: 0x001DDB90
		internal object c()
		{
			if (this.b == null)
			{
				this.b = this.a;
			}
			object result = this.b.a;
			this.b = this.b.b;
			return result;
		}

		// Token: 0x04001A20 RID: 6688
		private akk.a a = null;

		// Token: 0x04001A21 RID: 6689
		private akk.a b = null;

		// Token: 0x0200056D RID: 1389
		internal class a
		{
			// Token: 0x06003751 RID: 14161 RVA: 0x001DEBDC File Offset: 0x001DDBDC
			internal a(object A_0)
			{
				this.a = A_0;
				this.b = null;
			}

			// Token: 0x04001A22 RID: 6690
			internal object a;

			// Token: 0x04001A23 RID: 6691
			internal akk.a b;
		}
	}
}
