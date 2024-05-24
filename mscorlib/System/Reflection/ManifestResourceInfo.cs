using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005F2 RID: 1522
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public class ManifestResourceInfo
	{
		// Token: 0x0600466F RID: 18031 RVA: 0x0010267F File Offset: 0x0010087F
		[__DynamicallyInvokable]
		public ManifestResourceInfo(Assembly containingAssembly, string containingFileName, ResourceLocation resourceLocation)
		{
			this._containingAssembly = containingAssembly;
			this._containingFileName = containingFileName;
			this._resourceLocation = resourceLocation;
		}

		// Token: 0x17000A9A RID: 2714
		// (get) Token: 0x06004670 RID: 18032 RVA: 0x0010269C File Offset: 0x0010089C
		[__DynamicallyInvokable]
		public virtual Assembly ReferencedAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return this._containingAssembly;
			}
		}

		// Token: 0x17000A9B RID: 2715
		// (get) Token: 0x06004671 RID: 18033 RVA: 0x001026A4 File Offset: 0x001008A4
		[__DynamicallyInvokable]
		public virtual string FileName
		{
			[__DynamicallyInvokable]
			get
			{
				return this._containingFileName;
			}
		}

		// Token: 0x17000A9C RID: 2716
		// (get) Token: 0x06004672 RID: 18034 RVA: 0x001026AC File Offset: 0x001008AC
		[__DynamicallyInvokable]
		public virtual ResourceLocation ResourceLocation
		{
			[__DynamicallyInvokable]
			get
			{
				return this._resourceLocation;
			}
		}

		// Token: 0x04001CD1 RID: 7377
		private Assembly _containingAssembly;

		// Token: 0x04001CD2 RID: 7378
		private string _containingFileName;

		// Token: 0x04001CD3 RID: 7379
		private ResourceLocation _resourceLocation;
	}
}
