using System;
using System.ComponentModel;

namespace CefSharp
{
	// Token: 0x02000066 RID: 102
	public interface IBrowserSettings : IDisposable
	{
		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001D8 RID: 472
		// (set) Token: 0x060001D9 RID: 473
		string StandardFontFamily { get; set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001DA RID: 474
		// (set) Token: 0x060001DB RID: 475
		string FixedFontFamily { get; set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001DC RID: 476
		// (set) Token: 0x060001DD RID: 477
		string SerifFontFamily { get; set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001DE RID: 478
		// (set) Token: 0x060001DF RID: 479
		string SansSerifFontFamily { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001E0 RID: 480
		// (set) Token: 0x060001E1 RID: 481
		string CursiveFontFamily { get; set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001E2 RID: 482
		// (set) Token: 0x060001E3 RID: 483
		string FantasyFontFamily { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001E4 RID: 484
		// (set) Token: 0x060001E5 RID: 485
		int DefaultFontSize { get; set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001E6 RID: 486
		// (set) Token: 0x060001E7 RID: 487
		int DefaultFixedFontSize { get; set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001E8 RID: 488
		// (set) Token: 0x060001E9 RID: 489
		int MinimumFontSize { get; set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001EA RID: 490
		// (set) Token: 0x060001EB RID: 491
		int MinimumLogicalFontSize { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060001EC RID: 492
		// (set) Token: 0x060001ED RID: 493
		string DefaultEncoding { get; set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060001EE RID: 494
		// (set) Token: 0x060001EF RID: 495
		CefState RemoteFonts { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060001F0 RID: 496
		// (set) Token: 0x060001F1 RID: 497
		CefState Javascript { get; set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060001F2 RID: 498
		// (set) Token: 0x060001F3 RID: 499
		CefState JavascriptCloseWindows { get; set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060001F4 RID: 500
		// (set) Token: 0x060001F5 RID: 501
		CefState JavascriptAccessClipboard { get; set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060001F6 RID: 502
		// (set) Token: 0x060001F7 RID: 503
		CefState JavascriptDomPaste { get; set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060001F8 RID: 504
		// (set) Token: 0x060001F9 RID: 505
		CefState ImageLoading { get; set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060001FA RID: 506
		// (set) Token: 0x060001FB RID: 507
		CefState ImageShrinkStandaloneToFit { get; set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060001FC RID: 508
		// (set) Token: 0x060001FD RID: 509
		CefState TextAreaResize { get; set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060001FE RID: 510
		// (set) Token: 0x060001FF RID: 511
		CefState TabToLinks { get; set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000200 RID: 512
		// (set) Token: 0x06000201 RID: 513
		CefState LocalStorage { get; set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000202 RID: 514
		// (set) Token: 0x06000203 RID: 515
		CefState Databases { get; set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000204 RID: 516
		// (set) Token: 0x06000205 RID: 517
		CefState WebGl { get; set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000206 RID: 518
		// (set) Token: 0x06000207 RID: 519
		uint BackgroundColor { get; set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000208 RID: 520
		// (set) Token: 0x06000209 RID: 521
		string AcceptLanguageList { get; set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600020A RID: 522
		// (set) Token: 0x0600020B RID: 523
		int WindowlessFrameRate { get; set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600020C RID: 524
		bool IsDisposed { get; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600020D RID: 525
		bool AutoDispose { get; }

		// Token: 0x0600020E RID: 526
		[EditorBrowsable(EditorBrowsableState.Never)]
		IBrowserSettings UnWrap();
	}
}
