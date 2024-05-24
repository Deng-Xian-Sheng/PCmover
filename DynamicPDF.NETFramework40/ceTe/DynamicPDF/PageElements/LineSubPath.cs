using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000730 RID: 1840
	public class LineSubPath : SubPath
	{
		// Token: 0x0600497E RID: 18814 RVA: 0x0025AF01 File Offset: 0x00259F01
		public LineSubPath(float x, float y)
		{
			this.a = x;
			this.b = y;
		}

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x0600497F RID: 18815 RVA: 0x0025AF1C File Offset: 0x00259F1C
		// (set) Token: 0x06004980 RID: 18816 RVA: 0x0025AF34 File Offset: 0x00259F34
		public float X
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

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06004981 RID: 18817 RVA: 0x0025AF40 File Offset: 0x00259F40
		// (set) Token: 0x06004982 RID: 18818 RVA: 0x0025AF58 File Offset: 0x00259F58
		public float Y
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

		// Token: 0x06004983 RID: 18819 RVA: 0x0025AF62 File Offset: 0x00259F62
		public override void Draw(PageWriter writer)
		{
			writer.Write_l_(this.a, this.b);
		}

		// Token: 0x04002801 RID: 10241
		private float a;

		// Token: 0x04002802 RID: 10242
		private float b;
	}
}
