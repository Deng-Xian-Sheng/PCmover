using System;
using System.Collections.Generic;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000121 RID: 289
	public class StockIcons
	{
		// Token: 0x06000C97 RID: 3223 RVA: 0x0002FBD0 File Offset: 0x0002DDD0
		public StockIcons()
		{
			this.stockIconCache = new Dictionary<StockIconIdentifier, StockIcon>();
			Array values = Enum.GetValues(typeof(StockIconIdentifier));
			foreach (object obj in values)
			{
				StockIconIdentifier key = (StockIconIdentifier)obj;
				this.stockIconCache.Add(key, null);
			}
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x0002FC68 File Offset: 0x0002DE68
		public StockIcons(StockIconSize size, bool linkOverlay, bool selected)
		{
			this.defaultSize = size;
			this.isLinkOverlay = linkOverlay;
			this.isSelected = selected;
			this.stockIconCache = new Dictionary<StockIconIdentifier, StockIcon>();
			Array values = Enum.GetValues(typeof(StockIconIdentifier));
			foreach (object obj in values)
			{
				StockIconIdentifier key = (StockIconIdentifier)obj;
				this.stockIconCache.Add(key, null);
			}
		}

		// Token: 0x170007C1 RID: 1985
		// (get) Token: 0x06000C99 RID: 3225 RVA: 0x0002FD14 File Offset: 0x0002DF14
		public StockIconSize DefaultSize
		{
			get
			{
				return this.defaultSize;
			}
		}

		// Token: 0x170007C2 RID: 1986
		// (get) Token: 0x06000C9A RID: 3226 RVA: 0x0002FD2C File Offset: 0x0002DF2C
		public bool DefaultLinkOverlay
		{
			get
			{
				return this.isLinkOverlay;
			}
		}

		// Token: 0x170007C3 RID: 1987
		// (get) Token: 0x06000C9B RID: 3227 RVA: 0x0002FD44 File Offset: 0x0002DF44
		public bool DefaultSelectedState
		{
			get
			{
				return this.isSelected;
			}
		}

		// Token: 0x170007C4 RID: 1988
		// (get) Token: 0x06000C9C RID: 3228 RVA: 0x0002FD5C File Offset: 0x0002DF5C
		public ICollection<StockIcon> AllStockIcons
		{
			get
			{
				return this.GetAllStockIcons();
			}
		}

		// Token: 0x170007C5 RID: 1989
		// (get) Token: 0x06000C9D RID: 3229 RVA: 0x0002FD74 File Offset: 0x0002DF74
		public StockIcon DocumentNotAssociated
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DocumentNotAssociated);
			}
		}

		// Token: 0x170007C6 RID: 1990
		// (get) Token: 0x06000C9E RID: 3230 RVA: 0x0002FD90 File Offset: 0x0002DF90
		public StockIcon DocumentAssociated
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DocumentAssociated);
			}
		}

		// Token: 0x170007C7 RID: 1991
		// (get) Token: 0x06000C9F RID: 3231 RVA: 0x0002FDAC File Offset: 0x0002DFAC
		public StockIcon Application
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Application);
			}
		}

		// Token: 0x170007C8 RID: 1992
		// (get) Token: 0x06000CA0 RID: 3232 RVA: 0x0002FDC8 File Offset: 0x0002DFC8
		public StockIcon Folder
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Folder);
			}
		}

		// Token: 0x170007C9 RID: 1993
		// (get) Token: 0x06000CA1 RID: 3233 RVA: 0x0002FDE4 File Offset: 0x0002DFE4
		public StockIcon FolderOpen
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.FolderOpen);
			}
		}

		// Token: 0x170007CA RID: 1994
		// (get) Token: 0x06000CA2 RID: 3234 RVA: 0x0002FE00 File Offset: 0x0002E000
		public StockIcon Drive525
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Drive525);
			}
		}

		// Token: 0x170007CB RID: 1995
		// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x0002FE1C File Offset: 0x0002E01C
		public StockIcon Drive35
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Drive35);
			}
		}

		// Token: 0x170007CC RID: 1996
		// (get) Token: 0x06000CA4 RID: 3236 RVA: 0x0002FE38 File Offset: 0x0002E038
		public StockIcon DriveRemove
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DriveRemove);
			}
		}

		// Token: 0x170007CD RID: 1997
		// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x0002FE54 File Offset: 0x0002E054
		public StockIcon DriveFixed
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DriveFixed);
			}
		}

		// Token: 0x170007CE RID: 1998
		// (get) Token: 0x06000CA6 RID: 3238 RVA: 0x0002FE70 File Offset: 0x0002E070
		public StockIcon DriveNetwork
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DriveNetwork);
			}
		}

		// Token: 0x170007CF RID: 1999
		// (get) Token: 0x06000CA7 RID: 3239 RVA: 0x0002FE8C File Offset: 0x0002E08C
		public StockIcon DriveNetworkDisabled
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DriveNetworkDisabled);
			}
		}

		// Token: 0x170007D0 RID: 2000
		// (get) Token: 0x06000CA8 RID: 3240 RVA: 0x0002FEA8 File Offset: 0x0002E0A8
		public StockIcon DriveCD
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DriveCD);
			}
		}

		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x0002FEC4 File Offset: 0x0002E0C4
		public StockIcon DriveRam
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DriveRam);
			}
		}

		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x06000CAA RID: 3242 RVA: 0x0002FEE0 File Offset: 0x0002E0E0
		public StockIcon World
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.World);
			}
		}

		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x06000CAB RID: 3243 RVA: 0x0002FEFC File Offset: 0x0002E0FC
		public StockIcon Server
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Server);
			}
		}

		// Token: 0x170007D4 RID: 2004
		// (get) Token: 0x06000CAC RID: 3244 RVA: 0x0002FF18 File Offset: 0x0002E118
		public StockIcon Printer
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Printer);
			}
		}

		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x06000CAD RID: 3245 RVA: 0x0002FF34 File Offset: 0x0002E134
		public StockIcon MyNetwork
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MyNetwork);
			}
		}

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x06000CAE RID: 3246 RVA: 0x0002FF50 File Offset: 0x0002E150
		public StockIcon Find
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Find);
			}
		}

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x0002FF6C File Offset: 0x0002E16C
		public StockIcon Help
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Help);
			}
		}

		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x06000CB0 RID: 3248 RVA: 0x0002FF88 File Offset: 0x0002E188
		public StockIcon Share
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Share);
			}
		}

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x06000CB1 RID: 3249 RVA: 0x0002FFA4 File Offset: 0x0002E1A4
		public StockIcon Link
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Link);
			}
		}

		// Token: 0x170007DA RID: 2010
		// (get) Token: 0x06000CB2 RID: 3250 RVA: 0x0002FFC0 File Offset: 0x0002E1C0
		public StockIcon SlowFile
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.SlowFile);
			}
		}

		// Token: 0x170007DB RID: 2011
		// (get) Token: 0x06000CB3 RID: 3251 RVA: 0x0002FFDC File Offset: 0x0002E1DC
		public StockIcon Recycler
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Recycler);
			}
		}

		// Token: 0x170007DC RID: 2012
		// (get) Token: 0x06000CB4 RID: 3252 RVA: 0x0002FFF8 File Offset: 0x0002E1F8
		public StockIcon RecyclerFull
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.RecyclerFull);
			}
		}

		// Token: 0x170007DD RID: 2013
		// (get) Token: 0x06000CB5 RID: 3253 RVA: 0x00030014 File Offset: 0x0002E214
		public StockIcon MediaCDAudio
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaCDAudio);
			}
		}

		// Token: 0x170007DE RID: 2014
		// (get) Token: 0x06000CB6 RID: 3254 RVA: 0x00030030 File Offset: 0x0002E230
		public StockIcon Lock
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Lock);
			}
		}

		// Token: 0x170007DF RID: 2015
		// (get) Token: 0x06000CB7 RID: 3255 RVA: 0x0003004C File Offset: 0x0002E24C
		public StockIcon AutoList
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.AutoList);
			}
		}

		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x06000CB8 RID: 3256 RVA: 0x00030068 File Offset: 0x0002E268
		public StockIcon PrinterNet
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.PrinterNet);
			}
		}

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x06000CB9 RID: 3257 RVA: 0x00030084 File Offset: 0x0002E284
		public StockIcon ServerShare
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.ServerShare);
			}
		}

		// Token: 0x170007E2 RID: 2018
		// (get) Token: 0x06000CBA RID: 3258 RVA: 0x000300A0 File Offset: 0x0002E2A0
		public StockIcon PrinterFax
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.PrinterFax);
			}
		}

		// Token: 0x170007E3 RID: 2019
		// (get) Token: 0x06000CBB RID: 3259 RVA: 0x000300BC File Offset: 0x0002E2BC
		public StockIcon PrinterFaxNet
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.PrinterFaxNet);
			}
		}

		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x06000CBC RID: 3260 RVA: 0x000300D8 File Offset: 0x0002E2D8
		public StockIcon PrinterFile
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.PrinterFile);
			}
		}

		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x06000CBD RID: 3261 RVA: 0x000300F4 File Offset: 0x0002E2F4
		public StockIcon Stack
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Stack);
			}
		}

		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x06000CBE RID: 3262 RVA: 0x00030110 File Offset: 0x0002E310
		public StockIcon MediaSvcd
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaSvcd);
			}
		}

		// Token: 0x170007E7 RID: 2023
		// (get) Token: 0x06000CBF RID: 3263 RVA: 0x0003012C File Offset: 0x0002E32C
		public StockIcon StuffedFolder
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.StuffedFolder);
			}
		}

		// Token: 0x170007E8 RID: 2024
		// (get) Token: 0x06000CC0 RID: 3264 RVA: 0x00030148 File Offset: 0x0002E348
		public StockIcon DriveUnknown
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DriveUnknown);
			}
		}

		// Token: 0x170007E9 RID: 2025
		// (get) Token: 0x06000CC1 RID: 3265 RVA: 0x00030164 File Offset: 0x0002E364
		public StockIcon DriveDvd
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DriveDvd);
			}
		}

		// Token: 0x170007EA RID: 2026
		// (get) Token: 0x06000CC2 RID: 3266 RVA: 0x00030180 File Offset: 0x0002E380
		public StockIcon MediaDvd
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaDvd);
			}
		}

		// Token: 0x170007EB RID: 2027
		// (get) Token: 0x06000CC3 RID: 3267 RVA: 0x0003019C File Offset: 0x0002E39C
		public StockIcon MediaDvdRam
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaDvdRam);
			}
		}

		// Token: 0x170007EC RID: 2028
		// (get) Token: 0x06000CC4 RID: 3268 RVA: 0x000301B8 File Offset: 0x0002E3B8
		public StockIcon MediaDvdRW
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaDvdRW);
			}
		}

		// Token: 0x170007ED RID: 2029
		// (get) Token: 0x06000CC5 RID: 3269 RVA: 0x000301D4 File Offset: 0x0002E3D4
		public StockIcon MediaDvdR
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaDvdR);
			}
		}

		// Token: 0x170007EE RID: 2030
		// (get) Token: 0x06000CC6 RID: 3270 RVA: 0x000301F0 File Offset: 0x0002E3F0
		public StockIcon MediaDvdRom
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaDvdRom);
			}
		}

		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x0003020C File Offset: 0x0002E40C
		public StockIcon MediaCDAudioPlus
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaCDAudioPlus);
			}
		}

		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x06000CC8 RID: 3272 RVA: 0x00030228 File Offset: 0x0002E428
		public StockIcon MediaCDRW
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaCDRW);
			}
		}

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x00030244 File Offset: 0x0002E444
		public StockIcon MediaCDR
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaCDR);
			}
		}

		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x06000CCA RID: 3274 RVA: 0x00030260 File Offset: 0x0002E460
		public StockIcon MediaCDBurn
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaCDBurn);
			}
		}

		// Token: 0x170007F3 RID: 2035
		// (get) Token: 0x06000CCB RID: 3275 RVA: 0x0003027C File Offset: 0x0002E47C
		public StockIcon MediaBlankCD
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaBlankCD);
			}
		}

		// Token: 0x170007F4 RID: 2036
		// (get) Token: 0x06000CCC RID: 3276 RVA: 0x00030298 File Offset: 0x0002E498
		public StockIcon MediaCDRom
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaCDRom);
			}
		}

		// Token: 0x170007F5 RID: 2037
		// (get) Token: 0x06000CCD RID: 3277 RVA: 0x000302B4 File Offset: 0x0002E4B4
		public StockIcon AudioFiles
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.AudioFiles);
			}
		}

		// Token: 0x170007F6 RID: 2038
		// (get) Token: 0x06000CCE RID: 3278 RVA: 0x000302D0 File Offset: 0x0002E4D0
		public StockIcon ImageFiles
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.ImageFiles);
			}
		}

		// Token: 0x170007F7 RID: 2039
		// (get) Token: 0x06000CCF RID: 3279 RVA: 0x000302EC File Offset: 0x0002E4EC
		public StockIcon VideoFiles
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.VideoFiles);
			}
		}

		// Token: 0x170007F8 RID: 2040
		// (get) Token: 0x06000CD0 RID: 3280 RVA: 0x00030308 File Offset: 0x0002E508
		public StockIcon MixedFiles
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MixedFiles);
			}
		}

		// Token: 0x170007F9 RID: 2041
		// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x00030324 File Offset: 0x0002E524
		public StockIcon FolderBack
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.FolderBack);
			}
		}

		// Token: 0x170007FA RID: 2042
		// (get) Token: 0x06000CD2 RID: 3282 RVA: 0x00030340 File Offset: 0x0002E540
		public StockIcon FolderFront
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.FolderFront);
			}
		}

		// Token: 0x170007FB RID: 2043
		// (get) Token: 0x06000CD3 RID: 3283 RVA: 0x0003035C File Offset: 0x0002E55C
		public StockIcon Shield
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Shield);
			}
		}

		// Token: 0x170007FC RID: 2044
		// (get) Token: 0x06000CD4 RID: 3284 RVA: 0x00030378 File Offset: 0x0002E578
		public StockIcon Warning
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Warning);
			}
		}

		// Token: 0x170007FD RID: 2045
		// (get) Token: 0x06000CD5 RID: 3285 RVA: 0x00030394 File Offset: 0x0002E594
		public StockIcon Info
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Info);
			}
		}

		// Token: 0x170007FE RID: 2046
		// (get) Token: 0x06000CD6 RID: 3286 RVA: 0x000303B0 File Offset: 0x0002E5B0
		public StockIcon Error
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Error);
			}
		}

		// Token: 0x170007FF RID: 2047
		// (get) Token: 0x06000CD7 RID: 3287 RVA: 0x000303CC File Offset: 0x0002E5CC
		public StockIcon Key
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Key);
			}
		}

		// Token: 0x17000800 RID: 2048
		// (get) Token: 0x06000CD8 RID: 3288 RVA: 0x000303E8 File Offset: 0x0002E5E8
		public StockIcon Software
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Software);
			}
		}

		// Token: 0x17000801 RID: 2049
		// (get) Token: 0x06000CD9 RID: 3289 RVA: 0x00030404 File Offset: 0x0002E604
		public StockIcon Rename
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Rename);
			}
		}

		// Token: 0x17000802 RID: 2050
		// (get) Token: 0x06000CDA RID: 3290 RVA: 0x00030420 File Offset: 0x0002E620
		public StockIcon Delete
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Delete);
			}
		}

		// Token: 0x17000803 RID: 2051
		// (get) Token: 0x06000CDB RID: 3291 RVA: 0x0003043C File Offset: 0x0002E63C
		public StockIcon MediaAudioDvd
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaAudioDvd);
			}
		}

		// Token: 0x17000804 RID: 2052
		// (get) Token: 0x06000CDC RID: 3292 RVA: 0x00030458 File Offset: 0x0002E658
		public StockIcon MediaMovieDvd
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaMovieDvd);
			}
		}

		// Token: 0x17000805 RID: 2053
		// (get) Token: 0x06000CDD RID: 3293 RVA: 0x00030474 File Offset: 0x0002E674
		public StockIcon MediaEnhancedCD
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaEnhancedCD);
			}
		}

		// Token: 0x17000806 RID: 2054
		// (get) Token: 0x06000CDE RID: 3294 RVA: 0x00030490 File Offset: 0x0002E690
		public StockIcon MediaEnhancedDvd
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaEnhancedDvd);
			}
		}

		// Token: 0x17000807 RID: 2055
		// (get) Token: 0x06000CDF RID: 3295 RVA: 0x000304AC File Offset: 0x0002E6AC
		public StockIcon MediaHDDvd
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaHDDvd);
			}
		}

		// Token: 0x17000808 RID: 2056
		// (get) Token: 0x06000CE0 RID: 3296 RVA: 0x000304C8 File Offset: 0x0002E6C8
		public StockIcon MediaBluRay
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaBluRay);
			}
		}

		// Token: 0x17000809 RID: 2057
		// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x000304E4 File Offset: 0x0002E6E4
		public StockIcon MediaVcd
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaVcd);
			}
		}

		// Token: 0x1700080A RID: 2058
		// (get) Token: 0x06000CE2 RID: 3298 RVA: 0x00030500 File Offset: 0x0002E700
		public StockIcon MediaDvdPlusR
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaDvdPlusR);
			}
		}

		// Token: 0x1700080B RID: 2059
		// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x0003051C File Offset: 0x0002E71C
		public StockIcon MediaDvdPlusRW
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaDvdPlusRW);
			}
		}

		// Token: 0x1700080C RID: 2060
		// (get) Token: 0x06000CE4 RID: 3300 RVA: 0x00030538 File Offset: 0x0002E738
		public StockIcon DesktopPC
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DesktopPC);
			}
		}

		// Token: 0x1700080D RID: 2061
		// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x00030554 File Offset: 0x0002E754
		public StockIcon MobilePC
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MobilePC);
			}
		}

		// Token: 0x1700080E RID: 2062
		// (get) Token: 0x06000CE6 RID: 3302 RVA: 0x00030570 File Offset: 0x0002E770
		public StockIcon Users
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Users);
			}
		}

		// Token: 0x1700080F RID: 2063
		// (get) Token: 0x06000CE7 RID: 3303 RVA: 0x0003058C File Offset: 0x0002E78C
		public StockIcon MediaSmartMedia
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaSmartMedia);
			}
		}

		// Token: 0x17000810 RID: 2064
		// (get) Token: 0x06000CE8 RID: 3304 RVA: 0x000305A8 File Offset: 0x0002E7A8
		public StockIcon MediaCompactFlash
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaCompactFlash);
			}
		}

		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x000305C4 File Offset: 0x0002E7C4
		public StockIcon DeviceCellPhone
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DeviceCellPhone);
			}
		}

		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x06000CEA RID: 3306 RVA: 0x000305E0 File Offset: 0x0002E7E0
		public StockIcon DeviceCamera
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DeviceCamera);
			}
		}

		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x06000CEB RID: 3307 RVA: 0x000305FC File Offset: 0x0002E7FC
		public StockIcon DeviceVideoCamera
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DeviceVideoCamera);
			}
		}

		// Token: 0x17000814 RID: 2068
		// (get) Token: 0x06000CEC RID: 3308 RVA: 0x00030618 File Offset: 0x0002E818
		public StockIcon DeviceAudioPlayer
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DeviceAudioPlayer);
			}
		}

		// Token: 0x17000815 RID: 2069
		// (get) Token: 0x06000CED RID: 3309 RVA: 0x00030634 File Offset: 0x0002E834
		public StockIcon NetworkConnect
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.NetworkConnect);
			}
		}

		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x06000CEE RID: 3310 RVA: 0x00030650 File Offset: 0x0002E850
		public StockIcon Internet
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Internet);
			}
		}

		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x06000CEF RID: 3311 RVA: 0x0003066C File Offset: 0x0002E86C
		public StockIcon ZipFile
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.ZipFile);
			}
		}

		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x06000CF0 RID: 3312 RVA: 0x00030688 File Offset: 0x0002E888
		public StockIcon Settings
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.Settings);
			}
		}

		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x06000CF1 RID: 3313 RVA: 0x000306A4 File Offset: 0x0002E8A4
		public StockIcon DriveHDDVD
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DriveHDDVD);
			}
		}

		// Token: 0x1700081A RID: 2074
		// (get) Token: 0x06000CF2 RID: 3314 RVA: 0x000306C4 File Offset: 0x0002E8C4
		public StockIcon DriveBluRay
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.DriveBluRay);
			}
		}

		// Token: 0x1700081B RID: 2075
		// (get) Token: 0x06000CF3 RID: 3315 RVA: 0x000306E4 File Offset: 0x0002E8E4
		public StockIcon MediaHDDVDROM
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaHDDVDROM);
			}
		}

		// Token: 0x1700081C RID: 2076
		// (get) Token: 0x06000CF4 RID: 3316 RVA: 0x00030704 File Offset: 0x0002E904
		public StockIcon MediaHDDVDR
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaHDDVDR);
			}
		}

		// Token: 0x1700081D RID: 2077
		// (get) Token: 0x06000CF5 RID: 3317 RVA: 0x00030724 File Offset: 0x0002E924
		public StockIcon MediaHDDVDRAM
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaHDDVDRAM);
			}
		}

		// Token: 0x1700081E RID: 2078
		// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x00030744 File Offset: 0x0002E944
		public StockIcon MediaBluRayROM
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaBluRayROM);
			}
		}

		// Token: 0x1700081F RID: 2079
		// (get) Token: 0x06000CF7 RID: 3319 RVA: 0x00030764 File Offset: 0x0002E964
		public StockIcon MediaBluRayR
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaBluRayR);
			}
		}

		// Token: 0x17000820 RID: 2080
		// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x00030784 File Offset: 0x0002E984
		public StockIcon MediaBluRayRE
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.MediaBluRayRE);
			}
		}

		// Token: 0x17000821 RID: 2081
		// (get) Token: 0x06000CF9 RID: 3321 RVA: 0x000307A4 File Offset: 0x0002E9A4
		public StockIcon ClusteredDisk
		{
			get
			{
				return this.GetStockIcon(StockIconIdentifier.ClusteredDisk);
			}
		}

		// Token: 0x06000CFA RID: 3322 RVA: 0x000307C4 File Offset: 0x0002E9C4
		private StockIcon GetStockIcon(StockIconIdentifier stockIconIdentifier)
		{
			StockIcon result;
			if (this.stockIconCache[stockIconIdentifier] != null)
			{
				result = this.stockIconCache[stockIconIdentifier];
			}
			else
			{
				StockIcon stockIcon = new StockIcon(stockIconIdentifier, this.defaultSize, this.isLinkOverlay, this.isSelected);
				try
				{
					this.stockIconCache[stockIconIdentifier] = stockIcon;
				}
				catch
				{
					stockIcon.Dispose();
					throw;
				}
				result = stockIcon;
			}
			return result;
		}

		// Token: 0x06000CFB RID: 3323 RVA: 0x00030844 File Offset: 0x0002EA44
		private ICollection<StockIcon> GetAllStockIcons()
		{
			StockIconIdentifier[] array = new StockIconIdentifier[this.stockIconCache.Count];
			this.stockIconCache.Keys.CopyTo(array, 0);
			foreach (StockIconIdentifier stockIconIdentifier in array)
			{
				if (this.stockIconCache[stockIconIdentifier] == null)
				{
					this.GetStockIcon(stockIconIdentifier);
				}
			}
			return this.stockIconCache.Values;
		}

		// Token: 0x040004EA RID: 1258
		private IDictionary<StockIconIdentifier, StockIcon> stockIconCache;

		// Token: 0x040004EB RID: 1259
		private StockIconSize defaultSize = StockIconSize.Large;

		// Token: 0x040004EC RID: 1260
		private bool isSelected;

		// Token: 0x040004ED RID: 1261
		private bool isLinkOverlay;
	}
}
