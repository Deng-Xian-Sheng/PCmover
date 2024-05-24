using System;
using System.Text;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020004F0 RID: 1264
	internal class ag5 : ab7
	{
		// Token: 0x060033B5 RID: 13237 RVA: 0x001CB054 File Offset: 0x001CA054
		internal ag5(agt A_0, abi A_1, int A_2, int A_3, bool A_4)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.d = A_3;
		}

		// Token: 0x060033B6 RID: 13238 RVA: 0x001CB07C File Offset: 0x001CA07C
		internal override string kf()
		{
			string result;
			if (this.g)
			{
				result = this.e;
			}
			else
			{
				this.f = this.kg();
				if (this.f.Length > 1 && this.f[0] == 254 && this.f[1] == 255)
				{
					this.e = Encoding.BigEndianUnicode.GetString(this.f, 2, this.f.Length - 2);
				}
				else
				{
					this.e = ab2.a(this.f);
				}
				this.g = true;
				result = this.e;
			}
			return result;
		}

		// Token: 0x060033B7 RID: 13239 RVA: 0x001CB12C File Offset: 0x001CA12C
		internal override byte[] kg()
		{
			byte[] result;
			if (this.f != null)
			{
				result = this.f;
			}
			else
			{
				if (this.a.b(this.c) == 40)
				{
					this.f = this.b(this.c + 1, this.d - 2);
				}
				else
				{
					this.f = this.a(this.c + 1, this.d / 2 - 1);
				}
				if (this.b.h2())
				{
					if (this.b.b().g() != null && !this.b.b().g().at())
					{
						int num = this.b.h1(this.f, 0, this.f.Length);
						if (num != 0)
						{
							Array.Resize<byte>(ref this.f, num);
						}
					}
				}
				result = this.f;
			}
			return result;
		}

		// Token: 0x060033B8 RID: 13240 RVA: 0x001CB230 File Offset: 0x001CA230
		internal override byte[] kh()
		{
			byte[] result;
			if (this.f != null)
			{
				result = this.f;
			}
			else
			{
				if (this.a.b(this.c) == 40)
				{
					this.f = this.b(this.c + 1, this.d - 2);
				}
				else
				{
					this.f = this.a(this.c + 1, this.d / 2 - 1);
				}
				result = this.f;
			}
			return result;
		}

		// Token: 0x060033B9 RID: 13241 RVA: 0x001CB2BC File Offset: 0x001CA2BC
		internal override void hz(DocumentWriter A_0)
		{
			if (base.p())
			{
				if (this.b.h2() || A_0.Document.Security != null)
				{
					A_0.WriteText(this.kg());
				}
				else
				{
					A_0.WriteTextRawWithoutEncryption(this.a.a(), this.c, this.d);
				}
			}
		}

		// Token: 0x060033BA RID: 13242 RVA: 0x001CB330 File Offset: 0x001CA330
		private byte[] b(int A_0, int A_1)
		{
			byte[] array = new byte[A_1];
			int num = 0;
			int i = 1;
			bool flag = false;
			while (i > 0)
			{
				byte b;
				if (flag)
				{
					b = this.a.b(A_0);
					if (b <= 98)
					{
						if (b != 13)
						{
							if (b != 98)
							{
								goto IL_D6;
							}
							array[num++] = 8;
							A_0++;
						}
						else
						{
							A_0++;
						}
					}
					else if (b != 102)
					{
						if (b != 110)
						{
							switch (b)
							{
							case 114:
								array[num++] = 13;
								A_0++;
								break;
							case 115:
								goto IL_D6;
							case 116:
								array[num++] = 9;
								A_0++;
								break;
							default:
								goto IL_D6;
							}
						}
						else
						{
							array[num++] = 10;
							A_0++;
						}
					}
					else
					{
						array[num++] = 12;
						A_0++;
					}
					IL_1D9:
					flag = false;
					continue;
					IL_D6:
					if (this.a.b(A_0) >= 48 && this.a.b(A_0) <= 57)
					{
						int num2 = (int)(this.a.b(A_0++) - 48);
						if (this.a.b(A_0) >= 48 && this.a.b(A_0) <= 57)
						{
							num2 *= 8;
							num2 += (int)(this.a.b(A_0++) - 48);
							if (this.a.b(A_0) >= 48 && this.a.b(A_0) <= 57)
							{
								num2 *= 8;
								num2 += (int)(this.a.b(A_0++) - 48);
							}
						}
						array[num++] = (byte)num2;
					}
					else
					{
						array[num++] = this.a.b(A_0++);
					}
					goto IL_1D9;
				}
				b = this.a.b(A_0);
				switch (b)
				{
				case 40:
					i++;
					goto IL_21C;
				case 41:
					i--;
					goto IL_21C;
				default:
					if (b != 92)
					{
						goto IL_21C;
					}
					flag = true;
					A_0++;
					break;
				}
				continue;
				IL_21C:
				if (i > 0)
				{
					array[num++] = this.a.b(A_0++);
				}
			}
			byte[] array2 = new byte[num];
			Array.Copy(array, 0, array2, 0, num);
			return array2;
		}

		// Token: 0x060033BB RID: 13243 RVA: 0x001CB5AC File Offset: 0x001CA5AC
		private byte[] a(int A_0, int A_1)
		{
			byte[] array = new byte[A_1];
			int num = 0;
			while (this.a.b(A_0) != 62)
			{
				A_0 = this.a.c(A_0);
				byte a_ = this.a.b(A_0++);
				A_0 = this.a.c(A_0);
				if (this.a.b(A_0) == 62)
				{
					array[num++] = this.a(a_, 0);
					break;
				}
				array[num++] = this.a(a_, this.a.b(A_0++));
				A_0 = this.a.c(A_0);
			}
			byte[] array2 = new byte[num];
			Array.Copy(array, 0, array2, 0, num);
			return array2;
		}

		// Token: 0x060033BC RID: 13244 RVA: 0x001CB68C File Offset: 0x001CA68C
		private byte a(byte A_0, byte A_1)
		{
			return (byte)(this.a(A_0) << 4 | this.a(A_1));
		}

		// Token: 0x060033BD RID: 13245 RVA: 0x001CB6B0 File Offset: 0x001CA6B0
		private int a(byte A_0)
		{
			int result;
			if (A_0 <= 57)
			{
				result = (int)(A_0 - 48);
			}
			else if (A_0 <= 70)
			{
				result = (int)(A_0 - 55);
			}
			else
			{
				result = (int)(A_0 - 87);
			}
			return result;
		}

		// Token: 0x040018A3 RID: 6307
		private agt a;

		// Token: 0x040018A4 RID: 6308
		private abi b;

		// Token: 0x040018A5 RID: 6309
		private int c;

		// Token: 0x040018A6 RID: 6310
		private int d;

		// Token: 0x040018A7 RID: 6311
		private string e;

		// Token: 0x040018A8 RID: 6312
		private byte[] f;

		// Token: 0x040018A9 RID: 6313
		private bool g;
	}
}
