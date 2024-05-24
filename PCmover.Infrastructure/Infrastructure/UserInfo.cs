using System;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x0200003C RID: 60
	public class UserInfo
	{
		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060002FA RID: 762 RVA: 0x000083F7 File Offset: 0x000065F7
		// (set) Token: 0x060002FB RID: 763 RVA: 0x000083FF File Offset: 0x000065FF
		public string OldUsername { get; set; }

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060002FC RID: 764 RVA: 0x00008408 File Offset: 0x00006608
		// (set) Token: 0x060002FD RID: 765 RVA: 0x00008410 File Offset: 0x00006610
		public string NewUsername { get; set; }

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060002FE RID: 766 RVA: 0x00008419 File Offset: 0x00006619
		// (set) Token: 0x060002FF RID: 767 RVA: 0x00008421 File Offset: 0x00006621
		public UserType UserType { get; set; }

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000300 RID: 768 RVA: 0x0000842A File Offset: 0x0000662A
		// (set) Token: 0x06000301 RID: 769 RVA: 0x00008432 File Offset: 0x00006632
		public bool Create { get; set; }
	}
}
