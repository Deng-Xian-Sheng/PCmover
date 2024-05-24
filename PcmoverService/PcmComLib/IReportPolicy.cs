using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x0200008B RID: 139
	[CompilerGenerated]
	[Guid("D377B1DF-274D-4ECD-BE93-96EFD8266F9C")]
	[TypeIdentifier]
	[ComImport]
	public interface IReportPolicy
	{
		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000482 RID: 1154
		// (set) Token: 0x06000483 RID: 1155
		[DispId(1)]
		REPORT_TYPE Type { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000484 RID: 1156
		// (set) Token: 0x06000485 RID: 1157
		[DispId(2)]
		bool bAppend { [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(2)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000486 RID: 1158
		// (set) Token: 0x06000487 RID: 1159
		[DispId(3)]
		bool bTimeStamp { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000488 RID: 1160
		// (set) Token: 0x06000489 RID: 1161
		[DispId(4)]
		bool bExceptionsOnly { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x0600048A RID: 1162
		// (set) Token: 0x0600048B RID: 1163
		[DispId(5)]
		string strFileName { [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(5)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600048C RID: 1164
		// (set) Token: 0x0600048D RID: 1165
		[DispId(6)]
		string Mask { [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] [return: MarshalAs(UnmanagedType.BStr)] get; [DispId(6)] [MethodImpl(MethodImplOptions.InternalCall)] [param: MarshalAs(UnmanagedType.BStr)] [param: In] set; }

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x0600048E RID: 1166
		// (set) Token: 0x0600048F RID: 1167
		[DispId(7)]
		uint nItems { [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(7)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000490 RID: 1168
		// (set) Token: 0x06000491 RID: 1169
		[DispId(8)]
		bool bMigrated { [DispId(8)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(8)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000492 RID: 1170
		// (set) Token: 0x06000493 RID: 1171
		[DispId(9)]
		bool bShowComponents { [DispId(9)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(9)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000494 RID: 1172
		// (set) Token: 0x06000495 RID: 1173
		[DispId(10)]
		REPORT_FORMAT Format { [DispId(10)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(10)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000496 RID: 1174
		// (set) Token: 0x06000497 RID: 1175
		[DispId(11)]
		REPORT_GENERATOR Generator { [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] get; [DispId(11)] [MethodImpl(MethodImplOptions.InternalCall)] [param: In] set; }
	}
}
