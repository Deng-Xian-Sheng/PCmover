using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000143 RID: 323
	[DataContract]
	public class ConsoleAPICalledEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170002BB RID: 699
		// (get) Token: 0x0600095B RID: 2395 RVA: 0x0000E5C6 File Offset: 0x0000C7C6
		// (set) Token: 0x0600095C RID: 2396 RVA: 0x0000E5E2 File Offset: 0x0000C7E2
		public ConsoleAPICalledType Type
		{
			get
			{
				return (ConsoleAPICalledType)DevToolsDomainEventArgsBase.StringToEnum(typeof(ConsoleAPICalledType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x0600095D RID: 2397 RVA: 0x0000E5F5 File Offset: 0x0000C7F5
		// (set) Token: 0x0600095E RID: 2398 RVA: 0x0000E5FD File Offset: 0x0000C7FD
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; private set; }

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x0600095F RID: 2399 RVA: 0x0000E606 File Offset: 0x0000C806
		// (set) Token: 0x06000960 RID: 2400 RVA: 0x0000E60E File Offset: 0x0000C80E
		[DataMember(Name = "args", IsRequired = true)]
		public IList<RemoteObject> Args { get; private set; }

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06000961 RID: 2401 RVA: 0x0000E617 File Offset: 0x0000C817
		// (set) Token: 0x06000962 RID: 2402 RVA: 0x0000E61F File Offset: 0x0000C81F
		[DataMember(Name = "executionContextId", IsRequired = true)]
		public int ExecutionContextId { get; private set; }

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06000963 RID: 2403 RVA: 0x0000E628 File Offset: 0x0000C828
		// (set) Token: 0x06000964 RID: 2404 RVA: 0x0000E630 File Offset: 0x0000C830
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000965 RID: 2405 RVA: 0x0000E639 File Offset: 0x0000C839
		// (set) Token: 0x06000966 RID: 2406 RVA: 0x0000E641 File Offset: 0x0000C841
		[DataMember(Name = "stackTrace", IsRequired = false)]
		public StackTrace StackTrace { get; private set; }

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000967 RID: 2407 RVA: 0x0000E64A File Offset: 0x0000C84A
		// (set) Token: 0x06000968 RID: 2408 RVA: 0x0000E652 File Offset: 0x0000C852
		[DataMember(Name = "context", IsRequired = false)]
		public string Context { get; private set; }
	}
}
