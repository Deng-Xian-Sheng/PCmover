using System;

namespace zz93
{
	// Token: 0x020003A7 RID: 935
	internal abstract class yh : yg
	{
		// Token: 0x060027BC RID: 10172 RVA: 0x0016BEB8 File Offset: 0x0016AEB8
		internal yh(yj A_0, int A_1, int A_2)
		{
			this.d = A_1;
			this.e = A_2;
			bool a_ = false;
			uint[] a_2 = null;
			uint[] a_3 = null;
			if (A_0.b(262U))
			{
				this.b = (A_0.e() == 1);
			}
			if (A_0.b(266U))
			{
				a_ = (A_0.e() == 2);
			}
			if (A_0.b(273U))
			{
				a_2 = A_0.k();
			}
			if (A_0.b(278U))
			{
				this.c = A_0.f();
			}
			if (A_0.b(279U))
			{
				a_3 = A_0.k();
			}
			this.a = this.gz(A_0, a_2, a_3, a_);
		}

		// Token: 0x060027BD RID: 10173 RVA: 0x0016BF90 File Offset: 0x0016AF90
		protected virtual byte[] gz(yj A_0, uint[] A_1, uint[] A_2, bool A_3)
		{
			uint num = 0U;
			foreach (uint num2 in A_2)
			{
				num += num2;
			}
			if (num == 0U)
			{
				uint num3 = 0U;
				foreach (uint num4 in A_1)
				{
					num3 += num4;
				}
				num = (uint)(A_0.p() - (int)num3);
				for (int j = 0; j < A_1.Length; j++)
				{
					A_2[j] = num;
				}
			}
			byte[] array = new byte[num + 2U];
			int num5 = 0;
			for (int j = 0; j < A_1.Length; j++)
			{
				A_0.a(A_1[j], array, num5, (int)A_2[j]);
				num5 += (int)A_2[j];
			}
			array[(int)((UIntPtr)num)] = 0;
			array[(int)((UIntPtr)(num + 1U))] = 1;
			if (A_3)
			{
				base.a(array);
			}
			return array;
		}

		// Token: 0x060027BE RID: 10174 RVA: 0x0016C09C File Offset: 0x0016B09C
		protected new int a()
		{
			return (int)this.c;
		}

		// Token: 0x060027BF RID: 10175 RVA: 0x0016C0B4 File Offset: 0x0016B0B4
		protected new bool b()
		{
			return this.b;
		}

		// Token: 0x060027C0 RID: 10176 RVA: 0x0016C0CC File Offset: 0x0016B0CC
		protected new int c()
		{
			return this.d;
		}

		// Token: 0x060027C1 RID: 10177 RVA: 0x0016C0E4 File Offset: 0x0016B0E4
		protected new int d()
		{
			return this.e;
		}

		// Token: 0x060027C2 RID: 10178 RVA: 0x0016C0FC File Offset: 0x0016B0FC
		internal override byte[] gx()
		{
			return this.a;
		}

		// Token: 0x04001145 RID: 4421
		private new byte[] a = null;

		// Token: 0x04001146 RID: 4422
		private new bool b = false;

		// Token: 0x04001147 RID: 4423
		private new uint c;

		// Token: 0x04001148 RID: 4424
		private new int d;

		// Token: 0x04001149 RID: 4425
		private new int e;
	}
}
