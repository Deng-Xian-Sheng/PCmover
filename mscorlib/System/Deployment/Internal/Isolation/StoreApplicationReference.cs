using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006A1 RID: 1697
	internal struct StoreApplicationReference
	{
		// Token: 0x06004FC3 RID: 20419 RVA: 0x0011C785 File Offset: 0x0011A985
		public StoreApplicationReference(Guid RefScheme, string Id, string NcData)
		{
			this.Size = (uint)Marshal.SizeOf(typeof(StoreApplicationReference));
			this.Flags = StoreApplicationReference.RefFlags.Nothing;
			this.GuidScheme = RefScheme;
			this.Identifier = Id;
			this.NonCanonicalData = NcData;
		}

		// Token: 0x06004FC4 RID: 20420 RVA: 0x0011C7B8 File Offset: 0x0011A9B8
		[SecurityCritical]
		public IntPtr ToIntPtr()
		{
			IntPtr intPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf<StoreApplicationReference>(this));
			Marshal.StructureToPtr<StoreApplicationReference>(this, intPtr, false);
			return intPtr;
		}

		// Token: 0x06004FC5 RID: 20421 RVA: 0x0011C7E4 File Offset: 0x0011A9E4
		[SecurityCritical]
		public static void Destroy(IntPtr ip)
		{
			if (ip != IntPtr.Zero)
			{
				Marshal.DestroyStructure(ip, typeof(StoreApplicationReference));
				Marshal.FreeCoTaskMem(ip);
			}
		}

		// Token: 0x04002227 RID: 8743
		[MarshalAs(UnmanagedType.U4)]
		public uint Size;

		// Token: 0x04002228 RID: 8744
		[MarshalAs(UnmanagedType.U4)]
		public StoreApplicationReference.RefFlags Flags;

		// Token: 0x04002229 RID: 8745
		public Guid GuidScheme;

		// Token: 0x0400222A RID: 8746
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Identifier;

		// Token: 0x0400222B RID: 8747
		[MarshalAs(UnmanagedType.LPWStr)]
		public string NonCanonicalData;

		// Token: 0x02000C46 RID: 3142
		[Flags]
		public enum RefFlags
		{
			// Token: 0x04003766 RID: 14182
			Nothing = 0
		}
	}
}
