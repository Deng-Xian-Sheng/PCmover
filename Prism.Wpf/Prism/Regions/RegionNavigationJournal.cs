using System;
using System.Collections.Generic;

namespace Prism.Regions
{
	// Token: 0x0200002D RID: 45
	public class RegionNavigationJournal : IRegionNavigationJournal
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00003E8A File Offset: 0x0000208A
		// (set) Token: 0x06000123 RID: 291 RVA: 0x00003E92 File Offset: 0x00002092
		public INavigateAsync NavigationTarget { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00003E9B File Offset: 0x0000209B
		// (set) Token: 0x06000125 RID: 293 RVA: 0x00003EA3 File Offset: 0x000020A3
		public IRegionNavigationJournalEntry CurrentEntry { get; private set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00003EAC File Offset: 0x000020AC
		public bool CanGoBack
		{
			get
			{
				return this.backStack.Count > 0;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00003EBC File Offset: 0x000020BC
		public bool CanGoForward
		{
			get
			{
				return this.forwardStack.Count > 0;
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00003ECC File Offset: 0x000020CC
		public void GoBack()
		{
			if (this.CanGoBack)
			{
				IRegionNavigationJournalEntry entry = this.backStack.Peek();
				this.InternalNavigate(entry, delegate(bool result)
				{
					if (result)
					{
						if (this.CurrentEntry != null)
						{
							this.forwardStack.Push(this.CurrentEntry);
						}
						this.backStack.Pop();
						this.CurrentEntry = entry;
					}
				});
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00003F18 File Offset: 0x00002118
		public void GoForward()
		{
			if (this.CanGoForward)
			{
				IRegionNavigationJournalEntry entry = this.forwardStack.Peek();
				this.InternalNavigate(entry, delegate(bool result)
				{
					if (result)
					{
						if (this.CurrentEntry != null)
						{
							this.backStack.Push(this.CurrentEntry);
						}
						this.forwardStack.Pop();
						this.CurrentEntry = entry;
					}
				});
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00003F63 File Offset: 0x00002163
		public void RecordNavigation(IRegionNavigationJournalEntry entry)
		{
			if (!this.isNavigatingInternal)
			{
				if (this.CurrentEntry != null)
				{
					this.backStack.Push(this.CurrentEntry);
				}
				this.forwardStack.Clear();
				this.CurrentEntry = entry;
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00003F98 File Offset: 0x00002198
		public void Clear()
		{
			this.CurrentEntry = null;
			this.backStack.Clear();
			this.forwardStack.Clear();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00003FB8 File Offset: 0x000021B8
		private void InternalNavigate(IRegionNavigationJournalEntry entry, Action<bool> callback)
		{
			this.isNavigatingInternal = true;
			this.NavigationTarget.RequestNavigate(entry.Uri, delegate(NavigationResult nr)
			{
				this.isNavigatingInternal = false;
				if (nr.Result != null)
				{
					callback(nr.Result.Value);
				}
			}, entry.Parameters);
		}

		// Token: 0x0400002E RID: 46
		private Stack<IRegionNavigationJournalEntry> backStack = new Stack<IRegionNavigationJournalEntry>();

		// Token: 0x0400002F RID: 47
		private Stack<IRegionNavigationJournalEntry> forwardStack = new Stack<IRegionNavigationJournalEntry>();

		// Token: 0x04000030 RID: 48
		private bool isNavigatingInternal;
	}
}
