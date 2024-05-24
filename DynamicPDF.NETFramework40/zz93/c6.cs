using System;
using System.Reflection;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x0200008F RID: 143
	[DefaultMember("Item")]
	internal class c6
	{
		// Token: 0x0600070E RID: 1806 RVA: 0x00060E19 File Offset: 0x0005FE19
		internal c6()
		{
			this.a = new StructureElement[1];
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x00060E3E File Offset: 0x0005FE3E
		internal c6(int A_0)
		{
			this.a = new StructureElement[A_0];
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x00060E64 File Offset: 0x0005FE64
		internal void a(int A_0, StructureElement A_1)
		{
			if (A_0 >= 0)
			{
				if (A_0 >= this.a.Length)
				{
					StructureElement[] array = new StructureElement[A_0 + 5];
					this.a.CopyTo(array, 0);
					this.a = array;
				}
				this.a[A_0] = A_1;
				if (this.b <= A_0)
				{
					this.b = A_0 + 1;
				}
			}
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x00060ED0 File Offset: 0x0005FED0
		internal StructureElement c(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00060EEC File Offset: 0x0005FEEC
		internal int c()
		{
			return this.b;
		}

		// Token: 0x040003C2 RID: 962
		protected StructureElement[] a = null;

		// Token: 0x040003C3 RID: 963
		private int b = 0;
	}
}
