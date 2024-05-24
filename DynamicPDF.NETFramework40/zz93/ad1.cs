using System;
using System.IO;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;
using ceTe.DynamicPDF.Text.OpenTypeFontTables;

namespace zz93
{
	// Token: 0x0200047E RID: 1150
	internal abstract class ad1
	{
		// Token: 0x06002F70 RID: 12144 RVA: 0x001AE0D0 File Offset: 0x001AD0D0
		internal ad1()
		{
		}

		// Token: 0x06002F71 RID: 12145 RVA: 0x001AE0EC File Offset: 0x001AD0EC
		internal static ad1 a(Stream A_0, bool A_1)
		{
			byte[] buffer = new byte[A_0.Length];
			A_0.Read(buffer, 0, (int)A_0.Length);
			A_0.Seek(4L, SeekOrigin.Begin);
			int num = A_0.ReadByte() << 8 | A_0.ReadByte();
			byte[] array = new byte[num * 16];
			A_0.Seek(12L, SeekOrigin.Begin);
			A_0.Read(array, 0, num * 16);
			int a_ = -1;
			int num2 = -1;
			int a_2 = -1;
			int a_3 = -1;
			int a_4 = -1;
			int num3 = -1;
			int num4 = -1;
			int num5 = -1;
			int num6 = -1;
			int num7 = -1;
			adp adp = null;
			adz adz = null;
			adi a_5 = null;
			ad5 a_6 = null;
			adm a_7 = null;
			ad0 ad = null;
			ad4 ad2 = null;
			sc sc = null;
			for (int i = 0; i < array.Length; i += 16)
			{
				int num8 = BitConverter.ToInt32(array, i);
				if (num8 <= 1701667182)
				{
					if (num8 <= 1414284112)
					{
						if (num8 <= 544503395)
						{
							if (num8 != 541476419)
							{
								if (num8 == 544503395)
								{
									a_5 = new adi(A_0, array, i);
								}
							}
							else
							{
								num5 = i;
							}
						}
						else if (num8 != 841962319)
						{
							if (num8 == 1414284112)
							{
								num2 = i;
							}
						}
						else
						{
							num6 = i;
						}
					}
					else if (num8 <= 1634035816)
					{
						if (num8 != 1633906540)
						{
							if (num8 == 1634035816)
							{
								a_ = i;
							}
						}
						else
						{
							a_4 = i;
						}
					}
					else if (num8 != 1684104552)
					{
						if (num8 == 1701667182)
						{
							ad = new ad0(A_0, array, i);
						}
					}
					else
					{
						adp = new adp(A_0, array, i);
					}
				}
				else if (num8 <= 1885433187)
				{
					if (num8 <= 1835495526)
					{
						if (num8 != 1719233639)
						{
							if (num8 == 1835495526)
							{
								a_7 = new adm(A_0, array, i);
							}
						}
						else
						{
							num3 = i;
						}
					}
					else if (num8 != 1852990827)
					{
						if (num8 == 1885433187)
						{
							a_3 = i;
						}
					}
					else
					{
						num4 = i;
					}
				}
				else if (num8 <= 1886937453)
				{
					if (num8 != 1885696624)
					{
						if (num8 == 1886937453)
						{
							adz = new adz(A_0, array, i);
						}
					}
					else
					{
						a_6 = new ad5(A_0, array, i);
					}
				}
				else if (num8 != 1953722224)
				{
					if (num8 == 2020896104)
					{
						a_2 = i;
					}
				}
				else
				{
					num7 = i;
				}
			}
			if (num6 != -1)
			{
				sc = new sc(A_0, array, num6, (int)adp.a());
			}
			if (num7 != -1)
			{
				ad2 = new ad4(A_0, array, num7, (int)adp.a());
			}
			ad1 ad3;
			if (num3 != -1)
			{
				ad3 = new ad9();
			}
			else
			{
				if (num5 == -1)
				{
					throw new Exception("Opentype font not recogonized");
				}
				ad3 = new ad3();
			}
			ad3.o = adp;
			ad3.q = adz;
			ad3.k = ad;
			ad3.l = ad2;
			ad3.s = sc;
			ad3.t = buffer;
			ad3.p = new adq(ad3.o.a(), A_0, array, a_);
			if (num2 >= 0)
			{
				ad2 ad4 = new ad2(ad3.o.a(), A_0, array, num2);
				ad3.f = (int)ad4.a();
			}
			else
			{
				ad3.f = (int)((short)((float)ad3.p.a() * 0.73f));
			}
			ad3.n = new adr(ad3.q.a(), ad3.o.a(), ad3.p.d(), A_0, array, a_2);
			ad3.m = new adh(ad3.q.a(), A_0, array, a_3);
			if (ad3.jr() == OutLineType.TrueTypeOutline)
			{
				((ad9)ad3).a(a_5);
				((ad9)ad3).a(a_6);
				((ad9)ad3).a(a_7);
				if (ad3.o.f())
				{
					((ad9)ad3).a(new ady((ushort)(ad3.q.a() + 1), A_0, array, a_4));
				}
				else
				{
					((ad9)ad3).a(new ad6((ushort)(ad3.q.a() + 1), A_0, array, a_4));
				}
				((ad9)ad3).a(new adn(((ad9)ad3).a().a(), ad3.m.c(), A_0, array, num3));
			}
			else if (ad3.jr() == OutLineType.PostScriptOutLine)
			{
				((ad3)ad3).a(new adc(A_0, array, num5));
			}
			ad3.c = ad3.y().a();
			ad3.d = ad3.y().b();
			ad3.e = ad3.y().c();
			if (ad3.c == 0 && ad3.d == 0)
			{
				ad3.c = 900;
				ad3.d = -220;
				if (ad3.f == 0)
				{
					ad3.f = 657;
				}
			}
			if (num4 >= 0)
			{
				ad3.r = new adw(A_0, array, num4, (int)ad3.o.a());
			}
			return ad3;
		}

		// Token: 0x06002F72 RID: 12146
		internal abstract void jq(DocumentWriter A_0, OpenTypeFont A_1);

		// Token: 0x06002F73 RID: 12147
		internal abstract OutLineType jr();

		// Token: 0x06002F74 RID: 12148 RVA: 0x001AE688 File Offset: 0x001AD688
		internal byte[] b()
		{
			Random random = new Random();
			byte[] array = new byte[7];
			for (int i = 0; i < 6; i++)
			{
				array[i] = (byte)random.Next(65, 90);
			}
			array[6] = 43;
			return array;
		}

		// Token: 0x06002F75 RID: 12149 RVA: 0x001AE6D0 File Offset: 0x001AD6D0
		internal float a(char A_0, char A_1)
		{
			float result;
			if (this.r == null || this.r.a() == null || this.r.a().Length <= 0)
			{
				result = 0f;
			}
			else
			{
				ushort num = (ushort)this.m.b()[(int)A_0];
				ushort num2 = (ushort)this.m.b()[(int)A_1];
				adv adv = null;
				int num3 = -1;
				for (int i = 0; i < this.r.a().Length; i++)
				{
					adv = this.r.a()[i];
					if (adv.a()[adv.a().Length - 1].a() >= num)
					{
						num3 = i;
						break;
					}
				}
				if (num3 == -1)
				{
					result = 0f;
				}
				else
				{
					int num4 = this.a(adv, (int)num);
					if (num4 == -1)
					{
						result = 0f;
					}
					else
					{
						int num5 = (adv.a()[num4].b() < num2) ? 1 : -1;
						while (adv.a()[num4].a() == num)
						{
							if (adv.a()[num4].b() == num2)
							{
								return adv.a()[num4].c();
							}
							num4 += num5;
							if (num4 < 0 || num4 >= adv.a().Length)
							{
								break;
							}
						}
						result = 0f;
					}
				}
			}
			return result;
		}

		// Token: 0x06002F76 RID: 12150 RVA: 0x001AE874 File Offset: 0x001AD874
		private int a(adv A_0, int A_1)
		{
			int i = 0;
			int num = A_0.a().Length - 1;
			while (i <= num)
			{
				int num2 = (i + num) / 2;
				if ((int)A_0.a()[num2].a() < A_1)
				{
					i = num2 + 1;
				}
				else
				{
					if ((int)A_0.a()[num2].a() <= A_1)
					{
						return num2;
					}
					num = num2 - 1;
				}
			}
			return -1;
		}

		// Token: 0x06002F77 RID: 12151 RVA: 0x001AE8F8 File Offset: 0x001AD8F8
		internal byte[] a(DocumentWriter A_0)
		{
			bool[] glyphsUsed = A_0.FontSubsetter.GlyphsUsed;
			byte[] array = new byte[glyphsUsed.Length / 8 + ((glyphsUsed.Length % 8 > 0) ? 1 : 0)];
			if (array.Length > 1)
			{
				array[0] = 128;
			}
			for (int i = 1; i < glyphsUsed.Length; i++)
			{
				if (glyphsUsed[i])
				{
					int num = i / 8;
					int num2 = i % 8;
					array[num] = (byte)((int)array[num] | 128 >> num2);
				}
			}
			return array;
		}

		// Token: 0x06002F78 RID: 12152 RVA: 0x001AE98C File Offset: 0x001AD98C
		internal byte[] b(DocumentWriter A_0)
		{
			bool[] glyphsUsed = A_0.FontSubsetter.GlyphsUsed;
			byte[] array = new byte[glyphsUsed.Length / 8 + ((glyphsUsed.Length % 8 > 0) ? 1 : 0)];
			if (array.Length > 1)
			{
				array[0] = 128;
			}
			for (int i = 1; i < glyphsUsed.Length; i++)
			{
				int num = i / 8;
				int num2 = i % 8;
				array[num] = (byte)((int)array[num] | 128 >> num2);
			}
			return array;
		}

		// Token: 0x06002F79 RID: 12153 RVA: 0x001AEA14 File Offset: 0x001ADA14
		internal bool c()
		{
			return this.a;
		}

		// Token: 0x06002F7A RID: 12154 RVA: 0x001AEA2C File Offset: 0x001ADA2C
		internal void a(bool A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06002F7B RID: 12155 RVA: 0x001AEA38 File Offset: 0x001ADA38
		internal bool d()
		{
			return this.b;
		}

		// Token: 0x06002F7C RID: 12156 RVA: 0x001AEA50 File Offset: 0x001ADA50
		internal void b(bool A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06002F7D RID: 12157 RVA: 0x001AEA5C File Offset: 0x001ADA5C
		internal int e()
		{
			return this.f;
		}

		// Token: 0x06002F7E RID: 12158 RVA: 0x001AEA74 File Offset: 0x001ADA74
		internal short f()
		{
			return this.c;
		}

		// Token: 0x06002F7F RID: 12159 RVA: 0x001AEA8C File Offset: 0x001ADA8C
		internal short g()
		{
			return this.d;
		}

		// Token: 0x06002F80 RID: 12160 RVA: 0x001AEAA4 File Offset: 0x001ADAA4
		internal short h()
		{
			return this.s.n();
		}

		// Token: 0x06002F81 RID: 12161 RVA: 0x001AEAC4 File Offset: 0x001ADAC4
		internal short i()
		{
			return this.s.m();
		}

		// Token: 0x06002F82 RID: 12162 RVA: 0x001AEAE4 File Offset: 0x001ADAE4
		internal short j()
		{
			return this.s.a();
		}

		// Token: 0x06002F83 RID: 12163 RVA: 0x001AEB04 File Offset: 0x001ADB04
		internal short k()
		{
			return this.s.b();
		}

		// Token: 0x06002F84 RID: 12164 RVA: 0x001AEB24 File Offset: 0x001ADB24
		internal short l()
		{
			return this.s.c();
		}

		// Token: 0x06002F85 RID: 12165 RVA: 0x001AEB44 File Offset: 0x001ADB44
		internal short m()
		{
			return this.s.d();
		}

		// Token: 0x06002F86 RID: 12166 RVA: 0x001AEB64 File Offset: 0x001ADB64
		internal short n()
		{
			return this.s.e();
		}

		// Token: 0x06002F87 RID: 12167 RVA: 0x001AEB84 File Offset: 0x001ADB84
		internal short o()
		{
			return this.s.f();
		}

		// Token: 0x06002F88 RID: 12168 RVA: 0x001AEBA4 File Offset: 0x001ADBA4
		internal short p()
		{
			return this.s.g();
		}

		// Token: 0x06002F89 RID: 12169 RVA: 0x001AEBC4 File Offset: 0x001ADBC4
		internal short q()
		{
			return this.s.h();
		}

		// Token: 0x06002F8A RID: 12170 RVA: 0x001AEBE4 File Offset: 0x001ADBE4
		internal short r()
		{
			return this.l.b();
		}

		// Token: 0x06002F8B RID: 12171 RVA: 0x001AEC04 File Offset: 0x001ADC04
		internal short s()
		{
			return this.l.c();
		}

		// Token: 0x06002F8C RID: 12172 RVA: 0x001AEC24 File Offset: 0x001ADC24
		internal short t()
		{
			return this.e;
		}

		// Token: 0x06002F8D RID: 12173 RVA: 0x001AEC3C File Offset: 0x001ADC3C
		internal ad0 u()
		{
			return this.k;
		}

		// Token: 0x06002F8E RID: 12174 RVA: 0x001AEC54 File Offset: 0x001ADC54
		internal ad4 v()
		{
			return this.l;
		}

		// Token: 0x06002F8F RID: 12175 RVA: 0x001AEC6C File Offset: 0x001ADC6C
		internal adh w()
		{
			return this.m;
		}

		// Token: 0x06002F90 RID: 12176 RVA: 0x001AEC84 File Offset: 0x001ADC84
		internal adr x()
		{
			return this.n;
		}

		// Token: 0x06002F91 RID: 12177 RVA: 0x001AEC9C File Offset: 0x001ADC9C
		internal adq y()
		{
			return this.p;
		}

		// Token: 0x06002F92 RID: 12178 RVA: 0x001AECB4 File Offset: 0x001ADCB4
		internal adp z()
		{
			return this.o;
		}

		// Token: 0x06002F93 RID: 12179 RVA: 0x001AECCC File Offset: 0x001ADCCC
		internal adz aa()
		{
			return this.q;
		}

		// Token: 0x06002F94 RID: 12180 RVA: 0x001AECE4 File Offset: 0x001ADCE4
		internal adw ab()
		{
			return this.r;
		}

		// Token: 0x06002F95 RID: 12181 RVA: 0x001AECFC File Offset: 0x001ADCFC
		internal sc ac()
		{
			return this.s;
		}

		// Token: 0x06002F96 RID: 12182 RVA: 0x001AED14 File Offset: 0x001ADD14
		internal byte[] ad()
		{
			return this.t;
		}

		// Token: 0x06002F97 RID: 12183
		internal abstract byte[] js();

		// Token: 0x04001696 RID: 5782
		private bool a = true;

		// Token: 0x04001697 RID: 5783
		private bool b = true;

		// Token: 0x04001698 RID: 5784
		private short c;

		// Token: 0x04001699 RID: 5785
		private short d;

		// Token: 0x0400169A RID: 5786
		private short e;

		// Token: 0x0400169B RID: 5787
		private int f;

		// Token: 0x0400169C RID: 5788
		internal static byte[] g = new byte[]
		{
			73,
			100,
			101,
			110,
			116,
			105,
			116,
			121,
			45,
			72
		};

		// Token: 0x0400169D RID: 5789
		internal static byte[] h = new byte[]
		{
			84,
			111,
			85,
			110,
			105,
			99,
			111,
			100,
			101
		};

		// Token: 0x0400169E RID: 5790
		internal static byte[] i = new byte[]
		{
			70,
			111,
			110,
			116,
			70,
			105,
			108,
			101,
			50
		};

		// Token: 0x0400169F RID: 5791
		internal static byte[] j = new byte[]
		{
			70,
			111,
			110,
			116,
			70,
			105,
			108,
			101,
			51
		};

		// Token: 0x040016A0 RID: 5792
		private ad0 k;

		// Token: 0x040016A1 RID: 5793
		private ad4 l;

		// Token: 0x040016A2 RID: 5794
		private adh m;

		// Token: 0x040016A3 RID: 5795
		private adr n;

		// Token: 0x040016A4 RID: 5796
		private adp o;

		// Token: 0x040016A5 RID: 5797
		private adq p;

		// Token: 0x040016A6 RID: 5798
		private adz q;

		// Token: 0x040016A7 RID: 5799
		private adw r;

		// Token: 0x040016A8 RID: 5800
		private sc s;

		// Token: 0x040016A9 RID: 5801
		private byte[] t;
	}
}
