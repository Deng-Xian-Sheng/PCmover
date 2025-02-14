﻿using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	// Token: 0x02000263 RID: 611
	[ComVisible(true)]
	public class HMACRIPEMD160 : HMAC
	{
		// Token: 0x060021BD RID: 8637 RVA: 0x0007790A File Offset: 0x00075B0A
		public HMACRIPEMD160() : this(Utils.GenerateRandom(64))
		{
		}

		// Token: 0x060021BE RID: 8638 RVA: 0x00077919 File Offset: 0x00075B19
		public HMACRIPEMD160(byte[] key)
		{
			this.m_hashName = "RIPEMD160";
			this.m_hash1 = new RIPEMD160Managed();
			this.m_hash2 = new RIPEMD160Managed();
			this.HashSizeValue = 160;
			base.InitializeKey(key);
		}
	}
}
