using System;
using System.IO;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;

namespace System.Security.AccessControl
{
	// Token: 0x0200021C RID: 540
	public sealed class FileSecurity : FileSystemSecurity
	{
		// Token: 0x06001F59 RID: 8025 RVA: 0x0006DB13 File Offset: 0x0006BD13
		[SecuritySafeCritical]
		public FileSecurity() : base(false)
		{
		}

		// Token: 0x06001F5A RID: 8026 RVA: 0x0006DB1C File Offset: 0x0006BD1C
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
		public FileSecurity(string fileName, AccessControlSections includeSections) : base(false, fileName, includeSections, false)
		{
			string fullPathInternal = Path.GetFullPathInternal(fileName);
			FileIOPermission.QuickDemand(FileIOPermissionAccess.NoAccess, AccessControlActions.View, fullPathInternal, false, false);
		}

		// Token: 0x06001F5B RID: 8027 RVA: 0x0006DB44 File Offset: 0x0006BD44
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Assert, UnmanagedCode = true)]
		internal FileSecurity(SafeFileHandle handle, string fullPath, AccessControlSections includeSections) : base(false, handle, includeSections, false)
		{
			if (fullPath != null)
			{
				FileIOPermission.QuickDemand(FileIOPermissionAccess.NoAccess, AccessControlActions.View, fullPath, false, true);
				return;
			}
			FileIOPermission.QuickDemand(PermissionState.Unrestricted);
		}
	}
}
