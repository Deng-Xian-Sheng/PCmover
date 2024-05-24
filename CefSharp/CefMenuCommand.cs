using System;

namespace CefSharp
{
	// Token: 0x02000029 RID: 41
	public enum CefMenuCommand
	{
		// Token: 0x04000153 RID: 339
		NotFound = -1,
		// Token: 0x04000154 RID: 340
		Back = 100,
		// Token: 0x04000155 RID: 341
		Forward,
		// Token: 0x04000156 RID: 342
		Reload,
		// Token: 0x04000157 RID: 343
		ReloadNoCache,
		// Token: 0x04000158 RID: 344
		StopLoad,
		// Token: 0x04000159 RID: 345
		Undo = 110,
		// Token: 0x0400015A RID: 346
		Redo,
		// Token: 0x0400015B RID: 347
		Cut,
		// Token: 0x0400015C RID: 348
		Copy,
		// Token: 0x0400015D RID: 349
		Paste,
		// Token: 0x0400015E RID: 350
		Delete,
		// Token: 0x0400015F RID: 351
		SelectAll,
		// Token: 0x04000160 RID: 352
		Find = 130,
		// Token: 0x04000161 RID: 353
		Print,
		// Token: 0x04000162 RID: 354
		ViewSource,
		// Token: 0x04000163 RID: 355
		SpellCheckSuggestion0 = 200,
		// Token: 0x04000164 RID: 356
		SpellCheckSuggestion1,
		// Token: 0x04000165 RID: 357
		SpellCheckSuggestion2,
		// Token: 0x04000166 RID: 358
		SpellCheckSuggestion3,
		// Token: 0x04000167 RID: 359
		SpellCheckSuggestion4,
		// Token: 0x04000168 RID: 360
		SpellCheckLastSuggestion = 204,
		// Token: 0x04000169 RID: 361
		SpellCheckNoSuggestions,
		// Token: 0x0400016A RID: 362
		AddToDictionary,
		// Token: 0x0400016B RID: 363
		CustomFirst = 220,
		// Token: 0x0400016C RID: 364
		CustomLast = 250,
		// Token: 0x0400016D RID: 365
		UserFirst = 26500,
		// Token: 0x0400016E RID: 366
		UserLast = 28500
	}
}
