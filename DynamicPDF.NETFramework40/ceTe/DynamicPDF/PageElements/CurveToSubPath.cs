using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000727 RID: 1831
	public class CurveToSubPath : SubPath
	{
		// Token: 0x06004916 RID: 18710 RVA: 0x002591FC File Offset: 0x002581FC
		public CurveToSubPath(float x, float y, float destinationControlPointX, float destinationControlPointY)
		{
			this.a = x;
			this.b = y;
			this.c = destinationControlPointX;
			this.d = destinationControlPointY;
		}

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06004917 RID: 18711 RVA: 0x00259224 File Offset: 0x00258224
		// (set) Token: 0x06004918 RID: 18712 RVA: 0x0025923C File Offset: 0x0025823C
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

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06004919 RID: 18713 RVA: 0x00259248 File Offset: 0x00258248
		// (set) Token: 0x0600491A RID: 18714 RVA: 0x00259260 File Offset: 0x00258260
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

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x0600491B RID: 18715 RVA: 0x0025926C File Offset: 0x0025826C
		// (set) Token: 0x0600491C RID: 18716 RVA: 0x00259284 File Offset: 0x00258284
		public float DestinationControlPointX
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

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x0600491D RID: 18717 RVA: 0x00259290 File Offset: 0x00258290
		// (set) Token: 0x0600491E RID: 18718 RVA: 0x002592A8 File Offset: 0x002582A8
		public float DestinationControlPointY
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

		// Token: 0x0600491F RID: 18719 RVA: 0x002592B2 File Offset: 0x002582B2
		public override void Draw(PageWriter writer)
		{
			writer.Write_v(this.c, this.d, this.a, this.b);
		}

		// Token: 0x040027DB RID: 10203
		private float a;

		// Token: 0x040027DC RID: 10204
		private float b;

		// Token: 0x040027DD RID: 10205
		private float c;

		// Token: 0x040027DE RID: 10206
		private float d;
	}
}
