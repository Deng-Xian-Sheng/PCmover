using System;
using System.Collections.Generic;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008FD RID: 2301
	[CLSCompliant(false)]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
	public sealed class TupleElementNamesAttribute : Attribute
	{
		// Token: 0x06005E4F RID: 24143 RVA: 0x0014B44B File Offset: 0x0014964B
		public TupleElementNamesAttribute(string[] transformNames)
		{
			if (transformNames == null)
			{
				throw new ArgumentNullException("transformNames");
			}
			this._transformNames = transformNames;
		}

		// Token: 0x17001032 RID: 4146
		// (get) Token: 0x06005E50 RID: 24144 RVA: 0x0014B468 File Offset: 0x00149668
		public IList<string> TransformNames
		{
			get
			{
				return this._transformNames;
			}
		}

		// Token: 0x04002A52 RID: 10834
		private readonly string[] _transformNames;
	}
}
