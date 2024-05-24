using System;
using System.Runtime.CompilerServices;

namespace RestSharp
{
	// Token: 0x0200000E RID: 14
	[NullableContext(1)]
	[Nullable(0)]
	[Obsolete("The HttpCooking class will be removed in future versions")]
	public class HttpCookie
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600009B RID: 155 RVA: 0x000037CC File Offset: 0x000019CC
		// (set) Token: 0x0600009C RID: 156 RVA: 0x000037D4 File Offset: 0x000019D4
		public string Comment { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600009D RID: 157 RVA: 0x000037DD File Offset: 0x000019DD
		// (set) Token: 0x0600009E RID: 158 RVA: 0x000037E5 File Offset: 0x000019E5
		public Uri CommentUri { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600009F RID: 159 RVA: 0x000037EE File Offset: 0x000019EE
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x000037F6 File Offset: 0x000019F6
		public bool Discard { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x000037FF File Offset: 0x000019FF
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x00003807 File Offset: 0x00001A07
		public string Domain { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00003810 File Offset: 0x00001A10
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x00003818 File Offset: 0x00001A18
		public bool Expired { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00003821 File Offset: 0x00001A21
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00003829 File Offset: 0x00001A29
		public DateTime Expires { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00003832 File Offset: 0x00001A32
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x0000383A File Offset: 0x00001A3A
		public bool HttpOnly { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00003843 File Offset: 0x00001A43
		// (set) Token: 0x060000AA RID: 170 RVA: 0x0000384B File Offset: 0x00001A4B
		public string Name { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00003854 File Offset: 0x00001A54
		// (set) Token: 0x060000AC RID: 172 RVA: 0x0000385C File Offset: 0x00001A5C
		public string Path { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00003865 File Offset: 0x00001A65
		// (set) Token: 0x060000AE RID: 174 RVA: 0x0000386D File Offset: 0x00001A6D
		public string Port { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000AF RID: 175 RVA: 0x00003876 File Offset: 0x00001A76
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x0000387E File Offset: 0x00001A7E
		public bool Secure { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00003887 File Offset: 0x00001A87
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x0000388F File Offset: 0x00001A8F
		public DateTime TimeStamp { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00003898 File Offset: 0x00001A98
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x000038A0 File Offset: 0x00001AA0
		public string Value { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x000038A9 File Offset: 0x00001AA9
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x000038B1 File Offset: 0x00001AB1
		public int Version { get; set; }
	}
}
