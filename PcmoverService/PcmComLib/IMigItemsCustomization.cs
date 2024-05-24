using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace PcmComLib
{
	// Token: 0x02000073 RID: 115
	[CompilerGenerated]
	[Guid("A0FAC303-D4F8-4B2D-B307-9CB78F9E82BB")]
	[TypeIdentifier]
	[ComImport]
	public interface IMigItemsCustomization
	{
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x0600037C RID: 892
		[DispId(1)]
		MIGITEMS_OPTIONS DefaultOption { [DispId(1)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x0600037D RID: 893
		void _VtblGap1_1();

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600037E RID: 894
		[DispId(3)]
		bool bInteractive { [DispId(3)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600037F RID: 895
		[DispId(4)]
		MIGITEMS_ENABLED EnabledItems { [DispId(4)] [MethodImpl(MethodImplOptions.InternalCall)] get; }
	}
}
