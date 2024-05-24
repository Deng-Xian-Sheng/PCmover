using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200009A RID: 154
	public class UserMappings
	{
		// Token: 0x06000405 RID: 1029 RVA: 0x00004930 File Offset: 0x00002B30
		public UserMappings()
		{
			this.Settings = new UserMapSettings();
			this.Mappings = new List<UserMapping>();
			this.UnusedOnNew = new List<UserDetail>();
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00004959 File Offset: 0x00002B59
		public UserMappings(IEnumerable<UserMapping> mappings)
		{
			this.Settings = new UserMapSettings();
			this.Mappings = mappings;
			this.UnusedOnNew = new List<UserDetail>();
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000497E File Offset: 0x00002B7E
		public UserMappings(UserMapSettings settings, IEnumerable<UserMapping> mappings, IEnumerable<UserDetail> unusedOnNew)
		{
			this.Settings = settings;
			this.Mappings = mappings;
			this.UnusedOnNew = unusedOnNew;
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x0000499B File Offset: 0x00002B9B
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x000049A3 File Offset: 0x00002BA3
		public UserMapSettings Settings { get; set; }

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x000049AC File Offset: 0x00002BAC
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x000049B4 File Offset: 0x00002BB4
		public IEnumerable<UserMapping> Mappings { get; set; }

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x000049BD File Offset: 0x00002BBD
		// (set) Token: 0x0600040D RID: 1037 RVA: 0x000049C5 File Offset: 0x00002BC5
		public IEnumerable<UserDetail> UnusedOnNew { get; set; }
	}
}
