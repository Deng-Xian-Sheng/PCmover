using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Laplink.Pcmover.Contracts;
using Prism.Mvvm;

namespace PCmover.Infrastructure
{
	// Token: 0x0200001E RID: 30
	public class GroupInfo : BindableBase
	{
		// Token: 0x060001AF RID: 431 RVA: 0x000068F9 File Offset: 0x00004AF9
		public GroupInfo(string name, IPCmoverEngine engine, bool isOtherGroup = false)
		{
			this.Name = name;
			this.Engine = engine;
			this.Folders = new List<FolderDetail>();
			this._unassignedFolders = new List<FolderDetail>();
			this.IsOtherGroup = isOtherGroup;
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x0000692C File Offset: 0x00004B2C
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x00006934 File Offset: 0x00004B34
		public bool IsOtherGroup { get; private set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x0000693D File Offset: 0x00004B3D
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x00006945 File Offset: 0x00004B45
		public string Name { get; set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0000694E File Offset: 0x00004B4E
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x00006956 File Offset: 0x00004B56
		public ulong NumFolders { get; set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x0000695F File Offset: 0x00004B5F
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x00006967 File Offset: 0x00004B67
		public ulong NumFiles { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x00006970 File Offset: 0x00004B70
		public ulong NumSelectedFiles
		{
			get
			{
				ulong num = 0UL;
				foreach (FolderDetail folderDetail in this.Folders)
				{
					num += folderDetail.NumSelectedFiles;
				}
				return num;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x000069CC File Offset: 0x00004BCC
		// (set) Token: 0x060001BA RID: 442 RVA: 0x000069D4 File Offset: 0x00004BD4
		public ulong TotalSize { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060001BB RID: 443 RVA: 0x000069E0 File Offset: 0x00004BE0
		public ulong SelectedSize
		{
			get
			{
				ulong num = 0UL;
				foreach (FolderDetail folderDetail in this.Folders)
				{
					num += folderDetail.SelectedSize;
				}
				return num;
			}
		}

		// Token: 0x060001BC RID: 444 RVA: 0x00006A3C File Offset: 0x00004C3C
		public void RefreshDetails()
		{
			foreach (FolderDetail folderDetail in this.Folders)
			{
				folderDetail.RefreshDetails();
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060001BD RID: 445 RVA: 0x00006A8C File Offset: 0x00004C8C
		public List<FolderDetail> Folders { get; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00006A94 File Offset: 0x00004C94
		internal IPCmoverEngine Engine { get; }

		// Token: 0x060001BF RID: 447 RVA: 0x00006A9C File Offset: 0x00004C9C
		public void AddCategory(TransferrableCategoryDefinition catDef, bool canRedirect = true)
		{
			FolderDetail folderDetail = new FolderDetail(catDef, this, canRedirect);
			if (this.AddFolder(folderDetail))
			{
				this.NumFolders += catDef.NumContainers;
				this.NumFiles += catDef.NumItems;
				this.TotalSize += catDef.TotalSize;
				folderDetail.PropertyChanged += this.FolderDetail_PropertyChanged;
			}
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00006890 File Offset: 0x00004A90
		private void FolderDetail_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "SelectedSize")
			{
				base.RaisePropertyChanged("SelectedSize");
				base.RaisePropertyChanged("NumSelectedFiles");
			}
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00006B08 File Offset: 0x00004D08
		private bool AddFolder(FolderDetail folder)
		{
			GroupInfo.Ancestry rootAncestry = this.GetRootAncestry(folder);
			if (rootAncestry == GroupInfo.Ancestry.Same)
			{
				return false;
			}
			if (rootAncestry == GroupInfo.Ancestry.Ancestor)
			{
				List<FolderDetail> unassignedFolders = this._unassignedFolders;
				lock (unassignedFolders)
				{
					if (this._unassignedFolders.Find((FolderDetail unassigned) => unassigned.PathMatches(folder.FullPath)) == null)
					{
						this._unassignedFolders.Add(folder);
					}
				}
				return true;
			}
			List<FolderDetail> list = new List<FolderDetail>();
			foreach (FolderDetail folderDetail in this.Folders)
			{
				GroupInfo.Ancestry ancestry = GroupInfo.DetermineAncestry(folder.FullPath, folderDetail.FullPath);
				if (ancestry == GroupInfo.Ancestry.Same)
				{
					return false;
				}
				if (ancestry == GroupInfo.Ancestry.Ancestor)
				{
					list.Add(folderDetail);
				}
			}
			if (list.Count > 0)
			{
				List<FolderDetail> unassignedFolders = this._unassignedFolders;
				lock (unassignedFolders)
				{
					foreach (FolderDetail item in list)
					{
						this._unassignedFolders.Add(item);
						this.Folders.Remove(item);
					}
				}
			}
			this.Folders.Add(folder);
			return true;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00006CA4 File Offset: 0x00004EA4
		internal static GroupInfo.Ancestry DetermineAncestry(string possibleAncestorPath, string possibleChildPath)
		{
			if (FolderDetail.PathMatches(possibleChildPath, possibleAncestorPath))
			{
				return GroupInfo.Ancestry.Same;
			}
			while (possibleChildPath.Length > possibleAncestorPath.Length)
			{
				possibleChildPath = Path.GetDirectoryName(possibleChildPath);
				if (FolderDetail.PathMatches(possibleChildPath, possibleAncestorPath))
				{
					return GroupInfo.Ancestry.Ancestor;
				}
			}
			return GroupInfo.Ancestry.NotAncestor;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00006CD4 File Offset: 0x00004ED4
		internal static string GetChildThatIsAncestor(string parentPath, string childPath)
		{
			string result = childPath;
			while (childPath.Length > parentPath.Length)
			{
				childPath = Path.GetDirectoryName(childPath);
				if (FolderDetail.PathMatches(parentPath, childPath))
				{
					return result;
				}
				result = childPath;
			}
			return null;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00006D0C File Offset: 0x00004F0C
		private GroupInfo.Ancestry GetRootAncestry(FolderDetail folder)
		{
			GroupInfo.Ancestry ancestry = GroupInfo.Ancestry.NotAncestor;
			foreach (FolderDetail folderDetail in this.Folders)
			{
				ancestry = GroupInfo.DetermineAncestry(folderDetail.FullPath, folder.FullPath);
				if (ancestry != GroupInfo.Ancestry.NotAncestor)
				{
					break;
				}
			}
			return ancestry;
		}

		// Token: 0x040000B4 RID: 180
		public List<FolderDetail> _unassignedFolders;

		// Token: 0x020000ED RID: 237
		internal enum Ancestry
		{
			// Token: 0x040002E4 RID: 740
			Ancestor,
			// Token: 0x040002E5 RID: 741
			Same,
			// Token: 0x040002E6 RID: 742
			NotAncestor
		}
	}
}
