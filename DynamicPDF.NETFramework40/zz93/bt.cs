using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000055 RID: 85
	internal class bt
	{
		// Token: 0x060002E2 RID: 738 RVA: 0x0003F4AC File Offset: 0x0003E4AC
		internal bt(ArrayList A_0, ArrayList A_1)
		{
			this.a = A_0;
			this.b = A_1;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0003F4D4 File Offset: 0x0003E4D4
		internal void b(DocumentWriter A_0)
		{
			if (this.a != null)
			{
				A_0.WriteName(new byte[]
				{
					67,
					111,
					108,
					111,
					114,
					83,
					112,
					97,
					99,
					101
				});
				A_0.WriteDictionaryOpen();
				this.a(A_0);
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0003F520 File Offset: 0x0003E520
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

		// Token: 0x040001FD RID: 509
		private ArrayList a = null;

		// Token: 0x040001FE RID: 510
		private ArrayList b = null;
	}
}
