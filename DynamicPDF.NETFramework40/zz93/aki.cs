using System;

namespace zz93
{
	// Token: 0x0200056A RID: 1386
	internal class aki
	{
		// Token: 0x0600373C RID: 14140 RVA: 0x001DE026 File Offset: 0x001DD026
		internal aki()
		{
		}

		// Token: 0x0600373D RID: 14141 RVA: 0x001DE050 File Offset: 0x001DD050
		internal void a()
		{
			if (this.d == null)
			{
				this.a = (this.c = (this.d = new akh()));
			}
			else
			{
				akh akh;
				this.d.a(akh = new akh());
				this.d = akh;
			}
		}

		// Token: 0x0600373E RID: 14142 RVA: 0x001DE0AC File Offset: 0x001DD0AC
		internal void a(object A_0)
		{
			if (this.a != null)
			{
				if (this.b == null)
				{
					this.b = this.a;
					this.b.a(A_0);
				}
				while (this.b != this.d)
				{
					this.b = this.b.b();
					this.b.a(A_0);
				}
			}
		}

		// Token: 0x0600373F RID: 14143 RVA: 0x001DE12B File Offset: 0x001DD12B
		internal void b(object A_0)
		{
			this.a.a(A_0);
		}

		// Token: 0x06003740 RID: 14144 RVA: 0x001DE13C File Offset: 0x001DD13C
		internal object b()
		{
			object result;
			if (this.c == null)
			{
				result = this.a.a();
			}
			else
			{
				object obj = this.c.a();
				this.c = this.c.b();
				result = obj;
			}
			return result;
		}

		// Token: 0x06003741 RID: 14145 RVA: 0x001DE18C File Offset: 0x001DD18C
		internal object c()
		{
			return this.a.a();
		}

		// Token: 0x04001A1C RID: 6684
		private akh a = null;

		// Token: 0x04001A1D RID: 6685
		private akh b = null;

		// Token: 0x04001A1E RID: 6686
		private akh c = null;

		// Token: 0x04001A1F RID: 6687
		private akh d = null;
	}
}
