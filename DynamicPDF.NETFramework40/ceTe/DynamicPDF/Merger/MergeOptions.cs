using System;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006F7 RID: 1783
	public class MergeOptions
	{
		// Token: 0x06004507 RID: 17671 RVA: 0x002367E9 File Offset: 0x002357E9
		public MergeOptions(bool mergeFormFields) : this(mergeFormFields, string.Empty)
		{
		}

		// Token: 0x06004508 RID: 17672 RVA: 0x002367FC File Offset: 0x002357FC
		public MergeOptions(bool mergeFormFields, string rootFormField)
		{
			this.a = true;
			this.b = true;
			this.c = true;
			this.d = true;
			this.e = true;
			this.f = true;
			this.g = true;
			this.h = true;
			this.i = true;
			this.j = true;
			this.k = true;
			this.l = true;
			this.m = true;
			this.n = null;
			this.o = null;
			this.p = true;
			this.q = true;
			base..ctor();
			this.a = mergeFormFields;
			this.n = rootFormField;
		}

		// Token: 0x06004509 RID: 17673 RVA: 0x00236898 File Offset: 0x00235898
		public MergeOptions()
		{
			this.a = true;
			this.b = true;
			this.c = true;
			this.d = true;
			this.e = true;
			this.f = true;
			this.g = true;
			this.h = true;
			this.i = true;
			this.j = true;
			this.k = true;
			this.l = true;
			this.m = true;
			this.n = null;
			this.o = null;
			this.p = true;
			this.q = true;
			base..ctor();
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x0600450A RID: 17674 RVA: 0x00236928 File Offset: 0x00235928
		// (set) Token: 0x0600450B RID: 17675 RVA: 0x00236940 File Offset: 0x00235940
		public bool FormFields
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x0600450C RID: 17676 RVA: 0x0023694C File Offset: 0x0023594C
		// (set) Token: 0x0600450D RID: 17677 RVA: 0x00236964 File Offset: 0x00235964
		public bool FormsXfaData
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x0600450E RID: 17678 RVA: 0x00236970 File Offset: 0x00235970
		// (set) Token: 0x0600450F RID: 17679 RVA: 0x00236988 File Offset: 0x00235988
		public bool PageAnnotations
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06004510 RID: 17680 RVA: 0x00236994 File Offset: 0x00235994
		// (set) Token: 0x06004511 RID: 17681 RVA: 0x002369AC File Offset: 0x002359AC
		public bool Outlines
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x06004512 RID: 17682 RVA: 0x002369B8 File Offset: 0x002359B8
		// (set) Token: 0x06004513 RID: 17683 RVA: 0x002369D0 File Offset: 0x002359D0
		public bool DocumentInfo
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x06004514 RID: 17684 RVA: 0x002369DC File Offset: 0x002359DC
		// (set) Token: 0x06004515 RID: 17685 RVA: 0x002369F4 File Offset: 0x002359F4
		public bool DocumentProperties
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x06004516 RID: 17686 RVA: 0x00236A00 File Offset: 0x00235A00
		// (set) Token: 0x06004517 RID: 17687 RVA: 0x00236A18 File Offset: 0x00235A18
		public bool OpenAction
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06004518 RID: 17688 RVA: 0x00236A24 File Offset: 0x00235A24
		// (set) Token: 0x06004519 RID: 17689 RVA: 0x00236A3C File Offset: 0x00235A3C
		public bool AllOtherData
		{
			get
			{
				return this.l;
			}
			set
			{
				this.l = value;
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x0600451A RID: 17690 RVA: 0x00236A48 File Offset: 0x00235A48
		// (set) Token: 0x0600451B RID: 17691 RVA: 0x00236A60 File Offset: 0x00235A60
		public bool DocumentJavaScript
		{
			get
			{
				return this.j;
			}
			set
			{
				this.j = value;
			}
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x0600451C RID: 17692 RVA: 0x00236A6C File Offset: 0x00235A6C
		// (set) Token: 0x0600451D RID: 17693 RVA: 0x00236A84 File Offset: 0x00235A84
		public bool EmbeddedFiles
		{
			get
			{
				return this.k;
			}
			set
			{
				this.k = value;
			}
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x0600451E RID: 17694 RVA: 0x00236A90 File Offset: 0x00235A90
		// (set) Token: 0x0600451F RID: 17695 RVA: 0x00236AA8 File Offset: 0x00235AA8
		public bool PageLabelsAndSections
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06004520 RID: 17696 RVA: 0x00236AB4 File Offset: 0x00235AB4
		// (set) Token: 0x06004521 RID: 17697 RVA: 0x00236ACC File Offset: 0x00235ACC
		public bool XmpMetadata
		{
			get
			{
				return this.i;
			}
			set
			{
				this.i = value;
			}
		}

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06004522 RID: 17698 RVA: 0x00236AD8 File Offset: 0x00235AD8
		// (set) Token: 0x06004523 RID: 17699 RVA: 0x00236AF0 File Offset: 0x00235AF0
		public bool LogicalStructure
		{
			get
			{
				return this.q;
			}
			set
			{
				this.q = value;
			}
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06004524 RID: 17700 RVA: 0x00236AFC File Offset: 0x00235AFC
		// (set) Token: 0x06004525 RID: 17701 RVA: 0x00236B14 File Offset: 0x00235B14
		public bool OutputIntent
		{
			get
			{
				return this.m;
			}
			set
			{
				this.m = value;
			}
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06004526 RID: 17702 RVA: 0x00236B20 File Offset: 0x00235B20
		// (set) Token: 0x06004527 RID: 17703 RVA: 0x00236B38 File Offset: 0x00235B38
		public Outline RootOutline
		{
			get
			{
				return this.o;
			}
			set
			{
				this.o = value;
			}
		}

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06004528 RID: 17704 RVA: 0x00236B44 File Offset: 0x00235B44
		// (set) Token: 0x06004529 RID: 17705 RVA: 0x00236B5C File Offset: 0x00235B5C
		public string RootFormField
		{
			get
			{
				return this.n;
			}
			set
			{
				this.n = value;
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x0600452A RID: 17706 RVA: 0x00236B68 File Offset: 0x00235B68
		// (set) Token: 0x0600452B RID: 17707 RVA: 0x00236B80 File Offset: 0x00235B80
		public bool OptionalContentInfo
		{
			get
			{
				return this.p;
			}
			set
			{
				this.p = value;
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x0600452C RID: 17708 RVA: 0x00236B8C File Offset: 0x00235B8C
		public static MergeOptions All
		{
			get
			{
				return new MergeOptions();
			}
		}

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x0600452D RID: 17709 RVA: 0x00236BA4 File Offset: 0x00235BA4
		public static MergeOptions Append
		{
			get
			{
				return new MergeOptions
				{
					l = false,
					e = false,
					f = false,
					j = false,
					g = false,
					b = false,
					i = false
				};
			}
		}

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x0600452E RID: 17710 RVA: 0x00236BF0 File Offset: 0x00235BF0
		public static MergeOptions None
		{
			get
			{
				return new MergeOptions
				{
					l = false,
					e = false,
					j = false,
					f = false,
					a = false,
					b = false,
					g = false,
					d = false,
					c = false,
					h = false,
					i = false,
					k = false,
					p = false,
					LogicalStructure = false
				};
			}
		}

		// Token: 0x0600452F RID: 17711 RVA: 0x00236C6C File Offset: 0x00235C6C
		internal abb a(MergeDocument A_0, PdfDocument A_1)
		{
			return new abb(A_0, A_1, this);
		}

		// Token: 0x04002659 RID: 9817
		private bool a;

		// Token: 0x0400265A RID: 9818
		private bool b;

		// Token: 0x0400265B RID: 9819
		private bool c;

		// Token: 0x0400265C RID: 9820
		private bool d;

		// Token: 0x0400265D RID: 9821
		private bool e;

		// Token: 0x0400265E RID: 9822
		private bool f;

		// Token: 0x0400265F RID: 9823
		private bool g;

		// Token: 0x04002660 RID: 9824
		private bool h;

		// Token: 0x04002661 RID: 9825
		private bool i;

		// Token: 0x04002662 RID: 9826
		private bool j;

		// Token: 0x04002663 RID: 9827
		private bool k;

		// Token: 0x04002664 RID: 9828
		private bool l;

		// Token: 0x04002665 RID: 9829
		private bool m;

		// Token: 0x04002666 RID: 9830
		private string n;

		// Token: 0x04002667 RID: 9831
		private Outline o;

		// Token: 0x04002668 RID: 9832
		private bool p;

		// Token: 0x04002669 RID: 9833
		private bool q;
	}
}
