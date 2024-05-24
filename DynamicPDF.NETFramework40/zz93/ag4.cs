using System;
using System.Collections;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004EF RID: 1263
	internal class ag4 : afj
	{
		// Token: 0x060033A7 RID: 13223 RVA: 0x001CA84B File Offset: 0x001C984B
		internal ag4(agt A_0, abi A_1, abk A_2) : base(A_1, A_2)
		{
			this.a = A_0;
		}

		// Token: 0x060033A8 RID: 13224 RVA: 0x001CA866 File Offset: 0x001C9866
		internal new void d(int A_0)
		{
			this.b = A_0;
		}

		// Token: 0x060033A9 RID: 13225 RVA: 0x001CA870 File Offset: 0x001C9870
		private byte[] c(int A_0)
		{
			byte[] array = new byte[(int)((float)base.g() * 0.8f + 4f)];
			int num = this.b(A_0);
			int num2 = 0;
			while (this.a.a()[num] != 126)
			{
				if (this.a.a()[num] == 122)
				{
					this.b(array, ref num, ref num2);
				}
				else if (!this.a(array, ref num, ref num2))
				{
					break;
				}
			}
			byte[] array2 = new byte[num2];
			Array.Copy(array, array2, num2);
			return array2;
		}

		// Token: 0x060033AA RID: 13226 RVA: 0x001CA914 File Offset: 0x001C9914
		private int b(int A_0)
		{
			while (this.a.a()[A_0] <= 32)
			{
				A_0++;
			}
			return A_0;
		}

		// Token: 0x060033AB RID: 13227 RVA: 0x001CA948 File Offset: 0x001C9948
		private void b(byte[] A_0, ref int A_1, ref int A_2)
		{
			A_0[A_2++] = 0;
			A_0[A_2++] = 0;
			A_0[A_2++] = 0;
			A_0[A_2++] = 0;
			A_1++;
			A_1 = this.b(A_1);
		}

		// Token: 0x060033AC RID: 13228 RVA: 0x001CA998 File Offset: 0x001C9998
		private bool a(byte[] A_0, ref int A_1, ref int A_2)
		{
			int num = 1;
			uint num2 = (uint)(this.a.a()[A_1++] - 33) * 52200625U;
			A_1 = this.b(A_1);
			num2 += (uint)(this.a.a()[A_1++] - 33) * 614125U;
			A_1 = this.b(A_1);
			bool result;
			if (this.a.a()[A_1] == 126)
			{
				this.a(A_0, ref A_2, num2, num);
				A_1 = this.b(A_1);
				result = false;
			}
			else
			{
				num++;
				num2 += (uint)(this.a.a()[A_1++] - 33) * 7225U;
				A_1 = this.b(A_1);
				if (this.a.a()[A_1] == 126)
				{
					this.a(A_0, ref A_2, num2, num);
					A_1 = this.b(A_1);
					result = false;
				}
				else
				{
					num++;
					num2 += (uint)((this.a.a()[A_1++] - 33) * 85);
					A_1 = this.b(A_1);
					if (this.a.a()[A_1] == 126)
					{
						this.a(A_0, ref A_2, num2, num);
						A_1 = this.b(A_1);
						result = false;
					}
					else
					{
						num++;
						num2 += (uint)(this.a.a()[A_1++] - 33);
						this.a(A_0, ref A_2, num2, num);
						A_1 = this.b(A_1);
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x060033AD RID: 13229 RVA: 0x001CAB38 File Offset: 0x001C9B38
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

		// Token: 0x060033AE RID: 13230 RVA: 0x001CAC00 File Offset: 0x001C9C00
		internal override byte[] j3()
		{
			byte[] array = new byte[base.g()];
			Array.Copy(this.a.a(), this.b, array, 0, base.g());
			return array;
		}

		// Token: 0x060033AF RID: 13231 RVA: 0x001CAC40 File Offset: 0x001C9C40
		internal override byte[] j4()
		{
			return this.a(0);
		}

		// Token: 0x060033B0 RID: 13232 RVA: 0x001CAC5C File Offset: 0x001C9C5C
		internal override byte[] j5()
		{
			return this.a(1);
		}

		// Token: 0x060033B1 RID: 13233 RVA: 0x001CAC78 File Offset: 0x001C9C78
		private byte[] a(int A_0)
		{
			byte[] result;
			if (base.g() == 0)
			{
				result = new byte[A_0];
			}
			else
			{
				byte[] array = null;
				if (base.c())
				{
					array = this.c(this.b);
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
						aa.a(this.a.a(), this.b, base.g());
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
						array = new byte[array2.Length * arrayList.Count + i + A_0];
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
						array = new byte[i + A_0];
						Array.Copy(array2, array, i);
					}
				}
				if (base.d())
				{
					zd zd = new zd(this.a.a(), this.b, base.g() * 4);
					array = new byte[zd.e() + A_0];
					Array.Copy(zd.d(), array, zd.e());
				}
				else if (!base.b() && !base.c())
				{
					array = new byte[base.g() + A_0];
					Array.Copy(this.a.a(), this.b, array, 0, base.g());
				}
				result = array;
			}
			return result;
		}

		// Token: 0x060033B2 RID: 13234 RVA: 0x001CAEF4 File Offset: 0x001C9EF4
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				A_0.WriteDictionaryOpen();
				base.b(A_0);
				A_0.WriteName(afj.d);
				A_0.ai(base.g());
				A_0.WriteDictionaryClose();
				this.a(A_0);
			}
		}

		// Token: 0x060033B3 RID: 13235 RVA: 0x001CAF48 File Offset: 0x001C9F48
		internal void a(DocumentWriter A_0)
		{
			if (base.m() != ag1.e)
			{
				A_0.WriteStream(this.a.a(), this.b, base.g());
			}
			else if (A_0.Document.Security == null || A_0.Document.Security.c())
			{
				A_0.WriteStream(this.a.a(), this.b, base.g());
			}
			else
			{
				A_0.ag(this.a.a(), this.b, base.g());
			}
		}

		// Token: 0x060033B4 RID: 13236 RVA: 0x001CAFF8 File Offset: 0x001C9FF8
		internal override void j6(DocumentWriter A_0)
		{
			A_0.WriteName(afj.d);
			A_0.WriteNumber(base.g() + 16 + (16 - base.g() % 16));
			A_0.WriteDictionaryClose();
			A_0.ae(this.a.a(), this.b, base.g());
		}

		// Token: 0x040018A1 RID: 6305
		private new agt a;

		// Token: 0x040018A2 RID: 6306
		private new int b = 0;
	}
}
