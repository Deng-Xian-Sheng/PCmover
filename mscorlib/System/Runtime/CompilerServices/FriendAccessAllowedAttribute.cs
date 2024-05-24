using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008B9 RID: 2233
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	[FriendAccessAllowed]
	internal sealed class FriendAccessAllowedAttribute : Attribute
	{
	}
}
