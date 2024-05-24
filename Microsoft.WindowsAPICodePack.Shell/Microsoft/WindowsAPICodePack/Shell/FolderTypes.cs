using System;
using System.Collections.Generic;
using Microsoft.WindowsAPICodePack.Shell.Resources;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x02000063 RID: 99
	internal static class FolderTypes
	{
		// Token: 0x06000306 RID: 774 RVA: 0x0000C2E0 File Offset: 0x0000A4E0
		static FolderTypes()
		{
			FolderTypes.types.Add(FolderTypes.NotSpecified, LocalizedMessages.FolderTypeNotSpecified);
			FolderTypes.types.Add(FolderTypes.Invalid, LocalizedMessages.FolderTypeInvalid);
			FolderTypes.types.Add(FolderTypes.Communications, LocalizedMessages.FolderTypeCommunications);
			FolderTypes.types.Add(FolderTypes.CompressedFolder, LocalizedMessages.FolderTypeCompressedFolder);
			FolderTypes.types.Add(FolderTypes.Contacts, LocalizedMessages.FolderTypeContacts);
			FolderTypes.types.Add(FolderTypes.ControlPanelCategory, LocalizedMessages.FolderTypeCategory);
			FolderTypes.types.Add(FolderTypes.ControlPanelClassic, LocalizedMessages.FolderTypeClassic);
			FolderTypes.types.Add(FolderTypes.Documents, LocalizedMessages.FolderTypeDocuments);
			FolderTypes.types.Add(FolderTypes.Games, LocalizedMessages.FolderTypeGames);
			FolderTypes.types.Add(FolderTypes.GenericSearchResults, LocalizedMessages.FolderTypeSearchResults);
			FolderTypes.types.Add(FolderTypes.GenericLibrary, LocalizedMessages.FolderTypeGenericLibrary);
			FolderTypes.types.Add(FolderTypes.Library, LocalizedMessages.FolderTypeLibrary);
			FolderTypes.types.Add(FolderTypes.Music, LocalizedMessages.FolderTypeMusic);
			FolderTypes.types.Add(FolderTypes.MusicIcons, LocalizedMessages.FolderTypeMusicIcons);
			FolderTypes.types.Add(FolderTypes.NetworkExplorer, LocalizedMessages.FolderTypeNetworkExplorer);
			FolderTypes.types.Add(FolderTypes.OtherUsers, LocalizedMessages.FolderTypeOtherUsers);
			FolderTypes.types.Add(FolderTypes.OpenSearch, LocalizedMessages.FolderTypeOpenSearch);
			FolderTypes.types.Add(FolderTypes.Pictures, LocalizedMessages.FolderTypePictures);
			FolderTypes.types.Add(FolderTypes.Printers, LocalizedMessages.FolderTypePrinters);
			FolderTypes.types.Add(FolderTypes.RecycleBin, LocalizedMessages.FolderTypeRecycleBin);
			FolderTypes.types.Add(FolderTypes.RecordedTV, LocalizedMessages.FolderTypeRecordedTV);
			FolderTypes.types.Add(FolderTypes.SoftwareExplorer, LocalizedMessages.FolderTypeSoftwareExplorer);
			FolderTypes.types.Add(FolderTypes.SavedGames, LocalizedMessages.FolderTypeSavedGames);
			FolderTypes.types.Add(FolderTypes.SearchConnector, LocalizedMessages.FolderTypeSearchConnector);
			FolderTypes.types.Add(FolderTypes.Searches, LocalizedMessages.FolderTypeSearches);
			FolderTypes.types.Add(FolderTypes.UsersLibraries, LocalizedMessages.FolderTypeUserLibraries);
			FolderTypes.types.Add(FolderTypes.UserFiles, LocalizedMessages.FolderTypeUserFiles);
			FolderTypes.types.Add(FolderTypes.Videos, LocalizedMessages.FolderTypeVideos);
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0000CB30 File Offset: 0x0000AD30
		internal static string GetFolderType(Guid typeId)
		{
			string text;
			return FolderTypes.types.TryGetValue(typeId, out text) ? text : string.Empty;
		}

		// Token: 0x0400021D RID: 541
		internal static Guid NotSpecified = new Guid(1548691637U, 63593, 20100, 142, 96, 241, 29, 185, 124, 92, 199);

		// Token: 0x0400021E RID: 542
		internal static Guid Invalid = new Guid(1468037272U, 35919, 17506, 187, 99, 113, 4, 35, 128, 177, 9);

		// Token: 0x0400021F RID: 543
		internal static Guid Documents = new Guid(2101991206, 15393, 20229, 153, 170, 253, 194, 201, 71, 70, 86);

		// Token: 0x04000220 RID: 544
		internal static Guid Pictures = new Guid(3010006616U, 59745, 16955, 182, 135, 56, 110, 191, 216, 50, 57);

		// Token: 0x04000221 RID: 545
		internal static Guid Music = new Guid(2946237398U, 32185, 18965, 148, 100, 19, 191, 159, 182, 154, 42);

		// Token: 0x04000222 RID: 546
		internal static Guid MusicIcons = new Guid(192178171U, 33978, 19118, 160, 155, 21, 183, 16, 151, 175, 158);

		// Token: 0x04000223 RID: 547
		internal static Guid Games = new Guid(3062477008U, 30419, 19643, 135, 247, 88, 93, 14, 12, 224, 112);

		// Token: 0x04000224 RID: 548
		internal static Guid ControlPanelCategory = new Guid(3729720928U, 64016, 19343, 164, 148, 6, 139, 32, 178, 35, 7);

		// Token: 0x04000225 RID: 549
		internal static Guid ControlPanelClassic = new Guid(204969203U, 46405, 17322, 163, 41, 195, 116, 48, 197, 141, 42);

		// Token: 0x04000226 RID: 550
		internal static Guid Printers = new Guid(746307270U, 51268, 18954, 145, 250, 206, 246, 245, 156, 253, 161);

		// Token: 0x04000227 RID: 551
		internal static Guid RecycleBin = new Guid(3604602884U, 52615, 17451, 157, 87, 94, 10, 235, 79, 111, 114);

		// Token: 0x04000228 RID: 552
		internal static Guid SoftwareExplorer = new Guid(3597941019U, 21209, 19975, 131, 78, 103, 201, 134, 16, 243, 157);

		// Token: 0x04000229 RID: 553
		internal static Guid CompressedFolder = new Guid(2149662338U, 48381, 19535, 136, 23, 187, 39, 96, 18, 103, 169);

		// Token: 0x0400022A RID: 554
		internal static Guid Contacts = new Guid(3727388908U, 39927, 19091, 189, 61, 36, 63, 120, 129, 212, 146);

		// Token: 0x0400022B RID: 555
		internal static Guid Library = new Guid(1269693544U, 50348, 18198, 160, 160, 77, 93, 170, 107, 15, 62);

		// Token: 0x0400022C RID: 556
		internal static Guid NetworkExplorer = new Guid(634135595U, 39548, 20305, 128, 224, 122, 41, 40, 254, 190, 66);

		// Token: 0x0400022D RID: 557
		internal static Guid UserFiles = new Guid(3440363163U, 29154, 18149, 150, 144, 91, 205, 159, 87, 170, 179);

		// Token: 0x0400022E RID: 558
		internal static Guid GenericSearchResults = new Guid(2145262110U, 35633, 18853, 147, 184, 107, 225, 76, 250, 73, 67);

		// Token: 0x0400022F RID: 559
		internal static Guid GenericLibrary = new Guid(1598991258, 26675, 20321, 137, 157, 49, 207, 70, 151, 157, 73);

		// Token: 0x04000230 RID: 560
		internal static Guid Videos = new Guid(1604936711, 32375, 18492, 172, 147, 105, 29, 5, 133, 13, 232);

		// Token: 0x04000231 RID: 561
		internal static Guid UsersLibraries = new Guid(3302592265U, 24868, 20448, 153, 66, 130, 100, 22, 8, 45, 169);

		// Token: 0x04000232 RID: 562
		internal static Guid OtherUsers = new Guid(3006790912U, 40405, 17973, 166, 212, 218, 51, 253, 16, 43, 122);

		// Token: 0x04000233 RID: 563
		internal static Guid Communications = new Guid(2437373925U, 22635, 20154, 141, 117, 209, 116, 52, 184, 205, 246);

		// Token: 0x04000234 RID: 564
		internal static Guid RecordedTV = new Guid(1431806607, 23974, 20355, 136, 9, 194, 201, 138, 17, 166, 250);

		// Token: 0x04000235 RID: 565
		internal static Guid SavedGames = new Guid(3493212935U, 10443, 16646, 159, 35, 41, 86, 227, 229, 224, 231);

		// Token: 0x04000236 RID: 566
		internal static Guid OpenSearch = new Guid(2410649129U, 6528, 18175, 128, 35, 157, 206, 171, 156, 62, 227);

		// Token: 0x04000237 RID: 567
		internal static Guid SearchConnector = new Guid(2552702446U, 28487, 18334, 180, 71, 129, 43, 250, 125, 46, 143);

		// Token: 0x04000238 RID: 568
		internal static Guid Searches = new Guid(185311971, 16479, 16734, 166, 238, 202, 214, 37, 32, 120, 83);

		// Token: 0x04000239 RID: 569
		private static Dictionary<Guid, string> types = new Dictionary<Guid, string>();
	}
}
