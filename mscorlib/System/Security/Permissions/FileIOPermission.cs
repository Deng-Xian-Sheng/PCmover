﻿using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Security.Util;

namespace System.Security.Permissions
{
	// Token: 0x020002E1 RID: 737
	[ComVisible(true)]
	[Serializable]
	public sealed class FileIOPermission : CodeAccessPermission, IUnrestrictedPermission, IBuiltInPermission
	{
		// Token: 0x060025D5 RID: 9685 RVA: 0x00089E80 File Offset: 0x00088080
		public FileIOPermission(PermissionState state)
		{
			if (state == PermissionState.Unrestricted)
			{
				this.m_unrestricted = true;
				return;
			}
			if (state == PermissionState.None)
			{
				this.m_unrestricted = false;
				return;
			}
			throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPermissionState"));
		}

		// Token: 0x060025D6 RID: 9686 RVA: 0x00089EB0 File Offset: 0x000880B0
		[SecuritySafeCritical]
		public FileIOPermission(FileIOPermissionAccess access, string path)
		{
			FileIOPermission.VerifyAccess(access);
			string[] pathListOrig = new string[]
			{
				path
			};
			this.AddPathList(access, pathListOrig, false, true, false);
		}

		// Token: 0x060025D7 RID: 9687 RVA: 0x00089EDF File Offset: 0x000880DF
		[SecuritySafeCritical]
		public FileIOPermission(FileIOPermissionAccess access, string[] pathList)
		{
			FileIOPermission.VerifyAccess(access);
			this.AddPathList(access, pathList, false, true, false);
		}

		// Token: 0x060025D8 RID: 9688 RVA: 0x00089EF8 File Offset: 0x000880F8
		[SecuritySafeCritical]
		public FileIOPermission(FileIOPermissionAccess access, AccessControlActions control, string path)
		{
			FileIOPermission.VerifyAccess(access);
			string[] pathListOrig = new string[]
			{
				path
			};
			this.AddPathList(access, control, pathListOrig, false, true, false);
		}

		// Token: 0x060025D9 RID: 9689 RVA: 0x00089F28 File Offset: 0x00088128
		[SecuritySafeCritical]
		public FileIOPermission(FileIOPermissionAccess access, AccessControlActions control, string[] pathList) : this(access, control, pathList, true, true)
		{
		}

		// Token: 0x060025DA RID: 9690 RVA: 0x00089F35 File Offset: 0x00088135
		[SecurityCritical]
		internal FileIOPermission(FileIOPermissionAccess access, string[] pathList, bool checkForDuplicates, bool needFullPath)
		{
			FileIOPermission.VerifyAccess(access);
			this.AddPathList(access, pathList, checkForDuplicates, needFullPath, true);
		}

		// Token: 0x060025DB RID: 9691 RVA: 0x00089F4F File Offset: 0x0008814F
		[SecurityCritical]
		internal FileIOPermission(FileIOPermissionAccess access, AccessControlActions control, string[] pathList, bool checkForDuplicates, bool needFullPath)
		{
			FileIOPermission.VerifyAccess(access);
			this.AddPathList(access, control, pathList, checkForDuplicates, needFullPath, true);
		}

		// Token: 0x060025DC RID: 9692 RVA: 0x00089F6C File Offset: 0x0008816C
		public void SetPathList(FileIOPermissionAccess access, string path)
		{
			string[] pathList;
			if (path == null)
			{
				pathList = new string[0];
			}
			else
			{
				pathList = new string[]
				{
					path
				};
			}
			this.SetPathList(access, pathList, false);
		}

		// Token: 0x060025DD RID: 9693 RVA: 0x00089F99 File Offset: 0x00088199
		public void SetPathList(FileIOPermissionAccess access, string[] pathList)
		{
			this.SetPathList(access, pathList, true);
		}

		// Token: 0x060025DE RID: 9694 RVA: 0x00089FA4 File Offset: 0x000881A4
		internal void SetPathList(FileIOPermissionAccess access, string[] pathList, bool checkForDuplicates)
		{
			this.SetPathList(access, AccessControlActions.None, pathList, checkForDuplicates);
		}

		// Token: 0x060025DF RID: 9695 RVA: 0x00089FB0 File Offset: 0x000881B0
		[SecuritySafeCritical]
		internal void SetPathList(FileIOPermissionAccess access, AccessControlActions control, string[] pathList, bool checkForDuplicates)
		{
			FileIOPermission.VerifyAccess(access);
			if ((access & FileIOPermissionAccess.Read) != FileIOPermissionAccess.NoAccess)
			{
				this.m_read = null;
			}
			if ((access & FileIOPermissionAccess.Write) != FileIOPermissionAccess.NoAccess)
			{
				this.m_write = null;
			}
			if ((access & FileIOPermissionAccess.Append) != FileIOPermissionAccess.NoAccess)
			{
				this.m_append = null;
			}
			if ((access & FileIOPermissionAccess.PathDiscovery) != FileIOPermissionAccess.NoAccess)
			{
				this.m_pathDiscovery = null;
			}
			if ((control & AccessControlActions.View) != AccessControlActions.None)
			{
				this.m_viewAcl = null;
			}
			if ((control & AccessControlActions.Change) != AccessControlActions.None)
			{
				this.m_changeAcl = null;
			}
			this.m_unrestricted = false;
			this.AddPathList(access, control, pathList, checkForDuplicates, true, true);
		}

		// Token: 0x060025E0 RID: 9696 RVA: 0x0008A020 File Offset: 0x00088220
		[SecuritySafeCritical]
		public void AddPathList(FileIOPermissionAccess access, string path)
		{
			string[] pathListOrig;
			if (path == null)
			{
				pathListOrig = new string[0];
			}
			else
			{
				pathListOrig = new string[]
				{
					path
				};
			}
			this.AddPathList(access, pathListOrig, false, true, false);
		}

		// Token: 0x060025E1 RID: 9697 RVA: 0x0008A04F File Offset: 0x0008824F
		[SecuritySafeCritical]
		public void AddPathList(FileIOPermissionAccess access, string[] pathList)
		{
			this.AddPathList(access, pathList, true, true, true);
		}

		// Token: 0x060025E2 RID: 9698 RVA: 0x0008A05C File Offset: 0x0008825C
		[SecurityCritical]
		internal void AddPathList(FileIOPermissionAccess access, string[] pathListOrig, bool checkForDuplicates, bool needFullPath, bool copyPathList)
		{
			this.AddPathList(access, AccessControlActions.None, pathListOrig, checkForDuplicates, needFullPath, copyPathList);
		}

		// Token: 0x060025E3 RID: 9699 RVA: 0x0008A06C File Offset: 0x0008826C
		[SecurityCritical]
		internal void AddPathList(FileIOPermissionAccess access, AccessControlActions control, string[] pathListOrig, bool checkForDuplicates, bool needFullPath, bool copyPathList)
		{
			if (pathListOrig == null)
			{
				throw new ArgumentNullException("pathList");
			}
			if (pathListOrig.Length == 0)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_EmptyPath"));
			}
			FileIOPermission.VerifyAccess(access);
			if (this.m_unrestricted)
			{
				return;
			}
			string[] array = pathListOrig;
			if (copyPathList)
			{
				array = new string[pathListOrig.Length];
				Array.Copy(pathListOrig, array, pathListOrig.Length);
			}
			FileIOPermission.CheckIllegalCharacters(array, needFullPath);
			ArrayList values = StringExpressionSet.CreateListFromExpressions(array, needFullPath);
			if ((access & FileIOPermissionAccess.Read) != FileIOPermissionAccess.NoAccess)
			{
				if (this.m_read == null)
				{
					this.m_read = new FileIOAccess();
				}
				this.m_read.AddExpressions(values, checkForDuplicates);
			}
			if ((access & FileIOPermissionAccess.Write) != FileIOPermissionAccess.NoAccess)
			{
				if (this.m_write == null)
				{
					this.m_write = new FileIOAccess();
				}
				this.m_write.AddExpressions(values, checkForDuplicates);
			}
			if ((access & FileIOPermissionAccess.Append) != FileIOPermissionAccess.NoAccess)
			{
				if (this.m_append == null)
				{
					this.m_append = new FileIOAccess();
				}
				this.m_append.AddExpressions(values, checkForDuplicates);
			}
			if ((access & FileIOPermissionAccess.PathDiscovery) != FileIOPermissionAccess.NoAccess)
			{
				if (this.m_pathDiscovery == null)
				{
					this.m_pathDiscovery = new FileIOAccess(true);
				}
				this.m_pathDiscovery.AddExpressions(values, checkForDuplicates);
			}
			if ((control & AccessControlActions.View) != AccessControlActions.None)
			{
				if (this.m_viewAcl == null)
				{
					this.m_viewAcl = new FileIOAccess();
				}
				this.m_viewAcl.AddExpressions(values, checkForDuplicates);
			}
			if ((control & AccessControlActions.Change) != AccessControlActions.None)
			{
				if (this.m_changeAcl == null)
				{
					this.m_changeAcl = new FileIOAccess();
				}
				this.m_changeAcl.AddExpressions(values, checkForDuplicates);
			}
		}

		// Token: 0x060025E4 RID: 9700 RVA: 0x0008A1BC File Offset: 0x000883BC
		[SecuritySafeCritical]
		public string[] GetPathList(FileIOPermissionAccess access)
		{
			FileIOPermission.VerifyAccess(access);
			FileIOPermission.ExclusiveAccess(access);
			if (FileIOPermission.AccessIsSet(access, FileIOPermissionAccess.Read))
			{
				if (this.m_read == null)
				{
					return null;
				}
				return this.m_read.ToStringArray();
			}
			else if (FileIOPermission.AccessIsSet(access, FileIOPermissionAccess.Write))
			{
				if (this.m_write == null)
				{
					return null;
				}
				return this.m_write.ToStringArray();
			}
			else if (FileIOPermission.AccessIsSet(access, FileIOPermissionAccess.Append))
			{
				if (this.m_append == null)
				{
					return null;
				}
				return this.m_append.ToStringArray();
			}
			else
			{
				if (!FileIOPermission.AccessIsSet(access, FileIOPermissionAccess.PathDiscovery))
				{
					return null;
				}
				if (this.m_pathDiscovery == null)
				{
					return null;
				}
				return this.m_pathDiscovery.ToStringArray();
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x060025E5 RID: 9701 RVA: 0x0008A254 File Offset: 0x00088454
		// (set) Token: 0x060025E6 RID: 9702 RVA: 0x0008A2D4 File Offset: 0x000884D4
		public FileIOPermissionAccess AllLocalFiles
		{
			get
			{
				if (this.m_unrestricted)
				{
					return FileIOPermissionAccess.AllAccess;
				}
				FileIOPermissionAccess fileIOPermissionAccess = FileIOPermissionAccess.NoAccess;
				if (this.m_read != null && this.m_read.AllLocalFiles)
				{
					fileIOPermissionAccess |= FileIOPermissionAccess.Read;
				}
				if (this.m_write != null && this.m_write.AllLocalFiles)
				{
					fileIOPermissionAccess |= FileIOPermissionAccess.Write;
				}
				if (this.m_append != null && this.m_append.AllLocalFiles)
				{
					fileIOPermissionAccess |= FileIOPermissionAccess.Append;
				}
				if (this.m_pathDiscovery != null && this.m_pathDiscovery.AllLocalFiles)
				{
					fileIOPermissionAccess |= FileIOPermissionAccess.PathDiscovery;
				}
				return fileIOPermissionAccess;
			}
			set
			{
				if ((value & FileIOPermissionAccess.Read) != FileIOPermissionAccess.NoAccess)
				{
					if (this.m_read == null)
					{
						this.m_read = new FileIOAccess();
					}
					this.m_read.AllLocalFiles = true;
				}
				else if (this.m_read != null)
				{
					this.m_read.AllLocalFiles = false;
				}
				if ((value & FileIOPermissionAccess.Write) != FileIOPermissionAccess.NoAccess)
				{
					if (this.m_write == null)
					{
						this.m_write = new FileIOAccess();
					}
					this.m_write.AllLocalFiles = true;
				}
				else if (this.m_write != null)
				{
					this.m_write.AllLocalFiles = false;
				}
				if ((value & FileIOPermissionAccess.Append) != FileIOPermissionAccess.NoAccess)
				{
					if (this.m_append == null)
					{
						this.m_append = new FileIOAccess();
					}
					this.m_append.AllLocalFiles = true;
				}
				else if (this.m_append != null)
				{
					this.m_append.AllLocalFiles = false;
				}
				if ((value & FileIOPermissionAccess.PathDiscovery) != FileIOPermissionAccess.NoAccess)
				{
					if (this.m_pathDiscovery == null)
					{
						this.m_pathDiscovery = new FileIOAccess(true);
					}
					this.m_pathDiscovery.AllLocalFiles = true;
					return;
				}
				if (this.m_pathDiscovery != null)
				{
					this.m_pathDiscovery.AllLocalFiles = false;
				}
			}
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x060025E7 RID: 9703 RVA: 0x0008A3CC File Offset: 0x000885CC
		// (set) Token: 0x060025E8 RID: 9704 RVA: 0x0008A44C File Offset: 0x0008864C
		public FileIOPermissionAccess AllFiles
		{
			get
			{
				if (this.m_unrestricted)
				{
					return FileIOPermissionAccess.AllAccess;
				}
				FileIOPermissionAccess fileIOPermissionAccess = FileIOPermissionAccess.NoAccess;
				if (this.m_read != null && this.m_read.AllFiles)
				{
					fileIOPermissionAccess |= FileIOPermissionAccess.Read;
				}
				if (this.m_write != null && this.m_write.AllFiles)
				{
					fileIOPermissionAccess |= FileIOPermissionAccess.Write;
				}
				if (this.m_append != null && this.m_append.AllFiles)
				{
					fileIOPermissionAccess |= FileIOPermissionAccess.Append;
				}
				if (this.m_pathDiscovery != null && this.m_pathDiscovery.AllFiles)
				{
					fileIOPermissionAccess |= FileIOPermissionAccess.PathDiscovery;
				}
				return fileIOPermissionAccess;
			}
			set
			{
				if (value == FileIOPermissionAccess.AllAccess)
				{
					this.m_unrestricted = true;
					return;
				}
				if ((value & FileIOPermissionAccess.Read) != FileIOPermissionAccess.NoAccess)
				{
					if (this.m_read == null)
					{
						this.m_read = new FileIOAccess();
					}
					this.m_read.AllFiles = true;
				}
				else if (this.m_read != null)
				{
					this.m_read.AllFiles = false;
				}
				if ((value & FileIOPermissionAccess.Write) != FileIOPermissionAccess.NoAccess)
				{
					if (this.m_write == null)
					{
						this.m_write = new FileIOAccess();
					}
					this.m_write.AllFiles = true;
				}
				else if (this.m_write != null)
				{
					this.m_write.AllFiles = false;
				}
				if ((value & FileIOPermissionAccess.Append) != FileIOPermissionAccess.NoAccess)
				{
					if (this.m_append == null)
					{
						this.m_append = new FileIOAccess();
					}
					this.m_append.AllFiles = true;
				}
				else if (this.m_append != null)
				{
					this.m_append.AllFiles = false;
				}
				if ((value & FileIOPermissionAccess.PathDiscovery) != FileIOPermissionAccess.NoAccess)
				{
					if (this.m_pathDiscovery == null)
					{
						this.m_pathDiscovery = new FileIOAccess(true);
					}
					this.m_pathDiscovery.AllFiles = true;
					return;
				}
				if (this.m_pathDiscovery != null)
				{
					this.m_pathDiscovery.AllFiles = false;
				}
			}
		}

		// Token: 0x060025E9 RID: 9705 RVA: 0x0008A54E File Offset: 0x0008874E
		private static void VerifyAccess(FileIOPermissionAccess access)
		{
			if ((access & ~(FileIOPermissionAccess.Read | FileIOPermissionAccess.Write | FileIOPermissionAccess.Append | FileIOPermissionAccess.PathDiscovery)) != FileIOPermissionAccess.NoAccess)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumIllegalVal", new object[]
				{
					(int)access
				}));
			}
		}

		// Token: 0x060025EA RID: 9706 RVA: 0x0008A575 File Offset: 0x00088775
		private static void ExclusiveAccess(FileIOPermissionAccess access)
		{
			if (access == FileIOPermissionAccess.NoAccess)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumNotSingleFlag"));
			}
			if ((access & access - 1) != FileIOPermissionAccess.NoAccess)
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_EnumNotSingleFlag"));
			}
		}

		// Token: 0x060025EB RID: 9707 RVA: 0x0008A5A4 File Offset: 0x000887A4
		private static void CheckIllegalCharacters(string[] str, bool onlyCheckExtras)
		{
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == null)
				{
					throw new ArgumentNullException("path");
				}
				if (FileIOPermission.CheckExtraPathCharacters(str[i]))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPathChars"));
				}
				if (!onlyCheckExtras)
				{
					Path.CheckInvalidPathChars(str[i], false);
				}
			}
		}

		// Token: 0x060025EC RID: 9708 RVA: 0x0008A5F8 File Offset: 0x000887F8
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool CheckExtraPathCharacters(string path)
		{
			bool flag = CodeAccessSecurityEngine.QuickCheckForAllDemands() && !AppContextSwitches.UseLegacyPathHandling;
			int num = (!flag) ? 0 : (PathInternal.IsDevice(path) ? 4 : 0);
			for (int i = num; i < path.Length; i++)
			{
				char c = path[i];
				if (c == '*' || c == '?' || c == '\0')
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060025ED RID: 9709 RVA: 0x0008A654 File Offset: 0x00088854
		private static bool AccessIsSet(FileIOPermissionAccess access, FileIOPermissionAccess question)
		{
			return (access & question) > FileIOPermissionAccess.NoAccess;
		}

		// Token: 0x060025EE RID: 9710 RVA: 0x0008A65C File Offset: 0x0008885C
		private bool IsEmpty()
		{
			return !this.m_unrestricted && (this.m_read == null || this.m_read.IsEmpty()) && (this.m_write == null || this.m_write.IsEmpty()) && (this.m_append == null || this.m_append.IsEmpty()) && (this.m_pathDiscovery == null || this.m_pathDiscovery.IsEmpty()) && (this.m_viewAcl == null || this.m_viewAcl.IsEmpty()) && (this.m_changeAcl == null || this.m_changeAcl.IsEmpty());
		}

		// Token: 0x060025EF RID: 9711 RVA: 0x0008A6F1 File Offset: 0x000888F1
		public bool IsUnrestricted()
		{
			return this.m_unrestricted;
		}

		// Token: 0x060025F0 RID: 9712 RVA: 0x0008A6FC File Offset: 0x000888FC
		public override bool IsSubsetOf(IPermission target)
		{
			if (target == null)
			{
				return this.IsEmpty();
			}
			FileIOPermission fileIOPermission = target as FileIOPermission;
			if (fileIOPermission == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			return fileIOPermission.IsUnrestricted() || (!this.IsUnrestricted() && ((this.m_read == null || this.m_read.IsSubsetOf(fileIOPermission.m_read)) && (this.m_write == null || this.m_write.IsSubsetOf(fileIOPermission.m_write)) && (this.m_append == null || this.m_append.IsSubsetOf(fileIOPermission.m_append)) && (this.m_pathDiscovery == null || this.m_pathDiscovery.IsSubsetOf(fileIOPermission.m_pathDiscovery)) && (this.m_viewAcl == null || this.m_viewAcl.IsSubsetOf(fileIOPermission.m_viewAcl))) && (this.m_changeAcl == null || this.m_changeAcl.IsSubsetOf(fileIOPermission.m_changeAcl)));
		}

		// Token: 0x060025F1 RID: 9713 RVA: 0x0008A7FC File Offset: 0x000889FC
		public override IPermission Intersect(IPermission target)
		{
			if (target == null)
			{
				return null;
			}
			FileIOPermission fileIOPermission = target as FileIOPermission;
			if (fileIOPermission == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			if (this.IsUnrestricted())
			{
				return target.Copy();
			}
			if (fileIOPermission.IsUnrestricted())
			{
				return this.Copy();
			}
			FileIOAccess fileIOAccess = (this.m_read == null) ? null : this.m_read.Intersect(fileIOPermission.m_read);
			FileIOAccess fileIOAccess2 = (this.m_write == null) ? null : this.m_write.Intersect(fileIOPermission.m_write);
			FileIOAccess fileIOAccess3 = (this.m_append == null) ? null : this.m_append.Intersect(fileIOPermission.m_append);
			FileIOAccess fileIOAccess4 = (this.m_pathDiscovery == null) ? null : this.m_pathDiscovery.Intersect(fileIOPermission.m_pathDiscovery);
			FileIOAccess fileIOAccess5 = (this.m_viewAcl == null) ? null : this.m_viewAcl.Intersect(fileIOPermission.m_viewAcl);
			FileIOAccess fileIOAccess6 = (this.m_changeAcl == null) ? null : this.m_changeAcl.Intersect(fileIOPermission.m_changeAcl);
			if ((fileIOAccess == null || fileIOAccess.IsEmpty()) && (fileIOAccess2 == null || fileIOAccess2.IsEmpty()) && (fileIOAccess3 == null || fileIOAccess3.IsEmpty()) && (fileIOAccess4 == null || fileIOAccess4.IsEmpty()) && (fileIOAccess5 == null || fileIOAccess5.IsEmpty()) && (fileIOAccess6 == null || fileIOAccess6.IsEmpty()))
			{
				return null;
			}
			return new FileIOPermission(PermissionState.None)
			{
				m_unrestricted = false,
				m_read = fileIOAccess,
				m_write = fileIOAccess2,
				m_append = fileIOAccess3,
				m_pathDiscovery = fileIOAccess4,
				m_viewAcl = fileIOAccess5,
				m_changeAcl = fileIOAccess6
			};
		}

		// Token: 0x060025F2 RID: 9714 RVA: 0x0008A99C File Offset: 0x00088B9C
		public override IPermission Union(IPermission other)
		{
			if (other == null)
			{
				return this.Copy();
			}
			FileIOPermission fileIOPermission = other as FileIOPermission;
			if (fileIOPermission == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_WrongType", new object[]
				{
					base.GetType().FullName
				}));
			}
			if (this.IsUnrestricted() || fileIOPermission.IsUnrestricted())
			{
				return new FileIOPermission(PermissionState.Unrestricted);
			}
			FileIOAccess fileIOAccess = (this.m_read == null) ? fileIOPermission.m_read : this.m_read.Union(fileIOPermission.m_read);
			FileIOAccess fileIOAccess2 = (this.m_write == null) ? fileIOPermission.m_write : this.m_write.Union(fileIOPermission.m_write);
			FileIOAccess fileIOAccess3 = (this.m_append == null) ? fileIOPermission.m_append : this.m_append.Union(fileIOPermission.m_append);
			FileIOAccess fileIOAccess4 = (this.m_pathDiscovery == null) ? fileIOPermission.m_pathDiscovery : this.m_pathDiscovery.Union(fileIOPermission.m_pathDiscovery);
			FileIOAccess fileIOAccess5 = (this.m_viewAcl == null) ? fileIOPermission.m_viewAcl : this.m_viewAcl.Union(fileIOPermission.m_viewAcl);
			FileIOAccess fileIOAccess6 = (this.m_changeAcl == null) ? fileIOPermission.m_changeAcl : this.m_changeAcl.Union(fileIOPermission.m_changeAcl);
			if ((fileIOAccess == null || fileIOAccess.IsEmpty()) && (fileIOAccess2 == null || fileIOAccess2.IsEmpty()) && (fileIOAccess3 == null || fileIOAccess3.IsEmpty()) && (fileIOAccess4 == null || fileIOAccess4.IsEmpty()) && (fileIOAccess5 == null || fileIOAccess5.IsEmpty()) && (fileIOAccess6 == null || fileIOAccess6.IsEmpty()))
			{
				return null;
			}
			return new FileIOPermission(PermissionState.None)
			{
				m_unrestricted = false,
				m_read = fileIOAccess,
				m_write = fileIOAccess2,
				m_append = fileIOAccess3,
				m_pathDiscovery = fileIOAccess4,
				m_viewAcl = fileIOAccess5,
				m_changeAcl = fileIOAccess6
			};
		}

		// Token: 0x060025F3 RID: 9715 RVA: 0x0008AB58 File Offset: 0x00088D58
		public override IPermission Copy()
		{
			FileIOPermission fileIOPermission = new FileIOPermission(PermissionState.None);
			if (this.m_unrestricted)
			{
				fileIOPermission.m_unrestricted = true;
			}
			else
			{
				fileIOPermission.m_unrestricted = false;
				if (this.m_read != null)
				{
					fileIOPermission.m_read = this.m_read.Copy();
				}
				if (this.m_write != null)
				{
					fileIOPermission.m_write = this.m_write.Copy();
				}
				if (this.m_append != null)
				{
					fileIOPermission.m_append = this.m_append.Copy();
				}
				if (this.m_pathDiscovery != null)
				{
					fileIOPermission.m_pathDiscovery = this.m_pathDiscovery.Copy();
				}
				if (this.m_viewAcl != null)
				{
					fileIOPermission.m_viewAcl = this.m_viewAcl.Copy();
				}
				if (this.m_changeAcl != null)
				{
					fileIOPermission.m_changeAcl = this.m_changeAcl.Copy();
				}
			}
			return fileIOPermission;
		}

		// Token: 0x060025F4 RID: 9716 RVA: 0x0008AC20 File Offset: 0x00088E20
		public override SecurityElement ToXml()
		{
			SecurityElement securityElement = CodeAccessPermission.CreatePermissionElement(this, "System.Security.Permissions.FileIOPermission");
			if (!this.IsUnrestricted())
			{
				if (this.m_read != null && !this.m_read.IsEmpty())
				{
					securityElement.AddAttribute("Read", SecurityElement.Escape(this.m_read.ToString()));
				}
				if (this.m_write != null && !this.m_write.IsEmpty())
				{
					securityElement.AddAttribute("Write", SecurityElement.Escape(this.m_write.ToString()));
				}
				if (this.m_append != null && !this.m_append.IsEmpty())
				{
					securityElement.AddAttribute("Append", SecurityElement.Escape(this.m_append.ToString()));
				}
				if (this.m_pathDiscovery != null && !this.m_pathDiscovery.IsEmpty())
				{
					securityElement.AddAttribute("PathDiscovery", SecurityElement.Escape(this.m_pathDiscovery.ToString()));
				}
				if (this.m_viewAcl != null && !this.m_viewAcl.IsEmpty())
				{
					securityElement.AddAttribute("ViewAcl", SecurityElement.Escape(this.m_viewAcl.ToString()));
				}
				if (this.m_changeAcl != null && !this.m_changeAcl.IsEmpty())
				{
					securityElement.AddAttribute("ChangeAcl", SecurityElement.Escape(this.m_changeAcl.ToString()));
				}
			}
			else
			{
				securityElement.AddAttribute("Unrestricted", "true");
			}
			return securityElement;
		}

		// Token: 0x060025F5 RID: 9717 RVA: 0x0008AD78 File Offset: 0x00088F78
		[SecuritySafeCritical]
		public override void FromXml(SecurityElement esd)
		{
			CodeAccessPermission.ValidateElement(esd, this);
			if (XMLUtil.IsUnrestricted(esd))
			{
				this.m_unrestricted = true;
				return;
			}
			this.m_unrestricted = false;
			string text = esd.Attribute("Read");
			if (text != null)
			{
				this.m_read = new FileIOAccess(text);
			}
			else
			{
				this.m_read = null;
			}
			text = esd.Attribute("Write");
			if (text != null)
			{
				this.m_write = new FileIOAccess(text);
			}
			else
			{
				this.m_write = null;
			}
			text = esd.Attribute("Append");
			if (text != null)
			{
				this.m_append = new FileIOAccess(text);
			}
			else
			{
				this.m_append = null;
			}
			text = esd.Attribute("PathDiscovery");
			if (text != null)
			{
				this.m_pathDiscovery = new FileIOAccess(text);
				this.m_pathDiscovery.PathDiscovery = true;
			}
			else
			{
				this.m_pathDiscovery = null;
			}
			text = esd.Attribute("ViewAcl");
			if (text != null)
			{
				this.m_viewAcl = new FileIOAccess(text);
			}
			else
			{
				this.m_viewAcl = null;
			}
			text = esd.Attribute("ChangeAcl");
			if (text != null)
			{
				this.m_changeAcl = new FileIOAccess(text);
				return;
			}
			this.m_changeAcl = null;
		}

		// Token: 0x060025F6 RID: 9718 RVA: 0x0008AE86 File Offset: 0x00089086
		int IBuiltInPermission.GetTokenIndex()
		{
			return FileIOPermission.GetTokenIndex();
		}

		// Token: 0x060025F7 RID: 9719 RVA: 0x0008AE8D File Offset: 0x0008908D
		internal static int GetTokenIndex()
		{
			return 2;
		}

		// Token: 0x060025F8 RID: 9720 RVA: 0x0008AE90 File Offset: 0x00089090
		[ComVisible(false)]
		public override bool Equals(object obj)
		{
			FileIOPermission fileIOPermission = obj as FileIOPermission;
			if (fileIOPermission == null)
			{
				return false;
			}
			if (this.m_unrestricted && fileIOPermission.m_unrestricted)
			{
				return true;
			}
			if (this.m_unrestricted != fileIOPermission.m_unrestricted)
			{
				return false;
			}
			if (this.m_read == null)
			{
				if (fileIOPermission.m_read != null && !fileIOPermission.m_read.IsEmpty())
				{
					return false;
				}
			}
			else if (!this.m_read.Equals(fileIOPermission.m_read))
			{
				return false;
			}
			if (this.m_write == null)
			{
				if (fileIOPermission.m_write != null && !fileIOPermission.m_write.IsEmpty())
				{
					return false;
				}
			}
			else if (!this.m_write.Equals(fileIOPermission.m_write))
			{
				return false;
			}
			if (this.m_append == null)
			{
				if (fileIOPermission.m_append != null && !fileIOPermission.m_append.IsEmpty())
				{
					return false;
				}
			}
			else if (!this.m_append.Equals(fileIOPermission.m_append))
			{
				return false;
			}
			if (this.m_pathDiscovery == null)
			{
				if (fileIOPermission.m_pathDiscovery != null && !fileIOPermission.m_pathDiscovery.IsEmpty())
				{
					return false;
				}
			}
			else if (!this.m_pathDiscovery.Equals(fileIOPermission.m_pathDiscovery))
			{
				return false;
			}
			if (this.m_viewAcl == null)
			{
				if (fileIOPermission.m_viewAcl != null && !fileIOPermission.m_viewAcl.IsEmpty())
				{
					return false;
				}
			}
			else if (!this.m_viewAcl.Equals(fileIOPermission.m_viewAcl))
			{
				return false;
			}
			if (this.m_changeAcl == null)
			{
				if (fileIOPermission.m_changeAcl != null && !fileIOPermission.m_changeAcl.IsEmpty())
				{
					return false;
				}
			}
			else if (!this.m_changeAcl.Equals(fileIOPermission.m_changeAcl))
			{
				return false;
			}
			return true;
		}

		// Token: 0x060025F9 RID: 9721 RVA: 0x0008B004 File Offset: 0x00089204
		[ComVisible(false)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060025FA RID: 9722 RVA: 0x0008B00C File Offset: 0x0008920C
		[SecuritySafeCritical]
		internal static void QuickDemand(FileIOPermissionAccess access, string fullPath, bool checkForDuplicates = false, bool needFullPath = true)
		{
			if (!CodeAccessSecurityEngine.QuickCheckForAllDemands())
			{
				new FileIOPermission(access, new string[]
				{
					fullPath
				}, checkForDuplicates, needFullPath).Demand();
				return;
			}
			FileIOPermission.EmulateFileIOPermissionChecks(fullPath);
		}

		// Token: 0x060025FB RID: 9723 RVA: 0x0008B034 File Offset: 0x00089234
		[SecuritySafeCritical]
		internal static void QuickDemand(FileIOPermissionAccess access, string[] fullPathList, bool checkForDuplicates = false, bool needFullPath = true)
		{
			if (!CodeAccessSecurityEngine.QuickCheckForAllDemands())
			{
				new FileIOPermission(access, fullPathList, checkForDuplicates, needFullPath).Demand();
				return;
			}
			foreach (string fullPath in fullPathList)
			{
				FileIOPermission.EmulateFileIOPermissionChecks(fullPath);
			}
		}

		// Token: 0x060025FC RID: 9724 RVA: 0x0008B071 File Offset: 0x00089271
		[SecuritySafeCritical]
		internal static void QuickDemand(PermissionState state)
		{
			if (!CodeAccessSecurityEngine.QuickCheckForAllDemands())
			{
				new FileIOPermission(state).Demand();
			}
		}

		// Token: 0x060025FD RID: 9725 RVA: 0x0008B085 File Offset: 0x00089285
		[SecuritySafeCritical]
		internal static void QuickDemand(FileIOPermissionAccess access, AccessControlActions control, string fullPath, bool checkForDuplicates = false, bool needFullPath = true)
		{
			if (!CodeAccessSecurityEngine.QuickCheckForAllDemands())
			{
				new FileIOPermission(access, control, new string[]
				{
					fullPath
				}, checkForDuplicates, needFullPath).Demand();
				return;
			}
			FileIOPermission.EmulateFileIOPermissionChecks(fullPath);
		}

		// Token: 0x060025FE RID: 9726 RVA: 0x0008B0B0 File Offset: 0x000892B0
		[SecuritySafeCritical]
		internal static void QuickDemand(FileIOPermissionAccess access, AccessControlActions control, string[] fullPathList, bool checkForDuplicates = true, bool needFullPath = true)
		{
			if (!CodeAccessSecurityEngine.QuickCheckForAllDemands())
			{
				new FileIOPermission(access, control, fullPathList, checkForDuplicates, needFullPath).Demand();
				return;
			}
			foreach (string fullPath in fullPathList)
			{
				FileIOPermission.EmulateFileIOPermissionChecks(fullPath);
			}
		}

		// Token: 0x060025FF RID: 9727 RVA: 0x0008B0F0 File Offset: 0x000892F0
		internal static void EmulateFileIOPermissionChecks(string fullPath)
		{
			if (AppContextSwitches.UseLegacyPathHandling || !PathInternal.IsDevice(fullPath))
			{
				if (PathInternal.HasWildCardCharacters(fullPath))
				{
					throw new ArgumentException(Environment.GetResourceString("Argument_InvalidPathChars"));
				}
				if (PathInternal.HasInvalidVolumeSeparator(fullPath))
				{
					throw new NotSupportedException(Environment.GetResourceString("Argument_PathFormatNotSupported"));
				}
			}
		}

		// Token: 0x04000E7C RID: 3708
		private FileIOAccess m_read;

		// Token: 0x04000E7D RID: 3709
		private FileIOAccess m_write;

		// Token: 0x04000E7E RID: 3710
		private FileIOAccess m_append;

		// Token: 0x04000E7F RID: 3711
		private FileIOAccess m_pathDiscovery;

		// Token: 0x04000E80 RID: 3712
		[OptionalField(VersionAdded = 2)]
		private FileIOAccess m_viewAcl;

		// Token: 0x04000E81 RID: 3713
		[OptionalField(VersionAdded = 2)]
		private FileIOAccess m_changeAcl;

		// Token: 0x04000E82 RID: 3714
		private bool m_unrestricted;
	}
}
