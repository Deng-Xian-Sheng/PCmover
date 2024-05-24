using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000062 RID: 98
	internal static class FolderIdentifiers
	{
		// Token: 0x06000303 RID: 771 RVA: 0x0000AC00 File Offset: 0x00008E00
		static FolderIdentifiers()
		{
			FolderIdentifiers.folders = new Dictionary<Guid, string>();
			Type typeFromHandle = typeof(FolderIdentifiers);
			FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.FieldType == typeof(Guid))
				{
					Guid key = (Guid)fieldInfo.GetValue(null);
					string name = fieldInfo.Name;
					FolderIdentifiers.folders.Add(key, name);
				}
			}
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0000C228 File Offset: 0x0000A428
		internal static string NameForGuid(Guid folderId)
		{
			string result;
			if (!FolderIdentifiers.folders.TryGetValue(folderId, out result))
			{
				throw new ArgumentException(LocalizedMessages.FolderIdsUnknownGuid, "folderId");
			}
			return result;
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0000C260 File Offset: 0x0000A460
		internal static SortedList<string, Guid> GetAllFolders()
		{
			ICollection<Guid> keys = FolderIdentifiers.folders.Keys;
			SortedList<string, Guid> sortedList = new SortedList<string, Guid>();
			foreach (Guid guid in keys)
			{
				sortedList.Add(FolderIdentifiers.folders[guid], guid);
			}
			return sortedList;
		}

		// Token: 0x040001B5 RID: 437
		private static Dictionary<Guid, string> folders;

		// Token: 0x040001B6 RID: 438
		internal static Guid Computer = new Guid(180388732U, 48120, 17706, 133, 13, 121, 208, 142, 102, 124, 167);

		// Token: 0x040001B7 RID: 439
		internal static Guid Conflict = new Guid(1275001669, 13437, 16390, 165, 190, 172, 12, 176, 86, 113, 146);

		// Token: 0x040001B8 RID: 440
		internal static Guid ControlPanel = new Guid(2192001771U, 44724, 18012, 160, 20, 208, 151, 238, 52, 109, 99);

		// Token: 0x040001B9 RID: 441
		internal static Guid Desktop = new Guid(3032468538U, 56108, 16972, 176, 41, 127, 233, 154, 135, 198, 65);

		// Token: 0x040001BA RID: 442
		internal static Guid Internet = new Guid(1302296692, 19980, 18692, 150, 123, 64, 176, 210, 12, 62, 75);

		// Token: 0x040001BB RID: 443
		internal static Guid Network = new Guid(3523997380U, 23720, 18693, 174, 59, 191, 37, 30, 160, 155, 83);

		// Token: 0x040001BC RID: 444
		internal static Guid Printers = new Guid(1996246573U, 54957, 17689, 166, 99, 55, 189, 86, 6, 129, 133);

		// Token: 0x040001BD RID: 445
		internal static Guid SyncManager = new Guid(1130793976U, 49486, 18866, 151, 201, 116, 119, 132, 215, 132, 183);

		// Token: 0x040001BE RID: 446
		internal static Guid Connections = new Guid(1863113003, 11927, 17873, 136, byte.MaxValue, 176, 209, 134, 184, 222, 221);

		// Token: 0x040001BF RID: 447
		internal static Guid SyncSetup = new Guid(253837624U, 45523, 19088, 187, 169, 39, 203, 192, 197, 56, 154);

		// Token: 0x040001C0 RID: 448
		internal static Guid SyncResults = new Guid(681220675U, 48708, 16471, 164, 27, 88, 122, 118, 215, 231, 249);

		// Token: 0x040001C1 RID: 449
		internal static Guid RecycleBin = new Guid(3075686470U, 16075, 19480, 190, 78, 100, 205, 76, 183, 214, 172);

		// Token: 0x040001C2 RID: 450
		internal static Guid Fonts = new Guid(4246899895U, 44561, 19171, 134, 76, 22, 243, 145, 10, 184, 254);

		// Token: 0x040001C3 RID: 451
		internal static Guid Startup = new Guid(3111985339U, 62570, 19607, 186, 16, 94, 54, 8, 67, 8, 84);

		// Token: 0x040001C4 RID: 452
		internal static Guid Programs = new Guid(2810142071U, 11819, 17603, 166, 162, 171, 166, 1, 5, 74, 81);

		// Token: 0x040001C5 RID: 453
		internal static Guid StartMenu = new Guid(1650152387U, 43848, 20161, 186, 31, 161, 239, 65, 70, 252, 25);

		// Token: 0x040001C6 RID: 454
		internal static Guid Recent = new Guid(2924527745U, 60370, 17290, 134, 85, 138, 9, 46, 52, 152, 122);

		// Token: 0x040001C7 RID: 455
		internal static Guid SendTo = new Guid(2307064684U, 10176, 16459, 143, 8, 16, 45, 16, 220, 253, 116);

		// Token: 0x040001C8 RID: 456
		internal static Guid Documents = new Guid(4258503376U, 9103, 18095, 173, 180, 108, 133, 72, 3, 105, 199);

		// Token: 0x040001C9 RID: 457
		internal static Guid Favorites = new Guid(393738081, 26797, 19850, 135, 189, 48, 183, 89, 250, 51, 221);

		// Token: 0x040001CA RID: 458
		internal static Guid NetHood = new Guid(3316367187U, 57727, 16673, 137, 0, 134, 98, 111, 194, 201, 115);

		// Token: 0x040001CB RID: 459
		internal static Guid PrintHood = new Guid(2457124237U, 53201, 16835, 179, 94, 177, 63, 85, 167, 88, 244);

		// Token: 0x040001CC RID: 460
		internal static Guid Templates = new Guid(2788332520U, 26190, 18651, 160, 121, 223, 117, 158, 5, 9, 247);

		// Token: 0x040001CD RID: 461
		internal static Guid CommonStartup = new Guid(2191911477U, 55757, 18373, 150, 41, 225, 93, 47, 113, 78, 110);

		// Token: 0x040001CE RID: 462
		internal static Guid CommonPrograms = new Guid(20567118, 27390, 18930, 134, 144, 61, 175, 202, 230, byte.MaxValue, 184);

		// Token: 0x040001CF RID: 463
		internal static Guid CommonStartMenu = new Guid(2752599833U, 54830, 18717, 170, 124, 231, 75, 139, 227, 176, 103);

		// Token: 0x040001D0 RID: 464
		internal static Guid PublicDesktop = new Guid(3299488781U, 61967, 18531, 175, 239, 248, 126, 242, 230, 186, 37);

		// Token: 0x040001D1 RID: 465
		internal static Guid ProgramData = new Guid(1655397762U, 64961, 19907, 169, 221, 7, 13, 29, 73, 93, 151);

		// Token: 0x040001D2 RID: 466
		internal static Guid CommonTemplates = new Guid(3108124647U, 22444, 17223, 145, 81, 176, 140, 108, 50, 209, 247);

		// Token: 0x040001D3 RID: 467
		internal static Guid PublicDocuments = new Guid(3980928175U, 56548, 17832, 129, 226, 252, 121, 101, 8, 54, 52);

		// Token: 0x040001D4 RID: 468
		internal static Guid RoamingAppData = new Guid(1052149211, 26105, 19702, 160, 58, 227, 239, 101, 114, 159, 61);

		// Token: 0x040001D5 RID: 469
		internal static Guid LocalAppData = new Guid(4055050117U, 28602, 20431, 157, 85, 123, 142, 127, 21, 112, 145);

		// Token: 0x040001D6 RID: 470
		internal static Guid LocalAppDataLow = new Guid(2770379172U, 6016, 20470, 189, 24, 22, 115, 67, 197, 175, 22);

		// Token: 0x040001D7 RID: 471
		internal static Guid InternetCache = new Guid(891585000, 13246, 16977, 186, 133, 96, 7, 202, 237, 207, 157);

		// Token: 0x040001D8 RID: 472
		internal static Guid Cookies = new Guid(722433629U, 49385, 16753, 144, 142, 8, 166, 17, 184, 79, 246);

		// Token: 0x040001D9 RID: 473
		internal static Guid History = new Guid(3655109179U, 46980, 17198, 167, 129, 90, 17, 48, 167, 89, 99);

		// Token: 0x040001DA RID: 474
		internal static Guid System = new Guid(448876151, 743, 20061, 183, 68, 46, 177, 174, 81, 152, 183);

		// Token: 0x040001DB RID: 475
		internal static Guid SystemX86 = new Guid(3595710896U, 45809, 18519, 164, 206, 168, 231, 198, 234, 125, 39);

		// Token: 0x040001DC RID: 476
		internal static Guid Windows = new Guid(4086035460U, 7491, 17138, 147, 5, 103, 222, 11, 40, 252, 35);

		// Token: 0x040001DD RID: 477
		internal static Guid Profile = new Guid(1584170383, 3618, 18272, 154, 254, 234, 51, 23, 182, 113, 115);

		// Token: 0x040001DE RID: 478
		internal static Guid Pictures = new Guid(870482224, 19998, 18038, 131, 90, 152, 57, 92, 59, 195, 187);

		// Token: 0x040001DF RID: 479
		internal static Guid ProgramFilesX86 = new Guid(2086289647U, 41211, 19452, 135, 74, 192, 242, 224, 185, 250, 142);

		// Token: 0x040001E0 RID: 480
		internal static Guid ProgramFilesCommonX86 = new Guid(3734457636U, 55750, 19774, 191, 145, 244, 69, 81, 32, 185, 23);

		// Token: 0x040001E1 RID: 481
		internal static Guid ProgramFilesX64 = new Guid(1837142903, 27376, 17483, 137, 87, 163, 119, 63, 2, 32, 14);

		// Token: 0x040001E2 RID: 482
		internal static Guid ProgramFilesCommonX64 = new Guid(1667618215, 3853, 17893, 135, 246, 13, 165, 107, 106, 79, 125);

		// Token: 0x040001E3 RID: 483
		internal static Guid ProgramFiles = new Guid(2422105014U, 49599, 18766, 178, 156, 101, 183, 50, 211, 210, 26);

		// Token: 0x040001E4 RID: 484
		internal static Guid ProgramFilesCommon = new Guid(4159827205U, 40813, 18338, 170, 174, 41, 211, 23, 198, 240, 102);

		// Token: 0x040001E5 RID: 485
		internal static Guid AdminTools = new Guid(1917776240U, 42029, 20463, 159, 38, 182, 14, 132, 111, 186, 79);

		// Token: 0x040001E6 RID: 486
		internal static Guid CommonAdminTools = new Guid(3493351037U, 47811, 18327, 143, 20, 203, 162, 41, 179, 146, 181);

		// Token: 0x040001E7 RID: 487
		internal static Guid Music = new Guid(1272501617, 27929, 18643, 190, 151, 66, 34, 32, 8, 14, 67);

		// Token: 0x040001E8 RID: 488
		internal static Guid Videos = new Guid(412654365U, 39349, 17755, 132, 28, 171, 124, 116, 228, 221, 252);

		// Token: 0x040001E9 RID: 489
		internal static Guid PublicPictures = new Guid(3068918662U, 26887, 16700, 154, 247, 79, 194, 171, 240, 124, 197);

		// Token: 0x040001EA RID: 490
		internal static Guid PublicMusic = new Guid(840235701U, 38743, 17048, 187, 97, 146, 169, 222, 170, 68, byte.MaxValue);

		// Token: 0x040001EB RID: 491
		internal static Guid PublicVideos = new Guid(603985978, 24965, 18939, 162, 216, 74, 57, 42, 96, 43, 163);

		// Token: 0x040001EC RID: 492
		internal static Guid ResourceDir = new Guid(2328955953U, 10971, 17046, 168, 247, 228, 112, 18, 50, 201, 114);

		// Token: 0x040001ED RID: 493
		internal static Guid LocalizedResourcesDir = new Guid(704657246, 8780, 18910, 184, 209, 68, 13, 247, 239, 61, 220);

		// Token: 0x040001EE RID: 494
		internal static Guid CommonOEMLinks = new Guid(3250250448U, 4319, 17204, 190, 221, 122, 162, 11, 34, 122, 157);

		// Token: 0x040001EF RID: 495
		internal static Guid CDBurning = new Guid(2656217872U, 63501, 18911, 172, 184, 67, 48, 245, 104, 120, 85);

		// Token: 0x040001F0 RID: 496
		internal static Guid UserProfiles = new Guid(123916914U, 50442, 19376, 163, 130, 105, 125, 205, 114, 155, 128);

		// Token: 0x040001F1 RID: 497
		internal static Guid Playlists = new Guid(3734159815U, 33663, 20329, 163, 187, 134, 230, 49, 32, 74, 35);

		// Token: 0x040001F2 RID: 498
		internal static Guid SamplePlaylists = new Guid(365586867, 12526, 18881, 172, 225, 107, 94, 195, 114, 175, 181);

		// Token: 0x040001F3 RID: 499
		internal static Guid SampleMusic = new Guid(2991638120U, 62845, 20193, 166, 60, 41, 14, 231, 209, 170, 31);

		// Token: 0x040001F4 RID: 500
		internal static Guid SamplePictures = new Guid(3297772864U, 9081, 19573, 132, 75, 100, 230, 250, 248, 113, 107);

		// Token: 0x040001F5 RID: 501
		internal static Guid SampleVideos = new Guid(2241768852U, 11909, 18605, 167, 26, 9, 105, 203, 86, 166, 205);

		// Token: 0x040001F6 RID: 502
		internal static Guid PhotoAlbums = new Guid(1775423376U, 64563, 20407, 154, 12, 235, 176, 240, 252, 180, 60);

		// Token: 0x040001F7 RID: 503
		internal static Guid Public = new Guid(3755964066U, 51242, 19811, 144, 106, 86, 68, 172, 69, 115, 133);

		// Token: 0x040001F8 RID: 504
		internal static Guid ChangeRemovePrograms = new Guid(3748816556U, 37492, 18535, 141, 85, 59, 214, 97, 222, 135, 45);

		// Token: 0x040001F9 RID: 505
		internal static Guid AppUpdates = new Guid(2735066777U, 62759, 18731, 139, 26, 126, 118, 250, 152, 214, 228);

		// Token: 0x040001FA RID: 506
		internal static Guid AddNewPrograms = new Guid(3730954609U, 24252, 20226, 163, 169, 108, 130, 137, 94, 92, 4);

		// Token: 0x040001FB RID: 507
		internal static Guid Downloads = new Guid(927851152, 4671, 17765, 145, 100, 57, 196, 146, 94, 70, 123);

		// Token: 0x040001FC RID: 508
		internal static Guid PublicDownloads = new Guid(1029983387, 8120, 20272, 155, 69, 246, 112, 35, 95, 121, 192);

		// Token: 0x040001FD RID: 509
		internal static Guid SavedSearches = new Guid(2099067396U, 57019, 16661, 149, 207, 47, 41, 218, 41, 32, 218);

		// Token: 0x040001FE RID: 510
		internal static Guid QuickLaunch = new Guid(1386541089, 31605, 18601, 159, 107, 75, 135, 162, 16, 188, 143);

		// Token: 0x040001FF RID: 511
		internal static Guid Contacts = new Guid(1450723412U, 50891, 17963, 129, 105, 136, 227, 80, 172, 184, 130);

		// Token: 0x04000200 RID: 512
		internal static Guid SidebarParts = new Guid(2807903790U, 20732, 20407, 172, 44, 168, 190, 170, 49, 68, 147);

		// Token: 0x04000201 RID: 513
		internal static Guid SidebarDefaultParts = new Guid(2067361364U, 40645, 17152, 190, 10, 36, 130, 235, 174, 26, 38);

		// Token: 0x04000202 RID: 514
		internal static Guid TreeProperties = new Guid(1530349997U, 46239, 18881, 131, 235, 21, 55, 15, 189, 72, 130);

		// Token: 0x04000203 RID: 515
		internal static Guid PublicGameTasks = new Guid(3737068854U, 57768, 19545, 182, 162, 65, 69, 134, 71, 106, 234);

		// Token: 0x04000204 RID: 516
		internal static Guid GameTasks = new Guid(89108065, 19928, 18311, 128, 182, 9, 2, 32, 196, 183, 0);

		// Token: 0x04000205 RID: 517
		internal static Guid SavedGames = new Guid(1281110783U, 48029, 17328, 181, 180, 45, 114, 229, 78, 170, 164);

		// Token: 0x04000206 RID: 518
		internal static Guid Games = new Guid(3401919514U, 46397, 20188, 146, 215, 107, 46, 138, 193, 148, 52);

		// Token: 0x04000207 RID: 519
		internal static Guid RecordedTV = new Guid(3179667457U, 4398, 17182, 152, 59, 123, 21, 172, 9, byte.MaxValue, 241);

		// Token: 0x04000208 RID: 520
		internal static Guid SearchMapi = new Guid(2565606936U, 8344, 19780, 134, 68, 102, 151, 147, 21, 162, 129);

		// Token: 0x04000209 RID: 521
		internal static Guid SearchCsc = new Guid(3996312646U, 12746, 19130, 129, 79, 165, 235, 210, 253, 109, 94);

		// Token: 0x0400020A RID: 522
		internal static Guid Links = new Guid(3216627168U, 50857, 16460, 178, 178, 174, 109, 182, 175, 73, 104);

		// Token: 0x0400020B RID: 523
		internal static Guid UsersFiles = new Guid(4090367868U, 18689, 19148, 134, 72, 213, 212, 75, 4, 239, 143);

		// Token: 0x0400020C RID: 524
		internal static Guid SearchHome = new Guid(419641297U, 47306, 16673, 166, 57, 109, 71, 45, 22, 151, 42);

		// Token: 0x0400020D RID: 525
		internal static Guid OriginalImages = new Guid(741785770, 22546, 19335, 191, 208, 76, 208, 223, 177, 155, 57);

		// Token: 0x0400020E RID: 526
		internal static Guid UserProgramFiles = new Guid(1557638882, 8729, 19047, 184, 93, 108, 156, 225, 86, 96, 203);

		// Token: 0x0400020F RID: 527
		internal static Guid UserProgramFilesCommon = new Guid(3166515287U, 51804, 17954, 180, 45, 188, 86, 219, 10, 229, 22);

		// Token: 0x04000210 RID: 528
		internal static Guid Ringtones = new Guid(3362784331U, 62622, 16678, 169, 195, 181, 42, 31, 244, 17, 232);

		// Token: 0x04000211 RID: 529
		internal static Guid PublicRingtones = new Guid(3847596896U, 5435, 19735, 159, 4, 165, 254, 153, 252, 21, 236);

		// Token: 0x04000212 RID: 530
		internal static Guid UsersLibraries = new Guid(2734838877U, 57087, 17995, 171, 232, 97, 200, 100, 141, 147, 155);

		// Token: 0x04000213 RID: 531
		internal static Guid DocumentsLibrary = new Guid(2064494973U, 40146, 19091, 151, 51, 70, 204, 137, 2, 46, 124);

		// Token: 0x04000214 RID: 532
		internal static Guid MusicLibrary = new Guid(554871562U, 51306, 20478, 163, 104, 13, 233, 110, 71, 1, 46);

		// Token: 0x04000215 RID: 533
		internal static Guid PicturesLibrary = new Guid(2844831391U, 41019, 20096, 148, 188, 153, 18, 215, 80, 65, 4);

		// Token: 0x04000216 RID: 534
		internal static Guid VideosLibrary = new Guid(1226740271, 22083, 19188, 167, 235, 78, 122, 19, 141, 129, 116);

		// Token: 0x04000217 RID: 535
		internal static Guid RecordedTVLibrary = new Guid(443538338U, 62509, 17240, 167, 152, 183, 77, 116, 89, 38, 197);

		// Token: 0x04000218 RID: 536
		internal static Guid OtherUsers = new Guid(1381141099U, 47587, 19165, 182, 13, 88, 140, 45, 186, 132, 45);

		// Token: 0x04000219 RID: 537
		internal static Guid DeviceMetadataStore = new Guid(1558488553U, 58603, 18333, 184, 159, 19, 12, 2, 136, 97, 85);

		// Token: 0x0400021A RID: 538
		internal static Guid Libraries = new Guid(457090524U, 46471, 18310, 180, 239, 189, 29, 195, 50, 174, 174);

		// Token: 0x0400021B RID: 539
		internal static Guid UserPinned = new Guid(2654573995U, 8092, 20243, 184, 39, 72, 178, 75, 108, 113, 116);

		// Token: 0x0400021C RID: 540
		internal static Guid ImplicitAppShortcuts = new Guid(3165988207U, 31222, 19694, 183, 37, 220, 52, 228, 2, 253, 70);
	}
}
