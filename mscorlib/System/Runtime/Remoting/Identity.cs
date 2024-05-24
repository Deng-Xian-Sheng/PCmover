using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Security.Cryptography;
using System.Threading;

namespace System.Runtime.Remoting
{
	// Token: 0x020007B0 RID: 1968
	internal class Identity
	{
		// Token: 0x17000E04 RID: 3588
		// (get) Token: 0x06005540 RID: 21824 RVA: 0x0012EF8C File Offset: 0x0012D18C
		internal static string ProcessIDGuid
		{
			get
			{
				return SharedStatics.Remoting_Identity_IDGuid;
			}
		}

		// Token: 0x17000E05 RID: 3589
		// (get) Token: 0x06005541 RID: 21825 RVA: 0x0012EF93 File Offset: 0x0012D193
		internal static string AppDomainUniqueId
		{
			get
			{
				if (Identity.s_configuredAppDomainGuid != null)
				{
					return Identity.s_configuredAppDomainGuid;
				}
				return Identity.s_originalAppDomainGuid;
			}
		}

		// Token: 0x17000E06 RID: 3590
		// (get) Token: 0x06005542 RID: 21826 RVA: 0x0012EFA7 File Offset: 0x0012D1A7
		internal static string IDGuidString
		{
			get
			{
				return Identity.s_IDGuidString;
			}
		}

		// Token: 0x06005543 RID: 21827 RVA: 0x0012EFB0 File Offset: 0x0012D1B0
		internal static string RemoveAppNameOrAppGuidIfNecessary(string uri)
		{
			if (uri == null || uri.Length <= 1 || uri[0] != '/')
			{
				return uri;
			}
			string text;
			if (Identity.s_configuredAppDomainGuidString != null)
			{
				text = Identity.s_configuredAppDomainGuidString;
				if (uri.Length > text.Length && Identity.StringStartsWith(uri, text))
				{
					return uri.Substring(text.Length);
				}
			}
			text = Identity.s_originalAppDomainGuidString;
			if (uri.Length > text.Length && Identity.StringStartsWith(uri, text))
			{
				return uri.Substring(text.Length);
			}
			string applicationName = RemotingConfiguration.ApplicationName;
			if (applicationName != null && uri.Length > applicationName.Length + 2 && string.Compare(uri, 1, applicationName, 0, applicationName.Length, true, CultureInfo.InvariantCulture) == 0 && uri[applicationName.Length + 1] == '/')
			{
				return uri.Substring(applicationName.Length + 2);
			}
			uri = uri.Substring(1);
			return uri;
		}

		// Token: 0x06005544 RID: 21828 RVA: 0x0012F08C File Offset: 0x0012D28C
		private static bool StringStartsWith(string s1, string prefix)
		{
			return s1.Length >= prefix.Length && string.CompareOrdinal(s1, 0, prefix, 0, prefix.Length) == 0;
		}

		// Token: 0x17000E07 RID: 3591
		// (get) Token: 0x06005545 RID: 21829 RVA: 0x0012F0B0 File Offset: 0x0012D2B0
		internal static string ProcessGuid
		{
			get
			{
				return Identity.ProcessIDGuid;
			}
		}

		// Token: 0x06005546 RID: 21830 RVA: 0x0012F0B7 File Offset: 0x0012D2B7
		private static int GetNextSeqNum()
		{
			return SharedStatics.Remoting_Identity_GetNextSeqNum();
		}

		// Token: 0x06005547 RID: 21831 RVA: 0x0012F0C0 File Offset: 0x0012D2C0
		private static byte[] GetRandomBytes()
		{
			byte[] array = new byte[18];
			Identity.s_rng.GetBytes(array);
			return array;
		}

		// Token: 0x06005548 RID: 21832 RVA: 0x0012F0E1 File Offset: 0x0012D2E1
		internal Identity(string objURI, string URL)
		{
			if (URL != null)
			{
				this._flags |= 256;
				this._URL = URL;
			}
			this.SetOrCreateURI(objURI, true);
		}

		// Token: 0x06005549 RID: 21833 RVA: 0x0012F10D File Offset: 0x0012D30D
		internal Identity(bool bContextBound)
		{
			if (bContextBound)
			{
				this._flags |= 16;
			}
		}

		// Token: 0x17000E08 RID: 3592
		// (get) Token: 0x0600554A RID: 21834 RVA: 0x0012F127 File Offset: 0x0012D327
		internal bool IsContextBound
		{
			get
			{
				return (this._flags & 16) == 16;
			}
		}

		// Token: 0x17000E09 RID: 3593
		// (get) Token: 0x0600554B RID: 21835 RVA: 0x0012F136 File Offset: 0x0012D336
		// (set) Token: 0x0600554C RID: 21836 RVA: 0x0012F140 File Offset: 0x0012D340
		internal bool IsInitializing
		{
			get
			{
				return this._initializing;
			}
			set
			{
				this._initializing = value;
			}
		}

		// Token: 0x0600554D RID: 21837 RVA: 0x0012F14B File Offset: 0x0012D34B
		internal bool IsWellKnown()
		{
			return (this._flags & 256) == 256;
		}

		// Token: 0x0600554E RID: 21838 RVA: 0x0012F160 File Offset: 0x0012D360
		internal void SetInIDTable()
		{
			int flags;
			int value;
			do
			{
				flags = this._flags;
				value = (this._flags | 4);
			}
			while (flags != Interlocked.CompareExchange(ref this._flags, value, flags));
		}

		// Token: 0x0600554F RID: 21839 RVA: 0x0012F190 File Offset: 0x0012D390
		[SecurityCritical]
		internal void ResetInIDTable(bool bResetURI)
		{
			int flags;
			int value;
			do
			{
				flags = this._flags;
				value = (this._flags & -5);
			}
			while (flags != Interlocked.CompareExchange(ref this._flags, value, flags));
			if (bResetURI)
			{
				((ObjRef)this._objRef).URI = null;
				this._ObjURI = null;
			}
		}

		// Token: 0x06005550 RID: 21840 RVA: 0x0012F1D9 File Offset: 0x0012D3D9
		internal bool IsInIDTable()
		{
			return (this._flags & 4) == 4;
		}

		// Token: 0x06005551 RID: 21841 RVA: 0x0012F1E8 File Offset: 0x0012D3E8
		internal void SetFullyConnected()
		{
			int flags;
			int value;
			do
			{
				flags = this._flags;
				value = (this._flags & -4);
			}
			while (flags != Interlocked.CompareExchange(ref this._flags, value, flags));
		}

		// Token: 0x06005552 RID: 21842 RVA: 0x0012F216 File Offset: 0x0012D416
		internal bool IsFullyDisconnected()
		{
			return (this._flags & 1) == 1;
		}

		// Token: 0x06005553 RID: 21843 RVA: 0x0012F223 File Offset: 0x0012D423
		internal bool IsRemoteDisconnected()
		{
			return (this._flags & 2) == 2;
		}

		// Token: 0x06005554 RID: 21844 RVA: 0x0012F230 File Offset: 0x0012D430
		internal bool IsDisconnected()
		{
			return this.IsFullyDisconnected() || this.IsRemoteDisconnected();
		}

		// Token: 0x17000E0A RID: 3594
		// (get) Token: 0x06005555 RID: 21845 RVA: 0x0012F242 File Offset: 0x0012D442
		internal string URI
		{
			get
			{
				if (this.IsWellKnown())
				{
					return this._URL;
				}
				return this._ObjURI;
			}
		}

		// Token: 0x17000E0B RID: 3595
		// (get) Token: 0x06005556 RID: 21846 RVA: 0x0012F259 File Offset: 0x0012D459
		internal string ObjURI
		{
			get
			{
				return this._ObjURI;
			}
		}

		// Token: 0x17000E0C RID: 3596
		// (get) Token: 0x06005557 RID: 21847 RVA: 0x0012F261 File Offset: 0x0012D461
		internal MarshalByRefObject TPOrObject
		{
			get
			{
				return (MarshalByRefObject)this._tpOrObject;
			}
		}

		// Token: 0x06005558 RID: 21848 RVA: 0x0012F26E File Offset: 0x0012D46E
		internal object RaceSetTransparentProxy(object tpObj)
		{
			if (this._tpOrObject == null)
			{
				Interlocked.CompareExchange(ref this._tpOrObject, tpObj, null);
			}
			return this._tpOrObject;
		}

		// Token: 0x17000E0D RID: 3597
		// (get) Token: 0x06005559 RID: 21849 RVA: 0x0012F28C File Offset: 0x0012D48C
		internal ObjRef ObjectRef
		{
			[SecurityCritical]
			get
			{
				return (ObjRef)this._objRef;
			}
		}

		// Token: 0x0600555A RID: 21850 RVA: 0x0012F299 File Offset: 0x0012D499
		[SecurityCritical]
		internal ObjRef RaceSetObjRef(ObjRef objRefGiven)
		{
			if (this._objRef == null)
			{
				Interlocked.CompareExchange(ref this._objRef, objRefGiven, null);
			}
			return (ObjRef)this._objRef;
		}

		// Token: 0x17000E0E RID: 3598
		// (get) Token: 0x0600555B RID: 21851 RVA: 0x0012F2BC File Offset: 0x0012D4BC
		internal IMessageSink ChannelSink
		{
			get
			{
				return (IMessageSink)this._channelSink;
			}
		}

		// Token: 0x0600555C RID: 21852 RVA: 0x0012F2C9 File Offset: 0x0012D4C9
		internal IMessageSink RaceSetChannelSink(IMessageSink channelSink)
		{
			if (this._channelSink == null)
			{
				Interlocked.CompareExchange(ref this._channelSink, channelSink, null);
			}
			return (IMessageSink)this._channelSink;
		}

		// Token: 0x17000E0F RID: 3599
		// (get) Token: 0x0600555D RID: 21853 RVA: 0x0012F2EC File Offset: 0x0012D4EC
		internal IMessageSink EnvoyChain
		{
			get
			{
				return (IMessageSink)this._envoyChain;
			}
		}

		// Token: 0x17000E10 RID: 3600
		// (get) Token: 0x0600555E RID: 21854 RVA: 0x0012F2F9 File Offset: 0x0012D4F9
		// (set) Token: 0x0600555F RID: 21855 RVA: 0x0012F301 File Offset: 0x0012D501
		internal Lease Lease
		{
			get
			{
				return this._lease;
			}
			set
			{
				this._lease = value;
			}
		}

		// Token: 0x06005560 RID: 21856 RVA: 0x0012F30A File Offset: 0x0012D50A
		internal IMessageSink RaceSetEnvoyChain(IMessageSink envoyChain)
		{
			if (this._envoyChain == null)
			{
				Interlocked.CompareExchange(ref this._envoyChain, envoyChain, null);
			}
			return (IMessageSink)this._envoyChain;
		}

		// Token: 0x06005561 RID: 21857 RVA: 0x0012F32D File Offset: 0x0012D52D
		internal void SetOrCreateURI(string uri)
		{
			this.SetOrCreateURI(uri, false);
		}

		// Token: 0x06005562 RID: 21858 RVA: 0x0012F338 File Offset: 0x0012D538
		internal void SetOrCreateURI(string uri, bool bIdCtor)
		{
			if (!bIdCtor && this._ObjURI != null)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_SetObjectUriForMarshal__UriExists"));
			}
			if (uri == null)
			{
				string text = Convert.ToBase64String(Identity.GetRandomBytes());
				this._ObjURI = string.Concat(new string[]
				{
					Identity.IDGuidString,
					text.Replace('/', '_'),
					"_",
					Identity.GetNextSeqNum().ToString(CultureInfo.InvariantCulture.NumberFormat),
					".rem"
				}).ToLower(CultureInfo.InvariantCulture);
				return;
			}
			if (this is ServerIdentity)
			{
				this._ObjURI = Identity.IDGuidString + uri;
				return;
			}
			this._ObjURI = uri;
		}

		// Token: 0x06005563 RID: 21859 RVA: 0x0012F3EC File Offset: 0x0012D5EC
		internal static string GetNewLogicalCallID()
		{
			return Identity.IDGuidString + Identity.GetNextSeqNum().ToString();
		}

		// Token: 0x06005564 RID: 21860 RVA: 0x0012F410 File Offset: 0x0012D610
		[SecurityCritical]
		[Conditional("_DEBUG")]
		internal virtual void AssertValid()
		{
			if (this.URI != null)
			{
				Identity identity = IdentityHolder.ResolveIdentity(this.URI);
			}
		}

		// Token: 0x06005565 RID: 21861 RVA: 0x0012F434 File Offset: 0x0012D634
		[SecurityCritical]
		internal bool AddProxySideDynamicProperty(IDynamicProperty prop)
		{
			bool result;
			lock (this)
			{
				if (this._dph == null)
				{
					DynamicPropertyHolder dph = new DynamicPropertyHolder();
					lock (this)
					{
						if (this._dph == null)
						{
							this._dph = dph;
						}
					}
				}
				result = this._dph.AddDynamicProperty(prop);
			}
			return result;
		}

		// Token: 0x06005566 RID: 21862 RVA: 0x0012F4BC File Offset: 0x0012D6BC
		[SecurityCritical]
		internal bool RemoveProxySideDynamicProperty(string name)
		{
			bool result;
			lock (this)
			{
				if (this._dph == null)
				{
					throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_Contexts_NoProperty"), name));
				}
				result = this._dph.RemoveDynamicProperty(name);
			}
			return result;
		}

		// Token: 0x17000E11 RID: 3601
		// (get) Token: 0x06005567 RID: 21863 RVA: 0x0012F524 File Offset: 0x0012D724
		internal ArrayWithSize ProxySideDynamicSinks
		{
			[SecurityCritical]
			get
			{
				if (this._dph == null)
				{
					return null;
				}
				return this._dph.DynamicSinks;
			}
		}

		// Token: 0x0400273B RID: 10043
		private static string s_originalAppDomainGuid = Guid.NewGuid().ToString().Replace('-', '_');

		// Token: 0x0400273C RID: 10044
		private static string s_configuredAppDomainGuid = null;

		// Token: 0x0400273D RID: 10045
		private static string s_originalAppDomainGuidString = "/" + Identity.s_originalAppDomainGuid.ToLower(CultureInfo.InvariantCulture) + "/";

		// Token: 0x0400273E RID: 10046
		private static string s_configuredAppDomainGuidString = null;

		// Token: 0x0400273F RID: 10047
		private static string s_IDGuidString = "/" + Identity.s_originalAppDomainGuid.ToLower(CultureInfo.InvariantCulture) + "/";

		// Token: 0x04002740 RID: 10048
		private static RNGCryptoServiceProvider s_rng = new RNGCryptoServiceProvider();

		// Token: 0x04002741 RID: 10049
		protected const int IDFLG_DISCONNECTED_FULL = 1;

		// Token: 0x04002742 RID: 10050
		protected const int IDFLG_DISCONNECTED_REM = 2;

		// Token: 0x04002743 RID: 10051
		protected const int IDFLG_IN_IDTABLE = 4;

		// Token: 0x04002744 RID: 10052
		protected const int IDFLG_CONTEXT_BOUND = 16;

		// Token: 0x04002745 RID: 10053
		protected const int IDFLG_WELLKNOWN = 256;

		// Token: 0x04002746 RID: 10054
		protected const int IDFLG_SERVER_SINGLECALL = 512;

		// Token: 0x04002747 RID: 10055
		protected const int IDFLG_SERVER_SINGLETON = 1024;

		// Token: 0x04002748 RID: 10056
		internal int _flags;

		// Token: 0x04002749 RID: 10057
		internal object _tpOrObject;

		// Token: 0x0400274A RID: 10058
		protected string _ObjURI;

		// Token: 0x0400274B RID: 10059
		protected string _URL;

		// Token: 0x0400274C RID: 10060
		internal object _objRef;

		// Token: 0x0400274D RID: 10061
		internal object _channelSink;

		// Token: 0x0400274E RID: 10062
		internal object _envoyChain;

		// Token: 0x0400274F RID: 10063
		internal DynamicPropertyHolder _dph;

		// Token: 0x04002750 RID: 10064
		internal Lease _lease;

		// Token: 0x04002751 RID: 10065
		private volatile bool _initializing;
	}
}
