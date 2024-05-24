using System;
using System.ComponentModel;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006E5 RID: 1765
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("This class is obsolete. Refer ceTe.DynamicPDF.Document.Form.Output and ceTe.DynamicPDF.Document.Form.SignatureFieldsOutput properties for more details.", false)]
	public class FormFlatteningOptions
	{
		// Token: 0x170003AC RID: 940
		// (get) Token: 0x0600443C RID: 17468 RVA: 0x00233480 File Offset: 0x00232480
		// (set) Token: 0x0600443D RID: 17469 RVA: 0x00233498 File Offset: 0x00232498
		public SignatureFieldFlatteningOptions DigitalSignatures
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x0600443E RID: 17470 RVA: 0x002334A4 File Offset: 0x002324A4
		public static FormFlatteningOptions Default
		{
			get
			{
				return new FormFlatteningOptions();
			}
		}

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x0600443F RID: 17471 RVA: 0x002334BC File Offset: 0x002324BC
		public static FormFlatteningOptions RetainDigitalSignatures
		{
			get
			{
				return new FormFlatteningOptions
				{
					DigitalSignatures = SignatureFieldFlatteningOptions.Retain
				};
			}
		}

		// Token: 0x0400260E RID: 9742
		private SignatureFieldFlatteningOptions a = SignatureFieldFlatteningOptions.Remove;
	}
}
