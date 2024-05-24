using System;
using System.Collections.Generic;
using System.IO;
using CefSharp.Structs;

namespace CefSharp
{
	// Token: 0x0200006B RID: 107
	public interface IDragData : IDisposable
	{
		// Token: 0x06000243 RID: 579
		IDragData Clone();

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000244 RID: 580
		bool IsReadOnly { get; }

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000245 RID: 581
		// (set) Token: 0x06000246 RID: 582
		string FileName { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000247 RID: 583
		IList<string> FileNames { get; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000248 RID: 584
		// (set) Token: 0x06000249 RID: 585
		string FragmentBaseUrl { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600024A RID: 586
		// (set) Token: 0x0600024B RID: 587
		string FragmentHtml { get; set; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600024C RID: 588
		// (set) Token: 0x0600024D RID: 589
		string FragmentText { get; set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600024E RID: 590
		bool HasImage { get; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x0600024F RID: 591
		IImage Image { get; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000250 RID: 592
		Point ImageHotspot { get; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000252 RID: 594
		// (set) Token: 0x06000251 RID: 593
		string LinkMetaData { get; set; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000254 RID: 596
		// (set) Token: 0x06000253 RID: 595
		string LinkTitle { get; set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000256 RID: 598
		// (set) Token: 0x06000255 RID: 597
		string LinkUrl { get; set; }

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000257 RID: 599
		// (set) Token: 0x06000258 RID: 600
		bool IsFile { get; set; }

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000259 RID: 601
		// (set) Token: 0x0600025A RID: 602
		bool IsFragment { get; set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600025B RID: 603
		// (set) Token: 0x0600025C RID: 604
		bool IsLink { get; set; }

		// Token: 0x0600025D RID: 605
		void AddFile(string path, string displayName = null);

		// Token: 0x0600025E RID: 606
		void ResetFileContents();

		// Token: 0x0600025F RID: 607
		long GetFileContents(Stream stream);

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000260 RID: 608
		bool IsDisposed { get; }
	}
}
