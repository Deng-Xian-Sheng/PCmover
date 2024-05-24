using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008C4 RID: 2244
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	[Serializable]
	public sealed class DependencyAttribute : Attribute
	{
		// Token: 0x06005DB9 RID: 23993 RVA: 0x001497BE File Offset: 0x001479BE
		public DependencyAttribute(string dependentAssemblyArgument, LoadHint loadHintArgument)
		{
			this.dependentAssembly = dependentAssemblyArgument;
			this.loadHint = loadHintArgument;
		}

		// Token: 0x1700101B RID: 4123
		// (get) Token: 0x06005DBA RID: 23994 RVA: 0x001497D4 File Offset: 0x001479D4
		public string DependentAssembly
		{
			get
			{
				return this.dependentAssembly;
			}
		}

		// Token: 0x1700101C RID: 4124
		// (get) Token: 0x06005DBB RID: 23995 RVA: 0x001497DC File Offset: 0x001479DC
		public LoadHint LoadHint
		{
			get
			{
				return this.loadHint;
			}
		}

		// Token: 0x04002A2A RID: 10794
		private string dependentAssembly;

		// Token: 0x04002A2B RID: 10795
		private LoadHint loadHint;
	}
}
