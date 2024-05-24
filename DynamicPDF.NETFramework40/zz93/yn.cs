using System;

namespace zz93
{
	// Token: 0x020003AD RID: 941
	internal class yn
	{
		// Token: 0x060027FB RID: 10235 RVA: 0x0016FD08 File Offset: 0x0016ED08
		internal yn(yj A_0, uint[] A_1, uint[] A_2, bool A_3, int A_4, int A_5, int A_6)
		{
			this.a = A_0;
			this.b = A_1;
			this.c = A_2;
			this.g = A_6;
			uint num = 0U;
			foreach (uint num2 in A_2)
			{
				num += num2;
			}
			this.d = new byte[num + 1334U];
			ym a_ = new ym(this.a(0, A_3), A_4, A_6, false, A_1.Length);
			this.a(a_, false);
			for (int j = 1; j < A_1.Length; j++)
			{
				A_5 -= A_6;
				a_ = new ym(this.a(j, A_3), A_4, (A_5 > A_6) ? A_6 : A_5, true, A_1.Length);
				this.a(a_, true);
			}
			if (this.f != 0)
			{
				this.e++;
			}
		}

		// Token: 0x060027FC RID: 10236 RVA: 0x0016FE04 File Offset: 0x0016EE04
		internal byte[] d()
		{
			return this.d;
		}

		// Token: 0x060027FD RID: 10237 RVA: 0x0016FE1C File Offset: 0x0016EE1C
		internal int e()
		{
			return this.e;
		}

		// Token: 0x060027FE RID: 10238 RVA: 0x0016FE34 File Offset: 0x0016EE34
		private void a(ym A_0, bool A_1)
		{
			if (A_1)
			{
				for (int i = 0; i < A_0.o(); i++)
				{
					this.b(A_0.d(i++), A_0.d(i));
				}
			}
			if (!A_1 || this.g != 1)
			{
				if (this.f != 0)
				{
					int a_ = 8 - this.f;
					byte[] array = this.d;
					int num = this.e;
					array[num] |= A_0.e(a_);
					this.e++;
					this.f = 0;
				}
				this.d(A_0.o());
				int num2 = A_0.a(this.d, this.e);
				this.e += num2 / 8;
				this.f += num2 % 8;
				if (A_0.p())
				{
					this.a(A_0.q());
				}
				if (this.f >= 8)
				{
					this.f -= 8;
					this.e++;
				}
			}
		}

		// Token: 0x060027FF RID: 10239 RVA: 0x0016FF74 File Offset: 0x0016EF74
		private byte[] a(int A_0, bool A_1)
		{
			byte[] array = new byte[this.c[A_0]];
			this.a.a(this.b[A_0], array, 0, (int)this.c[A_0]);
			if (A_1)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = yn.h[(int)array[i]];
				}
			}
			return array;
		}

		// Token: 0x06002800 RID: 10240 RVA: 0x0016FFDC File Offset: 0x0016EFDC
		private void b(int A_0, int A_1)
		{
			this.d(64);
			this.b();
			this.b();
			this.c();
			this.c(A_0);
			this.b(A_1);
		}

		// Token: 0x06002801 RID: 10241 RVA: 0x00170010 File Offset: 0x0016F010
		private void d(int A_0)
		{
			if (this.d.Length - this.e < A_0)
			{
				byte[] array = new byte[this.e + A_0 + 1024];
				this.d.CopyTo(array, 0);
				this.d = array;
			}
		}

		// Token: 0x06002802 RID: 10242 RVA: 0x00170064 File Offset: 0x0016F064
		private void c(int A_0)
		{
			if (A_0 < 64)
			{
				switch (A_0)
				{
				case 0:
					this.a(1696, 8);
					break;
				case 1:
					this.a(896, 6);
					break;
				case 2:
					this.a(3584, 4);
					break;
				case 3:
					this.a(4096, 4);
					break;
				case 4:
					this.a(5632, 4);
					break;
				case 5:
					this.a(6144, 4);
					break;
				case 6:
					this.a(7168, 4);
					break;
				case 7:
					this.a(7680, 4);
					break;
				case 8:
					this.a(4864, 5);
					break;
				case 9:
					this.a(5120, 5);
					break;
				case 10:
					this.a(1792, 5);
					break;
				case 11:
					this.a(2048, 5);
					break;
				case 12:
					this.a(1024, 6);
					break;
				case 13:
					this.a(384, 6);
					break;
				case 14:
					this.a(6656, 6);
					break;
				case 15:
					this.a(6784, 6);
					break;
				case 16:
					this.a(5376, 6);
					break;
				case 17:
					this.a(5504, 6);
					break;
				case 18:
					this.a(2496, 7);
					break;
				case 19:
					this.a(768, 7);
					break;
				case 20:
					this.a(512, 7);
					break;
				case 21:
					this.a(1472, 7);
					break;
				case 22:
					this.a(192, 7);
					break;
				case 23:
					this.a(256, 7);
					break;
				case 24:
					this.a(2560, 7);
					break;
				case 25:
					this.a(2752, 7);
					break;
				case 26:
					this.a(1216, 7);
					break;
				case 27:
					this.a(2304, 7);
					break;
				case 28:
					this.a(1536, 7);
					break;
				case 29:
					this.a(64, 8);
					break;
				case 30:
					this.a(96, 8);
					break;
				case 31:
					this.a(832, 8);
					break;
				case 32:
					this.a(864, 8);
					break;
				case 33:
					this.a(576, 8);
					break;
				case 34:
					this.a(608, 8);
					break;
				case 35:
					this.a(640, 8);
					break;
				case 36:
					this.a(672, 8);
					break;
				case 37:
					this.a(704, 8);
					break;
				case 38:
					this.a(736, 8);
					break;
				case 39:
					this.a(1280, 8);
					break;
				case 40:
					this.a(1312, 8);
					break;
				case 41:
					this.a(1344, 8);
					break;
				case 42:
					this.a(1376, 8);
					break;
				case 43:
					this.a(1408, 8);
					break;
				case 44:
					this.a(1440, 8);
					break;
				case 45:
					this.a(128, 8);
					break;
				case 46:
					this.a(160, 8);
					break;
				case 47:
					this.a(320, 8);
					break;
				case 48:
					this.a(352, 8);
					break;
				case 49:
					this.a(2624, 8);
					break;
				case 50:
					this.a(2656, 8);
					break;
				case 51:
					this.a(2688, 8);
					break;
				case 52:
					this.a(2720, 8);
					break;
				case 53:
					this.a(1152, 8);
					break;
				case 54:
					this.a(1184, 8);
					break;
				case 55:
					this.a(2816, 8);
					break;
				case 56:
					this.a(2848, 8);
					break;
				case 57:
					this.a(2880, 8);
					break;
				case 58:
					this.a(2912, 8);
					break;
				case 59:
					this.a(2368, 8);
					break;
				case 60:
					this.a(2400, 8);
					break;
				case 61:
					this.a(1600, 8);
					break;
				case 62:
					this.a(1632, 8);
					break;
				default:
					this.a(1664, 8);
					break;
				}
			}
			else
			{
				switch (A_0 / 64)
				{
				case 1:
					this.a(6912, 5);
					this.c(A_0 - 64);
					break;
				case 2:
					this.a(4608, 5);
					this.c(A_0 - 128);
					break;
				case 3:
					this.a(2944, 6);
					this.c(A_0 - 192);
					break;
				case 4:
					this.a(3520, 7);
					this.c(A_0 - 256);
					break;
				case 5:
					this.a(1728, 8);
					this.c(A_0 - 320);
					break;
				case 6:
					this.a(1760, 8);
					this.c(A_0 - 384);
					break;
				case 7:
					this.a(3200, 8);
					this.c(A_0 - 448);
					break;
				case 8:
					this.a(3232, 8);
					this.c(A_0 - 512);
					break;
				case 9:
					this.a(3328, 8);
					this.c(A_0 - 576);
					break;
				case 10:
					this.a(3296, 8);
					this.c(A_0 - 640);
					break;
				case 11:
					this.a(3264, 9);
					this.c(A_0 - 704);
					break;
				case 12:
					this.a(3280, 9);
					this.c(A_0 - 768);
					break;
				case 13:
					this.a(3360, 9);
					this.c(A_0 - 832);
					break;
				case 14:
					this.a(3376, 9);
					this.c(A_0 - 896);
					break;
				case 15:
					this.a(3392, 9);
					this.c(A_0 - 960);
					break;
				case 16:
					this.a(3408, 9);
					this.c(A_0 - 1024);
					break;
				case 17:
					this.a(3424, 9);
					this.c(A_0 - 1088);
					break;
				case 18:
					this.a(3440, 9);
					this.c(A_0 - 1152);
					break;
				case 19:
					this.a(3456, 9);
					this.c(A_0 - 1216);
					break;
				case 20:
					this.a(3472, 9);
					this.c(A_0 - 1280);
					break;
				case 21:
					this.a(3488, 9);
					this.c(A_0 - 1344);
					break;
				case 22:
					this.a(3504, 9);
					this.c(A_0 - 1408);
					break;
				case 23:
					this.a(2432, 9);
					this.c(A_0 - 1472);
					break;
				case 24:
					this.a(2448, 9);
					this.c(A_0 - 1536);
					break;
				case 25:
					this.a(2464, 9);
					this.c(A_0 - 1600);
					break;
				case 26:
					this.a(3072, 6);
					this.c(A_0 - 1664);
					break;
				case 27:
					this.a(2480, 9);
					this.c(A_0 - 1728);
					break;
				case 28:
					this.a(32, 11);
					this.c(A_0 - 1792);
					break;
				case 29:
					this.a(48, 11);
					this.c(A_0 - 1856);
					break;
				case 30:
					this.a(52, 11);
					this.c(A_0 - 1920);
					break;
				case 31:
					this.a(36, 12);
					this.c(A_0 - 1984);
					break;
				case 32:
					this.a(38, 12);
					this.c(A_0 - 2048);
					break;
				case 33:
					this.a(40, 12);
					this.c(A_0 - 2112);
					break;
				case 34:
					this.a(42, 12);
					this.c(A_0 - 2176);
					break;
				case 35:
					this.a(44, 12);
					this.c(A_0 - 2240);
					break;
				case 36:
					this.a(46, 12);
					this.c(A_0 - 2304);
					break;
				case 37:
					this.a(56, 12);
					this.c(A_0 - 2368);
					break;
				case 38:
					this.a(58, 12);
					this.c(A_0 - 2432);
					break;
				case 39:
					this.a(60, 12);
					this.c(A_0 - 2496);
					break;
				default:
					this.a(62, 12);
					this.c(A_0 - 2560);
					break;
				}
			}
		}

		// Token: 0x06002803 RID: 10243 RVA: 0x00170B98 File Offset: 0x0016FB98
		private void b(int A_0)
		{
			if (A_0 < 64)
			{
				switch (A_0)
				{
				case 0:
					this.a(440, 10);
					break;
				case 1:
					this.a(2048, 3);
					break;
				case 2:
					this.a(6144, 2);
					break;
				case 3:
					this.a(4096, 2);
					break;
				case 4:
					this.a(3072, 3);
					break;
				case 5:
					this.a(1536, 4);
					break;
				case 6:
					this.a(1024, 4);
					break;
				case 7:
					this.a(768, 5);
					break;
				case 8:
					this.a(640, 6);
					break;
				case 9:
					this.a(512, 6);
					break;
				case 10:
					this.a(256, 7);
					break;
				case 11:
					this.a(320, 7);
					break;
				case 12:
					this.a(448, 7);
					break;
				case 13:
					this.a(128, 8);
					break;
				case 14:
					this.a(224, 8);
					break;
				case 15:
					this.a(384, 9);
					break;
				case 16:
					this.a(184, 10);
					break;
				case 17:
					this.a(192, 10);
					break;
				case 18:
					this.a(64, 10);
					break;
				case 19:
					this.a(412, 11);
					break;
				case 20:
					this.a(416, 11);
					break;
				case 21:
					this.a(432, 11);
					break;
				case 22:
					this.a(220, 11);
					break;
				case 23:
					this.a(160, 11);
					break;
				case 24:
					this.a(92, 11);
					break;
				case 25:
					this.a(96, 11);
					break;
				case 26:
					this.a(404, 12);
					break;
				case 27:
					this.a(406, 12);
					break;
				case 28:
					this.a(408, 12);
					break;
				case 29:
					this.a(410, 12);
					break;
				case 30:
					this.a(208, 12);
					break;
				case 31:
					this.a(210, 12);
					break;
				case 32:
					this.a(212, 12);
					break;
				case 33:
					this.a(214, 12);
					break;
				case 34:
					this.a(420, 12);
					break;
				case 35:
					this.a(422, 12);
					break;
				case 36:
					this.a(424, 12);
					break;
				case 37:
					this.a(426, 12);
					break;
				case 38:
					this.a(428, 12);
					break;
				case 39:
					this.a(430, 12);
					break;
				case 40:
					this.a(216, 12);
					break;
				case 41:
					this.a(218, 12);
					break;
				case 42:
					this.a(436, 12);
					break;
				case 43:
					this.a(438, 12);
					break;
				case 44:
					this.a(168, 12);
					break;
				case 45:
					this.a(170, 12);
					break;
				case 46:
					this.a(172, 12);
					break;
				case 47:
					this.a(174, 12);
					break;
				case 48:
					this.a(200, 12);
					break;
				case 49:
					this.a(202, 12);
					break;
				case 50:
					this.a(164, 12);
					break;
				case 51:
					this.a(166, 12);
					break;
				case 52:
					this.a(72, 12);
					break;
				case 53:
					this.a(110, 12);
					break;
				case 54:
					this.a(112, 12);
					break;
				case 55:
					this.a(78, 12);
					break;
				case 56:
					this.a(80, 12);
					break;
				case 57:
					this.a(176, 12);
					break;
				case 58:
					this.a(178, 12);
					break;
				case 59:
					this.a(86, 12);
					break;
				case 60:
					this.a(88, 12);
					break;
				case 61:
					this.a(180, 12);
					break;
				case 62:
					this.a(204, 12);
					break;
				default:
					this.a(206, 12);
					break;
				}
			}
			else
			{
				switch (A_0 / 64)
				{
				case 1:
					this.a(120, 10);
					this.b(A_0 - 64);
					break;
				case 2:
					this.a(400, 12);
					this.b(A_0 - 128);
					break;
				case 3:
					this.a(402, 12);
					this.b(A_0 - 192);
					break;
				case 4:
					this.a(182, 12);
					this.b(A_0 - 256);
					break;
				case 5:
					this.a(102, 12);
					this.b(A_0 - 320);
					break;
				case 6:
					this.a(104, 12);
					this.b(A_0 - 384);
					break;
				case 7:
					this.a(106, 12);
					this.b(A_0 - 448);
					break;
				case 8:
					this.a(108, 13);
					this.b(A_0 - 512);
					break;
				case 9:
					this.a(109, 13);
					this.b(A_0 - 576);
					break;
				case 10:
					this.a(74, 13);
					this.b(A_0 - 640);
					break;
				case 11:
					this.a(75, 13);
					this.b(A_0 - 704);
					break;
				case 12:
					this.a(76, 13);
					this.b(A_0 - 768);
					break;
				case 13:
					this.a(77, 13);
					this.b(A_0 - 832);
					break;
				case 14:
					this.a(114, 13);
					this.b(A_0 - 896);
					break;
				case 15:
					this.a(115, 13);
					this.b(A_0 - 960);
					break;
				case 16:
					this.a(116, 13);
					this.b(A_0 - 1024);
					break;
				case 17:
					this.a(117, 13);
					this.b(A_0 - 1088);
					break;
				case 18:
					this.a(118, 13);
					this.b(A_0 - 1152);
					break;
				case 19:
					this.a(119, 13);
					this.b(A_0 - 1216);
					break;
				case 20:
					this.a(82, 13);
					this.b(A_0 - 1280);
					break;
				case 21:
					this.a(83, 13);
					this.b(A_0 - 1344);
					break;
				case 22:
					this.a(84, 13);
					this.b(A_0 - 1408);
					break;
				case 23:
					this.a(85, 13);
					this.b(A_0 - 1472);
					break;
				case 24:
					this.a(90, 13);
					this.b(A_0 - 1536);
					break;
				case 25:
					this.a(91, 13);
					this.b(A_0 - 1600);
					break;
				case 26:
					this.a(100, 13);
					this.b(A_0 - 1664);
					break;
				case 27:
					this.a(101, 13);
					this.b(A_0 - 1728);
					break;
				case 28:
					this.a(32, 11);
					this.b(A_0 - 1792);
					break;
				case 29:
					this.a(48, 11);
					this.b(A_0 - 1856);
					break;
				case 30:
					this.a(52, 11);
					this.b(A_0 - 1920);
					break;
				case 31:
					this.a(36, 12);
					this.b(A_0 - 1984);
					break;
				case 32:
					this.a(38, 12);
					this.b(A_0 - 2048);
					break;
				case 33:
					this.a(40, 12);
					this.b(A_0 - 2112);
					break;
				case 34:
					this.a(42, 12);
					this.b(A_0 - 2176);
					break;
				case 35:
					this.a(44, 12);
					this.b(A_0 - 2240);
					break;
				case 36:
					this.a(46, 12);
					this.b(A_0 - 2304);
					break;
				case 37:
					this.a(56, 12);
					this.b(A_0 - 2368);
					break;
				case 38:
					this.a(58, 12);
					this.b(A_0 - 2432);
					break;
				case 39:
					this.a(60, 12);
					this.b(A_0 - 2496);
					break;
				default:
					this.a(62, 12);
					this.b(A_0 - 2560);
					break;
				}
			}
		}

		// Token: 0x06002804 RID: 10244 RVA: 0x001716AC File Offset: 0x001706AC
		private void a(int A_0, int A_1)
		{
			int num = 4096;
			for (int i = 0; i < A_1; i++)
			{
				int num2 = A_0 - num;
				if (num2 >= 0)
				{
					A_0 = num2;
					this.c();
				}
				else
				{
					this.b();
				}
				num /= 2;
			}
		}

		// Token: 0x06002805 RID: 10245 RVA: 0x001716FC File Offset: 0x001706FC
		private void c()
		{
			switch (this.f)
			{
			case 0:
			{
				byte[] array = this.d;
				int num = this.e;
				array[num] |= 128;
				this.f++;
				break;
			}
			case 1:
			{
				byte[] array2 = this.d;
				int num2 = this.e;
				array2[num2] |= 64;
				this.f++;
				break;
			}
			case 2:
			{
				byte[] array3 = this.d;
				int num3 = this.e;
				array3[num3] |= 32;
				this.f++;
				break;
			}
			case 3:
			{
				byte[] array4 = this.d;
				int num4 = this.e;
				array4[num4] |= 16;
				this.f++;
				break;
			}
			case 4:
			{
				byte[] array5 = this.d;
				int num5 = this.e;
				array5[num5] |= 8;
				this.f++;
				break;
			}
			case 5:
			{
				byte[] array6 = this.d;
				int num6 = this.e;
				array6[num6] |= 4;
				this.f++;
				break;
			}
			case 6:
			{
				byte[] array7 = this.d;
				int num7 = this.e;
				array7[num7] |= 2;
				this.f++;
				break;
			}
			default:
			{
				byte[] array8 = this.d;
				int num8 = this.e;
				array8[num8] |= 1;
				this.e++;
				this.f = 0;
				break;
			}
			}
		}

		// Token: 0x06002806 RID: 10246 RVA: 0x001718D0 File Offset: 0x001708D0
		private void b()
		{
			this.f++;
			if (this.f == 8)
			{
				this.f = 0;
				this.e++;
			}
		}

		// Token: 0x06002807 RID: 10247 RVA: 0x00171914 File Offset: 0x00170914
		private void a(int A_0)
		{
			if (A_0 < this.g)
			{
				this.e--;
				if (this.f > 1)
				{
					this.f -= 2;
				}
				else
				{
					this.e--;
					this.f = 6 + this.f;
				}
				this.a();
				while (A_0 < this.g)
				{
					this.c();
					A_0++;
				}
				this.d[++this.e] = 0;
				this.d[++this.e] = 1;
			}
		}

		// Token: 0x06002808 RID: 10248 RVA: 0x001719D9 File Offset: 0x001709D9
		private void a()
		{
			this.d(64);
			this.b();
			this.b();
			this.b();
			this.c();
		}

		// Token: 0x04001178 RID: 4472
		private yj a;

		// Token: 0x04001179 RID: 4473
		private uint[] b;

		// Token: 0x0400117A RID: 4474
		private uint[] c;

		// Token: 0x0400117B RID: 4475
		private byte[] d;

		// Token: 0x0400117C RID: 4476
		private int e;

		// Token: 0x0400117D RID: 4477
		private int f = 0;

		// Token: 0x0400117E RID: 4478
		private int g;

		// Token: 0x0400117F RID: 4479
		private static byte[] h = new byte[]
		{
			0,
			128,
			64,
			192,
			32,
			160,
			96,
			224,
			16,
			144,
			80,
			208,
			48,
			176,
			112,
			240,
			8,
			136,
			72,
			200,
			40,
			168,
			104,
			232,
			24,
			152,
			88,
			216,
			56,
			184,
			120,
			248,
			4,
			132,
			68,
			196,
			36,
			164,
			100,
			228,
			20,
			148,
			84,
			212,
			52,
			180,
			116,
			244,
			12,
			140,
			76,
			204,
			44,
			172,
			108,
			236,
			28,
			156,
			92,
			220,
			60,
			188,
			124,
			252,
			2,
			130,
			66,
			194,
			34,
			162,
			98,
			226,
			18,
			146,
			82,
			210,
			50,
			178,
			114,
			242,
			10,
			138,
			74,
			202,
			42,
			170,
			106,
			234,
			26,
			154,
			90,
			218,
			58,
			186,
			122,
			250,
			6,
			134,
			70,
			198,
			38,
			166,
			102,
			230,
			22,
			150,
			86,
			214,
			54,
			182,
			118,
			246,
			14,
			142,
			78,
			206,
			46,
			174,
			110,
			238,
			30,
			158,
			94,
			222,
			62,
			190,
			126,
			254,
			1,
			129,
			65,
			193,
			33,
			161,
			97,
			225,
			17,
			145,
			81,
			209,
			49,
			177,
			113,
			241,
			9,
			137,
			73,
			201,
			41,
			169,
			105,
			233,
			25,
			153,
			89,
			217,
			57,
			185,
			121,
			249,
			5,
			133,
			69,
			197,
			37,
			165,
			101,
			229,
			21,
			149,
			85,
			213,
			53,
			181,
			117,
			245,
			13,
			141,
			77,
			205,
			45,
			173,
			109,
			237,
			29,
			157,
			93,
			221,
			61,
			189,
			125,
			253,
			3,
			131,
			67,
			195,
			35,
			163,
			99,
			227,
			19,
			147,
			83,
			211,
			51,
			179,
			115,
			243,
			11,
			139,
			75,
			203,
			43,
			171,
			107,
			235,
			27,
			155,
			91,
			219,
			59,
			187,
			123,
			251,
			7,
			135,
			71,
			199,
			39,
			167,
			103,
			231,
			23,
			151,
			87,
			215,
			55,
			183,
			119,
			247,
			15,
			143,
			79,
			207,
			47,
			175,
			111,
			239,
			31,
			159,
			95,
			223,
			63,
			191,
			127,
			byte.MaxValue
		};
	}
}
