using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x02000184 RID: 388
	public class JumpList
	{
		// Token: 0x06000F07 RID: 3847 RVA: 0x00034890 File Offset: 0x00032A90
		public static JumpList CreateJumpList()
		{
			return new JumpList(TaskbarManager.Instance.ApplicationId);
		}

		// Token: 0x06000F08 RID: 3848 RVA: 0x000348B4 File Offset: 0x00032AB4
		public static JumpList CreateJumpListForIndividualWindow(string appId, IntPtr windowHandle)
		{
			return new JumpList(appId, windowHandle);
		}

		// Token: 0x06000F09 RID: 3849 RVA: 0x000348D0 File Offset: 0x00032AD0
		public static JumpList CreateJumpListForIndividualWindow(string appId, Window window)
		{
			return new JumpList(appId, window);
		}

		// Token: 0x06000F0A RID: 3850 RVA: 0x000348EC File Offset: 0x00032AEC
		public void AddCustomCategories(params JumpListCustomCategory[] customCategories)
		{
			lock (this.syncLock)
			{
				if (this.customCategoriesCollection == null)
				{
					this.customCategoriesCollection = new JumpListCustomCategoryCollection();
				}
			}
			if (customCategories != null)
			{
				foreach (JumpListCustomCategory category in customCategories)
				{
					this.customCategoriesCollection.Add(category);
				}
			}
		}

		// Token: 0x06000F0B RID: 3851 RVA: 0x0003497C File Offset: 0x00032B7C
		public void AddUserTasks(params JumpListTask[] tasks)
		{
			if (this.userTasks == null)
			{
				lock (this.syncLock)
				{
					if (this.userTasks == null)
					{
						this.userTasks = new JumpListItemCollection<JumpListTask>();
					}
				}
			}
			if (tasks != null)
			{
				foreach (JumpListTask item in tasks)
				{
					this.userTasks.Add(item);
				}
			}
		}

		// Token: 0x06000F0C RID: 3852 RVA: 0x00034A1C File Offset: 0x00032C1C
		public void ClearAllUserTasks()
		{
			if (this.userTasks != null)
			{
				this.userTasks.Clear();
			}
		}

		// Token: 0x1700086F RID: 2159
		// (get) Token: 0x06000F0D RID: 3853 RVA: 0x00034A48 File Offset: 0x00032C48
		public uint MaxSlotsInList
		{
			get
			{
				uint result = 10U;
				object obj;
				HResult result2 = this.customDestinationList.BeginList(out result, ref TaskbarNativeMethods.TaskbarGuids.IObjectArray, out obj);
				if (CoreErrorHelper.Succeeded(result2))
				{
					this.customDestinationList.AbortList();
				}
				return result;
			}
		}

		// Token: 0x17000870 RID: 2160
		// (get) Token: 0x06000F0E RID: 3854 RVA: 0x00034A90 File Offset: 0x00032C90
		// (set) Token: 0x06000F0F RID: 3855 RVA: 0x00034AA7 File Offset: 0x00032CA7
		public JumpListKnownCategoryType KnownCategoryToDisplay { get; set; }

		// Token: 0x17000871 RID: 2161
		// (get) Token: 0x06000F10 RID: 3856 RVA: 0x00034AB0 File Offset: 0x00032CB0
		// (set) Token: 0x06000F11 RID: 3857 RVA: 0x00034AC8 File Offset: 0x00032CC8
		public int KnownCategoryOrdinalPosition
		{
			get
			{
				return this.knownCategoryOrdinalPosition;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value", LocalizedMessages.JumpListNegativeOrdinalPosition);
				}
				this.knownCategoryOrdinalPosition = value;
			}
		}

		// Token: 0x17000872 RID: 2162
		// (get) Token: 0x06000F12 RID: 3858 RVA: 0x00034AFC File Offset: 0x00032CFC
		// (set) Token: 0x06000F13 RID: 3859 RVA: 0x00034B13 File Offset: 0x00032D13
		public string ApplicationId { get; private set; }

		// Token: 0x06000F14 RID: 3860 RVA: 0x00034B1C File Offset: 0x00032D1C
		internal JumpList(string appID) : this(appID, TaskbarManager.Instance.OwnerHandle)
		{
		}

		// Token: 0x06000F15 RID: 3861 RVA: 0x00034B32 File Offset: 0x00032D32
		internal JumpList(string appID, Window window) : this(appID, new WindowInteropHelper(window).Handle)
		{
		}

		// Token: 0x06000F16 RID: 3862 RVA: 0x00034B4C File Offset: 0x00032D4C
		private JumpList(string appID, IntPtr windowHandle)
		{
			CoreHelpers.ThrowIfNotWin7();
			this.customDestinationList = (ICustomDestinationList)new CDestinationList();
			if (!string.IsNullOrEmpty(appID))
			{
				this.ApplicationId = appID;
				if (!TaskbarManager.Instance.ApplicationIdSetProcessWide)
				{
					TaskbarManager.Instance.ApplicationId = appID;
				}
				TaskbarManager.Instance.SetApplicationIdForSpecificWindow(windowHandle, appID);
			}
		}

		// Token: 0x06000F17 RID: 3863 RVA: 0x00034BE5 File Offset: 0x00032DE5
		public static void AddToRecent(string destination)
		{
			TaskbarNativeMethods.SHAddToRecentDocs(destination);
		}

		// Token: 0x06000F18 RID: 3864 RVA: 0x00034BF0 File Offset: 0x00032DF0
		public void Refresh()
		{
			if (!string.IsNullOrEmpty(this.ApplicationId))
			{
				this.customDestinationList.SetAppID(this.ApplicationId);
			}
			this.BeginList();
			Exception ex = null;
			try
			{
				this.AppendTaskList();
			}
			catch (Exception ex2)
			{
				ex = ex2;
			}
			try
			{
				this.AppendCustomCategories();
			}
			finally
			{
				this.customDestinationList.CommitList();
			}
			if (ex != null)
			{
				throw ex;
			}
		}

		// Token: 0x06000F19 RID: 3865 RVA: 0x00034C80 File Offset: 0x00032E80
		private void BeginList()
		{
			uint num = 10U;
			object obj;
			HResult result = this.customDestinationList.BeginList(out num, ref TaskbarNativeMethods.TaskbarGuids.IObjectArray, out obj);
			if (!CoreErrorHelper.Succeeded(result))
			{
				throw new ShellException(result);
			}
			IEnumerable enumerable = this.ProcessDeletedItems((IObjectArray)obj);
			if (this.JumpListItemsRemoved != null && enumerable != null && enumerable.GetEnumerator().MoveNext())
			{
				this.JumpListItemsRemoved(this, new UserRemovedJumpListItemsEventArgs(enumerable));
			}
		}

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x06000F1A RID: 3866 RVA: 0x00034D00 File Offset: 0x00032F00
		// (remove) Token: 0x06000F1B RID: 3867 RVA: 0x00034D3C File Offset: 0x00032F3C
		public event EventHandler<UserRemovedJumpListItemsEventArgs> JumpListItemsRemoved = delegate(object param0, UserRemovedJumpListItemsEventArgs param1)
		{
		};

		// Token: 0x17000873 RID: 2163
		// (get) Token: 0x06000F1C RID: 3868 RVA: 0x00034D78 File Offset: 0x00032F78
		public IEnumerable RemovedDestinations
		{
			get
			{
				object obj;
				this.customDestinationList.GetRemovedDestinations(ref TaskbarNativeMethods.TaskbarGuids.IObjectArray, out obj);
				return this.ProcessDeletedItems((IObjectArray)obj);
			}
		}

		// Token: 0x06000F1D RID: 3869 RVA: 0x00034DAC File Offset: 0x00032FAC
		private IEnumerable<string> ProcessDeletedItems(IObjectArray removedItems)
		{
			List<string> list = new List<string>();
			uint num;
			removedItems.GetCount(out num);
			for (uint num2 = 0U; num2 < num; num2 += 1U)
			{
				object obj;
				removedItems.GetAt(num2, ref TaskbarNativeMethods.TaskbarGuids.IUnknown, out obj);
				IShellItem shellItem = obj as IShellItem;
				IShellLinkW link;
				if (shellItem != null)
				{
					list.Add(this.RemoveCustomCategoryItem(shellItem));
				}
				else if ((link = (obj as IShellLinkW)) != null)
				{
					list.Add(this.RemoveCustomCategoryLink(link));
				}
			}
			return list;
		}

		// Token: 0x06000F1E RID: 3870 RVA: 0x00034E3C File Offset: 0x0003303C
		private string RemoveCustomCategoryItem(IShellItem item)
		{
			string text = null;
			if (this.customCategoriesCollection != null)
			{
				IntPtr zero = IntPtr.Zero;
				if (item.GetDisplayName(ShellNativeMethods.ShellItemDesignNameOptions.FileSystemPath, out zero) == HResult.Ok && zero != IntPtr.Zero)
				{
					text = Marshal.PtrToStringAuto(zero);
					Marshal.FreeCoTaskMem(zero);
				}
				foreach (JumpListCustomCategory jumpListCustomCategory in ((IEnumerable<JumpListCustomCategory>)this.customCategoriesCollection))
				{
					jumpListCustomCategory.RemoveJumpListItem(text);
				}
			}
			return text;
		}

		// Token: 0x06000F1F RID: 3871 RVA: 0x00034EFC File Offset: 0x000330FC
		private string RemoveCustomCategoryLink(IShellLinkW link)
		{
			string text = null;
			if (this.customCategoriesCollection != null)
			{
				StringBuilder stringBuilder = new StringBuilder(256);
				link.GetPath(stringBuilder, stringBuilder.Capacity, IntPtr.Zero, 2U);
				text = stringBuilder.ToString();
				foreach (JumpListCustomCategory jumpListCustomCategory in ((IEnumerable<JumpListCustomCategory>)this.customCategoriesCollection))
				{
					jumpListCustomCategory.RemoveJumpListItem(text);
				}
			}
			return text;
		}

		// Token: 0x06000F20 RID: 3872 RVA: 0x00034FA0 File Offset: 0x000331A0
		private void AppendCustomCategories()
		{
			int num = 0;
			bool flag = false;
			if (this.customCategoriesCollection != null)
			{
				foreach (JumpListCustomCategory jumpListCustomCategory in ((IEnumerable<JumpListCustomCategory>)this.customCategoriesCollection))
				{
					if (!flag && num == this.KnownCategoryOrdinalPosition)
					{
						this.AppendKnownCategories();
						flag = true;
					}
					if (jumpListCustomCategory.JumpListItems.Count != 0)
					{
						IObjectCollection objectCollection = (IObjectCollection)new CEnumerableObjectCollection();
						foreach (IJumpListItem jumpListItem in ((IEnumerable<IJumpListItem>)jumpListCustomCategory.JumpListItems))
						{
							JumpListItem jumpListItem2 = jumpListItem as JumpListItem;
							JumpListLink jumpListLink = jumpListItem as JumpListLink;
							if (jumpListItem2 != null)
							{
								objectCollection.AddObject(jumpListItem2.NativeShellItem);
							}
							else if (jumpListLink != null)
							{
								objectCollection.AddObject(jumpListLink.NativeShellLink);
							}
						}
						HResult hresult = this.customDestinationList.AppendCategory(jumpListCustomCategory.Name, (IObjectArray)objectCollection);
						if (!CoreErrorHelper.Succeeded(hresult))
						{
							if (hresult == (HResult)(-2147217661))
							{
								throw new InvalidOperationException(LocalizedMessages.JumpListFileTypeNotRegistered);
							}
							if (hresult == (HResult)(-2147024891))
							{
								throw new UnauthorizedAccessException(LocalizedMessages.JumpListCustomCategoriesDisabled);
							}
							throw new ShellException(hresult);
						}
						else
						{
							num++;
						}
					}
				}
			}
			if (!flag)
			{
				this.AppendKnownCategories();
			}
		}

		// Token: 0x06000F21 RID: 3873 RVA: 0x00035198 File Offset: 0x00033398
		private void AppendTaskList()
		{
			if (this.userTasks != null && this.userTasks.Count != 0)
			{
				IObjectCollection objectCollection = (IObjectCollection)new CEnumerableObjectCollection();
				foreach (JumpListTask jumpListTask in ((IEnumerable<JumpListTask>)this.userTasks))
				{
					JumpListLink jumpListLink = jumpListTask as JumpListLink;
					JumpListSeparator jumpListSeparator;
					if (jumpListLink != null)
					{
						objectCollection.AddObject(jumpListLink.NativeShellLink);
					}
					else if ((jumpListSeparator = (jumpListTask as JumpListSeparator)) != null)
					{
						objectCollection.AddObject(jumpListSeparator.NativeShellLink);
					}
				}
				HResult hresult = this.customDestinationList.AddUserTasks((IObjectArray)objectCollection);
				if (!CoreErrorHelper.Succeeded(hresult))
				{
					if (hresult == (HResult)(-2147217661))
					{
						throw new InvalidOperationException(LocalizedMessages.JumpListFileTypeNotRegistered);
					}
					throw new ShellException(hresult);
				}
			}
		}

		// Token: 0x06000F22 RID: 3874 RVA: 0x000352B4 File Offset: 0x000334B4
		private void AppendKnownCategories()
		{
			if (this.KnownCategoryToDisplay == JumpListKnownCategoryType.Recent)
			{
				this.customDestinationList.AppendKnownCategory(KnownDestinationCategory.Recent);
			}
			else if (this.KnownCategoryToDisplay == JumpListKnownCategoryType.Frequent)
			{
				this.customDestinationList.AppendKnownCategory(KnownDestinationCategory.Frequent);
			}
		}

		// Token: 0x04000667 RID: 1639
		private readonly object syncLock = new object();

		// Token: 0x04000668 RID: 1640
		private ICustomDestinationList customDestinationList;

		// Token: 0x04000669 RID: 1641
		private JumpListCustomCategoryCollection customCategoriesCollection;

		// Token: 0x0400066A RID: 1642
		private JumpListItemCollection<JumpListTask> userTasks;

		// Token: 0x0400066B RID: 1643
		private int knownCategoryOrdinalPosition;
	}
}
