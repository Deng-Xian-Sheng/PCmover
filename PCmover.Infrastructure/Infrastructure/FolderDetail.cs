using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Laplink.Pcmover.Contracts;
using Prism.Mvvm;

namespace PCmover.Infrastructure
{
	// Token: 0x0200001D RID: 29
	public class FolderDetail : BindableBase
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00005902 File Offset: 0x00003B02
		// (set) Token: 0x06000187 RID: 391 RVA: 0x0000590A File Offset: 0x00003B0A
		public GroupInfo Group { get; private set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000188 RID: 392 RVA: 0x00005913 File Offset: 0x00003B13
		private IPCmoverEngine Engine
		{
			get
			{
				return this.Group.Engine;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000189 RID: 393 RVA: 0x00005920 File Offset: 0x00003B20
		public bool IsCloud
		{
			get
			{
				return this._category.IsCloud;
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000592D File Offset: 0x00003B2D
		public FolderDetail(TransferrableCategoryDefinition info, GroupInfo group, bool canRedirect)
		{
			this._category = info;
			this.CanRedirect = canRedirect;
			this.Init(info, group);
			this.DisplayName = this.FullPath;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00005957 File Offset: 0x00003B57
		public FolderDetail(TransferrableContainerInfo info, CategoryDefinition def, GroupInfo group, bool canRedirect)
		{
			this._category = def;
			this.CanRedirect = canRedirect;
			this.Init(info, group);
			this.DisplayName = Path.GetFileName(this.FullPath);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00005988 File Offset: 0x00003B88
		private void Init(ITransferrableContainer info, GroupInfo group)
		{
			this.FullPath = info.FullPath;
			this.Group = group;
			this._mySize = info.TotalSize;
			this._numFiles = info.NumItems;
			this._transferrable = info.Transferrable;
			this._target = info.Target;
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600018D RID: 397 RVA: 0x000059D8 File Offset: 0x00003BD8
		// (set) Token: 0x0600018E RID: 398 RVA: 0x000059E0 File Offset: 0x00003BE0
		public string FullPath { get; set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600018F RID: 399 RVA: 0x000059E9 File Offset: 0x00003BE9
		// (set) Token: 0x06000190 RID: 400 RVA: 0x000059F1 File Offset: 0x00003BF1
		public string DisplayName { get; private set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000191 RID: 401 RVA: 0x000059FA File Offset: 0x00003BFA
		// (set) Token: 0x06000192 RID: 402 RVA: 0x00005A02 File Offset: 0x00003C02
		public bool CanRedirect { get; private set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000193 RID: 403 RVA: 0x00005A0B File Offset: 0x00003C0B
		private ulong CurrentSize
		{
			get
			{
				return this._mySize + this._assignedSize;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000194 RID: 404 RVA: 0x00005A1C File Offset: 0x00003C1C
		public ulong Size
		{
			get
			{
				ulong num = 0UL;
				List<FolderDetail> unassignedFolders = this.Group._unassignedFolders;
				lock (unassignedFolders)
				{
					foreach (FolderDetail folderDetail in this.Group._unassignedFolders)
					{
						if (GroupInfo.DetermineAncestry(this.FullPath, folderDetail.FullPath) == GroupInfo.Ancestry.Ancestor)
						{
							num += folderDetail.CurrentSize;
						}
					}
				}
				return num + this.CurrentSize;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000195 RID: 405 RVA: 0x00005AC4 File Offset: 0x00003CC4
		public ulong SelectedSize
		{
			get
			{
				ulong result;
				try
				{
					ulong num = 0UL;
					if (this._isComplete)
					{
						foreach (FileDetail fileDetail in this._fileList)
						{
							num += fileDetail.SelectedSize;
						}
						using (List<FolderDetail>.Enumerator enumerator2 = this._folderList.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								FolderDetail folderDetail = enumerator2.Current;
								num += folderDetail.SelectedSize;
							}
							goto IL_116;
						}
					}
					num = ((this.Transferrable == Transferrable.Transfer) ? this.CurrentSize : 0UL);
					List<FolderDetail> unassignedFolders = this.Group._unassignedFolders;
					lock (unassignedFolders)
					{
						foreach (FolderDetail folderDetail2 in this.Group._unassignedFolders)
						{
							if (GroupInfo.DetermineAncestry(this.FullPath, folderDetail2.FullPath) == GroupInfo.Ancestry.Ancestor && folderDetail2.Transferrable == Transferrable.Transfer)
							{
								num += folderDetail2.CurrentSize;
							}
						}
					}
					IL_116:
					result = num;
				}
				catch (Exception)
				{
					result = 0UL;
				}
				return result;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00005C74 File Offset: 0x00003E74
		public ulong NumSelectedFiles
		{
			get
			{
				ulong num = 0UL;
				if (this._isComplete)
				{
					using (List<FileDetail>.Enumerator enumerator = this._fileList.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current.Selected == Transferrable.Transfer)
							{
								num += 1UL;
							}
						}
					}
					using (List<FolderDetail>.Enumerator enumerator2 = this._folderList.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							FolderDetail folderDetail = enumerator2.Current;
							num += folderDetail.NumSelectedFiles;
						}
						return num;
					}
				}
				num = ((this.Transferrable == Transferrable.Transfer) ? this._numFiles : 0UL);
				List<FolderDetail> unassignedFolders = this.Group._unassignedFolders;
				lock (unassignedFolders)
				{
					foreach (FolderDetail folderDetail2 in this.Group._unassignedFolders)
					{
						if (GroupInfo.DetermineAncestry(this.FullPath, folderDetail2.FullPath) == GroupInfo.Ancestry.Ancestor && folderDetail2.Transferrable == Transferrable.Transfer)
						{
							num += folderDetail2._numFiles;
						}
					}
				}
				return num;
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000197 RID: 407 RVA: 0x00005DCC File Offset: 0x00003FCC
		public string Name
		{
			get
			{
				return Path.GetFileName(this.FullPath);
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00005DD9 File Offset: 0x00003FD9
		// (set) Token: 0x06000199 RID: 409 RVA: 0x00005DE4 File Offset: 0x00003FE4
		public string Target
		{
			get
			{
				return this._target;
			}
			set
			{
				if (this._target != value)
				{
					this.Engine.CatchCommEx(delegate
					{
						CustomizationData customizationData = this.Engine.ChangeDiskData(this.FullPath, "", true, null, value);
						if (customizationData != null && customizationData.Result == CustomizationResult.Success && customizationData.Affects.HasFlag(CustomizationAffects.DiskItems))
						{
							this.RefreshDetailsAndUnassigned();
						}
					}, "Target");
				}
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00005E35 File Offset: 0x00004035
		public bool SetTarget(string target)
		{
			return this.SetProperty<string>(ref this._target, target, "Target");
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00005E49 File Offset: 0x00004049
		// (set) Token: 0x0600019C RID: 412 RVA: 0x00005E54 File Offset: 0x00004054
		public Transferrable Transferrable
		{
			get
			{
				return this._transferrable;
			}
			set
			{
				if (this._transferrable == Transferrable.RuleExcluded)
				{
					return;
				}
				if (value == Transferrable.RuleExcluded)
				{
					return;
				}
				if (this._transferrable != value)
				{
					this.Engine.CatchCommEx(delegate
					{
						CustomizationData customizationData = this.Engine.ChangeDiskData(this.FullPath, "", true, new bool?(value == Transferrable.Transfer), null);
						if (customizationData != null && customizationData.Result == CustomizationResult.Success)
						{
							this.ChangeTransferrable(value);
						}
					}, "Transferrable");
				}
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00005EB4 File Offset: 0x000040B4
		public bool PathMatches(string otherPath)
		{
			return FolderDetail.PathMatches(this.FullPath, otherPath);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00005EC2 File Offset: 0x000040C2
		public static bool PathMatches(string firstPath, string secondPath)
		{
			return FolderDetail.PathCompare(firstPath, secondPath) == 0;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00005ECE File Offset: 0x000040CE
		public int PathCompare(string otherPath)
		{
			return FolderDetail.PathCompare(this.FullPath, otherPath);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00005EDC File Offset: 0x000040DC
		public static int PathCompare(string firstPath, string secondPath)
		{
			return string.Compare(firstPath, secondPath, StringComparison.CurrentCultureIgnoreCase);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00005EE8 File Offset: 0x000040E8
		public bool ChangeTransferrable(Transferrable transferrable)
		{
			bool result = false;
			if (this._transferrable != Transferrable.RuleExcluded)
			{
				result = this.SetProperty<Transferrable>(ref this._transferrable, transferrable, "Transferrable");
			}
			this.UpdateTransferrableForChildren(transferrable);
			base.RaisePropertyChanged("SelectedSize");
			base.RaisePropertyChanged("NumSelectedFiles");
			return result;
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00005F34 File Offset: 0x00004134
		public List<FileDetail> FileList
		{
			get
			{
				if (this._isComplete)
				{
					return this._fileList;
				}
				this.Complete();
				return new List<FileDetail>
				{
					new FileDetail(new TransferrableItemDefinition
					{
						Name = "...",
						Transferrable = this.Transferrable
					}, this)
				};
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00005F83 File Offset: 0x00004183
		public List<FolderDetail> FolderList
		{
			get
			{
				if (this._isComplete)
				{
					return this._folderList;
				}
				this.Complete();
				return null;
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00005F9C File Offset: 0x0000419C
		private void UpdateTransferrableForChildren(Transferrable transferrable)
		{
			if (this._folderList != null)
			{
				foreach (FolderDetail folderDetail in this._folderList)
				{
					folderDetail.ChangeTransferrable(transferrable);
				}
			}
			if (this._fileList != null)
			{
				foreach (FileDetail fileDetail in this._fileList)
				{
					fileDetail.ChangeSelected(transferrable);
				}
			}
			List<FolderDetail> unassignedFolders = this.Group._unassignedFolders;
			lock (unassignedFolders)
			{
				foreach (FolderDetail folderDetail2 in this.Group._unassignedFolders)
				{
					if (GroupInfo.DetermineAncestry(this.FullPath, folderDetail2.FullPath) == GroupInfo.Ancestry.Ancestor)
					{
						folderDetail2.ChangeTransferrable(transferrable);
					}
				}
			}
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000060C8 File Offset: 0x000042C8
		private void RefreshDetailsAndUnassigned()
		{
			this.RefreshDetails();
			List<FolderDetail> unassignedFolders = this.Group._unassignedFolders;
			lock (unassignedFolders)
			{
				foreach (FolderDetail folderDetail in this.Group._unassignedFolders)
				{
					if (GroupInfo.DetermineAncestry(this.FullPath, folderDetail.FullPath) == GroupInfo.Ancestry.Ancestor)
					{
						folderDetail.RefreshDetails();
					}
				}
			}
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00006164 File Offset: 0x00004364
		public void RefreshDetails()
		{
			this.UpdateDetailsData();
			if (this._folderList != null)
			{
				foreach (FolderDetail folderDetail in this._folderList)
				{
					folderDetail.RefreshDetails();
				}
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000061C4 File Offset: 0x000043C4
		private void UpdateDetailsData()
		{
			if (!this._isComplete)
			{
				base.RaisePropertyChanged("SelectedSize");
				base.RaisePropertyChanged("NumSelectedFiles");
				return;
			}
			Mouse.OverrideCursor = Cursors.Wait;
			try
			{
				TransferrableContainerData folderData = null;
				if (!this.Engine.CatchCommEx(delegate
				{
					folderData = this.Engine.GetFolderData(this.FullPath, false, false);
				}, "UpdateDetailsData"))
				{
					return;
				}
				if (folderData != null)
				{
					this.ChangeTransferrable(folderData.Transferrable);
					this.SetTarget(folderData.Target);
					using (IEnumerator<TransferrableItemDefinition> enumerator = folderData.Items.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							TransferrableItemDefinition fileItem = enumerator.Current;
							List<FileDetail> fileList = this._fileList;
							FileDetail fileDetail = (fileList != null) ? fileList.Find((FileDetail x) => x.Name == fileItem.Name) : null;
							if (fileDetail != null)
							{
								fileDetail.ChangeSelected(fileItem.Transferrable);
								fileDetail.SetTarget(fileItem.Target);
							}
						}
					}
					using (IEnumerator<TransferrableContainerInfo> enumerator2 = folderData.Containers.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							TransferrableContainerInfo folderItem = enumerator2.Current;
							List<FolderDetail> folderList = this._folderList;
							FolderDetail folderDetail = (folderList != null) ? folderList.Find((FolderDetail x) => x.FullPath == folderItem.FullPath) : null;
							if (folderDetail != null)
							{
								folderDetail.ChangeTransferrable(folderItem.Transferrable);
								folderDetail.SetTarget(folderItem.Target);
							}
						}
					}
				}
			}
			catch
			{
			}
			Mouse.OverrideCursor = null;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000063C4 File Offset: 0x000045C4
		private void AddFolder(FolderDetail folderDetail)
		{
			folderDetail.PropertyChanged += this.Child_PropertyChanged;
			this._folderList.Add(folderDetail);
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000063E4 File Offset: 0x000045E4
		private void AddFile(FileDetail fileDetail)
		{
			fileDetail.PropertyChanged += this.Child_PropertyChanged;
			this._fileList.Add(fileDetail);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00006404 File Offset: 0x00004604
		private void Complete()
		{
			lock (this)
			{
				if (!this._isComplete && !this._completing)
				{
					this._completing = true;
					Task.Run(delegate()
					{
						this.CompleteThread();
					});
				}
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00006464 File Offset: 0x00004664
		private void CompleteThread()
		{
			if (!this._isComplete)
			{
				try
				{
					TransferrableContainerData folderData = null;
					if (this.Engine.CatchCommEx(delegate
					{
						folderData = this.Engine.GetFolderData(this.FullPath, true, false);
					}, "CompleteThread"))
					{
						if (folderData != null)
						{
							this._transferrable = folderData.Transferrable;
							this._target = folderData.Target;
							this._fileList = new List<FileDetail>();
							foreach (TransferrableItemDefinition fileItem in folderData.Items)
							{
								this.AddFile(new FileDetail(fileItem, this));
							}
							this._folderList = new List<FolderDetail>();
							foreach (TransferrableContainerInfo info in folderData.Containers)
							{
								this.AddFolder(new FolderDetail(info, this._category, this.Group, true));
							}
							if (this.Group._unassignedFolders.Count > 0)
							{
								bool flag = false;
								List<FolderDetail> list = new List<FolderDetail>();
								List<FolderDetail> unassignedFolders = this.Group._unassignedFolders;
								lock (unassignedFolders)
								{
									foreach (FolderDetail folderDetail in this.Group._unassignedFolders)
									{
										if (this.PathMatches(Path.GetDirectoryName(folderDetail.FullPath)))
										{
											folderDetail.DisplayName = Path.GetFileName(folderDetail.FullPath);
											this.AddFolder(folderDetail);
											this._assignedSize += folderDetail.CurrentSize;
											list.Add(folderDetail);
											flag = true;
										}
									}
									foreach (FolderDetail item in list)
									{
										this.Group._unassignedFolders.Remove(item);
									}
									foreach (FolderDetail folderDetail2 in this.Group._unassignedFolders)
									{
										if (GroupInfo.DetermineAncestry(this.FullPath, folderDetail2.FullPath) == GroupInfo.Ancestry.Ancestor)
										{
											string childPath = GroupInfo.GetChildThatIsAncestor(this.FullPath, folderDetail2.FullPath);
											if (childPath != null && this._folderList.Find((FolderDetail f) => FolderDetail.PathMatches(f.FullPath, childPath)) == null)
											{
												TransferrableContainerInfo info2 = new TransferrableContainerInfo
												{
													FullPath = childPath,
													NumContainers = 1UL,
													NumItems = 0UL,
													TotalSize = 0UL,
													Target = this.Target + "\\" + Path.GetFileName(childPath),
													Transferrable = this.Transferrable
												};
												this.AddFolder(new FolderDetail(info2, this._category, this.Group, false));
												flag = true;
											}
										}
									}
								}
								if (flag)
								{
									this._folderList.Sort((FolderDetail folder1, FolderDetail folder2) => folder1.PathCompare(folder2.FullPath));
								}
							}
							this._isComplete = true;
							this._completing = false;
						}
						base.RaisePropertyChanged("TreeItems");
					}
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00006890 File Offset: 0x00004A90
		private void Child_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "SelectedSize")
			{
				base.RaisePropertyChanged("SelectedSize");
				base.RaisePropertyChanged("NumSelectedFiles");
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060001AD RID: 429 RVA: 0x000068BA File Offset: 0x00004ABA
		public IList TreeItems
		{
			get
			{
				return new CompositeCollection
				{
					new CollectionContainer
					{
						Collection = this.FolderList
					},
					new CollectionContainer
					{
						Collection = this.FileList
					}
				};
			}
		}

		// Token: 0x040000A0 RID: 160
		private readonly CategoryDefinition _category;

		// Token: 0x040000A4 RID: 164
		private ulong _mySize;

		// Token: 0x040000A5 RID: 165
		private ulong _assignedSize;

		// Token: 0x040000A6 RID: 166
		private ulong _numFiles;

		// Token: 0x040000A7 RID: 167
		private string _target;

		// Token: 0x040000A8 RID: 168
		private Transferrable _transferrable;

		// Token: 0x040000A9 RID: 169
		private List<FileDetail> _fileList;

		// Token: 0x040000AA RID: 170
		private List<FolderDetail> _folderList;

		// Token: 0x040000AB RID: 171
		private bool _isComplete;

		// Token: 0x040000AC RID: 172
		private bool _completing;
	}
}
