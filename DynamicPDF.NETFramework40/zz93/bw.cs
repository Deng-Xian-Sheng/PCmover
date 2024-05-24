using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000058 RID: 88
	internal class bw : DocumentResourceList
	{
		// Token: 0x060002EE RID: 750 RVA: 0x0003F7B5 File Offset: 0x0003E7B5
		internal bw(int A_0) : base(A_0)
		{
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0003F7CF File Offset: 0x0003E7CF
		internal bw(int A_0, int A_1) : base(A_0)
		{
			this.c = new int[A_1];
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0003F7F8 File Offset: 0x0003E7F8
		internal new void a(b3 A_0)
		{
			while (this.a < this.a.Count)
			{
				Resource resource = (Resource)this.a[this.a];
				A_0.b((byte)resource.ResourceType);
				resource.Draw(A_0);
				this.a++;
			}
			A_0.b(0);
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0003F864 File Offset: 0x0003E864
		internal new void a()
		{
			this.c[this.b++] = base.b();
		}

		// Token: 0x04000203 RID: 515
		private new int a = 0;

		// Token: 0x04000204 RID: 516
		private new int b = 0;

		// Token: 0x04000205 RID: 517
		private int[] c;
	}
}
