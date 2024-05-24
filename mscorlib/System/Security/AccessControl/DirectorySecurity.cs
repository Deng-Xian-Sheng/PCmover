using System;
using System.IO;
using System.Security.Permissions;

namespace System.Security.AccessControl
{
	// Token: 0x0200021D RID: 541
	public sealed class DirectorySecurity : FileSystemSecurity
	{
		// Token: 0x06001F5C RID: 8028 RVA: 0x0006DB64 File Offset: 0x0006BD64
		[SecuritySafeCritical]
		public DirectorySecurity() : base(true)
		{
		}

		// Token: 0x06001F5D RID: 8029 RVA: 0x0006DB70 File Offset: 0x0006BD70
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
		public DirectorySecurity(string name, AccessControlSections includeSections) : base(true, name, includeSections, true)
		{
			string fullPathInternal = Path.GetFullPathInternal(name);
			FileIOPermission.QuickDemand(FileIOPermissionAccess.NoAccess, AccessControlActions.View, fullPathInternal, false, false);
		}
	}
}
