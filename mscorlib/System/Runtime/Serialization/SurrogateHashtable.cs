﻿using System;
using System.Collections;

namespace System.Runtime.Serialization
{
	// Token: 0x0200075A RID: 1882
	internal class SurrogateHashtable : Hashtable
	{
		// Token: 0x060052ED RID: 21229 RVA: 0x001239D0 File Offset: 0x00121BD0
		internal SurrogateHashtable(int size) : base(size)
		{
		}

		// Token: 0x060052EE RID: 21230 RVA: 0x001239DC File Offset: 0x00121BDC
		protected override bool KeyEquals(object key, object item)
		{
			SurrogateKey surrogateKey = (SurrogateKey)item;
			SurrogateKey surrogateKey2 = (SurrogateKey)key;
			return surrogateKey2.m_type == surrogateKey.m_type && (surrogateKey2.m_context.m_state & surrogateKey.m_context.m_state) == surrogateKey.m_context.m_state && surrogateKey2.m_context.Context == surrogateKey.m_context.Context;
		}
	}
}
