using System;
using System.Security.Principal;

namespace System.Security.AccessControl
{
	// Token: 0x02000219 RID: 537
	public sealed class FileSystemAccessRule : AccessRule
	{
		// Token: 0x06001F33 RID: 7987 RVA: 0x0006D55B File Offset: 0x0006B75B
		public FileSystemAccessRule(IdentityReference identity, FileSystemRights fileSystemRights, AccessControlType type) : this(identity, FileSystemAccessRule.AccessMaskFromRights(fileSystemRights, type), false, InheritanceFlags.None, PropagationFlags.None, type)
		{
		}

		// Token: 0x06001F34 RID: 7988 RVA: 0x0006D56F File Offset: 0x0006B76F
		public FileSystemAccessRule(string identity, FileSystemRights fileSystemRights, AccessControlType type) : this(new NTAccount(identity), FileSystemAccessRule.AccessMaskFromRights(fileSystemRights, type), false, InheritanceFlags.None, PropagationFlags.None, type)
		{
		}

		// Token: 0x06001F35 RID: 7989 RVA: 0x0006D588 File Offset: 0x0006B788
		public FileSystemAccessRule(IdentityReference identity, FileSystemRights fileSystemRights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) : this(identity, FileSystemAccessRule.AccessMaskFromRights(fileSystemRights, type), false, inheritanceFlags, propagationFlags, type)
		{
		}

		// Token: 0x06001F36 RID: 7990 RVA: 0x0006D59F File Offset: 0x0006B79F
		public FileSystemAccessRule(string identity, FileSystemRights fileSystemRights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) : this(new NTAccount(identity), FileSystemAccessRule.AccessMaskFromRights(fileSystemRights, type), false, inheritanceFlags, propagationFlags, type)
		{
		}

		// Token: 0x06001F37 RID: 7991 RVA: 0x0006D5BB File Offset: 0x0006B7BB
		internal FileSystemAccessRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) : base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, type)
		{
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06001F38 RID: 7992 RVA: 0x0006D5CC File Offset: 0x0006B7CC
		public FileSystemRights FileSystemRights
		{
			get
			{
				return FileSystemAccessRule.RightsFromAccessMask(base.AccessMask);
			}
		}

		// Token: 0x06001F39 RID: 7993 RVA: 0x0006D5DC File Offset: 0x0006B7DC
		internal static int AccessMaskFromRights(FileSystemRights fileSystemRights, AccessControlType controlType)
		{
			if (fileSystemRights < (FileSystemRights)0 || fileSystemRights > FileSystemRights.FullControl)
			{
				throw new ArgumentOutOfRangeException("fileSystemRights", Environment.GetResourceString("Argument_InvalidEnumValue", new object[]
				{
					fileSystemRights,
					"FileSystemRights"
				}));
			}
			if (controlType == AccessControlType.Allow)
			{
				fileSystemRights |= FileSystemRights.Synchronize;
			}
			else if (controlType == AccessControlType.Deny && fileSystemRights != FileSystemRights.FullControl && fileSystemRights != (FileSystemRights.ReadData | FileSystemRights.WriteData | FileSystemRights.AppendData | FileSystemRights.ReadExtendedAttributes | FileSystemRights.WriteExtendedAttributes | FileSystemRights.ExecuteFile | FileSystemRights.ReadAttributes | FileSystemRights.WriteAttributes | FileSystemRights.Delete | FileSystemRights.ReadPermissions | FileSystemRights.ChangePermissions | FileSystemRights.TakeOwnership | FileSystemRights.Synchronize))
			{
				fileSystemRights &= ~FileSystemRights.Synchronize;
			}
			return (int)fileSystemRights;
		}

		// Token: 0x06001F3A RID: 7994 RVA: 0x0006D64D File Offset: 0x0006B84D
		internal static FileSystemRights RightsFromAccessMask(int accessMask)
		{
			return (FileSystemRights)accessMask;
		}
	}
}
