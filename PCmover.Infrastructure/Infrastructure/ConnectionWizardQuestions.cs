using System;
using Prism.Mvvm;

namespace PCmover.Infrastructure
{
	// Token: 0x0200000B RID: 11
	public class ConnectionWizardQuestions : BindableBase
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00002853 File Offset: 0x00000A53
		// (set) Token: 0x06000044 RID: 68 RVA: 0x0000285B File Offset: 0x00000A5B
		public bool UsbCableYes
		{
			get
			{
				return this._UsbCableYes;
			}
			set
			{
				this.SetProperty<bool>(ref this._UsbCableYes, value, "UsbCableYes");
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00002870 File Offset: 0x00000A70
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00002878 File Offset: 0x00000A78
		public bool UsbCableNo
		{
			get
			{
				return this._UsbCableNo;
			}
			set
			{
				this.SetProperty<bool>(ref this._UsbCableNo, value, "UsbCableNo");
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000047 RID: 71 RVA: 0x0000288D File Offset: 0x00000A8D
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00002895 File Offset: 0x00000A95
		public bool EthernetPortLocal
		{
			get
			{
				return this._EthernetPortLocal;
			}
			set
			{
				this.SetProperty<bool>(ref this._EthernetPortLocal, value, "EthernetPortLocal");
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000028AA File Offset: 0x00000AAA
		// (set) Token: 0x0600004A RID: 74 RVA: 0x000028B2 File Offset: 0x00000AB2
		public bool WiFiLocal
		{
			get
			{
				return this._WiFiLocal;
			}
			set
			{
				this.SetProperty<bool>(ref this._WiFiLocal, value, "WiFiLocal");
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000028C7 File Offset: 0x00000AC7
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000028CF File Offset: 0x00000ACF
		public bool EthernetPortRemoteYes
		{
			get
			{
				return this._EthernetPortRemoteYes;
			}
			set
			{
				this.SetProperty<bool>(ref this._EthernetPortRemoteYes, value, "EthernetPortRemoteYes");
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000028E4 File Offset: 0x00000AE4
		// (set) Token: 0x0600004E RID: 78 RVA: 0x000028EC File Offset: 0x00000AEC
		public bool EthernetPortRemoteNo
		{
			get
			{
				return this._EthernetPortRemoteNo;
			}
			set
			{
				this.SetProperty<bool>(ref this._EthernetPortRemoteNo, value, "EthernetPortRemoteNo");
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00002901 File Offset: 0x00000B01
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00002909 File Offset: 0x00000B09
		public bool EthernetCableYes
		{
			get
			{
				return this._EthernetCableYes;
			}
			set
			{
				this.SetProperty<bool>(ref this._EthernetCableYes, value, "EthernetCableYes");
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000051 RID: 81 RVA: 0x0000291E File Offset: 0x00000B1E
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002926 File Offset: 0x00000B26
		public bool EthernetCableNo
		{
			get
			{
				return this._EthernetCableNo;
			}
			set
			{
				this.SetProperty<bool>(ref this._EthernetCableNo, value, "EthernetCableNo");
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000053 RID: 83 RVA: 0x0000293B File Offset: 0x00000B3B
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00002943 File Offset: 0x00000B43
		public bool WiFiRemoteYes
		{
			get
			{
				return this._WiFiRemoteYes;
			}
			set
			{
				this.SetProperty<bool>(ref this._WiFiRemoteYes, value, "WiFiRemoteYes");
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002958 File Offset: 0x00000B58
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00002960 File Offset: 0x00000B60
		public bool WiFiRemoteNo
		{
			get
			{
				return this._WiFiRemoteNo;
			}
			set
			{
				this.SetProperty<bool>(ref this._WiFiRemoteNo, value, "WiFiRemoteNo");
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002975 File Offset: 0x00000B75
		// (set) Token: 0x06000058 RID: 88 RVA: 0x0000297D File Offset: 0x00000B7D
		public bool CrossoverCableNo
		{
			get
			{
				return this._CrossoverCableNo;
			}
			set
			{
				this.SetProperty<bool>(ref this._CrossoverCableNo, value, "CrossoverCableNo");
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002992 File Offset: 0x00000B92
		// (set) Token: 0x0600005A RID: 90 RVA: 0x0000299A File Offset: 0x00000B9A
		public bool CrossoverCableYes
		{
			get
			{
				return this._CrossoverCableYes;
			}
			set
			{
				this.SetProperty<bool>(ref this._CrossoverCableYes, value, "CrossoverCableYes");
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600005B RID: 91 RVA: 0x000029AF File Offset: 0x00000BAF
		// (set) Token: 0x0600005C RID: 92 RVA: 0x000029B7 File Offset: 0x00000BB7
		public bool ExternalUsbDriveYes
		{
			get
			{
				return this._ExternalUsbDriveYes;
			}
			set
			{
				this.SetProperty<bool>(ref this._ExternalUsbDriveYes, value, "ExternalUsbDriveYes");
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600005D RID: 93 RVA: 0x000029CC File Offset: 0x00000BCC
		// (set) Token: 0x0600005E RID: 94 RVA: 0x000029D4 File Offset: 0x00000BD4
		public bool ExternalUsbDriveNo
		{
			get
			{
				return this._ExternalUsbDriveNo;
			}
			set
			{
				this.SetProperty<bool>(ref this._ExternalUsbDriveNo, value, "ExternalUsbDriveNo");
			}
		}

		// Token: 0x0400001A RID: 26
		private bool _UsbCableYes;

		// Token: 0x0400001B RID: 27
		private bool _UsbCableNo;

		// Token: 0x0400001C RID: 28
		private bool _EthernetPortLocal;

		// Token: 0x0400001D RID: 29
		private bool _WiFiLocal;

		// Token: 0x0400001E RID: 30
		private bool _EthernetPortRemoteYes;

		// Token: 0x0400001F RID: 31
		private bool _EthernetPortRemoteNo;

		// Token: 0x04000020 RID: 32
		private bool _EthernetCableYes;

		// Token: 0x04000021 RID: 33
		private bool _EthernetCableNo;

		// Token: 0x04000022 RID: 34
		private bool _WiFiRemoteYes;

		// Token: 0x04000023 RID: 35
		private bool _WiFiRemoteNo;

		// Token: 0x04000024 RID: 36
		private bool _CrossoverCableNo;

		// Token: 0x04000025 RID: 37
		private bool _CrossoverCableYes;

		// Token: 0x04000026 RID: 38
		private bool _ExternalUsbDriveYes;

		// Token: 0x04000027 RID: 39
		private bool _ExternalUsbDriveNo;
	}
}
