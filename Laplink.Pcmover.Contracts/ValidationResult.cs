using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000062 RID: 98
	public class ValidationResult : AuthorizationInfo
	{
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060002AD RID: 685 RVA: 0x000039B2 File Offset: 0x00001BB2
		// (set) Token: 0x060002AE RID: 686 RVA: 0x000039BA File Offset: 0x00001BBA
		public ulong UseId { get; set; }

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060002AF RID: 687 RVA: 0x000039C3 File Offset: 0x00001BC3
		// (set) Token: 0x060002B0 RID: 688 RVA: 0x000039CB File Offset: 0x00001BCB
		public string Message { get; set; }

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x000039D4 File Offset: 0x00001BD4
		// (set) Token: 0x060002B2 RID: 690 RVA: 0x000039DC File Offset: 0x00001BDC
		public ValidationErrorCode ErrorCode { get; set; }

		// Token: 0x060002B3 RID: 691 RVA: 0x000039E5 File Offset: 0x00001BE5
		public void SetErrorCode(uint uintErrorCode)
		{
			if (uintErrorCode == 0U)
			{
				this.ErrorCode = ValidationErrorCode.Internet;
				return;
			}
			if (Enum.IsDefined(typeof(ValidationErrorCode), (int)uintErrorCode))
			{
				this.ErrorCode = (ValidationErrorCode)uintErrorCode;
				return;
			}
			this.ErrorCode = ValidationErrorCode.Generic;
		}
	}
}
