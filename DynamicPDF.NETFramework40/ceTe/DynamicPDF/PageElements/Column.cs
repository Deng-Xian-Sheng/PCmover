using System;
using System.ComponentModel;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000721 RID: 1825
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This class is obsolete. Use Column2 class instead.", false)]
	public class Column
	{
		// Token: 0x060048DE RID: 18654 RVA: 0x00258C74 File Offset: 0x00257C74
		internal Column()
		{
		}

		// Token: 0x060048DF RID: 18655 RVA: 0x00258C86 File Offset: 0x00257C86
		internal Column(float A_0)
		{
			this.a = A_0;
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x060048E0 RID: 18656 RVA: 0x00258CA0 File Offset: 0x00257CA0
		public float Width
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x060048E1 RID: 18657 RVA: 0x00258CB8 File Offset: 0x00257CB8
		internal int a()
		{
			return this.b;
		}

		// Token: 0x060048E2 RID: 18658 RVA: 0x00258CD0 File Offset: 0x00257CD0
		internal void a(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x040027C8 RID: 10184
		private float a;

		// Token: 0x040027C9 RID: 10185
		private int b = 1;
	}
}
