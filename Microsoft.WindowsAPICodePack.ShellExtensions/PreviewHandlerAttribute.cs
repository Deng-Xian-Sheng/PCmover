using System;

namespace Microsoft.WindowsAPICodePack.ShellExtensions
{
	// Token: 0x0200000D RID: 13
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class PreviewHandlerAttribute : Attribute
	{
		// Token: 0x06000039 RID: 57 RVA: 0x000029D4 File Offset: 0x00000BD4
		public PreviewHandlerAttribute(string name, string extensions, string appId)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (extensions == null)
			{
				throw new ArgumentNullException("extensions");
			}
			if (appId == null)
			{
				throw new ArgumentNullException("appId");
			}
			this.Name = name;
			this.Extensions = extensions;
			this.AppId = appId;
			this.DisableLowILProcessIsolation = false;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002A4C File Offset: 0x00000C4C
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00002A63 File Offset: 0x00000C63
		public string Name { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002A6C File Offset: 0x00000C6C
		// (set) Token: 0x0600003D RID: 61 RVA: 0x00002A83 File Offset: 0x00000C83
		public string Extensions { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002A8C File Offset: 0x00000C8C
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00002AA3 File Offset: 0x00000CA3
		public string AppId { get; private set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002AAC File Offset: 0x00000CAC
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00002AC3 File Offset: 0x00000CC3
		public bool DisableLowILProcessIsolation { get; set; }
	}
}
