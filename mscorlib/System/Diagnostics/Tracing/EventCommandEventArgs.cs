using System;
using System.Collections.Generic;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000422 RID: 1058
	[__DynamicallyInvokable]
	public class EventCommandEventArgs : EventArgs
	{
		// Token: 0x170007D0 RID: 2000
		// (get) Token: 0x06003502 RID: 13570 RVA: 0x000CE226 File Offset: 0x000CC426
		// (set) Token: 0x06003503 RID: 13571 RVA: 0x000CE22E File Offset: 0x000CC42E
		[__DynamicallyInvokable]
		public EventCommand Command { [__DynamicallyInvokable] get; internal set; }

		// Token: 0x170007D1 RID: 2001
		// (get) Token: 0x06003504 RID: 13572 RVA: 0x000CE237 File Offset: 0x000CC437
		// (set) Token: 0x06003505 RID: 13573 RVA: 0x000CE23F File Offset: 0x000CC43F
		[__DynamicallyInvokable]
		public IDictionary<string, string> Arguments { [__DynamicallyInvokable] get; internal set; }

		// Token: 0x06003506 RID: 13574 RVA: 0x000CE248 File Offset: 0x000CC448
		[__DynamicallyInvokable]
		public bool EnableEvent(int eventId)
		{
			if (this.Command != EventCommand.Enable && this.Command != EventCommand.Disable)
			{
				throw new InvalidOperationException();
			}
			return this.eventSource.EnableEventForDispatcher(this.dispatcher, eventId, true);
		}

		// Token: 0x06003507 RID: 13575 RVA: 0x000CE277 File Offset: 0x000CC477
		[__DynamicallyInvokable]
		public bool DisableEvent(int eventId)
		{
			if (this.Command != EventCommand.Enable && this.Command != EventCommand.Disable)
			{
				throw new InvalidOperationException();
			}
			return this.eventSource.EnableEventForDispatcher(this.dispatcher, eventId, false);
		}

		// Token: 0x06003508 RID: 13576 RVA: 0x000CE2A8 File Offset: 0x000CC4A8
		internal EventCommandEventArgs(EventCommand command, IDictionary<string, string> arguments, EventSource eventSource, EventListener listener, int perEventSourceSessionId, int etwSessionId, bool enable, EventLevel level, EventKeywords matchAnyKeyword)
		{
			this.Command = command;
			this.Arguments = arguments;
			this.eventSource = eventSource;
			this.listener = listener;
			this.perEventSourceSessionId = perEventSourceSessionId;
			this.etwSessionId = etwSessionId;
			this.enable = enable;
			this.level = level;
			this.matchAnyKeyword = matchAnyKeyword;
		}

		// Token: 0x04001779 RID: 6009
		internal EventSource eventSource;

		// Token: 0x0400177A RID: 6010
		internal EventDispatcher dispatcher;

		// Token: 0x0400177B RID: 6011
		internal EventListener listener;

		// Token: 0x0400177C RID: 6012
		internal int perEventSourceSessionId;

		// Token: 0x0400177D RID: 6013
		internal int etwSessionId;

		// Token: 0x0400177E RID: 6014
		internal bool enable;

		// Token: 0x0400177F RID: 6015
		internal EventLevel level;

		// Token: 0x04001780 RID: 6016
		internal EventKeywords matchAnyKeyword;

		// Token: 0x04001781 RID: 6017
		internal EventCommandEventArgs nextCommand;
	}
}
