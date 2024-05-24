using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000087 RID: 135
	[CompilerGenerated]
	[Guid("18946C8B-1EE0-41D8-BC06-178601835EED")]
	[TypeIdentifier]
	[ComImport]
	public interface IProgressCallbacks
	{
		// Token: 0x0600045C RID: 1116
		[DispId(1)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnTaskChanged([In] UI_CALLBACK_CODE code, [MarshalAs(UnmanagedType.BStr)] [In] string strTask);

		// Token: 0x0600045D RID: 1117
		[DispId(2)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnActionChanged([In] UI_CALLBACK_CODE code, [MarshalAs(UnmanagedType.BStr)] [In] string strAction);

		// Token: 0x0600045E RID: 1118
		[DispId(3)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnItemChanged([In] UI_CALLBACK_CODE code, [MarshalAs(UnmanagedType.BStr)] [In] string newVal);

		// Token: 0x0600045F RID: 1119
		[DispId(4)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnPercentageChanged([In] ushort newVal);

		// Token: 0x06000460 RID: 1120
		[DispId(5)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void OnBytesProcessedChanged([In] ulong newVal);
	}
}
