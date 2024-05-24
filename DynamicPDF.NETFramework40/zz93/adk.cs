using System;

namespace zz93
{
	// Token: 0x0200046D RID: 1133
	internal class adk
	{
		// Token: 0x06002F13 RID: 12051 RVA: 0x001AC72E File Offset: 0x001AB72E
		internal adk(byte A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002F14 RID: 12052 RVA: 0x001AC740 File Offset: 0x001AB740
		internal void a(add A_0)
		{
			A_0.a(this.a);
			if (this.a == 0)
			{
				for (int i = 0; i < this.d.Length; i++)
				{
					A_0.a(this.d[i]);
				}
			}
			else
			{
				A_0.b((int)this.b);
				for (int i = 0; i < this.e.Length; i++)
				{
					A_0.b((int)this.e[i].a());
					A_0.a(this.e[i].b());
				}
				A_0.b((int)this.c);
			}
		}

		// Token: 0x06002F15 RID: 12053 RVA: 0x001AC7F4 File Offset: 0x001AB7F4
		internal int a()
		{
			int result;
			if (this.a == 0 && this.d != null)
			{
				result = this.d.Length + 1;
			}
			else if (this.a == 3 && this.e != null)
			{
				result = this.e.Length * 3 + 5;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x06002F16 RID: 12054 RVA: 0x001AC858 File Offset: 0x001AB858
		internal byte b()
		{
			return this.a;
		}

		// Token: 0x06002F17 RID: 12055 RVA: 0x001AC870 File Offset: 0x001AB870
		internal ushort c()
		{
			return this.b;
		}

		// Token: 0x06002F18 RID: 12056 RVA: 0x001AC888 File Offset: 0x001AB888
		internal void a(ushort A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002F19 RID: 12057 RVA: 0x001AC894 File Offset: 0x001AB894
		internal ushort d()
		{
			return this.c;
		}

		// Token: 0x06002F1A RID: 12058 RVA: 0x001AC8AC File Offset: 0x001AB8AC
		internal void b(ushort A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06002F1B RID: 12059 RVA: 0x001AC8B8 File Offset: 0x001AB8B8
		internal byte[] e()
		{
			return this.d;
		}

		// Token: 0x06002F1C RID: 12060 RVA: 0x001AC8D0 File Offset: 0x001AB8D0
		internal void a(byte[] A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06002F1D RID: 12061 RVA: 0x001AC8DC File Offset: 0x001AB8DC
		internal adl[] f()
		{
			return this.e;
		}

		// Token: 0x06002F1E RID: 12062 RVA: 0x001AC8F4 File Offset: 0x001AB8F4
		internal void a(adl[] A_0)
		{
			this.e = A_0;
		}

		// Token: 0x04001663 RID: 5731
		private byte a;

		// Token: 0x04001664 RID: 5732
		private ushort b;

		// Token: 0x04001665 RID: 5733
		private ushort c;

		// Token: 0x04001666 RID: 5734
		private byte[] d;

		// Token: 0x04001667 RID: 5735
		private adl[] e;
	}
}
