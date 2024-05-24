using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008C3 RID: 2243
	[AttributeUsage(AttributeTargets.Assembly)]
	[Serializable]
	public sealed class DefaultDependencyAttribute : Attribute
	{
		// Token: 0x06005DB7 RID: 23991 RVA: 0x001497A7 File Offset: 0x001479A7
		public DefaultDependencyAttribute(LoadHint loadHintArgument)
		{
			this.loadHint = loadHintArgument;
		}

		// Token: 0x1700101A RID: 4122
		// (get) Token: 0x06005DB8 RID: 23992 RVA: 0x001497B6 File Offset: 0x001479B6
		public LoadHint LoadHint
		{
			get
			{
				return this.loadHint;
			}
		}

		// Token: 0x04002A29 RID: 10793
		private LoadHint loadHint;
	}
}
