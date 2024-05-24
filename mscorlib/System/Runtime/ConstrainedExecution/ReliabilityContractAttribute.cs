using System;

namespace System.Runtime.ConstrainedExecution
{
	// Token: 0x0200072B RID: 1835
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Interface, Inherited = false)]
	public sealed class ReliabilityContractAttribute : Attribute
	{
		// Token: 0x0600516E RID: 20846 RVA: 0x0011F098 File Offset: 0x0011D298
		public ReliabilityContractAttribute(Consistency consistencyGuarantee, Cer cer)
		{
			this._consistency = consistencyGuarantee;
			this._cer = cer;
		}

		// Token: 0x17000D6F RID: 3439
		// (get) Token: 0x0600516F RID: 20847 RVA: 0x0011F0AE File Offset: 0x0011D2AE
		public Consistency ConsistencyGuarantee
		{
			get
			{
				return this._consistency;
			}
		}

		// Token: 0x17000D70 RID: 3440
		// (get) Token: 0x06005170 RID: 20848 RVA: 0x0011F0B6 File Offset: 0x0011D2B6
		public Cer Cer
		{
			get
			{
				return this._cer;
			}
		}

		// Token: 0x04002431 RID: 9265
		private Consistency _consistency;

		// Token: 0x04002432 RID: 9266
		private Cer _cer;
	}
}
