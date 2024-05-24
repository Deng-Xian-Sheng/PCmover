using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Prism.Unity.Properties
{
	// Token: 0x02000009 RID: 9
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000032 RID: 50 RVA: 0x0000297B File Offset: 0x00000B7B
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
