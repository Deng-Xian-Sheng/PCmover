using System;
using CefSharp.Enums;

namespace CefSharp.Structs
{
	// Token: 0x020000A3 RID: 163
	public struct AudioParameters
	{
		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x00008084 File Offset: 0x00006284
		// (set) Token: 0x06000502 RID: 1282 RVA: 0x0000808C File Offset: 0x0000628C
		public ChannelLayout ChannelLayout { get; set; }

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000503 RID: 1283 RVA: 0x00008095 File Offset: 0x00006295
		// (set) Token: 0x06000504 RID: 1284 RVA: 0x0000809D File Offset: 0x0000629D
		public int SampleRate { get; set; }

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x000080A6 File Offset: 0x000062A6
		// (set) Token: 0x06000506 RID: 1286 RVA: 0x000080AE File Offset: 0x000062AE
		public int FramesPerBuffer { get; set; }

		// Token: 0x06000507 RID: 1287 RVA: 0x000080B7 File Offset: 0x000062B7
		public AudioParameters(ChannelLayout channelLayout, int sampleRate, int framesPerBuffer)
		{
			this.ChannelLayout = channelLayout;
			this.SampleRate = sampleRate;
			this.FramesPerBuffer = framesPerBuffer;
		}
	}
}
