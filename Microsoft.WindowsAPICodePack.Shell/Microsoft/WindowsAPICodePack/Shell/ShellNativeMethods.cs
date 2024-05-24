using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200014E RID: 334
	internal static class ShellNativeMethods
	{
		// Token: 0x06000E31 RID: 3633
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int SHCreateShellItemArrayFromDataObject(IDataObject pdo, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellItemArray iShellItemArray);

		// Token: 0x06000E32 RID: 3634
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int SHCreateItemFromParsingName([MarshalAs(UnmanagedType.LPWStr)] string path, IntPtr pbc, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellItem2 shellItem);

		// Token: 0x06000E33 RID: 3635
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int SHCreateItemFromParsingName([MarshalAs(UnmanagedType.LPWStr)] string path, IntPtr pbc, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellItem shellItem);

		// Token: 0x06000E34 RID: 3636
		[DllImport("shlwapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int PathParseIconLocation([MarshalAs(UnmanagedType.LPWStr)] ref string pszIconFile);

		// Token: 0x06000E35 RID: 3637
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int SHCreateItemFromIDList(IntPtr pidl, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out IShellItem2 ppv);

		// Token: 0x06000E36 RID: 3638
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int SHParseDisplayName([MarshalAs(UnmanagedType.LPWStr)] string pszName, IntPtr pbc, out IntPtr ppidl, ShellNativeMethods.ShellFileGetAttributesOptions sfgaoIn, out ShellNativeMethods.ShellFileGetAttributesOptions psfgaoOut);

		// Token: 0x06000E37 RID: 3639
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int SHGetIDListFromObject(IntPtr iUnknown, out IntPtr ppidl);

		// Token: 0x06000E38 RID: 3640
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int SHGetDesktopFolder([MarshalAs(UnmanagedType.Interface)] out IShellFolder ppshf);

		// Token: 0x06000E39 RID: 3641
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int SHCreateShellItem(IntPtr pidlParent, [MarshalAs(UnmanagedType.Interface)] [In] IShellFolder psfParent, IntPtr pidl, [MarshalAs(UnmanagedType.Interface)] out IShellItem ppsi);

		// Token: 0x06000E3A RID: 3642
		[DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern uint ILGetSize(IntPtr pidl);

		// Token: 0x06000E3B RID: 3643
		[DllImport("shell32.dll")]
		public static extern void ILFree(IntPtr pidl);

		// Token: 0x06000E3C RID: 3644
		[DllImport("gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x06000E3D RID: 3645
		[DllImport("Shell32", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern int SHShowManageLibraryUI([MarshalAs(UnmanagedType.Interface)] [In] IShellItem library, [In] IntPtr hwndOwner, [In] string title, [In] string instruction, [In] ShellNativeMethods.LibraryManageDialogOptions lmdOptions);

		// Token: 0x06000E3E RID: 3646
		[DllImport("shell32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SHGetPathFromIDListW(IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszPath);

		// Token: 0x06000E3F RID: 3647
		[DllImport("shell32.dll")]
		internal static extern uint SHChangeNotifyRegister(IntPtr windowHandle, ShellNativeMethods.ShellChangeNotifyEventSource sources, ShellObjectChangeTypes events, uint message, int entries, ref ShellNativeMethods.SHChangeNotifyEntry changeNotifyEntry);

		// Token: 0x06000E40 RID: 3648
		[DllImport("shell32.dll")]
		internal static extern IntPtr SHChangeNotification_Lock(IntPtr windowHandle, int processId, out IntPtr pidl, out uint lEvent);

		// Token: 0x06000E41 RID: 3649
		[DllImport("shell32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SHChangeNotification_Unlock(IntPtr hLock);

		// Token: 0x06000E42 RID: 3650
		[DllImport("shell32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SHChangeNotifyDeregister(uint hNotify);

		// Token: 0x040005B0 RID: 1456
		internal const int CommandLink = 14;

		// Token: 0x040005B1 RID: 1457
		internal const uint SetNote = 5641U;

		// Token: 0x040005B2 RID: 1458
		internal const uint GetNote = 5642U;

		// Token: 0x040005B3 RID: 1459
		internal const uint GetNoteLength = 5643U;

		// Token: 0x040005B4 RID: 1460
		internal const uint SetShield = 5644U;

		// Token: 0x040005B5 RID: 1461
		internal const int MaxPath = 260;

		// Token: 0x040005B6 RID: 1462
		internal const int InPlaceStringTruncated = 262560;

		// Token: 0x0200014F RID: 335
		[Flags]
		internal enum FileOpenOptions
		{
			// Token: 0x040005B8 RID: 1464
			OverwritePrompt = 2,
			// Token: 0x040005B9 RID: 1465
			StrictFileTypes = 4,
			// Token: 0x040005BA RID: 1466
			NoChangeDirectory = 8,
			// Token: 0x040005BB RID: 1467
			PickFolders = 32,
			// Token: 0x040005BC RID: 1468
			ForceFilesystem = 64,
			// Token: 0x040005BD RID: 1469
			AllNonStorageItems = 128,
			// Token: 0x040005BE RID: 1470
			NoValidate = 256,
			// Token: 0x040005BF RID: 1471
			AllowMultiSelect = 512,
			// Token: 0x040005C0 RID: 1472
			PathMustExist = 2048,
			// Token: 0x040005C1 RID: 1473
			FileMustExist = 4096,
			// Token: 0x040005C2 RID: 1474
			CreatePrompt = 8192,
			// Token: 0x040005C3 RID: 1475
			ShareAware = 16384,
			// Token: 0x040005C4 RID: 1476
			NoReadOnlyReturn = 32768,
			// Token: 0x040005C5 RID: 1477
			NoTestFileCreate = 65536,
			// Token: 0x040005C6 RID: 1478
			HideMruPlaces = 131072,
			// Token: 0x040005C7 RID: 1479
			HidePinnedPlaces = 262144,
			// Token: 0x040005C8 RID: 1480
			NoDereferenceLinks = 1048576,
			// Token: 0x040005C9 RID: 1481
			DontAddToRecent = 33554432,
			// Token: 0x040005CA RID: 1482
			ForceShowHidden = 268435456,
			// Token: 0x040005CB RID: 1483
			DefaultNoMiniMode = 536870912
		}

		// Token: 0x02000150 RID: 336
		internal enum ControlState
		{
			// Token: 0x040005CD RID: 1485
			Inactive,
			// Token: 0x040005CE RID: 1486
			Enable,
			// Token: 0x040005CF RID: 1487
			Visible
		}

		// Token: 0x02000151 RID: 337
		internal enum ShellItemDesignNameOptions
		{
			// Token: 0x040005D1 RID: 1489
			Normal,
			// Token: 0x040005D2 RID: 1490
			ParentRelativeParsing = -2147385343,
			// Token: 0x040005D3 RID: 1491
			DesktopAbsoluteParsing = -2147319808,
			// Token: 0x040005D4 RID: 1492
			ParentRelativeEditing = -2147282943,
			// Token: 0x040005D5 RID: 1493
			DesktopAbsoluteEditing = -2147172352,
			// Token: 0x040005D6 RID: 1494
			FileSystemPath = -2147123200,
			// Token: 0x040005D7 RID: 1495
			Url = -2147057664,
			// Token: 0x040005D8 RID: 1496
			ParentRelativeForAddressBar = -2146975743,
			// Token: 0x040005D9 RID: 1497
			ParentRelative = -2146959359
		}

		// Token: 0x02000152 RID: 338
		[Flags]
		internal enum GetPropertyStoreOptions
		{
			// Token: 0x040005DB RID: 1499
			Default = 0,
			// Token: 0x040005DC RID: 1500
			HandlePropertiesOnly = 1,
			// Token: 0x040005DD RID: 1501
			ReadWrite = 2,
			// Token: 0x040005DE RID: 1502
			Temporary = 4,
			// Token: 0x040005DF RID: 1503
			FastPropertiesOnly = 8,
			// Token: 0x040005E0 RID: 1504
			OpensLowItem = 16,
			// Token: 0x040005E1 RID: 1505
			DelayCreation = 32,
			// Token: 0x040005E2 RID: 1506
			BestEffort = 64,
			// Token: 0x040005E3 RID: 1507
			MaskValid = 255
		}

		// Token: 0x02000153 RID: 339
		internal enum ShellItemAttributeOptions
		{
			// Token: 0x040005E5 RID: 1509
			And = 1,
			// Token: 0x040005E6 RID: 1510
			Or,
			// Token: 0x040005E7 RID: 1511
			AppCompat,
			// Token: 0x040005E8 RID: 1512
			Mask = 3,
			// Token: 0x040005E9 RID: 1513
			AllItems = 16384
		}

		// Token: 0x02000154 RID: 340
		internal enum FileDialogEventShareViolationResponse
		{
			// Token: 0x040005EB RID: 1515
			Default,
			// Token: 0x040005EC RID: 1516
			Accept,
			// Token: 0x040005ED RID: 1517
			Refuse
		}

		// Token: 0x02000155 RID: 341
		internal enum FileDialogEventOverwriteResponse
		{
			// Token: 0x040005EF RID: 1519
			Default,
			// Token: 0x040005F0 RID: 1520
			Accept,
			// Token: 0x040005F1 RID: 1521
			Refuse
		}

		// Token: 0x02000156 RID: 342
		internal enum FileDialogAddPlacement
		{
			// Token: 0x040005F3 RID: 1523
			Bottom,
			// Token: 0x040005F4 RID: 1524
			Top
		}

		// Token: 0x02000157 RID: 343
		[Flags]
		internal enum SIIGBF
		{
			// Token: 0x040005F6 RID: 1526
			ResizeToFit = 0,
			// Token: 0x040005F7 RID: 1527
			BiggerSizeOk = 1,
			// Token: 0x040005F8 RID: 1528
			MemoryOnly = 2,
			// Token: 0x040005F9 RID: 1529
			IconOnly = 4,
			// Token: 0x040005FA RID: 1530
			ThumbnailOnly = 8,
			// Token: 0x040005FB RID: 1531
			InCacheOnly = 16
		}

		// Token: 0x02000158 RID: 344
		[Flags]
		internal enum ThumbnailOptions
		{
			// Token: 0x040005FD RID: 1533
			Extract = 0,
			// Token: 0x040005FE RID: 1534
			InCacheOnly = 1,
			// Token: 0x040005FF RID: 1535
			FastExtract = 2,
			// Token: 0x04000600 RID: 1536
			ForceExtraction = 4,
			// Token: 0x04000601 RID: 1537
			SlowReclaim = 8,
			// Token: 0x04000602 RID: 1538
			ExtractDoNotCache = 32
		}

		// Token: 0x02000159 RID: 345
		[Flags]
		internal enum ThumbnailCacheOptions
		{
			// Token: 0x04000604 RID: 1540
			Default = 0,
			// Token: 0x04000605 RID: 1541
			LowQuality = 1,
			// Token: 0x04000606 RID: 1542
			Cached = 2
		}

		// Token: 0x0200015A RID: 346
		[Flags]
		internal enum ShellFileGetAttributesOptions
		{
			// Token: 0x04000608 RID: 1544
			CanCopy = 1,
			// Token: 0x04000609 RID: 1545
			CanMove = 2,
			// Token: 0x0400060A RID: 1546
			CanLink = 4,
			// Token: 0x0400060B RID: 1547
			Storage = 8,
			// Token: 0x0400060C RID: 1548
			CanRename = 16,
			// Token: 0x0400060D RID: 1549
			CanDelete = 32,
			// Token: 0x0400060E RID: 1550
			HasPropertySheet = 64,
			// Token: 0x0400060F RID: 1551
			DropTarget = 256,
			// Token: 0x04000610 RID: 1552
			CapabilityMask = 375,
			// Token: 0x04000611 RID: 1553
			System = 4096,
			// Token: 0x04000612 RID: 1554
			Encrypted = 8192,
			// Token: 0x04000613 RID: 1555
			IsSlow = 16384,
			// Token: 0x04000614 RID: 1556
			Ghosted = 32768,
			// Token: 0x04000615 RID: 1557
			Link = 65536,
			// Token: 0x04000616 RID: 1558
			Share = 131072,
			// Token: 0x04000617 RID: 1559
			ReadOnly = 262144,
			// Token: 0x04000618 RID: 1560
			Hidden = 524288,
			// Token: 0x04000619 RID: 1561
			DisplayAttributeMask = 1032192,
			// Token: 0x0400061A RID: 1562
			FileSystemAncestor = 268435456,
			// Token: 0x0400061B RID: 1563
			Folder = 536870912,
			// Token: 0x0400061C RID: 1564
			FileSystem = 1073741824,
			// Token: 0x0400061D RID: 1565
			HasSubFolder = -2147483648,
			// Token: 0x0400061E RID: 1566
			ContentsMask = -2147483648,
			// Token: 0x0400061F RID: 1567
			Validate = 16777216,
			// Token: 0x04000620 RID: 1568
			Removable = 33554432,
			// Token: 0x04000621 RID: 1569
			Compressed = 67108864,
			// Token: 0x04000622 RID: 1570
			Browsable = 134217728,
			// Token: 0x04000623 RID: 1571
			Nonenumerated = 1048576,
			// Token: 0x04000624 RID: 1572
			NewContent = 2097152,
			// Token: 0x04000625 RID: 1573
			CanMoniker = 4194304,
			// Token: 0x04000626 RID: 1574
			HasStorage = 4194304,
			// Token: 0x04000627 RID: 1575
			Stream = 4194304,
			// Token: 0x04000628 RID: 1576
			StorageAncestor = 8388608,
			// Token: 0x04000629 RID: 1577
			StorageCapabilityMask = 1891958792,
			// Token: 0x0400062A RID: 1578
			PkeyMask = -2130427904
		}

		// Token: 0x0200015B RID: 347
		[Flags]
		internal enum ShellFolderEnumerationOptions : ushort
		{
			// Token: 0x0400062C RID: 1580
			CheckingForChildren = 16,
			// Token: 0x0400062D RID: 1581
			Folders = 32,
			// Token: 0x0400062E RID: 1582
			NonFolders = 64,
			// Token: 0x0400062F RID: 1583
			IncludeHidden = 128,
			// Token: 0x04000630 RID: 1584
			InitializeOnFirstNext = 256,
			// Token: 0x04000631 RID: 1585
			NetPrinterSearch = 512,
			// Token: 0x04000632 RID: 1586
			Shareable = 1024,
			// Token: 0x04000633 RID: 1587
			Storage = 2048,
			// Token: 0x04000634 RID: 1588
			NavigationEnum = 4096,
			// Token: 0x04000635 RID: 1589
			FastItems = 8192,
			// Token: 0x04000636 RID: 1590
			FlatList = 16384,
			// Token: 0x04000637 RID: 1591
			EnableAsync = 32768
		}

		// Token: 0x0200015C RID: 348
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		internal struct FilterSpec
		{
			// Token: 0x06000E43 RID: 3651 RVA: 0x00033DF7 File Offset: 0x00031FF7
			internal FilterSpec(string name, string spec)
			{
				this.Name = name;
				this.Spec = spec;
			}

			// Token: 0x04000638 RID: 1592
			[MarshalAs(UnmanagedType.LPWStr)]
			internal string Name;

			// Token: 0x04000639 RID: 1593
			[MarshalAs(UnmanagedType.LPWStr)]
			internal string Spec;
		}

		// Token: 0x0200015D RID: 349
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		internal struct ThumbnailId
		{
			// Token: 0x0400063A RID: 1594
			[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 16)]
			private byte rgbKey;
		}

		// Token: 0x0200015E RID: 350
		internal enum LibraryFolderFilter
		{
			// Token: 0x0400063C RID: 1596
			ForceFileSystem = 1,
			// Token: 0x0400063D RID: 1597
			StorageItems,
			// Token: 0x0400063E RID: 1598
			AllItems
		}

		// Token: 0x0200015F RID: 351
		[Flags]
		internal enum LibraryOptions
		{
			// Token: 0x04000640 RID: 1600
			Default = 0,
			// Token: 0x04000641 RID: 1601
			PinnedToNavigationPane = 1,
			// Token: 0x04000642 RID: 1602
			MaskAll = 1
		}

		// Token: 0x02000160 RID: 352
		internal enum DefaultSaveFolderType
		{
			// Token: 0x04000644 RID: 1604
			Detect = 1,
			// Token: 0x04000645 RID: 1605
			Private,
			// Token: 0x04000646 RID: 1606
			Public
		}

		// Token: 0x02000161 RID: 353
		internal enum LibrarySaveOptions
		{
			// Token: 0x04000648 RID: 1608
			FailIfThere,
			// Token: 0x04000649 RID: 1609
			OverrideExisting,
			// Token: 0x0400064A RID: 1610
			MakeUniqueName
		}

		// Token: 0x02000162 RID: 354
		internal enum LibraryManageDialogOptions
		{
			// Token: 0x0400064C RID: 1612
			Default,
			// Token: 0x0400064D RID: 1613
			NonIndexableLocationWarning
		}

		// Token: 0x02000163 RID: 355
		internal struct ShellNotifyStruct
		{
			// Token: 0x0400064E RID: 1614
			internal IntPtr item1;

			// Token: 0x0400064F RID: 1615
			internal IntPtr item2;
		}

		// Token: 0x02000164 RID: 356
		internal struct SHChangeNotifyEntry
		{
			// Token: 0x04000650 RID: 1616
			internal IntPtr pIdl;

			// Token: 0x04000651 RID: 1617
			[MarshalAs(UnmanagedType.Bool)]
			internal bool recursively;
		}

		// Token: 0x02000165 RID: 357
		[Flags]
		internal enum ShellChangeNotifyEventSource
		{
			// Token: 0x04000653 RID: 1619
			InterruptLevel = 1,
			// Token: 0x04000654 RID: 1620
			ShellLevel = 2,
			// Token: 0x04000655 RID: 1621
			RecursiveInterrupt = 4096,
			// Token: 0x04000656 RID: 1622
			NewDelivery = 32768
		}
	}
}
