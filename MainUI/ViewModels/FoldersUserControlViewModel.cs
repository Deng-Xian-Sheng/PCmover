using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Laplink.Pcmover.Configurator.FolderTools;
using Laplink.Tools.Helpers;
using MainUI.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Reconfigurator.Infrastructure;

namespace MainUI.ViewModels
{
	// Token: 0x02000012 RID: 18
	public class FoldersUserControlViewModel : BindableBase, INavigationAware
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600008C RID: 140 RVA: 0x00002FA1 File Offset: 0x000011A1
		// (set) Token: 0x0600008D RID: 141 RVA: 0x00002FA9 File Offset: 0x000011A9
		public ObservableCollection<FolderDisplay> Folders { get; private set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00002FB2 File Offset: 0x000011B2
		// (set) Token: 0x0600008F RID: 143 RVA: 0x00002FBA File Offset: 0x000011BA
		public bool AllSelected
		{
			get
			{
				return this._AllSelected;
			}
			set
			{
				this.SetProperty<bool>(ref this._AllSelected, value, "AllSelected");
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00002FCF File Offset: 0x000011CF
		// (set) Token: 0x06000091 RID: 145 RVA: 0x00002FD7 File Offset: 0x000011D7
		public bool TransferComplete
		{
			get
			{
				return this._TransferComplete;
			}
			set
			{
				this.SetProperty<bool>(ref this._TransferComplete, value, "TransferComplete");
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00002FEC File Offset: 0x000011EC
		// (set) Token: 0x06000093 RID: 147 RVA: 0x00002FF4 File Offset: 0x000011F4
		public ObservableCollection<DriveDisplay> Drives { get; private set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00002FFD File Offset: 0x000011FD
		// (set) Token: 0x06000095 RID: 149 RVA: 0x00003008 File Offset: 0x00001208
		public DriveDisplay SelectedFromDrive
		{
			get
			{
				return this._SelectedFromDrive;
			}
			set
			{
				this.SetProperty<DriveDisplay>(ref this._SelectedFromDrive, value, "SelectedFromDrive");
				IEventAggregator eventAggregator = this.eventAggregator;
				if (eventAggregator != null)
				{
					eventAggregator.GetEvent<Events.FromDriveChangeEvent>().Publish(value.Root);
				}
				foreach (FolderDisplay folderDisplay in this.Folders)
				{
					folderDisplay.Selected = false;
				}
				this.AllSelected = false;
				this.OnTransfer.RaiseCanExecuteChanged();
				this.ChangeSourceBaseDrive(this.SelectedFromDrive.DriveName);
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000096 RID: 150 RVA: 0x000030A8 File Offset: 0x000012A8
		// (set) Token: 0x06000097 RID: 151 RVA: 0x000030B0 File Offset: 0x000012B0
		public DriveDisplay SelectedToDrive
		{
			get
			{
				return this._SelectedToDrive;
			}
			set
			{
				this.SetProperty<DriveDisplay>(ref this._SelectedToDrive, value, "SelectedToDrive");
				this.ChangeDestinationBaseDrive(this.SelectedToDrive.DriveName);
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000098 RID: 152 RVA: 0x000030D6 File Offset: 0x000012D6
		// (set) Token: 0x06000099 RID: 153 RVA: 0x000030DE File Offset: 0x000012DE
		public bool AllowChange
		{
			get
			{
				return this._AllowChange;
			}
			private set
			{
				this.SetProperty<bool>(ref this._AllowChange, value, "AllowChange");
				this.eventAggregator.GetEvent<Events.AllowChangeEvent>().Publish(value);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00003104 File Offset: 0x00001304
		// (set) Token: 0x0600009B RID: 155 RVA: 0x0000310C File Offset: 0x0000130C
		public string DestinationBase
		{
			get
			{
				return this._DestinationBase;
			}
			private set
			{
				this.SetProperty<string>(ref this._DestinationBase, value, "DestinationBase");
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00003121 File Offset: 0x00001321
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00003129 File Offset: 0x00001329
		public bool ShowError
		{
			get
			{
				return this._ShowError;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowError, value, "ShowError");
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600009E RID: 158 RVA: 0x0000313E File Offset: 0x0000133E
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00003146 File Offset: 0x00001346
		public bool DisplaySpaceError
		{
			get
			{
				return this._DisplaySpaceError;
			}
			set
			{
				this.SetProperty<bool>(ref this._DisplaySpaceError, value, "DisplaySpaceError");
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x0000315B File Offset: 0x0000135B
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00003163 File Offset: 0x00001363
		public bool ShowDrives
		{
			get
			{
				return this._ShowDrives;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowDrives, value, "ShowDrives");
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00003178 File Offset: 0x00001378
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00003180 File Offset: 0x00001380
		public bool DisplayExplorerError
		{
			get
			{
				return this._DisplayExplorerError;
			}
			private set
			{
				this.SetProperty<bool>(ref this._DisplayExplorerError, value, "DisplayExplorerError");
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00003195 File Offset: 0x00001395
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x0000319D File Offset: 0x0000139D
		public ObservableCollection<string> ExplorerFolders
		{
			get
			{
				return this._ExplorerFolders;
			}
			private set
			{
				this.SetProperty<ObservableCollection<string>>(ref this._ExplorerFolders, value, "ExplorerFolders");
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x000031B2 File Offset: 0x000013B2
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x000031BA File Offset: 0x000013BA
		public string TransferButtonText
		{
			get
			{
				return this._TransferButtonText;
			}
			private set
			{
				this.SetProperty<string>(ref this._TransferButtonText, value, "TransferButtonText");
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000031D0 File Offset: 0x000013D0
		public FoldersUserControlViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, ISummary summary, ShellFolderInfo shellFolderInfo, LlTraceSource ts)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.summary = summary;
			this.ts = ts;
			this.shellFolderInfo = shellFolderInfo;
			this.Folders = new ObservableCollection<FolderDisplay>();
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnTransfer = new DelegateCommand(new Action(this.OnTransferCommand), new Func<bool>(this.CanOnTransferCommand));
			this.SelectAll = new DelegateCommand(new Action(this.DoSelectAllCommand), new Func<bool>(this.CanDoSelectAllCommand));
			this.OnChange = new DelegateCommand(new Action(this.OnChangeCommand), new Func<bool>(this.CanOnChangeCommand));
			this.OnCloseSpaceError = new DelegateCommand(new Action(this.OnCloseSpaceErrorCommand));
			this.OnCloseExplorerError = new DelegateCommand(new Action(this.OnCloseExplorerErrorCommand));
			this.DisplaySpaceError = false;
			eventAggregator.GetEvent<Events.SelectionHappened>().Subscribe(new Action<string>(this.OnSelected), ThreadOption.UIThread);
			eventAggregator.GetEvent<Events.TransferErrorCompleteEvent>().Subscribe(new Action<TransferError>(this.OnTransferErrorComplete), ThreadOption.UIThread);
			eventAggregator.GetEvent<Events.MoveLibraryEvent>().Subscribe(new Action<MoveLibraryData>(this.OnMoveLibrary));
			this.ShowError = false;
			this.ShowDrives = true;
			IEnumerable<DriveInfo> enumerable = from drive in DriveInfo.GetDrives()
			where drive.DriveType == DriveType.Fixed
			select drive;
			this.Drives = new ObservableCollection<DriveDisplay>();
			int num = 0;
			foreach (DriveInfo driveInfo in enumerable)
			{
				DriveDisplay driveDisplay = new DriveDisplay(driveInfo, Resources.FreeString);
				this.Drives.Add(driveDisplay);
				if (num == 0)
				{
					this.SelectedFromDrive = driveDisplay;
				}
				else if (num == 1)
				{
					this.SelectedToDrive = driveDisplay;
				}
				num++;
			}
			this.AllowChange = true;
			if (num <= 1)
			{
				this.ShowError = true;
				this.AllowChange = false;
			}
			if (this.SelectedToDrive != null)
			{
				this.ChangeDestinationBaseDrive(this.SelectedToDrive.DriveName);
			}
			summary.BeforeDrives = this.Drives;
			this.DisplayExplorerError = false;
			this.tempTimer.Tick += this.TempTimer_Tick;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003484 File Offset: 0x00001684
		private FolderDisplay FindFolder(string name)
		{
			foreach (FolderDisplay folderDisplay in this.Folders)
			{
				if (string.Compare(folderDisplay.DisplayName, name) == 0)
				{
					return folderDisplay;
				}
			}
			return null;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000034E0 File Offset: 0x000016E0
		private void OnTransferErrorComplete(TransferError transferError)
		{
			switch (transferError.ErrorType)
			{
			case ErrorType.SourceLibraryDoesNotExist:
				using (IEnumerator<FolderDisplay> enumerator = this.Folders.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						FolderDisplay folderDisplay = enumerator.Current;
						if (string.Compare(folderDisplay.DisplayName, transferError.Library.LibraryDisplayName) == 0)
						{
							folderDisplay.IsBusy = false;
							folderDisplay.IsDone = true;
							this.summary.Folders.Add(folderDisplay);
							this.TransferComplete = this.CheckForAllDone(false);
						}
					}
					return;
				}
				break;
			case ErrorType.DestinationLibraryExists:
				break;
			case ErrorType.SourceFolderDoesNotExist:
				throw new NotImplementedException();
			case ErrorType.DestinationFolderExists:
			{
				MoveLibraryData library = transferError.Library;
				int copyPopupCount = library.CopyPopupCount;
				library.CopyPopupCount = copyPopupCount - 1;
				if (transferError.ErrorResult == ErrorResult.Replace)
				{
					LlTraceSource llTraceSource = this.ts;
					if (llTraceSource != null)
					{
						llTraceSource.TraceInformation(string.Format("Adding {0} from folder replace", transferError.Source.DirectoryInfo));
					}
					foreach (FolderToMove folderToMove in new List<FolderToMove>(this.GetDirectories(transferError.Source.DirectoryInfo, transferError.Destination, transferError.Source.level, transferError.Library)))
					{
						DirectoryInfo destionationDirectory = FoldersUserControlViewModel.GetDestionationDirectory(folderToMove.DirectoryInfo.FullName, transferError.Source.DirectoryInfo.FullName, transferError.Destination.FullName, this.ts);
						FolderPair item = new FolderPair
						{
							SourceFolder = folderToMove,
							DestinationFolder = destionationDirectory,
							LibraryDisplayName = transferError.Library.LibraryDisplayName
						};
						this.FolderCopyQueue.Enqueue(item);
					}
					FolderPair item2 = new FolderPair
					{
						SourceFolder = transferError.Source,
						DestinationFolder = transferError.Destination,
						LibraryDisplayName = transferError.Library.LibraryDisplayName
					};
					this.FolderCopyQueue.Enqueue(item2);
				}
				if (this.FolderCopyQueue.Count > 0 && transferError.Library.CopyPopupCount == 0)
				{
					this.OnMoveFolders(transferError.Library.LibraryDisplayName);
					return;
				}
				return;
			}
			case ErrorType.FileExists:
				throw new NotImplementedException();
			default:
				return;
			}
			LlTraceSource llTraceSource2 = this.ts;
			if (llTraceSource2 != null)
			{
				llTraceSource2.TraceInformation("In DestinationLibraryExists Complete " + transferError.Library.LibraryDisplayName);
			}
			if (transferError.ErrorResult != ErrorResult.Continue)
			{
				FolderDisplay folderDisplay2 = this.FindFolder(transferError.Library.LibraryDisplayName);
				if (folderDisplay2 != null)
				{
					folderDisplay2.IsBusy = false;
					folderDisplay2.IsDone = true;
				}
				this.TransferComplete = this.CheckForAllDone(false);
				return;
			}
			MoveLibraryData payload = new MoveLibraryData
			{
				Source = transferError.Source.DirectoryInfo,
				Destination = transferError.Destination,
				LibraryDisplayName = transferError.Library.LibraryDisplayName,
				CopyPopupCount = transferError.Library.CopyPopupCount
			};
			FolderDisplay folderDisplay3 = this.FindFolder(transferError.Library.LibraryDisplayName);
			if (folderDisplay3 != null)
			{
				folderDisplay3.IsBusy = true;
				folderDisplay3.IsDone = false;
			}
			this.eventAggregator.GetEvent<Events.MoveLibraryEvent>().Publish(payload);
			if (!this.tempTimer.IsEnabled)
			{
				this.tempTimer.Start();
				return;
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000381C File Offset: 0x00001A1C
		private void OnSelected(string folderType)
		{
			this.DisplaySpaceError = !this.CheckDestinationSize();
			if (!this.DisplaySpaceError)
			{
				this.OnTransfer.RaiseCanExecuteChanged();
				return;
			}
			foreach (FolderDisplay folderDisplay in this.Folders)
			{
				if (folderDisplay.ShellFolderData.FolderType.ToString() == folderType)
				{
					folderDisplay.Selected = false;
				}
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000AC RID: 172 RVA: 0x000038B0 File Offset: 0x00001AB0
		// (set) Token: 0x060000AD RID: 173 RVA: 0x000038B8 File Offset: 0x00001AB8
		public DelegateCommand OnChange { get; private set; }

		// Token: 0x060000AE RID: 174 RVA: 0x000038C1 File Offset: 0x00001AC1
		private bool CanOnChangeCommand()
		{
			return this.AllowChange;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000038CC File Offset: 0x00001ACC
		private void OnChangeCommand()
		{
			CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
			commonOpenFileDialog.IsFolderPicker = true;
			string text = this.DestinationBase;
			while (!Directory.Exists(text))
			{
				text = Directory.GetParent(text).FullName;
			}
			commonOpenFileDialog.InitialDirectory = text;
			if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
			{
				string fileName = commonOpenFileDialog.FileName;
				string pathRoot = Path.GetPathRoot(fileName);
				bool flag = false;
				foreach (DriveDisplay driveDisplay in this.Drives)
				{
					if (driveDisplay.DriveName == pathRoot)
					{
						flag = true;
						this.SelectedToDrive = driveDisplay;
					}
				}
				if (!flag)
				{
					MessageBox.Show("Not a valid location");
					return;
				}
				this.DestinationBase = fileName;
			}
			this.DisplaySpaceError = !this.CheckDestinationSize();
			this.OnTransfer.RaiseCanExecuteChanged();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000039B0 File Offset: 0x00001BB0
		private void ChangeDestinationBaseDrive(string drive)
		{
			if (!string.IsNullOrEmpty(this.DestinationBase))
			{
				string path = this.DestinationBase.Substring(Path.GetPathRoot(this.DestinationBase).Length);
				this.DestinationBase = Path.Combine(drive, path);
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000039F4 File Offset: 0x00001BF4
		private void ChangeSourceBaseDrive(string drive)
		{
			if (!string.IsNullOrEmpty(this.SourceBase))
			{
				string path = this.SourceBase.Substring(Path.GetPathRoot(this.DestinationBase).Length);
				this.SourceBase = Path.Combine(drive, path);
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003A38 File Offset: 0x00001C38
		private bool CheckForAllDone(bool fromTimer)
		{
			bool flag = true;
			using (List<FolderDisplay>.Enumerator enumerator = this._transferringFolders.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsDone)
					{
						flag = false;
					}
				}
			}
			if (flag)
			{
				if (!this.movedSomething && !fromTimer)
				{
					LlTraceSource llTraceSource = this.ts;
					if (llTraceSource != null)
					{
						llTraceSource.TraceError("nothing happened, make sure Undo doesn't show");
					}
					new RegSettings(this.ts).Folders = new List<string>();
					this.AllowChange = true;
					this.enableNext = false;
					this.OnNext.RaiseCanExecuteChanged();
					flag = false;
					this.enableBack = true;
					this.OnBack.RaiseCanExecuteChanged();
					this.OnTransfer.RaiseCanExecuteChanged();
					this.tempTimer.Stop();
				}
				this.transferring = false;
				this.OnTransfer.RaiseCanExecuteChanged();
			}
			return flag;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003B20 File Offset: 0x00001D20
		private void RemoveFolders()
		{
			int num = 0;
			LlTraceSource llTraceSource = this.ts;
			if (llTraceSource != null)
			{
				llTraceSource.TraceInformation(string.Format("Folders to Remove Count {0}", this.FoldersToRemoveBag.Count));
			}
			for (int i = 0; i < this.FoldersToRemoveBag.Count; i++)
			{
				FolderPair folderPair = this.FoldersToRemoveBag[i];
				if (folderPair != null)
				{
					num = Math.Max(num, folderPair.SourceFolder.level);
				}
			}
			LlTraceSource llTraceSource2 = this.ts;
			if (llTraceSource2 != null)
			{
				llTraceSource2.TraceInformation(string.Format("Folders to Remove Max Level {0}", num));
			}
			for (int j = num; j >= 0; j--)
			{
				LlTraceSource llTraceSource3 = this.ts;
				if (llTraceSource3 != null)
				{
					llTraceSource3.TraceInformation(string.Format("Processing Level {0}", j));
				}
				for (int k = 0; k < this.FoldersToRemoveBag.Count; k++)
				{
					FolderPair folderPair2 = this.FoldersToRemoveBag[k];
					if (folderPair2 != null)
					{
						LlTraceSource llTraceSource4 = this.ts;
						if (llTraceSource4 != null)
						{
							llTraceSource4.TraceInformation(string.Format("Checking to see if I should remove {0} at level {1}", folderPair2.SourceFolder.DirectoryInfo, folderPair2.SourceFolder.level));
						}
						if (folderPair2.SourceFolder.level == j)
						{
							LlTraceSource llTraceSource5 = this.ts;
							if (llTraceSource5 != null)
							{
								llTraceSource5.TraceError("removing folder " + folderPair2.SourceFolder.DirectoryInfo.FullName);
							}
							try
							{
								FolderMover.DeleteDirectory(folderPair2.SourceFolder.DirectoryInfo);
							}
							catch (Exception ex)
							{
								LlTraceSource llTraceSource6 = this.ts;
								if (llTraceSource6 != null)
								{
									llTraceSource6.TraceException(ex, "RemoveFolders");
								}
							}
						}
					}
				}
			}
			this.FoldersToRemoveBag = ImmutableList.Create<FolderPair>();
			if (this.summary.Undo)
			{
				LlTraceSource llTraceSource7 = this.ts;
				if (llTraceSource7 != null)
				{
					llTraceSource7.TraceError("cleaning up from undo");
				}
				new RegSettings(this.ts).Folders = new List<string>();
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003D14 File Offset: 0x00001F14
		private void TempTimer_Tick(object sender, EventArgs e)
		{
			LlTraceSource llTraceSource = this.ts;
			if (llTraceSource != null)
			{
				llTraceSource.TraceError("In Timer Tick");
			}
			List<FolderDisplay> list = new List<FolderDisplay>();
			List<FolderDisplay> transferringFolders = this._transferringFolders;
			lock (transferringFolders)
			{
				foreach (FolderDisplay folderDisplay in this._transferringFolders)
				{
					if (!folderDisplay.IsBusy)
					{
						folderDisplay.IsDone = true;
						this.summary.Folders.Add(folderDisplay);
						list.Add(folderDisplay);
					}
				}
			}
			bool flag2 = this.CheckForAllDone(true);
			foreach (FolderDisplay item in list)
			{
				this._transferringFolders.Remove(item);
			}
			if (flag2)
			{
				LlTraceSource llTraceSource2 = this.ts;
				if (llTraceSource2 != null)
				{
					llTraceSource2.TraceInformation("Timer Done Processing");
				}
				this.RemoveFolders();
				this.TransferComplete = true;
				this.tempTimer.Stop();
				this.enableNext = true;
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00003E64 File Offset: 0x00002064
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x00003E6C File Offset: 0x0000206C
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x060000B7 RID: 183 RVA: 0x00003E75 File Offset: 0x00002075
		private bool CanOnNextCommand()
		{
			return this.enableNext;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003E7D File Offset: 0x0000207D
		private void OnNextCommand()
		{
			LlTraceSource llTraceSource = this.ts;
			if (llTraceSource != null)
			{
				llTraceSource.TraceInformation("In On Next");
			}
			this.regionManager.RequestNavigate("MainRegion", new Uri("SummaryUserControl", UriKind.Relative));
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00003EB0 File Offset: 0x000020B0
		// (set) Token: 0x060000BA RID: 186 RVA: 0x00003EB8 File Offset: 0x000020B8
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x060000BB RID: 187 RVA: 0x00003EC1 File Offset: 0x000020C1
		private bool CanOnBackCommand()
		{
			return this.enableBack;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003ECC File Offset: 0x000020CC
		private void OnBackCommand()
		{
			LlTraceSource llTraceSource = this.ts;
			if (llTraceSource != null)
			{
				llTraceSource.TraceInformation("In On Back");
			}
			this.AllowChange = true;
			this.ShowDrives = true;
			if (new RegSettings(this.ts).RegVerificationCode.StartsWith("Serial:"))
			{
				this.regionManager.RequestNavigate("MainRegion", new Uri("MainUserControl", UriKind.Relative));
				return;
			}
			this.regionManager.RequestNavigate("MainRegion", new Uri("RegistrationUserControl", UriKind.Relative));
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00003F50 File Offset: 0x00002150
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00003F58 File Offset: 0x00002158
		public DelegateCommand OnTransfer { get; private set; }

		// Token: 0x060000BF RID: 191 RVA: 0x00003F64 File Offset: 0x00002164
		private bool CanOnTransferCommand()
		{
			if (this.transferring)
			{
				return false;
			}
			if (string.Compare(this.SourceBase, this.DestinationBase) != 0)
			{
				using (IEnumerator<FolderDisplay> enumerator = this.Folders.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Selected)
						{
							return true;
						}
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003FD4 File Offset: 0x000021D4
		private void OnTransferCommand()
		{
			LlTraceSource llTraceSource = this.ts;
			if (llTraceSource != null)
			{
				llTraceSource.TraceInformation("On Transfer Command");
			}
			this.transferring = true;
			this.OnTransfer.RaiseCanExecuteChanged();
			this.enableBack = false;
			this.OnBack.RaiseCanExecuteChanged();
			this.AllowChange = false;
			this.summary.SelectedFromDrive = this.SelectedFromDrive;
			this.summary.SelectedToDrive = this.SelectedToDrive;
			RegSettings regSettings = new RegSettings(this.ts);
			regSettings.Source = this.SourceBase;
			regSettings.SourceDrive = this.SelectedFromDrive.DriveName;
			regSettings.Destination = this.DestinationBase;
			if (this.SelectedToDrive != null)
			{
				regSettings.DestinationDrive = this.SelectedToDrive.DriveName;
			}
			List<string> list = new List<string>();
			using (IEnumerator<FolderDisplay> enumerator = this.Folders.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FolderDisplay folder = enumerator.Current;
					if (folder.Selected)
					{
						FolderDisplay folder3 = folder;
						lock (folder3)
						{
							if (folder.IsBusy)
							{
								continue;
							}
							folder.IsBusy = true;
							FolderInfo folder2 = folder.ShellFolderData.Folder;
							folder.Destination = folder2.GetPathNewDestination(this.DestinationBase);
						}
						list.Add(folder.DisplayName);
						this._transferringFolders.Add(folder);
						Task.Run<MoveResult>(() => this.StartLibraryProcessing(folder, this.DestinationBase));
					}
				}
			}
			regSettings.Folders = list;
			this.tempTimer.Interval = TimeSpan.FromSeconds(1.0);
			this.tempTimer.Start();
			LlTraceSource llTraceSource2 = this.ts;
			if (llTraceSource2 == null)
			{
				return;
			}
			llTraceSource2.TraceInformation("Leaving OnTransfer Command");
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x000041E0 File Offset: 0x000023E0
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x000041E8 File Offset: 0x000023E8
		public DelegateCommand OnCloseSpaceError { get; private set; }

		// Token: 0x060000C3 RID: 195 RVA: 0x000041F1 File Offset: 0x000023F1
		private void OnCloseSpaceErrorCommand()
		{
			this.DisplaySpaceError = false;
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x000041FA File Offset: 0x000023FA
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00004202 File Offset: 0x00002402
		public DelegateCommand OnCloseExplorerError { get; private set; }

		// Token: 0x060000C6 RID: 198 RVA: 0x0000420B File Offset: 0x0000240B
		private void OnCloseExplorerErrorCommand()
		{
			this.DisplayExplorerError = false;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004214 File Offset: 0x00002414
		private static DirectoryInfo GetDestionationDirectory(string path, string subtractPath, string addPath, LlTraceSource ts)
		{
			DirectoryInfo result = null;
			try
			{
				result = new DirectoryInfo(path.Replace(subtractPath, addPath));
			}
			catch (Exception ex)
			{
				if (ts != null)
				{
					ts.TraceException(ex, "GetDestionationDirectory");
				}
			}
			return result;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004258 File Offset: 0x00002458
		public List<FolderToMove> GetAllDirectories(MoveLibraryData library)
		{
			LlTraceSource llTraceSource = this.ts;
			if (llTraceSource != null)
			{
				llTraceSource.TraceInformation("In GetAllDirectories " + library.LibraryDisplayName);
			}
			List<FolderToMove> list = new List<FolderToMove>(this.GetDirectories(library.Source, library.Destination, 0, library));
			FolderToMove folderToMove = new FolderToMove(library.Source, 0);
			LlTraceSource llTraceSource2 = this.ts;
			if (llTraceSource2 != null)
			{
				llTraceSource2.TraceInformation("also adding top level " + folderToMove.DirectoryInfo.FullName);
			}
			list.Add(folderToMove);
			return list;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000042DC File Offset: 0x000024DC
		private List<FolderToMove> GetDirectories(DirectoryInfo source, DirectoryInfo dest, int presentLevel, MoveLibraryData library)
		{
			LlTraceSource llTraceSource = this.ts;
			if (llTraceSource != null)
			{
				llTraceSource.TraceInformation(string.Format("In GetDirectories {0} at level {1}", source, presentLevel));
			}
			List<FolderToMove> result;
			try
			{
				List<FolderToMove> list = new List<FolderToMove>();
				foreach (DirectoryInfo directoryInfo in source.GetDirectories())
				{
					LlTraceSource llTraceSource2 = this.ts;
					if (llTraceSource2 != null)
					{
						llTraceSource2.TraceInformation(string.Format("GetDirectories - adding {0}", directoryInfo));
					}
					DirectoryInfo destionationDirectory = FoldersUserControlViewModel.GetDestionationDirectory(directoryInfo.FullName, source.FullName, dest.FullName, this.ts);
					if (destionationDirectory != null)
					{
						FolderToMove folderToMove = new FolderToMove(directoryInfo, presentLevel + 1);
						if (destionationDirectory.Exists)
						{
							LlTraceSource llTraceSource3 = this.ts;
							if (llTraceSource3 != null)
							{
								llTraceSource3.TraceInformation(destionationDirectory.FullName + " already exists");
							}
							int copyPopupCount = library.CopyPopupCount;
							library.CopyPopupCount = copyPopupCount + 1;
							TransferError payload = new TransferError
							{
								Title = Resources.SkipOrReplace,
								ErrorType = ErrorType.DestinationFolderExists,
								Source = folderToMove,
								Destination = destionationDirectory,
								Library = library,
								ErrorText = string.Format(Resources.FolderExists, destionationDirectory.FullName),
								ShowReplace = true,
								ShowSkip = true
							};
							this.eventAggregator.GetEvent<Events.TransferErrorEvent>().Publish(payload);
						}
						else
						{
							list.AddRange(this.GetDirectories(directoryInfo, destionationDirectory, presentLevel + 1, library));
							list.Add(folderToMove);
						}
					}
					else
					{
						LlTraceSource llTraceSource4 = this.ts;
						if (llTraceSource4 != null)
						{
							llTraceSource4.TraceError("null destination folder in GetDirectories");
						}
					}
				}
				LlTraceSource llTraceSource5 = this.ts;
				if (llTraceSource5 != null)
				{
					llTraceSource5.TraceInformation(string.Format("GetDirectories - returning {0}", list.Count));
				}
				result = list;
			}
			catch (UnauthorizedAccessException)
			{
				result = new List<FolderToMove>();
			}
			return result;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000044B0 File Offset: 0x000026B0
		private MoveResult StartLibraryProcessing(FolderDisplay folderDisplay, string destinationBase)
		{
			MoveResult result;
			try
			{
				FolderInfo folder = folderDisplay.ShellFolderData.Folder;
				FolderInfo folderInfo = new FolderInfo(folder.GetPathNewDestination(destinationBase));
				LlTraceSource llTraceSource = this.ts;
				if (llTraceSource != null)
				{
					llTraceSource.TraceInformation(string.Format("Processing {0}", folder.DirInfo));
				}
				LlTraceSource llTraceSource2 = this.ts;
				if (llTraceSource2 != null)
				{
					llTraceSource2.TraceInformation(string.Format("AfterLock {0}", folder.DirInfo));
				}
				folder.StopGetSize();
				MoveLibraryData moveLibraryData = new MoveLibraryData
				{
					Source = folder.DirInfo,
					Destination = folderInfo.DirInfo,
					LibraryDisplayName = folderDisplay.DisplayName,
					CopyPopupCount = 0
				};
				if (!folder.DirInfo.Exists)
				{
					LlTraceSource llTraceSource3 = this.ts;
					if (llTraceSource3 != null)
					{
						llTraceSource3.TraceError(string.Format("{0} does not exist, so not moving", folder.DirInfo));
					}
					TransferError payload = new TransferError
					{
						Title = Resources.NoSource,
						ErrorType = ErrorType.SourceLibraryDoesNotExist,
						Source = new FolderToMove(folder.DirInfo, 0),
						Destination = null,
						Library = moveLibraryData,
						ErrorText = string.Format(Resources.SourceDoesNotExist, folder.DirInfo.FullName),
						ShowContinue = true
					};
					this.eventAggregator.GetEvent<Events.TransferErrorEvent>().Publish(payload);
					result = MoveResult.SourceDoesNotExist;
				}
				else if (folderInfo.DirInfo.Exists)
				{
					LlTraceSource llTraceSource4 = this.ts;
					if (llTraceSource4 != null)
					{
						llTraceSource4.TraceError(string.Format("{0} exists", folderInfo.DirInfo));
					}
					TransferError payload2 = new TransferError
					{
						Title = Resources.Overwrite,
						ErrorType = ErrorType.DestinationLibraryExists,
						Source = new FolderToMove(folder.DirInfo, 0),
						Destination = folderInfo.DirInfo,
						Library = moveLibraryData,
						ErrorText = string.Format(Resources.DestinationExists, folderInfo.DirInfo.FullName),
						ShowContinue = true,
						ShowCancel = true
					};
					LlTraceSource llTraceSource5 = this.ts;
					if (llTraceSource5 != null)
					{
						llTraceSource5.TraceError("Publishing transferError event");
					}
					this.eventAggregator.GetEvent<Events.TransferErrorEvent>().Publish(payload2);
					result = MoveResult.DestinationExists;
				}
				else
				{
					LlTraceSource llTraceSource6 = this.ts;
					if (llTraceSource6 != null)
					{
						llTraceSource6.TraceInformation("publishing moveLibraryData");
					}
					this.eventAggregator.GetEvent<Events.MoveLibraryEvent>().Publish(moveLibraryData);
					result = MoveResult.Success;
				}
			}
			catch (Exception)
			{
				result = MoveResult.UnexpectedException;
			}
			return result;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004708 File Offset: 0x00002908
		private void OnMoveLibrary(MoveLibraryData moveLibaryData)
		{
			LlTraceSource llTraceSource = this.ts;
			if (llTraceSource != null)
			{
				llTraceSource.TraceInformation("in OnMoveLibrary " + moveLibaryData.LibraryDisplayName);
			}
			foreach (FolderToMove folderToMove in this.GetAllDirectories(moveLibaryData))
			{
				DirectoryInfo destionationDirectory = FoldersUserControlViewModel.GetDestionationDirectory(folderToMove.DirectoryInfo.FullName, moveLibaryData.Source.FullName, moveLibaryData.Destination.FullName, this.ts);
				FolderPair item = new FolderPair
				{
					SourceFolder = folderToMove,
					DestinationFolder = destionationDirectory,
					LibraryDisplayName = moveLibaryData.LibraryDisplayName
				};
				this.FolderCopyQueue.Enqueue(item);
			}
			LlTraceSource llTraceSource2 = this.ts;
			if (llTraceSource2 != null)
			{
				llTraceSource2.TraceInformation("in OnMoveLibrary " + moveLibaryData.LibraryDisplayName);
			}
			if (this.FolderCopyQueue.Count > 0 && moveLibaryData.CopyPopupCount == 0)
			{
				this.OnMoveFolders(moveLibaryData.LibraryDisplayName);
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004814 File Offset: 0x00002A14
		private void OnMoveFolders(string libraryDisplayName)
		{
			LlTraceSource llTraceSource = this.ts;
			if (llTraceSource != null)
			{
				llTraceSource.TraceError("in OnMoveFolders " + libraryDisplayName);
			}
			MoveResult moveResult = MoveResult.Success;
			foreach (FolderPair folderPair in this.FolderCopyQueue)
			{
				if (string.Compare(folderPair.LibraryDisplayName, libraryDisplayName) == 0)
				{
					FolderMover folderMover = new FolderMover(folderPair.SourceFolder.DirectoryInfo, folderPair.DestinationFolder, this.ts);
					LlTraceSource llTraceSource2 = this.ts;
					if (llTraceSource2 != null)
					{
						llTraceSource2.TraceError(string.Format("Starting Move of {0}", folderPair.SourceFolder.DirectoryInfo));
					}
					MoveResult moveResult2 = folderMover.Move();
					if (moveResult2 != MoveResult.Success)
					{
						moveResult = moveResult2;
					}
					else
					{
						this.movedSomething = true;
						LlTraceSource llTraceSource3 = this.ts;
						if (llTraceSource3 != null)
						{
							llTraceSource3.TraceError(string.Format("Adding folder to remove {0}", folderPair.SourceFolder.DirectoryInfo));
						}
						object @lock = this._lock;
						lock (@lock)
						{
							this.FoldersToRemoveBag = this.FoldersToRemoveBag.Add(folderPair);
						}
					}
				}
			}
			FolderDisplay folderDisplay = this.FindFolder(libraryDisplayName);
			if (moveResult == MoveResult.Success || moveResult == MoveResult.ErrorDeleting)
			{
				LlTraceSource llTraceSource4 = this.ts;
				if (llTraceSource4 != null)
				{
					llTraceSource4.TraceError(string.Format("Checking {0} for redirects", folderDisplay.ShellFolderData.Folder));
				}
				FolderInfo folder = folderDisplay.ShellFolderData.Folder;
				string pathNewDestination = folder.GetPathNewDestination(this.DestinationBase);
				FolderInfo destinationFolder = new FolderInfo(pathNewDestination);
				folderDisplay.ShellFolderData.RedirectTo(destinationFolder);
				if ((folderDisplay.ShellFolderData.FolderType != ShellFolderType.Music && folderDisplay.ShellFolderData.FolderType != ShellFolderType.Pictures && folderDisplay.ShellFolderData.FolderType != ShellFolderType.Videos) || this._documentsFolderData == null)
				{
					goto IL_221;
				}
				ShellFolderData documentsFolderData = this._documentsFolderData;
				lock (documentsFolderData)
				{
					this._documentsFolderData.Folder.RedirectJunctionPoints(folder.DirInfo.FullName, pathNewDestination, this.ts);
					goto IL_221;
				}
			}
			LlTraceSource llTraceSource5 = this.ts;
			if (llTraceSource5 != null)
			{
				llTraceSource5.TraceError("Error moving " + libraryDisplayName + " " + moveResult.ToString());
			}
			IL_221:
			LlTraceSource llTraceSource6 = this.ts;
			if (llTraceSource6 != null)
			{
				llTraceSource6.TraceInformation("Before Lock IsBusy");
			}
			FolderDisplay obj = folderDisplay;
			lock (obj)
			{
				folderDisplay.IsBusy = false;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00004AB0 File Offset: 0x00002CB0
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00004AB8 File Offset: 0x00002CB8
		public DelegateCommand SelectAll { get; private set; }

		// Token: 0x060000CF RID: 207 RVA: 0x00004AC1 File Offset: 0x00002CC1
		private bool CanDoSelectAllCommand()
		{
			return this.AllowChange;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00004ACC File Offset: 0x00002CCC
		private void DoSelectAllCommand()
		{
			bool allSelected = this.AllSelected;
			foreach (FolderDisplay folderDisplay in this.Folders)
			{
				if (folderDisplay.FolderName.Contains(this.SourceBase))
				{
					folderDisplay.Selected = allSelected;
					this.DisplaySpaceError = !this.CheckDestinationSize();
				}
			}
			if (!this.DisplaySpaceError)
			{
				this.OnTransfer.RaiseCanExecuteChanged();
				return;
			}
			foreach (FolderDisplay folderDisplay2 in this.Folders)
			{
				folderDisplay2.Selected = false;
			}
			this.AllSelected = false;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00004B98 File Offset: 0x00002D98
		private void TrySetBase(ShellFolderData sf)
		{
			if (!this.summary.Undo && !sf.IsWithinOneDrive)
			{
				this.SourceBase = sf.Folder.DirInfo.Parent.FullName;
				this.DestinationBase = sf.Folder.DirInfo.Parent.FullName;
				this.ChangeDestinationBaseDrive(this.SelectedToDrive.DriveName);
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00004C04 File Offset: 0x00002E04
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			string iconUri = null;
			RegSettings regSettings = new RegSettings(this.ts);
			this.Folders.Clear();
			foreach (ShellFolderData shellFolderData in this.shellFolderInfo.UserShellFolders)
			{
				string text;
				switch (shellFolderData.FolderType)
				{
				case ShellFolderType.Documents:
					text = Resources.Documents;
					iconUri = "/MainUI;component/Assets/DocIcon.png";
					this._documentsFolderData = shellFolderData;
					this.TrySetBase(shellFolderData);
					break;
				case ShellFolderType.Music:
					text = Resources.Music;
					iconUri = "/MainUI;component/Assets/MusIcon.png";
					this.TrySetBase(shellFolderData);
					break;
				case ShellFolderType.Pictures:
					text = Resources.Pictures;
					iconUri = "/MainUI;component/Assets/PicIcon.png";
					this.TrySetBase(shellFolderData);
					break;
				case ShellFolderType.Videos:
					text = Resources.Videos;
					iconUri = "/MainUI;component/Assets/VidIcon.png";
					this.TrySetBase(shellFolderData);
					break;
				case ShellFolderType.Downloads:
					text = Resources.Downloads;
					iconUri = "/MainUI;component/Assets/OthIcon.png";
					this.TrySetBase(shellFolderData);
					break;
				default:
					text = null;
					break;
				}
				if (text != null)
				{
					this.Folders.Add(new FolderDisplay(shellFolderData, text, iconUri, this.eventAggregator));
				}
			}
			this.AllowChange = !this.summary.Undo;
			this.ShowDrives = !this.summary.Undo;
			this.transferring = false;
			this.OnTransfer.RaiseCanExecuteChanged();
			this.OnChange.RaiseCanExecuteChanged();
			if (this.summary.Undo)
			{
				this.TransferButtonText = Resources.Undo;
				LlTraceSource llTraceSource = this.ts;
				if (llTraceSource != null)
				{
					llTraceSource.TraceVerbose("Undo: DestinationDrive: " + regSettings.DestinationDrive);
				}
				using (IEnumerator<DriveDisplay> enumerator2 = this.Drives.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						DriveDisplay driveDisplay = enumerator2.Current;
						LlTraceSource llTraceSource2 = this.ts;
						if (llTraceSource2 != null)
						{
							llTraceSource2.TraceVerbose("Undo: DriveName " + driveDisplay.DriveName);
						}
						if (driveDisplay.DriveName == regSettings.SourceDrive)
						{
							this.SelectedToDrive = driveDisplay;
						}
						else if (driveDisplay.DriveName == regSettings.DestinationDrive)
						{
							this.SelectedFromDrive = driveDisplay;
							LlTraceSource llTraceSource3 = this.ts;
							if (llTraceSource3 != null)
							{
								llTraceSource3.TraceVerbose("Undo: DestinationBase " + regSettings.Source);
							}
							this.DestinationBase = regSettings.Source;
						}
					}
					goto IL_274;
				}
			}
			this.TransferButtonText = Resources.Transfer;
			IEventAggregator eventAggregator = this.eventAggregator;
			if (eventAggregator != null)
			{
				eventAggregator.GetEvent<Events.FromDriveChangeEvent>().Publish(this.SelectedFromDrive.Root);
			}
			IL_274:
			foreach (FolderDisplay folderDisplay in this.Folders)
			{
				folderDisplay.SetSize();
				if (this.summary.Undo)
				{
					using (List<string>.Enumerator enumerator4 = regSettings.Folders.GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							if (enumerator4.Current == folderDisplay.DisplayName)
							{
								folderDisplay.Selected = true;
							}
						}
					}
				}
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00004F44 File Offset: 0x00003144
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00004F47 File Offset: 0x00003147
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00004F4C File Offset: 0x0000314C
		private bool CheckDestinationSize()
		{
			long num = 0L;
			foreach (FolderDisplay folderDisplay in this.Folders)
			{
				if (folderDisplay.Selected)
				{
					num += folderDisplay.ShellFolderData.Folder.Size;
					if (num > this.SelectedToDrive.GetFreeSpace)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x04000032 RID: 50
		private readonly IRegionManager regionManager;

		// Token: 0x04000033 RID: 51
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000034 RID: 52
		private readonly ISummary summary;

		// Token: 0x04000035 RID: 53
		private readonly LlTraceSource ts;

		// Token: 0x04000036 RID: 54
		private ShellFolderData _documentsFolderData;

		// Token: 0x04000037 RID: 55
		private readonly ShellFolderInfo shellFolderInfo;

		// Token: 0x04000038 RID: 56
		private readonly object _lock = new object();

		// Token: 0x0400003A RID: 58
		private readonly List<FolderDisplay> _transferringFolders = new List<FolderDisplay>();

		// Token: 0x0400003B RID: 59
		private readonly DispatcherTimer tempTimer = new DispatcherTimer();

		// Token: 0x0400003C RID: 60
		private string SourceBase;

		// Token: 0x0400003D RID: 61
		private bool enableNext;

		// Token: 0x0400003E RID: 62
		private bool enableBack = true;

		// Token: 0x0400003F RID: 63
		private bool movedSomething;

		// Token: 0x04000040 RID: 64
		private bool transferring;

		// Token: 0x04000041 RID: 65
		private readonly ConcurrentQueue<FolderPair> FolderCopyQueue = new ConcurrentQueue<FolderPair>();

		// Token: 0x04000042 RID: 66
		private ImmutableList<FolderPair> FoldersToRemoveBag = ImmutableList.Create<FolderPair>();

		// Token: 0x04000043 RID: 67
		private bool _AllSelected;

		// Token: 0x04000044 RID: 68
		private bool _TransferComplete;

		// Token: 0x04000046 RID: 70
		private DriveDisplay _SelectedFromDrive;

		// Token: 0x04000047 RID: 71
		private DriveDisplay _SelectedToDrive;

		// Token: 0x04000048 RID: 72
		private bool _AllowChange;

		// Token: 0x04000049 RID: 73
		private string _DestinationBase;

		// Token: 0x0400004A RID: 74
		private bool _ShowError;

		// Token: 0x0400004B RID: 75
		private bool _DisplaySpaceError;

		// Token: 0x0400004C RID: 76
		private bool _ShowDrives;

		// Token: 0x0400004D RID: 77
		private bool _DisplayExplorerError;

		// Token: 0x0400004E RID: 78
		private ObservableCollection<string> _ExplorerFolders;

		// Token: 0x0400004F RID: 79
		private string _TransferButtonText;
	}
}
