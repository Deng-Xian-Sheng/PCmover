using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000744 RID: 1860
	public class TransformationGroup : Group, IArea, ICoordinate
	{
		// Token: 0x06004B96 RID: 19350 RVA: 0x00265054 File Offset: 0x00264054
		public TransformationGroup(float x, float y, float width, float height) : this(x, y, width, height, 0f)
		{
		}

		// Token: 0x06004B97 RID: 19351 RVA: 0x0026506C File Offset: 0x0026406C
		public TransformationGroup(float x, float y, float width, float height, float angle)
		{
			this.a = x;
			this.b = y;
			this.c = width;
			this.d = height;
			this.g = angle;
		}

		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x06004B98 RID: 19352 RVA: 0x002650C0 File Offset: 0x002640C0
		// (set) Token: 0x06004B99 RID: 19353 RVA: 0x002650D8 File Offset: 0x002640D8
		public float Angle
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x170005A7 RID: 1447
		// (get) Token: 0x06004B9A RID: 19354 RVA: 0x002650E4 File Offset: 0x002640E4
		// (set) Token: 0x06004B9B RID: 19355 RVA: 0x002650FC File Offset: 0x002640FC
		public float ScaleX
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

		// Token: 0x170005A8 RID: 1448
		// (get) Token: 0x06004B9C RID: 19356 RVA: 0x00265108 File Offset: 0x00264108
		// (set) Token: 0x06004B9D RID: 19357 RVA: 0x00265120 File Offset: 0x00264120
		public float ScaleY
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

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x06004B9E RID: 19358 RVA: 0x0026512C File Offset: 0x0026412C
		// (set) Token: 0x06004B9F RID: 19359 RVA: 0x00265144 File Offset: 0x00264144
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

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x06004BA0 RID: 19360 RVA: 0x00265150 File Offset: 0x00264150
		// (set) Token: 0x06004BA1 RID: 19361 RVA: 0x00265168 File Offset: 0x00264168
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

		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x06004BA2 RID: 19362 RVA: 0x00265174 File Offset: 0x00264174
		// (set) Token: 0x06004BA3 RID: 19363 RVA: 0x0026518C File Offset: 0x0026418C
		public float Width
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

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x06004BA4 RID: 19364 RVA: 0x00265198 File Offset: 0x00264198
		// (set) Token: 0x06004BA5 RID: 19365 RVA: 0x002651B0 File Offset: 0x002641B0
		public float Height
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

		// Token: 0x06004BA6 RID: 19366 RVA: 0x002651BC File Offset: 0x002641BC
		public override void Draw(PageWriter writer)
		{
			if (this.g == 0f)
			{
				if (this.e == 1f && this.f == 1f)
				{
					writer.SetDimensionsShift(this.a, this.b, this.c, this.d);
				}
				else
				{
					writer.SetDimensionsScale(this.a, this.b, this.c, this.d, this.e, this.f);
				}
			}
			else if (this.e == 1f && this.f == 1f)
			{
				writer.SetDimensionsRotate(this.a, this.b, this.c, this.d, this.g);
			}
			else
			{
				writer.SetDimensionsTransform(this.a, this.b, this.c, this.d, this.g, this.e, this.f);
			}
			base.Draw(writer);
			writer.ResetDimensions();
		}

		// Token: 0x040028CB RID: 10443
		private new float a;

		// Token: 0x040028CC RID: 10444
		private float b;

		// Token: 0x040028CD RID: 10445
		private float c;

		// Token: 0x040028CE RID: 10446
		private new float d;

		// Token: 0x040028CF RID: 10447
		private float e = 1f;

		// Token: 0x040028D0 RID: 10448
		private float f = 1f;

		// Token: 0x040028D1 RID: 10449
		private float g;
	}
}
