using System;
using System.Deployment.Internal.Isolation.Manifest;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x020006B3 RID: 1715
	internal static class IsolationInterop
	{
		// Token: 0x06005017 RID: 20503 RVA: 0x0011D586 File Offset: 0x0011B786
		[SecuritySafeCritical]
		public static Store GetUserStore()
		{
			return new Store(IsolationInterop.GetUserStore(0U, IntPtr.Zero, ref IsolationInterop.IID_IStore) as IStore);
		}

		// Token: 0x17000CAD RID: 3245
		// (get) Token: 0x06005018 RID: 20504 RVA: 0x0011D5A4 File Offset: 0x0011B7A4
		public static IIdentityAuthority IdentityAuthority
		{
			[SecuritySafeCritical]
			get
			{
				if (IsolationInterop._idAuth == null)
				{
					object synchObject = IsolationInterop._synchObject;
					lock (synchObject)
					{
						if (IsolationInterop._idAuth == null)
						{
							IsolationInterop._idAuth = IsolationInterop.GetIdentityAuthority();
						}
					}
				}
				return IsolationInterop._idAuth;
			}
		}

		// Token: 0x17000CAE RID: 3246
		// (get) Token: 0x06005019 RID: 20505 RVA: 0x0011D604 File Offset: 0x0011B804
		public static IAppIdAuthority AppIdAuthority
		{
			[SecuritySafeCritical]
			get
			{
				if (IsolationInterop._appIdAuth == null)
				{
					object synchObject = IsolationInterop._synchObject;
					lock (synchObject)
					{
						if (IsolationInterop._appIdAuth == null)
						{
							IsolationInterop._appIdAuth = IsolationInterop.GetAppIdAuthority();
						}
					}
				}
				return IsolationInterop._appIdAuth;
			}
		}

		// Token: 0x0600501A RID: 20506 RVA: 0x0011D664 File Offset: 0x0011B864
		[SecuritySafeCritical]
		internal static IActContext CreateActContext(IDefinitionAppId AppId)
		{
			IsolationInterop.CreateActContextParameters createActContextParameters;
			createActContextParameters.Size = (uint)Marshal.SizeOf(typeof(IsolationInterop.CreateActContextParameters));
			createActContextParameters.Flags = 16U;
			createActContextParameters.CustomStoreList = IntPtr.Zero;
			createActContextParameters.CultureFallbackList = IntPtr.Zero;
			createActContextParameters.ProcessorArchitectureList = IntPtr.Zero;
			createActContextParameters.Source = IntPtr.Zero;
			createActContextParameters.ProcArch = 0;
			IsolationInterop.CreateActContextParametersSource createActContextParametersSource;
			createActContextParametersSource.Size = (uint)Marshal.SizeOf(typeof(IsolationInterop.CreateActContextParametersSource));
			createActContextParametersSource.Flags = 0U;
			createActContextParametersSource.SourceType = 1U;
			createActContextParametersSource.Data = IntPtr.Zero;
			IsolationInterop.CreateActContextParametersSourceDefinitionAppid createActContextParametersSourceDefinitionAppid;
			createActContextParametersSourceDefinitionAppid.Size = (uint)Marshal.SizeOf(typeof(IsolationInterop.CreateActContextParametersSourceDefinitionAppid));
			createActContextParametersSourceDefinitionAppid.Flags = 0U;
			createActContextParametersSourceDefinitionAppid.AppId = AppId;
			IActContext result;
			try
			{
				createActContextParametersSource.Data = createActContextParametersSourceDefinitionAppid.ToIntPtr();
				createActContextParameters.Source = createActContextParametersSource.ToIntPtr();
				result = (IsolationInterop.CreateActContext(ref createActContextParameters) as IActContext);
			}
			finally
			{
				if (createActContextParametersSource.Data != IntPtr.Zero)
				{
					IsolationInterop.CreateActContextParametersSourceDefinitionAppid.Destroy(createActContextParametersSource.Data);
					createActContextParametersSource.Data = IntPtr.Zero;
				}
				if (createActContextParameters.Source != IntPtr.Zero)
				{
					IsolationInterop.CreateActContextParametersSource.Destroy(createActContextParameters.Source);
					createActContextParameters.Source = IntPtr.Zero;
				}
			}
			return result;
		}

		// Token: 0x0600501B RID: 20507
		[DllImport("clr.dll", PreserveSig = false)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		internal static extern object CreateActContext(ref IsolationInterop.CreateActContextParameters Params);

		// Token: 0x0600501C RID: 20508
		[SecurityCritical]
		[DllImport("clr.dll", PreserveSig = false)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		internal static extern object CreateCMSFromXml([In] byte[] buffer, [In] uint bufferSize, [In] IManifestParseErrorCallback Callback, [In] ref Guid riid);

		// Token: 0x0600501D RID: 20509
		[SecurityCritical]
		[DllImport("clr.dll", PreserveSig = false)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		internal static extern object ParseManifest([MarshalAs(UnmanagedType.LPWStr)] [In] string pszManifestPath, [In] IManifestParseErrorCallback pIManifestParseErrorCallback, [In] ref Guid riid);

		// Token: 0x0600501E RID: 20510
		[SecurityCritical]
		[DllImport("clr.dll", PreserveSig = false)]
		[return: MarshalAs(UnmanagedType.IUnknown)]
		private static extern object GetUserStore([In] uint Flags, [In] IntPtr hToken, [In] ref Guid riid);

		// Token: 0x0600501F RID: 20511
		[SecurityCritical]
		[DllImport("clr.dll", PreserveSig = false)]
		[return: MarshalAs(UnmanagedType.Interface)]
		private static extern IIdentityAuthority GetIdentityAuthority();

		// Token: 0x06005020 RID: 20512
		[SecurityCritical]
		[DllImport("clr.dll", PreserveSig = false)]
		[return: MarshalAs(UnmanagedType.Interface)]
		private static extern IAppIdAuthority GetAppIdAuthority();

		// Token: 0x06005021 RID: 20513 RVA: 0x0011D7B0 File Offset: 0x0011B9B0
		internal static Guid GetGuidOfType(Type type)
		{
			GuidAttribute guidAttribute = (GuidAttribute)Attribute.GetCustomAttribute(type, typeof(GuidAttribute), false);
			return new Guid(guidAttribute.Value);
		}

		// Token: 0x0400226C RID: 8812
		private static object _synchObject = new object();

		// Token: 0x0400226D RID: 8813
		private static volatile IIdentityAuthority _idAuth = null;

		// Token: 0x0400226E RID: 8814
		private static volatile IAppIdAuthority _appIdAuth = null;

		// Token: 0x0400226F RID: 8815
		public const string IsolationDllName = "clr.dll";

		// Token: 0x04002270 RID: 8816
		public static Guid IID_ICMS = IsolationInterop.GetGuidOfType(typeof(ICMS));

		// Token: 0x04002271 RID: 8817
		public static Guid IID_IDefinitionIdentity = IsolationInterop.GetGuidOfType(typeof(IDefinitionIdentity));

		// Token: 0x04002272 RID: 8818
		public static Guid IID_IManifestInformation = IsolationInterop.GetGuidOfType(typeof(IManifestInformation));

		// Token: 0x04002273 RID: 8819
		public static Guid IID_IEnumSTORE_ASSEMBLY = IsolationInterop.GetGuidOfType(typeof(IEnumSTORE_ASSEMBLY));

		// Token: 0x04002274 RID: 8820
		public static Guid IID_IEnumSTORE_ASSEMBLY_FILE = IsolationInterop.GetGuidOfType(typeof(IEnumSTORE_ASSEMBLY_FILE));

		// Token: 0x04002275 RID: 8821
		public static Guid IID_IEnumSTORE_CATEGORY = IsolationInterop.GetGuidOfType(typeof(IEnumSTORE_CATEGORY));

		// Token: 0x04002276 RID: 8822
		public static Guid IID_IEnumSTORE_CATEGORY_INSTANCE = IsolationInterop.GetGuidOfType(typeof(IEnumSTORE_CATEGORY_INSTANCE));

		// Token: 0x04002277 RID: 8823
		public static Guid IID_IEnumSTORE_DEPLOYMENT_METADATA = IsolationInterop.GetGuidOfType(typeof(IEnumSTORE_DEPLOYMENT_METADATA));

		// Token: 0x04002278 RID: 8824
		public static Guid IID_IEnumSTORE_DEPLOYMENT_METADATA_PROPERTY = IsolationInterop.GetGuidOfType(typeof(IEnumSTORE_DEPLOYMENT_METADATA_PROPERTY));

		// Token: 0x04002279 RID: 8825
		public static Guid IID_IStore = IsolationInterop.GetGuidOfType(typeof(IStore));

		// Token: 0x0400227A RID: 8826
		public static Guid GUID_SXS_INSTALL_REFERENCE_SCHEME_OPAQUESTRING = new Guid("2ec93463-b0c3-45e1-8364-327e96aea856");

		// Token: 0x0400227B RID: 8827
		public static Guid SXS_INSTALL_REFERENCE_SCHEME_SXS_STRONGNAME_SIGNED_PRIVATE_ASSEMBLY = new Guid("3ab20ac0-67e8-4512-8385-a487e35df3da");

		// Token: 0x02000C5E RID: 3166
		internal struct CreateActContextParameters
		{
			// Token: 0x040037A9 RID: 14249
			[MarshalAs(UnmanagedType.U4)]
			public uint Size;

			// Token: 0x040037AA RID: 14250
			[MarshalAs(UnmanagedType.U4)]
			public uint Flags;

			// Token: 0x040037AB RID: 14251
			[MarshalAs(UnmanagedType.SysInt)]
			public IntPtr CustomStoreList;

			// Token: 0x040037AC RID: 14252
			[MarshalAs(UnmanagedType.SysInt)]
			public IntPtr CultureFallbackList;

			// Token: 0x040037AD RID: 14253
			[MarshalAs(UnmanagedType.SysInt)]
			public IntPtr ProcessorArchitectureList;

			// Token: 0x040037AE RID: 14254
			[MarshalAs(UnmanagedType.SysInt)]
			public IntPtr Source;

			// Token: 0x040037AF RID: 14255
			[MarshalAs(UnmanagedType.U2)]
			public ushort ProcArch;

			// Token: 0x02000D0E RID: 3342
			[Flags]
			public enum CreateFlags
			{
				// Token: 0x0400395A RID: 14682
				Nothing = 0,
				// Token: 0x0400395B RID: 14683
				StoreListValid = 1,
				// Token: 0x0400395C RID: 14684
				CultureListValid = 2,
				// Token: 0x0400395D RID: 14685
				ProcessorFallbackListValid = 4,
				// Token: 0x0400395E RID: 14686
				ProcessorValid = 8,
				// Token: 0x0400395F RID: 14687
				SourceValid = 16,
				// Token: 0x04003960 RID: 14688
				IgnoreVisibility = 32
			}
		}

		// Token: 0x02000C5F RID: 3167
		internal struct CreateActContextParametersSource
		{
			// Token: 0x06007071 RID: 28785 RVA: 0x001833A8 File Offset: 0x001815A8
			[SecurityCritical]
			public IntPtr ToIntPtr()
			{
				IntPtr intPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf<IsolationInterop.CreateActContextParametersSource>(this));
				Marshal.StructureToPtr<IsolationInterop.CreateActContextParametersSource>(this, intPtr, false);
				return intPtr;
			}

			// Token: 0x06007072 RID: 28786 RVA: 0x001833D4 File Offset: 0x001815D4
			[SecurityCritical]
			public static void Destroy(IntPtr p)
			{
				Marshal.DestroyStructure(p, typeof(IsolationInterop.CreateActContextParametersSource));
				Marshal.FreeCoTaskMem(p);
			}

			// Token: 0x040037B0 RID: 14256
			[MarshalAs(UnmanagedType.U4)]
			public uint Size;

			// Token: 0x040037B1 RID: 14257
			[MarshalAs(UnmanagedType.U4)]
			public uint Flags;

			// Token: 0x040037B2 RID: 14258
			[MarshalAs(UnmanagedType.U4)]
			public uint SourceType;

			// Token: 0x040037B3 RID: 14259
			[MarshalAs(UnmanagedType.SysInt)]
			public IntPtr Data;

			// Token: 0x02000D0F RID: 3343
			[Flags]
			public enum SourceFlags
			{
				// Token: 0x04003962 RID: 14690
				Definition = 1,
				// Token: 0x04003963 RID: 14691
				Reference = 2
			}
		}

		// Token: 0x02000C60 RID: 3168
		internal struct CreateActContextParametersSourceDefinitionAppid
		{
			// Token: 0x06007073 RID: 28787 RVA: 0x001833EC File Offset: 0x001815EC
			[SecurityCritical]
			public IntPtr ToIntPtr()
			{
				IntPtr intPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf<IsolationInterop.CreateActContextParametersSourceDefinitionAppid>(this));
				Marshal.StructureToPtr<IsolationInterop.CreateActContextParametersSourceDefinitionAppid>(this, intPtr, false);
				return intPtr;
			}

			// Token: 0x06007074 RID: 28788 RVA: 0x00183418 File Offset: 0x00181618
			[SecurityCritical]
			public static void Destroy(IntPtr p)
			{
				Marshal.DestroyStructure(p, typeof(IsolationInterop.CreateActContextParametersSourceDefinitionAppid));
				Marshal.FreeCoTaskMem(p);
			}

			// Token: 0x040037B4 RID: 14260
			[MarshalAs(UnmanagedType.U4)]
			public uint Size;

			// Token: 0x040037B5 RID: 14261
			[MarshalAs(UnmanagedType.U4)]
			public uint Flags;

			// Token: 0x040037B6 RID: 14262
			public IDefinitionAppId AppId;
		}
	}
}
