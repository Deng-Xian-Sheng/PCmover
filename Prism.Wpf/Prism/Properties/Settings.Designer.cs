using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Prism.Properties
{
	// Token: 0x02000045 RID: 69
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000218 RID: 536 RVA: 0x000064E4 File Offset: 0x000046E4
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000062 RID: 98
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
