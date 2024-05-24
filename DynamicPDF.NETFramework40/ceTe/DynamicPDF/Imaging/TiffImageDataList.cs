using System;
using System.Collections;

namespace ceTe.DynamicPDF.Imaging
{
	// Token: 0x0200087E RID: 2174
	public class TiffImageDataList : IEnumerable
	{
		// Token: 0x0600588F RID: 22671 RVA: 0x00336AE3 File Offset: 0x00335AE3
		internal TiffImageDataList(TiffImageData A_0)
		{
			this.c = A_0;
			this.a.Add(A_0);
		}

		// Token: 0x06005890 RID: 22672 RVA: 0x00336B14 File Offset: 0x00335B14
		private void a()
		{
			if (!this.b)
			{
				for (TiffImageData tiffImageData = this.c.k(); tiffImageData != null; tiffImageData = tiffImageData.k())
				{
					this.a.Add(tiffImageData);
				}
				this.b = true;
			}
		}

		// Token: 0x170008E0 RID: 2272
		// (get) Token: 0x06005891 RID: 22673 RVA: 0x00336B64 File Offset: 0x00335B64
		public int Count
		{
			get
			{
				this.a();
				return this.a.Count;
			}
		}

		// Token: 0x06005892 RID: 22674 RVA: 0x00336B88 File Offset: 0x00335B88
		public IEnumerator GetEnumerator()
		{
			this.a();
			return this.a.GetEnumerator();
		}

		// Token: 0x170008E1 RID: 2273
		public TiffImageData this[int index]
		{
			get
			{
				if (index > 0)
				{
					this.a();
				}
				return (TiffImageData)this.a[index];
			}
		}

		// Token: 0x04002F0F RID: 12047
		private ArrayList a = new ArrayList();

		// Token: 0x04002F10 RID: 12048
		private bool b = false;

		// Token: 0x04002F11 RID: 12049
		private TiffImageData c;
	}
}
