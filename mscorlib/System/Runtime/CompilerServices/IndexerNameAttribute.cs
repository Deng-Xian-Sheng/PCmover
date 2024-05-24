using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008B7 RID: 2231
	[AttributeUsage(AttributeTargets.Property, Inherited = true)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class IndexerNameAttribute : Attribute
	{
		// Token: 0x06005DA7 RID: 23975 RVA: 0x001496E8 File Offset: 0x001478E8
		[__DynamicallyInvokable]
		public IndexerNameAttribute(string indexerName)
		{
		}
	}
}
