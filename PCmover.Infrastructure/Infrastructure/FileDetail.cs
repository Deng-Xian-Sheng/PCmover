using System;
using System.IO;
using Laplink.Pcmover.Contracts;
using PCmover.Infrastructure.Properties;
using Prism.Mvvm;

namespace PCmover.Infrastructure
{
	// Token: 0x0200001B RID: 27
	public class FileDetail : BindableBase
	{
		// Token: 0x06000166 RID: 358 RVA: 0x000055B4 File Offset: 0x000037B4
		public FileDetail(TransferrableItemDefinition fileItem, FolderDetail folder)
		{
			this.Folder = folder;
			this.Name = fileItem.Name;
			this.Size = fileItem.Size;
			this._selected = fileItem.Transferrable;
			this._target = fileItem.Target;
			this.FullPath = Path.Combine(this.Folder.FullPath, this.Name);
			if (fileItem.Transferrable != Transferrable.RuleExcluded)
			{
				this._Selectable = true;
				return;
			}
			this._Selectable = false;
			if (folder.IsCloud)
			{
				this._NotSelectableImage = "/WizardModule;component/Assets/cloud.png";
				this._NotSelectableText = Resources.NotSelectedCloud;
				return;
			}
			this._NotSelectableImage = "/WizardModule;component/Assets/cant.png";
			this._NotSelectableText = Resources.NotSelectedRules;
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00005667 File Offset: 0x00003867
		public FolderDetail Folder { get; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000168 RID: 360 RVA: 0x0000566F File Offset: 0x0000386F
		public bool CanRedirect
		{
			get
			{
				return this.Selectable;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00005677 File Offset: 0x00003877
		// (set) Token: 0x0600016A RID: 362 RVA: 0x0000567F File Offset: 0x0000387F
		public string Name { get; set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00005688 File Offset: 0x00003888
		// (set) Token: 0x0600016C RID: 364 RVA: 0x00005690 File Offset: 0x00003890
		public ulong Size { get; set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600016D RID: 365 RVA: 0x00005699 File Offset: 0x00003899
		public ulong SelectedSize
		{
			get
			{
				if (this._selected != Transferrable.Transfer)
				{
					return 0UL;
				}
				return this.Size;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600016E RID: 366 RVA: 0x000056AC File Offset: 0x000038AC
		private IPCmoverEngine Engine
		{
			get
			{
				return this.Folder.Group.Engine;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600016F RID: 367 RVA: 0x000056BE File Offset: 0x000038BE
		// (set) Token: 0x06000170 RID: 368 RVA: 0x000056C8 File Offset: 0x000038C8
		public Transferrable Selected
		{
			get
			{
				return this._selected;
			}
			set
			{
				if (this._selected == Transferrable.RuleExcluded)
				{
					return;
				}
				if (value == Transferrable.RuleExcluded)
				{
					return;
				}
				if (this._selected != value)
				{
					this.Engine.CatchCommEx(delegate
					{
						CustomizationData customizationData = this.Engine.ChangeDiskData(this.Folder.FullPath, this.Name, false, new bool?(value == Transferrable.Transfer), null);
						if (customizationData != null && customizationData.Result == CustomizationResult.Success)
						{
							this.ChangeSelected(value);
						}
					}, "Selected");
				}
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000171 RID: 369 RVA: 0x00005728 File Offset: 0x00003928
		public string FullPath { get; }

		// Token: 0x06000172 RID: 370 RVA: 0x00005730 File Offset: 0x00003930
		public void ChangeSelected(Transferrable selected)
		{
			if (selected != Transferrable.RuleExcluded && this.SetProperty<Transferrable>(ref this._selected, selected, "Selected"))
			{
				base.RaisePropertyChanged("SelectedSize");
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000173 RID: 371 RVA: 0x00005755 File Offset: 0x00003955
		// (set) Token: 0x06000174 RID: 372 RVA: 0x00005760 File Offset: 0x00003960
		public string Target
		{
			get
			{
				return this._target;
			}
			set
			{
				if (this._target != value)
				{
					this.Engine.CatchCommEx(delegate
					{
						CustomizationData customizationData = this.Engine.ChangeDiskData(this.Folder.FullPath, this.Name, false, null, value);
						if (customizationData != null && customizationData.Result == CustomizationResult.Success)
						{
							if (string.IsNullOrEmpty(value))
							{
								if (customizationData.Affects.HasFlag(CustomizationAffects.DiskItems))
								{
									this.Folder.RefreshDetails();
									return;
								}
							}
							else
							{
								this.SetTarget(value);
							}
						}
					}, "Target");
				}
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000175 RID: 373 RVA: 0x000057B1 File Offset: 0x000039B1
		// (set) Token: 0x06000176 RID: 374 RVA: 0x000057B9 File Offset: 0x000039B9
		public bool Selectable
		{
			get
			{
				return this._Selectable;
			}
			set
			{
				if (this.SetProperty<bool>(ref this._Selectable, value, "Selectable"))
				{
					base.RaisePropertyChanged("CanRedirect");
				}
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000177 RID: 375 RVA: 0x000057DA File Offset: 0x000039DA
		// (set) Token: 0x06000178 RID: 376 RVA: 0x000057E2 File Offset: 0x000039E2
		public string NotSelectableText
		{
			get
			{
				return this._NotSelectableText;
			}
			set
			{
				this._NotSelectableText = value;
				base.RaisePropertyChanged("NotSelectableText");
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000179 RID: 377 RVA: 0x000057F6 File Offset: 0x000039F6
		// (set) Token: 0x0600017A RID: 378 RVA: 0x000057FE File Offset: 0x000039FE
		public string NotSelectableImage
		{
			get
			{
				return this._NotSelectableImage;
			}
			set
			{
				this._NotSelectableImage = value;
				base.RaisePropertyChanged("NotSelectableImage");
			}
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00005812 File Offset: 0x00003A12
		public void SetTarget(string target)
		{
			this.SetProperty<string>(ref this._target, target, "Target");
		}

		// Token: 0x04000096 RID: 150
		private Transferrable _selected;

		// Token: 0x04000098 RID: 152
		private string _target;

		// Token: 0x04000099 RID: 153
		private bool _Selectable;

		// Token: 0x0400009A RID: 154
		private string _NotSelectableText;

		// Token: 0x0400009B RID: 155
		private string _NotSelectableImage;
	}
}
