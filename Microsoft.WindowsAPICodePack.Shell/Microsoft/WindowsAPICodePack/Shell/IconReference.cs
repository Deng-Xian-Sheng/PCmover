using System;
using System.Globalization;
using Microsoft.WindowsAPICodePack.Resources;

namespace Microsoft.WindowsAPICodePack.Shell
{
	// Token: 0x0200000C RID: 12
	public struct IconReference
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00002E60 File Offset: 0x00001060
		public IconReference(string moduleName, int resourceId)
		{
			this = default(IconReference);
			if (string.IsNullOrEmpty(moduleName))
			{
				throw new ArgumentNullException("moduleName");
			}
			this.moduleName = moduleName;
			this.ResourceId = resourceId;
			this.referencePath = string.Format(CultureInfo.InvariantCulture, "{0},{1}", new object[]
			{
				moduleName,
				resourceId
			});
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002EC8 File Offset: 0x000010C8
		public IconReference(string refPath)
		{
			this = default(IconReference);
			if (string.IsNullOrEmpty(refPath))
			{
				throw new ArgumentNullException("refPath");
			}
			string[] array = refPath.Split(IconReference.commaSeparator);
			if (array.Length != 2 || string.IsNullOrEmpty(array[0]) || string.IsNullOrEmpty(array[1]))
			{
				throw new ArgumentException(LocalizedMessages.InvalidReferencePath, "refPath");
			}
			this.moduleName = array[0];
			this.ResourceId = int.Parse(array[1], CultureInfo.InvariantCulture);
			this.referencePath = refPath;
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00002F5C File Offset: 0x0000115C
		// (set) Token: 0x06000058 RID: 88 RVA: 0x00002F74 File Offset: 0x00001174
		public string ModuleName
		{
			get
			{
				return this.moduleName;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("value");
				}
				this.moduleName = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00002FA4 File Offset: 0x000011A4
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00002FBB File Offset: 0x000011BB
		public int ResourceId { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002FC4 File Offset: 0x000011C4
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00002FDC File Offset: 0x000011DC
		public string ReferencePath
		{
			get
			{
				return this.referencePath;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("value");
				}
				string[] array = value.Split(IconReference.commaSeparator);
				if (array.Length != 2 || string.IsNullOrEmpty(array[0]) || string.IsNullOrEmpty(array[1]))
				{
					throw new ArgumentException(LocalizedMessages.InvalidReferencePath, "value");
				}
				this.ModuleName = array[0];
				this.ResourceId = int.Parse(array[1], CultureInfo.InvariantCulture);
				this.referencePath = value;
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003068 File Offset: 0x00001268
		public static bool operator ==(IconReference icon1, IconReference icon2)
		{
			return icon1.moduleName == icon2.moduleName && icon1.referencePath == icon2.referencePath && icon1.ResourceId == icon2.ResourceId;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x000030B8 File Offset: 0x000012B8
		public static bool operator !=(IconReference icon1, IconReference icon2)
		{
			return !(icon1 == icon2);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000030D4 File Offset: 0x000012D4
		public override bool Equals(object obj)
		{
			return obj != null && obj is IconReference && this == (IconReference)obj;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003110 File Offset: 0x00001310
		public override int GetHashCode()
		{
			int num = this.moduleName.GetHashCode();
			num = num * 31 + this.referencePath.GetHashCode();
			return num * 31 + this.ResourceId.GetHashCode();
		}

		// Token: 0x04000015 RID: 21
		private string moduleName;

		// Token: 0x04000016 RID: 22
		private string referencePath;

		// Token: 0x04000017 RID: 23
		private static char[] commaSeparator = new char[]
		{
			','
		};
	}
}
