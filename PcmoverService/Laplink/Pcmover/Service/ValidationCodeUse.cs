using System;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000035 RID: 53
	public class ValidationCodeUse : ValidationCode
	{
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000274 RID: 628 RVA: 0x0001185C File Offset: 0x0000FA5C
		// (set) Token: 0x06000275 RID: 629 RVA: 0x000118DF File Offset: 0x0000FADF
		public string ValidationCode
		{
			get
			{
				if (this._recalcValidationCode)
				{
					this._recalcValidationCode = false;
					this._recalcIsValid = false;
					Guid editionGuid = this._editionGuid;
					string text = this.UseId.ToString();
					uint num;
					Laplink.Pcmover.Service.ValidationCode.GetCheckDigit(text, out num);
					this._validationCode = string.Format("{0}{1}-{2}{3}", new object[]
					{
						"SPC1-",
						this.EncodedCode,
						text,
						num
					});
					this._isValid = true;
				}
				return this._validationCode;
			}
			set
			{
				if (value != null && value != this._validationCode)
				{
					this._recalcValidationCode = false;
					this._validationCode = value.ToUpper();
					this._recalcIsValid = true;
				}
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000276 RID: 630 RVA: 0x0001190C File Offset: 0x0000FB0C
		public bool IsValid
		{
			get
			{
				if (this._recalcIsValid)
				{
					this.EvaluateValidationCode();
				}
				return this._isValid;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00011922 File Offset: 0x0000FB22
		// (set) Token: 0x06000278 RID: 632 RVA: 0x00011938 File Offset: 0x0000FB38
		public uint UseId
		{
			get
			{
				if (this._recalcIsValid)
				{
					this.EvaluateValidationCode();
				}
				return this._useId;
			}
			set
			{
				if (this._useId != value)
				{
					this._useId = value;
					this._recalcValidationCode = true;
				}
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000279 RID: 633 RVA: 0x00011951 File Offset: 0x0000FB51
		// (set) Token: 0x0600027A RID: 634 RVA: 0x00011959 File Offset: 0x0000FB59
		public Guid EditionGuid
		{
			get
			{
				return this._editionGuid;
			}
			set
			{
				Guid editionGuid = this._editionGuid;
				if (this._editionGuid.CompareTo(value) != 0)
				{
					this._editionGuid = value;
					this._recalcValidationCode = true;
				}
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600027B RID: 635 RVA: 0x0001197E File Offset: 0x0000FB7E
		// (set) Token: 0x0600027C RID: 636 RVA: 0x00011988 File Offset: 0x0000FB88
		public string NetName
		{
			get
			{
				return this._netName;
			}
			set
			{
				if (value != null)
				{
					string text = value.ToUpper();
					if (this._netName != text)
					{
						this._netName = text;
						this._recalcValidationCode = true;
					}
				}
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600027D RID: 637 RVA: 0x000119BB File Offset: 0x0000FBBB
		// (set) Token: 0x0600027E RID: 638 RVA: 0x000119C4 File Offset: 0x0000FBC4
		public uint SessionCode
		{
			get
			{
				return this._sessionCode;
			}
			set
			{
				uint num = value % 100U;
				if (this._sessionCode != num)
				{
					this._sessionCode = num;
					this._recalcValidationCode = true;
				}
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600027F RID: 639 RVA: 0x000119F0 File Offset: 0x0000FBF0
		private uint EditionCookie
		{
			get
			{
				byte[] value = this._editionGuid.ToByteArray();
				uint num = BitConverter.ToUInt32(value, 0);
				uint num2 = BitConverter.ToUInt32(value, 4);
				uint num3 = BitConverter.ToUInt32(value, 8);
				return num ^ num2 ^ num3;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000280 RID: 640 RVA: 0x00011A24 File Offset: 0x0000FC24
		private string EncodedCode
		{
			get
			{
				return Laplink.Pcmover.Service.ValidationCode.CreateVcCode(Laplink.Pcmover.Service.ValidationCode.CalcChecksum(this.NetName) * (this.SessionCode + 1U) ^ this.EditionCookie);
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00011A48 File Offset: 0x0000FC48
		public ValidationCodeUse(Guid editionGuid, string netName, uint sessionCode)
		{
			this.EditionGuid = editionGuid;
			this.NetName = netName;
			this.SessionCode = sessionCode;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00011A94 File Offset: 0x0000FC94
		private void EvaluateValidationCode()
		{
			this._recalcIsValid = false;
			this._isValid = false;
			if (this.ValidationCode.Length < "SPC1-".Length + 7 + 1 + 1 + 1)
			{
				return;
			}
			if (this.ValidationCode.Substring(0, "SPC1-".Length) != "SPC1-")
			{
				return;
			}
			if (this.ValidationCode.Substring("SPC1-".Length, 7) != this.EncodedCode)
			{
				return;
			}
			if (this.ValidationCode["SPC1-".Length + 7] != '-')
			{
				return;
			}
			string text = this.ValidationCode.Substring("SPC1-".Length + 7 + 1);
			string text2 = text.Substring(0, text.Length - 1);
			string s = text.Substring(text.Length - 1);
			if (!uint.TryParse(text2, out this._useId))
			{
				return;
			}
			uint num;
			if (!uint.TryParse(s, out num))
			{
				return;
			}
			uint num2;
			if (!Laplink.Pcmover.Service.ValidationCode.GetCheckDigit(text2, out num2))
			{
				return;
			}
			if (num2 == num)
			{
				this._isValid = true;
			}
		}

		// Token: 0x040000D2 RID: 210
		private const string PREFIX = "SPC1-";

		// Token: 0x040000D3 RID: 211
		private bool _recalcValidationCode = true;

		// Token: 0x040000D4 RID: 212
		private string _validationCode = "";

		// Token: 0x040000D5 RID: 213
		private bool _recalcIsValid = true;

		// Token: 0x040000D6 RID: 214
		private bool _isValid;

		// Token: 0x040000D7 RID: 215
		private uint _useId;

		// Token: 0x040000D8 RID: 216
		private Guid _editionGuid;

		// Token: 0x040000D9 RID: 217
		private string _netName = "";

		// Token: 0x040000DA RID: 218
		private uint _sessionCode;
	}
}
