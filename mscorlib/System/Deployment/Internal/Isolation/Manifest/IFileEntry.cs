using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006D8 RID: 1752
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("A2A55FAD-349B-469b-BF12-ADC33D14A937")]
	[ComImport]
	internal interface IFileEntry
	{
		// Token: 0x17000CD7 RID: 3287
		// (get) Token: 0x06005077 RID: 20599
		FileEntry AllData { [SecurityCritical] get; }

		// Token: 0x17000CD8 RID: 3288
		// (get) Token: 0x06005078 RID: 20600
		string Name { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000CD9 RID: 3289
		// (get) Token: 0x06005079 RID: 20601
		uint HashAlgorithm { [SecurityCritical] get; }

		// Token: 0x17000CDA RID: 3290
		// (get) Token: 0x0600507A RID: 20602
		string LoadFrom { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000CDB RID: 3291
		// (get) Token: 0x0600507B RID: 20603
		string SourcePath { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000CDC RID: 3292
		// (get) Token: 0x0600507C RID: 20604
		string ImportPath { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000CDD RID: 3293
		// (get) Token: 0x0600507D RID: 20605
		string SourceName { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000CDE RID: 3294
		// (get) Token: 0x0600507E RID: 20606
		string Location { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000CDF RID: 3295
		// (get) Token: 0x0600507F RID: 20607
		object HashValue { [SecurityCritical] [return: MarshalAs(UnmanagedType.Interface)] get; }

		// Token: 0x17000CE0 RID: 3296
		// (get) Token: 0x06005080 RID: 20608
		ulong Size { [SecurityCritical] get; }

		// Token: 0x17000CE1 RID: 3297
		// (get) Token: 0x06005081 RID: 20609
		string Group { [SecurityCritical] [return: MarshalAs(UnmanagedType.LPWStr)] get; }

		// Token: 0x17000CE2 RID: 3298
		// (get) Token: 0x06005082 RID: 20610
		uint Flags { [SecurityCritical] get; }

		// Token: 0x17000CE3 RID: 3299
		// (get) Token: 0x06005083 RID: 20611
		IMuiResourceMapEntry MuiMapping { [SecurityCritical] get; }

		// Token: 0x17000CE4 RID: 3300
		// (get) Token: 0x06005084 RID: 20612
		uint WritableType { [SecurityCritical] get; }

		// Token: 0x17000CE5 RID: 3301
		// (get) Token: 0x06005085 RID: 20613
		ISection HashElements { [SecurityCritical] get; }
	}
}
