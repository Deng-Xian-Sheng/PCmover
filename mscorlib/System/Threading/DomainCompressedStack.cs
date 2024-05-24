using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Threading
{
	// Token: 0x020004F1 RID: 1265
	[Serializable]
	internal sealed class DomainCompressedStack
	{
		// Token: 0x1700090C RID: 2316
		// (get) Token: 0x06003BCB RID: 15307 RVA: 0x000E2D30 File Offset: 0x000E0F30
		internal PermissionListSet PLS
		{
			get
			{
				return this.m_pls;
			}
		}

		// Token: 0x1700090D RID: 2317
		// (get) Token: 0x06003BCC RID: 15308 RVA: 0x000E2D38 File Offset: 0x000E0F38
		internal bool ConstructionHalted
		{
			get
			{
				return this.m_bHaltConstruction;
			}
		}

		// Token: 0x06003BCD RID: 15309 RVA: 0x000E2D40 File Offset: 0x000E0F40
		[SecurityCritical]
		private static DomainCompressedStack CreateManagedObject(IntPtr unmanagedDCS)
		{
			DomainCompressedStack domainCompressedStack = new DomainCompressedStack();
			domainCompressedStack.m_pls = PermissionListSet.CreateCompressedState(unmanagedDCS, out domainCompressedStack.m_bHaltConstruction);
			return domainCompressedStack;
		}

		// Token: 0x06003BCE RID: 15310
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int GetDescCount(IntPtr dcs);

		// Token: 0x06003BCF RID: 15311
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void GetDomainPermissionSets(IntPtr dcs, out PermissionSet granted, out PermissionSet refused);

		// Token: 0x06003BD0 RID: 15312
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool GetDescriptorInfo(IntPtr dcs, int index, out PermissionSet granted, out PermissionSet refused, out Assembly assembly, out FrameSecurityDescriptor fsd);

		// Token: 0x06003BD1 RID: 15313
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool IgnoreDomain(IntPtr dcs);

		// Token: 0x04001976 RID: 6518
		private PermissionListSet m_pls;

		// Token: 0x04001977 RID: 6519
		private bool m_bHaltConstruction;
	}
}
