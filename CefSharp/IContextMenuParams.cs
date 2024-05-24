using System;
using System.Collections.Generic;

namespace CefSharp
{
	// Token: 0x02000068 RID: 104
	public interface IContextMenuParams : IDisposable
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000225 RID: 549
		int YCoord { get; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000226 RID: 550
		int XCoord { get; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000227 RID: 551
		ContextMenuType TypeFlags { get; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000228 RID: 552
		string LinkUrl { get; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000229 RID: 553
		string UnfilteredLinkUrl { get; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600022A RID: 554
		string SourceUrl { get; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600022B RID: 555
		bool HasImageContents { get; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x0600022C RID: 556
		string PageUrl { get; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600022D RID: 557
		string FrameUrl { get; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600022E RID: 558
		string FrameCharset { get; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600022F RID: 559
		ContextMenuMediaType MediaType { get; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000230 RID: 560
		ContextMenuMediaState MediaStateFlags { get; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000231 RID: 561
		string SelectionText { get; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000232 RID: 562
		string MisspelledWord { get; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000233 RID: 563
		List<string> DictionarySuggestions { get; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000234 RID: 564
		bool IsEditable { get; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000235 RID: 565
		bool IsSpellCheckEnabled { get; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000236 RID: 566
		ContextMenuEditState EditStateFlags { get; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000237 RID: 567
		bool IsCustomMenu { get; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000238 RID: 568
		bool IsDisposed { get; }
	}
}
