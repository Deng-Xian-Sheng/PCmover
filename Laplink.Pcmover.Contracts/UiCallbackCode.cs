using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000090 RID: 144
	public enum UiCallbackCode
	{
		// Token: 0x0400033E RID: 830
		Empty,
		// Token: 0x0400033F RID: 831
		Custom,
		// Token: 0x04000340 RID: 832
		InitError_HasInitializedBefore,
		// Token: 0x04000341 RID: 833
		InitError_NetworkExecutionDisallowed,
		// Token: 0x04000342 RID: 834
		InitError_AdminRequired,
		// Token: 0x04000343 RID: 835
		InitError_ShlnkNotFound,
		// Token: 0x04000344 RID: 836
		InitError_ShlnkProcess,
		// Token: 0x04000345 RID: 837
		InitError_ShlnkRegister,
		// Token: 0x04000346 RID: 838
		InitError_DomainUserRequired,
		// Token: 0x04000347 RID: 839
		InitError_JoinDisallowed,
		// Token: 0x04000348 RID: 840
		InitError_JoinRequired,
		// Token: 0x04000349 RID: 841
		InitError_WrongDomain,
		// Token: 0x0400034A RID: 842
		InitError_CannotCreateLogs,
		// Token: 0x0400034B RID: 843
		InitError_PolicyDisallow,
		// Token: 0x0400034C RID: 844
		InitError_PolicyUndoDisabled,
		// Token: 0x0400034D RID: 845
		InitError_PolicySnapshotFile,
		// Token: 0x0400034E RID: 846
		InitError_PolicyNoSnapshot,
		// Token: 0x0400034F RID: 847
		InitError_NoDomain,
		// Token: 0x04000350 RID: 848
		InitError_BadArchiveFormat,
		// Token: 0x04000351 RID: 849
		InitError_BadArchiveVersion,
		// Token: 0x04000352 RID: 850
		InitError1Param_CannotCreateFolder,
		// Token: 0x04000353 RID: 851
		InitErrorUrl_Timeout,
		// Token: 0x04000354 RID: 852
		RegError1Param_BadId,
		// Token: 0x04000355 RID: 853
		MachineError_RegLoaded,
		// Token: 0x04000356 RID: 854
		MachineError_RegHives,
		// Token: 0x04000357 RID: 855
		MachineError_RegNoCCS,
		// Token: 0x04000358 RID: 856
		MachineError_TreeMgr,
		// Token: 0x04000359 RID: 857
		MachineErrorUrl_WindowsVersionSrc,
		// Token: 0x0400035A RID: 858
		MachineErrorUrl_WindowsVersionDst,
		// Token: 0x0400035B RID: 859
		TransferError_MergeIni,
		// Token: 0x0400035C RID: 860
		TransferError_WrongOem,
		// Token: 0x0400035D RID: 861
		TransferError_FipsEnforced,
		// Token: 0x0400035E RID: 862
		TransferError_PostMigSetup,
		// Token: 0x0400035F RID: 863
		TransferError_WrongVersion,
		// Token: 0x04000360 RID: 864
		TransferError1Param_BadPathSavingArchive,
		// Token: 0x04000361 RID: 865
		TransferError1Param_CreateUser,
		// Token: 0x04000362 RID: 866
		Transfer1Param_SpanDisk,
		// Token: 0x04000363 RID: 867
		Transfer1Param_SpanBlankDisk,
		// Token: 0x04000364 RID: 868
		Action_AppFindApps,
		// Token: 0x04000365 RID: 869
		Action_AppGetInfo,
		// Token: 0x04000366 RID: 870
		Action_AppScanShortcuts,
		// Token: 0x04000367 RID: 871
		Action_AppScanOthers,
		// Token: 0x04000368 RID: 872
		Action_AppScanAll,
		// Token: 0x04000369 RID: 873
		Action_AppScanMsiProducts,
		// Token: 0x0400036A RID: 874
		Action_AppScanAddRem,
		// Token: 0x0400036B RID: 875
		Action_AppDetermineProfiles,
		// Token: 0x0400036C RID: 876
		Action_AppScanMsi,
		// Token: 0x0400036D RID: 877
		Action_AppScanAssemblies,
		// Token: 0x0400036E RID: 878
		Action_AppScanUpgradeCodes,
		// Token: 0x0400036F RID: 879
		Action_AppScanProductNames,
		// Token: 0x04000370 RID: 880
		Action_AppMatchReg,
		// Token: 0x04000371 RID: 881
		Action_AppParseLogs,
		// Token: 0x04000372 RID: 882
		Action_AppEnumShortcuts,
		// Token: 0x04000373 RID: 883
		Action_AppAssignShortcuts,
		// Token: 0x04000374 RID: 884
		Action_AppCreateShortcutApps,
		// Token: 0x04000375 RID: 885
		Action_AppCleanup,
		// Token: 0x04000376 RID: 886
		Action_AppCollectReg,
		// Token: 0x04000377 RID: 887
		Action_AppLinkReg,
		// Token: 0x04000378 RID: 888
		Action_AppExpandFolders,
		// Token: 0x04000379 RID: 889
		Action_AppScanDlls,
		// Token: 0x0400037A RID: 890
		Action_AppAssignDep,
		// Token: 0x0400037B RID: 891
		Action_MacSaving,
		// Token: 0x0400037C RID: 892
		Action_MacLoading,
		// Token: 0x0400037D RID: 893
		Action_TaskSaving,
		// Token: 0x0400037E RID: 894
		Action_TaskLoading,
		// Token: 0x0400037F RID: 895
		Action_ChlBuilding,
		// Token: 0x04000380 RID: 896
		Action_FillProgressDisk,
		// Token: 0x04000381 RID: 897
		Action_FillProgressReg,
		// Token: 0x04000382 RID: 898
		Action_UnloadProgressDisk,
		// Token: 0x04000383 RID: 899
		Action_UnloadProgressReg,
		// Token: 0x04000384 RID: 900
		Action_UndoProgressDisk,
		// Token: 0x04000385 RID: 901
		Action_UndoProgressReg,
		// Token: 0x04000386 RID: 902
		Action_CreatingUsers,
		// Token: 0x04000387 RID: 903
		Action_MigratingPasswords,
		// Token: 0x04000388 RID: 904
		Action_PostMigSetup,
		// Token: 0x04000389 RID: 905
		Action_CreatingJournals,
		// Token: 0x0400038A RID: 906
		Action_CreatingJournalsFor,
		// Token: 0x0400038B RID: 907
		Item_ProgSection,
		// Token: 0x0400038C RID: 908
		Item_Remaining,
		// Token: 0x0400038D RID: 909
		Item_AppRegExtensions,
		// Token: 0x0400038E RID: 910
		Item_AppRegProgids,
		// Token: 0x0400038F RID: 911
		Item_AppRegClsids,
		// Token: 0x04000390 RID: 912
		Item_AppRegAppids,
		// Token: 0x04000391 RID: 913
		Item_AppRegTypelibs,
		// Token: 0x04000392 RID: 914
		Item_AppRegInterfaces,
		// Token: 0x04000393 RID: 915
		Item_AppRegApplications,
		// Token: 0x04000394 RID: 916
		Item_AppRegComponentCategories,
		// Token: 0x04000395 RID: 917
		Item_AppRegMime,
		// Token: 0x04000396 RID: 918
		Item_AppRegAppPaths,
		// Token: 0x04000397 RID: 919
		Item_AppRegAutoStart,
		// Token: 0x04000398 RID: 920
		Item_AppRegStartupThis,
		// Token: 0x04000399 RID: 921
		Item_AppRegActiveSetup,
		// Token: 0x0400039A RID: 922
		Item_AppRegBhos,
		// Token: 0x0400039B RID: 923
		Item_AppRegExplorerBars,
		// Token: 0x0400039C RID: 924
		Item_AppRegIeToolbars,
		// Token: 0x0400039D RID: 925
		Item_AppRegIeExtensions,
		// Token: 0x0400039E RID: 926
		Item_AppRegIeMenuExt,
		// Token: 0x0400039F RID: 927
		Item_AppRegUrlSearchHooks,
		// Token: 0x040003A0 RID: 928
		Item_AppRegNamespace,
		// Token: 0x040003A1 RID: 929
		Item_AppRegServices,
		// Token: 0x040003A2 RID: 930
		Item_AppRegEventLog,
		// Token: 0x040003A3 RID: 931
		Item_AppRegMsiFolders,
		// Token: 0x040003A4 RID: 932
		Item_AppRegSharedDlls,
		// Token: 0x040003A5 RID: 933
		Item_AppRegFontsSettings,
		// Token: 0x040003A6 RID: 934
		Item_AppRegShellExtensions,
		// Token: 0x040003A7 RID: 935
		Item_AppRegAssemblies,
		// Token: 0x040003A8 RID: 936
		Item_AppRegClients,
		// Token: 0x040003A9 RID: 937
		Item_AppRegProtocols,
		// Token: 0x040003AA RID: 938
		Item_AppRegFileExts,
		// Token: 0x040003AB RID: 939
		Item_AppRegMmcNodeTypes,
		// Token: 0x040003AC RID: 940
		Item_AppRegMmcSnapins,
		// Token: 0x040003AD RID: 941
		Item_AppRegControlPanel,
		// Token: 0x040003AE RID: 942
		Item_AppRegTasks,
		// Token: 0x040003AF RID: 943
		Item_Disk,
		// Token: 0x040003B0 RID: 944
		Item_Reg,
		// Token: 0x040003B1 RID: 945
		Item_UserProfile,
		// Token: 0x040003B2 RID: 946
		InitError_FIPS_Enforced,
		// Token: 0x040003B3 RID: 947
		InitError_Corrupted,
		// Token: 0x040003B4 RID: 948
		InitError_InvalidPolicy,
		// Token: 0x040003B5 RID: 949
		TransferError_USBSSL,
		// Token: 0x040003B6 RID: 950
		InitError_PolicySameDomain,
		// Token: 0x040003B7 RID: 951
		TransferError_NotSameDomain,
		// Token: 0x040003B8 RID: 952
		START_SERVICE = 1000,
		// Token: 0x040003B9 RID: 953
		InitError_EngineWrongEditionId,
		// Token: 0x040003BA RID: 954
		InitError_EngineWrongOem,
		// Token: 0x040003BB RID: 955
		InitError_CannotLoadPcmCom,
		// Token: 0x040003BC RID: 956
		InitError_CannotFindCertificateService,
		// Token: 0x040003BD RID: 957
		InitError_UnexpectedException
	}
}
