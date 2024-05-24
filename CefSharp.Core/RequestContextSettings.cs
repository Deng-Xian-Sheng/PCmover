using System;
using CefSharp.Core;

namespace CefSharp
{
	// Token: 0x0200000D RID: 13
	public class RequestContextSettings
	{
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00003112 File Offset: 0x00001312
		// (set) Token: 0x06000107 RID: 263 RVA: 0x0000311F File Offset: 0x0000131F
		public bool PersistSessionCookies
		{
			get
			{
				return this.settings.PersistSessionCookies;
			}
			set
			{
				this.settings.PersistSessionCookies = value;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000108 RID: 264 RVA: 0x0000312D File Offset: 0x0000132D
		// (set) Token: 0x06000109 RID: 265 RVA: 0x0000313A File Offset: 0x0000133A
		public bool PersistUserPreferences
		{
			get
			{
				return this.settings.PersistUserPreferences;
			}
			set
			{
				this.settings.PersistUserPreferences = value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00003148 File Offset: 0x00001348
		// (set) Token: 0x0600010B RID: 267 RVA: 0x00003155 File Offset: 0x00001355
		public string CachePath
		{
			get
			{
				return this.settings.CachePath;
			}
			set
			{
				this.settings.CachePath = value;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00003163 File Offset: 0x00001363
		// (set) Token: 0x0600010D RID: 269 RVA: 0x00003170 File Offset: 0x00001370
		public string AcceptLanguageList
		{
			get
			{
				return this.settings.AcceptLanguageList;
			}
			set
			{
				this.settings.AcceptLanguageList = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600010E RID: 270 RVA: 0x0000317E File Offset: 0x0000137E
		// (set) Token: 0x0600010F RID: 271 RVA: 0x0000318B File Offset: 0x0000138B
		public string CookieableSchemesList
		{
			get
			{
				return this.settings.CookieableSchemesList;
			}
			set
			{
				this.settings.CookieableSchemesList = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000110 RID: 272 RVA: 0x00003199 File Offset: 0x00001399
		// (set) Token: 0x06000111 RID: 273 RVA: 0x000031A6 File Offset: 0x000013A6
		public bool CookieableSchemesExcludeDefaults
		{
			get
			{
				return this.settings.CookieableSchemesExcludeDefaults;
			}
			set
			{
				this.settings.CookieableSchemesExcludeDefaults = value;
			}
		}

		// Token: 0x0400000B RID: 11
		internal RequestContextSettings settings = new RequestContextSettings();
	}
}
