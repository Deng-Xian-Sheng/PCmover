using System;

namespace ceTe.DynamicPDF
{
	// Token: 0x02000662 RID: 1634
	public class GeneratorException : Exception
	{
		// Token: 0x06003DCD RID: 15821 RVA: 0x00216BAF File Offset: 0x00215BAF
		public GeneratorException(string message) : base(message)
		{
		}

		// Token: 0x06003DCE RID: 15822 RVA: 0x00216BBB File Offset: 0x00215BBB
		internal GeneratorException(string A_0, Exception A_1) : base(A_0, A_1)
		{
		}
	}
}
