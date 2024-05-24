using System;
using System.Collections.Generic;

namespace zz93
{
	// Token: 0x020004D5 RID: 1237
	internal class age
	{
		// Token: 0x06003294 RID: 12948 RVA: 0x001C2A2C File Offset: 0x001C1A2C
		private static uint a(char A_0, char A_1, char A_2, char A_3)
		{
			return (uint)((int)((byte)A_0) << 24 | (int)((byte)A_1) << 16 | (int)((byte)A_2) << 8 | (int)((byte)A_3));
		}

		// Token: 0x06003295 RID: 12949 RVA: 0x001C2A54 File Offset: 0x001C1A54
		internal static KeyValuePair<uint, agf> a(char A_0)
		{
			for (int i = 0; i < age.df.Length; i++)
			{
				if ((int)A_0 >= age.df[i].Value.a() && (int)A_0 <= age.df[i].Value.b())
				{
					return age.df[i];
				}
			}
			return new KeyValuePair<uint, agf>(age.c, new agf((int)A_0, (int)A_0));
		}

		// Token: 0x06003296 RID: 12950 RVA: 0x001C2ADC File Offset: 0x001C1ADC
		internal static KeyValuePair<uint, agf> a()
		{
			return age.df[0];
		}

		// Token: 0x040017B1 RID: 6065
		internal static uint a = age.a('Z', 'y', 'y', 'y');

		// Token: 0x040017B2 RID: 6066
		internal static uint b = age.a('Z', 'i', 'n', 'h');

		// Token: 0x040017B3 RID: 6067
		internal static uint c = age.a('Z', 'z', 'z', 'z');

		// Token: 0x040017B4 RID: 6068
		internal static uint d = age.a('A', 'r', 'a', 'b');

		// Token: 0x040017B5 RID: 6069
		internal static uint e = age.a('A', 'r', 'm', 'n');

		// Token: 0x040017B6 RID: 6070
		internal static uint f = age.a('B', 'e', 'n', 'g');

		// Token: 0x040017B7 RID: 6071
		internal static uint g = age.a('C', 'y', 'r', 'l');

		// Token: 0x040017B8 RID: 6072
		internal static uint h = age.a('D', 'e', 'v', 'a');

		// Token: 0x040017B9 RID: 6073
		internal static uint i = age.a('G', 'e', 'o', 'r');

		// Token: 0x040017BA RID: 6074
		internal static uint j = age.a('G', 'r', 'e', 'k');

		// Token: 0x040017BB RID: 6075
		internal static uint k = age.a('G', 'u', 'j', 'r');

		// Token: 0x040017BC RID: 6076
		internal static uint l = age.a('G', 'u', 'r', 'u');

		// Token: 0x040017BD RID: 6077
		internal static uint m = age.a('H', 'a', 'n', 'g');

		// Token: 0x040017BE RID: 6078
		internal static uint n = age.a('H', 'a', 'n', 'i');

		// Token: 0x040017BF RID: 6079
		internal static uint o = age.a('H', 'e', 'b', 'r');

		// Token: 0x040017C0 RID: 6080
		internal static uint p = age.a('H', 'i', 'r', 'a');

		// Token: 0x040017C1 RID: 6081
		internal static uint q = age.a('K', 'n', 'd', 'a');

		// Token: 0x040017C2 RID: 6082
		internal static uint r = age.a('K', 'a', 'n', 'a');

		// Token: 0x040017C3 RID: 6083
		internal static uint s = age.a('L', 'a', 'o', 'o');

		// Token: 0x040017C4 RID: 6084
		internal static uint t = age.a('L', 'a', 't', 'n');

		// Token: 0x040017C5 RID: 6085
		internal static uint u = age.a('M', 'l', 'y', 'm');

		// Token: 0x040017C6 RID: 6086
		internal static uint v = age.a('O', 'r', 'y', 'a');

		// Token: 0x040017C7 RID: 6087
		internal static uint w = age.a('T', 'a', 'm', 'l');

		// Token: 0x040017C8 RID: 6088
		internal static uint x = age.a('T', 'e', 'l', 'u');

		// Token: 0x040017C9 RID: 6089
		internal static uint y = age.a('T', 'h', 'a', 'i');

		// Token: 0x040017CA RID: 6090
		internal static uint z = age.a('T', 'i', 'b', 't');

		// Token: 0x040017CB RID: 6091
		internal static uint aa = age.a('B', 'o', 'p', 'o');

		// Token: 0x040017CC RID: 6092
		internal static uint ab = age.a('B', 'r', 'a', 'i');

		// Token: 0x040017CD RID: 6093
		internal static uint ac = age.a('C', 'a', 'n', 's');

		// Token: 0x040017CE RID: 6094
		internal static uint ad = age.a('C', 'h', 'e', 'r');

		// Token: 0x040017CF RID: 6095
		internal static uint ae = age.a('E', 't', 'h', 'i');

		// Token: 0x040017D0 RID: 6096
		internal static uint af = age.a('K', 'h', 'm', 'r');

		// Token: 0x040017D1 RID: 6097
		internal static uint ag = age.a('M', 'o', 'n', 'g');

		// Token: 0x040017D2 RID: 6098
		internal static uint ah = age.a('M', 'y', 'm', 'r');

		// Token: 0x040017D3 RID: 6099
		internal static uint ai = age.a('O', 'g', 'a', 'm');

		// Token: 0x040017D4 RID: 6100
		internal static uint aj = age.a('R', 'u', 'n', 'r');

		// Token: 0x040017D5 RID: 6101
		internal static uint ak = age.a('S', 'i', 'n', 'h');

		// Token: 0x040017D6 RID: 6102
		internal static uint al = age.a('S', 'y', 'r', 'c');

		// Token: 0x040017D7 RID: 6103
		internal static uint am = age.a('T', 'h', 'a', 'a');

		// Token: 0x040017D8 RID: 6104
		internal static uint an = age.a('Y', 'i', 'i', 'i');

		// Token: 0x040017D9 RID: 6105
		internal static uint ao = age.a('D', 's', 'r', 't');

		// Token: 0x040017DA RID: 6106
		internal static uint ap = age.a('G', 'o', 't', 'h');

		// Token: 0x040017DB RID: 6107
		internal static uint aq = age.a('I', 't', 'a', 'l');

		// Token: 0x040017DC RID: 6108
		internal static uint ar = age.a('B', 'u', 'h', 'd');

		// Token: 0x040017DD RID: 6109
		internal static uint @as = age.a('H', 'a', 'n', 'o');

		// Token: 0x040017DE RID: 6110
		internal static uint at = age.a('T', 'g', 'l', 'g');

		// Token: 0x040017DF RID: 6111
		internal static uint au = age.a('T', 'a', 'g', 'b');

		// Token: 0x040017E0 RID: 6112
		internal static uint av = age.a('C', 'p', 'r', 't');

		// Token: 0x040017E1 RID: 6113
		internal static uint aw = age.a('L', 'i', 'm', 'b');

		// Token: 0x040017E2 RID: 6114
		internal static uint ax = age.a('L', 'i', 'n', 'b');

		// Token: 0x040017E3 RID: 6115
		internal static uint ay = age.a('O', 's', 'm', 'a');

		// Token: 0x040017E4 RID: 6116
		internal static uint az = age.a('S', 'h', 'a', 'w');

		// Token: 0x040017E5 RID: 6117
		internal static uint a0 = age.a('T', 'a', 'l', 'e');

		// Token: 0x040017E6 RID: 6118
		internal static uint a1 = age.a('U', 'g', 'a', 'r');

		// Token: 0x040017E7 RID: 6119
		internal static uint a2 = age.a('B', 'u', 'g', 'i');

		// Token: 0x040017E8 RID: 6120
		internal static uint a3 = age.a('C', 'o', 'p', 't');

		// Token: 0x040017E9 RID: 6121
		internal static uint a4 = age.a('G', 'l', 'a', 'g');

		// Token: 0x040017EA RID: 6122
		internal static uint a5 = age.a('K', 'h', 'a', 'r');

		// Token: 0x040017EB RID: 6123
		internal static uint a6 = age.a('T', 'a', 'l', 'u');

		// Token: 0x040017EC RID: 6124
		internal static uint a7 = age.a('X', 'p', 'e', 'o');

		// Token: 0x040017ED RID: 6125
		internal static uint a8 = age.a('S', 'y', 'l', 'o');

		// Token: 0x040017EE RID: 6126
		internal static uint a9 = age.a('T', 'f', 'n', 'g');

		// Token: 0x040017EF RID: 6127
		internal static uint ba = age.a('B', 'a', 'l', 'i');

		// Token: 0x040017F0 RID: 6128
		internal static uint bb = age.a('X', 's', 'u', 'x');

		// Token: 0x040017F1 RID: 6129
		internal static uint bc = age.a('N', 'k', 'o', 'o');

		// Token: 0x040017F2 RID: 6130
		internal static uint bd = age.a('P', 'h', 'a', 'g');

		// Token: 0x040017F3 RID: 6131
		internal static uint be = age.a('P', 'h', 'n', 'x');

		// Token: 0x040017F4 RID: 6132
		internal static uint bf = age.a('C', 'a', 'r', 'i');

		// Token: 0x040017F5 RID: 6133
		internal static uint bg = age.a('C', 'h', 'a', 'm');

		// Token: 0x040017F6 RID: 6134
		internal static uint bh = age.a('K', 'a', 'l', 'i');

		// Token: 0x040017F7 RID: 6135
		internal static uint bi = age.a('L', 'e', 'p', 'c');

		// Token: 0x040017F8 RID: 6136
		internal static uint bj = age.a('L', 'y', 'c', 'i');

		// Token: 0x040017F9 RID: 6137
		internal static uint bk = age.a('L', 'y', 'd', 'i');

		// Token: 0x040017FA RID: 6138
		internal static uint bl = age.a('O', 'l', 'c', 'k');

		// Token: 0x040017FB RID: 6139
		internal static uint bm = age.a('R', 'j', 'n', 'g');

		// Token: 0x040017FC RID: 6140
		internal static uint bn = age.a('S', 'a', 'u', 'r');

		// Token: 0x040017FD RID: 6141
		internal static uint bo = age.a('S', 'u', 'n', 'd');

		// Token: 0x040017FE RID: 6142
		internal static uint bp = age.a('V', 'a', 'i', 'i');

		// Token: 0x040017FF RID: 6143
		internal static uint bq = age.a('A', 'v', 's', 't');

		// Token: 0x04001800 RID: 6144
		internal static uint br = age.a('B', 'a', 'm', 'u');

		// Token: 0x04001801 RID: 6145
		internal static uint bs = age.a('E', 'g', 'y', 'p');

		// Token: 0x04001802 RID: 6146
		internal static uint bt = age.a('A', 'r', 'm', 'i');

		// Token: 0x04001803 RID: 6147
		internal static uint bu = age.a('P', 'h', 'l', 'i');

		// Token: 0x04001804 RID: 6148
		internal static uint bv = age.a('P', 'r', 't', 'i');

		// Token: 0x04001805 RID: 6149
		internal static uint bw = age.a('J', 'a', 'v', 'a');

		// Token: 0x04001806 RID: 6150
		internal static uint bx = age.a('K', 't', 'h', 'i');

		// Token: 0x04001807 RID: 6151
		internal static uint by = age.a('L', 'i', 's', 'u');

		// Token: 0x04001808 RID: 6152
		internal static uint bz = age.a('M', 't', 'e', 'i');

		// Token: 0x04001809 RID: 6153
		internal static uint b0 = age.a('S', 'a', 'r', 'b');

		// Token: 0x0400180A RID: 6154
		internal static uint b1 = age.a('O', 'r', 'k', 'h');

		// Token: 0x0400180B RID: 6155
		internal static uint b2 = age.a('S', 'a', 'm', 'r');

		// Token: 0x0400180C RID: 6156
		internal static uint b3 = age.a('L', 'a', 'n', 'a');

		// Token: 0x0400180D RID: 6157
		internal static uint b4 = age.a('T', 'a', 'v', 't');

		// Token: 0x0400180E RID: 6158
		internal static uint b5 = age.a('B', 'a', 't', 'k');

		// Token: 0x0400180F RID: 6159
		internal static uint b6 = age.a('B', 'r', 'a', 'h');

		// Token: 0x04001810 RID: 6160
		internal static uint b7 = age.a('M', 'a', 'n', 'd');

		// Token: 0x04001811 RID: 6161
		internal static uint b8 = age.a('C', 'a', 'k', 'm');

		// Token: 0x04001812 RID: 6162
		internal static uint b9 = age.a('M', 'e', 'r', 'c');

		// Token: 0x04001813 RID: 6163
		internal static uint ca = age.a('M', 'e', 'r', 'o');

		// Token: 0x04001814 RID: 6164
		internal static uint cb = age.a('P', 'l', 'r', 'd');

		// Token: 0x04001815 RID: 6165
		internal static uint cc = age.a('S', 'h', 'r', 'd');

		// Token: 0x04001816 RID: 6166
		internal static uint cd = age.a('S', 'o', 'r', 'a');

		// Token: 0x04001817 RID: 6167
		internal static uint ce = age.a('T', 'a', 'k', 'r');

		// Token: 0x04001818 RID: 6168
		internal static uint cf = age.a('B', 'a', 's', 's');

		// Token: 0x04001819 RID: 6169
		internal static uint cg = age.a('A', 'g', 'h', 'b');

		// Token: 0x0400181A RID: 6170
		internal static uint ch = age.a('D', 'u', 'p', 'l');

		// Token: 0x0400181B RID: 6171
		internal static uint ci = age.a('E', 'l', 'b', 'a');

		// Token: 0x0400181C RID: 6172
		internal static uint cj = age.a('G', 'r', 'a', 'n');

		// Token: 0x0400181D RID: 6173
		internal static uint ck = age.a('K', 'h', 'o', 'j');

		// Token: 0x0400181E RID: 6174
		internal static uint cl = age.a('S', 'i', 'n', 'd');

		// Token: 0x0400181F RID: 6175
		internal static uint cm = age.a('L', 'i', 'n', 'a');

		// Token: 0x04001820 RID: 6176
		internal static uint cn = age.a('M', 'a', 'h', 'j');

		// Token: 0x04001821 RID: 6177
		internal static uint co = age.a('M', 'a', 'n', 'i');

		// Token: 0x04001822 RID: 6178
		internal static uint cp = age.a('M', 'e', 'n', 'd');

		// Token: 0x04001823 RID: 6179
		internal static uint cq = age.a('M', 'o', 'd', 'i');

		// Token: 0x04001824 RID: 6180
		internal static uint cr = age.a('M', 'r', 'o', 'o');

		// Token: 0x04001825 RID: 6181
		internal static uint cs = age.a('N', 'b', 'a', 't');

		// Token: 0x04001826 RID: 6182
		internal static uint ct = age.a('N', 'a', 'r', 'b');

		// Token: 0x04001827 RID: 6183
		internal static uint cu = age.a('P', 'e', 'r', 'm');

		// Token: 0x04001828 RID: 6184
		internal static uint cv = age.a('H', 'm', 'n', 'g');

		// Token: 0x04001829 RID: 6185
		internal static uint cw = age.a('P', 'a', 'l', 'm');

		// Token: 0x0400182A RID: 6186
		internal static uint cx = age.a('P', 'a', 'u', 'c');

		// Token: 0x0400182B RID: 6187
		internal static uint cy = age.a('P', 'h', 'l', 'p');

		// Token: 0x0400182C RID: 6188
		internal static uint cz = age.a('S', 'i', 'd', 'd');

		// Token: 0x0400182D RID: 6189
		internal static uint c0 = age.a('T', 'i', 'r', 'h');

		// Token: 0x0400182E RID: 6190
		internal static uint c1 = age.a('W', 'a', 'r', 'a');

		// Token: 0x0400182F RID: 6191
		internal static uint c2 = age.a('A', 'h', 'o', 'm');

		// Token: 0x04001830 RID: 6192
		internal static uint c3 = age.a('H', 'l', 'u', 'w');

		// Token: 0x04001831 RID: 6193
		internal static uint c4 = age.a('H', 'a', 't', 'r');

		// Token: 0x04001832 RID: 6194
		internal static uint c5 = age.a('M', 'u', 'l', 't');

		// Token: 0x04001833 RID: 6195
		internal static uint c6 = age.a('H', 'u', 'n', 'g');

		// Token: 0x04001834 RID: 6196
		internal static uint c7 = age.a('S', 'g', 'n', 'w');

		// Token: 0x04001835 RID: 6197
		internal static uint c8 = age.a('A', 'd', 'l', 'm');

		// Token: 0x04001836 RID: 6198
		internal static uint c9 = age.a('B', 'h', 'k', 's');

		// Token: 0x04001837 RID: 6199
		internal static uint da = age.a('M', 'a', 'r', 'c');

		// Token: 0x04001838 RID: 6200
		internal static uint db = age.a('O', 's', 'g', 'e');

		// Token: 0x04001839 RID: 6201
		internal static uint dc = age.a('T', 'a', 'n', 'g');

		// Token: 0x0400183A RID: 6202
		internal static uint dd = age.a('N', 'e', 'w', 'a');

		// Token: 0x0400183B RID: 6203
		internal static uint de = 0U;

		// Token: 0x0400183C RID: 6204
		internal static readonly KeyValuePair<uint, agf>[] df = new KeyValuePair<uint, agf>[]
		{
			new KeyValuePair<uint, agf>(age.t, new agf(0, 127)),
			new KeyValuePair<uint, agf>(age.d, new agf(1536, 1791)),
			new KeyValuePair<uint, agf>(age.e, new agf(1328, 1423)),
			new KeyValuePair<uint, agf>(age.ba, new agf(6912, 7039)),
			new KeyValuePair<uint, agf>(age.f, new agf(2432, 2559)),
			new KeyValuePair<uint, agf>(age.aa, new agf(12544, 12591)),
			new KeyValuePair<uint, agf>(age.ab, new agf(10240, 10495)),
			new KeyValuePair<uint, agf>(age.a2, new agf(6656, 6687)),
			new KeyValuePair<uint, agf>(age.ar, new agf(5952, 5983)),
			new KeyValuePair<uint, agf>(age.ac, new agf(6320, 6399)),
			new KeyValuePair<uint, agf>(age.bf, new agf(66208, 66271)),
			new KeyValuePair<uint, agf>(age.bg, new agf(43520, 43615)),
			new KeyValuePair<uint, agf>(age.ad, new agf(5024, 5119)),
			new KeyValuePair<uint, agf>(age.n, new agf(65535, 65535)),
			new KeyValuePair<uint, agf>(age.a3, new agf(11392, 11519)),
			new KeyValuePair<uint, agf>(age.av, new agf(67584, 67647)),
			new KeyValuePair<uint, agf>(age.g, new agf(1024, 1279)),
			new KeyValuePair<uint, agf>(age.ao, new agf(66560, 66639)),
			new KeyValuePair<uint, agf>(age.h, new agf(2304, 2431)),
			new KeyValuePair<uint, agf>(age.ae, new agf(4608, 4799)),
			new KeyValuePair<uint, agf>(age.i, new agf(4256, 4351)),
			new KeyValuePair<uint, agf>(age.a4, new agf(11264, 11359)),
			new KeyValuePair<uint, agf>(age.ap, new agf(66352, 66383)),
			new KeyValuePair<uint, agf>(age.j, new agf(880, 1023)),
			new KeyValuePair<uint, agf>(age.k, new agf(2688, 2815)),
			new KeyValuePair<uint, agf>(age.l, new agf(2560, 2687)),
			new KeyValuePair<uint, agf>(age.m, new agf(44032, 55215)),
			new KeyValuePair<uint, agf>(age.@as, new agf(5920, 5951)),
			new KeyValuePair<uint, agf>(age.o, new agf(1424, 1535)),
			new KeyValuePair<uint, agf>(age.r, new agf(12352, 12447)),
			new KeyValuePair<uint, agf>(age.bw, new agf(43392, 43487)),
			new KeyValuePair<uint, agf>(age.q, new agf(3200, 3327)),
			new KeyValuePair<uint, agf>(age.bh, new agf(43264, 43311)),
			new KeyValuePair<uint, agf>(age.a5, new agf(68096, 68191)),
			new KeyValuePair<uint, agf>(age.af, new agf(6016, 6143)),
			new KeyValuePair<uint, agf>(age.s, new agf(3712, 3839)),
			new KeyValuePair<uint, agf>(age.bi, new agf(7168, 7247)),
			new KeyValuePair<uint, agf>(age.aw, new agf(6400, 6479)),
			new KeyValuePair<uint, agf>(age.ax, new agf(65536, 65663)),
			new KeyValuePair<uint, agf>(age.bj, new agf(66176, 66207)),
			new KeyValuePair<uint, agf>(age.bk, new agf(67872, 67903)),
			new KeyValuePair<uint, agf>(age.u, new agf(3328, 3455)),
			new KeyValuePair<uint, agf>(age.ag, new agf(6144, 6319)),
			new KeyValuePair<uint, agf>(age.ah, new agf(4096, 4255)),
			new KeyValuePair<uint, agf>(age.a6, new agf(6528, 6623)),
			new KeyValuePair<uint, agf>(age.bc, new agf(1984, 2047)),
			new KeyValuePair<uint, agf>(age.ai, new agf(5760, 5791)),
			new KeyValuePair<uint, agf>(age.bl, new agf(7248, 7295)),
			new KeyValuePair<uint, agf>(age.aq, new agf(66304, 66351)),
			new KeyValuePair<uint, agf>(age.a7, new agf(66464, 66517)),
			new KeyValuePair<uint, agf>(age.v, new agf(2816, 2943)),
			new KeyValuePair<uint, agf>(age.ay, new agf(66688, 66735)),
			new KeyValuePair<uint, agf>(age.bd, new agf(43072, 43135)),
			new KeyValuePair<uint, agf>(age.be, new agf(67840, 67871)),
			new KeyValuePair<uint, agf>(age.bm, new agf(43312, 43359)),
			new KeyValuePair<uint, agf>(age.aj, new agf(5792, 5887)),
			new KeyValuePair<uint, agf>(age.bn, new agf(43136, 43231)),
			new KeyValuePair<uint, agf>(age.az, new agf(66640, 66687)),
			new KeyValuePair<uint, agf>(age.ak, new agf(3456, 3583)),
			new KeyValuePair<uint, agf>(age.bb, new agf(73728, 74751)),
			new KeyValuePair<uint, agf>(age.bo, new agf(7040, 7103)),
			new KeyValuePair<uint, agf>(age.a8, new agf(43008, 43055)),
			new KeyValuePair<uint, agf>(age.al, new agf(1792, 1871)),
			new KeyValuePair<uint, agf>(age.at, new agf(5888, 5919)),
			new KeyValuePair<uint, agf>(age.au, new agf(5984, 6015)),
			new KeyValuePair<uint, agf>(age.a0, new agf(6480, 6527)),
			new KeyValuePair<uint, agf>(age.w, new agf(2944, 3071)),
			new KeyValuePair<uint, agf>(age.x, new agf(3072, 3199)),
			new KeyValuePair<uint, agf>(age.am, new agf(1920, 1983)),
			new KeyValuePair<uint, agf>(age.y, new agf(3584, 3711)),
			new KeyValuePair<uint, agf>(age.z, new agf(3840, 4095)),
			new KeyValuePair<uint, agf>(age.a9, new agf(11568, 11647)),
			new KeyValuePair<uint, agf>(age.a1, new agf(66432, 66463)),
			new KeyValuePair<uint, agf>(age.bp, new agf(42240, 42559)),
			new KeyValuePair<uint, agf>(age.an, new agf(40960, 42127))
		};
	}
}
