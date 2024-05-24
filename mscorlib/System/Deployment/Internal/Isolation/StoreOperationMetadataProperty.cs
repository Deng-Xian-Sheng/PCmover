using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006A6 RID: 1702
	internal struct StoreOperationMetadataProperty
	{
		// Token: 0x06004FD0 RID: 20432 RVA: 0x0011C94E File Offset: 0x0011AB4E
		public StoreOperationMetadataProperty(Guid PropertySet, string Name)
		{
			this = new StoreOperationMetadataProperty(PropertySet, Name, null);
		}

		// Token: 0x06004FD1 RID: 20433 RVA: 0x0011C959 File Offset: 0x0011AB59
		public StoreOperationMetadataProperty(Guid PropertySet, string Name, string Value)
		{
			this.GuidPropertySet = PropertySet;
			this.Name = Name;
			this.Value = Value;
			this.ValueSize = ((Value != null) ? new IntPtr((Value.Length + 1) * 2) : IntPtr.Zero);
		}

		// Token: 0x0400223D RID: 8765
		public Guid GuidPropertySet;

		// Token: 0x0400223E RID: 8766
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name;

		// Token: 0x0400223F RID: 8767
		[MarshalAs(UnmanagedType.SysUInt)]
		public IntPtr ValueSize;

		// Token: 0x04002240 RID: 8768
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Value;
	}
}
