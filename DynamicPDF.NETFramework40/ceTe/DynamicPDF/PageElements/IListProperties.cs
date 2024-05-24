using System;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x0200072C RID: 1836
	public interface IListProperties
	{
		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x0600492E RID: 18734
		Font Font { get; }

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x0600492F RID: 18735
		float FontSize { get; }

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06004930 RID: 18736
		float Leading { get; }

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06004931 RID: 18737
		float RightIndent { get; }

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06004932 RID: 18738
		float LeftIndent { get; }

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06004933 RID: 18739
		TextAlign TextAlign { get; }

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06004934 RID: 18740
		Color TextColor { get; }

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06004935 RID: 18741
		Color TextOutlineColor { get; }

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06004936 RID: 18742
		float TextOutlineWidth { get; }

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06004937 RID: 18743
		Align BulletAlign { get; }

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06004938 RID: 18744
		int Level { get; }

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06004939 RID: 18745
		float ParagraphIndent { get; }

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x0600493A RID: 18746
		float BulletAreaWidth { get; }

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x0600493B RID: 18747
		bool StrikeThrough { get; }

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x0600493C RID: 18748
		bool RightToLeft { get; }

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x0600493D RID: 18749
		float BulletSize { get; }

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x0600493E RID: 18750
		float ListItemTopMargin { get; }

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x0600493F RID: 18751
		float ListItemBottomMargin { get; }

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x06004940 RID: 18752
		string BulletSuffix { get; }

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06004941 RID: 18753
		string BulletPrefix { get; }

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06004942 RID: 18754
		NumberingStyle BulletType { get; }
	}
}
