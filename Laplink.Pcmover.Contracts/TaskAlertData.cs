using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000072 RID: 114
	public class TaskAlertData
	{
		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000313 RID: 787 RVA: 0x00003E01 File Offset: 0x00002001
		// (set) Token: 0x06000314 RID: 788 RVA: 0x00003E09 File Offset: 0x00002009
		public TaskAlertData.AlertType Type { get; set; }

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000315 RID: 789 RVA: 0x00003E12 File Offset: 0x00002012
		// (set) Token: 0x06000316 RID: 790 RVA: 0x00003E1A File Offset: 0x0000201A
		public string User { get; set; }

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000317 RID: 791 RVA: 0x00003E23 File Offset: 0x00002023
		// (set) Token: 0x06000318 RID: 792 RVA: 0x00003E2B File Offset: 0x0000202B
		public string Email { get; set; }

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000319 RID: 793 RVA: 0x00003E34 File Offset: 0x00002034
		// (set) Token: 0x0600031A RID: 794 RVA: 0x00003E3C File Offset: 0x0000203C
		public string Message { get; set; }

		// Token: 0x0600031B RID: 795 RVA: 0x00003E45 File Offset: 0x00002045
		public TaskAlertData()
		{
			this.Type = TaskAlertData.AlertType.Done;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00003E54 File Offset: 0x00002054
		public TaskAlertData(string user, string email, string message, TaskAlertData.AlertType type = TaskAlertData.AlertType.Done)
		{
			this.Type = type;
			this.User = user;
			this.Email = email;
			this.Message = message;
		}

		// Token: 0x0200009F RID: 159
		public enum AlertType
		{
			// Token: 0x0400040E RID: 1038
			None,
			// Token: 0x0400040F RID: 1039
			Done
		}
	}
}
