using System;
using System.Reflection;
using System.Security;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000934 RID: 2356
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class StructLayoutAttribute : Attribute
	{
		// Token: 0x06006039 RID: 24633 RVA: 0x0014BC30 File Offset: 0x00149E30
		[SecurityCritical]
		internal static Attribute GetCustomAttribute(RuntimeType type)
		{
			if (!StructLayoutAttribute.IsDefined(type))
			{
				return null;
			}
			int num = 0;
			int size = 0;
			LayoutKind layoutKind = LayoutKind.Auto;
			TypeAttributes typeAttributes = type.Attributes & TypeAttributes.LayoutMask;
			if (typeAttributes != TypeAttributes.NotPublic)
			{
				if (typeAttributes != TypeAttributes.SequentialLayout)
				{
					if (typeAttributes == TypeAttributes.ExplicitLayout)
					{
						layoutKind = LayoutKind.Explicit;
					}
				}
				else
				{
					layoutKind = LayoutKind.Sequential;
				}
			}
			else
			{
				layoutKind = LayoutKind.Auto;
			}
			CharSet charSet = CharSet.None;
			TypeAttributes typeAttributes2 = type.Attributes & TypeAttributes.StringFormatMask;
			if (typeAttributes2 != TypeAttributes.NotPublic)
			{
				if (typeAttributes2 != TypeAttributes.UnicodeClass)
				{
					if (typeAttributes2 == TypeAttributes.AutoClass)
					{
						charSet = CharSet.Auto;
					}
				}
				else
				{
					charSet = CharSet.Unicode;
				}
			}
			else
			{
				charSet = CharSet.Ansi;
			}
			type.GetRuntimeModule().MetadataImport.GetClassLayout(type.MetadataToken, out num, out size);
			if (num == 0)
			{
				num = 8;
			}
			return new StructLayoutAttribute(layoutKind, num, size, charSet);
		}

		// Token: 0x0600603A RID: 24634 RVA: 0x0014BCCF File Offset: 0x00149ECF
		internal static bool IsDefined(RuntimeType type)
		{
			return !type.IsInterface && !type.HasElementType && !type.IsGenericParameter;
		}

		// Token: 0x0600603B RID: 24635 RVA: 0x0014BCEC File Offset: 0x00149EEC
		internal StructLayoutAttribute(LayoutKind layoutKind, int pack, int size, CharSet charSet)
		{
			this._val = layoutKind;
			this.Pack = pack;
			this.Size = size;
			this.CharSet = charSet;
		}

		// Token: 0x0600603C RID: 24636 RVA: 0x0014BD11 File Offset: 0x00149F11
		[__DynamicallyInvokable]
		public StructLayoutAttribute(LayoutKind layoutKind)
		{
			this._val = layoutKind;
		}

		// Token: 0x0600603D RID: 24637 RVA: 0x0014BD20 File Offset: 0x00149F20
		public StructLayoutAttribute(short layoutKind)
		{
			this._val = (LayoutKind)layoutKind;
		}

		// Token: 0x170010E3 RID: 4323
		// (get) Token: 0x0600603E RID: 24638 RVA: 0x0014BD2F File Offset: 0x00149F2F
		[__DynamicallyInvokable]
		public LayoutKind Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002B14 RID: 11028
		private const int DEFAULT_PACKING_SIZE = 8;

		// Token: 0x04002B15 RID: 11029
		internal LayoutKind _val;

		// Token: 0x04002B16 RID: 11030
		[__DynamicallyInvokable]
		public int Pack;

		// Token: 0x04002B17 RID: 11031
		[__DynamicallyInvokable]
		public int Size;

		// Token: 0x04002B18 RID: 11032
		[__DynamicallyInvokable]
		public CharSet CharSet;
	}
}
