using System;
using System.Collections;
using System.Reflection;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Forms;

namespace zz93
{
	// Token: 0x02000442 RID: 1090
	[DefaultMember("Item")]
	internal class acg
	{
		// Token: 0x06002D08 RID: 11528 RVA: 0x0019A168 File Offset: 0x00199168
		internal acg()
		{
		}

		// Token: 0x06002D09 RID: 11529 RVA: 0x0019A17E File Offset: 0x0019917E
		internal void a(int A_0, Resource A_1)
		{
			this.a.Add(A_0, A_1);
		}

		// Token: 0x06002D0A RID: 11530 RVA: 0x0019A194 File Offset: 0x00199194
		internal FormField a(int A_0)
		{
			return (FormField)this.a[A_0];
		}

		// Token: 0x0400154E RID: 5454
		private Hashtable a = new Hashtable();
	}
}
