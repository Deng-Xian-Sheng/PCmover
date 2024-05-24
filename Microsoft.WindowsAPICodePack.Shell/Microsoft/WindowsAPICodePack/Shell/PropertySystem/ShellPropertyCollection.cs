using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x0200013E RID: 318
	public class ShellPropertyCollection : ReadOnlyCollection<IShellProperty>, IDisposable
	{
		// Token: 0x06000DB3 RID: 3507 RVA: 0x00032FB6 File Offset: 0x000311B6
		internal ShellPropertyCollection(IPropertyStore nativePropertyStore) : base(new List<IShellProperty>())
		{
			this.NativePropertyStore = nativePropertyStore;
			this.AddProperties(nativePropertyStore);
		}

		// Token: 0x06000DB4 RID: 3508 RVA: 0x00032FD8 File Offset: 0x000311D8
		public ShellPropertyCollection(ShellObject parent) : base(new List<IShellProperty>())
		{
			this.ParentShellObject = parent;
			IPropertyStore propertyStore = null;
			try
			{
				propertyStore = ShellPropertyCollection.CreateDefaultPropertyStore(this.ParentShellObject);
				this.AddProperties(propertyStore);
			}
			catch
			{
				if (parent != null)
				{
					parent.Dispose();
				}
				throw;
			}
			finally
			{
				if (propertyStore != null)
				{
					Marshal.ReleaseComObject(propertyStore);
					propertyStore = null;
				}
			}
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x00033068 File Offset: 0x00031268
		public ShellPropertyCollection(string path) : this(ShellObjectFactory.Create(path))
		{
		}

		// Token: 0x1700084B RID: 2123
		// (get) Token: 0x06000DB6 RID: 3510 RVA: 0x0003307C File Offset: 0x0003127C
		// (set) Token: 0x06000DB7 RID: 3511 RVA: 0x00033093 File Offset: 0x00031293
		private ShellObject ParentShellObject { get; set; }

		// Token: 0x1700084C RID: 2124
		// (get) Token: 0x06000DB8 RID: 3512 RVA: 0x0003309C File Offset: 0x0003129C
		// (set) Token: 0x06000DB9 RID: 3513 RVA: 0x000330B3 File Offset: 0x000312B3
		private IPropertyStore NativePropertyStore { get; set; }

		// Token: 0x06000DBA RID: 3514 RVA: 0x000330BC File Offset: 0x000312BC
		private void AddProperties(IPropertyStore nativePropertyStore)
		{
			uint num;
			nativePropertyStore.GetCount(out num);
			for (uint num2 = 0U; num2 < num; num2 += 1U)
			{
				PropertyKey propKey;
				nativePropertyStore.GetAt(num2, out propKey);
				if (this.ParentShellObject != null)
				{
					base.Items.Add(this.ParentShellObject.Properties.CreateTypedProperty(propKey));
				}
				else
				{
					base.Items.Add(ShellPropertyCollection.CreateTypedProperty(propKey, this.NativePropertyStore));
				}
			}
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x00033140 File Offset: 0x00031340
		internal static IPropertyStore CreateDefaultPropertyStore(ShellObject shellObj)
		{
			IPropertyStore propertyStore = null;
			Guid guid = new Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99");
			int propertyStore2 = shellObj.NativeShellItem2.GetPropertyStore(ShellNativeMethods.GetPropertyStoreOptions.BestEffort, ref guid, out propertyStore);
			if (propertyStore == null || !CoreErrorHelper.Succeeded(propertyStore2))
			{
				throw new ShellException(propertyStore2);
			}
			return propertyStore;
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x000331C0 File Offset: 0x000313C0
		public bool Contains(string canonicalName)
		{
			if (string.IsNullOrEmpty(canonicalName))
			{
				throw new ArgumentException(LocalizedMessages.PropertyCollectionNullCanonicalName, "canonicalName");
			}
			return base.Items.Any((IShellProperty p) => p.CanonicalName == canonicalName);
		}

		// Token: 0x06000DBD RID: 3517 RVA: 0x00033248 File Offset: 0x00031448
		public bool Contains(PropertyKey key)
		{
			return base.Items.Any((IShellProperty p) => p.PropertyKey == key);
		}

		// Token: 0x1700084D RID: 2125
		public IShellProperty this[string canonicalName]
		{
			get
			{
				if (string.IsNullOrEmpty(canonicalName))
				{
					throw new ArgumentException(LocalizedMessages.PropertyCollectionNullCanonicalName, "canonicalName");
				}
				IShellProperty shellProperty = base.Items.FirstOrDefault((IShellProperty p) => p.CanonicalName == canonicalName);
				if (shellProperty == null)
				{
					throw new IndexOutOfRangeException(LocalizedMessages.PropertyCollectionCanonicalInvalidIndex);
				}
				return shellProperty;
			}
		}

		// Token: 0x1700084E RID: 2126
		public IShellProperty this[PropertyKey key]
		{
			get
			{
				IShellProperty shellProperty = base.Items.FirstOrDefault((IShellProperty p) => p.PropertyKey == key);
				if (shellProperty != null)
				{
					return shellProperty;
				}
				throw new IndexOutOfRangeException(LocalizedMessages.PropertyCollectionInvalidIndex);
			}
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x00033398 File Offset: 0x00031598
		internal static IShellProperty CreateTypedProperty(PropertyKey propKey, IPropertyStore NativePropertyStore)
		{
			return ShellPropertyFactory.CreateShellProperty(propKey, NativePropertyStore);
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x000333B4 File Offset: 0x000315B4
		protected virtual void Dispose(bool disposing)
		{
			if (this.NativePropertyStore != null)
			{
				Marshal.ReleaseComObject(this.NativePropertyStore);
				this.NativePropertyStore = null;
			}
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x000333E5 File Offset: 0x000315E5
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x000333F8 File Offset: 0x000315F8
		~ShellPropertyCollection()
		{
			this.Dispose(false);
		}
	}
}
