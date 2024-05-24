using System;
using System.ComponentModel;
using System.IO;
using Laplink.Pcmover.Configurator.FolderTools;
using Laplink.Tools.Ui.Converters;

namespace MainUI
{
	// Token: 0x02000005 RID: 5
	public class ProgramFilesFolder : INotifyPropertyChanged, IDisposable
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600002E RID: 46 RVA: 0x00002438 File Offset: 0x00000638
		// (remove) Token: 0x0600002F RID: 47 RVA: 0x00002470 File Offset: 0x00000670
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000024A5 File Offset: 0x000006A5
		public string Name { get; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000031 RID: 49 RVA: 0x000024AD File Offset: 0x000006AD
		// (set) Token: 0x06000032 RID: 50 RVA: 0x000024B5 File Offset: 0x000006B5
		public FolderInfo Folder32 { get; private set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000024BE File Offset: 0x000006BE
		// (set) Token: 0x06000034 RID: 52 RVA: 0x000024C6 File Offset: 0x000006C6
		public FolderInfo Folder64 { get; private set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000024CF File Offset: 0x000006CF
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000024D7 File Offset: 0x000006D7
		public bool Is64BitOperatingSystem { get; private set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000024E0 File Offset: 0x000006E0
		// (set) Token: 0x06000038 RID: 56 RVA: 0x000024E8 File Offset: 0x000006E8
		public bool IsBusy
		{
			get
			{
				return this._IsBusy;
			}
			set
			{
				this._IsBusy = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("IsBusy"));
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000039 RID: 57 RVA: 0x0000250C File Offset: 0x0000070C
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002514 File Offset: 0x00000714
		public bool IsDone
		{
			get
			{
				return this._IsDone;
			}
			set
			{
				this._IsDone = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("IsDone"));
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002538 File Offset: 0x00000738
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002540 File Offset: 0x00000740
		public bool Selected
		{
			get
			{
				return this._Selected;
			}
			set
			{
				this._Selected = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("Selected"));
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002564 File Offset: 0x00000764
		public string BaseDisplayName
		{
			get
			{
				if (!this.Is64BitOperatingSystem)
				{
					return this.Name;
				}
				if (this.Folder32 == null)
				{
					return this.Name + " (64-bit)";
				}
				if (this.Folder64 == null)
				{
					return this.Name + " (32-bit)";
				}
				return this.Name + " (Both)";
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000025C4 File Offset: 0x000007C4
		public string DisplayName
		{
			get
			{
				if ((this.Folder32 == null || this.Folder32.IsSizeKnown) && (this.Folder64 == null || this.Folder64.IsSizeKnown))
				{
					long lngBytes = ((this.Folder32 == null) ? 0L : this.Folder32.Size) + ((this.Folder64 == null) ? 0L : this.Folder64.Size);
					return this.BaseDisplayName + " - " + FileSizeConverter.ToString(lngBytes);
				}
				return this.BaseDisplayName;
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000264E File Offset: 0x0000084E
		public override string ToString()
		{
			return this.DisplayName;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002658 File Offset: 0x00000858
		public ProgramFilesFolder(FolderInfo folder, bool? is64Bit)
		{
			this.Name = folder.DirInfo.Name;
			this.IsDone = false;
			this.IsBusy = false;
			if (is64Bit == null)
			{
				this.Is64BitOperatingSystem = false;
				this.Folder32 = folder;
			}
			else
			{
				this.Is64BitOperatingSystem = true;
				if (is64Bit.Value)
				{
					this.Folder64 = folder;
				}
				else
				{
					this.Folder32 = folder;
				}
			}
			folder.PropertyChanged += this.Folder_PropertyChanged;
			folder.GetSizeAsync();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000026DC File Offset: 0x000008DC
		public ProgramFilesFolder(DirectoryInfo dir, bool? is64Bit) : this(new FolderInfo(dir), is64Bit)
		{
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000026EB File Offset: 0x000008EB
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposedValue)
			{
				if (disposing)
				{
					FolderInfo folder = this.Folder32;
					if (folder != null)
					{
						folder.StopGetSize();
					}
					FolderInfo folder2 = this.Folder64;
					if (folder2 != null)
					{
						folder2.StopGetSize();
					}
				}
				this.disposedValue = true;
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00002721 File Offset: 0x00000921
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00002730 File Offset: 0x00000930
		private void Folder_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "IsSizeKnown")
			{
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged != null)
				{
					propertyChanged(this, new PropertyChangedEventArgs("DisplayName"));
				}
			}
			if (e.PropertyName == "IsBusy")
			{
				PropertyChangedEventHandler propertyChanged2 = this.PropertyChanged;
				if (propertyChanged2 != null)
				{
					propertyChanged2(this, new PropertyChangedEventArgs("IsBusy"));
				}
			}
			if (e.PropertyName == "IsDone")
			{
				PropertyChangedEventHandler propertyChanged3 = this.PropertyChanged;
				if (propertyChanged3 != null)
				{
					propertyChanged3(this, new PropertyChangedEventArgs("IsDone"));
				}
			}
			if (e.PropertyName == "Selected")
			{
				PropertyChangedEventHandler propertyChanged4 = this.PropertyChanged;
				if (propertyChanged4 == null)
				{
					return;
				}
				propertyChanged4(this, new PropertyChangedEventArgs("Selected"));
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000027F4 File Offset: 0x000009F4
		public void AddFolder(FolderInfo folder)
		{
			if (this.Folder32 == null)
			{
				this.Folder32 = folder;
			}
			else
			{
				if (this.Folder64 != null)
				{
					return;
				}
				this.Folder64 = folder;
			}
			this.Is64BitOperatingSystem = true;
			folder.PropertyChanged += this.Folder_PropertyChanged;
			folder.GetSizeAsync();
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged == null)
			{
				return;
			}
			propertyChanged(this, new PropertyChangedEventArgs("DisplayName"));
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000285F File Offset: 0x00000A5F
		public void AddFolder(DirectoryInfo dir)
		{
			this.AddFolder(new FolderInfo(dir));
		}

		// Token: 0x04000015 RID: 21
		private bool _IsBusy;

		// Token: 0x04000016 RID: 22
		private bool _IsDone;

		// Token: 0x04000017 RID: 23
		private bool _Selected;

		// Token: 0x04000018 RID: 24
		private bool disposedValue;
	}
}
