using System;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003AA RID: 938
	internal class yk : yh
	{
		// Token: 0x060027DB RID: 10203 RVA: 0x0016CB20 File Offset: 0x0016BB20
		internal yk(TiffImageData A_0, yj A_1) : base(A_1, A_0.Width, A_0.Height)
		{
			this.a = A_0;
		}

		// Token: 0x060027DC RID: 10204 RVA: 0x0016CB5C File Offset: 0x0016BB5C
		private new byte[] a(int A_0, bool A_1, yj A_2, uint[] A_3, uint[] A_4)
		{
			byte[] array = new byte[A_3[A_0]];
			A_2.a(A_4[A_0], array, 0, (int)A_3[A_0]);
			if (A_1)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = yg.y[(int)array[i]];
				}
			}
			return array;
		}

		// Token: 0x060027DD RID: 10205 RVA: 0x0016CBB8 File Offset: 0x0016BBB8
		protected override byte[] gz(yj A_0, uint[] A_1, uint[] A_2, bool A_3)
		{
			uint num = 0U;
			byte[] array = null;
			if (A_0.b(292U))
			{
				num = A_0.i();
			}
			if ((num & 1U) == 1U)
			{
				this.d = true;
			}
			if ((num & 2U) == 2U)
			{
				throw new ImageParsingException("Group 3 uncompressed mode is unsupported.");
			}
			if ((num & 4U) == 4U)
			{
				this.b = true;
				this.c = true;
			}
			if (A_0.b(34675U))
			{
				array = A_0.m();
			}
			if (array != null)
			{
				this.f = new bn(array);
			}
			int num2 = 0;
			byte[] result;
			if (!this.b)
			{
				int num3 = 0;
				for (int i = 0; i < A_2.Length; i++)
				{
					num3 += (int)A_2[i];
				}
				byte[] array2;
				if (A_2.Length == 1)
				{
					array2 = new byte[num3 + 1717];
				}
				else
				{
					array2 = new byte[num3];
				}
				int num4 = 0;
				int a_ = 0;
				int num5 = base.d();
				int num6 = base.a();
				if (num == 1U)
				{
					byte[] array3 = new byte[num3];
					for (int j = 0; j < A_2.Length; j++)
					{
						byte[] array4 = new byte[A_2[j]];
						array4 = this.a(j, A_3, A_0, A_2, A_1);
						Array.Copy(array4, 0, array3, num2, array4.Length);
						num2 += (int)A_2[j];
					}
					result = array3;
				}
				else
				{
					for (int j = 0; j < A_2.Length; j++)
					{
						cf cf = new cf(this.a(j, A_3, A_0, A_2, A_1), base.c(), (num5 > num6) ? num6 : num5, array2, num4, a_);
						num4 = cf.i();
						a_ = cf.j();
						num5 -= num6;
					}
					byte[] array5 = new byte[num4 += 2];
					Array.Copy(array2, 0, array5, 0, num4);
					result = array5;
				}
			}
			else
			{
				uint num7 = 0U;
				foreach (uint num8 in A_2)
				{
					num7 += num8;
				}
				byte[] array3 = new byte[num7 + 2U];
				bool flag = false;
				for (int j = 0; j < A_1.Length; j++)
				{
					byte[] array4 = this.a(j, A_3, A_0, A_2, A_1);
					if (flag && array4[0] == 0 && (array4[1] & 240) == 16)
					{
						num2--;
					}
					Array.Copy(array4, 0, array3, num2, array4.Length);
					num2 += (int)A_2[j];
					flag = false;
					if (array3[num2 - 1] == 1 && (array3[num2 - 2] & 15) == 0)
					{
						flag = true;
					}
					else if (array3[num2 - 1] == 2 && (array3[num2 - 2] & 1) == 0 && (array3[num2 - 2] & 2) == 0 && (array3[num2 - 2] & 4) == 0 && (array3[num2 - 2] & 8) == 0 && (array3[num2 - 2] & 16) == 0)
					{
						flag = true;
					}
					else if (array3[num2 - 1] == 4 && (array3[num2 - 2] & 1) == 0 && (array3[num2 - 2] & 2) == 0 && (array3[num2 - 2] & 4) == 0 && (array3[num2 - 2] & 8) == 0 && (array3[num2 - 2] & 16) == 0 && (array3[num2 - 2] & 32) == 0)
					{
						flag = true;
					}
					else if (array3[num2 - 1] == 8 && (array3[num2 - 2] & 1) == 0 && (array3[num2 - 2] & 2) == 0 && (array3[num2 - 2] & 4) == 0 && (array3[num2 - 2] & 8) == 0 && (array3[num2 - 2] & 16) == 0 && (array3[num2 - 2] & 32) == 0 && (array3[num2 - 2] & 64) == 0)
					{
						flag = true;
					}
					else if (array3[num2 - 1] == 16 && array3[num2 - 2] == 0)
					{
						flag = true;
					}
					else if (array3[num2 - 1] == 32 && array3[num2 - 2] == 0 && (array3[num2 - 3] & 1) == 0)
					{
						flag = true;
					}
					else if (array3[num2 - 1] == 64 && array3[num2 - 2] == 0 && (array3[num2 - 3] & 1) == 0 && (array3[num2 - 3] & 2) == 0)
					{
						flag = true;
					}
					else if (array3[num2 - 1] == 128 && array3[num2 - 2] == 0 && (array3[num2 - 3] & 1) == 0 && (array3[num2 - 3] & 2) == 0 && (array3[num2 - 3] & 4) == 0)
					{
						flag = true;
					}
				}
				if (array3[(int)((UIntPtr)(num7 - 1U))] != 1 && (array3[(int)((UIntPtr)(num7 - 2U))] & 15) != 0)
				{
					array3[(int)((UIntPtr)num7)] = 0;
					array3[(int)((UIntPtr)(num7 + 1U))] = 1;
				}
				result = array3;
			}
			return result;
		}

		// Token: 0x060027DE RID: 10206 RVA: 0x0016D0AC File Offset: 0x0016C0AC
		internal override void gy(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(yg.g);
			A_0.WriteName(yg.k);
			A_0.WriteName(yg.h);
			A_0.WriteName(yg.l);
			if (this.a.Interpolate)
			{
				A_0.WriteName(yg.a);
				A_0.WriteBoolean(true);
			}
			A_0.WriteName(yg.b);
			A_0.WriteNumber(this.a.Width);
			A_0.WriteName(yg.c);
			A_0.WriteNumber(this.a.Height);
			A_0.WriteName(yg.d);
			A_0.WriteNumber1();
			A_0.WriteName(yg.e);
			if (this.f != null && this.f.b() == 1)
			{
				A_0.WriteArrayOpen();
				A_0.WriteName(yg.x);
				A_0.WriteReference(this.f.a());
				A_0.WriteArrayClose();
			}
			else
			{
				A_0.WriteName(yg.f);
			}
			A_0.WriteName(yg.i);
			A_0.WriteName(yg.q);
			A_0.WriteName(yg.p);
			A_0.WriteDictionaryOpen();
			A_0.WriteName(75);
			if (this.d)
			{
				A_0.WriteNumber1();
			}
			else
			{
				A_0.WriteNumber0();
			}
			A_0.WriteName(yg.o);
			A_0.WriteNumber(this.a.Width);
			if (base.b())
			{
				A_0.WriteName(yg.m);
				A_0.WriteBoolean(true);
			}
			if (this.b)
			{
				A_0.WriteName(yg.n);
				A_0.WriteBoolean(true);
			}
			if (this.c)
			{
				A_0.WriteName(yk.e);
				A_0.WriteBoolean(true);
			}
			A_0.WriteDictionaryClose();
			A_0.WriteName(yg.j);
			A_0.ai(this.gx().Length);
			A_0.WriteDictionaryClose();
			A_0.WriteStream(this.gx(), this.gx().Length);
			A_0.WriteEndObject();
		}

		// Token: 0x04001153 RID: 4435
		private new TiffImageData a;

		// Token: 0x04001154 RID: 4436
		private new bool b = false;

		// Token: 0x04001155 RID: 4437
		private new bool c = false;

		// Token: 0x04001156 RID: 4438
		private new bool d = false;

		// Token: 0x04001157 RID: 4439
		private new static byte[] e = new byte[]
		{
			69,
			110,
			100,
			79,
			102,
			76,
			105,
			110,
			101
		};

		// Token: 0x04001158 RID: 4440
		private new bn f = null;
	}
}
