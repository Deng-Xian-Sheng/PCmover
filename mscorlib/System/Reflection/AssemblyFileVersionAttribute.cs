using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005BC RID: 1468
	[AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class AssemblyFileVersionAttribute : Attribute
	{
		// Token: 0x0600445E RID: 17502 RVA: 0x000FC393 File Offset: 0x000FA593
		[__DynamicallyInvokable]
		public AssemblyFileVersionAttribute(string version)
		{
			if (version == null)
			{
				throw new ArgumentNullException("version");
			}
			this._version = version;
		}

		// Token: 0x17000A18 RID: 2584
		// (get) Token: 0x0600445F RID: 17503 RVA: 0x000FC3B0 File Offset: 0x000FA5B0
		[__DynamicallyInvokable]
		public string Version
		{
			[__DynamicallyInvokable]
			get
			{
				return this._version;
			}
		}

		// Token: 0x04001BFF RID: 7167
		private string _version;
	}
}
