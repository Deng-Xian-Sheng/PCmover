using System;

namespace System.Reflection
{
	// Token: 0x020005AD RID: 1453
	[Serializable]
	internal class __Filters
	{
		// Token: 0x06004362 RID: 17250 RVA: 0x000FA5A0 File Offset: 0x000F87A0
		public virtual bool FilterTypeName(Type cls, object filterCriteria)
		{
			if (filterCriteria == null || !(filterCriteria is string))
			{
				throw new InvalidFilterCriteriaException(Environment.GetResourceString("RFLCT.FltCritString"));
			}
			string text = (string)filterCriteria;
			if (text.Length > 0 && text[text.Length - 1] == '*')
			{
				text = text.Substring(0, text.Length - 1);
				return cls.Name.StartsWith(text, StringComparison.Ordinal);
			}
			return cls.Name.Equals(text);
		}

		// Token: 0x06004363 RID: 17251 RVA: 0x000FA614 File Offset: 0x000F8814
		public virtual bool FilterTypeNameIgnoreCase(Type cls, object filterCriteria)
		{
			if (filterCriteria == null || !(filterCriteria is string))
			{
				throw new InvalidFilterCriteriaException(Environment.GetResourceString("RFLCT.FltCritString"));
			}
			string text = (string)filterCriteria;
			if (text.Length > 0 && text[text.Length - 1] == '*')
			{
				text = text.Substring(0, text.Length - 1);
				string name = cls.Name;
				return name.Length >= text.Length && string.Compare(name, 0, text, 0, text.Length, StringComparison.OrdinalIgnoreCase) == 0;
			}
			return string.Compare(text, cls.Name, StringComparison.OrdinalIgnoreCase) == 0;
		}
	}
}
