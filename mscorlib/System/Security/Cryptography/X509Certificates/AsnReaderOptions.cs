using System;

namespace System.Security.Cryptography.X509Certificates
{
	// Token: 0x020002B5 RID: 693
	internal struct AsnReaderOptions
	{
		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x060024CB RID: 9419 RVA: 0x000853F7 File Offset: 0x000835F7
		// (set) Token: 0x060024CC RID: 9420 RVA: 0x0008540D File Offset: 0x0008360D
		public int UtcTimeTwoDigitYearMax
		{
			get
			{
				if (this._twoDigitYearMax == 0)
				{
					return 2049;
				}
				return (int)this._twoDigitYearMax;
			}
			set
			{
				if (value < 1 || value > 9999)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._twoDigitYearMax = (ushort)value;
			}
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x060024CD RID: 9421 RVA: 0x0008542E File Offset: 0x0008362E
		// (set) Token: 0x060024CE RID: 9422 RVA: 0x00085436 File Offset: 0x00083636
		public bool SkipSetSortOrderVerification
		{
			get
			{
				return this._skipSetSortOrderVerification;
			}
			set
			{
				this._skipSetSortOrderVerification = value;
			}
		}

		// Token: 0x04000DBE RID: 3518
		private const int DefaultTwoDigitMax = 2049;

		// Token: 0x04000DBF RID: 3519
		private ushort _twoDigitYearMax;

		// Token: 0x04000DC0 RID: 3520
		private bool _skipSetSortOrderVerification;
	}
}
