using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000096 RID: 150
	public class UserDetail
	{
		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x0000471C File Offset: 0x0000291C
		// (set) Token: 0x060003D9 RID: 985 RVA: 0x00004724 File Offset: 0x00002924
		public string AccountName { get; set; }

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060003DA RID: 986 RVA: 0x0000472D File Offset: 0x0000292D
		// (set) Token: 0x060003DB RID: 987 RVA: 0x00004735 File Offset: 0x00002935
		public string FullName { get; set; }

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060003DC RID: 988 RVA: 0x0000473E File Offset: 0x0000293E
		// (set) Token: 0x060003DD RID: 989 RVA: 0x00004746 File Offset: 0x00002946
		public string FriendlyName { get; set; }

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060003DE RID: 990 RVA: 0x0000474F File Offset: 0x0000294F
		// (set) Token: 0x060003DF RID: 991 RVA: 0x00004757 File Offset: 0x00002957
		public UserType UserType { get; set; }

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x00004760 File Offset: 0x00002960
		// (set) Token: 0x060003E1 RID: 993 RVA: 0x00004768 File Offset: 0x00002968
		public bool IsCurrentUser { get; set; }

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x00004771 File Offset: 0x00002971
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x00004779 File Offset: 0x00002979
		public bool IsAzureAdUser { get; set; }

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x00004782 File Offset: 0x00002982
		// (set) Token: 0x060003E5 RID: 997 RVA: 0x0000478A File Offset: 0x0000298A
		public bool IsRegularUser { get; set; }

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x00004793 File Offset: 0x00002993
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x0000479B File Offset: 0x0000299B
		public List<MapiProfile> MapiProfiles { get; set; }

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x000047A4 File Offset: 0x000029A4
		public bool IsDomainUser
		{
			get
			{
				return this.FriendlyName != null && this.FriendlyName.Contains("\\");
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x000047C0 File Offset: 0x000029C0
		public string Domain
		{
			get
			{
				if (this.FriendlyName == null)
				{
					return null;
				}
				int num = this.FriendlyName.IndexOf('\\');
				if (num < 0)
				{
					return null;
				}
				return this.FriendlyName.Substring(0, num);
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x000047F8 File Offset: 0x000029F8
		public string UserName
		{
			get
			{
				if (this.FriendlyName == null)
				{
					return this.AccountName;
				}
				int num = this.FriendlyName.IndexOf('\\');
				if (num < 0)
				{
					return this.AccountName;
				}
				return this.FriendlyName.Substring(num + 1);
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060003EB RID: 1003 RVA: 0x0000483B File Offset: 0x00002A3B
		public string DisplayName
		{
			get
			{
				if (string.IsNullOrEmpty(this.FriendlyName))
				{
					return this.AccountName;
				}
				if (this.IsAzureAdUser)
				{
					return this.FriendlyName + " (AAD)";
				}
				return this.FriendlyName;
			}
		}
	}
}
