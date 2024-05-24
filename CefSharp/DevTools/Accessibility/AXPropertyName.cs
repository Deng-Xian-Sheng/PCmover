using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x02000446 RID: 1094
	public enum AXPropertyName
	{
		// Token: 0x04001147 RID: 4423
		[EnumMember(Value = "busy")]
		Busy,
		// Token: 0x04001148 RID: 4424
		[EnumMember(Value = "disabled")]
		Disabled,
		// Token: 0x04001149 RID: 4425
		[EnumMember(Value = "editable")]
		Editable,
		// Token: 0x0400114A RID: 4426
		[EnumMember(Value = "focusable")]
		Focusable,
		// Token: 0x0400114B RID: 4427
		[EnumMember(Value = "focused")]
		Focused,
		// Token: 0x0400114C RID: 4428
		[EnumMember(Value = "hidden")]
		Hidden,
		// Token: 0x0400114D RID: 4429
		[EnumMember(Value = "hiddenRoot")]
		HiddenRoot,
		// Token: 0x0400114E RID: 4430
		[EnumMember(Value = "invalid")]
		Invalid,
		// Token: 0x0400114F RID: 4431
		[EnumMember(Value = "keyshortcuts")]
		Keyshortcuts,
		// Token: 0x04001150 RID: 4432
		[EnumMember(Value = "settable")]
		Settable,
		// Token: 0x04001151 RID: 4433
		[EnumMember(Value = "roledescription")]
		Roledescription,
		// Token: 0x04001152 RID: 4434
		[EnumMember(Value = "live")]
		Live,
		// Token: 0x04001153 RID: 4435
		[EnumMember(Value = "atomic")]
		Atomic,
		// Token: 0x04001154 RID: 4436
		[EnumMember(Value = "relevant")]
		Relevant,
		// Token: 0x04001155 RID: 4437
		[EnumMember(Value = "root")]
		Root,
		// Token: 0x04001156 RID: 4438
		[EnumMember(Value = "autocomplete")]
		Autocomplete,
		// Token: 0x04001157 RID: 4439
		[EnumMember(Value = "hasPopup")]
		HasPopup,
		// Token: 0x04001158 RID: 4440
		[EnumMember(Value = "level")]
		Level,
		// Token: 0x04001159 RID: 4441
		[EnumMember(Value = "multiselectable")]
		Multiselectable,
		// Token: 0x0400115A RID: 4442
		[EnumMember(Value = "orientation")]
		Orientation,
		// Token: 0x0400115B RID: 4443
		[EnumMember(Value = "multiline")]
		Multiline,
		// Token: 0x0400115C RID: 4444
		[EnumMember(Value = "readonly")]
		Readonly,
		// Token: 0x0400115D RID: 4445
		[EnumMember(Value = "required")]
		Required,
		// Token: 0x0400115E RID: 4446
		[EnumMember(Value = "valuemin")]
		Valuemin,
		// Token: 0x0400115F RID: 4447
		[EnumMember(Value = "valuemax")]
		Valuemax,
		// Token: 0x04001160 RID: 4448
		[EnumMember(Value = "valuetext")]
		Valuetext,
		// Token: 0x04001161 RID: 4449
		[EnumMember(Value = "checked")]
		Checked,
		// Token: 0x04001162 RID: 4450
		[EnumMember(Value = "expanded")]
		Expanded,
		// Token: 0x04001163 RID: 4451
		[EnumMember(Value = "modal")]
		Modal,
		// Token: 0x04001164 RID: 4452
		[EnumMember(Value = "pressed")]
		Pressed,
		// Token: 0x04001165 RID: 4453
		[EnumMember(Value = "selected")]
		Selected,
		// Token: 0x04001166 RID: 4454
		[EnumMember(Value = "activedescendant")]
		Activedescendant,
		// Token: 0x04001167 RID: 4455
		[EnumMember(Value = "controls")]
		Controls,
		// Token: 0x04001168 RID: 4456
		[EnumMember(Value = "describedby")]
		Describedby,
		// Token: 0x04001169 RID: 4457
		[EnumMember(Value = "details")]
		Details,
		// Token: 0x0400116A RID: 4458
		[EnumMember(Value = "errormessage")]
		Errormessage,
		// Token: 0x0400116B RID: 4459
		[EnumMember(Value = "flowto")]
		Flowto,
		// Token: 0x0400116C RID: 4460
		[EnumMember(Value = "labelledby")]
		Labelledby,
		// Token: 0x0400116D RID: 4461
		[EnumMember(Value = "owns")]
		Owns
	}
}
