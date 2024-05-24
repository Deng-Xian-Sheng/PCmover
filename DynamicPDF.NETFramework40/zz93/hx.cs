using System;

namespace zz93
{
	// Token: 0x0200013D RID: 317
	internal class hx : fd
	{
		// Token: 0x06000BFF RID: 3071 RVA: 0x0008FD34 File Offset: 0x0008ED34
		internal hx()
		{
			this.a = new fb<ge>[4];
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x0008FD59 File Offset: 0x0008ED59
		internal hx(gi A_0)
		{
			this.a = new fb<ge>[4];
			this.cw(A_0);
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x0008FD88 File Offset: 0x0008ED88
		internal fb<ge>[] a()
		{
			return this.a;
		}

		// Token: 0x06000C02 RID: 3074 RVA: 0x0008FDA0 File Offset: 0x0008EDA0
		internal void a(fb<ge>[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x0008FDAC File Offset: 0x0008EDAC
		internal override int cv()
		{
			return 265770411;
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x0008FDC4 File Offset: 0x0008EDC4
		internal override bool ct()
		{
			return this.c;
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x0008FDDC File Offset: 0x0008EDDC
		internal override void cu(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000C06 RID: 3078 RVA: 0x0008FDE8 File Offset: 0x0008EDE8
		private void a(gi A_0)
		{
			string[] array = new string[4];
			int num = 0;
			if (A_0.aw())
			{
				array[num] = A_0.ah().Trim();
				num++;
				while (A_0.a0() && A_0.aw() && num < 4)
				{
					if (num < 4)
					{
						array[num] = A_0.ah().Trim();
						num++;
					}
					else
					{
						A_0.ah().Trim();
					}
				}
			}
			num = ((num > 4) ? 4 : num);
			this.a(num, array, A_0);
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x0008FE84 File Offset: 0x0008EE84
		private void a(gi A_0, int A_1)
		{
			if (A_1 <= 7021096)
			{
				if (A_1 == 136794)
				{
					string a_ = A_0.au();
					this.a(136794, a_, A_0);
					return;
				}
				if (A_1 == 7021096)
				{
					string a_ = A_0.au();
					this.a(7021096, a_, A_0);
					return;
				}
			}
			else
			{
				if (A_1 == 426354259)
				{
					string a_ = A_0.au();
					this.a(426354259, a_, A_0);
					return;
				}
				if (A_1 == 448574430)
				{
					string a_ = A_0.au();
					this.a(448574430, a_, A_0);
					return;
				}
			}
			A_0.ap();
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x0008FF28 File Offset: 0x0008EF28
		private void a(int A_0, string[] A_1, gi A_2)
		{
			switch (A_0)
			{
			case 1:
				this.a(136794, A_1[0], A_2);
				this.a(448574430, A_1[0], A_2);
				this.a(426354259, A_1[0], A_2);
				this.a(7021096, A_1[0], A_2);
				break;
			case 2:
				this.a(136794, A_1[0], A_2);
				this.a(448574430, A_1[1], A_2);
				this.a(426354259, A_1[0], A_2);
				this.a(7021096, A_1[1], A_2);
				break;
			case 3:
				this.a(136794, A_1[0], A_2);
				this.a(448574430, A_1[1], A_2);
				this.a(426354259, A_1[2], A_2);
				this.a(7021096, A_1[1], A_2);
				break;
			case 4:
				this.a(136794, A_1[0], A_2);
				this.a(448574430, A_1[1], A_2);
				this.a(426354259, A_1[2], A_2);
				this.a(7021096, A_1[3], A_2);
				break;
			}
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x00090068 File Offset: 0x0008F068
		private void a(int A_0, string A_1, gi A_2)
		{
			if (A_1 != null)
			{
				int num;
				ge ge;
				if (!A_1.StartsWith("-") && (char.IsNumber(A_1[0]) || A_1.StartsWith("+") || A_1.StartsWith(".")))
				{
					num = this.a(A_0);
					i4 a_ = A_2.a(A_1);
					ge = new ge(m4.a(new h2(a_)));
					ge.a(a_.b());
					if (a_.b() == i2.b)
					{
						ge.a(true);
					}
				}
				else
				{
					num = this.a(A_0);
					ge = new ge(x5.a(0f));
					string text = A_1.ToLower();
					if (text != null)
					{
						if (text == "inherit")
						{
							ge.d(true);
						}
					}
				}
				if (num < 0)
				{
					this.a[this.b++] = new fb<ge>(A_0, ge);
				}
				else
				{
					this.a[num].a(A_0);
					this.a[num].a(ge);
				}
			}
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x000901BC File Offset: 0x0008F1BC
		private int a(int A_0)
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i].a() == A_0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x0009020C File Offset: 0x0008F20C
		private void a(fb<ge> A_0, ref hx A_1, ref int A_2)
		{
			if (!this.a(A_0.a(), A_1.a()))
			{
				A_1.a()[A_2].a(A_0.a());
				A_1.a()[A_2].a(A_0.b());
				A_1.a()[A_2].b().d(A_0.b().g());
				A_2++;
			}
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x00090298 File Offset: 0x0008F298
		private bool a(int A_0, fb<ge>[] A_1)
		{
			for (int i = 0; i < A_1.Length; i++)
			{
				if (A_1[i].a() == A_0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x000902DC File Offset: 0x0008F2DC
		private bool a(int A_0, fb<ge>[] A_1, ref int A_2)
		{
			while (A_2 < A_1.Length)
			{
				bool result;
				if (A_1[A_2].a() != 0 && A_1[A_2].a() == A_0)
				{
					result = true;
				}
				else
				{
					if (A_1[A_2].a() != 0)
					{
						A_2++;
						continue;
					}
					result = false;
				}
				return result;
			}
			return false;
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x00090350 File Offset: 0x0008F350
		internal override void cw(gi A_0)
		{
			if (A_0.x())
			{
				int a_ = A_0.y();
				this.a(A_0, a_);
			}
			else
			{
				this.a = new fb<ge>[4];
				this.b = 0;
				this.a(A_0);
				this.c = true;
			}
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x000903A3 File Offset: 0x0008F3A3
		internal override fn cx()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x000903B0 File Offset: 0x0008F3B0
		internal bool b()
		{
			bool result = false;
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0 && this.a()[i].b().g())
				{
					result = true;
					i = this.a().Length;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x00090420 File Offset: 0x0008F420
		internal hx a(hx A_0, hx A_1)
		{
			hx hx = new hx();
			fb<ge>[] array = A_0.a();
			fb<ge>[] array2 = A_1.a();
			int num = 0;
			for (int i = 0; i < array2.Length; i++)
			{
				if (!this.a(array2[i].a(), array, ref num))
				{
					if (array2[i].a() != 0)
					{
						array[num].a(array2[i].a());
						array[num].a(array2[i].b());
					}
				}
				num = 0;
			}
			hx.a(array);
			return hx;
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x000904DC File Offset: 0x0008F4DC
		internal hx a(hx A_0)
		{
			fb<ge>[] array = A_0.a();
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0)
				{
					for (int j = 0; j < array.Length; j++)
					{
						if (this.a()[i].a() == array[j].a())
						{
							if (this.a()[i].b().g() && !array[j].b().g())
							{
								this.a()[i].a(array[j].b());
								this.a()[i].b().d(false);
							}
							break;
						}
					}
				}
			}
			return this;
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x000905E8 File Offset: 0x0008F5E8
		internal hx b(hx A_0)
		{
			hx hx = new hx();
			int num = 0;
			fb<ge>[] array = A_0.a();
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0)
				{
					hx.a()[num].a(this.a()[i].a());
					hx.a()[num].a(this.a()[i].b());
					num++;
				}
			}
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = false;
				if (array[i].a() != 0)
				{
					for (int j = 0; j < this.a().Length; j++)
					{
						if (this.a()[j].a() == array[i].a())
						{
							flag = true;
							break;
						}
					}
					if (!flag && num < 4)
					{
						this.a(array[i], ref hx, ref num);
					}
				}
			}
			return hx;
		}

		// Token: 0x04000641 RID: 1601
		private new fb<ge>[] a;

		// Token: 0x04000642 RID: 1602
		private int b = 0;

		// Token: 0x04000643 RID: 1603
		private bool c = false;
	}
}
