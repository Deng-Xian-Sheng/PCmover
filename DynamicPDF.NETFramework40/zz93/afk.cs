using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004B7 RID: 1207
	internal class afk : afj
	{
		// Token: 0x060031A4 RID: 12708 RVA: 0x001BC2C8 File Offset: 0x001BB2C8
		internal afk(agp A_0, abi A_1, abk A_2) : base(A_1, A_2)
		{
			this.a = A_0;
		}

		// Token: 0x060031A5 RID: 12709 RVA: 0x001BC2EA File Offset: 0x001BB2EA
		internal void a(int A_0, int A_1)
		{
			this.b = A_0;
			this.c = (short)A_1;
		}

		// Token: 0x060031A6 RID: 12710 RVA: 0x001BC2FC File Offset: 0x001BB2FC
		internal override byte[] j3()
		{
			agx agx = this.a.a(this.b, (int)this.c);
			byte[] array = agx.j(base.g());
			this.a.a(agx);
			if (base.k().h2())
			{
				bool flag = false;
				if (base.k().b().g() != null && !base.k().b().g().at())
				{
					if (base.m() != ag1.e || base.k().b().g().@as())
					{
						flag = true;
					}
				}
				else if (base.o() != null && base.o() == base.k().b().g().c())
				{
					flag = true;
				}
				if (flag)
				{
					int num = base.k().h1(array, 0, array.Length);
					if (num != 0)
					{
						base.e(num);
						Array.Resize<byte>(ref array, num);
					}
				}
			}
			return array;
		}

		// Token: 0x060031A7 RID: 12711 RVA: 0x001BC43C File Offset: 0x001BB43C
		internal override byte[] j4()
		{
			return this.a(0);
		}

		// Token: 0x060031A8 RID: 12712 RVA: 0x001BC458 File Offset: 0x001BB458
		internal override byte[] j5()
		{
			return this.a(1);
		}

		// Token: 0x060031A9 RID: 12713 RVA: 0x001BC474 File Offset: 0x001BB474
		private byte[] a(int A_0)
		{
			byte[] result;
			if (base.g() == 0)
			{
				result = new byte[A_0];
			}
			else
			{
				byte[] array;
				if (base.k().h2())
				{
					byte[] a_ = this.j3();
					array = this.c(a_, A_0);
				}
				else
				{
					agx agx = this.a.a(this.b, (int)this.c);
					array = agx.a(base.b(), base.d(), base.c(), base.g(), A_0);
					this.a.a(agx);
				}
				result = array;
			}
			return result;
		}

		// Token: 0x060031AA RID: 12714 RVA: 0x001BC514 File Offset: 0x001BB514
		private byte[] c(byte[] A_0, int A_1)
		{
			byte[] result;
			if (base.g() == 0)
			{
				result = new byte[A_1];
			}
			else
			{
				byte[] array = null;
				if (base.c())
				{
					array = this.b(A_0, 0);
					if (!base.b() && !base.d())
					{
						return array;
					}
				}
				if (base.b())
				{
					byte[] array2 = new byte[base.g() * 4];
					aa4 aa = new aa4();
					if (base.c())
					{
						aa.a(array, 0, array.Length);
					}
					else
					{
						aa.a(A_0, 0, A_0.Length);
					}
					int i = aa.a(array2);
					if (i == array2.Length)
					{
						ArrayList arrayList = new ArrayList(4);
						while (i >= array2.Length)
						{
							arrayList.Add(array2);
							array2 = new byte[array2.Length];
							i = aa.a(array2);
						}
						array = new byte[array2.Length * arrayList.Count + i + A_1];
						int num = 0;
						foreach (object obj in arrayList)
						{
							byte[] sourceArray = (byte[])obj;
							Array.Copy(sourceArray, 0, array, num++ * array2.Length, array2.Length);
						}
						Array.Copy(array2, 0, array, num * array2.Length, i);
					}
					else
					{
						array = new byte[i + A_1];
						Array.Copy(array2, array, i);
					}
				}
				if (base.d())
				{
					zd zd = new zd(A_0, 0, base.g() * 4);
					array = new byte[zd.e() + A_1];
					Array.Copy(zd.d(), array, zd.e());
				}
				else if (!base.b() && !base.c())
				{
					array = new byte[base.g() + A_1];
					Array.Copy(A_0, 0, array, 0, base.g());
				}
				result = array;
			}
			return result;
		}

		// Token: 0x060031AB RID: 12715 RVA: 0x001BC75C File Offset: 0x001BB75C
		internal void a(agx A_0, DocumentWriter A_1)
		{
			A_0.c(this.b, (int)this.c);
			if (base.k().h2())
			{
				byte[] array = this.j3();
				if (base.m() != ag1.e)
				{
					A_1.WriteStream(array, 0, array.Length);
				}
				else if (A_1.Document.Security == null || A_1.Document.Security.c())
				{
					A_1.WriteStream(array, 0, array.Length);
				}
				else
				{
					A_1.af(array, array.Length);
				}
			}
			else if (base.m() != ag1.e)
			{
				A_0.d(A_1, base.g());
			}
			else if (A_1.Document.Security == null || A_1.Document.Security.c())
			{
				A_0.d(A_1, base.g());
			}
			else
			{
				A_0.e(A_1, base.g());
			}
		}

		// Token: 0x060031AC RID: 12716 RVA: 0x001BC874 File Offset: 0x001BB874
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				agx a_ = A_0.a(this.a);
				A_0.WriteDictionaryOpen();
				base.b(a_, A_0);
				A_0.WriteName(afj.d);
				A_0.ai(base.g());
				A_0.WriteDictionaryClose();
				this.a(a_, A_0);
			}
		}

		// Token: 0x060031AD RID: 12717 RVA: 0x001BC8D7 File Offset: 0x001BB8D7
		internal override void h9(agx A_0, DocumentWriter A_1)
		{
			throw new GeneratorException("This method cannot be used on a dictionary stream.");
		}

		// Token: 0x060031AE RID: 12718 RVA: 0x001BC8E4 File Offset: 0x001BB8E4
		internal override void j6(DocumentWriter A_0)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060031AF RID: 12719 RVA: 0x001BC8EC File Offset: 0x001BB8EC
		private byte[] b(byte[] A_0, int A_1)
		{
			byte[] array = new byte[(int)((float)A_0.Length * 0.8f + 4f)];
			int num = this.a(A_0, A_1);
			int num2 = 0;
			while (A_0[num] != 126)
			{
				if (A_0[num] == 122)
				{
					this.b(A_0, array, ref num, ref num2);
				}
				else if (!this.a(A_0, array, ref num, ref num2))
				{
					break;
				}
			}
			byte[] array2 = new byte[num2];
			Array.Copy(array, array2, num2);
			return array2;
		}

		// Token: 0x060031B0 RID: 12720 RVA: 0x001BC97C File Offset: 0x001BB97C
		private int a(byte[] A_0, int A_1)
		{
			while (A_0[A_1] <= 32)
			{
				A_1++;
			}
			return A_1;
		}

		// Token: 0x060031B1 RID: 12721 RVA: 0x001BC9A4 File Offset: 0x001BB9A4
		private void b(byte[] A_0, byte[] A_1, ref int A_2, ref int A_3)
		{
			A_1[A_3++] = 0;
			A_1[A_3++] = 0;
			A_1[A_3++] = 0;
			A_1[A_3++] = 0;
			A_2++;
			A_2 = this.a(A_0, A_2);
		}

		// Token: 0x060031B2 RID: 12722 RVA: 0x001BC9F8 File Offset: 0x001BB9F8
		private bool a(byte[] A_0, byte[] A_1, ref int A_2, ref int A_3)
		{
			int num = 1;
			uint num2 = (uint)(A_0[A_2++] - 33) * 52200625U;
			A_2 = this.a(A_0, A_2);
			num2 += (uint)(A_0[A_2++] - 33) * 614125U;
			A_2 = this.a(A_0, A_2);
			bool result;
			if (A_0[A_2] == 126)
			{
				this.a(A_1, ref A_3, num2, num);
				A_2 = this.a(A_0, A_2);
				result = false;
			}
			else
			{
				num++;
				num2 += (uint)(A_0[A_2++] - 33) * 7225U;
				A_2 = this.a(A_0, A_2);
				if (A_0[A_2] == 126)
				{
					this.a(A_1, ref A_3, num2, num);
					A_2 = this.a(A_0, A_2);
					result = false;
				}
				else
				{
					num++;
					num2 += (uint)((A_0[A_2++] - 33) * 85);
					A_2 = this.a(A_0, A_2);
					if (A_0[A_2] == 126)
					{
						this.a(A_1, ref A_3, num2, num);
						A_2 = this.a(A_0, A_2);
						result = false;
					}
					else
					{
						num++;
						num2 += (uint)(A_0[A_2++] - 33);
						this.a(A_1, ref A_3, num2, num);
						A_2 = this.a(A_0, A_2);
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x060031B3 RID: 12723 RVA: 0x001BCB54 File Offset: 0x001BBB54
		private void a(byte[] A_0, ref int A_1, uint A_2, int A_3)
		{
			if (A_3 == 1)
			{
				A_2 += 614125U;
			}
			if (A_3 == 2)
			{
				A_2 += 7225U;
			}
			if (A_3 == 3)
			{
				A_2 += 85U;
			}
			A_0[A_1++] = (byte)((A_2 & 4278190080U) >> 24);
			if (A_3 != 1)
			{
				A_0[A_1++] = (byte)((A_2 & 16711680U) >> 16);
				if (A_3 != 2)
				{
					A_0[A_1++] = (byte)((A_2 & 65280U) >> 8);
					if (A_3 != 3)
					{
						A_0[A_1++] = (byte)(A_2 & 255U);
					}
				}
			}
		}

		// Token: 0x04001733 RID: 5939
		private new agp a;

		// Token: 0x04001734 RID: 5940
		private new int b = 0;

		// Token: 0x04001735 RID: 5941
		private short c = 0;
	}
}
