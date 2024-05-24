using System;
using CefSharp.Enums;

namespace CefSharp.Structs
{
	// Token: 0x020000A4 RID: 164
	public struct CompositionUnderline
	{
		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x000080CE File Offset: 0x000062CE
		// (set) Token: 0x06000509 RID: 1289 RVA: 0x000080D6 File Offset: 0x000062D6
		public Range Range { get; private set; }

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x000080DF File Offset: 0x000062DF
		// (set) Token: 0x0600050B RID: 1291 RVA: 0x000080E7 File Offset: 0x000062E7
		public uint Color { get; private set; }

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x000080F0 File Offset: 0x000062F0
		// (set) Token: 0x0600050D RID: 1293 RVA: 0x000080F8 File Offset: 0x000062F8
		public uint BackgroundColor { get; private set; }

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x00008101 File Offset: 0x00006301
		// (set) Token: 0x0600050F RID: 1295 RVA: 0x00008109 File Offset: 0x00006309
		public bool Thick { get; private set; }

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000510 RID: 1296 RVA: 0x00008112 File Offset: 0x00006312
		// (set) Token: 0x06000511 RID: 1297 RVA: 0x0000811A File Offset: 0x0000631A
		public CompositionUnderlineStyle Style { get; private set; }

		// Token: 0x06000512 RID: 1298 RVA: 0x00008123 File Offset: 0x00006323
		public CompositionUnderline(Range range, uint color, uint backGroundColor, bool thick)
		{
			this = default(CompositionUnderline);
			this.Range = range;
			this.Color = color;
			this.BackgroundColor = backGroundColor;
			this.Thick = thick;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00008149 File Offset: 0x00006349
		public CompositionUnderline(Range range, uint color, uint backGroundColor, bool thick, CompositionUnderlineStyle style)
		{
			this = default(CompositionUnderline);
			this.Range = range;
			this.Color = color;
			this.BackgroundColor = backGroundColor;
			this.Thick = thick;
			this.Style = style;
		}
	}
}
