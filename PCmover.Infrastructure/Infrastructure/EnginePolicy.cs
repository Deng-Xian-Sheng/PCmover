using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x02000017 RID: 23
	public class EnginePolicy
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00005343 File Offset: 0x00003543
		[XmlIgnore]
		public bool UseFips
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00005346 File Offset: 0x00003546
		// (set) Token: 0x06000135 RID: 309 RVA: 0x0000534E File Offset: 0x0000354E
		public EnginePolicy.ConnectionPolicy Connection { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00005357 File Offset: 0x00003557
		// (set) Token: 0x06000137 RID: 311 RVA: 0x0000535F File Offset: 0x0000355F
		public EnginePolicy.SettingsPolicy Settings { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00005368 File Offset: 0x00003568
		// (set) Token: 0x06000139 RID: 313 RVA: 0x00005370 File Offset: 0x00003570
		public EnginePolicy.ReportsPolicy Reports { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00005379 File Offset: 0x00003579
		// (set) Token: 0x0600013B RID: 315 RVA: 0x00005381 File Offset: 0x00003581
		public EnginePolicy.ConfigurationPolicy Configuration { get; set; }

		// Token: 0x0600013C RID: 316 RVA: 0x0000538A File Offset: 0x0000358A
		public bool ShouldSerializeConfiguration()
		{
			return this.Configuration.ShouldSerialize();
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00005397 File Offset: 0x00003597
		// (set) Token: 0x0600013E RID: 318 RVA: 0x0000539F File Offset: 0x0000359F
		public ObservableCollection<DefaultPolicy.Run> AutoRun { get; set; }

		// Token: 0x0600013F RID: 319 RVA: 0x000053A8 File Offset: 0x000035A8
		public bool ShouldSerializeAutoRun()
		{
			return this.AutoRun.Any<DefaultPolicy.Run>();
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000140 RID: 320 RVA: 0x000053B5 File Offset: 0x000035B5
		// (set) Token: 0x06000141 RID: 321 RVA: 0x000053BD File Offset: 0x000035BD
		public EnginePolicy.ApplicationsPolicy AppSel { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000142 RID: 322 RVA: 0x000053C6 File Offset: 0x000035C6
		// (set) Token: 0x06000143 RID: 323 RVA: 0x000053CE File Offset: 0x000035CE
		public EnginePolicy.DriveMapping DriveMap { get; set; }

		// Token: 0x06000144 RID: 324 RVA: 0x000053D7 File Offset: 0x000035D7
		public bool ShouldSerializeDriveMap()
		{
			return this.DriveMap.ShouldSerialize();
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000145 RID: 325 RVA: 0x000053E4 File Offset: 0x000035E4
		// (set) Token: 0x06000146 RID: 326 RVA: 0x000053EC File Offset: 0x000035EC
		public EnginePolicy.FileFilterPolicy FileFilter { get; set; }

		// Token: 0x06000147 RID: 327 RVA: 0x000053F5 File Offset: 0x000035F5
		public bool ShouldSerializeFileFilter()
		{
			return this.FileFilter.ShouldSerialize();
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000148 RID: 328 RVA: 0x00005402 File Offset: 0x00003602
		// (set) Token: 0x06000149 RID: 329 RVA: 0x0000540A File Offset: 0x0000360A
		public EnginePolicy.DirFilterPolicy DirFilter { get; set; }

		// Token: 0x0600014A RID: 330 RVA: 0x00005413 File Offset: 0x00003613
		public bool ShouldSerializeDirFilter()
		{
			return this.DirFilter.ShouldSerialize();
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600014B RID: 331 RVA: 0x00005420 File Offset: 0x00003620
		// (set) Token: 0x0600014C RID: 332 RVA: 0x00005428 File Offset: 0x00003628
		public EnginePolicy.UserMapping UserMap { get; set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600014D RID: 333 RVA: 0x00005431 File Offset: 0x00003631
		// (set) Token: 0x0600014E RID: 334 RVA: 0x00005439 File Offset: 0x00003639
		public EnginePolicy.RegistrationPolicy Registration { get; set; }

		// Token: 0x0600014F RID: 335 RVA: 0x00005442 File Offset: 0x00003642
		public bool ShouldSerializeRegistration()
		{
			return this.Registration.ShouldSerialize();
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000150 RID: 336 RVA: 0x0000544F File Offset: 0x0000364F
		// (set) Token: 0x06000151 RID: 337 RVA: 0x00005457 File Offset: 0x00003657
		public EnginePolicy.AlertsPolicy Alerts { get; set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000152 RID: 338 RVA: 0x00005460 File Offset: 0x00003660
		// (set) Token: 0x06000153 RID: 339 RVA: 0x00005468 File Offset: 0x00003668
		public EnginePolicy.MigmodPolicy MigMod { get; set; }

		// Token: 0x06000154 RID: 340 RVA: 0x00005471 File Offset: 0x00003671
		public bool ShouldSerializeMigMod()
		{
			return this.MigMod.ShouldSerialize();
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000155 RID: 341 RVA: 0x0000547E File Offset: 0x0000367E
		// (set) Token: 0x06000156 RID: 342 RVA: 0x00005486 File Offset: 0x00003686
		public EnginePolicy.MigTypePolicy MigType { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000157 RID: 343 RVA: 0x0000548F File Offset: 0x0000368F
		// (set) Token: 0x06000158 RID: 344 RVA: 0x00005497 File Offset: 0x00003697
		public EnginePolicy.DoneMigrationPolicy DoneMigration { get; set; }

		// Token: 0x06000159 RID: 345 RVA: 0x000054A0 File Offset: 0x000036A0
		public bool ShouldSerializeDoneMigration()
		{
			return this.DoneMigration.ShouldSerialize();
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600015A RID: 346 RVA: 0x000054AD File Offset: 0x000036AD
		// (set) Token: 0x0600015B RID: 347 RVA: 0x000054B5 File Offset: 0x000036B5
		public EnginePolicy.MigItemsPolicy MigItems { get; set; }

		// Token: 0x0600015C RID: 348 RVA: 0x000054C0 File Offset: 0x000036C0
		public EnginePolicy()
		{
			this.Connection = new EnginePolicy.ConnectionPolicy();
			this.Settings = new EnginePolicy.SettingsPolicy
			{
				DisplayWarningPage = new bool?(true)
			};
			this.Reports = new EnginePolicy.ReportsPolicy();
			this.Configuration = new EnginePolicy.ConfigurationPolicy();
			this.AutoRun = new ObservableCollection<DefaultPolicy.Run>();
			this.AppSel = new EnginePolicy.ApplicationsPolicy
			{
				Interactive = new bool?(true)
			};
			this.DriveMap = new EnginePolicy.DriveMapping();
			this.FileFilter = new EnginePolicy.FileFilterPolicy();
			this.DirFilter = new EnginePolicy.DirFilterPolicy();
			this.UserMap = new EnginePolicy.UserMapping
			{
				Interactive = new bool?(true)
			};
			this.Registration = new EnginePolicy.RegistrationPolicy();
			this.Alerts = new EnginePolicy.AlertsPolicy();
			this.MigMod = new EnginePolicy.MigmodPolicy();
			this.MigType = new EnginePolicy.MigTypePolicy();
			this.DoneMigration = new EnginePolicy.DoneMigrationPolicy
			{
				Interactive = new bool?(true)
			};
			this.MigItems = new EnginePolicy.MigItemsPolicy();
		}

		// Token: 0x02000091 RID: 145
		public class EncryptedValue
		{
			// Token: 0x170001FD RID: 509
			// (get) Token: 0x06000509 RID: 1289 RVA: 0x0000D2ED File Offset: 0x0000B4ED
			// (set) Token: 0x0600050A RID: 1290 RVA: 0x0000D2F5 File Offset: 0x0000B4F5
			[XmlAttribute]
			public bool fips { get; set; }

			// Token: 0x0600050B RID: 1291 RVA: 0x0000D2FE File Offset: 0x0000B4FE
			public bool ShouldSerializefips()
			{
				return !string.IsNullOrEmpty(this.Value);
			}

			// Token: 0x170001FE RID: 510
			// (get) Token: 0x0600050C RID: 1292 RVA: 0x0000D30E File Offset: 0x0000B50E
			// (set) Token: 0x0600050D RID: 1293 RVA: 0x0000D316 File Offset: 0x0000B516
			[XmlText]
			public string Value { get; set; }

			// Token: 0x0600050E RID: 1294 RVA: 0x0000D2FE File Offset: 0x0000B4FE
			public bool ShouldSerialize()
			{
				return !string.IsNullOrEmpty(this.Value);
			}
		}

		// Token: 0x02000092 RID: 146
		public class EnableItem
		{
			// Token: 0x170001FF RID: 511
			// (get) Token: 0x06000510 RID: 1296 RVA: 0x0000D31F File Offset: 0x0000B51F
			// (set) Token: 0x06000511 RID: 1297 RVA: 0x0000D327 File Offset: 0x0000B527
			[XmlAttribute]
			public bool Enable { get; set; } = true;
		}

		// Token: 0x02000093 RID: 147
		public class ModifyItem
		{
			// Token: 0x17000200 RID: 512
			// (get) Token: 0x06000513 RID: 1299 RVA: 0x0000D33F File Offset: 0x0000B53F
			// (set) Token: 0x06000514 RID: 1300 RVA: 0x0000D347 File Offset: 0x0000B547
			[XmlIgnore]
			public bool? Modify { get; set; }

			// Token: 0x17000201 RID: 513
			// (get) Token: 0x06000515 RID: 1301 RVA: 0x0000D350 File Offset: 0x0000B550
			// (set) Token: 0x06000516 RID: 1302 RVA: 0x0000D384 File Offset: 0x0000B584
			[XmlAttribute("Modify")]
			public string ModifyString
			{
				get
				{
					if (this.Modify == null)
					{
						return null;
					}
					return this.Modify.ToString();
				}
				set
				{
					this.Modify = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}
		}

		// Token: 0x02000094 RID: 148
		public class InteractiveItem
		{
			// Token: 0x17000202 RID: 514
			// (get) Token: 0x06000518 RID: 1304 RVA: 0x0000D3B5 File Offset: 0x0000B5B5
			// (set) Token: 0x06000519 RID: 1305 RVA: 0x0000D3BD File Offset: 0x0000B5BD
			[XmlIgnore]
			public bool? Interactive { get; set; } = new bool?(true);

			// Token: 0x17000203 RID: 515
			// (get) Token: 0x0600051A RID: 1306 RVA: 0x0000D3C8 File Offset: 0x0000B5C8
			// (set) Token: 0x0600051B RID: 1307 RVA: 0x0000D3FC File Offset: 0x0000B5FC
			[XmlAttribute("Interactive")]
			public string InteractiveString
			{
				get
				{
					if (this.Interactive == null)
					{
						return null;
					}
					return this.Interactive.ToString();
				}
				set
				{
					this.Interactive = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}
		}

		// Token: 0x02000095 RID: 149
		public class NullableBoolTextModifyItem : EnginePolicy.ModifyItem
		{
			// Token: 0x17000204 RID: 516
			// (get) Token: 0x0600051D RID: 1309 RVA: 0x0000D441 File Offset: 0x0000B641
			// (set) Token: 0x0600051E RID: 1310 RVA: 0x0000D449 File Offset: 0x0000B649
			[XmlIgnore]
			public bool? Value { get; set; }

			// Token: 0x17000205 RID: 517
			// (get) Token: 0x0600051F RID: 1311 RVA: 0x0000D454 File Offset: 0x0000B654
			// (set) Token: 0x06000520 RID: 1312 RVA: 0x0000D488 File Offset: 0x0000B688
			[XmlText]
			public string ValueString
			{
				get
				{
					if (this.Value == null)
					{
						return null;
					}
					return this.Value.ToString();
				}
				set
				{
					this.Value = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}
		}

		// Token: 0x02000096 RID: 150
		public class MigrateModifyItem : EnginePolicy.ModifyItem
		{
			// Token: 0x17000206 RID: 518
			// (get) Token: 0x06000522 RID: 1314 RVA: 0x0000D4C1 File Offset: 0x0000B6C1
			// (set) Token: 0x06000523 RID: 1315 RVA: 0x0000D4C9 File Offset: 0x0000B6C9
			[XmlIgnore]
			public bool? Migrate { get; set; }

			// Token: 0x17000207 RID: 519
			// (get) Token: 0x06000524 RID: 1316 RVA: 0x0000D4D4 File Offset: 0x0000B6D4
			// (set) Token: 0x06000525 RID: 1317 RVA: 0x0000D508 File Offset: 0x0000B708
			[XmlAttribute("Migrate")]
			public string MigrateString
			{
				get
				{
					if (this.Migrate == null)
					{
						return null;
					}
					return this.Migrate.ToString();
				}
				set
				{
					this.Migrate = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}
		}

		// Token: 0x02000097 RID: 151
		public class SelectedModifyItem : EnginePolicy.ModifyItem
		{
			// Token: 0x17000208 RID: 520
			// (get) Token: 0x06000527 RID: 1319 RVA: 0x0000D539 File Offset: 0x0000B739
			// (set) Token: 0x06000528 RID: 1320 RVA: 0x0000D541 File Offset: 0x0000B741
			[XmlIgnore]
			public bool? Selected { get; set; }

			// Token: 0x17000209 RID: 521
			// (get) Token: 0x06000529 RID: 1321 RVA: 0x0000D54C File Offset: 0x0000B74C
			// (set) Token: 0x0600052A RID: 1322 RVA: 0x0000D580 File Offset: 0x0000B780
			[XmlAttribute("Selected")]
			public string SelectedString
			{
				get
				{
					if (this.Selected == null)
					{
						return null;
					}
					return this.Selected.ToString();
				}
				set
				{
					this.Selected = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}
		}

		// Token: 0x02000098 RID: 152
		public class ConnectionPolicy
		{
			// Token: 0x1700020A RID: 522
			// (get) Token: 0x0600052C RID: 1324 RVA: 0x0000D5B1 File Offset: 0x0000B7B1
			// (set) Token: 0x0600052D RID: 1325 RVA: 0x0000D5B9 File Offset: 0x0000B7B9
			public EnginePolicy.ConnectionPolicy.NetworkConnection Network { get; set; }

			// Token: 0x1700020B RID: 523
			// (get) Token: 0x0600052E RID: 1326 RVA: 0x0000D5C2 File Offset: 0x0000B7C2
			// (set) Token: 0x0600052F RID: 1327 RVA: 0x0000D5CA File Offset: 0x0000B7CA
			public EnginePolicy.EnableItem Crossover { get; set; }

			// Token: 0x1700020C RID: 524
			// (get) Token: 0x06000530 RID: 1328 RVA: 0x0000D5D3 File Offset: 0x0000B7D3
			// (set) Token: 0x06000531 RID: 1329 RVA: 0x0000D5DB File Offset: 0x0000B7DB
			public EnginePolicy.ConnectionPolicy.FilesBased File { get; set; }

			// Token: 0x1700020D RID: 525
			// (get) Token: 0x06000532 RID: 1330 RVA: 0x0000D5E4 File Offset: 0x0000B7E4
			// (set) Token: 0x06000533 RID: 1331 RVA: 0x0000D5EC File Offset: 0x0000B7EC
			public EnginePolicy.EnableItem USB { get; set; }

			// Token: 0x1700020E RID: 526
			// (get) Token: 0x06000534 RID: 1332 RVA: 0x0000D5F5 File Offset: 0x0000B7F5
			// (set) Token: 0x06000535 RID: 1333 RVA: 0x0000D5FD File Offset: 0x0000B7FD
			public EnginePolicy.ConnectionPolicy.EMA EMASettings { get; set; }

			// Token: 0x06000536 RID: 1334 RVA: 0x0000D606 File Offset: 0x0000B806
			public bool ShouldSerializeEMASettings()
			{
				return this.EMASettings.ShouldSerialize();
			}

			// Token: 0x1700020F RID: 527
			// (get) Token: 0x06000537 RID: 1335 RVA: 0x0000D613 File Offset: 0x0000B813
			// (set) Token: 0x06000538 RID: 1336 RVA: 0x0000D61B File Offset: 0x0000B81B
			public EnginePolicy.EnableItem Image { get; set; }

			// Token: 0x17000210 RID: 528
			// (get) Token: 0x06000539 RID: 1337 RVA: 0x0000D624 File Offset: 0x0000B824
			// (set) Token: 0x0600053A RID: 1338 RVA: 0x0000D62C File Offset: 0x0000B82C
			public EnginePolicy.EnableItem Self { get; set; }

			// Token: 0x0600053B RID: 1339 RVA: 0x0000D638 File Offset: 0x0000B838
			public ConnectionPolicy()
			{
				this.Network = new EnginePolicy.ConnectionPolicy.NetworkConnection();
				this.Crossover = new EnginePolicy.EnableItem();
				this.File = new EnginePolicy.ConnectionPolicy.FilesBased();
				this.USB = new EnginePolicy.EnableItem();
				this.EMASettings = new EnginePolicy.ConnectionPolicy.EMA();
				this.Image = new EnginePolicy.EnableItem();
				this.Self = new EnginePolicy.EnableItem();
			}

			// Token: 0x020000FD RID: 253
			public class NetworkTargetItem
			{
				// Token: 0x0600070F RID: 1807 RVA: 0x000021D2 File Offset: 0x000003D2
				public NetworkTargetItem()
				{
				}

				// Token: 0x06000710 RID: 1808 RVA: 0x0000F18E File Offset: 0x0000D38E
				public NetworkTargetItem(string target)
				{
					this.Target = target;
				}

				// Token: 0x170002AF RID: 687
				// (get) Token: 0x06000711 RID: 1809 RVA: 0x0000F19D File Offset: 0x0000D39D
				// (set) Token: 0x06000712 RID: 1810 RVA: 0x0000F1A5 File Offset: 0x0000D3A5
				[XmlAttribute]
				public string New { get; set; }

				// Token: 0x170002B0 RID: 688
				// (get) Token: 0x06000713 RID: 1811 RVA: 0x0000F1AE File Offset: 0x0000D3AE
				// (set) Token: 0x06000714 RID: 1812 RVA: 0x0000F1B6 File Offset: 0x0000D3B6
				[XmlText]
				public string Target { get; set; }
			}

			// Token: 0x020000FE RID: 254
			public class NetworkConnection : EnginePolicy.EnableItem
			{
				// Token: 0x06000715 RID: 1813 RVA: 0x0000F1C0 File Offset: 0x0000D3C0
				public NetworkConnection()
				{
					this.Settings = new EnginePolicy.ConnectionPolicy.NetworkSettings
					{
						UdpDiscoveryPort = 29717,
						TcpConnectPort = 29717,
						UdpConnectPort = 12345,
						SSLConnectPort = 29718,
						SSLFlags = SSLFlags.EnforceTimeValidity,
						EnableWiFi = true
					};
					this.CustomerCA = new EnginePolicy.ConnectionPolicy.CertSettings();
					this.Targets = new List<EnginePolicy.ConnectionPolicy.NetworkTargetItem>();
				}

				// Token: 0x170002B1 RID: 689
				// (get) Token: 0x06000716 RID: 1814 RVA: 0x0000F22E File Offset: 0x0000D42E
				// (set) Token: 0x06000717 RID: 1815 RVA: 0x0000F236 File Offset: 0x0000D436
				[XmlElement("Target")]
				public List<EnginePolicy.ConnectionPolicy.NetworkTargetItem> Targets { get; set; }

				// Token: 0x06000718 RID: 1816 RVA: 0x0000F240 File Offset: 0x0000D440
				public void SetDefaultTarget(string targetName)
				{
					foreach (EnginePolicy.ConnectionPolicy.NetworkTargetItem item in (from t in this.Targets
					where string.IsNullOrWhiteSpace(t.New)
					select t).ToList<EnginePolicy.ConnectionPolicy.NetworkTargetItem>())
					{
						this.Targets.Remove(item);
					}
					if (!string.IsNullOrWhiteSpace(targetName))
					{
						this.Targets.Add(new EnginePolicy.ConnectionPolicy.NetworkTargetItem(targetName));
					}
				}

				// Token: 0x170002B2 RID: 690
				// (get) Token: 0x06000719 RID: 1817 RVA: 0x0000F2DC File Offset: 0x0000D4DC
				// (set) Token: 0x0600071A RID: 1818 RVA: 0x0000F2E4 File Offset: 0x0000D4E4
				[XmlIgnore]
				public bool? IsOld { get; set; }

				// Token: 0x170002B3 RID: 691
				// (get) Token: 0x0600071B RID: 1819 RVA: 0x0000F2F0 File Offset: 0x0000D4F0
				// (set) Token: 0x0600071C RID: 1820 RVA: 0x0000F324 File Offset: 0x0000D524
				[XmlElement("IsOld")]
				public string IsOldString
				{
					get
					{
						if (this.IsOld == null)
						{
							return null;
						}
						return this.IsOld.ToString();
					}
					set
					{
						this.IsOld = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
					}
				}

				// Token: 0x170002B4 RID: 692
				// (get) Token: 0x0600071D RID: 1821 RVA: 0x0000F355 File Offset: 0x0000D555
				// (set) Token: 0x0600071E RID: 1822 RVA: 0x0000F35D File Offset: 0x0000D55D
				public EnginePolicy.ConnectionPolicy.NetworkSettings Settings { get; set; }

				// Token: 0x170002B5 RID: 693
				// (get) Token: 0x0600071F RID: 1823 RVA: 0x0000F366 File Offset: 0x0000D566
				// (set) Token: 0x06000720 RID: 1824 RVA: 0x0000F36E File Offset: 0x0000D56E
				[XmlElement]
				public EnginePolicy.ConnectionPolicy.CertSettings CustomerCA { get; set; }

				// Token: 0x06000721 RID: 1825 RVA: 0x0000F377 File Offset: 0x0000D577
				public bool ShouldSerializeCustomerCA()
				{
					return this.CustomerCA.ShouldSerialize();
				}
			}

			// Token: 0x020000FF RID: 255
			public class VanItem : EnginePolicy.ModifyItem
			{
				// Token: 0x06000722 RID: 1826 RVA: 0x0000D4B9 File Offset: 0x0000B6B9
				public VanItem()
				{
				}

				// Token: 0x06000723 RID: 1827 RVA: 0x0000F384 File Offset: 0x0000D584
				public VanItem(string fileName)
				{
					this.File = fileName;
				}

				// Token: 0x170002B6 RID: 694
				// (get) Token: 0x06000724 RID: 1828 RVA: 0x0000F393 File Offset: 0x0000D593
				// (set) Token: 0x06000725 RID: 1829 RVA: 0x0000F39B File Offset: 0x0000D59B
				[XmlIgnore]
				public bool? ModifyIfAbsent { get; set; }

				// Token: 0x170002B7 RID: 695
				// (get) Token: 0x06000726 RID: 1830 RVA: 0x0000F3A4 File Offset: 0x0000D5A4
				// (set) Token: 0x06000727 RID: 1831 RVA: 0x0000F3D8 File Offset: 0x0000D5D8
				[XmlAttribute("ModifyIfAbsent")]
				public string ModifyIfAbsentString
				{
					get
					{
						if (this.ModifyIfAbsent == null)
						{
							return null;
						}
						return this.ModifyIfAbsent.ToString();
					}
					set
					{
						this.ModifyIfAbsent = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
					}
				}

				// Token: 0x170002B8 RID: 696
				// (get) Token: 0x06000728 RID: 1832 RVA: 0x0000F409 File Offset: 0x0000D609
				// (set) Token: 0x06000729 RID: 1833 RVA: 0x0000F411 File Offset: 0x0000D611
				[XmlAttribute]
				public string Source { get; set; }

				// Token: 0x170002B9 RID: 697
				// (get) Token: 0x0600072A RID: 1834 RVA: 0x0000F41A File Offset: 0x0000D61A
				// (set) Token: 0x0600072B RID: 1835 RVA: 0x0000F422 File Offset: 0x0000D622
				[XmlAttribute]
				public string Target { get; set; }

				// Token: 0x170002BA RID: 698
				// (get) Token: 0x0600072C RID: 1836 RVA: 0x0000F42B File Offset: 0x0000D62B
				// (set) Token: 0x0600072D RID: 1837 RVA: 0x0000F433 File Offset: 0x0000D633
				[XmlText]
				public string File { get; set; }
			}

			// Token: 0x02000100 RID: 256
			public class FilesBased : EnginePolicy.EnableItem
			{
				// Token: 0x0600072E RID: 1838 RVA: 0x0000F43C File Offset: 0x0000D63C
				public FilesBased()
				{
					this.Settings = new EnginePolicy.ConnectionPolicy.FilesBased.FileSettings();
					this.VanPassword = new EnginePolicy.ConnectionPolicy.FilesBased.FileVanPassword();
					this.AWSSettings = new EnginePolicy.ConnectionPolicy.FilesBased.FileAWSSettings();
					this.AzureSettings = new EnginePolicy.ConnectionPolicy.FilesBased.FileAzureSettings();
					this.GCSSettings = new EnginePolicy.ConnectionPolicy.FilesBased.FileGCSSettings();
				}

				// Token: 0x170002BB RID: 699
				// (get) Token: 0x0600072F RID: 1839 RVA: 0x0000F491 File Offset: 0x0000D691
				// (set) Token: 0x06000730 RID: 1840 RVA: 0x0000F499 File Offset: 0x0000D699
				public EnginePolicy.ConnectionPolicy.FilesBased.FileSettings Settings { get; set; }

				// Token: 0x170002BC RID: 700
				// (get) Token: 0x06000731 RID: 1841 RVA: 0x0000F4A2 File Offset: 0x0000D6A2
				// (set) Token: 0x06000732 RID: 1842 RVA: 0x0000F4AA File Offset: 0x0000D6AA
				public EnginePolicy.ConnectionPolicy.FilesBased.FileVanPassword VanPassword { get; set; }

				// Token: 0x170002BD RID: 701
				// (get) Token: 0x06000733 RID: 1843 RVA: 0x0000F4B3 File Offset: 0x0000D6B3
				// (set) Token: 0x06000734 RID: 1844 RVA: 0x0000F4BB File Offset: 0x0000D6BB
				public EnginePolicy.ConnectionPolicy.FilesBased.FileAWSSettings AWSSettings { get; set; }

				// Token: 0x170002BE RID: 702
				// (get) Token: 0x06000735 RID: 1845 RVA: 0x0000F4C4 File Offset: 0x0000D6C4
				// (set) Token: 0x06000736 RID: 1846 RVA: 0x0000F4CC File Offset: 0x0000D6CC
				public EnginePolicy.ConnectionPolicy.FilesBased.FileAzureSettings AzureSettings { get; set; }

				// Token: 0x170002BF RID: 703
				// (get) Token: 0x06000737 RID: 1847 RVA: 0x0000F4D5 File Offset: 0x0000D6D5
				// (set) Token: 0x06000738 RID: 1848 RVA: 0x0000F4DD File Offset: 0x0000D6DD
				public EnginePolicy.ConnectionPolicy.FilesBased.FileGCSSettings GCSSettings { get; set; }

				// Token: 0x170002C0 RID: 704
				// (get) Token: 0x06000739 RID: 1849 RVA: 0x0000F4E6 File Offset: 0x0000D6E6
				// (set) Token: 0x0600073A RID: 1850 RVA: 0x0000F4EE File Offset: 0x0000D6EE
				[XmlElement("Van")]
				public List<EnginePolicy.ConnectionPolicy.VanItem> Vans { get; set; } = new List<EnginePolicy.ConnectionPolicy.VanItem>();

				// Token: 0x0600073B RID: 1851 RVA: 0x0000F4F8 File Offset: 0x0000D6F8
				public void SetDefaultVan(string vanName)
				{
					this.Vans.RemoveAll((EnginePolicy.ConnectionPolicy.VanItem v) => string.IsNullOrWhiteSpace(v.Source) && string.IsNullOrWhiteSpace(v.Target));
					if (!string.IsNullOrWhiteSpace(vanName))
					{
						this.Vans.Add(new EnginePolicy.ConnectionPolicy.VanItem(vanName));
					}
				}

				// Token: 0x02000105 RID: 261
				public class FileSettings : IUpgradeToUiPolicy
				{
					// Token: 0x170002CD RID: 717
					// (get) Token: 0x0600075C RID: 1884 RVA: 0x0000F660 File Offset: 0x0000D860
					// (set) Token: 0x0600075D RID: 1885 RVA: 0x0000F668 File Offset: 0x0000D868
					[XmlAttribute]
					public bool Span { get; set; }

					// Token: 0x170002CE RID: 718
					// (get) Token: 0x0600075E RID: 1886 RVA: 0x0000F671 File Offset: 0x0000D871
					// (set) Token: 0x0600075F RID: 1887 RVA: 0x0000F679 File Offset: 0x0000D879
					[XmlAttribute]
					public string SpanSize { get; set; }

					// Token: 0x170002CF RID: 719
					// (get) Token: 0x06000760 RID: 1888 RVA: 0x0000F682 File Offset: 0x0000D882
					// (set) Token: 0x06000761 RID: 1889 RVA: 0x0000F68A File Offset: 0x0000D88A
					[XmlAttribute]
					public bool SpanNotify { get; set; }

					// Token: 0x170002D0 RID: 720
					// (get) Token: 0x06000762 RID: 1890 RVA: 0x0000F693 File Offset: 0x0000D893
					// (set) Token: 0x06000763 RID: 1891 RVA: 0x0000F69B File Offset: 0x0000D89B
					[XmlAttribute]
					public bool Encrypt { get; set; }

					// Token: 0x170002D1 RID: 721
					// (get) Token: 0x06000764 RID: 1892 RVA: 0x0000F6A4 File Offset: 0x0000D8A4
					// (set) Token: 0x06000765 RID: 1893 RVA: 0x0000F6AC File Offset: 0x0000D8AC
					[XmlAttribute]
					public bool CertificateBased { get; set; }

					// Token: 0x170002D2 RID: 722
					// (get) Token: 0x06000766 RID: 1894 RVA: 0x0000F6B5 File Offset: 0x0000D8B5
					// (set) Token: 0x06000767 RID: 1895 RVA: 0x0000F6BD File Offset: 0x0000D8BD
					[XmlAttribute]
					public string CloudBased { get; set; }

					// Token: 0x170002D3 RID: 723
					// (get) Token: 0x06000768 RID: 1896 RVA: 0x0000F6C6 File Offset: 0x0000D8C6
					// (set) Token: 0x06000769 RID: 1897 RVA: 0x0000F6CE File Offset: 0x0000D8CE
					[XmlIgnore]
					public bool? ShowDelete { get; set; }

					// Token: 0x170002D4 RID: 724
					// (get) Token: 0x0600076A RID: 1898 RVA: 0x0000F6D8 File Offset: 0x0000D8D8
					// (set) Token: 0x0600076B RID: 1899 RVA: 0x0000F70C File Offset: 0x0000D90C
					[XmlAttribute("ShowDelete")]
					public string ShowDeleteString
					{
						get
						{
							if (this.ShowDelete == null)
							{
								return null;
							}
							return this.ShowDelete.ToString();
						}
						set
						{
							this.ShowDelete = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
						}
					}

					// Token: 0x170002D5 RID: 725
					// (get) Token: 0x0600076C RID: 1900 RVA: 0x0000F73D File Offset: 0x0000D93D
					// (set) Token: 0x0600076D RID: 1901 RVA: 0x0000F745 File Offset: 0x0000D945
					[XmlIgnore]
					public bool? IsOld { get; set; }

					// Token: 0x170002D6 RID: 726
					// (get) Token: 0x0600076E RID: 1902 RVA: 0x0000F750 File Offset: 0x0000D950
					// (set) Token: 0x0600076F RID: 1903 RVA: 0x0000F784 File Offset: 0x0000D984
					[XmlAttribute("IsOld")]
					public string IsOldString
					{
						get
						{
							if (this.IsOld == null)
							{
								return null;
							}
							return this.IsOld.ToString();
						}
						set
						{
							this.IsOld = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
						}
					}

					// Token: 0x170002D7 RID: 727
					// (get) Token: 0x06000770 RID: 1904 RVA: 0x0000F7B5 File Offset: 0x0000D9B5
					// (set) Token: 0x06000771 RID: 1905 RVA: 0x0000F7BD File Offset: 0x0000D9BD
					[XmlIgnore]
					public int NumUpgradedItems { get; set; }

					// Token: 0x06000772 RID: 1906 RVA: 0x0000F7C8 File Offset: 0x0000D9C8
					public void Upgrade(DefaultPolicy policy)
					{
						if (this.ShowDelete != null)
						{
							policy.ShowDelete = this.ShowDelete.Value;
							this.ShowDelete = null;
							int numUpgradedItems = this.NumUpgradedItems;
							this.NumUpgradedItems = numUpgradedItems + 1;
						}
					}
				}

				// Token: 0x02000106 RID: 262
				public class FileVanPassword : EnginePolicy.EncryptedValue
				{
					// Token: 0x170002D8 RID: 728
					// (get) Token: 0x06000774 RID: 1908 RVA: 0x0000F818 File Offset: 0x0000DA18
					// (set) Token: 0x06000775 RID: 1909 RVA: 0x0000F820 File Offset: 0x0000DA20
					[XmlAttribute]
					public bool Modify { get; set; }

					// Token: 0x06000776 RID: 1910 RVA: 0x0000F829 File Offset: 0x0000DA29
					public bool ShouldSerializeModify()
					{
						return base.ShouldSerialize();
					}

					// Token: 0x170002D9 RID: 729
					// (get) Token: 0x06000777 RID: 1911 RVA: 0x0000F831 File Offset: 0x0000DA31
					// (set) Token: 0x06000778 RID: 1912 RVA: 0x0000F839 File Offset: 0x0000DA39
					[XmlAttribute]
					public bool Required { get; set; }
				}

				// Token: 0x02000107 RID: 263
				public class FileAWSSettings
				{
					// Token: 0x0600077A RID: 1914 RVA: 0x0000F842 File Offset: 0x0000DA42
					public FileAWSSettings()
					{
						this.Secret = new EnginePolicy.EncryptedValue();
					}

					// Token: 0x170002DA RID: 730
					// (get) Token: 0x0600077B RID: 1915 RVA: 0x0000F855 File Offset: 0x0000DA55
					// (set) Token: 0x0600077C RID: 1916 RVA: 0x0000F85D File Offset: 0x0000DA5D
					[XmlAttribute]
					public string Authentication { get; set; }

					// Token: 0x170002DB RID: 731
					// (get) Token: 0x0600077D RID: 1917 RVA: 0x0000F866 File Offset: 0x0000DA66
					// (set) Token: 0x0600077E RID: 1918 RVA: 0x0000F86E File Offset: 0x0000DA6E
					[XmlElement]
					public string Account { get; set; }

					// Token: 0x170002DC RID: 732
					// (get) Token: 0x0600077F RID: 1919 RVA: 0x0000F877 File Offset: 0x0000DA77
					// (set) Token: 0x06000780 RID: 1920 RVA: 0x0000F87F File Offset: 0x0000DA7F
					[XmlElement]
					public string Region { get; set; }

					// Token: 0x170002DD RID: 733
					// (get) Token: 0x06000781 RID: 1921 RVA: 0x0000F888 File Offset: 0x0000DA88
					// (set) Token: 0x06000782 RID: 1922 RVA: 0x0000F890 File Offset: 0x0000DA90
					[XmlElement]
					public string Bucket { get; set; }

					// Token: 0x170002DE RID: 734
					// (get) Token: 0x06000783 RID: 1923 RVA: 0x0000F899 File Offset: 0x0000DA99
					// (set) Token: 0x06000784 RID: 1924 RVA: 0x0000F8A1 File Offset: 0x0000DAA1
					[XmlElement]
					public string KeyPrefix { get; set; }

					// Token: 0x170002DF RID: 735
					// (get) Token: 0x06000785 RID: 1925 RVA: 0x0000F8AA File Offset: 0x0000DAAA
					// (set) Token: 0x06000786 RID: 1926 RVA: 0x0000F8B2 File Offset: 0x0000DAB2
					[XmlElement]
					public string ClientId { get; set; }

					// Token: 0x170002E0 RID: 736
					// (get) Token: 0x06000787 RID: 1927 RVA: 0x0000F8BB File Offset: 0x0000DABB
					// (set) Token: 0x06000788 RID: 1928 RVA: 0x0000F8C3 File Offset: 0x0000DAC3
					[XmlElement]
					public string UserPoolId { get; set; }

					// Token: 0x170002E1 RID: 737
					// (get) Token: 0x06000789 RID: 1929 RVA: 0x0000F8CC File Offset: 0x0000DACC
					// (set) Token: 0x0600078A RID: 1930 RVA: 0x0000F8D4 File Offset: 0x0000DAD4
					[XmlElement]
					public string IdentityPoolId { get; set; }

					// Token: 0x170002E2 RID: 738
					// (get) Token: 0x0600078B RID: 1931 RVA: 0x0000F8DD File Offset: 0x0000DADD
					// (set) Token: 0x0600078C RID: 1932 RVA: 0x0000F8E5 File Offset: 0x0000DAE5
					[XmlElement]
					public string Domain { get; set; }

					// Token: 0x170002E3 RID: 739
					// (get) Token: 0x0600078D RID: 1933 RVA: 0x0000F8EE File Offset: 0x0000DAEE
					// (set) Token: 0x0600078E RID: 1934 RVA: 0x0000F8F6 File Offset: 0x0000DAF6
					[XmlElement]
					public string RedirectUrl { get; set; }

					// Token: 0x170002E4 RID: 740
					// (get) Token: 0x0600078F RID: 1935 RVA: 0x0000F8FF File Offset: 0x0000DAFF
					// (set) Token: 0x06000790 RID: 1936 RVA: 0x0000F907 File Offset: 0x0000DB07
					[XmlElement]
					public string AccessKey { get; set; }

					// Token: 0x170002E5 RID: 741
					// (get) Token: 0x06000791 RID: 1937 RVA: 0x0000F910 File Offset: 0x0000DB10
					// (set) Token: 0x06000792 RID: 1938 RVA: 0x0000F918 File Offset: 0x0000DB18
					public EnginePolicy.EncryptedValue Secret { get; set; }

					// Token: 0x06000793 RID: 1939 RVA: 0x0000F921 File Offset: 0x0000DB21
					public bool ShouldSerializeSecret()
					{
						return this.Secret.ShouldSerialize();
					}

					// Token: 0x0200010B RID: 267
					public enum AuthenticationType
					{
						// Token: 0x04000353 RID: 851
						Default,
						// Token: 0x04000354 RID: 852
						AccessKey,
						// Token: 0x04000355 RID: 853
						Cognito,
						// Token: 0x04000356 RID: 854
						Google
					}
				}

				// Token: 0x02000108 RID: 264
				public class FileAzureSettings
				{
					// Token: 0x06000794 RID: 1940 RVA: 0x0000F92E File Offset: 0x0000DB2E
					public FileAzureSettings()
					{
						this.AccessKey = new EnginePolicy.EncryptedValue();
					}

					// Token: 0x170002E6 RID: 742
					// (get) Token: 0x06000795 RID: 1941 RVA: 0x0000F941 File Offset: 0x0000DB41
					// (set) Token: 0x06000796 RID: 1942 RVA: 0x0000F949 File Offset: 0x0000DB49
					[XmlAttribute]
					public string Authentication { get; set; }

					// Token: 0x170002E7 RID: 743
					// (get) Token: 0x06000797 RID: 1943 RVA: 0x0000F952 File Offset: 0x0000DB52
					// (set) Token: 0x06000798 RID: 1944 RVA: 0x0000F95A File Offset: 0x0000DB5A
					[XmlAttribute]
					public bool SaveCredentials { get; set; }

					// Token: 0x170002E8 RID: 744
					// (get) Token: 0x06000799 RID: 1945 RVA: 0x0000F963 File Offset: 0x0000DB63
					// (set) Token: 0x0600079A RID: 1946 RVA: 0x0000F96B File Offset: 0x0000DB6B
					[XmlElement]
					public string StorageAccount { get; set; }

					// Token: 0x170002E9 RID: 745
					// (get) Token: 0x0600079B RID: 1947 RVA: 0x0000F974 File Offset: 0x0000DB74
					// (set) Token: 0x0600079C RID: 1948 RVA: 0x0000F97C File Offset: 0x0000DB7C
					[XmlElement]
					public string Container { get; set; }

					// Token: 0x170002EA RID: 746
					// (get) Token: 0x0600079D RID: 1949 RVA: 0x0000F985 File Offset: 0x0000DB85
					// (set) Token: 0x0600079E RID: 1950 RVA: 0x0000F98D File Offset: 0x0000DB8D
					[XmlElement]
					public string Prefix { get; set; }

					// Token: 0x170002EB RID: 747
					// (get) Token: 0x0600079F RID: 1951 RVA: 0x0000F996 File Offset: 0x0000DB96
					// (set) Token: 0x060007A0 RID: 1952 RVA: 0x0000F99E File Offset: 0x0000DB9E
					[XmlElement]
					public string TenantId { get; set; }

					// Token: 0x170002EC RID: 748
					// (get) Token: 0x060007A1 RID: 1953 RVA: 0x0000F9A7 File Offset: 0x0000DBA7
					// (set) Token: 0x060007A2 RID: 1954 RVA: 0x0000F9AF File Offset: 0x0000DBAF
					[XmlElement]
					public string ClientId { get; set; }

					// Token: 0x170002ED RID: 749
					// (get) Token: 0x060007A3 RID: 1955 RVA: 0x0000F9B8 File Offset: 0x0000DBB8
					// (set) Token: 0x060007A4 RID: 1956 RVA: 0x0000F9C0 File Offset: 0x0000DBC0
					public EnginePolicy.EncryptedValue AccessKey { get; set; }

					// Token: 0x060007A5 RID: 1957 RVA: 0x0000F9C9 File Offset: 0x0000DBC9
					public bool ShouldSerializeAccessKey()
					{
						return this.AccessKey.ShouldSerialize();
					}

					// Token: 0x0200010C RID: 268
					public enum AuthenticationType
					{
						// Token: 0x04000358 RID: 856
						Default,
						// Token: 0x04000359 RID: 857
						AccessKey,
						// Token: 0x0400035A RID: 858
						OAuth2
					}
				}

				// Token: 0x02000109 RID: 265
				public class FileGCSSettings
				{
					// Token: 0x060007A6 RID: 1958 RVA: 0x0000F9D6 File Offset: 0x0000DBD6
					public FileGCSSettings()
					{
						this.ServiceAccount = new EnginePolicy.EncryptedValue();
						this.ClientSecret = new EnginePolicy.EncryptedValue();
					}

					// Token: 0x170002EE RID: 750
					// (get) Token: 0x060007A7 RID: 1959 RVA: 0x0000F9F4 File Offset: 0x0000DBF4
					// (set) Token: 0x060007A8 RID: 1960 RVA: 0x0000F9FC File Offset: 0x0000DBFC
					[XmlAttribute]
					public string Authentication { get; set; }

					// Token: 0x170002EF RID: 751
					// (get) Token: 0x060007A9 RID: 1961 RVA: 0x0000FA05 File Offset: 0x0000DC05
					// (set) Token: 0x060007AA RID: 1962 RVA: 0x0000FA0D File Offset: 0x0000DC0D
					[XmlElement]
					public string Bucket { get; set; }

					// Token: 0x170002F0 RID: 752
					// (get) Token: 0x060007AB RID: 1963 RVA: 0x0000FA16 File Offset: 0x0000DC16
					// (set) Token: 0x060007AC RID: 1964 RVA: 0x0000FA1E File Offset: 0x0000DC1E
					[XmlElement]
					public string KeyPrefix { get; set; }

					// Token: 0x170002F1 RID: 753
					// (get) Token: 0x060007AD RID: 1965 RVA: 0x0000FA27 File Offset: 0x0000DC27
					// (set) Token: 0x060007AE RID: 1966 RVA: 0x0000FA2F File Offset: 0x0000DC2F
					public EnginePolicy.EncryptedValue ClientSecret { get; set; }

					// Token: 0x060007AF RID: 1967 RVA: 0x0000FA38 File Offset: 0x0000DC38
					public bool ShouldSerializeClientSecret()
					{
						return this.ClientSecret.ShouldSerialize();
					}

					// Token: 0x170002F2 RID: 754
					// (get) Token: 0x060007B0 RID: 1968 RVA: 0x0000FA45 File Offset: 0x0000DC45
					// (set) Token: 0x060007B1 RID: 1969 RVA: 0x0000FA4D File Offset: 0x0000DC4D
					public EnginePolicy.EncryptedValue ServiceAccount { get; set; }

					// Token: 0x060007B2 RID: 1970 RVA: 0x0000FA56 File Offset: 0x0000DC56
					public bool ShouldSerializeServiceAccount()
					{
						return this.ServiceAccount.ShouldSerialize();
					}

					// Token: 0x0200010D RID: 269
					public enum AuthenticationType
					{
						// Token: 0x0400035C RID: 860
						Default,
						// Token: 0x0400035D RID: 861
						ServiceAccount,
						// Token: 0x0400035E RID: 862
						OAuth2
					}
				}
			}

			// Token: 0x02000101 RID: 257
			public class EMA
			{
				// Token: 0x170002C1 RID: 705
				// (get) Token: 0x0600073C RID: 1852 RVA: 0x0000F549 File Offset: 0x0000D749
				// (set) Token: 0x0600073D RID: 1853 RVA: 0x0000F551 File Offset: 0x0000D751
				[XmlAttribute]
				public string ServerURL { get; set; }

				// Token: 0x170002C2 RID: 706
				// (get) Token: 0x0600073E RID: 1854 RVA: 0x0000F55A File Offset: 0x0000D75A
				// (set) Token: 0x0600073F RID: 1855 RVA: 0x0000F562 File Offset: 0x0000D762
				[XmlAttribute]
				public string Username { get; set; }

				// Token: 0x170002C3 RID: 707
				// (get) Token: 0x06000740 RID: 1856 RVA: 0x0000F56B File Offset: 0x0000D76B
				// (set) Token: 0x06000741 RID: 1857 RVA: 0x0000F573 File Offset: 0x0000D773
				[XmlAttribute]
				public string Password { get; set; }

				// Token: 0x06000742 RID: 1858 RVA: 0x0000F57C File Offset: 0x0000D77C
				public bool ShouldSerialize()
				{
					return this.ServerURL != null || this.Username != null || this.Password != null;
				}
			}

			// Token: 0x02000102 RID: 258
			public class NetworkSettings
			{
				// Token: 0x170002C4 RID: 708
				// (get) Token: 0x06000744 RID: 1860 RVA: 0x0000F599 File Offset: 0x0000D799
				// (set) Token: 0x06000745 RID: 1861 RVA: 0x0000F5A1 File Offset: 0x0000D7A1
				[XmlAttribute]
				public int UdpDiscoveryPort { get; set; }

				// Token: 0x170002C5 RID: 709
				// (get) Token: 0x06000746 RID: 1862 RVA: 0x0000F5AA File Offset: 0x0000D7AA
				// (set) Token: 0x06000747 RID: 1863 RVA: 0x0000F5B2 File Offset: 0x0000D7B2
				[XmlAttribute]
				public int TcpConnectPort { get; set; }

				// Token: 0x170002C6 RID: 710
				// (get) Token: 0x06000748 RID: 1864 RVA: 0x0000F5BB File Offset: 0x0000D7BB
				// (set) Token: 0x06000749 RID: 1865 RVA: 0x0000F5C3 File Offset: 0x0000D7C3
				[XmlAttribute]
				public int UdpConnectPort { get; set; }

				// Token: 0x170002C7 RID: 711
				// (get) Token: 0x0600074A RID: 1866 RVA: 0x0000F5CC File Offset: 0x0000D7CC
				// (set) Token: 0x0600074B RID: 1867 RVA: 0x0000F5D4 File Offset: 0x0000D7D4
				[XmlAttribute]
				public int SSLConnectPort { get; set; }

				// Token: 0x170002C8 RID: 712
				// (get) Token: 0x0600074C RID: 1868 RVA: 0x0000F5DD File Offset: 0x0000D7DD
				// (set) Token: 0x0600074D RID: 1869 RVA: 0x0000F5E5 File Offset: 0x0000D7E5
				[XmlIgnore]
				public SSLFlags SSLFlags { get; set; }

				// Token: 0x170002C9 RID: 713
				// (get) Token: 0x0600074E RID: 1870 RVA: 0x0000F5EE File Offset: 0x0000D7EE
				// (set) Token: 0x0600074F RID: 1871 RVA: 0x0000F5F6 File Offset: 0x0000D7F6
				[XmlAttribute("SSLFlags")]
				public int SSLFlagsInt
				{
					get
					{
						return (int)this.SSLFlags;
					}
					set
					{
						this.SSLFlags = (SSLFlags)value;
					}
				}

				// Token: 0x170002CA RID: 714
				// (get) Token: 0x06000750 RID: 1872 RVA: 0x0000F5FF File Offset: 0x0000D7FF
				// (set) Token: 0x06000751 RID: 1873 RVA: 0x0000F607 File Offset: 0x0000D807
				[XmlAttribute]
				public bool EnableWiFi { get; set; }
			}

			// Token: 0x02000103 RID: 259
			public class CertSettings
			{
				// Token: 0x170002CB RID: 715
				// (get) Token: 0x06000753 RID: 1875 RVA: 0x0000F610 File Offset: 0x0000D810
				// (set) Token: 0x06000754 RID: 1876 RVA: 0x0000F618 File Offset: 0x0000D818
				[XmlAttribute]
				public string File { get; set; }

				// Token: 0x170002CC RID: 716
				// (get) Token: 0x06000755 RID: 1877 RVA: 0x0000F621 File Offset: 0x0000D821
				// (set) Token: 0x06000756 RID: 1878 RVA: 0x0000F629 File Offset: 0x0000D829
				[XmlText]
				public string Cert { get; set; }

				// Token: 0x06000757 RID: 1879 RVA: 0x0000F632 File Offset: 0x0000D832
				public bool ShouldSerialize()
				{
					return this.File != null || this.Cert != null;
				}
			}
		}

		// Token: 0x02000099 RID: 153
		public class SettingsPolicy : IUpgradeable
		{
			// Token: 0x17000211 RID: 529
			// (get) Token: 0x0600053C RID: 1340 RVA: 0x0000D698 File Offset: 0x0000B898
			// (set) Token: 0x0600053D RID: 1341 RVA: 0x0000D6A0 File Offset: 0x0000B8A0
			[XmlAttribute]
			public bool CompressOthers { get; set; }

			// Token: 0x17000212 RID: 530
			// (get) Token: 0x0600053E RID: 1342 RVA: 0x0000D6A9 File Offset: 0x0000B8A9
			// (set) Token: 0x0600053F RID: 1343 RVA: 0x0000D6B1 File Offset: 0x0000B8B1
			[XmlAttribute]
			public bool CompressVan { get; set; }

			// Token: 0x17000213 RID: 531
			// (get) Token: 0x06000540 RID: 1344 RVA: 0x0000D6BA File Offset: 0x0000B8BA
			// (set) Token: 0x06000541 RID: 1345 RVA: 0x0000D6C2 File Offset: 0x0000B8C2
			[XmlIgnore]
			public bool? DisplayUI { get; set; }

			// Token: 0x17000214 RID: 532
			// (get) Token: 0x06000542 RID: 1346 RVA: 0x0000D6CC File Offset: 0x0000B8CC
			// (set) Token: 0x06000543 RID: 1347 RVA: 0x0000D700 File Offset: 0x0000B900
			[XmlAttribute("DisplayUI")]
			public string DisplayUIString
			{
				get
				{
					if (this.DisplayUI == null)
					{
						return null;
					}
					return this.DisplayUI.ToString();
				}
				set
				{
					this.DisplayUI = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}

			// Token: 0x17000215 RID: 533
			// (get) Token: 0x06000544 RID: 1348 RVA: 0x0000D731 File Offset: 0x0000B931
			// (set) Token: 0x06000545 RID: 1349 RVA: 0x0000D739 File Offset: 0x0000B939
			[XmlIgnore]
			public bool? DisplayWarningPage { get; set; }

			// Token: 0x17000216 RID: 534
			// (get) Token: 0x06000546 RID: 1350 RVA: 0x0000D744 File Offset: 0x0000B944
			// (set) Token: 0x06000547 RID: 1351 RVA: 0x0000D778 File Offset: 0x0000B978
			[XmlAttribute("DisplayWarningPage")]
			public string DisplayWarningPageString
			{
				get
				{
					if (this.DisplayWarningPage == null)
					{
						return null;
					}
					return this.DisplayWarningPage.ToString();
				}
				set
				{
					this.DisplayWarningPage = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}

			// Token: 0x17000217 RID: 535
			// (get) Token: 0x06000548 RID: 1352 RVA: 0x0000D7A9 File Offset: 0x0000B9A9
			// (set) Token: 0x06000549 RID: 1353 RVA: 0x0000D7B1 File Offset: 0x0000B9B1
			[XmlAttribute("RenameMapi")]
			public string RenameMapiString { get; set; }

			// Token: 0x17000218 RID: 536
			// (get) Token: 0x0600054A RID: 1354 RVA: 0x0000D7BA File Offset: 0x0000B9BA
			// (set) Token: 0x0600054B RID: 1355 RVA: 0x0000D7C2 File Offset: 0x0000B9C2
			[XmlAttribute]
			public bool RequireAdmin { get; set; }

			// Token: 0x17000219 RID: 537
			// (get) Token: 0x0600054C RID: 1356 RVA: 0x0000D7CB File Offset: 0x0000B9CB
			// (set) Token: 0x0600054D RID: 1357 RVA: 0x0000D7D3 File Offset: 0x0000B9D3
			[XmlAttribute]
			public bool SameJoinedDomain { get; set; }

			// Token: 0x1700021A RID: 538
			// (get) Token: 0x0600054E RID: 1358 RVA: 0x0000D7DC File Offset: 0x0000B9DC
			// (set) Token: 0x0600054F RID: 1359 RVA: 0x0000D7E4 File Offset: 0x0000B9E4
			[XmlAttribute]
			public string TransferThreads { get; set; }

			// Token: 0x1700021B RID: 539
			// (get) Token: 0x06000550 RID: 1360 RVA: 0x0000D7ED File Offset: 0x0000B9ED
			// (set) Token: 0x06000551 RID: 1361 RVA: 0x0000D7F5 File Offset: 0x0000B9F5
			[XmlAttribute]
			public string TransferBufSize { get; set; }

			// Token: 0x1700021C RID: 540
			// (get) Token: 0x06000552 RID: 1362 RVA: 0x0000D7FE File Offset: 0x0000B9FE
			// (set) Token: 0x06000553 RID: 1363 RVA: 0x0000D806 File Offset: 0x0000BA06
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x06000554 RID: 1364 RVA: 0x0000D810 File Offset: 0x0000BA10
			public void Upgrade(EnginePolicy enginePolicy)
			{
				if (this.RenameMapiString != null)
				{
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
					this.RenameMapiString = null;
				}
			}
		}

		// Token: 0x0200009A RID: 154
		public class ReportsPolicy : IUpgradeable
		{
			// Token: 0x06000556 RID: 1366 RVA: 0x0000D83C File Offset: 0x0000BA3C
			public ReportsPolicy()
			{
				this.Summary = new ObservableCollection<EnginePolicy.SummaryReport>();
				this.Detail = new ObservableCollection<EnginePolicy.DetailReport>();
			}

			// Token: 0x1700021D RID: 541
			// (get) Token: 0x06000557 RID: 1367 RVA: 0x0000D85A File Offset: 0x0000BA5A
			// (set) Token: 0x06000558 RID: 1368 RVA: 0x0000D862 File Offset: 0x0000BA62
			[XmlElement("Summary")]
			public ObservableCollection<EnginePolicy.SummaryReport> Summary { get; set; }

			// Token: 0x1700021E RID: 542
			// (get) Token: 0x06000559 RID: 1369 RVA: 0x0000D86B File Offset: 0x0000BA6B
			// (set) Token: 0x0600055A RID: 1370 RVA: 0x0000D873 File Offset: 0x0000BA73
			[XmlElement("Detail")]
			public ObservableCollection<EnginePolicy.DetailReport> Detail { get; set; }

			// Token: 0x1700021F RID: 543
			// (get) Token: 0x0600055B RID: 1371 RVA: 0x0000D87C File Offset: 0x0000BA7C
			// (set) Token: 0x0600055C RID: 1372 RVA: 0x0000D884 File Offset: 0x0000BA84
			[XmlAttribute]
			public string Format { get; set; }

			// Token: 0x17000220 RID: 544
			// (get) Token: 0x0600055D RID: 1373 RVA: 0x0000D88D File Offset: 0x0000BA8D
			// (set) Token: 0x0600055E RID: 1374 RVA: 0x0000D895 File Offset: 0x0000BA95
			[XmlAttribute]
			public string Encoding { get; set; }

			// Token: 0x17000221 RID: 545
			// (get) Token: 0x0600055F RID: 1375 RVA: 0x0000D89E File Offset: 0x0000BA9E
			// (set) Token: 0x06000560 RID: 1376 RVA: 0x0000D8A6 File Offset: 0x0000BAA6
			[XmlAttribute]
			public string Dir { get; set; }

			// Token: 0x17000222 RID: 546
			// (get) Token: 0x06000561 RID: 1377 RVA: 0x0000D8AF File Offset: 0x0000BAAF
			// (set) Token: 0x06000562 RID: 1378 RVA: 0x0000D8B7 File Offset: 0x0000BAB7
			[XmlAttribute]
			public string ClientDir { get; set; }

			// Token: 0x17000223 RID: 547
			// (get) Token: 0x06000563 RID: 1379 RVA: 0x0000D8C0 File Offset: 0x0000BAC0
			// (set) Token: 0x06000564 RID: 1380 RVA: 0x0000D8C8 File Offset: 0x0000BAC8
			[XmlIgnore]
			public int NumUpgradedItems { get; set; }

			// Token: 0x06000565 RID: 1381 RVA: 0x0000D8D4 File Offset: 0x0000BAD4
			public void Upgrade(EnginePolicy enginePolicy)
			{
				foreach (EnginePolicy.DetailReport detailReport in this.Detail)
				{
					if (string.IsNullOrWhiteSpace(detailReport.Generator))
					{
						int numUpgradedItems = this.NumUpgradedItems + 1;
						this.NumUpgradedItems = numUpgradedItems;
						detailReport.Generator = "Engine";
					}
				}
				foreach (EnginePolicy.SummaryReport summaryReport in this.Summary)
				{
					EnginePolicy.DetailReport item = new EnginePolicy.DetailReport
					{
						Type = "Summary",
						Append = summaryReport.Append,
						Mask = summaryReport.Format,
						Items = summaryReport.Value,
						Exceptions = summaryReport.Exceptions,
						Transferred = false,
						ShowComponents = false,
						Generator = "Engine",
						Value = summaryReport.Value
					};
					this.Detail.Add(item);
					int numUpgradedItems = this.NumUpgradedItems + 1;
					this.NumUpgradedItems = numUpgradedItems;
				}
				this.Summary.Clear();
			}
		}

		// Token: 0x0200009B RID: 155
		public class SummaryReport
		{
			// Token: 0x06000566 RID: 1382 RVA: 0x0000DA14 File Offset: 0x0000BC14
			public SummaryReport()
			{
				this.Append = true;
			}

			// Token: 0x17000224 RID: 548
			// (get) Token: 0x06000567 RID: 1383 RVA: 0x0000DA23 File Offset: 0x0000BC23
			// (set) Token: 0x06000568 RID: 1384 RVA: 0x0000DA2B File Offset: 0x0000BC2B
			[XmlAttribute]
			public bool Append { get; set; }

			// Token: 0x17000225 RID: 549
			// (get) Token: 0x06000569 RID: 1385 RVA: 0x0000DA34 File Offset: 0x0000BC34
			// (set) Token: 0x0600056A RID: 1386 RVA: 0x0000DA3C File Offset: 0x0000BC3C
			[XmlAttribute]
			public bool Exceptions { get; set; }

			// Token: 0x17000226 RID: 550
			// (get) Token: 0x0600056B RID: 1387 RVA: 0x0000DA45 File Offset: 0x0000BC45
			// (set) Token: 0x0600056C RID: 1388 RVA: 0x0000DA4D File Offset: 0x0000BC4D
			[XmlAttribute]
			public string Format { get; set; }

			// Token: 0x17000227 RID: 551
			// (get) Token: 0x0600056D RID: 1389 RVA: 0x0000DA56 File Offset: 0x0000BC56
			// (set) Token: 0x0600056E RID: 1390 RVA: 0x0000DA5E File Offset: 0x0000BC5E
			[XmlText]
			public string Value { get; set; }
		}

		// Token: 0x0200009C RID: 156
		public class DetailReport
		{
			// Token: 0x17000228 RID: 552
			// (get) Token: 0x0600056F RID: 1391 RVA: 0x0000DA67 File Offset: 0x0000BC67
			// (set) Token: 0x06000570 RID: 1392 RVA: 0x0000DA6F File Offset: 0x0000BC6F
			[XmlAttribute]
			public string Type { get; set; }

			// Token: 0x17000229 RID: 553
			// (get) Token: 0x06000571 RID: 1393 RVA: 0x0000DA78 File Offset: 0x0000BC78
			// (set) Token: 0x06000572 RID: 1394 RVA: 0x0000DA80 File Offset: 0x0000BC80
			[XmlAttribute]
			public bool Append { get; set; }

			// Token: 0x1700022A RID: 554
			// (get) Token: 0x06000573 RID: 1395 RVA: 0x0000DA89 File Offset: 0x0000BC89
			// (set) Token: 0x06000574 RID: 1396 RVA: 0x0000DA91 File Offset: 0x0000BC91
			[XmlAttribute]
			public string Mask { get; set; }

			// Token: 0x1700022B RID: 555
			// (get) Token: 0x06000575 RID: 1397 RVA: 0x0000DA9A File Offset: 0x0000BC9A
			// (set) Token: 0x06000576 RID: 1398 RVA: 0x0000DAA2 File Offset: 0x0000BCA2
			[XmlAttribute]
			public string Items { get; set; }

			// Token: 0x1700022C RID: 556
			// (get) Token: 0x06000577 RID: 1399 RVA: 0x0000DAAB File Offset: 0x0000BCAB
			// (set) Token: 0x06000578 RID: 1400 RVA: 0x0000DAB3 File Offset: 0x0000BCB3
			[XmlAttribute]
			public bool Exceptions { get; set; }

			// Token: 0x1700022D RID: 557
			// (get) Token: 0x06000579 RID: 1401 RVA: 0x0000DABC File Offset: 0x0000BCBC
			// (set) Token: 0x0600057A RID: 1402 RVA: 0x0000DAC4 File Offset: 0x0000BCC4
			[XmlAttribute]
			public bool Transferred { get; set; }

			// Token: 0x1700022E RID: 558
			// (get) Token: 0x0600057B RID: 1403 RVA: 0x0000DACD File Offset: 0x0000BCCD
			// (set) Token: 0x0600057C RID: 1404 RVA: 0x0000DAD5 File Offset: 0x0000BCD5
			[XmlAttribute]
			public bool ShowComponents { get; set; }

			// Token: 0x1700022F RID: 559
			// (get) Token: 0x0600057D RID: 1405 RVA: 0x0000DADE File Offset: 0x0000BCDE
			// (set) Token: 0x0600057E RID: 1406 RVA: 0x0000DAE6 File Offset: 0x0000BCE6
			[XmlAttribute]
			public string Generator { get; set; }

			// Token: 0x17000230 RID: 560
			// (get) Token: 0x0600057F RID: 1407 RVA: 0x0000DAEF File Offset: 0x0000BCEF
			// (set) Token: 0x06000580 RID: 1408 RVA: 0x0000DAF7 File Offset: 0x0000BCF7
			[XmlAttribute]
			public string Format { get; set; }

			// Token: 0x17000231 RID: 561
			// (get) Token: 0x06000581 RID: 1409 RVA: 0x0000DB00 File Offset: 0x0000BD00
			// (set) Token: 0x06000582 RID: 1410 RVA: 0x0000DB08 File Offset: 0x0000BD08
			[XmlText]
			public string Value { get; set; }
		}

		// Token: 0x0200009D RID: 157
		public class ConfigurationPolicy
		{
			// Token: 0x17000232 RID: 562
			// (get) Token: 0x06000584 RID: 1412 RVA: 0x0000DB11 File Offset: 0x0000BD11
			// (set) Token: 0x06000585 RID: 1413 RVA: 0x0000DB19 File Offset: 0x0000BD19
			public string LogDir { get; set; }

			// Token: 0x17000233 RID: 563
			// (get) Token: 0x06000586 RID: 1414 RVA: 0x0000DB22 File Offset: 0x0000BD22
			// (set) Token: 0x06000587 RID: 1415 RVA: 0x0000DB2A File Offset: 0x0000BD2A
			public string RuleDir { get; set; }

			// Token: 0x17000234 RID: 564
			// (get) Token: 0x06000588 RID: 1416 RVA: 0x0000DB33 File Offset: 0x0000BD33
			// (set) Token: 0x06000589 RID: 1417 RVA: 0x0000DB3B File Offset: 0x0000BD3B
			public string AppProfileDir { get; set; }

			// Token: 0x17000235 RID: 565
			// (get) Token: 0x0600058A RID: 1418 RVA: 0x0000DB44 File Offset: 0x0000BD44
			// (set) Token: 0x0600058B RID: 1419 RVA: 0x0000DB4C File Offset: 0x0000BD4C
			public string RedistDir { get; set; }

			// Token: 0x0600058C RID: 1420 RVA: 0x0000DB55 File Offset: 0x0000BD55
			public bool ShouldSerialize()
			{
				return this.LogDir != null || this.RuleDir != null || this.AppProfileDir != null || this.RedistDir != null;
			}
		}

		// Token: 0x0200009E RID: 158
		public class ApplicationsPolicy : EnginePolicy.InteractiveItem
		{
			// Token: 0x0600058E RID: 1422 RVA: 0x0000DB7A File Offset: 0x0000BD7A
			public ApplicationsPolicy()
			{
				this.Applications = new ObservableCollection<EnginePolicy.AppData>();
			}

			// Token: 0x17000236 RID: 566
			// (get) Token: 0x0600058F RID: 1423 RVA: 0x0000DB8D File Offset: 0x0000BD8D
			// (set) Token: 0x06000590 RID: 1424 RVA: 0x0000DB95 File Offset: 0x0000BD95
			[XmlAttribute]
			public bool MigrateByDefault { get; set; }

			// Token: 0x17000237 RID: 567
			// (get) Token: 0x06000591 RID: 1425 RVA: 0x0000DB9E File Offset: 0x0000BD9E
			// (set) Token: 0x06000592 RID: 1426 RVA: 0x0000DBA6 File Offset: 0x0000BDA6
			[XmlAttribute]
			public string MigrateUntested { get; set; }

			// Token: 0x17000238 RID: 568
			// (get) Token: 0x06000593 RID: 1427 RVA: 0x0000DBAF File Offset: 0x0000BDAF
			// (set) Token: 0x06000594 RID: 1428 RVA: 0x0000DBB7 File Offset: 0x0000BDB7
			[XmlAttribute]
			public bool ModifyDeselected { get; set; }

			// Token: 0x17000239 RID: 569
			// (get) Token: 0x06000595 RID: 1429 RVA: 0x0000DBC0 File Offset: 0x0000BDC0
			// (set) Token: 0x06000596 RID: 1430 RVA: 0x0000DBC8 File Offset: 0x0000BDC8
			[XmlAttribute]
			public bool ShowUndisplayed { get; set; }

			// Token: 0x1700023A RID: 570
			// (get) Token: 0x06000597 RID: 1431 RVA: 0x0000DBD1 File Offset: 0x0000BDD1
			// (set) Token: 0x06000598 RID: 1432 RVA: 0x0000DBD9 File Offset: 0x0000BDD9
			[XmlAttribute]
			public bool Migrate32to64 { get; set; }

			// Token: 0x1700023B RID: 571
			// (get) Token: 0x06000599 RID: 1433 RVA: 0x0000DBE2 File Offset: 0x0000BDE2
			// (set) Token: 0x0600059A RID: 1434 RVA: 0x0000DBEA File Offset: 0x0000BDEA
			[XmlElement("Application")]
			public ObservableCollection<EnginePolicy.AppData> Applications { get; set; }
		}

		// Token: 0x0200009F RID: 159
		[XmlRoot(ElementName = "Application")]
		public class AppData
		{
			// Token: 0x1700023C RID: 572
			// (get) Token: 0x0600059B RID: 1435 RVA: 0x0000DBF3 File Offset: 0x0000BDF3
			// (set) Token: 0x0600059C RID: 1436 RVA: 0x0000DBFB File Offset: 0x0000BDFB
			[XmlAttribute]
			public string Name { get; set; }

			// Token: 0x1700023D RID: 573
			// (get) Token: 0x0600059D RID: 1437 RVA: 0x0000DC04 File Offset: 0x0000BE04
			// (set) Token: 0x0600059E RID: 1438 RVA: 0x0000DC0C File Offset: 0x0000BE0C
			[XmlAttribute]
			public string Id { get; set; }

			// Token: 0x1700023E RID: 574
			// (get) Token: 0x0600059F RID: 1439 RVA: 0x0000DC15 File Offset: 0x0000BE15
			// (set) Token: 0x060005A0 RID: 1440 RVA: 0x0000DC1D File Offset: 0x0000BE1D
			[XmlAttribute]
			public string Publisher { get; set; }

			// Token: 0x1700023F RID: 575
			// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0000DC26 File Offset: 0x0000BE26
			// (set) Token: 0x060005A2 RID: 1442 RVA: 0x0000DC2E File Offset: 0x0000BE2E
			[XmlAttribute]
			public bool Migrate { get; set; }

			// Token: 0x17000240 RID: 576
			// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0000DC37 File Offset: 0x0000BE37
			// (set) Token: 0x060005A4 RID: 1444 RVA: 0x0000DC3F File Offset: 0x0000BE3F
			[XmlAttribute]
			public bool Modify { get; set; }
		}

		// Token: 0x020000A0 RID: 160
		[XmlRoot(ElementName = "DriveMap")]
		public class DriveMapping : EnginePolicy.InteractiveItem
		{
			// Token: 0x060005A6 RID: 1446 RVA: 0x0000DC48 File Offset: 0x0000BE48
			public DriveMapping()
			{
				this.Drives = new List<EnginePolicy.DriveMapItem>();
			}

			// Token: 0x17000241 RID: 577
			// (get) Token: 0x060005A7 RID: 1447 RVA: 0x0000DC5B File Offset: 0x0000BE5B
			// (set) Token: 0x060005A8 RID: 1448 RVA: 0x0000DC63 File Offset: 0x0000BE63
			[XmlElement("Drive")]
			public List<EnginePolicy.DriveMapItem> Drives { get; set; }

			// Token: 0x060005A9 RID: 1449 RVA: 0x00005343 File Offset: 0x00003543
			public bool ShouldSerialize()
			{
				return true;
			}
		}

		// Token: 0x020000A1 RID: 161
		[XmlRoot(ElementName = "Drive")]
		public class DriveMapItem : EnginePolicy.MigrateModifyItem
		{
			// Token: 0x060005AA RID: 1450 RVA: 0x0000DC6C File Offset: 0x0000BE6C
			public DriveMapItem()
			{
			}

			// Token: 0x060005AB RID: 1451 RVA: 0x0000DC74 File Offset: 0x0000BE74
			public DriveMapItem(string source, string target)
			{
				this.Source = source;
				this.Target = target;
				base.Migrate = new bool?(!string.IsNullOrWhiteSpace(target));
			}

			// Token: 0x17000242 RID: 578
			// (get) Token: 0x060005AC RID: 1452 RVA: 0x0000DC9E File Offset: 0x0000BE9E
			// (set) Token: 0x060005AD RID: 1453 RVA: 0x0000DCA6 File Offset: 0x0000BEA6
			[XmlAttribute]
			public string Source { get; set; }

			// Token: 0x17000243 RID: 579
			// (get) Token: 0x060005AE RID: 1454 RVA: 0x0000DCAF File Offset: 0x0000BEAF
			// (set) Token: 0x060005AF RID: 1455 RVA: 0x0000DCB7 File Offset: 0x0000BEB7
			[XmlAttribute]
			public string Target { get; set; }

			// Token: 0x17000244 RID: 580
			// (get) Token: 0x060005B0 RID: 1456 RVA: 0x0000DCC0 File Offset: 0x0000BEC0
			// (set) Token: 0x060005B1 RID: 1457 RVA: 0x0000DCE4 File Offset: 0x0000BEE4
			[XmlAttribute("Exists")]
			public string ExistsString
			{
				get
				{
					if (this.Exists == null)
					{
						return null;
					}
					return this.Exists.ToString();
				}
				set
				{
					this.Exists = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}

			// Token: 0x04000266 RID: 614
			[XmlIgnore]
			public bool? Exists;
		}

		// Token: 0x020000A2 RID: 162
		[XmlRoot(ElementName = "FileFilter")]
		public class FileFilterPolicy : EnginePolicy.InteractiveItem
		{
			// Token: 0x060005B2 RID: 1458 RVA: 0x0000DD15 File Offset: 0x0000BF15
			public FileFilterPolicy()
			{
				this.Filters = new List<EnginePolicy.FileFilterItem>();
			}

			// Token: 0x17000245 RID: 581
			// (get) Token: 0x060005B3 RID: 1459 RVA: 0x0000DD28 File Offset: 0x0000BF28
			// (set) Token: 0x060005B4 RID: 1460 RVA: 0x0000DD30 File Offset: 0x0000BF30
			[XmlElement("Filter")]
			public List<EnginePolicy.FileFilterItem> Filters { get; set; }

			// Token: 0x060005B5 RID: 1461 RVA: 0x0000DD39 File Offset: 0x0000BF39
			public bool ShouldSerialize()
			{
				return this.Filters.Any<EnginePolicy.FileFilterItem>();
			}
		}

		// Token: 0x020000A3 RID: 163
		[XmlRoot(ElementName = "Filter")]
		public class FileFilterItem : EnginePolicy.MigrateModifyItem
		{
			// Token: 0x060005B6 RID: 1462 RVA: 0x0000DC6C File Offset: 0x0000BE6C
			public FileFilterItem()
			{
			}

			// Token: 0x060005B7 RID: 1463 RVA: 0x0000DD46 File Offset: 0x0000BF46
			public FileFilterItem(string source, bool? migrate) : this(source, "", migrate)
			{
			}

			// Token: 0x060005B8 RID: 1464 RVA: 0x0000DD55 File Offset: 0x0000BF55
			public FileFilterItem(string source, string target) : this(source, target, new bool?(true))
			{
			}

			// Token: 0x060005B9 RID: 1465 RVA: 0x0000DD65 File Offset: 0x0000BF65
			public FileFilterItem(string source, string target, bool? migrate)
			{
				this.Source = source;
				this.Target = target;
				base.Migrate = migrate;
			}

			// Token: 0x17000246 RID: 582
			// (get) Token: 0x060005BA RID: 1466 RVA: 0x0000DD82 File Offset: 0x0000BF82
			// (set) Token: 0x060005BB RID: 1467 RVA: 0x0000DD8A File Offset: 0x0000BF8A
			[XmlAttribute]
			public string Source { get; set; }

			// Token: 0x17000247 RID: 583
			// (get) Token: 0x060005BC RID: 1468 RVA: 0x0000DD93 File Offset: 0x0000BF93
			// (set) Token: 0x060005BD RID: 1469 RVA: 0x0000DD9B File Offset: 0x0000BF9B
			[XmlAttribute]
			public string Target { get; set; }
		}

		// Token: 0x020000A4 RID: 164
		[XmlRoot(ElementName = "DirFilter")]
		public class DirFilterPolicy : EnginePolicy.InteractiveItem
		{
			// Token: 0x060005BE RID: 1470 RVA: 0x0000DDA4 File Offset: 0x0000BFA4
			public DirFilterPolicy()
			{
				this.Filters = new ObservableCollection<EnginePolicy.DirFilterItem>();
			}

			// Token: 0x17000248 RID: 584
			// (get) Token: 0x060005BF RID: 1471 RVA: 0x0000DDB7 File Offset: 0x0000BFB7
			// (set) Token: 0x060005C0 RID: 1472 RVA: 0x0000DDBF File Offset: 0x0000BFBF
			[XmlElement("Filter")]
			public ObservableCollection<EnginePolicy.DirFilterItem> Filters { get; set; }

			// Token: 0x060005C1 RID: 1473 RVA: 0x0000DDC8 File Offset: 0x0000BFC8
			public bool ShouldSerialize()
			{
				return this.Filters.Any<EnginePolicy.DirFilterItem>();
			}
		}

		// Token: 0x020000A5 RID: 165
		[XmlRoot(ElementName = "Filter")]
		public class DirFilterItem : EnginePolicy.MigrateModifyItem
		{
			// Token: 0x060005C2 RID: 1474 RVA: 0x0000DC6C File Offset: 0x0000BE6C
			public DirFilterItem()
			{
			}

			// Token: 0x060005C3 RID: 1475 RVA: 0x0000DDD5 File Offset: 0x0000BFD5
			public DirFilterItem(string source, string target) : this(source, target, new bool?(true))
			{
			}

			// Token: 0x060005C4 RID: 1476 RVA: 0x0000DDE5 File Offset: 0x0000BFE5
			public DirFilterItem(string source, bool? migrate) : this(source, "", migrate)
			{
			}

			// Token: 0x060005C5 RID: 1477 RVA: 0x0000DDF4 File Offset: 0x0000BFF4
			public DirFilterItem(string source, string target, bool? migrate)
			{
				this.Source = source;
				this.TargetNonApp = target;
				base.Migrate = migrate;
			}

			// Token: 0x060005C6 RID: 1478 RVA: 0x0000DE14 File Offset: 0x0000C014
			public DirFilterItem(EnginePolicy.DirFilterItem other)
			{
				this.Source = other.Source;
				this.TargetNonApp = other.TargetNonApp;
				this.TargetAll = other.TargetAll;
				base.Migrate = other.Migrate;
				base.Modify = other.Modify;
			}

			// Token: 0x17000249 RID: 585
			// (get) Token: 0x060005C7 RID: 1479 RVA: 0x0000DE63 File Offset: 0x0000C063
			// (set) Token: 0x060005C8 RID: 1480 RVA: 0x0000DE6B File Offset: 0x0000C06B
			[XmlAttribute]
			public string Source { get; set; }

			// Token: 0x1700024A RID: 586
			// (get) Token: 0x060005C9 RID: 1481 RVA: 0x0000DE74 File Offset: 0x0000C074
			// (set) Token: 0x060005CA RID: 1482 RVA: 0x0000DE7C File Offset: 0x0000C07C
			[XmlAttribute]
			public string TargetAll { get; set; }

			// Token: 0x1700024B RID: 587
			// (get) Token: 0x060005CB RID: 1483 RVA: 0x0000DE85 File Offset: 0x0000C085
			// (set) Token: 0x060005CC RID: 1484 RVA: 0x0000DE8D File Offset: 0x0000C08D
			[XmlAttribute]
			public string TargetNonApp { get; set; }
		}

		// Token: 0x020000A6 RID: 166
		public class UserMapping : EnginePolicy.InteractiveItem
		{
			// Token: 0x060005CD RID: 1485 RVA: 0x0000DE96 File Offset: 0x0000C096
			public UserMapping()
			{
				this.Users = new ObservableCollection<EnginePolicy.UserPolicy>();
				this.Domains = new ObservableCollection<EnginePolicy.DomainMapPolicy>();
			}

			// Token: 0x1700024C RID: 588
			// (get) Token: 0x060005CE RID: 1486 RVA: 0x0000DEB4 File Offset: 0x0000C0B4
			// (set) Token: 0x060005CF RID: 1487 RVA: 0x0000DEBC File Offset: 0x0000C0BC
			[XmlAttribute]
			public int LogonDays { get; set; }

			// Token: 0x1700024D RID: 589
			// (get) Token: 0x060005D0 RID: 1488 RVA: 0x0000DEC5 File Offset: 0x0000C0C5
			// (set) Token: 0x060005D1 RID: 1489 RVA: 0x0000DECD File Offset: 0x0000C0CD
			[XmlAttribute]
			public bool CurrentToCurrent { get; set; }

			// Token: 0x1700024E RID: 590
			// (get) Token: 0x060005D2 RID: 1490 RVA: 0x0000DED6 File Offset: 0x0000C0D6
			// (set) Token: 0x060005D3 RID: 1491 RVA: 0x0000DEDE File Offset: 0x0000C0DE
			[XmlAttribute]
			public bool Create { get; set; }

			// Token: 0x1700024F RID: 591
			// (get) Token: 0x060005D4 RID: 1492 RVA: 0x0000DEE7 File Offset: 0x0000C0E7
			// (set) Token: 0x060005D5 RID: 1493 RVA: 0x0000DEEF File Offset: 0x0000C0EF
			[XmlAttribute]
			public bool CurrentOnly { get; set; }

			// Token: 0x17000250 RID: 592
			// (get) Token: 0x060005D6 RID: 1494 RVA: 0x0000DEF8 File Offset: 0x0000C0F8
			// (set) Token: 0x060005D7 RID: 1495 RVA: 0x0000DF00 File Offset: 0x0000C100
			[XmlAttribute]
			public bool UsersOnly { get; set; }

			// Token: 0x17000251 RID: 593
			// (get) Token: 0x060005D8 RID: 1496 RVA: 0x0000DF09 File Offset: 0x0000C109
			// (set) Token: 0x060005D9 RID: 1497 RVA: 0x0000DF11 File Offset: 0x0000C111
			[XmlAttribute]
			public bool ProfilesOnly { get; set; }

			// Token: 0x17000252 RID: 594
			// (get) Token: 0x060005DA RID: 1498 RVA: 0x0000DF1A File Offset: 0x0000C11A
			// (set) Token: 0x060005DB RID: 1499 RVA: 0x0000DF22 File Offset: 0x0000C122
			[XmlAttribute]
			public bool RegularOnly { get; set; }

			// Token: 0x17000253 RID: 595
			// (get) Token: 0x060005DC RID: 1500 RVA: 0x0000DF2B File Offset: 0x0000C12B
			// (set) Token: 0x060005DD RID: 1501 RVA: 0x0000DF33 File Offset: 0x0000C133
			[XmlAttribute]
			public string DeferUser { get; set; }

			// Token: 0x17000254 RID: 596
			// (get) Token: 0x060005DE RID: 1502 RVA: 0x0000DF3C File Offset: 0x0000C13C
			// (set) Token: 0x060005DF RID: 1503 RVA: 0x0000DF44 File Offset: 0x0000C144
			[XmlAttribute]
			public bool RequireJoinedDomain { get; set; }

			// Token: 0x17000255 RID: 597
			// (get) Token: 0x060005E0 RID: 1504 RVA: 0x0000DF4D File Offset: 0x0000C14D
			// (set) Token: 0x060005E1 RID: 1505 RVA: 0x0000DF55 File Offset: 0x0000C155
			[XmlElement("User")]
			public ObservableCollection<EnginePolicy.UserPolicy> Users { get; set; }

			// Token: 0x17000256 RID: 598
			// (get) Token: 0x060005E2 RID: 1506 RVA: 0x0000DF5E File Offset: 0x0000C15E
			// (set) Token: 0x060005E3 RID: 1507 RVA: 0x0000DF66 File Offset: 0x0000C166
			[XmlElement("Domain")]
			public ObservableCollection<EnginePolicy.DomainMapPolicy> Domains { get; set; }
		}

		// Token: 0x020000A7 RID: 167
		public class RegistrationPolicy
		{
			// Token: 0x060005E4 RID: 1508 RVA: 0x0000DF6F File Offset: 0x0000C16F
			public RegistrationPolicy()
			{
				this.Validations = new ObservableCollection<EnginePolicy.ValidationCodePolicy>();
			}

			// Token: 0x17000257 RID: 599
			// (get) Token: 0x060005E5 RID: 1509 RVA: 0x0000DF8D File Offset: 0x0000C18D
			// (set) Token: 0x060005E6 RID: 1510 RVA: 0x0000DF95 File Offset: 0x0000C195
			public string Name { get; set; }

			// Token: 0x17000258 RID: 600
			// (get) Token: 0x060005E7 RID: 1511 RVA: 0x0000DF9E File Offset: 0x0000C19E
			// (set) Token: 0x060005E8 RID: 1512 RVA: 0x0000DFA6 File Offset: 0x0000C1A6
			public string Email { get; set; }

			// Token: 0x17000259 RID: 601
			// (get) Token: 0x060005E9 RID: 1513 RVA: 0x0000DFAF File Offset: 0x0000C1AF
			// (set) Token: 0x060005EA RID: 1514 RVA: 0x0000DFB7 File Offset: 0x0000C1B7
			public EnginePolicy.EncryptedValue SerialNumber { get; set; } = new EnginePolicy.EncryptedValue();

			// Token: 0x060005EB RID: 1515 RVA: 0x0000DFC0 File Offset: 0x0000C1C0
			public bool ShouldSerializeSerialNumber()
			{
				return this.SerialNumber.ShouldSerialize();
			}

			// Token: 0x1700025A RID: 602
			// (get) Token: 0x060005EC RID: 1516 RVA: 0x0000DFCD File Offset: 0x0000C1CD
			// (set) Token: 0x060005ED RID: 1517 RVA: 0x0000DFD5 File Offset: 0x0000C1D5
			[XmlElement("ValidationCode")]
			public ObservableCollection<EnginePolicy.ValidationCodePolicy> Validations { get; set; }

			// Token: 0x060005EE RID: 1518 RVA: 0x0000DFDE File Offset: 0x0000C1DE
			public bool ShouldSerialize()
			{
				return this.Name != null || this.Email != null || this.ShouldSerializeSerialNumber() || this.Validations.Any<EnginePolicy.ValidationCodePolicy>();
			}
		}

		// Token: 0x020000A8 RID: 168
		[XmlRoot(ElementName = "ValidationCode")]
		public class ValidationCodePolicy : EnginePolicy.EncryptedValue
		{
			// Token: 0x1700025B RID: 603
			// (get) Token: 0x060005EF RID: 1519 RVA: 0x0000E005 File Offset: 0x0000C205
			// (set) Token: 0x060005F0 RID: 1520 RVA: 0x0000E00D File Offset: 0x0000C20D
			[XmlAttribute]
			public string SrcNetworkName { get; set; }

			// Token: 0x1700025C RID: 604
			// (get) Token: 0x060005F1 RID: 1521 RVA: 0x0000E016 File Offset: 0x0000C216
			// (set) Token: 0x060005F2 RID: 1522 RVA: 0x0000E01E File Offset: 0x0000C21E
			[XmlAttribute]
			public string DstNetworkName { get; set; }

			// Token: 0x1700025D RID: 605
			// (get) Token: 0x060005F3 RID: 1523 RVA: 0x0000E027 File Offset: 0x0000C227
			// (set) Token: 0x060005F4 RID: 1524 RVA: 0x0000E02F File Offset: 0x0000C22F
			[XmlAttribute]
			public uint SrcMachineId { get; set; }

			// Token: 0x1700025E RID: 606
			// (get) Token: 0x060005F5 RID: 1525 RVA: 0x0000E038 File Offset: 0x0000C238
			// (set) Token: 0x060005F6 RID: 1526 RVA: 0x0000E040 File Offset: 0x0000C240
			[XmlAttribute]
			public uint DstMachineId { get; set; }
		}

		// Token: 0x020000A9 RID: 169
		[XmlRoot(ElementName = "Alerts")]
		public class AlertsPolicy
		{
			// Token: 0x060005F8 RID: 1528 RVA: 0x0000E051 File Offset: 0x0000C251
			public AlertsPolicy()
			{
				this.AlertList = new ObservableCollection<EnginePolicy.AlertData>();
			}

			// Token: 0x1700025F RID: 607
			// (get) Token: 0x060005F9 RID: 1529 RVA: 0x0000E064 File Offset: 0x0000C264
			// (set) Token: 0x060005FA RID: 1530 RVA: 0x0000E06C File Offset: 0x0000C26C
			public string Name { get; set; }

			// Token: 0x17000260 RID: 608
			// (get) Token: 0x060005FB RID: 1531 RVA: 0x0000E075 File Offset: 0x0000C275
			// (set) Token: 0x060005FC RID: 1532 RVA: 0x0000E07D File Offset: 0x0000C27D
			public string Email { get; set; }

			// Token: 0x17000261 RID: 609
			// (get) Token: 0x060005FD RID: 1533 RVA: 0x0000E086 File Offset: 0x0000C286
			// (set) Token: 0x060005FE RID: 1534 RVA: 0x0000E08E File Offset: 0x0000C28E
			public string Message { get; set; }

			// Token: 0x17000262 RID: 610
			// (get) Token: 0x060005FF RID: 1535 RVA: 0x0000E097 File Offset: 0x0000C297
			// (set) Token: 0x06000600 RID: 1536 RVA: 0x0000E09F File Offset: 0x0000C29F
			[XmlAttribute]
			public bool EnableInteractive { get; set; }

			// Token: 0x17000263 RID: 611
			// (get) Token: 0x06000601 RID: 1537 RVA: 0x0000E0A8 File Offset: 0x0000C2A8
			// (set) Token: 0x06000602 RID: 1538 RVA: 0x0000E0B0 File Offset: 0x0000C2B0
			[XmlElement(ElementName = "Alert")]
			public ObservableCollection<EnginePolicy.AlertData> AlertList { get; set; }
		}

		// Token: 0x020000AA RID: 170
		public class AlertData
		{
			// Token: 0x17000264 RID: 612
			// (get) Token: 0x06000603 RID: 1539 RVA: 0x0000E0B9 File Offset: 0x0000C2B9
			// (set) Token: 0x06000604 RID: 1540 RVA: 0x0000E0C1 File Offset: 0x0000C2C1
			public string Name { get; set; }

			// Token: 0x17000265 RID: 613
			// (get) Token: 0x06000605 RID: 1541 RVA: 0x0000E0CA File Offset: 0x0000C2CA
			// (set) Token: 0x06000606 RID: 1542 RVA: 0x0000E0D2 File Offset: 0x0000C2D2
			public string Email { get; set; }

			// Token: 0x17000266 RID: 614
			// (get) Token: 0x06000607 RID: 1543 RVA: 0x0000E0DB File Offset: 0x0000C2DB
			// (set) Token: 0x06000608 RID: 1544 RVA: 0x0000E0E3 File Offset: 0x0000C2E3
			public string Message { get; set; }
		}

		// Token: 0x020000AB RID: 171
		public class MigmodPolicy : EnginePolicy.InteractiveItem
		{
			// Token: 0x0600060A RID: 1546 RVA: 0x0000E0EC File Offset: 0x0000C2EC
			public MigmodPolicy()
			{
				this.Items = new List<EnginePolicy.MigModItem>();
				this.Rulesets = new ObservableCollection<string>();
			}

			// Token: 0x17000267 RID: 615
			// (get) Token: 0x0600060B RID: 1547 RVA: 0x0000E10A File Offset: 0x0000C30A
			// (set) Token: 0x0600060C RID: 1548 RVA: 0x0000E112 File Offset: 0x0000C312
			[XmlElement("Item")]
			public List<EnginePolicy.MigModItem> Items { get; set; }

			// Token: 0x17000268 RID: 616
			// (get) Token: 0x0600060D RID: 1549 RVA: 0x0000E11B File Offset: 0x0000C31B
			// (set) Token: 0x0600060E RID: 1550 RVA: 0x0000E123 File Offset: 0x0000C323
			[XmlElement("Ruleset")]
			public ObservableCollection<string> Rulesets { get; set; }

			// Token: 0x0600060F RID: 1551 RVA: 0x0000E12C File Offset: 0x0000C32C
			public bool ShouldSerialize()
			{
				if (!this.Items.Any<EnginePolicy.MigModItem>() && !this.Rulesets.Any<string>())
				{
					bool? interactive = base.Interactive;
					bool flag = false;
					return interactive.GetValueOrDefault() == flag & interactive != null;
				}
				return true;
			}
		}

		// Token: 0x020000AC RID: 172
		public class MigModItem : EnginePolicy.SelectedModifyItem
		{
			// Token: 0x06000610 RID: 1552 RVA: 0x0000E170 File Offset: 0x0000C370
			public MigModItem()
			{
			}

			// Token: 0x06000611 RID: 1553 RVA: 0x0000E178 File Offset: 0x0000C378
			public MigModItem(string name, bool? selected)
			{
				this.Name = name;
				base.Selected = selected;
			}

			// Token: 0x17000269 RID: 617
			// (get) Token: 0x06000612 RID: 1554 RVA: 0x0000E18E File Offset: 0x0000C38E
			// (set) Token: 0x06000613 RID: 1555 RVA: 0x0000E196 File Offset: 0x0000C396
			[XmlAttribute]
			public string Name { get; set; }
		}

		// Token: 0x020000AD RID: 173
		[XmlRoot(ElementName = "User")]
		public class UserPolicy
		{
			// Token: 0x06000614 RID: 1556 RVA: 0x0000E19F File Offset: 0x0000C39F
			public UserPolicy()
			{
				this.MapiProfiles = new ObservableCollection<EnginePolicy.MapiProfilePolicy>();
			}

			// Token: 0x06000615 RID: 1557 RVA: 0x0000E1B4 File Offset: 0x0000C3B4
			public UserPolicy(EnginePolicy.UserPolicy other)
			{
				this.Source = other.Source;
				this.SourceType = other.SourceType;
				this.Target = other.Target;
				this.FullName = other.FullName;
				this.TargetType = other.TargetType;
				this.Migrate = other.Migrate;
				this.Password = other.Password;
			}

			// Token: 0x1700026A RID: 618
			// (get) Token: 0x06000616 RID: 1558 RVA: 0x0000E21B File Offset: 0x0000C41B
			// (set) Token: 0x06000617 RID: 1559 RVA: 0x0000E223 File Offset: 0x0000C423
			[XmlAttribute]
			public string Source { get; set; }

			// Token: 0x1700026B RID: 619
			// (get) Token: 0x06000618 RID: 1560 RVA: 0x0000E22C File Offset: 0x0000C42C
			// (set) Token: 0x06000619 RID: 1561 RVA: 0x0000E234 File Offset: 0x0000C434
			[XmlAttribute]
			public string SourceType { get; set; }

			// Token: 0x1700026C RID: 620
			// (get) Token: 0x0600061A RID: 1562 RVA: 0x0000E23D File Offset: 0x0000C43D
			// (set) Token: 0x0600061B RID: 1563 RVA: 0x0000E245 File Offset: 0x0000C445
			[XmlAttribute]
			public string Target { get; set; }

			// Token: 0x1700026D RID: 621
			// (get) Token: 0x0600061C RID: 1564 RVA: 0x0000E24E File Offset: 0x0000C44E
			// (set) Token: 0x0600061D RID: 1565 RVA: 0x0000E256 File Offset: 0x0000C456
			[XmlAttribute]
			public string FullName { get; set; }

			// Token: 0x1700026E RID: 622
			// (get) Token: 0x0600061E RID: 1566 RVA: 0x0000E25F File Offset: 0x0000C45F
			// (set) Token: 0x0600061F RID: 1567 RVA: 0x0000E267 File Offset: 0x0000C467
			[XmlAttribute]
			public string TargetType { get; set; }

			// Token: 0x1700026F RID: 623
			// (get) Token: 0x06000620 RID: 1568 RVA: 0x0000E270 File Offset: 0x0000C470
			// (set) Token: 0x06000621 RID: 1569 RVA: 0x0000E278 File Offset: 0x0000C478
			[XmlAttribute]
			public bool Migrate { get; set; }

			// Token: 0x17000270 RID: 624
			// (get) Token: 0x06000622 RID: 1570 RVA: 0x0000E281 File Offset: 0x0000C481
			// (set) Token: 0x06000623 RID: 1571 RVA: 0x0000E289 File Offset: 0x0000C489
			[XmlElement("MapiProfile")]
			public ObservableCollection<EnginePolicy.MapiProfilePolicy> MapiProfiles { get; set; }

			// Token: 0x17000271 RID: 625
			// (get) Token: 0x06000624 RID: 1572 RVA: 0x0000E292 File Offset: 0x0000C492
			// (set) Token: 0x06000625 RID: 1573 RVA: 0x0000E29A File Offset: 0x0000C49A
			public string Password { get; set; }

			// Token: 0x06000626 RID: 1574 RVA: 0x0000E2A3 File Offset: 0x0000C4A3
			public bool ShouldSerializePassword()
			{
				return !string.IsNullOrWhiteSpace(this.Password);
			}
		}

		// Token: 0x020000AE RID: 174
		[XmlRoot(ElementName = "Domain")]
		public class DomainMapPolicy
		{
			// Token: 0x17000272 RID: 626
			// (get) Token: 0x06000627 RID: 1575 RVA: 0x0000E2B3 File Offset: 0x0000C4B3
			// (set) Token: 0x06000628 RID: 1576 RVA: 0x0000E2BB File Offset: 0x0000C4BB
			[XmlAttribute]
			public string Source { get; set; }

			// Token: 0x17000273 RID: 627
			// (get) Token: 0x06000629 RID: 1577 RVA: 0x0000E2C4 File Offset: 0x0000C4C4
			// (set) Token: 0x0600062A RID: 1578 RVA: 0x0000E2CC File Offset: 0x0000C4CC
			[XmlAttribute]
			public string Target { get; set; }

			// Token: 0x17000274 RID: 628
			// (get) Token: 0x0600062B RID: 1579 RVA: 0x0000E2D5 File Offset: 0x0000C4D5
			public bool IsEmpty
			{
				get
				{
					return string.IsNullOrWhiteSpace(this.Source) && string.IsNullOrWhiteSpace(this.Target);
				}
			}
		}

		// Token: 0x020000AF RID: 175
		[XmlRoot(ElementName = "MapiProfile")]
		public class MapiProfilePolicy
		{
			// Token: 0x17000275 RID: 629
			// (get) Token: 0x0600062D RID: 1581 RVA: 0x0000E2F1 File Offset: 0x0000C4F1
			// (set) Token: 0x0600062E RID: 1582 RVA: 0x0000E2F9 File Offset: 0x0000C4F9
			[XmlAttribute]
			public string Source { get; set; }

			// Token: 0x17000276 RID: 630
			// (get) Token: 0x0600062F RID: 1583 RVA: 0x0000E302 File Offset: 0x0000C502
			// (set) Token: 0x06000630 RID: 1584 RVA: 0x0000E30A File Offset: 0x0000C50A
			[XmlAttribute]
			public bool Migrate { get; set; }

			// Token: 0x17000277 RID: 631
			// (get) Token: 0x06000631 RID: 1585 RVA: 0x0000E313 File Offset: 0x0000C513
			// (set) Token: 0x06000632 RID: 1586 RVA: 0x0000E31B File Offset: 0x0000C51B
			[XmlAttribute]
			public string CreateTarget { get; set; }

			// Token: 0x17000278 RID: 632
			// (get) Token: 0x06000633 RID: 1587 RVA: 0x0000E324 File Offset: 0x0000C524
			// (set) Token: 0x06000634 RID: 1588 RVA: 0x0000E32C File Offset: 0x0000C52C
			[XmlAttribute]
			public string ExistsTarget { get; set; }
		}

		// Token: 0x020000B0 RID: 176
		public class MigTypePolicy
		{
			// Token: 0x17000279 RID: 633
			// (get) Token: 0x06000636 RID: 1590 RVA: 0x0000E335 File Offset: 0x0000C535
			// (set) Token: 0x06000637 RID: 1591 RVA: 0x0000E33D File Offset: 0x0000C53D
			[XmlIgnore]
			public MigrationTypeOption DefaultOption { get; set; } = MigrationTypeOption.Nothing;

			// Token: 0x1700027A RID: 634
			// (get) Token: 0x06000638 RID: 1592 RVA: 0x0000E348 File Offset: 0x0000C548
			// (set) Token: 0x06000639 RID: 1593 RVA: 0x0000E374 File Offset: 0x0000C574
			[XmlAttribute]
			public string Items
			{
				get
				{
					if (this.DefaultOption == MigrationTypeOption.Nothing)
					{
						return null;
					}
					return this.DefaultOption.ToString();
				}
				set
				{
					if (string.IsNullOrWhiteSpace(value))
					{
						this.DefaultOption = MigrationTypeOption.Nothing;
						return;
					}
					try
					{
						this.DefaultOption = (MigrationTypeOption)Enum.Parse(typeof(MigrationTypeOption), value);
					}
					catch
					{
						this.DefaultOption = MigrationTypeOption.Nothing;
					}
				}
			}

			// Token: 0x1700027B RID: 635
			// (get) Token: 0x0600063A RID: 1594 RVA: 0x0000E3CC File Offset: 0x0000C5CC
			// (set) Token: 0x0600063B RID: 1595 RVA: 0x0000E3D4 File Offset: 0x0000C5D4
			public EnginePolicy.EnableItem Migration { get; set; } = new EnginePolicy.EnableItem();

			// Token: 0x1700027C RID: 636
			// (get) Token: 0x0600063C RID: 1596 RVA: 0x0000E3DD File Offset: 0x0000C5DD
			// (set) Token: 0x0600063D RID: 1597 RVA: 0x0000E3E5 File Offset: 0x0000C5E5
			public EnginePolicy.EnableItem WinUpgrade { get; set; } = new EnginePolicy.EnableItem();

			// Token: 0x1700027D RID: 637
			// (get) Token: 0x0600063E RID: 1598 RVA: 0x0000E3EE File Offset: 0x0000C5EE
			// (set) Token: 0x0600063F RID: 1599 RVA: 0x0000E3F6 File Offset: 0x0000C5F6
			public EnginePolicy.MigTypeImage Image { get; set; } = new EnginePolicy.MigTypeImage();

			// Token: 0x1700027E RID: 638
			// (get) Token: 0x06000640 RID: 1600 RVA: 0x0000E3FF File Offset: 0x0000C5FF
			// (set) Token: 0x06000641 RID: 1601 RVA: 0x0000E407 File Offset: 0x0000C607
			public EnginePolicy.EnableItem Undo { get; set; } = new EnginePolicy.EnableItem();

			// Token: 0x1700027F RID: 639
			// (get) Token: 0x06000642 RID: 1602 RVA: 0x0000E410 File Offset: 0x0000C610
			// (set) Token: 0x06000643 RID: 1603 RVA: 0x0000E418 File Offset: 0x0000C618
			public EnginePolicy.EnableItem Profile { get; set; } = new EnginePolicy.EnableItem();

			// Token: 0x17000280 RID: 640
			// (get) Token: 0x06000644 RID: 1604 RVA: 0x0000E421 File Offset: 0x0000C621
			// (set) Token: 0x06000645 RID: 1605 RVA: 0x0000E429 File Offset: 0x0000C629
			public EnginePolicy.EnableItem FileBased { get; set; } = new EnginePolicy.EnableItem();
		}

		// Token: 0x020000B1 RID: 177
		public class MigTypeImage : EnginePolicy.EnableItem
		{
			// Token: 0x17000281 RID: 641
			// (get) Token: 0x06000647 RID: 1607 RVA: 0x0000E490 File Offset: 0x0000C690
			// (set) Token: 0x06000648 RID: 1608 RVA: 0x0000E498 File Offset: 0x0000C698
			[XmlIgnore]
			public bool? Interactive { get; set; } = new bool?(true);

			// Token: 0x17000282 RID: 642
			// (get) Token: 0x06000649 RID: 1609 RVA: 0x0000E4A4 File Offset: 0x0000C6A4
			// (set) Token: 0x0600064A RID: 1610 RVA: 0x0000E4D8 File Offset: 0x0000C6D8
			[XmlAttribute("Interactive")]
			public string InteractiveString
			{
				get
				{
					if (this.Interactive == null)
					{
						return null;
					}
					return this.Interactive.ToString();
				}
				set
				{
					this.Interactive = (string.IsNullOrEmpty(value) ? null : new bool?(bool.Parse(value)));
				}
			}

			// Token: 0x17000283 RID: 643
			// (get) Token: 0x0600064B RID: 1611 RVA: 0x0000E509 File Offset: 0x0000C709
			// (set) Token: 0x0600064C RID: 1612 RVA: 0x0000E511 File Offset: 0x0000C711
			public string Windows { get; set; }

			// Token: 0x17000284 RID: 644
			// (get) Token: 0x0600064D RID: 1613 RVA: 0x0000E51A File Offset: 0x0000C71A
			// (set) Token: 0x0600064E RID: 1614 RVA: 0x0000E522 File Offset: 0x0000C722
			public string Name { get; set; }

			// Token: 0x17000285 RID: 645
			// (get) Token: 0x0600064F RID: 1615 RVA: 0x0000E52B File Offset: 0x0000C72B
			// (set) Token: 0x06000650 RID: 1616 RVA: 0x0000E533 File Offset: 0x0000C733
			[XmlElement("VirtualDisk")]
			public ObservableCollection<EnginePolicy.VirtualToPhysical> DiskMapping { get; set; } = new ObservableCollection<EnginePolicy.VirtualToPhysical>();
		}

		// Token: 0x020000B2 RID: 178
		public class VirtualToPhysical
		{
			// Token: 0x06000652 RID: 1618 RVA: 0x000021D2 File Offset: 0x000003D2
			public VirtualToPhysical()
			{
			}

			// Token: 0x06000653 RID: 1619 RVA: 0x0000E55B File Offset: 0x0000C75B
			public VirtualToPhysical(ImageFolderMapping mapping)
			{
				this.VStr = mapping.VStr;
				this.PStr = mapping.PStr;
			}

			// Token: 0x17000286 RID: 646
			// (get) Token: 0x06000654 RID: 1620 RVA: 0x0000E57B File Offset: 0x0000C77B
			[XmlIgnore]
			public bool IsDriveC
			{
				get
				{
					return string.Compare(this.VStr, "C:\\", true) == 0;
				}
			}

			// Token: 0x17000287 RID: 647
			// (get) Token: 0x06000655 RID: 1621 RVA: 0x0000E591 File Offset: 0x0000C791
			// (set) Token: 0x06000656 RID: 1622 RVA: 0x0000E599 File Offset: 0x0000C799
			[XmlAttribute("Dir")]
			public string VStr { get; set; }

			// Token: 0x17000288 RID: 648
			// (get) Token: 0x06000657 RID: 1623 RVA: 0x0000E5A2 File Offset: 0x0000C7A2
			// (set) Token: 0x06000658 RID: 1624 RVA: 0x0000E5AA File Offset: 0x0000C7AA
			[XmlText]
			public string PStr { get; set; }
		}

		// Token: 0x020000B3 RID: 179
		public class DoneMigrationPolicy : EnginePolicy.InteractiveItem
		{
			// Token: 0x17000289 RID: 649
			// (get) Token: 0x06000659 RID: 1625 RVA: 0x0000E5B3 File Offset: 0x0000C7B3
			// (set) Token: 0x0600065A RID: 1626 RVA: 0x0000E5BB File Offset: 0x0000C7BB
			public EnginePolicy.NullableBoolTextModifyItem Reboot { get; set; } = new EnginePolicy.NullableBoolTextModifyItem();

			// Token: 0x1700028A RID: 650
			// (get) Token: 0x0600065B RID: 1627 RVA: 0x0000E5C4 File Offset: 0x0000C7C4
			// (set) Token: 0x0600065C RID: 1628 RVA: 0x0000E5CC File Offset: 0x0000C7CC
			public EnginePolicy.NullableBoolTextModifyItem UploadReport { get; set; } = new EnginePolicy.NullableBoolTextModifyItem();

			// Token: 0x0600065D RID: 1629 RVA: 0x0000E5D8 File Offset: 0x0000C7D8
			public bool ShouldSerializeReboot()
			{
				return this.Reboot.Value != null;
			}

			// Token: 0x0600065E RID: 1630 RVA: 0x0000E5F8 File Offset: 0x0000C7F8
			public bool ShouldSerializeUploadReport()
			{
				return this.UploadReport.Value != null;
			}

			// Token: 0x0600065F RID: 1631 RVA: 0x0000E618 File Offset: 0x0000C818
			internal bool ShouldSerialize()
			{
				return base.Interactive != null || this.ShouldSerializeReboot() || this.ShouldSerializeUploadReport();
			}
		}

		// Token: 0x020000B4 RID: 180
		public class MigItemsPolicy
		{
			// Token: 0x1700028B RID: 651
			// (get) Token: 0x06000661 RID: 1633 RVA: 0x0000E663 File Offset: 0x0000C863
			// (set) Token: 0x06000662 RID: 1634 RVA: 0x0000E66B File Offset: 0x0000C86B
			[XmlIgnore]
			public MigrationItemsOption? DefaultOption { get; set; }

			// Token: 0x1700028C RID: 652
			// (get) Token: 0x06000663 RID: 1635 RVA: 0x0000E674 File Offset: 0x0000C874
			// (set) Token: 0x06000664 RID: 1636 RVA: 0x0000E6B0 File Offset: 0x0000C8B0
			[XmlAttribute]
			public string Items
			{
				get
				{
					if (this.DefaultOption == null)
					{
						return null;
					}
					return this.DefaultOption.Value.ToString();
				}
				set
				{
					if (string.IsNullOrWhiteSpace(value))
					{
						this.DefaultOption = null;
						return;
					}
					try
					{
						this.DefaultOption = new MigrationItemsOption?((MigrationItemsOption)Enum.Parse(typeof(MigrationItemsOption), value));
					}
					catch
					{
						this.DefaultOption = null;
					}
				}
			}

			// Token: 0x1700028D RID: 653
			// (get) Token: 0x06000665 RID: 1637 RVA: 0x0000E71C File Offset: 0x0000C91C
			// (set) Token: 0x06000666 RID: 1638 RVA: 0x0000E724 File Offset: 0x0000C924
			public EnginePolicy.EnableItem All { get; set; } = new EnginePolicy.EnableItem();

			// Token: 0x1700028E RID: 654
			// (get) Token: 0x06000667 RID: 1639 RVA: 0x0000E72D File Offset: 0x0000C92D
			// (set) Token: 0x06000668 RID: 1640 RVA: 0x0000E735 File Offset: 0x0000C935
			public EnginePolicy.EnableItem FilesAndSettings { get; set; } = new EnginePolicy.EnableItem();

			// Token: 0x1700028F RID: 655
			// (get) Token: 0x06000669 RID: 1641 RVA: 0x0000E73E File Offset: 0x0000C93E
			// (set) Token: 0x0600066A RID: 1642 RVA: 0x0000E746 File Offset: 0x0000C946
			public EnginePolicy.EnableItem FilesOnly { get; set; } = new EnginePolicy.EnableItem();
		}
	}
}
