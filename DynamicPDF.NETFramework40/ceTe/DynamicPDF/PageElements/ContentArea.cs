using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000723 RID: 1827
	public class ContentArea : Group
	{
		// Token: 0x060048E9 RID: 18665 RVA: 0x00258DB5 File Offset: 0x00257DB5
		internal ContentArea()
		{
		}

		// Token: 0x060048EA RID: 18666 RVA: 0x00258DCB File Offset: 0x00257DCB
		public ContentArea(float x, float y, float width, float height)
		{
			this.a = x;
			this.b = y;
			this.c = width;
			this.d = height;
		}

		// Token: 0x060048EB RID: 18667 RVA: 0x00258E00 File Offset: 0x00257E00
		public override void Draw(PageWriter writer)
		{
			if (base.HasElements)
			{
				writer.SetDimensionsShift(this.a, this.b, this.c, this.d);
				base.Draw(writer);
				writer.ResetDimensions();
			}
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x060048EC RID: 18668 RVA: 0x00258E4C File Offset: 0x00257E4C
		// (set) Token: 0x060048ED RID: 18669 RVA: 0x00258E64 File Offset: 0x00257E64
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

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x060048EE RID: 18670 RVA: 0x00258E70 File Offset: 0x00257E70
		// (set) Token: 0x060048EF RID: 18671 RVA: 0x00258E88 File Offset: 0x00257E88
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

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x060048F0 RID: 18672 RVA: 0x00258E94 File Offset: 0x00257E94
		// (set) Token: 0x060048F1 RID: 18673 RVA: 0x00258EAC File Offset: 0x00257EAC
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

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060048F2 RID: 18674 RVA: 0x00258EB8 File Offset: 0x00257EB8
		// (set) Token: 0x060048F3 RID: 18675 RVA: 0x00258ED0 File Offset: 0x00257ED0
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

		// Token: 0x060048F4 RID: 18676 RVA: 0x00258EDC File Offset: 0x00257EDC
		internal override x5 b7()
		{
			return x5.a(this.Y);
		}

		// Token: 0x060048F5 RID: 18677 RVA: 0x00258EFC File Offset: 0x00257EFC
		internal override x5 b8()
		{
			return x5.a(this.Y + this.d);
		}

		// Token: 0x060048F6 RID: 18678 RVA: 0x00258F24 File Offset: 0x00257F24
		internal override x5 fa(x5 A_0)
		{
			return al1.d;
		}

		// Token: 0x060048F7 RID: 18679 RVA: 0x00258F3B File Offset: 0x00257F3B
		internal override void ca(x5 A_0)
		{
			this.b -= x5.b(A_0);
		}

		// Token: 0x060048F8 RID: 18680 RVA: 0x00258F52 File Offset: 0x00257F52
		internal override void b5(dv A_0)
		{
			this.b += x5.b(A_0.a(x5.a(this.b)));
		}

		// Token: 0x060048F9 RID: 18681 RVA: 0x00258F7C File Offset: 0x00257F7C
		internal override PageElement fc()
		{
			return new ContentArea(this.a, this.b, this.c, this.d)
			{
				e = this.e
			};
		}

		// Token: 0x060048FA RID: 18682 RVA: 0x00258FBC File Offset: 0x00257FBC
		internal override short fd()
		{
			return this.e;
		}

		// Token: 0x060048FB RID: 18683 RVA: 0x00258FD4 File Offset: 0x00257FD4
		internal void a(short A_0)
		{
			this.e = A_0;
		}

		// Token: 0x040027CC RID: 10188
		private new float a;

		// Token: 0x040027CD RID: 10189
		private float b;

		// Token: 0x040027CE RID: 10190
		private float c;

		// Token: 0x040027CF RID: 10191
		private new float d;

		// Token: 0x040027D0 RID: 10192
		private short e = short.MinValue;
	}
}
