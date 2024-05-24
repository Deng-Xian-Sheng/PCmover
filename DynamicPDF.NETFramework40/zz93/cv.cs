using System;
using System.Reflection;

namespace zz93
{
	// Token: 0x02000081 RID: 129
	[DefaultMember("Item")]
	internal class cv
	{
		// Token: 0x060005F8 RID: 1528 RVA: 0x000559EF File Offset: 0x000549EF
		internal cv()
		{
			this.a = new cu[1];
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00055A14 File Offset: 0x00054A14
		internal cv(int A_0)
		{
			this.a = new cu[A_0];
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00055A3C File Offset: 0x00054A3C
		internal void a(cu A_0)
		{
			if (this.b == this.a.Length)
			{
				if (this.a.Length != 0)
				{
					cu[] array = new cu[this.a.Length * 2];
					this.a.CopyTo(array, 0);
					this.a = array;
				}
				else
				{
					this.a = new cu[2];
				}
			}
			this.a[this.b++] = A_0;
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00055AC0 File Offset: 0x00054AC0
		internal cu[] a()
		{
			return this.a;
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00055AD8 File Offset: 0x00054AD8
		internal void a(cu[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00055AE4 File Offset: 0x00054AE4
		internal cu a(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00055B00 File Offset: 0x00054B00
		internal int b()
		{
			return this.b;
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x00055B18 File Offset: 0x00054B18
		internal void b(cu A_0)
		{
			for (int i = 0; i < this.b; i++)
			{
				if (this.a[i].Equals(A_0))
				{
					this.a[i] = null;
					cu[] array = new cu[this.a.Length - 1];
					Array.Copy(this.a, array, i);
					if (i + 1 <= array.Length)
					{
						Array.Copy(this.a, i + 1, array, i, this.b - (i + 1));
					}
					this.a = array;
					this.b--;
					break;
				}
			}
		}

		// Token: 0x0400032D RID: 813
		private cu[] a = null;

		// Token: 0x0400032E RID: 814
		private int b = 0;
	}
}
