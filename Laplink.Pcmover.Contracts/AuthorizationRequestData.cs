using System;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x0200005F RID: 95
	public class AuthorizationRequestData
	{
		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600028F RID: 655 RVA: 0x0000378D File Offset: 0x0000198D
		// (set) Token: 0x06000290 RID: 656 RVA: 0x00003795 File Offset: 0x00001995
		public string SerialNumber { get; set; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000291 RID: 657 RVA: 0x0000379E File Offset: 0x0000199E
		// (set) Token: 0x06000292 RID: 658 RVA: 0x000037A6 File Offset: 0x000019A6
		public string ValidationCode { get; set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000293 RID: 659 RVA: 0x000037AF File Offset: 0x000019AF
		// (set) Token: 0x06000294 RID: 660 RVA: 0x000037B7 File Offset: 0x000019B7
		public string User { get; set; }

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000295 RID: 661 RVA: 0x000037C0 File Offset: 0x000019C0
		// (set) Token: 0x06000296 RID: 662 RVA: 0x000037C8 File Offset: 0x000019C8
		public string Email { get; set; }

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000297 RID: 663 RVA: 0x000037D1 File Offset: 0x000019D1
		// (set) Token: 0x06000298 RID: 664 RVA: 0x000037D9 File Offset: 0x000019D9
		public bool IsSerialNumberFromPolicy { get; set; }

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000299 RID: 665 RVA: 0x000037E2 File Offset: 0x000019E2
		// (set) Token: 0x0600029A RID: 666 RVA: 0x000037EA File Offset: 0x000019EA
		public string PreviousTransferOldMachine { get; set; }

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600029B RID: 667 RVA: 0x000037F3 File Offset: 0x000019F3
		// (set) Token: 0x0600029C RID: 668 RVA: 0x000037FB File Offset: 0x000019FB
		public string PreviousTransferNewMachine { get; set; }

		// Token: 0x0600029D RID: 669 RVA: 0x00002050 File Offset: 0x00000250
		public AuthorizationRequestData()
		{
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00003804 File Offset: 0x00001A04
		public AuthorizationRequestData(AuthorizationRequestData other)
		{
			this.SerialNumber = other.SerialNumber;
			this.ValidationCode = other.ValidationCode;
			this.User = other.User;
			this.Email = other.Email;
			this.IsSerialNumberFromPolicy = other.IsSerialNumberFromPolicy;
			this.PreviousTransferOldMachine = other.PreviousTransferOldMachine;
			this.PreviousTransferNewMachine = other.PreviousTransferNewMachine;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000386C File Offset: 0x00001A6C
		public override string ToString()
		{
			string text;
			if (string.IsNullOrWhiteSpace(this.SerialNumber))
			{
				text = "No serial number";
			}
			else if (this.IsSerialNumberFromPolicy)
			{
				text = "Serial number from Policy";
			}
			else
			{
				text = "Serial number from registry";
			}
			string text2;
			if (string.IsNullOrWhiteSpace(this.ValidationCode))
			{
				text2 = "No validation code";
			}
			else if (this.ValidationCode == this.SerialNumber)
			{
				text2 = "Validation code same as serial number";
			}
			else
			{
				text2 = "Validation code from registry";
			}
			string text3;
			if (string.IsNullOrEmpty(this.PreviousTransferNewMachine))
			{
				text3 = string.Empty;
			}
			else
			{
				text3 = " Old: " + this.PreviousTransferOldMachine + " New: " + this.PreviousTransferNewMachine;
			}
			return string.Concat(new string[]
			{
				text,
				", ",
				text2,
				", User: ",
				this.User,
				", Email: ",
				this.Email,
				text3
			});
		}
	}
}
