using System;
using System.Reflection;

namespace zz93
{
	// Token: 0x02000503 RID: 1283
	[DefaultMember("Item")]
	internal class aho
	{
		// Token: 0x0600342B RID: 13355 RVA: 0x001CF018 File Offset: 0x001CE018
		internal aho(alo A_0, aks A_1)
		{
			this.a = new ahn[A_1.a()];
			int num = 0;
			for (akr akr = A_1.b(); akr != null; akr = akr.a())
			{
				this.a[num++] = new ahn(A_0, akr);
			}
		}

		// Token: 0x0600342C RID: 13356 RVA: 0x001CF074 File Offset: 0x001CE074
		internal aho(alo A_0, aks A_1, ref bool A_2)
		{
			this.a = new ahn[A_1.a()];
			int num = 0;
			for (akr akr = A_1.b(); akr != null; akr = akr.a())
			{
				if (!A_2)
				{
					A_2 = (akr.f() != null);
				}
				this.a[num++] = new ahn(A_0, akr);
			}
		}

		// Token: 0x0600342D RID: 13357 RVA: 0x001CF0E4 File Offset: 0x001CE0E4
		internal int a()
		{
			return this.a.Length;
		}

		// Token: 0x0600342E RID: 13358 RVA: 0x001CF100 File Offset: 0x001CE100
		internal ahn a(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x0400194D RID: 6477
		private ahn[] a;
	}
}
