using System;
using System.ComponentModel;
using System.Windows.Media;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x02000002 RID: 2
	public class ApplicationInfo : INotifyPropertyChanged
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public ApplicationInfo(ApplicationData data)
		{
			this.Data = data;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000002 RID: 2 RVA: 0x00002060 File Offset: 0x00000260
		// (remove) Token: 0x06000003 RID: 3 RVA: 0x00002098 File Offset: 0x00000298
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000004 RID: 4 RVA: 0x000020CD File Offset: 0x000002CD
		private void OnPropertyChanged(string prop)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged == null)
			{
				return;
			}
			propertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020E6 File Offset: 0x000002E6
		public ApplicationData Data { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x000020EE File Offset: 0x000002EE
		public string AppId
		{
			get
			{
				return this.Data.AppId;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020FB File Offset: 0x000002FB
		public ulong Id
		{
			get
			{
				return this.Data.Id;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002108 File Offset: 0x00000308
		public string AppName
		{
			get
			{
				return this.Data.Name;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002115 File Offset: 0x00000315
		public string Message
		{
			get
			{
				return this.Data.Message;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002122 File Offset: 0x00000322
		public SelectedReason Reason
		{
			get
			{
				return this.Data.Reason;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000212F File Offset: 0x0000032F
		public bool DefaultSelected
		{
			get
			{
				return this.Data.DefaultSelected;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000C RID: 12 RVA: 0x0000213C File Offset: 0x0000033C
		public bool IsMatching
		{
			get
			{
				return this.Data.IsMatching;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002149 File Offset: 0x00000349
		public ulong AppDiskSpace
		{
			get
			{
				return this.Data.AppDiskSpace;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002158 File Offset: 0x00000358
		public AppColor Color
		{
			get
			{
				AppColor result = AppColor.Yellow;
				if (this.Data.Safety == TransferSafety.High)
				{
					result = AppColor.Green;
				}
				else if (this.Data.Safety == TransferSafety.Low)
				{
					result = AppColor.Red;
				}
				return result;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600000F RID: 15 RVA: 0x0000218A File Offset: 0x0000038A
		// (set) Token: 0x06000010 RID: 16 RVA: 0x00002197 File Offset: 0x00000397
		public bool Selected
		{
			get
			{
				return this.Data.Selected;
			}
			set
			{
				this.Data.Selected = value;
				this.OnPropertyChanged("Selected");
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000021B0 File Offset: 0x000003B0
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000021B8 File Offset: 0x000003B8
		public ImageSource AppImage { get; set; }
	}
}
