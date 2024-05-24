using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008B8 RID: 2232
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class InternalsVisibleToAttribute : Attribute
	{
		// Token: 0x06005DA8 RID: 23976 RVA: 0x001496F0 File Offset: 0x001478F0
		[__DynamicallyInvokable]
		public InternalsVisibleToAttribute(string assemblyName)
		{
			this._assemblyName = assemblyName;
		}

		// Token: 0x17001016 RID: 4118
		// (get) Token: 0x06005DA9 RID: 23977 RVA: 0x00149706 File Offset: 0x00147906
		[__DynamicallyInvokable]
		public string AssemblyName
		{
			[__DynamicallyInvokable]
			get
			{
				return this._assemblyName;
			}
		}

		// Token: 0x17001017 RID: 4119
		// (get) Token: 0x06005DAA RID: 23978 RVA: 0x0014970E File Offset: 0x0014790E
		// (set) Token: 0x06005DAB RID: 23979 RVA: 0x00149716 File Offset: 0x00147916
		public bool AllInternalsVisible
		{
			get
			{
				return this._allInternalsVisible;
			}
			set
			{
				this._allInternalsVisible = value;
			}
		}

		// Token: 0x04002A11 RID: 10769
		private string _assemblyName;

		// Token: 0x04002A12 RID: 10770
		private bool _allInternalsVisible = true;
	}
}
