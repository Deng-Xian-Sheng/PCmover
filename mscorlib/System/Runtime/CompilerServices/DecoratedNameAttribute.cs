using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008DE RID: 2270
	[AttributeUsage(AttributeTargets.All)]
	[ComVisible(false)]
	internal sealed class DecoratedNameAttribute : Attribute
	{
		// Token: 0x06005DD1 RID: 24017 RVA: 0x001498A7 File Offset: 0x00147AA7
		public DecoratedNameAttribute(string decoratedName)
		{
		}
	}
}
