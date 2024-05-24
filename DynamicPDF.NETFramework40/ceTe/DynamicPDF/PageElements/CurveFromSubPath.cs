using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000725 RID: 1829
	public class CurveFromSubPath : SubPath
	{
		// Token: 0x060048FE RID: 18686 RVA: 0x00258FE6 File Offset: 0x00257FE6
		public CurveFromSubPath(float x, float y, float sourceControlPointX, float sourceControlPointY)
		{
			this.a = x;
			this.b = y;
			this.c = sourceControlPointX;
			this.d = sourceControlPointY;
		}

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x060048FF RID: 18687 RVA: 0x00259010 File Offset: 0x00258010
		// (set) Token: 0x06004900 RID: 18688 RVA: 0x00259028 File Offset: 0x00258028
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

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06004901 RID: 18689 RVA: 0x00259034 File Offset: 0x00258034
		// (set) Token: 0x06004902 RID: 18690 RVA: 0x0025904C File Offset: 0x0025804C
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

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06004903 RID: 18691 RVA: 0x00259058 File Offset: 0x00258058
		// (set) Token: 0x06004904 RID: 18692 RVA: 0x00259070 File Offset: 0x00258070
		public float SourceControlPointX
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06004905 RID: 18693 RVA: 0x0025907C File Offset: 0x0025807C
		// (set) Token: 0x06004906 RID: 18694 RVA: 0x00259094 File Offset: 0x00258094
		public float SourceControlPointY
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x06004907 RID: 18695 RVA: 0x0025909E File Offset: 0x0025809E
		public override void Draw(PageWriter writer)
		{
			writer.Write_y(this.c, this.d, this.a, this.b);
		}

		// Token: 0x040027D1 RID: 10193
		private float a;

		// Token: 0x040027D2 RID: 10194
		private float b;

		// Token: 0x040027D3 RID: 10195
		private float c;

		// Token: 0x040027D4 RID: 10196
		private float d;
	}
}
