using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Policy
{
	// Token: 0x02000348 RID: 840
	internal sealed class AssemblyEvidenceFactory : IRuntimeEvidenceFactory
	{
		// Token: 0x060029C2 RID: 10690 RVA: 0x0009A57E File Offset: 0x0009877E
		private AssemblyEvidenceFactory(RuntimeAssembly targetAssembly, PEFileEvidenceFactory peFileFactory)
		{
			this.m_targetAssembly = targetAssembly;
			this.m_peFileFactory = peFileFactory;
		}

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x060029C3 RID: 10691 RVA: 0x0009A594 File Offset: 0x00098794
		internal SafePEFileHandle PEFile
		{
			[SecurityCritical]
			get
			{
				return this.m_peFileFactory.PEFile;
			}
		}

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x060029C4 RID: 10692 RVA: 0x0009A5A1 File Offset: 0x000987A1
		public IEvidenceFactory Target
		{
			get
			{
				return this.m_targetAssembly;
			}
		}

		// Token: 0x060029C5 RID: 10693 RVA: 0x0009A5AC File Offset: 0x000987AC
		public EvidenceBase GenerateEvidence(Type evidenceType)
		{
			EvidenceBase evidenceBase = this.m_peFileFactory.GenerateEvidence(evidenceType);
			if (evidenceBase != null)
			{
				return evidenceBase;
			}
			if (evidenceType == typeof(GacInstalled))
			{
				return this.GenerateGacEvidence();
			}
			if (evidenceType == typeof(Hash))
			{
				return this.GenerateHashEvidence();
			}
			if (evidenceType == typeof(PermissionRequestEvidence))
			{
				return this.GeneratePermissionRequestEvidence();
			}
			if (evidenceType == typeof(StrongName))
			{
				return this.GenerateStrongNameEvidence();
			}
			return null;
		}

		// Token: 0x060029C6 RID: 10694 RVA: 0x0009A630 File Offset: 0x00098830
		private GacInstalled GenerateGacEvidence()
		{
			if (!this.m_targetAssembly.GlobalAssemblyCache)
			{
				return null;
			}
			this.m_peFileFactory.FireEvidenceGeneratedEvent(EvidenceTypeGenerated.Gac);
			return new GacInstalled();
		}

		// Token: 0x060029C7 RID: 10695 RVA: 0x0009A652 File Offset: 0x00098852
		private Hash GenerateHashEvidence()
		{
			if (this.m_targetAssembly.IsDynamic)
			{
				return null;
			}
			this.m_peFileFactory.FireEvidenceGeneratedEvent(EvidenceTypeGenerated.Hash);
			return new Hash(this.m_targetAssembly);
		}

		// Token: 0x060029C8 RID: 10696 RVA: 0x0009A67C File Offset: 0x0009887C
		[SecuritySafeCritical]
		private PermissionRequestEvidence GeneratePermissionRequestEvidence()
		{
			PermissionSet permissionSet = null;
			PermissionSet permissionSet2 = null;
			PermissionSet permissionSet3 = null;
			AssemblyEvidenceFactory.GetAssemblyPermissionRequests(this.m_targetAssembly.GetNativeHandle(), JitHelpers.GetObjectHandleOnStack<PermissionSet>(ref permissionSet), JitHelpers.GetObjectHandleOnStack<PermissionSet>(ref permissionSet2), JitHelpers.GetObjectHandleOnStack<PermissionSet>(ref permissionSet3));
			if (permissionSet != null || permissionSet2 != null || permissionSet3 != null)
			{
				return new PermissionRequestEvidence(permissionSet, permissionSet2, permissionSet3);
			}
			return null;
		}

		// Token: 0x060029C9 RID: 10697 RVA: 0x0009A6C8 File Offset: 0x000988C8
		[SecuritySafeCritical]
		private StrongName GenerateStrongNameEvidence()
		{
			byte[] array = null;
			string name = null;
			ushort major = 0;
			ushort minor = 0;
			ushort build = 0;
			ushort revision = 0;
			AssemblyEvidenceFactory.GetStrongNameInformation(this.m_targetAssembly.GetNativeHandle(), JitHelpers.GetObjectHandleOnStack<byte[]>(ref array), JitHelpers.GetStringHandleOnStack(ref name), out major, out minor, out build, out revision);
			if (array == null || array.Length == 0)
			{
				return null;
			}
			return new StrongName(new StrongNamePublicKeyBlob(array), name, new Version((int)major, (int)minor, (int)build, (int)revision), this.m_targetAssembly);
		}

		// Token: 0x060029CA RID: 10698
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetAssemblyPermissionRequests(RuntimeAssembly assembly, ObjectHandleOnStack retMinimumPermissions, ObjectHandleOnStack retOptionalPermissions, ObjectHandleOnStack retRefusedPermissions);

		// Token: 0x060029CB RID: 10699 RVA: 0x0009A72F File Offset: 0x0009892F
		public IEnumerable<EvidenceBase> GetFactorySuppliedEvidence()
		{
			return this.m_peFileFactory.GetFactorySuppliedEvidence();
		}

		// Token: 0x060029CC RID: 10700
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetStrongNameInformation(RuntimeAssembly assembly, ObjectHandleOnStack retPublicKeyBlob, StringHandleOnStack retSimpleName, out ushort majorVersion, out ushort minorVersion, out ushort build, out ushort revision);

		// Token: 0x060029CD RID: 10701 RVA: 0x0009A73C File Offset: 0x0009893C
		[SecurityCritical]
		private static Evidence UpgradeSecurityIdentity(Evidence peFileEvidence, RuntimeAssembly targetAssembly)
		{
			peFileEvidence.Target = new AssemblyEvidenceFactory(targetAssembly, peFileEvidence.Target as PEFileEvidenceFactory);
			HostSecurityManager hostSecurityManager = AppDomain.CurrentDomain.HostSecurityManager;
			if ((hostSecurityManager.Flags & HostSecurityManagerOptions.HostAssemblyEvidence) == HostSecurityManagerOptions.HostAssemblyEvidence)
			{
				peFileEvidence = hostSecurityManager.ProvideAssemblyEvidence(targetAssembly, peFileEvidence);
				if (peFileEvidence == null)
				{
					throw new InvalidOperationException(Environment.GetResourceString("Policy_NullHostEvidence", new object[]
					{
						hostSecurityManager.GetType().FullName,
						targetAssembly.FullName
					}));
				}
			}
			return peFileEvidence;
		}

		// Token: 0x0400111E RID: 4382
		private PEFileEvidenceFactory m_peFileFactory;

		// Token: 0x0400111F RID: 4383
		private RuntimeAssembly m_targetAssembly;
	}
}
