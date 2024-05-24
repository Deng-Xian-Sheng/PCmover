using System;
using System.Collections;
using System.Collections.Generic;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements.BarCoding
{
	// Token: 0x0200074F RID: 1871
	public abstract class BarCode : RotatingPageElement, ICoordinate
	{
		// Token: 0x06004C1D RID: 19485 RVA: 0x0026ACD8 File Offset: 0x00269CD8
		protected BarCode(string value, float x, float y, float height, float xDimension) : base(x, y, height)
		{
			this.b = value;
			this.a = xDimension;
			base.d(3);
		}

		// Token: 0x170005C6 RID: 1478
		// (get) Token: 0x06004C1E RID: 19486 RVA: 0x0026AD18 File Offset: 0x00269D18
		// (set) Token: 0x06004C1F RID: 19487 RVA: 0x0026AD30 File Offset: 0x00269D30
		public int PixelsPerXDimension
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

		// Token: 0x170005C7 RID: 1479
		// (get) Token: 0x06004C20 RID: 19488 RVA: 0x0026AD3C File Offset: 0x00269D3C
		// (set) Token: 0x06004C21 RID: 19489 RVA: 0x0026AD54 File Offset: 0x00269D54
		public virtual string Value
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

		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x06004C22 RID: 19490 RVA: 0x0026AD60 File Offset: 0x00269D60
		// (set) Token: 0x06004C23 RID: 19491 RVA: 0x0026AD78 File Offset: 0x00269D78
		public virtual float XDimension
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

		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x06004C24 RID: 19492 RVA: 0x0026AD84 File Offset: 0x00269D84
		// (set) Token: 0x06004C25 RID: 19493 RVA: 0x0026ADA2 File Offset: 0x00269DA2
		public virtual float XDimensionsPerInch
		{
			get
			{
				return 72f / this.a;
			}
			set
			{
				this.a = 72f / value;
			}
		}

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x06004C26 RID: 19494 RVA: 0x0026ADB4 File Offset: 0x00269DB4
		// (set) Token: 0x06004C27 RID: 19495 RVA: 0x0026ADD2 File Offset: 0x00269DD2
		public virtual float XDimensionsPerCentiMeter
		{
			get
			{
				return 28.346457f / this.a;
			}
			set
			{
				this.a = 28.346457f / value;
			}
		}

		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x06004C28 RID: 19496 RVA: 0x0026ADE4 File Offset: 0x00269DE4
		// (set) Token: 0x06004C29 RID: 19497 RVA: 0x0026AE02 File Offset: 0x00269E02
		public float XDimensionMils
		{
			get
			{
				return this.XDimension * 13.888889f;
			}
			set
			{
				this.XDimension = value / 13.888889f;
			}
		}

		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x06004C2A RID: 19498 RVA: 0x0026AE14 File Offset: 0x00269E14
		// (set) Token: 0x06004C2B RID: 19499 RVA: 0x0026AE32 File Offset: 0x00269E32
		public float XDimensionMilliMeters
		{
			get
			{
				return this.XDimension * 0.35277778f;
			}
			set
			{
				this.XDimension = value / 0.35277778f;
			}
		}

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x06004C2C RID: 19500 RVA: 0x0026AE44 File Offset: 0x00269E44
		// (set) Token: 0x06004C2D RID: 19501 RVA: 0x0026AE5C File Offset: 0x00269E5C
		public Color Color
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

		// Token: 0x06004C2E RID: 19502
		public abstract float GetSymbolWidth();

		// Token: 0x06004C2F RID: 19503
		protected abstract void DrawBarCode(PageWriter writer);

		// Token: 0x06004C30 RID: 19504 RVA: 0x0026AE66 File Offset: 0x00269E66
		protected override void DrawRotated(PageWriter writer)
		{
			this.DrawBarCode(writer);
		}

		// Token: 0x06004C31 RID: 19505 RVA: 0x0026AE74 File Offset: 0x00269E74
		internal static byte[] a(BitArray A_0, int A_1, int A_2, int A_3)
		{
			int num = A_2 / 8;
			if (A_2 % 8 != 0)
			{
				num++;
			}
			int a_ = num * A_3;
			int num2 = 0;
			i i = new i(a_);
			for (int j = 0; j < A_1; j++)
			{
				int k;
				for (k = A_2; k >= 8; k -= 8)
				{
					byte b = 0;
					for (int l = 0; l < 8; l++)
					{
						if (A_0[num2])
						{
							b |= (byte)(1 << 7 - l);
						}
						num2++;
					}
					i.a(b);
				}
				if (k != 0)
				{
					byte b = 0;
					for (int l = 0; l < 8; l++)
					{
						if (l < k)
						{
							if (A_0[num2])
							{
								b |= (byte)(1 << 7 - l);
							}
							num2++;
						}
						else
						{
							b |= (byte)(1 << 7 - l);
						}
					}
					i.a(b);
				}
				j += A_2 - 1;
			}
			return i.a;
		}

		// Token: 0x06004C32 RID: 19506 RVA: 0x0026AFB4 File Offset: 0x00269FB4
		internal static List<string> b(string A_0)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < A_0.Length; i++)
			{
				int num = A_0.IndexOf('(', i) + 1;
				int num2 = A_0.IndexOf(')', num);
				if (num2 == -1)
				{
					list.Add(A_0.Substring(num, A_0.Length - num));
					break;
				}
				if (BarCode.a(A_0.Substring(num, num2 - num)))
				{
					int num3 = A_0.IndexOf('(', num2);
					if (num3 < 0)
					{
						num3 = A_0.Length - i;
						list.Add(A_0.Substring(i, num3));
						break;
					}
					list.Add(A_0.Substring(i, num3 - i));
					i = num3 - 1;
				}
			}
			return list;
		}

		// Token: 0x06004C33 RID: 19507 RVA: 0x0026B094 File Offset: 0x0026A094
		internal static byte[] a(BitArray A_0, int A_1, int A_2, int A_3, int A_4)
		{
			BitArray bitArray = new BitArray(A_3 * A_1 * (A_4 * A_2));
			int num = 0;
			int num2 = 0;
			for (int i = 1; i <= A_4; i++)
			{
				for (int j = 0; j < A_2; j++)
				{
					for (int k = num2; k < A_3 * i; k++)
					{
						for (int l = 0; l < A_1; l++)
						{
							bitArray.Set(num++, A_0[k]);
						}
					}
				}
				num2 += A_3;
			}
			return BarCode.a(bitArray, num - 1, A_3 * A_1, A_4 * A_2);
		}

		// Token: 0x06004C34 RID: 19508 RVA: 0x0026B144 File Offset: 0x0026A144
		internal static float a(float A_0, Font A_1)
		{
			return (float)(A_1.bh() - A_1.bi()) * (A_0 / 1000f);
		}

		// Token: 0x06004C35 RID: 19509 RVA: 0x0026B16C File Offset: 0x0026A16C
		private static bool a(string A_0)
		{
			for (int i = 0; i < A_0.Length; i++)
			{
				if ((byte)A_0[i] > 57 || (byte)A_0[i] < 48)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06004C36 RID: 19510 RVA: 0x0026B1BC File Offset: 0x0026A1BC
		internal bool j()
		{
			return this.d;
		}

		// Token: 0x06004C37 RID: 19511 RVA: 0x0026B1D4 File Offset: 0x0026A1D4
		internal void b(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06004C38 RID: 19512 RVA: 0x0026B1E0 File Offset: 0x0026A1E0
		internal void a(PageWriter A_0)
		{
			if (this.Tag == null)
			{
				this.Tag = new StructureElement(TagType.Figure, true);
				((StructureElement)this.Tag).Order = this.TagOrder;
			}
			this.Tag.e(A_0, this);
		}

		// Token: 0x06004C39 RID: 19513 RVA: 0x0026B238 File Offset: 0x0026A238
		internal override byte cb()
		{
			return 32;
		}

		// Token: 0x04002925 RID: 10533
		private new float a;

		// Token: 0x04002926 RID: 10534
		private string b;

		// Token: 0x04002927 RID: 10535
		private Color c = Grayscale.Black;

		// Token: 0x04002928 RID: 10536
		private new bool d = false;

		// Token: 0x04002929 RID: 10537
		private int e = 3;
	}
}
