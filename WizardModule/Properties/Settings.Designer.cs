using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace WizardModule.Properties
{
	// Token: 0x02000008 RID: 8
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.6.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700037E RID: 894
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x0000822C File Offset: 0x0000642C
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400002C RID: 44
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
