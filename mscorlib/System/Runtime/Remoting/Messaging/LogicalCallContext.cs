using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Principal;

namespace System.Runtime.Remoting.Messaging
{
	// Token: 0x0200088D RID: 2189
	[SecurityCritical]
	[ComVisible(true)]
	[Serializable]
	public sealed class LogicalCallContext : ISerializable, ICloneable
	{
		// Token: 0x06005CBD RID: 23741 RVA: 0x0014522A File Offset: 0x0014342A
		internal LogicalCallContext()
		{
		}

		// Token: 0x06005CBE RID: 23742 RVA: 0x00145234 File Offset: 0x00143434
		[SecurityCritical]
		internal LogicalCallContext(SerializationInfo info, StreamingContext context)
		{
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Name.Equals("__RemotingData"))
				{
					this.m_RemotingData = (CallContextRemotingData)enumerator.Value;
				}
				else if (enumerator.Name.Equals("__SecurityData"))
				{
					if (context.State == StreamingContextStates.CrossAppDomain)
					{
						this.m_SecurityData = (CallContextSecurityData)enumerator.Value;
					}
				}
				else if (enumerator.Name.Equals("__HostContext"))
				{
					this.m_HostContext = enumerator.Value;
				}
				else if (enumerator.Name.Equals("__CorrelationMgrSlotPresent"))
				{
					this.m_IsCorrelationMgr = (bool)enumerator.Value;
				}
				else
				{
					this.Datastore[enumerator.Name] = enumerator.Value;
				}
			}
		}

		// Token: 0x06005CBF RID: 23743 RVA: 0x00145318 File Offset: 0x00143518
		[SecurityCritical]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}
			info.SetType(LogicalCallContext.s_callContextType);
			if (this.m_RemotingData != null)
			{
				info.AddValue("__RemotingData", this.m_RemotingData);
			}
			if (this.m_SecurityData != null && context.State == StreamingContextStates.CrossAppDomain)
			{
				info.AddValue("__SecurityData", this.m_SecurityData);
			}
			if (this.m_HostContext != null)
			{
				info.AddValue("__HostContext", this.m_HostContext);
			}
			if (this.m_IsCorrelationMgr)
			{
				info.AddValue("__CorrelationMgrSlotPresent", this.m_IsCorrelationMgr);
			}
			if (this.HasUserData)
			{
				IDictionaryEnumerator enumerator = this.m_Datastore.GetEnumerator();
				while (enumerator.MoveNext())
				{
					info.AddValue((string)enumerator.Key, enumerator.Value);
				}
			}
		}

		// Token: 0x06005CC0 RID: 23744 RVA: 0x001453E8 File Offset: 0x001435E8
		[SecuritySafeCritical]
		public object Clone()
		{
			LogicalCallContext logicalCallContext = new LogicalCallContext();
			if (this.m_RemotingData != null)
			{
				logicalCallContext.m_RemotingData = (CallContextRemotingData)this.m_RemotingData.Clone();
			}
			if (this.m_SecurityData != null)
			{
				logicalCallContext.m_SecurityData = (CallContextSecurityData)this.m_SecurityData.Clone();
			}
			if (this.m_HostContext != null)
			{
				logicalCallContext.m_HostContext = this.m_HostContext;
			}
			logicalCallContext.m_IsCorrelationMgr = this.m_IsCorrelationMgr;
			if (this.HasUserData)
			{
				IDictionaryEnumerator enumerator = this.m_Datastore.GetEnumerator();
				if (!this.m_IsCorrelationMgr)
				{
					while (enumerator.MoveNext())
					{
						logicalCallContext.Datastore[(string)enumerator.Key] = enumerator.Value;
					}
				}
				else
				{
					while (enumerator.MoveNext())
					{
						string text = (string)enumerator.Key;
						if (text.Equals("System.Diagnostics.Trace.CorrelationManagerSlot"))
						{
							logicalCallContext.Datastore[text] = ((ICloneable)enumerator.Value).Clone();
						}
						else
						{
							logicalCallContext.Datastore[text] = enumerator.Value;
						}
					}
				}
			}
			return logicalCallContext;
		}

		// Token: 0x06005CC1 RID: 23745 RVA: 0x001454F0 File Offset: 0x001436F0
		[SecurityCritical]
		internal void Merge(LogicalCallContext lc)
		{
			if (lc != null && this != lc && lc.HasUserData)
			{
				IDictionaryEnumerator enumerator = lc.Datastore.GetEnumerator();
				while (enumerator.MoveNext())
				{
					this.Datastore[(string)enumerator.Key] = enumerator.Value;
				}
			}
		}

		// Token: 0x17000FF0 RID: 4080
		// (get) Token: 0x06005CC2 RID: 23746 RVA: 0x00145540 File Offset: 0x00143740
		public bool HasInfo
		{
			[SecurityCritical]
			get
			{
				bool result = false;
				if ((this.m_RemotingData != null && this.m_RemotingData.HasInfo) || (this.m_SecurityData != null && this.m_SecurityData.HasInfo) || this.m_HostContext != null || this.HasUserData)
				{
					result = true;
				}
				return result;
			}
		}

		// Token: 0x17000FF1 RID: 4081
		// (get) Token: 0x06005CC3 RID: 23747 RVA: 0x0014558C File Offset: 0x0014378C
		private bool HasUserData
		{
			get
			{
				return this.m_Datastore != null && this.m_Datastore.Count > 0;
			}
		}

		// Token: 0x17000FF2 RID: 4082
		// (get) Token: 0x06005CC4 RID: 23748 RVA: 0x001455A6 File Offset: 0x001437A6
		internal CallContextRemotingData RemotingData
		{
			get
			{
				if (this.m_RemotingData == null)
				{
					this.m_RemotingData = new CallContextRemotingData();
				}
				return this.m_RemotingData;
			}
		}

		// Token: 0x17000FF3 RID: 4083
		// (get) Token: 0x06005CC5 RID: 23749 RVA: 0x001455C1 File Offset: 0x001437C1
		internal CallContextSecurityData SecurityData
		{
			get
			{
				if (this.m_SecurityData == null)
				{
					this.m_SecurityData = new CallContextSecurityData();
				}
				return this.m_SecurityData;
			}
		}

		// Token: 0x17000FF4 RID: 4084
		// (get) Token: 0x06005CC6 RID: 23750 RVA: 0x001455DC File Offset: 0x001437DC
		// (set) Token: 0x06005CC7 RID: 23751 RVA: 0x001455E4 File Offset: 0x001437E4
		internal object HostContext
		{
			get
			{
				return this.m_HostContext;
			}
			set
			{
				this.m_HostContext = value;
			}
		}

		// Token: 0x17000FF5 RID: 4085
		// (get) Token: 0x06005CC8 RID: 23752 RVA: 0x001455ED File Offset: 0x001437ED
		private Hashtable Datastore
		{
			get
			{
				if (this.m_Datastore == null)
				{
					this.m_Datastore = new Hashtable();
				}
				return this.m_Datastore;
			}
		}

		// Token: 0x17000FF6 RID: 4086
		// (get) Token: 0x06005CC9 RID: 23753 RVA: 0x00145608 File Offset: 0x00143808
		// (set) Token: 0x06005CCA RID: 23754 RVA: 0x0014561F File Offset: 0x0014381F
		internal IPrincipal Principal
		{
			get
			{
				if (this.m_SecurityData != null)
				{
					return this.m_SecurityData.Principal;
				}
				return null;
			}
			[SecurityCritical]
			set
			{
				this.SecurityData.Principal = value;
			}
		}

		// Token: 0x06005CCB RID: 23755 RVA: 0x0014562D File Offset: 0x0014382D
		[SecurityCritical]
		public void FreeNamedDataSlot(string name)
		{
			this.Datastore.Remove(name);
		}

		// Token: 0x06005CCC RID: 23756 RVA: 0x0014563B File Offset: 0x0014383B
		[SecurityCritical]
		public object GetData(string name)
		{
			return this.Datastore[name];
		}

		// Token: 0x06005CCD RID: 23757 RVA: 0x00145649 File Offset: 0x00143849
		[SecurityCritical]
		public void SetData(string name, object data)
		{
			this.Datastore[name] = data;
			if (name.Equals("System.Diagnostics.Trace.CorrelationManagerSlot"))
			{
				this.m_IsCorrelationMgr = true;
			}
		}

		// Token: 0x06005CCE RID: 23758 RVA: 0x0014566C File Offset: 0x0014386C
		private Header[] InternalGetOutgoingHeaders()
		{
			Header[] sendHeaders = this._sendHeaders;
			this._sendHeaders = null;
			this._recvHeaders = null;
			return sendHeaders;
		}

		// Token: 0x06005CCF RID: 23759 RVA: 0x0014568F File Offset: 0x0014388F
		internal void InternalSetHeaders(Header[] headers)
		{
			this._sendHeaders = headers;
			this._recvHeaders = null;
		}

		// Token: 0x06005CD0 RID: 23760 RVA: 0x0014569F File Offset: 0x0014389F
		internal Header[] InternalGetHeaders()
		{
			if (this._sendHeaders != null)
			{
				return this._sendHeaders;
			}
			return this._recvHeaders;
		}

		// Token: 0x06005CD1 RID: 23761 RVA: 0x001456B8 File Offset: 0x001438B8
		[SecurityCritical]
		internal IPrincipal RemovePrincipalIfNotSerializable()
		{
			IPrincipal principal = this.Principal;
			if (principal != null && !principal.GetType().IsSerializable)
			{
				this.Principal = null;
			}
			return principal;
		}

		// Token: 0x06005CD2 RID: 23762 RVA: 0x001456E4 File Offset: 0x001438E4
		[SecurityCritical]
		internal void PropagateOutgoingHeadersToMessage(IMessage msg)
		{
			Header[] array = this.InternalGetOutgoingHeaders();
			if (array != null)
			{
				IDictionary properties = msg.Properties;
				foreach (Header header in array)
				{
					if (header != null)
					{
						string propertyKeyForHeader = LogicalCallContext.GetPropertyKeyForHeader(header);
						properties[propertyKeyForHeader] = header;
					}
				}
			}
		}

		// Token: 0x06005CD3 RID: 23763 RVA: 0x0014572E File Offset: 0x0014392E
		internal static string GetPropertyKeyForHeader(Header header)
		{
			if (header == null)
			{
				return null;
			}
			if (header.HeaderNamespace != null)
			{
				return header.Name + ", " + header.HeaderNamespace;
			}
			return header.Name;
		}

		// Token: 0x06005CD4 RID: 23764 RVA: 0x0014575C File Offset: 0x0014395C
		[SecurityCritical]
		internal void PropagateIncomingHeadersToCallContext(IMessage msg)
		{
			IInternalMessage internalMessage = msg as IInternalMessage;
			if (internalMessage != null && !internalMessage.HasProperties())
			{
				return;
			}
			IDictionary properties = msg.Properties;
			IDictionaryEnumerator enumerator = properties.GetEnumerator();
			int num = 0;
			while (enumerator.MoveNext())
			{
				string text = (string)enumerator.Key;
				if (!text.StartsWith("__", StringComparison.Ordinal) && enumerator.Value is Header)
				{
					num++;
				}
			}
			Header[] array = null;
			if (num > 0)
			{
				array = new Header[num];
				num = 0;
				enumerator.Reset();
				while (enumerator.MoveNext())
				{
					string text2 = (string)enumerator.Key;
					if (!text2.StartsWith("__", StringComparison.Ordinal))
					{
						Header header = enumerator.Value as Header;
						if (header != null)
						{
							array[num++] = header;
						}
					}
				}
			}
			this._recvHeaders = array;
			this._sendHeaders = null;
		}

		// Token: 0x040029D2 RID: 10706
		private static Type s_callContextType = typeof(LogicalCallContext);

		// Token: 0x040029D3 RID: 10707
		private const string s_CorrelationMgrSlotName = "System.Diagnostics.Trace.CorrelationManagerSlot";

		// Token: 0x040029D4 RID: 10708
		private Hashtable m_Datastore;

		// Token: 0x040029D5 RID: 10709
		private CallContextRemotingData m_RemotingData;

		// Token: 0x040029D6 RID: 10710
		private CallContextSecurityData m_SecurityData;

		// Token: 0x040029D7 RID: 10711
		private object m_HostContext;

		// Token: 0x040029D8 RID: 10712
		private bool m_IsCorrelationMgr;

		// Token: 0x040029D9 RID: 10713
		private Header[] _sendHeaders;

		// Token: 0x040029DA RID: 10714
		private Header[] _recvHeaders;

		// Token: 0x02000C7B RID: 3195
		internal struct Reader
		{
			// Token: 0x060070BF RID: 28863 RVA: 0x00184B6F File Offset: 0x00182D6F
			public Reader(LogicalCallContext ctx)
			{
				this.m_ctx = ctx;
			}

			// Token: 0x17001358 RID: 4952
			// (get) Token: 0x060070C0 RID: 28864 RVA: 0x00184B78 File Offset: 0x00182D78
			public bool IsNull
			{
				get
				{
					return this.m_ctx == null;
				}
			}

			// Token: 0x17001359 RID: 4953
			// (get) Token: 0x060070C1 RID: 28865 RVA: 0x00184B83 File Offset: 0x00182D83
			public bool HasInfo
			{
				get
				{
					return !this.IsNull && this.m_ctx.HasInfo;
				}
			}

			// Token: 0x060070C2 RID: 28866 RVA: 0x00184B9A File Offset: 0x00182D9A
			public LogicalCallContext Clone()
			{
				return (LogicalCallContext)this.m_ctx.Clone();
			}

			// Token: 0x1700135A RID: 4954
			// (get) Token: 0x060070C3 RID: 28867 RVA: 0x00184BAC File Offset: 0x00182DAC
			public IPrincipal Principal
			{
				get
				{
					if (!this.IsNull)
					{
						return this.m_ctx.Principal;
					}
					return null;
				}
			}

			// Token: 0x060070C4 RID: 28868 RVA: 0x00184BC3 File Offset: 0x00182DC3
			[SecurityCritical]
			public object GetData(string name)
			{
				if (!this.IsNull)
				{
					return this.m_ctx.GetData(name);
				}
				return null;
			}

			// Token: 0x1700135B RID: 4955
			// (get) Token: 0x060070C5 RID: 28869 RVA: 0x00184BDB File Offset: 0x00182DDB
			public object HostContext
			{
				get
				{
					if (!this.IsNull)
					{
						return this.m_ctx.HostContext;
					}
					return null;
				}
			}

			// Token: 0x04003807 RID: 14343
			private LogicalCallContext m_ctx;
		}
	}
}
