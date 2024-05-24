using System;
using System.Reflection;

namespace zz93
{
	// Token: 0x0200000B RID: 11
	[DefaultMember("Item")]
	internal class i
	{
		// Token: 0x06000084 RID: 132 RVA: 0x0001B886 File Offset: 0x0001A886
		internal i()
		{
			this.a = new byte[32];
		}

		// Token: 0x06000085 RID: 133 RVA: 0x0001B89E File Offset: 0x0001A89E
		internal i(int A_0)
		{
			this.a = new byte[A_0];
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0001B8B8 File Offset: 0x0001A8B8
		internal int a()
		{
			return this.b;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0001B8D0 File Offset: 0x0001A8D0
		internal void a(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0001B8DC File Offset: 0x0001A8DC
		internal byte b(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x06000089 RID: 137 RVA: 0x0001B8F8 File Offset: 0x0001A8F8
		internal void a(byte A_0)
		{
			if (this.b == this.a.Length)
			{
				byte[] array = new byte[this.a.Length * 2];
				this.a.CopyTo(array, 0);
				this.a = array;
			}
			this.a[this.b++] = A_0;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0001B95D File Offset: 0x0001A95D
		internal void a(ref i A_0)
		{
			A_0 = new i(this.a.Length);
			Array.Copy(this.a, A_0.a, this.a());
			A_0.a(this.a());
		}

		// Token: 0x04000059 RID: 89
		internal byte[] a;

		// Token: 0x0400005A RID: 90
		private int b;
	}
}
