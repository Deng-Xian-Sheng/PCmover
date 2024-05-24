using System;
using System.Xml.Serialization;
using Prism.Mvvm;

namespace PCmover.Infrastructure
{
	// Token: 0x0200001C RID: 28
	public class FileFilter : BindableBase
	{
		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600017C RID: 380 RVA: 0x00005827 File Offset: 0x00003A27
		// (set) Token: 0x0600017D RID: 381 RVA: 0x0000582F File Offset: 0x00003A2F
		[XmlAttribute]
		public string filter
		{
			get
			{
				return this._filter;
			}
			set
			{
				this.SetProperty<string>(ref this._filter, value, "filter");
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00005844 File Offset: 0x00003A44
		// (set) Token: 0x0600017F RID: 383 RVA: 0x0000584C File Offset: 0x00003A4C
		[XmlIgnore]
		public bool? transfer
		{
			get
			{
				return this._transfer;
			}
			set
			{
				this.SetProperty<bool?>(ref this._transfer, value, "transfer");
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000180 RID: 384 RVA: 0x00005864 File Offset: 0x00003A64
		// (set) Token: 0x06000181 RID: 385 RVA: 0x00005888 File Offset: 0x00003A88
		[XmlAttribute("transfer")]
		public string xmlTransfer
		{
			get
			{
				return this.transfer.ToString();
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.transfer = null;
					return;
				}
				this.transfer = new bool?(bool.Parse(value));
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000182 RID: 386 RVA: 0x000058BE File Offset: 0x00003ABE
		// (set) Token: 0x06000183 RID: 387 RVA: 0x000058C6 File Offset: 0x00003AC6
		[XmlAttribute]
		public string target
		{
			get
			{
				return this._target;
			}
			set
			{
				this.SetProperty<string>(ref this._target, value, "target");
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000058DB File Offset: 0x00003ADB
		public FileFilter(string filter, bool? transfer, string target = "")
		{
			this._filter = string.Copy(filter);
			this._transfer = transfer;
			this._target = string.Copy(target);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000029E9 File Offset: 0x00000BE9
		public FileFilter()
		{
		}

		// Token: 0x0400009C RID: 156
		private string _filter;

		// Token: 0x0400009D RID: 157
		private bool? _transfer;

		// Token: 0x0400009E RID: 158
		private string _target;
	}
}
