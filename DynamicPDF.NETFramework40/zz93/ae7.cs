using System;
using System.Collections;

namespace zz93
{
	// Token: 0x020004A8 RID: 1192
	internal class ae7
	{
		// Token: 0x0600316A RID: 12650 RVA: 0x001BB6A4 File Offset: 0x001BA6A4
		public void a(object A_0)
		{
			if (this.a == null)
			{
				this.a = new ArrayList();
				this.a.Add(A_0);
				this.c++;
			}
			else
			{
				this.a.Add(A_0);
				this.c++;
			}
		}

		// Token: 0x0600316B RID: 12651 RVA: 0x001BB70C File Offset: 0x001BA70C
		public int a()
		{
			int result;
			if (this.a != null)
			{
				result = this.a.Count;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600316C RID: 12652 RVA: 0x001BB73C File Offset: 0x001BA73C
		public int b()
		{
			return this.b;
		}

		// Token: 0x0600316D RID: 12653 RVA: 0x001BB754 File Offset: 0x001BA754
		public object c()
		{
			int num = this.b;
			return this.a[num + 1];
		}

		// Token: 0x0600316E RID: 12654 RVA: 0x001BB77D File Offset: 0x001BA77D
		public void d()
		{
			this.b = -1;
		}

		// Token: 0x0600316F RID: 12655 RVA: 0x001BB788 File Offset: 0x001BA788
		public object e()
		{
			object result;
			if (this.b == this.c)
			{
				result = null;
			}
			else
			{
				result = this.a[++this.b];
			}
			return result;
		}

		// Token: 0x06003170 RID: 12656 RVA: 0x001BB7D0 File Offset: 0x001BA7D0
		public ae7 f()
		{
			return (ae7)base.MemberwiseClone();
		}

		// Token: 0x04001706 RID: 5894
		private ArrayList a = null;

		// Token: 0x04001707 RID: 5895
		private int b = -1;

		// Token: 0x04001708 RID: 5896
		private int c = -1;
	}
}
