using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Laplink.Pcmover.Configurator.FolderTools;
using Laplink.Tools.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reconfigurator.Infrastructure;

namespace MainUI.ViewModels
{
	// Token: 0x02000015 RID: 21
	public class MainUserControlViewModel : BindableBase, INavigationAware
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x0000514C File Offset: 0x0000334C
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00005154 File Offset: 0x00003354
		public bool HasOtherDrive { get; private set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x0000515D File Offset: 0x0000335D
		public Visibility FunctionalityVisibility
		{
			get
			{
				if (!this.HasOtherDrive)
				{
					return Visibility.Collapsed;
				}
				return Visibility.Visible;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000EA RID: 234 RVA: 0x0000516A File Offset: 0x0000336A
		public Visibility NoFunctionalityVisibility
		{
			get
			{
				if (!this.HasOtherDrive)
				{
					return Visibility.Visible;
				}
				return Visibility.Collapsed;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00005177 File Offset: 0x00003377
		// (set) Token: 0x060000EC RID: 236 RVA: 0x0000517F File Offset: 0x0000337F
		public ObservableCollection<ShellFolderData> DriveCShellFolders { get; private set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00005188 File Offset: 0x00003388
		// (set) Token: 0x060000EE RID: 238 RVA: 0x00005190 File Offset: 0x00003390
		public ShellFolderData SelectedShellFolder
		{
			get
			{
				return this._selectedShellFolder;
			}
			set
			{
				if (this._selectedShellFolder != value)
				{
					bool flag = value == null || this._selectedShellFolder == null;
					this.SetProperty<ShellFolderData>(ref this._selectedShellFolder, value, "SelectedShellFolder");
					if (flag)
					{
						this.MoveShellFolderCommand.FireCanExecuteChanged(this);
					}
				}
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000EF RID: 239 RVA: 0x000051CB File Offset: 0x000033CB
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x000051D3 File Offset: 0x000033D3
		public ObservableCollection<ProgramFilesFolder> ProgramFilesFolders { get; private set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x000051DC File Offset: 0x000033DC
		// (set) Token: 0x060000F2 RID: 242 RVA: 0x000051E4 File Offset: 0x000033E4
		public ProgramFilesFolder SelectedPfFolder
		{
			get
			{
				return this._selectedPfFolder;
			}
			set
			{
				if (this._selectedPfFolder != value)
				{
					bool flag = value == null || this._selectedPfFolder == null;
					this.SetProperty<ProgramFilesFolder>(ref this._selectedPfFolder, value, "SelectedPfFolder");
					if (flag)
					{
						this.MovePfFolderCommand.FireCanExecuteChanged(this);
					}
				}
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x0000521F File Offset: 0x0000341F
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x00005227 File Offset: 0x00003427
		public bool ShowUndo
		{
			get
			{
				return this._ShowUndo;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowUndo, value, "ShowUndo");
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000523C File Offset: 0x0000343C
		public MainUserControlViewModel(IRegionManager regionManager, ISummary summary, ShellFolderInfo shellFolderInfo, LlTraceSource ts)
		{
			this.regionManager = regionManager;
			this.summary = summary;
			this.ts = ts;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnUndo = new DelegateCommand(new Action(this.OnUndoCommand), new Func<bool>(this.CanOnUndoCommand));
			this.MoveShellFolderCommand = new MainUserControlViewModel.MoveShellFolderCommandClass(this);
			this.MovePfFolderCommand = new MainUserControlViewModel.MovePfFolderCommandClass(this);
			this.GetDriveInfo();
			this.DriveCShellFolders = new ObservableCollection<ShellFolderData>(from sf in shellFolderInfo.UserShellFolders
			where sf.Folder.IsOnDriveC
			select sf);
			RegSettings regSettings = new RegSettings(ts);
			if (regSettings.Folders != null && regSettings.Folders.Count > 0)
			{
				this.ShowUndo = true;
				return;
			}
			this.ShowUndo = false;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000532C File Offset: 0x0000352C
		private void GetDriveInfo()
		{
			OtherDriveInfo otherDriveInfo = new OtherDriveInfo();
			this.HasOtherDrive = (otherDriveInfo.HasDriveC && otherDriveInfo.HasOtherDrives);
			this.HasOtherDrive = true;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00005360 File Offset: 0x00003560
		private string FormatErrorMessage(FolderMover fm, MoveResult res, string actionMessage)
		{
			if (res == MoveResult.Success)
			{
				return null;
			}
			if (fm.LastException != null)
			{
				Exception lastException = fm.LastException;
				return string.Format("{0} {1} {2}: {3}", new object[]
				{
					res,
					lastException.GetType(),
					actionMessage,
					lastException.Message
				});
			}
			return string.Format("{0} error {1}", res, actionMessage);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000053C4 File Offset: 0x000035C4
		private MoveResult MoveFolder(FolderInfo sourceFolder, FolderInfo destinationFolder, string actionMessage)
		{
			sourceFolder.StopGetSize();
			FolderMover folderMover = new FolderMover(sourceFolder.DirInfo, destinationFolder.DirInfo, this.ts);
			MoveResult moveResult = folderMover.Move();
			if (moveResult != MoveResult.Success)
			{
				MessageBox.Show(this.FormatErrorMessage(folderMover, moveResult, actionMessage));
			}
			return moveResult;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00005409 File Offset: 0x00003609
		private MoveResult Undo(FolderMover originalFm)
		{
			return new FolderMover(originalFm.DestinationDirectory, originalFm.SourceDirectory, this.ts).Move();
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00005428 File Offset: 0x00003628
		private string ReplaceFolderWithJunction(FolderInfo sourceFolder, FolderInfo destinationFolder)
		{
			sourceFolder.StopGetSize();
			FolderMover folderMover = new FolderMover(sourceFolder.DirInfo, destinationFolder.DirInfo, this.ts);
			MoveResult moveResult = folderMover.Move();
			if (moveResult != MoveResult.Success)
			{
				return this.FormatErrorMessage(folderMover, moveResult, "moving " + sourceFolder.DirInfo.FullName + " to " + destinationFolder.DirInfo.FullName);
			}
			string result;
			try
			{
				JunctionPoint.Create(sourceFolder.DirInfo.FullName, destinationFolder.DirInfo.FullName, false);
				result = null;
			}
			catch (Exception ex)
			{
				this.Undo(folderMover);
				result = string.Format("{0} setting up juntion point from {1} to {2}: {3}", new object[]
				{
					ex.GetType(),
					sourceFolder.DirInfo.FullName,
					destinationFolder.DirInfo.FullName,
					ex.Message
				});
			}
			return result;
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00005508 File Offset: 0x00003708
		// (set) Token: 0x060000FC RID: 252 RVA: 0x00005510 File Offset: 0x00003710
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x060000FD RID: 253 RVA: 0x00005519 File Offset: 0x00003719
		private bool CanOnNextCommand()
		{
			return true;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000551C File Offset: 0x0000371C
		private void OnNextCommand()
		{
			string empty = string.Empty;
			ProductTypes productTypes = ProductTypes.ePro;
			string empty2 = string.Empty;
			RegSettings regSettings = new RegSettings(this.ts);
			string installLocation = Installation.GetInstallLocation(ref empty, ref productTypes, ref empty2);
			this.summary.Undo = false;
			if ((!string.IsNullOrEmpty(regSettings.RegVerificationCode) && regSettings.RegVerificationCode.StartsWith("Serial:")) || installLocation != string.Empty)
			{
				this.regionManager.RequestNavigate("MainRegion", new Uri("FoldersUserControl", UriKind.Relative));
				return;
			}
			this.regionManager.RequestNavigate("MainRegion", new Uri("RegistrationUserControl", UriKind.Relative));
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000FF RID: 255 RVA: 0x000055C0 File Offset: 0x000037C0
		// (set) Token: 0x06000100 RID: 256 RVA: 0x000055C8 File Offset: 0x000037C8
		public DelegateCommand OnUndo { get; private set; }

		// Token: 0x06000101 RID: 257 RVA: 0x000055D1 File Offset: 0x000037D1
		private bool CanOnUndoCommand()
		{
			return true;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x000055D4 File Offset: 0x000037D4
		private void OnUndoCommand()
		{
			this.summary.Undo = true;
			this.regionManager.RequestNavigate("MainRegion", new Uri("FoldersUserControl", UriKind.Relative), new NavigationParameters
			{
				{
					"DoPrograms",
					true
				}
			});
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00005614 File Offset: 0x00003814
		private void MoveShellFolder(ShellFolderData sf)
		{
			if (sf == null)
			{
				MessageBox.Show("No shell folder to move");
				return;
			}
			string pathNewDrive = sf.Folder.GetPathNewDrive('D');
			FolderInfo destinationFolder = new FolderInfo(pathNewDrive);
			string text = string.Concat(new string[]
			{
				"transferring ",
				sf.BaseDisplayName,
				" from ",
				sf.Folder.DirInfo.FullName,
				" to ",
				pathNewDrive
			});
			if (this.MoveFolder(sf.Folder, destinationFolder, text) != MoveResult.Success)
			{
				return;
			}
			sf.RedirectTo(destinationFolder);
			this.DriveCShellFolders.Remove(sf);
			MessageBox.Show("Completed " + text);
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000104 RID: 260 RVA: 0x000056BF File Offset: 0x000038BF
		public MainUserControlViewModel.MoveShellFolderCommandClass MoveShellFolderCommand { get; }

		// Token: 0x06000105 RID: 261 RVA: 0x000056C8 File Offset: 0x000038C8
		private void MovePfFolder(ProgramFilesFolder pfFolder)
		{
			if (pfFolder == null)
			{
				MessageBox.Show("No Program Files folder to move");
				return;
			}
			FolderInfo folderInfo = pfFolder.Folder32;
			if (folderInfo != null)
			{
				string pathNewDrive = folderInfo.GetPathNewDrive('D');
				string text = this.ReplaceFolderWithJunction(folderInfo, new FolderInfo(pathNewDrive));
				if (text != null)
				{
					MessageBox.Show(text);
					return;
				}
			}
			folderInfo = pfFolder.Folder64;
			if (folderInfo != null)
			{
				string pathNewDrive = folderInfo.GetPathNewDrive('D');
				string text = this.ReplaceFolderWithJunction(folderInfo, new FolderInfo(pathNewDrive));
				if (text != null)
				{
					if (pfFolder.Folder32 == null)
					{
						MessageBox.Show(text);
						return;
					}
					MessageBox.Show("32-bit folder for " + pfFolder.BaseDisplayName + " moved successfully, but " + text);
					return;
				}
			}
			this.ProgramFilesFolders.Remove(pfFolder);
			MessageBox.Show("Completed moving the contents of " + pfFolder.BaseDisplayName);
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00005784 File Offset: 0x00003984
		public MainUserControlViewModel.MovePfFolderCommandClass MovePfFolderCommand { get; }

		// Token: 0x06000107 RID: 263 RVA: 0x0000578C File Offset: 0x0000398C
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.summary.Undo = false;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000579A File Offset: 0x0000399A
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000579D File Offset: 0x0000399D
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x0400005E RID: 94
		private readonly IRegionManager regionManager;

		// Token: 0x0400005F RID: 95
		private readonly LlTraceSource ts;

		// Token: 0x04000060 RID: 96
		private readonly ISummary summary;

		// Token: 0x04000063 RID: 99
		private ShellFolderData _selectedShellFolder;

		// Token: 0x04000065 RID: 101
		private ProgramFilesFolder _selectedPfFolder;

		// Token: 0x04000066 RID: 102
		private bool _ShowUndo;

		// Token: 0x02000020 RID: 32
		public class MoveShellFolderCommandClass : ICommand
		{
			// Token: 0x060001FB RID: 507 RVA: 0x00007150 File Offset: 0x00005350
			public MoveShellFolderCommandClass(MainUserControlViewModel vm)
			{
				this._vm = vm;
			}

			// Token: 0x14000002 RID: 2
			// (add) Token: 0x060001FC RID: 508 RVA: 0x00007160 File Offset: 0x00005360
			// (remove) Token: 0x060001FD RID: 509 RVA: 0x00007198 File Offset: 0x00005398
			public event EventHandler CanExecuteChanged;

			// Token: 0x060001FE RID: 510 RVA: 0x000071CD File Offset: 0x000053CD
			public bool CanExecute(object parameter)
			{
				return this._vm.SelectedShellFolder != null;
			}

			// Token: 0x060001FF RID: 511 RVA: 0x000071DD File Offset: 0x000053DD
			public void Execute(object parameter)
			{
				this._vm.MoveShellFolder(this._vm.SelectedShellFolder);
			}

			// Token: 0x06000200 RID: 512 RVA: 0x000071F5 File Offset: 0x000053F5
			public void FireCanExecuteChanged(object sender)
			{
				EventHandler canExecuteChanged = this.CanExecuteChanged;
				if (canExecuteChanged == null)
				{
					return;
				}
				canExecuteChanged(sender, EventArgs.Empty);
			}

			// Token: 0x040000AF RID: 175
			private readonly MainUserControlViewModel _vm;
		}

		// Token: 0x02000021 RID: 33
		public class MovePfFolderCommandClass : ICommand
		{
			// Token: 0x06000201 RID: 513 RVA: 0x0000720D File Offset: 0x0000540D
			public MovePfFolderCommandClass(MainUserControlViewModel vm)
			{
				this._vm = vm;
			}

			// Token: 0x14000003 RID: 3
			// (add) Token: 0x06000202 RID: 514 RVA: 0x0000721C File Offset: 0x0000541C
			// (remove) Token: 0x06000203 RID: 515 RVA: 0x00007254 File Offset: 0x00005454
			public event EventHandler CanExecuteChanged;

			// Token: 0x06000204 RID: 516 RVA: 0x00007289 File Offset: 0x00005489
			public bool CanExecute(object parameter)
			{
				return this._vm.SelectedPfFolder != null;
			}

			// Token: 0x06000205 RID: 517 RVA: 0x00007299 File Offset: 0x00005499
			public void Execute(object parameter)
			{
				this._vm.MovePfFolder(this._vm.SelectedPfFolder);
			}

			// Token: 0x06000206 RID: 518 RVA: 0x000072B1 File Offset: 0x000054B1
			public void FireCanExecuteChanged(object sender)
			{
				EventHandler canExecuteChanged = this.CanExecuteChanged;
				if (canExecuteChanged == null)
				{
					return;
				}
				canExecuteChanged(sender, EventArgs.Empty);
			}

			// Token: 0x040000B1 RID: 177
			private MainUserControlViewModel _vm;
		}
	}
}
