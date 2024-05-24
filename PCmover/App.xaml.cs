using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows;
using Microsoft.Win32;
using PcmBrandUI.Properties;
using WizardModule;

namespace PCmover
{
	// Token: 0x02000002 RID: 2
	public partial class App : Application
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public App()
		{
			bool flag;
			this.m = new Mutex(true, "5BA4C875-7C0E-44A3-9733-90AD5756F82C", ref flag);
			if (!flag)
			{
				Environment.Exit(0);
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002080 File Offset: 0x00000280
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			WizardParameters wizardParameters = new WizardParameters(e);
			if (!wizardParameters.NoSplash)
			{
				Assembly assembly = Assembly.GetAssembly(typeof(Resources));
				wizardParameters.SplashScreen = new SplashScreen(assembly, "Resources\\splash.png");
				wizardParameters.SplashScreen.Show(false, true);
			}
			try
			{
				string text = string.Empty;
				using (RegistryKey localMachine = Registry.LocalMachine)
				{
					RegistryKey registryKey = localMachine.OpenSubKey("Software\\Wow6432Node\\Laplink\\PCmover\\Install", false);
					if (registryKey == null)
					{
						registryKey = localMachine.OpenSubKey("Software\\Laplink\\PCmover\\Install", false);
					}
					if (registryKey != null)
					{
						object value = registryKey.GetValue("Culture");
						text = ((value != null) ? value.ToString() : null);
						registryKey.Close();
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					Thread.CurrentThread.CurrentCulture = new CultureInfo(text);
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(text);
				}
			}
			catch
			{
			}
			new Bootstrapper(wizardParameters).Run();
			SplashScreen splashScreen = wizardParameters.SplashScreen;
			if (splashScreen != null)
			{
				splashScreen.Close(new TimeSpan(0, 0, 0, 1, 500));
			}
			wizardParameters.SplashScreen = null;
		}

		// Token: 0x04000001 RID: 1
		private Mutex m;
	}
}
