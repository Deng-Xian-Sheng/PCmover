using System;
using Microsoft.WindowsAPICodePack.Resources;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000058 RID: 88
	public class TaskDialogProgressBar : TaskDialogBar
	{
		// Token: 0x0600026F RID: 623 RVA: 0x00008D50 File Offset: 0x00006F50
		public TaskDialogProgressBar()
		{
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00008D63 File Offset: 0x00006F63
		public TaskDialogProgressBar(string name) : base(name)
		{
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00008D77 File Offset: 0x00006F77
		public TaskDialogProgressBar(int minimum, int maximum, int value)
		{
			this.Minimum = minimum;
			this.Maximum = maximum;
			this.Value = value;
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000272 RID: 626 RVA: 0x00008DA4 File Offset: 0x00006FA4
		// (set) Token: 0x06000273 RID: 627 RVA: 0x00008DBC File Offset: 0x00006FBC
		public int Minimum
		{
			get
			{
				return this._minimum;
			}
			set
			{
				base.CheckPropertyChangeAllowed("Minimum");
				if (value < 0)
				{
					throw new ArgumentException(LocalizedMessages.TaskDialogProgressBarMinValueGreaterThanZero, "value");
				}
				if (value >= this.Maximum)
				{
					throw new ArgumentException(LocalizedMessages.TaskDialogProgressBarMinValueLessThanMax, "value");
				}
				this._minimum = value;
				base.ApplyPropertyChange("Minimum");
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06000274 RID: 628 RVA: 0x00008E24 File Offset: 0x00007024
		// (set) Token: 0x06000275 RID: 629 RVA: 0x00008E3C File Offset: 0x0000703C
		public int Maximum
		{
			get
			{
				return this._maximum;
			}
			set
			{
				base.CheckPropertyChangeAllowed("Maximum");
				if (value < this.Minimum)
				{
					throw new ArgumentException(LocalizedMessages.TaskDialogProgressBarMaxValueGreaterThanMin, "value");
				}
				this._maximum = value;
				base.ApplyPropertyChange("Maximum");
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06000276 RID: 630 RVA: 0x00008E8C File Offset: 0x0000708C
		// (set) Token: 0x06000277 RID: 631 RVA: 0x00008EA4 File Offset: 0x000070A4
		public int Value
		{
			get
			{
				return this._value;
			}
			set
			{
				base.CheckPropertyChangeAllowed("Value");
				if (value < this.Minimum || value > this.Maximum)
				{
					throw new ArgumentException(LocalizedMessages.TaskDialogProgressBarValueInRange, "value");
				}
				this._value = value;
				base.ApplyPropertyChange("Value");
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000278 RID: 632 RVA: 0x00008F00 File Offset: 0x00007100
		internal bool HasValidValues
		{
			get
			{
				return this._minimum <= this._value && this._value <= this._maximum;
			}
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00008F35 File Offset: 0x00007135
		protected internal override void Reset()
		{
			base.Reset();
			this._value = this._minimum;
		}

		// Token: 0x0400029E RID: 670
		private int _minimum;

		// Token: 0x0400029F RID: 671
		private int _value;

		// Token: 0x040002A0 RID: 672
		private int _maximum = 100;
	}
}
