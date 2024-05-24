using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000069 RID: 105
	[CompilerGenerated]
	[Guid("66A37BD6-12FB-4BFF-9071-F55BB3AADC0F")]
	[TypeIdentifier]
	[ComImport]
	public interface IEnginePolicy
	{
		// Token: 0x0600030B RID: 779
		void _VtblGap1_2();

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600030C RID: 780
		[DispId(4)]
		bool bRequireSerialNumber { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600030D RID: 781
		[DispId(5)]
		bool bValidateSerialNumber { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600030E RID: 782
		void _VtblGap2_1();

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600030F RID: 783
		[DispId(7)]
		bool bGetSerialNumberFromServer { [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000310 RID: 784
		void _VtblGap3_1();

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000311 RID: 785
		[DispId(9)]
		bool bVerifyHardwareOemOnOld { [DispId(9)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000312 RID: 786
		[DispId(10)]
		bool bVerifyHardwareOemOnNew { [DispId(10)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000313 RID: 787
		[DispId(11)]
		uint nEdition { [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06000314 RID: 788
		void _VtblGap4_3();

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000315 RID: 789
		[DispId(15)]
		string strValidationPrefix { [DispId(15)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x06000316 RID: 790
		void _VtblGap5_1();

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000317 RID: 791
		[DispId(17)]
		string strValidationServer { [DispId(17)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000318 RID: 792
		[DispId(18)]
		uint nOemId { [DispId(18)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000319 RID: 793
		[DispId(19)]
		BrandEnginePolicy BrandEnginePolicy { [DispId(19)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600031A RID: 794
		[DispId(20)]
		string WebValidatorShortcut { [DispId(20)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; }
	}
}
