using System;
using System.Runtime.CompilerServices;

namespace RestSharp.Deserializers
{
	// Token: 0x02000037 RID: 55
	[NullableContext(1)]
	[Nullable(0)]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = false)]
	public sealed class DeserializeAsAttribute : Attribute
	{
		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x00009F46 File Offset: 0x00008146
		// (set) Token: 0x06000464 RID: 1124 RVA: 0x00009F4E File Offset: 0x0000814E
		public string Name { get; set; }

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x00009F57 File Offset: 0x00008157
		// (set) Token: 0x06000466 RID: 1126 RVA: 0x00009F5F File Offset: 0x0000815F
		public bool Attribute { get; set; }

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x00009F68 File Offset: 0x00008168
		// (set) Token: 0x06000468 RID: 1128 RVA: 0x00009F70 File Offset: 0x00008170
		public bool Content { get; set; }
	}
}
