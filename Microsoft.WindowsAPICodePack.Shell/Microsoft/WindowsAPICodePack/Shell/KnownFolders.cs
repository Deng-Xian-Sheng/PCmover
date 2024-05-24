using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000065 RID: 101
	public static class KnownFolders
	{
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600030F RID: 783 RVA: 0x0000CE40 File Offset: 0x0000B040
		public static ICollection<IKnownFolder> All
		{
			get
			{
				return KnownFolders.GetAllFolders();
			}
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000CE58 File Offset: 0x0000B058
		private static ReadOnlyCollection<IKnownFolder> GetAllFolders()
		{
			IList<IKnownFolder> list = new List<IKnownFolder>();
			IntPtr zero = IntPtr.Zero;
			try
			{
				KnownFolderManagerClass knownFolderManagerClass = new KnownFolderManagerClass();
				uint num;
				knownFolderManagerClass.GetFolderIds(out zero, out num);
				if (num > 0U && zero != IntPtr.Zero)
				{
					int num2 = 0;
					while ((long)num2 < (long)((ulong)num))
					{
						IntPtr ptr = new IntPtr(zero.ToInt64() + (long)(Marshal.SizeOf(typeof(Guid)) * num2));
						Guid knownFolderId = (Guid)Marshal.PtrToStructure(ptr, typeof(Guid));
						IKnownFolder knownFolder = KnownFolderHelper.FromKnownFolderIdInternal(knownFolderId);
						if (knownFolder != null)
						{
							list.Add(knownFolder);
						}
						num2++;
					}
				}
			}
			finally
			{
				if (zero != IntPtr.Zero)
				{
					Marshal.FreeCoTaskMem(zero);
				}
			}
			return new ReadOnlyCollection<IKnownFolder>(list);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0000CF58 File Offset: 0x0000B158
		private static IKnownFolder GetKnownFolder(Guid guid)
		{
			return KnownFolderHelper.FromKnownFolderId(guid);
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000312 RID: 786 RVA: 0x0000CF70 File Offset: 0x0000B170
		public static IKnownFolder Computer
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Computer);
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000313 RID: 787 RVA: 0x0000CF8C File Offset: 0x0000B18C
		public static IKnownFolder Conflict
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Conflict);
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000314 RID: 788 RVA: 0x0000CFA8 File Offset: 0x0000B1A8
		public static IKnownFolder ControlPanel
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.ControlPanel);
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000315 RID: 789 RVA: 0x0000CFC4 File Offset: 0x0000B1C4
		public static IKnownFolder Desktop
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Desktop);
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000316 RID: 790 RVA: 0x0000CFE0 File Offset: 0x0000B1E0
		public static IKnownFolder Internet
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Internet);
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000317 RID: 791 RVA: 0x0000CFFC File Offset: 0x0000B1FC
		public static IKnownFolder Network
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Network);
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000318 RID: 792 RVA: 0x0000D018 File Offset: 0x0000B218
		public static IKnownFolder Printers
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Printers);
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000319 RID: 793 RVA: 0x0000D034 File Offset: 0x0000B234
		public static IKnownFolder SyncManager
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SyncManager);
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x0600031A RID: 794 RVA: 0x0000D050 File Offset: 0x0000B250
		public static IKnownFolder Connections
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Connections);
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600031B RID: 795 RVA: 0x0000D06C File Offset: 0x0000B26C
		public static IKnownFolder SyncSetup
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SyncSetup);
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600031C RID: 796 RVA: 0x0000D088 File Offset: 0x0000B288
		public static IKnownFolder SyncResults
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SyncResults);
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600031D RID: 797 RVA: 0x0000D0A4 File Offset: 0x0000B2A4
		public static IKnownFolder RecycleBin
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.RecycleBin);
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600031E RID: 798 RVA: 0x0000D0C0 File Offset: 0x0000B2C0
		public static IKnownFolder Fonts
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Fonts);
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600031F RID: 799 RVA: 0x0000D0DC File Offset: 0x0000B2DC
		public static IKnownFolder Startup
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Startup);
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000320 RID: 800 RVA: 0x0000D0F8 File Offset: 0x0000B2F8
		public static IKnownFolder Programs
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Programs);
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000321 RID: 801 RVA: 0x0000D114 File Offset: 0x0000B314
		public static IKnownFolder StartMenu
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.StartMenu);
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000322 RID: 802 RVA: 0x0000D130 File Offset: 0x0000B330
		public static IKnownFolder Recent
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Recent);
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000323 RID: 803 RVA: 0x0000D14C File Offset: 0x0000B34C
		public static IKnownFolder SendTo
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SendTo);
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000324 RID: 804 RVA: 0x0000D168 File Offset: 0x0000B368
		public static IKnownFolder Documents
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Documents);
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000325 RID: 805 RVA: 0x0000D184 File Offset: 0x0000B384
		public static IKnownFolder Favorites
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Favorites);
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000326 RID: 806 RVA: 0x0000D1A0 File Offset: 0x0000B3A0
		public static IKnownFolder NetHood
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.NetHood);
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000327 RID: 807 RVA: 0x0000D1BC File Offset: 0x0000B3BC
		public static IKnownFolder PrintHood
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.PrintHood);
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000328 RID: 808 RVA: 0x0000D1D8 File Offset: 0x0000B3D8
		public static IKnownFolder Templates
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Templates);
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000329 RID: 809 RVA: 0x0000D1F4 File Offset: 0x0000B3F4
		public static IKnownFolder CommonStartup
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.CommonStartup);
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600032A RID: 810 RVA: 0x0000D210 File Offset: 0x0000B410
		public static IKnownFolder CommonPrograms
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.CommonPrograms);
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600032B RID: 811 RVA: 0x0000D22C File Offset: 0x0000B42C
		public static IKnownFolder CommonStartMenu
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.CommonStartMenu);
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600032C RID: 812 RVA: 0x0000D248 File Offset: 0x0000B448
		public static IKnownFolder PublicDesktop
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.PublicDesktop);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600032D RID: 813 RVA: 0x0000D264 File Offset: 0x0000B464
		public static IKnownFolder ProgramData
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.ProgramData);
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600032E RID: 814 RVA: 0x0000D280 File Offset: 0x0000B480
		public static IKnownFolder CommonTemplates
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.CommonTemplates);
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600032F RID: 815 RVA: 0x0000D29C File Offset: 0x0000B49C
		public static IKnownFolder PublicDocuments
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.PublicDocuments);
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000330 RID: 816 RVA: 0x0000D2B8 File Offset: 0x0000B4B8
		public static IKnownFolder RoamingAppData
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.RoamingAppData);
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000331 RID: 817 RVA: 0x0000D2D4 File Offset: 0x0000B4D4
		public static IKnownFolder LocalAppData
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.LocalAppData);
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000332 RID: 818 RVA: 0x0000D2F0 File Offset: 0x0000B4F0
		public static IKnownFolder LocalAppDataLow
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.LocalAppDataLow);
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000333 RID: 819 RVA: 0x0000D30C File Offset: 0x0000B50C
		public static IKnownFolder InternetCache
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.InternetCache);
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000334 RID: 820 RVA: 0x0000D328 File Offset: 0x0000B528
		public static IKnownFolder Cookies
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Cookies);
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000335 RID: 821 RVA: 0x0000D344 File Offset: 0x0000B544
		public static IKnownFolder History
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.History);
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000336 RID: 822 RVA: 0x0000D360 File Offset: 0x0000B560
		public static IKnownFolder System
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.System);
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000337 RID: 823 RVA: 0x0000D37C File Offset: 0x0000B57C
		public static IKnownFolder SystemX86
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SystemX86);
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000338 RID: 824 RVA: 0x0000D398 File Offset: 0x0000B598
		public static IKnownFolder Windows
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Windows);
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000339 RID: 825 RVA: 0x0000D3B4 File Offset: 0x0000B5B4
		public static IKnownFolder Profile
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Profile);
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600033A RID: 826 RVA: 0x0000D3D0 File Offset: 0x0000B5D0
		public static IKnownFolder Pictures
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Pictures);
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600033B RID: 827 RVA: 0x0000D3EC File Offset: 0x0000B5EC
		public static IKnownFolder ProgramFilesX86
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.ProgramFilesX86);
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600033C RID: 828 RVA: 0x0000D408 File Offset: 0x0000B608
		public static IKnownFolder ProgramFilesCommonX86
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.ProgramFilesCommonX86);
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600033D RID: 829 RVA: 0x0000D424 File Offset: 0x0000B624
		public static IKnownFolder ProgramFilesX64
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.ProgramFilesX64);
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600033E RID: 830 RVA: 0x0000D440 File Offset: 0x0000B640
		public static IKnownFolder ProgramFilesCommonX64
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.ProgramFilesCommonX64);
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600033F RID: 831 RVA: 0x0000D45C File Offset: 0x0000B65C
		public static IKnownFolder ProgramFiles
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.ProgramFiles);
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000340 RID: 832 RVA: 0x0000D478 File Offset: 0x0000B678
		public static IKnownFolder ProgramFilesCommon
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.ProgramFilesCommon);
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000341 RID: 833 RVA: 0x0000D494 File Offset: 0x0000B694
		public static IKnownFolder AdminTools
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.AdminTools);
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000342 RID: 834 RVA: 0x0000D4B0 File Offset: 0x0000B6B0
		public static IKnownFolder CommonAdminTools
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.CommonAdminTools);
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000343 RID: 835 RVA: 0x0000D4CC File Offset: 0x0000B6CC
		public static IKnownFolder Music
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Music);
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000344 RID: 836 RVA: 0x0000D4E8 File Offset: 0x0000B6E8
		public static IKnownFolder Videos
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Videos);
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000345 RID: 837 RVA: 0x0000D504 File Offset: 0x0000B704
		public static IKnownFolder PublicPictures
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.PublicPictures);
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000346 RID: 838 RVA: 0x0000D520 File Offset: 0x0000B720
		public static IKnownFolder PublicMusic
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.PublicMusic);
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000347 RID: 839 RVA: 0x0000D53C File Offset: 0x0000B73C
		public static IKnownFolder PublicVideos
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.PublicVideos);
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000348 RID: 840 RVA: 0x0000D558 File Offset: 0x0000B758
		public static IKnownFolder ResourceDir
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.ResourceDir);
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000349 RID: 841 RVA: 0x0000D574 File Offset: 0x0000B774
		public static IKnownFolder LocalizedResourcesDir
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.LocalizedResourcesDir);
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600034A RID: 842 RVA: 0x0000D590 File Offset: 0x0000B790
		public static IKnownFolder CommonOemLinks
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.CommonOEMLinks);
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600034B RID: 843 RVA: 0x0000D5AC File Offset: 0x0000B7AC
		public static IKnownFolder CDBurning
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.CDBurning);
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600034C RID: 844 RVA: 0x0000D5C8 File Offset: 0x0000B7C8
		public static IKnownFolder UserProfiles
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.UserProfiles);
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600034D RID: 845 RVA: 0x0000D5E4 File Offset: 0x0000B7E4
		public static IKnownFolder Playlists
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Playlists);
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600034E RID: 846 RVA: 0x0000D600 File Offset: 0x0000B800
		public static IKnownFolder SamplePlaylists
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SamplePlaylists);
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600034F RID: 847 RVA: 0x0000D61C File Offset: 0x0000B81C
		public static IKnownFolder SampleMusic
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SampleMusic);
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000350 RID: 848 RVA: 0x0000D638 File Offset: 0x0000B838
		public static IKnownFolder SamplePictures
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SamplePictures);
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000351 RID: 849 RVA: 0x0000D654 File Offset: 0x0000B854
		public static IKnownFolder SampleVideos
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SampleVideos);
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000352 RID: 850 RVA: 0x0000D670 File Offset: 0x0000B870
		public static IKnownFolder PhotoAlbums
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.PhotoAlbums);
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000353 RID: 851 RVA: 0x0000D68C File Offset: 0x0000B88C
		public static IKnownFolder Public
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Public);
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000354 RID: 852 RVA: 0x0000D6A8 File Offset: 0x0000B8A8
		public static IKnownFolder ChangeRemovePrograms
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.ChangeRemovePrograms);
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000355 RID: 853 RVA: 0x0000D6C4 File Offset: 0x0000B8C4
		public static IKnownFolder AppUpdates
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.AppUpdates);
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000356 RID: 854 RVA: 0x0000D6E0 File Offset: 0x0000B8E0
		public static IKnownFolder AddNewPrograms
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.AddNewPrograms);
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000357 RID: 855 RVA: 0x0000D6FC File Offset: 0x0000B8FC
		public static IKnownFolder Downloads
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Downloads);
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000358 RID: 856 RVA: 0x0000D718 File Offset: 0x0000B918
		public static IKnownFolder PublicDownloads
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.PublicDownloads);
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000359 RID: 857 RVA: 0x0000D734 File Offset: 0x0000B934
		public static IKnownFolder SavedSearches
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SavedSearches);
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x0600035A RID: 858 RVA: 0x0000D750 File Offset: 0x0000B950
		public static IKnownFolder QuickLaunch
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.QuickLaunch);
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x0600035B RID: 859 RVA: 0x0000D76C File Offset: 0x0000B96C
		public static IKnownFolder Contacts
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Contacts);
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600035C RID: 860 RVA: 0x0000D788 File Offset: 0x0000B988
		public static IKnownFolder SidebarParts
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SidebarParts);
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600035D RID: 861 RVA: 0x0000D7A4 File Offset: 0x0000B9A4
		public static IKnownFolder SidebarDefaultParts
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SidebarDefaultParts);
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600035E RID: 862 RVA: 0x0000D7C0 File Offset: 0x0000B9C0
		public static IKnownFolder TreeProperties
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.TreeProperties);
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x0600035F RID: 863 RVA: 0x0000D7DC File Offset: 0x0000B9DC
		public static IKnownFolder PublicGameTasks
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.PublicGameTasks);
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000360 RID: 864 RVA: 0x0000D7F8 File Offset: 0x0000B9F8
		public static IKnownFolder GameTasks
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.GameTasks);
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000361 RID: 865 RVA: 0x0000D814 File Offset: 0x0000BA14
		public static IKnownFolder SavedGames
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SavedGames);
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000362 RID: 866 RVA: 0x0000D830 File Offset: 0x0000BA30
		public static IKnownFolder Games
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Games);
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000363 RID: 867 RVA: 0x0000D84C File Offset: 0x0000BA4C
		public static IKnownFolder RecordedTV
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.RecordedTV);
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000364 RID: 868 RVA: 0x0000D868 File Offset: 0x0000BA68
		public static IKnownFolder SearchMapi
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SearchMapi);
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000365 RID: 869 RVA: 0x0000D884 File Offset: 0x0000BA84
		public static IKnownFolder SearchCsc
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SearchCsc);
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000366 RID: 870 RVA: 0x0000D8A0 File Offset: 0x0000BAA0
		public static IKnownFolder Links
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Links);
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000367 RID: 871 RVA: 0x0000D8BC File Offset: 0x0000BABC
		public static IKnownFolder UsersFiles
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.UsersFiles);
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000368 RID: 872 RVA: 0x0000D8D8 File Offset: 0x0000BAD8
		public static IKnownFolder SearchHome
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.SearchHome);
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000369 RID: 873 RVA: 0x0000D8F4 File Offset: 0x0000BAF4
		public static IKnownFolder OriginalImages
		{
			get
			{
				return KnownFolders.GetKnownFolder(FolderIdentifiers.OriginalImages);
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600036A RID: 874 RVA: 0x0000D910 File Offset: 0x0000BB10
		public static IKnownFolder UserProgramFiles
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.UserProgramFiles);
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600036B RID: 875 RVA: 0x0000D934 File Offset: 0x0000BB34
		public static IKnownFolder UserProgramFilesCommon
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.UserProgramFilesCommon);
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x0600036C RID: 876 RVA: 0x0000D958 File Offset: 0x0000BB58
		public static IKnownFolder Ringtones
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Ringtones);
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x0600036D RID: 877 RVA: 0x0000D97C File Offset: 0x0000BB7C
		public static IKnownFolder PublicRingtones
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.PublicRingtones);
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x0600036E RID: 878 RVA: 0x0000D9A0 File Offset: 0x0000BBA0
		public static IKnownFolder UsersLibraries
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.UsersLibraries);
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600036F RID: 879 RVA: 0x0000D9C4 File Offset: 0x0000BBC4
		public static IKnownFolder DocumentsLibrary
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.DocumentsLibrary);
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000370 RID: 880 RVA: 0x0000D9E8 File Offset: 0x0000BBE8
		public static IKnownFolder MusicLibrary
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.MusicLibrary);
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000371 RID: 881 RVA: 0x0000DA0C File Offset: 0x0000BC0C
		public static IKnownFolder PicturesLibrary
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.PicturesLibrary);
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000372 RID: 882 RVA: 0x0000DA30 File Offset: 0x0000BC30
		public static IKnownFolder VideosLibrary
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.VideosLibrary);
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000373 RID: 883 RVA: 0x0000DA54 File Offset: 0x0000BC54
		public static IKnownFolder RecordedTVLibrary
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.RecordedTVLibrary);
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000374 RID: 884 RVA: 0x0000DA78 File Offset: 0x0000BC78
		public static IKnownFolder OtherUsers
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.OtherUsers);
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000375 RID: 885 RVA: 0x0000DA9C File Offset: 0x0000BC9C
		public static IKnownFolder DeviceMetadataStore
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.DeviceMetadataStore);
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000376 RID: 886 RVA: 0x0000DAC0 File Offset: 0x0000BCC0
		public static IKnownFolder Libraries
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.Libraries);
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000377 RID: 887 RVA: 0x0000DAE4 File Offset: 0x0000BCE4
		public static IKnownFolder UserPinned
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.UserPinned);
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000378 RID: 888 RVA: 0x0000DB08 File Offset: 0x0000BD08
		public static IKnownFolder ImplicitAppShortcuts
		{
			get
			{
				CoreHelpers.ThrowIfNotWin7();
				return KnownFolders.GetKnownFolder(FolderIdentifiers.ImplicitAppShortcuts);
			}
		}
	}
}
