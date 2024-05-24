using System;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x0200079B RID: 1947
	internal sealed class NameInfo
	{
		// Token: 0x06005455 RID: 21589 RVA: 0x0012936D File Offset: 0x0012756D
		internal NameInfo()
		{
		}

		// Token: 0x06005456 RID: 21590 RVA: 0x00129378 File Offset: 0x00127578
		internal void Init()
		{
			this.NIFullName = null;
			this.NIobjectId = 0L;
			this.NIassemId = 0L;
			this.NIprimitiveTypeEnum = InternalPrimitiveTypeE.Invalid;
			this.NItype = null;
			this.NIisSealed = false;
			this.NItransmitTypeOnObject = false;
			this.NItransmitTypeOnMember = false;
			this.NIisParentTypeOnObject = false;
			this.NIisArray = false;
			this.NIisArrayItem = false;
			this.NIarrayEnum = InternalArrayTypeE.Empty;
			this.NIsealedStatusChecked = false;
		}

		// Token: 0x17000DDA RID: 3546
		// (get) Token: 0x06005457 RID: 21591 RVA: 0x001293E2 File Offset: 0x001275E2
		public bool IsSealed
		{
			get
			{
				if (!this.NIsealedStatusChecked)
				{
					this.NIisSealed = this.NItype.IsSealed;
					this.NIsealedStatusChecked = true;
				}
				return this.NIisSealed;
			}
		}

		// Token: 0x17000DDB RID: 3547
		// (get) Token: 0x06005458 RID: 21592 RVA: 0x0012940A File Offset: 0x0012760A
		// (set) Token: 0x06005459 RID: 21593 RVA: 0x0012942B File Offset: 0x0012762B
		public string NIname
		{
			get
			{
				if (this.NIFullName == null)
				{
					this.NIFullName = this.NItype.FullName;
				}
				return this.NIFullName;
			}
			set
			{
				this.NIFullName = value;
			}
		}

		// Token: 0x0400265D RID: 9821
		internal string NIFullName;

		// Token: 0x0400265E RID: 9822
		internal long NIobjectId;

		// Token: 0x0400265F RID: 9823
		internal long NIassemId;

		// Token: 0x04002660 RID: 9824
		internal InternalPrimitiveTypeE NIprimitiveTypeEnum;

		// Token: 0x04002661 RID: 9825
		internal Type NItype;

		// Token: 0x04002662 RID: 9826
		internal bool NIisSealed;

		// Token: 0x04002663 RID: 9827
		internal bool NIisArray;

		// Token: 0x04002664 RID: 9828
		internal bool NIisArrayItem;

		// Token: 0x04002665 RID: 9829
		internal bool NItransmitTypeOnObject;

		// Token: 0x04002666 RID: 9830
		internal bool NItransmitTypeOnMember;

		// Token: 0x04002667 RID: 9831
		internal bool NIisParentTypeOnObject;

		// Token: 0x04002668 RID: 9832
		internal InternalArrayTypeE NIarrayEnum;

		// Token: 0x04002669 RID: 9833
		private bool NIsealedStatusChecked;
	}
}
