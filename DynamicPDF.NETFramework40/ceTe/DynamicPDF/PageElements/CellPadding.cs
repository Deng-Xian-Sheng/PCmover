using System;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200070F RID: 1807
	public class CellPadding
	{
		// Token: 0x06004795 RID: 18325 RVA: 0x00250D48 File Offset: 0x0024FD48
		internal CellPadding(qy A_0)
		{
			this.f = A_0;
			float? num = null;
			this.e = num;
			this.a = (this.b = (this.c = (this.d = (this.e = num))));
		}

		// Token: 0x06004796 RID: 18326 RVA: 0x00250DA0 File Offset: 0x0024FDA0
		internal CellPadding(CellPadding A_0, CellPadding A_1)
		{
			if (A_0.a == null)
			{
				this.a = A_1.a;
			}
			else
			{
				this.a = A_0.a;
			}
			if (A_0.b == null)
			{
				this.b = A_1.b;
			}
			else
			{
				this.b = A_0.b;
			}
			if (A_0.c == null)
			{
				this.c = A_1.c;
			}
			else
			{
				this.c = A_0.c;
			}
			if (A_0.d == null)
			{
				this.d = A_1.d;
			}
			else
			{
				this.d = A_0.d;
			}
			if (A_0.e == null)
			{
				this.e = A_1.e;
			}
			else
			{
				this.e = A_0.e;
			}
		}

		// Token: 0x06004797 RID: 18327 RVA: 0x00250E88 File Offset: 0x0024FE88
		public CellPadding(float? value)
		{
			this.a = value;
			float? num = null;
			this.e = num;
			this.b = (this.c = (this.d = (this.e = num)));
		}

		// Token: 0x06004798 RID: 18328 RVA: 0x00250ED6 File Offset: 0x0024FED6
		internal void a(qy A_0)
		{
			this.f = A_0;
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06004799 RID: 18329 RVA: 0x00250EE0 File Offset: 0x0024FEE0
		// (set) Token: 0x0600479A RID: 18330 RVA: 0x00250EF8 File Offset: 0x0024FEF8
		public float? Value
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
				float? num = null;
				this.e = num;
				this.b = (this.c = (this.d = (this.e = num)));
			}
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x0600479B RID: 18331 RVA: 0x00250F40 File Offset: 0x0024FF40
		// (set) Token: 0x0600479C RID: 18332 RVA: 0x00250F70 File Offset: 0x0024FF70
		public float? Top
		{
			get
			{
				float? result;
				if (this.b == null)
				{
					result = this.a;
				}
				else
				{
					result = this.b;
				}
				return result;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x0600479D RID: 18333 RVA: 0x00250F7C File Offset: 0x0024FF7C
		// (set) Token: 0x0600479E RID: 18334 RVA: 0x00250FAC File Offset: 0x0024FFAC
		public float? Bottom
		{
			get
			{
				float? result;
				if (this.c == null)
				{
					result = this.a;
				}
				else
				{
					result = this.c;
				}
				return result;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x0600479F RID: 18335 RVA: 0x00250FB8 File Offset: 0x0024FFB8
		// (set) Token: 0x060047A0 RID: 18336 RVA: 0x00250FE8 File Offset: 0x0024FFE8
		public float? Left
		{
			get
			{
				float? result;
				if (this.d == null)
				{
					result = this.a;
				}
				else
				{
					result = this.d;
				}
				return result;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x060047A1 RID: 18337 RVA: 0x00250FF4 File Offset: 0x0024FFF4
		// (set) Token: 0x060047A2 RID: 18338 RVA: 0x00251024 File Offset: 0x00250024
		public float? Right
		{
			get
			{
				float? result;
				if (this.e == null)
				{
					result = this.a;
				}
				else
				{
					result = this.e;
				}
				return result;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x060047A3 RID: 18339 RVA: 0x00251030 File Offset: 0x00250030
		internal bool a()
		{
			float? num = this.Top;
			float? num2 = this.Bottom;
			if (num.GetValueOrDefault() == num2.GetValueOrDefault() && num != null == (num2 != null))
			{
				num = this.Bottom;
				num2 = this.Left;
				if (num.GetValueOrDefault() == num2.GetValueOrDefault() && num != null == (num2 != null))
				{
					num = this.Left;
					num2 = this.Right;
					return num.GetValueOrDefault() == num2.GetValueOrDefault() && num != null == (num2 != null);
				}
			}
			return false;
		}

		// Token: 0x060047A4 RID: 18340 RVA: 0x002510E8 File Offset: 0x002500E8
		public override int GetHashCode()
		{
			int num = this.Top.GetHashCode();
			int hashCode = this.Bottom.GetHashCode();
			num ^= hashCode << 8;
			num ^= hashCode >> 24;
			int hashCode2 = this.Left.GetHashCode();
			num ^= hashCode2 << 16;
			num ^= hashCode2 >> 16;
			int hashCode3 = this.Right.GetHashCode();
			num ^= hashCode3 << 24;
			return num ^ hashCode3 >> 8;
		}

		// Token: 0x060047A5 RID: 18341 RVA: 0x00251180 File Offset: 0x00250180
		public override bool Equals(object obj)
		{
			return obj != null && obj is CellPadding && CellPadding.a(this, (CellPadding)obj);
		}

		// Token: 0x060047A6 RID: 18342 RVA: 0x002511BC File Offset: 0x002501BC
		public bool Equals(CellPadding padding)
		{
			return CellPadding.a(this, padding);
		}

		// Token: 0x060047A7 RID: 18343 RVA: 0x002511D8 File Offset: 0x002501D8
		public static bool operator ==(CellPadding a, CellPadding b)
		{
			return CellPadding.a(a, b);
		}

		// Token: 0x060047A8 RID: 18344 RVA: 0x002511F4 File Offset: 0x002501F4
		public static bool operator !=(CellPadding a, CellPadding b)
		{
			return !CellPadding.a(a, b);
		}

		// Token: 0x060047A9 RID: 18345 RVA: 0x00251210 File Offset: 0x00250210
		public static CellPadding operator +(CellPadding a, CellPadding b)
		{
			return new CellPadding(new float?(a.a.Value + b.a.Value));
		}

		// Token: 0x060047AA RID: 18346 RVA: 0x00251248 File Offset: 0x00250248
		public static CellPadding operator -(CellPadding a, CellPadding b)
		{
			return new CellPadding(new float?(a.a.Value - b.a.Value));
		}

		// Token: 0x060047AB RID: 18347 RVA: 0x00251280 File Offset: 0x00250280
		public static CellPadding operator -(CellPadding a)
		{
			float? num = a.a;
			return new CellPadding(new float?(((num != null) ? new float?(-num.GetValueOrDefault()) : null).Value));
		}

		// Token: 0x060047AC RID: 18348 RVA: 0x002512D0 File Offset: 0x002502D0
		public static CellPadding operator ++(CellPadding a)
		{
			CellPadding cellPadding = new CellPadding(a.a);
			CellPadding cellPadding2 = cellPadding;
			float? num = cellPadding2.a;
			cellPadding2.a = ((num != null) ? new float?(num.GetValueOrDefault() + 1f) : null);
			return cellPadding;
		}

		// Token: 0x060047AD RID: 18349 RVA: 0x00251324 File Offset: 0x00250324
		public static CellPadding operator --(CellPadding a)
		{
			CellPadding cellPadding = new CellPadding(a.a);
			CellPadding cellPadding2 = cellPadding;
			float? num = cellPadding2.a;
			cellPadding2.a = ((num != null) ? new float?(num.GetValueOrDefault() - 1f) : null);
			return cellPadding;
		}

		// Token: 0x060047AE RID: 18350 RVA: 0x00251378 File Offset: 0x00250378
		public static CellPadding operator *(CellPadding a, CellPadding b)
		{
			return new CellPadding(new float?(a.a.Value * b.a.Value));
		}

		// Token: 0x060047AF RID: 18351 RVA: 0x002513B0 File Offset: 0x002503B0
		public static CellPadding operator /(CellPadding a, CellPadding b)
		{
			return new CellPadding(new float?(a.a.Value / b.a.Value));
		}

		// Token: 0x060047B0 RID: 18352 RVA: 0x002513E8 File Offset: 0x002503E8
		public static implicit operator CellPadding(float? a)
		{
			return new CellPadding(a);
		}

		// Token: 0x060047B1 RID: 18353 RVA: 0x00251400 File Offset: 0x00250400
		internal CellPadding a(bool A_0)
		{
			CellPadding cellPadding = new CellPadding(this.f);
			if (this.a == null && A_0)
			{
				cellPadding.a = new float?(2f);
			}
			else
			{
				cellPadding.a = this.a;
			}
			cellPadding.b = this.b;
			cellPadding.c = this.c;
			cellPadding.d = this.d;
			cellPadding.e = this.e;
			return cellPadding;
		}

		// Token: 0x060047B2 RID: 18354 RVA: 0x00251488 File Offset: 0x00250488
		internal void a(CellPadding A_0)
		{
			if (this.a == null)
			{
				this.a = A_0.a;
			}
			if (this.b == null)
			{
				this.b = A_0.b;
			}
			if (this.c == null)
			{
				this.c = A_0.c;
			}
			if (this.d == null)
			{
				this.d = A_0.d;
			}
			if (this.e == null)
			{
				this.e = A_0.e;
			}
		}

		// Token: 0x060047B3 RID: 18355 RVA: 0x00251520 File Offset: 0x00250520
		internal float b()
		{
			float result;
			if (this.Right == null)
			{
				result = 0f;
			}
			else
			{
				result = this.Right.Value;
			}
			return result;
		}

		// Token: 0x060047B4 RID: 18356 RVA: 0x0025155C File Offset: 0x0025055C
		internal float c()
		{
			float result;
			if (this.Left == null)
			{
				result = 0f;
			}
			else
			{
				result = this.Left.Value;
			}
			return result;
		}

		// Token: 0x060047B5 RID: 18357 RVA: 0x00251598 File Offset: 0x00250598
		internal float d()
		{
			float result;
			if (this.Top == null)
			{
				result = 0f;
			}
			else
			{
				result = this.Top.Value;
			}
			return result;
		}

		// Token: 0x060047B6 RID: 18358 RVA: 0x002515D4 File Offset: 0x002505D4
		internal float e()
		{
			float result;
			if (this.Bottom == null)
			{
				result = 0f;
			}
			else
			{
				result = this.Bottom.Value;
			}
			return result;
		}

		// Token: 0x060047B7 RID: 18359 RVA: 0x00251610 File Offset: 0x00250610
		private static bool a(CellPadding A_0, CellPadding A_1)
		{
			bool result;
			if (object.ReferenceEquals(A_0, A_1))
			{
				result = true;
			}
			else if (object.ReferenceEquals(A_1, null) || object.ReferenceEquals(A_0, null))
			{
				result = false;
			}
			else
			{
				float? num = A_0.Top;
				float? num2 = A_1.Top;
				bool flag;
				if (num.GetValueOrDefault() == num2.GetValueOrDefault() && num != null == (num2 != null))
				{
					num = A_0.Bottom;
					num2 = A_1.Bottom;
					if (num.GetValueOrDefault() == num2.GetValueOrDefault() && num != null == (num2 != null))
					{
						num = A_0.Left;
						num2 = A_1.Left;
						if (num.GetValueOrDefault() == num2.GetValueOrDefault() && num != null == (num2 != null))
						{
							num = A_0.Right;
							num2 = A_1.Right;
							flag = (num.GetValueOrDefault() == num2.GetValueOrDefault() && num != null == (num2 != null));
							goto IL_114;
						}
					}
				}
				flag = false;
				IL_114:
				result = flag;
			}
			return result;
		}

		// Token: 0x060047B8 RID: 18360 RVA: 0x00251738 File Offset: 0x00250738
		internal CellPadding b(qy A_0)
		{
			return new CellPadding(A_0)
			{
				a = this.a,
				b = this.b,
				c = this.c,
				d = this.d,
				e = this.e
			};
		}

		// Token: 0x0400273A RID: 10042
		private float? a;

		// Token: 0x0400273B RID: 10043
		private float? b;

		// Token: 0x0400273C RID: 10044
		private float? c;

		// Token: 0x0400273D RID: 10045
		private float? d;

		// Token: 0x0400273E RID: 10046
		private float? e;

		// Token: 0x0400273F RID: 10047
		private qy f;
	}
}
