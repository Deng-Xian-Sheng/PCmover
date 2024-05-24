using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Laplink.Tools.Popups;
using PcmBrandUI.Properties;
using PCmover.Infrastructure.Properties;
using PCmover.Tools;

namespace PCmover.Infrastructure
{
	// Token: 0x02000010 RID: 16
	[XmlRoot("Policy", IsNullable = false)]
	public class DefaultPolicy : IMessageBoxPolicy, IUpgradeable
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002A4C File Offset: 0x00000C4C
		[XmlIgnore]
		public static bool InDebugMode { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00002A53 File Offset: 0x00000C53
		[XmlIgnore]
		public static bool UseTestCloudSettings
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002A56 File Offset: 0x00000C56
		[XmlIgnore]
		public static bool SerializePlainText
		{
			get
			{
				return DefaultPolicy.InDebugMode;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00002A5D File Offset: 0x00000C5D
		[XmlIgnore]
		public static bool EnableAuthentication
		{
			get
			{
				return !DefaultPolicy.InDebugMode;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002A56 File Offset: 0x00000C56
		[XmlIgnore]
		public static bool IgnoreRecorded
		{
			get
			{
				return DefaultPolicy.InDebugMode;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00002A56 File Offset: 0x00000C56
		[XmlIgnore]
		private static bool IgnoreType
		{
			get
			{
				return DefaultPolicy.InDebugMode;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600006E RID: 110 RVA: 0x00002A67 File Offset: 0x00000C67
		public static string RecordedPolicyPath
		{
			get
			{
				return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Laplink\\PCmover\\RecordedProfile.pol");
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002A7A File Offset: 0x00000C7A
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00002A82 File Offset: 0x00000C82
		[XmlIgnore]
		public string PolicyPath { get; private set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00002A8B File Offset: 0x00000C8B
		[XmlIgnore]
		public static bool EnforceSignedPolicy
		{
			get
			{
				return Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_EnforceSignedPolicy);
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00002A97 File Offset: 0x00000C97
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00002A9F File Offset: 0x00000C9F
		[XmlIgnore]
		public string CertificateName { get; private set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00002AA8 File Offset: 0x00000CA8
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00002AB0 File Offset: 0x00000CB0
		[XmlIgnore]
		public bool SignatureVerified { get; private set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000076 RID: 118 RVA: 0x00002AB9 File Offset: 0x00000CB9
		// (set) Token: 0x06000077 RID: 119 RVA: 0x00002AC1 File Offset: 0x00000CC1
		public string PublishPath { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000078 RID: 120 RVA: 0x00002ACA File Offset: 0x00000CCA
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00002AD2 File Offset: 0x00000CD2
		public int PolicyVersion { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00002ADB File Offset: 0x00000CDB
		// (set) Token: 0x0600007B RID: 123 RVA: 0x00002AE3 File Offset: 0x00000CE3
		[XmlIgnore]
		public int TotalUpgradedItems { get; private set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600007C RID: 124 RVA: 0x00002AEC File Offset: 0x00000CEC
		// (set) Token: 0x0600007D RID: 125 RVA: 0x00002AF4 File Offset: 0x00000CF4
		public DefaultPolicy.WelcomePagePolicy welcomePagePolicy { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00002AFD File Offset: 0x00000CFD
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00002B05 File Offset: 0x00000D05
		public DefaultPolicy.WarningPagePolicy warningPagePolicy { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00002B0E File Offset: 0x00000D0E
		// (set) Token: 0x06000081 RID: 129 RVA: 0x00002B16 File Offset: 0x00000D16
		public DefaultPolicy.LicensePagePolicy licensePagePolicy { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00002B1F File Offset: 0x00000D1F
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00002B27 File Offset: 0x00000D27
		public DefaultPolicy.GetInstalledPagePolicy getInstalledPagePolicy { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00002B30 File Offset: 0x00000D30
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00002B38 File Offset: 0x00000D38
		public DefaultPolicy.AdvancedOptionsPagePolicy advancedOptionsPagePolicy { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00002B41 File Offset: 0x00000D41
		// (set) Token: 0x06000087 RID: 135 RVA: 0x00002B49 File Offset: 0x00000D49
		public DefaultPolicy.SelectImagePagePolicy selectImagePagePolicy { get; set; }

		// Token: 0x06000088 RID: 136 RVA: 0x00002A53 File Offset: 0x00000C53
		public bool ShouldSerializeselectImagePagePolicy()
		{
			return false;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00002B52 File Offset: 0x00000D52
		// (set) Token: 0x0600008A RID: 138 RVA: 0x00002B5A File Offset: 0x00000D5A
		public DefaultPolicy.FilesBasedTransferPagePolicy filesBasedTransferPagePolicy { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00002B63 File Offset: 0x00000D63
		// (set) Token: 0x0600008C RID: 140 RVA: 0x00002B6B File Offset: 0x00000D6B
		public DefaultPolicy.FilesBasedAnalyzePagePolicy filesBasedAnalyzePagePolicy { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00002B74 File Offset: 0x00000D74
		// (set) Token: 0x0600008E RID: 142 RVA: 0x00002B7C File Offset: 0x00000D7C
		public DefaultPolicy.FilesBasedTransferProgressPagePolicy filesBasedTransferProgressPagePolicy { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00002B85 File Offset: 0x00000D85
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00002B8D File Offset: 0x00000D8D
		public DefaultPolicy.ProfileMigratorPagePolicy profileMigratorPagePolicy { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00002B96 File Offset: 0x00000D96
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00002B9E File Offset: 0x00000D9E
		public DefaultPolicy.DetailButtonListPolicy detailButtonListPolicy { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00002BA7 File Offset: 0x00000DA7
		// (set) Token: 0x06000094 RID: 148 RVA: 0x00002BAF File Offset: 0x00000DAF
		public DefaultPolicy.SectionApplicationsPolicy sectionApplicationsPolicy { get; set; }

		// Token: 0x06000095 RID: 149 RVA: 0x00002A53 File Offset: 0x00000C53
		public bool ShouldSerializesectionApplicationsPolicy()
		{
			return false;
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00002BB8 File Offset: 0x00000DB8
		// (set) Token: 0x06000097 RID: 151 RVA: 0x00002BC0 File Offset: 0x00000DC0
		public DefaultPolicy.SectionUsersPolicy sectionUsersPolicy { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00002BC9 File Offset: 0x00000DC9
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00002BD1 File Offset: 0x00000DD1
		public DefaultPolicy.SectionDocumentsPolicy sectionDocumentsPolicy { get; set; }

		// Token: 0x0600009A RID: 154 RVA: 0x00002A53 File Offset: 0x00000C53
		public bool ShouldSerializesectionDocumentsPolicy()
		{
			return false;
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00002BDA File Offset: 0x00000DDA
		// (set) Token: 0x0600009C RID: 156 RVA: 0x00002BE2 File Offset: 0x00000DE2
		public DefaultPolicy.SectionAdvancedPolicy sectionAdvancedPolicy { get; set; }

		// Token: 0x0600009D RID: 157 RVA: 0x00002A53 File Offset: 0x00000C53
		public bool ShouldSerializesectionAdvancedPolicy()
		{
			return false;
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00002BEB File Offset: 0x00000DEB
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00002BF3 File Offset: 0x00000DF3
		public DefaultPolicy.FindPCPagePolicy findPCPagePolicy { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00002BFC File Offset: 0x00000DFC
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00002C04 File Offset: 0x00000E04
		public DefaultPolicy.AnalyzePCPagePolicy analyzePCPagePolicy { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00002C0D File Offset: 0x00000E0D
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00002C15 File Offset: 0x00000E15
		public DefaultPolicy.CustomTransferPagePolicy customTransferPagePolicy { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00002C1E File Offset: 0x00000E1E
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x00002C26 File Offset: 0x00000E26
		public DefaultPolicy.TransferEverythingPagePolicy transferEverythingPagePolicy { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00002C2F File Offset: 0x00000E2F
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x00002C37 File Offset: 0x00000E37
		public DefaultPolicy.TransferEverythingProgressPagePolicy transferEverythingProgressPagePolicy { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00002C40 File Offset: 0x00000E40
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x00002C48 File Offset: 0x00000E48
		public DefaultPolicy.TransferCompletePagePolicy transferCompletePagePolicy { get; set; }

		// Token: 0x060000AA RID: 170 RVA: 0x00002A53 File Offset: 0x00000C53
		public bool ShouldSerializetransferCompletePagePolicy()
		{
			return false;
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00002C51 File Offset: 0x00000E51
		// (set) Token: 0x060000AC RID: 172 RVA: 0x00002C59 File Offset: 0x00000E59
		public DefaultPolicy.DownloadManagerPagePolicy downloadManagerPagePolicy { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00002C62 File Offset: 0x00000E62
		// (set) Token: 0x060000AE RID: 174 RVA: 0x00002C6A File Offset: 0x00000E6A
		public DefaultPolicy.CustomUI CustomUIPagePolicy { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000AF RID: 175 RVA: 0x00002C73 File Offset: 0x00000E73
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x00002C7B File Offset: 0x00000E7B
		public EnginePolicy enginePolicy { get; set; }

		// Token: 0x060000B1 RID: 177 RVA: 0x00002C84 File Offset: 0x00000E84
		public DefaultPolicy()
		{
			this.InitPolicy(DefaultPolicy.DefaultType.Normal);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00002CA9 File Offset: 0x00000EA9
		public DefaultPolicy(DefaultPolicy.DefaultType type)
		{
			this.InitPolicy(type);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00002CCE File Offset: 0x00000ECE
		public DefaultPolicy(DefaultPolicy.DefaultType type, string certificateName)
		{
			this.CertificateName = certificateName;
			this.InitPolicy(type);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00002CFC File Offset: 0x00000EFC
		private void InitPolicy(DefaultPolicy.DefaultType type)
		{
			this.PolicyType = type;
			this.PolicyVersion = Convert.ToInt32(PCmover.Infrastructure.Properties.Resources.PolicyVersion);
			this.DoRecord = true;
			this.IsComplete = DefaultPolicy.Tristate.Null;
			this.GnSimMode = false;
			this.PolicyPath = DefaultPolicy.RecordedPolicyPath;
			this.SuppressMessageBoxes = false;
			this.ShowUserGuideButton = true;
			this.ShowReportsButton = DefaultPolicy.Tristate.Null;
			this.ShowSerialNumberInfo = false;
			this.SignatureVerified = true;
			this.DisplayQuickSteps = true;
			this.SupportEmail = "corpsales@laplink.com";
			if (DefaultPolicy.EnforceSignedPolicy)
			{
				CryptoConfig.AddAlgorithm(typeof(SHA256Cng), new string[]
				{
					"http://www.w3.org/2001/04/xmlenc#sha256"
				});
				this.SignatureVerified = false;
			}
			this.welcomePagePolicy = new DefaultPolicy.WelcomePagePolicy
			{
				WpAdvancedClicked = false,
				WpNextClicked = false
			};
			this.warningPagePolicy = new DefaultPolicy.WarningPagePolicy
			{
				WarnPageChecked = false,
				WarnPageNextClicked = false
			};
			this.licensePagePolicy = new DefaultPolicy.LicensePagePolicy
			{
				IsPageDisplayed = true
			};
			this.getInstalledPagePolicy = new DefaultPolicy.GetInstalledPagePolicy
			{
				IsPageDisplayed = true,
				GiIsEULAAccepted = DefaultPolicy.Tristate.Null
			};
			this.advancedOptionsPagePolicy = new DefaultPolicy.AdvancedOptionsPagePolicy
			{
				IsPageDisplayed = true
			};
			this.selectImagePagePolicy = new DefaultPolicy.SelectImagePagePolicy();
			this.filesBasedTransferPagePolicy = new DefaultPolicy.FilesBasedTransferPagePolicy
			{
				IsPageDisplayed = true,
				TransferList = new ObservableCollection<DefaultPolicy.FileBasedTransferData>()
			};
			this.filesBasedTransferProgressPagePolicy = new DefaultPolicy.FilesBasedTransferProgressPagePolicy
			{
				IsPageDisplayed = true
			};
			this.profileMigratorPagePolicy = new DefaultPolicy.ProfileMigratorPagePolicy
			{
				IsPageDisplayed = true,
				Mappings = new ObservableCollection<UserMap>()
			};
			this.detailButtonListPolicy = new DefaultPolicy.DetailButtonListPolicy
			{
				IsPageDisplayed = true,
				DblSelectedButton = DefaultPolicy.SelectedButtonEnum.None,
				DblShowDocsButton = true,
				DblShowPicsButton = true,
				DblShowVideoButton = true,
				DblShowMusicButton = true,
				DblShowOtherButton = true,
				DblShowAdvancedButton = true,
				DblTitle = string.Empty,
				DblRegion = string.Empty
			};
			this.sectionApplicationsPolicy = new DefaultPolicy.SectionApplicationsPolicy
			{
				Applications = new ObservableCollection<DefaultPolicy.Application>()
			};
			this.sectionUsersPolicy = new DefaultPolicy.SectionUsersPolicy
			{
				Mappings = new ObservableCollection<UserMap>()
			};
			this.sectionDocumentsPolicy = new DefaultPolicy.SectionDocumentsPolicy
			{
				Folders = new ObservableCollection<DefaultPolicy.RedirectionData>(),
				Files = new ObservableCollection<DefaultPolicy.RedirectionData>()
			};
			this.sectionAdvancedPolicy = new DefaultPolicy.SectionAdvancedPolicy
			{
				DriveMapping = new List<DrivePair>(),
				FileFilters = new List<FileFilter>(),
				MigModSettings = new ObservableCollection<MiscSettingsGroupData>()
			};
			this.findPCPagePolicy = new DefaultPolicy.FindPCPagePolicy
			{
				IsPageDisplayed = true,
				AllowDirectWifi = false,
				DirectWifiOnly = false,
				ShowVproLink = false
			};
			this.analyzePCPagePolicy = new DefaultPolicy.AnalyzePCPagePolicy
			{
				IsPageDisplayed = true
			};
			this.customTransferPagePolicy = new DefaultPolicy.CustomTransferPagePolicy
			{
				IsPageDisplayed = true,
				IsLetMeChooseDisabled = false
			};
			this.transferEverythingPagePolicy = new DefaultPolicy.TransferEverythingPagePolicy
			{
				IsPageDisplayed = true
			};
			this.transferEverythingProgressPagePolicy = new DefaultPolicy.TransferEverythingProgressPagePolicy
			{
				IsPageDisplayed = true
			};
			this.transferCompletePagePolicy = new DefaultPolicy.TransferCompletePagePolicy();
			this.downloadManagerPagePolicy = new DefaultPolicy.DownloadManagerPagePolicy
			{
				IsPageDisplayed = true
			};
			this.CustomUIPagePolicy = new DefaultPolicy.CustomUI();
			this.enginePolicy = new EnginePolicy();
			this.enginePolicy.Connection.File.VanPassword.fips = this.enginePolicy.UseFips;
			this.enginePolicy.Connection.File.Settings.CloudBased = "Local";
			this.InitCloudSettings("");
			this.enginePolicy.AppSel.MigrateUntested = "SameBitness";
			this.enginePolicy.AppSel.MigrateByDefault = true;
			this.enginePolicy.AppSel.ModifyDeselected = true;
			this.enginePolicy.Reports.Encoding = "ANSI";
			this.enginePolicy.Reports.Format = "CSV";
			this.enginePolicy.Settings.CompressOthers = true;
			this.enginePolicy.Settings.CompressVan = false;
			this.enginePolicy.UserMap.CurrentToCurrent = true;
			this.enginePolicy.UserMap.Create = true;
			this.enginePolicy.UserMap.ProfilesOnly = true;
			this.enginePolicy.Connection.Network.Settings.SSLFlags = SSLFlags.EnforceTimeValidity;
			this.enginePolicy.Registration.SerialNumber.fips = this.enginePolicy.UseFips;
			this.enginePolicy.DoneMigration.Reboot.Value = new bool?(true);
			this.enginePolicy.DoneMigration.UploadReport.Value = new bool?(true);
			this.enginePolicy.MigType.DefaultOption = MigrationTypeOption.Nothing;
			this.SupressPageAnimation = true;
			if (type == DefaultPolicy.DefaultType.MSFTProfile)
			{
				this.welcomePagePolicy.WpAdvancedClicked = true;
				this.enginePolicy.MigType.DefaultOption = MigrationTypeOption.Profile;
				this.advancedOptionsPagePolicy.IsPageDisplayed = false;
				this.transferEverythingPagePolicy.IsPageDisplayed = false;
				this.transferEverythingProgressPagePolicy.IsPageDisplayed = false;
				this.downloadManagerPagePolicy.IsPageDisplayed = false;
				this.detailButtonListPolicy.DblSelectedButton = DefaultPolicy.SelectedButtonEnum.Users;
				this.detailButtonListPolicy.DblRegion = "SectionUsers_Self";
				this.detailButtonListPolicy.DblTitle = "User Accounts";
				this.SupressOffers = true;
				return;
			}
			if (type == DefaultPolicy.DefaultType.Profile)
			{
				this.welcomePagePolicy.WpAdvancedClicked = true;
				this.enginePolicy.MigType.DefaultOption = MigrationTypeOption.Profile;
				this.advancedOptionsPagePolicy.IsPageDisplayed = false;
				this.downloadManagerPagePolicy.IsPageDisplayed = false;
				this.detailButtonListPolicy.DblSelectedButton = DefaultPolicy.SelectedButtonEnum.Users;
				this.ShowSerialNumberInfo = true;
				return;
			}
			if (type == DefaultPolicy.DefaultType.Enterprise)
			{
				this.InitEnterpriseSettings();
				return;
			}
			if (type == DefaultPolicy.DefaultType.EnterpriseGov)
			{
				this.InitEnterpriseSettings();
				return;
			}
			if (type == DefaultPolicy.DefaultType.Business)
			{
				this.SupressOffers = true;
				this.ShowSerialNumberInfo = true;
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000326C File Offset: 0x0000146C
		public void InitCloudSettings(string CloudBased = "")
		{
			if (!(CloudBased == "AWS"))
			{
				if (!(CloudBased == "Azure"))
				{
					if (!(CloudBased == "GCS"))
					{
						this.InitCloudSettings("AWS");
						this.InitCloudSettings("Azure");
						this.InitCloudSettings("GCS");
					}
					else
					{
						if (this.enginePolicy.Connection.File.AWSSettings.Authentication == "Google")
						{
							this.enginePolicy.Connection.File.GCSSettings.Authentication = "OAuth2";
						}
						else
						{
							this.enginePolicy.Connection.File.GCSSettings.Authentication = "ServiceAccount";
							this.enginePolicy.Connection.File.GCSSettings.ClientSecret.fips = this.enginePolicy.UseFips;
							this.enginePolicy.Connection.File.GCSSettings.ClientSecret.Value = string.Empty;
						}
						this.enginePolicy.Connection.File.GCSSettings.KeyPrefix = "pcmover/";
						this.enginePolicy.Connection.File.GCSSettings.Bucket = string.Empty;
						this.enginePolicy.Connection.File.GCSSettings.ServiceAccount.fips = this.enginePolicy.UseFips;
						this.enginePolicy.Connection.File.GCSSettings.ServiceAccount.Value = string.Empty;
						if (DefaultPolicy.UseTestCloudSettings)
						{
							this.enginePolicy.Connection.File.GCSSettings.Bucket = "orin-test";
							this.enginePolicy.Connection.File.GCSSettings.ServiceAccount.Value = Encryptor.Encrypt("{\r\n  \"type\": \"service_account\",\r\n  \"project_id\": \"lunar-marker-277921\",\r\n  \"private_key_id\": \"1ea2b90980b8a207cab501756e7e2b4e54f4d452\",\r\n  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDEjlLJiihAOEoz\\nqKPx8LtU8rceGJ98jdQaH6C4rCWarKayGMWyvDUWB3dO+gRzOKIRYDKdEnD1wut5\\n73gE46dtw/zRvll9jwJLhgCo3voHfQrqV4WMMcuP9+yE/g1/K6miDRx5v9yOQ+ur\\ndpiWyKJrU2BfGbGVoKk6DgiCc/L+OmUEadKrQAf+jJbrAJ7ojQ5GsUmgFTAYsqzU\\nZw+V8rt2kMgC61Ubq4bre3WENdEFvGtJGrL1IzwghAb/+PLN22EU8XUgL96JxBVf\\nyo96oKe0GnChs2ugEKtsstyMc0oaPPvPEf7HamksNS6c0sGRBV3bm7r3hrf16N9/\\niJR/omwHAgMBAAECggEACFVKYD4Jv9NDHhaPwNGmd48EwXNky5iNvf/KRhoSTBD2\\nzkUrmIzPKVxuq/wAlUv43wi3jJ48CMdXSWekLHzkW8x72v6Zd6/I9p+7Rm2RpyCf\\nhljokg2IZlWqAudsdhBJVFP++ZBvTt7FTpMsG/RsomU6CD4kH8Zcdlgi9zjoO+v1\\n1EtVDW7KOF/YVH0LlzvY0HQRsEbk0OWrRLGC+YcLKZ6Nmc2j6Su36e6gfYbS9WVx\\n1sg6mzuM87G3g8XqGlCfLYjmPyRJ4z+zuggpcYVDNFEdZ41A+4dSZr+ieXfDbvoS\\nqQyg884aFn0OeyIM9ZAeeCWqjKTfn7kP/xlJrsPvKQKBgQDpcVZEJzX0HJEre/3P\\n+EkipPdavZ4WUFEsqnpguGknheKvWX7iVgGZpBMYkoZUSSnD2uXWb40dZVoaJLg6\\nkZ3f+Rl9Y/R44uHcL66+uJuNMIgY1+p7b5B1afe2uYUyALdzk2/XeCEZ7IsumpEy\\nVdyXv+sT5DAJvQIZ/AcXu2nKeQKBgQDXjIUVGiS8qSyZ+kk9Mx2iK/Ds3y/TLgIf\\n5O9W6vzSk+ESx0Dk8jMcEfcK+ZSJ8BX452e7FHmWQUxdZsyjwo3NMt7aHBiouTXi\\nmsQyRF+bREp013+kDx6Za0GNvnQ1Delw6UiBSWJ4+l1MsdGDeSjc7vINFm6oRUbN\\nm1fFFqBKfwKBgQDHjrOIH1zoCWOwIJagqkca7prlXyM9P/ukizeCZyK9Pp7B92eY\\nZJ2JkdEhOGDMvJ6PZxkDbujbMEEOCEXVC5ZCWNeJcWET1h/t8nUXZQjUcaBmXG1+\\nh6ieNrAj7AQI8sPgcTEyqObjGmsAs/FbbjrdHpr+rhrCuGiLff8yMmwFQQKBgELU\\n7u58DKfyTEHxuIOhNa7ysODA0rNHsKDy+sKYWYtxDngkD5rs/avWZiKg/81FA4sJ\\nNMBsuMY9uM+87/ZWfGEDRNWboImv42U/V1W+nWYm5m8T4h+cEIDBILIyOxW4GolH\\ny5NKjZ21AvikqbF5/5GBBMvKCMVjtXBKmgwh19FBAoGAES5UxwJcvjVnX6aqbQez\\nYmjN1Qm/x/AuQHVlQH0Bip0AJHjMVLMz5s5Vy5j1CA8nGjluZk1iDrcRg/04nmOd\\nvGFKRy5CAKkrvD32Jnhau56lbbmoJ/pa6IDwENRj16vsksRSdWIbAOTyrnJY21ET\\npbLue7/p7FKJwiVjWFrlTc4=\\n-----END PRIVATE KEY-----\\n\",\r\n  \"client_email\": \"orin-test@lunar-marker-277921.iam.gserviceaccount.com\",\r\n  \"client_id\": \"113417744438781933994\",\r\n  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\r\n  \"token_uri\": \"https://oauth2.googleapis.com/token\",\r\n  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\r\n  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/orin-test%40lunar-marker-277921.iam.gserviceaccount.com\"\r\n}", this.enginePolicy.UseFips);
							this.enginePolicy.Connection.File.GCSSettings.ClientSecret.Value = Encryptor.Encrypt("{\"installed\":{\"client_id\":\"228714685191-fcc24aqto0475rrqgr78nplb8jo5ce8i.apps.googleusercontent.com\",\"project_id\":\"orin-279223\",\"auth_uri\":\"https://accounts.google.com/o/oauth2/auth\",\"token_uri\":\"https://oauth2.googleapis.com/token\",\"auth_provider_x509_cert_url\":\"https://www.googleapis.com/oauth2/v1/certs\",\"client_secret\":\"Gu9Czh3eSNtg_RmrwuvBhuFL\",\"redirect_uris\":[\"urn:ietf:wg:oauth:2.0:oob\",\"http://localhost\"]}}", this.enginePolicy.UseFips);
							return;
						}
					}
				}
				else
				{
					this.enginePolicy.Connection.File.AzureSettings.AccessKey.fips = this.enginePolicy.UseFips;
					this.enginePolicy.Connection.File.AzureSettings.SaveCredentials = false;
					this.enginePolicy.Connection.File.AzureSettings.Prefix = "pcmover/";
					this.enginePolicy.Connection.File.AzureSettings.Authentication = string.Empty;
					this.enginePolicy.Connection.File.AzureSettings.StorageAccount = string.Empty;
					this.enginePolicy.Connection.File.AzureSettings.Container = string.Empty;
					this.enginePolicy.Connection.File.AzureSettings.ClientId = string.Empty;
					this.enginePolicy.Connection.File.AzureSettings.TenantId = string.Empty;
					this.enginePolicy.Connection.File.AzureSettings.AccessKey.Value = string.Empty;
					if (DefaultPolicy.UseTestCloudSettings)
					{
						this.enginePolicy.Connection.File.AzureSettings.SaveCredentials = true;
						this.enginePolicy.Connection.File.AzureSettings.Authentication = "OAuth2";
						this.enginePolicy.Connection.File.AzureSettings.StorageAccount = "orinstorage";
						this.enginePolicy.Connection.File.AzureSettings.Container = "pcmover-test";
						this.enginePolicy.Connection.File.AzureSettings.ClientId = "5bd95929-9f73-471a-9895-89a26ff41bb2";
						this.enginePolicy.Connection.File.AzureSettings.TenantId = "cbb1f1a5-60ff-4271-abd5-0d8b28e22ca5";
						this.enginePolicy.Connection.File.AzureSettings.AccessKey.Value = Encryptor.Encrypt("6IOicqVMnDFuqgyab477PMmiKbX9ApNuRdG5L+VR2BhNDrr3NGneEcbi2A0LfRzP2pXJwfByXbfGx5l1WAVo1Q==", this.enginePolicy.UseFips);
						return;
					}
					this.enginePolicy.Connection.File.AzureSettings.SaveCredentials = false;
					this.enginePolicy.Connection.File.AzureSettings.Authentication = "AccessKey";
					return;
				}
			}
			else
			{
				this.enginePolicy.Connection.File.AWSSettings.Authentication = "AccessKey";
				this.enginePolicy.Connection.File.AWSSettings.Secret.fips = this.enginePolicy.UseFips;
				this.enginePolicy.Connection.File.AWSSettings.KeyPrefix = "pcmover/";
				this.enginePolicy.Connection.File.AWSSettings.RedirectUrl = "pcmover://";
				this.enginePolicy.Connection.File.AWSSettings.Domain = string.Empty;
				if (DefaultPolicy.UseTestCloudSettings)
				{
					this.enginePolicy.Connection.File.AWSSettings.Domain = "pcmover";
					return;
				}
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000037C4 File Offset: 0x000019C4
		private void InitEnterpriseSettings()
		{
			this.SupressPageAnimation = true;
			this.SupressOffers = true;
			this.StartOnAdvancedOptionsPage = true;
			this.ShowSerialNumberInfo = true;
			this.enginePolicy.UserMap.CurrentToCurrent = false;
			this.enginePolicy.FileFilter.Filters.Add(new EnginePolicy.FileFilterItem("*.ost", new bool?(false)));
			this.enginePolicy.FileFilter.Filters.Add(new EnginePolicy.FileFilterItem("*.tmp", new bool?(false)));
			this.enginePolicy.FileFilter.Filters.Add(new EnginePolicy.FileFilterItem("*.bak", new bool?(false)));
			this.enginePolicy.FileFilter.Filters.Add(new EnginePolicy.FileFilterItem("*.log", new bool?(false)));
			this.enginePolicy.FileFilter.Filters.Add(new EnginePolicy.FileFilterItem("*.gho", new bool?(false)));
			this.enginePolicy.FileFilter.Filters.Add(new EnginePolicy.FileFilterItem("~*.*", new bool?(false)));
			this.enginePolicy.FileFilter.Filters.Add(new EnginePolicy.FileFilterItem("$*.*", new bool?(false)));
			this.enginePolicy.DirFilter.Filters.Add(new EnginePolicy.DirFilterItem("C:\\Intel", new bool?(false)));
			this.enginePolicy.DirFilter.Filters.Add(new EnginePolicy.DirFilterItem("C:\\Dell", new bool?(false)));
			this.enginePolicy.DirFilter.Filters.Add(new EnginePolicy.DirFilterItem("C:\\Windows.old", new bool?(false)));
			this.enginePolicy.Alerts.EnableInteractive = true;
			this.enginePolicy.Reports.Dir = "Reports";
			this.enginePolicy.Reports.Detail.Add(new EnginePolicy.DetailReport
			{
				Type = "Applications",
				Value = "Applications for %USERNAME% on %COMPUTERNAME%",
				Generator = "Engine"
			});
			this.enginePolicy.Reports.Detail.Add(new EnginePolicy.DetailReport
			{
				Type = "DiskItems",
				Value = "DiskItems for %USERNAME% on %COMPUTERNAME%",
				Generator = "Engine"
			});
			this.enginePolicy.Reports.Detail.Add(new EnginePolicy.DetailReport
			{
				Type = "Summary",
				Value = "Summary Report",
				Append = true,
				Generator = "Engine"
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*Java*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*VPN*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*Microsoft.NET*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*Oracle*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*SQL*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*Intel*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*Dell*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*Driver*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*Symantec*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*Wireless*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*Adobe*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*MSXML*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*HP*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*Logitech*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*VZAccess*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*Autodesk*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*DW WLAN*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "Card*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*modem*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*Sevinst*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*norton*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*mcafee*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*virus*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*spyware*",
				Modify = true,
				Migrate = false
			});
			this.enginePolicy.AppSel.Applications.Add(new EnginePolicy.AppData
			{
				Name = "*spysweeper*",
				Modify = true,
				Migrate = false
			});
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003F4C File Offset: 0x0000214C
		private XmlDocument ConvertToXmlDocument()
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(DefaultPolicy));
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.PreserveWhitespace = true;
			using (StringWriter stringWriter = new StringWriter())
			{
				xmlSerializer.Serialize(stringWriter, this);
				string text = stringWriter.ToString();
				if (!string.IsNullOrWhiteSpace(text))
				{
					xmlDocument.LoadXml(text);
				}
			}
			return xmlDocument;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003FB8 File Offset: 0x000021B8
		public bool CanSign()
		{
			return SignPolicy.SignXmlDocument(this.ConvertToXmlDocument(), this.CertificateName);
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003FCB File Offset: 0x000021CB
		public void WriteProfile()
		{
			if (this.DoRecord && DefaultPolicy.EnforceSignedPolicy && !this.CanSign())
			{
				this.DoRecord = false;
			}
			if (this.DoRecord)
			{
				this.WriteProfile(DefaultPolicy.RecordedPolicyPath, false);
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004000 File Offset: 0x00002200
		public void WriteProfile(string filePath, bool throwErrors = false)
		{
			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName(filePath));
				if (DefaultPolicy.EnforceSignedPolicy)
				{
					XmlDocument xmlDocument = this.ConvertToXmlDocument();
					if (!SignPolicy.SignXmlDocument(xmlDocument, this.CertificateName))
					{
						throw new ApplicationException("Unable to sign document");
					}
					using (FileStream fileStream = File.Create(filePath))
					{
						using (GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Compress))
						{
							xmlDocument.Save(gzipStream);
						}
						goto IL_BC;
					}
				}
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(DefaultPolicy));
				if (DefaultPolicy.SerializePlainText)
				{
					using (TextWriter textWriter = new StreamWriter(filePath))
					{
						xmlSerializer.Serialize(textWriter, this);
						goto IL_BC;
					}
				}
				using (GZipStream gzipStream2 = new GZipStream(File.Create(filePath), CompressionMode.Compress))
				{
					xmlSerializer.Serialize(gzipStream2, this);
				}
				IL_BC:
				this.ClearUpgradedCount();
			}
			catch (ApplicationException ex)
			{
				if (throwErrors)
				{
					throw;
				}
				Trace.WriteLine("Exception writing policy: " + ex.Message);
				throw;
			}
			catch (Exception)
			{
				if (throwErrors)
				{
					throw;
				}
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004144 File Offset: 0x00002344
		public void CreateProfile(string filePath)
		{
			if (!string.IsNullOrWhiteSpace(filePath))
			{
				this.WriteProfile(filePath, false);
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00004158 File Offset: 0x00002358
		public static bool VerifyPolicySignature(string policyPath)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.PreserveWhitespace = true;
			try
			{
				using (GZipStream gzipStream = new GZipStream(File.OpenRead(policyPath), CompressionMode.Decompress))
				{
					xmlDocument.Load(gzipStream);
				}
			}
			catch (InvalidDataException)
			{
				try
				{
					using (FileStream fileStream = new FileStream(policyPath, FileMode.Open))
					{
						xmlDocument.Load(fileStream);
					}
				}
				catch
				{
				}
			}
			string text;
			return SignPolicy.VerifyXmlFile(xmlDocument, out text);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x000041F4 File Offset: 0x000023F4
		public static DefaultPolicy Load(string fileName)
		{
			if (!File.Exists(fileName))
			{
				return null;
			}
			bool flag = false;
			DefaultPolicy defaultPolicy = null;
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(DefaultPolicy));
			if (DefaultPolicy.EnforceSignedPolicy)
			{
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.PreserveWhitespace = true;
					using (GZipStream gzipStream = new GZipStream(File.OpenRead(fileName), CompressionMode.Decompress))
					{
						xmlDocument.Load(gzipStream);
					}
					string certificateName;
					bool signatureVerified = SignPolicy.VerifyXmlFile(xmlDocument, out certificateName);
					using (XmlReader xmlReader = new XmlNodeReader(xmlDocument.DocumentElement))
					{
						defaultPolicy = (DefaultPolicy)xmlSerializer.Deserialize(xmlReader);
						defaultPolicy.CertificateName = certificateName;
						defaultPolicy.PolicyPath = fileName;
					}
					defaultPolicy.SignatureVerified = signatureVerified;
					goto IL_14A;
				}
				catch (Exception)
				{
					goto IL_14A;
				}
			}
			xmlSerializer.UnknownNode += delegate(object sender, XmlNodeEventArgs e)
			{
				Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
			};
			xmlSerializer.UnknownAttribute += delegate(object sender, XmlAttributeEventArgs e)
			{
				Console.WriteLine(string.Concat(new string[]
				{
					"Unknown attribute ",
					e.Attr.Name,
					"='",
					e.Attr.Value,
					"'"
				}));
			};
			try
			{
				using (GZipStream gzipStream2 = new GZipStream(File.OpenRead(fileName), CompressionMode.Decompress))
				{
					defaultPolicy = (DefaultPolicy)xmlSerializer.Deserialize(gzipStream2);
					if (!DefaultPolicy.IsPolicyAllowed(defaultPolicy))
					{
						defaultPolicy = null;
					}
					else
					{
						defaultPolicy.PolicyPath = fileName;
						defaultPolicy.SignatureVerified = true;
					}
				}
			}
			catch (InvalidDataException)
			{
				flag = true;
			}
			catch (Exception)
			{
			}
			IL_14A:
			if (flag)
			{
				Task.Run(() => Task.Delay(1000)).Wait();
				try
				{
					using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
					{
						defaultPolicy = (DefaultPolicy)xmlSerializer.Deserialize(fileStream);
						if (!DefaultPolicy.IsPolicyAllowed(defaultPolicy))
						{
							defaultPolicy = null;
						}
						else
						{
							defaultPolicy.PolicyPath = fileName;
							defaultPolicy.SignatureVerified = true;
						}
					}
				}
				catch
				{
				}
			}
			if (defaultPolicy != null)
			{
				defaultPolicy.FixBackwardCompatibility();
			}
			return defaultPolicy;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000442C File Offset: 0x0000262C
		private void InitUpgradeableSections()
		{
			this.UpgradeableSections = new List<IUpgradeable>
			{
				this.profileMigratorPagePolicy,
				this.sectionUsersPolicy,
				this.advancedOptionsPagePolicy,
				this.sectionApplicationsPolicy,
				this.sectionAdvancedPolicy,
				this.sectionDocumentsPolicy,
				this.selectImagePagePolicy,
				this.filesBasedTransferPagePolicy,
				this.findPCPagePolicy,
				this.transferCompletePagePolicy,
				this,
				this.enginePolicy.Settings,
				this.licensePagePolicy,
				this.customTransferPagePolicy,
				this.warningPagePolicy,
				this.detailButtonListPolicy,
				this.enginePolicy.Reports
			};
			this.UpgradeToUiPolicySections = new List<IUpgradeToUiPolicy>
			{
				this.enginePolicy.Connection.File.Settings
			};
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000453C File Offset: 0x0000273C
		public void Upgrade()
		{
			this.InitUpgradeableSections();
			this.TotalUpgradedItems = 0;
			foreach (IUpgradeable upgradeable in this.UpgradeableSections)
			{
				upgradeable.Upgrade(this.enginePolicy);
				this.TotalUpgradedItems += upgradeable.NumUpgradedItems;
			}
			foreach (IUpgradeToUiPolicy upgradeToUiPolicy in this.UpgradeToUiPolicySections)
			{
				upgradeToUiPolicy.Upgrade(this);
				this.TotalUpgradedItems += upgradeToUiPolicy.NumUpgradedItems;
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000460C File Offset: 0x0000280C
		private void ClearUpgradedCount()
		{
			foreach (IUpgradeable upgradeable in this.UpgradeableSections)
			{
				upgradeable.NumUpgradedItems = 0;
			}
			foreach (IUpgradeToUiPolicy upgradeToUiPolicy in this.UpgradeToUiPolicySections)
			{
				upgradeToUiPolicy.NumUpgradedItems = 0;
			}
			this.TotalUpgradedItems = 0;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000046A4 File Offset: 0x000028A4
		private static bool IsPolicyAllowed(DefaultPolicy policy)
		{
			if (!Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowAdvancedSSLSettings))
			{
				SSLFlags sslflags = policy.enginePolicy.Connection.Network.Settings.SSLFlags;
				if (sslflags.HasFlag(SSLFlags.DisallowLaplinkCA) || sslflags.HasFlag(SSLFlags.DisallowSelfSigned) || sslflags.HasFlag(SSLFlags.EnforceCertificateName) || sslflags.HasFlag(SSLFlags.RequireClientCertificate) || sslflags.HasFlag(SSLFlags.RequireCustomerCA))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000473C File Offset: 0x0000293C
		public void SetPolicyVersion()
		{
			this.PolicyVersion = Convert.ToInt32(PCmover.Infrastructure.Properties.Resources.PolicyVersion);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004750 File Offset: 0x00002950
		public void Reset()
		{
			bool minUI = this.MinUI;
			string value = this.enginePolicy.Registration.SerialNumber.Value;
			bool gnSimMode = this.GnSimMode;
			bool flag = !this.DoRecord;
			this.InitPolicy(this.PolicyType);
			this.MinUI = minUI;
			this.enginePolicy.Registration.SerialNumber.Value = value;
			this.GnSimMode = gnSimMode;
			this.DoRecord = !flag;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000047C8 File Offset: 0x000029C8
		public void Reset(string PolicyFile)
		{
			DefaultPolicy defaultPolicy = DefaultPolicy.Load(PolicyFile);
			if (defaultPolicy != null)
			{
				this.Reset(defaultPolicy);
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000047E8 File Offset: 0x000029E8
		public void Reset(DefaultPolicy policy)
		{
			foreach (PropertyInfo propertyInfo in from x in policy.GetType().GetProperties()
			where x.CanRead && x.CanWrite
			select x)
			{
				object value = propertyInfo.GetValue(policy);
				propertyInfo.SetValue(this, value);
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004868 File Offset: 0x00002A68
		public void Reset(Stream policyStream)
		{
			this.Reset(policyStream.ReadIntoByteArray());
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004878 File Offset: 0x00002A78
		public void Reset(byte[] policy)
		{
			string @string = Encoding.Default.GetString(policy);
			this.ResetString(@string);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004898 File Offset: 0x00002A98
		public void ResetString(string policyString)
		{
			DefaultPolicy policy = this.DeserializeObject<DefaultPolicy>(policyString);
			this.Reset(policy);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000048B4 File Offset: 0x00002AB4
		public DefaultPolicy Clone()
		{
			string xml = this.SerializeObjectToString<DefaultPolicy>(this);
			return this.DeserializeObject<DefaultPolicy>(xml);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000048D0 File Offset: 0x00002AD0
		private T DeserializeObject<T>(string xml)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			T result;
			using (StringReader stringReader = new StringReader(xml))
			{
				result = (T)((object)xmlSerializer.Deserialize(stringReader));
			}
			return result;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004920 File Offset: 0x00002B20
		private string SerializeObjectToString<T>(T obj)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Encoding = new UnicodeEncoding(true, true);
			xmlWriterSettings.Indent = true;
			XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
			xmlSerializerNamespaces.Add("", "");
			string result;
			using (StringWriter stringWriter = new StringWriter())
			{
				using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
				{
					xmlSerializer.Serialize(xmlWriter, obj, xmlSerializerNamespaces);
				}
				result = stringWriter.ToString();
			}
			return result;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000049CC File Offset: 0x00002BCC
		public void FixBackwardCompatibility()
		{
			this.Upgrade();
			try
			{
				if (string.IsNullOrEmpty(this.enginePolicy.Connection.File.Settings.CloudBased))
				{
					this.enginePolicy.Connection.File.Settings.CloudBased = "Local";
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004A34 File Offset: 0x00002C34
		public Stream GetPolicyStream(bool unicode = false)
		{
			string text = this.SerializeObjectToString<DefaultPolicy>(this);
			if (unicode)
			{
				return new MemoryStream(Encoding.Unicode.GetBytes(text ?? string.Empty));
			}
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter streamWriter = new StreamWriter(memoryStream);
			streamWriter.Write(text);
			streamWriter.Flush();
			memoryStream.Position = 0L;
			return memoryStream;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004A85 File Offset: 0x00002C85
		public string GetPolicyString()
		{
			return this.SerializeObjectToString<DefaultPolicy>(this);
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00004A90 File Offset: 0x00002C90
		public static DefaultPolicy.DefaultType DefaultPolicyType
		{
			get
			{
				string edition = PcmBrandUI.Properties.Resources.Edition;
				DefaultPolicy.DefaultType result;
				if (!(edition == "ProfileMigrator"))
				{
					if (!(edition == "Enterprise"))
					{
						if (!(edition == "EnterpriseGov"))
						{
							if (!(edition == "Business"))
							{
								if (!(edition == "Express"))
								{
									result = DefaultPolicy.DefaultType.Normal;
								}
								else
								{
									result = DefaultPolicy.DefaultType.Express;
								}
							}
							else
							{
								result = DefaultPolicy.DefaultType.Business;
							}
						}
						else
						{
							result = DefaultPolicy.DefaultType.EnterpriseGov;
						}
					}
					else
					{
						result = DefaultPolicy.DefaultType.Enterprise;
					}
				}
				else if (PcmBrandUI.Properties.Resources.OEM == "Microsoft")
				{
					result = DefaultPolicy.DefaultType.MSFTProfile;
				}
				else
				{
					result = DefaultPolicy.DefaultType.Profile;
				}
				return result;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00004B12 File Offset: 0x00002D12
		private bool IsValidPolicyType
		{
			get
			{
				return this.PolicyType == DefaultPolicy.DefaultType.Custom || this.PolicyType == DefaultPolicy.DefaultPolicyType;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00004B2C File Offset: 0x00002D2C
		public bool IsValidPolicyVersion
		{
			get
			{
				return this.PolicyVersion == Convert.ToInt32(PCmover.Infrastructure.Properties.Resources.PolicyVersion);
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x00004B40 File Offset: 0x00002D40
		[XmlAnyElement("GeneralCommentStart")]
		public XmlComment GeneralCommentStart
		{
			get
			{
				return new XmlDocument().CreateComment("General - Start");
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00004B51 File Offset: 0x00002D51
		[XmlAnyElement("IsCompleteComment")]
		public XmlComment IsCompleteComment
		{
			get
			{
				return new XmlDocument().CreateComment("Set to Null to use as a normal policy file, true will force a new default policy, and false will just run the policy regardless of IsPageDisplayed.");
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00004B62 File Offset: 0x00002D62
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x00004B6A File Offset: 0x00002D6A
		public DefaultPolicy.Tristate IsComplete { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00004B73 File Offset: 0x00002D73
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00004B7B File Offset: 0x00002D7B
		public bool DoRecord { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00004B84 File Offset: 0x00002D84
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00004B8C File Offset: 0x00002D8C
		public bool GnSimMode { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00004B95 File Offset: 0x00002D95
		// (set) Token: 0x060000DB RID: 219 RVA: 0x00004B9D File Offset: 0x00002D9D
		public bool SupressOffers { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00004BA6 File Offset: 0x00002DA6
		// (set) Token: 0x060000DD RID: 221 RVA: 0x00004BAE File Offset: 0x00002DAE
		public DefaultPolicy.DefaultType PolicyType { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00004BB7 File Offset: 0x00002DB7
		// (set) Token: 0x060000DF RID: 223 RVA: 0x00004BBF File Offset: 0x00002DBF
		public bool MinUI { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00004BC8 File Offset: 0x00002DC8
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x00004BD0 File Offset: 0x00002DD0
		public bool SupressRunPolicyPrompt { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00004BD9 File Offset: 0x00002DD9
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x00004BE1 File Offset: 0x00002DE1
		public bool SupressPageAnimation { get; set; }

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00004BEA File Offset: 0x00002DEA
		// (set) Token: 0x060000E5 RID: 229 RVA: 0x00004BF2 File Offset: 0x00002DF2
		public bool SupressWindowsRebootCheck { get; set; }

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x00004BFB File Offset: 0x00002DFB
		// (set) Token: 0x060000E7 RID: 231 RVA: 0x00004C03 File Offset: 0x00002E03
		public bool SuppressMessageBoxes { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00004C0C File Offset: 0x00002E0C
		// (set) Token: 0x060000E9 RID: 233 RVA: 0x00004C14 File Offset: 0x00002E14
		public bool StartOnAdvancedOptionsPage { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00004C1D File Offset: 0x00002E1D
		// (set) Token: 0x060000EB RID: 235 RVA: 0x00004C25 File Offset: 0x00002E25
		public bool ShowUserGuideButton { get; set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00004C2E File Offset: 0x00002E2E
		// (set) Token: 0x060000ED RID: 237 RVA: 0x00004C36 File Offset: 0x00002E36
		public DefaultPolicy.Tristate ShowReportsButton { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00004C3F File Offset: 0x00002E3F
		// (set) Token: 0x060000EF RID: 239 RVA: 0x00004C47 File Offset: 0x00002E47
		public bool ShowSerialNumberInfo { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00004C50 File Offset: 0x00002E50
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x00004C58 File Offset: 0x00002E58
		[XmlIgnore]
		public bool? HideUI { get; set; }

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00004C64 File Offset: 0x00002E64
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x00004C98 File Offset: 0x00002E98
		[XmlElement("HideUI")]
		public string HideUIString
		{
			get
			{
				if (this.HideUI == null)
				{
					return null;
				}
				return this.HideUI.ToString();
			}
			set
			{
				this.HideUI = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00004CC9 File Offset: 0x00002EC9
		// (set) Token: 0x060000F5 RID: 245 RVA: 0x00004CD1 File Offset: 0x00002ED1
		public bool DisplayQuickSteps { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00004CDA File Offset: 0x00002EDA
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x00004CE2 File Offset: 0x00002EE2
		public string SupportEmail { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x00004CEB File Offset: 0x00002EEB
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x00004CF3 File Offset: 0x00002EF3
		public bool ShowDelete { get; set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060000FA RID: 250 RVA: 0x00004CFC File Offset: 0x00002EFC
		[XmlAnyElement("GeneralCommentEnd")]
		public XmlComment GeneralCommentEnd
		{
			get
			{
				return new XmlDocument().CreateComment("General - End");
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00004D10 File Offset: 0x00002F10
		public void Upgrade(EnginePolicy enginePolicy)
		{
			if (this.HideUI != null)
			{
				enginePolicy.Settings.DisplayUI = new bool?(!this.HideUI.Value);
				int numUpgradedItems = this.NumUpgradedItems + 1;
				this.NumUpgradedItems = numUpgradedItems;
				this.HideUI = null;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00004D6D File Offset: 0x00002F6D
		// (set) Token: 0x060000FD RID: 253 RVA: 0x00004D75 File Offset: 0x00002F75
		[XmlIgnore]
		public int NumUpgradedItems { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00004D7E File Offset: 0x00002F7E
		// (set) Token: 0x060000FF RID: 255 RVA: 0x00004D86 File Offset: 0x00002F86
		public string CurrentPage { get; set; }

		// Token: 0x0400004F RID: 79
		private List<IUpgradeable> UpgradeableSections = new List<IUpgradeable>();

		// Token: 0x04000050 RID: 80
		private List<IUpgradeToUiPolicy> UpgradeToUiPolicySections = new List<IUpgradeToUiPolicy>();

		// Token: 0x02000049 RID: 73
		public enum Tristate : byte
		{
			// Token: 0x04000164 RID: 356
			Null,
			// Token: 0x04000165 RID: 357
			True,
			// Token: 0x04000166 RID: 358
			False
		}

		// Token: 0x0200004A RID: 74
		public enum SelectedButtonEnum
		{
			// Token: 0x04000168 RID: 360
			None,
			// Token: 0x04000169 RID: 361
			Applications,
			// Token: 0x0400016A RID: 362
			Documents,
			// Token: 0x0400016B RID: 363
			Pictures,
			// Token: 0x0400016C RID: 364
			Videos,
			// Token: 0x0400016D RID: 365
			Music,
			// Token: 0x0400016E RID: 366
			Others,
			// Token: 0x0400016F RID: 367
			Advanced,
			// Token: 0x04000170 RID: 368
			Users
		}

		// Token: 0x0200004B RID: 75
		public enum DefaultType
		{
			// Token: 0x04000172 RID: 370
			Normal,
			// Token: 0x04000173 RID: 371
			MSFTProfile,
			// Token: 0x04000174 RID: 372
			Profile,
			// Token: 0x04000175 RID: 373
			Custom,
			// Token: 0x04000176 RID: 374
			Enterprise,
			// Token: 0x04000177 RID: 375
			EnterpriseGov,
			// Token: 0x04000178 RID: 376
			Business,
			// Token: 0x04000179 RID: 377
			Express
		}

		// Token: 0x0200004C RID: 76
		public class Application
		{
			// Token: 0x17000168 RID: 360
			// (get) Token: 0x06000381 RID: 897 RVA: 0x0000A042 File Offset: 0x00008242
			// (set) Token: 0x06000382 RID: 898 RVA: 0x0000A04A File Offset: 0x0000824A
			[XmlAttribute]
			public string Id { get; set; }

			// Token: 0x17000169 RID: 361
			// (get) Token: 0x06000383 RID: 899 RVA: 0x0000A053 File Offset: 0x00008253
			// (set) Token: 0x06000384 RID: 900 RVA: 0x0000A05B File Offset: 0x0000825B
			[XmlAttribute]
			public bool Selected { get; set; }

			// Token: 0x1700016A RID: 362
			// (get) Token: 0x06000385 RID: 901 RVA: 0x0000A064 File Offset: 0x00008264
			// (set) Token: 0x06000386 RID: 902 RVA: 0x0000A06C File Offset: 0x0000826C
			[XmlAttribute]
			public string Name { get; set; }

			// Token: 0x1700016B RID: 363
			// (get) Token: 0x06000387 RID: 903 RVA: 0x0000A075 File Offset: 0x00008275
			// (set) Token: 0x06000388 RID: 904 RVA: 0x0000A07D File Offset: 0x0000827D
			[XmlAttribute]
			public string Publisher { get; set; }

			// Token: 0x1700016C RID: 364
			// (get) Token: 0x06000389 RID: 905 RVA: 0x0000A086 File Offset: 0x00008286
			// (set) Token: 0x0600038A RID: 906 RVA: 0x0000A08E File Offset: 0x0000828E
			[XmlAttribute]
			public bool Modify { get; set; }
		}

		// Token: 0x0200004D RID: 77
		public class Run
		{
			// Token: 0x1700016D RID: 365
			// (get) Token: 0x0600038C RID: 908 RVA: 0x0000A097 File Offset: 0x00008297
			// (set) Token: 0x0600038D RID: 909 RVA: 0x0000A09F File Offset: 0x0000829F
			[XmlAttribute]
			public string Trigger { get; set; }

			// Token: 0x1700016E RID: 366
			// (get) Token: 0x0600038E RID: 910 RVA: 0x0000A0A8 File Offset: 0x000082A8
			// (set) Token: 0x0600038F RID: 911 RVA: 0x0000A0B0 File Offset: 0x000082B0
			[XmlAttribute]
			public string When { get; set; }

			// Token: 0x1700016F RID: 367
			// (get) Token: 0x06000390 RID: 912 RVA: 0x0000A0B9 File Offset: 0x000082B9
			// (set) Token: 0x06000391 RID: 913 RVA: 0x0000A0C1 File Offset: 0x000082C1
			public string Name { get; set; }

			// Token: 0x17000170 RID: 368
			// (get) Token: 0x06000392 RID: 914 RVA: 0x0000A0CA File Offset: 0x000082CA
			// (set) Token: 0x06000393 RID: 915 RVA: 0x0000A0D2 File Offset: 0x000082D2
			public string File { get; set; }

			// Token: 0x17000171 RID: 369
			// (get) Token: 0x06000394 RID: 916 RVA: 0x0000A0DB File Offset: 0x000082DB
			// (set) Token: 0x06000395 RID: 917 RVA: 0x0000A0E3 File Offset: 0x000082E3
			public string Parameters { get; set; }

			// Token: 0x17000172 RID: 370
			// (get) Token: 0x06000396 RID: 918 RVA: 0x0000A0EC File Offset: 0x000082EC
			// (set) Token: 0x06000397 RID: 919 RVA: 0x0000A0F4 File Offset: 0x000082F4
			[XmlAttribute]
			public int Timeout { get; set; }

			// Token: 0x06000398 RID: 920 RVA: 0x0000A100 File Offset: 0x00008300
			public Run()
			{
				this.Trigger = string.Empty;
				this.When = string.Empty;
				this.Name = string.Empty;
				this.File = string.Empty;
				this.Parameters = string.Empty;
				this.Timeout = 30;
			}
		}

		// Token: 0x0200004E RID: 78
		public class Login
		{
			// Token: 0x17000173 RID: 371
			// (get) Token: 0x06000399 RID: 921 RVA: 0x0000A152 File Offset: 0x00008352
			// (set) Token: 0x0600039A RID: 922 RVA: 0x0000A15A File Offset: 0x0000835A
			[XmlAttribute]
			public string Who { get; set; }

			// Token: 0x17000174 RID: 372
			// (get) Token: 0x0600039B RID: 923 RVA: 0x0000A163 File Offset: 0x00008363
			// (set) Token: 0x0600039C RID: 924 RVA: 0x0000A16B File Offset: 0x0000836B
			public List<string> User { get; set; }

			// Token: 0x0600039D RID: 925 RVA: 0x0000A174 File Offset: 0x00008374
			public Login()
			{
				this.User = new List<string>();
			}
		}

		// Token: 0x0200004F RID: 79
		public class FileBasedTransferData
		{
			// Token: 0x17000175 RID: 373
			// (get) Token: 0x0600039E RID: 926 RVA: 0x0000A187 File Offset: 0x00008387
			// (set) Token: 0x0600039F RID: 927 RVA: 0x0000A18F File Offset: 0x0000838F
			[XmlAttribute]
			public string Source { get; set; }

			// Token: 0x17000176 RID: 374
			// (get) Token: 0x060003A0 RID: 928 RVA: 0x0000A198 File Offset: 0x00008398
			// (set) Token: 0x060003A1 RID: 929 RVA: 0x0000A1A0 File Offset: 0x000083A0
			[XmlAttribute]
			public string Target { get; set; }

			// Token: 0x17000177 RID: 375
			// (get) Token: 0x060003A2 RID: 930 RVA: 0x0000A1A9 File Offset: 0x000083A9
			// (set) Token: 0x060003A3 RID: 931 RVA: 0x0000A1B1 File Offset: 0x000083B1
			[XmlAttribute]
			public string File { get; set; }
		}

		// Token: 0x02000050 RID: 80
		public class RedirectionData
		{
			// Token: 0x17000178 RID: 376
			// (get) Token: 0x060003A5 RID: 933 RVA: 0x0000A1BA File Offset: 0x000083BA
			// (set) Token: 0x060003A6 RID: 934 RVA: 0x0000A1C2 File Offset: 0x000083C2
			[XmlAttribute]
			public string Path { get; set; }

			// Token: 0x17000179 RID: 377
			// (get) Token: 0x060003A7 RID: 935 RVA: 0x0000A1CB File Offset: 0x000083CB
			// (set) Token: 0x060003A8 RID: 936 RVA: 0x0000A1D3 File Offset: 0x000083D3
			[XmlAttribute]
			public string Target { get; set; }

			// Token: 0x1700017A RID: 378
			// (get) Token: 0x060003A9 RID: 937 RVA: 0x0000A1DC File Offset: 0x000083DC
			// (set) Token: 0x060003AA RID: 938 RVA: 0x0000A1E4 File Offset: 0x000083E4
			[XmlIgnore]
			public bool Transfer { get; set; }
		}

		// Token: 0x02000051 RID: 81
		public class MachinePair
		{
			// Token: 0x1700017B RID: 379
			// (get) Token: 0x060003AC RID: 940 RVA: 0x0000A1ED File Offset: 0x000083ED
			// (set) Token: 0x060003AD RID: 941 RVA: 0x0000A1F5 File Offset: 0x000083F5
			[XmlAttribute]
			public string Source { get; set; }

			// Token: 0x1700017C RID: 380
			// (get) Token: 0x060003AE RID: 942 RVA: 0x0000A1FE File Offset: 0x000083FE
			// (set) Token: 0x060003AF RID: 943 RVA: 0x0000A206 File Offset: 0x00008406
			[XmlAttribute]
			public string Target { get; set; }
		}

		// Token: 0x02000052 RID: 82
		public class DomainTransfer
		{
			// Token: 0x1700017D RID: 381
			// (get) Token: 0x060003B1 RID: 945 RVA: 0x0000A20F File Offset: 0x0000840F
			// (set) Token: 0x060003B2 RID: 946 RVA: 0x0000A217 File Offset: 0x00008417
			[XmlAttribute]
			public string Old { get; set; }

			// Token: 0x1700017E RID: 382
			// (get) Token: 0x060003B3 RID: 947 RVA: 0x0000A220 File Offset: 0x00008420
			// (set) Token: 0x060003B4 RID: 948 RVA: 0x0000A228 File Offset: 0x00008428
			[XmlAttribute]
			public string New { get; set; }

			// Token: 0x060003B5 RID: 949 RVA: 0x0000A234 File Offset: 0x00008434
			public int Upgrade(EnginePolicy enginePolicy)
			{
				int result = 0;
				if (!string.IsNullOrWhiteSpace(this.Old) || !string.IsNullOrWhiteSpace(this.New))
				{
					enginePolicy.UserMap.Domains.Insert(0, new EnginePolicy.DomainMapPolicy
					{
						Source = this.Old,
						Target = this.New
					});
					this.Old = null;
					this.New = null;
					result = 1;
				}
				return result;
			}
		}

		// Token: 0x02000053 RID: 83
		public class WelcomePagePolicy
		{
			// Token: 0x1700017F RID: 383
			// (get) Token: 0x060003B7 RID: 951 RVA: 0x0000A29C File Offset: 0x0000849C
			[XmlAnyElement("WelcomePageCommentStart")]
			public XmlComment WelcomePageCommentStart
			{
				get
				{
					return new XmlDocument().CreateComment("WelcomePage - Start");
				}
			}

			// Token: 0x17000180 RID: 384
			// (get) Token: 0x060003B8 RID: 952 RVA: 0x0000A2AD File Offset: 0x000084AD
			// (set) Token: 0x060003B9 RID: 953 RVA: 0x0000A2B5 File Offset: 0x000084B5
			public bool WpAdvancedClicked { get; set; }

			// Token: 0x17000181 RID: 385
			// (get) Token: 0x060003BA RID: 954 RVA: 0x0000A2BE File Offset: 0x000084BE
			// (set) Token: 0x060003BB RID: 955 RVA: 0x0000A2C6 File Offset: 0x000084C6
			public bool WpNextClicked { get; set; }

			// Token: 0x17000182 RID: 386
			// (get) Token: 0x060003BC RID: 956 RVA: 0x0000A2CF File Offset: 0x000084CF
			[XmlAnyElement("WelcomePageCommentEnd")]
			public XmlComment WelcomePageCommentEnd
			{
				get
				{
					return new XmlDocument().CreateComment("WelcomePage - End");
				}
			}
		}

		// Token: 0x02000054 RID: 84
		public class WarningPagePolicy : IUpgradeable
		{
			// Token: 0x17000183 RID: 387
			// (get) Token: 0x060003BE RID: 958 RVA: 0x0000A2E0 File Offset: 0x000084E0
			[XmlAnyElement("WarningPageCommentStart")]
			public XmlComment WelcomePageCommentStart
			{
				get
				{
					return new XmlDocument().CreateComment("WarningPage - Start");
				}
			}

			// Token: 0x17000184 RID: 388
			// (get) Token: 0x060003BF RID: 959 RVA: 0x0000A2F1 File Offset: 0x000084F1
			// (set) Token: 0x060003C0 RID: 960 RVA: 0x0000A314 File Offset: 0x00008514
			[XmlAttribute("IsPageDisplayed")]
			public string IsPageDisplayedString
			{
				get
				{
					if (this._isPageDisplayed == null)
					{
						return null;
					}
					return this._isPageDisplayed.ToString();
				}
				set
				{
					this._isPageDisplayed = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}

			// Token: 0x17000185 RID: 389
			// (get) Token: 0x060003C1 RID: 961 RVA: 0x0000A345 File Offset: 0x00008545
			// (set) Token: 0x060003C2 RID: 962 RVA: 0x0000A34D File Offset: 0x0000854D
			public bool WarnPageChecked { get; set; }

			// Token: 0x17000186 RID: 390
			// (get) Token: 0x060003C3 RID: 963 RVA: 0x0000A356 File Offset: 0x00008556
			// (set) Token: 0x060003C4 RID: 964 RVA: 0x0000A35E File Offset: 0x0000855E
			public bool WarnPageNextClicked { get; set; }

			// Token: 0x17000187 RID: 391
			// (get) Token: 0x060003C5 RID: 965 RVA: 0x0000A367 File Offset: 0x00008567
			[XmlAnyElement("WarnPageCommentEnd")]
			public XmlComment WarnPageCommentEnd
			{
				get
				{
					return new XmlDocument().CreateComment("WarnPage - End");
				}
			}

			// Token: 0x17000188 RID: 392
			// (get) Token: 0x060003C6 RID: 966 RVA: 0x0000A378 File Offset: 0x00008578
			// (set) Token: 0x060003C7 RID: 967 RVA: 0x0000A380 File Offset: 0x00008580
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x060003C8 RID: 968 RVA: 0x0000A38C File Offset: 0x0000858C
			public void Upgrade(EnginePolicy enginePolicy)
			{
				if (this._isPageDisplayed != null)
				{
					enginePolicy.Settings.DisplayWarningPage = this._isPageDisplayed;
					this._isPageDisplayed = null;
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
				}
			}

			// Token: 0x04000193 RID: 403
			private bool? _isPageDisplayed;
		}

		// Token: 0x02000055 RID: 85
		public class LicensePagePolicy : IUpgradeable
		{
			// Token: 0x17000189 RID: 393
			// (get) Token: 0x060003CA RID: 970 RVA: 0x0000A3D3 File Offset: 0x000085D3
			[XmlAnyElement("LicensePageCommentStart")]
			public XmlComment LicensePageCommentStart
			{
				get
				{
					return new XmlDocument().CreateComment("LicensePage - Start");
				}
			}

			// Token: 0x1700018A RID: 394
			// (get) Token: 0x060003CB RID: 971 RVA: 0x0000A3E4 File Offset: 0x000085E4
			// (set) Token: 0x060003CC RID: 972 RVA: 0x0000A3EC File Offset: 0x000085EC
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }

			// Token: 0x1700018B RID: 395
			// (get) Token: 0x060003CD RID: 973 RVA: 0x0000A3F5 File Offset: 0x000085F5
			// (set) Token: 0x060003CE RID: 974 RVA: 0x0000A3FD File Offset: 0x000085FD
			public string LpUser { get; set; }

			// Token: 0x1700018C RID: 396
			// (get) Token: 0x060003CF RID: 975 RVA: 0x0000A406 File Offset: 0x00008606
			// (set) Token: 0x060003D0 RID: 976 RVA: 0x0000A40E File Offset: 0x0000860E
			public string LpEmail { get; set; }

			// Token: 0x1700018D RID: 397
			// (get) Token: 0x060003D1 RID: 977 RVA: 0x0000A417 File Offset: 0x00008617
			// (set) Token: 0x060003D2 RID: 978 RVA: 0x0000A41F File Offset: 0x0000861F
			public string LpSerialNumber { get; set; }

			// Token: 0x1700018E RID: 398
			// (get) Token: 0x060003D3 RID: 979 RVA: 0x0000A428 File Offset: 0x00008628
			// (set) Token: 0x060003D4 RID: 980 RVA: 0x0000A430 File Offset: 0x00008630
			public bool AllowReentryOnError { get; set; } = true;

			// Token: 0x1700018F RID: 399
			// (get) Token: 0x060003D5 RID: 981 RVA: 0x0000A439 File Offset: 0x00008639
			[XmlAnyElement("LicensePageCommentEnd")]
			public XmlComment LicensePageCommentEnd
			{
				get
				{
					return new XmlDocument().CreateComment("LicensePage - End");
				}
			}

			// Token: 0x17000190 RID: 400
			// (get) Token: 0x060003D6 RID: 982 RVA: 0x0000A44A File Offset: 0x0000864A
			// (set) Token: 0x060003D7 RID: 983 RVA: 0x0000A452 File Offset: 0x00008652
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x060003D8 RID: 984 RVA: 0x0000A45C File Offset: 0x0000865C
			public void Upgrade(EnginePolicy enginePolicy)
			{
				if (this.LpUser != null)
				{
					if (!string.IsNullOrWhiteSpace(this.LpUser))
					{
						enginePolicy.Registration.Name = this.LpUser;
						int numUpgradedItems = this.NumUpgradedItems;
						this.NumUpgradedItems = numUpgradedItems + 1;
					}
					this.LpUser = null;
				}
				if (this.LpEmail != null)
				{
					if (!string.IsNullOrWhiteSpace(this.LpEmail))
					{
						enginePolicy.Registration.Email = this.LpEmail;
						int numUpgradedItems = this.NumUpgradedItems;
						this.NumUpgradedItems = numUpgradedItems + 1;
					}
					this.LpEmail = null;
				}
				if (this.LpSerialNumber != null)
				{
					if (!string.IsNullOrWhiteSpace(this.LpSerialNumber))
					{
						enginePolicy.Registration.SerialNumber.Value = this.LpSerialNumber;
						int numUpgradedItems = this.NumUpgradedItems;
						this.NumUpgradedItems = numUpgradedItems + 1;
					}
					this.LpSerialNumber = null;
				}
			}
		}

		// Token: 0x02000056 RID: 86
		public class GetInstalledPagePolicy
		{
			// Token: 0x17000191 RID: 401
			// (get) Token: 0x060003DA RID: 986 RVA: 0x0000A534 File Offset: 0x00008734
			[XmlAnyElement("GetInstalledCommentStart")]
			public XmlComment GetInstalledCommentStart
			{
				get
				{
					return new XmlDocument().CreateComment("GetInstalled - Start");
				}
			}

			// Token: 0x17000192 RID: 402
			// (get) Token: 0x060003DB RID: 987 RVA: 0x0000A545 File Offset: 0x00008745
			// (set) Token: 0x060003DC RID: 988 RVA: 0x0000A54D File Offset: 0x0000874D
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }

			// Token: 0x17000193 RID: 403
			// (get) Token: 0x060003DD RID: 989 RVA: 0x0000A556 File Offset: 0x00008756
			// (set) Token: 0x060003DE RID: 990 RVA: 0x0000A55E File Offset: 0x0000875E
			public DefaultPolicy.Tristate GiIsEULAAccepted { get; set; }

			// Token: 0x060003DF RID: 991 RVA: 0x0000A567 File Offset: 0x00008767
			public bool ShouldSerializeGiIsEULAAccepted()
			{
				return this.GiIsEULAAccepted > DefaultPolicy.Tristate.Null;
			}

			// Token: 0x17000194 RID: 404
			// (get) Token: 0x060003E0 RID: 992 RVA: 0x0000A572 File Offset: 0x00008772
			[XmlAnyElement("GetInstalledCommentEnd")]
			public XmlComment GetInstalledCommentEnd
			{
				get
				{
					return new XmlDocument().CreateComment("GetInstalled - End");
				}
			}
		}

		// Token: 0x02000057 RID: 87
		public class AdvancedOptionsPagePolicy : IUpgradeable
		{
			// Token: 0x17000195 RID: 405
			// (get) Token: 0x060003E2 RID: 994 RVA: 0x0000A583 File Offset: 0x00008783
			[XmlAnyElement("AdvancedOptionsCommentStart")]
			public XmlComment AdvancedOptionsCommentStart
			{
				get
				{
					return new XmlDocument().CreateComment("AdvancedOptions - Start");
				}
			}

			// Token: 0x17000196 RID: 406
			// (get) Token: 0x060003E3 RID: 995 RVA: 0x0000A594 File Offset: 0x00008794
			// (set) Token: 0x060003E4 RID: 996 RVA: 0x0000A59C File Offset: 0x0000879C
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }

			// Token: 0x17000197 RID: 407
			// (get) Token: 0x060003E5 RID: 997 RVA: 0x0000A5A5 File Offset: 0x000087A5
			// (set) Token: 0x060003E6 RID: 998 RVA: 0x0000A5C3 File Offset: 0x000087C3
			public string AoOptionSelection
			{
				get
				{
					if (this._aoOptionSelection == DefaultPolicy.AdvancedOptionsPagePolicy.ObsOptionSelections.None)
					{
						return null;
					}
					return this._aoOptionSelection.ToString();
				}
				set
				{
					if (string.IsNullOrWhiteSpace(value))
					{
						this._aoOptionSelection = DefaultPolicy.AdvancedOptionsPagePolicy.ObsOptionSelections.None;
					}
					else
					{
						this._aoOptionSelection = (DefaultPolicy.AdvancedOptionsPagePolicy.ObsOptionSelections)Enum.Parse(typeof(DefaultPolicy.AdvancedOptionsPagePolicy.ObsOptionSelections), value);
					}
					this._setAoOptionSelection = true;
				}
			}

			// Token: 0x17000198 RID: 408
			// (get) Token: 0x060003E7 RID: 999 RVA: 0x0000A5F8 File Offset: 0x000087F8
			// (set) Token: 0x060003E8 RID: 1000 RVA: 0x0000A627 File Offset: 0x00008827
			[XmlElement("HideTransferButton")]
			public string ObsHideTransferButton
			{
				get
				{
					if (this._hideTransferButton == null)
					{
						return null;
					}
					return this._hideTransferButton.Value.ToString();
				}
				set
				{
					this._hideTransferButton = new bool?(bool.Parse(value));
				}
			}

			// Token: 0x17000199 RID: 409
			// (get) Token: 0x060003E9 RID: 1001 RVA: 0x0000A63C File Offset: 0x0000883C
			// (set) Token: 0x060003EA RID: 1002 RVA: 0x0000A66B File Offset: 0x0000886B
			[XmlElement("HideFilesBasedButton")]
			public string ObsHideFilesBasedButton
			{
				get
				{
					if (this._hideFilesBasedButton == null)
					{
						return null;
					}
					return this._hideFilesBasedButton.Value.ToString();
				}
				set
				{
					this._hideFilesBasedButton = new bool?(bool.Parse(value));
				}
			}

			// Token: 0x1700019A RID: 410
			// (get) Token: 0x060003EB RID: 1003 RVA: 0x0000A680 File Offset: 0x00008880
			// (set) Token: 0x060003EC RID: 1004 RVA: 0x0000A6AF File Offset: 0x000088AF
			[XmlElement("HideImageButton")]
			public string ObsHideImageButton
			{
				get
				{
					if (this._hideImageButton == null)
					{
						return null;
					}
					return this._hideImageButton.Value.ToString();
				}
				set
				{
					this._hideImageButton = new bool?(bool.Parse(value));
				}
			}

			// Token: 0x1700019B RID: 411
			// (get) Token: 0x060003ED RID: 1005 RVA: 0x0000A6C4 File Offset: 0x000088C4
			// (set) Token: 0x060003EE RID: 1006 RVA: 0x0000A6F3 File Offset: 0x000088F3
			[XmlElement("HideProfileButton")]
			public string ObsHideProfileButton
			{
				get
				{
					if (this._hideProfileButton == null)
					{
						return null;
					}
					return this._hideProfileButton.Value.ToString();
				}
				set
				{
					this._hideProfileButton = new bool?(bool.Parse(value));
				}
			}

			// Token: 0x1700019C RID: 412
			// (get) Token: 0x060003EF RID: 1007 RVA: 0x0000A706 File Offset: 0x00008906
			// (set) Token: 0x060003F0 RID: 1008 RVA: 0x0000A70E File Offset: 0x0000890E
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x060003F1 RID: 1009 RVA: 0x0000A718 File Offset: 0x00008918
			public void Upgrade(EnginePolicy enginePolicy)
			{
				if (this._hideFilesBasedButton != null)
				{
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
					this._hideFilesBasedButton = null;
				}
				if (this._hideTransferButton != null)
				{
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
					this._hideTransferButton = null;
				}
				if (this._hideImageButton != null)
				{
					enginePolicy.Connection.Image.Enable = !this._hideImageButton.Value;
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
					this._hideImageButton = null;
				}
				if (this._hideProfileButton != null)
				{
					enginePolicy.Connection.Self.Enable = !this._hideProfileButton.Value;
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
					this._hideProfileButton = null;
				}
				if (this._setAoOptionSelection)
				{
					MigrationTypeOption defaultOption;
					switch (this._aoOptionSelection)
					{
					case DefaultPolicy.AdvancedOptionsPagePolicy.ObsOptionSelections.FileBased:
						defaultOption = MigrationTypeOption.FileBased;
						break;
					case DefaultPolicy.AdvancedOptionsPagePolicy.ObsOptionSelections.ImageAndDrive:
						defaultOption = MigrationTypeOption.Image;
						break;
					case DefaultPolicy.AdvancedOptionsPagePolicy.ObsOptionSelections.UpgradeAssistant:
						defaultOption = MigrationTypeOption.WinUpgrade;
						break;
					case DefaultPolicy.AdvancedOptionsPagePolicy.ObsOptionSelections.Profile:
						defaultOption = MigrationTypeOption.Profile;
						break;
					case DefaultPolicy.AdvancedOptionsPagePolicy.ObsOptionSelections.Transfer:
						defaultOption = MigrationTypeOption.Migration;
						break;
					default:
						defaultOption = MigrationTypeOption.Nothing;
						break;
					}
					enginePolicy.MigType.DefaultOption = defaultOption;
					this._setAoOptionSelection = false;
					this._aoOptionSelection = DefaultPolicy.AdvancedOptionsPagePolicy.ObsOptionSelections.None;
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
				}
			}

			// Token: 0x1700019D RID: 413
			// (get) Token: 0x060003F2 RID: 1010 RVA: 0x0000A870 File Offset: 0x00008A70
			[XmlAnyElement("AdvancedOptionsCommentEnd")]
			public XmlComment AdvancedOptionsCommentEnd
			{
				get
				{
					return new XmlDocument().CreateComment("AdvancedOptions - End");
				}
			}

			// Token: 0x040001A0 RID: 416
			private bool _setAoOptionSelection;

			// Token: 0x040001A1 RID: 417
			private DefaultPolicy.AdvancedOptionsPagePolicy.ObsOptionSelections _aoOptionSelection = DefaultPolicy.AdvancedOptionsPagePolicy.ObsOptionSelections.None;

			// Token: 0x040001A2 RID: 418
			private bool? _hideTransferButton;

			// Token: 0x040001A3 RID: 419
			private bool? _hideFilesBasedButton;

			// Token: 0x040001A4 RID: 420
			private bool? _hideImageButton;

			// Token: 0x040001A5 RID: 421
			private bool? _hideProfileButton;

			// Token: 0x020000F3 RID: 243
			public enum ObsOptionSelections
			{
				// Token: 0x040002F2 RID: 754
				FileBased,
				// Token: 0x040002F3 RID: 755
				ImageAndDrive,
				// Token: 0x040002F4 RID: 756
				UpgradeAssistant,
				// Token: 0x040002F5 RID: 757
				Profile,
				// Token: 0x040002F6 RID: 758
				Transfer,
				// Token: 0x040002F7 RID: 759
				None
			}
		}

		// Token: 0x02000058 RID: 88
		public class SelectImagePagePolicy : IUpgradeable
		{
			// Token: 0x060003F4 RID: 1012 RVA: 0x0000A890 File Offset: 0x00008A90
			public SelectImagePagePolicy()
			{
				this.FolderMappings = new ObservableCollection<ImageFolderMapping>();
			}

			// Token: 0x1700019E RID: 414
			// (get) Token: 0x060003F5 RID: 1013 RVA: 0x0000A8A3 File Offset: 0x00008AA3
			[XmlAnyElement("SelectImagePageCommentStart")]
			public XmlComment SelectImagePageCommentStart
			{
				get
				{
					return new XmlDocument().CreateComment("SelectImagePage - Start");
				}
			}

			// Token: 0x1700019F RID: 415
			// (get) Token: 0x060003F6 RID: 1014 RVA: 0x0000A8B4 File Offset: 0x00008AB4
			// (set) Token: 0x060003F7 RID: 1015 RVA: 0x0000A8D8 File Offset: 0x00008AD8
			[XmlAttribute("IsPageDisplayed")]
			public string IsPageDisplayedString
			{
				get
				{
					if (this._isPageDisplayed == null)
					{
						return null;
					}
					return this._isPageDisplayed.ToString();
				}
				set
				{
					this._isPageDisplayed = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}

			// Token: 0x170001A0 RID: 416
			// (get) Token: 0x060003F8 RID: 1016 RVA: 0x0000A909 File Offset: 0x00008B09
			// (set) Token: 0x060003F9 RID: 1017 RVA: 0x0000A911 File Offset: 0x00008B11
			public string SiSingleDrive { get; set; }

			// Token: 0x170001A1 RID: 417
			// (get) Token: 0x060003FA RID: 1018 RVA: 0x0000A91C File Offset: 0x00008B1C
			// (set) Token: 0x060003FB RID: 1019 RVA: 0x0000A94B File Offset: 0x00008B4B
			[XmlElement("SiSingleSelected")]
			public string ObsSiSingleSelected
			{
				get
				{
					if (this._siSingleSelected == null)
					{
						return null;
					}
					return this._siSingleSelected.Value.ToString();
				}
				set
				{
					this._siSingleSelected = new bool?(bool.Parse(value));
				}
			}

			// Token: 0x170001A2 RID: 418
			// (get) Token: 0x060003FC RID: 1020 RVA: 0x0000A95E File Offset: 0x00008B5E
			// (set) Token: 0x060003FD RID: 1021 RVA: 0x0000A966 File Offset: 0x00008B66
			[XmlArray(ElementName = "FolderMappings")]
			[XmlArrayItem(ElementName = "ImageFolderMapping")]
			public ObservableCollection<ImageFolderMapping> FolderMappings { get; set; }

			// Token: 0x170001A3 RID: 419
			// (get) Token: 0x060003FE RID: 1022 RVA: 0x0000A96F File Offset: 0x00008B6F
			[XmlAnyElement("SelectImagePageCommentEnd")]
			public XmlComment SelectImagePageCommentEnd
			{
				get
				{
					return new XmlDocument().CreateComment("SelectImagePageComment - End");
				}
			}

			// Token: 0x170001A4 RID: 420
			// (get) Token: 0x060003FF RID: 1023 RVA: 0x0000A980 File Offset: 0x00008B80
			// (set) Token: 0x06000400 RID: 1024 RVA: 0x0000A988 File Offset: 0x00008B88
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x06000401 RID: 1025 RVA: 0x0000A994 File Offset: 0x00008B94
			public void Upgrade(EnginePolicy enginePolicy)
			{
				if (this.FolderMappings != null && this.FolderMappings.Count > 0)
				{
					foreach (ImageFolderMapping mapping in this.FolderMappings)
					{
						enginePolicy.MigType.Image.DiskMapping.Add(new EnginePolicy.VirtualToPhysical(mapping));
						int numUpgradedItems = this.NumUpgradedItems + 1;
						this.NumUpgradedItems = numUpgradedItems;
					}
					this.FolderMappings.Clear();
				}
				bool? siSingleSelected = this._siSingleSelected;
				bool flag = true;
				if ((siSingleSelected.GetValueOrDefault() == flag & siSingleSelected != null) && !string.IsNullOrWhiteSpace(this.SiSingleDrive))
				{
					EnginePolicy.VirtualToPhysical virtualToPhysical = enginePolicy.MigType.Image.DiskMapping.FirstOrDefault((EnginePolicy.VirtualToPhysical m) => string.Compare(m.VStr, "C:\\", true) == 0);
					if (virtualToPhysical == null)
					{
						enginePolicy.MigType.Image.DiskMapping.Add(new EnginePolicy.VirtualToPhysical
						{
							VStr = "C:\\",
							PStr = this.SiSingleDrive
						});
					}
					else
					{
						virtualToPhysical.PStr = this.SiSingleDrive;
					}
				}
				if (this.SiSingleDrive != null)
				{
					this.SiSingleDrive = null;
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
				}
				if (this._siSingleSelected != null)
				{
					this._siSingleSelected = null;
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
				}
				if (this._isPageDisplayed != null)
				{
					enginePolicy.MigType.Image.Interactive = this._isPageDisplayed;
					this._isPageDisplayed = null;
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
				}
			}

			// Token: 0x040001A7 RID: 423
			private bool? _isPageDisplayed;

			// Token: 0x040001A9 RID: 425
			private bool? _siSingleSelected;
		}

		// Token: 0x02000059 RID: 89
		public class FilesBasedTransferPagePolicy : IUpgradeable
		{
			// Token: 0x170001A5 RID: 421
			// (get) Token: 0x06000402 RID: 1026 RVA: 0x0000AB58 File Offset: 0x00008D58
			[XmlAnyElement("FilesBasedTransferPageCommentStart")]
			public XmlComment FilesBasedTransferPageCommentStart
			{
				get
				{
					return new XmlDocument().CreateComment("FilesBasedTransferPageComment - Start");
				}
			}

			// Token: 0x170001A6 RID: 422
			// (get) Token: 0x06000403 RID: 1027 RVA: 0x0000AB69 File Offset: 0x00008D69
			// (set) Token: 0x06000404 RID: 1028 RVA: 0x0000AB71 File Offset: 0x00008D71
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }

			// Token: 0x170001A7 RID: 423
			// (get) Token: 0x06000405 RID: 1029 RVA: 0x0000AB7A File Offset: 0x00008D7A
			// (set) Token: 0x06000406 RID: 1030 RVA: 0x0000AB97 File Offset: 0x00008D97
			public string FbtOldSelected
			{
				get
				{
					if (this._fbtOldSelected == DefaultPolicy.Tristate.Null)
					{
						return null;
					}
					return this._fbtOldSelected.ToString();
				}
				set
				{
					this._fbtOldSelected = (DefaultPolicy.Tristate)Enum.Parse(typeof(DefaultPolicy.Tristate), value);
				}
			}

			// Token: 0x170001A8 RID: 424
			// (get) Token: 0x06000407 RID: 1031 RVA: 0x0000ABB4 File Offset: 0x00008DB4
			// (set) Token: 0x06000408 RID: 1032 RVA: 0x0000ABBC File Offset: 0x00008DBC
			public string FbtTransferFile { get; set; }

			// Token: 0x170001A9 RID: 425
			// (get) Token: 0x06000409 RID: 1033 RVA: 0x0000ABC5 File Offset: 0x00008DC5
			// (set) Token: 0x0600040A RID: 1034 RVA: 0x0000ABCD File Offset: 0x00008DCD
			public ObservableCollection<DefaultPolicy.FileBasedTransferData> TransferList { get; set; }

			// Token: 0x0600040B RID: 1035 RVA: 0x00002A53 File Offset: 0x00000C53
			public bool ShouldSerializeTransferList()
			{
				return false;
			}

			// Token: 0x170001AA RID: 426
			// (get) Token: 0x0600040C RID: 1036 RVA: 0x0000ABD6 File Offset: 0x00008DD6
			[XmlAnyElement("FilesBasedTransferPageCommentEnd")]
			public XmlComment FilesBasedTransferPageCommentEnd
			{
				get
				{
					return new XmlDocument().CreateComment("FilesBasedTransferPageComment - End");
				}
			}

			// Token: 0x170001AB RID: 427
			// (get) Token: 0x0600040D RID: 1037 RVA: 0x0000ABE7 File Offset: 0x00008DE7
			// (set) Token: 0x0600040E RID: 1038 RVA: 0x0000ABEF File Offset: 0x00008DEF
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x0600040F RID: 1039 RVA: 0x0000ABF8 File Offset: 0x00008DF8
			public void Upgrade(EnginePolicy enginePolicy)
			{
				if (this.FbtTransferFile != null)
				{
					if (!string.IsNullOrEmpty(this.FbtTransferFile))
					{
						enginePolicy.Connection.File.Vans.Add(new EnginePolicy.ConnectionPolicy.VanItem(this.FbtTransferFile));
					}
					this.FbtTransferFile = null;
					int numUpgradedItems = this.NumUpgradedItems;
					this.NumUpgradedItems = numUpgradedItems + 1;
				}
				if (this.TransferList != null)
				{
					foreach (DefaultPolicy.FileBasedTransferData fileBasedTransferData in this.TransferList)
					{
						enginePolicy.Connection.File.Vans.Add(new EnginePolicy.ConnectionPolicy.VanItem
						{
							Source = fileBasedTransferData.Source,
							Target = fileBasedTransferData.Target,
							File = fileBasedTransferData.File
						});
						int numUpgradedItems = this.NumUpgradedItems;
						this.NumUpgradedItems = numUpgradedItems + 1;
					}
					this.TransferList.Clear();
				}
				if (this._fbtOldSelected != DefaultPolicy.Tristate.Null)
				{
					enginePolicy.Connection.File.Settings.IsOld = new bool?(this._fbtOldSelected == DefaultPolicy.Tristate.True);
					this._fbtOldSelected = DefaultPolicy.Tristate.Null;
					int numUpgradedItems = this.NumUpgradedItems;
					this.NumUpgradedItems = numUpgradedItems + 1;
				}
			}

			// Token: 0x040001AD RID: 429
			private DefaultPolicy.Tristate _fbtOldSelected;
		}

		// Token: 0x0200005A RID: 90
		public class FilesBasedAnalyzePagePolicy
		{
			// Token: 0x170001AC RID: 428
			// (get) Token: 0x06000411 RID: 1041 RVA: 0x0000AD30 File Offset: 0x00008F30
			// (set) Token: 0x06000412 RID: 1042 RVA: 0x0000AD38 File Offset: 0x00008F38
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }

			// Token: 0x170001AD RID: 429
			// (get) Token: 0x06000413 RID: 1043 RVA: 0x0000AD41 File Offset: 0x00008F41
			// (set) Token: 0x06000414 RID: 1044 RVA: 0x0000AD49 File Offset: 0x00008F49
			public bool AllowCustomization { get; set; }

			// Token: 0x170001AE RID: 430
			// (get) Token: 0x06000415 RID: 1045 RVA: 0x0000AD52 File Offset: 0x00008F52
			// (set) Token: 0x06000416 RID: 1046 RVA: 0x0000AD5A File Offset: 0x00008F5A
			public bool CustomTransfer { get; set; }
		}

		// Token: 0x0200005B RID: 91
		public class FilesBasedTransferProgressPagePolicy
		{
			// Token: 0x170001AF RID: 431
			// (get) Token: 0x06000418 RID: 1048 RVA: 0x0000AD63 File Offset: 0x00008F63
			// (set) Token: 0x06000419 RID: 1049 RVA: 0x0000AD6B File Offset: 0x00008F6B
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }

			// Token: 0x170001B0 RID: 432
			// (get) Token: 0x0600041A RID: 1050 RVA: 0x0000AD74 File Offset: 0x00008F74
			// (set) Token: 0x0600041B RID: 1051 RVA: 0x0000AD7C File Offset: 0x00008F7C
			public bool SuppressUnloadDialogs { get; set; }

			// Token: 0x170001B1 RID: 433
			// (get) Token: 0x0600041C RID: 1052 RVA: 0x0000AD85 File Offset: 0x00008F85
			// (set) Token: 0x0600041D RID: 1053 RVA: 0x0000AD8D File Offset: 0x00008F8D
			public bool SuppressApplicationUnloadDialog { get; set; }
		}

		// Token: 0x0200005C RID: 92
		public class ProfileMigratorPagePolicy : IUpgradeable
		{
			// Token: 0x0600041F RID: 1055 RVA: 0x0000AD96 File Offset: 0x00008F96
			public ProfileMigratorPagePolicy()
			{
				this.DomainToDomain = new DefaultPolicy.DomainTransfer
				{
					Old = string.Empty,
					New = string.Empty
				};
			}

			// Token: 0x170001B2 RID: 434
			// (get) Token: 0x06000420 RID: 1056 RVA: 0x0000ADBF File Offset: 0x00008FBF
			[XmlAnyElement("ProfileMigratorPageCommentStart")]
			public XmlComment ProfileMigratorPageCommentStart
			{
				get
				{
					return new XmlDocument().CreateComment("ProfileMigratorPageComment - Start");
				}
			}

			// Token: 0x170001B3 RID: 435
			// (get) Token: 0x06000421 RID: 1057 RVA: 0x0000ADD0 File Offset: 0x00008FD0
			// (set) Token: 0x06000422 RID: 1058 RVA: 0x0000ADD8 File Offset: 0x00008FD8
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }

			// Token: 0x170001B4 RID: 436
			// (get) Token: 0x06000423 RID: 1059 RVA: 0x0000ADE1 File Offset: 0x00008FE1
			// (set) Token: 0x06000424 RID: 1060 RVA: 0x0000ADE9 File Offset: 0x00008FE9
			[XmlArray]
			public ObservableCollection<UserMap> Mappings { get; set; }

			// Token: 0x06000425 RID: 1061 RVA: 0x00002A53 File Offset: 0x00000C53
			public bool ShouldSerializeMappings()
			{
				return false;
			}

			// Token: 0x170001B5 RID: 437
			// (get) Token: 0x06000426 RID: 1062 RVA: 0x0000ADF2 File Offset: 0x00008FF2
			// (set) Token: 0x06000427 RID: 1063 RVA: 0x0000ADFA File Offset: 0x00008FFA
			public DefaultPolicy.DomainTransfer DomainToDomain { get; set; }

			// Token: 0x06000428 RID: 1064 RVA: 0x00002A53 File Offset: 0x00000C53
			public bool ShouldSerializeDomainToDomain()
			{
				return false;
			}

			// Token: 0x170001B6 RID: 438
			// (get) Token: 0x06000429 RID: 1065 RVA: 0x0000AE03 File Offset: 0x00009003
			[XmlAnyElement("ProfileMigratorPageCommentEnd")]
			public XmlComment ProfileMigratorPageCommentEnd
			{
				get
				{
					return new XmlDocument().CreateComment("ProfileMigratorPageComment - End");
				}
			}

			// Token: 0x0600042A RID: 1066 RVA: 0x0000AE14 File Offset: 0x00009014
			public static int UpgradeMappings(ObservableCollection<UserMap> mappings, EnginePolicy enginePolicy)
			{
				int num = 0;
				if (mappings != null)
				{
					num = mappings.Count;
					if (num > 0)
					{
						foreach (UserMap userMap in mappings)
						{
							Collection<EnginePolicy.UserPolicy> users = enginePolicy.UserMap.Users;
							EnginePolicy.UserPolicy userPolicy = new EnginePolicy.UserPolicy();
							UserDetail old = userMap.Old;
							userPolicy.Source = ((old != null) ? old.FriendlyName : null);
							UserDetail @new = userMap.New;
							userPolicy.Target = ((@new != null) ? @new.FriendlyName : null);
							userPolicy.TargetType = userMap.New.UserType.ToString();
							userPolicy.Migrate = !userMap.DontMigrate;
							userPolicy.Password = userMap.CreatedUserPassword;
							users.Add(userPolicy);
						}
						mappings.Clear();
					}
				}
				return num;
			}

			// Token: 0x170001B7 RID: 439
			// (get) Token: 0x0600042B RID: 1067 RVA: 0x0000AEF8 File Offset: 0x000090F8
			// (set) Token: 0x0600042C RID: 1068 RVA: 0x0000AF00 File Offset: 0x00009100
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x0600042D RID: 1069 RVA: 0x0000AF09 File Offset: 0x00009109
			public void Upgrade(EnginePolicy enginePolicy)
			{
				if (this.DomainToDomain != null)
				{
					this.NumUpgradedItems += this.DomainToDomain.Upgrade(enginePolicy);
				}
				this.NumUpgradedItems += DefaultPolicy.ProfileMigratorPagePolicy.UpgradeMappings(this.Mappings, enginePolicy);
			}
		}

		// Token: 0x0200005D RID: 93
		public class DetailButtonListPolicy : IUpgradeable
		{
			// Token: 0x170001B8 RID: 440
			// (get) Token: 0x0600042E RID: 1070 RVA: 0x0000AF45 File Offset: 0x00009145
			[XmlAnyElement("DefaultButtonListCommentStart")]
			public XmlComment DefaultButtonListCommentStart
			{
				get
				{
					return new XmlDocument().CreateComment("DefaultButtonListComment - Start");
				}
			}

			// Token: 0x170001B9 RID: 441
			// (get) Token: 0x0600042F RID: 1071 RVA: 0x0000AF56 File Offset: 0x00009156
			// (set) Token: 0x06000430 RID: 1072 RVA: 0x0000AF5E File Offset: 0x0000915E
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }

			// Token: 0x170001BA RID: 442
			// (get) Token: 0x06000431 RID: 1073 RVA: 0x0000AF67 File Offset: 0x00009167
			// (set) Token: 0x06000432 RID: 1074 RVA: 0x0000AF6F File Offset: 0x0000916F
			public DefaultPolicy.SelectedButtonEnum DblSelectedButton { get; set; }

			// Token: 0x170001BB RID: 443
			// (get) Token: 0x06000433 RID: 1075 RVA: 0x0000AF78 File Offset: 0x00009178
			// (set) Token: 0x06000434 RID: 1076 RVA: 0x0000AF80 File Offset: 0x00009180
			public string DblTitle { get; set; }

			// Token: 0x170001BC RID: 444
			// (get) Token: 0x06000435 RID: 1077 RVA: 0x0000AF89 File Offset: 0x00009189
			// (set) Token: 0x06000436 RID: 1078 RVA: 0x0000AF91 File Offset: 0x00009191
			public string DblRegion { get; set; }

			// Token: 0x170001BD RID: 445
			// (get) Token: 0x06000437 RID: 1079 RVA: 0x0000AF9A File Offset: 0x0000919A
			// (set) Token: 0x06000438 RID: 1080 RVA: 0x0000AFBC File Offset: 0x000091BC
			[XmlElement("DblShowAppButton")]
			public string DblShowAppButtonString
			{
				get
				{
					if (this._dblShowAppButton == null)
					{
						return null;
					}
					return this._dblShowAppButton.ToString();
				}
				set
				{
					this._dblShowAppButton = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}

			// Token: 0x170001BE RID: 446
			// (get) Token: 0x06000439 RID: 1081 RVA: 0x0000AFED File Offset: 0x000091ED
			// (set) Token: 0x0600043A RID: 1082 RVA: 0x0000AFF5 File Offset: 0x000091F5
			public bool DblShowDocsButton { get; set; }

			// Token: 0x170001BF RID: 447
			// (get) Token: 0x0600043B RID: 1083 RVA: 0x0000AFFE File Offset: 0x000091FE
			// (set) Token: 0x0600043C RID: 1084 RVA: 0x0000B006 File Offset: 0x00009206
			public bool DblShowPicsButton { get; set; }

			// Token: 0x170001C0 RID: 448
			// (get) Token: 0x0600043D RID: 1085 RVA: 0x0000B00F File Offset: 0x0000920F
			// (set) Token: 0x0600043E RID: 1086 RVA: 0x0000B017 File Offset: 0x00009217
			public bool DblShowVideoButton { get; set; }

			// Token: 0x170001C1 RID: 449
			// (get) Token: 0x0600043F RID: 1087 RVA: 0x0000B020 File Offset: 0x00009220
			// (set) Token: 0x06000440 RID: 1088 RVA: 0x0000B028 File Offset: 0x00009228
			public bool DblShowMusicButton { get; set; }

			// Token: 0x170001C2 RID: 450
			// (get) Token: 0x06000441 RID: 1089 RVA: 0x0000B031 File Offset: 0x00009231
			// (set) Token: 0x06000442 RID: 1090 RVA: 0x0000B039 File Offset: 0x00009239
			public bool DblShowOtherButton { get; set; }

			// Token: 0x170001C3 RID: 451
			// (get) Token: 0x06000443 RID: 1091 RVA: 0x0000B042 File Offset: 0x00009242
			// (set) Token: 0x06000444 RID: 1092 RVA: 0x0000B064 File Offset: 0x00009264
			[XmlElement("DblShowUserButton")]
			public string DblShowUserButtonString
			{
				get
				{
					if (this._dblShowUserButton == null)
					{
						return null;
					}
					return this._dblShowUserButton.ToString();
				}
				set
				{
					this._dblShowUserButton = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}

			// Token: 0x170001C4 RID: 452
			// (get) Token: 0x06000445 RID: 1093 RVA: 0x0000B095 File Offset: 0x00009295
			// (set) Token: 0x06000446 RID: 1094 RVA: 0x0000B09D File Offset: 0x0000929D
			public bool DblShowAdvancedButton { get; set; }

			// Token: 0x170001C5 RID: 453
			// (get) Token: 0x06000447 RID: 1095 RVA: 0x0000B0A6 File Offset: 0x000092A6
			[XmlAnyElement("DefaultButtonListCommentEnd")]
			public XmlComment DefaultButtonListCommentEnd
			{
				get
				{
					return new XmlDocument().CreateComment("DefaultButtonListComment - End");
				}
			}

			// Token: 0x170001C6 RID: 454
			// (get) Token: 0x06000448 RID: 1096 RVA: 0x0000B0B7 File Offset: 0x000092B7
			// (set) Token: 0x06000449 RID: 1097 RVA: 0x0000B0BF File Offset: 0x000092BF
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x0600044A RID: 1098 RVA: 0x0000B0C8 File Offset: 0x000092C8
			public void Upgrade(EnginePolicy enginePolicy)
			{
				if (this._dblShowAppButton != null)
				{
					enginePolicy.AppSel.Interactive = this._dblShowAppButton;
					this._dblShowAppButton = null;
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
				}
				if (this._dblShowUserButton != null)
				{
					enginePolicy.UserMap.Interactive = this._dblShowUserButton;
					this._dblShowUserButton = null;
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
				}
			}

			// Token: 0x040001BF RID: 447
			private bool? _dblShowAppButton;

			// Token: 0x040001C5 RID: 453
			private bool? _dblShowUserButton;
		}

		// Token: 0x0200005E RID: 94
		public class SectionApplicationsPolicy : IUpgradeable
		{
			// Token: 0x170001C7 RID: 455
			// (get) Token: 0x0600044C RID: 1100 RVA: 0x0000B149 File Offset: 0x00009349
			[XmlAnyElement("SectionApplicationsCommentStart")]
			public XmlComment SectionApplicationsCommentStart
			{
				get
				{
					return new XmlDocument().CreateComment("SectionApplications - Start");
				}
			}

			// Token: 0x170001C8 RID: 456
			// (get) Token: 0x0600044D RID: 1101 RVA: 0x0000B15A File Offset: 0x0000935A
			// (set) Token: 0x0600044E RID: 1102 RVA: 0x0000B162 File Offset: 0x00009362
			[XmlArray(ElementName = "Applications")]
			public ObservableCollection<DefaultPolicy.Application> Applications { get; set; }

			// Token: 0x170001C9 RID: 457
			// (get) Token: 0x0600044F RID: 1103 RVA: 0x0000B16B File Offset: 0x0000936B
			// (set) Token: 0x06000450 RID: 1104 RVA: 0x0000B173 File Offset: 0x00009373
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x06000451 RID: 1105 RVA: 0x0000B17C File Offset: 0x0000937C
			public void Upgrade(EnginePolicy engine)
			{
				if (this.Applications != null && this.Applications.Count > 0)
				{
					if (engine.AppSel == null)
					{
						engine.AppSel = new EnginePolicy.ApplicationsPolicy();
					}
					if (engine.AppSel.Applications == null)
					{
						engine.AppSel.Applications = new ObservableCollection<EnginePolicy.AppData>();
					}
					ObservableCollection<EnginePolicy.AppData> applications = engine.AppSel.Applications;
					using (IEnumerator<DefaultPolicy.Application> enumerator = this.Applications.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							DefaultPolicy.Application application = enumerator.Current;
							EnginePolicy.AppData appData = applications.FirstOrDefault((EnginePolicy.AppData app) => app.Id == application.Id);
							if (appData == null)
							{
								appData = new EnginePolicy.AppData
								{
									Name = application.Name,
									Id = application.Id,
									Publisher = application.Publisher,
									Migrate = application.Selected,
									Modify = true
								};
								applications.Add(appData);
								int num = this.NumUpgradedItems;
								this.NumUpgradedItems = num + 1;
							}
							else if (appData.Migrate != application.Selected)
							{
								appData.Migrate = application.Selected;
								int num = this.NumUpgradedItems + 1;
								this.NumUpgradedItems = num;
							}
						}
					}
					this.Applications.Clear();
				}
			}

			// Token: 0x170001CA RID: 458
			// (get) Token: 0x06000452 RID: 1106 RVA: 0x0000B2F0 File Offset: 0x000094F0
			[XmlAnyElement("SectionApplicationsCommentEnd")]
			public XmlComment SectionApplicationsCommentEnd
			{
				get
				{
					return new XmlDocument().CreateComment("SectionApplications - End");
				}
			}
		}

		// Token: 0x0200005F RID: 95
		public class SectionUsersPolicy : IUpgradeable
		{
			// Token: 0x170001CB RID: 459
			// (get) Token: 0x06000454 RID: 1108 RVA: 0x0000B301 File Offset: 0x00009501
			// (set) Token: 0x06000455 RID: 1109 RVA: 0x0000B309 File Offset: 0x00009509
			public bool IsPageDisplayed { get; set; }

			// Token: 0x170001CC RID: 460
			// (get) Token: 0x06000456 RID: 1110 RVA: 0x0000B312 File Offset: 0x00009512
			// (set) Token: 0x06000457 RID: 1111 RVA: 0x0000B31A File Offset: 0x0000951A
			[XmlArray]
			public ObservableCollection<UserMap> Mappings { get; set; }

			// Token: 0x06000458 RID: 1112 RVA: 0x00002A53 File Offset: 0x00000C53
			public bool ShouldSerializeMappings()
			{
				return false;
			}

			// Token: 0x170001CD RID: 461
			// (get) Token: 0x06000459 RID: 1113 RVA: 0x0000B323 File Offset: 0x00009523
			// (set) Token: 0x0600045A RID: 1114 RVA: 0x0000B32B File Offset: 0x0000952B
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x0600045B RID: 1115 RVA: 0x0000B334 File Offset: 0x00009534
			public void Upgrade(EnginePolicy enginePolicy)
			{
				this.NumUpgradedItems = DefaultPolicy.ProfileMigratorPagePolicy.UpgradeMappings(this.Mappings, enginePolicy);
			}
		}

		// Token: 0x02000060 RID: 96
		public class SectionDocumentsPolicy : IUpgradeable
		{
			// Token: 0x170001CE RID: 462
			// (get) Token: 0x0600045D RID: 1117 RVA: 0x0000B348 File Offset: 0x00009548
			// (set) Token: 0x0600045E RID: 1118 RVA: 0x0000B350 File Offset: 0x00009550
			[XmlArray]
			public ObservableCollection<DefaultPolicy.RedirectionData> Folders { get; set; }

			// Token: 0x170001CF RID: 463
			// (get) Token: 0x0600045F RID: 1119 RVA: 0x0000B359 File Offset: 0x00009559
			// (set) Token: 0x06000460 RID: 1120 RVA: 0x0000B361 File Offset: 0x00009561
			[XmlArray]
			public ObservableCollection<DefaultPolicy.RedirectionData> Files { get; set; }

			// Token: 0x170001D0 RID: 464
			// (get) Token: 0x06000461 RID: 1121 RVA: 0x0000B36A File Offset: 0x0000956A
			// (set) Token: 0x06000462 RID: 1122 RVA: 0x0000B372 File Offset: 0x00009572
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x06000463 RID: 1123 RVA: 0x0000B37C File Offset: 0x0000957C
			public void Upgrade(EnginePolicy enginePolicy)
			{
				if (this.Folders != null && this.Folders.Count > 0)
				{
					foreach (DefaultPolicy.RedirectionData redirectionData in this.Folders)
					{
						enginePolicy.DirFilter.Filters.Add(new EnginePolicy.DirFilterItem
						{
							Source = redirectionData.Path,
							TargetNonApp = redirectionData.Target,
							Migrate = new bool?(redirectionData.Transfer)
						});
						int num = this.NumUpgradedItems;
						this.NumUpgradedItems = num + 1;
					}
					this.Folders.Clear();
				}
				if (this.Files != null && this.Files.Count != 0)
				{
					foreach (DefaultPolicy.RedirectionData redirectionData2 in this.Files)
					{
						enginePolicy.FileFilter.Filters.Add(new EnginePolicy.FileFilterItem(redirectionData2.Path, redirectionData2.Target, new bool?(redirectionData2.Transfer)));
						int num = this.NumUpgradedItems + 1;
						this.NumUpgradedItems = num;
					}
					this.Files.Clear();
				}
			}
		}

		// Token: 0x02000061 RID: 97
		public class SectionAdvancedPolicy : IUpgradeable
		{
			// Token: 0x170001D1 RID: 465
			// (get) Token: 0x06000465 RID: 1125 RVA: 0x0000B4C8 File Offset: 0x000096C8
			// (set) Token: 0x06000466 RID: 1126 RVA: 0x0000B4D0 File Offset: 0x000096D0
			[XmlArray]
			public List<DrivePair> DriveMapping { get; set; }

			// Token: 0x170001D2 RID: 466
			// (get) Token: 0x06000467 RID: 1127 RVA: 0x0000B4D9 File Offset: 0x000096D9
			// (set) Token: 0x06000468 RID: 1128 RVA: 0x0000B4E1 File Offset: 0x000096E1
			[XmlArray]
			public List<FileFilter> FileFilters { get; set; }

			// Token: 0x170001D3 RID: 467
			// (get) Token: 0x06000469 RID: 1129 RVA: 0x0000B4EA File Offset: 0x000096EA
			// (set) Token: 0x0600046A RID: 1130 RVA: 0x0000B4F2 File Offset: 0x000096F2
			[XmlArray]
			public ObservableCollection<MiscSettingsGroupData> MigModSettings { get; set; }

			// Token: 0x0600046B RID: 1131 RVA: 0x0000B4FC File Offset: 0x000096FC
			public static ObservableCollection<MiscSettingsGroupData> GetDefaultMigmodSettings()
			{
				ObservableCollection<MiscSettingsGroupData> observableCollection = new ObservableCollection<MiscSettingsGroupData>();
				MiscSettingsGroupData miscSettingsGroupData = new MiscSettingsGroupData
				{
					DisplayName = PCmover.Infrastructure.Properties.Resources.MigMod_Main,
					Name = "Main",
					Settings = new List<MiscSettingData>()
				};
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_Main_Desktop,
					Name = "Desktop",
					Selected = true
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_Main_ControlPanel,
					Name = "Control Panel",
					Selected = true
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_Main_MergeIni,
					Name = "Merge Ini",
					Selected = false
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_Main_Printers,
					Name = "Printers",
					Selected = false
				});
				observableCollection.Add(miscSettingsGroupData);
				miscSettingsGroupData = new MiscSettingsGroupData
				{
					DisplayName = PCmover.Infrastructure.Properties.Resources.MigMod_Mail,
					Name = "Mail",
					Settings = new List<MiscSettingData>()
				};
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_Mail_MailClient,
					Name = "Mail Client",
					Selected = false
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_Mail_MapiProfile,
					Name = "Mapi Profile",
					Selected = true
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_Mail_OEIdentity,
					Name = "Outlook Express Identity",
					Selected = true
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_Mail_OERules,
					Name = "Outlook Express Rules",
					Selected = false
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_Mail_WAB,
					Name = "Windows Address Book",
					Selected = true
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_Mail_OutlookMailFiles,
					Name = "Outlook Mail Files",
					Selected = false
				});
				observableCollection.Add(miscSettingsGroupData);
				miscSettingsGroupData = new MiscSettingsGroupData
				{
					DisplayName = PCmover.Infrastructure.Properties.Resources.MigMod_SystemHooks,
					Name = "System Hooks",
					Settings = new List<MiscSettingData>()
				};
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_SystemHooks_AntiSpy,
					Name = "Antispy",
					Selected = false
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_SystemHooks_SuppressStartup,
					Name = "Suppress Startup",
					Selected = false
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_SystemHooks_FileAssociations,
					Name = "File Associations",
					Selected = false
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_SystemHooks_BlockGPOs,
					Name = "Block GPOs",
					Selected = true
				});
				observableCollection.Add(miscSettingsGroupData);
				miscSettingsGroupData = new MiscSettingsGroupData
				{
					DisplayName = PCmover.Infrastructure.Properties.Resources.MigMod_ApplicationSettings,
					Name = "Application Settings",
					Settings = new List<MiscSettingData>()
				};
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_ApplicationSettings_IEHome,
					Name = "IE Home",
					Selected = true
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_ApplicationSettings_IESettings,
					Name = "IE Settings",
					Selected = true
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_ApplicationSettings_WordSettings,
					Name = "Word Settings",
					Selected = false
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_ApplicationSettings_NotesIni,
					Name = "NotesIni",
					Selected = false
				});
				observableCollection.Add(miscSettingsGroupData);
				miscSettingsGroupData = new MiscSettingsGroupData
				{
					DisplayName = PCmover.Infrastructure.Properties.Resources.MigMod_Troubleshooting,
					Name = "Troubleshooting",
					Settings = new List<MiscSettingData>()
				};
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_Troubleshooting_NoWindows,
					Name = "No Windows",
					Selected = false
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_Troubleshooting_MoveNothing,
					Name = "Move Nothing",
					Selected = false
				});
				miscSettingsGroupData.Settings.Add(new MiscSettingData
				{
					Text = PCmover.Infrastructure.Properties.Resources.MigMod_Troubleshooting_EmptyFolders,
					Name = "Empty Folders",
					Selected = true
				});
				observableCollection.Add(miscSettingsGroupData);
				return observableCollection;
			}

			// Token: 0x170001D4 RID: 468
			// (get) Token: 0x0600046C RID: 1132 RVA: 0x0000B9A5 File Offset: 0x00009BA5
			// (set) Token: 0x0600046D RID: 1133 RVA: 0x0000B9AD File Offset: 0x00009BAD
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x0600046E RID: 1134 RVA: 0x0000B9B6 File Offset: 0x00009BB6
			public void Upgrade(EnginePolicy enginePolicy)
			{
				this.NumUpgradedItems += this.UpgradeDriveMapping(enginePolicy);
				this.NumUpgradedItems += this.UpgradeFileFilters(enginePolicy);
				this.NumUpgradedItems += this.UpgradeMigMod(enginePolicy);
			}

			// Token: 0x0600046F RID: 1135 RVA: 0x0000B9F4 File Offset: 0x00009BF4
			private int UpgradeFileFilters(EnginePolicy enginePolicy)
			{
				int num = 0;
				if (this.FileFilters != null && this.FileFilters.Count != 0)
				{
					foreach (FileFilter fileFilter in this.FileFilters)
					{
						enginePolicy.FileFilter.Filters.Add(new EnginePolicy.FileFilterItem(fileFilter.filter, fileFilter.target, fileFilter.transfer));
						num++;
					}
					this.FileFilters.Clear();
				}
				return num;
			}

			// Token: 0x06000470 RID: 1136 RVA: 0x0000BA90 File Offset: 0x00009C90
			private int UpgradeDriveMapping(EnginePolicy enginePolicy)
			{
				int num = 0;
				if (this.DriveMapping != null && this.DriveMapping.Count != 0)
				{
					foreach (DrivePair drivePair in this.DriveMapping)
					{
						enginePolicy.DriveMap.Drives.Add(new EnginePolicy.DriveMapItem(drivePair.OldDrive, drivePair.NewDrive));
						num++;
					}
					this.DriveMapping.Clear();
				}
				return num;
			}

			// Token: 0x06000471 RID: 1137 RVA: 0x0000BB24 File Offset: 0x00009D24
			private int UpgradeMigMod(EnginePolicy enginePolicy)
			{
				int num = 0;
				if (this.MigModSettings != null && this.MigModSettings.Count != 0)
				{
					ObservableCollection<MiscSettingsGroupData> defaultMigmodSettings = DefaultPolicy.SectionAdvancedPolicy.GetDefaultMigmodSettings();
					using (IEnumerator<MiscSettingsGroupData> enumerator = this.MigModSettings.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							MiscSettingsGroupData groupData = enumerator.Current;
							MiscSettingsGroupData miscSettingsGroupData = defaultMigmodSettings.FirstOrDefault((MiscSettingsGroupData g) => g.Name == groupData.Name);
							using (List<MiscSettingData>.Enumerator enumerator2 = groupData.Settings.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									MiscSettingData setting = enumerator2.Current;
									MiscSettingData miscSettingData = (miscSettingsGroupData != null) ? miscSettingsGroupData.Settings.FirstOrDefault((MiscSettingData s) => s.Name == setting.Name) : null;
									if (miscSettingData == null || setting.Selected != miscSettingData.Selected)
									{
										enginePolicy.MigMod.Items.Add(new EnginePolicy.MigModItem(setting.Name, new bool?(setting.Selected)));
										num++;
									}
								}
							}
						}
					}
					this.MigModSettings.Clear();
				}
				return num;
			}
		}

		// Token: 0x02000062 RID: 98
		public class FindPCPagePolicy : IUpgradeable
		{
			// Token: 0x06000473 RID: 1139 RVA: 0x0000BC84 File Offset: 0x00009E84
			public FindPCPagePolicy()
			{
				this.MachinePairs = new ObservableCollection<DefaultPolicy.MachinePair>();
			}

			// Token: 0x170001D5 RID: 469
			// (get) Token: 0x06000474 RID: 1140 RVA: 0x0000BC9F File Offset: 0x00009E9F
			// (set) Token: 0x06000475 RID: 1141 RVA: 0x0000BCA7 File Offset: 0x00009EA7
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }

			// Token: 0x170001D6 RID: 470
			// (get) Token: 0x06000476 RID: 1142 RVA: 0x0000BCB0 File Offset: 0x00009EB0
			// (set) Token: 0x06000477 RID: 1143 RVA: 0x0000BCB8 File Offset: 0x00009EB8
			[XmlAttribute]
			public int FindPcTimeout { get; set; } = 120;

			// Token: 0x170001D7 RID: 471
			// (get) Token: 0x06000478 RID: 1144 RVA: 0x0000BCC1 File Offset: 0x00009EC1
			// (set) Token: 0x06000479 RID: 1145 RVA: 0x0000BCC9 File Offset: 0x00009EC9
			public string TargetMachineName { get; set; }

			// Token: 0x170001D8 RID: 472
			// (get) Token: 0x0600047A RID: 1146 RVA: 0x0000BCD2 File Offset: 0x00009ED2
			// (set) Token: 0x0600047B RID: 1147 RVA: 0x0000BCDA File Offset: 0x00009EDA
			public bool AllowDirectWifi { get; set; }

			// Token: 0x170001D9 RID: 473
			// (get) Token: 0x0600047C RID: 1148 RVA: 0x0000BCE3 File Offset: 0x00009EE3
			// (set) Token: 0x0600047D RID: 1149 RVA: 0x0000BCEB File Offset: 0x00009EEB
			public bool DirectWifiOnly { get; set; }

			// Token: 0x170001DA RID: 474
			// (get) Token: 0x0600047E RID: 1150 RVA: 0x0000BCF4 File Offset: 0x00009EF4
			// (set) Token: 0x0600047F RID: 1151 RVA: 0x0000BCFC File Offset: 0x00009EFC
			public bool ShowVproLink { get; set; }

			// Token: 0x170001DB RID: 475
			// (get) Token: 0x06000480 RID: 1152 RVA: 0x0000BD05 File Offset: 0x00009F05
			// (set) Token: 0x06000481 RID: 1153 RVA: 0x0000BD0D File Offset: 0x00009F0D
			public ObservableCollection<DefaultPolicy.MachinePair> MachinePairs { get; set; }

			// Token: 0x06000482 RID: 1154 RVA: 0x00002A53 File Offset: 0x00000C53
			public bool ShouldSerializeMachinePairs()
			{
				return false;
			}

			// Token: 0x170001DC RID: 476
			// (get) Token: 0x06000483 RID: 1155 RVA: 0x0000BD16 File Offset: 0x00009F16
			// (set) Token: 0x06000484 RID: 1156 RVA: 0x0000BD1E File Offset: 0x00009F1E
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x06000485 RID: 1157 RVA: 0x0000BD28 File Offset: 0x00009F28
			public void Upgrade(EnginePolicy enginePolicy)
			{
				if (this.TargetMachineName != null)
				{
					if (!string.IsNullOrWhiteSpace(this.TargetMachineName))
					{
						enginePolicy.Connection.Network.Targets.Add(new EnginePolicy.ConnectionPolicy.NetworkTargetItem(this.TargetMachineName));
					}
					this.TargetMachineName = null;
					int numUpgradedItems = this.NumUpgradedItems;
					this.NumUpgradedItems = numUpgradedItems + 1;
				}
				if (this.MachinePairs.Any<DefaultPolicy.MachinePair>())
				{
					foreach (DefaultPolicy.MachinePair machinePair in this.MachinePairs)
					{
						enginePolicy.Connection.Network.Targets.Add(new EnginePolicy.ConnectionPolicy.NetworkTargetItem(machinePair.Source)
						{
							New = machinePair.Target
						});
						int numUpgradedItems = this.NumUpgradedItems;
						this.NumUpgradedItems = numUpgradedItems + 1;
					}
					this.MachinePairs.Clear();
				}
			}
		}

		// Token: 0x02000063 RID: 99
		public class AnalyzePCPagePolicy
		{
			// Token: 0x170001DD RID: 477
			// (get) Token: 0x06000486 RID: 1158 RVA: 0x0000BE10 File Offset: 0x0000A010
			// (set) Token: 0x06000487 RID: 1159 RVA: 0x0000BE18 File Offset: 0x0000A018
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }

			// Token: 0x170001DE RID: 478
			// (get) Token: 0x06000488 RID: 1160 RVA: 0x0000BE21 File Offset: 0x0000A021
			// (set) Token: 0x06000489 RID: 1161 RVA: 0x0000BE29 File Offset: 0x0000A029
			[XmlAttribute]
			public bool CustomTransfer { get; set; }
		}

		// Token: 0x02000064 RID: 100
		public class CustomTransferPagePolicy : IUpgradeable
		{
			// Token: 0x170001DF RID: 479
			// (get) Token: 0x0600048B RID: 1163 RVA: 0x0000BE32 File Offset: 0x0000A032
			// (set) Token: 0x0600048C RID: 1164 RVA: 0x0000BE3A File Offset: 0x0000A03A
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }

			// Token: 0x170001E0 RID: 480
			// (get) Token: 0x0600048D RID: 1165 RVA: 0x0000BE43 File Offset: 0x0000A043
			// (set) Token: 0x0600048E RID: 1166 RVA: 0x0000BE4B File Offset: 0x0000A04B
			[XmlAttribute]
			public bool AutoCustomize { get; set; }

			// Token: 0x170001E1 RID: 481
			// (get) Token: 0x0600048F RID: 1167 RVA: 0x0000BE54 File Offset: 0x0000A054
			// (set) Token: 0x06000490 RID: 1168 RVA: 0x0000BE5C File Offset: 0x0000A05C
			[XmlElement("IsLetMeChoseDisabled")]
			public bool IsLetMeChooseDisabled { get; set; }

			// Token: 0x170001E2 RID: 482
			// (get) Token: 0x06000491 RID: 1169 RVA: 0x0000BE65 File Offset: 0x0000A065
			// (set) Token: 0x06000492 RID: 1170 RVA: 0x0000BE6D File Offset: 0x0000A06D
			[XmlIgnore]
			public DefaultPolicy.CustomTransferPagePolicy.CustomTransferSelection Selection { get; set; }

			// Token: 0x170001E3 RID: 483
			// (get) Token: 0x06000493 RID: 1171 RVA: 0x0000BE78 File Offset: 0x0000A078
			// (set) Token: 0x06000494 RID: 1172 RVA: 0x0000BEA4 File Offset: 0x0000A0A4
			[XmlElement("Selection")]
			public string SelectionString
			{
				get
				{
					if (this.Selection == DefaultPolicy.CustomTransferPagePolicy.CustomTransferSelection.Unknown)
					{
						return null;
					}
					return this.Selection.ToString();
				}
				set
				{
					if (string.IsNullOrWhiteSpace(value))
					{
						this.Selection = DefaultPolicy.CustomTransferPagePolicy.CustomTransferSelection.Unknown;
						return;
					}
					try
					{
						this.Selection = (DefaultPolicy.CustomTransferPagePolicy.CustomTransferSelection)Enum.Parse(typeof(DefaultPolicy.CustomTransferPagePolicy.CustomTransferSelection), value);
					}
					catch (Exception)
					{
						this.Selection = DefaultPolicy.CustomTransferPagePolicy.CustomTransferSelection.Unknown;
					}
				}
			}

			// Token: 0x170001E4 RID: 484
			// (get) Token: 0x06000495 RID: 1173 RVA: 0x0000BEFC File Offset: 0x0000A0FC
			// (set) Token: 0x06000496 RID: 1174 RVA: 0x0000BF04 File Offset: 0x0000A104
			[XmlIgnore]
			public bool? IsTransferEverythingDisabled { get; set; }

			// Token: 0x170001E5 RID: 485
			// (get) Token: 0x06000497 RID: 1175 RVA: 0x0000BF10 File Offset: 0x0000A110
			// (set) Token: 0x06000498 RID: 1176 RVA: 0x0000BF44 File Offset: 0x0000A144
			[XmlElement("IsTransferEverythingDisabled")]
			public string IsTransferEverythingDisabledString
			{
				get
				{
					if (this.IsTransferEverythingDisabled == null)
					{
						return null;
					}
					return this.IsTransferEverythingDisabled.ToString();
				}
				set
				{
					this.IsTransferEverythingDisabled = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}

			// Token: 0x170001E6 RID: 486
			// (get) Token: 0x06000499 RID: 1177 RVA: 0x0000BF75 File Offset: 0x0000A175
			// (set) Token: 0x0600049A RID: 1178 RVA: 0x0000BF7D File Offset: 0x0000A17D
			[XmlIgnore]
			public bool? IsFilesAndSettingsDisabled { get; set; }

			// Token: 0x170001E7 RID: 487
			// (get) Token: 0x0600049B RID: 1179 RVA: 0x0000BF88 File Offset: 0x0000A188
			// (set) Token: 0x0600049C RID: 1180 RVA: 0x0000BFBC File Offset: 0x0000A1BC
			[XmlElement("IsFilesAndSettingsDisabled")]
			public string IsFilesAndSettingsDisabledString
			{
				get
				{
					if (this.IsFilesAndSettingsDisabled == null)
					{
						return null;
					}
					return this.IsFilesAndSettingsDisabled.ToString();
				}
				set
				{
					this.IsFilesAndSettingsDisabled = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}

			// Token: 0x170001E8 RID: 488
			// (get) Token: 0x0600049D RID: 1181 RVA: 0x0000BFED File Offset: 0x0000A1ED
			// (set) Token: 0x0600049E RID: 1182 RVA: 0x0000BFF5 File Offset: 0x0000A1F5
			[XmlIgnore]
			public bool? IsFilesOnlyDisabled { get; set; }

			// Token: 0x170001E9 RID: 489
			// (get) Token: 0x0600049F RID: 1183 RVA: 0x0000C000 File Offset: 0x0000A200
			// (set) Token: 0x060004A0 RID: 1184 RVA: 0x0000C034 File Offset: 0x0000A234
			[XmlElement("IsFilesOnlyDisabled")]
			public string IsFilesOnlyDisabledString
			{
				get
				{
					if (this.IsFilesOnlyDisabled == null)
					{
						return null;
					}
					return this.IsFilesOnlyDisabled.ToString();
				}
				set
				{
					this.IsFilesOnlyDisabled = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}

			// Token: 0x170001EA RID: 490
			// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0000C065 File Offset: 0x0000A265
			// (set) Token: 0x060004A2 RID: 1186 RVA: 0x0000C06D File Offset: 0x0000A26D
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x060004A3 RID: 1187 RVA: 0x0000C078 File Offset: 0x0000A278
			public void Upgrade(EnginePolicy enginePolicy)
			{
				if (this.Selection != DefaultPolicy.CustomTransferPagePolicy.CustomTransferSelection.Unknown)
				{
					switch (this.Selection)
					{
					case DefaultPolicy.CustomTransferPagePolicy.CustomTransferSelection.All:
						enginePolicy.MigItems.DefaultOption = new MigrationItemsOption?(MigrationItemsOption.All);
						break;
					case DefaultPolicy.CustomTransferPagePolicy.CustomTransferSelection.FilesAndSettings:
						enginePolicy.MigItems.DefaultOption = new MigrationItemsOption?(MigrationItemsOption.FilesAndSettings);
						break;
					case DefaultPolicy.CustomTransferPagePolicy.CustomTransferSelection.Files:
						enginePolicy.MigItems.DefaultOption = new MigrationItemsOption?(MigrationItemsOption.FilesOnly);
						break;
					case DefaultPolicy.CustomTransferPagePolicy.CustomTransferSelection.Custom:
						enginePolicy.MigItems.DefaultOption = new MigrationItemsOption?(MigrationItemsOption.All);
						break;
					}
					this.Selection = DefaultPolicy.CustomTransferPagePolicy.CustomTransferSelection.Unknown;
					int numUpgradedItems = this.NumUpgradedItems;
					this.NumUpgradedItems = numUpgradedItems + 1;
				}
				if (this.IsTransferEverythingDisabled != null)
				{
					enginePolicy.MigItems.All.Enable = !this.IsTransferEverythingDisabled.Value;
					this.IsTransferEverythingDisabled = null;
					int numUpgradedItems = this.NumUpgradedItems;
					this.NumUpgradedItems = numUpgradedItems + 1;
				}
				if (this.IsFilesAndSettingsDisabled != null)
				{
					enginePolicy.MigItems.FilesAndSettings.Enable = !this.IsFilesAndSettingsDisabled.Value;
					this.IsFilesAndSettingsDisabled = null;
					int numUpgradedItems = this.NumUpgradedItems;
					this.NumUpgradedItems = numUpgradedItems + 1;
				}
				if (this.IsFilesOnlyDisabled != null)
				{
					enginePolicy.MigItems.FilesOnly.Enable = !this.IsFilesOnlyDisabled.Value;
					this.IsFilesOnlyDisabled = null;
					int numUpgradedItems = this.NumUpgradedItems;
					this.NumUpgradedItems = numUpgradedItems + 1;
				}
			}

			// Token: 0x020000F8 RID: 248
			public enum CustomTransferSelection
			{
				// Token: 0x040002FE RID: 766
				Unknown,
				// Token: 0x040002FF RID: 767
				All,
				// Token: 0x04000300 RID: 768
				FilesAndSettings,
				// Token: 0x04000301 RID: 769
				Files,
				// Token: 0x04000302 RID: 770
				Custom
			}
		}

		// Token: 0x02000065 RID: 101
		public class TransferEverythingPagePolicy
		{
			// Token: 0x170001EB RID: 491
			// (get) Token: 0x060004A5 RID: 1189 RVA: 0x0000C202 File Offset: 0x0000A402
			// (set) Token: 0x060004A6 RID: 1190 RVA: 0x0000C20A File Offset: 0x0000A40A
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }

			// Token: 0x170001EC RID: 492
			// (get) Token: 0x060004A7 RID: 1191 RVA: 0x0000C213 File Offset: 0x0000A413
			// (set) Token: 0x060004A8 RID: 1192 RVA: 0x0000C21B File Offset: 0x0000A41B
			public bool HideViewDetails { get; set; }
		}

		// Token: 0x02000066 RID: 102
		public class TransferEverythingProgressPagePolicy
		{
			// Token: 0x170001ED RID: 493
			// (get) Token: 0x060004AA RID: 1194 RVA: 0x0000C224 File Offset: 0x0000A424
			// (set) Token: 0x060004AB RID: 1195 RVA: 0x0000C22C File Offset: 0x0000A42C
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }
		}

		// Token: 0x02000067 RID: 103
		public class TransferCompletePagePolicy : IUpgradeable
		{
			// Token: 0x170001EE RID: 494
			// (get) Token: 0x060004AD RID: 1197 RVA: 0x0000C235 File Offset: 0x0000A435
			// (set) Token: 0x060004AE RID: 1198 RVA: 0x0000C258 File Offset: 0x0000A458
			[XmlAttribute("IsPageDisplayed")]
			public string IsPageDisplayedString
			{
				get
				{
					if (this._isPageDisplayed == null)
					{
						return null;
					}
					return this._isPageDisplayed.ToString();
				}
				set
				{
					this._isPageDisplayed = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}

			// Token: 0x170001EF RID: 495
			// (get) Token: 0x060004AF RID: 1199 RVA: 0x0000C28C File Offset: 0x0000A48C
			// (set) Token: 0x060004B0 RID: 1200 RVA: 0x0000C2BB File Offset: 0x0000A4BB
			[XmlElement("Restart")]
			public string ObsRestart
			{
				get
				{
					if (this._restart == null)
					{
						return null;
					}
					return this._restart.Value.ToString();
				}
				set
				{
					this._restart = new bool?(bool.Parse(value));
				}
			}

			// Token: 0x170001F0 RID: 496
			// (get) Token: 0x060004B1 RID: 1201 RVA: 0x0000C2D0 File Offset: 0x0000A4D0
			// (set) Token: 0x060004B2 RID: 1202 RVA: 0x0000C2FF File Offset: 0x0000A4FF
			[XmlElement("Upload")]
			public string ObsUpload
			{
				get
				{
					if (this._upload == null)
					{
						return null;
					}
					return this._upload.Value.ToString();
				}
				set
				{
					this._upload = new bool?(bool.Parse(value));
				}
			}

			// Token: 0x170001F1 RID: 497
			// (get) Token: 0x060004B3 RID: 1203 RVA: 0x0000C312 File Offset: 0x0000A512
			// (set) Token: 0x060004B4 RID: 1204 RVA: 0x0000C31A File Offset: 0x0000A51A
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x060004B5 RID: 1205 RVA: 0x0000C324 File Offset: 0x0000A524
			public void Upgrade(EnginePolicy enginePolicy)
			{
				if (this._restart != null)
				{
					enginePolicy.DoneMigration.Reboot.Value = new bool?(this._restart.Value);
					this._restart = null;
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
				}
				if (this._upload != null)
				{
					enginePolicy.DoneMigration.UploadReport.Value = new bool?(this._upload.Value);
					this._upload = null;
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
				}
				if (this._isPageDisplayed != null)
				{
					enginePolicy.DoneMigration.Interactive = this._isPageDisplayed;
					this._isPageDisplayed = null;
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
				}
			}

			// Token: 0x040001E9 RID: 489
			private bool? _isPageDisplayed;

			// Token: 0x040001EA RID: 490
			private bool? _restart;

			// Token: 0x040001EB RID: 491
			private bool? _upload;
		}

		// Token: 0x02000068 RID: 104
		public class DownloadManagerPagePolicy
		{
			// Token: 0x170001F2 RID: 498
			// (get) Token: 0x060004B7 RID: 1207 RVA: 0x0000C3FD File Offset: 0x0000A5FD
			// (set) Token: 0x060004B8 RID: 1208 RVA: 0x0000C405 File Offset: 0x0000A605
			[XmlAttribute]
			public bool IsPageDisplayed { get; set; }
		}

		// Token: 0x02000069 RID: 105
		public class CustomUI
		{
			// Token: 0x170001F3 RID: 499
			// (get) Token: 0x060004BA RID: 1210 RVA: 0x0000C40E File Offset: 0x0000A60E
			// (set) Token: 0x060004BB RID: 1211 RVA: 0x0000C416 File Offset: 0x0000A616
			public string WelcomeText { get; set; }

			// Token: 0x170001F4 RID: 500
			// (get) Token: 0x060004BC RID: 1212 RVA: 0x0000C41F File Offset: 0x0000A61F
			// (set) Token: 0x060004BD RID: 1213 RVA: 0x0000C427 File Offset: 0x0000A627
			public string FTAImagePath { get; set; }

			// Token: 0x170001F5 RID: 501
			// (get) Token: 0x060004BE RID: 1214 RVA: 0x0000C430 File Offset: 0x0000A630
			// (set) Token: 0x060004BF RID: 1215 RVA: 0x0000C438 File Offset: 0x0000A638
			public string FTATopText { get; set; }

			// Token: 0x170001F6 RID: 502
			// (get) Token: 0x060004C0 RID: 1216 RVA: 0x0000C441 File Offset: 0x0000A641
			// (set) Token: 0x060004C1 RID: 1217 RVA: 0x0000C449 File Offset: 0x0000A649
			public string FTABottomText { get; set; }

			// Token: 0x170001F7 RID: 503
			// (get) Token: 0x060004C2 RID: 1218 RVA: 0x0000C452 File Offset: 0x0000A652
			// (set) Token: 0x060004C3 RID: 1219 RVA: 0x0000C45A File Offset: 0x0000A65A
			public string FTAURL { get; set; }

			// Token: 0x170001F8 RID: 504
			// (get) Token: 0x060004C4 RID: 1220 RVA: 0x0000C463 File Offset: 0x0000A663
			// (set) Token: 0x060004C5 RID: 1221 RVA: 0x0000C46B File Offset: 0x0000A66B
			public string FTADisplayURL { get; set; }

			// Token: 0x170001F9 RID: 505
			// (get) Token: 0x060004C6 RID: 1222 RVA: 0x0000C474 File Offset: 0x0000A674
			// (set) Token: 0x060004C7 RID: 1223 RVA: 0x0000C47C File Offset: 0x0000A67C
			public string UserGuideUrl { get; set; }
		}
	}
}
