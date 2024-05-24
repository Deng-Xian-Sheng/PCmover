using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000056 RID: 86
	internal class bu
	{
		// Token: 0x060002E5 RID: 741 RVA: 0x0003F5A8 File Offset: 0x0003E5A8
		internal bu(ArrayList A_0, ArrayList A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0003F5D0 File Offset: 0x0003E5D0
		internal void b(DocumentWriter A_0)
		{
			if (this.a != null)
			{
				A_0.WriteName(new byte[]
				{
					69,
					120,
					116,
					71,
					83,
					116,
					97,
					116,
					101
				});
				A_0.WriteDictionaryOpen();
				this.a(A_0);
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0003F61C File Offset: 0x0003E61C
		private void a(DocumentWriter A_0)
		{
			int num = 0;
			foreach (object obj in this.a)
			{
				abg abg = (abg)obj;
				A_0.WriteName(this.b[num].ToString());
				abg.a(A_0);
				num++;
			}
		}

		// Token: 0x040001FF RID: 511
		private ArrayList a = null;

		// Token: 0x04000200 RID: 512
		private ArrayList b = null;
	}
}
