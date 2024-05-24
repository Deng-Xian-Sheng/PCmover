using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Microsoft.WindowsAPICodePack.Shell;

namespace Microsoft.WindowsAPICodePack.Dialogs
{
	// Token: 0x02000082 RID: 130
	public class CommonFileDialogFilter
	{
		// Token: 0x06000481 RID: 1153 RVA: 0x000114D4 File Offset: 0x0000F6D4
		public CommonFileDialogFilter()
		{
			this.extensions = new Collection<string>();
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x000114F4 File Offset: 0x0000F6F4
		public CommonFileDialogFilter(string rawDisplayName, string extensionList) : this()
		{
			if (string.IsNullOrEmpty(extensionList))
			{
				throw new ArgumentNullException("extensionList");
			}
			this.rawDisplayName = rawDisplayName;
			string[] array = extensionList.Split(new char[]
			{
				',',
				';'
			});
			foreach (string rawExtension in array)
			{
				this.extensions.Add(CommonFileDialogFilter.NormalizeExtension(rawExtension));
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x00011578 File Offset: 0x0000F778
		// (set) Token: 0x06000484 RID: 1156 RVA: 0x000115D0 File Offset: 0x0000F7D0
		public string DisplayName
		{
			get
			{
				string result;
				if (this.showExtensions)
				{
					result = string.Format(CultureInfo.InvariantCulture, "{0} ({1})", new object[]
					{
						this.rawDisplayName,
						CommonFileDialogFilter.GetDisplayExtensionList(this.extensions)
					});
				}
				else
				{
					result = this.rawDisplayName;
				}
				return result;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException("value");
				}
				this.rawDisplayName = value;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x00011600 File Offset: 0x0000F800
		public Collection<string> Extensions
		{
			get
			{
				return this.extensions;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x00011618 File Offset: 0x0000F818
		// (set) Token: 0x06000487 RID: 1159 RVA: 0x00011630 File Offset: 0x0000F830
		public bool ShowExtensions
		{
			get
			{
				return this.showExtensions;
			}
			set
			{
				this.showExtensions = value;
			}
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0001163C File Offset: 0x0000F83C
		private static string NormalizeExtension(string rawExtension)
		{
			rawExtension = rawExtension.Trim();
			rawExtension = rawExtension.Replace("*.", null);
			rawExtension = rawExtension.Replace(".", null);
			return rawExtension;
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00011674 File Offset: 0x0000F874
		private static string GetDisplayExtensionList(Collection<string> extensions)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string value in extensions)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append("*.");
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0001170C File Offset: 0x0000F90C
		internal ShellNativeMethods.FilterSpec GetFilterSpec()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string value in this.extensions)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(";");
				}
				stringBuilder.Append("*.");
				stringBuilder.Append(value);
			}
			return new ShellNativeMethods.FilterSpec(this.DisplayName, stringBuilder.ToString());
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x000117B4 File Offset: 0x0000F9B4
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0} ({1})", new object[]
			{
				this.rawDisplayName,
				CommonFileDialogFilter.GetDisplayExtensionList(this.extensions)
			});
		}

		// Token: 0x040002E8 RID: 744
		private Collection<string> extensions;

		// Token: 0x040002E9 RID: 745
		private string rawDisplayName;

		// Token: 0x040002EA RID: 746
		private bool showExtensions = true;
	}
}
