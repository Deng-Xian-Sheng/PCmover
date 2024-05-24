using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Laplink.Pcmover.Contracts;

namespace PCmover.Infrastructure
{
	// Token: 0x0200003D RID: 61
	public class UserMap : INotifyPropertyChanged
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000303 RID: 771 RVA: 0x0000843C File Offset: 0x0000663C
		// (remove) Token: 0x06000304 RID: 772 RVA: 0x00008474 File Offset: 0x00006674
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000305 RID: 773 RVA: 0x000084A9 File Offset: 0x000066A9
		public UserMap(UserDetail old, bool isUserElevated)
		{
			this._Old = old;
			this.IsUserTypeEnabled = false;
			this._IsUserElevated = isUserElevated;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x000021D2 File Offset: 0x000003D2
		public UserMap()
		{
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000307 RID: 775 RVA: 0x000084C6 File Offset: 0x000066C6
		// (set) Token: 0x06000308 RID: 776 RVA: 0x000084CE File Offset: 0x000066CE
		[XmlIgnore]
		public string NewAccountName
		{
			get
			{
				return this._NewAccountName;
			}
			set
			{
				this._NewAccountName = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("NewAccountName"));
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000309 RID: 777 RVA: 0x000084F2 File Offset: 0x000066F2
		// (set) Token: 0x0600030A RID: 778 RVA: 0x000084FA File Offset: 0x000066FA
		[XmlAttribute]
		public bool Create
		{
			get
			{
				return this._Create;
			}
			set
			{
				this._Create = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("Create"));
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600030B RID: 779 RVA: 0x0000851E File Offset: 0x0000671E
		// (set) Token: 0x0600030C RID: 780 RVA: 0x00008526 File Offset: 0x00006726
		[XmlAttribute]
		public bool DontMigrate
		{
			get
			{
				return this._DontMigrate;
			}
			set
			{
				this._DontMigrate = value;
				this.ShowDontTransferLabel = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("DontMigrate"));
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600030D RID: 781 RVA: 0x00008551 File Offset: 0x00006751
		// (set) Token: 0x0600030E RID: 782 RVA: 0x00008559 File Offset: 0x00006759
		[XmlAttribute]
		public bool Current
		{
			get
			{
				return this._Current;
			}
			set
			{
				this._Current = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("Current"));
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600030F RID: 783 RVA: 0x0000857D File Offset: 0x0000677D
		// (set) Token: 0x06000310 RID: 784 RVA: 0x00008585 File Offset: 0x00006785
		[XmlAttribute]
		public bool NewUser
		{
			get
			{
				return this._NewUser;
			}
			set
			{
				this._NewUser = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("NewUser"));
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000311 RID: 785 RVA: 0x000085A9 File Offset: 0x000067A9
		// (set) Token: 0x06000312 RID: 786 RVA: 0x000085B1 File Offset: 0x000067B1
		[XmlAttribute]
		public bool Existing
		{
			get
			{
				return this._Existing;
			}
			set
			{
				this._Existing = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("Existing"));
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000313 RID: 787 RVA: 0x000085D5 File Offset: 0x000067D5
		// (set) Token: 0x06000314 RID: 788 RVA: 0x000085DD File Offset: 0x000067DD
		public UserDetail New
		{
			get
			{
				return this._New;
			}
			set
			{
				this._New = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("New"));
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000315 RID: 789 RVA: 0x00008601 File Offset: 0x00006801
		// (set) Token: 0x06000316 RID: 790 RVA: 0x00008609 File Offset: 0x00006809
		public UserDetail Old
		{
			get
			{
				return this._Old;
			}
			set
			{
				this._Old = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("Old"));
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000317 RID: 791 RVA: 0x0000862D File Offset: 0x0000682D
		// (set) Token: 0x06000318 RID: 792 RVA: 0x00008638 File Offset: 0x00006838
		[XmlIgnore]
		public bool EditMode
		{
			get
			{
				return this._EditMode;
			}
			set
			{
				this._EditMode = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged != null)
				{
					propertyChanged(this, new PropertyChangedEventArgs("EditMode"));
				}
				if (this._EditMode)
				{
					this.ShowCreateLabel = false;
					this.ShowDontTransferLabel = false;
					this.IsUserTypeEnabled = this._IsUserElevated;
					return;
				}
				this.IsUserTypeEnabled = false;
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000319 RID: 793 RVA: 0x00008692 File Offset: 0x00006892
		// (set) Token: 0x0600031A RID: 794 RVA: 0x0000869A File Offset: 0x0000689A
		[XmlIgnore]
		public bool ShowCreateLabel
		{
			get
			{
				return this._ShowCreateLabel;
			}
			set
			{
				if (!this.EditMode)
				{
					this._ShowCreateLabel = value;
				}
				else
				{
					this._ShowCreateLabel = false;
				}
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("ShowCreateLabel"));
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x0600031B RID: 795 RVA: 0x000086CF File Offset: 0x000068CF
		// (set) Token: 0x0600031C RID: 796 RVA: 0x000086D7 File Offset: 0x000068D7
		[XmlIgnore]
		public bool ShowDontTransferLabel
		{
			get
			{
				return this._ShowDontTransferLabel;
			}
			set
			{
				if (!this.EditMode)
				{
					this._ShowDontTransferLabel = value;
				}
				else
				{
					this._ShowDontTransferLabel = false;
				}
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("ShowDontTransferLabel"));
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x0600031D RID: 797 RVA: 0x0000870C File Offset: 0x0000690C
		// (set) Token: 0x0600031E RID: 798 RVA: 0x00008714 File Offset: 0x00006914
		[XmlIgnore]
		public bool IsCreateOptionAvailable
		{
			get
			{
				return this._IsCreateOptionAvailable;
			}
			set
			{
				this._IsCreateOptionAvailable = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("IsCreateOptionAvailable"));
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600031F RID: 799 RVA: 0x00008738 File Offset: 0x00006938
		// (set) Token: 0x06000320 RID: 800 RVA: 0x00008740 File Offset: 0x00006940
		[XmlIgnore]
		public bool IsNewUserOptionAvailable
		{
			get
			{
				return this._IsNewUserOptionAvailable;
			}
			set
			{
				this._IsNewUserOptionAvailable = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("IsNewUserOptionAvailable"));
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000321 RID: 801 RVA: 0x00008764 File Offset: 0x00006964
		// (set) Token: 0x06000322 RID: 802 RVA: 0x0000876C File Offset: 0x0000696C
		[XmlIgnore]
		public bool IsCurrentToCurrentOptionAvailable
		{
			get
			{
				return this._IsCurrentToCurrentOptionAvailable;
			}
			set
			{
				this._IsCurrentToCurrentOptionAvailable = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("IsCurrentToCurrentOptionAvailable"));
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000323 RID: 803 RVA: 0x00008790 File Offset: 0x00006990
		// (set) Token: 0x06000324 RID: 804 RVA: 0x00008798 File Offset: 0x00006998
		[XmlIgnore]
		public bool IsMapToExistingOptionAvailable
		{
			get
			{
				return this._IsMapToExistingOptionAvailable;
			}
			set
			{
				this._IsMapToExistingOptionAvailable = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("IsMapToExistingOptionAvailable"));
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000325 RID: 805 RVA: 0x000087BC File Offset: 0x000069BC
		// (set) Token: 0x06000326 RID: 806 RVA: 0x000087C4 File Offset: 0x000069C4
		[XmlIgnore]
		public bool IsUserTypeEnabled
		{
			get
			{
				return this._IsUSerTypeEnabled;
			}
			set
			{
				this._IsUSerTypeEnabled = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("IsUserTypeEnabled"));
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000327 RID: 807 RVA: 0x000087E8 File Offset: 0x000069E8
		// (set) Token: 0x06000328 RID: 808 RVA: 0x000087F0 File Offset: 0x000069F0
		[XmlIgnore]
		public bool Selected
		{
			get
			{
				return this._Selected;
			}
			set
			{
				this._Selected = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("Selected"));
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000329 RID: 809 RVA: 0x00008814 File Offset: 0x00006A14
		// (set) Token: 0x0600032A RID: 810 RVA: 0x0000881C File Offset: 0x00006A1C
		public string CreatedUserPassword
		{
			get
			{
				return this._CreatedUserPassword;
			}
			set
			{
				this._CreatedUserPassword = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("CreatedUserPassword"));
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600032B RID: 811 RVA: 0x00008840 File Offset: 0x00006A40
		// (set) Token: 0x0600032C RID: 812 RVA: 0x00008848 File Offset: 0x00006A48
		[XmlIgnore]
		public List<MapiProfileMapping> MapiProfileMappings
		{
			get
			{
				return this._MapiProfileMappings;
			}
			set
			{
				this._MapiProfileMappings = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("MapiProfileMappings"));
			}
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x0600032D RID: 813 RVA: 0x0000886C File Offset: 0x00006A6C
		// (set) Token: 0x0600032E RID: 814 RVA: 0x00008874 File Offset: 0x00006A74
		[XmlIgnore]
		public List<string> AvailableProfiles
		{
			get
			{
				return this._AvailableProfiles;
			}
			set
			{
				this._AvailableProfiles = value;
				PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
				if (propertyChanged == null)
				{
					return;
				}
				propertyChanged(this, new PropertyChangedEventArgs("AvailableProfiles"));
			}
		}

		// Token: 0x0400011B RID: 283
		private bool _IsUserElevated;

		// Token: 0x0400011C RID: 284
		private string _NewAccountName;

		// Token: 0x0400011D RID: 285
		private bool _Create;

		// Token: 0x0400011E RID: 286
		private bool _DontMigrate;

		// Token: 0x0400011F RID: 287
		private bool _Current;

		// Token: 0x04000120 RID: 288
		private bool _NewUser;

		// Token: 0x04000121 RID: 289
		private bool _Existing;

		// Token: 0x04000122 RID: 290
		private UserDetail _New;

		// Token: 0x04000123 RID: 291
		private UserDetail _Old;

		// Token: 0x04000124 RID: 292
		private bool _EditMode;

		// Token: 0x04000125 RID: 293
		private bool _ShowCreateLabel;

		// Token: 0x04000126 RID: 294
		private bool _ShowDontTransferLabel;

		// Token: 0x04000127 RID: 295
		private bool _IsCreateOptionAvailable;

		// Token: 0x04000128 RID: 296
		private bool _IsNewUserOptionAvailable;

		// Token: 0x04000129 RID: 297
		private bool _IsCurrentToCurrentOptionAvailable;

		// Token: 0x0400012A RID: 298
		private bool _IsMapToExistingOptionAvailable;

		// Token: 0x0400012B RID: 299
		private bool _IsUSerTypeEnabled;

		// Token: 0x0400012C RID: 300
		private bool _Selected;

		// Token: 0x0400012D RID: 301
		private string _CreatedUserPassword;

		// Token: 0x0400012E RID: 302
		private List<MapiProfileMapping> _MapiProfileMappings;

		// Token: 0x0400012F RID: 303
		private List<string> _AvailableProfiles;
	}
}
