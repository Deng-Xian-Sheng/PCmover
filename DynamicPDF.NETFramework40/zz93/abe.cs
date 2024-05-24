using System;
using System.Collections.Generic;
using System.Reflection;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200041C RID: 1052
	[DefaultMember("Item")]
	internal class abe : abd
	{
		// Token: 0x06002BCE RID: 11214 RVA: 0x001941BF File Offset: 0x001931BF
		internal abe(List<abd> A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002BCF RID: 11215 RVA: 0x001941D4 File Offset: 0x001931D4
		internal override ag9 hy()
		{
			return ag9.e;
		}

		// Token: 0x06002BD0 RID: 11216 RVA: 0x001941E8 File Offset: 0x001931E8
		internal abd a(int A_0)
		{
			return this.a[A_0];
		}

		// Token: 0x06002BD1 RID: 11217 RVA: 0x00194208 File Offset: 0x00193208
		internal int a()
		{
			return this.a.Count;
		}

		// Token: 0x06002BD2 RID: 11218 RVA: 0x00194228 File Offset: 0x00193228
		internal void a(DocumentWriter A_0)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				this.a[i].hz(A_0);
			}
		}

		// Token: 0x06002BD3 RID: 11219 RVA: 0x00194268 File Offset: 0x00193268
		internal void a(agx A_0, DocumentWriter A_1)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				this.a[i].h9(A_0, A_1);
			}
		}

		// Token: 0x06002BD4 RID: 11220 RVA: 0x001942A8 File Offset: 0x001932A8
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				A_0.WriteArrayOpen();
				this.a(A_0);
				A_0.WriteArrayClose();
			}
		}

		// Token: 0x0400149F RID: 5279
		private List<abd> a;
	}
}
