using System;
using Laplink.Pcmover.Configurator.FolderTools;
using MainUI.Properties;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Reconfigurator.Infrastructure;

namespace MainUI
{
	// Token: 0x02000002 RID: 2
	public class FolderDisplay : BindableBase
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public ShellFolderData ShellFolderData { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		// (set) Token: 0x06000003 RID: 3 RVA: 0x00002060 File Offset: 0x00000260
		public MoveResult Result { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00000269
		// (set) Token: 0x06000005 RID: 5 RVA: 0x00002071 File Offset: 0x00000271
		public string DisplayName
		{
			get
			{
				return this._DisplayName;
			}
			set
			{
				this.SetProperty<string>(ref this._DisplayName, value, "DisplayName");
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00002086 File Offset: 0x00000286
		// (set) Token: 0x06000007 RID: 7 RVA: 0x0000208E File Offset: 0x0000028E
		public string FolderName
		{
			get
			{
				return this._FolderName;
			}
			set
			{
				this.SetProperty<string>(ref this._FolderName, value, "FolderName");
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020A3 File Offset: 0x000002A3
		// (set) Token: 0x06000009 RID: 9 RVA: 0x000020AB File Offset: 0x000002AB
		public string FormattedSize
		{
			get
			{
				return this._FormattedSize;
			}
			set
			{
				this.SetProperty<string>(ref this._FormattedSize, value, "FormattedSize");
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020C0 File Offset: 0x000002C0
		// (set) Token: 0x0600000B RID: 11 RVA: 0x000020C8 File Offset: 0x000002C8
		public string IconUri
		{
			get
			{
				return this._IconUri;
			}
			set
			{
				this.SetProperty<string>(ref this._IconUri, value, "IconUri");
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000C RID: 12 RVA: 0x000020DD File Offset: 0x000002DD
		// (set) Token: 0x0600000D RID: 13 RVA: 0x000020E5 File Offset: 0x000002E5
		public bool IsBusy
		{
			get
			{
				return this._IsBusy;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsBusy, value, "IsBusy");
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000020FA File Offset: 0x000002FA
		// (set) Token: 0x0600000F RID: 15 RVA: 0x00002102 File Offset: 0x00000302
		public bool IsDone
		{
			get
			{
				return this._IsDone;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsDone, value, "IsDone");
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000010 RID: 16 RVA: 0x00002117 File Offset: 0x00000317
		// (set) Token: 0x06000011 RID: 17 RVA: 0x0000211F File Offset: 0x0000031F
		public bool Selected
		{
			get
			{
				return this._Selected;
			}
			set
			{
				this.SetProperty<bool>(ref this._Selected, value, "Selected");
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002134 File Offset: 0x00000334
		// (set) Token: 0x06000013 RID: 19 RVA: 0x0000213C File Offset: 0x0000033C
		public bool AllowChange
		{
			get
			{
				return this._AllowChange;
			}
			set
			{
				this.SetProperty<bool>(ref this._AllowChange, value, "AllowChange");
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002151 File Offset: 0x00000351
		// (set) Token: 0x06000015 RID: 21 RVA: 0x00002159 File Offset: 0x00000359
		public string Destination
		{
			get
			{
				return this._Destination;
			}
			set
			{
				this.SetProperty<string>(ref this._Destination, value, "Destination");
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002170 File Offset: 0x00000370
		public FolderDisplay(ShellFolderData shellFolderData, string displayName, string iconUri, IEventAggregator eventAggregator)
		{
			this.ShellFolderData = shellFolderData;
			this.DisplayName = displayName;
			this.eventAggregator = eventAggregator;
			this.IconUri = iconUri;
			this.FormattedSize = shellFolderData.Folder.DisplaySize;
			this.FolderName = shellFolderData.Folder.DirInfo.FullName;
			this.IsBusy = false;
			this.IsDone = false;
			this.Selected = false;
			this.DoSelect = new DelegateCommand<string>(new Action<string>(this.DoSelectCommand));
			eventAggregator.GetEvent<Events.AllowChangeEvent>().Subscribe(new Action<bool>(this.AllowChanges));
			eventAggregator.GetEvent<Events.FromDriveChangeEvent>().Subscribe(new Action<string>(this.FromDriveChange));
			this.AllowChange = true;
			this.CheckOneDrive();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002232 File Offset: 0x00000432
		private void CheckOneDrive()
		{
			if (this.ShellFolderData.IsWithinOneDrive)
			{
				this.AllowChange = false;
				this.FolderName = Resources.OneDriveMapped;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002253 File Offset: 0x00000453
		private void FromDriveChange(string driveRoot)
		{
			if (this.ShellFolderData.Folder.DirInfo.Root.Name != driveRoot)
			{
				this.AllowChange = false;
				return;
			}
			this.AllowChange = true;
			this.CheckOneDrive();
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000228C File Offset: 0x0000048C
		private void AllowChanges(bool allowChange)
		{
			this.AllowChange = allowChange;
			this.CheckOneDrive();
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001A RID: 26 RVA: 0x0000229B File Offset: 0x0000049B
		// (set) Token: 0x0600001B RID: 27 RVA: 0x000022A3 File Offset: 0x000004A3
		public DelegateCommand<string> DoSelect { get; private set; }

		// Token: 0x0600001C RID: 28 RVA: 0x000022AC File Offset: 0x000004AC
		private void DoSelectCommand(string folderType)
		{
			this.eventAggregator.GetEvent<Events.SelectionHappened>().Publish(folderType);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000022BF File Offset: 0x000004BF
		public void SetSize()
		{
			this.FormattedSize = this.ShellFolderData.Folder.DisplaySize;
		}

		// Token: 0x04000001 RID: 1
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000004 RID: 4
		private string _DisplayName;

		// Token: 0x04000005 RID: 5
		private string _FolderName;

		// Token: 0x04000006 RID: 6
		private string _FormattedSize;

		// Token: 0x04000007 RID: 7
		private string _IconUri;

		// Token: 0x04000008 RID: 8
		private bool _IsBusy;

		// Token: 0x04000009 RID: 9
		private bool _IsDone;

		// Token: 0x0400000A RID: 10
		private bool _Selected;

		// Token: 0x0400000B RID: 11
		private bool _AllowChange;

		// Token: 0x0400000C RID: 12
		private string _Destination;
	}
}
