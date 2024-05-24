using System;
using System.ComponentModel;
using System.Diagnostics;
using CefSharp.Enums;

namespace CefSharp
{
	// Token: 0x0200001D RID: 29
	[DebuggerDisplay("Domain = {Domain}, Path = {Path}, Name = {Name}, Secure = {Secure}, HttpOnly = {HttpOnly},Creation = {Creation}, Expires = {Expires}, LastAccess = {LastAccess}", Name = "Cookie")]
	public sealed class Cookie
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00002895 File Offset: 0x00000A95
		// (set) Token: 0x06000084 RID: 132 RVA: 0x0000289D File Offset: 0x00000A9D
		public string Name { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000085 RID: 133 RVA: 0x000028A6 File Offset: 0x00000AA6
		// (set) Token: 0x06000086 RID: 134 RVA: 0x000028AE File Offset: 0x00000AAE
		public string Value { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000087 RID: 135 RVA: 0x000028B7 File Offset: 0x00000AB7
		// (set) Token: 0x06000088 RID: 136 RVA: 0x000028BF File Offset: 0x00000ABF
		public string Domain { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000089 RID: 137 RVA: 0x000028C8 File Offset: 0x00000AC8
		// (set) Token: 0x0600008A RID: 138 RVA: 0x000028D0 File Offset: 0x00000AD0
		public string Path { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600008B RID: 139 RVA: 0x000028D9 File Offset: 0x00000AD9
		// (set) Token: 0x0600008C RID: 140 RVA: 0x000028E1 File Offset: 0x00000AE1
		public bool Secure { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000028EA File Offset: 0x00000AEA
		// (set) Token: 0x0600008E RID: 142 RVA: 0x000028F2 File Offset: 0x00000AF2
		public bool HttpOnly { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600008F RID: 143 RVA: 0x000028FB File Offset: 0x00000AFB
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00002903 File Offset: 0x00000B03
		public DateTime? Expires { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000091 RID: 145 RVA: 0x0000290C File Offset: 0x00000B0C
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00002914 File Offset: 0x00000B14
		public DateTime Creation { get; private set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000093 RID: 147 RVA: 0x0000291D File Offset: 0x00000B1D
		// (set) Token: 0x06000094 RID: 148 RVA: 0x00002925 File Offset: 0x00000B25
		public DateTime LastAccess { get; private set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000095 RID: 149 RVA: 0x0000292E File Offset: 0x00000B2E
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00002936 File Offset: 0x00000B36
		public CookieSameSite SameSite { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000097 RID: 151 RVA: 0x0000293F File Offset: 0x00000B3F
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00002947 File Offset: 0x00000B47
		public CookiePriority Priority { get; set; }

		// Token: 0x06000099 RID: 153 RVA: 0x00002950 File Offset: 0x00000B50
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetCreationDate(DateTime dateTime)
		{
			this.Creation = dateTime;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00002959 File Offset: 0x00000B59
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetLastAccessDate(DateTime dateTime)
		{
			this.LastAccess = dateTime;
		}
	}
}
