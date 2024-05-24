using System;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x0200077B RID: 1915
	internal sealed class ObjectMapInfo
	{
		// Token: 0x060053AD RID: 21421 RVA: 0x0012685D File Offset: 0x00124A5D
		internal ObjectMapInfo(int objectId, int numMembers, string[] memberNames, Type[] memberTypes)
		{
			this.objectId = objectId;
			this.numMembers = numMembers;
			this.memberNames = memberNames;
			this.memberTypes = memberTypes;
		}

		// Token: 0x060053AE RID: 21422 RVA: 0x00126884 File Offset: 0x00124A84
		internal bool isCompatible(int numMembers, string[] memberNames, Type[] memberTypes)
		{
			bool result = true;
			if (this.numMembers == numMembers)
			{
				for (int i = 0; i < numMembers; i++)
				{
					if (!this.memberNames[i].Equals(memberNames[i]))
					{
						result = false;
						break;
					}
					if (memberTypes != null && this.memberTypes[i] != memberTypes[i])
					{
						result = false;
						break;
					}
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x040025AD RID: 9645
		internal int objectId;

		// Token: 0x040025AE RID: 9646
		private int numMembers;

		// Token: 0x040025AF RID: 9647
		private string[] memberNames;

		// Token: 0x040025B0 RID: 9648
		private Type[] memberTypes;
	}
}
