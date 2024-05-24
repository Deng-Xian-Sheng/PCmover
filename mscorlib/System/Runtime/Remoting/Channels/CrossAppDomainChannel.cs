using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x02000835 RID: 2101
	[Serializable]
	internal class CrossAppDomainChannel : IChannel, IChannelSender, IChannelReceiver
	{
		// Token: 0x17000EE3 RID: 3811
		// (get) Token: 0x060059CC RID: 22988 RVA: 0x0013CAF1 File Offset: 0x0013ACF1
		// (set) Token: 0x060059CD RID: 22989 RVA: 0x0013CB07 File Offset: 0x0013AD07
		private static CrossAppDomainChannel gAppDomainChannel
		{
			get
			{
				return Thread.GetDomain().RemotingData.ChannelServicesData.xadmessageSink;
			}
			set
			{
				Thread.GetDomain().RemotingData.ChannelServicesData.xadmessageSink = value;
			}
		}

		// Token: 0x17000EE4 RID: 3812
		// (get) Token: 0x060059CE RID: 22990 RVA: 0x0013CB20 File Offset: 0x0013AD20
		internal static CrossAppDomainChannel AppDomainChannel
		{
			get
			{
				if (CrossAppDomainChannel.gAppDomainChannel == null)
				{
					CrossAppDomainChannel gAppDomainChannel = new CrossAppDomainChannel();
					object obj = CrossAppDomainChannel.staticSyncObject;
					lock (obj)
					{
						if (CrossAppDomainChannel.gAppDomainChannel == null)
						{
							CrossAppDomainChannel.gAppDomainChannel = gAppDomainChannel;
						}
					}
				}
				return CrossAppDomainChannel.gAppDomainChannel;
			}
		}

		// Token: 0x060059CF RID: 22991 RVA: 0x0013CB78 File Offset: 0x0013AD78
		[SecurityCritical]
		internal static void RegisterChannel()
		{
			CrossAppDomainChannel appDomainChannel = CrossAppDomainChannel.AppDomainChannel;
			ChannelServices.RegisterChannelInternal(appDomainChannel, false);
		}

		// Token: 0x17000EE5 RID: 3813
		// (get) Token: 0x060059D0 RID: 22992 RVA: 0x0013CB92 File Offset: 0x0013AD92
		public virtual string ChannelName
		{
			[SecurityCritical]
			get
			{
				return "XAPPDMN";
			}
		}

		// Token: 0x17000EE6 RID: 3814
		// (get) Token: 0x060059D1 RID: 22993 RVA: 0x0013CB99 File Offset: 0x0013AD99
		public virtual string ChannelURI
		{
			get
			{
				return "XAPPDMN_URI";
			}
		}

		// Token: 0x17000EE7 RID: 3815
		// (get) Token: 0x060059D2 RID: 22994 RVA: 0x0013CBA0 File Offset: 0x0013ADA0
		public virtual int ChannelPriority
		{
			[SecurityCritical]
			get
			{
				return 100;
			}
		}

		// Token: 0x060059D3 RID: 22995 RVA: 0x0013CBA4 File Offset: 0x0013ADA4
		[SecurityCritical]
		public string Parse(string url, out string objectURI)
		{
			objectURI = url;
			return null;
		}

		// Token: 0x17000EE8 RID: 3816
		// (get) Token: 0x060059D4 RID: 22996 RVA: 0x0013CBAA File Offset: 0x0013ADAA
		public virtual object ChannelData
		{
			[SecurityCritical]
			get
			{
				return new CrossAppDomainData(Context.DefaultContext.InternalContextID, Thread.GetDomain().GetId(), Identity.ProcessGuid);
			}
		}

		// Token: 0x060059D5 RID: 22997 RVA: 0x0013CBCC File Offset: 0x0013ADCC
		[SecurityCritical]
		public virtual IMessageSink CreateMessageSink(string url, object data, out string objectURI)
		{
			objectURI = null;
			IMessageSink result = null;
			if (url != null && data == null)
			{
				if (url.StartsWith("XAPPDMN", StringComparison.Ordinal))
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_AppDomains_NYI"));
				}
			}
			else
			{
				CrossAppDomainData crossAppDomainData = data as CrossAppDomainData;
				if (crossAppDomainData != null && crossAppDomainData.ProcessGuid.Equals(Identity.ProcessGuid))
				{
					result = CrossAppDomainSink.FindOrCreateSink(crossAppDomainData);
				}
			}
			return result;
		}

		// Token: 0x060059D6 RID: 22998 RVA: 0x0013CC26 File Offset: 0x0013AE26
		[SecurityCritical]
		public virtual string[] GetUrlsForUri(string objectURI)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_Method"));
		}

		// Token: 0x060059D7 RID: 22999 RVA: 0x0013CC37 File Offset: 0x0013AE37
		[SecurityCritical]
		public virtual void StartListening(object data)
		{
		}

		// Token: 0x060059D8 RID: 23000 RVA: 0x0013CC39 File Offset: 0x0013AE39
		[SecurityCritical]
		public virtual void StopListening(object data)
		{
		}

		// Token: 0x040028DE RID: 10462
		private const string _channelName = "XAPPDMN";

		// Token: 0x040028DF RID: 10463
		private const string _channelURI = "XAPPDMN_URI";

		// Token: 0x040028E0 RID: 10464
		private static object staticSyncObject = new object();

		// Token: 0x040028E1 RID: 10465
		private static PermissionSet s_fullTrust = new PermissionSet(PermissionState.Unrestricted);
	}
}
