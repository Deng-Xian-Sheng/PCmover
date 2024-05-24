using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000084 RID: 132
	[CompilerGenerated]
	[Guid("FBC33005-8476-4083-8DF9-C6C15BD3AEAC")]
	[TypeIdentifier]
	[ComImport]
	public interface IPolicy
	{
		// Token: 0x17000130 RID: 304
		// (get) Token: 0x0600043E RID: 1086
		[DispId(1)]
		PolicySettings PolicySettings { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600043F RID: 1087
		[DispId(2)]
		StartPolicy StartPolicy { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000440 RID: 1088
		[DispId(3)]
		AppSelCustomization AppSelCustomization { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000441 RID: 1089
		[DispId(4)]
		MigTypeCustomization MigTypeCustomization { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000442 RID: 1090
		[DispId(5)]
		MigItemsCustomization MigItemsCustomization { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000443 RID: 1091
		void _VtblGap1_2();

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000444 RID: 1092
		[DispId(8)]
		ConnectionPolicy ConnectionPolicy { [DispId(8)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000445 RID: 1093
		[DispId(9)]
		DonePolicy DonePolicy { [DispId(9)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000446 RID: 1094
		void _VtblGap2_2();

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000447 RID: 1095
		[DispId(12)]
		UserMapCustomization UserMapCustomization { [DispId(12)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000448 RID: 1096
		[DispId(13)]
		AlertPolicy AlertPolicy { [DispId(13)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x06000449 RID: 1097
		void _VtblGap3_3();

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600044A RID: 1098
		[DispId(17)]
		RegistrationPolicy RegistrationPolicy { [DispId(17)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600044B RID: 1099
		[DispId(18)]
		ReportsPolicy ReportsPolicy { [DispId(18)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600044C RID: 1100
		[DispId(19)]
		StringMap PropertiesPolicy { [DispId(19)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600044D RID: 1101
		[DispId(20)]
		bool IsDirFiltersInteractive { [DispId(20)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600044E RID: 1102
		[DispId(21)]
		bool IsDriveMapInteractive { [DispId(21)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600044F RID: 1103
		[DispId(22)]
		bool IsFileFiltersInteractive { [DispId(22)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000450 RID: 1104
		[DispId(23)]
		bool IsMigModInteractive { [DispId(23)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
