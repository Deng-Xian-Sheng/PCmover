using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200066F RID: 1647
	public class Dimensions
	{
		// Token: 0x06003F42 RID: 16194 RVA: 0x0021ADFC File Offset: 0x00219DFC
		public Dimensions(PageSize size, PageOrientation orientation)
		{
			this.a = 0f;
			this.b = 0f;
			if (orientation == PageOrientation.Portrait)
			{
				switch (size)
				{
				case PageSize.A3:
					this.c = 842f;
					this.d = 1191f;
					break;
				case PageSize.A4:
					this.c = 595f;
					this.d = 842f;
					break;
				case PageSize.A5:
					this.c = 420f;
					this.d = 595f;
					break;
				case PageSize.A6:
					this.c = 298f;
					this.d = 420f;
					break;
				case PageSize.B3:
					this.c = 1032f;
					this.d = 1460f;
					break;
				case PageSize.B4:
					this.c = 709f;
					this.d = 1001f;
					break;
				case PageSize.B5:
					this.c = 499f;
					this.d = 709f;
					break;
				case PageSize.B5JIS:
					this.c = 516f;
					this.d = 729f;
					break;
				case PageSize.DoublePostcard:
					this.c = 419f;
					this.d = 567f;
					break;
				case PageSize.Envelope10:
					this.c = 297f;
					this.d = 684f;
					break;
				case PageSize.EnvelopeDL:
					this.c = 312f;
					this.d = 624f;
					break;
				case PageSize.EnvelopeC5:
					this.c = 459f;
					this.d = 649f;
					break;
				case PageSize.EnvelopeB5:
					this.c = 499f;
					this.d = 709f;
					break;
				case PageSize.EnvelopeMonarch:
					this.c = 279f;
					this.d = 540f;
					break;
				case PageSize.Executive:
					this.c = 522f;
					this.d = 756f;
					break;
				case PageSize.Legal:
					this.c = 612f;
					this.d = 1008f;
					break;
				case PageSize.Folio:
					this.c = 595f;
					this.d = 935f;
					break;
				case PageSize.Letter:
					this.c = 612f;
					this.d = 792f;
					break;
				case PageSize.Postcard:
					this.c = 284f;
					this.d = 419f;
					break;
				case PageSize.PRC16K:
					this.c = 414f;
					this.d = 610f;
					break;
				case PageSize.PRC32K:
					this.c = 275f;
					this.d = 428f;
					break;
				case PageSize.Quatro:
					this.c = 610f;
					this.d = 780f;
					break;
				case PageSize.Statement:
					this.c = 396f;
					this.d = 612f;
					break;
				case PageSize.Tabloid:
					this.c = 792f;
					this.d = 1224f;
					break;
				default:
					this.c = 612f;
					this.d = 792f;
					break;
				}
			}
			else
			{
				switch (size)
				{
				case PageSize.A3:
					this.c = 1191f;
					this.d = 842f;
					break;
				case PageSize.A4:
					this.c = 842f;
					this.d = 595f;
					break;
				case PageSize.A5:
					this.c = 595f;
					this.d = 420f;
					break;
				case PageSize.A6:
					this.c = 420f;
					this.d = 298f;
					break;
				case PageSize.B3:
					this.c = 1460f;
					this.d = 1032f;
					break;
				case PageSize.B4:
					this.c = 1001f;
					this.d = 709f;
					break;
				case PageSize.B5:
					this.c = 709f;
					this.d = 499f;
					break;
				case PageSize.B5JIS:
					this.c = 729f;
					this.d = 516f;
					break;
				case PageSize.DoublePostcard:
					this.c = 567f;
					this.d = 419f;
					break;
				case PageSize.Envelope10:
					this.c = 684f;
					this.d = 297f;
					break;
				case PageSize.EnvelopeDL:
					this.c = 624f;
					this.d = 312f;
					break;
				case PageSize.EnvelopeC5:
					this.c = 649f;
					this.d = 459f;
					break;
				case PageSize.EnvelopeB5:
					this.c = 709f;
					this.d = 499f;
					break;
				case PageSize.EnvelopeMonarch:
					this.c = 540f;
					this.d = 279f;
					break;
				case PageSize.Executive:
					this.c = 756f;
					this.d = 522f;
					break;
				case PageSize.Legal:
					this.c = 1008f;
					this.d = 612f;
					break;
				case PageSize.Folio:
					this.c = 935f;
					this.d = 595f;
					break;
				case PageSize.Letter:
					this.c = 792f;
					this.d = 612f;
					break;
				case PageSize.Postcard:
					this.c = 419f;
					this.d = 284f;
					break;
				case PageSize.PRC16K:
					this.c = 610f;
					this.d = 414f;
					break;
				case PageSize.PRC32K:
					this.c = 428f;
					this.d = 275f;
					break;
				case PageSize.Quatro:
					this.c = 780f;
					this.d = 610f;
					break;
				case PageSize.Statement:
					this.c = 612f;
					this.d = 396f;
					break;
				case PageSize.Tabloid:
					this.c = 1224f;
					this.d = 792f;
					break;
				default:
					this.c = 612f;
					this.d = 792f;
					break;
				}
			}
		}

		// Token: 0x06003F43 RID: 16195 RVA: 0x0021B43B File Offset: 0x0021A43B
		public Dimensions(float width, float height)
		{
			this.a = 0f;
			this.b = 0f;
			this.c = width;
			this.d = height;
		}

		// Token: 0x06003F44 RID: 16196 RVA: 0x0021B46A File Offset: 0x0021A46A
		public Dimensions(float left, float top, float right, float bottom)
		{
			this.a = left;
			this.b = top;
			this.c = right;
			this.d = bottom;
		}

		// Token: 0x06003F45 RID: 16197 RVA: 0x0021B494 File Offset: 0x0021A494
		internal Dimensions(Dimensions A_0, float A_1)
		{
			this.a = A_0.Left + A_1;
			this.b = A_0.Top + A_1;
			this.c = A_0.Right - A_1;
			this.d = A_0.Bottom - A_1;
		}

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06003F46 RID: 16198 RVA: 0x0021B4E4 File Offset: 0x0021A4E4
		// (set) Token: 0x06003F47 RID: 16199 RVA: 0x0021B503 File Offset: 0x0021A503
		public float Width
		{
			get
			{
				return this.Right - this.Left;
			}
			set
			{
				this.Right = value - this.Left;
			}
		}

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06003F48 RID: 16200 RVA: 0x0021B518 File Offset: 0x0021A518
		// (set) Token: 0x06003F49 RID: 16201 RVA: 0x0021B537 File Offset: 0x0021A537
		public float Height
		{
			get
			{
				return this.Bottom - this.Top;
			}
			set
			{
				this.Bottom = this.Top + value;
			}
		}

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06003F4A RID: 16202 RVA: 0x0021B54C File Offset: 0x0021A54C
		// (set) Token: 0x06003F4B RID: 16203 RVA: 0x0021B564 File Offset: 0x0021A564
		public float Left
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

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06003F4C RID: 16204 RVA: 0x0021B570 File Offset: 0x0021A570
		// (set) Token: 0x06003F4D RID: 16205 RVA: 0x0021B588 File Offset: 0x0021A588
		public float Top
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

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06003F4E RID: 16206 RVA: 0x0021B594 File Offset: 0x0021A594
		// (set) Token: 0x06003F4F RID: 16207 RVA: 0x0021B5AC File Offset: 0x0021A5AC
		public float Right
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

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x06003F50 RID: 16208 RVA: 0x0021B5B8 File Offset: 0x0021A5B8
		// (set) Token: 0x06003F51 RID: 16209 RVA: 0x0021B5D0 File Offset: 0x0021A5D0
		public float Bottom
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

		// Token: 0x06003F52 RID: 16210 RVA: 0x0021B5DC File Offset: 0x0021A5DC
		public override bool Equals(object obj)
		{
			return obj is Dimensions && this.d == ((Dimensions)obj).d && this.a == ((Dimensions)obj).a && this.c == ((Dimensions)obj).c && this.b == ((Dimensions)obj).b && this.Height == ((Dimensions)obj).Height && this.Width == ((Dimensions)obj).Width;
		}

		// Token: 0x06003F53 RID: 16211 RVA: 0x0021B66C File Offset: 0x0021A66C
		public override int GetHashCode()
		{
			return this.d.GetHashCode() ^ this.a.GetHashCode() ^ this.c.GetHashCode() ^ this.b.GetHashCode() ^ this.Height.GetHashCode() ^ this.Width.GetHashCode();
		}

		// Token: 0x06003F54 RID: 16212 RVA: 0x0021B6CC File Offset: 0x0021A6CC
		public static bool operator ==(Dimensions a, Dimensions b)
		{
			return Dimensions.a(a, b);
		}

		// Token: 0x06003F55 RID: 16213 RVA: 0x0021B6E8 File Offset: 0x0021A6E8
		public static bool operator !=(Dimensions a, Dimensions b)
		{
			return !Dimensions.a(a, b);
		}

		// Token: 0x06003F56 RID: 16214 RVA: 0x0021B704 File Offset: 0x0021A704
		private static bool a(Dimensions A_0, Dimensions A_1)
		{
			return object.ReferenceEquals(A_0, A_1) || (!object.ReferenceEquals(A_1, null) && !object.ReferenceEquals(A_0, null) && (A_0.Top == A_1.Top && A_0.Bottom == A_1.Bottom && A_0.Left == A_1.Left) && A_0.Right == A_1.Right);
		}

		// Token: 0x06003F57 RID: 16215 RVA: 0x0021B784 File Offset: 0x0021A784
		internal Dimensions a()
		{
			return new Dimensions(this.a, this.b, this.c, this.d);
		}

		// Token: 0x04002210 RID: 8720
		private float a;

		// Token: 0x04002211 RID: 8721
		private float b;

		// Token: 0x04002212 RID: 8722
		private float c;

		// Token: 0x04002213 RID: 8723
		private float d;
	}
}
