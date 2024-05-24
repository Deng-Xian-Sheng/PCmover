using System;
using System.Diagnostics;
using System.Windows;

namespace MahApps.Metro
{
	// Token: 0x02000006 RID: 6
	[DebuggerDisplay("apptheme={Name}, res={Resources.Source}")]
	public class AppTheme
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000021A0 File Offset: 0x000003A0
		public ResourceDictionary Resources { get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000021A8 File Offset: 0x000003A8
		public string Name { get; }

		// Token: 0x06000015 RID: 21 RVA: 0x000021B0 File Offset: 0x000003B0
		public AppTheme(string name, Uri resourceAddress)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (resourceAddress == null)
			{
				throw new ArgumentNullException("resourceAddress");
			}
			this.Name = name;
			this.Resources = new ResourceDictionary
			{
				Source = resourceAddress
			};
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000021FE File Offset: 0x000003FE
		public AppTheme(string name, ResourceDictionary resourceDictionary)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (resourceDictionary == null)
			{
				throw new ArgumentNullException("resourceDictionary");
			}
			this.Name = name;
			this.Resources = resourceDictionary;
		}
	}
}
