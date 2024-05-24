using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace PCmover.Properties
{
	// Token: 0x02000005 RID: 5
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.6.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002A19 File Offset: 0x00000C19
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000007 RID: 7
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
