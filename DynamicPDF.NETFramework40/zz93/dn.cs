using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020000A0 RID: 160
	internal class dn
	{
		// Token: 0x060007AF RID: 1967 RVA: 0x0006E9F1 File Offset: 0x0006D9F1
		internal dn()
		{
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x0006EA18 File Offset: 0x0006DA18
		internal dp a()
		{
			if (this.e == null)
			{
				this.e = new dp();
			}
			return this.e;
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x0006EA4C File Offset: 0x0006DA4C
		internal @do b()
		{
			if (this.f == null)
			{
				this.f = new @do();
			}
			return this.f;
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x0006EA7F File Offset: 0x0006DA7F
		internal void a(@do A_0)
		{
			this.g.Add(A_0);
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x0006EA90 File Offset: 0x0006DA90
		internal void a(DocumentWriter A_0)
		{
			A_0.WriteName(dn.a);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(dn.b);
			A_0.WriteDictionaryOpen();
			if (this.f != null)
			{
				this.f.a(A_0);
			}
			A_0.WriteDictionaryClose();
			A_0.WriteName(dn.c);
			A_0.WriteArrayOpen();
			if (this.e != null)
			{
				this.e.a(A_0);
			}
			A_0.WriteArrayClose();
			if (this.g.Count > 0)
			{
				A_0.WriteName(dn.d);
				for (int i = 0; i < this.g.Count; i++)
				{
					((@do)this.g[i]).a(A_0);
				}
			}
			A_0.WriteDictionaryClose();
		}

		// Token: 0x04000416 RID: 1046
		private static byte[] a = new byte[]
		{
			79,
			67,
			80,
			114,
			111,
			112,
			101,
			114,
			116,
			105,
			101,
			115
		};

		// Token: 0x04000417 RID: 1047
		private static byte[] b = new byte[]
		{
			68
		};

		// Token: 0x04000418 RID: 1048
		private static byte[] c = new byte[]
		{
			79,
			67,
			71,
			115
		};

		// Token: 0x04000419 RID: 1049
		private static byte[] d = new byte[]
		{
			67,
			111,
			110,
			102,
			105,
			103,
			115
		};

		// Token: 0x0400041A RID: 1050
		private dp e = null;

		// Token: 0x0400041B RID: 1051
		private @do f = null;

		// Token: 0x0400041C RID: 1052
		private ArrayList g = new ArrayList();
	}
}
