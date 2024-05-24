using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000663 RID: 1635
	public class PageReaderEvents
	{
		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06003DCF RID: 15823 RVA: 0x00216BC8 File Offset: 0x00215BC8
		// (set) Token: 0x06003DD0 RID: 15824 RVA: 0x00216BE0 File Offset: 0x00215BE0
		public OutlineAnnotationAction Open
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06003DD1 RID: 15825 RVA: 0x00216BEC File Offset: 0x00215BEC
		// (set) Token: 0x06003DD2 RID: 15826 RVA: 0x00216C04 File Offset: 0x00215C04
		public OutlineAnnotationAction Close
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x06003DD3 RID: 15827 RVA: 0x00216C10 File Offset: 0x00215C10
		internal void a(DocumentWriter A_0)
		{
			if (this.a != null)
			{
				A_0.WriteName(PageReaderEvents.e);
				A_0.WriteDictionaryOpen();
				A_0.WriteName(PageReaderEvents.d);
				this.a.Draw(A_0);
				if (this.b == null)
				{
					A_0.WriteDictionaryClose();
					return;
				}
			}
			if (this.b != null)
			{
				if (this.a == null)
				{
					A_0.WriteName(PageReaderEvents.e);
					A_0.WriteDictionaryOpen();
				}
				A_0.WriteName(PageReaderEvents.c);
				this.b.Draw(A_0);
				A_0.WriteDictionaryClose();
			}
		}

		// Token: 0x04002166 RID: 8550
		private OutlineAnnotationAction a;

		// Token: 0x04002167 RID: 8551
		private OutlineAnnotationAction b;

		// Token: 0x04002168 RID: 8552
		private static byte[] c = new byte[]
		{
			67
		};

		// Token: 0x04002169 RID: 8553
		private static byte[] d = new byte[]
		{
			79
		};

		// Token: 0x0400216A RID: 8554
		private static byte[] e = new byte[]
		{
			65,
			65
		};
	}
}
