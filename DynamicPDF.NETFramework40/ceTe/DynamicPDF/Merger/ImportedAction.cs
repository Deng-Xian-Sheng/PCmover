using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Merger
{
	// Token: 0x020006EE RID: 1774
	public class ImportedAction : Action
	{
		// Token: 0x06004464 RID: 17508 RVA: 0x00234788 File Offset: 0x00233788
		private ImportedAction()
		{
		}

		// Token: 0x06004465 RID: 17509 RVA: 0x00234793 File Offset: 0x00233793
		internal ImportedAction(abj A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06004466 RID: 17510 RVA: 0x002347A5 File Offset: 0x002337A5
		public override void Draw(DocumentWriter writer)
		{
			this.a.hz(writer);
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06004467 RID: 17511 RVA: 0x002347B8 File Offset: 0x002337B8
		public ImportedActionType ActionType
		{
			get
			{
				if (this.a != null)
				{
					this.a();
				}
				return this.b;
			}
		}

		// Token: 0x06004468 RID: 17512 RVA: 0x002347E8 File Offset: 0x002337E8
		private new void a()
		{
			abk abk = this.a.l();
			abu abu = null;
			while (abk != null)
			{
				int num = abk.a().j8();
				if (num == 19)
				{
					abu = (abu)abk.c();
				}
				abk = abk.d();
			}
			if (abu != null)
			{
				int num = abu.j8();
				if (num <= 243718500)
				{
					if (num <= 65524356)
					{
						if (num <= 2028847)
						{
							if (num != 87177)
							{
								if (num == 2028847)
								{
									this.b = ImportedActionType.GoTo;
								}
							}
							else
							{
								this.b = ImportedActionType.URI;
							}
						}
						else if (num != 2267429)
						{
							if (num == 65524356)
							{
								this.b = ImportedActionType.GoTo3DView;
							}
						}
						else
						{
							this.b = ImportedActionType.Hide;
						}
					}
					else if (num <= 129846226)
					{
						if (num != 129846213)
						{
							if (num == 129846226)
							{
								this.b = ImportedActionType.GoToRemote;
							}
						}
						else
						{
							this.b = ImportedActionType.GoToEmbedded;
						}
					}
					else if (num != 210197387)
					{
						if (num != 230648421)
						{
							if (num == 243718500)
							{
								this.b = ImportedActionType.Named;
							}
						}
						else
						{
							this.b = ImportedActionType.Movie;
						}
					}
					else
					{
						this.b = ImportedActionType.Launch;
					}
				}
				else if (num <= 346237253)
				{
					if (num <= 311281113)
					{
						if (num != 306475719)
						{
							if (num == 311281113)
							{
								this.b = ImportedActionType.ResetForm;
							}
						}
						else
						{
							this.b = ImportedActionType.Rendition;
						}
					}
					else if (num != 331307940)
					{
						if (num == 346237253)
						{
							this.b = ImportedActionType.Thread;
						}
					}
					else
					{
						this.b = ImportedActionType.Sound;
					}
				}
				else if (num <= 349703058)
				{
					if (num != 348789683)
					{
						if (num == 349703058)
						{
							this.b = ImportedActionType.SetOCGState;
						}
					}
					else
					{
						this.b = ImportedActionType.Transition;
					}
				}
				else if (num != 667736004)
				{
					if (num != 692974695)
					{
						if (num == 1034229459)
						{
							this.b = ImportedActionType.ImportData;
						}
					}
					else
					{
						this.b = ImportedActionType.JavaScript;
					}
				}
				else
				{
					this.b = ImportedActionType.SubmitForm;
				}
			}
		}

		// Token: 0x04002632 RID: 9778
		private new abj a;

		// Token: 0x04002633 RID: 9779
		private new ImportedActionType b;
	}
}
