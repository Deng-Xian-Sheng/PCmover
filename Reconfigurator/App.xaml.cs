using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using Laplink.Tools.Helpers;

namespace Reconfigurator
{
	// Token: 0x02000003 RID: 3
	public partial class App : Application
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000020C3 File Offset: 0x000002C3
		protected override void OnStartup(StartupEventArgs e)
		{
			LlTraceSource llTraceSource = new LlTraceSource("Reconfigurator");
			llTraceSource.InitLoggingFromAppData("Laplink\\Reconfigurator\\Reconfigurator.log");
			base.OnStartup(e);
			new Bootstrapper(llTraceSource).Run();
		}
	}
}
