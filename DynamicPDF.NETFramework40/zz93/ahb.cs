using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace zz93
{
	// Token: 0x020004F6 RID: 1270
	internal class ahb
	{
		// Token: 0x060033D5 RID: 13269 RVA: 0x001CBFD0 File Offset: 0x001CAFD0
		internal ahb(byte[] A_0)
		{
			this.a = A_0;
			this.b = A_0.Length;
			this.f(0);
			this.e(0);
		}

		// Token: 0x060033D6 RID: 13270 RVA: 0x001CC004 File Offset: 0x001CB004
		[CompilerGenerated]
		internal int e()
		{
			return this.c;
		}

		// Token: 0x060033D7 RID: 13271 RVA: 0x001CC01B File Offset: 0x001CB01B
		[CompilerGenerated]
		private void f(int A_0)
		{
			this.c = A_0;
		}

		// Token: 0x060033D8 RID: 13272 RVA: 0x001CC024 File Offset: 0x001CB024
		[CompilerGenerated]
		internal int f()
		{
			return this.d;
		}

		// Token: 0x060033D9 RID: 13273 RVA: 0x001CC03B File Offset: 0x001CB03B
		[CompilerGenerated]
		private void e(int A_0)
		{
			this.d = A_0;
		}

		// Token: 0x060033DA RID: 13274 RVA: 0x001CC044 File Offset: 0x001CB044
		internal ahc g()
		{
			this.e(this.e());
			bool flag = false;
			byte b = 0;
			this.c();
			while (this.e() < this.b)
			{
				if (!flag && ahb.i(this.a[this.e()]) && !this.d())
				{
					if (this.a[this.e()] == 40)
					{
						b = 41;
					}
					else
					{
						b = 62;
					}
					flag = true;
				}
				else if (flag && this.a[this.e()] == b && !this.d())
				{
					b = 0;
					flag = false;
				}
				else if (!flag && (this.e() == 0 || ahb.c(this.a[this.e() - 1]) || ahb.g(this.a[this.e() - 1])))
				{
					if (ahb.d(this.a[this.e()]))
					{
						ahc result;
						if (this.e() + 1 < this.b && ahb.e(this.a[this.e() + 1]))
						{
							if (this.e() + 2 < this.b && ahb.e(this.a[this.e() + 2]))
							{
								if ((this.e() + 3 >= this.b || !ahb.c(this.a[this.e() + 3])) && this.e() + 3 != this.b)
								{
									this.f(this.e() + 3);
									continue;
								}
								ahc ahc = this.a(this.e(), 3);
								this.f(this.e() + 3);
								result = ahc;
							}
							else
							{
								ahc ahc = this.a(this.e(), 2);
								this.f(this.e() + 2);
								result = ahc;
							}
						}
						else
						{
							ahc ahc = this.f(this.a[this.e()]);
							this.f(this.e() + 1);
							result = ahc;
						}
						return result;
					}
				}
				this.f(this.e() + 1);
			}
			return ahc.a;
		}

		// Token: 0x060033DB RID: 13275 RVA: 0x001CC2C0 File Offset: 0x001CB2C0
		private bool d()
		{
			bool result;
			if (this.a[this.e() - 1] == 92)
			{
				if (this.a[this.e() - 2] == 92)
				{
					int i = this.e() - 2;
					bool flag = false;
					while (i > 0)
					{
						i--;
						if (this.a[i] != 92)
						{
							break;
						}
						flag = !flag;
					}
					result = flag;
				}
				else
				{
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x060033DC RID: 13276 RVA: 0x001CC350 File Offset: 0x001CB350
		private static bool i(byte A_0)
		{
			return A_0 == 40 || A_0 == 60;
		}

		// Token: 0x060033DD RID: 13277 RVA: 0x001CC380 File Offset: 0x001CB380
		private static bool h(byte A_0)
		{
			return (A_0 >= 65 && A_0 <= 90) || (A_0 >= 97 && A_0 <= 122);
		}

		// Token: 0x060033DE RID: 13278 RVA: 0x001CC3BC File Offset: 0x001CB3BC
		private static bool g(byte A_0)
		{
			return A_0 == 41 || A_0 == 62 || A_0 == 93 || A_0 == 125;
		}

		// Token: 0x060033DF RID: 13279 RVA: 0x001CC3F4 File Offset: 0x001CB3F4
		private ahc f(byte A_0)
		{
			return (ahc)A_0;
		}

		// Token: 0x060033E0 RID: 13280 RVA: 0x001CC408 File Offset: 0x001CB408
		private ahc a(int A_0, int A_1)
		{
			ahc result;
			if (A_1 == 2)
			{
				result = (ahc)((int)this.a[A_0] << 8 | (int)this.a[A_0 + 1]);
			}
			else
			{
				result = (ahc)((int)this.a[A_0] << 16 | (int)this.a[A_0 + 1] << 8 | (int)this.a[A_0 + 2]);
			}
			return result;
		}

		// Token: 0x060033E1 RID: 13281 RVA: 0x001CC464 File Offset: 0x001CB464
		private static bool e(byte A_0)
		{
			return (A_0 >= 65 && A_0 <= 90) || (A_0 >= 97 && A_0 <= 122) || (A_0 == 48 || A_0 == 49 || A_0 == 42 || A_0 == 34) || A_0 == 39;
		}

		// Token: 0x060033E2 RID: 13282 RVA: 0x001CC4BC File Offset: 0x001CB4BC
		private static bool d(byte A_0)
		{
			return (A_0 >= 65 && A_0 <= 90) || (A_0 >= 97 && A_0 <= 122) || A_0 == 34 || A_0 == 39;
		}

		// Token: 0x060033E3 RID: 13283 RVA: 0x001CC500 File Offset: 0x001CB500
		private static bool c(byte A_0)
		{
			return A_0 <= 32;
		}

		// Token: 0x060033E4 RID: 13284 RVA: 0x001CC524 File Offset: 0x001CB524
		private bool b(byte A_0)
		{
			return (A_0 >= 48 && A_0 <= 57) || A_0 == 46 || A_0 == 45;
		}

		// Token: 0x060033E5 RID: 13285 RVA: 0x001CC55C File Offset: 0x001CB55C
		private void c()
		{
			while (this.e() < this.b && this.a[this.e()] <= 32)
			{
				this.f(this.e() + 1);
			}
		}

		// Token: 0x060033E6 RID: 13286 RVA: 0x001CC5A8 File Offset: 0x001CB5A8
		internal void a(ref float? A_0, float[,] A_1, ref string A_2, ref float A_3, ref float A_4, string A_5, df A_6)
		{
			float a_ = 0f;
			float a_2 = 0f;
			float num = 0f;
			float num2 = 0f;
			float[,] array = A_1;
			bool a_3 = false;
			bool flag = false;
			ahc ahc = this.g();
			while (ahc != ahc.a && ahc != ahc.aq)
			{
				ahc ahc2 = ahc;
				float[] array4;
				if (ahc2 <= ahc.ba)
				{
					if (ahc2 <= ahc.ab)
					{
						if (ahc2 != ahc.ac)
						{
							if (ahc2 == ahc.ab)
							{
								float[] array2 = new float[2];
								float[] array3 = array2;
								int num3 = 1;
								float? num4 = A_0;
								num4 = ((num4 != null) ? new float?(-num4.GetValueOrDefault()) : null);
								array3[num3] = ((num4 != null) ? num4.GetValueOrDefault() : 0f);
								array4 = array2;
								array = ahb.a(array4, array);
								a_ = array[2, 0];
								a_2 = array[2, 1];
								if (A_4 != 0f)
								{
									A_3 = A_4 * array[0, 0];
								}
								else
								{
									A_3 = array[0, 0];
								}
								if (num != 0f || num2 != 0f)
								{
									num *= array[0, 0];
									num2 *= array[0, 0];
								}
								de de = this.b();
								if (de != null)
								{
									ahb.a(de, num2, num, A_2, A_3, a_, a_2, A_0, a_3, A_5);
									A_6.a().Add(de);
								}
								a_3 = false;
							}
						}
						else
						{
							float[] array2 = new float[2];
							float[] array5 = array2;
							int num5 = 1;
							float? num4 = A_0;
							num4 = ((num4 != null) ? new float?(-num4.GetValueOrDefault()) : null);
							array5[num5] = ((num4 != null) ? num4.GetValueOrDefault() : 0f);
							array4 = array2;
							array = ahb.a(array4, array);
							a_ = array[2, 0];
							a_2 = array[2, 1];
							if (A_4 != 0f)
							{
								A_3 = A_4 * array[0, 0];
							}
							else
							{
								A_3 = array[0, 0];
							}
							if (num != 0f || num2 != 0f)
							{
								num *= array[0, 0];
								num2 *= array[0, 0];
							}
							de de = this.a(ref num, ref num2);
							if (de != null)
							{
								ahb.a(de, num2, num, A_2, A_3, a_, a_2, A_0, a_3, A_5);
								A_6.a().Add(de);
							}
							a_3 = false;
						}
					}
					else if (ahc2 != ahc.a3)
					{
						if (ahc2 == ahc.a6)
						{
							goto IL_29E;
						}
						switch (ahc2)
						{
						case ahc.a9:
							if (!flag)
							{
								A_3 = this.a(A_3, array);
							}
							if (num != 0f || num2 != 0f)
							{
								num *= array[0, 0];
								num2 *= array[0, 0];
							}
							this.a(A_6, num2, num, A_2, A_3, a_, a_2, A_0, a_3, A_5);
							a_3 = false;
							break;
						case ahc.ba:
							A_0 = this.i();
							a_3 = true;
							break;
						}
					}
					else
					{
						float[] array2 = new float[2];
						float[] array6 = array2;
						int num6 = 1;
						float? num4 = A_0;
						num4 = ((num4 != null) ? new float?(-num4.GetValueOrDefault()) : null);
						array6[num6] = ((num4 != null) ? num4.GetValueOrDefault() : 0f);
						array4 = array2;
						array = ahb.a(array4, array);
						a_ = array[2, 0];
						a_2 = array[2, 1];
						if (A_4 != 0f)
						{
							A_3 = A_4 * array[0, 0];
						}
						else
						{
							A_3 = array[0, 0];
						}
					}
				}
				else if (ahc2 <= ahc.a8)
				{
					switch (ahc2)
					{
					case ahc.a4:
					{
						int a_4 = this.e();
						this.f(this.f());
						float? num4 = this.b(a_4);
						num = ((num4 != null) ? num4.GetValueOrDefault() : 0f);
						this.f(a_4);
						break;
					}
					case ahc.a5:
						goto IL_29E;
					case (ahc)21605:
						break;
					case ahc.a7:
						A_2 = this.a(ref A_3);
						A_4 = A_3;
						flag = true;
						break;
					default:
						if (ahc2 == ahc.a8)
						{
							if (!flag)
							{
								A_3 = this.a(A_3, array);
							}
							if (num != 0f || num2 != 0f)
							{
								num *= array[0, 0];
								num2 *= array[0, 0];
							}
							de de = this.b();
							if (de != null)
							{
								ahb.a(de, num2, num, A_2, A_3, a_, a_2, A_0, a_3, A_5);
								A_6.a().Add(de);
							}
							a_3 = false;
						}
						break;
					}
				}
				else if (ahc2 != ahc.bb)
				{
					switch (ahc2)
					{
					case ahc.bc:
						break;
					case ahc.bd:
						break;
					default:
						if (ahc2 == ahc.be)
						{
							int a_4 = this.e();
							this.f(this.f());
							float? num4 = this.b(a_4);
							num2 = ((num4 != null) ? num4.GetValueOrDefault() : 0f);
							this.f(a_4);
						}
						break;
					}
				}
				else
				{
					float[] a_5 = this.j();
					array = ahb.b(a_5, A_1);
					a_ = array[2, 0];
					a_2 = array[2, 1];
					if (A_4 != 0f)
					{
						A_3 = A_4 * array[0, 0];
					}
					else
					{
						A_3 = array[0, 0];
					}
					flag = true;
				}
				IL_69E:
				ahc = this.g();
				continue;
				IL_29E:
				array4 = this.a();
				if (ahc == ahc.a6)
				{
					A_0 = new float?(-array4[1]);
				}
				array = ahb.a(array4, array);
				a_ = array[2, 0];
				a_2 = array[2, 1];
				if (A_4 != 0f)
				{
					A_3 = A_4 * array[0, 0];
				}
				else
				{
					A_3 = array[0, 0];
				}
				flag = true;
				goto IL_69E;
			}
		}

		// Token: 0x060033E7 RID: 13287 RVA: 0x001CCC7C File Offset: 0x001CBC7C
		private de a(ref float A_0, ref float A_1)
		{
			int a_ = this.e();
			this.f(this.f());
			float? num = this.b(a_);
			A_1 = ((num != null) ? num.GetValueOrDefault() : 0f);
			num = this.b(a_);
			A_0 = ((num != null) ? num.GetValueOrDefault() : 0f);
			bool flag = false;
			byte[] array = this.a(a_, ref flag);
			de de;
			if (array != null)
			{
				de = new de();
				de.a(array);
				if (flag)
				{
					de.b(false);
				}
				else
				{
					de.b(true);
				}
			}
			else
			{
				de = null;
			}
			this.f(a_);
			return de;
		}

		// Token: 0x060033E8 RID: 13288 RVA: 0x001CCD44 File Offset: 0x001CBD44
		private float a(float A_0, float[,] A_1)
		{
			if (A_0 == 0f)
			{
				A_0 = ((A_1[1, 1] == 0f) ? 12f : A_1[1, 1]);
			}
			else if (A_1[1, 1] > 1f)
			{
				A_0 = A_1[1, 1];
			}
			else
			{
				A_0 *= A_1[1, 1];
			}
			return A_0;
		}

		// Token: 0x060033E9 RID: 13289 RVA: 0x001CCDC0 File Offset: 0x001CBDC0
		private void a(df A_0, float A_1, float A_2, string A_3, float A_4, float A_5, float A_6, float? A_7, bool A_8, string A_9)
		{
			int num = this.e();
			this.f(this.f());
			this.c();
			float num2 = 0f;
			bool flag = false;
			bool flag2 = true;
			byte[] array = this.a;
			int num3;
			this.f((num3 = this.e()) + 1);
			if (array[num3] == 91)
			{
				while (this.e() < num && this.a[this.e()] != 93)
				{
					byte[] array2 = this.a(num, ref flag);
					if (array2 != null)
					{
						float num4 = num2;
						float? num5 = this.b(num);
						num2 = num4 + ((num5 != null) ? num5.GetValueOrDefault() : 0f);
						de de = new de();
						de.a(array2);
						de.c(num2);
						if (flag)
						{
							de.b(false);
						}
						else
						{
							de.b(true);
						}
						if (flag2)
						{
							flag2 = false;
						}
						else
						{
							de.a(true);
						}
						ahb.a(de, A_1, A_2, A_3, A_4, A_5, A_6, A_7, A_8, A_9);
						A_0.a().Add(de);
						num2 = 0f;
						flag = false;
					}
					else
					{
						this.f(this.e() + 1);
					}
				}
			}
			this.f(num);
		}

		// Token: 0x060033EA RID: 13290 RVA: 0x001CCF34 File Offset: 0x001CBF34
		private static byte[] a(byte[] A_0)
		{
			if (A_0.Length % 2 != 0)
			{
				Array.Resize<byte>(ref A_0, A_0.Length + 1);
				A_0[A_0.Length - 1] = 0;
			}
			byte[] array = new byte[A_0.Length / 2];
			int num = 0;
			for (int i = 0; i < A_0.Length; i += 2)
			{
				array[num] = (byte)((int)ahb.a(A_0[i]) << 4 | (int)ahb.a(A_0[i + 1]));
				num++;
			}
			return array;
		}

		// Token: 0x060033EB RID: 13291 RVA: 0x001CCFAC File Offset: 0x001CBFAC
		private static byte a(byte A_0)
		{
			byte result;
			if (A_0 >= 48 && A_0 <= 57)
			{
				result = A_0 - 48;
			}
			else
			{
				switch (A_0)
				{
				case 65:
					break;
				case 66:
					goto IL_68;
				case 67:
					goto IL_6D;
				case 68:
					goto IL_72;
				case 69:
					goto IL_77;
				case 70:
					goto IL_7C;
				default:
					switch (A_0)
					{
					case 97:
						break;
					case 98:
						goto IL_68;
					case 99:
						goto IL_6D;
					case 100:
						goto IL_72;
					case 101:
						goto IL_77;
					case 102:
						goto IL_7C;
					default:
						return 0;
					}
					break;
				}
				return 10;
				IL_68:
				return 11;
				IL_6D:
				return 12;
				IL_72:
				return 13;
				IL_77:
				return 14;
				IL_7C:
				result = 15;
			}
			return result;
		}

		// Token: 0x060033EC RID: 13292 RVA: 0x001CD040 File Offset: 0x001CC040
		private de b()
		{
			int a_ = this.e();
			this.f(this.f());
			bool flag = false;
			byte[] array = this.a(a_, ref flag);
			de de;
			if (array != null)
			{
				de = new de();
				de.a(array);
				if (flag)
				{
					de.b(false);
				}
				else
				{
					de.b(true);
				}
			}
			else
			{
				de = null;
			}
			this.f(a_);
			return de;
		}

		// Token: 0x060033ED RID: 13293 RVA: 0x001CD0C0 File Offset: 0x001CC0C0
		private byte[] a(int A_0, ref bool A_1)
		{
			this.c();
			byte[] result;
			if (this.a[this.e()] == 40)
			{
				this.f(this.e() + 1);
				result = this.c(A_0);
			}
			else if (this.a[this.e()] == 60)
			{
				this.f(this.e() + 1);
				A_1 = true;
				result = this.d(A_0);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060033EE RID: 13294 RVA: 0x001CD144 File Offset: 0x001CC144
		private byte[] d(int A_0)
		{
			byte[] array = new byte[A_0 - this.e()];
			int num = 0;
			while (this.e() < A_0)
			{
				if (this.a[this.e()] == 62)
				{
					this.f(this.e() + 1);
					break;
				}
				if (this.a[this.e()] != 10)
				{
					array[num] = this.a[this.e()];
					num++;
				}
				this.f(this.e() + 1);
			}
			Array.Resize<byte>(ref array, num);
			return array;
		}

		// Token: 0x060033EF RID: 13295 RVA: 0x001CD1E8 File Offset: 0x001CC1E8
		private byte[] c(int A_0)
		{
			byte[] array = new byte[A_0 - this.e()];
			int num = 0;
			while (this.e() < A_0)
			{
				if (this.a[this.e()] == 41 && !this.d())
				{
					this.f(this.e() + 1);
					break;
				}
				array[num] = this.a[this.e()];
				num++;
				this.f(this.e() + 1);
			}
			Array.Resize<byte>(ref array, num);
			return array;
		}

		// Token: 0x060033F0 RID: 13296 RVA: 0x001CD27C File Offset: 0x001CC27C
		internal string h()
		{
			int a_ = this.e();
			this.f(this.f());
			string result = this.a(a_);
			this.f(a_);
			return result;
		}

		// Token: 0x060033F1 RID: 13297 RVA: 0x001CD2B4 File Offset: 0x001CC2B4
		internal string a(ref float A_0)
		{
			int a_ = this.e();
			this.f(this.f());
			string result = this.a(a_);
			float? num = this.b(a_);
			A_0 = ((num != null) ? num.GetValueOrDefault() : 0f);
			this.f(a_);
			return result;
		}

		// Token: 0x060033F2 RID: 13298 RVA: 0x001CD310 File Offset: 0x001CC310
		internal float? i()
		{
			int a_ = this.e();
			this.f(this.f());
			float? result = this.b(a_);
			this.f(a_);
			return result;
		}

		// Token: 0x060033F3 RID: 13299 RVA: 0x001CD348 File Offset: 0x001CC348
		private float[] a()
		{
			int a_ = this.e();
			this.f(this.f());
			float[] array = new float[2];
			float[] array2 = array;
			int num = 0;
			float? num2 = this.b(a_);
			array2[num] = ((num2 != null) ? num2.GetValueOrDefault() : 0f);
			float[] array3 = array;
			int num3 = 1;
			num2 = this.b(a_);
			array3[num3] = ((num2 != null) ? num2.GetValueOrDefault() : 0f);
			this.f(a_);
			return array;
		}

		// Token: 0x060033F4 RID: 13300 RVA: 0x001CD3C8 File Offset: 0x001CC3C8
		internal float[] j()
		{
			int a_ = this.e();
			this.f(this.f());
			float[] array = new float[6];
			float[] array2 = array;
			int num = 0;
			float? num2 = this.b(a_);
			array2[num] = ((num2 != null) ? num2.GetValueOrDefault() : 0f);
			float[] array3 = array;
			int num3 = 1;
			num2 = this.b(a_);
			array3[num3] = ((num2 != null) ? num2.GetValueOrDefault() : 0f);
			float[] array4 = array;
			int num4 = 2;
			num2 = this.b(a_);
			array4[num4] = ((num2 != null) ? num2.GetValueOrDefault() : 0f);
			float[] array5 = array;
			int num5 = 3;
			num2 = this.b(a_);
			array5[num5] = ((num2 != null) ? num2.GetValueOrDefault() : 0f);
			float[] array6 = array;
			int num6 = 4;
			num2 = this.b(a_);
			array6[num6] = ((num2 != null) ? num2.GetValueOrDefault() : 0f);
			float[] array7 = array;
			int num7 = 5;
			num2 = this.b(a_);
			array7[num7] = ((num2 != null) ? num2.GetValueOrDefault() : 0f);
			this.f(a_);
			return array;
		}

		// Token: 0x060033F5 RID: 13301 RVA: 0x001CD4DC File Offset: 0x001CC4DC
		private float? b(int A_0)
		{
			string text = "";
			this.c();
			while (this.e() <= A_0)
			{
				if (!this.b(this.a[this.e()]))
				{
					break;
				}
				text += (char)this.a[this.e()];
				this.f(this.e() + 1);
			}
			float? result;
			if (text == "")
			{
				result = null;
			}
			else
			{
				float value;
				if (!float.TryParse(text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out value))
				{
					text = text.TrimStart(new char[0]);
					if (text[0] == '-' & text[1] == '-')
					{
						text = text.Substring(1);
					}
					float.TryParse(text, out value);
				}
				result = new float?(value);
			}
			return result;
		}

		// Token: 0x060033F6 RID: 13302 RVA: 0x001CD5DC File Offset: 0x001CC5DC
		private string a(int A_0)
		{
			string text = "";
			this.c();
			if (this.a[this.e()] == 47)
			{
				this.f(this.e() + 1);
				while (this.e() <= A_0)
				{
					if (ahb.c(this.a[this.e()]))
					{
						break;
					}
					text += (char)this.a[this.e()];
					this.f(this.e() + 1);
				}
			}
			return text;
		}

		// Token: 0x060033F7 RID: 13303 RVA: 0x001CD680 File Offset: 0x001CC680
		internal static float[,] b(float[] A_0, float[,] A_1)
		{
			float[,] array = new float[3, 3];
			array[0, 0] = A_0[0];
			array[0, 1] = A_0[1];
			array[0, 2] = 0f;
			array[1, 0] = A_0[2];
			array[1, 1] = A_0[3];
			array[1, 2] = 0f;
			array[2, 0] = A_0[4];
			array[2, 1] = A_0[5];
			array[2, 2] = 1f;
			return ahb.a(A_1, array);
		}

		// Token: 0x060033F8 RID: 13304 RVA: 0x001CD70C File Offset: 0x001CC70C
		private static float[,] a(float[] A_0, float[,] A_1)
		{
			float[,] array = new float[3, 3];
			array[0, 0] = 1f;
			array[0, 1] = 0f;
			array[0, 2] = 0f;
			array[1, 0] = 0f;
			array[1, 1] = 1f;
			array[1, 2] = 0f;
			array[2, 0] = A_0[0];
			array[2, 1] = A_0[1];
			array[2, 2] = 1f;
			return ahb.a(A_1, array);
		}

		// Token: 0x060033F9 RID: 13305 RVA: 0x001CD7A0 File Offset: 0x001CC7A0
		private static float[,] a(float[,] A_0, float[,] A_1)
		{
			float[,] array = new float[3, 3];
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					float num = 0f;
					for (int k = 0; k < 3; k++)
					{
						num += A_1[i, k] * A_0[k, j];
					}
					array[i, j] = num;
				}
			}
			return array;
		}

		// Token: 0x060033FA RID: 13306 RVA: 0x001CD828 File Offset: 0x001CC828
		public static void a(de A_0, float A_1, float A_2, string A_3, float A_4, float A_5, float A_6, float? A_7, bool A_8, string A_9)
		{
			A_0.e(A_1);
			A_0.d(A_2);
			A_0.a(A_3);
			A_0.b(A_4);
			A_0.a(A_5);
			A_0.a(new float?(A_6));
			A_0.b(A_7);
			A_0.c(A_8);
			A_0.b(A_9);
		}

		// Token: 0x060033FB RID: 13307 RVA: 0x001CD88C File Offset: 0x001CC88C
		internal void k()
		{
			while (this.a.Length > this.e() + 3 && (this.a[this.e()] > 32 || this.a[this.e() + 1] != 69 || this.a[this.e() + 2] != 73))
			{
				this.f(this.e() + 1);
			}
		}

		// Token: 0x040018CB RID: 6347
		private byte[] a;

		// Token: 0x040018CC RID: 6348
		private int b = 0;

		// Token: 0x040018CD RID: 6349
		[CompilerGenerated]
		private int c;

		// Token: 0x040018CE RID: 6350
		[CompilerGenerated]
		private int d;
	}
}
