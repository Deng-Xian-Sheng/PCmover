using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000177 RID: 375
	public enum ScopeType
	{
		// Token: 0x040005C5 RID: 1477
		[EnumMember(Value = "global")]
		Global,
		// Token: 0x040005C6 RID: 1478
		[EnumMember(Value = "local")]
		Local,
		// Token: 0x040005C7 RID: 1479
		[EnumMember(Value = "with")]
		With,
		// Token: 0x040005C8 RID: 1480
		[EnumMember(Value = "closure")]
		Closure,
		// Token: 0x040005C9 RID: 1481
		[EnumMember(Value = "catch")]
		Catch,
		// Token: 0x040005CA RID: 1482
		[EnumMember(Value = "block")]
		Block,
		// Token: 0x040005CB RID: 1483
		[EnumMember(Value = "script")]
		Script,
		// Token: 0x040005CC RID: 1484
		[EnumMember(Value = "eval")]
		Eval,
		// Token: 0x040005CD RID: 1485
		[EnumMember(Value = "module")]
		Module,
		// Token: 0x040005CE RID: 1486
		[EnumMember(Value = "wasm-expression-stack")]
		WasmExpressionStack
	}
}
