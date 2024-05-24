using System;

namespace MahApps.Metro
{
	// Token: 0x02000008 RID: 8
	public class OnThemeChangedEventArgs : EventArgs
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00002F18 File Offset: 0x00001118
		public OnThemeChangedEventArgs(AppTheme appTheme, Accent accent)
		{
			this.AppTheme = appTheme;
			this.Accent = accent;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002F2E File Offset: 0x0000112E
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00002F36 File Offset: 0x00001136
		public AppTheme AppTheme { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002F3F File Offset: 0x0000113F
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00002F47 File Offset: 0x00001147
		public Accent Accent { get; set; }
	}
}
