using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000940 RID: 2368
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	[ComVisible(false)]
	public sealed class ManagedToNativeComInteropStubAttribute : Attribute
	{
		// Token: 0x0600605C RID: 24668 RVA: 0x0014BED7 File Offset: 0x0014A0D7
		public ManagedToNativeComInteropStubAttribute(Type classType, string methodName)
		{
			this._classType = classType;
			this._methodName = methodName;
		}

		// Token: 0x170010F4 RID: 4340
		// (get) Token: 0x0600605D RID: 24669 RVA: 0x0014BEED File Offset: 0x0014A0ED
		public Type ClassType
		{
			get
			{
				return this._classType;
			}
		}

		// Token: 0x170010F5 RID: 4341
		// (get) Token: 0x0600605E RID: 24670 RVA: 0x0014BEF5 File Offset: 0x0014A0F5
		public string MethodName
		{
			get
			{
				return this._methodName;
			}
		}

		// Token: 0x04002B2A RID: 11050
		internal Type _classType;

		// Token: 0x04002B2B RID: 11051
		internal string _methodName;
	}
}
