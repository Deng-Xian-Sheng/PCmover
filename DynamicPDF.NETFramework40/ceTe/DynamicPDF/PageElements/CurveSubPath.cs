using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000726 RID: 1830
	public class CurveSubPath : SubPath
	{
		// Token: 0x06004908 RID: 18696 RVA: 0x002590C0 File Offset: 0x002580C0
		public CurveSubPath(float x, float y, float sourceControlPointX, float sourceControlPointY, float destinationControlPointX, float destinationControlPointY)
		{
			this.a = x;
			this.b = y;
			this.c = sourceControlPointX;
			this.d = sourceControlPointY;
			this.e = destinationControlPointX;
			this.f = destinationControlPointY;
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06004909 RID: 18697 RVA: 0x002590F8 File Offset: 0x002580F8
		// (set) Token: 0x0600490A RID: 18698 RVA: 0x00259110 File Offset: 0x00258110
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

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x0600490B RID: 18699 RVA: 0x0025911C File Offset: 0x0025811C
		// (set) Token: 0x0600490C RID: 18700 RVA: 0x00259134 File Offset: 0x00258134
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

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x0600490D RID: 18701 RVA: 0x00259140 File Offset: 0x00258140
		// (set) Token: 0x0600490E RID: 18702 RVA: 0x00259158 File Offset: 0x00258158
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

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x0600490F RID: 18703 RVA: 0x00259164 File Offset: 0x00258164
		// (set) Token: 0x06004910 RID: 18704 RVA: 0x0025917C File Offset: 0x0025817C
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

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06004911 RID: 18705 RVA: 0x00259188 File Offset: 0x00258188
		// (set) Token: 0x06004912 RID: 18706 RVA: 0x002591A0 File Offset: 0x002581A0
		public float DestinationControlPointX
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06004913 RID: 18707 RVA: 0x002591AC File Offset: 0x002581AC
		// (set) Token: 0x06004914 RID: 18708 RVA: 0x002591C4 File Offset: 0x002581C4
		public float DestinationControlPointY
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x06004915 RID: 18709 RVA: 0x002591CE File Offset: 0x002581CE
		public override void Draw(PageWriter writer)
		{
			writer.Write_c(this.c, this.d, this.e, this.f, this.a, this.b);
		}

		// Token: 0x040027D5 RID: 10197
		private float a;

		// Token: 0x040027D6 RID: 10198
		private float b;

		// Token: 0x040027D7 RID: 10199
		private float c;

		// Token: 0x040027D8 RID: 10200
		private float d;

		// Token: 0x040027D9 RID: 10201
		private float e;

		// Token: 0x040027DA RID: 10202
		private float f;
	}
}
