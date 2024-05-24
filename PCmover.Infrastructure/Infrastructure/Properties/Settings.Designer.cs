using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace PCmover.Infrastructure.Properties
{
	// Token: 0x02000043 RID: 67
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.6.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000167 RID: 359
		// (get) Token: 0x0600036C RID: 876 RVA: 0x00008D41 File Offset: 0x00006F41
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400013B RID: 315
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
