﻿using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x0200048C RID: 1164
	internal class aef : Encoder
	{
		// Token: 0x06003010 RID: 12304 RVA: 0x001B15B8 File Offset: 0x001B05B8
		static aef()
		{
			for (int i = 0; i < 184; i++)
			{
				aef.b[(int)(aef.a[i, 0] - 9312)] = (byte)aef.a[i, 1];
			}
		}

		// Token: 0x06003011 RID: 12305 RVA: 0x001B162C File Offset: 0x001B062C
		public aef() : base(true)
		{
		}

		// Token: 0x06003012 RID: 12306 RVA: 0x001B1638 File Offset: 0x001B0638
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

		// Token: 0x06003013 RID: 12307 RVA: 0x001B1734 File Offset: 0x001B0734
		public byte a(char A_0)
		{
			byte result;
			if (A_0 != ' ')
			{
				switch (A_0)
				{
				case '→':
					return 213;
				case '↔':
					return 214;
				case '↕':
					return 215;
				}
				if (A_0 < ' ')
				{
					result = 0;
				}
				else if (A_0 < 'ÿ')
				{
					result = (byte)A_0;
				}
				else if (A_0 < '①')
				{
					result = 0;
				}
				else if (A_0 <= '➾')
				{
					result = aef.b[(int)(A_0 - '①')];
				}
				else if (A_0 < '')
				{
					result = 0;
				}
				else if (A_0 <= '')
				{
					result = (byte)(A_0 - '');
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = 32;
			}
			return result;
		}

		// Token: 0x06003014 RID: 12308 RVA: 0x001B1814 File Offset: 0x001B0814
		internal override int fl()
		{
			return 1;
		}

		// Token: 0x06003015 RID: 12309 RVA: 0x001B1828 File Offset: 0x001B0828
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

		// Token: 0x040016DF RID: 5855
		private static ushort[,] a = new ushort[,]
		{
			{
				9312,
				172
			},
			{
				9313,
				173
			},
			{
				9314,
				174
			},
			{
				9315,
				175
			},
			{
				9316,
				176
			},
			{
				9317,
				177
			},
			{
				9318,
				178
			},
			{
				9319,
				179
			},
			{
				9320,
				180
			},
			{
				9321,
				181
			},
			{
				9632,
				110
			},
			{
				9650,
				115
			},
			{
				9660,
				116
			},
			{
				9670,
				117
			},
			{
				9679,
				108
			},
			{
				9687,
				119
			},
			{
				9733,
				72
			},
			{
				9742,
				37
			},
			{
				9755,
				42
			},
			{
				9758,
				43
			},
			{
				9824,
				171
			},
			{
				9827,
				168
			},
			{
				9829,
				170
			},
			{
				9830,
				169
			},
			{
				9985,
				33
			},
			{
				9986,
				34
			},
			{
				9987,
				35
			},
			{
				9988,
				36
			},
			{
				9990,
				38
			},
			{
				9991,
				39
			},
			{
				9992,
				40
			},
			{
				9993,
				41
			},
			{
				9996,
				44
			},
			{
				9997,
				45
			},
			{
				9998,
				46
			},
			{
				9999,
				47
			},
			{
				10000,
				48
			},
			{
				10001,
				49
			},
			{
				10002,
				50
			},
			{
				10003,
				51
			},
			{
				10004,
				52
			},
			{
				10005,
				53
			},
			{
				10006,
				54
			},
			{
				10007,
				55
			},
			{
				10008,
				56
			},
			{
				10009,
				57
			},
			{
				10010,
				58
			},
			{
				10011,
				59
			},
			{
				10012,
				60
			},
			{
				10013,
				61
			},
			{
				10014,
				62
			},
			{
				10015,
				63
			},
			{
				10016,
				64
			},
			{
				10017,
				65
			},
			{
				10018,
				66
			},
			{
				10019,
				67
			},
			{
				10020,
				68
			},
			{
				10021,
				69
			},
			{
				10022,
				70
			},
			{
				10023,
				71
			},
			{
				10025,
				73
			},
			{
				10026,
				74
			},
			{
				10027,
				75
			},
			{
				10028,
				76
			},
			{
				10029,
				77
			},
			{
				10030,
				78
			},
			{
				10031,
				79
			},
			{
				10032,
				80
			},
			{
				10033,
				81
			},
			{
				10034,
				82
			},
			{
				10035,
				83
			},
			{
				10036,
				84
			},
			{
				10037,
				85
			},
			{
				10038,
				86
			},
			{
				10039,
				87
			},
			{
				10040,
				88
			},
			{
				10041,
				89
			},
			{
				10042,
				90
			},
			{
				10043,
				91
			},
			{
				10044,
				92
			},
			{
				10045,
				93
			},
			{
				10046,
				94
			},
			{
				10047,
				95
			},
			{
				10048,
				96
			},
			{
				10049,
				97
			},
			{
				10050,
				98
			},
			{
				10051,
				99
			},
			{
				10052,
				100
			},
			{
				10053,
				101
			},
			{
				10054,
				102
			},
			{
				10055,
				103
			},
			{
				10056,
				104
			},
			{
				10057,
				105
			},
			{
				10058,
				106
			},
			{
				10059,
				107
			},
			{
				10061,
				109
			},
			{
				10063,
				111
			},
			{
				10064,
				112
			},
			{
				10065,
				113
			},
			{
				10066,
				114
			},
			{
				10070,
				118
			},
			{
				10072,
				120
			},
			{
				10073,
				121
			},
			{
				10074,
				122
			},
			{
				10075,
				123
			},
			{
				10076,
				124
			},
			{
				10077,
				125
			},
			{
				10078,
				126
			},
			{
				10081,
				161
			},
			{
				10082,
				162
			},
			{
				10083,
				163
			},
			{
				10084,
				164
			},
			{
				10085,
				165
			},
			{
				10086,
				166
			},
			{
				10087,
				167
			},
			{
				10102,
				182
			},
			{
				10103,
				183
			},
			{
				10104,
				184
			},
			{
				10105,
				185
			},
			{
				10106,
				186
			},
			{
				10107,
				187
			},
			{
				10108,
				188
			},
			{
				10109,
				189
			},
			{
				10110,
				190
			},
			{
				10111,
				191
			},
			{
				10112,
				192
			},
			{
				10113,
				193
			},
			{
				10114,
				194
			},
			{
				10115,
				195
			},
			{
				10116,
				196
			},
			{
				10117,
				197
			},
			{
				10118,
				198
			},
			{
				10119,
				199
			},
			{
				10120,
				200
			},
			{
				10121,
				201
			},
			{
				10122,
				202
			},
			{
				10123,
				203
			},
			{
				10124,
				204
			},
			{
				10125,
				205
			},
			{
				10126,
				206
			},
			{
				10127,
				207
			},
			{
				10128,
				208
			},
			{
				10129,
				209
			},
			{
				10130,
				210
			},
			{
				10131,
				211
			},
			{
				10132,
				212
			},
			{
				10136,
				216
			},
			{
				10137,
				217
			},
			{
				10138,
				218
			},
			{
				10139,
				219
			},
			{
				10140,
				220
			},
			{
				10141,
				221
			},
			{
				10142,
				222
			},
			{
				10143,
				223
			},
			{
				10144,
				224
			},
			{
				10145,
				225
			},
			{
				10146,
				226
			},
			{
				10147,
				227
			},
			{
				10148,
				228
			},
			{
				10149,
				229
			},
			{
				10150,
				230
			},
			{
				10151,
				231
			},
			{
				10152,
				232
			},
			{
				10153,
				233
			},
			{
				10154,
				234
			},
			{
				10155,
				235
			},
			{
				10156,
				236
			},
			{
				10157,
				237
			},
			{
				10158,
				238
			},
			{
				10159,
				239
			},
			{
				10161,
				241
			},
			{
				10162,
				242
			},
			{
				10163,
				243
			},
			{
				10164,
				244
			},
			{
				10165,
				245
			},
			{
				10166,
				246
			},
			{
				10167,
				247
			},
			{
				10168,
				248
			},
			{
				10169,
				249
			},
			{
				10170,
				250
			},
			{
				10171,
				251
			},
			{
				10172,
				252
			},
			{
				10173,
				253
			},
			{
				10174,
				254
			}
		};

		// Token: 0x040016E0 RID: 5856
		private static byte[] b = new byte[863];
	}
}
