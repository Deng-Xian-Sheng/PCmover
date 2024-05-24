using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace System.Resources
{
	// Token: 0x0200038C RID: 908
	internal interface IResourceGroveler
	{
		// Token: 0x06002CE7 RID: 11495
		ResourceSet GrovelForResourceSet(CultureInfo culture, Dictionary<string, ResourceSet> localResourceSets, bool tryParents, bool createIfNotExists, ref StackCrawlMark stackMark);

		// Token: 0x06002CE8 RID: 11496
		bool HasNeutralResources(CultureInfo culture, string defaultResName);
	}
}
