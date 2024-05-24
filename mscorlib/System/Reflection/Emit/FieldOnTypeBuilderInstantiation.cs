using System;
using System.Globalization;

namespace System.Reflection.Emit
{
	// Token: 0x02000669 RID: 1641
	internal sealed class FieldOnTypeBuilderInstantiation : FieldInfo
	{
		// Token: 0x06004EEE RID: 20206 RVA: 0x0011BE94 File Offset: 0x0011A094
		internal static FieldInfo GetField(FieldInfo Field, TypeBuilderInstantiation type)
		{
			FieldInfo fieldInfo;
			if (type.m_hashtable.Contains(Field))
			{
				fieldInfo = (type.m_hashtable[Field] as FieldInfo);
			}
			else
			{
				fieldInfo = new FieldOnTypeBuilderInstantiation(Field, type);
				type.m_hashtable[Field] = fieldInfo;
			}
			return fieldInfo;
		}

		// Token: 0x06004EEF RID: 20207 RVA: 0x0011BEDB File Offset: 0x0011A0DB
		internal FieldOnTypeBuilderInstantiation(FieldInfo field, TypeBuilderInstantiation type)
		{
			this.m_field = field;
			this.m_type = type;
		}

		// Token: 0x17000C88 RID: 3208
		// (get) Token: 0x06004EF0 RID: 20208 RVA: 0x0011BEF1 File Offset: 0x0011A0F1
		internal FieldInfo FieldInfo
		{
			get
			{
				return this.m_field;
			}
		}

		// Token: 0x17000C89 RID: 3209
		// (get) Token: 0x06004EF1 RID: 20209 RVA: 0x0011BEF9 File Offset: 0x0011A0F9
		public override MemberTypes MemberType
		{
			get
			{
				return MemberTypes.Field;
			}
		}

		// Token: 0x17000C8A RID: 3210
		// (get) Token: 0x06004EF2 RID: 20210 RVA: 0x0011BEFC File Offset: 0x0011A0FC
		public override string Name
		{
			get
			{
				return this.m_field.Name;
			}
		}

		// Token: 0x17000C8B RID: 3211
		// (get) Token: 0x06004EF3 RID: 20211 RVA: 0x0011BF09 File Offset: 0x0011A109
		public override Type DeclaringType
		{
			get
			{
				return this.m_type;
			}
		}

		// Token: 0x17000C8C RID: 3212
		// (get) Token: 0x06004EF4 RID: 20212 RVA: 0x0011BF11 File Offset: 0x0011A111
		public override Type ReflectedType
		{
			get
			{
				return this.m_type;
			}
		}

		// Token: 0x06004EF5 RID: 20213 RVA: 0x0011BF19 File Offset: 0x0011A119
		public override object[] GetCustomAttributes(bool inherit)
		{
			return this.m_field.GetCustomAttributes(inherit);
		}

		// Token: 0x06004EF6 RID: 20214 RVA: 0x0011BF27 File Offset: 0x0011A127
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return this.m_field.GetCustomAttributes(attributeType, inherit);
		}

		// Token: 0x06004EF7 RID: 20215 RVA: 0x0011BF36 File Offset: 0x0011A136
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return this.m_field.IsDefined(attributeType, inherit);
		}

		// Token: 0x17000C8D RID: 3213
		// (get) Token: 0x06004EF8 RID: 20216 RVA: 0x0011BF48 File Offset: 0x0011A148
		internal int MetadataTokenInternal
		{
			get
			{
				FieldBuilder fieldBuilder = this.m_field as FieldBuilder;
				if (fieldBuilder != null)
				{
					return fieldBuilder.MetadataTokenInternal;
				}
				return this.m_field.MetadataToken;
			}
		}

		// Token: 0x17000C8E RID: 3214
		// (get) Token: 0x06004EF9 RID: 20217 RVA: 0x0011BF7C File Offset: 0x0011A17C
		public override Module Module
		{
			get
			{
				return this.m_field.Module;
			}
		}

		// Token: 0x06004EFA RID: 20218 RVA: 0x0011BF89 File Offset: 0x0011A189
		public new Type GetType()
		{
			return base.GetType();
		}

		// Token: 0x06004EFB RID: 20219 RVA: 0x0011BF91 File Offset: 0x0011A191
		public override Type[] GetRequiredCustomModifiers()
		{
			return this.m_field.GetRequiredCustomModifiers();
		}

		// Token: 0x06004EFC RID: 20220 RVA: 0x0011BF9E File Offset: 0x0011A19E
		public override Type[] GetOptionalCustomModifiers()
		{
			return this.m_field.GetOptionalCustomModifiers();
		}

		// Token: 0x06004EFD RID: 20221 RVA: 0x0011BFAB File Offset: 0x0011A1AB
		public override void SetValueDirect(TypedReference obj, object value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004EFE RID: 20222 RVA: 0x0011BFB2 File Offset: 0x0011A1B2
		public override object GetValueDirect(TypedReference obj)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000C8F RID: 3215
		// (get) Token: 0x06004EFF RID: 20223 RVA: 0x0011BFB9 File Offset: 0x0011A1B9
		public override RuntimeFieldHandle FieldHandle
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000C90 RID: 3216
		// (get) Token: 0x06004F00 RID: 20224 RVA: 0x0011BFC0 File Offset: 0x0011A1C0
		public override Type FieldType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06004F01 RID: 20225 RVA: 0x0011BFC7 File Offset: 0x0011A1C7
		public override object GetValue(object obj)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06004F02 RID: 20226 RVA: 0x0011BFCE File Offset: 0x0011A1CE
		public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x17000C91 RID: 3217
		// (get) Token: 0x06004F03 RID: 20227 RVA: 0x0011BFD5 File Offset: 0x0011A1D5
		public override FieldAttributes Attributes
		{
			get
			{
				return this.m_field.Attributes;
			}
		}

		// Token: 0x040021D2 RID: 8658
		private FieldInfo m_field;

		// Token: 0x040021D3 RID: 8659
		private TypeBuilderInstantiation m_type;
	}
}
