using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata;
using System.Security;
using System.Security.Permissions;
using System.Security.Util;

namespace System.Runtime.Remoting
{
	// Token: 0x020007AE RID: 1966
	internal static class RemotingConfigHandler
	{
		// Token: 0x17000E00 RID: 3584
		// (get) Token: 0x0600551A RID: 21786 RVA: 0x0012E373 File Offset: 0x0012C573
		// (set) Token: 0x0600551B RID: 21787 RVA: 0x0012E398 File Offset: 0x0012C598
		internal static string ApplicationName
		{
			get
			{
				if (RemotingConfigHandler._applicationName == null)
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_Config_NoAppName"));
				}
				return RemotingConfigHandler._applicationName;
			}
			set
			{
				if (RemotingConfigHandler._applicationName != null)
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_AppNameSet"), RemotingConfigHandler._applicationName));
				}
				RemotingConfigHandler._applicationName = value;
				char[] trimChars = new char[]
				{
					'/'
				};
				if (RemotingConfigHandler._applicationName.StartsWith("/", StringComparison.Ordinal))
				{
					RemotingConfigHandler._applicationName = RemotingConfigHandler._applicationName.TrimStart(trimChars);
				}
				if (RemotingConfigHandler._applicationName.EndsWith("/", StringComparison.Ordinal))
				{
					RemotingConfigHandler._applicationName = RemotingConfigHandler._applicationName.TrimEnd(trimChars);
				}
			}
		}

		// Token: 0x0600551C RID: 21788 RVA: 0x0012E433 File Offset: 0x0012C633
		internal static bool HasApplicationNameBeenSet()
		{
			return RemotingConfigHandler._applicationName != null;
		}

		// Token: 0x17000E01 RID: 3585
		// (get) Token: 0x0600551D RID: 21789 RVA: 0x0012E43F File Offset: 0x0012C63F
		internal static bool UrlObjRefMode
		{
			get
			{
				return RemotingConfigHandler._bUrlObjRefMode;
			}
		}

		// Token: 0x17000E02 RID: 3586
		// (get) Token: 0x0600551E RID: 21790 RVA: 0x0012E448 File Offset: 0x0012C648
		// (set) Token: 0x0600551F RID: 21791 RVA: 0x0012E451 File Offset: 0x0012C651
		internal static CustomErrorsModes CustomErrorsMode
		{
			get
			{
				return RemotingConfigHandler._errorMode;
			}
			set
			{
				if (RemotingConfigHandler._errorsModeSet)
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_Config_ErrorsModeSet"));
				}
				RemotingConfigHandler._errorMode = value;
				RemotingConfigHandler._errorsModeSet = true;
			}
		}

		// Token: 0x06005520 RID: 21792 RVA: 0x0012E47C File Offset: 0x0012C67C
		[SecurityCritical]
		internal static IMessageSink FindDelayLoadChannelForCreateMessageSink(string url, object data, out string objectURI)
		{
			RemotingConfigHandler.LoadMachineConfigIfNecessary();
			objectURI = null;
			foreach (object obj in RemotingConfigHandler._delayLoadChannelConfigQueue)
			{
				DelayLoadClientChannelEntry delayLoadClientChannelEntry = (DelayLoadClientChannelEntry)obj;
				IChannelSender channel = delayLoadClientChannelEntry.Channel;
				if (channel != null)
				{
					IMessageSink messageSink = channel.CreateMessageSink(url, data, out objectURI);
					if (messageSink != null)
					{
						delayLoadClientChannelEntry.RegisterChannel();
						return messageSink;
					}
				}
			}
			return null;
		}

		// Token: 0x06005521 RID: 21793 RVA: 0x0012E500 File Offset: 0x0012C700
		[SecurityCritical]
		private static void LoadMachineConfigIfNecessary()
		{
			if (!RemotingConfigHandler._bMachineConfigLoaded)
			{
				RemotingConfigHandler.RemotingConfigInfo info = RemotingConfigHandler.Info;
				lock (info)
				{
					if (!RemotingConfigHandler._bMachineConfigLoaded)
					{
						RemotingXmlConfigFileData remotingXmlConfigFileData = RemotingXmlConfigFileParser.ParseDefaultConfiguration();
						if (remotingXmlConfigFileData != null)
						{
							RemotingConfigHandler.ConfigureRemoting(remotingXmlConfigFileData, false);
						}
						string machineDirectory = Config.MachineDirectory;
						string text = machineDirectory + "machine.config";
						new FileIOPermission(FileIOPermissionAccess.Read, text).Assert();
						remotingXmlConfigFileData = RemotingConfigHandler.LoadConfigurationFromXmlFile(text);
						if (remotingXmlConfigFileData != null)
						{
							RemotingConfigHandler.ConfigureRemoting(remotingXmlConfigFileData, false);
						}
						RemotingConfigHandler._bMachineConfigLoaded = true;
					}
				}
			}
		}

		// Token: 0x06005522 RID: 21794 RVA: 0x0012E598 File Offset: 0x0012C798
		[SecurityCritical]
		internal static void DoConfiguration(string filename, bool ensureSecurity)
		{
			RemotingConfigHandler.LoadMachineConfigIfNecessary();
			RemotingXmlConfigFileData remotingXmlConfigFileData = RemotingConfigHandler.LoadConfigurationFromXmlFile(filename);
			if (remotingXmlConfigFileData != null)
			{
				RemotingConfigHandler.ConfigureRemoting(remotingXmlConfigFileData, ensureSecurity);
			}
		}

		// Token: 0x06005523 RID: 21795 RVA: 0x0012E5BC File Offset: 0x0012C7BC
		private static RemotingXmlConfigFileData LoadConfigurationFromXmlFile(string filename)
		{
			RemotingXmlConfigFileData result;
			try
			{
				if (filename != null)
				{
					result = RemotingXmlConfigFileParser.ParseConfigFile(filename);
				}
				else
				{
					result = null;
				}
			}
			catch (Exception ex)
			{
				Exception ex2 = ex.InnerException as FileNotFoundException;
				if (ex2 != null)
				{
					ex = ex2;
				}
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_ReadFailure"), filename, ex));
			}
			return result;
		}

		// Token: 0x06005524 RID: 21796 RVA: 0x0012E618 File Offset: 0x0012C818
		[SecurityCritical]
		private static void ConfigureRemoting(RemotingXmlConfigFileData configData, bool ensureSecurity)
		{
			try
			{
				string applicationName = configData.ApplicationName;
				if (applicationName != null)
				{
					RemotingConfigHandler.ApplicationName = applicationName;
				}
				if (configData.CustomErrors != null)
				{
					RemotingConfigHandler._errorMode = configData.CustomErrors.Mode;
				}
				RemotingConfigHandler.ConfigureChannels(configData, ensureSecurity);
				if (configData.Lifetime != null)
				{
					if (configData.Lifetime.IsLeaseTimeSet)
					{
						LifetimeServices.LeaseTime = configData.Lifetime.LeaseTime;
					}
					if (configData.Lifetime.IsRenewOnCallTimeSet)
					{
						LifetimeServices.RenewOnCallTime = configData.Lifetime.RenewOnCallTime;
					}
					if (configData.Lifetime.IsSponsorshipTimeoutSet)
					{
						LifetimeServices.SponsorshipTimeout = configData.Lifetime.SponsorshipTimeout;
					}
					if (configData.Lifetime.IsLeaseManagerPollTimeSet)
					{
						LifetimeServices.LeaseManagerPollTime = configData.Lifetime.LeaseManagerPollTime;
					}
				}
				RemotingConfigHandler._bUrlObjRefMode = configData.UrlObjRefMode;
				RemotingConfigHandler.Info.StoreRemoteAppEntries(configData);
				RemotingConfigHandler.Info.StoreActivatedExports(configData);
				RemotingConfigHandler.Info.StoreInteropEntries(configData);
				RemotingConfigHandler.Info.StoreWellKnownExports(configData);
				if (configData.ServerActivatedEntries.Count > 0)
				{
					ActivationServices.StartListeningForRemoteRequests();
				}
			}
			catch (Exception arg)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_ConfigurationFailure"), arg));
			}
		}

		// Token: 0x06005525 RID: 21797 RVA: 0x0012E74C File Offset: 0x0012C94C
		[SecurityCritical]
		private static void ConfigureChannels(RemotingXmlConfigFileData configData, bool ensureSecurity)
		{
			RemotingServices.RegisterWellKnownChannels();
			foreach (object obj in configData.ChannelEntries)
			{
				RemotingXmlConfigFileData.ChannelEntry channelEntry = (RemotingXmlConfigFileData.ChannelEntry)obj;
				if (!channelEntry.DelayLoad)
				{
					IChannel chnl = RemotingConfigHandler.CreateChannelFromConfigEntry(channelEntry);
					ChannelServices.RegisterChannel(chnl, ensureSecurity);
				}
				else
				{
					RemotingConfigHandler._delayLoadChannelConfigQueue.Enqueue(new DelayLoadClientChannelEntry(channelEntry, ensureSecurity));
				}
			}
		}

		// Token: 0x06005526 RID: 21798 RVA: 0x0012E7D0 File Offset: 0x0012C9D0
		[SecurityCritical]
		internal static IChannel CreateChannelFromConfigEntry(RemotingXmlConfigFileData.ChannelEntry entry)
		{
			Type type = RemotingConfigHandler.RemotingConfigInfo.LoadType(entry.TypeName, entry.AssemblyName);
			bool flag = typeof(IChannelReceiver).IsAssignableFrom(type);
			bool flag2 = typeof(IChannelSender).IsAssignableFrom(type);
			IClientChannelSinkProvider clientChannelSinkProvider = null;
			IServerChannelSinkProvider serverChannelSinkProvider = null;
			if (entry.ClientSinkProviders.Count > 0)
			{
				clientChannelSinkProvider = RemotingConfigHandler.CreateClientChannelSinkProviderChain(entry.ClientSinkProviders);
			}
			if (entry.ServerSinkProviders.Count > 0)
			{
				serverChannelSinkProvider = RemotingConfigHandler.CreateServerChannelSinkProviderChain(entry.ServerSinkProviders);
			}
			object[] args;
			if (flag && flag2)
			{
				args = new object[]
				{
					entry.Properties,
					clientChannelSinkProvider,
					serverChannelSinkProvider
				};
			}
			else if (flag)
			{
				args = new object[]
				{
					entry.Properties,
					serverChannelSinkProvider
				};
			}
			else
			{
				if (!flag2)
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_InvalidChannelType"), type.FullName));
				}
				args = new object[]
				{
					entry.Properties,
					clientChannelSinkProvider
				};
			}
			IChannel result = null;
			try
			{
				result = (IChannel)Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, null, args, null, null);
			}
			catch (MissingMethodException)
			{
				string arg = null;
				if (flag && flag2)
				{
					arg = "MyChannel(IDictionary properties, IClientChannelSinkProvider clientSinkProvider, IServerChannelSinkProvider serverSinkProvider)";
				}
				else if (flag)
				{
					arg = "MyChannel(IDictionary properties, IServerChannelSinkProvider serverSinkProvider)";
				}
				else if (flag2)
				{
					arg = "MyChannel(IDictionary properties, IClientChannelSinkProvider clientSinkProvider)";
				}
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_ChannelMissingCtor"), type.FullName, arg));
			}
			return result;
		}

		// Token: 0x06005527 RID: 21799 RVA: 0x0012E940 File Offset: 0x0012CB40
		[SecurityCritical]
		private static IClientChannelSinkProvider CreateClientChannelSinkProviderChain(ArrayList entries)
		{
			IClientChannelSinkProvider clientChannelSinkProvider = null;
			IClientChannelSinkProvider clientChannelSinkProvider2 = null;
			foreach (object obj in entries)
			{
				RemotingXmlConfigFileData.SinkProviderEntry entry = (RemotingXmlConfigFileData.SinkProviderEntry)obj;
				if (clientChannelSinkProvider == null)
				{
					clientChannelSinkProvider = (IClientChannelSinkProvider)RemotingConfigHandler.CreateChannelSinkProvider(entry, false);
					clientChannelSinkProvider2 = clientChannelSinkProvider;
				}
				else
				{
					clientChannelSinkProvider2.Next = (IClientChannelSinkProvider)RemotingConfigHandler.CreateChannelSinkProvider(entry, false);
					clientChannelSinkProvider2 = clientChannelSinkProvider2.Next;
				}
			}
			return clientChannelSinkProvider;
		}

		// Token: 0x06005528 RID: 21800 RVA: 0x0012E9C4 File Offset: 0x0012CBC4
		[SecurityCritical]
		private static IServerChannelSinkProvider CreateServerChannelSinkProviderChain(ArrayList entries)
		{
			IServerChannelSinkProvider serverChannelSinkProvider = null;
			IServerChannelSinkProvider serverChannelSinkProvider2 = null;
			foreach (object obj in entries)
			{
				RemotingXmlConfigFileData.SinkProviderEntry entry = (RemotingXmlConfigFileData.SinkProviderEntry)obj;
				if (serverChannelSinkProvider == null)
				{
					serverChannelSinkProvider = (IServerChannelSinkProvider)RemotingConfigHandler.CreateChannelSinkProvider(entry, true);
					serverChannelSinkProvider2 = serverChannelSinkProvider;
				}
				else
				{
					serverChannelSinkProvider2.Next = (IServerChannelSinkProvider)RemotingConfigHandler.CreateChannelSinkProvider(entry, true);
					serverChannelSinkProvider2 = serverChannelSinkProvider2.Next;
				}
			}
			return serverChannelSinkProvider;
		}

		// Token: 0x06005529 RID: 21801 RVA: 0x0012EA48 File Offset: 0x0012CC48
		[SecurityCritical]
		private static object CreateChannelSinkProvider(RemotingXmlConfigFileData.SinkProviderEntry entry, bool bServer)
		{
			object result = null;
			Type type = RemotingConfigHandler.RemotingConfigInfo.LoadType(entry.TypeName, entry.AssemblyName);
			if (bServer)
			{
				if (!typeof(IServerChannelSinkProvider).IsAssignableFrom(type))
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_InvalidSinkProviderType"), type.FullName, "IServerChannelSinkProvider"));
				}
			}
			else if (!typeof(IClientChannelSinkProvider).IsAssignableFrom(type))
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_InvalidSinkProviderType"), type.FullName, "IClientChannelSinkProvider"));
			}
			if (entry.IsFormatter && ((bServer && !typeof(IServerFormatterSinkProvider).IsAssignableFrom(type)) || (!bServer && !typeof(IClientFormatterSinkProvider).IsAssignableFrom(type))))
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_SinkProviderNotFormatter"), type.FullName));
			}
			object[] args = new object[]
			{
				entry.Properties,
				entry.ProviderData
			};
			try
			{
				result = Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.Public | BindingFlags.CreateInstance, null, args, null, null);
			}
			catch (MissingMethodException)
			{
				throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_SinkProviderMissingCtor"), type.FullName, "MySinkProvider(IDictionary properties, ICollection providerData)"));
			}
			return result;
		}

		// Token: 0x0600552A RID: 21802 RVA: 0x0012EB90 File Offset: 0x0012CD90
		[SecurityCritical]
		internal static ActivatedClientTypeEntry IsRemotelyActivatedClientType(RuntimeType svrType)
		{
			RemotingTypeCachedData reflectionCachedData = InternalRemotingServices.GetReflectionCachedData(svrType);
			string simpleAssemblyName = reflectionCachedData.SimpleAssemblyName;
			ActivatedClientTypeEntry activatedClientTypeEntry = RemotingConfigHandler.Info.QueryRemoteActivate(svrType.FullName, simpleAssemblyName);
			if (activatedClientTypeEntry == null)
			{
				string assemblyName = reflectionCachedData.AssemblyName;
				activatedClientTypeEntry = RemotingConfigHandler.Info.QueryRemoteActivate(svrType.FullName, assemblyName);
				if (activatedClientTypeEntry == null)
				{
					activatedClientTypeEntry = RemotingConfigHandler.Info.QueryRemoteActivate(svrType.Name, simpleAssemblyName);
				}
			}
			return activatedClientTypeEntry;
		}

		// Token: 0x0600552B RID: 21803 RVA: 0x0012EBEF File Offset: 0x0012CDEF
		internal static ActivatedClientTypeEntry IsRemotelyActivatedClientType(string typeName, string assemblyName)
		{
			return RemotingConfigHandler.Info.QueryRemoteActivate(typeName, assemblyName);
		}

		// Token: 0x0600552C RID: 21804 RVA: 0x0012EC00 File Offset: 0x0012CE00
		[SecurityCritical]
		internal static WellKnownClientTypeEntry IsWellKnownClientType(RuntimeType svrType)
		{
			RemotingTypeCachedData reflectionCachedData = InternalRemotingServices.GetReflectionCachedData(svrType);
			string simpleAssemblyName = reflectionCachedData.SimpleAssemblyName;
			WellKnownClientTypeEntry wellKnownClientTypeEntry = RemotingConfigHandler.Info.QueryConnect(svrType.FullName, simpleAssemblyName);
			if (wellKnownClientTypeEntry == null)
			{
				wellKnownClientTypeEntry = RemotingConfigHandler.Info.QueryConnect(svrType.Name, simpleAssemblyName);
			}
			return wellKnownClientTypeEntry;
		}

		// Token: 0x0600552D RID: 21805 RVA: 0x0012EC43 File Offset: 0x0012CE43
		internal static WellKnownClientTypeEntry IsWellKnownClientType(string typeName, string assemblyName)
		{
			return RemotingConfigHandler.Info.QueryConnect(typeName, assemblyName);
		}

		// Token: 0x0600552E RID: 21806 RVA: 0x0012EC54 File Offset: 0x0012CE54
		private static void ParseGenericType(string typeAssem, int indexStart, out string typeName, out string assemName)
		{
			int length = typeAssem.Length;
			int num = 1;
			int num2 = indexStart;
			while (num > 0 && ++num2 < length - 1)
			{
				if (typeAssem[num2] == '[')
				{
					num++;
				}
				else if (typeAssem[num2] == ']')
				{
					num--;
				}
			}
			if (num > 0 || num2 >= length)
			{
				typeName = null;
				assemName = null;
				return;
			}
			num2 = typeAssem.IndexOf(',', num2);
			if (num2 >= 0 && num2 < length - 1)
			{
				typeName = typeAssem.Substring(0, num2).Trim();
				assemName = typeAssem.Substring(num2 + 1).Trim();
				return;
			}
			typeName = null;
			assemName = null;
		}

		// Token: 0x0600552F RID: 21807 RVA: 0x0012ECE8 File Offset: 0x0012CEE8
		internal static void ParseType(string typeAssem, out string typeName, out string assemName)
		{
			int num = typeAssem.IndexOf("[");
			if (num >= 0 && num < typeAssem.Length - 1)
			{
				RemotingConfigHandler.ParseGenericType(typeAssem, num, out typeName, out assemName);
				return;
			}
			int num2 = typeAssem.IndexOf(",");
			if (num2 >= 0 && num2 < typeAssem.Length - 1)
			{
				typeName = typeAssem.Substring(0, num2).Trim();
				assemName = typeAssem.Substring(num2 + 1).Trim();
				return;
			}
			typeName = null;
			assemName = null;
		}

		// Token: 0x06005530 RID: 21808 RVA: 0x0012ED60 File Offset: 0x0012CF60
		[SecurityCritical]
		internal static bool IsActivationAllowed(RuntimeType svrType)
		{
			if (svrType == null)
			{
				return false;
			}
			RemotingTypeCachedData reflectionCachedData = InternalRemotingServices.GetReflectionCachedData(svrType);
			string simpleAssemblyName = reflectionCachedData.SimpleAssemblyName;
			return RemotingConfigHandler.Info.ActivationAllowed(svrType.FullName, simpleAssemblyName);
		}

		// Token: 0x06005531 RID: 21809 RVA: 0x0012ED98 File Offset: 0x0012CF98
		[SecurityCritical]
		internal static bool IsActivationAllowed(string TypeName)
		{
			string text = RemotingServices.InternalGetTypeNameFromQualifiedTypeName(TypeName);
			if (text == null)
			{
				return false;
			}
			string typeName;
			string text2;
			RemotingConfigHandler.ParseType(text, out typeName, out text2);
			if (text2 == null)
			{
				return false;
			}
			int num = text2.IndexOf(',');
			if (num != -1)
			{
				text2 = text2.Substring(0, num);
			}
			return RemotingConfigHandler.Info.ActivationAllowed(typeName, text2);
		}

		// Token: 0x06005532 RID: 21810 RVA: 0x0012EDE2 File Offset: 0x0012CFE2
		internal static void RegisterActivatedServiceType(ActivatedServiceTypeEntry entry)
		{
			RemotingConfigHandler.Info.AddActivatedType(entry.TypeName, entry.AssemblyName, entry.ContextAttributes);
		}

		// Token: 0x06005533 RID: 21811 RVA: 0x0012EE00 File Offset: 0x0012D000
		[SecurityCritical]
		internal static void RegisterWellKnownServiceType(WellKnownServiceTypeEntry entry)
		{
			string typeName = entry.TypeName;
			string assemblyName = entry.AssemblyName;
			string objectUri = entry.ObjectUri;
			WellKnownObjectMode mode = entry.Mode;
			RemotingConfigHandler.RemotingConfigInfo info = RemotingConfigHandler.Info;
			lock (info)
			{
				RemotingConfigHandler.Info.AddWellKnownEntry(entry);
			}
		}

		// Token: 0x06005534 RID: 21812 RVA: 0x0012EE68 File Offset: 0x0012D068
		internal static void RegisterActivatedClientType(ActivatedClientTypeEntry entry)
		{
			RemotingConfigHandler.Info.AddActivatedClientType(entry);
		}

		// Token: 0x06005535 RID: 21813 RVA: 0x0012EE75 File Offset: 0x0012D075
		internal static void RegisterWellKnownClientType(WellKnownClientTypeEntry entry)
		{
			RemotingConfigHandler.Info.AddWellKnownClientType(entry);
		}

		// Token: 0x06005536 RID: 21814 RVA: 0x0012EE82 File Offset: 0x0012D082
		[SecurityCritical]
		internal static Type GetServerTypeForUri(string URI)
		{
			URI = Identity.RemoveAppNameOrAppGuidIfNecessary(URI);
			return RemotingConfigHandler.Info.GetServerTypeForUri(URI);
		}

		// Token: 0x06005537 RID: 21815 RVA: 0x0012EE97 File Offset: 0x0012D097
		internal static ActivatedServiceTypeEntry[] GetRegisteredActivatedServiceTypes()
		{
			return RemotingConfigHandler.Info.GetRegisteredActivatedServiceTypes();
		}

		// Token: 0x06005538 RID: 21816 RVA: 0x0012EEA3 File Offset: 0x0012D0A3
		internal static WellKnownServiceTypeEntry[] GetRegisteredWellKnownServiceTypes()
		{
			return RemotingConfigHandler.Info.GetRegisteredWellKnownServiceTypes();
		}

		// Token: 0x06005539 RID: 21817 RVA: 0x0012EEAF File Offset: 0x0012D0AF
		internal static ActivatedClientTypeEntry[] GetRegisteredActivatedClientTypes()
		{
			return RemotingConfigHandler.Info.GetRegisteredActivatedClientTypes();
		}

		// Token: 0x0600553A RID: 21818 RVA: 0x0012EEBB File Offset: 0x0012D0BB
		internal static WellKnownClientTypeEntry[] GetRegisteredWellKnownClientTypes()
		{
			return RemotingConfigHandler.Info.GetRegisteredWellKnownClientTypes();
		}

		// Token: 0x0600553B RID: 21819 RVA: 0x0012EEC7 File Offset: 0x0012D0C7
		[SecurityCritical]
		internal static ServerIdentity CreateWellKnownObject(string uri)
		{
			uri = Identity.RemoveAppNameOrAppGuidIfNecessary(uri);
			return RemotingConfigHandler.Info.StartupWellKnownObject(uri);
		}

		// Token: 0x0400272F RID: 10031
		private static volatile string _applicationName;

		// Token: 0x04002730 RID: 10032
		private static volatile CustomErrorsModes _errorMode = CustomErrorsModes.RemoteOnly;

		// Token: 0x04002731 RID: 10033
		private static volatile bool _errorsModeSet = false;

		// Token: 0x04002732 RID: 10034
		private static volatile bool _bMachineConfigLoaded = false;

		// Token: 0x04002733 RID: 10035
		private static volatile bool _bUrlObjRefMode = false;

		// Token: 0x04002734 RID: 10036
		private static Queue _delayLoadChannelConfigQueue = new Queue();

		// Token: 0x04002735 RID: 10037
		public static RemotingConfigHandler.RemotingConfigInfo Info = new RemotingConfigHandler.RemotingConfigInfo();

		// Token: 0x04002736 RID: 10038
		private const string _machineConfigFilename = "machine.config";

		// Token: 0x02000C68 RID: 3176
		internal class RemotingConfigInfo
		{
			// Token: 0x06007083 RID: 28803 RVA: 0x00183600 File Offset: 0x00181800
			internal RemotingConfigInfo()
			{
				this._remoteTypeInfo = Hashtable.Synchronized(new Hashtable());
				this._exportableClasses = Hashtable.Synchronized(new Hashtable());
				this._remoteAppInfo = Hashtable.Synchronized(new Hashtable());
				this._wellKnownExportInfo = Hashtable.Synchronized(new Hashtable());
			}

			// Token: 0x06007084 RID: 28804 RVA: 0x00183653 File Offset: 0x00181853
			private string EncodeTypeAndAssemblyNames(string typeName, string assemblyName)
			{
				return typeName + ", " + assemblyName.ToLower(CultureInfo.InvariantCulture);
			}

			// Token: 0x06007085 RID: 28805 RVA: 0x0018366C File Offset: 0x0018186C
			internal void StoreActivatedExports(RemotingXmlConfigFileData configData)
			{
				foreach (object obj in configData.ServerActivatedEntries)
				{
					RemotingXmlConfigFileData.TypeEntry typeEntry = (RemotingXmlConfigFileData.TypeEntry)obj;
					RemotingConfiguration.RegisterActivatedServiceType(new ActivatedServiceTypeEntry(typeEntry.TypeName, typeEntry.AssemblyName)
					{
						ContextAttributes = RemotingConfigHandler.RemotingConfigInfo.CreateContextAttributesFromConfigEntries(typeEntry.ContextAttributes)
					});
				}
			}

			// Token: 0x06007086 RID: 28806 RVA: 0x001836E8 File Offset: 0x001818E8
			[SecurityCritical]
			internal void StoreInteropEntries(RemotingXmlConfigFileData configData)
			{
				foreach (object obj in configData.InteropXmlElementEntries)
				{
					RemotingXmlConfigFileData.InteropXmlElementEntry interopXmlElementEntry = (RemotingXmlConfigFileData.InteropXmlElementEntry)obj;
					Assembly assembly = Assembly.Load(interopXmlElementEntry.UrtAssemblyName);
					Type type = assembly.GetType(interopXmlElementEntry.UrtTypeName);
					SoapServices.RegisterInteropXmlElement(interopXmlElementEntry.XmlElementName, interopXmlElementEntry.XmlElementNamespace, type);
				}
				foreach (object obj2 in configData.InteropXmlTypeEntries)
				{
					RemotingXmlConfigFileData.InteropXmlTypeEntry interopXmlTypeEntry = (RemotingXmlConfigFileData.InteropXmlTypeEntry)obj2;
					Assembly assembly2 = Assembly.Load(interopXmlTypeEntry.UrtAssemblyName);
					Type type2 = assembly2.GetType(interopXmlTypeEntry.UrtTypeName);
					SoapServices.RegisterInteropXmlType(interopXmlTypeEntry.XmlTypeName, interopXmlTypeEntry.XmlTypeNamespace, type2);
				}
				foreach (object obj3 in configData.PreLoadEntries)
				{
					RemotingXmlConfigFileData.PreLoadEntry preLoadEntry = (RemotingXmlConfigFileData.PreLoadEntry)obj3;
					Assembly assembly3 = Assembly.Load(preLoadEntry.AssemblyName);
					if (preLoadEntry.TypeName != null)
					{
						Type type3 = assembly3.GetType(preLoadEntry.TypeName);
						SoapServices.PreLoad(type3);
					}
					else
					{
						SoapServices.PreLoad(assembly3);
					}
				}
			}

			// Token: 0x06007087 RID: 28807 RVA: 0x00183864 File Offset: 0x00181A64
			internal void StoreRemoteAppEntries(RemotingXmlConfigFileData configData)
			{
				char[] trimChars = new char[]
				{
					'/'
				};
				foreach (object obj in configData.RemoteAppEntries)
				{
					RemotingXmlConfigFileData.RemoteAppEntry remoteAppEntry = (RemotingXmlConfigFileData.RemoteAppEntry)obj;
					string text = remoteAppEntry.AppUri;
					if (text != null && !text.EndsWith("/", StringComparison.Ordinal))
					{
						text = text.TrimEnd(trimChars);
					}
					foreach (object obj2 in remoteAppEntry.ActivatedObjects)
					{
						RemotingXmlConfigFileData.TypeEntry typeEntry = (RemotingXmlConfigFileData.TypeEntry)obj2;
						RemotingConfiguration.RegisterActivatedClientType(new ActivatedClientTypeEntry(typeEntry.TypeName, typeEntry.AssemblyName, text)
						{
							ContextAttributes = RemotingConfigHandler.RemotingConfigInfo.CreateContextAttributesFromConfigEntries(typeEntry.ContextAttributes)
						});
					}
					foreach (object obj3 in remoteAppEntry.WellKnownObjects)
					{
						RemotingXmlConfigFileData.ClientWellKnownEntry clientWellKnownEntry = (RemotingXmlConfigFileData.ClientWellKnownEntry)obj3;
						RemotingConfiguration.RegisterWellKnownClientType(new WellKnownClientTypeEntry(clientWellKnownEntry.TypeName, clientWellKnownEntry.AssemblyName, clientWellKnownEntry.Url)
						{
							ApplicationUrl = text
						});
					}
				}
			}

			// Token: 0x06007088 RID: 28808 RVA: 0x001839FC File Offset: 0x00181BFC
			[SecurityCritical]
			internal void StoreWellKnownExports(RemotingXmlConfigFileData configData)
			{
				foreach (object obj in configData.ServerWellKnownEntries)
				{
					RemotingXmlConfigFileData.ServerWellKnownEntry serverWellKnownEntry = (RemotingXmlConfigFileData.ServerWellKnownEntry)obj;
					RemotingConfigHandler.RegisterWellKnownServiceType(new WellKnownServiceTypeEntry(serverWellKnownEntry.TypeName, serverWellKnownEntry.AssemblyName, serverWellKnownEntry.ObjectURI, serverWellKnownEntry.ObjectMode)
					{
						ContextAttributes = null
					});
				}
			}

			// Token: 0x06007089 RID: 28809 RVA: 0x00183A7C File Offset: 0x00181C7C
			private static IContextAttribute[] CreateContextAttributesFromConfigEntries(ArrayList contextAttributes)
			{
				int count = contextAttributes.Count;
				if (count == 0)
				{
					return null;
				}
				IContextAttribute[] array = new IContextAttribute[count];
				int num = 0;
				foreach (object obj in contextAttributes)
				{
					RemotingXmlConfigFileData.ContextAttributeEntry contextAttributeEntry = (RemotingXmlConfigFileData.ContextAttributeEntry)obj;
					Assembly assembly = Assembly.Load(contextAttributeEntry.AssemblyName);
					Hashtable properties = contextAttributeEntry.Properties;
					IContextAttribute contextAttribute;
					if (properties != null && properties.Count > 0)
					{
						object[] args = new object[]
						{
							properties
						};
						contextAttribute = (IContextAttribute)Activator.CreateInstance(assembly.GetType(contextAttributeEntry.TypeName, false, false), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance, null, args, null, null);
					}
					else
					{
						contextAttribute = (IContextAttribute)Activator.CreateInstance(assembly.GetType(contextAttributeEntry.TypeName, false, false), true);
					}
					array[num++] = contextAttribute;
				}
				return array;
			}

			// Token: 0x0600708A RID: 28810 RVA: 0x00183B70 File Offset: 0x00181D70
			internal bool ActivationAllowed(string typeName, string assemblyName)
			{
				return this._exportableClasses.ContainsKey(this.EncodeTypeAndAssemblyNames(typeName, assemblyName));
			}

			// Token: 0x0600708B RID: 28811 RVA: 0x00183B88 File Offset: 0x00181D88
			internal ActivatedClientTypeEntry QueryRemoteActivate(string typeName, string assemblyName)
			{
				string key = this.EncodeTypeAndAssemblyNames(typeName, assemblyName);
				ActivatedClientTypeEntry activatedClientTypeEntry = this._remoteTypeInfo[key] as ActivatedClientTypeEntry;
				if (activatedClientTypeEntry == null)
				{
					return null;
				}
				if (activatedClientTypeEntry.GetRemoteAppEntry() == null)
				{
					RemoteAppEntry remoteAppEntry = (RemoteAppEntry)this._remoteAppInfo[activatedClientTypeEntry.ApplicationUrl];
					if (remoteAppEntry == null)
					{
						throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Activation_MissingRemoteAppEntry"), activatedClientTypeEntry.ApplicationUrl));
					}
					activatedClientTypeEntry.CacheRemoteAppEntry(remoteAppEntry);
				}
				return activatedClientTypeEntry;
			}

			// Token: 0x0600708C RID: 28812 RVA: 0x00183C00 File Offset: 0x00181E00
			internal WellKnownClientTypeEntry QueryConnect(string typeName, string assemblyName)
			{
				string key = this.EncodeTypeAndAssemblyNames(typeName, assemblyName);
				WellKnownClientTypeEntry wellKnownClientTypeEntry = this._remoteTypeInfo[key] as WellKnownClientTypeEntry;
				if (wellKnownClientTypeEntry == null)
				{
					return null;
				}
				return wellKnownClientTypeEntry;
			}

			// Token: 0x0600708D RID: 28813 RVA: 0x00183C30 File Offset: 0x00181E30
			internal ActivatedServiceTypeEntry[] GetRegisteredActivatedServiceTypes()
			{
				ActivatedServiceTypeEntry[] array = new ActivatedServiceTypeEntry[this._exportableClasses.Count];
				int num = 0;
				foreach (object obj in this._exportableClasses)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					array[num++] = (ActivatedServiceTypeEntry)dictionaryEntry.Value;
				}
				return array;
			}

			// Token: 0x0600708E RID: 28814 RVA: 0x00183CAC File Offset: 0x00181EAC
			internal WellKnownServiceTypeEntry[] GetRegisteredWellKnownServiceTypes()
			{
				WellKnownServiceTypeEntry[] array = new WellKnownServiceTypeEntry[this._wellKnownExportInfo.Count];
				int num = 0;
				foreach (object obj in this._wellKnownExportInfo)
				{
					WellKnownServiceTypeEntry wellKnownServiceTypeEntry = (WellKnownServiceTypeEntry)((DictionaryEntry)obj).Value;
					WellKnownServiceTypeEntry wellKnownServiceTypeEntry2 = new WellKnownServiceTypeEntry(wellKnownServiceTypeEntry.TypeName, wellKnownServiceTypeEntry.AssemblyName, wellKnownServiceTypeEntry.ObjectUri, wellKnownServiceTypeEntry.Mode);
					wellKnownServiceTypeEntry2.ContextAttributes = wellKnownServiceTypeEntry.ContextAttributes;
					array[num++] = wellKnownServiceTypeEntry2;
				}
				return array;
			}

			// Token: 0x0600708F RID: 28815 RVA: 0x00183D60 File Offset: 0x00181F60
			internal ActivatedClientTypeEntry[] GetRegisteredActivatedClientTypes()
			{
				int num = 0;
				foreach (object obj in this._remoteTypeInfo)
				{
					ActivatedClientTypeEntry activatedClientTypeEntry = ((DictionaryEntry)obj).Value as ActivatedClientTypeEntry;
					if (activatedClientTypeEntry != null)
					{
						num++;
					}
				}
				ActivatedClientTypeEntry[] array = new ActivatedClientTypeEntry[num];
				int num2 = 0;
				foreach (object obj2 in this._remoteTypeInfo)
				{
					ActivatedClientTypeEntry activatedClientTypeEntry2 = ((DictionaryEntry)obj2).Value as ActivatedClientTypeEntry;
					if (activatedClientTypeEntry2 != null)
					{
						string appUrl = null;
						RemoteAppEntry remoteAppEntry = activatedClientTypeEntry2.GetRemoteAppEntry();
						if (remoteAppEntry != null)
						{
							appUrl = remoteAppEntry.GetAppURI();
						}
						ActivatedClientTypeEntry activatedClientTypeEntry3 = new ActivatedClientTypeEntry(activatedClientTypeEntry2.TypeName, activatedClientTypeEntry2.AssemblyName, appUrl);
						activatedClientTypeEntry3.ContextAttributes = activatedClientTypeEntry2.ContextAttributes;
						array[num2++] = activatedClientTypeEntry3;
					}
				}
				return array;
			}

			// Token: 0x06007090 RID: 28816 RVA: 0x00183E7C File Offset: 0x0018207C
			internal WellKnownClientTypeEntry[] GetRegisteredWellKnownClientTypes()
			{
				int num = 0;
				foreach (object obj in this._remoteTypeInfo)
				{
					WellKnownClientTypeEntry wellKnownClientTypeEntry = ((DictionaryEntry)obj).Value as WellKnownClientTypeEntry;
					if (wellKnownClientTypeEntry != null)
					{
						num++;
					}
				}
				WellKnownClientTypeEntry[] array = new WellKnownClientTypeEntry[num];
				int num2 = 0;
				foreach (object obj2 in this._remoteTypeInfo)
				{
					WellKnownClientTypeEntry wellKnownClientTypeEntry2 = ((DictionaryEntry)obj2).Value as WellKnownClientTypeEntry;
					if (wellKnownClientTypeEntry2 != null)
					{
						WellKnownClientTypeEntry wellKnownClientTypeEntry3 = new WellKnownClientTypeEntry(wellKnownClientTypeEntry2.TypeName, wellKnownClientTypeEntry2.AssemblyName, wellKnownClientTypeEntry2.ObjectUrl);
						RemoteAppEntry remoteAppEntry = wellKnownClientTypeEntry2.GetRemoteAppEntry();
						if (remoteAppEntry != null)
						{
							wellKnownClientTypeEntry3.ApplicationUrl = remoteAppEntry.GetAppURI();
						}
						array[num2++] = wellKnownClientTypeEntry3;
					}
				}
				return array;
			}

			// Token: 0x06007091 RID: 28817 RVA: 0x00183F90 File Offset: 0x00182190
			internal void AddActivatedType(string typeName, string assemblyName, IContextAttribute[] contextAttributes)
			{
				if (typeName == null)
				{
					throw new ArgumentNullException("typeName");
				}
				if (assemblyName == null)
				{
					throw new ArgumentNullException("assemblyName");
				}
				if (this.CheckForRedirectedClientType(typeName, assemblyName))
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_CantUseRedirectedTypeForWellKnownService"), typeName, assemblyName));
				}
				ActivatedServiceTypeEntry activatedServiceTypeEntry = new ActivatedServiceTypeEntry(typeName, assemblyName);
				activatedServiceTypeEntry.ContextAttributes = contextAttributes;
				string key = this.EncodeTypeAndAssemblyNames(typeName, assemblyName);
				this._exportableClasses.Add(key, activatedServiceTypeEntry);
			}

			// Token: 0x06007092 RID: 28818 RVA: 0x00184004 File Offset: 0x00182204
			private bool CheckForServiceEntryWithType(string typeName, string asmName)
			{
				return this.CheckForWellKnownServiceEntryWithType(typeName, asmName) || this.ActivationAllowed(typeName, asmName);
			}

			// Token: 0x06007093 RID: 28819 RVA: 0x0018401C File Offset: 0x0018221C
			private bool CheckForWellKnownServiceEntryWithType(string typeName, string asmName)
			{
				foreach (object obj in this._wellKnownExportInfo)
				{
					WellKnownServiceTypeEntry wellKnownServiceTypeEntry = (WellKnownServiceTypeEntry)((DictionaryEntry)obj).Value;
					if (typeName == wellKnownServiceTypeEntry.TypeName)
					{
						bool flag = false;
						if (asmName == wellKnownServiceTypeEntry.AssemblyName)
						{
							flag = true;
						}
						else if (string.Compare(wellKnownServiceTypeEntry.AssemblyName, 0, asmName, 0, asmName.Length, StringComparison.OrdinalIgnoreCase) == 0 && wellKnownServiceTypeEntry.AssemblyName[asmName.Length] == ',')
						{
							flag = true;
						}
						if (flag)
						{
							return true;
						}
					}
				}
				return false;
			}

			// Token: 0x06007094 RID: 28820 RVA: 0x001840DC File Offset: 0x001822DC
			private bool CheckForRedirectedClientType(string typeName, string asmName)
			{
				int num = asmName.IndexOf(",");
				if (num != -1)
				{
					asmName = asmName.Substring(0, num);
				}
				return this.QueryRemoteActivate(typeName, asmName) != null || this.QueryConnect(typeName, asmName) != null;
			}

			// Token: 0x06007095 RID: 28821 RVA: 0x0018411C File Offset: 0x0018231C
			internal void AddActivatedClientType(ActivatedClientTypeEntry entry)
			{
				if (this.CheckForRedirectedClientType(entry.TypeName, entry.AssemblyName))
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_TypeAlreadyRedirected"), entry.TypeName, entry.AssemblyName));
				}
				if (this.CheckForServiceEntryWithType(entry.TypeName, entry.AssemblyName))
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_CantRedirectActivationOfWellKnownService"), entry.TypeName, entry.AssemblyName));
				}
				string applicationUrl = entry.ApplicationUrl;
				RemoteAppEntry remoteAppEntry = (RemoteAppEntry)this._remoteAppInfo[applicationUrl];
				if (remoteAppEntry == null)
				{
					remoteAppEntry = new RemoteAppEntry(applicationUrl, applicationUrl);
					this._remoteAppInfo.Add(applicationUrl, remoteAppEntry);
				}
				if (remoteAppEntry != null)
				{
					entry.CacheRemoteAppEntry(remoteAppEntry);
				}
				string key = this.EncodeTypeAndAssemblyNames(entry.TypeName, entry.AssemblyName);
				this._remoteTypeInfo.Add(key, entry);
			}

			// Token: 0x06007096 RID: 28822 RVA: 0x001841F8 File Offset: 0x001823F8
			internal void AddWellKnownClientType(WellKnownClientTypeEntry entry)
			{
				if (this.CheckForRedirectedClientType(entry.TypeName, entry.AssemblyName))
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_TypeAlreadyRedirected"), entry.TypeName, entry.AssemblyName));
				}
				if (this.CheckForServiceEntryWithType(entry.TypeName, entry.AssemblyName))
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_CantRedirectActivationOfWellKnownService"), entry.TypeName, entry.AssemblyName));
				}
				string applicationUrl = entry.ApplicationUrl;
				RemoteAppEntry remoteAppEntry = null;
				if (applicationUrl != null)
				{
					remoteAppEntry = (RemoteAppEntry)this._remoteAppInfo[applicationUrl];
					if (remoteAppEntry == null)
					{
						remoteAppEntry = new RemoteAppEntry(applicationUrl, applicationUrl);
						this._remoteAppInfo.Add(applicationUrl, remoteAppEntry);
					}
				}
				if (remoteAppEntry != null)
				{
					entry.CacheRemoteAppEntry(remoteAppEntry);
				}
				string key = this.EncodeTypeAndAssemblyNames(entry.TypeName, entry.AssemblyName);
				this._remoteTypeInfo.Add(key, entry);
			}

			// Token: 0x06007097 RID: 28823 RVA: 0x001842D9 File Offset: 0x001824D9
			[SecurityCritical]
			internal void AddWellKnownEntry(WellKnownServiceTypeEntry entry)
			{
				this.AddWellKnownEntry(entry, true);
			}

			// Token: 0x06007098 RID: 28824 RVA: 0x001842E4 File Offset: 0x001824E4
			[SecurityCritical]
			internal void AddWellKnownEntry(WellKnownServiceTypeEntry entry, bool fReplace)
			{
				if (this.CheckForRedirectedClientType(entry.TypeName, entry.AssemblyName))
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Config_CantUseRedirectedTypeForWellKnownService"), entry.TypeName, entry.AssemblyName));
				}
				string key = entry.ObjectUri.ToLower(CultureInfo.InvariantCulture);
				if (fReplace)
				{
					this._wellKnownExportInfo[key] = entry;
					IdentityHolder.RemoveIdentity(entry.ObjectUri);
					return;
				}
				this._wellKnownExportInfo.Add(key, entry);
			}

			// Token: 0x06007099 RID: 28825 RVA: 0x00184368 File Offset: 0x00182568
			[SecurityCritical]
			internal Type GetServerTypeForUri(string URI)
			{
				Type result = null;
				string key = URI.ToLower(CultureInfo.InvariantCulture);
				WellKnownServiceTypeEntry wellKnownServiceTypeEntry = (WellKnownServiceTypeEntry)this._wellKnownExportInfo[key];
				if (wellKnownServiceTypeEntry != null)
				{
					result = RemotingConfigHandler.RemotingConfigInfo.LoadType(wellKnownServiceTypeEntry.TypeName, wellKnownServiceTypeEntry.AssemblyName);
				}
				return result;
			}

			// Token: 0x0600709A RID: 28826 RVA: 0x001843AC File Offset: 0x001825AC
			[SecurityCritical]
			internal ServerIdentity StartupWellKnownObject(string URI)
			{
				string key = URI.ToLower(CultureInfo.InvariantCulture);
				ServerIdentity result = null;
				WellKnownServiceTypeEntry wellKnownServiceTypeEntry = (WellKnownServiceTypeEntry)this._wellKnownExportInfo[key];
				if (wellKnownServiceTypeEntry != null)
				{
					result = this.StartupWellKnownObject(wellKnownServiceTypeEntry.AssemblyName, wellKnownServiceTypeEntry.TypeName, wellKnownServiceTypeEntry.ObjectUri, wellKnownServiceTypeEntry.Mode);
				}
				return result;
			}

			// Token: 0x0600709B RID: 28827 RVA: 0x001843FC File Offset: 0x001825FC
			[SecurityCritical]
			internal ServerIdentity StartupWellKnownObject(string asmName, string svrTypeName, string URI, WellKnownObjectMode mode)
			{
				return this.StartupWellKnownObject(asmName, svrTypeName, URI, mode, false);
			}

			// Token: 0x0600709C RID: 28828 RVA: 0x0018440C File Offset: 0x0018260C
			[SecurityCritical]
			internal ServerIdentity StartupWellKnownObject(string asmName, string svrTypeName, string URI, WellKnownObjectMode mode, bool fReplace)
			{
				object obj = RemotingConfigHandler.RemotingConfigInfo.s_wkoStartLock;
				ServerIdentity result;
				lock (obj)
				{
					ServerIdentity serverIdentity = null;
					Type type = RemotingConfigHandler.RemotingConfigInfo.LoadType(svrTypeName, asmName);
					if (!type.IsMarshalByRef)
					{
						throw new RemotingException(Environment.GetResourceString("Remoting_WellKnown_MustBeMBR", new object[]
						{
							svrTypeName
						}));
					}
					serverIdentity = (ServerIdentity)IdentityHolder.ResolveIdentity(URI);
					if (serverIdentity != null && serverIdentity.IsRemoteDisconnected())
					{
						IdentityHolder.RemoveIdentity(URI);
						serverIdentity = null;
					}
					if (serverIdentity == null)
					{
						RemotingConfigHandler.RemotingConfigInfo.s_fullTrust.Assert();
						try
						{
							MarshalByRefObject marshalByRefObject = (MarshalByRefObject)Activator.CreateInstance(type, true);
							if (RemotingServices.IsClientProxy(marshalByRefObject))
							{
								RemotingServices.MarshalInternal(new RedirectionProxy(marshalByRefObject, type)
								{
									ObjectMode = mode
								}, URI, type, true, true);
								serverIdentity = (ServerIdentity)IdentityHolder.ResolveIdentity(URI);
								serverIdentity.SetSingletonObjectMode();
							}
							else if (type.IsCOMObject && mode == WellKnownObjectMode.Singleton)
							{
								ComRedirectionProxy obj2 = new ComRedirectionProxy(marshalByRefObject, type);
								RemotingServices.MarshalInternal(obj2, URI, type, true, true);
								serverIdentity = (ServerIdentity)IdentityHolder.ResolveIdentity(URI);
								serverIdentity.SetSingletonObjectMode();
							}
							else
							{
								string objectUri = RemotingServices.GetObjectUri(marshalByRefObject);
								if (objectUri != null)
								{
									throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_WellKnown_CtorCantMarshal"), URI));
								}
								RemotingServices.MarshalInternal(marshalByRefObject, URI, type, true, true);
								serverIdentity = (ServerIdentity)IdentityHolder.ResolveIdentity(URI);
								if (mode == WellKnownObjectMode.SingleCall)
								{
									serverIdentity.SetSingleCallObjectMode();
								}
								else
								{
									serverIdentity.SetSingletonObjectMode();
								}
							}
						}
						catch
						{
							throw;
						}
						finally
						{
							if (serverIdentity != null)
							{
								serverIdentity.IsInitializing = false;
							}
							CodeAccessPermission.RevertAssert();
						}
					}
					result = serverIdentity;
				}
				return result;
			}

			// Token: 0x0600709D RID: 28829 RVA: 0x001845D4 File Offset: 0x001827D4
			[SecurityCritical]
			internal static Type LoadType(string typeName, string assemblyName)
			{
				Assembly assembly = null;
				new FileIOPermission(PermissionState.Unrestricted).Assert();
				try
				{
					assembly = Assembly.Load(assemblyName);
				}
				finally
				{
					CodeAccessPermission.RevertAssert();
				}
				if (assembly == null)
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_AssemblyLoadFailed", new object[]
					{
						assemblyName
					}));
				}
				Type type = assembly.GetType(typeName, false, false);
				if (type == null)
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_BadType", new object[]
					{
						typeName + ", " + assemblyName
					}));
				}
				return type;
			}

			// Token: 0x040037CD RID: 14285
			private Hashtable _exportableClasses;

			// Token: 0x040037CE RID: 14286
			private Hashtable _remoteTypeInfo;

			// Token: 0x040037CF RID: 14287
			private Hashtable _remoteAppInfo;

			// Token: 0x040037D0 RID: 14288
			private Hashtable _wellKnownExportInfo;

			// Token: 0x040037D1 RID: 14289
			private static char[] SepSpace = new char[]
			{
				' '
			};

			// Token: 0x040037D2 RID: 14290
			private static char[] SepPound = new char[]
			{
				'#'
			};

			// Token: 0x040037D3 RID: 14291
			private static char[] SepSemiColon = new char[]
			{
				';'
			};

			// Token: 0x040037D4 RID: 14292
			private static char[] SepEquals = new char[]
			{
				'='
			};

			// Token: 0x040037D5 RID: 14293
			private static object s_wkoStartLock = new object();

			// Token: 0x040037D6 RID: 14294
			private static PermissionSet s_fullTrust = new PermissionSet(PermissionState.Unrestricted);
		}
	}
}
