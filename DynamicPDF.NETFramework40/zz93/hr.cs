using System;

namespace zz93
{
	// Token: 0x02000137 RID: 311
	internal class hr : fd
	{
		// Token: 0x06000BCE RID: 3022 RVA: 0x0008EBD5 File Offset: 0x0008DBD5
		internal hr()
		{
			this.a = new fb<f9>[4];
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x0008EBFA File Offset: 0x0008DBFA
		internal hr(gi A_0)
		{
			this.a = new fb<f9>[4];
			this.cw(A_0);
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x0008EC28 File Offset: 0x0008DC28
		internal fb<f9>[] a()
		{
			return this.a;
		}

		// Token: 0x06000BD1 RID: 3025 RVA: 0x0008EC40 File Offset: 0x0008DC40
		internal void a(fb<f9>[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000BD2 RID: 3026 RVA: 0x0008EC4C File Offset: 0x0008DC4C
		internal override int cv()
		{
			return 254664735;
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x0008EC64 File Offset: 0x0008DC64
		internal override bool ct()
		{
			return this.c;
		}

		// Token: 0x06000BD4 RID: 3028 RVA: 0x0008EC7C File Offset: 0x0008DC7C
		internal override void cu(bool A_0)
		{
			this.c = A_0;
		}

		// Token: 0x06000BD5 RID: 3029 RVA: 0x0008EC86 File Offset: 0x0008DC86
		internal override fn cx()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x0008EC94 File Offset: 0x0008DC94
		private void a(gi A_0)
		{
			string[] array = new string[4];
			int num = 0;
			if (A_0.aw())
			{
				array[num] = A_0.ah().Trim().ToLower();
				num++;
				while (A_0.a0() && A_0.aw())
				{
					array[num] = A_0.ah().Trim().ToLower();
					num++;
				}
			}
			num = ((num > 4) ? 4 : num);
			this.a(num, array, A_0);
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x0008ED18 File Offset: 0x0008DD18
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

		// Token: 0x06000BD8 RID: 3032 RVA: 0x0008EDBC File Offset: 0x0008DDBC
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

		// Token: 0x06000BD9 RID: 3033 RVA: 0x0008EEFC File Offset: 0x0008DEFC
		private void a(int A_0, string A_1, gi A_2)
		{
			if (A_1 != null)
			{
				int num;
				f9 f;
				if (char.IsNumber(A_1[0]) || A_1.StartsWith("+") || A_1.StartsWith("-"))
				{
					num = this.a(A_0);
					i4 a_ = A_2.a(A_1);
					f = new f9(m4.a(new h2(a_)));
					f.a(a_.b());
					if (a_.b() == i2.b)
					{
						f.a(true);
					}
				}
				else
				{
					num = this.a(A_0);
					f = new f9(x5.a(0f));
					string text = A_1.ToLower();
					if (text != null)
					{
						if (!(text == "auto"))
						{
							if (text == "inherit")
							{
								f.d(true);
							}
						}
						else
						{
							f.b(true);
						}
					}
				}
				if (num < 0)
				{
					this.a[this.b++] = new fb<f9>(A_0, f);
				}
				else
				{
					this.a[num].a(A_0);
					this.a[num].a(f);
				}
			}
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x0008F054 File Offset: 0x0008E054
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

		// Token: 0x06000BDB RID: 3035 RVA: 0x0008F0A4 File Offset: 0x0008E0A4
		private void a(fb<f9> A_0, ref hr A_1, ref int A_2)
		{
			if (!this.a(A_0.a(), A_1.a()))
			{
				A_1.a()[A_2].a(A_0.a());
				A_1.a()[A_2].a(A_0.b());
				A_1.a()[A_2].b().d(A_0.b().g());
				A_2++;
			}
		}

		// Token: 0x06000BDC RID: 3036 RVA: 0x0008F130 File Offset: 0x0008E130
		private bool a(int A_0, fb<f9>[] A_1)
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

		// Token: 0x06000BDD RID: 3037 RVA: 0x0008F174 File Offset: 0x0008E174
		private bool a(int A_0, fb<f9>[] A_1, ref int A_2)
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

		// Token: 0x06000BDE RID: 3038 RVA: 0x0008F1E8 File Offset: 0x0008E1E8
		internal override void cw(gi A_0)
		{
			if (A_0.x())
			{
				int num = A_0.y();
				if (num != 0)
				{
					this.a(A_0, num);
				}
			}
			else
			{
				this.a = new fb<f9>[4];
				this.b = 0;
				this.a(A_0);
				this.c = true;
			}
		}

		// Token: 0x06000BDF RID: 3039 RVA: 0x0008F244 File Offset: 0x0008E244
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

		// Token: 0x06000BE0 RID: 3040 RVA: 0x0008F2B4 File Offset: 0x0008E2B4
		internal hr a(hr A_0)
		{
			fb<f9>[] array = A_0.a();
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

		// Token: 0x06000BE1 RID: 3041 RVA: 0x0008F3C0 File Offset: 0x0008E3C0
		internal hr b(hr A_0)
		{
			hr hr = new hr();
			int num = 0;
			fb<f9>[] array = A_0.a();
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0)
				{
					hr.a()[num].a(this.a()[i].a());
					hr.a()[num].a(this.a()[i].b());
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
					if (!flag)
					{
						this.a(array[i], ref hr, ref num);
					}
				}
			}
			return hr;
		}

		// Token: 0x06000BE2 RID: 3042 RVA: 0x0008F50C File Offset: 0x0008E50C
		internal hr a(hr A_0, hr A_1)
		{
			hr hr = new hr();
			fb<f9>[] array = A_0.a();
			fb<f9>[] array2 = A_1.a();
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
			hr.a(array);
			return hr;
		}

		// Token: 0x04000639 RID: 1593
		private new fb<f9>[] a;

		// Token: 0x0400063A RID: 1594
		private int b = 0;

		// Token: 0x0400063B RID: 1595
		private bool c = false;
	}
}
