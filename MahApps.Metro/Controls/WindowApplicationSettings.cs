using System;
using System.Configuration;
using System.Windows;
using ControlzEx.Standard;

namespace MahApps.Metro.Controls
{
	// Token: 0x0200009E RID: 158
	internal partial class WindowApplicationSettings : ApplicationSettingsBase, IWindowPlacementSettings
	{
		// Token: 0x06000892 RID: 2194 RVA: 0x00022840 File Offset: 0x00020A40
		public WindowApplicationSettings(Window window) : base(window.GetType().FullName)
		{
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000893 RID: 2195 RVA: 0x00022853 File Offset: 0x00020A53
		// (set) Token: 0x06000894 RID: 2196 RVA: 0x00022874 File Offset: 0x00020A74
		[UserScopedSetting]
		public WINDOWPLACEMENT Placement
		{
			get
			{
				if (this["Placement"] != null)
				{
					return (WINDOWPLACEMENT)this["Placement"];
				}
				return null;
			}
			set
			{
				this["Placement"] = value;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000895 RID: 2197 RVA: 0x00022884 File Offset: 0x00020A84
		// (set) Token: 0x06000896 RID: 2198 RVA: 0x00022900 File Offset: 0x00020B00
		[UserScopedSetting]
		public bool UpgradeSettings
		{
			get
			{
				try
				{
					if (this["UpgradeSettings"] != null)
					{
						return (bool)this["UpgradeSettings"];
					}
				}
				catch (ConfigurationErrorsException ex)
				{
					string text = null;
					while (ex != null && (text = ex.Filename) == null)
					{
						ex = (ex.InnerException as ConfigurationErrorsException);
					}
					throw new MahAppsException(string.Format("The settings file '{0}' seems to be corrupted", text ?? "<unknown>"), ex);
				}
				return true;
			}
			set
			{
				this["UpgradeSettings"] = value;
			}
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x00022913 File Offset: 0x00020B13
		void IWindowPlacementSettings.Reload()
		{
			base.Reload();
		}
	}
}
