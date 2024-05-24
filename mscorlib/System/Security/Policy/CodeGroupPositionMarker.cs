using System;

namespace System.Security.Policy
{
	// Token: 0x0200034B RID: 843
	internal class CodeGroupPositionMarker
	{
		// Token: 0x060029F5 RID: 10741 RVA: 0x0009B4A4 File Offset: 0x000996A4
		internal CodeGroupPositionMarker(int elementIndex, int groupIndex, SecurityElement element)
		{
			this.elementIndex = elementIndex;
			this.groupIndex = groupIndex;
			this.element = element;
		}

		// Token: 0x04001127 RID: 4391
		internal int elementIndex;

		// Token: 0x04001128 RID: 4392
		internal int groupIndex;

		// Token: 0x04001129 RID: 4393
		internal SecurityElement element;
	}
}
