using System;
using System.Collections;
using System.IO;

namespace zz93
{
	// Token: 0x02000469 RID: 1129
	internal class adg
	{
		// Token: 0x06002EF2 RID: 12018 RVA: 0x001AAD84 File Offset: 0x001A9D84
		internal adg(add A_0, ads A_1, ads A_2, ads A_3, ads A_4, ade A_5, adk A_6, ads A_7, ads A_8, byte[][] A_9, ads[] A_10)
		{
			this.k = A_0;
			this.a = A_1;
			this.b = A_2;
			this.c = A_3;
			this.d = A_4;
			this.e = this.a(A_0.b());
			this.g = this.a(A_0.b(), A_7);
			this.f = this.a(A_5.b() + 1, this.g, this.e, A_6);
			this.h = this.a(this.f, A_8, A_9, A_10);
		}

		// Token: 0x06002EF3 RID: 12019 RVA: 0x001AAE20 File Offset: 0x001A9E20
		internal void d()
		{
			this.k.a(adc.a());
			this.a.a(this.k);
			int[] array = new int[(int)(this.h.a() + 1)];
			int num = this.a(array);
			int num2 = 4 + this.a.e() + this.c.e() + this.d.e() + this.e.a() + this.f.a() + this.g.e();
			byte b;
			if (array[array.Length - 1] <= 255)
			{
				b = 1;
			}
			else if (array[array.Length - 1] <= 65535)
			{
				b = 2;
			}
			else if (array[array.Length - 1] <= 16777215)
			{
				b = 3;
			}
			else
			{
				b = 4;
			}
			num2 += 3 + array.Length * (int)b + num;
			num2 += this.b(num2);
			this.c.a(this.k);
			this.d.a(this.k);
			this.e.a(this.k);
			this.f.a(this.k);
			this.g.a(this.k);
			this.a(b, array, num2);
			this.c();
			this.a(this.k);
		}

		// Token: 0x06002EF4 RID: 12020 RVA: 0x001AAF90 File Offset: 0x001A9F90
		private ads a(adk A_0, ads A_1, byte[][] A_2, ads[] A_3)
		{
			adt adt = new adt();
			bool[] array = new bool[(int)A_1.a()];
			byte[] array2 = new byte[(int)A_1.a()];
			for (int i = 0; i < A_0.f().Length; i++)
			{
				array[(int)A_0.f()[i].b()] = true;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i])
				{
					int num = A_1.a(i);
					int a_ = A_1.a(i + 1) - num;
					array2[i] = (byte)adt.b();
					adt.a(A_1.d(), num, a_);
				}
			}
			ads ads = adt.a();
			this.i = new byte[(int)ads.a()][];
			this.j = new ads[(int)ads.a()];
			int num2 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i])
				{
					this.i[num2] = A_2[i];
					this.j[num2++] = A_3[i];
				}
			}
			for (int i = 0; i < A_0.f().Length; i++)
			{
				A_0.f()[i].a(array2[(int)A_0.f()[i].b()]);
			}
			return ads;
		}

		// Token: 0x06002EF5 RID: 12021 RVA: 0x001AB0F0 File Offset: 0x001AA0F0
		private adk a(int A_0, ads A_1, ade A_2, adk A_3)
		{
			adk adk = new adk(3);
			if (A_3.b() == 10)
			{
				adk.a(new adl[1]);
				adk.f()[0] = new adl(0, 0);
				adk.a(1);
				adk.b(A_1.a());
			}
			else
			{
				byte[] array = new byte[A_0];
				if (A_3.b() == 3)
				{
					for (int i = 0; i < (int)(A_3.c() - 1); i++)
					{
						for (int j = (int)A_3.f()[i].a(); j < (int)A_3.f()[i + 1].a(); j++)
						{
							array[j] = A_3.f()[i].b();
						}
					}
					for (int i = (int)A_3.f()[(int)(A_3.c() - 1)].a(); i < (int)A_3.d(); i++)
					{
						array[i] = A_3.f()[(int)(A_3.c() - 1)].b();
					}
				}
				else if (A_3.b() == 0)
				{
					for (int i = 0; i < A_3.e().Length; i++)
					{
						array[i] = A_3.e()[i];
					}
				}
				adl[] array2 = new adl[(int)A_1.a()];
				ushort num = 0;
				ushort num2 = 0;
				ushort num3 = 0;
				ushort num4 = 0;
				byte b = array[0];
				for (int i = 0; i < A_2.e().Length; i++)
				{
					for (int j = (int)A_2.e()[i].a(); j <= (int)(A_2.e()[i].a() + A_2.e()[i].b()); j++)
					{
						num2 += 1;
						if (array[j] != b)
						{
							adl[] array3 = array2;
							ushort num5 = num;
							num = num5 + 1;
							array3[(int)num5] = new adl(num3, b);
							num4 = num3;
							num3 = num2;
							b = array[j];
						}
					}
				}
				if (num2 == 0 || num4 != num2)
				{
					adl[] array4 = array2;
					ushort num6 = num;
					num = num6 + 1;
					array4[(int)num6] = new adl(num3, b);
				}
				adk.b(A_1.a());
				adk.a(num);
				adk.a(new adl[(int)num]);
				for (int i = 0; i < (int)num; i++)
				{
					adk.f()[i] = array2[i];
				}
			}
			return adk;
		}

		// Token: 0x06002EF6 RID: 12022 RVA: 0x001AB37C File Offset: 0x001AA37C
		private ads a(bool[] A_0, ads A_1)
		{
			ads ads = new ads();
			MemoryStream memoryStream = new MemoryStream();
			ArrayList arrayList = new ArrayList();
			arrayList.Add(1);
			int num = A_1.a(0);
			int count = A_1.a(1) - num;
			memoryStream.Write(A_1.d(), num, count);
			arrayList.Add((int)memoryStream.Position + 1);
			for (int i = 1; i < A_0.Length; i++)
			{
				if (A_0[i])
				{
					num = A_1.a(i);
					count = A_1.a(i + 1) - num;
					memoryStream.Write(A_1.d(), num, count);
					arrayList.Add((int)(memoryStream.Position + 1L));
				}
			}
			ads.a((ushort)(arrayList.Count - 1));
			int num2 = (int)arrayList[arrayList.Count - 1];
			if (num2 < 255)
			{
				ads.a(1);
			}
			else if (num2 < 65535)
			{
				ads.a(2);
			}
			else if (num2 < 16777215)
			{
				ads.a(3);
			}
			else
			{
				ads.a(4);
			}
			ads.a(new byte[(int)((ads.a() + 1) * (ushort)ads.c())]);
			for (int i = 0; i < arrayList.Count; i++)
			{
				ads.a(i, (int)arrayList[i]);
			}
			byte[] array = new byte[memoryStream.Position];
			memoryStream.Position = 0L;
			memoryStream.Read(array, 0, array.Length);
			ads.b(array);
			return ads;
		}

		// Token: 0x06002EF7 RID: 12023 RVA: 0x001AB54C File Offset: 0x001AA54C
		private ade a(bool[] A_0)
		{
			ade ade = new ade(1);
			ushort num = 0;
			ushort num2 = 0;
			ushort num3 = 1;
			while ((int)num3 < A_0.Length)
			{
				if (A_0[(int)num3])
				{
					if (num2 == 0)
					{
						num2 = num3;
					}
					else
					{
						num += 1;
					}
				}
				else if (num2 > 0)
				{
					adf a_ = new adf(num2, num);
					ade.a(a_);
					if (num > 255)
					{
						ade.a(2);
					}
					num2 = 0;
					num = 0;
				}
				num3 += 1;
			}
			if (num2 > 0)
			{
				adf a_ = new adf(num2, num);
				ade.a(a_);
				if (num > 255)
				{
					ade.a(2);
				}
			}
			return ade;
		}

		// Token: 0x06002EF8 RID: 12024 RVA: 0x001AB624 File Offset: 0x001AA624
		private void a(add A_0)
		{
			if (this.j != null)
			{
				for (int i = 0; i < this.j.Length; i++)
				{
					if (this.j[i] != null)
					{
						this.j[i].a(A_0);
					}
				}
			}
		}

		// Token: 0x06002EF9 RID: 12025 RVA: 0x001AB67C File Offset: 0x001AA67C
		private void c()
		{
			adj adj = new adj();
			int i = 0;
			int num = this.b();
			for (int j = 0; j < this.i.Length; j++)
			{
				if (this.i[j] != null)
				{
					i = 0;
					int num2 = this.i[j].Length;
					while (i < num2)
					{
						int num3 = i;
						adc.a(ref i, this.i[j], adj);
						int num4 = adj.b();
						if (num4 != 19)
						{
							this.k.a(this.i[j], num3, i - num3);
						}
						else
						{
							this.k.a(29);
							this.k.a(new byte[]
							{
								(byte)(num >> 24),
								(byte)(num >> 16),
								(byte)(num >> 8),
								(byte)num
							});
							this.k.a(19);
							num += this.j[j].e();
						}
					}
					num -= this.a(j);
				}
			}
		}

		// Token: 0x06002EFA RID: 12026 RVA: 0x001AB7B4 File Offset: 0x001AA7B4
		private void a(byte A_0, int[] A_1, int A_2)
		{
			this.k.b((int)this.h.a());
			this.k.a(A_0);
			if (A_0 == 1)
			{
				for (int i = 0; i < A_1.Length; i++)
				{
					this.k.a((byte)A_1[i]);
				}
			}
			else if (A_0 == 2)
			{
				for (int i = 0; i < A_1.Length; i++)
				{
					this.k.b(A_1[i]);
				}
			}
			else if (A_0 == 3)
			{
				for (int i = 0; i < A_1.Length; i++)
				{
					this.k.a((byte)(A_1[i] >> 16));
					this.k.a((byte)(A_1[i] >> 8));
					this.k.a((byte)A_1[i]);
				}
			}
			else
			{
				for (int i = 0; i < A_1.Length; i++)
				{
					this.k.a((byte)(A_1[i] >> 24));
					this.k.a((byte)(A_1[i] >> 16));
					this.k.a((byte)(A_1[i] >> 8));
					this.k.a((byte)A_1[i]);
				}
			}
			adj adj = new adj();
			int num = 0;
			for (int i = 0; i < (int)this.h.a(); i++)
			{
				int j;
				if (i == 0)
				{
					j = this.h.a(i);
				}
				else
				{
					j = num;
				}
				num = this.h.a(i + 1);
				while (j < num)
				{
					int num2 = j;
					adc.a(ref j, this.h.d(), adj);
					int num3 = adj.b();
					if (num3 != 18)
					{
						this.k.a(this.h.d(), num2, j - num2);
					}
					else if (this.i[i] != null)
					{
						int num4 = this.a(i);
						this.k.a(29);
						this.k.a(new byte[]
						{
							(byte)(num4 >> 24),
							(byte)(num4 >> 16),
							(byte)(num4 >> 8),
							(byte)num4
						});
						this.k.a(29);
						this.k.a(new byte[]
						{
							(byte)(A_2 >> 24),
							(byte)(A_2 >> 16),
							(byte)(A_2 >> 8),
							(byte)A_2
						});
						this.k.a(18);
						A_2 += num4;
					}
				}
			}
		}

		// Token: 0x06002EFB RID: 12027 RVA: 0x001ABA8C File Offset: 0x001AAA8C
		private int b(int A_0)
		{
			int num = this.a();
			int num2 = 4 + this.a.e() + this.c.e() + this.d.e();
			this.k.b(1);
			int num3;
			if (num < 254)
			{
				this.k.a(1);
				this.k.a(1);
				this.k.a((byte)(num + 1));
				num3 = 5 + num;
			}
			else
			{
				this.k.a(2);
				this.k.b(1);
				this.k.b(num + 1);
				num3 = 7 + num;
			}
			num2 += num3;
			int i = 0;
			int num4 = this.b.a(1);
			adj adj = new adj();
			while (i < num4)
			{
				int num5 = i;
				adc.a(ref i, this.b.d(), adj);
				int num6 = adj.b();
				switch (num6)
				{
				case 15:
				{
					int num7 = num2;
					this.k.a(29);
					this.k.a(new byte[]
					{
						(byte)(num7 >> 24),
						(byte)(num7 >> 16),
						(byte)(num7 >> 8),
						(byte)num7
					});
					this.k.a(15);
					break;
				}
				case 16:
					goto IL_3C6;
				case 17:
				{
					int num7 = num2 + this.e.a() + this.f.a();
					this.k.a(29);
					this.k.a(new byte[]
					{
						(byte)(num7 >> 24),
						(byte)(num7 >> 16),
						(byte)(num7 >> 8),
						(byte)num7
					});
					this.k.a(17);
					break;
				}
				case 18:
				{
					int num7 = A_0 + num3;
					this.k.a(29);
					this.k.a(new byte[]
					{
						(byte)(this.i[0].Length >> 24),
						(byte)(this.i[0].Length >> 16),
						(byte)(this.i[0].Length >> 8),
						(byte)this.i[0].Length
					});
					this.k.a(29);
					this.k.a(new byte[]
					{
						(byte)(num7 >> 24),
						(byte)(num7 >> 16),
						(byte)(num7 >> 8),
						(byte)num7
					});
					this.k.a(18);
					break;
				}
				default:
					switch (num6)
					{
					case 3108:
					{
						int num7 = num2 + this.e.a() + this.f.a() + this.g.e();
						this.k.a(29);
						this.k.a(new byte[]
						{
							(byte)(num7 >> 24),
							(byte)(num7 >> 16),
							(byte)(num7 >> 8),
							(byte)num7
						});
						this.k.a(12);
						this.k.a(36);
						break;
					}
					case 3109:
					{
						int num7 = num2 + this.e.a();
						this.k.a(29);
						this.k.a(new byte[]
						{
							(byte)(num7 >> 24),
							(byte)(num7 >> 16),
							(byte)(num7 >> 8),
							(byte)num7
						});
						this.k.a(12);
						this.k.a(37);
						break;
					}
					default:
						goto IL_3C6;
					}
					break;
				}
				continue;
				IL_3C6:
				this.k.a(this.b.d(), num5, i - num5);
			}
			return num3;
		}

		// Token: 0x06002EFC RID: 12028 RVA: 0x001ABE94 File Offset: 0x001AAE94
		private int a(int A_0)
		{
			adj adj = new adj();
			int num = 0;
			if (this.i[A_0] != null)
			{
				int i = 0;
				int num2 = this.i[A_0].Length;
				while (i < num2)
				{
					int num3 = i;
					adc.a(ref i, this.i[A_0], adj);
					int num4 = adj.b();
					if (num4 != 19)
					{
						num += i - num3;
					}
					else
					{
						num += 6;
					}
				}
			}
			return num;
		}

		// Token: 0x06002EFD RID: 12029 RVA: 0x001ABF18 File Offset: 0x001AAF18
		private int b()
		{
			adj adj = new adj();
			int i = 0;
			int num = 0;
			for (int j = 0; j < this.i.Length; j++)
			{
				if (this.i[j] != null)
				{
					i = 0;
					int num2 = this.i[j].Length;
					while (i < num2)
					{
						int num3 = i;
						adc.a(ref i, this.i[j], adj);
						int num4 = adj.b();
						if (num4 != 19)
						{
							num += i - num3;
						}
						else
						{
							num += 6;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06002EFE RID: 12030 RVA: 0x001ABFC4 File Offset: 0x001AAFC4
		private int a(int[] A_0)
		{
			adj adj = new adj();
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < (int)this.h.a(); i++)
			{
				int j;
				if (i == 0)
				{
					j = this.h.a(i);
				}
				else
				{
					j = num;
				}
				A_0[i] = num2 + 1;
				num = this.h.a(i + 1);
				while (j < num)
				{
					int num3 = j;
					adc.a(ref j, this.h.d(), adj);
					int num4 = adj.b();
					if (num4 != 18)
					{
						num2 += j - num3;
					}
					else
					{
						num2 += 11;
					}
				}
			}
			A_0[(int)this.h.a()] = num2 + 1;
			return num2;
		}

		// Token: 0x06002EFF RID: 12031 RVA: 0x001AC098 File Offset: 0x001AB098
		private int a()
		{
			int i = 0;
			int num = this.b.a(1);
			int num2 = 0;
			adj adj = new adj();
			while (i < num)
			{
				int num3 = i;
				adc.a(ref i, this.b.d(), adj);
				int num4 = adj.b();
				switch (num4)
				{
				case 15:
				case 16:
				case 17:
					num2 += 6;
					break;
				case 18:
					num2 += 11;
					break;
				default:
					switch (num4)
					{
					case 3108:
					case 3109:
						num2 += 7;
						break;
					default:
						num2 += i - num3;
						break;
					}
					break;
				}
			}
			return num2;
		}

		// Token: 0x04001651 RID: 5713
		private ads a;

		// Token: 0x04001652 RID: 5714
		private ads b;

		// Token: 0x04001653 RID: 5715
		private ads c;

		// Token: 0x04001654 RID: 5716
		private ads d;

		// Token: 0x04001655 RID: 5717
		private ade e;

		// Token: 0x04001656 RID: 5718
		private adk f;

		// Token: 0x04001657 RID: 5719
		private ads g;

		// Token: 0x04001658 RID: 5720
		private ads h;

		// Token: 0x04001659 RID: 5721
		private byte[][] i;

		// Token: 0x0400165A RID: 5722
		private ads[] j;

		// Token: 0x0400165B RID: 5723
		private add k;
	}
}
