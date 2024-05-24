using System;
using System.Resources;
using System.Windows.Markup;
using WizardModule.Properties;

namespace WizardModule.Views
{
	// Token: 0x02000020 RID: 32
	public sealed class EnumerateExtension : MarkupExtension
	{
		// Token: 0x1700037F RID: 895
		// (get) Token: 0x060003FE RID: 1022 RVA: 0x00008D04 File Offset: 0x00006F04
		// (set) Token: 0x060003FF RID: 1023 RVA: 0x00008D0C File Offset: 0x00006F0C
		public Type Type { get; set; }

		// Token: 0x06000400 RID: 1024 RVA: 0x00008D15 File Offset: 0x00006F15
		public EnumerateExtension(Type type)
		{
			this.Type = type;
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x00008D24 File Offset: 0x00006F24
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			ResourceManager resourceManager = Resources.ResourceManager;
			string[] names = Enum.GetNames(this.Type);
			string[] array = new string[names.Length];
			for (int i = 0; i < names.Length; i++)
			{
				array[i] = resourceManager.GetString("ENUM_" + names[i]);
			}
			return array;
		}
	}
}
