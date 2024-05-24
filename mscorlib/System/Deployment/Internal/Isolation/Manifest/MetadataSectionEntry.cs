using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x0200070F RID: 1807
	[StructLayout(LayoutKind.Sequential)]
	internal class MetadataSectionEntry : IDisposable
	{
		// Token: 0x060050F4 RID: 20724 RVA: 0x0011DD44 File Offset: 0x0011BF44
		~MetadataSectionEntry()
		{
			this.Dispose(false);
		}

		// Token: 0x060050F5 RID: 20725 RVA: 0x0011DD74 File Offset: 0x0011BF74
		void IDisposable.Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x060050F6 RID: 20726 RVA: 0x0011DD80 File Offset: 0x0011BF80
		[SecuritySafeCritical]
		public void Dispose(bool fDisposing)
		{
			if (this.ManifestHash != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(this.ManifestHash);
				this.ManifestHash = IntPtr.Zero;
			}
			if (this.MvidValue != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(this.MvidValue);
				this.MvidValue = IntPtr.Zero;
			}
			if (fDisposing)
			{
				GC.SuppressFinalize(this);
			}
		}

		// Token: 0x040023B5 RID: 9141
		public uint SchemaVersion;

		// Token: 0x040023B6 RID: 9142
		public uint ManifestFlags;

		// Token: 0x040023B7 RID: 9143
		public uint UsagePatterns;

		// Token: 0x040023B8 RID: 9144
		public IDefinitionIdentity CdfIdentity;

		// Token: 0x040023B9 RID: 9145
		[MarshalAs(UnmanagedType.LPWStr)]
		public string LocalPath;

		// Token: 0x040023BA RID: 9146
		public uint HashAlgorithm;

		// Token: 0x040023BB RID: 9147
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr ManifestHash;

		// Token: 0x040023BC RID: 9148
		public uint ManifestHashSize;

		// Token: 0x040023BD RID: 9149
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ContentType;

		// Token: 0x040023BE RID: 9150
		[MarshalAs(UnmanagedType.LPWStr)]
		public string RuntimeImageVersion;

		// Token: 0x040023BF RID: 9151
		[MarshalAs(UnmanagedType.SysInt)]
		public IntPtr MvidValue;

		// Token: 0x040023C0 RID: 9152
		public uint MvidValueSize;

		// Token: 0x040023C1 RID: 9153
		public DescriptionMetadataEntry DescriptionData;

		// Token: 0x040023C2 RID: 9154
		public DeploymentMetadataEntry DeploymentData;

		// Token: 0x040023C3 RID: 9155
		public DependentOSMetadataEntry DependentOSData;

		// Token: 0x040023C4 RID: 9156
		[MarshalAs(UnmanagedType.LPWStr)]
		public string defaultPermissionSetID;

		// Token: 0x040023C5 RID: 9157
		[MarshalAs(UnmanagedType.LPWStr)]
		public string RequestedExecutionLevel;

		// Token: 0x040023C6 RID: 9158
		public bool RequestedExecutionLevelUIAccess;

		// Token: 0x040023C7 RID: 9159
		public IReferenceIdentity ResourceTypeResourcesDependency;

		// Token: 0x040023C8 RID: 9160
		public IReferenceIdentity ResourceTypeManifestResourcesDependency;

		// Token: 0x040023C9 RID: 9161
		[MarshalAs(UnmanagedType.LPWStr)]
		public string KeyInfoElement;

		// Token: 0x040023CA RID: 9162
		public CompatibleFrameworksMetadataEntry CompatibleFrameworksData;
	}
}
