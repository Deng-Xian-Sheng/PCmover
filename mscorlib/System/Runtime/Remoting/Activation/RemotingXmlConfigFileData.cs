using System;
using System.Collections;
using System.Reflection;

namespace System.Runtime.Remoting.Activation
{
	// Token: 0x0200089C RID: 2204
	internal class RemotingXmlConfigFileData
	{
		// Token: 0x06005D2D RID: 23853 RVA: 0x00146A50 File Offset: 0x00144C50
		internal void AddInteropXmlElementEntry(string xmlElementName, string xmlElementNamespace, string urtTypeName, string urtAssemblyName)
		{
			this.TryToLoadTypeIfApplicable(urtTypeName, urtAssemblyName);
			RemotingXmlConfigFileData.InteropXmlElementEntry value = new RemotingXmlConfigFileData.InteropXmlElementEntry(xmlElementName, xmlElementNamespace, urtTypeName, urtAssemblyName);
			this.InteropXmlElementEntries.Add(value);
		}

		// Token: 0x06005D2E RID: 23854 RVA: 0x00146A80 File Offset: 0x00144C80
		internal void AddInteropXmlTypeEntry(string xmlTypeName, string xmlTypeNamespace, string urtTypeName, string urtAssemblyName)
		{
			this.TryToLoadTypeIfApplicable(urtTypeName, urtAssemblyName);
			RemotingXmlConfigFileData.InteropXmlTypeEntry value = new RemotingXmlConfigFileData.InteropXmlTypeEntry(xmlTypeName, xmlTypeNamespace, urtTypeName, urtAssemblyName);
			this.InteropXmlTypeEntries.Add(value);
		}

		// Token: 0x06005D2F RID: 23855 RVA: 0x00146AB0 File Offset: 0x00144CB0
		internal void AddPreLoadEntry(string typeName, string assemblyName)
		{
			this.TryToLoadTypeIfApplicable(typeName, assemblyName);
			RemotingXmlConfigFileData.PreLoadEntry value = new RemotingXmlConfigFileData.PreLoadEntry(typeName, assemblyName);
			this.PreLoadEntries.Add(value);
		}

		// Token: 0x06005D30 RID: 23856 RVA: 0x00146ADC File Offset: 0x00144CDC
		internal RemotingXmlConfigFileData.RemoteAppEntry AddRemoteAppEntry(string appUri)
		{
			RemotingXmlConfigFileData.RemoteAppEntry remoteAppEntry = new RemotingXmlConfigFileData.RemoteAppEntry(appUri);
			this.RemoteAppEntries.Add(remoteAppEntry);
			return remoteAppEntry;
		}

		// Token: 0x06005D31 RID: 23857 RVA: 0x00146B00 File Offset: 0x00144D00
		internal void AddServerActivatedEntry(string typeName, string assemName, ArrayList contextAttributes)
		{
			this.TryToLoadTypeIfApplicable(typeName, assemName);
			RemotingXmlConfigFileData.TypeEntry value = new RemotingXmlConfigFileData.TypeEntry(typeName, assemName, contextAttributes);
			this.ServerActivatedEntries.Add(value);
		}

		// Token: 0x06005D32 RID: 23858 RVA: 0x00146B2C File Offset: 0x00144D2C
		internal RemotingXmlConfigFileData.ServerWellKnownEntry AddServerWellKnownEntry(string typeName, string assemName, ArrayList contextAttributes, string objURI, WellKnownObjectMode objMode)
		{
			this.TryToLoadTypeIfApplicable(typeName, assemName);
			RemotingXmlConfigFileData.ServerWellKnownEntry serverWellKnownEntry = new RemotingXmlConfigFileData.ServerWellKnownEntry(typeName, assemName, contextAttributes, objURI, objMode);
			this.ServerWellKnownEntries.Add(serverWellKnownEntry);
			return serverWellKnownEntry;
		}

		// Token: 0x06005D33 RID: 23859 RVA: 0x00146B5C File Offset: 0x00144D5C
		private void TryToLoadTypeIfApplicable(string typeName, string assemblyName)
		{
			if (!RemotingXmlConfigFileData.LoadTypes)
			{
				return;
			}
			Assembly assembly = Assembly.Load(assemblyName);
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
					typeName
				}));
			}
		}

		// Token: 0x040029F4 RID: 10740
		internal static volatile bool LoadTypes;

		// Token: 0x040029F5 RID: 10741
		internal string ApplicationName;

		// Token: 0x040029F6 RID: 10742
		internal RemotingXmlConfigFileData.LifetimeEntry Lifetime;

		// Token: 0x040029F7 RID: 10743
		internal bool UrlObjRefMode = RemotingConfigHandler.UrlObjRefMode;

		// Token: 0x040029F8 RID: 10744
		internal RemotingXmlConfigFileData.CustomErrorsEntry CustomErrors;

		// Token: 0x040029F9 RID: 10745
		internal ArrayList ChannelEntries = new ArrayList();

		// Token: 0x040029FA RID: 10746
		internal ArrayList InteropXmlElementEntries = new ArrayList();

		// Token: 0x040029FB RID: 10747
		internal ArrayList InteropXmlTypeEntries = new ArrayList();

		// Token: 0x040029FC RID: 10748
		internal ArrayList PreLoadEntries = new ArrayList();

		// Token: 0x040029FD RID: 10749
		internal ArrayList RemoteAppEntries = new ArrayList();

		// Token: 0x040029FE RID: 10750
		internal ArrayList ServerActivatedEntries = new ArrayList();

		// Token: 0x040029FF RID: 10751
		internal ArrayList ServerWellKnownEntries = new ArrayList();

		// Token: 0x02000C7C RID: 3196
		internal class ChannelEntry
		{
			// Token: 0x060070C6 RID: 28870 RVA: 0x00184BF2 File Offset: 0x00182DF2
			internal ChannelEntry(string typeName, string assemblyName, Hashtable properties)
			{
				this.TypeName = typeName;
				this.AssemblyName = assemblyName;
				this.Properties = properties;
			}

			// Token: 0x04003808 RID: 14344
			internal string TypeName;

			// Token: 0x04003809 RID: 14345
			internal string AssemblyName;

			// Token: 0x0400380A RID: 14346
			internal Hashtable Properties;

			// Token: 0x0400380B RID: 14347
			internal bool DelayLoad;

			// Token: 0x0400380C RID: 14348
			internal ArrayList ClientSinkProviders = new ArrayList();

			// Token: 0x0400380D RID: 14349
			internal ArrayList ServerSinkProviders = new ArrayList();
		}

		// Token: 0x02000C7D RID: 3197
		internal class ClientWellKnownEntry
		{
			// Token: 0x060070C7 RID: 28871 RVA: 0x00184C25 File Offset: 0x00182E25
			internal ClientWellKnownEntry(string typeName, string assemName, string url)
			{
				this.TypeName = typeName;
				this.AssemblyName = assemName;
				this.Url = url;
			}

			// Token: 0x0400380E RID: 14350
			internal string TypeName;

			// Token: 0x0400380F RID: 14351
			internal string AssemblyName;

			// Token: 0x04003810 RID: 14352
			internal string Url;
		}

		// Token: 0x02000C7E RID: 3198
		internal class ContextAttributeEntry
		{
			// Token: 0x060070C8 RID: 28872 RVA: 0x00184C42 File Offset: 0x00182E42
			internal ContextAttributeEntry(string typeName, string assemName, Hashtable properties)
			{
				this.TypeName = typeName;
				this.AssemblyName = assemName;
				this.Properties = properties;
			}

			// Token: 0x04003811 RID: 14353
			internal string TypeName;

			// Token: 0x04003812 RID: 14354
			internal string AssemblyName;

			// Token: 0x04003813 RID: 14355
			internal Hashtable Properties;
		}

		// Token: 0x02000C7F RID: 3199
		internal class InteropXmlElementEntry
		{
			// Token: 0x060070C9 RID: 28873 RVA: 0x00184C5F File Offset: 0x00182E5F
			internal InteropXmlElementEntry(string xmlElementName, string xmlElementNamespace, string urtTypeName, string urtAssemblyName)
			{
				this.XmlElementName = xmlElementName;
				this.XmlElementNamespace = xmlElementNamespace;
				this.UrtTypeName = urtTypeName;
				this.UrtAssemblyName = urtAssemblyName;
			}

			// Token: 0x04003814 RID: 14356
			internal string XmlElementName;

			// Token: 0x04003815 RID: 14357
			internal string XmlElementNamespace;

			// Token: 0x04003816 RID: 14358
			internal string UrtTypeName;

			// Token: 0x04003817 RID: 14359
			internal string UrtAssemblyName;
		}

		// Token: 0x02000C80 RID: 3200
		internal class CustomErrorsEntry
		{
			// Token: 0x060070CA RID: 28874 RVA: 0x00184C84 File Offset: 0x00182E84
			internal CustomErrorsEntry(CustomErrorsModes mode)
			{
				this.Mode = mode;
			}

			// Token: 0x04003818 RID: 14360
			internal CustomErrorsModes Mode;
		}

		// Token: 0x02000C81 RID: 3201
		internal class InteropXmlTypeEntry
		{
			// Token: 0x060070CB RID: 28875 RVA: 0x00184C93 File Offset: 0x00182E93
			internal InteropXmlTypeEntry(string xmlTypeName, string xmlTypeNamespace, string urtTypeName, string urtAssemblyName)
			{
				this.XmlTypeName = xmlTypeName;
				this.XmlTypeNamespace = xmlTypeNamespace;
				this.UrtTypeName = urtTypeName;
				this.UrtAssemblyName = urtAssemblyName;
			}

			// Token: 0x04003819 RID: 14361
			internal string XmlTypeName;

			// Token: 0x0400381A RID: 14362
			internal string XmlTypeNamespace;

			// Token: 0x0400381B RID: 14363
			internal string UrtTypeName;

			// Token: 0x0400381C RID: 14364
			internal string UrtAssemblyName;
		}

		// Token: 0x02000C82 RID: 3202
		internal class LifetimeEntry
		{
			// Token: 0x1700135C RID: 4956
			// (get) Token: 0x060070CC RID: 28876 RVA: 0x00184CB8 File Offset: 0x00182EB8
			// (set) Token: 0x060070CD RID: 28877 RVA: 0x00184CC0 File Offset: 0x00182EC0
			internal TimeSpan LeaseTime
			{
				get
				{
					return this._leaseTime;
				}
				set
				{
					this._leaseTime = value;
					this.IsLeaseTimeSet = true;
				}
			}

			// Token: 0x1700135D RID: 4957
			// (get) Token: 0x060070CE RID: 28878 RVA: 0x00184CD0 File Offset: 0x00182ED0
			// (set) Token: 0x060070CF RID: 28879 RVA: 0x00184CD8 File Offset: 0x00182ED8
			internal TimeSpan RenewOnCallTime
			{
				get
				{
					return this._renewOnCallTime;
				}
				set
				{
					this._renewOnCallTime = value;
					this.IsRenewOnCallTimeSet = true;
				}
			}

			// Token: 0x1700135E RID: 4958
			// (get) Token: 0x060070D0 RID: 28880 RVA: 0x00184CE8 File Offset: 0x00182EE8
			// (set) Token: 0x060070D1 RID: 28881 RVA: 0x00184CF0 File Offset: 0x00182EF0
			internal TimeSpan SponsorshipTimeout
			{
				get
				{
					return this._sponsorshipTimeout;
				}
				set
				{
					this._sponsorshipTimeout = value;
					this.IsSponsorshipTimeoutSet = true;
				}
			}

			// Token: 0x1700135F RID: 4959
			// (get) Token: 0x060070D2 RID: 28882 RVA: 0x00184D00 File Offset: 0x00182F00
			// (set) Token: 0x060070D3 RID: 28883 RVA: 0x00184D08 File Offset: 0x00182F08
			internal TimeSpan LeaseManagerPollTime
			{
				get
				{
					return this._leaseManagerPollTime;
				}
				set
				{
					this._leaseManagerPollTime = value;
					this.IsLeaseManagerPollTimeSet = true;
				}
			}

			// Token: 0x0400381D RID: 14365
			internal bool IsLeaseTimeSet;

			// Token: 0x0400381E RID: 14366
			internal bool IsRenewOnCallTimeSet;

			// Token: 0x0400381F RID: 14367
			internal bool IsSponsorshipTimeoutSet;

			// Token: 0x04003820 RID: 14368
			internal bool IsLeaseManagerPollTimeSet;

			// Token: 0x04003821 RID: 14369
			private TimeSpan _leaseTime;

			// Token: 0x04003822 RID: 14370
			private TimeSpan _renewOnCallTime;

			// Token: 0x04003823 RID: 14371
			private TimeSpan _sponsorshipTimeout;

			// Token: 0x04003824 RID: 14372
			private TimeSpan _leaseManagerPollTime;
		}

		// Token: 0x02000C83 RID: 3203
		internal class PreLoadEntry
		{
			// Token: 0x060070D5 RID: 28885 RVA: 0x00184D20 File Offset: 0x00182F20
			public PreLoadEntry(string typeName, string assemblyName)
			{
				this.TypeName = typeName;
				this.AssemblyName = assemblyName;
			}

			// Token: 0x04003825 RID: 14373
			internal string TypeName;

			// Token: 0x04003826 RID: 14374
			internal string AssemblyName;
		}

		// Token: 0x02000C84 RID: 3204
		internal class RemoteAppEntry
		{
			// Token: 0x060070D6 RID: 28886 RVA: 0x00184D36 File Offset: 0x00182F36
			internal RemoteAppEntry(string appUri)
			{
				this.AppUri = appUri;
			}

			// Token: 0x060070D7 RID: 28887 RVA: 0x00184D5C File Offset: 0x00182F5C
			internal void AddWellKnownEntry(string typeName, string assemName, string url)
			{
				RemotingXmlConfigFileData.ClientWellKnownEntry value = new RemotingXmlConfigFileData.ClientWellKnownEntry(typeName, assemName, url);
				this.WellKnownObjects.Add(value);
			}

			// Token: 0x060070D8 RID: 28888 RVA: 0x00184D80 File Offset: 0x00182F80
			internal void AddActivatedEntry(string typeName, string assemName, ArrayList contextAttributes)
			{
				RemotingXmlConfigFileData.TypeEntry value = new RemotingXmlConfigFileData.TypeEntry(typeName, assemName, contextAttributes);
				this.ActivatedObjects.Add(value);
			}

			// Token: 0x04003827 RID: 14375
			internal string AppUri;

			// Token: 0x04003828 RID: 14376
			internal ArrayList WellKnownObjects = new ArrayList();

			// Token: 0x04003829 RID: 14377
			internal ArrayList ActivatedObjects = new ArrayList();
		}

		// Token: 0x02000C85 RID: 3205
		internal class ServerWellKnownEntry : RemotingXmlConfigFileData.TypeEntry
		{
			// Token: 0x060070D9 RID: 28889 RVA: 0x00184DA3 File Offset: 0x00182FA3
			internal ServerWellKnownEntry(string typeName, string assemName, ArrayList contextAttributes, string objURI, WellKnownObjectMode objMode) : base(typeName, assemName, contextAttributes)
			{
				this.ObjectURI = objURI;
				this.ObjectMode = objMode;
			}

			// Token: 0x0400382A RID: 14378
			internal string ObjectURI;

			// Token: 0x0400382B RID: 14379
			internal WellKnownObjectMode ObjectMode;
		}

		// Token: 0x02000C86 RID: 3206
		internal class SinkProviderEntry
		{
			// Token: 0x060070DA RID: 28890 RVA: 0x00184DBE File Offset: 0x00182FBE
			internal SinkProviderEntry(string typeName, string assemName, Hashtable properties, bool isFormatter)
			{
				this.TypeName = typeName;
				this.AssemblyName = assemName;
				this.Properties = properties;
				this.IsFormatter = isFormatter;
			}

			// Token: 0x0400382C RID: 14380
			internal string TypeName;

			// Token: 0x0400382D RID: 14381
			internal string AssemblyName;

			// Token: 0x0400382E RID: 14382
			internal Hashtable Properties;

			// Token: 0x0400382F RID: 14383
			internal ArrayList ProviderData = new ArrayList();

			// Token: 0x04003830 RID: 14384
			internal bool IsFormatter;
		}

		// Token: 0x02000C87 RID: 3207
		internal class TypeEntry
		{
			// Token: 0x060070DB RID: 28891 RVA: 0x00184DEE File Offset: 0x00182FEE
			internal TypeEntry(string typeName, string assemName, ArrayList contextAttributes)
			{
				this.TypeName = typeName;
				this.AssemblyName = assemName;
				this.ContextAttributes = contextAttributes;
			}

			// Token: 0x04003831 RID: 14385
			internal string TypeName;

			// Token: 0x04003832 RID: 14386
			internal string AssemblyName;

			// Token: 0x04003833 RID: 14387
			internal ArrayList ContextAttributes;
		}
	}
}
