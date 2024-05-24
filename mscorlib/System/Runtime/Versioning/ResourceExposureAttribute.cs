using System;
using System.Diagnostics;

namespace System.Runtime.Versioning
{
	// Token: 0x0200071F RID: 1823
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, Inherited = false)]
	[Conditional("RESOURCE_ANNOTATION_WORK")]
	public sealed class ResourceExposureAttribute : Attribute
	{
		// Token: 0x06005155 RID: 20821 RVA: 0x0011EC98 File Offset: 0x0011CE98
		public ResourceExposureAttribute(ResourceScope exposureLevel)
		{
			this._resourceExposureLevel = exposureLevel;
		}

		// Token: 0x17000D6C RID: 3436
		// (get) Token: 0x06005156 RID: 20822 RVA: 0x0011ECA7 File Offset: 0x0011CEA7
		public ResourceScope ResourceExposureLevel
		{
			get
			{
				return this._resourceExposureLevel;
			}
		}

		// Token: 0x0400240A RID: 9226
		private ResourceScope _resourceExposureLevel;
	}
}
