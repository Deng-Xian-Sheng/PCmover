using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace ThankYou
{
	// Token: 0x02000006 RID: 6
	public partial class App : Application
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002600 File Offset: 0x00000800
		public App()
		{
			bool flag;
			this.m = new Mutex(true, "3EA5D847-3A0E-84B3-3247-40ED9476A81B", ref flag);
			if (!flag)
			{
				Environment.Exit(0);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000262F File Offset: 0x0000082F
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			new Bootstrapper().Run();
		}

		// Token: 0x04000003 RID: 3
		private Mutex m;
	}
}
