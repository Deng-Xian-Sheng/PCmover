using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MainUI.Properties
{
	// Token: 0x0200001D RID: 29
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.5.0.0")]
	public sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x0000702D File Offset: 0x0000522D
		// (set) Token: 0x060001E9 RID: 489 RVA: 0x0000703F File Offset: 0x0000523F
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public StringCollection Folders
		{
			get
			{
				return (StringCollection)this["Folders"];
			}
			set
			{
				this["Folders"] = value;
			}
		}
	}
}
