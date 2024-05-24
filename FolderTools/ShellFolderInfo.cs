using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

namespace Laplink.Pcmover.Configurator.FolderTools
{
	// Token: 0x0200000A RID: 10
	public class ShellFolderInfo
	{
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00003540 File Offset: 0x00001740
		public IReadOnlyList<ShellFolderData> UserShellFolders
		{
			get
			{
				return this._userShellFolders;
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003548 File Offset: 0x00001748
		public ShellFolderInfo()
		{
			this.InitUserShellFolders();
			this.MarkOneDriveFolders();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003568 File Offset: 0x00001768
		private void InitUserShellFolders()
		{
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(ShellFolderData.UserShellFolderPath, false))
				{
					if (registryKey != null)
					{
						this.AddShellFolder(registryKey, ShellFolderType.Documents, "Personal", "{F42EE2D3-909F-4907-8871-4C22FC0BF756}", "Documents", true);
						this.AddShellFolder(registryKey, ShellFolderType.Music, "My Music", "{A0C69A99-21C8-4671-8703-7934162FCF1D}", "Music", true);
						this.AddShellFolder(registryKey, ShellFolderType.Pictures, "My Pictures", "{0DDD015D-B06C-45D5-8C4C-F59713854639}", "Pictures", true);
						this.AddShellFolder(registryKey, ShellFolderType.Videos, "My Video", "{35286A68-3C57-41A1-BBB1-0EAE73d76C95}", "Videos", true);
						this.AddShellFolder(registryKey, ShellFolderType.Downloads, "{374DE290-123F-4565-9164-39C4925E467B}", "{7D83EE9B-2244-4E70-B1F5-5393042AF1E4}", "Downloads", true);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003630 File Offset: 0x00001830
		private void AddShellFolder(RegistryKey key, ShellFolderType type, string valueName, string alternativeValue, string displayName, bool isUser)
		{
			string text = key.GetValue(valueName) as string;
			if (text != null)
			{
				ShellFolderData shellFolderData = new ShellFolderData(type, valueName, alternativeValue, displayName, text, isUser);
				shellFolderData.Folder.GetSizeAsync();
				this._userShellFolders.Add(shellFolderData);
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003674 File Offset: 0x00001874
		private void MarkOneDriveFolders()
		{
			HashSet<string> hashSet = new HashSet<string>();
			foreach (object obj in Environment.GetEnvironmentVariables())
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string text = dictionaryEntry.Key as string;
				if (text != null && text.ToUpper().StartsWith("ONEDRIVE"))
				{
					hashSet.Add(dictionaryEntry.Value as string);
				}
			}
			foreach (ShellFolderData shellFolderData in this._userShellFolders)
			{
				string fullName = shellFolderData.Folder.DirInfo.FullName;
				using (HashSet<string>.Enumerator enumerator3 = hashSet.GetEnumerator())
				{
					while (enumerator3.MoveNext())
					{
						if (ShellFolderInfo.FolderContains(enumerator3.Current, fullName))
						{
							shellFolderData.IsWithinOneDrive = true;
							break;
						}
					}
				}
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000379C File Offset: 0x0000199C
		private static bool FolderContains(string parentFolder, string childFolder)
		{
			return parentFolder != null && childFolder != null && (string.Compare(parentFolder, childFolder, true) == 0 || (childFolder.Length > parentFolder.Length && ShellFolderInfo.FolderContains(parentFolder, Path.GetDirectoryName(childFolder))));
		}

		// Token: 0x04000033 RID: 51
		private readonly List<ShellFolderData> _userShellFolders = new List<ShellFolderData>();
	}
}
