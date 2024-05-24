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
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00006FE6 File Offset: 0x000051E6
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x00006FED File Offset: 0x000051ED
		// (set) Token: 0x060001E5 RID: 485 RVA: 0x00006FFF File Offset: 0x000051FF
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Source
		{
			get
			{
				return (string)this["Source"];
			}
			set
			{
				this["Source"] = value;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x0000700D File Offset: 0x0000520D
		// (set) Token: 0x060001E7 RID: 487 RVA: 0x0000701F File Offset: 0x0000521F
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Destination
		{
			get
			{
				return (string)this["Destination"];
			}
			set
			{
				this["Destination"] = value;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x060001EA RID: 490 RVA: 0x0000704D File Offset: 0x0000524D
		// (set) Token: 0x060001EB RID: 491 RVA: 0x0000705F File Offset: 0x0000525F
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string SourceDrive
		{
			get
			{
				return (string)this["SourceDrive"];
			}
			set
			{
				this["SourceDrive"] = value;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x060001EC RID: 492 RVA: 0x0000706D File Offset: 0x0000526D
		// (set) Token: 0x060001ED RID: 493 RVA: 0x0000707F File Offset: 0x0000527F
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string DestinationDrive
		{
			get
			{
				return (string)this["DestinationDrive"];
			}
			set
			{
				this["DestinationDrive"] = value;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060001EE RID: 494 RVA: 0x0000708D File Offset: 0x0000528D
		// (set) Token: 0x060001EF RID: 495 RVA: 0x0000709F File Offset: 0x0000529F
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string FirstName
		{
			get
			{
				return (string)this["FirstName"];
			}
			set
			{
				this["FirstName"] = value;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x000070AD File Offset: 0x000052AD
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x000070BF File Offset: 0x000052BF
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string LastName
		{
			get
			{
				return (string)this["LastName"];
			}
			set
			{
				this["LastName"] = value;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x000070CD File Offset: 0x000052CD
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x000070DF File Offset: 0x000052DF
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Email
		{
			get
			{
				return (string)this["Email"];
			}
			set
			{
				this["Email"] = value;
			}
		}

		// Token: 0x040000AA RID: 170
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
