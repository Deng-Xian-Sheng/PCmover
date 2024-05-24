using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security;

namespace System.Runtime.Remoting.Channels
{
	// Token: 0x0200082E RID: 2094
	[SecurityCritical]
	[ComVisible(true)]
	public class ClientChannelSinkStack : IClientChannelSinkStack, IClientResponseChannelSinkStack
	{
		// Token: 0x0600599F RID: 22943 RVA: 0x0013BFB5 File Offset: 0x0013A1B5
		public ClientChannelSinkStack()
		{
		}

		// Token: 0x060059A0 RID: 22944 RVA: 0x0013BFBD File Offset: 0x0013A1BD
		public ClientChannelSinkStack(IMessageSink replySink)
		{
			this._replySink = replySink;
		}

		// Token: 0x060059A1 RID: 22945 RVA: 0x0013BFCC File Offset: 0x0013A1CC
		[SecurityCritical]
		public void Push(IClientChannelSink sink, object state)
		{
			this._stack = new ClientChannelSinkStack.SinkStack
			{
				PrevStack = this._stack,
				Sink = sink,
				State = state
			};
		}

		// Token: 0x060059A2 RID: 22946 RVA: 0x0013C000 File Offset: 0x0013A200
		[SecurityCritical]
		public object Pop(IClientChannelSink sink)
		{
			if (this._stack == null)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Channel_PopOnEmptySinkStack"));
			}
			while (this._stack.Sink != sink)
			{
				this._stack = this._stack.PrevStack;
				if (this._stack == null)
				{
					break;
				}
			}
			if (this._stack.Sink == null)
			{
				throw new RemotingException(Environment.GetResourceString("Remoting_Channel_PopFromSinkStackWithoutPush"));
			}
			object state = this._stack.State;
			this._stack = this._stack.PrevStack;
			return state;
		}

		// Token: 0x060059A3 RID: 22947 RVA: 0x0013C088 File Offset: 0x0013A288
		[SecurityCritical]
		public void AsyncProcessResponse(ITransportHeaders headers, Stream stream)
		{
			if (this._replySink != null)
			{
				if (this._stack == null)
				{
					throw new RemotingException(Environment.GetResourceString("Remoting_Channel_CantCallAPRWhenStackEmpty"));
				}
				IClientChannelSink sink = this._stack.Sink;
				object state = this._stack.State;
				this._stack = this._stack.PrevStack;
				sink.AsyncProcessResponse(this, state, headers, stream);
			}
		}

		// Token: 0x060059A4 RID: 22948 RVA: 0x0013C0E8 File Offset: 0x0013A2E8
		[SecurityCritical]
		public void DispatchReplyMessage(IMessage msg)
		{
			if (this._replySink != null)
			{
				this._replySink.SyncProcessMessage(msg);
			}
		}

		// Token: 0x060059A5 RID: 22949 RVA: 0x0013C0FF File Offset: 0x0013A2FF
		[SecurityCritical]
		public void DispatchException(Exception e)
		{
			this.DispatchReplyMessage(new ReturnMessage(e, null));
		}

		// Token: 0x040028CC RID: 10444
		private ClientChannelSinkStack.SinkStack _stack;

		// Token: 0x040028CD RID: 10445
		private IMessageSink _replySink;

		// Token: 0x02000C75 RID: 3189
		private class SinkStack
		{
			// Token: 0x040037FB RID: 14331
			public ClientChannelSinkStack.SinkStack PrevStack;

			// Token: 0x040037FC RID: 14332
			public IClientChannelSink Sink;

			// Token: 0x040037FD RID: 14333
			public object State;
		}
	}
}
