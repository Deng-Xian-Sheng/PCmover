using System;

namespace CefSharp.OffScreen
{
	// Token: 0x02000003 RID: 3
	public class CefSettings : CefSettingsBase
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002224 File Offset: 0x00000424
		public CefSettings()
		{
			base.WindowlessRenderingEnabled = true;
			base.CefCommandLineArgs.Add("mute-audio");
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002243 File Offset: 0x00000443
		public void EnableAudio()
		{
			if (base.CefCommandLineArgs.ContainsKey("mute-audio"))
			{
				base.CefCommandLineArgs.Remove("mute-audio");
			}
		}
	}
}
