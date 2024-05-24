using System;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
	// Token: 0x0200001E RID: 30
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class ThumbnailProviderAttribute : Attribute
	{
		// Token: 0x060000BC RID: 188 RVA: 0x00004318 File Offset: 0x00002518
		public ThumbnailProviderAttribute(string name, string extensions)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (extensions == null)
			{
				throw new ArgumentNullException("extensions");
			}
			this.Name = name;
			this.Extensions = extensions;
			this.DisableProcessIsolation = false;
			this.ThumbnailCutoff = ThumbnailCutoffSize.Square20;
			this.TypeOverlay = null;
			this.ThumbnailAdornment = ThumbnailAdornment.Default;
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000BD RID: 189 RVA: 0x0000438C File Offset: 0x0000258C
		// (set) Token: 0x060000BE RID: 190 RVA: 0x000043A3 File Offset: 0x000025A3
		public string Name { get; private set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000BF RID: 191 RVA: 0x000043AC File Offset: 0x000025AC
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x000043C3 File Offset: 0x000025C3
		public string Extensions { get; private set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x000043CC File Offset: 0x000025CC
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x000043E3 File Offset: 0x000025E3
		public bool DisableProcessIsolation { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x000043EC File Offset: 0x000025EC
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x00004403 File Offset: 0x00002603
		public ThumbnailCutoffSize ThumbnailCutoff { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x0000440C File Offset: 0x0000260C
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00004423 File Offset: 0x00002623
		public string TypeOverlay { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x0000442C File Offset: 0x0000262C
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x00004443 File Offset: 0x00002643
		public ThumbnailAdornment ThumbnailAdornment { get; set; }
	}
}
