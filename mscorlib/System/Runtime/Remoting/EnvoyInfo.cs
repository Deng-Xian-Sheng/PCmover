using System;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting
{
	// Token: 0x020007BA RID: 1978
	[Serializable]
	internal sealed class EnvoyInfo : IEnvoyInfo
	{
		// Token: 0x06005599 RID: 21913 RVA: 0x0012FFC4 File Offset: 0x0012E1C4
		[SecurityCritical]
		internal static IEnvoyInfo CreateEnvoyInfo(ServerIdentity serverID)
		{
			IEnvoyInfo result = null;
			if (serverID != null)
			{
				if (serverID.EnvoyChain == null)
				{
					serverID.RaceSetEnvoyChain(serverID.ServerContext.CreateEnvoyChain(serverID.TPOrObject));
				}
				if (!(serverID.EnvoyChain is EnvoyTerminatorSink))
				{
					result = new EnvoyInfo(serverID.EnvoyChain);
				}
			}
			return result;
		}

		// Token: 0x0600559A RID: 21914 RVA: 0x00130012 File Offset: 0x0012E212
		[SecurityCritical]
		private EnvoyInfo(IMessageSink sinks)
		{
			this.EnvoySinks = sinks;
		}

		// Token: 0x17000E1D RID: 3613
		// (get) Token: 0x0600559B RID: 21915 RVA: 0x00130021 File Offset: 0x0012E221
		// (set) Token: 0x0600559C RID: 21916 RVA: 0x00130029 File Offset: 0x0012E229
		public IMessageSink EnvoySinks
		{
			[SecurityCritical]
			get
			{
				return this.envoySinks;
			}
			[SecurityCritical]
			set
			{
				this.envoySinks = value;
			}
		}

		// Token: 0x04002762 RID: 10082
		private IMessageSink envoySinks;
	}
}
