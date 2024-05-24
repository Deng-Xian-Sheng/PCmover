using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000488 RID: 1160
	internal class aeb : Encoder
	{
		// Token: 0x06002FEC RID: 12268 RVA: 0x001B0DEC File Offset: 0x001AFDEC
		static aeb()
		{
			int i = 0;
			while (aeb.a[i, 0] < 8226)
			{
				aeb.c(i++);
			}
			while (aeb.a[i, 0] < 63193)
			{
				aeb.b(i++);
			}
			while (i < 194)
			{
				aeb.a(i++);
			}
		}

		// Token: 0x06002FED RID: 12269 RVA: 0x001B0EAC File Offset: 0x001AFEAC
		private static void c(int A_0)
		{
			aeb.b[(int)aeb.a[A_0, 0]] = (byte)aeb.a[A_0, 1];
		}

		// Token: 0x06002FEE RID: 12270 RVA: 0x001B0ECE File Offset: 0x001AFECE
		private static void b(int A_0)
		{
			aeb.c[(int)(aeb.a[A_0, 0] - 8226)] = (byte)aeb.a[A_0, 1];
		}

		// Token: 0x06002FEF RID: 12271 RVA: 0x001B0EF6 File Offset: 0x001AFEF6
		private static void a(int A_0)
		{
			aeb.d[(int)(aeb.a[A_0, 0] - 63193)] = (byte)aeb.a[A_0, 1];
		}

		// Token: 0x06002FF0 RID: 12272 RVA: 0x001B0F1E File Offset: 0x001AFF1E
		public aeb() : base(true)
		{
		}

		// Token: 0x06002FF1 RID: 12273 RVA: 0x001B0F2C File Offset: 0x001AFF2C
		public override byte[] Encode(FontSubsetter subsetter, char[] text, int start, int length, bool rightToLeft)
		{
			byte[] array = new byte[length];
			if (rightToLeft)
			{
				int num = start + length;
				int num2 = length - 1;
				for (int i = start; i < num; i++)
				{
					byte b = this.a(text[i]);
					if (b != 0)
					{
						array[num2--] = b;
					}
				}
				if (num2 >= 0)
				{
					num2++;
					byte[] array2 = new byte[length - num2];
					Array.Copy(array, num2, array2, 0, array2.Length);
					return array2;
				}
			}
			else
			{
				int num = start + length;
				int num2 = 0;
				for (int i = start; i < num; i++)
				{
					byte b = this.a(text[i]);
					if (b != 0)
					{
						array[num2++] = b;
					}
				}
				if (num2 < array.Length)
				{
					byte[] array2 = new byte[num2];
					Array.Copy(array, array2, num2);
					return array2;
				}
			}
			return array;
		}

		// Token: 0x06002FF2 RID: 12274 RVA: 0x001B1028 File Offset: 0x001B0028
		public byte a(char A_0)
		{
			byte result;
			if (A_0 < ' ')
			{
				result = 0;
			}
			else if (A_0 < 'ÿ')
			{
				result = (byte)A_0;
			}
			else if (A_0 <= 'ϖ')
			{
				result = aeb.b[(int)A_0];
			}
			else if (A_0 < '•')
			{
				result = 0;
			}
			else if (A_0 <= '♦')
			{
				result = aeb.c[(int)(A_0 - '•')];
			}
			else if (A_0 < '')
			{
				result = 0;
			}
			else if (A_0 <= '')
			{
				result = aeb.d[(int)(A_0 - '')];
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06002FF3 RID: 12275 RVA: 0x001B10D8 File Offset: 0x001B00D8
		internal override int fl()
		{
			return 1;
		}

		// Token: 0x06002FF4 RID: 12276 RVA: 0x001B10EC File Offset: 0x001B00EC
		internal override void fm(br A_0, FontSubsetter A_1, char[] A_2, int A_3, int A_4, bool A_5)
		{
			A_0.g();
			if (A_5)
			{
				for (int i = A_3 + A_4 - 1; i >= A_3; i--)
				{
					byte b = this.a(A_2[i]);
					if (b != 0)
					{
						A_0.b(b);
					}
				}
			}
			else
			{
				for (int i = A_3; i < A_3 + A_4; i++)
				{
					byte b = this.a(A_2[i]);
					if (b != 0)
					{
						A_0.b(b);
					}
				}
			}
			A_0.h();
		}

		// Token: 0x040016D4 RID: 5844
		private static ushort[,] a = new ushort[,]
		{
			{
				32,
				32
			},
			{
				33,
				33
			},
			{
				35,
				35
			},
			{
				37,
				37
			},
			{
				38,
				38
			},
			{
				40,
				40
			},
			{
				41,
				41
			},
			{
				43,
				43
			},
			{
				44,
				44
			},
			{
				46,
				46
			},
			{
				47,
				47
			},
			{
				48,
				48
			},
			{
				49,
				49
			},
			{
				50,
				50
			},
			{
				51,
				51
			},
			{
				52,
				52
			},
			{
				53,
				53
			},
			{
				54,
				54
			},
			{
				55,
				55
			},
			{
				56,
				56
			},
			{
				57,
				57
			},
			{
				58,
				58
			},
			{
				59,
				59
			},
			{
				60,
				60
			},
			{
				61,
				61
			},
			{
				62,
				62
			},
			{
				63,
				63
			},
			{
				91,
				91
			},
			{
				93,
				93
			},
			{
				95,
				95
			},
			{
				123,
				123
			},
			{
				124,
				124
			},
			{
				125,
				125
			},
			{
				160,
				32
			},
			{
				172,
				216
			},
			{
				176,
				176
			},
			{
				177,
				177
			},
			{
				181,
				109
			},
			{
				215,
				180
			},
			{
				247,
				184
			},
			{
				402,
				166
			},
			{
				913,
				65
			},
			{
				914,
				66
			},
			{
				915,
				71
			},
			{
				916,
				68
			},
			{
				917,
				69
			},
			{
				918,
				90
			},
			{
				919,
				72
			},
			{
				920,
				81
			},
			{
				921,
				73
			},
			{
				922,
				75
			},
			{
				923,
				76
			},
			{
				924,
				77
			},
			{
				925,
				78
			},
			{
				926,
				88
			},
			{
				927,
				79
			},
			{
				928,
				80
			},
			{
				929,
				82
			},
			{
				931,
				83
			},
			{
				932,
				84
			},
			{
				933,
				85
			},
			{
				934,
				70
			},
			{
				935,
				67
			},
			{
				936,
				89
			},
			{
				937,
				87
			},
			{
				945,
				97
			},
			{
				946,
				98
			},
			{
				947,
				103
			},
			{
				948,
				100
			},
			{
				949,
				101
			},
			{
				950,
				122
			},
			{
				951,
				104
			},
			{
				952,
				113
			},
			{
				953,
				105
			},
			{
				954,
				107
			},
			{
				955,
				108
			},
			{
				956,
				109
			},
			{
				957,
				110
			},
			{
				958,
				120
			},
			{
				959,
				111
			},
			{
				960,
				112
			},
			{
				961,
				114
			},
			{
				962,
				86
			},
			{
				963,
				115
			},
			{
				964,
				116
			},
			{
				965,
				117
			},
			{
				966,
				102
			},
			{
				967,
				99
			},
			{
				968,
				121
			},
			{
				969,
				119
			},
			{
				977,
				74
			},
			{
				978,
				161
			},
			{
				981,
				106
			},
			{
				982,
				118
			},
			{
				8226,
				183
			},
			{
				8230,
				188
			},
			{
				8242,
				162
			},
			{
				8243,
				178
			},
			{
				8260,
				164
			},
			{
				8364,
				160
			},
			{
				8465,
				193
			},
			{
				8472,
				195
			},
			{
				8476,
				194
			},
			{
				8486,
				87
			},
			{
				8501,
				192
			},
			{
				8592,
				172
			},
			{
				8593,
				173
			},
			{
				8594,
				174
			},
			{
				8595,
				175
			},
			{
				8596,
				171
			},
			{
				8629,
				191
			},
			{
				8656,
				220
			},
			{
				8657,
				221
			},
			{
				8658,
				222
			},
			{
				8659,
				223
			},
			{
				8660,
				219
			},
			{
				8704,
				34
			},
			{
				8706,
				182
			},
			{
				8707,
				36
			},
			{
				8709,
				198
			},
			{
				8710,
				68
			},
			{
				8711,
				209
			},
			{
				8712,
				206
			},
			{
				8713,
				207
			},
			{
				8715,
				39
			},
			{
				8719,
				213
			},
			{
				8721,
				229
			},
			{
				8722,
				45
			},
			{
				8725,
				164
			},
			{
				8727,
				42
			},
			{
				8730,
				214
			},
			{
				8733,
				181
			},
			{
				8734,
				165
			},
			{
				8736,
				208
			},
			{
				8743,
				217
			},
			{
				8744,
				218
			},
			{
				8745,
				199
			},
			{
				8746,
				200
			},
			{
				8747,
				242
			},
			{
				8756,
				92
			},
			{
				8764,
				126
			},
			{
				8773,
				64
			},
			{
				8776,
				187
			},
			{
				8800,
				185
			},
			{
				8801,
				186
			},
			{
				8804,
				163
			},
			{
				8805,
				179
			},
			{
				8834,
				204
			},
			{
				8835,
				201
			},
			{
				8836,
				203
			},
			{
				8838,
				205
			},
			{
				8839,
				202
			},
			{
				8853,
				197
			},
			{
				8855,
				196
			},
			{
				8869,
				94
			},
			{
				8901,
				215
			},
			{
				8992,
				243
			},
			{
				8993,
				245
			},
			{
				9001,
				225
			},
			{
				9002,
				241
			},
			{
				9674,
				224
			},
			{
				9824,
				170
			},
			{
				9827,
				167
			},
			{
				9829,
				169
			},
			{
				9830,
				168
			},
			{
				63193,
				211
			},
			{
				63194,
				210
			},
			{
				63195,
				212
			},
			{
				63717,
				96
			},
			{
				63718,
				189
			},
			{
				63719,
				190
			},
			{
				63720,
				226
			},
			{
				63721,
				227
			},
			{
				63722,
				228
			},
			{
				63723,
				230
			},
			{
				63724,
				231
			},
			{
				63725,
				232
			},
			{
				63726,
				233
			},
			{
				63727,
				234
			},
			{
				63728,
				235
			},
			{
				63729,
				236
			},
			{
				63730,
				237
			},
			{
				63731,
				238
			},
			{
				63732,
				239
			},
			{
				63733,
				244
			},
			{
				63734,
				246
			},
			{
				63735,
				247
			},
			{
				63736,
				248
			},
			{
				63737,
				249
			},
			{
				63738,
				250
			},
			{
				63739,
				251
			},
			{
				63740,
				252
			},
			{
				63741,
				253
			},
			{
				63742,
				254
			}
		};

		// Token: 0x040016D5 RID: 5845
		private static byte[] b = new byte[983];

		// Token: 0x040016D6 RID: 5846
		private static byte[] c = new byte[1605];

		// Token: 0x040016D7 RID: 5847
		private static byte[] d = new byte[550];
	}
}
