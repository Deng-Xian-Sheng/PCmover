using System;
using System.ComponentModel;
using Microsoft.Win32;

namespace Laplink.Pcmover.Configurator.FolderTools
{
	// Token: 0x02000009 RID: 9
	public class ShellFolderData : INotifyPropertyChanged
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000059 RID: 89 RVA: 0x000032C4 File Offset: 0x000014C4
		// (remove) Token: 0x0600005A RID: 90 RVA: 0x000032FC File Offset: 0x000014FC
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00003331 File Offset: 0x00001531
		public bool IsUser { get; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00003339 File Offset: 0x00001539
		public string BaseDisplayName { get; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00003341 File Offset: 0x00001541
		public string DisplayName
		{
			get
			{
				if (!this.Folder.IsSizeKnown)
				{
					return this.BaseDisplayName;
				}
				return this.BaseDisplayName + " - " + this.Folder.DisplaySize;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00003372 File Offset: 0x00001572
		public string Key { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600005F RID: 95 RVA: 0x0000337A File Offset: 0x0000157A
		public string AlternativeKey { get; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00003382 File Offset: 0x00001582
		public ShellFolderType FolderType { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000061 RID: 97 RVA: 0x0000338A File Offset: 0x0000158A
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00003392 File Offset: 0x00001592
		public bool IsWithinOneDrive { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000063 RID: 99 RVA: 0x0000339B File Offset: 0x0000159B
		// (set) Token: 0x06000064 RID: 100 RVA: 0x000033A4 File Offset: 0x000015A4
		public FolderInfo Folder
		{
			get
			{
				return this._folder;
			}
			private set
			{
				if (this._folder != value)
				{
					if (this._folder != null)
					{
						this._folder.PropertyChanged -= this.Folder_PropertyChanged;
					}
					this._folder = value;
					this._folder.PropertyChanged += this.Folder_PropertyChanged;
					PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
					if (propertyChanged == null)
					{
						return;
					}
					propertyChanged(this, new PropertyChangedEventArgs("Folder"));
				}
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00003412 File Offset: 0x00001612
		private string UserShellFolderRegKeyName
		{
			get
			{
				return (this.IsUser ? "HKEY_CURRENT_USER\\" : "HKEY_LOCAL_MACHINE") + ShellFolderData.UserShellFolderPath;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00003432 File Offset: 0x00001632
		private string ShellFolderRegKeyName
		{
			get
			{
				return (this.IsUser ? "HKEY_CURRENT_USER\\" : "HKEY_LOCAL_MACHINE") + ShellFolderData.ShellFolderPath;
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003452 File Offset: 0x00001652
		public ShellFolderData(ShellFolderType type, string key, string alternativeKey, string displayName, string path, bool isUser = true)
		{
			this.FolderType = type;
			this.Key = key;
			this.AlternativeKey = alternativeKey;
			this.BaseDisplayName = displayName;
			this.Folder = new FolderInfo(path);
			this.IsUser = isUser;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000348C File Offset: 0x0000168C
		private void Folder_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "IsSizeKnown")
			{
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("DisplayName"));
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000034BC File Offset: 0x000016BC
		public void RedirectTo(FolderInfo destinationFolder)
		{
			string fullName = destinationFolder.DirInfo.FullName;
			Registry.SetValue(this.UserShellFolderRegKeyName, this.Key, fullName, RegistryValueKind.String);
			Registry.SetValue(this.ShellFolderRegKeyName, this.Key, fullName, RegistryValueKind.String);
			if (!string.IsNullOrWhiteSpace(this.AlternativeKey))
			{
				Registry.SetValue(this.UserShellFolderRegKeyName, this.AlternativeKey, fullName, RegistryValueKind.String);
			}
			this.Folder = destinationFolder;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003522 File Offset: 0x00001722
		public override string ToString()
		{
			return this.DisplayName;
		}

		// Token: 0x04000030 RID: 48
		private FolderInfo _folder;

		// Token: 0x04000031 RID: 49
		public static string UserShellFolderPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders";

		// Token: 0x04000032 RID: 50
		public static string ShellFolderPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Shell Folders";
	}
}
