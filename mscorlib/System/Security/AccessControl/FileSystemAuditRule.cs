﻿using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x0200021A RID: 538
	public sealed class FileSystemAuditRule : AuditRule
	{
		// Token: 0x06001F3B RID: 7995 RVA: 0x0006D650 File Offset: 0x0006B850
		public FileSystemAuditRule(IdentityReference identity, FileSystemRights fileSystemRights, AuditFlags flags) : this(identity, fileSystemRights, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		// Token: 0x06001F3C RID: 7996 RVA: 0x0006D65D File Offset: 0x0006B85D
		public FileSystemAuditRule(IdentityReference identity, FileSystemRights fileSystemRights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : this(identity, FileSystemAuditRule.AccessMaskFromRights(fileSystemRights), false, inheritanceFlags, propagationFlags, flags)
		{
		}

		// Token: 0x06001F3D RID: 7997 RVA: 0x0006D672 File Offset: 0x0006B872
		public FileSystemAuditRule(string identity, FileSystemRights fileSystemRights, AuditFlags flags) : this(new NTAccount(identity), fileSystemRights, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		// Token: 0x06001F3E RID: 7998 RVA: 0x0006D684 File Offset: 0x0006B884
		public FileSystemAuditRule(string identity, FileSystemRights fileSystemRights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : this(new NTAccount(identity), FileSystemAuditRule.AccessMaskFromRights(fileSystemRights), false, inheritanceFlags, propagationFlags, flags)
		{
		}

		// Token: 0x06001F3F RID: 7999 RVA: 0x0006D69E File Offset: 0x0006B89E
		internal FileSystemAuditRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, flags)
		{
		}

		// Token: 0x06001F40 RID: 8000 RVA: 0x0006D6AF File Offset: 0x0006B8AF
		private static int AccessMaskFromRights(FileSystemRights fileSystemRights)
		{
			if (fileSystemRights < (FileSystemRights)0 || fileSystemRights > FileSystemRights.FullControl)
			{
				throw new ArgumentOutOfRangeException("fileSystemRights", Environment.GetResourceString("Argument_InvalidEnumValue", new object[]
				{
					fileSystemRights,
					"FileSystemRights"
				}));
			}
			return (int)fileSystemRights;
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x06001F41 RID: 8001 RVA: 0x0006D6EA File Offset: 0x0006B8EA
		public FileSystemRights FileSystemRights
		{
			get
			{
				return FileSystemAccessRule.RightsFromAccessMask(base.AccessMask);
			}
		}
	}
}
