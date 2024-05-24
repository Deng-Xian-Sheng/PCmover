using System;
using System.Globalization;

namespace System.Reflection
{
	// Token: 0x020005FB RID: 1531
	[Serializable]
	internal struct MetadataToken
	{
		// Token: 0x06004677 RID: 18039 RVA: 0x00102906 File Offset: 0x00100B06
		public static implicit operator int(MetadataToken token)
		{
			return token.Value;
		}

		// Token: 0x06004678 RID: 18040 RVA: 0x0010290E File Offset: 0x00100B0E
		public static implicit operator MetadataToken(int token)
		{
			return new MetadataToken(token);
		}

		// Token: 0x06004679 RID: 18041 RVA: 0x00102918 File Offset: 0x00100B18
		public static bool IsTokenOfType(int token, params MetadataTokenType[] types)
		{
			for (int i = 0; i < types.Length; i++)
			{
				if ((MetadataTokenType)((long)token & (long)((ulong)-16777216)) == types[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600467A RID: 18042 RVA: 0x00102945 File Offset: 0x00100B45
		public static bool IsNullToken(int token)
		{
			return (token & 16777215) == 0;
		}

		// Token: 0x0600467B RID: 18043 RVA: 0x00102951 File Offset: 0x00100B51
		public MetadataToken(int token)
		{
			this.Value = token;
		}

		// Token: 0x17000AA0 RID: 2720
		// (get) Token: 0x0600467C RID: 18044 RVA: 0x0010295A File Offset: 0x00100B5A
		public bool IsGlobalTypeDefToken
		{
			get
			{
				return this.Value == 33554433;
			}
		}

		// Token: 0x17000AA1 RID: 2721
		// (get) Token: 0x0600467D RID: 18045 RVA: 0x00102969 File Offset: 0x00100B69
		public MetadataTokenType TokenType
		{
			get
			{
				return (MetadataTokenType)((long)this.Value & (long)((ulong)-16777216));
			}
		}

		// Token: 0x17000AA2 RID: 2722
		// (get) Token: 0x0600467E RID: 18046 RVA: 0x0010297A File Offset: 0x00100B7A
		public bool IsTypeRef
		{
			get
			{
				return this.TokenType == MetadataTokenType.TypeRef;
			}
		}

		// Token: 0x17000AA3 RID: 2723
		// (get) Token: 0x0600467F RID: 18047 RVA: 0x00102989 File Offset: 0x00100B89
		public bool IsTypeDef
		{
			get
			{
				return this.TokenType == MetadataTokenType.TypeDef;
			}
		}

		// Token: 0x17000AA4 RID: 2724
		// (get) Token: 0x06004680 RID: 18048 RVA: 0x00102998 File Offset: 0x00100B98
		public bool IsFieldDef
		{
			get
			{
				return this.TokenType == MetadataTokenType.FieldDef;
			}
		}

		// Token: 0x17000AA5 RID: 2725
		// (get) Token: 0x06004681 RID: 18049 RVA: 0x001029A7 File Offset: 0x00100BA7
		public bool IsMethodDef
		{
			get
			{
				return this.TokenType == MetadataTokenType.MethodDef;
			}
		}

		// Token: 0x17000AA6 RID: 2726
		// (get) Token: 0x06004682 RID: 18050 RVA: 0x001029B6 File Offset: 0x00100BB6
		public bool IsMemberRef
		{
			get
			{
				return this.TokenType == MetadataTokenType.MemberRef;
			}
		}

		// Token: 0x17000AA7 RID: 2727
		// (get) Token: 0x06004683 RID: 18051 RVA: 0x001029C5 File Offset: 0x00100BC5
		public bool IsEvent
		{
			get
			{
				return this.TokenType == MetadataTokenType.Event;
			}
		}

		// Token: 0x17000AA8 RID: 2728
		// (get) Token: 0x06004684 RID: 18052 RVA: 0x001029D4 File Offset: 0x00100BD4
		public bool IsProperty
		{
			get
			{
				return this.TokenType == MetadataTokenType.Property;
			}
		}

		// Token: 0x17000AA9 RID: 2729
		// (get) Token: 0x06004685 RID: 18053 RVA: 0x001029E3 File Offset: 0x00100BE3
		public bool IsParamDef
		{
			get
			{
				return this.TokenType == MetadataTokenType.ParamDef;
			}
		}

		// Token: 0x17000AAA RID: 2730
		// (get) Token: 0x06004686 RID: 18054 RVA: 0x001029F2 File Offset: 0x00100BF2
		public bool IsTypeSpec
		{
			get
			{
				return this.TokenType == MetadataTokenType.TypeSpec;
			}
		}

		// Token: 0x17000AAB RID: 2731
		// (get) Token: 0x06004687 RID: 18055 RVA: 0x00102A01 File Offset: 0x00100C01
		public bool IsMethodSpec
		{
			get
			{
				return this.TokenType == MetadataTokenType.MethodSpec;
			}
		}

		// Token: 0x17000AAC RID: 2732
		// (get) Token: 0x06004688 RID: 18056 RVA: 0x00102A10 File Offset: 0x00100C10
		public bool IsString
		{
			get
			{
				return this.TokenType == MetadataTokenType.String;
			}
		}

		// Token: 0x17000AAD RID: 2733
		// (get) Token: 0x06004689 RID: 18057 RVA: 0x00102A1F File Offset: 0x00100C1F
		public bool IsSignature
		{
			get
			{
				return this.TokenType == MetadataTokenType.Signature;
			}
		}

		// Token: 0x17000AAE RID: 2734
		// (get) Token: 0x0600468A RID: 18058 RVA: 0x00102A2E File Offset: 0x00100C2E
		public bool IsModule
		{
			get
			{
				return this.TokenType == MetadataTokenType.Module;
			}
		}

		// Token: 0x17000AAF RID: 2735
		// (get) Token: 0x0600468B RID: 18059 RVA: 0x00102A39 File Offset: 0x00100C39
		public bool IsAssembly
		{
			get
			{
				return this.TokenType == MetadataTokenType.Assembly;
			}
		}

		// Token: 0x17000AB0 RID: 2736
		// (get) Token: 0x0600468C RID: 18060 RVA: 0x00102A48 File Offset: 0x00100C48
		public bool IsGenericPar
		{
			get
			{
				return this.TokenType == MetadataTokenType.GenericPar;
			}
		}

		// Token: 0x0600468D RID: 18061 RVA: 0x00102A57 File Offset: 0x00100C57
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "0x{0:x8}", this.Value);
		}

		// Token: 0x04001D48 RID: 7496
		public int Value;
	}
}
