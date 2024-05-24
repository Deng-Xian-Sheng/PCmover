using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CefSharp.ModelBinding
{
	// Token: 0x020000B5 RID: 181
	public class BindingMemberInfo
	{
		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x00008AB2 File Offset: 0x00006CB2
		// (set) Token: 0x06000580 RID: 1408 RVA: 0x00008ABA File Offset: 0x00006CBA
		public string Name { get; private set; }

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000581 RID: 1409 RVA: 0x00008AC3 File Offset: 0x00006CC3
		// (set) Token: 0x06000582 RID: 1410 RVA: 0x00008ACB File Offset: 0x00006CCB
		public Type Type { get; private set; }

		// Token: 0x06000583 RID: 1411 RVA: 0x00008AD4 File Offset: 0x00006CD4
		public BindingMemberInfo(PropertyInfo propertyInfo)
		{
			if (propertyInfo == null)
			{
				throw new ArgumentNullException("propertyInfo");
			}
			this.memberInfo = propertyInfo;
			this.Type = propertyInfo.PropertyType;
			this.Name = propertyInfo.Name;
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00008B0F File Offset: 0x00006D0F
		public BindingMemberInfo(FieldInfo fieldInfo)
		{
			if (fieldInfo == null)
			{
				throw new ArgumentNullException("fieldInfo");
			}
			this.memberInfo = fieldInfo;
			this.Type = fieldInfo.FieldType;
			this.Name = fieldInfo.Name;
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00008B4A File Offset: 0x00006D4A
		public void SetValue(object destinationObject, object newValue)
		{
			if (this.memberInfo is PropertyInfo)
			{
				((PropertyInfo)this.memberInfo).SetValue(destinationObject, newValue, null);
				return;
			}
			((FieldInfo)this.memberInfo).SetValue(destinationObject, newValue);
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00008B7F File Offset: 0x00006D7F
		public static implicit operator MemberInfo(BindingMemberInfo info)
		{
			return info.memberInfo;
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00008B88 File Offset: 0x00006D88
		public static IEnumerable<BindingMemberInfo> Collect(Type type)
		{
			IEnumerable<BindingMemberInfo> first = from p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
			where p.CanRead && p.CanWrite
			select p into property
			where !property.GetIndexParameters().Any<ParameterInfo>()
			select new BindingMemberInfo(property);
			IEnumerable<BindingMemberInfo> second = from f in type.GetFields(BindingFlags.Instance | BindingFlags.Public)
			where !f.IsInitOnly
			select f into field
			select new BindingMemberInfo(field);
			return first.Concat(second);
		}

		// Token: 0x0400031B RID: 795
		private readonly MemberInfo memberInfo;
	}
}
