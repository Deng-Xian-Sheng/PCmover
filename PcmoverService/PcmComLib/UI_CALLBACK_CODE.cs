using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x020000D8 RID: 216
	[CompilerGenerated]
	[TypeIdentifier("014D1DE2-7A0B-457C-8B9C-A20AD2BF0977", "PcmComLib.UI_CALLBACK_CODE")]
	public enum UI_CALLBACK_CODE
	{
		// Token: 0x040001B4 RID: 436
		UICC_NoError,
		// Token: 0x040001B5 RID: 437
		UICC_Empty = 0,
		// Token: 0x040001B6 RID: 438
		UICC_Custom,
		// Token: 0x040001B7 RID: 439
		UICC_InitError_HasInitializedBefore,
		// Token: 0x040001B8 RID: 440
		UICC_InitError_NetworkExecutionDisallowed,
		// Token: 0x040001B9 RID: 441
		UICC_InitError_AdminRequired,
		// Token: 0x040001BA RID: 442
		UICC_InitError_ShlnkNotFound,
		// Token: 0x040001BB RID: 443
		UICC_InitError_ShlnkProcess,
		// Token: 0x040001BC RID: 444
		UICC_InitError_ShlnkRegister,
		// Token: 0x040001BD RID: 445
		UICC_InitError_DomainUserRequired,
		// Token: 0x040001BE RID: 446
		UICC_InitError_JoinDisallowed,
		// Token: 0x040001BF RID: 447
		UICC_InitError_JoinRequired,
		// Token: 0x040001C0 RID: 448
		UICC_InitError_WrongDomain,
		// Token: 0x040001C1 RID: 449
		UICC_InitError_CannotCreateLogs,
		// Token: 0x040001C2 RID: 450
		UICC_InitError_PolicyDisallow,
		// Token: 0x040001C3 RID: 451
		UICC_InitError_PolicyUndoDisabled,
		// Token: 0x040001C4 RID: 452
		UICC_InitError_PolicySnapshotFile,
		// Token: 0x040001C5 RID: 453
		UICC_InitError_PolicyNoSnapshot,
		// Token: 0x040001C6 RID: 454
		UICC_InitError_NoDomain,
		// Token: 0x040001C7 RID: 455
		UICC_InitError_BadArchiveFormat,
		// Token: 0x040001C8 RID: 456
		UICC_InitError_BadArchiveVersion,
		// Token: 0x040001C9 RID: 457
		UICC_InitError1Param_CannotCreateFolder,
		// Token: 0x040001CA RID: 458
		UICC_InitErrorUrl_Timeout,
		// Token: 0x040001CB RID: 459
		UICC_RegError1Param_BadId,
		// Token: 0x040001CC RID: 460
		UICC_MachineError_RegLoaded,
		// Token: 0x040001CD RID: 461
		UICC_MachineError_RegHives,
		// Token: 0x040001CE RID: 462
		UICC_MachineError_RegNoCCS,
		// Token: 0x040001CF RID: 463
		UICC_MachineError_TreeMgr,
		// Token: 0x040001D0 RID: 464
		UICC_MachineErrorUrl_WindowsVersionSrc,
		// Token: 0x040001D1 RID: 465
		UICC_MachineErrorUrl_WindowsVersionDst,
		// Token: 0x040001D2 RID: 466
		UICC_TransferError_MergeIni,
		// Token: 0x040001D3 RID: 467
		UICC_TransferError_WrongOem,
		// Token: 0x040001D4 RID: 468
		UICC_TransferError_FipsEnforced,
		// Token: 0x040001D5 RID: 469
		UICC_TransferError_PostMigSetup,
		// Token: 0x040001D6 RID: 470
		UICC_TransferError_WrongVersion,
		// Token: 0x040001D7 RID: 471
		UICC_TransferError1Param_BadPathSavingArchive,
		// Token: 0x040001D8 RID: 472
		UICC_TransferError1Param_CreateUser,
		// Token: 0x040001D9 RID: 473
		UICC_Transfer1Param_SpanDisk,
		// Token: 0x040001DA RID: 474
		UICC_Transfer1Param_SpanBlankDisk,
		// Token: 0x040001DB RID: 475
		UICC_Action_AppFindApps,
		// Token: 0x040001DC RID: 476
		UICC_Action_AppGetInfo,
		// Token: 0x040001DD RID: 477
		UICC_Action_AppScanShortcuts,
		// Token: 0x040001DE RID: 478
		UICC_Action_AppScanOthers,
		// Token: 0x040001DF RID: 479
		UICC_Action_AppScanAll,
		// Token: 0x040001E0 RID: 480
		UICC_Action_AppScanMsiProducts,
		// Token: 0x040001E1 RID: 481
		UICC_Action_AppScanAddRem,
		// Token: 0x040001E2 RID: 482
		UICC_Action_AppDetermineProfiles,
		// Token: 0x040001E3 RID: 483
		UICC_Action_AppScanMsi,
		// Token: 0x040001E4 RID: 484
		UICC_Action_AppScanAssemblies,
		// Token: 0x040001E5 RID: 485
		UICC_Action_AppScanUpgradeCodes,
		// Token: 0x040001E6 RID: 486
		UICC_Action_AppScanProductNames,
		// Token: 0x040001E7 RID: 487
		UICC_Action_AppMatchReg,
		// Token: 0x040001E8 RID: 488
		UICC_Action_AppParseLogs,
		// Token: 0x040001E9 RID: 489
		UICC_Action_AppEnumShortcuts,
		// Token: 0x040001EA RID: 490
		UICC_Action_AppAssignShortcuts,
		// Token: 0x040001EB RID: 491
		UICC_Action_AppCreateShortcutApps,
		// Token: 0x040001EC RID: 492
		UICC_Action_AppCleanup,
		// Token: 0x040001ED RID: 493
		UICC_Action_AppCollectReg,
		// Token: 0x040001EE RID: 494
		UICC_Action_AppLinkReg,
		// Token: 0x040001EF RID: 495
		UICC_Action_AppExpandFolders,
		// Token: 0x040001F0 RID: 496
		UICC_Action_AppScanDlls,
		// Token: 0x040001F1 RID: 497
		UICC_Action_AppAssignDep,
		// Token: 0x040001F2 RID: 498
		UICC_Action_MacSaving,
		// Token: 0x040001F3 RID: 499
		UICC_Action_MacLoading,
		// Token: 0x040001F4 RID: 500
		UICC_Action_TaskSaving,
		// Token: 0x040001F5 RID: 501
		UICC_Action_TaskLoading,
		// Token: 0x040001F6 RID: 502
		UICC_Action_ChlBuilding,
		// Token: 0x040001F7 RID: 503
		UICC_Action_FillProgressDisk,
		// Token: 0x040001F8 RID: 504
		UICC_Action_FillProgressReg,
		// Token: 0x040001F9 RID: 505
		UICC_Action_UnloadProgressDisk,
		// Token: 0x040001FA RID: 506
		UICC_Action_UnloadProgressReg,
		// Token: 0x040001FB RID: 507
		UICC_Action_UndoProgressDisk,
		// Token: 0x040001FC RID: 508
		UICC_Action_UndoProgressReg,
		// Token: 0x040001FD RID: 509
		UICC_Action_CreatingUsers,
		// Token: 0x040001FE RID: 510
		UICC_Action_MigratingPasswords,
		// Token: 0x040001FF RID: 511
		UICC_Action_PostMigSetup,
		// Token: 0x04000200 RID: 512
		UICC_Action_CreatingJournals,
		// Token: 0x04000201 RID: 513
		UICC_Action_CreatingJournalsFor,
		// Token: 0x04000202 RID: 514
		UICC_Item_ProgSection,
		// Token: 0x04000203 RID: 515
		UICC_Item_Remaining,
		// Token: 0x04000204 RID: 516
		UICC_Item_AppRegExtensions,
		// Token: 0x04000205 RID: 517
		UICC_Item_AppRegProgids,
		// Token: 0x04000206 RID: 518
		UICC_Item_AppRegClsids,
		// Token: 0x04000207 RID: 519
		UICC_Item_AppRegAppids,
		// Token: 0x04000208 RID: 520
		UICC_Item_AppRegTypelibs,
		// Token: 0x04000209 RID: 521
		UICC_Item_AppRegInterfaces,
		// Token: 0x0400020A RID: 522
		UICC_Item_AppRegApplications,
		// Token: 0x0400020B RID: 523
		UICC_Item_AppRegComponentCategories,
		// Token: 0x0400020C RID: 524
		UICC_Item_AppRegMime,
		// Token: 0x0400020D RID: 525
		UICC_Item_AppRegAppPaths,
		// Token: 0x0400020E RID: 526
		UICC_Item_AppRegAutoStart,
		// Token: 0x0400020F RID: 527
		UICC_Item_AppRegStartupThis,
		// Token: 0x04000210 RID: 528
		UICC_Item_AppRegActiveSetup,
		// Token: 0x04000211 RID: 529
		UICC_Item_AppRegBhos,
		// Token: 0x04000212 RID: 530
		UICC_Item_AppRegExplorerBars,
		// Token: 0x04000213 RID: 531
		UICC_Item_AppRegIeToolbars,
		// Token: 0x04000214 RID: 532
		UICC_Item_AppRegIeExtensions,
		// Token: 0x04000215 RID: 533
		UICC_Item_AppRegIeMenuExt,
		// Token: 0x04000216 RID: 534
		UICC_Item_AppRegUrlSearchHooks,
		// Token: 0x04000217 RID: 535
		UICC_Item_AppRegNamespace,
		// Token: 0x04000218 RID: 536
		UICC_Item_AppRegServices,
		// Token: 0x04000219 RID: 537
		UICC_Item_AppRegEventLog,
		// Token: 0x0400021A RID: 538
		UICC_Item_AppRegMsiFolders,
		// Token: 0x0400021B RID: 539
		UICC_Item_AppRegSharedDlls,
		// Token: 0x0400021C RID: 540
		UICC_Item_AppRegFontsSettings,
		// Token: 0x0400021D RID: 541
		UICC_Item_AppRegShellExtensions,
		// Token: 0x0400021E RID: 542
		UICC_Item_AppRegAssemblies,
		// Token: 0x0400021F RID: 543
		UICC_Item_AppRegClients,
		// Token: 0x04000220 RID: 544
		UICC_Item_AppRegProtocols,
		// Token: 0x04000221 RID: 545
		UICC_Item_AppRegFileExts,
		// Token: 0x04000222 RID: 546
		UICC_Item_AppRegMmcNodeTypes,
		// Token: 0x04000223 RID: 547
		UICC_Item_AppRegMmcSnapins,
		// Token: 0x04000224 RID: 548
		UICC_Item_AppRegControlPanel,
		// Token: 0x04000225 RID: 549
		UICC_Item_AppRegTasks,
		// Token: 0x04000226 RID: 550
		UICC_Item_Disk,
		// Token: 0x04000227 RID: 551
		UICC_Item_Reg,
		// Token: 0x04000228 RID: 552
		UICC_Item_UserProfile,
		// Token: 0x04000229 RID: 553
		UICC_FIPS_Enforced,
		// Token: 0x0400022A RID: 554
		UICC_InitError_Corrupted,
		// Token: 0x0400022B RID: 555
		UICC_InitError_InvalidPolicy,
		// Token: 0x0400022C RID: 556
		UICC_TransferError_USBSSL,
		// Token: 0x0400022D RID: 557
		UICC_InitError_PolicySameDomain,
		// Token: 0x0400022E RID: 558
		UICC_TransferError_NotSameDomain
	}
}
