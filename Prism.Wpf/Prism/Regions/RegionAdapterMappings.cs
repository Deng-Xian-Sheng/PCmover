using System;
using System.Collections.Generic;
using System.Globalization;
using Prism.Properties;

namespace Prism.Regions
{
	// Token: 0x02000023 RID: 35
	public class RegionAdapterMappings
	{
		// Token: 0x060000DA RID: 218 RVA: 0x00003438 File Offset: 0x00001638
		public void RegisterMapping(Type controlType, IRegionAdapter adapter)
		{
			if (controlType == null)
			{
				throw new ArgumentNullException("controlType");
			}
			if (adapter == null)
			{
				throw new ArgumentNullException("adapter");
			}
			if (this.mappings.ContainsKey(controlType))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.MappingExistsException, new object[]
				{
					controlType.Name
				}));
			}
			this.mappings.Add(controlType, adapter);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000034A8 File Offset: 0x000016A8
		public IRegionAdapter GetMapping(Type controlType)
		{
			Type type = controlType;
			while (type != null)
			{
				if (this.mappings.ContainsKey(type))
				{
					return this.mappings[type];
				}
				type = type.BaseType;
			}
			throw new KeyNotFoundException(string.Format(CultureInfo.CurrentCulture, Resources.NoRegionAdapterException, new object[]
			{
				controlType
			}));
		}

		// Token: 0x0400001B RID: 27
		private readonly Dictionary<Type, IRegionAdapter> mappings = new Dictionary<Type, IRegionAdapter>();
	}
}
