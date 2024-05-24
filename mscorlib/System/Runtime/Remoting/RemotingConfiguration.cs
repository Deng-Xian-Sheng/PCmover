using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Security;
using System.Security.Permissions;

namespace System.Runtime.Remoting
{
	// Token: 0x020007BE RID: 1982
	[ComVisible(true)]
	public static class RemotingConfiguration
	{
		// Token: 0x060055CE RID: 21966 RVA: 0x00130C9A File Offset: 0x0012EE9A
		[SecuritySafeCritical]
		[Obsolete("Use System.Runtime.Remoting.RemotingConfiguration.Configure(string fileName, bool ensureSecurity) instead.", false)]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void Configure(string filename)
		{
			RemotingConfiguration.Configure(filename, false);
		}

		// Token: 0x060055CF RID: 21967 RVA: 0x00130CA3 File Offset: 0x0012EEA3
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void Configure(string filename, bool ensureSecurity)
		{
			RemotingConfigHandler.DoConfiguration(filename, ensureSecurity);
			RemotingServices.InternalSetRemoteActivationConfigured();
		}

		// Token: 0x17000E25 RID: 3621
		// (get) Token: 0x060055D0 RID: 21968 RVA: 0x00130CB1 File Offset: 0x0012EEB1
		// (set) Token: 0x060055D1 RID: 21969 RVA: 0x00130CC1 File Offset: 0x0012EEC1
		public static string ApplicationName
		{
			get
			{
				if (!RemotingConfigHandler.HasApplicationNameBeenSet())
				{
					return null;
				}
				return RemotingConfigHandler.ApplicationName;
			}
			[SecuritySafeCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
			set
			{
				RemotingConfigHandler.ApplicationName = value;
			}
		}

		// Token: 0x17000E26 RID: 3622
		// (get) Token: 0x060055D2 RID: 21970 RVA: 0x00130CC9 File Offset: 0x0012EEC9
		public static string ApplicationId
		{
			[SecurityCritical]
			get
			{
				return Identity.AppDomainUniqueId;
			}
		}

		// Token: 0x17000E27 RID: 3623
		// (get) Token: 0x060055D3 RID: 21971 RVA: 0x00130CD0 File Offset: 0x0012EED0
		public static string ProcessId
		{
			[SecurityCritical]
			get
			{
				return Identity.ProcessGuid;
			}
		}

		// Token: 0x17000E28 RID: 3624
		// (get) Token: 0x060055D4 RID: 21972 RVA: 0x00130CD7 File Offset: 0x0012EED7
		// (set) Token: 0x060055D5 RID: 21973 RVA: 0x00130CDE File Offset: 0x0012EEDE
		public static CustomErrorsModes CustomErrorsMode
		{
			get
			{
				return RemotingConfigHandler.CustomErrorsMode;
			}
			[SecuritySafeCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
			set
			{
				RemotingConfigHandler.CustomErrorsMode = value;
			}
		}

		// Token: 0x060055D6 RID: 21974 RVA: 0x00130CE8 File Offset: 0x0012EEE8
		public static bool CustomErrorsEnabled(bool isLocalRequest)
		{
			switch (RemotingConfiguration.CustomErrorsMode)
			{
			case CustomErrorsModes.On:
				return true;
			case CustomErrorsModes.Off:
				return false;
			case CustomErrorsModes.RemoteOnly:
				return !isLocalRequest;
			default:
				return true;
			}
		}

		// Token: 0x060055D7 RID: 21975 RVA: 0x00130D1C File Offset: 0x0012EF1C
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterActivatedServiceType(Type type)
		{
			ActivatedServiceTypeEntry entry = new ActivatedServiceTypeEntry(type);
			RemotingConfiguration.RegisterActivatedServiceType(entry);
		}

		// Token: 0x060055D8 RID: 21976 RVA: 0x00130D36 File Offset: 0x0012EF36
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterActivatedServiceType(ActivatedServiceTypeEntry entry)
		{
			RemotingConfigHandler.RegisterActivatedServiceType(entry);
			if (!RemotingConfiguration.s_ListeningForActivationRequests)
			{
				RemotingConfiguration.s_ListeningForActivationRequests = true;
				ActivationServices.StartListeningForRemoteRequests();
			}
		}

		// Token: 0x060055D9 RID: 21977 RVA: 0x00130D54 File Offset: 0x0012EF54
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterWellKnownServiceType(Type type, string objectUri, WellKnownObjectMode mode)
		{
			WellKnownServiceTypeEntry entry = new WellKnownServiceTypeEntry(type, objectUri, mode);
			RemotingConfiguration.RegisterWellKnownServiceType(entry);
		}

		// Token: 0x060055DA RID: 21978 RVA: 0x00130D70 File Offset: 0x0012EF70
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterWellKnownServiceType(WellKnownServiceTypeEntry entry)
		{
			RemotingConfigHandler.RegisterWellKnownServiceType(entry);
		}

		// Token: 0x060055DB RID: 21979 RVA: 0x00130D78 File Offset: 0x0012EF78
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterActivatedClientType(Type type, string appUrl)
		{
			ActivatedClientTypeEntry entry = new ActivatedClientTypeEntry(type, appUrl);
			RemotingConfiguration.RegisterActivatedClientType(entry);
		}

		// Token: 0x060055DC RID: 21980 RVA: 0x00130D93 File Offset: 0x0012EF93
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterActivatedClientType(ActivatedClientTypeEntry entry)
		{
			RemotingConfigHandler.RegisterActivatedClientType(entry);
			RemotingServices.InternalSetRemoteActivationConfigured();
		}

		// Token: 0x060055DD RID: 21981 RVA: 0x00130DA0 File Offset: 0x0012EFA0
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterWellKnownClientType(Type type, string objectUrl)
		{
			WellKnownClientTypeEntry entry = new WellKnownClientTypeEntry(type, objectUrl);
			RemotingConfiguration.RegisterWellKnownClientType(entry);
		}

		// Token: 0x060055DE RID: 21982 RVA: 0x00130DBB File Offset: 0x0012EFBB
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static void RegisterWellKnownClientType(WellKnownClientTypeEntry entry)
		{
			RemotingConfigHandler.RegisterWellKnownClientType(entry);
			RemotingServices.InternalSetRemoteActivationConfigured();
		}

		// Token: 0x060055DF RID: 21983 RVA: 0x00130DC8 File Offset: 0x0012EFC8
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static ActivatedServiceTypeEntry[] GetRegisteredActivatedServiceTypes()
		{
			return RemotingConfigHandler.GetRegisteredActivatedServiceTypes();
		}

		// Token: 0x060055E0 RID: 21984 RVA: 0x00130DCF File Offset: 0x0012EFCF
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static WellKnownServiceTypeEntry[] GetRegisteredWellKnownServiceTypes()
		{
			return RemotingConfigHandler.GetRegisteredWellKnownServiceTypes();
		}

		// Token: 0x060055E1 RID: 21985 RVA: 0x00130DD6 File Offset: 0x0012EFD6
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static ActivatedClientTypeEntry[] GetRegisteredActivatedClientTypes()
		{
			return RemotingConfigHandler.GetRegisteredActivatedClientTypes();
		}

		// Token: 0x060055E2 RID: 21986 RVA: 0x00130DDD File Offset: 0x0012EFDD
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static WellKnownClientTypeEntry[] GetRegisteredWellKnownClientTypes()
		{
			return RemotingConfigHandler.GetRegisteredWellKnownClientTypes();
		}

		// Token: 0x060055E3 RID: 21987 RVA: 0x00130DE4 File Offset: 0x0012EFE4
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static ActivatedClientTypeEntry IsRemotelyActivatedClientType(Type svrType)
		{
			if (svrType == null)
			{
				throw new ArgumentNullException("svrType");
			}
			RuntimeType runtimeType = svrType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			return RemotingConfigHandler.IsRemotelyActivatedClientType(runtimeType);
		}

		// Token: 0x060055E4 RID: 21988 RVA: 0x00130E2B File Offset: 0x0012F02B
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static ActivatedClientTypeEntry IsRemotelyActivatedClientType(string typeName, string assemblyName)
		{
			return RemotingConfigHandler.IsRemotelyActivatedClientType(typeName, assemblyName);
		}

		// Token: 0x060055E5 RID: 21989 RVA: 0x00130E34 File Offset: 0x0012F034
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static WellKnownClientTypeEntry IsWellKnownClientType(Type svrType)
		{
			if (svrType == null)
			{
				throw new ArgumentNullException("svrType");
			}
			RuntimeType runtimeType = svrType as RuntimeType;
			if (runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			return RemotingConfigHandler.IsWellKnownClientType(runtimeType);
		}

		// Token: 0x060055E6 RID: 21990 RVA: 0x00130E7B File Offset: 0x0012F07B
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static WellKnownClientTypeEntry IsWellKnownClientType(string typeName, string assemblyName)
		{
			return RemotingConfigHandler.IsWellKnownClientType(typeName, assemblyName);
		}

		// Token: 0x060055E7 RID: 21991 RVA: 0x00130E84 File Offset: 0x0012F084
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.RemotingConfiguration)]
		public static bool IsActivationAllowed(Type svrType)
		{
			RuntimeType runtimeType = svrType as RuntimeType;
			if (svrType != null && runtimeType == null)
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_MustBeRuntimeType"));
			}
			return RemotingConfigHandler.IsActivationAllowed(runtimeType);
		}

		// Token: 0x04002775 RID: 10101
		private static volatile bool s_ListeningForActivationRequests;
	}
}
