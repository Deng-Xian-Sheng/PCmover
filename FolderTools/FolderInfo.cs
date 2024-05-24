using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Laplink.Tools.Helpers;
using Laplink.Tools.Ui.Converters;

namespace Laplink.Pcmover.Configurator.FolderTools
{
	// Token: 0x02000003 RID: 3
	public class FolderInfo : IDisposable, INotifyPropertyChanged
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600000E RID: 14 RVA: 0x00002200 File Offset: 0x00000400
		// (remove) Token: 0x0600000F RID: 15 RVA: 0x00002238 File Offset: 0x00000438
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000010 RID: 16 RVA: 0x0000226D File Offset: 0x0000046D
		public DirectoryInfo DirInfo { get; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002275 File Offset: 0x00000475
		// (set) Token: 0x06000012 RID: 18 RVA: 0x0000227D File Offset: 0x0000047D
		public long Size { get; private set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002286 File Offset: 0x00000486
		public string DisplaySize
		{
			get
			{
				return FileSizeConverter.ToString(this.Size);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002293 File Offset: 0x00000493
		// (set) Token: 0x06000015 RID: 21 RVA: 0x0000229B File Offset: 0x0000049B
		public bool IsSizeKnown
		{
			get
			{
				return this._isSizeKnown;
			}
			private set
			{
				if (this._isSizeKnown != value)
				{
					this._isSizeKnown = value;
					this.PropertyChanged(this, new PropertyChangedEventArgs("IsSizeKnown"));
				}
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000022C3 File Offset: 0x000004C3
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000022CB File Offset: 0x000004CB
		public bool IsGetSizeInProgress { get; private set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000022D4 File Offset: 0x000004D4
		public bool IsOnDriveC
		{
			get
			{
				return string.Compare(this.DirInfo.Root.FullName, "C:\\", true) == 0;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000022F4 File Offset: 0x000004F4
		public FolderInfo(DirectoryInfo dir)
		{
			this.DirInfo = dir;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002303 File Offset: 0x00000503
		public FolderInfo(string path) : this(new DirectoryInfo(path))
		{
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002311 File Offset: 0x00000511
		public string GetPathNewDrive(char driveLetter)
		{
			return driveLetter.ToString() + this.DirInfo.FullName.Substring(1);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002330 File Offset: 0x00000530
		public string GetPathNewDestination(string destination)
		{
			return destination + "\\" + this.DirInfo.Name;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002348 File Offset: 0x00000548
		public Task<long> GetSizeAsync()
		{
			lock (this)
			{
				if (this.IsSizeKnown || this.IsGetSizeInProgress)
				{
					return Task.FromResult<long>(this.Size);
				}
				this.IsGetSizeInProgress = true;
			}
			return Task.Run<long>(new Func<long>(this.GetSize));
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000023B8 File Offset: 0x000005B8
		public void StopGetSize()
		{
			this.IsGetSizeInProgress = false;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000023C1 File Offset: 0x000005C1
		private long GetSize()
		{
			this.Size = 0L;
			this.GetSize(this.DirInfo);
			if (this.IsGetSizeInProgress)
			{
				this.IsSizeKnown = true;
			}
			this.IsGetSizeInProgress = false;
			return this.Size;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000023F4 File Offset: 0x000005F4
		private void GetSize(DirectoryInfo dirInfo)
		{
			if (dirInfo.Attributes.HasFlag(FileAttributes.ReparsePoint))
			{
				return;
			}
			try
			{
				foreach (FileInfo fileInfo in dirInfo.GetFiles())
				{
					this.Size += fileInfo.Length;
				}
			}
			catch (Exception getSizeException)
			{
				this._getSizeException = getSizeException;
			}
			if (!this.IsGetSizeInProgress)
			{
				return;
			}
			try
			{
				foreach (DirectoryInfo dirInfo2 in dirInfo.GetDirectories())
				{
					this.GetSize(dirInfo2);
					if (!this.IsGetSizeInProgress)
					{
						break;
					}
				}
			}
			catch (Exception getSizeException2)
			{
				this._getSizeException = getSizeException2;
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000024BC File Offset: 0x000006BC
		public void Dispose()
		{
			this.StopGetSize();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000024C4 File Offset: 0x000006C4
		public void RedirectJunctionPoints(string sourcePath, string destinationPath, LlTraceSource ts)
		{
			foreach (DirectoryInfo directoryInfo in this.DirInfo.GetDirectories())
			{
				if (directoryInfo.Attributes.HasFlag(FileAttributes.ReparsePoint) && string.Compare(JunctionPoint.GetTarget(directoryInfo.FullName), sourcePath, true) == 0)
				{
					if (ts != null)
					{
						ts.TraceVerbose(string.Concat(new string[]
						{
							"Found junction point at ",
							directoryInfo.FullName,
							" referencing ",
							sourcePath,
							". Redirecting it to ",
							destinationPath
						}));
					}
					JunctionPoint.Create(directoryInfo.FullName, destinationPath, true);
					if (ts != null)
					{
						ts.TraceVerbose("Redirection complete");
					}
				}
			}
		}

		// Token: 0x04000009 RID: 9
		private bool _isSizeKnown;

		// Token: 0x0400000B RID: 11
		private Exception _getSizeException;
	}
}
