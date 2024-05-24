using System;

namespace System.Runtime.InteropServices.TCEAdapterGen
{
	// Token: 0x020009C3 RID: 2499
	internal static class NameSpaceExtractor
	{
		// Token: 0x060063B0 RID: 25520 RVA: 0x001544C0 File Offset: 0x001526C0
		public static string ExtractNameSpace(string FullyQualifiedTypeName)
		{
			int num = FullyQualifiedTypeName.LastIndexOf(NameSpaceExtractor.NameSpaceSeperator);
			if (num == -1)
			{
				return "";
			}
			return FullyQualifiedTypeName.Substring(0, num);
		}

		// Token: 0x04002CCE RID: 11470
		private static char NameSpaceSeperator = '.';
	}
}
