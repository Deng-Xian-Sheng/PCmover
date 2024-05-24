using System;
using PCmover.Infrastructure.Properties;
using Prism.Mvvm;

namespace PCmover.Infrastructure
{
	// Token: 0x0200003B RID: 59
	public class UIDrivePair : BindableBase
	{
		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060002EF RID: 751 RVA: 0x00008364 File Offset: 0x00006564
		// (set) Token: 0x060002F0 RID: 752 RVA: 0x0000836C File Offset: 0x0000656C
		public bool Selected
		{
			get
			{
				return this._Selected;
			}
			set
			{
				this.SetProperty<bool>(ref this._Selected, value, "Selected");
				this.DriveIncludedText = (this._Selected ? Resources.SAdv_Included : Resources.SAdv_Excluded);
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x0000839B File Offset: 0x0000659B
		// (set) Token: 0x060002F2 RID: 754 RVA: 0x000083A3 File Offset: 0x000065A3
		public string DriveIncludedText
		{
			get
			{
				return this._DriveIncludedText;
			}
			set
			{
				this.SetProperty<string>(ref this._DriveIncludedText, value, "DriveIncludedText");
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060002F3 RID: 755 RVA: 0x000083B8 File Offset: 0x000065B8
		// (set) Token: 0x060002F4 RID: 756 RVA: 0x000083C0 File Offset: 0x000065C0
		public bool ShowChange
		{
			get
			{
				return this._ShowChange;
			}
			set
			{
				this.SetProperty<bool>(ref this._ShowChange, value, "ShowChange");
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x000083D5 File Offset: 0x000065D5
		// (set) Token: 0x060002F6 RID: 758 RVA: 0x000083DD File Offset: 0x000065DD
		public string OldDrive { get; set; }

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x000083E6 File Offset: 0x000065E6
		// (set) Token: 0x060002F8 RID: 760 RVA: 0x000083EE File Offset: 0x000065EE
		public string NewDrive { get; set; }

		// Token: 0x04000111 RID: 273
		private bool _Selected;

		// Token: 0x04000112 RID: 274
		private string _DriveIncludedText;

		// Token: 0x04000113 RID: 275
		private bool _ShowChange;
	}
}
