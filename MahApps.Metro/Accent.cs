using System;
using System.Diagnostics;
using System.Windows;

namespace MahApps.Metro
{
	// Token: 0x02000004 RID: 4
	[DebuggerDisplay("accent={Name}, res={Resources.Source}")]
	public class Accent
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020EB File Offset: 0x000002EB
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020F3 File Offset: 0x000002F3
		public ResourceDictionary Resources { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000020FC File Offset: 0x000002FC
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00002104 File Offset: 0x00000304
		public string Name { get; set; }

		// Token: 0x0600000F RID: 15 RVA: 0x0000210D File Offset: 0x0000030D
		public Accent()
		{
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002118 File Offset: 0x00000318
		public Accent(string name, Uri resourceAddress)
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

		// Token: 0x06000011 RID: 17 RVA: 0x00002166 File Offset: 0x00000366
		public Accent(string name, ResourceDictionary resourceDictionary)
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
