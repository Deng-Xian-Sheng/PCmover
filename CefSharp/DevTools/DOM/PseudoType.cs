using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200037E RID: 894
	public enum PseudoType
	{
		// Token: 0x04000E51 RID: 3665
		[EnumMember(Value = "first-line")]
		FirstLine,
		// Token: 0x04000E52 RID: 3666
		[EnumMember(Value = "first-letter")]
		FirstLetter,
		// Token: 0x04000E53 RID: 3667
		[EnumMember(Value = "before")]
		Before,
		// Token: 0x04000E54 RID: 3668
		[EnumMember(Value = "after")]
		After,
		// Token: 0x04000E55 RID: 3669
		[EnumMember(Value = "marker")]
		Marker,
		// Token: 0x04000E56 RID: 3670
		[EnumMember(Value = "backdrop")]
		Backdrop,
		// Token: 0x04000E57 RID: 3671
		[EnumMember(Value = "selection")]
		Selection,
		// Token: 0x04000E58 RID: 3672
		[EnumMember(Value = "target-text")]
		TargetText,
		// Token: 0x04000E59 RID: 3673
		[EnumMember(Value = "spelling-error")]
		SpellingError,
		// Token: 0x04000E5A RID: 3674
		[EnumMember(Value = "grammar-error")]
		GrammarError,
		// Token: 0x04000E5B RID: 3675
		[EnumMember(Value = "highlight")]
		Highlight,
		// Token: 0x04000E5C RID: 3676
		[EnumMember(Value = "first-line-inherited")]
		FirstLineInherited,
		// Token: 0x04000E5D RID: 3677
		[EnumMember(Value = "scrollbar")]
		Scrollbar,
		// Token: 0x04000E5E RID: 3678
		[EnumMember(Value = "scrollbar-thumb")]
		ScrollbarThumb,
		// Token: 0x04000E5F RID: 3679
		[EnumMember(Value = "scrollbar-button")]
		ScrollbarButton,
		// Token: 0x04000E60 RID: 3680
		[EnumMember(Value = "scrollbar-track")]
		ScrollbarTrack,
		// Token: 0x04000E61 RID: 3681
		[EnumMember(Value = "scrollbar-track-piece")]
		ScrollbarTrackPiece,
		// Token: 0x04000E62 RID: 3682
		[EnumMember(Value = "scrollbar-corner")]
		ScrollbarCorner,
		// Token: 0x04000E63 RID: 3683
		[EnumMember(Value = "resizer")]
		Resizer,
		// Token: 0x04000E64 RID: 3684
		[EnumMember(Value = "input-list-button")]
		InputListButton,
		// Token: 0x04000E65 RID: 3685
		[EnumMember(Value = "transition")]
		Transition,
		// Token: 0x04000E66 RID: 3686
		[EnumMember(Value = "transition-container")]
		TransitionContainer,
		// Token: 0x04000E67 RID: 3687
		[EnumMember(Value = "transition-old-content")]
		TransitionOldContent,
		// Token: 0x04000E68 RID: 3688
		[EnumMember(Value = "transition-new-content")]
		TransitionNewContent
	}
}
