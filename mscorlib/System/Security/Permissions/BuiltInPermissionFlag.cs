using System;

namespace System.Security.Permissions
{
	// Token: 0x020002E8 RID: 744
	[Serializable]
	internal enum BuiltInPermissionFlag
	{
		// Token: 0x04000EAD RID: 3757
		EnvironmentPermission = 1,
		// Token: 0x04000EAE RID: 3758
		FileDialogPermission,
		// Token: 0x04000EAF RID: 3759
		FileIOPermission = 4,
		// Token: 0x04000EB0 RID: 3760
		IsolatedStorageFilePermission = 8,
		// Token: 0x04000EB1 RID: 3761
		ReflectionPermission = 16,
		// Token: 0x04000EB2 RID: 3762
		RegistryPermission = 32,
		// Token: 0x04000EB3 RID: 3763
		SecurityPermission = 64,
		// Token: 0x04000EB4 RID: 3764
		UIPermission = 128,
		// Token: 0x04000EB5 RID: 3765
		PrincipalPermission = 256,
		// Token: 0x04000EB6 RID: 3766
		PublisherIdentityPermission = 512,
		// Token: 0x04000EB7 RID: 3767
		SiteIdentityPermission = 1024,
		// Token: 0x04000EB8 RID: 3768
		StrongNameIdentityPermission = 2048,
		// Token: 0x04000EB9 RID: 3769
		UrlIdentityPermission = 4096,
		// Token: 0x04000EBA RID: 3770
		ZoneIdentityPermission = 8192,
		// Token: 0x04000EBB RID: 3771
		KeyContainerPermission = 16384
	}
}
