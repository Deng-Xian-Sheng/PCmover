using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200005A RID: 90
	[CompilerGenerated]
	[Guid("C1F1073F-A17F-4FB0-99DE-25B72CD9CBB3")]
	[TypeIdentifier]
	[ComImport]
	public interface IAppCallbacks
	{
		// Token: 0x0600029D RID: 669
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		int DisplayMessageBox([MarshalAs(UnmanagedType.BStr)] [In] string Msg, [In] uint nType, [In] uint nIDHelp, [In] int nDefault);

		// Token: 0x0600029E RID: 670
		[DispId(2)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		int DisplayUiccMessage([In] UI_CALLBACK_CODE code, [MarshalAs(UnmanagedType.BStr)] [In] string Msg, [In] uint nType, [In] uint nIDHelp, [In] int nDefault);

		// Token: 0x0600029F RID: 671
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		int DisplayUiccMessage1Param([In] UI_CALLBACK_CODE code, [MarshalAs(UnmanagedType.BStr)] [In] string param, [MarshalAs(UnmanagedType.BStr)] [In] string Msg, [In] uint nType, [In] uint nIDHelp, [In] int nDefault);

		// Token: 0x060002A0 RID: 672
		[DispId(4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		int DisplayUiccMessageAndUrl([In] UI_CALLBACK_CODE code, [MarshalAs(UnmanagedType.BStr)] [In] string url, [MarshalAs(UnmanagedType.BStr)] [In] string Msg, [In] uint nType, [In] uint nIDHelp, [In] int nDefault);

		// Token: 0x060002A1 RID: 673
		[DispId(5)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void DisplayWrongEditionError([In] ulong taskId, [In] uint otherEdition, [In] uint thisEdition, [MarshalAs(UnmanagedType.BStr)] [In] string Msg);

		// Token: 0x060002A2 RID: 674
		[DispId(6)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void DisplaySaveLoadException([In] UI_EXCEPTION_TYPE uxt, [In] int cause, [In] int errorCode, [MarshalAs(UnmanagedType.BStr)] [In] string strFileName, [In] bool bSaving, [In] bool bNetwork, [MarshalAs(UnmanagedType.BStr)] [In] string strFormattedMessage);

		// Token: 0x060002A3 RID: 675
		[DispId(7)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool DisplaySpanNotification([In] UI_CALLBACK_CODE code, [MarshalAs(UnmanagedType.BStr)] [In] string strFileName, [MarshalAs(UnmanagedType.BStr)] [In] string Msg, [In] bool showCheckbox, out bool dontNotify);

		// Token: 0x060002A4 RID: 676
		[DispId(8)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool ImpersonateUser();

		// Token: 0x060002A5 RID: 677
		[DispId(9)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void StopImpersonating();

		// Token: 0x060002A6 RID: 678
		[DispId(10)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool PromptForVanPassword([In] ulong taskId);

		// Token: 0x060002A7 RID: 679
		[DispId(11)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool IsTransferValidationCode([MarshalAs(UnmanagedType.BStr)] [In] string tvc);

		// Token: 0x060002A8 RID: 680
		[DispId(12)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		uint GetTransferId([MarshalAs(UnmanagedType.BStr)] [In] string tvc, [MarshalAs(UnmanagedType.BStr)] [In] string editionString, [MarshalAs(UnmanagedType.BStr)] [In] string srcNetName, [In] uint srcId, [MarshalAs(UnmanagedType.BStr)] [In] string dstNetName, [In] uint dstId);

		// Token: 0x060002A9 RID: 681
		[DispId(13)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetTransferValidationCode([In] uint transferId, [MarshalAs(UnmanagedType.BStr)] [In] string editionString, [MarshalAs(UnmanagedType.BStr)] [In] string srcNetName, [In] uint srcId, [MarshalAs(UnmanagedType.BStr)] [In] string dstNetName, [In] uint dstId);

		// Token: 0x060002AA RID: 682
		[DispId(14)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool OpenAppProfileDatabase([MarshalAs(UnmanagedType.BStr)] [In] string strFullName);

		// Token: 0x060002AB RID: 683
		[DispId(15)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UI1)]
		byte[] LookupAppProfileFile([MarshalAs(UnmanagedType.BStr)] [In] string strFolderName, [MarshalAs(UnmanagedType.BStr)] [In] string strFileName);

		// Token: 0x060002AC RID: 684
		[DispId(16)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetAppProfileFileList([MarshalAs(UnmanagedType.BStr)] [In] string strFolderName);

		// Token: 0x060002AD RID: 685
		[DispId(17)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void CloseAppProfileDatabase();

		// Token: 0x060002AE RID: 686
		[DispId(18)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		bool PromptForProxyAuth([MarshalAs(UnmanagedType.BStr)] [In] string strProxy);

		// Token: 0x060002AF RID: 687
		[DispId(19)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetProxyForUrl([MarshalAs(UnmanagedType.BStr)] [In] string url);
	}
}
