using System;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000034 RID: 52
	public class ValidationCodeTransfer : ValidationCode
	{
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000262 RID: 610 RVA: 0x00011438 File Offset: 0x0000F638
		// (set) Token: 0x06000263 RID: 611 RVA: 0x000114A8 File Offset: 0x0000F6A8
		public string ValidationCode
		{
			get
			{
				if (this._validationCode == null)
				{
					string text = this.TransferId.ToString();
					uint num;
					Laplink.Pcmover.Service.ValidationCode.GetCheckDigit(text, out num);
					this._validationCode = string.Format("{0}{1}-{2}-{3}{4}", new object[]
					{
						"VC2",
						this.EditionString,
						this.EncodedCode,
						text,
						num
					});
				}
				return this._validationCode;
			}
			set
			{
				if (value != null && value != this._validationCode)
				{
					this._validationCode = value.ToUpper();
					this.EvaluateValidationCode();
				}
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000264 RID: 612 RVA: 0x000114CD File Offset: 0x0000F6CD
		// (set) Token: 0x06000265 RID: 613 RVA: 0x000114D5 File Offset: 0x0000F6D5
		public uint TransferId
		{
			get
			{
				return this._transferId;
			}
			set
			{
				if (this._transferId != value)
				{
					this._transferId = value;
					this._validationCode = null;
				}
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000266 RID: 614 RVA: 0x000114EE File Offset: 0x0000F6EE
		// (set) Token: 0x06000267 RID: 615 RVA: 0x000114F8 File Offset: 0x0000F6F8
		public string EditionString
		{
			get
			{
				return this._editionString;
			}
			set
			{
				if (value != null)
				{
					string text = value.ToUpper();
					if (this._editionString != text)
					{
						this._editionString = text;
						this._validationCode = null;
					}
				}
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000268 RID: 616 RVA: 0x0001152B File Offset: 0x0000F72B
		// (set) Token: 0x06000269 RID: 617 RVA: 0x00011534 File Offset: 0x0000F734
		public string SrcNetName
		{
			get
			{
				return this._srcNetName;
			}
			set
			{
				if (value != null)
				{
					string text = value.ToUpper();
					if (this._srcNetName != text)
					{
						this._srcNetName = text;
						this._validationCode = null;
					}
				}
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600026A RID: 618 RVA: 0x00011567 File Offset: 0x0000F767
		// (set) Token: 0x0600026B RID: 619 RVA: 0x00011570 File Offset: 0x0000F770
		public uint SrcSessionCode
		{
			get
			{
				return this._srcSessionCode;
			}
			set
			{
				uint num = value % 100U;
				if (this._srcSessionCode != num)
				{
					this._srcSessionCode = num;
					this._validationCode = null;
				}
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600026C RID: 620 RVA: 0x00011599 File Offset: 0x0000F799
		// (set) Token: 0x0600026D RID: 621 RVA: 0x000115A4 File Offset: 0x0000F7A4
		public string DstNetName
		{
			get
			{
				return this._dstNetName;
			}
			set
			{
				if (value != null)
				{
					string text = value.ToUpper();
					if (this._dstNetName != text)
					{
						this._dstNetName = text;
						this._validationCode = null;
					}
				}
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600026E RID: 622 RVA: 0x000115D7 File Offset: 0x0000F7D7
		// (set) Token: 0x0600026F RID: 623 RVA: 0x000115E0 File Offset: 0x0000F7E0
		public uint DstSessionCode
		{
			get
			{
				return this._dstSessionCode;
			}
			set
			{
				uint num = value % 100U;
				if (this._dstSessionCode != num)
				{
					this._dstSessionCode = num;
					this._validationCode = null;
				}
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000270 RID: 624 RVA: 0x0001160C File Offset: 0x0000F80C
		private string EncodedCode
		{
			get
			{
				uint num = Laplink.Pcmover.Service.ValidationCode.CalcChecksum(this.EditionString + this.SrcNetName) * (this.DstSessionCode + 1U);
				uint num2 = Laplink.Pcmover.Service.ValidationCode.CalcChecksum(this.DstNetName) * (this.SrcSessionCode + 1U);
				return Laplink.Pcmover.Service.ValidationCode.CreateVcCode(((num & 65535U) << 16) + (num2 & 65535U));
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00011664 File Offset: 0x0000F864
		public static bool LooksLikeCode(string code)
		{
			return code.Length >= "VC2".Length + 1 + 1 + 7 + 1 + 1 + 1 && code.ToUpper().Substring(0, "VC2".Length) == "VC2";
		}

		// Token: 0x06000272 RID: 626 RVA: 0x000116B4 File Offset: 0x0000F8B4
		public ValidationCodeTransfer(string editionString, string srcNetName, uint srcSessionCode, string dstNetName, uint dstSessionCode)
		{
			this.EditionString = editionString;
			this.SrcNetName = srcNetName;
			this.SrcSessionCode = srcSessionCode;
			this.DstNetName = dstNetName;
			this.DstSessionCode = dstSessionCode;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00011710 File Offset: 0x0000F910
		private void EvaluateValidationCode()
		{
			this._transferId = 0U;
			if (this.ValidationCode.Length < "VC2".Length + this.EditionString.Length + 1 + 7 + 1 + 1 + 1)
			{
				return;
			}
			int num = 0;
			if (this.ValidationCode.Substring(num, "VC2".Length) != "VC2")
			{
				return;
			}
			num += "VC2".Length;
			if (this.ValidationCode.Substring(num, this.EditionString.Length) != this.EditionString)
			{
				return;
			}
			num += this.EditionString.Length;
			if (this.ValidationCode[num] != '-')
			{
				return;
			}
			num++;
			if (this.ValidationCode.Substring(num, 7) != this.EncodedCode)
			{
				return;
			}
			num += 7;
			if (this.ValidationCode[num] != '-')
			{
				return;
			}
			num++;
			string text = this.ValidationCode.Substring(num);
			string text2 = text.Substring(0, text.Length - 1);
			string s = text.Substring(text.Length - 1);
			uint transferId;
			if (!uint.TryParse(text2, out transferId))
			{
				return;
			}
			uint num2;
			if (!uint.TryParse(s, out num2))
			{
				return;
			}
			uint num3;
			if (!Laplink.Pcmover.Service.ValidationCode.GetCheckDigit(text2, out num3))
			{
				return;
			}
			if (num3 == num2)
			{
				this._transferId = transferId;
			}
		}

		// Token: 0x040000C8 RID: 200
		private const string PREFIX = "VC2";

		// Token: 0x040000C9 RID: 201
		public const uint INVALID_TRANSFER_ID = 0U;

		// Token: 0x040000CA RID: 202
		public const uint INVALID_SESSION_CODE = 100U;

		// Token: 0x040000CB RID: 203
		private string _validationCode;

		// Token: 0x040000CC RID: 204
		private uint _transferId;

		// Token: 0x040000CD RID: 205
		private string _editionString = "";

		// Token: 0x040000CE RID: 206
		private string _srcNetName = "";

		// Token: 0x040000CF RID: 207
		private uint _srcSessionCode;

		// Token: 0x040000D0 RID: 208
		private string _dstNetName = "";

		// Token: 0x040000D1 RID: 209
		private uint _dstSessionCode;
	}
}
