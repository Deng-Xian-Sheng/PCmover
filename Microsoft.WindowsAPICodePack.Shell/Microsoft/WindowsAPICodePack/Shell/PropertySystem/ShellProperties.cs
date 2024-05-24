using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.WindowsAPICodePack.Shell.Resources;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Shell.PropertySystem
{
	// Token: 0x020000AC RID: 172
	public class ShellProperties : IDisposable
	{
		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x000129E4 File Offset: 0x00010BE4
		// (set) Token: 0x06000589 RID: 1417 RVA: 0x000129FB File Offset: 0x00010BFB
		private ShellObject ParentShellObject { get; set; }

		// Token: 0x0600058A RID: 1418 RVA: 0x00012A04 File Offset: 0x00010C04
		internal ShellProperties(ShellObject parent)
		{
			this.ParentShellObject = parent;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00012A18 File Offset: 0x00010C18
		public IShellProperty GetProperty(PropertyKey key)
		{
			return this.CreateTypedProperty(key);
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00012A34 File Offset: 0x00010C34
		public IShellProperty GetProperty(string canonicalName)
		{
			return this.CreateTypedProperty(canonicalName);
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00012A50 File Offset: 0x00010C50
		public ShellProperty<T> GetProperty<T>(PropertyKey key)
		{
			return this.CreateTypedProperty(key) as ShellProperty<T>;
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00012A70 File Offset: 0x00010C70
		public ShellProperty<T> GetProperty<T>(string canonicalName)
		{
			return this.CreateTypedProperty(canonicalName) as ShellProperty<T>;
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x00012A90 File Offset: 0x00010C90
		public ShellProperties.PropertySystem System
		{
			get
			{
				if (this.propertySystem == null)
				{
					this.propertySystem = new ShellProperties.PropertySystem(this.ParentShellObject);
				}
				return this.propertySystem;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x00012ACC File Offset: 0x00010CCC
		public ShellPropertyCollection DefaultPropertyCollection
		{
			get
			{
				if (this.defaultPropertyCollection == null)
				{
					this.defaultPropertyCollection = new ShellPropertyCollection(this.ParentShellObject);
				}
				return this.defaultPropertyCollection;
			}
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00012B08 File Offset: 0x00010D08
		public ShellPropertyWriter GetPropertyWriter()
		{
			return new ShellPropertyWriter(this.ParentShellObject);
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x00012B28 File Offset: 0x00010D28
		internal IShellProperty CreateTypedProperty<T>(PropertyKey propKey)
		{
			ShellPropertyDescription propertyDescription = ShellPropertyDescriptionsCache.Cache.GetPropertyDescription(propKey);
			return new ShellProperty<T>(propKey, propertyDescription, this.ParentShellObject);
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00012B54 File Offset: 0x00010D54
		internal IShellProperty CreateTypedProperty(PropertyKey propKey)
		{
			return ShellPropertyFactory.CreateShellProperty(propKey, this.ParentShellObject);
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x00012B74 File Offset: 0x00010D74
		internal IShellProperty CreateTypedProperty(string canonicalName)
		{
			PropertyKey propKey;
			int num = PropertySystemNativeMethods.PSGetPropertyKeyFromName(canonicalName, out propKey);
			if (!CoreErrorHelper.Succeeded(num))
			{
				throw new ArgumentException(LocalizedMessages.ShellInvalidCanonicalName, Marshal.GetExceptionForHR(num));
			}
			return this.CreateTypedProperty(propKey);
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00012BB2 File Offset: 0x00010DB2
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00012BC4 File Offset: 0x00010DC4
		protected virtual void Dispose(bool disposed)
		{
			if (disposed && this.defaultPropertyCollection != null)
			{
				this.defaultPropertyCollection.Dispose();
			}
		}

		// Token: 0x04000335 RID: 821
		private ShellPropertyCollection defaultPropertyCollection;

		// Token: 0x04000336 RID: 822
		private ShellProperties.PropertySystem propertySystem;

		// Token: 0x020000AE RID: 174
		public class PropertySystem : PropertyStoreItems
		{
			// Token: 0x06000598 RID: 1432 RVA: 0x00012BFC File Offset: 0x00010DFC
			internal PropertySystem(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700017E RID: 382
			// (get) Token: 0x06000599 RID: 1433 RVA: 0x00012C1C File Offset: 0x00010E1C
			public ShellProperty<int?> AcquisitionID
			{
				get
				{
					PropertyKey acquisitionID = SystemProperties.System.AcquisitionID;
					if (!this.hashtable.ContainsKey(acquisitionID))
					{
						this.hashtable.Add(acquisitionID, this.shellObjectParent.Properties.CreateTypedProperty<int?>(acquisitionID));
					}
					return this.hashtable[acquisitionID] as ShellProperty<int?>;
				}
			}

			// Token: 0x1700017F RID: 383
			// (get) Token: 0x0600059A RID: 1434 RVA: 0x00012C84 File Offset: 0x00010E84
			public ShellProperty<string> ApplicationName
			{
				get
				{
					PropertyKey applicationName = SystemProperties.System.ApplicationName;
					if (!this.hashtable.ContainsKey(applicationName))
					{
						this.hashtable.Add(applicationName, this.shellObjectParent.Properties.CreateTypedProperty<string>(applicationName));
					}
					return this.hashtable[applicationName] as ShellProperty<string>;
				}
			}

			// Token: 0x17000180 RID: 384
			// (get) Token: 0x0600059B RID: 1435 RVA: 0x00012CEC File Offset: 0x00010EEC
			public ShellProperty<string[]> Author
			{
				get
				{
					PropertyKey author = SystemProperties.System.Author;
					if (!this.hashtable.ContainsKey(author))
					{
						this.hashtable.Add(author, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(author));
					}
					return this.hashtable[author] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000181 RID: 385
			// (get) Token: 0x0600059C RID: 1436 RVA: 0x00012D54 File Offset: 0x00010F54
			public ShellProperty<ulong?> Capacity
			{
				get
				{
					PropertyKey capacity = SystemProperties.System.Capacity;
					if (!this.hashtable.ContainsKey(capacity))
					{
						this.hashtable.Add(capacity, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(capacity));
					}
					return this.hashtable[capacity] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x17000182 RID: 386
			// (get) Token: 0x0600059D RID: 1437 RVA: 0x00012DBC File Offset: 0x00010FBC
			public ShellProperty<string[]> Category
			{
				get
				{
					PropertyKey category = SystemProperties.System.Category;
					if (!this.hashtable.ContainsKey(category))
					{
						this.hashtable.Add(category, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(category));
					}
					return this.hashtable[category] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000183 RID: 387
			// (get) Token: 0x0600059E RID: 1438 RVA: 0x00012E24 File Offset: 0x00011024
			public ShellProperty<string> Comment
			{
				get
				{
					PropertyKey comment = SystemProperties.System.Comment;
					if (!this.hashtable.ContainsKey(comment))
					{
						this.hashtable.Add(comment, this.shellObjectParent.Properties.CreateTypedProperty<string>(comment));
					}
					return this.hashtable[comment] as ShellProperty<string>;
				}
			}

			// Token: 0x17000184 RID: 388
			// (get) Token: 0x0600059F RID: 1439 RVA: 0x00012E8C File Offset: 0x0001108C
			public ShellProperty<string> Company
			{
				get
				{
					PropertyKey company = SystemProperties.System.Company;
					if (!this.hashtable.ContainsKey(company))
					{
						this.hashtable.Add(company, this.shellObjectParent.Properties.CreateTypedProperty<string>(company));
					}
					return this.hashtable[company] as ShellProperty<string>;
				}
			}

			// Token: 0x17000185 RID: 389
			// (get) Token: 0x060005A0 RID: 1440 RVA: 0x00012EF4 File Offset: 0x000110F4
			public ShellProperty<string> ComputerName
			{
				get
				{
					PropertyKey computerName = SystemProperties.System.ComputerName;
					if (!this.hashtable.ContainsKey(computerName))
					{
						this.hashtable.Add(computerName, this.shellObjectParent.Properties.CreateTypedProperty<string>(computerName));
					}
					return this.hashtable[computerName] as ShellProperty<string>;
				}
			}

			// Token: 0x17000186 RID: 390
			// (get) Token: 0x060005A1 RID: 1441 RVA: 0x00012F5C File Offset: 0x0001115C
			public ShellProperty<IntPtr[]> ContainedItems
			{
				get
				{
					PropertyKey containedItems = SystemProperties.System.ContainedItems;
					if (!this.hashtable.ContainsKey(containedItems))
					{
						this.hashtable.Add(containedItems, this.shellObjectParent.Properties.CreateTypedProperty<IntPtr[]>(containedItems));
					}
					return this.hashtable[containedItems] as ShellProperty<IntPtr[]>;
				}
			}

			// Token: 0x17000187 RID: 391
			// (get) Token: 0x060005A2 RID: 1442 RVA: 0x00012FC4 File Offset: 0x000111C4
			public ShellProperty<string> ContentStatus
			{
				get
				{
					PropertyKey contentStatus = SystemProperties.System.ContentStatus;
					if (!this.hashtable.ContainsKey(contentStatus))
					{
						this.hashtable.Add(contentStatus, this.shellObjectParent.Properties.CreateTypedProperty<string>(contentStatus));
					}
					return this.hashtable[contentStatus] as ShellProperty<string>;
				}
			}

			// Token: 0x17000188 RID: 392
			// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0001302C File Offset: 0x0001122C
			public ShellProperty<string> ContentType
			{
				get
				{
					PropertyKey contentType = SystemProperties.System.ContentType;
					if (!this.hashtable.ContainsKey(contentType))
					{
						this.hashtable.Add(contentType, this.shellObjectParent.Properties.CreateTypedProperty<string>(contentType));
					}
					return this.hashtable[contentType] as ShellProperty<string>;
				}
			}

			// Token: 0x17000189 RID: 393
			// (get) Token: 0x060005A4 RID: 1444 RVA: 0x00013094 File Offset: 0x00011294
			public ShellProperty<string> Copyright
			{
				get
				{
					PropertyKey copyright = SystemProperties.System.Copyright;
					if (!this.hashtable.ContainsKey(copyright))
					{
						this.hashtable.Add(copyright, this.shellObjectParent.Properties.CreateTypedProperty<string>(copyright));
					}
					return this.hashtable[copyright] as ShellProperty<string>;
				}
			}

			// Token: 0x1700018A RID: 394
			// (get) Token: 0x060005A5 RID: 1445 RVA: 0x000130FC File Offset: 0x000112FC
			public ShellProperty<DateTime?> DateAccessed
			{
				get
				{
					PropertyKey dateAccessed = SystemProperties.System.DateAccessed;
					if (!this.hashtable.ContainsKey(dateAccessed))
					{
						this.hashtable.Add(dateAccessed, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateAccessed));
					}
					return this.hashtable[dateAccessed] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x1700018B RID: 395
			// (get) Token: 0x060005A6 RID: 1446 RVA: 0x00013164 File Offset: 0x00011364
			public ShellProperty<DateTime?> DateAcquired
			{
				get
				{
					PropertyKey dateAcquired = SystemProperties.System.DateAcquired;
					if (!this.hashtable.ContainsKey(dateAcquired))
					{
						this.hashtable.Add(dateAcquired, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateAcquired));
					}
					return this.hashtable[dateAcquired] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x1700018C RID: 396
			// (get) Token: 0x060005A7 RID: 1447 RVA: 0x000131CC File Offset: 0x000113CC
			public ShellProperty<DateTime?> DateArchived
			{
				get
				{
					PropertyKey dateArchived = SystemProperties.System.DateArchived;
					if (!this.hashtable.ContainsKey(dateArchived))
					{
						this.hashtable.Add(dateArchived, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateArchived));
					}
					return this.hashtable[dateArchived] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x1700018D RID: 397
			// (get) Token: 0x060005A8 RID: 1448 RVA: 0x00013234 File Offset: 0x00011434
			public ShellProperty<DateTime?> DateCompleted
			{
				get
				{
					PropertyKey dateCompleted = SystemProperties.System.DateCompleted;
					if (!this.hashtable.ContainsKey(dateCompleted))
					{
						this.hashtable.Add(dateCompleted, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateCompleted));
					}
					return this.hashtable[dateCompleted] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x1700018E RID: 398
			// (get) Token: 0x060005A9 RID: 1449 RVA: 0x0001329C File Offset: 0x0001149C
			public ShellProperty<DateTime?> DateCreated
			{
				get
				{
					PropertyKey dateCreated = SystemProperties.System.DateCreated;
					if (!this.hashtable.ContainsKey(dateCreated))
					{
						this.hashtable.Add(dateCreated, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateCreated));
					}
					return this.hashtable[dateCreated] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x1700018F RID: 399
			// (get) Token: 0x060005AA RID: 1450 RVA: 0x00013304 File Offset: 0x00011504
			public ShellProperty<DateTime?> DateImported
			{
				get
				{
					PropertyKey dateImported = SystemProperties.System.DateImported;
					if (!this.hashtable.ContainsKey(dateImported))
					{
						this.hashtable.Add(dateImported, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateImported));
					}
					return this.hashtable[dateImported] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000190 RID: 400
			// (get) Token: 0x060005AB RID: 1451 RVA: 0x0001336C File Offset: 0x0001156C
			public ShellProperty<DateTime?> DateModified
			{
				get
				{
					PropertyKey dateModified = SystemProperties.System.DateModified;
					if (!this.hashtable.ContainsKey(dateModified))
					{
						this.hashtable.Add(dateModified, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateModified));
					}
					return this.hashtable[dateModified] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000191 RID: 401
			// (get) Token: 0x060005AC RID: 1452 RVA: 0x000133D4 File Offset: 0x000115D4
			public ShellProperty<byte[]> DescriptionID
			{
				get
				{
					PropertyKey descriptionID = SystemProperties.System.DescriptionID;
					if (!this.hashtable.ContainsKey(descriptionID))
					{
						this.hashtable.Add(descriptionID, this.shellObjectParent.Properties.CreateTypedProperty<byte[]>(descriptionID));
					}
					return this.hashtable[descriptionID] as ShellProperty<byte[]>;
				}
			}

			// Token: 0x17000192 RID: 402
			// (get) Token: 0x060005AD RID: 1453 RVA: 0x0001343C File Offset: 0x0001163C
			public ShellProperty<DateTime?> DueDate
			{
				get
				{
					PropertyKey dueDate = SystemProperties.System.DueDate;
					if (!this.hashtable.ContainsKey(dueDate))
					{
						this.hashtable.Add(dueDate, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dueDate));
					}
					return this.hashtable[dueDate] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000193 RID: 403
			// (get) Token: 0x060005AE RID: 1454 RVA: 0x000134A4 File Offset: 0x000116A4
			public ShellProperty<DateTime?> EndDate
			{
				get
				{
					PropertyKey endDate = SystemProperties.System.EndDate;
					if (!this.hashtable.ContainsKey(endDate))
					{
						this.hashtable.Add(endDate, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(endDate));
					}
					return this.hashtable[endDate] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000194 RID: 404
			// (get) Token: 0x060005AF RID: 1455 RVA: 0x0001350C File Offset: 0x0001170C
			public ShellProperty<ulong?> FileAllocationSize
			{
				get
				{
					PropertyKey fileAllocationSize = SystemProperties.System.FileAllocationSize;
					if (!this.hashtable.ContainsKey(fileAllocationSize))
					{
						this.hashtable.Add(fileAllocationSize, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(fileAllocationSize));
					}
					return this.hashtable[fileAllocationSize] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x17000195 RID: 405
			// (get) Token: 0x060005B0 RID: 1456 RVA: 0x00013574 File Offset: 0x00011774
			public ShellProperty<uint?> FileAttributes
			{
				get
				{
					PropertyKey fileAttributes = SystemProperties.System.FileAttributes;
					if (!this.hashtable.ContainsKey(fileAttributes))
					{
						this.hashtable.Add(fileAttributes, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(fileAttributes));
					}
					return this.hashtable[fileAttributes] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000196 RID: 406
			// (get) Token: 0x060005B1 RID: 1457 RVA: 0x000135DC File Offset: 0x000117DC
			public ShellProperty<ulong?> FileCount
			{
				get
				{
					PropertyKey fileCount = SystemProperties.System.FileCount;
					if (!this.hashtable.ContainsKey(fileCount))
					{
						this.hashtable.Add(fileCount, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(fileCount));
					}
					return this.hashtable[fileCount] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x17000197 RID: 407
			// (get) Token: 0x060005B2 RID: 1458 RVA: 0x00013644 File Offset: 0x00011844
			public ShellProperty<string> FileDescription
			{
				get
				{
					PropertyKey fileDescription = SystemProperties.System.FileDescription;
					if (!this.hashtable.ContainsKey(fileDescription))
					{
						this.hashtable.Add(fileDescription, this.shellObjectParent.Properties.CreateTypedProperty<string>(fileDescription));
					}
					return this.hashtable[fileDescription] as ShellProperty<string>;
				}
			}

			// Token: 0x17000198 RID: 408
			// (get) Token: 0x060005B3 RID: 1459 RVA: 0x000136AC File Offset: 0x000118AC
			public ShellProperty<string> FileExtension
			{
				get
				{
					PropertyKey fileExtension = SystemProperties.System.FileExtension;
					if (!this.hashtable.ContainsKey(fileExtension))
					{
						this.hashtable.Add(fileExtension, this.shellObjectParent.Properties.CreateTypedProperty<string>(fileExtension));
					}
					return this.hashtable[fileExtension] as ShellProperty<string>;
				}
			}

			// Token: 0x17000199 RID: 409
			// (get) Token: 0x060005B4 RID: 1460 RVA: 0x00013714 File Offset: 0x00011914
			public ShellProperty<ulong?> FileFRN
			{
				get
				{
					PropertyKey fileFRN = SystemProperties.System.FileFRN;
					if (!this.hashtable.ContainsKey(fileFRN))
					{
						this.hashtable.Add(fileFRN, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(fileFRN));
					}
					return this.hashtable[fileFRN] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x1700019A RID: 410
			// (get) Token: 0x060005B5 RID: 1461 RVA: 0x0001377C File Offset: 0x0001197C
			public ShellProperty<string> FileName
			{
				get
				{
					PropertyKey fileName = SystemProperties.System.FileName;
					if (!this.hashtable.ContainsKey(fileName))
					{
						this.hashtable.Add(fileName, this.shellObjectParent.Properties.CreateTypedProperty<string>(fileName));
					}
					return this.hashtable[fileName] as ShellProperty<string>;
				}
			}

			// Token: 0x1700019B RID: 411
			// (get) Token: 0x060005B6 RID: 1462 RVA: 0x000137E4 File Offset: 0x000119E4
			public ShellProperty<string> FileOwner
			{
				get
				{
					PropertyKey fileOwner = SystemProperties.System.FileOwner;
					if (!this.hashtable.ContainsKey(fileOwner))
					{
						this.hashtable.Add(fileOwner, this.shellObjectParent.Properties.CreateTypedProperty<string>(fileOwner));
					}
					return this.hashtable[fileOwner] as ShellProperty<string>;
				}
			}

			// Token: 0x1700019C RID: 412
			// (get) Token: 0x060005B7 RID: 1463 RVA: 0x0001384C File Offset: 0x00011A4C
			public ShellProperty<string> FileVersion
			{
				get
				{
					PropertyKey fileVersion = SystemProperties.System.FileVersion;
					if (!this.hashtable.ContainsKey(fileVersion))
					{
						this.hashtable.Add(fileVersion, this.shellObjectParent.Properties.CreateTypedProperty<string>(fileVersion));
					}
					return this.hashtable[fileVersion] as ShellProperty<string>;
				}
			}

			// Token: 0x1700019D RID: 413
			// (get) Token: 0x060005B8 RID: 1464 RVA: 0x000138B4 File Offset: 0x00011AB4
			public ShellProperty<byte[]> FindData
			{
				get
				{
					PropertyKey findData = SystemProperties.System.FindData;
					if (!this.hashtable.ContainsKey(findData))
					{
						this.hashtable.Add(findData, this.shellObjectParent.Properties.CreateTypedProperty<byte[]>(findData));
					}
					return this.hashtable[findData] as ShellProperty<byte[]>;
				}
			}

			// Token: 0x1700019E RID: 414
			// (get) Token: 0x060005B9 RID: 1465 RVA: 0x0001391C File Offset: 0x00011B1C
			public ShellProperty<ushort?> FlagColor
			{
				get
				{
					PropertyKey flagColor = SystemProperties.System.FlagColor;
					if (!this.hashtable.ContainsKey(flagColor))
					{
						this.hashtable.Add(flagColor, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(flagColor));
					}
					return this.hashtable[flagColor] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x1700019F RID: 415
			// (get) Token: 0x060005BA RID: 1466 RVA: 0x00013984 File Offset: 0x00011B84
			public ShellProperty<string> FlagColorText
			{
				get
				{
					PropertyKey flagColorText = SystemProperties.System.FlagColorText;
					if (!this.hashtable.ContainsKey(flagColorText))
					{
						this.hashtable.Add(flagColorText, this.shellObjectParent.Properties.CreateTypedProperty<string>(flagColorText));
					}
					return this.hashtable[flagColorText] as ShellProperty<string>;
				}
			}

			// Token: 0x170001A0 RID: 416
			// (get) Token: 0x060005BB RID: 1467 RVA: 0x000139EC File Offset: 0x00011BEC
			public ShellProperty<int?> FlagStatus
			{
				get
				{
					PropertyKey flagStatus = SystemProperties.System.FlagStatus;
					if (!this.hashtable.ContainsKey(flagStatus))
					{
						this.hashtable.Add(flagStatus, this.shellObjectParent.Properties.CreateTypedProperty<int?>(flagStatus));
					}
					return this.hashtable[flagStatus] as ShellProperty<int?>;
				}
			}

			// Token: 0x170001A1 RID: 417
			// (get) Token: 0x060005BC RID: 1468 RVA: 0x00013A54 File Offset: 0x00011C54
			public ShellProperty<string> FlagStatusText
			{
				get
				{
					PropertyKey flagStatusText = SystemProperties.System.FlagStatusText;
					if (!this.hashtable.ContainsKey(flagStatusText))
					{
						this.hashtable.Add(flagStatusText, this.shellObjectParent.Properties.CreateTypedProperty<string>(flagStatusText));
					}
					return this.hashtable[flagStatusText] as ShellProperty<string>;
				}
			}

			// Token: 0x170001A2 RID: 418
			// (get) Token: 0x060005BD RID: 1469 RVA: 0x00013ABC File Offset: 0x00011CBC
			public ShellProperty<ulong?> FreeSpace
			{
				get
				{
					PropertyKey freeSpace = SystemProperties.System.FreeSpace;
					if (!this.hashtable.ContainsKey(freeSpace))
					{
						this.hashtable.Add(freeSpace, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(freeSpace));
					}
					return this.hashtable[freeSpace] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x170001A3 RID: 419
			// (get) Token: 0x060005BE RID: 1470 RVA: 0x00013B24 File Offset: 0x00011D24
			public ShellProperty<string> FullText
			{
				get
				{
					PropertyKey fullText = SystemProperties.System.FullText;
					if (!this.hashtable.ContainsKey(fullText))
					{
						this.hashtable.Add(fullText, this.shellObjectParent.Properties.CreateTypedProperty<string>(fullText));
					}
					return this.hashtable[fullText] as ShellProperty<string>;
				}
			}

			// Token: 0x170001A4 RID: 420
			// (get) Token: 0x060005BF RID: 1471 RVA: 0x00013B8C File Offset: 0x00011D8C
			public ShellProperty<string> IdentityProperty
			{
				get
				{
					PropertyKey identityProperty = SystemProperties.System.IdentityProperty;
					if (!this.hashtable.ContainsKey(identityProperty))
					{
						this.hashtable.Add(identityProperty, this.shellObjectParent.Properties.CreateTypedProperty<string>(identityProperty));
					}
					return this.hashtable[identityProperty] as ShellProperty<string>;
				}
			}

			// Token: 0x170001A5 RID: 421
			// (get) Token: 0x060005C0 RID: 1472 RVA: 0x00013BF4 File Offset: 0x00011DF4
			public ShellProperty<string[]> ImageParsingName
			{
				get
				{
					PropertyKey imageParsingName = SystemProperties.System.ImageParsingName;
					if (!this.hashtable.ContainsKey(imageParsingName))
					{
						this.hashtable.Add(imageParsingName, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(imageParsingName));
					}
					return this.hashtable[imageParsingName] as ShellProperty<string[]>;
				}
			}

			// Token: 0x170001A6 RID: 422
			// (get) Token: 0x060005C1 RID: 1473 RVA: 0x00013C5C File Offset: 0x00011E5C
			public ShellProperty<int?> Importance
			{
				get
				{
					PropertyKey importance = SystemProperties.System.Importance;
					if (!this.hashtable.ContainsKey(importance))
					{
						this.hashtable.Add(importance, this.shellObjectParent.Properties.CreateTypedProperty<int?>(importance));
					}
					return this.hashtable[importance] as ShellProperty<int?>;
				}
			}

			// Token: 0x170001A7 RID: 423
			// (get) Token: 0x060005C2 RID: 1474 RVA: 0x00013CC4 File Offset: 0x00011EC4
			public ShellProperty<string> ImportanceText
			{
				get
				{
					PropertyKey importanceText = SystemProperties.System.ImportanceText;
					if (!this.hashtable.ContainsKey(importanceText))
					{
						this.hashtable.Add(importanceText, this.shellObjectParent.Properties.CreateTypedProperty<string>(importanceText));
					}
					return this.hashtable[importanceText] as ShellProperty<string>;
				}
			}

			// Token: 0x170001A8 RID: 424
			// (get) Token: 0x060005C3 RID: 1475 RVA: 0x00013D2C File Offset: 0x00011F2C
			public ShellProperty<string> InfoTipText
			{
				get
				{
					PropertyKey infoTipText = SystemProperties.System.InfoTipText;
					if (!this.hashtable.ContainsKey(infoTipText))
					{
						this.hashtable.Add(infoTipText, this.shellObjectParent.Properties.CreateTypedProperty<string>(infoTipText));
					}
					return this.hashtable[infoTipText] as ShellProperty<string>;
				}
			}

			// Token: 0x170001A9 RID: 425
			// (get) Token: 0x060005C4 RID: 1476 RVA: 0x00013D94 File Offset: 0x00011F94
			public ShellProperty<string> InternalName
			{
				get
				{
					PropertyKey internalName = SystemProperties.System.InternalName;
					if (!this.hashtable.ContainsKey(internalName))
					{
						this.hashtable.Add(internalName, this.shellObjectParent.Properties.CreateTypedProperty<string>(internalName));
					}
					return this.hashtable[internalName] as ShellProperty<string>;
				}
			}

			// Token: 0x170001AA RID: 426
			// (get) Token: 0x060005C5 RID: 1477 RVA: 0x00013DFC File Offset: 0x00011FFC
			public ShellProperty<bool?> IsAttachment
			{
				get
				{
					PropertyKey isAttachment = SystemProperties.System.IsAttachment;
					if (!this.hashtable.ContainsKey(isAttachment))
					{
						this.hashtable.Add(isAttachment, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isAttachment));
					}
					return this.hashtable[isAttachment] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001AB RID: 427
			// (get) Token: 0x060005C6 RID: 1478 RVA: 0x00013E64 File Offset: 0x00012064
			public ShellProperty<bool?> IsDefaultNonOwnerSaveLocation
			{
				get
				{
					PropertyKey isDefaultNonOwnerSaveLocation = SystemProperties.System.IsDefaultNonOwnerSaveLocation;
					if (!this.hashtable.ContainsKey(isDefaultNonOwnerSaveLocation))
					{
						this.hashtable.Add(isDefaultNonOwnerSaveLocation, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isDefaultNonOwnerSaveLocation));
					}
					return this.hashtable[isDefaultNonOwnerSaveLocation] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001AC RID: 428
			// (get) Token: 0x060005C7 RID: 1479 RVA: 0x00013ECC File Offset: 0x000120CC
			public ShellProperty<bool?> IsDefaultSaveLocation
			{
				get
				{
					PropertyKey isDefaultSaveLocation = SystemProperties.System.IsDefaultSaveLocation;
					if (!this.hashtable.ContainsKey(isDefaultSaveLocation))
					{
						this.hashtable.Add(isDefaultSaveLocation, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isDefaultSaveLocation));
					}
					return this.hashtable[isDefaultSaveLocation] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001AD RID: 429
			// (get) Token: 0x060005C8 RID: 1480 RVA: 0x00013F34 File Offset: 0x00012134
			public ShellProperty<bool?> IsDeleted
			{
				get
				{
					PropertyKey isDeleted = SystemProperties.System.IsDeleted;
					if (!this.hashtable.ContainsKey(isDeleted))
					{
						this.hashtable.Add(isDeleted, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isDeleted));
					}
					return this.hashtable[isDeleted] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001AE RID: 430
			// (get) Token: 0x060005C9 RID: 1481 RVA: 0x00013F9C File Offset: 0x0001219C
			public ShellProperty<bool?> IsEncrypted
			{
				get
				{
					PropertyKey isEncrypted = SystemProperties.System.IsEncrypted;
					if (!this.hashtable.ContainsKey(isEncrypted))
					{
						this.hashtable.Add(isEncrypted, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isEncrypted));
					}
					return this.hashtable[isEncrypted] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001AF RID: 431
			// (get) Token: 0x060005CA RID: 1482 RVA: 0x00014004 File Offset: 0x00012204
			public ShellProperty<bool?> IsFlagged
			{
				get
				{
					PropertyKey isFlagged = SystemProperties.System.IsFlagged;
					if (!this.hashtable.ContainsKey(isFlagged))
					{
						this.hashtable.Add(isFlagged, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isFlagged));
					}
					return this.hashtable[isFlagged] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001B0 RID: 432
			// (get) Token: 0x060005CB RID: 1483 RVA: 0x0001406C File Offset: 0x0001226C
			public ShellProperty<bool?> IsFlaggedComplete
			{
				get
				{
					PropertyKey isFlaggedComplete = SystemProperties.System.IsFlaggedComplete;
					if (!this.hashtable.ContainsKey(isFlaggedComplete))
					{
						this.hashtable.Add(isFlaggedComplete, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isFlaggedComplete));
					}
					return this.hashtable[isFlaggedComplete] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001B1 RID: 433
			// (get) Token: 0x060005CC RID: 1484 RVA: 0x000140D4 File Offset: 0x000122D4
			public ShellProperty<bool?> IsIncomplete
			{
				get
				{
					PropertyKey isIncomplete = SystemProperties.System.IsIncomplete;
					if (!this.hashtable.ContainsKey(isIncomplete))
					{
						this.hashtable.Add(isIncomplete, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isIncomplete));
					}
					return this.hashtable[isIncomplete] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001B2 RID: 434
			// (get) Token: 0x060005CD RID: 1485 RVA: 0x0001413C File Offset: 0x0001233C
			public ShellProperty<bool?> IsLocationSupported
			{
				get
				{
					PropertyKey isLocationSupported = SystemProperties.System.IsLocationSupported;
					if (!this.hashtable.ContainsKey(isLocationSupported))
					{
						this.hashtable.Add(isLocationSupported, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isLocationSupported));
					}
					return this.hashtable[isLocationSupported] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001B3 RID: 435
			// (get) Token: 0x060005CE RID: 1486 RVA: 0x000141A4 File Offset: 0x000123A4
			public ShellProperty<bool?> IsPinnedToNamespaceTree
			{
				get
				{
					PropertyKey isPinnedToNamespaceTree = SystemProperties.System.IsPinnedToNamespaceTree;
					if (!this.hashtable.ContainsKey(isPinnedToNamespaceTree))
					{
						this.hashtable.Add(isPinnedToNamespaceTree, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isPinnedToNamespaceTree));
					}
					return this.hashtable[isPinnedToNamespaceTree] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001B4 RID: 436
			// (get) Token: 0x060005CF RID: 1487 RVA: 0x0001420C File Offset: 0x0001240C
			public ShellProperty<bool?> IsRead
			{
				get
				{
					PropertyKey isRead = SystemProperties.System.IsRead;
					if (!this.hashtable.ContainsKey(isRead))
					{
						this.hashtable.Add(isRead, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isRead));
					}
					return this.hashtable[isRead] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001B5 RID: 437
			// (get) Token: 0x060005D0 RID: 1488 RVA: 0x00014274 File Offset: 0x00012474
			public ShellProperty<bool?> IsSearchOnlyItem
			{
				get
				{
					PropertyKey isSearchOnlyItem = SystemProperties.System.IsSearchOnlyItem;
					if (!this.hashtable.ContainsKey(isSearchOnlyItem))
					{
						this.hashtable.Add(isSearchOnlyItem, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isSearchOnlyItem));
					}
					return this.hashtable[isSearchOnlyItem] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001B6 RID: 438
			// (get) Token: 0x060005D1 RID: 1489 RVA: 0x000142DC File Offset: 0x000124DC
			public ShellProperty<bool?> IsSendToTarget
			{
				get
				{
					PropertyKey isSendToTarget = SystemProperties.System.IsSendToTarget;
					if (!this.hashtable.ContainsKey(isSendToTarget))
					{
						this.hashtable.Add(isSendToTarget, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isSendToTarget));
					}
					return this.hashtable[isSendToTarget] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001B7 RID: 439
			// (get) Token: 0x060005D2 RID: 1490 RVA: 0x00014344 File Offset: 0x00012544
			public ShellProperty<bool?> IsShared
			{
				get
				{
					PropertyKey isShared = SystemProperties.System.IsShared;
					if (!this.hashtable.ContainsKey(isShared))
					{
						this.hashtable.Add(isShared, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isShared));
					}
					return this.hashtable[isShared] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170001B8 RID: 440
			// (get) Token: 0x060005D3 RID: 1491 RVA: 0x000143AC File Offset: 0x000125AC
			public ShellProperty<string[]> ItemAuthors
			{
				get
				{
					PropertyKey itemAuthors = SystemProperties.System.ItemAuthors;
					if (!this.hashtable.ContainsKey(itemAuthors))
					{
						this.hashtable.Add(itemAuthors, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(itemAuthors));
					}
					return this.hashtable[itemAuthors] as ShellProperty<string[]>;
				}
			}

			// Token: 0x170001B9 RID: 441
			// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00014414 File Offset: 0x00012614
			public ShellProperty<string> ItemClassType
			{
				get
				{
					PropertyKey itemClassType = SystemProperties.System.ItemClassType;
					if (!this.hashtable.ContainsKey(itemClassType))
					{
						this.hashtable.Add(itemClassType, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemClassType));
					}
					return this.hashtable[itemClassType] as ShellProperty<string>;
				}
			}

			// Token: 0x170001BA RID: 442
			// (get) Token: 0x060005D5 RID: 1493 RVA: 0x0001447C File Offset: 0x0001267C
			public ShellProperty<DateTime?> ItemDate
			{
				get
				{
					PropertyKey itemDate = SystemProperties.System.ItemDate;
					if (!this.hashtable.ContainsKey(itemDate))
					{
						this.hashtable.Add(itemDate, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(itemDate));
					}
					return this.hashtable[itemDate] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x170001BB RID: 443
			// (get) Token: 0x060005D6 RID: 1494 RVA: 0x000144E4 File Offset: 0x000126E4
			public ShellProperty<string> ItemFolderNameDisplay
			{
				get
				{
					PropertyKey itemFolderNameDisplay = SystemProperties.System.ItemFolderNameDisplay;
					if (!this.hashtable.ContainsKey(itemFolderNameDisplay))
					{
						this.hashtable.Add(itemFolderNameDisplay, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemFolderNameDisplay));
					}
					return this.hashtable[itemFolderNameDisplay] as ShellProperty<string>;
				}
			}

			// Token: 0x170001BC RID: 444
			// (get) Token: 0x060005D7 RID: 1495 RVA: 0x0001454C File Offset: 0x0001274C
			public ShellProperty<string> ItemFolderPathDisplay
			{
				get
				{
					PropertyKey itemFolderPathDisplay = SystemProperties.System.ItemFolderPathDisplay;
					if (!this.hashtable.ContainsKey(itemFolderPathDisplay))
					{
						this.hashtable.Add(itemFolderPathDisplay, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemFolderPathDisplay));
					}
					return this.hashtable[itemFolderPathDisplay] as ShellProperty<string>;
				}
			}

			// Token: 0x170001BD RID: 445
			// (get) Token: 0x060005D8 RID: 1496 RVA: 0x000145B4 File Offset: 0x000127B4
			public ShellProperty<string> ItemFolderPathDisplayNarrow
			{
				get
				{
					PropertyKey itemFolderPathDisplayNarrow = SystemProperties.System.ItemFolderPathDisplayNarrow;
					if (!this.hashtable.ContainsKey(itemFolderPathDisplayNarrow))
					{
						this.hashtable.Add(itemFolderPathDisplayNarrow, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemFolderPathDisplayNarrow));
					}
					return this.hashtable[itemFolderPathDisplayNarrow] as ShellProperty<string>;
				}
			}

			// Token: 0x170001BE RID: 446
			// (get) Token: 0x060005D9 RID: 1497 RVA: 0x0001461C File Offset: 0x0001281C
			public ShellProperty<string> ItemName
			{
				get
				{
					PropertyKey itemName = SystemProperties.System.ItemName;
					if (!this.hashtable.ContainsKey(itemName))
					{
						this.hashtable.Add(itemName, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemName));
					}
					return this.hashtable[itemName] as ShellProperty<string>;
				}
			}

			// Token: 0x170001BF RID: 447
			// (get) Token: 0x060005DA RID: 1498 RVA: 0x00014684 File Offset: 0x00012884
			public ShellProperty<string> ItemNameDisplay
			{
				get
				{
					PropertyKey itemNameDisplay = SystemProperties.System.ItemNameDisplay;
					if (!this.hashtable.ContainsKey(itemNameDisplay))
					{
						this.hashtable.Add(itemNameDisplay, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemNameDisplay));
					}
					return this.hashtable[itemNameDisplay] as ShellProperty<string>;
				}
			}

			// Token: 0x170001C0 RID: 448
			// (get) Token: 0x060005DB RID: 1499 RVA: 0x000146EC File Offset: 0x000128EC
			public ShellProperty<string> ItemNamePrefix
			{
				get
				{
					PropertyKey itemNamePrefix = SystemProperties.System.ItemNamePrefix;
					if (!this.hashtable.ContainsKey(itemNamePrefix))
					{
						this.hashtable.Add(itemNamePrefix, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemNamePrefix));
					}
					return this.hashtable[itemNamePrefix] as ShellProperty<string>;
				}
			}

			// Token: 0x170001C1 RID: 449
			// (get) Token: 0x060005DC RID: 1500 RVA: 0x00014754 File Offset: 0x00012954
			public ShellProperty<string[]> ItemParticipants
			{
				get
				{
					PropertyKey itemParticipants = SystemProperties.System.ItemParticipants;
					if (!this.hashtable.ContainsKey(itemParticipants))
					{
						this.hashtable.Add(itemParticipants, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(itemParticipants));
					}
					return this.hashtable[itemParticipants] as ShellProperty<string[]>;
				}
			}

			// Token: 0x170001C2 RID: 450
			// (get) Token: 0x060005DD RID: 1501 RVA: 0x000147BC File Offset: 0x000129BC
			public ShellProperty<string> ItemPathDisplay
			{
				get
				{
					PropertyKey itemPathDisplay = SystemProperties.System.ItemPathDisplay;
					if (!this.hashtable.ContainsKey(itemPathDisplay))
					{
						this.hashtable.Add(itemPathDisplay, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemPathDisplay));
					}
					return this.hashtable[itemPathDisplay] as ShellProperty<string>;
				}
			}

			// Token: 0x170001C3 RID: 451
			// (get) Token: 0x060005DE RID: 1502 RVA: 0x00014824 File Offset: 0x00012A24
			public ShellProperty<string> ItemPathDisplayNarrow
			{
				get
				{
					PropertyKey itemPathDisplayNarrow = SystemProperties.System.ItemPathDisplayNarrow;
					if (!this.hashtable.ContainsKey(itemPathDisplayNarrow))
					{
						this.hashtable.Add(itemPathDisplayNarrow, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemPathDisplayNarrow));
					}
					return this.hashtable[itemPathDisplayNarrow] as ShellProperty<string>;
				}
			}

			// Token: 0x170001C4 RID: 452
			// (get) Token: 0x060005DF RID: 1503 RVA: 0x0001488C File Offset: 0x00012A8C
			public ShellProperty<string> ItemType
			{
				get
				{
					PropertyKey itemType = SystemProperties.System.ItemType;
					if (!this.hashtable.ContainsKey(itemType))
					{
						this.hashtable.Add(itemType, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemType));
					}
					return this.hashtable[itemType] as ShellProperty<string>;
				}
			}

			// Token: 0x170001C5 RID: 453
			// (get) Token: 0x060005E0 RID: 1504 RVA: 0x000148F4 File Offset: 0x00012AF4
			public ShellProperty<string> ItemTypeText
			{
				get
				{
					PropertyKey itemTypeText = SystemProperties.System.ItemTypeText;
					if (!this.hashtable.ContainsKey(itemTypeText))
					{
						this.hashtable.Add(itemTypeText, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemTypeText));
					}
					return this.hashtable[itemTypeText] as ShellProperty<string>;
				}
			}

			// Token: 0x170001C6 RID: 454
			// (get) Token: 0x060005E1 RID: 1505 RVA: 0x0001495C File Offset: 0x00012B5C
			public ShellProperty<string> ItemUrl
			{
				get
				{
					PropertyKey itemUrl = SystemProperties.System.ItemUrl;
					if (!this.hashtable.ContainsKey(itemUrl))
					{
						this.hashtable.Add(itemUrl, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemUrl));
					}
					return this.hashtable[itemUrl] as ShellProperty<string>;
				}
			}

			// Token: 0x170001C7 RID: 455
			// (get) Token: 0x060005E2 RID: 1506 RVA: 0x000149C4 File Offset: 0x00012BC4
			public ShellProperty<string[]> Keywords
			{
				get
				{
					PropertyKey keywords = SystemProperties.System.Keywords;
					if (!this.hashtable.ContainsKey(keywords))
					{
						this.hashtable.Add(keywords, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(keywords));
					}
					return this.hashtable[keywords] as ShellProperty<string[]>;
				}
			}

			// Token: 0x170001C8 RID: 456
			// (get) Token: 0x060005E3 RID: 1507 RVA: 0x00014A2C File Offset: 0x00012C2C
			public ShellProperty<string[]> Kind
			{
				get
				{
					PropertyKey kind = SystemProperties.System.Kind;
					if (!this.hashtable.ContainsKey(kind))
					{
						this.hashtable.Add(kind, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(kind));
					}
					return this.hashtable[kind] as ShellProperty<string[]>;
				}
			}

			// Token: 0x170001C9 RID: 457
			// (get) Token: 0x060005E4 RID: 1508 RVA: 0x00014A94 File Offset: 0x00012C94
			public ShellProperty<string> KindText
			{
				get
				{
					PropertyKey kindText = SystemProperties.System.KindText;
					if (!this.hashtable.ContainsKey(kindText))
					{
						this.hashtable.Add(kindText, this.shellObjectParent.Properties.CreateTypedProperty<string>(kindText));
					}
					return this.hashtable[kindText] as ShellProperty<string>;
				}
			}

			// Token: 0x170001CA RID: 458
			// (get) Token: 0x060005E5 RID: 1509 RVA: 0x00014AFC File Offset: 0x00012CFC
			public ShellProperty<string> Language
			{
				get
				{
					PropertyKey language = SystemProperties.System.Language;
					if (!this.hashtable.ContainsKey(language))
					{
						this.hashtable.Add(language, this.shellObjectParent.Properties.CreateTypedProperty<string>(language));
					}
					return this.hashtable[language] as ShellProperty<string>;
				}
			}

			// Token: 0x170001CB RID: 459
			// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00014B64 File Offset: 0x00012D64
			public ShellProperty<string> MileageInformation
			{
				get
				{
					PropertyKey mileageInformation = SystemProperties.System.MileageInformation;
					if (!this.hashtable.ContainsKey(mileageInformation))
					{
						this.hashtable.Add(mileageInformation, this.shellObjectParent.Properties.CreateTypedProperty<string>(mileageInformation));
					}
					return this.hashtable[mileageInformation] as ShellProperty<string>;
				}
			}

			// Token: 0x170001CC RID: 460
			// (get) Token: 0x060005E7 RID: 1511 RVA: 0x00014BCC File Offset: 0x00012DCC
			public ShellProperty<string> MIMEType
			{
				get
				{
					PropertyKey mimetype = SystemProperties.System.MIMEType;
					if (!this.hashtable.ContainsKey(mimetype))
					{
						this.hashtable.Add(mimetype, this.shellObjectParent.Properties.CreateTypedProperty<string>(mimetype));
					}
					return this.hashtable[mimetype] as ShellProperty<string>;
				}
			}

			// Token: 0x170001CD RID: 461
			// (get) Token: 0x060005E8 RID: 1512 RVA: 0x00014C34 File Offset: 0x00012E34
			public ShellProperty<IntPtr?> NamespaceClsid
			{
				get
				{
					PropertyKey namespaceClsid = SystemProperties.System.NamespaceClsid;
					if (!this.hashtable.ContainsKey(namespaceClsid))
					{
						this.hashtable.Add(namespaceClsid, this.shellObjectParent.Properties.CreateTypedProperty<IntPtr?>(namespaceClsid));
					}
					return this.hashtable[namespaceClsid] as ShellProperty<IntPtr?>;
				}
			}

			// Token: 0x170001CE RID: 462
			// (get) Token: 0x060005E9 RID: 1513 RVA: 0x00014C9C File Offset: 0x00012E9C
			public ShellProperty<object> Null
			{
				get
				{
					PropertyKey @null = SystemProperties.System.Null;
					if (!this.hashtable.ContainsKey(@null))
					{
						this.hashtable.Add(@null, this.shellObjectParent.Properties.CreateTypedProperty<object>(@null));
					}
					return this.hashtable[@null] as ShellProperty<object>;
				}
			}

			// Token: 0x170001CF RID: 463
			// (get) Token: 0x060005EA RID: 1514 RVA: 0x00014D04 File Offset: 0x00012F04
			public ShellProperty<uint?> OfflineAvailability
			{
				get
				{
					PropertyKey offlineAvailability = SystemProperties.System.OfflineAvailability;
					if (!this.hashtable.ContainsKey(offlineAvailability))
					{
						this.hashtable.Add(offlineAvailability, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(offlineAvailability));
					}
					return this.hashtable[offlineAvailability] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170001D0 RID: 464
			// (get) Token: 0x060005EB RID: 1515 RVA: 0x00014D6C File Offset: 0x00012F6C
			public ShellProperty<uint?> OfflineStatus
			{
				get
				{
					PropertyKey offlineStatus = SystemProperties.System.OfflineStatus;
					if (!this.hashtable.ContainsKey(offlineStatus))
					{
						this.hashtable.Add(offlineStatus, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(offlineStatus));
					}
					return this.hashtable[offlineStatus] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170001D1 RID: 465
			// (get) Token: 0x060005EC RID: 1516 RVA: 0x00014DD4 File Offset: 0x00012FD4
			public ShellProperty<string> OriginalFileName
			{
				get
				{
					PropertyKey originalFileName = SystemProperties.System.OriginalFileName;
					if (!this.hashtable.ContainsKey(originalFileName))
					{
						this.hashtable.Add(originalFileName, this.shellObjectParent.Properties.CreateTypedProperty<string>(originalFileName));
					}
					return this.hashtable[originalFileName] as ShellProperty<string>;
				}
			}

			// Token: 0x170001D2 RID: 466
			// (get) Token: 0x060005ED RID: 1517 RVA: 0x00014E3C File Offset: 0x0001303C
			public ShellProperty<string> OwnerSid
			{
				get
				{
					PropertyKey ownerSid = SystemProperties.System.OwnerSid;
					if (!this.hashtable.ContainsKey(ownerSid))
					{
						this.hashtable.Add(ownerSid, this.shellObjectParent.Properties.CreateTypedProperty<string>(ownerSid));
					}
					return this.hashtable[ownerSid] as ShellProperty<string>;
				}
			}

			// Token: 0x170001D3 RID: 467
			// (get) Token: 0x060005EE RID: 1518 RVA: 0x00014EA4 File Offset: 0x000130A4
			public ShellProperty<string> ParentalRating
			{
				get
				{
					PropertyKey parentalRating = SystemProperties.System.ParentalRating;
					if (!this.hashtable.ContainsKey(parentalRating))
					{
						this.hashtable.Add(parentalRating, this.shellObjectParent.Properties.CreateTypedProperty<string>(parentalRating));
					}
					return this.hashtable[parentalRating] as ShellProperty<string>;
				}
			}

			// Token: 0x170001D4 RID: 468
			// (get) Token: 0x060005EF RID: 1519 RVA: 0x00014F0C File Offset: 0x0001310C
			public ShellProperty<string> ParentalRatingReason
			{
				get
				{
					PropertyKey parentalRatingReason = SystemProperties.System.ParentalRatingReason;
					if (!this.hashtable.ContainsKey(parentalRatingReason))
					{
						this.hashtable.Add(parentalRatingReason, this.shellObjectParent.Properties.CreateTypedProperty<string>(parentalRatingReason));
					}
					return this.hashtable[parentalRatingReason] as ShellProperty<string>;
				}
			}

			// Token: 0x170001D5 RID: 469
			// (get) Token: 0x060005F0 RID: 1520 RVA: 0x00014F74 File Offset: 0x00013174
			public ShellProperty<string> ParentalRatingsOrganization
			{
				get
				{
					PropertyKey parentalRatingsOrganization = SystemProperties.System.ParentalRatingsOrganization;
					if (!this.hashtable.ContainsKey(parentalRatingsOrganization))
					{
						this.hashtable.Add(parentalRatingsOrganization, this.shellObjectParent.Properties.CreateTypedProperty<string>(parentalRatingsOrganization));
					}
					return this.hashtable[parentalRatingsOrganization] as ShellProperty<string>;
				}
			}

			// Token: 0x170001D6 RID: 470
			// (get) Token: 0x060005F1 RID: 1521 RVA: 0x00014FDC File Offset: 0x000131DC
			public ShellProperty<object> ParsingBindContext
			{
				get
				{
					PropertyKey parsingBindContext = SystemProperties.System.ParsingBindContext;
					if (!this.hashtable.ContainsKey(parsingBindContext))
					{
						this.hashtable.Add(parsingBindContext, this.shellObjectParent.Properties.CreateTypedProperty<object>(parsingBindContext));
					}
					return this.hashtable[parsingBindContext] as ShellProperty<object>;
				}
			}

			// Token: 0x170001D7 RID: 471
			// (get) Token: 0x060005F2 RID: 1522 RVA: 0x00015044 File Offset: 0x00013244
			public ShellProperty<string> ParsingName
			{
				get
				{
					PropertyKey parsingName = SystemProperties.System.ParsingName;
					if (!this.hashtable.ContainsKey(parsingName))
					{
						this.hashtable.Add(parsingName, this.shellObjectParent.Properties.CreateTypedProperty<string>(parsingName));
					}
					return this.hashtable[parsingName] as ShellProperty<string>;
				}
			}

			// Token: 0x170001D8 RID: 472
			// (get) Token: 0x060005F3 RID: 1523 RVA: 0x000150AC File Offset: 0x000132AC
			public ShellProperty<string> ParsingPath
			{
				get
				{
					PropertyKey parsingPath = SystemProperties.System.ParsingPath;
					if (!this.hashtable.ContainsKey(parsingPath))
					{
						this.hashtable.Add(parsingPath, this.shellObjectParent.Properties.CreateTypedProperty<string>(parsingPath));
					}
					return this.hashtable[parsingPath] as ShellProperty<string>;
				}
			}

			// Token: 0x170001D9 RID: 473
			// (get) Token: 0x060005F4 RID: 1524 RVA: 0x00015114 File Offset: 0x00013314
			public ShellProperty<int?> PerceivedType
			{
				get
				{
					PropertyKey perceivedType = SystemProperties.System.PerceivedType;
					if (!this.hashtable.ContainsKey(perceivedType))
					{
						this.hashtable.Add(perceivedType, this.shellObjectParent.Properties.CreateTypedProperty<int?>(perceivedType));
					}
					return this.hashtable[perceivedType] as ShellProperty<int?>;
				}
			}

			// Token: 0x170001DA RID: 474
			// (get) Token: 0x060005F5 RID: 1525 RVA: 0x0001517C File Offset: 0x0001337C
			public ShellProperty<uint?> PercentFull
			{
				get
				{
					PropertyKey percentFull = SystemProperties.System.PercentFull;
					if (!this.hashtable.ContainsKey(percentFull))
					{
						this.hashtable.Add(percentFull, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(percentFull));
					}
					return this.hashtable[percentFull] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170001DB RID: 475
			// (get) Token: 0x060005F6 RID: 1526 RVA: 0x000151E4 File Offset: 0x000133E4
			public ShellProperty<ushort?> Priority
			{
				get
				{
					PropertyKey priority = SystemProperties.System.Priority;
					if (!this.hashtable.ContainsKey(priority))
					{
						this.hashtable.Add(priority, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(priority));
					}
					return this.hashtable[priority] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x170001DC RID: 476
			// (get) Token: 0x060005F7 RID: 1527 RVA: 0x0001524C File Offset: 0x0001344C
			public ShellProperty<string> PriorityText
			{
				get
				{
					PropertyKey priorityText = SystemProperties.System.PriorityText;
					if (!this.hashtable.ContainsKey(priorityText))
					{
						this.hashtable.Add(priorityText, this.shellObjectParent.Properties.CreateTypedProperty<string>(priorityText));
					}
					return this.hashtable[priorityText] as ShellProperty<string>;
				}
			}

			// Token: 0x170001DD RID: 477
			// (get) Token: 0x060005F8 RID: 1528 RVA: 0x000152B4 File Offset: 0x000134B4
			public ShellProperty<string> Project
			{
				get
				{
					PropertyKey project = SystemProperties.System.Project;
					if (!this.hashtable.ContainsKey(project))
					{
						this.hashtable.Add(project, this.shellObjectParent.Properties.CreateTypedProperty<string>(project));
					}
					return this.hashtable[project] as ShellProperty<string>;
				}
			}

			// Token: 0x170001DE RID: 478
			// (get) Token: 0x060005F9 RID: 1529 RVA: 0x0001531C File Offset: 0x0001351C
			public ShellProperty<string> ProviderItemID
			{
				get
				{
					PropertyKey providerItemID = SystemProperties.System.ProviderItemID;
					if (!this.hashtable.ContainsKey(providerItemID))
					{
						this.hashtable.Add(providerItemID, this.shellObjectParent.Properties.CreateTypedProperty<string>(providerItemID));
					}
					return this.hashtable[providerItemID] as ShellProperty<string>;
				}
			}

			// Token: 0x170001DF RID: 479
			// (get) Token: 0x060005FA RID: 1530 RVA: 0x00015384 File Offset: 0x00013584
			public ShellProperty<uint?> Rating
			{
				get
				{
					PropertyKey rating = SystemProperties.System.Rating;
					if (!this.hashtable.ContainsKey(rating))
					{
						this.hashtable.Add(rating, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(rating));
					}
					return this.hashtable[rating] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170001E0 RID: 480
			// (get) Token: 0x060005FB RID: 1531 RVA: 0x000153EC File Offset: 0x000135EC
			public ShellProperty<string> RatingText
			{
				get
				{
					PropertyKey ratingText = SystemProperties.System.RatingText;
					if (!this.hashtable.ContainsKey(ratingText))
					{
						this.hashtable.Add(ratingText, this.shellObjectParent.Properties.CreateTypedProperty<string>(ratingText));
					}
					return this.hashtable[ratingText] as ShellProperty<string>;
				}
			}

			// Token: 0x170001E1 RID: 481
			// (get) Token: 0x060005FC RID: 1532 RVA: 0x00015454 File Offset: 0x00013654
			public ShellProperty<ushort?> Sensitivity
			{
				get
				{
					PropertyKey sensitivity = SystemProperties.System.Sensitivity;
					if (!this.hashtable.ContainsKey(sensitivity))
					{
						this.hashtable.Add(sensitivity, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(sensitivity));
					}
					return this.hashtable[sensitivity] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x170001E2 RID: 482
			// (get) Token: 0x060005FD RID: 1533 RVA: 0x000154BC File Offset: 0x000136BC
			public ShellProperty<string> SensitivityText
			{
				get
				{
					PropertyKey sensitivityText = SystemProperties.System.SensitivityText;
					if (!this.hashtable.ContainsKey(sensitivityText))
					{
						this.hashtable.Add(sensitivityText, this.shellObjectParent.Properties.CreateTypedProperty<string>(sensitivityText));
					}
					return this.hashtable[sensitivityText] as ShellProperty<string>;
				}
			}

			// Token: 0x170001E3 RID: 483
			// (get) Token: 0x060005FE RID: 1534 RVA: 0x00015524 File Offset: 0x00013724
			public ShellProperty<uint?> SFGAOFlags
			{
				get
				{
					PropertyKey sfgaoflags = SystemProperties.System.SFGAOFlags;
					if (!this.hashtable.ContainsKey(sfgaoflags))
					{
						this.hashtable.Add(sfgaoflags, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(sfgaoflags));
					}
					return this.hashtable[sfgaoflags] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170001E4 RID: 484
			// (get) Token: 0x060005FF RID: 1535 RVA: 0x0001558C File Offset: 0x0001378C
			public ShellProperty<string[]> SharedWith
			{
				get
				{
					PropertyKey sharedWith = SystemProperties.System.SharedWith;
					if (!this.hashtable.ContainsKey(sharedWith))
					{
						this.hashtable.Add(sharedWith, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(sharedWith));
					}
					return this.hashtable[sharedWith] as ShellProperty<string[]>;
				}
			}

			// Token: 0x170001E5 RID: 485
			// (get) Token: 0x06000600 RID: 1536 RVA: 0x000155F4 File Offset: 0x000137F4
			public ShellProperty<uint?> ShareUserRating
			{
				get
				{
					PropertyKey shareUserRating = SystemProperties.System.ShareUserRating;
					if (!this.hashtable.ContainsKey(shareUserRating))
					{
						this.hashtable.Add(shareUserRating, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(shareUserRating));
					}
					return this.hashtable[shareUserRating] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170001E6 RID: 486
			// (get) Token: 0x06000601 RID: 1537 RVA: 0x0001565C File Offset: 0x0001385C
			public ShellProperty<uint?> SharingStatus
			{
				get
				{
					PropertyKey sharingStatus = SystemProperties.System.SharingStatus;
					if (!this.hashtable.ContainsKey(sharingStatus))
					{
						this.hashtable.Add(sharingStatus, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(sharingStatus));
					}
					return this.hashtable[sharingStatus] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170001E7 RID: 487
			// (get) Token: 0x06000602 RID: 1538 RVA: 0x000156C4 File Offset: 0x000138C4
			public ShellProperty<uint?> SimpleRating
			{
				get
				{
					PropertyKey simpleRating = SystemProperties.System.SimpleRating;
					if (!this.hashtable.ContainsKey(simpleRating))
					{
						this.hashtable.Add(simpleRating, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(simpleRating));
					}
					return this.hashtable[simpleRating] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170001E8 RID: 488
			// (get) Token: 0x06000603 RID: 1539 RVA: 0x0001572C File Offset: 0x0001392C
			public ShellProperty<ulong?> Size
			{
				get
				{
					PropertyKey size = SystemProperties.System.Size;
					if (!this.hashtable.ContainsKey(size))
					{
						this.hashtable.Add(size, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(size));
					}
					return this.hashtable[size] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x170001E9 RID: 489
			// (get) Token: 0x06000604 RID: 1540 RVA: 0x00015794 File Offset: 0x00013994
			public ShellProperty<string> SoftwareUsed
			{
				get
				{
					PropertyKey softwareUsed = SystemProperties.System.SoftwareUsed;
					if (!this.hashtable.ContainsKey(softwareUsed))
					{
						this.hashtable.Add(softwareUsed, this.shellObjectParent.Properties.CreateTypedProperty<string>(softwareUsed));
					}
					return this.hashtable[softwareUsed] as ShellProperty<string>;
				}
			}

			// Token: 0x170001EA RID: 490
			// (get) Token: 0x06000605 RID: 1541 RVA: 0x000157FC File Offset: 0x000139FC
			public ShellProperty<string> SourceItem
			{
				get
				{
					PropertyKey sourceItem = SystemProperties.System.SourceItem;
					if (!this.hashtable.ContainsKey(sourceItem))
					{
						this.hashtable.Add(sourceItem, this.shellObjectParent.Properties.CreateTypedProperty<string>(sourceItem));
					}
					return this.hashtable[sourceItem] as ShellProperty<string>;
				}
			}

			// Token: 0x170001EB RID: 491
			// (get) Token: 0x06000606 RID: 1542 RVA: 0x00015864 File Offset: 0x00013A64
			public ShellProperty<DateTime?> StartDate
			{
				get
				{
					PropertyKey startDate = SystemProperties.System.StartDate;
					if (!this.hashtable.ContainsKey(startDate))
					{
						this.hashtable.Add(startDate, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(startDate));
					}
					return this.hashtable[startDate] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x170001EC RID: 492
			// (get) Token: 0x06000607 RID: 1543 RVA: 0x000158CC File Offset: 0x00013ACC
			public ShellProperty<string> Status
			{
				get
				{
					PropertyKey status = SystemProperties.System.Status;
					if (!this.hashtable.ContainsKey(status))
					{
						this.hashtable.Add(status, this.shellObjectParent.Properties.CreateTypedProperty<string>(status));
					}
					return this.hashtable[status] as ShellProperty<string>;
				}
			}

			// Token: 0x170001ED RID: 493
			// (get) Token: 0x06000608 RID: 1544 RVA: 0x00015934 File Offset: 0x00013B34
			public ShellProperty<string> Subject
			{
				get
				{
					PropertyKey subject = SystemProperties.System.Subject;
					if (!this.hashtable.ContainsKey(subject))
					{
						this.hashtable.Add(subject, this.shellObjectParent.Properties.CreateTypedProperty<string>(subject));
					}
					return this.hashtable[subject] as ShellProperty<string>;
				}
			}

			// Token: 0x170001EE RID: 494
			// (get) Token: 0x06000609 RID: 1545 RVA: 0x0001599C File Offset: 0x00013B9C
			public ShellProperty<IntPtr?> Thumbnail
			{
				get
				{
					PropertyKey thumbnail = SystemProperties.System.Thumbnail;
					if (!this.hashtable.ContainsKey(thumbnail))
					{
						this.hashtable.Add(thumbnail, this.shellObjectParent.Properties.CreateTypedProperty<IntPtr?>(thumbnail));
					}
					return this.hashtable[thumbnail] as ShellProperty<IntPtr?>;
				}
			}

			// Token: 0x170001EF RID: 495
			// (get) Token: 0x0600060A RID: 1546 RVA: 0x00015A04 File Offset: 0x00013C04
			public ShellProperty<ulong?> ThumbnailCacheId
			{
				get
				{
					PropertyKey thumbnailCacheId = SystemProperties.System.ThumbnailCacheId;
					if (!this.hashtable.ContainsKey(thumbnailCacheId))
					{
						this.hashtable.Add(thumbnailCacheId, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(thumbnailCacheId));
					}
					return this.hashtable[thumbnailCacheId] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x170001F0 RID: 496
			// (get) Token: 0x0600060B RID: 1547 RVA: 0x00015A6C File Offset: 0x00013C6C
			public ShellProperty<IStream> ThumbnailStream
			{
				get
				{
					PropertyKey thumbnailStream = SystemProperties.System.ThumbnailStream;
					if (!this.hashtable.ContainsKey(thumbnailStream))
					{
						this.hashtable.Add(thumbnailStream, this.shellObjectParent.Properties.CreateTypedProperty<IStream>(thumbnailStream));
					}
					return this.hashtable[thumbnailStream] as ShellProperty<IStream>;
				}
			}

			// Token: 0x170001F1 RID: 497
			// (get) Token: 0x0600060C RID: 1548 RVA: 0x00015AD4 File Offset: 0x00013CD4
			public ShellProperty<string> Title
			{
				get
				{
					PropertyKey title = SystemProperties.System.Title;
					if (!this.hashtable.ContainsKey(title))
					{
						this.hashtable.Add(title, this.shellObjectParent.Properties.CreateTypedProperty<string>(title));
					}
					return this.hashtable[title] as ShellProperty<string>;
				}
			}

			// Token: 0x170001F2 RID: 498
			// (get) Token: 0x0600060D RID: 1549 RVA: 0x00015B3C File Offset: 0x00013D3C
			public ShellProperty<ulong?> TotalFileSize
			{
				get
				{
					PropertyKey totalFileSize = SystemProperties.System.TotalFileSize;
					if (!this.hashtable.ContainsKey(totalFileSize))
					{
						this.hashtable.Add(totalFileSize, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(totalFileSize));
					}
					return this.hashtable[totalFileSize] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x170001F3 RID: 499
			// (get) Token: 0x0600060E RID: 1550 RVA: 0x00015BA4 File Offset: 0x00013DA4
			public ShellProperty<string> Trademarks
			{
				get
				{
					PropertyKey trademarks = SystemProperties.System.Trademarks;
					if (!this.hashtable.ContainsKey(trademarks))
					{
						this.hashtable.Add(trademarks, this.shellObjectParent.Properties.CreateTypedProperty<string>(trademarks));
					}
					return this.hashtable[trademarks] as ShellProperty<string>;
				}
			}

			// Token: 0x170001F4 RID: 500
			// (get) Token: 0x0600060F RID: 1551 RVA: 0x00015C0C File Offset: 0x00013E0C
			public ShellProperties.PropertySystemAppUserModel AppUserModel
			{
				get
				{
					if (this.internalPropertySystemAppUserModel == null)
					{
						this.internalPropertySystemAppUserModel = new ShellProperties.PropertySystemAppUserModel(this.shellObjectParent);
					}
					return this.internalPropertySystemAppUserModel;
				}
			}

			// Token: 0x170001F5 RID: 501
			// (get) Token: 0x06000610 RID: 1552 RVA: 0x00015C48 File Offset: 0x00013E48
			public ShellProperties.PropertySystemAudio Audio
			{
				get
				{
					if (this.internalPropertySystemAudio == null)
					{
						this.internalPropertySystemAudio = new ShellProperties.PropertySystemAudio(this.shellObjectParent);
					}
					return this.internalPropertySystemAudio;
				}
			}

			// Token: 0x170001F6 RID: 502
			// (get) Token: 0x06000611 RID: 1553 RVA: 0x00015C84 File Offset: 0x00013E84
			public ShellProperties.PropertySystemCalendar Calendar
			{
				get
				{
					if (this.internalPropertySystemCalendar == null)
					{
						this.internalPropertySystemCalendar = new ShellProperties.PropertySystemCalendar(this.shellObjectParent);
					}
					return this.internalPropertySystemCalendar;
				}
			}

			// Token: 0x170001F7 RID: 503
			// (get) Token: 0x06000612 RID: 1554 RVA: 0x00015CC0 File Offset: 0x00013EC0
			public ShellProperties.PropertySystemCommunication Communication
			{
				get
				{
					if (this.internalPropertySystemCommunication == null)
					{
						this.internalPropertySystemCommunication = new ShellProperties.PropertySystemCommunication(this.shellObjectParent);
					}
					return this.internalPropertySystemCommunication;
				}
			}

			// Token: 0x170001F8 RID: 504
			// (get) Token: 0x06000613 RID: 1555 RVA: 0x00015CFC File Offset: 0x00013EFC
			public ShellProperties.PropertySystemComputer Computer
			{
				get
				{
					if (this.internalPropertySystemComputer == null)
					{
						this.internalPropertySystemComputer = new ShellProperties.PropertySystemComputer(this.shellObjectParent);
					}
					return this.internalPropertySystemComputer;
				}
			}

			// Token: 0x170001F9 RID: 505
			// (get) Token: 0x06000614 RID: 1556 RVA: 0x00015D38 File Offset: 0x00013F38
			public ShellProperties.PropertySystemContact Contact
			{
				get
				{
					if (this.internalPropertySystemContact == null)
					{
						this.internalPropertySystemContact = new ShellProperties.PropertySystemContact(this.shellObjectParent);
					}
					return this.internalPropertySystemContact;
				}
			}

			// Token: 0x170001FA RID: 506
			// (get) Token: 0x06000615 RID: 1557 RVA: 0x00015D74 File Offset: 0x00013F74
			public ShellProperties.PropertySystemDevice Device
			{
				get
				{
					if (this.internalPropertySystemDevice == null)
					{
						this.internalPropertySystemDevice = new ShellProperties.PropertySystemDevice(this.shellObjectParent);
					}
					return this.internalPropertySystemDevice;
				}
			}

			// Token: 0x170001FB RID: 507
			// (get) Token: 0x06000616 RID: 1558 RVA: 0x00015DB0 File Offset: 0x00013FB0
			public ShellProperties.PropertySystemDeviceInterface DeviceInterface
			{
				get
				{
					if (this.internalPropertySystemDeviceInterface == null)
					{
						this.internalPropertySystemDeviceInterface = new ShellProperties.PropertySystemDeviceInterface(this.shellObjectParent);
					}
					return this.internalPropertySystemDeviceInterface;
				}
			}

			// Token: 0x170001FC RID: 508
			// (get) Token: 0x06000617 RID: 1559 RVA: 0x00015DEC File Offset: 0x00013FEC
			public ShellProperties.PropertySystemDevices Devices
			{
				get
				{
					if (this.internalPropertySystemDevices == null)
					{
						this.internalPropertySystemDevices = new ShellProperties.PropertySystemDevices(this.shellObjectParent);
					}
					return this.internalPropertySystemDevices;
				}
			}

			// Token: 0x170001FD RID: 509
			// (get) Token: 0x06000618 RID: 1560 RVA: 0x00015E28 File Offset: 0x00014028
			public ShellProperties.PropertySystemDocument Document
			{
				get
				{
					if (this.internalPropertySystemDocument == null)
					{
						this.internalPropertySystemDocument = new ShellProperties.PropertySystemDocument(this.shellObjectParent);
					}
					return this.internalPropertySystemDocument;
				}
			}

			// Token: 0x170001FE RID: 510
			// (get) Token: 0x06000619 RID: 1561 RVA: 0x00015E64 File Offset: 0x00014064
			public ShellProperties.PropertySystemDRM DRM
			{
				get
				{
					if (this.internalPropertySystemDRM == null)
					{
						this.internalPropertySystemDRM = new ShellProperties.PropertySystemDRM(this.shellObjectParent);
					}
					return this.internalPropertySystemDRM;
				}
			}

			// Token: 0x170001FF RID: 511
			// (get) Token: 0x0600061A RID: 1562 RVA: 0x00015EA0 File Offset: 0x000140A0
			public ShellProperties.PropertySystemGPS GPS
			{
				get
				{
					if (this.internalPropertySystemGPS == null)
					{
						this.internalPropertySystemGPS = new ShellProperties.PropertySystemGPS(this.shellObjectParent);
					}
					return this.internalPropertySystemGPS;
				}
			}

			// Token: 0x17000200 RID: 512
			// (get) Token: 0x0600061B RID: 1563 RVA: 0x00015EDC File Offset: 0x000140DC
			public ShellProperties.PropertySystemIdentity Identity
			{
				get
				{
					if (this.internalPropertySystemIdentity == null)
					{
						this.internalPropertySystemIdentity = new ShellProperties.PropertySystemIdentity(this.shellObjectParent);
					}
					return this.internalPropertySystemIdentity;
				}
			}

			// Token: 0x17000201 RID: 513
			// (get) Token: 0x0600061C RID: 1564 RVA: 0x00015F18 File Offset: 0x00014118
			public ShellProperties.PropertySystemIdentityProvider IdentityProvider
			{
				get
				{
					if (this.internalPropertySystemIdentityProvider == null)
					{
						this.internalPropertySystemIdentityProvider = new ShellProperties.PropertySystemIdentityProvider(this.shellObjectParent);
					}
					return this.internalPropertySystemIdentityProvider;
				}
			}

			// Token: 0x17000202 RID: 514
			// (get) Token: 0x0600061D RID: 1565 RVA: 0x00015F54 File Offset: 0x00014154
			public ShellProperties.PropertySystemImage Image
			{
				get
				{
					if (this.internalPropertySystemImage == null)
					{
						this.internalPropertySystemImage = new ShellProperties.PropertySystemImage(this.shellObjectParent);
					}
					return this.internalPropertySystemImage;
				}
			}

			// Token: 0x17000203 RID: 515
			// (get) Token: 0x0600061E RID: 1566 RVA: 0x00015F90 File Offset: 0x00014190
			public ShellProperties.PropertySystemJournal Journal
			{
				get
				{
					if (this.internalPropertySystemJournal == null)
					{
						this.internalPropertySystemJournal = new ShellProperties.PropertySystemJournal(this.shellObjectParent);
					}
					return this.internalPropertySystemJournal;
				}
			}

			// Token: 0x17000204 RID: 516
			// (get) Token: 0x0600061F RID: 1567 RVA: 0x00015FCC File Offset: 0x000141CC
			public ShellProperties.PropertySystemLayoutPattern LayoutPattern
			{
				get
				{
					if (this.internalPropertySystemLayoutPattern == null)
					{
						this.internalPropertySystemLayoutPattern = new ShellProperties.PropertySystemLayoutPattern(this.shellObjectParent);
					}
					return this.internalPropertySystemLayoutPattern;
				}
			}

			// Token: 0x17000205 RID: 517
			// (get) Token: 0x06000620 RID: 1568 RVA: 0x00016008 File Offset: 0x00014208
			public ShellProperties.PropertySystemLink Link
			{
				get
				{
					if (this.internalPropertySystemLink == null)
					{
						this.internalPropertySystemLink = new ShellProperties.PropertySystemLink(this.shellObjectParent);
					}
					return this.internalPropertySystemLink;
				}
			}

			// Token: 0x17000206 RID: 518
			// (get) Token: 0x06000621 RID: 1569 RVA: 0x00016044 File Offset: 0x00014244
			public ShellProperties.PropertySystemMedia Media
			{
				get
				{
					if (this.internalPropertySystemMedia == null)
					{
						this.internalPropertySystemMedia = new ShellProperties.PropertySystemMedia(this.shellObjectParent);
					}
					return this.internalPropertySystemMedia;
				}
			}

			// Token: 0x17000207 RID: 519
			// (get) Token: 0x06000622 RID: 1570 RVA: 0x00016080 File Offset: 0x00014280
			public ShellProperties.PropertySystemMessage Message
			{
				get
				{
					if (this.internalPropertySystemMessage == null)
					{
						this.internalPropertySystemMessage = new ShellProperties.PropertySystemMessage(this.shellObjectParent);
					}
					return this.internalPropertySystemMessage;
				}
			}

			// Token: 0x17000208 RID: 520
			// (get) Token: 0x06000623 RID: 1571 RVA: 0x000160BC File Offset: 0x000142BC
			public ShellProperties.PropertySystemMusic Music
			{
				get
				{
					if (this.internalPropertySystemMusic == null)
					{
						this.internalPropertySystemMusic = new ShellProperties.PropertySystemMusic(this.shellObjectParent);
					}
					return this.internalPropertySystemMusic;
				}
			}

			// Token: 0x17000209 RID: 521
			// (get) Token: 0x06000624 RID: 1572 RVA: 0x000160F8 File Offset: 0x000142F8
			public ShellProperties.PropertySystemNote Note
			{
				get
				{
					if (this.internalPropertySystemNote == null)
					{
						this.internalPropertySystemNote = new ShellProperties.PropertySystemNote(this.shellObjectParent);
					}
					return this.internalPropertySystemNote;
				}
			}

			// Token: 0x1700020A RID: 522
			// (get) Token: 0x06000625 RID: 1573 RVA: 0x00016134 File Offset: 0x00014334
			public ShellProperties.PropertySystemPhoto Photo
			{
				get
				{
					if (this.internalPropertySystemPhoto == null)
					{
						this.internalPropertySystemPhoto = new ShellProperties.PropertySystemPhoto(this.shellObjectParent);
					}
					return this.internalPropertySystemPhoto;
				}
			}

			// Token: 0x1700020B RID: 523
			// (get) Token: 0x06000626 RID: 1574 RVA: 0x00016170 File Offset: 0x00014370
			public ShellProperties.PropertySystemPropGroup PropGroup
			{
				get
				{
					if (this.internalPropertySystemPropGroup == null)
					{
						this.internalPropertySystemPropGroup = new ShellProperties.PropertySystemPropGroup(this.shellObjectParent);
					}
					return this.internalPropertySystemPropGroup;
				}
			}

			// Token: 0x1700020C RID: 524
			// (get) Token: 0x06000627 RID: 1575 RVA: 0x000161AC File Offset: 0x000143AC
			public ShellProperties.PropertySystemPropList PropList
			{
				get
				{
					if (this.internalPropertySystemPropList == null)
					{
						this.internalPropertySystemPropList = new ShellProperties.PropertySystemPropList(this.shellObjectParent);
					}
					return this.internalPropertySystemPropList;
				}
			}

			// Token: 0x1700020D RID: 525
			// (get) Token: 0x06000628 RID: 1576 RVA: 0x000161E8 File Offset: 0x000143E8
			public ShellProperties.PropertySystemRecordedTV RecordedTV
			{
				get
				{
					if (this.internalPropertySystemRecordedTV == null)
					{
						this.internalPropertySystemRecordedTV = new ShellProperties.PropertySystemRecordedTV(this.shellObjectParent);
					}
					return this.internalPropertySystemRecordedTV;
				}
			}

			// Token: 0x1700020E RID: 526
			// (get) Token: 0x06000629 RID: 1577 RVA: 0x00016224 File Offset: 0x00014424
			public ShellProperties.PropertySystemSearch Search
			{
				get
				{
					if (this.internalPropertySystemSearch == null)
					{
						this.internalPropertySystemSearch = new ShellProperties.PropertySystemSearch(this.shellObjectParent);
					}
					return this.internalPropertySystemSearch;
				}
			}

			// Token: 0x1700020F RID: 527
			// (get) Token: 0x0600062A RID: 1578 RVA: 0x00016260 File Offset: 0x00014460
			public ShellProperties.PropertySystemShell Shell
			{
				get
				{
					if (this.internalPropertySystemShell == null)
					{
						this.internalPropertySystemShell = new ShellProperties.PropertySystemShell(this.shellObjectParent);
					}
					return this.internalPropertySystemShell;
				}
			}

			// Token: 0x17000210 RID: 528
			// (get) Token: 0x0600062B RID: 1579 RVA: 0x0001629C File Offset: 0x0001449C
			public ShellProperties.PropertySystemSoftware Software
			{
				get
				{
					if (this.internalPropertySystemSoftware == null)
					{
						this.internalPropertySystemSoftware = new ShellProperties.PropertySystemSoftware(this.shellObjectParent);
					}
					return this.internalPropertySystemSoftware;
				}
			}

			// Token: 0x17000211 RID: 529
			// (get) Token: 0x0600062C RID: 1580 RVA: 0x000162D8 File Offset: 0x000144D8
			public ShellProperties.PropertySystemSync Sync
			{
				get
				{
					if (this.internalPropertySystemSync == null)
					{
						this.internalPropertySystemSync = new ShellProperties.PropertySystemSync(this.shellObjectParent);
					}
					return this.internalPropertySystemSync;
				}
			}

			// Token: 0x17000212 RID: 530
			// (get) Token: 0x0600062D RID: 1581 RVA: 0x00016314 File Offset: 0x00014514
			public ShellProperties.PropertySystemTask Task
			{
				get
				{
					if (this.internalPropertySystemTask == null)
					{
						this.internalPropertySystemTask = new ShellProperties.PropertySystemTask(this.shellObjectParent);
					}
					return this.internalPropertySystemTask;
				}
			}

			// Token: 0x17000213 RID: 531
			// (get) Token: 0x0600062E RID: 1582 RVA: 0x00016350 File Offset: 0x00014550
			public ShellProperties.PropertySystemVideo Video
			{
				get
				{
					if (this.internalPropertySystemVideo == null)
					{
						this.internalPropertySystemVideo = new ShellProperties.PropertySystemVideo(this.shellObjectParent);
					}
					return this.internalPropertySystemVideo;
				}
			}

			// Token: 0x17000214 RID: 532
			// (get) Token: 0x0600062F RID: 1583 RVA: 0x0001638C File Offset: 0x0001458C
			public ShellProperties.PropertySystemVolume Volume
			{
				get
				{
					if (this.internalPropertySystemVolume == null)
					{
						this.internalPropertySystemVolume = new ShellProperties.PropertySystemVolume(this.shellObjectParent);
					}
					return this.internalPropertySystemVolume;
				}
			}

			// Token: 0x04000338 RID: 824
			private ShellObject shellObjectParent;

			// Token: 0x04000339 RID: 825
			private Hashtable hashtable = new Hashtable();

			// Token: 0x0400033A RID: 826
			private ShellProperties.PropertySystemAppUserModel internalPropertySystemAppUserModel;

			// Token: 0x0400033B RID: 827
			private ShellProperties.PropertySystemAudio internalPropertySystemAudio;

			// Token: 0x0400033C RID: 828
			private ShellProperties.PropertySystemCalendar internalPropertySystemCalendar;

			// Token: 0x0400033D RID: 829
			private ShellProperties.PropertySystemCommunication internalPropertySystemCommunication;

			// Token: 0x0400033E RID: 830
			private ShellProperties.PropertySystemComputer internalPropertySystemComputer;

			// Token: 0x0400033F RID: 831
			private ShellProperties.PropertySystemContact internalPropertySystemContact;

			// Token: 0x04000340 RID: 832
			private ShellProperties.PropertySystemDevice internalPropertySystemDevice;

			// Token: 0x04000341 RID: 833
			private ShellProperties.PropertySystemDeviceInterface internalPropertySystemDeviceInterface;

			// Token: 0x04000342 RID: 834
			private ShellProperties.PropertySystemDevices internalPropertySystemDevices;

			// Token: 0x04000343 RID: 835
			private ShellProperties.PropertySystemDocument internalPropertySystemDocument;

			// Token: 0x04000344 RID: 836
			private ShellProperties.PropertySystemDRM internalPropertySystemDRM;

			// Token: 0x04000345 RID: 837
			private ShellProperties.PropertySystemGPS internalPropertySystemGPS;

			// Token: 0x04000346 RID: 838
			private ShellProperties.PropertySystemIdentity internalPropertySystemIdentity;

			// Token: 0x04000347 RID: 839
			private ShellProperties.PropertySystemIdentityProvider internalPropertySystemIdentityProvider;

			// Token: 0x04000348 RID: 840
			private ShellProperties.PropertySystemImage internalPropertySystemImage;

			// Token: 0x04000349 RID: 841
			private ShellProperties.PropertySystemJournal internalPropertySystemJournal;

			// Token: 0x0400034A RID: 842
			private ShellProperties.PropertySystemLayoutPattern internalPropertySystemLayoutPattern;

			// Token: 0x0400034B RID: 843
			private ShellProperties.PropertySystemLink internalPropertySystemLink;

			// Token: 0x0400034C RID: 844
			private ShellProperties.PropertySystemMedia internalPropertySystemMedia;

			// Token: 0x0400034D RID: 845
			private ShellProperties.PropertySystemMessage internalPropertySystemMessage;

			// Token: 0x0400034E RID: 846
			private ShellProperties.PropertySystemMusic internalPropertySystemMusic;

			// Token: 0x0400034F RID: 847
			private ShellProperties.PropertySystemNote internalPropertySystemNote;

			// Token: 0x04000350 RID: 848
			private ShellProperties.PropertySystemPhoto internalPropertySystemPhoto;

			// Token: 0x04000351 RID: 849
			private ShellProperties.PropertySystemPropGroup internalPropertySystemPropGroup;

			// Token: 0x04000352 RID: 850
			private ShellProperties.PropertySystemPropList internalPropertySystemPropList;

			// Token: 0x04000353 RID: 851
			private ShellProperties.PropertySystemRecordedTV internalPropertySystemRecordedTV;

			// Token: 0x04000354 RID: 852
			private ShellProperties.PropertySystemSearch internalPropertySystemSearch;

			// Token: 0x04000355 RID: 853
			private ShellProperties.PropertySystemShell internalPropertySystemShell;

			// Token: 0x04000356 RID: 854
			private ShellProperties.PropertySystemSoftware internalPropertySystemSoftware;

			// Token: 0x04000357 RID: 855
			private ShellProperties.PropertySystemSync internalPropertySystemSync;

			// Token: 0x04000358 RID: 856
			private ShellProperties.PropertySystemTask internalPropertySystemTask;

			// Token: 0x04000359 RID: 857
			private ShellProperties.PropertySystemVideo internalPropertySystemVideo;

			// Token: 0x0400035A RID: 858
			private ShellProperties.PropertySystemVolume internalPropertySystemVolume;
		}

		// Token: 0x020000AF RID: 175
		public class PropertySystemAppUserModel : PropertyStoreItems
		{
			// Token: 0x06000630 RID: 1584 RVA: 0x000163C7 File Offset: 0x000145C7
			internal PropertySystemAppUserModel(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000215 RID: 533
			// (get) Token: 0x06000631 RID: 1585 RVA: 0x000163E4 File Offset: 0x000145E4
			public ShellProperty<bool?> ExcludeFromShowInNewInstall
			{
				get
				{
					PropertyKey excludeFromShowInNewInstall = SystemProperties.System.AppUserModel.ExcludeFromShowInNewInstall;
					if (!this.hashtable.ContainsKey(excludeFromShowInNewInstall))
					{
						this.hashtable.Add(excludeFromShowInNewInstall, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(excludeFromShowInNewInstall));
					}
					return this.hashtable[excludeFromShowInNewInstall] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000216 RID: 534
			// (get) Token: 0x06000632 RID: 1586 RVA: 0x0001644C File Offset: 0x0001464C
			public ShellProperty<string> ID
			{
				get
				{
					PropertyKey id = SystemProperties.System.AppUserModel.ID;
					if (!this.hashtable.ContainsKey(id))
					{
						this.hashtable.Add(id, this.shellObjectParent.Properties.CreateTypedProperty<string>(id));
					}
					return this.hashtable[id] as ShellProperty<string>;
				}
			}

			// Token: 0x17000217 RID: 535
			// (get) Token: 0x06000633 RID: 1587 RVA: 0x000164B4 File Offset: 0x000146B4
			public ShellProperty<bool?> IsDestinationListSeparator
			{
				get
				{
					PropertyKey isDestinationListSeparator = SystemProperties.System.AppUserModel.IsDestinationListSeparator;
					if (!this.hashtable.ContainsKey(isDestinationListSeparator))
					{
						this.hashtable.Add(isDestinationListSeparator, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isDestinationListSeparator));
					}
					return this.hashtable[isDestinationListSeparator] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000218 RID: 536
			// (get) Token: 0x06000634 RID: 1588 RVA: 0x0001651C File Offset: 0x0001471C
			public ShellProperty<bool?> PreventPinning
			{
				get
				{
					PropertyKey preventPinning = SystemProperties.System.AppUserModel.PreventPinning;
					if (!this.hashtable.ContainsKey(preventPinning))
					{
						this.hashtable.Add(preventPinning, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(preventPinning));
					}
					return this.hashtable[preventPinning] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000219 RID: 537
			// (get) Token: 0x06000635 RID: 1589 RVA: 0x00016584 File Offset: 0x00014784
			public ShellProperty<string> RelaunchCommand
			{
				get
				{
					PropertyKey relaunchCommand = SystemProperties.System.AppUserModel.RelaunchCommand;
					if (!this.hashtable.ContainsKey(relaunchCommand))
					{
						this.hashtable.Add(relaunchCommand, this.shellObjectParent.Properties.CreateTypedProperty<string>(relaunchCommand));
					}
					return this.hashtable[relaunchCommand] as ShellProperty<string>;
				}
			}

			// Token: 0x1700021A RID: 538
			// (get) Token: 0x06000636 RID: 1590 RVA: 0x000165EC File Offset: 0x000147EC
			public ShellProperty<string> RelaunchDisplayNameResource
			{
				get
				{
					PropertyKey relaunchDisplayNameResource = SystemProperties.System.AppUserModel.RelaunchDisplayNameResource;
					if (!this.hashtable.ContainsKey(relaunchDisplayNameResource))
					{
						this.hashtable.Add(relaunchDisplayNameResource, this.shellObjectParent.Properties.CreateTypedProperty<string>(relaunchDisplayNameResource));
					}
					return this.hashtable[relaunchDisplayNameResource] as ShellProperty<string>;
				}
			}

			// Token: 0x1700021B RID: 539
			// (get) Token: 0x06000637 RID: 1591 RVA: 0x00016654 File Offset: 0x00014854
			public ShellProperty<string> RelaunchIconResource
			{
				get
				{
					PropertyKey relaunchIconResource = SystemProperties.System.AppUserModel.RelaunchIconResource;
					if (!this.hashtable.ContainsKey(relaunchIconResource))
					{
						this.hashtable.Add(relaunchIconResource, this.shellObjectParent.Properties.CreateTypedProperty<string>(relaunchIconResource));
					}
					return this.hashtable[relaunchIconResource] as ShellProperty<string>;
				}
			}

			// Token: 0x0400035B RID: 859
			private ShellObject shellObjectParent;

			// Token: 0x0400035C RID: 860
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000B0 RID: 176
		public class PropertySystemAudio : PropertyStoreItems
		{
			// Token: 0x06000638 RID: 1592 RVA: 0x000166BC File Offset: 0x000148BC
			internal PropertySystemAudio(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700021C RID: 540
			// (get) Token: 0x06000639 RID: 1593 RVA: 0x000166DC File Offset: 0x000148DC
			public ShellProperty<uint?> ChannelCount
			{
				get
				{
					PropertyKey channelCount = SystemProperties.System.Audio.ChannelCount;
					if (!this.hashtable.ContainsKey(channelCount))
					{
						this.hashtable.Add(channelCount, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(channelCount));
					}
					return this.hashtable[channelCount] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700021D RID: 541
			// (get) Token: 0x0600063A RID: 1594 RVA: 0x00016744 File Offset: 0x00014944
			public ShellProperty<string> Compression
			{
				get
				{
					PropertyKey compression = SystemProperties.System.Audio.Compression;
					if (!this.hashtable.ContainsKey(compression))
					{
						this.hashtable.Add(compression, this.shellObjectParent.Properties.CreateTypedProperty<string>(compression));
					}
					return this.hashtable[compression] as ShellProperty<string>;
				}
			}

			// Token: 0x1700021E RID: 542
			// (get) Token: 0x0600063B RID: 1595 RVA: 0x000167AC File Offset: 0x000149AC
			public ShellProperty<uint?> EncodingBitrate
			{
				get
				{
					PropertyKey encodingBitrate = SystemProperties.System.Audio.EncodingBitrate;
					if (!this.hashtable.ContainsKey(encodingBitrate))
					{
						this.hashtable.Add(encodingBitrate, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(encodingBitrate));
					}
					return this.hashtable[encodingBitrate] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700021F RID: 543
			// (get) Token: 0x0600063C RID: 1596 RVA: 0x00016814 File Offset: 0x00014A14
			public ShellProperty<string> Format
			{
				get
				{
					PropertyKey format = SystemProperties.System.Audio.Format;
					if (!this.hashtable.ContainsKey(format))
					{
						this.hashtable.Add(format, this.shellObjectParent.Properties.CreateTypedProperty<string>(format));
					}
					return this.hashtable[format] as ShellProperty<string>;
				}
			}

			// Token: 0x17000220 RID: 544
			// (get) Token: 0x0600063D RID: 1597 RVA: 0x0001687C File Offset: 0x00014A7C
			public ShellProperty<bool?> IsVariableBitrate
			{
				get
				{
					PropertyKey isVariableBitrate = SystemProperties.System.Audio.IsVariableBitrate;
					if (!this.hashtable.ContainsKey(isVariableBitrate))
					{
						this.hashtable.Add(isVariableBitrate, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isVariableBitrate));
					}
					return this.hashtable[isVariableBitrate] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000221 RID: 545
			// (get) Token: 0x0600063E RID: 1598 RVA: 0x000168E4 File Offset: 0x00014AE4
			public ShellProperty<uint?> PeakValue
			{
				get
				{
					PropertyKey peakValue = SystemProperties.System.Audio.PeakValue;
					if (!this.hashtable.ContainsKey(peakValue))
					{
						this.hashtable.Add(peakValue, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(peakValue));
					}
					return this.hashtable[peakValue] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000222 RID: 546
			// (get) Token: 0x0600063F RID: 1599 RVA: 0x0001694C File Offset: 0x00014B4C
			public ShellProperty<uint?> SampleRate
			{
				get
				{
					PropertyKey sampleRate = SystemProperties.System.Audio.SampleRate;
					if (!this.hashtable.ContainsKey(sampleRate))
					{
						this.hashtable.Add(sampleRate, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(sampleRate));
					}
					return this.hashtable[sampleRate] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000223 RID: 547
			// (get) Token: 0x06000640 RID: 1600 RVA: 0x000169B4 File Offset: 0x00014BB4
			public ShellProperty<uint?> SampleSize
			{
				get
				{
					PropertyKey sampleSize = SystemProperties.System.Audio.SampleSize;
					if (!this.hashtable.ContainsKey(sampleSize))
					{
						this.hashtable.Add(sampleSize, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(sampleSize));
					}
					return this.hashtable[sampleSize] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000224 RID: 548
			// (get) Token: 0x06000641 RID: 1601 RVA: 0x00016A1C File Offset: 0x00014C1C
			public ShellProperty<string> StreamName
			{
				get
				{
					PropertyKey streamName = SystemProperties.System.Audio.StreamName;
					if (!this.hashtable.ContainsKey(streamName))
					{
						this.hashtable.Add(streamName, this.shellObjectParent.Properties.CreateTypedProperty<string>(streamName));
					}
					return this.hashtable[streamName] as ShellProperty<string>;
				}
			}

			// Token: 0x17000225 RID: 549
			// (get) Token: 0x06000642 RID: 1602 RVA: 0x00016A84 File Offset: 0x00014C84
			public ShellProperty<ushort?> StreamNumber
			{
				get
				{
					PropertyKey streamNumber = SystemProperties.System.Audio.StreamNumber;
					if (!this.hashtable.ContainsKey(streamNumber))
					{
						this.hashtable.Add(streamNumber, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(streamNumber));
					}
					return this.hashtable[streamNumber] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x0400035D RID: 861
			private ShellObject shellObjectParent;

			// Token: 0x0400035E RID: 862
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000B1 RID: 177
		public class PropertySystemCalendar : PropertyStoreItems
		{
			// Token: 0x06000643 RID: 1603 RVA: 0x00016AEC File Offset: 0x00014CEC
			internal PropertySystemCalendar(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000226 RID: 550
			// (get) Token: 0x06000644 RID: 1604 RVA: 0x00016B0C File Offset: 0x00014D0C
			public ShellProperty<string> Duration
			{
				get
				{
					PropertyKey duration = SystemProperties.System.Calendar.Duration;
					if (!this.hashtable.ContainsKey(duration))
					{
						this.hashtable.Add(duration, this.shellObjectParent.Properties.CreateTypedProperty<string>(duration));
					}
					return this.hashtable[duration] as ShellProperty<string>;
				}
			}

			// Token: 0x17000227 RID: 551
			// (get) Token: 0x06000645 RID: 1605 RVA: 0x00016B74 File Offset: 0x00014D74
			public ShellProperty<bool?> IsOnline
			{
				get
				{
					PropertyKey isOnline = SystemProperties.System.Calendar.IsOnline;
					if (!this.hashtable.ContainsKey(isOnline))
					{
						this.hashtable.Add(isOnline, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isOnline));
					}
					return this.hashtable[isOnline] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000228 RID: 552
			// (get) Token: 0x06000646 RID: 1606 RVA: 0x00016BDC File Offset: 0x00014DDC
			public ShellProperty<bool?> IsRecurring
			{
				get
				{
					PropertyKey isRecurring = SystemProperties.System.Calendar.IsRecurring;
					if (!this.hashtable.ContainsKey(isRecurring))
					{
						this.hashtable.Add(isRecurring, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isRecurring));
					}
					return this.hashtable[isRecurring] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000229 RID: 553
			// (get) Token: 0x06000647 RID: 1607 RVA: 0x00016C44 File Offset: 0x00014E44
			public ShellProperty<string> Location
			{
				get
				{
					PropertyKey location = SystemProperties.System.Calendar.Location;
					if (!this.hashtable.ContainsKey(location))
					{
						this.hashtable.Add(location, this.shellObjectParent.Properties.CreateTypedProperty<string>(location));
					}
					return this.hashtable[location] as ShellProperty<string>;
				}
			}

			// Token: 0x1700022A RID: 554
			// (get) Token: 0x06000648 RID: 1608 RVA: 0x00016CAC File Offset: 0x00014EAC
			public ShellProperty<string[]> OptionalAttendeeAddresses
			{
				get
				{
					PropertyKey optionalAttendeeAddresses = SystemProperties.System.Calendar.OptionalAttendeeAddresses;
					if (!this.hashtable.ContainsKey(optionalAttendeeAddresses))
					{
						this.hashtable.Add(optionalAttendeeAddresses, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(optionalAttendeeAddresses));
					}
					return this.hashtable[optionalAttendeeAddresses] as ShellProperty<string[]>;
				}
			}

			// Token: 0x1700022B RID: 555
			// (get) Token: 0x06000649 RID: 1609 RVA: 0x00016D14 File Offset: 0x00014F14
			public ShellProperty<string[]> OptionalAttendeeNames
			{
				get
				{
					PropertyKey optionalAttendeeNames = SystemProperties.System.Calendar.OptionalAttendeeNames;
					if (!this.hashtable.ContainsKey(optionalAttendeeNames))
					{
						this.hashtable.Add(optionalAttendeeNames, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(optionalAttendeeNames));
					}
					return this.hashtable[optionalAttendeeNames] as ShellProperty<string[]>;
				}
			}

			// Token: 0x1700022C RID: 556
			// (get) Token: 0x0600064A RID: 1610 RVA: 0x00016D7C File Offset: 0x00014F7C
			public ShellProperty<string> OrganizerAddress
			{
				get
				{
					PropertyKey organizerAddress = SystemProperties.System.Calendar.OrganizerAddress;
					if (!this.hashtable.ContainsKey(organizerAddress))
					{
						this.hashtable.Add(organizerAddress, this.shellObjectParent.Properties.CreateTypedProperty<string>(organizerAddress));
					}
					return this.hashtable[organizerAddress] as ShellProperty<string>;
				}
			}

			// Token: 0x1700022D RID: 557
			// (get) Token: 0x0600064B RID: 1611 RVA: 0x00016DE4 File Offset: 0x00014FE4
			public ShellProperty<string> OrganizerName
			{
				get
				{
					PropertyKey organizerName = SystemProperties.System.Calendar.OrganizerName;
					if (!this.hashtable.ContainsKey(organizerName))
					{
						this.hashtable.Add(organizerName, this.shellObjectParent.Properties.CreateTypedProperty<string>(organizerName));
					}
					return this.hashtable[organizerName] as ShellProperty<string>;
				}
			}

			// Token: 0x1700022E RID: 558
			// (get) Token: 0x0600064C RID: 1612 RVA: 0x00016E4C File Offset: 0x0001504C
			public ShellProperty<DateTime?> ReminderTime
			{
				get
				{
					PropertyKey reminderTime = SystemProperties.System.Calendar.ReminderTime;
					if (!this.hashtable.ContainsKey(reminderTime))
					{
						this.hashtable.Add(reminderTime, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(reminderTime));
					}
					return this.hashtable[reminderTime] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x1700022F RID: 559
			// (get) Token: 0x0600064D RID: 1613 RVA: 0x00016EB4 File Offset: 0x000150B4
			public ShellProperty<string[]> RequiredAttendeeAddresses
			{
				get
				{
					PropertyKey requiredAttendeeAddresses = SystemProperties.System.Calendar.RequiredAttendeeAddresses;
					if (!this.hashtable.ContainsKey(requiredAttendeeAddresses))
					{
						this.hashtable.Add(requiredAttendeeAddresses, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(requiredAttendeeAddresses));
					}
					return this.hashtable[requiredAttendeeAddresses] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000230 RID: 560
			// (get) Token: 0x0600064E RID: 1614 RVA: 0x00016F1C File Offset: 0x0001511C
			public ShellProperty<string[]> RequiredAttendeeNames
			{
				get
				{
					PropertyKey requiredAttendeeNames = SystemProperties.System.Calendar.RequiredAttendeeNames;
					if (!this.hashtable.ContainsKey(requiredAttendeeNames))
					{
						this.hashtable.Add(requiredAttendeeNames, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(requiredAttendeeNames));
					}
					return this.hashtable[requiredAttendeeNames] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000231 RID: 561
			// (get) Token: 0x0600064F RID: 1615 RVA: 0x00016F84 File Offset: 0x00015184
			public ShellProperty<string[]> Resources
			{
				get
				{
					PropertyKey resources = SystemProperties.System.Calendar.Resources;
					if (!this.hashtable.ContainsKey(resources))
					{
						this.hashtable.Add(resources, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(resources));
					}
					return this.hashtable[resources] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000232 RID: 562
			// (get) Token: 0x06000650 RID: 1616 RVA: 0x00016FEC File Offset: 0x000151EC
			public ShellProperty<ushort?> ResponseStatus
			{
				get
				{
					PropertyKey responseStatus = SystemProperties.System.Calendar.ResponseStatus;
					if (!this.hashtable.ContainsKey(responseStatus))
					{
						this.hashtable.Add(responseStatus, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(responseStatus));
					}
					return this.hashtable[responseStatus] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x17000233 RID: 563
			// (get) Token: 0x06000651 RID: 1617 RVA: 0x00017054 File Offset: 0x00015254
			public ShellProperty<ushort?> ShowTimeAs
			{
				get
				{
					PropertyKey showTimeAs = SystemProperties.System.Calendar.ShowTimeAs;
					if (!this.hashtable.ContainsKey(showTimeAs))
					{
						this.hashtable.Add(showTimeAs, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(showTimeAs));
					}
					return this.hashtable[showTimeAs] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x17000234 RID: 564
			// (get) Token: 0x06000652 RID: 1618 RVA: 0x000170BC File Offset: 0x000152BC
			public ShellProperty<string> ShowTimeAsText
			{
				get
				{
					PropertyKey showTimeAsText = SystemProperties.System.Calendar.ShowTimeAsText;
					if (!this.hashtable.ContainsKey(showTimeAsText))
					{
						this.hashtable.Add(showTimeAsText, this.shellObjectParent.Properties.CreateTypedProperty<string>(showTimeAsText));
					}
					return this.hashtable[showTimeAsText] as ShellProperty<string>;
				}
			}

			// Token: 0x0400035F RID: 863
			private ShellObject shellObjectParent;

			// Token: 0x04000360 RID: 864
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000B2 RID: 178
		public class PropertySystemCommunication : PropertyStoreItems
		{
			// Token: 0x06000653 RID: 1619 RVA: 0x00017124 File Offset: 0x00015324
			internal PropertySystemCommunication(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000235 RID: 565
			// (get) Token: 0x06000654 RID: 1620 RVA: 0x00017144 File Offset: 0x00015344
			public ShellProperty<string> AccountName
			{
				get
				{
					PropertyKey accountName = SystemProperties.System.Communication.AccountName;
					if (!this.hashtable.ContainsKey(accountName))
					{
						this.hashtable.Add(accountName, this.shellObjectParent.Properties.CreateTypedProperty<string>(accountName));
					}
					return this.hashtable[accountName] as ShellProperty<string>;
				}
			}

			// Token: 0x17000236 RID: 566
			// (get) Token: 0x06000655 RID: 1621 RVA: 0x000171AC File Offset: 0x000153AC
			public ShellProperty<DateTime?> DateItemExpires
			{
				get
				{
					PropertyKey dateItemExpires = SystemProperties.System.Communication.DateItemExpires;
					if (!this.hashtable.ContainsKey(dateItemExpires))
					{
						this.hashtable.Add(dateItemExpires, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateItemExpires));
					}
					return this.hashtable[dateItemExpires] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000237 RID: 567
			// (get) Token: 0x06000656 RID: 1622 RVA: 0x00017214 File Offset: 0x00015414
			public ShellProperty<int?> FollowUpIconIndex
			{
				get
				{
					PropertyKey followUpIconIndex = SystemProperties.System.Communication.FollowUpIconIndex;
					if (!this.hashtable.ContainsKey(followUpIconIndex))
					{
						this.hashtable.Add(followUpIconIndex, this.shellObjectParent.Properties.CreateTypedProperty<int?>(followUpIconIndex));
					}
					return this.hashtable[followUpIconIndex] as ShellProperty<int?>;
				}
			}

			// Token: 0x17000238 RID: 568
			// (get) Token: 0x06000657 RID: 1623 RVA: 0x0001727C File Offset: 0x0001547C
			public ShellProperty<bool?> HeaderItem
			{
				get
				{
					PropertyKey headerItem = SystemProperties.System.Communication.HeaderItem;
					if (!this.hashtable.ContainsKey(headerItem))
					{
						this.hashtable.Add(headerItem, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(headerItem));
					}
					return this.hashtable[headerItem] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000239 RID: 569
			// (get) Token: 0x06000658 RID: 1624 RVA: 0x000172E4 File Offset: 0x000154E4
			public ShellProperty<string> PolicyTag
			{
				get
				{
					PropertyKey policyTag = SystemProperties.System.Communication.PolicyTag;
					if (!this.hashtable.ContainsKey(policyTag))
					{
						this.hashtable.Add(policyTag, this.shellObjectParent.Properties.CreateTypedProperty<string>(policyTag));
					}
					return this.hashtable[policyTag] as ShellProperty<string>;
				}
			}

			// Token: 0x1700023A RID: 570
			// (get) Token: 0x06000659 RID: 1625 RVA: 0x0001734C File Offset: 0x0001554C
			public ShellProperty<int?> SecurityFlags
			{
				get
				{
					PropertyKey securityFlags = SystemProperties.System.Communication.SecurityFlags;
					if (!this.hashtable.ContainsKey(securityFlags))
					{
						this.hashtable.Add(securityFlags, this.shellObjectParent.Properties.CreateTypedProperty<int?>(securityFlags));
					}
					return this.hashtable[securityFlags] as ShellProperty<int?>;
				}
			}

			// Token: 0x1700023B RID: 571
			// (get) Token: 0x0600065A RID: 1626 RVA: 0x000173B4 File Offset: 0x000155B4
			public ShellProperty<string> Suffix
			{
				get
				{
					PropertyKey suffix = SystemProperties.System.Communication.Suffix;
					if (!this.hashtable.ContainsKey(suffix))
					{
						this.hashtable.Add(suffix, this.shellObjectParent.Properties.CreateTypedProperty<string>(suffix));
					}
					return this.hashtable[suffix] as ShellProperty<string>;
				}
			}

			// Token: 0x1700023C RID: 572
			// (get) Token: 0x0600065B RID: 1627 RVA: 0x0001741C File Offset: 0x0001561C
			public ShellProperty<ushort?> TaskStatus
			{
				get
				{
					PropertyKey taskStatus = SystemProperties.System.Communication.TaskStatus;
					if (!this.hashtable.ContainsKey(taskStatus))
					{
						this.hashtable.Add(taskStatus, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(taskStatus));
					}
					return this.hashtable[taskStatus] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x1700023D RID: 573
			// (get) Token: 0x0600065C RID: 1628 RVA: 0x00017484 File Offset: 0x00015684
			public ShellProperty<string> TaskStatusText
			{
				get
				{
					PropertyKey taskStatusText = SystemProperties.System.Communication.TaskStatusText;
					if (!this.hashtable.ContainsKey(taskStatusText))
					{
						this.hashtable.Add(taskStatusText, this.shellObjectParent.Properties.CreateTypedProperty<string>(taskStatusText));
					}
					return this.hashtable[taskStatusText] as ShellProperty<string>;
				}
			}

			// Token: 0x04000361 RID: 865
			private ShellObject shellObjectParent;

			// Token: 0x04000362 RID: 866
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000B3 RID: 179
		public class PropertySystemComputer : PropertyStoreItems
		{
			// Token: 0x0600065D RID: 1629 RVA: 0x000174EC File Offset: 0x000156EC
			internal PropertySystemComputer(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700023E RID: 574
			// (get) Token: 0x0600065E RID: 1630 RVA: 0x0001750C File Offset: 0x0001570C
			public ShellProperty<ulong[]> DecoratedFreeSpace
			{
				get
				{
					PropertyKey decoratedFreeSpace = SystemProperties.System.Computer.DecoratedFreeSpace;
					if (!this.hashtable.ContainsKey(decoratedFreeSpace))
					{
						this.hashtable.Add(decoratedFreeSpace, this.shellObjectParent.Properties.CreateTypedProperty<ulong[]>(decoratedFreeSpace));
					}
					return this.hashtable[decoratedFreeSpace] as ShellProperty<ulong[]>;
				}
			}

			// Token: 0x04000363 RID: 867
			private ShellObject shellObjectParent;

			// Token: 0x04000364 RID: 868
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000B4 RID: 180
		public class PropertySystemContact : PropertyStoreItems
		{
			// Token: 0x0600065F RID: 1631 RVA: 0x00017574 File Offset: 0x00015774
			internal PropertySystemContact(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700023F RID: 575
			// (get) Token: 0x06000660 RID: 1632 RVA: 0x00017594 File Offset: 0x00015794
			public ShellProperty<DateTime?> Anniversary
			{
				get
				{
					PropertyKey anniversary = SystemProperties.System.Contact.Anniversary;
					if (!this.hashtable.ContainsKey(anniversary))
					{
						this.hashtable.Add(anniversary, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(anniversary));
					}
					return this.hashtable[anniversary] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000240 RID: 576
			// (get) Token: 0x06000661 RID: 1633 RVA: 0x000175FC File Offset: 0x000157FC
			public ShellProperty<string> AssistantName
			{
				get
				{
					PropertyKey assistantName = SystemProperties.System.Contact.AssistantName;
					if (!this.hashtable.ContainsKey(assistantName))
					{
						this.hashtable.Add(assistantName, this.shellObjectParent.Properties.CreateTypedProperty<string>(assistantName));
					}
					return this.hashtable[assistantName] as ShellProperty<string>;
				}
			}

			// Token: 0x17000241 RID: 577
			// (get) Token: 0x06000662 RID: 1634 RVA: 0x00017664 File Offset: 0x00015864
			public ShellProperty<string> AssistantTelephone
			{
				get
				{
					PropertyKey assistantTelephone = SystemProperties.System.Contact.AssistantTelephone;
					if (!this.hashtable.ContainsKey(assistantTelephone))
					{
						this.hashtable.Add(assistantTelephone, this.shellObjectParent.Properties.CreateTypedProperty<string>(assistantTelephone));
					}
					return this.hashtable[assistantTelephone] as ShellProperty<string>;
				}
			}

			// Token: 0x17000242 RID: 578
			// (get) Token: 0x06000663 RID: 1635 RVA: 0x000176CC File Offset: 0x000158CC
			public ShellProperty<DateTime?> Birthday
			{
				get
				{
					PropertyKey birthday = SystemProperties.System.Contact.Birthday;
					if (!this.hashtable.ContainsKey(birthday))
					{
						this.hashtable.Add(birthday, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(birthday));
					}
					return this.hashtable[birthday] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000243 RID: 579
			// (get) Token: 0x06000664 RID: 1636 RVA: 0x00017734 File Offset: 0x00015934
			public ShellProperty<string> BusinessAddress
			{
				get
				{
					PropertyKey businessAddress = SystemProperties.System.Contact.BusinessAddress;
					if (!this.hashtable.ContainsKey(businessAddress))
					{
						this.hashtable.Add(businessAddress, this.shellObjectParent.Properties.CreateTypedProperty<string>(businessAddress));
					}
					return this.hashtable[businessAddress] as ShellProperty<string>;
				}
			}

			// Token: 0x17000244 RID: 580
			// (get) Token: 0x06000665 RID: 1637 RVA: 0x0001779C File Offset: 0x0001599C
			public ShellProperty<string> BusinessAddressCity
			{
				get
				{
					PropertyKey businessAddressCity = SystemProperties.System.Contact.BusinessAddressCity;
					if (!this.hashtable.ContainsKey(businessAddressCity))
					{
						this.hashtable.Add(businessAddressCity, this.shellObjectParent.Properties.CreateTypedProperty<string>(businessAddressCity));
					}
					return this.hashtable[businessAddressCity] as ShellProperty<string>;
				}
			}

			// Token: 0x17000245 RID: 581
			// (get) Token: 0x06000666 RID: 1638 RVA: 0x00017804 File Offset: 0x00015A04
			public ShellProperty<string> BusinessAddressCountry
			{
				get
				{
					PropertyKey businessAddressCountry = SystemProperties.System.Contact.BusinessAddressCountry;
					if (!this.hashtable.ContainsKey(businessAddressCountry))
					{
						this.hashtable.Add(businessAddressCountry, this.shellObjectParent.Properties.CreateTypedProperty<string>(businessAddressCountry));
					}
					return this.hashtable[businessAddressCountry] as ShellProperty<string>;
				}
			}

			// Token: 0x17000246 RID: 582
			// (get) Token: 0x06000667 RID: 1639 RVA: 0x0001786C File Offset: 0x00015A6C
			public ShellProperty<string> BusinessAddressPostalCode
			{
				get
				{
					PropertyKey businessAddressPostalCode = SystemProperties.System.Contact.BusinessAddressPostalCode;
					if (!this.hashtable.ContainsKey(businessAddressPostalCode))
					{
						this.hashtable.Add(businessAddressPostalCode, this.shellObjectParent.Properties.CreateTypedProperty<string>(businessAddressPostalCode));
					}
					return this.hashtable[businessAddressPostalCode] as ShellProperty<string>;
				}
			}

			// Token: 0x17000247 RID: 583
			// (get) Token: 0x06000668 RID: 1640 RVA: 0x000178D4 File Offset: 0x00015AD4
			public ShellProperty<string> BusinessAddressPostOfficeBox
			{
				get
				{
					PropertyKey businessAddressPostOfficeBox = SystemProperties.System.Contact.BusinessAddressPostOfficeBox;
					if (!this.hashtable.ContainsKey(businessAddressPostOfficeBox))
					{
						this.hashtable.Add(businessAddressPostOfficeBox, this.shellObjectParent.Properties.CreateTypedProperty<string>(businessAddressPostOfficeBox));
					}
					return this.hashtable[businessAddressPostOfficeBox] as ShellProperty<string>;
				}
			}

			// Token: 0x17000248 RID: 584
			// (get) Token: 0x06000669 RID: 1641 RVA: 0x0001793C File Offset: 0x00015B3C
			public ShellProperty<string> BusinessAddressState
			{
				get
				{
					PropertyKey businessAddressState = SystemProperties.System.Contact.BusinessAddressState;
					if (!this.hashtable.ContainsKey(businessAddressState))
					{
						this.hashtable.Add(businessAddressState, this.shellObjectParent.Properties.CreateTypedProperty<string>(businessAddressState));
					}
					return this.hashtable[businessAddressState] as ShellProperty<string>;
				}
			}

			// Token: 0x17000249 RID: 585
			// (get) Token: 0x0600066A RID: 1642 RVA: 0x000179A4 File Offset: 0x00015BA4
			public ShellProperty<string> BusinessAddressStreet
			{
				get
				{
					PropertyKey businessAddressStreet = SystemProperties.System.Contact.BusinessAddressStreet;
					if (!this.hashtable.ContainsKey(businessAddressStreet))
					{
						this.hashtable.Add(businessAddressStreet, this.shellObjectParent.Properties.CreateTypedProperty<string>(businessAddressStreet));
					}
					return this.hashtable[businessAddressStreet] as ShellProperty<string>;
				}
			}

			// Token: 0x1700024A RID: 586
			// (get) Token: 0x0600066B RID: 1643 RVA: 0x00017A0C File Offset: 0x00015C0C
			public ShellProperty<string> BusinessFaxNumber
			{
				get
				{
					PropertyKey businessFaxNumber = SystemProperties.System.Contact.BusinessFaxNumber;
					if (!this.hashtable.ContainsKey(businessFaxNumber))
					{
						this.hashtable.Add(businessFaxNumber, this.shellObjectParent.Properties.CreateTypedProperty<string>(businessFaxNumber));
					}
					return this.hashtable[businessFaxNumber] as ShellProperty<string>;
				}
			}

			// Token: 0x1700024B RID: 587
			// (get) Token: 0x0600066C RID: 1644 RVA: 0x00017A74 File Offset: 0x00015C74
			public ShellProperty<string> BusinessHomepage
			{
				get
				{
					PropertyKey businessHomepage = SystemProperties.System.Contact.BusinessHomepage;
					if (!this.hashtable.ContainsKey(businessHomepage))
					{
						this.hashtable.Add(businessHomepage, this.shellObjectParent.Properties.CreateTypedProperty<string>(businessHomepage));
					}
					return this.hashtable[businessHomepage] as ShellProperty<string>;
				}
			}

			// Token: 0x1700024C RID: 588
			// (get) Token: 0x0600066D RID: 1645 RVA: 0x00017ADC File Offset: 0x00015CDC
			public ShellProperty<string> BusinessTelephone
			{
				get
				{
					PropertyKey businessTelephone = SystemProperties.System.Contact.BusinessTelephone;
					if (!this.hashtable.ContainsKey(businessTelephone))
					{
						this.hashtable.Add(businessTelephone, this.shellObjectParent.Properties.CreateTypedProperty<string>(businessTelephone));
					}
					return this.hashtable[businessTelephone] as ShellProperty<string>;
				}
			}

			// Token: 0x1700024D RID: 589
			// (get) Token: 0x0600066E RID: 1646 RVA: 0x00017B44 File Offset: 0x00015D44
			public ShellProperty<string> CallbackTelephone
			{
				get
				{
					PropertyKey callbackTelephone = SystemProperties.System.Contact.CallbackTelephone;
					if (!this.hashtable.ContainsKey(callbackTelephone))
					{
						this.hashtable.Add(callbackTelephone, this.shellObjectParent.Properties.CreateTypedProperty<string>(callbackTelephone));
					}
					return this.hashtable[callbackTelephone] as ShellProperty<string>;
				}
			}

			// Token: 0x1700024E RID: 590
			// (get) Token: 0x0600066F RID: 1647 RVA: 0x00017BAC File Offset: 0x00015DAC
			public ShellProperty<string> CarTelephone
			{
				get
				{
					PropertyKey carTelephone = SystemProperties.System.Contact.CarTelephone;
					if (!this.hashtable.ContainsKey(carTelephone))
					{
						this.hashtable.Add(carTelephone, this.shellObjectParent.Properties.CreateTypedProperty<string>(carTelephone));
					}
					return this.hashtable[carTelephone] as ShellProperty<string>;
				}
			}

			// Token: 0x1700024F RID: 591
			// (get) Token: 0x06000670 RID: 1648 RVA: 0x00017C14 File Offset: 0x00015E14
			public ShellProperty<string[]> Children
			{
				get
				{
					PropertyKey children = SystemProperties.System.Contact.Children;
					if (!this.hashtable.ContainsKey(children))
					{
						this.hashtable.Add(children, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(children));
					}
					return this.hashtable[children] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000250 RID: 592
			// (get) Token: 0x06000671 RID: 1649 RVA: 0x00017C7C File Offset: 0x00015E7C
			public ShellProperty<string> CompanyMainTelephone
			{
				get
				{
					PropertyKey companyMainTelephone = SystemProperties.System.Contact.CompanyMainTelephone;
					if (!this.hashtable.ContainsKey(companyMainTelephone))
					{
						this.hashtable.Add(companyMainTelephone, this.shellObjectParent.Properties.CreateTypedProperty<string>(companyMainTelephone));
					}
					return this.hashtable[companyMainTelephone] as ShellProperty<string>;
				}
			}

			// Token: 0x17000251 RID: 593
			// (get) Token: 0x06000672 RID: 1650 RVA: 0x00017CE4 File Offset: 0x00015EE4
			public ShellProperty<string> Department
			{
				get
				{
					PropertyKey department = SystemProperties.System.Contact.Department;
					if (!this.hashtable.ContainsKey(department))
					{
						this.hashtable.Add(department, this.shellObjectParent.Properties.CreateTypedProperty<string>(department));
					}
					return this.hashtable[department] as ShellProperty<string>;
				}
			}

			// Token: 0x17000252 RID: 594
			// (get) Token: 0x06000673 RID: 1651 RVA: 0x00017D4C File Offset: 0x00015F4C
			public ShellProperty<string> EmailAddress
			{
				get
				{
					PropertyKey emailAddress = SystemProperties.System.Contact.EmailAddress;
					if (!this.hashtable.ContainsKey(emailAddress))
					{
						this.hashtable.Add(emailAddress, this.shellObjectParent.Properties.CreateTypedProperty<string>(emailAddress));
					}
					return this.hashtable[emailAddress] as ShellProperty<string>;
				}
			}

			// Token: 0x17000253 RID: 595
			// (get) Token: 0x06000674 RID: 1652 RVA: 0x00017DB4 File Offset: 0x00015FB4
			public ShellProperty<string> EmailAddress2
			{
				get
				{
					PropertyKey emailAddress = SystemProperties.System.Contact.EmailAddress2;
					if (!this.hashtable.ContainsKey(emailAddress))
					{
						this.hashtable.Add(emailAddress, this.shellObjectParent.Properties.CreateTypedProperty<string>(emailAddress));
					}
					return this.hashtable[emailAddress] as ShellProperty<string>;
				}
			}

			// Token: 0x17000254 RID: 596
			// (get) Token: 0x06000675 RID: 1653 RVA: 0x00017E1C File Offset: 0x0001601C
			public ShellProperty<string> EmailAddress3
			{
				get
				{
					PropertyKey emailAddress = SystemProperties.System.Contact.EmailAddress3;
					if (!this.hashtable.ContainsKey(emailAddress))
					{
						this.hashtable.Add(emailAddress, this.shellObjectParent.Properties.CreateTypedProperty<string>(emailAddress));
					}
					return this.hashtable[emailAddress] as ShellProperty<string>;
				}
			}

			// Token: 0x17000255 RID: 597
			// (get) Token: 0x06000676 RID: 1654 RVA: 0x00017E84 File Offset: 0x00016084
			public ShellProperty<string[]> EmailAddresses
			{
				get
				{
					PropertyKey emailAddresses = SystemProperties.System.Contact.EmailAddresses;
					if (!this.hashtable.ContainsKey(emailAddresses))
					{
						this.hashtable.Add(emailAddresses, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(emailAddresses));
					}
					return this.hashtable[emailAddresses] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000256 RID: 598
			// (get) Token: 0x06000677 RID: 1655 RVA: 0x00017EEC File Offset: 0x000160EC
			public ShellProperty<string> EmailName
			{
				get
				{
					PropertyKey emailName = SystemProperties.System.Contact.EmailName;
					if (!this.hashtable.ContainsKey(emailName))
					{
						this.hashtable.Add(emailName, this.shellObjectParent.Properties.CreateTypedProperty<string>(emailName));
					}
					return this.hashtable[emailName] as ShellProperty<string>;
				}
			}

			// Token: 0x17000257 RID: 599
			// (get) Token: 0x06000678 RID: 1656 RVA: 0x00017F54 File Offset: 0x00016154
			public ShellProperty<string> FileAsName
			{
				get
				{
					PropertyKey fileAsName = SystemProperties.System.Contact.FileAsName;
					if (!this.hashtable.ContainsKey(fileAsName))
					{
						this.hashtable.Add(fileAsName, this.shellObjectParent.Properties.CreateTypedProperty<string>(fileAsName));
					}
					return this.hashtable[fileAsName] as ShellProperty<string>;
				}
			}

			// Token: 0x17000258 RID: 600
			// (get) Token: 0x06000679 RID: 1657 RVA: 0x00017FBC File Offset: 0x000161BC
			public ShellProperty<string> FirstName
			{
				get
				{
					PropertyKey firstName = SystemProperties.System.Contact.FirstName;
					if (!this.hashtable.ContainsKey(firstName))
					{
						this.hashtable.Add(firstName, this.shellObjectParent.Properties.CreateTypedProperty<string>(firstName));
					}
					return this.hashtable[firstName] as ShellProperty<string>;
				}
			}

			// Token: 0x17000259 RID: 601
			// (get) Token: 0x0600067A RID: 1658 RVA: 0x00018024 File Offset: 0x00016224
			public ShellProperty<string> FullName
			{
				get
				{
					PropertyKey fullName = SystemProperties.System.Contact.FullName;
					if (!this.hashtable.ContainsKey(fullName))
					{
						this.hashtable.Add(fullName, this.shellObjectParent.Properties.CreateTypedProperty<string>(fullName));
					}
					return this.hashtable[fullName] as ShellProperty<string>;
				}
			}

			// Token: 0x1700025A RID: 602
			// (get) Token: 0x0600067B RID: 1659 RVA: 0x0001808C File Offset: 0x0001628C
			public ShellProperty<string> Gender
			{
				get
				{
					PropertyKey gender = SystemProperties.System.Contact.Gender;
					if (!this.hashtable.ContainsKey(gender))
					{
						this.hashtable.Add(gender, this.shellObjectParent.Properties.CreateTypedProperty<string>(gender));
					}
					return this.hashtable[gender] as ShellProperty<string>;
				}
			}

			// Token: 0x1700025B RID: 603
			// (get) Token: 0x0600067C RID: 1660 RVA: 0x000180F4 File Offset: 0x000162F4
			public ShellProperty<ushort?> GenderValue
			{
				get
				{
					PropertyKey genderValue = SystemProperties.System.Contact.GenderValue;
					if (!this.hashtable.ContainsKey(genderValue))
					{
						this.hashtable.Add(genderValue, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(genderValue));
					}
					return this.hashtable[genderValue] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x1700025C RID: 604
			// (get) Token: 0x0600067D RID: 1661 RVA: 0x0001815C File Offset: 0x0001635C
			public ShellProperty<string[]> Hobbies
			{
				get
				{
					PropertyKey hobbies = SystemProperties.System.Contact.Hobbies;
					if (!this.hashtable.ContainsKey(hobbies))
					{
						this.hashtable.Add(hobbies, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(hobbies));
					}
					return this.hashtable[hobbies] as ShellProperty<string[]>;
				}
			}

			// Token: 0x1700025D RID: 605
			// (get) Token: 0x0600067E RID: 1662 RVA: 0x000181C4 File Offset: 0x000163C4
			public ShellProperty<string> HomeAddress
			{
				get
				{
					PropertyKey homeAddress = SystemProperties.System.Contact.HomeAddress;
					if (!this.hashtable.ContainsKey(homeAddress))
					{
						this.hashtable.Add(homeAddress, this.shellObjectParent.Properties.CreateTypedProperty<string>(homeAddress));
					}
					return this.hashtable[homeAddress] as ShellProperty<string>;
				}
			}

			// Token: 0x1700025E RID: 606
			// (get) Token: 0x0600067F RID: 1663 RVA: 0x0001822C File Offset: 0x0001642C
			public ShellProperty<string> HomeAddressCity
			{
				get
				{
					PropertyKey homeAddressCity = SystemProperties.System.Contact.HomeAddressCity;
					if (!this.hashtable.ContainsKey(homeAddressCity))
					{
						this.hashtable.Add(homeAddressCity, this.shellObjectParent.Properties.CreateTypedProperty<string>(homeAddressCity));
					}
					return this.hashtable[homeAddressCity] as ShellProperty<string>;
				}
			}

			// Token: 0x1700025F RID: 607
			// (get) Token: 0x06000680 RID: 1664 RVA: 0x00018294 File Offset: 0x00016494
			public ShellProperty<string> HomeAddressCountry
			{
				get
				{
					PropertyKey homeAddressCountry = SystemProperties.System.Contact.HomeAddressCountry;
					if (!this.hashtable.ContainsKey(homeAddressCountry))
					{
						this.hashtable.Add(homeAddressCountry, this.shellObjectParent.Properties.CreateTypedProperty<string>(homeAddressCountry));
					}
					return this.hashtable[homeAddressCountry] as ShellProperty<string>;
				}
			}

			// Token: 0x17000260 RID: 608
			// (get) Token: 0x06000681 RID: 1665 RVA: 0x000182FC File Offset: 0x000164FC
			public ShellProperty<string> HomeAddressPostalCode
			{
				get
				{
					PropertyKey homeAddressPostalCode = SystemProperties.System.Contact.HomeAddressPostalCode;
					if (!this.hashtable.ContainsKey(homeAddressPostalCode))
					{
						this.hashtable.Add(homeAddressPostalCode, this.shellObjectParent.Properties.CreateTypedProperty<string>(homeAddressPostalCode));
					}
					return this.hashtable[homeAddressPostalCode] as ShellProperty<string>;
				}
			}

			// Token: 0x17000261 RID: 609
			// (get) Token: 0x06000682 RID: 1666 RVA: 0x00018364 File Offset: 0x00016564
			public ShellProperty<string> HomeAddressPostOfficeBox
			{
				get
				{
					PropertyKey homeAddressPostOfficeBox = SystemProperties.System.Contact.HomeAddressPostOfficeBox;
					if (!this.hashtable.ContainsKey(homeAddressPostOfficeBox))
					{
						this.hashtable.Add(homeAddressPostOfficeBox, this.shellObjectParent.Properties.CreateTypedProperty<string>(homeAddressPostOfficeBox));
					}
					return this.hashtable[homeAddressPostOfficeBox] as ShellProperty<string>;
				}
			}

			// Token: 0x17000262 RID: 610
			// (get) Token: 0x06000683 RID: 1667 RVA: 0x000183CC File Offset: 0x000165CC
			public ShellProperty<string> HomeAddressState
			{
				get
				{
					PropertyKey homeAddressState = SystemProperties.System.Contact.HomeAddressState;
					if (!this.hashtable.ContainsKey(homeAddressState))
					{
						this.hashtable.Add(homeAddressState, this.shellObjectParent.Properties.CreateTypedProperty<string>(homeAddressState));
					}
					return this.hashtable[homeAddressState] as ShellProperty<string>;
				}
			}

			// Token: 0x17000263 RID: 611
			// (get) Token: 0x06000684 RID: 1668 RVA: 0x00018434 File Offset: 0x00016634
			public ShellProperty<string> HomeAddressStreet
			{
				get
				{
					PropertyKey homeAddressStreet = SystemProperties.System.Contact.HomeAddressStreet;
					if (!this.hashtable.ContainsKey(homeAddressStreet))
					{
						this.hashtable.Add(homeAddressStreet, this.shellObjectParent.Properties.CreateTypedProperty<string>(homeAddressStreet));
					}
					return this.hashtable[homeAddressStreet] as ShellProperty<string>;
				}
			}

			// Token: 0x17000264 RID: 612
			// (get) Token: 0x06000685 RID: 1669 RVA: 0x0001849C File Offset: 0x0001669C
			public ShellProperty<string> HomeFaxNumber
			{
				get
				{
					PropertyKey homeFaxNumber = SystemProperties.System.Contact.HomeFaxNumber;
					if (!this.hashtable.ContainsKey(homeFaxNumber))
					{
						this.hashtable.Add(homeFaxNumber, this.shellObjectParent.Properties.CreateTypedProperty<string>(homeFaxNumber));
					}
					return this.hashtable[homeFaxNumber] as ShellProperty<string>;
				}
			}

			// Token: 0x17000265 RID: 613
			// (get) Token: 0x06000686 RID: 1670 RVA: 0x00018504 File Offset: 0x00016704
			public ShellProperty<string> HomeTelephone
			{
				get
				{
					PropertyKey homeTelephone = SystemProperties.System.Contact.HomeTelephone;
					if (!this.hashtable.ContainsKey(homeTelephone))
					{
						this.hashtable.Add(homeTelephone, this.shellObjectParent.Properties.CreateTypedProperty<string>(homeTelephone));
					}
					return this.hashtable[homeTelephone] as ShellProperty<string>;
				}
			}

			// Token: 0x17000266 RID: 614
			// (get) Token: 0x06000687 RID: 1671 RVA: 0x0001856C File Offset: 0x0001676C
			public ShellProperty<string[]> IMAddress
			{
				get
				{
					PropertyKey imaddress = SystemProperties.System.Contact.IMAddress;
					if (!this.hashtable.ContainsKey(imaddress))
					{
						this.hashtable.Add(imaddress, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(imaddress));
					}
					return this.hashtable[imaddress] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000267 RID: 615
			// (get) Token: 0x06000688 RID: 1672 RVA: 0x000185D4 File Offset: 0x000167D4
			public ShellProperty<string> Initials
			{
				get
				{
					PropertyKey initials = SystemProperties.System.Contact.Initials;
					if (!this.hashtable.ContainsKey(initials))
					{
						this.hashtable.Add(initials, this.shellObjectParent.Properties.CreateTypedProperty<string>(initials));
					}
					return this.hashtable[initials] as ShellProperty<string>;
				}
			}

			// Token: 0x17000268 RID: 616
			// (get) Token: 0x06000689 RID: 1673 RVA: 0x0001863C File Offset: 0x0001683C
			public ShellProperty<string> JobTitle
			{
				get
				{
					PropertyKey jobTitle = SystemProperties.System.Contact.JobTitle;
					if (!this.hashtable.ContainsKey(jobTitle))
					{
						this.hashtable.Add(jobTitle, this.shellObjectParent.Properties.CreateTypedProperty<string>(jobTitle));
					}
					return this.hashtable[jobTitle] as ShellProperty<string>;
				}
			}

			// Token: 0x17000269 RID: 617
			// (get) Token: 0x0600068A RID: 1674 RVA: 0x000186A4 File Offset: 0x000168A4
			public ShellProperty<string> Label
			{
				get
				{
					PropertyKey label = SystemProperties.System.Contact.Label;
					if (!this.hashtable.ContainsKey(label))
					{
						this.hashtable.Add(label, this.shellObjectParent.Properties.CreateTypedProperty<string>(label));
					}
					return this.hashtable[label] as ShellProperty<string>;
				}
			}

			// Token: 0x1700026A RID: 618
			// (get) Token: 0x0600068B RID: 1675 RVA: 0x0001870C File Offset: 0x0001690C
			public ShellProperty<string> LastName
			{
				get
				{
					PropertyKey lastName = SystemProperties.System.Contact.LastName;
					if (!this.hashtable.ContainsKey(lastName))
					{
						this.hashtable.Add(lastName, this.shellObjectParent.Properties.CreateTypedProperty<string>(lastName));
					}
					return this.hashtable[lastName] as ShellProperty<string>;
				}
			}

			// Token: 0x1700026B RID: 619
			// (get) Token: 0x0600068C RID: 1676 RVA: 0x00018774 File Offset: 0x00016974
			public ShellProperty<string> MailingAddress
			{
				get
				{
					PropertyKey mailingAddress = SystemProperties.System.Contact.MailingAddress;
					if (!this.hashtable.ContainsKey(mailingAddress))
					{
						this.hashtable.Add(mailingAddress, this.shellObjectParent.Properties.CreateTypedProperty<string>(mailingAddress));
					}
					return this.hashtable[mailingAddress] as ShellProperty<string>;
				}
			}

			// Token: 0x1700026C RID: 620
			// (get) Token: 0x0600068D RID: 1677 RVA: 0x000187DC File Offset: 0x000169DC
			public ShellProperty<string> MiddleName
			{
				get
				{
					PropertyKey middleName = SystemProperties.System.Contact.MiddleName;
					if (!this.hashtable.ContainsKey(middleName))
					{
						this.hashtable.Add(middleName, this.shellObjectParent.Properties.CreateTypedProperty<string>(middleName));
					}
					return this.hashtable[middleName] as ShellProperty<string>;
				}
			}

			// Token: 0x1700026D RID: 621
			// (get) Token: 0x0600068E RID: 1678 RVA: 0x00018844 File Offset: 0x00016A44
			public ShellProperty<string> MobileTelephone
			{
				get
				{
					PropertyKey mobileTelephone = SystemProperties.System.Contact.MobileTelephone;
					if (!this.hashtable.ContainsKey(mobileTelephone))
					{
						this.hashtable.Add(mobileTelephone, this.shellObjectParent.Properties.CreateTypedProperty<string>(mobileTelephone));
					}
					return this.hashtable[mobileTelephone] as ShellProperty<string>;
				}
			}

			// Token: 0x1700026E RID: 622
			// (get) Token: 0x0600068F RID: 1679 RVA: 0x000188AC File Offset: 0x00016AAC
			public ShellProperty<string> Nickname
			{
				get
				{
					PropertyKey nickname = SystemProperties.System.Contact.Nickname;
					if (!this.hashtable.ContainsKey(nickname))
					{
						this.hashtable.Add(nickname, this.shellObjectParent.Properties.CreateTypedProperty<string>(nickname));
					}
					return this.hashtable[nickname] as ShellProperty<string>;
				}
			}

			// Token: 0x1700026F RID: 623
			// (get) Token: 0x06000690 RID: 1680 RVA: 0x00018914 File Offset: 0x00016B14
			public ShellProperty<string> OfficeLocation
			{
				get
				{
					PropertyKey officeLocation = SystemProperties.System.Contact.OfficeLocation;
					if (!this.hashtable.ContainsKey(officeLocation))
					{
						this.hashtable.Add(officeLocation, this.shellObjectParent.Properties.CreateTypedProperty<string>(officeLocation));
					}
					return this.hashtable[officeLocation] as ShellProperty<string>;
				}
			}

			// Token: 0x17000270 RID: 624
			// (get) Token: 0x06000691 RID: 1681 RVA: 0x0001897C File Offset: 0x00016B7C
			public ShellProperty<string> OtherAddress
			{
				get
				{
					PropertyKey otherAddress = SystemProperties.System.Contact.OtherAddress;
					if (!this.hashtable.ContainsKey(otherAddress))
					{
						this.hashtable.Add(otherAddress, this.shellObjectParent.Properties.CreateTypedProperty<string>(otherAddress));
					}
					return this.hashtable[otherAddress] as ShellProperty<string>;
				}
			}

			// Token: 0x17000271 RID: 625
			// (get) Token: 0x06000692 RID: 1682 RVA: 0x000189E4 File Offset: 0x00016BE4
			public ShellProperty<string> OtherAddressCity
			{
				get
				{
					PropertyKey otherAddressCity = SystemProperties.System.Contact.OtherAddressCity;
					if (!this.hashtable.ContainsKey(otherAddressCity))
					{
						this.hashtable.Add(otherAddressCity, this.shellObjectParent.Properties.CreateTypedProperty<string>(otherAddressCity));
					}
					return this.hashtable[otherAddressCity] as ShellProperty<string>;
				}
			}

			// Token: 0x17000272 RID: 626
			// (get) Token: 0x06000693 RID: 1683 RVA: 0x00018A4C File Offset: 0x00016C4C
			public ShellProperty<string> OtherAddressCountry
			{
				get
				{
					PropertyKey otherAddressCountry = SystemProperties.System.Contact.OtherAddressCountry;
					if (!this.hashtable.ContainsKey(otherAddressCountry))
					{
						this.hashtable.Add(otherAddressCountry, this.shellObjectParent.Properties.CreateTypedProperty<string>(otherAddressCountry));
					}
					return this.hashtable[otherAddressCountry] as ShellProperty<string>;
				}
			}

			// Token: 0x17000273 RID: 627
			// (get) Token: 0x06000694 RID: 1684 RVA: 0x00018AB4 File Offset: 0x00016CB4
			public ShellProperty<string> OtherAddressPostalCode
			{
				get
				{
					PropertyKey otherAddressPostalCode = SystemProperties.System.Contact.OtherAddressPostalCode;
					if (!this.hashtable.ContainsKey(otherAddressPostalCode))
					{
						this.hashtable.Add(otherAddressPostalCode, this.shellObjectParent.Properties.CreateTypedProperty<string>(otherAddressPostalCode));
					}
					return this.hashtable[otherAddressPostalCode] as ShellProperty<string>;
				}
			}

			// Token: 0x17000274 RID: 628
			// (get) Token: 0x06000695 RID: 1685 RVA: 0x00018B1C File Offset: 0x00016D1C
			public ShellProperty<string> OtherAddressPostOfficeBox
			{
				get
				{
					PropertyKey otherAddressPostOfficeBox = SystemProperties.System.Contact.OtherAddressPostOfficeBox;
					if (!this.hashtable.ContainsKey(otherAddressPostOfficeBox))
					{
						this.hashtable.Add(otherAddressPostOfficeBox, this.shellObjectParent.Properties.CreateTypedProperty<string>(otherAddressPostOfficeBox));
					}
					return this.hashtable[otherAddressPostOfficeBox] as ShellProperty<string>;
				}
			}

			// Token: 0x17000275 RID: 629
			// (get) Token: 0x06000696 RID: 1686 RVA: 0x00018B84 File Offset: 0x00016D84
			public ShellProperty<string> OtherAddressState
			{
				get
				{
					PropertyKey otherAddressState = SystemProperties.System.Contact.OtherAddressState;
					if (!this.hashtable.ContainsKey(otherAddressState))
					{
						this.hashtable.Add(otherAddressState, this.shellObjectParent.Properties.CreateTypedProperty<string>(otherAddressState));
					}
					return this.hashtable[otherAddressState] as ShellProperty<string>;
				}
			}

			// Token: 0x17000276 RID: 630
			// (get) Token: 0x06000697 RID: 1687 RVA: 0x00018BEC File Offset: 0x00016DEC
			public ShellProperty<string> OtherAddressStreet
			{
				get
				{
					PropertyKey otherAddressStreet = SystemProperties.System.Contact.OtherAddressStreet;
					if (!this.hashtable.ContainsKey(otherAddressStreet))
					{
						this.hashtable.Add(otherAddressStreet, this.shellObjectParent.Properties.CreateTypedProperty<string>(otherAddressStreet));
					}
					return this.hashtable[otherAddressStreet] as ShellProperty<string>;
				}
			}

			// Token: 0x17000277 RID: 631
			// (get) Token: 0x06000698 RID: 1688 RVA: 0x00018C54 File Offset: 0x00016E54
			public ShellProperty<string> PagerTelephone
			{
				get
				{
					PropertyKey pagerTelephone = SystemProperties.System.Contact.PagerTelephone;
					if (!this.hashtable.ContainsKey(pagerTelephone))
					{
						this.hashtable.Add(pagerTelephone, this.shellObjectParent.Properties.CreateTypedProperty<string>(pagerTelephone));
					}
					return this.hashtable[pagerTelephone] as ShellProperty<string>;
				}
			}

			// Token: 0x17000278 RID: 632
			// (get) Token: 0x06000699 RID: 1689 RVA: 0x00018CBC File Offset: 0x00016EBC
			public ShellProperty<string> PersonalTitle
			{
				get
				{
					PropertyKey personalTitle = SystemProperties.System.Contact.PersonalTitle;
					if (!this.hashtable.ContainsKey(personalTitle))
					{
						this.hashtable.Add(personalTitle, this.shellObjectParent.Properties.CreateTypedProperty<string>(personalTitle));
					}
					return this.hashtable[personalTitle] as ShellProperty<string>;
				}
			}

			// Token: 0x17000279 RID: 633
			// (get) Token: 0x0600069A RID: 1690 RVA: 0x00018D24 File Offset: 0x00016F24
			public ShellProperty<string> PrimaryAddressCity
			{
				get
				{
					PropertyKey primaryAddressCity = SystemProperties.System.Contact.PrimaryAddressCity;
					if (!this.hashtable.ContainsKey(primaryAddressCity))
					{
						this.hashtable.Add(primaryAddressCity, this.shellObjectParent.Properties.CreateTypedProperty<string>(primaryAddressCity));
					}
					return this.hashtable[primaryAddressCity] as ShellProperty<string>;
				}
			}

			// Token: 0x1700027A RID: 634
			// (get) Token: 0x0600069B RID: 1691 RVA: 0x00018D8C File Offset: 0x00016F8C
			public ShellProperty<string> PrimaryAddressCountry
			{
				get
				{
					PropertyKey primaryAddressCountry = SystemProperties.System.Contact.PrimaryAddressCountry;
					if (!this.hashtable.ContainsKey(primaryAddressCountry))
					{
						this.hashtable.Add(primaryAddressCountry, this.shellObjectParent.Properties.CreateTypedProperty<string>(primaryAddressCountry));
					}
					return this.hashtable[primaryAddressCountry] as ShellProperty<string>;
				}
			}

			// Token: 0x1700027B RID: 635
			// (get) Token: 0x0600069C RID: 1692 RVA: 0x00018DF4 File Offset: 0x00016FF4
			public ShellProperty<string> PrimaryAddressPostalCode
			{
				get
				{
					PropertyKey primaryAddressPostalCode = SystemProperties.System.Contact.PrimaryAddressPostalCode;
					if (!this.hashtable.ContainsKey(primaryAddressPostalCode))
					{
						this.hashtable.Add(primaryAddressPostalCode, this.shellObjectParent.Properties.CreateTypedProperty<string>(primaryAddressPostalCode));
					}
					return this.hashtable[primaryAddressPostalCode] as ShellProperty<string>;
				}
			}

			// Token: 0x1700027C RID: 636
			// (get) Token: 0x0600069D RID: 1693 RVA: 0x00018E5C File Offset: 0x0001705C
			public ShellProperty<string> PrimaryAddressPostOfficeBox
			{
				get
				{
					PropertyKey primaryAddressPostOfficeBox = SystemProperties.System.Contact.PrimaryAddressPostOfficeBox;
					if (!this.hashtable.ContainsKey(primaryAddressPostOfficeBox))
					{
						this.hashtable.Add(primaryAddressPostOfficeBox, this.shellObjectParent.Properties.CreateTypedProperty<string>(primaryAddressPostOfficeBox));
					}
					return this.hashtable[primaryAddressPostOfficeBox] as ShellProperty<string>;
				}
			}

			// Token: 0x1700027D RID: 637
			// (get) Token: 0x0600069E RID: 1694 RVA: 0x00018EC4 File Offset: 0x000170C4
			public ShellProperty<string> PrimaryAddressState
			{
				get
				{
					PropertyKey primaryAddressState = SystemProperties.System.Contact.PrimaryAddressState;
					if (!this.hashtable.ContainsKey(primaryAddressState))
					{
						this.hashtable.Add(primaryAddressState, this.shellObjectParent.Properties.CreateTypedProperty<string>(primaryAddressState));
					}
					return this.hashtable[primaryAddressState] as ShellProperty<string>;
				}
			}

			// Token: 0x1700027E RID: 638
			// (get) Token: 0x0600069F RID: 1695 RVA: 0x00018F2C File Offset: 0x0001712C
			public ShellProperty<string> PrimaryAddressStreet
			{
				get
				{
					PropertyKey primaryAddressStreet = SystemProperties.System.Contact.PrimaryAddressStreet;
					if (!this.hashtable.ContainsKey(primaryAddressStreet))
					{
						this.hashtable.Add(primaryAddressStreet, this.shellObjectParent.Properties.CreateTypedProperty<string>(primaryAddressStreet));
					}
					return this.hashtable[primaryAddressStreet] as ShellProperty<string>;
				}
			}

			// Token: 0x1700027F RID: 639
			// (get) Token: 0x060006A0 RID: 1696 RVA: 0x00018F94 File Offset: 0x00017194
			public ShellProperty<string> PrimaryEmailAddress
			{
				get
				{
					PropertyKey primaryEmailAddress = SystemProperties.System.Contact.PrimaryEmailAddress;
					if (!this.hashtable.ContainsKey(primaryEmailAddress))
					{
						this.hashtable.Add(primaryEmailAddress, this.shellObjectParent.Properties.CreateTypedProperty<string>(primaryEmailAddress));
					}
					return this.hashtable[primaryEmailAddress] as ShellProperty<string>;
				}
			}

			// Token: 0x17000280 RID: 640
			// (get) Token: 0x060006A1 RID: 1697 RVA: 0x00018FFC File Offset: 0x000171FC
			public ShellProperty<string> PrimaryTelephone
			{
				get
				{
					PropertyKey primaryTelephone = SystemProperties.System.Contact.PrimaryTelephone;
					if (!this.hashtable.ContainsKey(primaryTelephone))
					{
						this.hashtable.Add(primaryTelephone, this.shellObjectParent.Properties.CreateTypedProperty<string>(primaryTelephone));
					}
					return this.hashtable[primaryTelephone] as ShellProperty<string>;
				}
			}

			// Token: 0x17000281 RID: 641
			// (get) Token: 0x060006A2 RID: 1698 RVA: 0x00019064 File Offset: 0x00017264
			public ShellProperty<string> Profession
			{
				get
				{
					PropertyKey profession = SystemProperties.System.Contact.Profession;
					if (!this.hashtable.ContainsKey(profession))
					{
						this.hashtable.Add(profession, this.shellObjectParent.Properties.CreateTypedProperty<string>(profession));
					}
					return this.hashtable[profession] as ShellProperty<string>;
				}
			}

			// Token: 0x17000282 RID: 642
			// (get) Token: 0x060006A3 RID: 1699 RVA: 0x000190CC File Offset: 0x000172CC
			public ShellProperty<string> SpouseName
			{
				get
				{
					PropertyKey spouseName = SystemProperties.System.Contact.SpouseName;
					if (!this.hashtable.ContainsKey(spouseName))
					{
						this.hashtable.Add(spouseName, this.shellObjectParent.Properties.CreateTypedProperty<string>(spouseName));
					}
					return this.hashtable[spouseName] as ShellProperty<string>;
				}
			}

			// Token: 0x17000283 RID: 643
			// (get) Token: 0x060006A4 RID: 1700 RVA: 0x00019134 File Offset: 0x00017334
			public ShellProperty<string> Suffix
			{
				get
				{
					PropertyKey suffix = SystemProperties.System.Contact.Suffix;
					if (!this.hashtable.ContainsKey(suffix))
					{
						this.hashtable.Add(suffix, this.shellObjectParent.Properties.CreateTypedProperty<string>(suffix));
					}
					return this.hashtable[suffix] as ShellProperty<string>;
				}
			}

			// Token: 0x17000284 RID: 644
			// (get) Token: 0x060006A5 RID: 1701 RVA: 0x0001919C File Offset: 0x0001739C
			public ShellProperty<string> TelexNumber
			{
				get
				{
					PropertyKey telexNumber = SystemProperties.System.Contact.TelexNumber;
					if (!this.hashtable.ContainsKey(telexNumber))
					{
						this.hashtable.Add(telexNumber, this.shellObjectParent.Properties.CreateTypedProperty<string>(telexNumber));
					}
					return this.hashtable[telexNumber] as ShellProperty<string>;
				}
			}

			// Token: 0x17000285 RID: 645
			// (get) Token: 0x060006A6 RID: 1702 RVA: 0x00019204 File Offset: 0x00017404
			public ShellProperty<string> TTYTDDTelephone
			{
				get
				{
					PropertyKey ttytddtelephone = SystemProperties.System.Contact.TTYTDDTelephone;
					if (!this.hashtable.ContainsKey(ttytddtelephone))
					{
						this.hashtable.Add(ttytddtelephone, this.shellObjectParent.Properties.CreateTypedProperty<string>(ttytddtelephone));
					}
					return this.hashtable[ttytddtelephone] as ShellProperty<string>;
				}
			}

			// Token: 0x17000286 RID: 646
			// (get) Token: 0x060006A7 RID: 1703 RVA: 0x0001926C File Offset: 0x0001746C
			public ShellProperty<string> Webpage
			{
				get
				{
					PropertyKey webpage = SystemProperties.System.Contact.Webpage;
					if (!this.hashtable.ContainsKey(webpage))
					{
						this.hashtable.Add(webpage, this.shellObjectParent.Properties.CreateTypedProperty<string>(webpage));
					}
					return this.hashtable[webpage] as ShellProperty<string>;
				}
			}

			// Token: 0x17000287 RID: 647
			// (get) Token: 0x060006A8 RID: 1704 RVA: 0x000192D4 File Offset: 0x000174D4
			public ShellProperties.PropertyContactJA JA
			{
				get
				{
					if (this.internalPropertyContactJA == null)
					{
						this.internalPropertyContactJA = new ShellProperties.PropertyContactJA(this.shellObjectParent);
					}
					return this.internalPropertyContactJA;
				}
			}

			// Token: 0x04000365 RID: 869
			private ShellObject shellObjectParent;

			// Token: 0x04000366 RID: 870
			private Hashtable hashtable = new Hashtable();

			// Token: 0x04000367 RID: 871
			private ShellProperties.PropertyContactJA internalPropertyContactJA;
		}

		// Token: 0x020000B5 RID: 181
		public class PropertyContactJA : PropertyStoreItems
		{
			// Token: 0x060006A9 RID: 1705 RVA: 0x0001930F File Offset: 0x0001750F
			internal PropertyContactJA(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000288 RID: 648
			// (get) Token: 0x060006AA RID: 1706 RVA: 0x0001932C File Offset: 0x0001752C
			public ShellProperty<string> CompanyNamePhonetic
			{
				get
				{
					PropertyKey companyNamePhonetic = SystemProperties.System.Contact.JA.CompanyNamePhonetic;
					if (!this.hashtable.ContainsKey(companyNamePhonetic))
					{
						this.hashtable.Add(companyNamePhonetic, this.shellObjectParent.Properties.CreateTypedProperty<string>(companyNamePhonetic));
					}
					return this.hashtable[companyNamePhonetic] as ShellProperty<string>;
				}
			}

			// Token: 0x17000289 RID: 649
			// (get) Token: 0x060006AB RID: 1707 RVA: 0x00019394 File Offset: 0x00017594
			public ShellProperty<string> FirstNamePhonetic
			{
				get
				{
					PropertyKey firstNamePhonetic = SystemProperties.System.Contact.JA.FirstNamePhonetic;
					if (!this.hashtable.ContainsKey(firstNamePhonetic))
					{
						this.hashtable.Add(firstNamePhonetic, this.shellObjectParent.Properties.CreateTypedProperty<string>(firstNamePhonetic));
					}
					return this.hashtable[firstNamePhonetic] as ShellProperty<string>;
				}
			}

			// Token: 0x1700028A RID: 650
			// (get) Token: 0x060006AC RID: 1708 RVA: 0x000193FC File Offset: 0x000175FC
			public ShellProperty<string> LastNamePhonetic
			{
				get
				{
					PropertyKey lastNamePhonetic = SystemProperties.System.Contact.JA.LastNamePhonetic;
					if (!this.hashtable.ContainsKey(lastNamePhonetic))
					{
						this.hashtable.Add(lastNamePhonetic, this.shellObjectParent.Properties.CreateTypedProperty<string>(lastNamePhonetic));
					}
					return this.hashtable[lastNamePhonetic] as ShellProperty<string>;
				}
			}

			// Token: 0x04000368 RID: 872
			private ShellObject shellObjectParent;

			// Token: 0x04000369 RID: 873
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000B6 RID: 182
		public class PropertySystemDevice : PropertyStoreItems
		{
			// Token: 0x060006AD RID: 1709 RVA: 0x00019464 File Offset: 0x00017664
			internal PropertySystemDevice(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700028B RID: 651
			// (get) Token: 0x060006AE RID: 1710 RVA: 0x00019484 File Offset: 0x00017684
			public ShellProperty<string> PrinterUrl
			{
				get
				{
					PropertyKey printerUrl = SystemProperties.System.Device.PrinterUrl;
					if (!this.hashtable.ContainsKey(printerUrl))
					{
						this.hashtable.Add(printerUrl, this.shellObjectParent.Properties.CreateTypedProperty<string>(printerUrl));
					}
					return this.hashtable[printerUrl] as ShellProperty<string>;
				}
			}

			// Token: 0x0400036A RID: 874
			private ShellObject shellObjectParent;

			// Token: 0x0400036B RID: 875
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000B7 RID: 183
		public class PropertySystemDeviceInterface : PropertyStoreItems
		{
			// Token: 0x060006AF RID: 1711 RVA: 0x000194EC File Offset: 0x000176EC
			internal PropertySystemDeviceInterface(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700028C RID: 652
			// (get) Token: 0x060006B0 RID: 1712 RVA: 0x0001950C File Offset: 0x0001770C
			public ShellProperty<string> PrinterDriverDirectory
			{
				get
				{
					PropertyKey printerDriverDirectory = SystemProperties.System.DeviceInterface.PrinterDriverDirectory;
					if (!this.hashtable.ContainsKey(printerDriverDirectory))
					{
						this.hashtable.Add(printerDriverDirectory, this.shellObjectParent.Properties.CreateTypedProperty<string>(printerDriverDirectory));
					}
					return this.hashtable[printerDriverDirectory] as ShellProperty<string>;
				}
			}

			// Token: 0x1700028D RID: 653
			// (get) Token: 0x060006B1 RID: 1713 RVA: 0x00019574 File Offset: 0x00017774
			public ShellProperty<string> PrinterDriverName
			{
				get
				{
					PropertyKey printerDriverName = SystemProperties.System.DeviceInterface.PrinterDriverName;
					if (!this.hashtable.ContainsKey(printerDriverName))
					{
						this.hashtable.Add(printerDriverName, this.shellObjectParent.Properties.CreateTypedProperty<string>(printerDriverName));
					}
					return this.hashtable[printerDriverName] as ShellProperty<string>;
				}
			}

			// Token: 0x1700028E RID: 654
			// (get) Token: 0x060006B2 RID: 1714 RVA: 0x000195DC File Offset: 0x000177DC
			public ShellProperty<string> PrinterName
			{
				get
				{
					PropertyKey printerName = SystemProperties.System.DeviceInterface.PrinterName;
					if (!this.hashtable.ContainsKey(printerName))
					{
						this.hashtable.Add(printerName, this.shellObjectParent.Properties.CreateTypedProperty<string>(printerName));
					}
					return this.hashtable[printerName] as ShellProperty<string>;
				}
			}

			// Token: 0x1700028F RID: 655
			// (get) Token: 0x060006B3 RID: 1715 RVA: 0x00019644 File Offset: 0x00017844
			public ShellProperty<string> PrinterPortName
			{
				get
				{
					PropertyKey printerPortName = SystemProperties.System.DeviceInterface.PrinterPortName;
					if (!this.hashtable.ContainsKey(printerPortName))
					{
						this.hashtable.Add(printerPortName, this.shellObjectParent.Properties.CreateTypedProperty<string>(printerPortName));
					}
					return this.hashtable[printerPortName] as ShellProperty<string>;
				}
			}

			// Token: 0x0400036C RID: 876
			private ShellObject shellObjectParent;

			// Token: 0x0400036D RID: 877
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000B8 RID: 184
		public class PropertySystemDevices : PropertyStoreItems
		{
			// Token: 0x060006B4 RID: 1716 RVA: 0x000196AC File Offset: 0x000178AC
			internal PropertySystemDevices(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000290 RID: 656
			// (get) Token: 0x060006B5 RID: 1717 RVA: 0x000196CC File Offset: 0x000178CC
			public ShellProperty<byte?> BatteryLife
			{
				get
				{
					PropertyKey batteryLife = SystemProperties.System.Devices.BatteryLife;
					if (!this.hashtable.ContainsKey(batteryLife))
					{
						this.hashtable.Add(batteryLife, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(batteryLife));
					}
					return this.hashtable[batteryLife] as ShellProperty<byte?>;
				}
			}

			// Token: 0x17000291 RID: 657
			// (get) Token: 0x060006B6 RID: 1718 RVA: 0x00019734 File Offset: 0x00017934
			public ShellProperty<byte?> BatteryPlusCharging
			{
				get
				{
					PropertyKey batteryPlusCharging = SystemProperties.System.Devices.BatteryPlusCharging;
					if (!this.hashtable.ContainsKey(batteryPlusCharging))
					{
						this.hashtable.Add(batteryPlusCharging, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(batteryPlusCharging));
					}
					return this.hashtable[batteryPlusCharging] as ShellProperty<byte?>;
				}
			}

			// Token: 0x17000292 RID: 658
			// (get) Token: 0x060006B7 RID: 1719 RVA: 0x0001979C File Offset: 0x0001799C
			public ShellProperty<string> BatteryPlusChargingText
			{
				get
				{
					PropertyKey batteryPlusChargingText = SystemProperties.System.Devices.BatteryPlusChargingText;
					if (!this.hashtable.ContainsKey(batteryPlusChargingText))
					{
						this.hashtable.Add(batteryPlusChargingText, this.shellObjectParent.Properties.CreateTypedProperty<string>(batteryPlusChargingText));
					}
					return this.hashtable[batteryPlusChargingText] as ShellProperty<string>;
				}
			}

			// Token: 0x17000293 RID: 659
			// (get) Token: 0x060006B8 RID: 1720 RVA: 0x00019804 File Offset: 0x00017A04
			public ShellProperty<string[]> Category
			{
				get
				{
					PropertyKey category = SystemProperties.System.Devices.Category;
					if (!this.hashtable.ContainsKey(category))
					{
						this.hashtable.Add(category, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(category));
					}
					return this.hashtable[category] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000294 RID: 660
			// (get) Token: 0x060006B9 RID: 1721 RVA: 0x0001986C File Offset: 0x00017A6C
			public ShellProperty<string[]> CategoryGroup
			{
				get
				{
					PropertyKey categoryGroup = SystemProperties.System.Devices.CategoryGroup;
					if (!this.hashtable.ContainsKey(categoryGroup))
					{
						this.hashtable.Add(categoryGroup, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(categoryGroup));
					}
					return this.hashtable[categoryGroup] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000295 RID: 661
			// (get) Token: 0x060006BA RID: 1722 RVA: 0x000198D4 File Offset: 0x00017AD4
			public ShellProperty<string[]> CategoryPlural
			{
				get
				{
					PropertyKey categoryPlural = SystemProperties.System.Devices.CategoryPlural;
					if (!this.hashtable.ContainsKey(categoryPlural))
					{
						this.hashtable.Add(categoryPlural, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(categoryPlural));
					}
					return this.hashtable[categoryPlural] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000296 RID: 662
			// (get) Token: 0x060006BB RID: 1723 RVA: 0x0001993C File Offset: 0x00017B3C
			public ShellProperty<byte?> ChargingState
			{
				get
				{
					PropertyKey chargingState = SystemProperties.System.Devices.ChargingState;
					if (!this.hashtable.ContainsKey(chargingState))
					{
						this.hashtable.Add(chargingState, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(chargingState));
					}
					return this.hashtable[chargingState] as ShellProperty<byte?>;
				}
			}

			// Token: 0x17000297 RID: 663
			// (get) Token: 0x060006BC RID: 1724 RVA: 0x000199A4 File Offset: 0x00017BA4
			public ShellProperty<bool?> Connected
			{
				get
				{
					PropertyKey connected = SystemProperties.System.Devices.Connected;
					if (!this.hashtable.ContainsKey(connected))
					{
						this.hashtable.Add(connected, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(connected));
					}
					return this.hashtable[connected] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000298 RID: 664
			// (get) Token: 0x060006BD RID: 1725 RVA: 0x00019A0C File Offset: 0x00017C0C
			public ShellProperty<IntPtr?> ContainerId
			{
				get
				{
					PropertyKey containerId = SystemProperties.System.Devices.ContainerId;
					if (!this.hashtable.ContainsKey(containerId))
					{
						this.hashtable.Add(containerId, this.shellObjectParent.Properties.CreateTypedProperty<IntPtr?>(containerId));
					}
					return this.hashtable[containerId] as ShellProperty<IntPtr?>;
				}
			}

			// Token: 0x17000299 RID: 665
			// (get) Token: 0x060006BE RID: 1726 RVA: 0x00019A74 File Offset: 0x00017C74
			public ShellProperty<string> DefaultTooltip
			{
				get
				{
					PropertyKey defaultTooltip = SystemProperties.System.Devices.DefaultTooltip;
					if (!this.hashtable.ContainsKey(defaultTooltip))
					{
						this.hashtable.Add(defaultTooltip, this.shellObjectParent.Properties.CreateTypedProperty<string>(defaultTooltip));
					}
					return this.hashtable[defaultTooltip] as ShellProperty<string>;
				}
			}

			// Token: 0x1700029A RID: 666
			// (get) Token: 0x060006BF RID: 1727 RVA: 0x00019ADC File Offset: 0x00017CDC
			public ShellProperty<string> DeviceDescription1
			{
				get
				{
					PropertyKey deviceDescription = SystemProperties.System.Devices.DeviceDescription1;
					if (!this.hashtable.ContainsKey(deviceDescription))
					{
						this.hashtable.Add(deviceDescription, this.shellObjectParent.Properties.CreateTypedProperty<string>(deviceDescription));
					}
					return this.hashtable[deviceDescription] as ShellProperty<string>;
				}
			}

			// Token: 0x1700029B RID: 667
			// (get) Token: 0x060006C0 RID: 1728 RVA: 0x00019B44 File Offset: 0x00017D44
			public ShellProperty<string> DeviceDescription2
			{
				get
				{
					PropertyKey deviceDescription = SystemProperties.System.Devices.DeviceDescription2;
					if (!this.hashtable.ContainsKey(deviceDescription))
					{
						this.hashtable.Add(deviceDescription, this.shellObjectParent.Properties.CreateTypedProperty<string>(deviceDescription));
					}
					return this.hashtable[deviceDescription] as ShellProperty<string>;
				}
			}

			// Token: 0x1700029C RID: 668
			// (get) Token: 0x060006C1 RID: 1729 RVA: 0x00019BAC File Offset: 0x00017DAC
			public ShellProperty<string[]> DiscoveryMethod
			{
				get
				{
					PropertyKey discoveryMethod = SystemProperties.System.Devices.DiscoveryMethod;
					if (!this.hashtable.ContainsKey(discoveryMethod))
					{
						this.hashtable.Add(discoveryMethod, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(discoveryMethod));
					}
					return this.hashtable[discoveryMethod] as ShellProperty<string[]>;
				}
			}

			// Token: 0x1700029D RID: 669
			// (get) Token: 0x060006C2 RID: 1730 RVA: 0x00019C14 File Offset: 0x00017E14
			public ShellProperty<string> FriendlyName
			{
				get
				{
					PropertyKey friendlyName = SystemProperties.System.Devices.FriendlyName;
					if (!this.hashtable.ContainsKey(friendlyName))
					{
						this.hashtable.Add(friendlyName, this.shellObjectParent.Properties.CreateTypedProperty<string>(friendlyName));
					}
					return this.hashtable[friendlyName] as ShellProperty<string>;
				}
			}

			// Token: 0x1700029E RID: 670
			// (get) Token: 0x060006C3 RID: 1731 RVA: 0x00019C7C File Offset: 0x00017E7C
			public ShellProperty<string[]> FunctionPaths
			{
				get
				{
					PropertyKey functionPaths = SystemProperties.System.Devices.FunctionPaths;
					if (!this.hashtable.ContainsKey(functionPaths))
					{
						this.hashtable.Add(functionPaths, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(functionPaths));
					}
					return this.hashtable[functionPaths] as ShellProperty<string[]>;
				}
			}

			// Token: 0x1700029F RID: 671
			// (get) Token: 0x060006C4 RID: 1732 RVA: 0x00019CE4 File Offset: 0x00017EE4
			public ShellProperty<string[]> InterfacePaths
			{
				get
				{
					PropertyKey interfacePaths = SystemProperties.System.Devices.InterfacePaths;
					if (!this.hashtable.ContainsKey(interfacePaths))
					{
						this.hashtable.Add(interfacePaths, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(interfacePaths));
					}
					return this.hashtable[interfacePaths] as ShellProperty<string[]>;
				}
			}

			// Token: 0x170002A0 RID: 672
			// (get) Token: 0x060006C5 RID: 1733 RVA: 0x00019D4C File Offset: 0x00017F4C
			public ShellProperty<bool?> IsDefault
			{
				get
				{
					PropertyKey isDefault = SystemProperties.System.Devices.IsDefault;
					if (!this.hashtable.ContainsKey(isDefault))
					{
						this.hashtable.Add(isDefault, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isDefault));
					}
					return this.hashtable[isDefault] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170002A1 RID: 673
			// (get) Token: 0x060006C6 RID: 1734 RVA: 0x00019DB4 File Offset: 0x00017FB4
			public ShellProperty<bool?> IsNetworkConnected
			{
				get
				{
					PropertyKey isNetworkConnected = SystemProperties.System.Devices.IsNetworkConnected;
					if (!this.hashtable.ContainsKey(isNetworkConnected))
					{
						this.hashtable.Add(isNetworkConnected, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isNetworkConnected));
					}
					return this.hashtable[isNetworkConnected] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170002A2 RID: 674
			// (get) Token: 0x060006C7 RID: 1735 RVA: 0x00019E1C File Offset: 0x0001801C
			public ShellProperty<bool?> IsShared
			{
				get
				{
					PropertyKey isShared = SystemProperties.System.Devices.IsShared;
					if (!this.hashtable.ContainsKey(isShared))
					{
						this.hashtable.Add(isShared, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isShared));
					}
					return this.hashtable[isShared] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170002A3 RID: 675
			// (get) Token: 0x060006C8 RID: 1736 RVA: 0x00019E84 File Offset: 0x00018084
			public ShellProperty<bool?> IsSoftwareInstalling
			{
				get
				{
					PropertyKey isSoftwareInstalling = SystemProperties.System.Devices.IsSoftwareInstalling;
					if (!this.hashtable.ContainsKey(isSoftwareInstalling))
					{
						this.hashtable.Add(isSoftwareInstalling, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isSoftwareInstalling));
					}
					return this.hashtable[isSoftwareInstalling] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170002A4 RID: 676
			// (get) Token: 0x060006C9 RID: 1737 RVA: 0x00019EEC File Offset: 0x000180EC
			public ShellProperty<bool?> LaunchDeviceStageFromExplorer
			{
				get
				{
					PropertyKey launchDeviceStageFromExplorer = SystemProperties.System.Devices.LaunchDeviceStageFromExplorer;
					if (!this.hashtable.ContainsKey(launchDeviceStageFromExplorer))
					{
						this.hashtable.Add(launchDeviceStageFromExplorer, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(launchDeviceStageFromExplorer));
					}
					return this.hashtable[launchDeviceStageFromExplorer] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170002A5 RID: 677
			// (get) Token: 0x060006CA RID: 1738 RVA: 0x00019F54 File Offset: 0x00018154
			public ShellProperty<bool?> LocalMachine
			{
				get
				{
					PropertyKey localMachine = SystemProperties.System.Devices.LocalMachine;
					if (!this.hashtable.ContainsKey(localMachine))
					{
						this.hashtable.Add(localMachine, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(localMachine));
					}
					return this.hashtable[localMachine] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170002A6 RID: 678
			// (get) Token: 0x060006CB RID: 1739 RVA: 0x00019FBC File Offset: 0x000181BC
			public ShellProperty<string> Manufacturer
			{
				get
				{
					PropertyKey manufacturer = SystemProperties.System.Devices.Manufacturer;
					if (!this.hashtable.ContainsKey(manufacturer))
					{
						this.hashtable.Add(manufacturer, this.shellObjectParent.Properties.CreateTypedProperty<string>(manufacturer));
					}
					return this.hashtable[manufacturer] as ShellProperty<string>;
				}
			}

			// Token: 0x170002A7 RID: 679
			// (get) Token: 0x060006CC RID: 1740 RVA: 0x0001A024 File Offset: 0x00018224
			public ShellProperty<byte?> MissedCalls
			{
				get
				{
					PropertyKey missedCalls = SystemProperties.System.Devices.MissedCalls;
					if (!this.hashtable.ContainsKey(missedCalls))
					{
						this.hashtable.Add(missedCalls, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(missedCalls));
					}
					return this.hashtable[missedCalls] as ShellProperty<byte?>;
				}
			}

			// Token: 0x170002A8 RID: 680
			// (get) Token: 0x060006CD RID: 1741 RVA: 0x0001A08C File Offset: 0x0001828C
			public ShellProperty<string> ModelName
			{
				get
				{
					PropertyKey modelName = SystemProperties.System.Devices.ModelName;
					if (!this.hashtable.ContainsKey(modelName))
					{
						this.hashtable.Add(modelName, this.shellObjectParent.Properties.CreateTypedProperty<string>(modelName));
					}
					return this.hashtable[modelName] as ShellProperty<string>;
				}
			}

			// Token: 0x170002A9 RID: 681
			// (get) Token: 0x060006CE RID: 1742 RVA: 0x0001A0F4 File Offset: 0x000182F4
			public ShellProperty<string> ModelNumber
			{
				get
				{
					PropertyKey modelNumber = SystemProperties.System.Devices.ModelNumber;
					if (!this.hashtable.ContainsKey(modelNumber))
					{
						this.hashtable.Add(modelNumber, this.shellObjectParent.Properties.CreateTypedProperty<string>(modelNumber));
					}
					return this.hashtable[modelNumber] as ShellProperty<string>;
				}
			}

			// Token: 0x170002AA RID: 682
			// (get) Token: 0x060006CF RID: 1743 RVA: 0x0001A15C File Offset: 0x0001835C
			public ShellProperty<string> NetworkedTooltip
			{
				get
				{
					PropertyKey networkedTooltip = SystemProperties.System.Devices.NetworkedTooltip;
					if (!this.hashtable.ContainsKey(networkedTooltip))
					{
						this.hashtable.Add(networkedTooltip, this.shellObjectParent.Properties.CreateTypedProperty<string>(networkedTooltip));
					}
					return this.hashtable[networkedTooltip] as ShellProperty<string>;
				}
			}

			// Token: 0x170002AB RID: 683
			// (get) Token: 0x060006D0 RID: 1744 RVA: 0x0001A1C4 File Offset: 0x000183C4
			public ShellProperty<string> NetworkName
			{
				get
				{
					PropertyKey networkName = SystemProperties.System.Devices.NetworkName;
					if (!this.hashtable.ContainsKey(networkName))
					{
						this.hashtable.Add(networkName, this.shellObjectParent.Properties.CreateTypedProperty<string>(networkName));
					}
					return this.hashtable[networkName] as ShellProperty<string>;
				}
			}

			// Token: 0x170002AC RID: 684
			// (get) Token: 0x060006D1 RID: 1745 RVA: 0x0001A22C File Offset: 0x0001842C
			public ShellProperty<string> NetworkType
			{
				get
				{
					PropertyKey networkType = SystemProperties.System.Devices.NetworkType;
					if (!this.hashtable.ContainsKey(networkType))
					{
						this.hashtable.Add(networkType, this.shellObjectParent.Properties.CreateTypedProperty<string>(networkType));
					}
					return this.hashtable[networkType] as ShellProperty<string>;
				}
			}

			// Token: 0x170002AD RID: 685
			// (get) Token: 0x060006D2 RID: 1746 RVA: 0x0001A294 File Offset: 0x00018494
			public ShellProperty<ushort?> NewPictures
			{
				get
				{
					PropertyKey newPictures = SystemProperties.System.Devices.NewPictures;
					if (!this.hashtable.ContainsKey(newPictures))
					{
						this.hashtable.Add(newPictures, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(newPictures));
					}
					return this.hashtable[newPictures] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x170002AE RID: 686
			// (get) Token: 0x060006D3 RID: 1747 RVA: 0x0001A2FC File Offset: 0x000184FC
			public ShellProperty<string> Notification
			{
				get
				{
					PropertyKey notification = SystemProperties.System.Devices.Notification;
					if (!this.hashtable.ContainsKey(notification))
					{
						this.hashtable.Add(notification, this.shellObjectParent.Properties.CreateTypedProperty<string>(notification));
					}
					return this.hashtable[notification] as ShellProperty<string>;
				}
			}

			// Token: 0x170002AF RID: 687
			// (get) Token: 0x060006D4 RID: 1748 RVA: 0x0001A364 File Offset: 0x00018564
			public ShellProperty<IntPtr?> NotificationStore
			{
				get
				{
					PropertyKey notificationStore = SystemProperties.System.Devices.NotificationStore;
					if (!this.hashtable.ContainsKey(notificationStore))
					{
						this.hashtable.Add(notificationStore, this.shellObjectParent.Properties.CreateTypedProperty<IntPtr?>(notificationStore));
					}
					return this.hashtable[notificationStore] as ShellProperty<IntPtr?>;
				}
			}

			// Token: 0x170002B0 RID: 688
			// (get) Token: 0x060006D5 RID: 1749 RVA: 0x0001A3CC File Offset: 0x000185CC
			public ShellProperty<bool?> NotWorkingProperly
			{
				get
				{
					PropertyKey notWorkingProperly = SystemProperties.System.Devices.NotWorkingProperly;
					if (!this.hashtable.ContainsKey(notWorkingProperly))
					{
						this.hashtable.Add(notWorkingProperly, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(notWorkingProperly));
					}
					return this.hashtable[notWorkingProperly] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170002B1 RID: 689
			// (get) Token: 0x060006D6 RID: 1750 RVA: 0x0001A434 File Offset: 0x00018634
			public ShellProperty<bool?> Paired
			{
				get
				{
					PropertyKey paired = SystemProperties.System.Devices.Paired;
					if (!this.hashtable.ContainsKey(paired))
					{
						this.hashtable.Add(paired, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(paired));
					}
					return this.hashtable[paired] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170002B2 RID: 690
			// (get) Token: 0x060006D7 RID: 1751 RVA: 0x0001A49C File Offset: 0x0001869C
			public ShellProperty<string> PrimaryCategory
			{
				get
				{
					PropertyKey primaryCategory = SystemProperties.System.Devices.PrimaryCategory;
					if (!this.hashtable.ContainsKey(primaryCategory))
					{
						this.hashtable.Add(primaryCategory, this.shellObjectParent.Properties.CreateTypedProperty<string>(primaryCategory));
					}
					return this.hashtable[primaryCategory] as ShellProperty<string>;
				}
			}

			// Token: 0x170002B3 RID: 691
			// (get) Token: 0x060006D8 RID: 1752 RVA: 0x0001A504 File Offset: 0x00018704
			public ShellProperty<byte?> Roaming
			{
				get
				{
					PropertyKey roaming = SystemProperties.System.Devices.Roaming;
					if (!this.hashtable.ContainsKey(roaming))
					{
						this.hashtable.Add(roaming, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(roaming));
					}
					return this.hashtable[roaming] as ShellProperty<byte?>;
				}
			}

			// Token: 0x170002B4 RID: 692
			// (get) Token: 0x060006D9 RID: 1753 RVA: 0x0001A56C File Offset: 0x0001876C
			public ShellProperty<bool?> SafeRemovalRequired
			{
				get
				{
					PropertyKey safeRemovalRequired = SystemProperties.System.Devices.SafeRemovalRequired;
					if (!this.hashtable.ContainsKey(safeRemovalRequired))
					{
						this.hashtable.Add(safeRemovalRequired, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(safeRemovalRequired));
					}
					return this.hashtable[safeRemovalRequired] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170002B5 RID: 693
			// (get) Token: 0x060006DA RID: 1754 RVA: 0x0001A5D4 File Offset: 0x000187D4
			public ShellProperty<string> SharedTooltip
			{
				get
				{
					PropertyKey sharedTooltip = SystemProperties.System.Devices.SharedTooltip;
					if (!this.hashtable.ContainsKey(sharedTooltip))
					{
						this.hashtable.Add(sharedTooltip, this.shellObjectParent.Properties.CreateTypedProperty<string>(sharedTooltip));
					}
					return this.hashtable[sharedTooltip] as ShellProperty<string>;
				}
			}

			// Token: 0x170002B6 RID: 694
			// (get) Token: 0x060006DB RID: 1755 RVA: 0x0001A63C File Offset: 0x0001883C
			public ShellProperty<byte?> SignalStrength
			{
				get
				{
					PropertyKey signalStrength = SystemProperties.System.Devices.SignalStrength;
					if (!this.hashtable.ContainsKey(signalStrength))
					{
						this.hashtable.Add(signalStrength, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(signalStrength));
					}
					return this.hashtable[signalStrength] as ShellProperty<byte?>;
				}
			}

			// Token: 0x170002B7 RID: 695
			// (get) Token: 0x060006DC RID: 1756 RVA: 0x0001A6A4 File Offset: 0x000188A4
			public ShellProperty<string> Status1
			{
				get
				{
					PropertyKey status = SystemProperties.System.Devices.Status1;
					if (!this.hashtable.ContainsKey(status))
					{
						this.hashtable.Add(status, this.shellObjectParent.Properties.CreateTypedProperty<string>(status));
					}
					return this.hashtable[status] as ShellProperty<string>;
				}
			}

			// Token: 0x170002B8 RID: 696
			// (get) Token: 0x060006DD RID: 1757 RVA: 0x0001A70C File Offset: 0x0001890C
			public ShellProperty<string> Status2
			{
				get
				{
					PropertyKey status = SystemProperties.System.Devices.Status2;
					if (!this.hashtable.ContainsKey(status))
					{
						this.hashtable.Add(status, this.shellObjectParent.Properties.CreateTypedProperty<string>(status));
					}
					return this.hashtable[status] as ShellProperty<string>;
				}
			}

			// Token: 0x170002B9 RID: 697
			// (get) Token: 0x060006DE RID: 1758 RVA: 0x0001A774 File Offset: 0x00018974
			public ShellProperty<ulong?> StorageCapacity
			{
				get
				{
					PropertyKey storageCapacity = SystemProperties.System.Devices.StorageCapacity;
					if (!this.hashtable.ContainsKey(storageCapacity))
					{
						this.hashtable.Add(storageCapacity, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(storageCapacity));
					}
					return this.hashtable[storageCapacity] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x170002BA RID: 698
			// (get) Token: 0x060006DF RID: 1759 RVA: 0x0001A7DC File Offset: 0x000189DC
			public ShellProperty<ulong?> StorageFreeSpace
			{
				get
				{
					PropertyKey storageFreeSpace = SystemProperties.System.Devices.StorageFreeSpace;
					if (!this.hashtable.ContainsKey(storageFreeSpace))
					{
						this.hashtable.Add(storageFreeSpace, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(storageFreeSpace));
					}
					return this.hashtable[storageFreeSpace] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x170002BB RID: 699
			// (get) Token: 0x060006E0 RID: 1760 RVA: 0x0001A844 File Offset: 0x00018A44
			public ShellProperty<uint?> StorageFreeSpacePercent
			{
				get
				{
					PropertyKey storageFreeSpacePercent = SystemProperties.System.Devices.StorageFreeSpacePercent;
					if (!this.hashtable.ContainsKey(storageFreeSpacePercent))
					{
						this.hashtable.Add(storageFreeSpacePercent, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(storageFreeSpacePercent));
					}
					return this.hashtable[storageFreeSpacePercent] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170002BC RID: 700
			// (get) Token: 0x060006E1 RID: 1761 RVA: 0x0001A8AC File Offset: 0x00018AAC
			public ShellProperty<byte?> TextMessages
			{
				get
				{
					PropertyKey textMessages = SystemProperties.System.Devices.TextMessages;
					if (!this.hashtable.ContainsKey(textMessages))
					{
						this.hashtable.Add(textMessages, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(textMessages));
					}
					return this.hashtable[textMessages] as ShellProperty<byte?>;
				}
			}

			// Token: 0x170002BD RID: 701
			// (get) Token: 0x060006E2 RID: 1762 RVA: 0x0001A914 File Offset: 0x00018B14
			public ShellProperty<byte?> Voicemail
			{
				get
				{
					PropertyKey voicemail = SystemProperties.System.Devices.Voicemail;
					if (!this.hashtable.ContainsKey(voicemail))
					{
						this.hashtable.Add(voicemail, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(voicemail));
					}
					return this.hashtable[voicemail] as ShellProperty<byte?>;
				}
			}

			// Token: 0x170002BE RID: 702
			// (get) Token: 0x060006E3 RID: 1763 RVA: 0x0001A97C File Offset: 0x00018B7C
			public ShellProperties.PropertyDevicesNotifications Notifications
			{
				get
				{
					if (this.internalPropertyDevicesNotifications == null)
					{
						this.internalPropertyDevicesNotifications = new ShellProperties.PropertyDevicesNotifications(this.shellObjectParent);
					}
					return this.internalPropertyDevicesNotifications;
				}
			}

			// Token: 0x0400036E RID: 878
			private ShellObject shellObjectParent;

			// Token: 0x0400036F RID: 879
			private Hashtable hashtable = new Hashtable();

			// Token: 0x04000370 RID: 880
			private ShellProperties.PropertyDevicesNotifications internalPropertyDevicesNotifications;
		}

		// Token: 0x020000B9 RID: 185
		public class PropertyDevicesNotifications : PropertyStoreItems
		{
			// Token: 0x060006E4 RID: 1764 RVA: 0x0001A9B7 File Offset: 0x00018BB7
			internal PropertyDevicesNotifications(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x170002BF RID: 703
			// (get) Token: 0x060006E5 RID: 1765 RVA: 0x0001A9D4 File Offset: 0x00018BD4
			public ShellProperty<byte?> LowBattery
			{
				get
				{
					PropertyKey lowBattery = SystemProperties.System.Devices.Notifications.LowBattery;
					if (!this.hashtable.ContainsKey(lowBattery))
					{
						this.hashtable.Add(lowBattery, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(lowBattery));
					}
					return this.hashtable[lowBattery] as ShellProperty<byte?>;
				}
			}

			// Token: 0x170002C0 RID: 704
			// (get) Token: 0x060006E6 RID: 1766 RVA: 0x0001AA3C File Offset: 0x00018C3C
			public ShellProperty<byte?> MissedCall
			{
				get
				{
					PropertyKey missedCall = SystemProperties.System.Devices.Notifications.MissedCall;
					if (!this.hashtable.ContainsKey(missedCall))
					{
						this.hashtable.Add(missedCall, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(missedCall));
					}
					return this.hashtable[missedCall] as ShellProperty<byte?>;
				}
			}

			// Token: 0x170002C1 RID: 705
			// (get) Token: 0x060006E7 RID: 1767 RVA: 0x0001AAA4 File Offset: 0x00018CA4
			public ShellProperty<byte?> NewMessage
			{
				get
				{
					PropertyKey newMessage = SystemProperties.System.Devices.Notifications.NewMessage;
					if (!this.hashtable.ContainsKey(newMessage))
					{
						this.hashtable.Add(newMessage, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(newMessage));
					}
					return this.hashtable[newMessage] as ShellProperty<byte?>;
				}
			}

			// Token: 0x170002C2 RID: 706
			// (get) Token: 0x060006E8 RID: 1768 RVA: 0x0001AB0C File Offset: 0x00018D0C
			public ShellProperty<byte?> NewVoicemail
			{
				get
				{
					PropertyKey newVoicemail = SystemProperties.System.Devices.Notifications.NewVoicemail;
					if (!this.hashtable.ContainsKey(newVoicemail))
					{
						this.hashtable.Add(newVoicemail, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(newVoicemail));
					}
					return this.hashtable[newVoicemail] as ShellProperty<byte?>;
				}
			}

			// Token: 0x170002C3 RID: 707
			// (get) Token: 0x060006E9 RID: 1769 RVA: 0x0001AB74 File Offset: 0x00018D74
			public ShellProperty<ulong?> StorageFull
			{
				get
				{
					PropertyKey storageFull = SystemProperties.System.Devices.Notifications.StorageFull;
					if (!this.hashtable.ContainsKey(storageFull))
					{
						this.hashtable.Add(storageFull, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(storageFull));
					}
					return this.hashtable[storageFull] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x170002C4 RID: 708
			// (get) Token: 0x060006EA RID: 1770 RVA: 0x0001ABDC File Offset: 0x00018DDC
			public ShellProperty<ulong?> StorageFullLinkText
			{
				get
				{
					PropertyKey storageFullLinkText = SystemProperties.System.Devices.Notifications.StorageFullLinkText;
					if (!this.hashtable.ContainsKey(storageFullLinkText))
					{
						this.hashtable.Add(storageFullLinkText, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(storageFullLinkText));
					}
					return this.hashtable[storageFullLinkText] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x04000371 RID: 881
			private ShellObject shellObjectParent;

			// Token: 0x04000372 RID: 882
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000BA RID: 186
		public class PropertySystemDocument : PropertyStoreItems
		{
			// Token: 0x060006EB RID: 1771 RVA: 0x0001AC44 File Offset: 0x00018E44
			internal PropertySystemDocument(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x170002C5 RID: 709
			// (get) Token: 0x060006EC RID: 1772 RVA: 0x0001AC64 File Offset: 0x00018E64
			public ShellProperty<int?> ByteCount
			{
				get
				{
					PropertyKey byteCount = SystemProperties.System.Document.ByteCount;
					if (!this.hashtable.ContainsKey(byteCount))
					{
						this.hashtable.Add(byteCount, this.shellObjectParent.Properties.CreateTypedProperty<int?>(byteCount));
					}
					return this.hashtable[byteCount] as ShellProperty<int?>;
				}
			}

			// Token: 0x170002C6 RID: 710
			// (get) Token: 0x060006ED RID: 1773 RVA: 0x0001ACCC File Offset: 0x00018ECC
			public ShellProperty<int?> CharacterCount
			{
				get
				{
					PropertyKey characterCount = SystemProperties.System.Document.CharacterCount;
					if (!this.hashtable.ContainsKey(characterCount))
					{
						this.hashtable.Add(characterCount, this.shellObjectParent.Properties.CreateTypedProperty<int?>(characterCount));
					}
					return this.hashtable[characterCount] as ShellProperty<int?>;
				}
			}

			// Token: 0x170002C7 RID: 711
			// (get) Token: 0x060006EE RID: 1774 RVA: 0x0001AD34 File Offset: 0x00018F34
			public ShellProperty<string> ClientID
			{
				get
				{
					PropertyKey clientID = SystemProperties.System.Document.ClientID;
					if (!this.hashtable.ContainsKey(clientID))
					{
						this.hashtable.Add(clientID, this.shellObjectParent.Properties.CreateTypedProperty<string>(clientID));
					}
					return this.hashtable[clientID] as ShellProperty<string>;
				}
			}

			// Token: 0x170002C8 RID: 712
			// (get) Token: 0x060006EF RID: 1775 RVA: 0x0001AD9C File Offset: 0x00018F9C
			public ShellProperty<string[]> Contributor
			{
				get
				{
					PropertyKey contributor = SystemProperties.System.Document.Contributor;
					if (!this.hashtable.ContainsKey(contributor))
					{
						this.hashtable.Add(contributor, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(contributor));
					}
					return this.hashtable[contributor] as ShellProperty<string[]>;
				}
			}

			// Token: 0x170002C9 RID: 713
			// (get) Token: 0x060006F0 RID: 1776 RVA: 0x0001AE04 File Offset: 0x00019004
			public ShellProperty<DateTime?> DateCreated
			{
				get
				{
					PropertyKey dateCreated = SystemProperties.System.Document.DateCreated;
					if (!this.hashtable.ContainsKey(dateCreated))
					{
						this.hashtable.Add(dateCreated, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateCreated));
					}
					return this.hashtable[dateCreated] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x170002CA RID: 714
			// (get) Token: 0x060006F1 RID: 1777 RVA: 0x0001AE6C File Offset: 0x0001906C
			public ShellProperty<DateTime?> DatePrinted
			{
				get
				{
					PropertyKey datePrinted = SystemProperties.System.Document.DatePrinted;
					if (!this.hashtable.ContainsKey(datePrinted))
					{
						this.hashtable.Add(datePrinted, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(datePrinted));
					}
					return this.hashtable[datePrinted] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x170002CB RID: 715
			// (get) Token: 0x060006F2 RID: 1778 RVA: 0x0001AED4 File Offset: 0x000190D4
			public ShellProperty<DateTime?> DateSaved
			{
				get
				{
					PropertyKey dateSaved = SystemProperties.System.Document.DateSaved;
					if (!this.hashtable.ContainsKey(dateSaved))
					{
						this.hashtable.Add(dateSaved, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateSaved));
					}
					return this.hashtable[dateSaved] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x170002CC RID: 716
			// (get) Token: 0x060006F3 RID: 1779 RVA: 0x0001AF3C File Offset: 0x0001913C
			public ShellProperty<string> Division
			{
				get
				{
					PropertyKey division = SystemProperties.System.Document.Division;
					if (!this.hashtable.ContainsKey(division))
					{
						this.hashtable.Add(division, this.shellObjectParent.Properties.CreateTypedProperty<string>(division));
					}
					return this.hashtable[division] as ShellProperty<string>;
				}
			}

			// Token: 0x170002CD RID: 717
			// (get) Token: 0x060006F4 RID: 1780 RVA: 0x0001AFA4 File Offset: 0x000191A4
			public ShellProperty<string> DocumentID
			{
				get
				{
					PropertyKey documentID = SystemProperties.System.Document.DocumentID;
					if (!this.hashtable.ContainsKey(documentID))
					{
						this.hashtable.Add(documentID, this.shellObjectParent.Properties.CreateTypedProperty<string>(documentID));
					}
					return this.hashtable[documentID] as ShellProperty<string>;
				}
			}

			// Token: 0x170002CE RID: 718
			// (get) Token: 0x060006F5 RID: 1781 RVA: 0x0001B00C File Offset: 0x0001920C
			public ShellProperty<int?> HiddenSlideCount
			{
				get
				{
					PropertyKey hiddenSlideCount = SystemProperties.System.Document.HiddenSlideCount;
					if (!this.hashtable.ContainsKey(hiddenSlideCount))
					{
						this.hashtable.Add(hiddenSlideCount, this.shellObjectParent.Properties.CreateTypedProperty<int?>(hiddenSlideCount));
					}
					return this.hashtable[hiddenSlideCount] as ShellProperty<int?>;
				}
			}

			// Token: 0x170002CF RID: 719
			// (get) Token: 0x060006F6 RID: 1782 RVA: 0x0001B074 File Offset: 0x00019274
			public ShellProperty<string> LastAuthor
			{
				get
				{
					PropertyKey lastAuthor = SystemProperties.System.Document.LastAuthor;
					if (!this.hashtable.ContainsKey(lastAuthor))
					{
						this.hashtable.Add(lastAuthor, this.shellObjectParent.Properties.CreateTypedProperty<string>(lastAuthor));
					}
					return this.hashtable[lastAuthor] as ShellProperty<string>;
				}
			}

			// Token: 0x170002D0 RID: 720
			// (get) Token: 0x060006F7 RID: 1783 RVA: 0x0001B0DC File Offset: 0x000192DC
			public ShellProperty<int?> LineCount
			{
				get
				{
					PropertyKey lineCount = SystemProperties.System.Document.LineCount;
					if (!this.hashtable.ContainsKey(lineCount))
					{
						this.hashtable.Add(lineCount, this.shellObjectParent.Properties.CreateTypedProperty<int?>(lineCount));
					}
					return this.hashtable[lineCount] as ShellProperty<int?>;
				}
			}

			// Token: 0x170002D1 RID: 721
			// (get) Token: 0x060006F8 RID: 1784 RVA: 0x0001B144 File Offset: 0x00019344
			public ShellProperty<string> Manager
			{
				get
				{
					PropertyKey manager = SystemProperties.System.Document.Manager;
					if (!this.hashtable.ContainsKey(manager))
					{
						this.hashtable.Add(manager, this.shellObjectParent.Properties.CreateTypedProperty<string>(manager));
					}
					return this.hashtable[manager] as ShellProperty<string>;
				}
			}

			// Token: 0x170002D2 RID: 722
			// (get) Token: 0x060006F9 RID: 1785 RVA: 0x0001B1AC File Offset: 0x000193AC
			public ShellProperty<int?> MultimediaClipCount
			{
				get
				{
					PropertyKey multimediaClipCount = SystemProperties.System.Document.MultimediaClipCount;
					if (!this.hashtable.ContainsKey(multimediaClipCount))
					{
						this.hashtable.Add(multimediaClipCount, this.shellObjectParent.Properties.CreateTypedProperty<int?>(multimediaClipCount));
					}
					return this.hashtable[multimediaClipCount] as ShellProperty<int?>;
				}
			}

			// Token: 0x170002D3 RID: 723
			// (get) Token: 0x060006FA RID: 1786 RVA: 0x0001B214 File Offset: 0x00019414
			public ShellProperty<int?> NoteCount
			{
				get
				{
					PropertyKey noteCount = SystemProperties.System.Document.NoteCount;
					if (!this.hashtable.ContainsKey(noteCount))
					{
						this.hashtable.Add(noteCount, this.shellObjectParent.Properties.CreateTypedProperty<int?>(noteCount));
					}
					return this.hashtable[noteCount] as ShellProperty<int?>;
				}
			}

			// Token: 0x170002D4 RID: 724
			// (get) Token: 0x060006FB RID: 1787 RVA: 0x0001B27C File Offset: 0x0001947C
			public ShellProperty<int?> PageCount
			{
				get
				{
					PropertyKey pageCount = SystemProperties.System.Document.PageCount;
					if (!this.hashtable.ContainsKey(pageCount))
					{
						this.hashtable.Add(pageCount, this.shellObjectParent.Properties.CreateTypedProperty<int?>(pageCount));
					}
					return this.hashtable[pageCount] as ShellProperty<int?>;
				}
			}

			// Token: 0x170002D5 RID: 725
			// (get) Token: 0x060006FC RID: 1788 RVA: 0x0001B2E4 File Offset: 0x000194E4
			public ShellProperty<int?> ParagraphCount
			{
				get
				{
					PropertyKey paragraphCount = SystemProperties.System.Document.ParagraphCount;
					if (!this.hashtable.ContainsKey(paragraphCount))
					{
						this.hashtable.Add(paragraphCount, this.shellObjectParent.Properties.CreateTypedProperty<int?>(paragraphCount));
					}
					return this.hashtable[paragraphCount] as ShellProperty<int?>;
				}
			}

			// Token: 0x170002D6 RID: 726
			// (get) Token: 0x060006FD RID: 1789 RVA: 0x0001B34C File Offset: 0x0001954C
			public ShellProperty<string> PresentationFormat
			{
				get
				{
					PropertyKey presentationFormat = SystemProperties.System.Document.PresentationFormat;
					if (!this.hashtable.ContainsKey(presentationFormat))
					{
						this.hashtable.Add(presentationFormat, this.shellObjectParent.Properties.CreateTypedProperty<string>(presentationFormat));
					}
					return this.hashtable[presentationFormat] as ShellProperty<string>;
				}
			}

			// Token: 0x170002D7 RID: 727
			// (get) Token: 0x060006FE RID: 1790 RVA: 0x0001B3B4 File Offset: 0x000195B4
			public ShellProperty<string> RevisionNumber
			{
				get
				{
					PropertyKey revisionNumber = SystemProperties.System.Document.RevisionNumber;
					if (!this.hashtable.ContainsKey(revisionNumber))
					{
						this.hashtable.Add(revisionNumber, this.shellObjectParent.Properties.CreateTypedProperty<string>(revisionNumber));
					}
					return this.hashtable[revisionNumber] as ShellProperty<string>;
				}
			}

			// Token: 0x170002D8 RID: 728
			// (get) Token: 0x060006FF RID: 1791 RVA: 0x0001B41C File Offset: 0x0001961C
			public ShellProperty<int?> Security
			{
				get
				{
					PropertyKey security = SystemProperties.System.Document.Security;
					if (!this.hashtable.ContainsKey(security))
					{
						this.hashtable.Add(security, this.shellObjectParent.Properties.CreateTypedProperty<int?>(security));
					}
					return this.hashtable[security] as ShellProperty<int?>;
				}
			}

			// Token: 0x170002D9 RID: 729
			// (get) Token: 0x06000700 RID: 1792 RVA: 0x0001B484 File Offset: 0x00019684
			public ShellProperty<int?> SlideCount
			{
				get
				{
					PropertyKey slideCount = SystemProperties.System.Document.SlideCount;
					if (!this.hashtable.ContainsKey(slideCount))
					{
						this.hashtable.Add(slideCount, this.shellObjectParent.Properties.CreateTypedProperty<int?>(slideCount));
					}
					return this.hashtable[slideCount] as ShellProperty<int?>;
				}
			}

			// Token: 0x170002DA RID: 730
			// (get) Token: 0x06000701 RID: 1793 RVA: 0x0001B4EC File Offset: 0x000196EC
			public ShellProperty<string> Template
			{
				get
				{
					PropertyKey template = SystemProperties.System.Document.Template;
					if (!this.hashtable.ContainsKey(template))
					{
						this.hashtable.Add(template, this.shellObjectParent.Properties.CreateTypedProperty<string>(template));
					}
					return this.hashtable[template] as ShellProperty<string>;
				}
			}

			// Token: 0x170002DB RID: 731
			// (get) Token: 0x06000702 RID: 1794 RVA: 0x0001B554 File Offset: 0x00019754
			public ShellProperty<ulong?> TotalEditingTime
			{
				get
				{
					PropertyKey totalEditingTime = SystemProperties.System.Document.TotalEditingTime;
					if (!this.hashtable.ContainsKey(totalEditingTime))
					{
						this.hashtable.Add(totalEditingTime, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(totalEditingTime));
					}
					return this.hashtable[totalEditingTime] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x170002DC RID: 732
			// (get) Token: 0x06000703 RID: 1795 RVA: 0x0001B5BC File Offset: 0x000197BC
			public ShellProperty<string> Version
			{
				get
				{
					PropertyKey version = SystemProperties.System.Document.Version;
					if (!this.hashtable.ContainsKey(version))
					{
						this.hashtable.Add(version, this.shellObjectParent.Properties.CreateTypedProperty<string>(version));
					}
					return this.hashtable[version] as ShellProperty<string>;
				}
			}

			// Token: 0x170002DD RID: 733
			// (get) Token: 0x06000704 RID: 1796 RVA: 0x0001B624 File Offset: 0x00019824
			public ShellProperty<int?> WordCount
			{
				get
				{
					PropertyKey wordCount = SystemProperties.System.Document.WordCount;
					if (!this.hashtable.ContainsKey(wordCount))
					{
						this.hashtable.Add(wordCount, this.shellObjectParent.Properties.CreateTypedProperty<int?>(wordCount));
					}
					return this.hashtable[wordCount] as ShellProperty<int?>;
				}
			}

			// Token: 0x04000373 RID: 883
			private ShellObject shellObjectParent;

			// Token: 0x04000374 RID: 884
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000BB RID: 187
		public class PropertySystemDRM : PropertyStoreItems
		{
			// Token: 0x06000705 RID: 1797 RVA: 0x0001B68C File Offset: 0x0001988C
			internal PropertySystemDRM(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x170002DE RID: 734
			// (get) Token: 0x06000706 RID: 1798 RVA: 0x0001B6AC File Offset: 0x000198AC
			public ShellProperty<DateTime?> DatePlayExpires
			{
				get
				{
					PropertyKey datePlayExpires = SystemProperties.System.DRM.DatePlayExpires;
					if (!this.hashtable.ContainsKey(datePlayExpires))
					{
						this.hashtable.Add(datePlayExpires, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(datePlayExpires));
					}
					return this.hashtable[datePlayExpires] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x170002DF RID: 735
			// (get) Token: 0x06000707 RID: 1799 RVA: 0x0001B714 File Offset: 0x00019914
			public ShellProperty<DateTime?> DatePlayStarts
			{
				get
				{
					PropertyKey datePlayStarts = SystemProperties.System.DRM.DatePlayStarts;
					if (!this.hashtable.ContainsKey(datePlayStarts))
					{
						this.hashtable.Add(datePlayStarts, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(datePlayStarts));
					}
					return this.hashtable[datePlayStarts] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x170002E0 RID: 736
			// (get) Token: 0x06000708 RID: 1800 RVA: 0x0001B77C File Offset: 0x0001997C
			public ShellProperty<string> Description
			{
				get
				{
					PropertyKey description = SystemProperties.System.DRM.Description;
					if (!this.hashtable.ContainsKey(description))
					{
						this.hashtable.Add(description, this.shellObjectParent.Properties.CreateTypedProperty<string>(description));
					}
					return this.hashtable[description] as ShellProperty<string>;
				}
			}

			// Token: 0x170002E1 RID: 737
			// (get) Token: 0x06000709 RID: 1801 RVA: 0x0001B7E4 File Offset: 0x000199E4
			public ShellProperty<bool?> IsProtected
			{
				get
				{
					PropertyKey isProtected = SystemProperties.System.DRM.IsProtected;
					if (!this.hashtable.ContainsKey(isProtected))
					{
						this.hashtable.Add(isProtected, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isProtected));
					}
					return this.hashtable[isProtected] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170002E2 RID: 738
			// (get) Token: 0x0600070A RID: 1802 RVA: 0x0001B84C File Offset: 0x00019A4C
			public ShellProperty<uint?> PlayCount
			{
				get
				{
					PropertyKey playCount = SystemProperties.System.DRM.PlayCount;
					if (!this.hashtable.ContainsKey(playCount))
					{
						this.hashtable.Add(playCount, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(playCount));
					}
					return this.hashtable[playCount] as ShellProperty<uint?>;
				}
			}

			// Token: 0x04000375 RID: 885
			private ShellObject shellObjectParent;

			// Token: 0x04000376 RID: 886
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000BC RID: 188
		public class PropertySystemGPS : PropertyStoreItems
		{
			// Token: 0x0600070B RID: 1803 RVA: 0x0001B8B4 File Offset: 0x00019AB4
			internal PropertySystemGPS(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x170002E3 RID: 739
			// (get) Token: 0x0600070C RID: 1804 RVA: 0x0001B8D4 File Offset: 0x00019AD4
			public ShellProperty<double?> Altitude
			{
				get
				{
					PropertyKey altitude = SystemProperties.System.GPS.Altitude;
					if (!this.hashtable.ContainsKey(altitude))
					{
						this.hashtable.Add(altitude, this.shellObjectParent.Properties.CreateTypedProperty<double?>(altitude));
					}
					return this.hashtable[altitude] as ShellProperty<double?>;
				}
			}

			// Token: 0x170002E4 RID: 740
			// (get) Token: 0x0600070D RID: 1805 RVA: 0x0001B93C File Offset: 0x00019B3C
			public ShellProperty<uint?> AltitudeDenominator
			{
				get
				{
					PropertyKey altitudeDenominator = SystemProperties.System.GPS.AltitudeDenominator;
					if (!this.hashtable.ContainsKey(altitudeDenominator))
					{
						this.hashtable.Add(altitudeDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(altitudeDenominator));
					}
					return this.hashtable[altitudeDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170002E5 RID: 741
			// (get) Token: 0x0600070E RID: 1806 RVA: 0x0001B9A4 File Offset: 0x00019BA4
			public ShellProperty<uint?> AltitudeNumerator
			{
				get
				{
					PropertyKey altitudeNumerator = SystemProperties.System.GPS.AltitudeNumerator;
					if (!this.hashtable.ContainsKey(altitudeNumerator))
					{
						this.hashtable.Add(altitudeNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(altitudeNumerator));
					}
					return this.hashtable[altitudeNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170002E6 RID: 742
			// (get) Token: 0x0600070F RID: 1807 RVA: 0x0001BA0C File Offset: 0x00019C0C
			public ShellProperty<byte?> AltitudeRef
			{
				get
				{
					PropertyKey altitudeRef = SystemProperties.System.GPS.AltitudeRef;
					if (!this.hashtable.ContainsKey(altitudeRef))
					{
						this.hashtable.Add(altitudeRef, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(altitudeRef));
					}
					return this.hashtable[altitudeRef] as ShellProperty<byte?>;
				}
			}

			// Token: 0x170002E7 RID: 743
			// (get) Token: 0x06000710 RID: 1808 RVA: 0x0001BA74 File Offset: 0x00019C74
			public ShellProperty<string> AreaInformation
			{
				get
				{
					PropertyKey areaInformation = SystemProperties.System.GPS.AreaInformation;
					if (!this.hashtable.ContainsKey(areaInformation))
					{
						this.hashtable.Add(areaInformation, this.shellObjectParent.Properties.CreateTypedProperty<string>(areaInformation));
					}
					return this.hashtable[areaInformation] as ShellProperty<string>;
				}
			}

			// Token: 0x170002E8 RID: 744
			// (get) Token: 0x06000711 RID: 1809 RVA: 0x0001BADC File Offset: 0x00019CDC
			public ShellProperty<DateTime?> Date
			{
				get
				{
					PropertyKey date = SystemProperties.System.GPS.Date;
					if (!this.hashtable.ContainsKey(date))
					{
						this.hashtable.Add(date, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(date));
					}
					return this.hashtable[date] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x170002E9 RID: 745
			// (get) Token: 0x06000712 RID: 1810 RVA: 0x0001BB44 File Offset: 0x00019D44
			public ShellProperty<double?> DestinationBearing
			{
				get
				{
					PropertyKey destinationBearing = SystemProperties.System.GPS.DestinationBearing;
					if (!this.hashtable.ContainsKey(destinationBearing))
					{
						this.hashtable.Add(destinationBearing, this.shellObjectParent.Properties.CreateTypedProperty<double?>(destinationBearing));
					}
					return this.hashtable[destinationBearing] as ShellProperty<double?>;
				}
			}

			// Token: 0x170002EA RID: 746
			// (get) Token: 0x06000713 RID: 1811 RVA: 0x0001BBAC File Offset: 0x00019DAC
			public ShellProperty<uint?> DestinationBearingDenominator
			{
				get
				{
					PropertyKey destinationBearingDenominator = SystemProperties.System.GPS.DestinationBearingDenominator;
					if (!this.hashtable.ContainsKey(destinationBearingDenominator))
					{
						this.hashtable.Add(destinationBearingDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(destinationBearingDenominator));
					}
					return this.hashtable[destinationBearingDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170002EB RID: 747
			// (get) Token: 0x06000714 RID: 1812 RVA: 0x0001BC14 File Offset: 0x00019E14
			public ShellProperty<uint?> DestinationBearingNumerator
			{
				get
				{
					PropertyKey destinationBearingNumerator = SystemProperties.System.GPS.DestinationBearingNumerator;
					if (!this.hashtable.ContainsKey(destinationBearingNumerator))
					{
						this.hashtable.Add(destinationBearingNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(destinationBearingNumerator));
					}
					return this.hashtable[destinationBearingNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170002EC RID: 748
			// (get) Token: 0x06000715 RID: 1813 RVA: 0x0001BC7C File Offset: 0x00019E7C
			public ShellProperty<string> DestinationBearingRef
			{
				get
				{
					PropertyKey destinationBearingRef = SystemProperties.System.GPS.DestinationBearingRef;
					if (!this.hashtable.ContainsKey(destinationBearingRef))
					{
						this.hashtable.Add(destinationBearingRef, this.shellObjectParent.Properties.CreateTypedProperty<string>(destinationBearingRef));
					}
					return this.hashtable[destinationBearingRef] as ShellProperty<string>;
				}
			}

			// Token: 0x170002ED RID: 749
			// (get) Token: 0x06000716 RID: 1814 RVA: 0x0001BCE4 File Offset: 0x00019EE4
			public ShellProperty<double?> DestinationDistance
			{
				get
				{
					PropertyKey destinationDistance = SystemProperties.System.GPS.DestinationDistance;
					if (!this.hashtable.ContainsKey(destinationDistance))
					{
						this.hashtable.Add(destinationDistance, this.shellObjectParent.Properties.CreateTypedProperty<double?>(destinationDistance));
					}
					return this.hashtable[destinationDistance] as ShellProperty<double?>;
				}
			}

			// Token: 0x170002EE RID: 750
			// (get) Token: 0x06000717 RID: 1815 RVA: 0x0001BD4C File Offset: 0x00019F4C
			public ShellProperty<uint?> DestinationDistanceDenominator
			{
				get
				{
					PropertyKey destinationDistanceDenominator = SystemProperties.System.GPS.DestinationDistanceDenominator;
					if (!this.hashtable.ContainsKey(destinationDistanceDenominator))
					{
						this.hashtable.Add(destinationDistanceDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(destinationDistanceDenominator));
					}
					return this.hashtable[destinationDistanceDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170002EF RID: 751
			// (get) Token: 0x06000718 RID: 1816 RVA: 0x0001BDB4 File Offset: 0x00019FB4
			public ShellProperty<uint?> DestinationDistanceNumerator
			{
				get
				{
					PropertyKey destinationDistanceNumerator = SystemProperties.System.GPS.DestinationDistanceNumerator;
					if (!this.hashtable.ContainsKey(destinationDistanceNumerator))
					{
						this.hashtable.Add(destinationDistanceNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(destinationDistanceNumerator));
					}
					return this.hashtable[destinationDistanceNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170002F0 RID: 752
			// (get) Token: 0x06000719 RID: 1817 RVA: 0x0001BE1C File Offset: 0x0001A01C
			public ShellProperty<string> DestinationDistanceRef
			{
				get
				{
					PropertyKey destinationDistanceRef = SystemProperties.System.GPS.DestinationDistanceRef;
					if (!this.hashtable.ContainsKey(destinationDistanceRef))
					{
						this.hashtable.Add(destinationDistanceRef, this.shellObjectParent.Properties.CreateTypedProperty<string>(destinationDistanceRef));
					}
					return this.hashtable[destinationDistanceRef] as ShellProperty<string>;
				}
			}

			// Token: 0x170002F1 RID: 753
			// (get) Token: 0x0600071A RID: 1818 RVA: 0x0001BE84 File Offset: 0x0001A084
			public ShellProperty<double[]> DestinationLatitude
			{
				get
				{
					PropertyKey destinationLatitude = SystemProperties.System.GPS.DestinationLatitude;
					if (!this.hashtable.ContainsKey(destinationLatitude))
					{
						this.hashtable.Add(destinationLatitude, this.shellObjectParent.Properties.CreateTypedProperty<double[]>(destinationLatitude));
					}
					return this.hashtable[destinationLatitude] as ShellProperty<double[]>;
				}
			}

			// Token: 0x170002F2 RID: 754
			// (get) Token: 0x0600071B RID: 1819 RVA: 0x0001BEEC File Offset: 0x0001A0EC
			public ShellProperty<uint[]> DestinationLatitudeDenominator
			{
				get
				{
					PropertyKey destinationLatitudeDenominator = SystemProperties.System.GPS.DestinationLatitudeDenominator;
					if (!this.hashtable.ContainsKey(destinationLatitudeDenominator))
					{
						this.hashtable.Add(destinationLatitudeDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint[]>(destinationLatitudeDenominator));
					}
					return this.hashtable[destinationLatitudeDenominator] as ShellProperty<uint[]>;
				}
			}

			// Token: 0x170002F3 RID: 755
			// (get) Token: 0x0600071C RID: 1820 RVA: 0x0001BF54 File Offset: 0x0001A154
			public ShellProperty<uint[]> DestinationLatitudeNumerator
			{
				get
				{
					PropertyKey destinationLatitudeNumerator = SystemProperties.System.GPS.DestinationLatitudeNumerator;
					if (!this.hashtable.ContainsKey(destinationLatitudeNumerator))
					{
						this.hashtable.Add(destinationLatitudeNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint[]>(destinationLatitudeNumerator));
					}
					return this.hashtable[destinationLatitudeNumerator] as ShellProperty<uint[]>;
				}
			}

			// Token: 0x170002F4 RID: 756
			// (get) Token: 0x0600071D RID: 1821 RVA: 0x0001BFBC File Offset: 0x0001A1BC
			public ShellProperty<string> DestinationLatitudeRef
			{
				get
				{
					PropertyKey destinationLatitudeRef = SystemProperties.System.GPS.DestinationLatitudeRef;
					if (!this.hashtable.ContainsKey(destinationLatitudeRef))
					{
						this.hashtable.Add(destinationLatitudeRef, this.shellObjectParent.Properties.CreateTypedProperty<string>(destinationLatitudeRef));
					}
					return this.hashtable[destinationLatitudeRef] as ShellProperty<string>;
				}
			}

			// Token: 0x170002F5 RID: 757
			// (get) Token: 0x0600071E RID: 1822 RVA: 0x0001C024 File Offset: 0x0001A224
			public ShellProperty<double[]> DestinationLongitude
			{
				get
				{
					PropertyKey destinationLongitude = SystemProperties.System.GPS.DestinationLongitude;
					if (!this.hashtable.ContainsKey(destinationLongitude))
					{
						this.hashtable.Add(destinationLongitude, this.shellObjectParent.Properties.CreateTypedProperty<double[]>(destinationLongitude));
					}
					return this.hashtable[destinationLongitude] as ShellProperty<double[]>;
				}
			}

			// Token: 0x170002F6 RID: 758
			// (get) Token: 0x0600071F RID: 1823 RVA: 0x0001C08C File Offset: 0x0001A28C
			public ShellProperty<uint[]> DestinationLongitudeDenominator
			{
				get
				{
					PropertyKey destinationLongitudeDenominator = SystemProperties.System.GPS.DestinationLongitudeDenominator;
					if (!this.hashtable.ContainsKey(destinationLongitudeDenominator))
					{
						this.hashtable.Add(destinationLongitudeDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint[]>(destinationLongitudeDenominator));
					}
					return this.hashtable[destinationLongitudeDenominator] as ShellProperty<uint[]>;
				}
			}

			// Token: 0x170002F7 RID: 759
			// (get) Token: 0x06000720 RID: 1824 RVA: 0x0001C0F4 File Offset: 0x0001A2F4
			public ShellProperty<uint[]> DestinationLongitudeNumerator
			{
				get
				{
					PropertyKey destinationLongitudeNumerator = SystemProperties.System.GPS.DestinationLongitudeNumerator;
					if (!this.hashtable.ContainsKey(destinationLongitudeNumerator))
					{
						this.hashtable.Add(destinationLongitudeNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint[]>(destinationLongitudeNumerator));
					}
					return this.hashtable[destinationLongitudeNumerator] as ShellProperty<uint[]>;
				}
			}

			// Token: 0x170002F8 RID: 760
			// (get) Token: 0x06000721 RID: 1825 RVA: 0x0001C15C File Offset: 0x0001A35C
			public ShellProperty<string> DestinationLongitudeRef
			{
				get
				{
					PropertyKey destinationLongitudeRef = SystemProperties.System.GPS.DestinationLongitudeRef;
					if (!this.hashtable.ContainsKey(destinationLongitudeRef))
					{
						this.hashtable.Add(destinationLongitudeRef, this.shellObjectParent.Properties.CreateTypedProperty<string>(destinationLongitudeRef));
					}
					return this.hashtable[destinationLongitudeRef] as ShellProperty<string>;
				}
			}

			// Token: 0x170002F9 RID: 761
			// (get) Token: 0x06000722 RID: 1826 RVA: 0x0001C1C4 File Offset: 0x0001A3C4
			public ShellProperty<ushort?> Differential
			{
				get
				{
					PropertyKey differential = SystemProperties.System.GPS.Differential;
					if (!this.hashtable.ContainsKey(differential))
					{
						this.hashtable.Add(differential, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(differential));
					}
					return this.hashtable[differential] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x170002FA RID: 762
			// (get) Token: 0x06000723 RID: 1827 RVA: 0x0001C22C File Offset: 0x0001A42C
			public ShellProperty<double?> DOP
			{
				get
				{
					PropertyKey dop = SystemProperties.System.GPS.DOP;
					if (!this.hashtable.ContainsKey(dop))
					{
						this.hashtable.Add(dop, this.shellObjectParent.Properties.CreateTypedProperty<double?>(dop));
					}
					return this.hashtable[dop] as ShellProperty<double?>;
				}
			}

			// Token: 0x170002FB RID: 763
			// (get) Token: 0x06000724 RID: 1828 RVA: 0x0001C294 File Offset: 0x0001A494
			public ShellProperty<uint?> DOPDenominator
			{
				get
				{
					PropertyKey dopdenominator = SystemProperties.System.GPS.DOPDenominator;
					if (!this.hashtable.ContainsKey(dopdenominator))
					{
						this.hashtable.Add(dopdenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(dopdenominator));
					}
					return this.hashtable[dopdenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170002FC RID: 764
			// (get) Token: 0x06000725 RID: 1829 RVA: 0x0001C2FC File Offset: 0x0001A4FC
			public ShellProperty<uint?> DOPNumerator
			{
				get
				{
					PropertyKey dopnumerator = SystemProperties.System.GPS.DOPNumerator;
					if (!this.hashtable.ContainsKey(dopnumerator))
					{
						this.hashtable.Add(dopnumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(dopnumerator));
					}
					return this.hashtable[dopnumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170002FD RID: 765
			// (get) Token: 0x06000726 RID: 1830 RVA: 0x0001C364 File Offset: 0x0001A564
			public ShellProperty<double?> ImageDirection
			{
				get
				{
					PropertyKey imageDirection = SystemProperties.System.GPS.ImageDirection;
					if (!this.hashtable.ContainsKey(imageDirection))
					{
						this.hashtable.Add(imageDirection, this.shellObjectParent.Properties.CreateTypedProperty<double?>(imageDirection));
					}
					return this.hashtable[imageDirection] as ShellProperty<double?>;
				}
			}

			// Token: 0x170002FE RID: 766
			// (get) Token: 0x06000727 RID: 1831 RVA: 0x0001C3CC File Offset: 0x0001A5CC
			public ShellProperty<uint?> ImageDirectionDenominator
			{
				get
				{
					PropertyKey imageDirectionDenominator = SystemProperties.System.GPS.ImageDirectionDenominator;
					if (!this.hashtable.ContainsKey(imageDirectionDenominator))
					{
						this.hashtable.Add(imageDirectionDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(imageDirectionDenominator));
					}
					return this.hashtable[imageDirectionDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170002FF RID: 767
			// (get) Token: 0x06000728 RID: 1832 RVA: 0x0001C434 File Offset: 0x0001A634
			public ShellProperty<uint?> ImageDirectionNumerator
			{
				get
				{
					PropertyKey imageDirectionNumerator = SystemProperties.System.GPS.ImageDirectionNumerator;
					if (!this.hashtable.ContainsKey(imageDirectionNumerator))
					{
						this.hashtable.Add(imageDirectionNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(imageDirectionNumerator));
					}
					return this.hashtable[imageDirectionNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000300 RID: 768
			// (get) Token: 0x06000729 RID: 1833 RVA: 0x0001C49C File Offset: 0x0001A69C
			public ShellProperty<string> ImageDirectionRef
			{
				get
				{
					PropertyKey imageDirectionRef = SystemProperties.System.GPS.ImageDirectionRef;
					if (!this.hashtable.ContainsKey(imageDirectionRef))
					{
						this.hashtable.Add(imageDirectionRef, this.shellObjectParent.Properties.CreateTypedProperty<string>(imageDirectionRef));
					}
					return this.hashtable[imageDirectionRef] as ShellProperty<string>;
				}
			}

			// Token: 0x17000301 RID: 769
			// (get) Token: 0x0600072A RID: 1834 RVA: 0x0001C504 File Offset: 0x0001A704
			public ShellProperty<double[]> Latitude
			{
				get
				{
					PropertyKey latitude = SystemProperties.System.GPS.Latitude;
					if (!this.hashtable.ContainsKey(latitude))
					{
						this.hashtable.Add(latitude, this.shellObjectParent.Properties.CreateTypedProperty<double[]>(latitude));
					}
					return this.hashtable[latitude] as ShellProperty<double[]>;
				}
			}

			// Token: 0x17000302 RID: 770
			// (get) Token: 0x0600072B RID: 1835 RVA: 0x0001C56C File Offset: 0x0001A76C
			public ShellProperty<uint[]> LatitudeDenominator
			{
				get
				{
					PropertyKey latitudeDenominator = SystemProperties.System.GPS.LatitudeDenominator;
					if (!this.hashtable.ContainsKey(latitudeDenominator))
					{
						this.hashtable.Add(latitudeDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint[]>(latitudeDenominator));
					}
					return this.hashtable[latitudeDenominator] as ShellProperty<uint[]>;
				}
			}

			// Token: 0x17000303 RID: 771
			// (get) Token: 0x0600072C RID: 1836 RVA: 0x0001C5D4 File Offset: 0x0001A7D4
			public ShellProperty<uint[]> LatitudeNumerator
			{
				get
				{
					PropertyKey latitudeNumerator = SystemProperties.System.GPS.LatitudeNumerator;
					if (!this.hashtable.ContainsKey(latitudeNumerator))
					{
						this.hashtable.Add(latitudeNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint[]>(latitudeNumerator));
					}
					return this.hashtable[latitudeNumerator] as ShellProperty<uint[]>;
				}
			}

			// Token: 0x17000304 RID: 772
			// (get) Token: 0x0600072D RID: 1837 RVA: 0x0001C63C File Offset: 0x0001A83C
			public ShellProperty<string> LatitudeRef
			{
				get
				{
					PropertyKey latitudeRef = SystemProperties.System.GPS.LatitudeRef;
					if (!this.hashtable.ContainsKey(latitudeRef))
					{
						this.hashtable.Add(latitudeRef, this.shellObjectParent.Properties.CreateTypedProperty<string>(latitudeRef));
					}
					return this.hashtable[latitudeRef] as ShellProperty<string>;
				}
			}

			// Token: 0x17000305 RID: 773
			// (get) Token: 0x0600072E RID: 1838 RVA: 0x0001C6A4 File Offset: 0x0001A8A4
			public ShellProperty<double[]> Longitude
			{
				get
				{
					PropertyKey longitude = SystemProperties.System.GPS.Longitude;
					if (!this.hashtable.ContainsKey(longitude))
					{
						this.hashtable.Add(longitude, this.shellObjectParent.Properties.CreateTypedProperty<double[]>(longitude));
					}
					return this.hashtable[longitude] as ShellProperty<double[]>;
				}
			}

			// Token: 0x17000306 RID: 774
			// (get) Token: 0x0600072F RID: 1839 RVA: 0x0001C70C File Offset: 0x0001A90C
			public ShellProperty<uint[]> LongitudeDenominator
			{
				get
				{
					PropertyKey longitudeDenominator = SystemProperties.System.GPS.LongitudeDenominator;
					if (!this.hashtable.ContainsKey(longitudeDenominator))
					{
						this.hashtable.Add(longitudeDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint[]>(longitudeDenominator));
					}
					return this.hashtable[longitudeDenominator] as ShellProperty<uint[]>;
				}
			}

			// Token: 0x17000307 RID: 775
			// (get) Token: 0x06000730 RID: 1840 RVA: 0x0001C774 File Offset: 0x0001A974
			public ShellProperty<uint[]> LongitudeNumerator
			{
				get
				{
					PropertyKey longitudeNumerator = SystemProperties.System.GPS.LongitudeNumerator;
					if (!this.hashtable.ContainsKey(longitudeNumerator))
					{
						this.hashtable.Add(longitudeNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint[]>(longitudeNumerator));
					}
					return this.hashtable[longitudeNumerator] as ShellProperty<uint[]>;
				}
			}

			// Token: 0x17000308 RID: 776
			// (get) Token: 0x06000731 RID: 1841 RVA: 0x0001C7DC File Offset: 0x0001A9DC
			public ShellProperty<string> LongitudeRef
			{
				get
				{
					PropertyKey longitudeRef = SystemProperties.System.GPS.LongitudeRef;
					if (!this.hashtable.ContainsKey(longitudeRef))
					{
						this.hashtable.Add(longitudeRef, this.shellObjectParent.Properties.CreateTypedProperty<string>(longitudeRef));
					}
					return this.hashtable[longitudeRef] as ShellProperty<string>;
				}
			}

			// Token: 0x17000309 RID: 777
			// (get) Token: 0x06000732 RID: 1842 RVA: 0x0001C844 File Offset: 0x0001AA44
			public ShellProperty<string> MapDatum
			{
				get
				{
					PropertyKey mapDatum = SystemProperties.System.GPS.MapDatum;
					if (!this.hashtable.ContainsKey(mapDatum))
					{
						this.hashtable.Add(mapDatum, this.shellObjectParent.Properties.CreateTypedProperty<string>(mapDatum));
					}
					return this.hashtable[mapDatum] as ShellProperty<string>;
				}
			}

			// Token: 0x1700030A RID: 778
			// (get) Token: 0x06000733 RID: 1843 RVA: 0x0001C8AC File Offset: 0x0001AAAC
			public ShellProperty<string> MeasureMode
			{
				get
				{
					PropertyKey measureMode = SystemProperties.System.GPS.MeasureMode;
					if (!this.hashtable.ContainsKey(measureMode))
					{
						this.hashtable.Add(measureMode, this.shellObjectParent.Properties.CreateTypedProperty<string>(measureMode));
					}
					return this.hashtable[measureMode] as ShellProperty<string>;
				}
			}

			// Token: 0x1700030B RID: 779
			// (get) Token: 0x06000734 RID: 1844 RVA: 0x0001C914 File Offset: 0x0001AB14
			public ShellProperty<string> ProcessingMethod
			{
				get
				{
					PropertyKey processingMethod = SystemProperties.System.GPS.ProcessingMethod;
					if (!this.hashtable.ContainsKey(processingMethod))
					{
						this.hashtable.Add(processingMethod, this.shellObjectParent.Properties.CreateTypedProperty<string>(processingMethod));
					}
					return this.hashtable[processingMethod] as ShellProperty<string>;
				}
			}

			// Token: 0x1700030C RID: 780
			// (get) Token: 0x06000735 RID: 1845 RVA: 0x0001C97C File Offset: 0x0001AB7C
			public ShellProperty<string> Satellites
			{
				get
				{
					PropertyKey satellites = SystemProperties.System.GPS.Satellites;
					if (!this.hashtable.ContainsKey(satellites))
					{
						this.hashtable.Add(satellites, this.shellObjectParent.Properties.CreateTypedProperty<string>(satellites));
					}
					return this.hashtable[satellites] as ShellProperty<string>;
				}
			}

			// Token: 0x1700030D RID: 781
			// (get) Token: 0x06000736 RID: 1846 RVA: 0x0001C9E4 File Offset: 0x0001ABE4
			public ShellProperty<double?> Speed
			{
				get
				{
					PropertyKey speed = SystemProperties.System.GPS.Speed;
					if (!this.hashtable.ContainsKey(speed))
					{
						this.hashtable.Add(speed, this.shellObjectParent.Properties.CreateTypedProperty<double?>(speed));
					}
					return this.hashtable[speed] as ShellProperty<double?>;
				}
			}

			// Token: 0x1700030E RID: 782
			// (get) Token: 0x06000737 RID: 1847 RVA: 0x0001CA4C File Offset: 0x0001AC4C
			public ShellProperty<uint?> SpeedDenominator
			{
				get
				{
					PropertyKey speedDenominator = SystemProperties.System.GPS.SpeedDenominator;
					if (!this.hashtable.ContainsKey(speedDenominator))
					{
						this.hashtable.Add(speedDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(speedDenominator));
					}
					return this.hashtable[speedDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700030F RID: 783
			// (get) Token: 0x06000738 RID: 1848 RVA: 0x0001CAB4 File Offset: 0x0001ACB4
			public ShellProperty<uint?> SpeedNumerator
			{
				get
				{
					PropertyKey speedNumerator = SystemProperties.System.GPS.SpeedNumerator;
					if (!this.hashtable.ContainsKey(speedNumerator))
					{
						this.hashtable.Add(speedNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(speedNumerator));
					}
					return this.hashtable[speedNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000310 RID: 784
			// (get) Token: 0x06000739 RID: 1849 RVA: 0x0001CB1C File Offset: 0x0001AD1C
			public ShellProperty<string> SpeedRef
			{
				get
				{
					PropertyKey speedRef = SystemProperties.System.GPS.SpeedRef;
					if (!this.hashtable.ContainsKey(speedRef))
					{
						this.hashtable.Add(speedRef, this.shellObjectParent.Properties.CreateTypedProperty<string>(speedRef));
					}
					return this.hashtable[speedRef] as ShellProperty<string>;
				}
			}

			// Token: 0x17000311 RID: 785
			// (get) Token: 0x0600073A RID: 1850 RVA: 0x0001CB84 File Offset: 0x0001AD84
			public ShellProperty<string> Status
			{
				get
				{
					PropertyKey status = SystemProperties.System.GPS.Status;
					if (!this.hashtable.ContainsKey(status))
					{
						this.hashtable.Add(status, this.shellObjectParent.Properties.CreateTypedProperty<string>(status));
					}
					return this.hashtable[status] as ShellProperty<string>;
				}
			}

			// Token: 0x17000312 RID: 786
			// (get) Token: 0x0600073B RID: 1851 RVA: 0x0001CBEC File Offset: 0x0001ADEC
			public ShellProperty<double?> Track
			{
				get
				{
					PropertyKey track = SystemProperties.System.GPS.Track;
					if (!this.hashtable.ContainsKey(track))
					{
						this.hashtable.Add(track, this.shellObjectParent.Properties.CreateTypedProperty<double?>(track));
					}
					return this.hashtable[track] as ShellProperty<double?>;
				}
			}

			// Token: 0x17000313 RID: 787
			// (get) Token: 0x0600073C RID: 1852 RVA: 0x0001CC54 File Offset: 0x0001AE54
			public ShellProperty<uint?> TrackDenominator
			{
				get
				{
					PropertyKey trackDenominator = SystemProperties.System.GPS.TrackDenominator;
					if (!this.hashtable.ContainsKey(trackDenominator))
					{
						this.hashtable.Add(trackDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(trackDenominator));
					}
					return this.hashtable[trackDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000314 RID: 788
			// (get) Token: 0x0600073D RID: 1853 RVA: 0x0001CCBC File Offset: 0x0001AEBC
			public ShellProperty<uint?> TrackNumerator
			{
				get
				{
					PropertyKey trackNumerator = SystemProperties.System.GPS.TrackNumerator;
					if (!this.hashtable.ContainsKey(trackNumerator))
					{
						this.hashtable.Add(trackNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(trackNumerator));
					}
					return this.hashtable[trackNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000315 RID: 789
			// (get) Token: 0x0600073E RID: 1854 RVA: 0x0001CD24 File Offset: 0x0001AF24
			public ShellProperty<string> TrackRef
			{
				get
				{
					PropertyKey trackRef = SystemProperties.System.GPS.TrackRef;
					if (!this.hashtable.ContainsKey(trackRef))
					{
						this.hashtable.Add(trackRef, this.shellObjectParent.Properties.CreateTypedProperty<string>(trackRef));
					}
					return this.hashtable[trackRef] as ShellProperty<string>;
				}
			}

			// Token: 0x17000316 RID: 790
			// (get) Token: 0x0600073F RID: 1855 RVA: 0x0001CD8C File Offset: 0x0001AF8C
			public ShellProperty<byte[]> VersionID
			{
				get
				{
					PropertyKey versionID = SystemProperties.System.GPS.VersionID;
					if (!this.hashtable.ContainsKey(versionID))
					{
						this.hashtable.Add(versionID, this.shellObjectParent.Properties.CreateTypedProperty<byte[]>(versionID));
					}
					return this.hashtable[versionID] as ShellProperty<byte[]>;
				}
			}

			// Token: 0x04000377 RID: 887
			private ShellObject shellObjectParent;

			// Token: 0x04000378 RID: 888
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000BD RID: 189
		public class PropertySystemIdentity : PropertyStoreItems
		{
			// Token: 0x06000740 RID: 1856 RVA: 0x0001CDF4 File Offset: 0x0001AFF4
			internal PropertySystemIdentity(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000317 RID: 791
			// (get) Token: 0x06000741 RID: 1857 RVA: 0x0001CE14 File Offset: 0x0001B014
			public ShellProperty<byte[]> Blob
			{
				get
				{
					PropertyKey blob = SystemProperties.System.Identity.Blob;
					if (!this.hashtable.ContainsKey(blob))
					{
						this.hashtable.Add(blob, this.shellObjectParent.Properties.CreateTypedProperty<byte[]>(blob));
					}
					return this.hashtable[blob] as ShellProperty<byte[]>;
				}
			}

			// Token: 0x17000318 RID: 792
			// (get) Token: 0x06000742 RID: 1858 RVA: 0x0001CE7C File Offset: 0x0001B07C
			public ShellProperty<string> DisplayName
			{
				get
				{
					PropertyKey displayName = SystemProperties.System.Identity.DisplayName;
					if (!this.hashtable.ContainsKey(displayName))
					{
						this.hashtable.Add(displayName, this.shellObjectParent.Properties.CreateTypedProperty<string>(displayName));
					}
					return this.hashtable[displayName] as ShellProperty<string>;
				}
			}

			// Token: 0x17000319 RID: 793
			// (get) Token: 0x06000743 RID: 1859 RVA: 0x0001CEE4 File Offset: 0x0001B0E4
			public ShellProperty<bool?> IsMeIdentity
			{
				get
				{
					PropertyKey isMeIdentity = SystemProperties.System.Identity.IsMeIdentity;
					if (!this.hashtable.ContainsKey(isMeIdentity))
					{
						this.hashtable.Add(isMeIdentity, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isMeIdentity));
					}
					return this.hashtable[isMeIdentity] as ShellProperty<bool?>;
				}
			}

			// Token: 0x1700031A RID: 794
			// (get) Token: 0x06000744 RID: 1860 RVA: 0x0001CF4C File Offset: 0x0001B14C
			public ShellProperty<string> PrimaryEmailAddress
			{
				get
				{
					PropertyKey primaryEmailAddress = SystemProperties.System.Identity.PrimaryEmailAddress;
					if (!this.hashtable.ContainsKey(primaryEmailAddress))
					{
						this.hashtable.Add(primaryEmailAddress, this.shellObjectParent.Properties.CreateTypedProperty<string>(primaryEmailAddress));
					}
					return this.hashtable[primaryEmailAddress] as ShellProperty<string>;
				}
			}

			// Token: 0x1700031B RID: 795
			// (get) Token: 0x06000745 RID: 1861 RVA: 0x0001CFB4 File Offset: 0x0001B1B4
			public ShellProperty<IntPtr?> ProviderID
			{
				get
				{
					PropertyKey providerID = SystemProperties.System.Identity.ProviderID;
					if (!this.hashtable.ContainsKey(providerID))
					{
						this.hashtable.Add(providerID, this.shellObjectParent.Properties.CreateTypedProperty<IntPtr?>(providerID));
					}
					return this.hashtable[providerID] as ShellProperty<IntPtr?>;
				}
			}

			// Token: 0x1700031C RID: 796
			// (get) Token: 0x06000746 RID: 1862 RVA: 0x0001D01C File Offset: 0x0001B21C
			public ShellProperty<string> UniqueID
			{
				get
				{
					PropertyKey uniqueID = SystemProperties.System.Identity.UniqueID;
					if (!this.hashtable.ContainsKey(uniqueID))
					{
						this.hashtable.Add(uniqueID, this.shellObjectParent.Properties.CreateTypedProperty<string>(uniqueID));
					}
					return this.hashtable[uniqueID] as ShellProperty<string>;
				}
			}

			// Token: 0x1700031D RID: 797
			// (get) Token: 0x06000747 RID: 1863 RVA: 0x0001D084 File Offset: 0x0001B284
			public ShellProperty<string> UserName
			{
				get
				{
					PropertyKey userName = SystemProperties.System.Identity.UserName;
					if (!this.hashtable.ContainsKey(userName))
					{
						this.hashtable.Add(userName, this.shellObjectParent.Properties.CreateTypedProperty<string>(userName));
					}
					return this.hashtable[userName] as ShellProperty<string>;
				}
			}

			// Token: 0x04000379 RID: 889
			private ShellObject shellObjectParent;

			// Token: 0x0400037A RID: 890
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000BE RID: 190
		public class PropertySystemIdentityProvider : PropertyStoreItems
		{
			// Token: 0x06000748 RID: 1864 RVA: 0x0001D0EC File Offset: 0x0001B2EC
			internal PropertySystemIdentityProvider(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700031E RID: 798
			// (get) Token: 0x06000749 RID: 1865 RVA: 0x0001D10C File Offset: 0x0001B30C
			public ShellProperty<string> Name
			{
				get
				{
					PropertyKey name = SystemProperties.System.IdentityProvider.Name;
					if (!this.hashtable.ContainsKey(name))
					{
						this.hashtable.Add(name, this.shellObjectParent.Properties.CreateTypedProperty<string>(name));
					}
					return this.hashtable[name] as ShellProperty<string>;
				}
			}

			// Token: 0x1700031F RID: 799
			// (get) Token: 0x0600074A RID: 1866 RVA: 0x0001D174 File Offset: 0x0001B374
			public ShellProperty<string> Picture
			{
				get
				{
					PropertyKey picture = SystemProperties.System.IdentityProvider.Picture;
					if (!this.hashtable.ContainsKey(picture))
					{
						this.hashtable.Add(picture, this.shellObjectParent.Properties.CreateTypedProperty<string>(picture));
					}
					return this.hashtable[picture] as ShellProperty<string>;
				}
			}

			// Token: 0x0400037B RID: 891
			private ShellObject shellObjectParent;

			// Token: 0x0400037C RID: 892
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000BF RID: 191
		public class PropertySystemImage : PropertyStoreItems
		{
			// Token: 0x0600074B RID: 1867 RVA: 0x0001D1DC File Offset: 0x0001B3DC
			internal PropertySystemImage(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000320 RID: 800
			// (get) Token: 0x0600074C RID: 1868 RVA: 0x0001D1FC File Offset: 0x0001B3FC
			public ShellProperty<uint?> BitDepth
			{
				get
				{
					PropertyKey bitDepth = SystemProperties.System.Image.BitDepth;
					if (!this.hashtable.ContainsKey(bitDepth))
					{
						this.hashtable.Add(bitDepth, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(bitDepth));
					}
					return this.hashtable[bitDepth] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000321 RID: 801
			// (get) Token: 0x0600074D RID: 1869 RVA: 0x0001D264 File Offset: 0x0001B464
			public ShellProperty<ushort?> ColorSpace
			{
				get
				{
					PropertyKey colorSpace = SystemProperties.System.Image.ColorSpace;
					if (!this.hashtable.ContainsKey(colorSpace))
					{
						this.hashtable.Add(colorSpace, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(colorSpace));
					}
					return this.hashtable[colorSpace] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x17000322 RID: 802
			// (get) Token: 0x0600074E RID: 1870 RVA: 0x0001D2CC File Offset: 0x0001B4CC
			public ShellProperty<double?> CompressedBitsPerPixel
			{
				get
				{
					PropertyKey compressedBitsPerPixel = SystemProperties.System.Image.CompressedBitsPerPixel;
					if (!this.hashtable.ContainsKey(compressedBitsPerPixel))
					{
						this.hashtable.Add(compressedBitsPerPixel, this.shellObjectParent.Properties.CreateTypedProperty<double?>(compressedBitsPerPixel));
					}
					return this.hashtable[compressedBitsPerPixel] as ShellProperty<double?>;
				}
			}

			// Token: 0x17000323 RID: 803
			// (get) Token: 0x0600074F RID: 1871 RVA: 0x0001D334 File Offset: 0x0001B534
			public ShellProperty<uint?> CompressedBitsPerPixelDenominator
			{
				get
				{
					PropertyKey compressedBitsPerPixelDenominator = SystemProperties.System.Image.CompressedBitsPerPixelDenominator;
					if (!this.hashtable.ContainsKey(compressedBitsPerPixelDenominator))
					{
						this.hashtable.Add(compressedBitsPerPixelDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(compressedBitsPerPixelDenominator));
					}
					return this.hashtable[compressedBitsPerPixelDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000324 RID: 804
			// (get) Token: 0x06000750 RID: 1872 RVA: 0x0001D39C File Offset: 0x0001B59C
			public ShellProperty<uint?> CompressedBitsPerPixelNumerator
			{
				get
				{
					PropertyKey compressedBitsPerPixelNumerator = SystemProperties.System.Image.CompressedBitsPerPixelNumerator;
					if (!this.hashtable.ContainsKey(compressedBitsPerPixelNumerator))
					{
						this.hashtable.Add(compressedBitsPerPixelNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(compressedBitsPerPixelNumerator));
					}
					return this.hashtable[compressedBitsPerPixelNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000325 RID: 805
			// (get) Token: 0x06000751 RID: 1873 RVA: 0x0001D404 File Offset: 0x0001B604
			public ShellProperty<ushort?> Compression
			{
				get
				{
					PropertyKey compression = SystemProperties.System.Image.Compression;
					if (!this.hashtable.ContainsKey(compression))
					{
						this.hashtable.Add(compression, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(compression));
					}
					return this.hashtable[compression] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x17000326 RID: 806
			// (get) Token: 0x06000752 RID: 1874 RVA: 0x0001D46C File Offset: 0x0001B66C
			public ShellProperty<string> CompressionText
			{
				get
				{
					PropertyKey compressionText = SystemProperties.System.Image.CompressionText;
					if (!this.hashtable.ContainsKey(compressionText))
					{
						this.hashtable.Add(compressionText, this.shellObjectParent.Properties.CreateTypedProperty<string>(compressionText));
					}
					return this.hashtable[compressionText] as ShellProperty<string>;
				}
			}

			// Token: 0x17000327 RID: 807
			// (get) Token: 0x06000753 RID: 1875 RVA: 0x0001D4D4 File Offset: 0x0001B6D4
			public ShellProperty<string> Dimensions
			{
				get
				{
					PropertyKey dimensions = SystemProperties.System.Image.Dimensions;
					if (!this.hashtable.ContainsKey(dimensions))
					{
						this.hashtable.Add(dimensions, this.shellObjectParent.Properties.CreateTypedProperty<string>(dimensions));
					}
					return this.hashtable[dimensions] as ShellProperty<string>;
				}
			}

			// Token: 0x17000328 RID: 808
			// (get) Token: 0x06000754 RID: 1876 RVA: 0x0001D53C File Offset: 0x0001B73C
			public ShellProperty<double?> HorizontalResolution
			{
				get
				{
					PropertyKey horizontalResolution = SystemProperties.System.Image.HorizontalResolution;
					if (!this.hashtable.ContainsKey(horizontalResolution))
					{
						this.hashtable.Add(horizontalResolution, this.shellObjectParent.Properties.CreateTypedProperty<double?>(horizontalResolution));
					}
					return this.hashtable[horizontalResolution] as ShellProperty<double?>;
				}
			}

			// Token: 0x17000329 RID: 809
			// (get) Token: 0x06000755 RID: 1877 RVA: 0x0001D5A4 File Offset: 0x0001B7A4
			public ShellProperty<uint?> HorizontalSize
			{
				get
				{
					PropertyKey horizontalSize = SystemProperties.System.Image.HorizontalSize;
					if (!this.hashtable.ContainsKey(horizontalSize))
					{
						this.hashtable.Add(horizontalSize, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(horizontalSize));
					}
					return this.hashtable[horizontalSize] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700032A RID: 810
			// (get) Token: 0x06000756 RID: 1878 RVA: 0x0001D60C File Offset: 0x0001B80C
			public ShellProperty<string> ImageID
			{
				get
				{
					PropertyKey imageID = SystemProperties.System.Image.ImageID;
					if (!this.hashtable.ContainsKey(imageID))
					{
						this.hashtable.Add(imageID, this.shellObjectParent.Properties.CreateTypedProperty<string>(imageID));
					}
					return this.hashtable[imageID] as ShellProperty<string>;
				}
			}

			// Token: 0x1700032B RID: 811
			// (get) Token: 0x06000757 RID: 1879 RVA: 0x0001D674 File Offset: 0x0001B874
			public ShellProperty<short?> ResolutionUnit
			{
				get
				{
					PropertyKey resolutionUnit = SystemProperties.System.Image.ResolutionUnit;
					if (!this.hashtable.ContainsKey(resolutionUnit))
					{
						this.hashtable.Add(resolutionUnit, this.shellObjectParent.Properties.CreateTypedProperty<short?>(resolutionUnit));
					}
					return this.hashtable[resolutionUnit] as ShellProperty<short?>;
				}
			}

			// Token: 0x1700032C RID: 812
			// (get) Token: 0x06000758 RID: 1880 RVA: 0x0001D6DC File Offset: 0x0001B8DC
			public ShellProperty<double?> VerticalResolution
			{
				get
				{
					PropertyKey verticalResolution = SystemProperties.System.Image.VerticalResolution;
					if (!this.hashtable.ContainsKey(verticalResolution))
					{
						this.hashtable.Add(verticalResolution, this.shellObjectParent.Properties.CreateTypedProperty<double?>(verticalResolution));
					}
					return this.hashtable[verticalResolution] as ShellProperty<double?>;
				}
			}

			// Token: 0x1700032D RID: 813
			// (get) Token: 0x06000759 RID: 1881 RVA: 0x0001D744 File Offset: 0x0001B944
			public ShellProperty<uint?> VerticalSize
			{
				get
				{
					PropertyKey verticalSize = SystemProperties.System.Image.VerticalSize;
					if (!this.hashtable.ContainsKey(verticalSize))
					{
						this.hashtable.Add(verticalSize, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(verticalSize));
					}
					return this.hashtable[verticalSize] as ShellProperty<uint?>;
				}
			}

			// Token: 0x0400037D RID: 893
			private ShellObject shellObjectParent;

			// Token: 0x0400037E RID: 894
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000C0 RID: 192
		public class PropertySystemJournal : PropertyStoreItems
		{
			// Token: 0x0600075A RID: 1882 RVA: 0x0001D7AC File Offset: 0x0001B9AC
			internal PropertySystemJournal(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700032E RID: 814
			// (get) Token: 0x0600075B RID: 1883 RVA: 0x0001D7CC File Offset: 0x0001B9CC
			public ShellProperty<string[]> Contacts
			{
				get
				{
					PropertyKey contacts = SystemProperties.System.Journal.Contacts;
					if (!this.hashtable.ContainsKey(contacts))
					{
						this.hashtable.Add(contacts, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(contacts));
					}
					return this.hashtable[contacts] as ShellProperty<string[]>;
				}
			}

			// Token: 0x1700032F RID: 815
			// (get) Token: 0x0600075C RID: 1884 RVA: 0x0001D834 File Offset: 0x0001BA34
			public ShellProperty<string> EntryType
			{
				get
				{
					PropertyKey entryType = SystemProperties.System.Journal.EntryType;
					if (!this.hashtable.ContainsKey(entryType))
					{
						this.hashtable.Add(entryType, this.shellObjectParent.Properties.CreateTypedProperty<string>(entryType));
					}
					return this.hashtable[entryType] as ShellProperty<string>;
				}
			}

			// Token: 0x0400037F RID: 895
			private ShellObject shellObjectParent;

			// Token: 0x04000380 RID: 896
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000C1 RID: 193
		public class PropertySystemLayoutPattern : PropertyStoreItems
		{
			// Token: 0x0600075D RID: 1885 RVA: 0x0001D89C File Offset: 0x0001BA9C
			internal PropertySystemLayoutPattern(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000330 RID: 816
			// (get) Token: 0x0600075E RID: 1886 RVA: 0x0001D8BC File Offset: 0x0001BABC
			public ShellProperty<string> ContentViewModeForBrowse
			{
				get
				{
					PropertyKey contentViewModeForBrowse = SystemProperties.System.LayoutPattern.ContentViewModeForBrowse;
					if (!this.hashtable.ContainsKey(contentViewModeForBrowse))
					{
						this.hashtable.Add(contentViewModeForBrowse, this.shellObjectParent.Properties.CreateTypedProperty<string>(contentViewModeForBrowse));
					}
					return this.hashtable[contentViewModeForBrowse] as ShellProperty<string>;
				}
			}

			// Token: 0x17000331 RID: 817
			// (get) Token: 0x0600075F RID: 1887 RVA: 0x0001D924 File Offset: 0x0001BB24
			public ShellProperty<string> ContentViewModeForSearch
			{
				get
				{
					PropertyKey contentViewModeForSearch = SystemProperties.System.LayoutPattern.ContentViewModeForSearch;
					if (!this.hashtable.ContainsKey(contentViewModeForSearch))
					{
						this.hashtable.Add(contentViewModeForSearch, this.shellObjectParent.Properties.CreateTypedProperty<string>(contentViewModeForSearch));
					}
					return this.hashtable[contentViewModeForSearch] as ShellProperty<string>;
				}
			}

			// Token: 0x04000381 RID: 897
			private ShellObject shellObjectParent;

			// Token: 0x04000382 RID: 898
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000C2 RID: 194
		public class PropertySystemLink : PropertyStoreItems
		{
			// Token: 0x06000760 RID: 1888 RVA: 0x0001D98C File Offset: 0x0001BB8C
			internal PropertySystemLink(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000332 RID: 818
			// (get) Token: 0x06000761 RID: 1889 RVA: 0x0001D9AC File Offset: 0x0001BBAC
			public ShellProperty<string> Arguments
			{
				get
				{
					PropertyKey arguments = SystemProperties.System.Link.Arguments;
					if (!this.hashtable.ContainsKey(arguments))
					{
						this.hashtable.Add(arguments, this.shellObjectParent.Properties.CreateTypedProperty<string>(arguments));
					}
					return this.hashtable[arguments] as ShellProperty<string>;
				}
			}

			// Token: 0x17000333 RID: 819
			// (get) Token: 0x06000762 RID: 1890 RVA: 0x0001DA14 File Offset: 0x0001BC14
			public ShellProperty<string> Comment
			{
				get
				{
					PropertyKey comment = SystemProperties.System.Link.Comment;
					if (!this.hashtable.ContainsKey(comment))
					{
						this.hashtable.Add(comment, this.shellObjectParent.Properties.CreateTypedProperty<string>(comment));
					}
					return this.hashtable[comment] as ShellProperty<string>;
				}
			}

			// Token: 0x17000334 RID: 820
			// (get) Token: 0x06000763 RID: 1891 RVA: 0x0001DA7C File Offset: 0x0001BC7C
			public ShellProperty<DateTime?> DateVisited
			{
				get
				{
					PropertyKey dateVisited = SystemProperties.System.Link.DateVisited;
					if (!this.hashtable.ContainsKey(dateVisited))
					{
						this.hashtable.Add(dateVisited, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateVisited));
					}
					return this.hashtable[dateVisited] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000335 RID: 821
			// (get) Token: 0x06000764 RID: 1892 RVA: 0x0001DAE4 File Offset: 0x0001BCE4
			public ShellProperty<string> Description
			{
				get
				{
					PropertyKey description = SystemProperties.System.Link.Description;
					if (!this.hashtable.ContainsKey(description))
					{
						this.hashtable.Add(description, this.shellObjectParent.Properties.CreateTypedProperty<string>(description));
					}
					return this.hashtable[description] as ShellProperty<string>;
				}
			}

			// Token: 0x17000336 RID: 822
			// (get) Token: 0x06000765 RID: 1893 RVA: 0x0001DB4C File Offset: 0x0001BD4C
			public ShellProperty<int?> Status
			{
				get
				{
					PropertyKey status = SystemProperties.System.Link.Status;
					if (!this.hashtable.ContainsKey(status))
					{
						this.hashtable.Add(status, this.shellObjectParent.Properties.CreateTypedProperty<int?>(status));
					}
					return this.hashtable[status] as ShellProperty<int?>;
				}
			}

			// Token: 0x17000337 RID: 823
			// (get) Token: 0x06000766 RID: 1894 RVA: 0x0001DBB4 File Offset: 0x0001BDB4
			public ShellProperty<string[]> TargetExtension
			{
				get
				{
					PropertyKey targetExtension = SystemProperties.System.Link.TargetExtension;
					if (!this.hashtable.ContainsKey(targetExtension))
					{
						this.hashtable.Add(targetExtension, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(targetExtension));
					}
					return this.hashtable[targetExtension] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000338 RID: 824
			// (get) Token: 0x06000767 RID: 1895 RVA: 0x0001DC1C File Offset: 0x0001BE1C
			public ShellProperty<string> TargetParsingPath
			{
				get
				{
					PropertyKey targetParsingPath = SystemProperties.System.Link.TargetParsingPath;
					if (!this.hashtable.ContainsKey(targetParsingPath))
					{
						this.hashtable.Add(targetParsingPath, this.shellObjectParent.Properties.CreateTypedProperty<string>(targetParsingPath));
					}
					return this.hashtable[targetParsingPath] as ShellProperty<string>;
				}
			}

			// Token: 0x17000339 RID: 825
			// (get) Token: 0x06000768 RID: 1896 RVA: 0x0001DC84 File Offset: 0x0001BE84
			public ShellProperty<uint?> TargetSFGAOFlags
			{
				get
				{
					PropertyKey targetSFGAOFlags = SystemProperties.System.Link.TargetSFGAOFlags;
					if (!this.hashtable.ContainsKey(targetSFGAOFlags))
					{
						this.hashtable.Add(targetSFGAOFlags, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(targetSFGAOFlags));
					}
					return this.hashtable[targetSFGAOFlags] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700033A RID: 826
			// (get) Token: 0x06000769 RID: 1897 RVA: 0x0001DCEC File Offset: 0x0001BEEC
			public ShellProperty<string[]> TargetSFGAOFlagsStrings
			{
				get
				{
					PropertyKey targetSFGAOFlagsStrings = SystemProperties.System.Link.TargetSFGAOFlagsStrings;
					if (!this.hashtable.ContainsKey(targetSFGAOFlagsStrings))
					{
						this.hashtable.Add(targetSFGAOFlagsStrings, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(targetSFGAOFlagsStrings));
					}
					return this.hashtable[targetSFGAOFlagsStrings] as ShellProperty<string[]>;
				}
			}

			// Token: 0x1700033B RID: 827
			// (get) Token: 0x0600076A RID: 1898 RVA: 0x0001DD54 File Offset: 0x0001BF54
			public ShellProperty<string> TargetUrl
			{
				get
				{
					PropertyKey targetUrl = SystemProperties.System.Link.TargetUrl;
					if (!this.hashtable.ContainsKey(targetUrl))
					{
						this.hashtable.Add(targetUrl, this.shellObjectParent.Properties.CreateTypedProperty<string>(targetUrl));
					}
					return this.hashtable[targetUrl] as ShellProperty<string>;
				}
			}

			// Token: 0x04000383 RID: 899
			private ShellObject shellObjectParent;

			// Token: 0x04000384 RID: 900
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000C3 RID: 195
		public class PropertySystemMedia : PropertyStoreItems
		{
			// Token: 0x0600076B RID: 1899 RVA: 0x0001DDBC File Offset: 0x0001BFBC
			internal PropertySystemMedia(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700033C RID: 828
			// (get) Token: 0x0600076C RID: 1900 RVA: 0x0001DDDC File Offset: 0x0001BFDC
			public ShellProperty<string> AuthorUrl
			{
				get
				{
					PropertyKey authorUrl = SystemProperties.System.Media.AuthorUrl;
					if (!this.hashtable.ContainsKey(authorUrl))
					{
						this.hashtable.Add(authorUrl, this.shellObjectParent.Properties.CreateTypedProperty<string>(authorUrl));
					}
					return this.hashtable[authorUrl] as ShellProperty<string>;
				}
			}

			// Token: 0x1700033D RID: 829
			// (get) Token: 0x0600076D RID: 1901 RVA: 0x0001DE44 File Offset: 0x0001C044
			public ShellProperty<uint?> AverageLevel
			{
				get
				{
					PropertyKey averageLevel = SystemProperties.System.Media.AverageLevel;
					if (!this.hashtable.ContainsKey(averageLevel))
					{
						this.hashtable.Add(averageLevel, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(averageLevel));
					}
					return this.hashtable[averageLevel] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700033E RID: 830
			// (get) Token: 0x0600076E RID: 1902 RVA: 0x0001DEAC File Offset: 0x0001C0AC
			public ShellProperty<string> ClassPrimaryID
			{
				get
				{
					PropertyKey classPrimaryID = SystemProperties.System.Media.ClassPrimaryID;
					if (!this.hashtable.ContainsKey(classPrimaryID))
					{
						this.hashtable.Add(classPrimaryID, this.shellObjectParent.Properties.CreateTypedProperty<string>(classPrimaryID));
					}
					return this.hashtable[classPrimaryID] as ShellProperty<string>;
				}
			}

			// Token: 0x1700033F RID: 831
			// (get) Token: 0x0600076F RID: 1903 RVA: 0x0001DF14 File Offset: 0x0001C114
			public ShellProperty<string> ClassSecondaryID
			{
				get
				{
					PropertyKey classSecondaryID = SystemProperties.System.Media.ClassSecondaryID;
					if (!this.hashtable.ContainsKey(classSecondaryID))
					{
						this.hashtable.Add(classSecondaryID, this.shellObjectParent.Properties.CreateTypedProperty<string>(classSecondaryID));
					}
					return this.hashtable[classSecondaryID] as ShellProperty<string>;
				}
			}

			// Token: 0x17000340 RID: 832
			// (get) Token: 0x06000770 RID: 1904 RVA: 0x0001DF7C File Offset: 0x0001C17C
			public ShellProperty<string> CollectionGroupID
			{
				get
				{
					PropertyKey collectionGroupID = SystemProperties.System.Media.CollectionGroupID;
					if (!this.hashtable.ContainsKey(collectionGroupID))
					{
						this.hashtable.Add(collectionGroupID, this.shellObjectParent.Properties.CreateTypedProperty<string>(collectionGroupID));
					}
					return this.hashtable[collectionGroupID] as ShellProperty<string>;
				}
			}

			// Token: 0x17000341 RID: 833
			// (get) Token: 0x06000771 RID: 1905 RVA: 0x0001DFE4 File Offset: 0x0001C1E4
			public ShellProperty<string> CollectionID
			{
				get
				{
					PropertyKey collectionID = SystemProperties.System.Media.CollectionID;
					if (!this.hashtable.ContainsKey(collectionID))
					{
						this.hashtable.Add(collectionID, this.shellObjectParent.Properties.CreateTypedProperty<string>(collectionID));
					}
					return this.hashtable[collectionID] as ShellProperty<string>;
				}
			}

			// Token: 0x17000342 RID: 834
			// (get) Token: 0x06000772 RID: 1906 RVA: 0x0001E04C File Offset: 0x0001C24C
			public ShellProperty<string> ContentDistributor
			{
				get
				{
					PropertyKey contentDistributor = SystemProperties.System.Media.ContentDistributor;
					if (!this.hashtable.ContainsKey(contentDistributor))
					{
						this.hashtable.Add(contentDistributor, this.shellObjectParent.Properties.CreateTypedProperty<string>(contentDistributor));
					}
					return this.hashtable[contentDistributor] as ShellProperty<string>;
				}
			}

			// Token: 0x17000343 RID: 835
			// (get) Token: 0x06000773 RID: 1907 RVA: 0x0001E0B4 File Offset: 0x0001C2B4
			public ShellProperty<string> ContentID
			{
				get
				{
					PropertyKey contentID = SystemProperties.System.Media.ContentID;
					if (!this.hashtable.ContainsKey(contentID))
					{
						this.hashtable.Add(contentID, this.shellObjectParent.Properties.CreateTypedProperty<string>(contentID));
					}
					return this.hashtable[contentID] as ShellProperty<string>;
				}
			}

			// Token: 0x17000344 RID: 836
			// (get) Token: 0x06000774 RID: 1908 RVA: 0x0001E11C File Offset: 0x0001C31C
			public ShellProperty<string> CreatorApplication
			{
				get
				{
					PropertyKey creatorApplication = SystemProperties.System.Media.CreatorApplication;
					if (!this.hashtable.ContainsKey(creatorApplication))
					{
						this.hashtable.Add(creatorApplication, this.shellObjectParent.Properties.CreateTypedProperty<string>(creatorApplication));
					}
					return this.hashtable[creatorApplication] as ShellProperty<string>;
				}
			}

			// Token: 0x17000345 RID: 837
			// (get) Token: 0x06000775 RID: 1909 RVA: 0x0001E184 File Offset: 0x0001C384
			public ShellProperty<string> CreatorApplicationVersion
			{
				get
				{
					PropertyKey creatorApplicationVersion = SystemProperties.System.Media.CreatorApplicationVersion;
					if (!this.hashtable.ContainsKey(creatorApplicationVersion))
					{
						this.hashtable.Add(creatorApplicationVersion, this.shellObjectParent.Properties.CreateTypedProperty<string>(creatorApplicationVersion));
					}
					return this.hashtable[creatorApplicationVersion] as ShellProperty<string>;
				}
			}

			// Token: 0x17000346 RID: 838
			// (get) Token: 0x06000776 RID: 1910 RVA: 0x0001E1EC File Offset: 0x0001C3EC
			public ShellProperty<DateTime?> DateEncoded
			{
				get
				{
					PropertyKey dateEncoded = SystemProperties.System.Media.DateEncoded;
					if (!this.hashtable.ContainsKey(dateEncoded))
					{
						this.hashtable.Add(dateEncoded, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateEncoded));
					}
					return this.hashtable[dateEncoded] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000347 RID: 839
			// (get) Token: 0x06000777 RID: 1911 RVA: 0x0001E254 File Offset: 0x0001C454
			public ShellProperty<string> DateReleased
			{
				get
				{
					PropertyKey dateReleased = SystemProperties.System.Media.DateReleased;
					if (!this.hashtable.ContainsKey(dateReleased))
					{
						this.hashtable.Add(dateReleased, this.shellObjectParent.Properties.CreateTypedProperty<string>(dateReleased));
					}
					return this.hashtable[dateReleased] as ShellProperty<string>;
				}
			}

			// Token: 0x17000348 RID: 840
			// (get) Token: 0x06000778 RID: 1912 RVA: 0x0001E2BC File Offset: 0x0001C4BC
			public ShellProperty<ulong?> Duration
			{
				get
				{
					PropertyKey duration = SystemProperties.System.Media.Duration;
					if (!this.hashtable.ContainsKey(duration))
					{
						this.hashtable.Add(duration, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(duration));
					}
					return this.hashtable[duration] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x17000349 RID: 841
			// (get) Token: 0x06000779 RID: 1913 RVA: 0x0001E324 File Offset: 0x0001C524
			public ShellProperty<string> DVDID
			{
				get
				{
					PropertyKey dvdid = SystemProperties.System.Media.DVDID;
					if (!this.hashtable.ContainsKey(dvdid))
					{
						this.hashtable.Add(dvdid, this.shellObjectParent.Properties.CreateTypedProperty<string>(dvdid));
					}
					return this.hashtable[dvdid] as ShellProperty<string>;
				}
			}

			// Token: 0x1700034A RID: 842
			// (get) Token: 0x0600077A RID: 1914 RVA: 0x0001E38C File Offset: 0x0001C58C
			public ShellProperty<string> EncodedBy
			{
				get
				{
					PropertyKey encodedBy = SystemProperties.System.Media.EncodedBy;
					if (!this.hashtable.ContainsKey(encodedBy))
					{
						this.hashtable.Add(encodedBy, this.shellObjectParent.Properties.CreateTypedProperty<string>(encodedBy));
					}
					return this.hashtable[encodedBy] as ShellProperty<string>;
				}
			}

			// Token: 0x1700034B RID: 843
			// (get) Token: 0x0600077B RID: 1915 RVA: 0x0001E3F4 File Offset: 0x0001C5F4
			public ShellProperty<string> EncodingSettings
			{
				get
				{
					PropertyKey encodingSettings = SystemProperties.System.Media.EncodingSettings;
					if (!this.hashtable.ContainsKey(encodingSettings))
					{
						this.hashtable.Add(encodingSettings, this.shellObjectParent.Properties.CreateTypedProperty<string>(encodingSettings));
					}
					return this.hashtable[encodingSettings] as ShellProperty<string>;
				}
			}

			// Token: 0x1700034C RID: 844
			// (get) Token: 0x0600077C RID: 1916 RVA: 0x0001E45C File Offset: 0x0001C65C
			public ShellProperty<uint?> FrameCount
			{
				get
				{
					PropertyKey frameCount = SystemProperties.System.Media.FrameCount;
					if (!this.hashtable.ContainsKey(frameCount))
					{
						this.hashtable.Add(frameCount, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(frameCount));
					}
					return this.hashtable[frameCount] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700034D RID: 845
			// (get) Token: 0x0600077D RID: 1917 RVA: 0x0001E4C4 File Offset: 0x0001C6C4
			public ShellProperty<string> MCDI
			{
				get
				{
					PropertyKey mcdi = SystemProperties.System.Media.MCDI;
					if (!this.hashtable.ContainsKey(mcdi))
					{
						this.hashtable.Add(mcdi, this.shellObjectParent.Properties.CreateTypedProperty<string>(mcdi));
					}
					return this.hashtable[mcdi] as ShellProperty<string>;
				}
			}

			// Token: 0x1700034E RID: 846
			// (get) Token: 0x0600077E RID: 1918 RVA: 0x0001E52C File Offset: 0x0001C72C
			public ShellProperty<string> MetadataContentProvider
			{
				get
				{
					PropertyKey metadataContentProvider = SystemProperties.System.Media.MetadataContentProvider;
					if (!this.hashtable.ContainsKey(metadataContentProvider))
					{
						this.hashtable.Add(metadataContentProvider, this.shellObjectParent.Properties.CreateTypedProperty<string>(metadataContentProvider));
					}
					return this.hashtable[metadataContentProvider] as ShellProperty<string>;
				}
			}

			// Token: 0x1700034F RID: 847
			// (get) Token: 0x0600077F RID: 1919 RVA: 0x0001E594 File Offset: 0x0001C794
			public ShellProperty<string[]> Producer
			{
				get
				{
					PropertyKey producer = SystemProperties.System.Media.Producer;
					if (!this.hashtable.ContainsKey(producer))
					{
						this.hashtable.Add(producer, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(producer));
					}
					return this.hashtable[producer] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000350 RID: 848
			// (get) Token: 0x06000780 RID: 1920 RVA: 0x0001E5FC File Offset: 0x0001C7FC
			public ShellProperty<string> PromotionUrl
			{
				get
				{
					PropertyKey promotionUrl = SystemProperties.System.Media.PromotionUrl;
					if (!this.hashtable.ContainsKey(promotionUrl))
					{
						this.hashtable.Add(promotionUrl, this.shellObjectParent.Properties.CreateTypedProperty<string>(promotionUrl));
					}
					return this.hashtable[promotionUrl] as ShellProperty<string>;
				}
			}

			// Token: 0x17000351 RID: 849
			// (get) Token: 0x06000781 RID: 1921 RVA: 0x0001E664 File Offset: 0x0001C864
			public ShellProperty<string> ProtectionType
			{
				get
				{
					PropertyKey protectionType = SystemProperties.System.Media.ProtectionType;
					if (!this.hashtable.ContainsKey(protectionType))
					{
						this.hashtable.Add(protectionType, this.shellObjectParent.Properties.CreateTypedProperty<string>(protectionType));
					}
					return this.hashtable[protectionType] as ShellProperty<string>;
				}
			}

			// Token: 0x17000352 RID: 850
			// (get) Token: 0x06000782 RID: 1922 RVA: 0x0001E6CC File Offset: 0x0001C8CC
			public ShellProperty<string> ProviderRating
			{
				get
				{
					PropertyKey providerRating = SystemProperties.System.Media.ProviderRating;
					if (!this.hashtable.ContainsKey(providerRating))
					{
						this.hashtable.Add(providerRating, this.shellObjectParent.Properties.CreateTypedProperty<string>(providerRating));
					}
					return this.hashtable[providerRating] as ShellProperty<string>;
				}
			}

			// Token: 0x17000353 RID: 851
			// (get) Token: 0x06000783 RID: 1923 RVA: 0x0001E734 File Offset: 0x0001C934
			public ShellProperty<string> ProviderStyle
			{
				get
				{
					PropertyKey providerStyle = SystemProperties.System.Media.ProviderStyle;
					if (!this.hashtable.ContainsKey(providerStyle))
					{
						this.hashtable.Add(providerStyle, this.shellObjectParent.Properties.CreateTypedProperty<string>(providerStyle));
					}
					return this.hashtable[providerStyle] as ShellProperty<string>;
				}
			}

			// Token: 0x17000354 RID: 852
			// (get) Token: 0x06000784 RID: 1924 RVA: 0x0001E79C File Offset: 0x0001C99C
			public ShellProperty<string> Publisher
			{
				get
				{
					PropertyKey publisher = SystemProperties.System.Media.Publisher;
					if (!this.hashtable.ContainsKey(publisher))
					{
						this.hashtable.Add(publisher, this.shellObjectParent.Properties.CreateTypedProperty<string>(publisher));
					}
					return this.hashtable[publisher] as ShellProperty<string>;
				}
			}

			// Token: 0x17000355 RID: 853
			// (get) Token: 0x06000785 RID: 1925 RVA: 0x0001E804 File Offset: 0x0001CA04
			public ShellProperty<string> SubscriptionContentId
			{
				get
				{
					PropertyKey subscriptionContentId = SystemProperties.System.Media.SubscriptionContentId;
					if (!this.hashtable.ContainsKey(subscriptionContentId))
					{
						this.hashtable.Add(subscriptionContentId, this.shellObjectParent.Properties.CreateTypedProperty<string>(subscriptionContentId));
					}
					return this.hashtable[subscriptionContentId] as ShellProperty<string>;
				}
			}

			// Token: 0x17000356 RID: 854
			// (get) Token: 0x06000786 RID: 1926 RVA: 0x0001E86C File Offset: 0x0001CA6C
			public ShellProperty<string> Subtitle
			{
				get
				{
					PropertyKey subtitle = SystemProperties.System.Media.Subtitle;
					if (!this.hashtable.ContainsKey(subtitle))
					{
						this.hashtable.Add(subtitle, this.shellObjectParent.Properties.CreateTypedProperty<string>(subtitle));
					}
					return this.hashtable[subtitle] as ShellProperty<string>;
				}
			}

			// Token: 0x17000357 RID: 855
			// (get) Token: 0x06000787 RID: 1927 RVA: 0x0001E8D4 File Offset: 0x0001CAD4
			public ShellProperty<string> UniqueFileIdentifier
			{
				get
				{
					PropertyKey uniqueFileIdentifier = SystemProperties.System.Media.UniqueFileIdentifier;
					if (!this.hashtable.ContainsKey(uniqueFileIdentifier))
					{
						this.hashtable.Add(uniqueFileIdentifier, this.shellObjectParent.Properties.CreateTypedProperty<string>(uniqueFileIdentifier));
					}
					return this.hashtable[uniqueFileIdentifier] as ShellProperty<string>;
				}
			}

			// Token: 0x17000358 RID: 856
			// (get) Token: 0x06000788 RID: 1928 RVA: 0x0001E93C File Offset: 0x0001CB3C
			public ShellProperty<string> UserNoAutoInfo
			{
				get
				{
					PropertyKey userNoAutoInfo = SystemProperties.System.Media.UserNoAutoInfo;
					if (!this.hashtable.ContainsKey(userNoAutoInfo))
					{
						this.hashtable.Add(userNoAutoInfo, this.shellObjectParent.Properties.CreateTypedProperty<string>(userNoAutoInfo));
					}
					return this.hashtable[userNoAutoInfo] as ShellProperty<string>;
				}
			}

			// Token: 0x17000359 RID: 857
			// (get) Token: 0x06000789 RID: 1929 RVA: 0x0001E9A4 File Offset: 0x0001CBA4
			public ShellProperty<string> UserWebUrl
			{
				get
				{
					PropertyKey userWebUrl = SystemProperties.System.Media.UserWebUrl;
					if (!this.hashtable.ContainsKey(userWebUrl))
					{
						this.hashtable.Add(userWebUrl, this.shellObjectParent.Properties.CreateTypedProperty<string>(userWebUrl));
					}
					return this.hashtable[userWebUrl] as ShellProperty<string>;
				}
			}

			// Token: 0x1700035A RID: 858
			// (get) Token: 0x0600078A RID: 1930 RVA: 0x0001EA0C File Offset: 0x0001CC0C
			public ShellProperty<string[]> Writer
			{
				get
				{
					PropertyKey writer = SystemProperties.System.Media.Writer;
					if (!this.hashtable.ContainsKey(writer))
					{
						this.hashtable.Add(writer, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(writer));
					}
					return this.hashtable[writer] as ShellProperty<string[]>;
				}
			}

			// Token: 0x1700035B RID: 859
			// (get) Token: 0x0600078B RID: 1931 RVA: 0x0001EA74 File Offset: 0x0001CC74
			public ShellProperty<uint?> Year
			{
				get
				{
					PropertyKey year = SystemProperties.System.Media.Year;
					if (!this.hashtable.ContainsKey(year))
					{
						this.hashtable.Add(year, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(year));
					}
					return this.hashtable[year] as ShellProperty<uint?>;
				}
			}

			// Token: 0x04000385 RID: 901
			private ShellObject shellObjectParent;

			// Token: 0x04000386 RID: 902
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000C4 RID: 196
		public class PropertySystemMessage : PropertyStoreItems
		{
			// Token: 0x0600078C RID: 1932 RVA: 0x0001EADC File Offset: 0x0001CCDC
			internal PropertySystemMessage(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700035C RID: 860
			// (get) Token: 0x0600078D RID: 1933 RVA: 0x0001EAFC File Offset: 0x0001CCFC
			public ShellProperty<string> AttachmentContents
			{
				get
				{
					PropertyKey attachmentContents = SystemProperties.System.Message.AttachmentContents;
					if (!this.hashtable.ContainsKey(attachmentContents))
					{
						this.hashtable.Add(attachmentContents, this.shellObjectParent.Properties.CreateTypedProperty<string>(attachmentContents));
					}
					return this.hashtable[attachmentContents] as ShellProperty<string>;
				}
			}

			// Token: 0x1700035D RID: 861
			// (get) Token: 0x0600078E RID: 1934 RVA: 0x0001EB64 File Offset: 0x0001CD64
			public ShellProperty<string[]> AttachmentNames
			{
				get
				{
					PropertyKey attachmentNames = SystemProperties.System.Message.AttachmentNames;
					if (!this.hashtable.ContainsKey(attachmentNames))
					{
						this.hashtable.Add(attachmentNames, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(attachmentNames));
					}
					return this.hashtable[attachmentNames] as ShellProperty<string[]>;
				}
			}

			// Token: 0x1700035E RID: 862
			// (get) Token: 0x0600078F RID: 1935 RVA: 0x0001EBCC File Offset: 0x0001CDCC
			public ShellProperty<string[]> BccAddress
			{
				get
				{
					PropertyKey bccAddress = SystemProperties.System.Message.BccAddress;
					if (!this.hashtable.ContainsKey(bccAddress))
					{
						this.hashtable.Add(bccAddress, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(bccAddress));
					}
					return this.hashtable[bccAddress] as ShellProperty<string[]>;
				}
			}

			// Token: 0x1700035F RID: 863
			// (get) Token: 0x06000790 RID: 1936 RVA: 0x0001EC34 File Offset: 0x0001CE34
			public ShellProperty<string[]> BccName
			{
				get
				{
					PropertyKey bccName = SystemProperties.System.Message.BccName;
					if (!this.hashtable.ContainsKey(bccName))
					{
						this.hashtable.Add(bccName, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(bccName));
					}
					return this.hashtable[bccName] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000360 RID: 864
			// (get) Token: 0x06000791 RID: 1937 RVA: 0x0001EC9C File Offset: 0x0001CE9C
			public ShellProperty<string[]> CcAddress
			{
				get
				{
					PropertyKey ccAddress = SystemProperties.System.Message.CcAddress;
					if (!this.hashtable.ContainsKey(ccAddress))
					{
						this.hashtable.Add(ccAddress, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(ccAddress));
					}
					return this.hashtable[ccAddress] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000361 RID: 865
			// (get) Token: 0x06000792 RID: 1938 RVA: 0x0001ED04 File Offset: 0x0001CF04
			public ShellProperty<string[]> CcName
			{
				get
				{
					PropertyKey ccName = SystemProperties.System.Message.CcName;
					if (!this.hashtable.ContainsKey(ccName))
					{
						this.hashtable.Add(ccName, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(ccName));
					}
					return this.hashtable[ccName] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000362 RID: 866
			// (get) Token: 0x06000793 RID: 1939 RVA: 0x0001ED6C File Offset: 0x0001CF6C
			public ShellProperty<string> ConversationID
			{
				get
				{
					PropertyKey conversationID = SystemProperties.System.Message.ConversationID;
					if (!this.hashtable.ContainsKey(conversationID))
					{
						this.hashtable.Add(conversationID, this.shellObjectParent.Properties.CreateTypedProperty<string>(conversationID));
					}
					return this.hashtable[conversationID] as ShellProperty<string>;
				}
			}

			// Token: 0x17000363 RID: 867
			// (get) Token: 0x06000794 RID: 1940 RVA: 0x0001EDD4 File Offset: 0x0001CFD4
			public ShellProperty<byte[]> ConversationIndex
			{
				get
				{
					PropertyKey conversationIndex = SystemProperties.System.Message.ConversationIndex;
					if (!this.hashtable.ContainsKey(conversationIndex))
					{
						this.hashtable.Add(conversationIndex, this.shellObjectParent.Properties.CreateTypedProperty<byte[]>(conversationIndex));
					}
					return this.hashtable[conversationIndex] as ShellProperty<byte[]>;
				}
			}

			// Token: 0x17000364 RID: 868
			// (get) Token: 0x06000795 RID: 1941 RVA: 0x0001EE3C File Offset: 0x0001D03C
			public ShellProperty<DateTime?> DateReceived
			{
				get
				{
					PropertyKey dateReceived = SystemProperties.System.Message.DateReceived;
					if (!this.hashtable.ContainsKey(dateReceived))
					{
						this.hashtable.Add(dateReceived, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateReceived));
					}
					return this.hashtable[dateReceived] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000365 RID: 869
			// (get) Token: 0x06000796 RID: 1942 RVA: 0x0001EEA4 File Offset: 0x0001D0A4
			public ShellProperty<DateTime?> DateSent
			{
				get
				{
					PropertyKey dateSent = SystemProperties.System.Message.DateSent;
					if (!this.hashtable.ContainsKey(dateSent))
					{
						this.hashtable.Add(dateSent, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateSent));
					}
					return this.hashtable[dateSent] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000366 RID: 870
			// (get) Token: 0x06000797 RID: 1943 RVA: 0x0001EF0C File Offset: 0x0001D10C
			public ShellProperty<int?> Flags
			{
				get
				{
					PropertyKey flags = SystemProperties.System.Message.Flags;
					if (!this.hashtable.ContainsKey(flags))
					{
						this.hashtable.Add(flags, this.shellObjectParent.Properties.CreateTypedProperty<int?>(flags));
					}
					return this.hashtable[flags] as ShellProperty<int?>;
				}
			}

			// Token: 0x17000367 RID: 871
			// (get) Token: 0x06000798 RID: 1944 RVA: 0x0001EF74 File Offset: 0x0001D174
			public ShellProperty<string[]> FromAddress
			{
				get
				{
					PropertyKey fromAddress = SystemProperties.System.Message.FromAddress;
					if (!this.hashtable.ContainsKey(fromAddress))
					{
						this.hashtable.Add(fromAddress, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(fromAddress));
					}
					return this.hashtable[fromAddress] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000368 RID: 872
			// (get) Token: 0x06000799 RID: 1945 RVA: 0x0001EFDC File Offset: 0x0001D1DC
			public ShellProperty<string[]> FromName
			{
				get
				{
					PropertyKey fromName = SystemProperties.System.Message.FromName;
					if (!this.hashtable.ContainsKey(fromName))
					{
						this.hashtable.Add(fromName, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(fromName));
					}
					return this.hashtable[fromName] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000369 RID: 873
			// (get) Token: 0x0600079A RID: 1946 RVA: 0x0001F044 File Offset: 0x0001D244
			public ShellProperty<bool?> HasAttachments
			{
				get
				{
					PropertyKey hasAttachments = SystemProperties.System.Message.HasAttachments;
					if (!this.hashtable.ContainsKey(hasAttachments))
					{
						this.hashtable.Add(hasAttachments, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(hasAttachments));
					}
					return this.hashtable[hasAttachments] as ShellProperty<bool?>;
				}
			}

			// Token: 0x1700036A RID: 874
			// (get) Token: 0x0600079B RID: 1947 RVA: 0x0001F0AC File Offset: 0x0001D2AC
			public ShellProperty<int?> IsFwdOrReply
			{
				get
				{
					PropertyKey isFwdOrReply = SystemProperties.System.Message.IsFwdOrReply;
					if (!this.hashtable.ContainsKey(isFwdOrReply))
					{
						this.hashtable.Add(isFwdOrReply, this.shellObjectParent.Properties.CreateTypedProperty<int?>(isFwdOrReply));
					}
					return this.hashtable[isFwdOrReply] as ShellProperty<int?>;
				}
			}

			// Token: 0x1700036B RID: 875
			// (get) Token: 0x0600079C RID: 1948 RVA: 0x0001F114 File Offset: 0x0001D314
			public ShellProperty<string> MessageClass
			{
				get
				{
					PropertyKey messageClass = SystemProperties.System.Message.MessageClass;
					if (!this.hashtable.ContainsKey(messageClass))
					{
						this.hashtable.Add(messageClass, this.shellObjectParent.Properties.CreateTypedProperty<string>(messageClass));
					}
					return this.hashtable[messageClass] as ShellProperty<string>;
				}
			}

			// Token: 0x1700036C RID: 876
			// (get) Token: 0x0600079D RID: 1949 RVA: 0x0001F17C File Offset: 0x0001D37C
			public ShellProperty<bool?> ProofInProgress
			{
				get
				{
					PropertyKey proofInProgress = SystemProperties.System.Message.ProofInProgress;
					if (!this.hashtable.ContainsKey(proofInProgress))
					{
						this.hashtable.Add(proofInProgress, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(proofInProgress));
					}
					return this.hashtable[proofInProgress] as ShellProperty<bool?>;
				}
			}

			// Token: 0x1700036D RID: 877
			// (get) Token: 0x0600079E RID: 1950 RVA: 0x0001F1E4 File Offset: 0x0001D3E4
			public ShellProperty<string> SenderAddress
			{
				get
				{
					PropertyKey senderAddress = SystemProperties.System.Message.SenderAddress;
					if (!this.hashtable.ContainsKey(senderAddress))
					{
						this.hashtable.Add(senderAddress, this.shellObjectParent.Properties.CreateTypedProperty<string>(senderAddress));
					}
					return this.hashtable[senderAddress] as ShellProperty<string>;
				}
			}

			// Token: 0x1700036E RID: 878
			// (get) Token: 0x0600079F RID: 1951 RVA: 0x0001F24C File Offset: 0x0001D44C
			public ShellProperty<string> SenderName
			{
				get
				{
					PropertyKey senderName = SystemProperties.System.Message.SenderName;
					if (!this.hashtable.ContainsKey(senderName))
					{
						this.hashtable.Add(senderName, this.shellObjectParent.Properties.CreateTypedProperty<string>(senderName));
					}
					return this.hashtable[senderName] as ShellProperty<string>;
				}
			}

			// Token: 0x1700036F RID: 879
			// (get) Token: 0x060007A0 RID: 1952 RVA: 0x0001F2B4 File Offset: 0x0001D4B4
			public ShellProperty<string> Store
			{
				get
				{
					PropertyKey store = SystemProperties.System.Message.Store;
					if (!this.hashtable.ContainsKey(store))
					{
						this.hashtable.Add(store, this.shellObjectParent.Properties.CreateTypedProperty<string>(store));
					}
					return this.hashtable[store] as ShellProperty<string>;
				}
			}

			// Token: 0x17000370 RID: 880
			// (get) Token: 0x060007A1 RID: 1953 RVA: 0x0001F31C File Offset: 0x0001D51C
			public ShellProperty<string[]> ToAddress
			{
				get
				{
					PropertyKey toAddress = SystemProperties.System.Message.ToAddress;
					if (!this.hashtable.ContainsKey(toAddress))
					{
						this.hashtable.Add(toAddress, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(toAddress));
					}
					return this.hashtable[toAddress] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000371 RID: 881
			// (get) Token: 0x060007A2 RID: 1954 RVA: 0x0001F384 File Offset: 0x0001D584
			public ShellProperty<int?> ToDoFlags
			{
				get
				{
					PropertyKey toDoFlags = SystemProperties.System.Message.ToDoFlags;
					if (!this.hashtable.ContainsKey(toDoFlags))
					{
						this.hashtable.Add(toDoFlags, this.shellObjectParent.Properties.CreateTypedProperty<int?>(toDoFlags));
					}
					return this.hashtable[toDoFlags] as ShellProperty<int?>;
				}
			}

			// Token: 0x17000372 RID: 882
			// (get) Token: 0x060007A3 RID: 1955 RVA: 0x0001F3EC File Offset: 0x0001D5EC
			public ShellProperty<string> ToDoTitle
			{
				get
				{
					PropertyKey toDoTitle = SystemProperties.System.Message.ToDoTitle;
					if (!this.hashtable.ContainsKey(toDoTitle))
					{
						this.hashtable.Add(toDoTitle, this.shellObjectParent.Properties.CreateTypedProperty<string>(toDoTitle));
					}
					return this.hashtable[toDoTitle] as ShellProperty<string>;
				}
			}

			// Token: 0x17000373 RID: 883
			// (get) Token: 0x060007A4 RID: 1956 RVA: 0x0001F454 File Offset: 0x0001D654
			public ShellProperty<string[]> ToName
			{
				get
				{
					PropertyKey toName = SystemProperties.System.Message.ToName;
					if (!this.hashtable.ContainsKey(toName))
					{
						this.hashtable.Add(toName, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(toName));
					}
					return this.hashtable[toName] as ShellProperty<string[]>;
				}
			}

			// Token: 0x04000387 RID: 903
			private ShellObject shellObjectParent;

			// Token: 0x04000388 RID: 904
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000C5 RID: 197
		public class PropertySystemMusic : PropertyStoreItems
		{
			// Token: 0x060007A5 RID: 1957 RVA: 0x0001F4BC File Offset: 0x0001D6BC
			internal PropertySystemMusic(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000374 RID: 884
			// (get) Token: 0x060007A6 RID: 1958 RVA: 0x0001F4DC File Offset: 0x0001D6DC
			public ShellProperty<string> AlbumArtist
			{
				get
				{
					PropertyKey albumArtist = SystemProperties.System.Music.AlbumArtist;
					if (!this.hashtable.ContainsKey(albumArtist))
					{
						this.hashtable.Add(albumArtist, this.shellObjectParent.Properties.CreateTypedProperty<string>(albumArtist));
					}
					return this.hashtable[albumArtist] as ShellProperty<string>;
				}
			}

			// Token: 0x17000375 RID: 885
			// (get) Token: 0x060007A7 RID: 1959 RVA: 0x0001F544 File Offset: 0x0001D744
			public ShellProperty<string> AlbumID
			{
				get
				{
					PropertyKey albumID = SystemProperties.System.Music.AlbumID;
					if (!this.hashtable.ContainsKey(albumID))
					{
						this.hashtable.Add(albumID, this.shellObjectParent.Properties.CreateTypedProperty<string>(albumID));
					}
					return this.hashtable[albumID] as ShellProperty<string>;
				}
			}

			// Token: 0x17000376 RID: 886
			// (get) Token: 0x060007A8 RID: 1960 RVA: 0x0001F5AC File Offset: 0x0001D7AC
			public ShellProperty<string> AlbumTitle
			{
				get
				{
					PropertyKey albumTitle = SystemProperties.System.Music.AlbumTitle;
					if (!this.hashtable.ContainsKey(albumTitle))
					{
						this.hashtable.Add(albumTitle, this.shellObjectParent.Properties.CreateTypedProperty<string>(albumTitle));
					}
					return this.hashtable[albumTitle] as ShellProperty<string>;
				}
			}

			// Token: 0x17000377 RID: 887
			// (get) Token: 0x060007A9 RID: 1961 RVA: 0x0001F614 File Offset: 0x0001D814
			public ShellProperty<string[]> Artist
			{
				get
				{
					PropertyKey artist = SystemProperties.System.Music.Artist;
					if (!this.hashtable.ContainsKey(artist))
					{
						this.hashtable.Add(artist, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(artist));
					}
					return this.hashtable[artist] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000378 RID: 888
			// (get) Token: 0x060007AA RID: 1962 RVA: 0x0001F67C File Offset: 0x0001D87C
			public ShellProperty<string> BeatsPerMinute
			{
				get
				{
					PropertyKey beatsPerMinute = SystemProperties.System.Music.BeatsPerMinute;
					if (!this.hashtable.ContainsKey(beatsPerMinute))
					{
						this.hashtable.Add(beatsPerMinute, this.shellObjectParent.Properties.CreateTypedProperty<string>(beatsPerMinute));
					}
					return this.hashtable[beatsPerMinute] as ShellProperty<string>;
				}
			}

			// Token: 0x17000379 RID: 889
			// (get) Token: 0x060007AB RID: 1963 RVA: 0x0001F6E4 File Offset: 0x0001D8E4
			public ShellProperty<string[]> Composer
			{
				get
				{
					PropertyKey composer = SystemProperties.System.Music.Composer;
					if (!this.hashtable.ContainsKey(composer))
					{
						this.hashtable.Add(composer, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(composer));
					}
					return this.hashtable[composer] as ShellProperty<string[]>;
				}
			}

			// Token: 0x1700037A RID: 890
			// (get) Token: 0x060007AC RID: 1964 RVA: 0x0001F74C File Offset: 0x0001D94C
			public ShellProperty<string[]> Conductor
			{
				get
				{
					PropertyKey conductor = SystemProperties.System.Music.Conductor;
					if (!this.hashtable.ContainsKey(conductor))
					{
						this.hashtable.Add(conductor, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(conductor));
					}
					return this.hashtable[conductor] as ShellProperty<string[]>;
				}
			}

			// Token: 0x1700037B RID: 891
			// (get) Token: 0x060007AD RID: 1965 RVA: 0x0001F7B4 File Offset: 0x0001D9B4
			public ShellProperty<string> ContentGroupDescription
			{
				get
				{
					PropertyKey contentGroupDescription = SystemProperties.System.Music.ContentGroupDescription;
					if (!this.hashtable.ContainsKey(contentGroupDescription))
					{
						this.hashtable.Add(contentGroupDescription, this.shellObjectParent.Properties.CreateTypedProperty<string>(contentGroupDescription));
					}
					return this.hashtable[contentGroupDescription] as ShellProperty<string>;
				}
			}

			// Token: 0x1700037C RID: 892
			// (get) Token: 0x060007AE RID: 1966 RVA: 0x0001F81C File Offset: 0x0001DA1C
			public ShellProperty<string> DisplayArtist
			{
				get
				{
					PropertyKey displayArtist = SystemProperties.System.Music.DisplayArtist;
					if (!this.hashtable.ContainsKey(displayArtist))
					{
						this.hashtable.Add(displayArtist, this.shellObjectParent.Properties.CreateTypedProperty<string>(displayArtist));
					}
					return this.hashtable[displayArtist] as ShellProperty<string>;
				}
			}

			// Token: 0x1700037D RID: 893
			// (get) Token: 0x060007AF RID: 1967 RVA: 0x0001F884 File Offset: 0x0001DA84
			public ShellProperty<string[]> Genre
			{
				get
				{
					PropertyKey genre = SystemProperties.System.Music.Genre;
					if (!this.hashtable.ContainsKey(genre))
					{
						this.hashtable.Add(genre, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(genre));
					}
					return this.hashtable[genre] as ShellProperty<string[]>;
				}
			}

			// Token: 0x1700037E RID: 894
			// (get) Token: 0x060007B0 RID: 1968 RVA: 0x0001F8EC File Offset: 0x0001DAEC
			public ShellProperty<string> InitialKey
			{
				get
				{
					PropertyKey initialKey = SystemProperties.System.Music.InitialKey;
					if (!this.hashtable.ContainsKey(initialKey))
					{
						this.hashtable.Add(initialKey, this.shellObjectParent.Properties.CreateTypedProperty<string>(initialKey));
					}
					return this.hashtable[initialKey] as ShellProperty<string>;
				}
			}

			// Token: 0x1700037F RID: 895
			// (get) Token: 0x060007B1 RID: 1969 RVA: 0x0001F954 File Offset: 0x0001DB54
			public ShellProperty<bool?> IsCompilation
			{
				get
				{
					PropertyKey isCompilation = SystemProperties.System.Music.IsCompilation;
					if (!this.hashtable.ContainsKey(isCompilation))
					{
						this.hashtable.Add(isCompilation, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isCompilation));
					}
					return this.hashtable[isCompilation] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000380 RID: 896
			// (get) Token: 0x060007B2 RID: 1970 RVA: 0x0001F9BC File Offset: 0x0001DBBC
			public ShellProperty<string> Lyrics
			{
				get
				{
					PropertyKey lyrics = SystemProperties.System.Music.Lyrics;
					if (!this.hashtable.ContainsKey(lyrics))
					{
						this.hashtable.Add(lyrics, this.shellObjectParent.Properties.CreateTypedProperty<string>(lyrics));
					}
					return this.hashtable[lyrics] as ShellProperty<string>;
				}
			}

			// Token: 0x17000381 RID: 897
			// (get) Token: 0x060007B3 RID: 1971 RVA: 0x0001FA24 File Offset: 0x0001DC24
			public ShellProperty<string> Mood
			{
				get
				{
					PropertyKey mood = SystemProperties.System.Music.Mood;
					if (!this.hashtable.ContainsKey(mood))
					{
						this.hashtable.Add(mood, this.shellObjectParent.Properties.CreateTypedProperty<string>(mood));
					}
					return this.hashtable[mood] as ShellProperty<string>;
				}
			}

			// Token: 0x17000382 RID: 898
			// (get) Token: 0x060007B4 RID: 1972 RVA: 0x0001FA8C File Offset: 0x0001DC8C
			public ShellProperty<string> PartOfSet
			{
				get
				{
					PropertyKey partOfSet = SystemProperties.System.Music.PartOfSet;
					if (!this.hashtable.ContainsKey(partOfSet))
					{
						this.hashtable.Add(partOfSet, this.shellObjectParent.Properties.CreateTypedProperty<string>(partOfSet));
					}
					return this.hashtable[partOfSet] as ShellProperty<string>;
				}
			}

			// Token: 0x17000383 RID: 899
			// (get) Token: 0x060007B5 RID: 1973 RVA: 0x0001FAF4 File Offset: 0x0001DCF4
			public ShellProperty<string> Period
			{
				get
				{
					PropertyKey period = SystemProperties.System.Music.Period;
					if (!this.hashtable.ContainsKey(period))
					{
						this.hashtable.Add(period, this.shellObjectParent.Properties.CreateTypedProperty<string>(period));
					}
					return this.hashtable[period] as ShellProperty<string>;
				}
			}

			// Token: 0x17000384 RID: 900
			// (get) Token: 0x060007B6 RID: 1974 RVA: 0x0001FB5C File Offset: 0x0001DD5C
			public ShellProperty<byte[]> SynchronizedLyrics
			{
				get
				{
					PropertyKey synchronizedLyrics = SystemProperties.System.Music.SynchronizedLyrics;
					if (!this.hashtable.ContainsKey(synchronizedLyrics))
					{
						this.hashtable.Add(synchronizedLyrics, this.shellObjectParent.Properties.CreateTypedProperty<byte[]>(synchronizedLyrics));
					}
					return this.hashtable[synchronizedLyrics] as ShellProperty<byte[]>;
				}
			}

			// Token: 0x17000385 RID: 901
			// (get) Token: 0x060007B7 RID: 1975 RVA: 0x0001FBC4 File Offset: 0x0001DDC4
			public ShellProperty<uint?> TrackNumber
			{
				get
				{
					PropertyKey trackNumber = SystemProperties.System.Music.TrackNumber;
					if (!this.hashtable.ContainsKey(trackNumber))
					{
						this.hashtable.Add(trackNumber, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(trackNumber));
					}
					return this.hashtable[trackNumber] as ShellProperty<uint?>;
				}
			}

			// Token: 0x04000389 RID: 905
			private ShellObject shellObjectParent;

			// Token: 0x0400038A RID: 906
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000C6 RID: 198
		public class PropertySystemNote : PropertyStoreItems
		{
			// Token: 0x060007B8 RID: 1976 RVA: 0x0001FC2C File Offset: 0x0001DE2C
			internal PropertySystemNote(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000386 RID: 902
			// (get) Token: 0x060007B9 RID: 1977 RVA: 0x0001FC4C File Offset: 0x0001DE4C
			public ShellProperty<ushort?> Color
			{
				get
				{
					PropertyKey color = SystemProperties.System.Note.Color;
					if (!this.hashtable.ContainsKey(color))
					{
						this.hashtable.Add(color, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(color));
					}
					return this.hashtable[color] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x17000387 RID: 903
			// (get) Token: 0x060007BA RID: 1978 RVA: 0x0001FCB4 File Offset: 0x0001DEB4
			public ShellProperty<string> ColorText
			{
				get
				{
					PropertyKey colorText = SystemProperties.System.Note.ColorText;
					if (!this.hashtable.ContainsKey(colorText))
					{
						this.hashtable.Add(colorText, this.shellObjectParent.Properties.CreateTypedProperty<string>(colorText));
					}
					return this.hashtable[colorText] as ShellProperty<string>;
				}
			}

			// Token: 0x0400038B RID: 907
			private ShellObject shellObjectParent;

			// Token: 0x0400038C RID: 908
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000C7 RID: 199
		public class PropertySystemPhoto : PropertyStoreItems
		{
			// Token: 0x060007BB RID: 1979 RVA: 0x0001FD1C File Offset: 0x0001DF1C
			internal PropertySystemPhoto(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000388 RID: 904
			// (get) Token: 0x060007BC RID: 1980 RVA: 0x0001FD3C File Offset: 0x0001DF3C
			public ShellProperty<double?> Aperture
			{
				get
				{
					PropertyKey aperture = SystemProperties.System.Photo.Aperture;
					if (!this.hashtable.ContainsKey(aperture))
					{
						this.hashtable.Add(aperture, this.shellObjectParent.Properties.CreateTypedProperty<double?>(aperture));
					}
					return this.hashtable[aperture] as ShellProperty<double?>;
				}
			}

			// Token: 0x17000389 RID: 905
			// (get) Token: 0x060007BD RID: 1981 RVA: 0x0001FDA4 File Offset: 0x0001DFA4
			public ShellProperty<uint?> ApertureDenominator
			{
				get
				{
					PropertyKey apertureDenominator = SystemProperties.System.Photo.ApertureDenominator;
					if (!this.hashtable.ContainsKey(apertureDenominator))
					{
						this.hashtable.Add(apertureDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(apertureDenominator));
					}
					return this.hashtable[apertureDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700038A RID: 906
			// (get) Token: 0x060007BE RID: 1982 RVA: 0x0001FE0C File Offset: 0x0001E00C
			public ShellProperty<uint?> ApertureNumerator
			{
				get
				{
					PropertyKey apertureNumerator = SystemProperties.System.Photo.ApertureNumerator;
					if (!this.hashtable.ContainsKey(apertureNumerator))
					{
						this.hashtable.Add(apertureNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(apertureNumerator));
					}
					return this.hashtable[apertureNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700038B RID: 907
			// (get) Token: 0x060007BF RID: 1983 RVA: 0x0001FE74 File Offset: 0x0001E074
			public ShellProperty<double?> Brightness
			{
				get
				{
					PropertyKey brightness = SystemProperties.System.Photo.Brightness;
					if (!this.hashtable.ContainsKey(brightness))
					{
						this.hashtable.Add(brightness, this.shellObjectParent.Properties.CreateTypedProperty<double?>(brightness));
					}
					return this.hashtable[brightness] as ShellProperty<double?>;
				}
			}

			// Token: 0x1700038C RID: 908
			// (get) Token: 0x060007C0 RID: 1984 RVA: 0x0001FEDC File Offset: 0x0001E0DC
			public ShellProperty<uint?> BrightnessDenominator
			{
				get
				{
					PropertyKey brightnessDenominator = SystemProperties.System.Photo.BrightnessDenominator;
					if (!this.hashtable.ContainsKey(brightnessDenominator))
					{
						this.hashtable.Add(brightnessDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(brightnessDenominator));
					}
					return this.hashtable[brightnessDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700038D RID: 909
			// (get) Token: 0x060007C1 RID: 1985 RVA: 0x0001FF44 File Offset: 0x0001E144
			public ShellProperty<uint?> BrightnessNumerator
			{
				get
				{
					PropertyKey brightnessNumerator = SystemProperties.System.Photo.BrightnessNumerator;
					if (!this.hashtable.ContainsKey(brightnessNumerator))
					{
						this.hashtable.Add(brightnessNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(brightnessNumerator));
					}
					return this.hashtable[brightnessNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700038E RID: 910
			// (get) Token: 0x060007C2 RID: 1986 RVA: 0x0001FFAC File Offset: 0x0001E1AC
			public ShellProperty<string> CameraManufacturer
			{
				get
				{
					PropertyKey cameraManufacturer = SystemProperties.System.Photo.CameraManufacturer;
					if (!this.hashtable.ContainsKey(cameraManufacturer))
					{
						this.hashtable.Add(cameraManufacturer, this.shellObjectParent.Properties.CreateTypedProperty<string>(cameraManufacturer));
					}
					return this.hashtable[cameraManufacturer] as ShellProperty<string>;
				}
			}

			// Token: 0x1700038F RID: 911
			// (get) Token: 0x060007C3 RID: 1987 RVA: 0x00020014 File Offset: 0x0001E214
			public ShellProperty<string> CameraModel
			{
				get
				{
					PropertyKey cameraModel = SystemProperties.System.Photo.CameraModel;
					if (!this.hashtable.ContainsKey(cameraModel))
					{
						this.hashtable.Add(cameraModel, this.shellObjectParent.Properties.CreateTypedProperty<string>(cameraModel));
					}
					return this.hashtable[cameraModel] as ShellProperty<string>;
				}
			}

			// Token: 0x17000390 RID: 912
			// (get) Token: 0x060007C4 RID: 1988 RVA: 0x0002007C File Offset: 0x0001E27C
			public ShellProperty<string> CameraSerialNumber
			{
				get
				{
					PropertyKey cameraSerialNumber = SystemProperties.System.Photo.CameraSerialNumber;
					if (!this.hashtable.ContainsKey(cameraSerialNumber))
					{
						this.hashtable.Add(cameraSerialNumber, this.shellObjectParent.Properties.CreateTypedProperty<string>(cameraSerialNumber));
					}
					return this.hashtable[cameraSerialNumber] as ShellProperty<string>;
				}
			}

			// Token: 0x17000391 RID: 913
			// (get) Token: 0x060007C5 RID: 1989 RVA: 0x000200E4 File Offset: 0x0001E2E4
			public ShellProperty<uint?> Contrast
			{
				get
				{
					PropertyKey contrast = SystemProperties.System.Photo.Contrast;
					if (!this.hashtable.ContainsKey(contrast))
					{
						this.hashtable.Add(contrast, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(contrast));
					}
					return this.hashtable[contrast] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000392 RID: 914
			// (get) Token: 0x060007C6 RID: 1990 RVA: 0x0002014C File Offset: 0x0001E34C
			public ShellProperty<string> ContrastText
			{
				get
				{
					PropertyKey contrastText = SystemProperties.System.Photo.ContrastText;
					if (!this.hashtable.ContainsKey(contrastText))
					{
						this.hashtable.Add(contrastText, this.shellObjectParent.Properties.CreateTypedProperty<string>(contrastText));
					}
					return this.hashtable[contrastText] as ShellProperty<string>;
				}
			}

			// Token: 0x17000393 RID: 915
			// (get) Token: 0x060007C7 RID: 1991 RVA: 0x000201B4 File Offset: 0x0001E3B4
			public ShellProperty<DateTime?> DateTaken
			{
				get
				{
					PropertyKey dateTaken = SystemProperties.System.Photo.DateTaken;
					if (!this.hashtable.ContainsKey(dateTaken))
					{
						this.hashtable.Add(dateTaken, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateTaken));
					}
					return this.hashtable[dateTaken] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000394 RID: 916
			// (get) Token: 0x060007C8 RID: 1992 RVA: 0x0002021C File Offset: 0x0001E41C
			public ShellProperty<double?> DigitalZoom
			{
				get
				{
					PropertyKey digitalZoom = SystemProperties.System.Photo.DigitalZoom;
					if (!this.hashtable.ContainsKey(digitalZoom))
					{
						this.hashtable.Add(digitalZoom, this.shellObjectParent.Properties.CreateTypedProperty<double?>(digitalZoom));
					}
					return this.hashtable[digitalZoom] as ShellProperty<double?>;
				}
			}

			// Token: 0x17000395 RID: 917
			// (get) Token: 0x060007C9 RID: 1993 RVA: 0x00020284 File Offset: 0x0001E484
			public ShellProperty<uint?> DigitalZoomDenominator
			{
				get
				{
					PropertyKey digitalZoomDenominator = SystemProperties.System.Photo.DigitalZoomDenominator;
					if (!this.hashtable.ContainsKey(digitalZoomDenominator))
					{
						this.hashtable.Add(digitalZoomDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(digitalZoomDenominator));
					}
					return this.hashtable[digitalZoomDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000396 RID: 918
			// (get) Token: 0x060007CA RID: 1994 RVA: 0x000202EC File Offset: 0x0001E4EC
			public ShellProperty<uint?> DigitalZoomNumerator
			{
				get
				{
					PropertyKey digitalZoomNumerator = SystemProperties.System.Photo.DigitalZoomNumerator;
					if (!this.hashtable.ContainsKey(digitalZoomNumerator))
					{
						this.hashtable.Add(digitalZoomNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(digitalZoomNumerator));
					}
					return this.hashtable[digitalZoomNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000397 RID: 919
			// (get) Token: 0x060007CB RID: 1995 RVA: 0x00020354 File Offset: 0x0001E554
			public ShellProperty<string[]> Event
			{
				get
				{
					PropertyKey @event = SystemProperties.System.Photo.Event;
					if (!this.hashtable.ContainsKey(@event))
					{
						this.hashtable.Add(@event, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(@event));
					}
					return this.hashtable[@event] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000398 RID: 920
			// (get) Token: 0x060007CC RID: 1996 RVA: 0x000203BC File Offset: 0x0001E5BC
			public ShellProperty<string> EXIFVersion
			{
				get
				{
					PropertyKey exifversion = SystemProperties.System.Photo.EXIFVersion;
					if (!this.hashtable.ContainsKey(exifversion))
					{
						this.hashtable.Add(exifversion, this.shellObjectParent.Properties.CreateTypedProperty<string>(exifversion));
					}
					return this.hashtable[exifversion] as ShellProperty<string>;
				}
			}

			// Token: 0x17000399 RID: 921
			// (get) Token: 0x060007CD RID: 1997 RVA: 0x00020424 File Offset: 0x0001E624
			public ShellProperty<double?> ExposureBias
			{
				get
				{
					PropertyKey exposureBias = SystemProperties.System.Photo.ExposureBias;
					if (!this.hashtable.ContainsKey(exposureBias))
					{
						this.hashtable.Add(exposureBias, this.shellObjectParent.Properties.CreateTypedProperty<double?>(exposureBias));
					}
					return this.hashtable[exposureBias] as ShellProperty<double?>;
				}
			}

			// Token: 0x1700039A RID: 922
			// (get) Token: 0x060007CE RID: 1998 RVA: 0x0002048C File Offset: 0x0001E68C
			public ShellProperty<int?> ExposureBiasDenominator
			{
				get
				{
					PropertyKey exposureBiasDenominator = SystemProperties.System.Photo.ExposureBiasDenominator;
					if (!this.hashtable.ContainsKey(exposureBiasDenominator))
					{
						this.hashtable.Add(exposureBiasDenominator, this.shellObjectParent.Properties.CreateTypedProperty<int?>(exposureBiasDenominator));
					}
					return this.hashtable[exposureBiasDenominator] as ShellProperty<int?>;
				}
			}

			// Token: 0x1700039B RID: 923
			// (get) Token: 0x060007CF RID: 1999 RVA: 0x000204F4 File Offset: 0x0001E6F4
			public ShellProperty<int?> ExposureBiasNumerator
			{
				get
				{
					PropertyKey exposureBiasNumerator = SystemProperties.System.Photo.ExposureBiasNumerator;
					if (!this.hashtable.ContainsKey(exposureBiasNumerator))
					{
						this.hashtable.Add(exposureBiasNumerator, this.shellObjectParent.Properties.CreateTypedProperty<int?>(exposureBiasNumerator));
					}
					return this.hashtable[exposureBiasNumerator] as ShellProperty<int?>;
				}
			}

			// Token: 0x1700039C RID: 924
			// (get) Token: 0x060007D0 RID: 2000 RVA: 0x0002055C File Offset: 0x0001E75C
			public ShellProperty<double?> ExposureIndex
			{
				get
				{
					PropertyKey exposureIndex = SystemProperties.System.Photo.ExposureIndex;
					if (!this.hashtable.ContainsKey(exposureIndex))
					{
						this.hashtable.Add(exposureIndex, this.shellObjectParent.Properties.CreateTypedProperty<double?>(exposureIndex));
					}
					return this.hashtable[exposureIndex] as ShellProperty<double?>;
				}
			}

			// Token: 0x1700039D RID: 925
			// (get) Token: 0x060007D1 RID: 2001 RVA: 0x000205C4 File Offset: 0x0001E7C4
			public ShellProperty<uint?> ExposureIndexDenominator
			{
				get
				{
					PropertyKey exposureIndexDenominator = SystemProperties.System.Photo.ExposureIndexDenominator;
					if (!this.hashtable.ContainsKey(exposureIndexDenominator))
					{
						this.hashtable.Add(exposureIndexDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(exposureIndexDenominator));
					}
					return this.hashtable[exposureIndexDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700039E RID: 926
			// (get) Token: 0x060007D2 RID: 2002 RVA: 0x0002062C File Offset: 0x0001E82C
			public ShellProperty<uint?> ExposureIndexNumerator
			{
				get
				{
					PropertyKey exposureIndexNumerator = SystemProperties.System.Photo.ExposureIndexNumerator;
					if (!this.hashtable.ContainsKey(exposureIndexNumerator))
					{
						this.hashtable.Add(exposureIndexNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(exposureIndexNumerator));
					}
					return this.hashtable[exposureIndexNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700039F RID: 927
			// (get) Token: 0x060007D3 RID: 2003 RVA: 0x00020694 File Offset: 0x0001E894
			public ShellProperty<uint?> ExposureProgram
			{
				get
				{
					PropertyKey exposureProgram = SystemProperties.System.Photo.ExposureProgram;
					if (!this.hashtable.ContainsKey(exposureProgram))
					{
						this.hashtable.Add(exposureProgram, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(exposureProgram));
					}
					return this.hashtable[exposureProgram] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003A0 RID: 928
			// (get) Token: 0x060007D4 RID: 2004 RVA: 0x000206FC File Offset: 0x0001E8FC
			public ShellProperty<string> ExposureProgramText
			{
				get
				{
					PropertyKey exposureProgramText = SystemProperties.System.Photo.ExposureProgramText;
					if (!this.hashtable.ContainsKey(exposureProgramText))
					{
						this.hashtable.Add(exposureProgramText, this.shellObjectParent.Properties.CreateTypedProperty<string>(exposureProgramText));
					}
					return this.hashtable[exposureProgramText] as ShellProperty<string>;
				}
			}

			// Token: 0x170003A1 RID: 929
			// (get) Token: 0x060007D5 RID: 2005 RVA: 0x00020764 File Offset: 0x0001E964
			public ShellProperty<double?> ExposureTime
			{
				get
				{
					PropertyKey exposureTime = SystemProperties.System.Photo.ExposureTime;
					if (!this.hashtable.ContainsKey(exposureTime))
					{
						this.hashtable.Add(exposureTime, this.shellObjectParent.Properties.CreateTypedProperty<double?>(exposureTime));
					}
					return this.hashtable[exposureTime] as ShellProperty<double?>;
				}
			}

			// Token: 0x170003A2 RID: 930
			// (get) Token: 0x060007D6 RID: 2006 RVA: 0x000207CC File Offset: 0x0001E9CC
			public ShellProperty<uint?> ExposureTimeDenominator
			{
				get
				{
					PropertyKey exposureTimeDenominator = SystemProperties.System.Photo.ExposureTimeDenominator;
					if (!this.hashtable.ContainsKey(exposureTimeDenominator))
					{
						this.hashtable.Add(exposureTimeDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(exposureTimeDenominator));
					}
					return this.hashtable[exposureTimeDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003A3 RID: 931
			// (get) Token: 0x060007D7 RID: 2007 RVA: 0x00020834 File Offset: 0x0001EA34
			public ShellProperty<uint?> ExposureTimeNumerator
			{
				get
				{
					PropertyKey exposureTimeNumerator = SystemProperties.System.Photo.ExposureTimeNumerator;
					if (!this.hashtable.ContainsKey(exposureTimeNumerator))
					{
						this.hashtable.Add(exposureTimeNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(exposureTimeNumerator));
					}
					return this.hashtable[exposureTimeNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003A4 RID: 932
			// (get) Token: 0x060007D8 RID: 2008 RVA: 0x0002089C File Offset: 0x0001EA9C
			public ShellProperty<byte?> Flash
			{
				get
				{
					PropertyKey flash = SystemProperties.System.Photo.Flash;
					if (!this.hashtable.ContainsKey(flash))
					{
						this.hashtable.Add(flash, this.shellObjectParent.Properties.CreateTypedProperty<byte?>(flash));
					}
					return this.hashtable[flash] as ShellProperty<byte?>;
				}
			}

			// Token: 0x170003A5 RID: 933
			// (get) Token: 0x060007D9 RID: 2009 RVA: 0x00020904 File Offset: 0x0001EB04
			public ShellProperty<double?> FlashEnergy
			{
				get
				{
					PropertyKey flashEnergy = SystemProperties.System.Photo.FlashEnergy;
					if (!this.hashtable.ContainsKey(flashEnergy))
					{
						this.hashtable.Add(flashEnergy, this.shellObjectParent.Properties.CreateTypedProperty<double?>(flashEnergy));
					}
					return this.hashtable[flashEnergy] as ShellProperty<double?>;
				}
			}

			// Token: 0x170003A6 RID: 934
			// (get) Token: 0x060007DA RID: 2010 RVA: 0x0002096C File Offset: 0x0001EB6C
			public ShellProperty<uint?> FlashEnergyDenominator
			{
				get
				{
					PropertyKey flashEnergyDenominator = SystemProperties.System.Photo.FlashEnergyDenominator;
					if (!this.hashtable.ContainsKey(flashEnergyDenominator))
					{
						this.hashtable.Add(flashEnergyDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(flashEnergyDenominator));
					}
					return this.hashtable[flashEnergyDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003A7 RID: 935
			// (get) Token: 0x060007DB RID: 2011 RVA: 0x000209D4 File Offset: 0x0001EBD4
			public ShellProperty<uint?> FlashEnergyNumerator
			{
				get
				{
					PropertyKey flashEnergyNumerator = SystemProperties.System.Photo.FlashEnergyNumerator;
					if (!this.hashtable.ContainsKey(flashEnergyNumerator))
					{
						this.hashtable.Add(flashEnergyNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(flashEnergyNumerator));
					}
					return this.hashtable[flashEnergyNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003A8 RID: 936
			// (get) Token: 0x060007DC RID: 2012 RVA: 0x00020A3C File Offset: 0x0001EC3C
			public ShellProperty<string> FlashManufacturer
			{
				get
				{
					PropertyKey flashManufacturer = SystemProperties.System.Photo.FlashManufacturer;
					if (!this.hashtable.ContainsKey(flashManufacturer))
					{
						this.hashtable.Add(flashManufacturer, this.shellObjectParent.Properties.CreateTypedProperty<string>(flashManufacturer));
					}
					return this.hashtable[flashManufacturer] as ShellProperty<string>;
				}
			}

			// Token: 0x170003A9 RID: 937
			// (get) Token: 0x060007DD RID: 2013 RVA: 0x00020AA4 File Offset: 0x0001ECA4
			public ShellProperty<string> FlashModel
			{
				get
				{
					PropertyKey flashModel = SystemProperties.System.Photo.FlashModel;
					if (!this.hashtable.ContainsKey(flashModel))
					{
						this.hashtable.Add(flashModel, this.shellObjectParent.Properties.CreateTypedProperty<string>(flashModel));
					}
					return this.hashtable[flashModel] as ShellProperty<string>;
				}
			}

			// Token: 0x170003AA RID: 938
			// (get) Token: 0x060007DE RID: 2014 RVA: 0x00020B0C File Offset: 0x0001ED0C
			public ShellProperty<string> FlashText
			{
				get
				{
					PropertyKey flashText = SystemProperties.System.Photo.FlashText;
					if (!this.hashtable.ContainsKey(flashText))
					{
						this.hashtable.Add(flashText, this.shellObjectParent.Properties.CreateTypedProperty<string>(flashText));
					}
					return this.hashtable[flashText] as ShellProperty<string>;
				}
			}

			// Token: 0x170003AB RID: 939
			// (get) Token: 0x060007DF RID: 2015 RVA: 0x00020B74 File Offset: 0x0001ED74
			public ShellProperty<double?> FNumber
			{
				get
				{
					PropertyKey fnumber = SystemProperties.System.Photo.FNumber;
					if (!this.hashtable.ContainsKey(fnumber))
					{
						this.hashtable.Add(fnumber, this.shellObjectParent.Properties.CreateTypedProperty<double?>(fnumber));
					}
					return this.hashtable[fnumber] as ShellProperty<double?>;
				}
			}

			// Token: 0x170003AC RID: 940
			// (get) Token: 0x060007E0 RID: 2016 RVA: 0x00020BDC File Offset: 0x0001EDDC
			public ShellProperty<uint?> FNumberDenominator
			{
				get
				{
					PropertyKey fnumberDenominator = SystemProperties.System.Photo.FNumberDenominator;
					if (!this.hashtable.ContainsKey(fnumberDenominator))
					{
						this.hashtable.Add(fnumberDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(fnumberDenominator));
					}
					return this.hashtable[fnumberDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003AD RID: 941
			// (get) Token: 0x060007E1 RID: 2017 RVA: 0x00020C44 File Offset: 0x0001EE44
			public ShellProperty<uint?> FNumberNumerator
			{
				get
				{
					PropertyKey fnumberNumerator = SystemProperties.System.Photo.FNumberNumerator;
					if (!this.hashtable.ContainsKey(fnumberNumerator))
					{
						this.hashtable.Add(fnumberNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(fnumberNumerator));
					}
					return this.hashtable[fnumberNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003AE RID: 942
			// (get) Token: 0x060007E2 RID: 2018 RVA: 0x00020CAC File Offset: 0x0001EEAC
			public ShellProperty<double?> FocalLength
			{
				get
				{
					PropertyKey focalLength = SystemProperties.System.Photo.FocalLength;
					if (!this.hashtable.ContainsKey(focalLength))
					{
						this.hashtable.Add(focalLength, this.shellObjectParent.Properties.CreateTypedProperty<double?>(focalLength));
					}
					return this.hashtable[focalLength] as ShellProperty<double?>;
				}
			}

			// Token: 0x170003AF RID: 943
			// (get) Token: 0x060007E3 RID: 2019 RVA: 0x00020D14 File Offset: 0x0001EF14
			public ShellProperty<uint?> FocalLengthDenominator
			{
				get
				{
					PropertyKey focalLengthDenominator = SystemProperties.System.Photo.FocalLengthDenominator;
					if (!this.hashtable.ContainsKey(focalLengthDenominator))
					{
						this.hashtable.Add(focalLengthDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(focalLengthDenominator));
					}
					return this.hashtable[focalLengthDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003B0 RID: 944
			// (get) Token: 0x060007E4 RID: 2020 RVA: 0x00020D7C File Offset: 0x0001EF7C
			public ShellProperty<ushort?> FocalLengthInFilm
			{
				get
				{
					PropertyKey focalLengthInFilm = SystemProperties.System.Photo.FocalLengthInFilm;
					if (!this.hashtable.ContainsKey(focalLengthInFilm))
					{
						this.hashtable.Add(focalLengthInFilm, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(focalLengthInFilm));
					}
					return this.hashtable[focalLengthInFilm] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x170003B1 RID: 945
			// (get) Token: 0x060007E5 RID: 2021 RVA: 0x00020DE4 File Offset: 0x0001EFE4
			public ShellProperty<uint?> FocalLengthNumerator
			{
				get
				{
					PropertyKey focalLengthNumerator = SystemProperties.System.Photo.FocalLengthNumerator;
					if (!this.hashtable.ContainsKey(focalLengthNumerator))
					{
						this.hashtable.Add(focalLengthNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(focalLengthNumerator));
					}
					return this.hashtable[focalLengthNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003B2 RID: 946
			// (get) Token: 0x060007E6 RID: 2022 RVA: 0x00020E4C File Offset: 0x0001F04C
			public ShellProperty<double?> FocalPlaneXResolution
			{
				get
				{
					PropertyKey focalPlaneXResolution = SystemProperties.System.Photo.FocalPlaneXResolution;
					if (!this.hashtable.ContainsKey(focalPlaneXResolution))
					{
						this.hashtable.Add(focalPlaneXResolution, this.shellObjectParent.Properties.CreateTypedProperty<double?>(focalPlaneXResolution));
					}
					return this.hashtable[focalPlaneXResolution] as ShellProperty<double?>;
				}
			}

			// Token: 0x170003B3 RID: 947
			// (get) Token: 0x060007E7 RID: 2023 RVA: 0x00020EB4 File Offset: 0x0001F0B4
			public ShellProperty<uint?> FocalPlaneXResolutionDenominator
			{
				get
				{
					PropertyKey focalPlaneXResolutionDenominator = SystemProperties.System.Photo.FocalPlaneXResolutionDenominator;
					if (!this.hashtable.ContainsKey(focalPlaneXResolutionDenominator))
					{
						this.hashtable.Add(focalPlaneXResolutionDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(focalPlaneXResolutionDenominator));
					}
					return this.hashtable[focalPlaneXResolutionDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003B4 RID: 948
			// (get) Token: 0x060007E8 RID: 2024 RVA: 0x00020F1C File Offset: 0x0001F11C
			public ShellProperty<uint?> FocalPlaneXResolutionNumerator
			{
				get
				{
					PropertyKey focalPlaneXResolutionNumerator = SystemProperties.System.Photo.FocalPlaneXResolutionNumerator;
					if (!this.hashtable.ContainsKey(focalPlaneXResolutionNumerator))
					{
						this.hashtable.Add(focalPlaneXResolutionNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(focalPlaneXResolutionNumerator));
					}
					return this.hashtable[focalPlaneXResolutionNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003B5 RID: 949
			// (get) Token: 0x060007E9 RID: 2025 RVA: 0x00020F84 File Offset: 0x0001F184
			public ShellProperty<double?> FocalPlaneYResolution
			{
				get
				{
					PropertyKey focalPlaneYResolution = SystemProperties.System.Photo.FocalPlaneYResolution;
					if (!this.hashtable.ContainsKey(focalPlaneYResolution))
					{
						this.hashtable.Add(focalPlaneYResolution, this.shellObjectParent.Properties.CreateTypedProperty<double?>(focalPlaneYResolution));
					}
					return this.hashtable[focalPlaneYResolution] as ShellProperty<double?>;
				}
			}

			// Token: 0x170003B6 RID: 950
			// (get) Token: 0x060007EA RID: 2026 RVA: 0x00020FEC File Offset: 0x0001F1EC
			public ShellProperty<uint?> FocalPlaneYResolutionDenominator
			{
				get
				{
					PropertyKey focalPlaneYResolutionDenominator = SystemProperties.System.Photo.FocalPlaneYResolutionDenominator;
					if (!this.hashtable.ContainsKey(focalPlaneYResolutionDenominator))
					{
						this.hashtable.Add(focalPlaneYResolutionDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(focalPlaneYResolutionDenominator));
					}
					return this.hashtable[focalPlaneYResolutionDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003B7 RID: 951
			// (get) Token: 0x060007EB RID: 2027 RVA: 0x00021054 File Offset: 0x0001F254
			public ShellProperty<uint?> FocalPlaneYResolutionNumerator
			{
				get
				{
					PropertyKey focalPlaneYResolutionNumerator = SystemProperties.System.Photo.FocalPlaneYResolutionNumerator;
					if (!this.hashtable.ContainsKey(focalPlaneYResolutionNumerator))
					{
						this.hashtable.Add(focalPlaneYResolutionNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(focalPlaneYResolutionNumerator));
					}
					return this.hashtable[focalPlaneYResolutionNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003B8 RID: 952
			// (get) Token: 0x060007EC RID: 2028 RVA: 0x000210BC File Offset: 0x0001F2BC
			public ShellProperty<double?> GainControl
			{
				get
				{
					PropertyKey gainControl = SystemProperties.System.Photo.GainControl;
					if (!this.hashtable.ContainsKey(gainControl))
					{
						this.hashtable.Add(gainControl, this.shellObjectParent.Properties.CreateTypedProperty<double?>(gainControl));
					}
					return this.hashtable[gainControl] as ShellProperty<double?>;
				}
			}

			// Token: 0x170003B9 RID: 953
			// (get) Token: 0x060007ED RID: 2029 RVA: 0x00021124 File Offset: 0x0001F324
			public ShellProperty<uint?> GainControlDenominator
			{
				get
				{
					PropertyKey gainControlDenominator = SystemProperties.System.Photo.GainControlDenominator;
					if (!this.hashtable.ContainsKey(gainControlDenominator))
					{
						this.hashtable.Add(gainControlDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(gainControlDenominator));
					}
					return this.hashtable[gainControlDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003BA RID: 954
			// (get) Token: 0x060007EE RID: 2030 RVA: 0x0002118C File Offset: 0x0001F38C
			public ShellProperty<uint?> GainControlNumerator
			{
				get
				{
					PropertyKey gainControlNumerator = SystemProperties.System.Photo.GainControlNumerator;
					if (!this.hashtable.ContainsKey(gainControlNumerator))
					{
						this.hashtable.Add(gainControlNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(gainControlNumerator));
					}
					return this.hashtable[gainControlNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003BB RID: 955
			// (get) Token: 0x060007EF RID: 2031 RVA: 0x000211F4 File Offset: 0x0001F3F4
			public ShellProperty<string> GainControlText
			{
				get
				{
					PropertyKey gainControlText = SystemProperties.System.Photo.GainControlText;
					if (!this.hashtable.ContainsKey(gainControlText))
					{
						this.hashtable.Add(gainControlText, this.shellObjectParent.Properties.CreateTypedProperty<string>(gainControlText));
					}
					return this.hashtable[gainControlText] as ShellProperty<string>;
				}
			}

			// Token: 0x170003BC RID: 956
			// (get) Token: 0x060007F0 RID: 2032 RVA: 0x0002125C File Offset: 0x0001F45C
			public ShellProperty<ushort?> ISOSpeed
			{
				get
				{
					PropertyKey isospeed = SystemProperties.System.Photo.ISOSpeed;
					if (!this.hashtable.ContainsKey(isospeed))
					{
						this.hashtable.Add(isospeed, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(isospeed));
					}
					return this.hashtable[isospeed] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x170003BD RID: 957
			// (get) Token: 0x060007F1 RID: 2033 RVA: 0x000212C4 File Offset: 0x0001F4C4
			public ShellProperty<string> LensManufacturer
			{
				get
				{
					PropertyKey lensManufacturer = SystemProperties.System.Photo.LensManufacturer;
					if (!this.hashtable.ContainsKey(lensManufacturer))
					{
						this.hashtable.Add(lensManufacturer, this.shellObjectParent.Properties.CreateTypedProperty<string>(lensManufacturer));
					}
					return this.hashtable[lensManufacturer] as ShellProperty<string>;
				}
			}

			// Token: 0x170003BE RID: 958
			// (get) Token: 0x060007F2 RID: 2034 RVA: 0x0002132C File Offset: 0x0001F52C
			public ShellProperty<string> LensModel
			{
				get
				{
					PropertyKey lensModel = SystemProperties.System.Photo.LensModel;
					if (!this.hashtable.ContainsKey(lensModel))
					{
						this.hashtable.Add(lensModel, this.shellObjectParent.Properties.CreateTypedProperty<string>(lensModel));
					}
					return this.hashtable[lensModel] as ShellProperty<string>;
				}
			}

			// Token: 0x170003BF RID: 959
			// (get) Token: 0x060007F3 RID: 2035 RVA: 0x00021394 File Offset: 0x0001F594
			public ShellProperty<uint?> LightSource
			{
				get
				{
					PropertyKey lightSource = SystemProperties.System.Photo.LightSource;
					if (!this.hashtable.ContainsKey(lightSource))
					{
						this.hashtable.Add(lightSource, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(lightSource));
					}
					return this.hashtable[lightSource] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003C0 RID: 960
			// (get) Token: 0x060007F4 RID: 2036 RVA: 0x000213FC File Offset: 0x0001F5FC
			public ShellProperty<byte[]> MakerNote
			{
				get
				{
					PropertyKey makerNote = SystemProperties.System.Photo.MakerNote;
					if (!this.hashtable.ContainsKey(makerNote))
					{
						this.hashtable.Add(makerNote, this.shellObjectParent.Properties.CreateTypedProperty<byte[]>(makerNote));
					}
					return this.hashtable[makerNote] as ShellProperty<byte[]>;
				}
			}

			// Token: 0x170003C1 RID: 961
			// (get) Token: 0x060007F5 RID: 2037 RVA: 0x00021464 File Offset: 0x0001F664
			public ShellProperty<ulong?> MakerNoteOffset
			{
				get
				{
					PropertyKey makerNoteOffset = SystemProperties.System.Photo.MakerNoteOffset;
					if (!this.hashtable.ContainsKey(makerNoteOffset))
					{
						this.hashtable.Add(makerNoteOffset, this.shellObjectParent.Properties.CreateTypedProperty<ulong?>(makerNoteOffset));
					}
					return this.hashtable[makerNoteOffset] as ShellProperty<ulong?>;
				}
			}

			// Token: 0x170003C2 RID: 962
			// (get) Token: 0x060007F6 RID: 2038 RVA: 0x000214CC File Offset: 0x0001F6CC
			public ShellProperty<double?> MaxAperture
			{
				get
				{
					PropertyKey maxAperture = SystemProperties.System.Photo.MaxAperture;
					if (!this.hashtable.ContainsKey(maxAperture))
					{
						this.hashtable.Add(maxAperture, this.shellObjectParent.Properties.CreateTypedProperty<double?>(maxAperture));
					}
					return this.hashtable[maxAperture] as ShellProperty<double?>;
				}
			}

			// Token: 0x170003C3 RID: 963
			// (get) Token: 0x060007F7 RID: 2039 RVA: 0x00021534 File Offset: 0x0001F734
			public ShellProperty<uint?> MaxApertureDenominator
			{
				get
				{
					PropertyKey maxApertureDenominator = SystemProperties.System.Photo.MaxApertureDenominator;
					if (!this.hashtable.ContainsKey(maxApertureDenominator))
					{
						this.hashtable.Add(maxApertureDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(maxApertureDenominator));
					}
					return this.hashtable[maxApertureDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003C4 RID: 964
			// (get) Token: 0x060007F8 RID: 2040 RVA: 0x0002159C File Offset: 0x0001F79C
			public ShellProperty<uint?> MaxApertureNumerator
			{
				get
				{
					PropertyKey maxApertureNumerator = SystemProperties.System.Photo.MaxApertureNumerator;
					if (!this.hashtable.ContainsKey(maxApertureNumerator))
					{
						this.hashtable.Add(maxApertureNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(maxApertureNumerator));
					}
					return this.hashtable[maxApertureNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003C5 RID: 965
			// (get) Token: 0x060007F9 RID: 2041 RVA: 0x00021604 File Offset: 0x0001F804
			public ShellProperty<ushort?> MeteringMode
			{
				get
				{
					PropertyKey meteringMode = SystemProperties.System.Photo.MeteringMode;
					if (!this.hashtable.ContainsKey(meteringMode))
					{
						this.hashtable.Add(meteringMode, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(meteringMode));
					}
					return this.hashtable[meteringMode] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x170003C6 RID: 966
			// (get) Token: 0x060007FA RID: 2042 RVA: 0x0002166C File Offset: 0x0001F86C
			public ShellProperty<string> MeteringModeText
			{
				get
				{
					PropertyKey meteringModeText = SystemProperties.System.Photo.MeteringModeText;
					if (!this.hashtable.ContainsKey(meteringModeText))
					{
						this.hashtable.Add(meteringModeText, this.shellObjectParent.Properties.CreateTypedProperty<string>(meteringModeText));
					}
					return this.hashtable[meteringModeText] as ShellProperty<string>;
				}
			}

			// Token: 0x170003C7 RID: 967
			// (get) Token: 0x060007FB RID: 2043 RVA: 0x000216D4 File Offset: 0x0001F8D4
			public ShellProperty<ushort?> Orientation
			{
				get
				{
					PropertyKey orientation = SystemProperties.System.Photo.Orientation;
					if (!this.hashtable.ContainsKey(orientation))
					{
						this.hashtable.Add(orientation, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(orientation));
					}
					return this.hashtable[orientation] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x170003C8 RID: 968
			// (get) Token: 0x060007FC RID: 2044 RVA: 0x0002173C File Offset: 0x0001F93C
			public ShellProperty<string> OrientationText
			{
				get
				{
					PropertyKey orientationText = SystemProperties.System.Photo.OrientationText;
					if (!this.hashtable.ContainsKey(orientationText))
					{
						this.hashtable.Add(orientationText, this.shellObjectParent.Properties.CreateTypedProperty<string>(orientationText));
					}
					return this.hashtable[orientationText] as ShellProperty<string>;
				}
			}

			// Token: 0x170003C9 RID: 969
			// (get) Token: 0x060007FD RID: 2045 RVA: 0x000217A4 File Offset: 0x0001F9A4
			public ShellProperty<string[]> PeopleNames
			{
				get
				{
					PropertyKey peopleNames = SystemProperties.System.Photo.PeopleNames;
					if (!this.hashtable.ContainsKey(peopleNames))
					{
						this.hashtable.Add(peopleNames, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(peopleNames));
					}
					return this.hashtable[peopleNames] as ShellProperty<string[]>;
				}
			}

			// Token: 0x170003CA RID: 970
			// (get) Token: 0x060007FE RID: 2046 RVA: 0x0002180C File Offset: 0x0001FA0C
			public ShellProperty<ushort?> PhotometricInterpretation
			{
				get
				{
					PropertyKey photometricInterpretation = SystemProperties.System.Photo.PhotometricInterpretation;
					if (!this.hashtable.ContainsKey(photometricInterpretation))
					{
						this.hashtable.Add(photometricInterpretation, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(photometricInterpretation));
					}
					return this.hashtable[photometricInterpretation] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x170003CB RID: 971
			// (get) Token: 0x060007FF RID: 2047 RVA: 0x00021874 File Offset: 0x0001FA74
			public ShellProperty<string> PhotometricInterpretationText
			{
				get
				{
					PropertyKey photometricInterpretationText = SystemProperties.System.Photo.PhotometricInterpretationText;
					if (!this.hashtable.ContainsKey(photometricInterpretationText))
					{
						this.hashtable.Add(photometricInterpretationText, this.shellObjectParent.Properties.CreateTypedProperty<string>(photometricInterpretationText));
					}
					return this.hashtable[photometricInterpretationText] as ShellProperty<string>;
				}
			}

			// Token: 0x170003CC RID: 972
			// (get) Token: 0x06000800 RID: 2048 RVA: 0x000218DC File Offset: 0x0001FADC
			public ShellProperty<uint?> ProgramMode
			{
				get
				{
					PropertyKey programMode = SystemProperties.System.Photo.ProgramMode;
					if (!this.hashtable.ContainsKey(programMode))
					{
						this.hashtable.Add(programMode, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(programMode));
					}
					return this.hashtable[programMode] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003CD RID: 973
			// (get) Token: 0x06000801 RID: 2049 RVA: 0x00021944 File Offset: 0x0001FB44
			public ShellProperty<string> ProgramModeText
			{
				get
				{
					PropertyKey programModeText = SystemProperties.System.Photo.ProgramModeText;
					if (!this.hashtable.ContainsKey(programModeText))
					{
						this.hashtable.Add(programModeText, this.shellObjectParent.Properties.CreateTypedProperty<string>(programModeText));
					}
					return this.hashtable[programModeText] as ShellProperty<string>;
				}
			}

			// Token: 0x170003CE RID: 974
			// (get) Token: 0x06000802 RID: 2050 RVA: 0x000219AC File Offset: 0x0001FBAC
			public ShellProperty<string> RelatedSoundFile
			{
				get
				{
					PropertyKey relatedSoundFile = SystemProperties.System.Photo.RelatedSoundFile;
					if (!this.hashtable.ContainsKey(relatedSoundFile))
					{
						this.hashtable.Add(relatedSoundFile, this.shellObjectParent.Properties.CreateTypedProperty<string>(relatedSoundFile));
					}
					return this.hashtable[relatedSoundFile] as ShellProperty<string>;
				}
			}

			// Token: 0x170003CF RID: 975
			// (get) Token: 0x06000803 RID: 2051 RVA: 0x00021A14 File Offset: 0x0001FC14
			public ShellProperty<uint?> Saturation
			{
				get
				{
					PropertyKey saturation = SystemProperties.System.Photo.Saturation;
					if (!this.hashtable.ContainsKey(saturation))
					{
						this.hashtable.Add(saturation, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(saturation));
					}
					return this.hashtable[saturation] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003D0 RID: 976
			// (get) Token: 0x06000804 RID: 2052 RVA: 0x00021A7C File Offset: 0x0001FC7C
			public ShellProperty<string> SaturationText
			{
				get
				{
					PropertyKey saturationText = SystemProperties.System.Photo.SaturationText;
					if (!this.hashtable.ContainsKey(saturationText))
					{
						this.hashtable.Add(saturationText, this.shellObjectParent.Properties.CreateTypedProperty<string>(saturationText));
					}
					return this.hashtable[saturationText] as ShellProperty<string>;
				}
			}

			// Token: 0x170003D1 RID: 977
			// (get) Token: 0x06000805 RID: 2053 RVA: 0x00021AE4 File Offset: 0x0001FCE4
			public ShellProperty<uint?> Sharpness
			{
				get
				{
					PropertyKey sharpness = SystemProperties.System.Photo.Sharpness;
					if (!this.hashtable.ContainsKey(sharpness))
					{
						this.hashtable.Add(sharpness, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(sharpness));
					}
					return this.hashtable[sharpness] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003D2 RID: 978
			// (get) Token: 0x06000806 RID: 2054 RVA: 0x00021B4C File Offset: 0x0001FD4C
			public ShellProperty<string> SharpnessText
			{
				get
				{
					PropertyKey sharpnessText = SystemProperties.System.Photo.SharpnessText;
					if (!this.hashtable.ContainsKey(sharpnessText))
					{
						this.hashtable.Add(sharpnessText, this.shellObjectParent.Properties.CreateTypedProperty<string>(sharpnessText));
					}
					return this.hashtable[sharpnessText] as ShellProperty<string>;
				}
			}

			// Token: 0x170003D3 RID: 979
			// (get) Token: 0x06000807 RID: 2055 RVA: 0x00021BB4 File Offset: 0x0001FDB4
			public ShellProperty<double?> ShutterSpeed
			{
				get
				{
					PropertyKey shutterSpeed = SystemProperties.System.Photo.ShutterSpeed;
					if (!this.hashtable.ContainsKey(shutterSpeed))
					{
						this.hashtable.Add(shutterSpeed, this.shellObjectParent.Properties.CreateTypedProperty<double?>(shutterSpeed));
					}
					return this.hashtable[shutterSpeed] as ShellProperty<double?>;
				}
			}

			// Token: 0x170003D4 RID: 980
			// (get) Token: 0x06000808 RID: 2056 RVA: 0x00021C1C File Offset: 0x0001FE1C
			public ShellProperty<int?> ShutterSpeedDenominator
			{
				get
				{
					PropertyKey shutterSpeedDenominator = SystemProperties.System.Photo.ShutterSpeedDenominator;
					if (!this.hashtable.ContainsKey(shutterSpeedDenominator))
					{
						this.hashtable.Add(shutterSpeedDenominator, this.shellObjectParent.Properties.CreateTypedProperty<int?>(shutterSpeedDenominator));
					}
					return this.hashtable[shutterSpeedDenominator] as ShellProperty<int?>;
				}
			}

			// Token: 0x170003D5 RID: 981
			// (get) Token: 0x06000809 RID: 2057 RVA: 0x00021C84 File Offset: 0x0001FE84
			public ShellProperty<int?> ShutterSpeedNumerator
			{
				get
				{
					PropertyKey shutterSpeedNumerator = SystemProperties.System.Photo.ShutterSpeedNumerator;
					if (!this.hashtable.ContainsKey(shutterSpeedNumerator))
					{
						this.hashtable.Add(shutterSpeedNumerator, this.shellObjectParent.Properties.CreateTypedProperty<int?>(shutterSpeedNumerator));
					}
					return this.hashtable[shutterSpeedNumerator] as ShellProperty<int?>;
				}
			}

			// Token: 0x170003D6 RID: 982
			// (get) Token: 0x0600080A RID: 2058 RVA: 0x00021CEC File Offset: 0x0001FEEC
			public ShellProperty<double?> SubjectDistance
			{
				get
				{
					PropertyKey subjectDistance = SystemProperties.System.Photo.SubjectDistance;
					if (!this.hashtable.ContainsKey(subjectDistance))
					{
						this.hashtable.Add(subjectDistance, this.shellObjectParent.Properties.CreateTypedProperty<double?>(subjectDistance));
					}
					return this.hashtable[subjectDistance] as ShellProperty<double?>;
				}
			}

			// Token: 0x170003D7 RID: 983
			// (get) Token: 0x0600080B RID: 2059 RVA: 0x00021D54 File Offset: 0x0001FF54
			public ShellProperty<uint?> SubjectDistanceDenominator
			{
				get
				{
					PropertyKey subjectDistanceDenominator = SystemProperties.System.Photo.SubjectDistanceDenominator;
					if (!this.hashtable.ContainsKey(subjectDistanceDenominator))
					{
						this.hashtable.Add(subjectDistanceDenominator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(subjectDistanceDenominator));
					}
					return this.hashtable[subjectDistanceDenominator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003D8 RID: 984
			// (get) Token: 0x0600080C RID: 2060 RVA: 0x00021DBC File Offset: 0x0001FFBC
			public ShellProperty<uint?> SubjectDistanceNumerator
			{
				get
				{
					PropertyKey subjectDistanceNumerator = SystemProperties.System.Photo.SubjectDistanceNumerator;
					if (!this.hashtable.ContainsKey(subjectDistanceNumerator))
					{
						this.hashtable.Add(subjectDistanceNumerator, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(subjectDistanceNumerator));
					}
					return this.hashtable[subjectDistanceNumerator] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003D9 RID: 985
			// (get) Token: 0x0600080D RID: 2061 RVA: 0x00021E24 File Offset: 0x00020024
			public ShellProperty<string[]> TagViewAggregate
			{
				get
				{
					PropertyKey tagViewAggregate = SystemProperties.System.Photo.TagViewAggregate;
					if (!this.hashtable.ContainsKey(tagViewAggregate))
					{
						this.hashtable.Add(tagViewAggregate, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(tagViewAggregate));
					}
					return this.hashtable[tagViewAggregate] as ShellProperty<string[]>;
				}
			}

			// Token: 0x170003DA RID: 986
			// (get) Token: 0x0600080E RID: 2062 RVA: 0x00021E8C File Offset: 0x0002008C
			public ShellProperty<bool?> TranscodedForSync
			{
				get
				{
					PropertyKey transcodedForSync = SystemProperties.System.Photo.TranscodedForSync;
					if (!this.hashtable.ContainsKey(transcodedForSync))
					{
						this.hashtable.Add(transcodedForSync, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(transcodedForSync));
					}
					return this.hashtable[transcodedForSync] as ShellProperty<bool?>;
				}
			}

			// Token: 0x170003DB RID: 987
			// (get) Token: 0x0600080F RID: 2063 RVA: 0x00021EF4 File Offset: 0x000200F4
			public ShellProperty<uint?> WhiteBalance
			{
				get
				{
					PropertyKey whiteBalance = SystemProperties.System.Photo.WhiteBalance;
					if (!this.hashtable.ContainsKey(whiteBalance))
					{
						this.hashtable.Add(whiteBalance, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(whiteBalance));
					}
					return this.hashtable[whiteBalance] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003DC RID: 988
			// (get) Token: 0x06000810 RID: 2064 RVA: 0x00021F5C File Offset: 0x0002015C
			public ShellProperty<string> WhiteBalanceText
			{
				get
				{
					PropertyKey whiteBalanceText = SystemProperties.System.Photo.WhiteBalanceText;
					if (!this.hashtable.ContainsKey(whiteBalanceText))
					{
						this.hashtable.Add(whiteBalanceText, this.shellObjectParent.Properties.CreateTypedProperty<string>(whiteBalanceText));
					}
					return this.hashtable[whiteBalanceText] as ShellProperty<string>;
				}
			}

			// Token: 0x0400038D RID: 909
			private ShellObject shellObjectParent;

			// Token: 0x0400038E RID: 910
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000C8 RID: 200
		public class PropertySystemPropGroup : PropertyStoreItems
		{
			// Token: 0x06000811 RID: 2065 RVA: 0x00021FC4 File Offset: 0x000201C4
			internal PropertySystemPropGroup(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x170003DD RID: 989
			// (get) Token: 0x06000812 RID: 2066 RVA: 0x00021FE4 File Offset: 0x000201E4
			public ShellProperty<object> Advanced
			{
				get
				{
					PropertyKey advanced = SystemProperties.System.PropGroup.Advanced;
					if (!this.hashtable.ContainsKey(advanced))
					{
						this.hashtable.Add(advanced, this.shellObjectParent.Properties.CreateTypedProperty<object>(advanced));
					}
					return this.hashtable[advanced] as ShellProperty<object>;
				}
			}

			// Token: 0x170003DE RID: 990
			// (get) Token: 0x06000813 RID: 2067 RVA: 0x0002204C File Offset: 0x0002024C
			public ShellProperty<object> Audio
			{
				get
				{
					PropertyKey audio = SystemProperties.System.PropGroup.Audio;
					if (!this.hashtable.ContainsKey(audio))
					{
						this.hashtable.Add(audio, this.shellObjectParent.Properties.CreateTypedProperty<object>(audio));
					}
					return this.hashtable[audio] as ShellProperty<object>;
				}
			}

			// Token: 0x170003DF RID: 991
			// (get) Token: 0x06000814 RID: 2068 RVA: 0x000220B4 File Offset: 0x000202B4
			public ShellProperty<object> Calendar
			{
				get
				{
					PropertyKey calendar = SystemProperties.System.PropGroup.Calendar;
					if (!this.hashtable.ContainsKey(calendar))
					{
						this.hashtable.Add(calendar, this.shellObjectParent.Properties.CreateTypedProperty<object>(calendar));
					}
					return this.hashtable[calendar] as ShellProperty<object>;
				}
			}

			// Token: 0x170003E0 RID: 992
			// (get) Token: 0x06000815 RID: 2069 RVA: 0x0002211C File Offset: 0x0002031C
			public ShellProperty<object> Camera
			{
				get
				{
					PropertyKey camera = SystemProperties.System.PropGroup.Camera;
					if (!this.hashtable.ContainsKey(camera))
					{
						this.hashtable.Add(camera, this.shellObjectParent.Properties.CreateTypedProperty<object>(camera));
					}
					return this.hashtable[camera] as ShellProperty<object>;
				}
			}

			// Token: 0x170003E1 RID: 993
			// (get) Token: 0x06000816 RID: 2070 RVA: 0x00022184 File Offset: 0x00020384
			public ShellProperty<object> Contact
			{
				get
				{
					PropertyKey contact = SystemProperties.System.PropGroup.Contact;
					if (!this.hashtable.ContainsKey(contact))
					{
						this.hashtable.Add(contact, this.shellObjectParent.Properties.CreateTypedProperty<object>(contact));
					}
					return this.hashtable[contact] as ShellProperty<object>;
				}
			}

			// Token: 0x170003E2 RID: 994
			// (get) Token: 0x06000817 RID: 2071 RVA: 0x000221EC File Offset: 0x000203EC
			public ShellProperty<object> Content
			{
				get
				{
					PropertyKey content = SystemProperties.System.PropGroup.Content;
					if (!this.hashtable.ContainsKey(content))
					{
						this.hashtable.Add(content, this.shellObjectParent.Properties.CreateTypedProperty<object>(content));
					}
					return this.hashtable[content] as ShellProperty<object>;
				}
			}

			// Token: 0x170003E3 RID: 995
			// (get) Token: 0x06000818 RID: 2072 RVA: 0x00022254 File Offset: 0x00020454
			public ShellProperty<object> Description
			{
				get
				{
					PropertyKey description = SystemProperties.System.PropGroup.Description;
					if (!this.hashtable.ContainsKey(description))
					{
						this.hashtable.Add(description, this.shellObjectParent.Properties.CreateTypedProperty<object>(description));
					}
					return this.hashtable[description] as ShellProperty<object>;
				}
			}

			// Token: 0x170003E4 RID: 996
			// (get) Token: 0x06000819 RID: 2073 RVA: 0x000222BC File Offset: 0x000204BC
			public ShellProperty<object> FileSystem
			{
				get
				{
					PropertyKey fileSystem = SystemProperties.System.PropGroup.FileSystem;
					if (!this.hashtable.ContainsKey(fileSystem))
					{
						this.hashtable.Add(fileSystem, this.shellObjectParent.Properties.CreateTypedProperty<object>(fileSystem));
					}
					return this.hashtable[fileSystem] as ShellProperty<object>;
				}
			}

			// Token: 0x170003E5 RID: 997
			// (get) Token: 0x0600081A RID: 2074 RVA: 0x00022324 File Offset: 0x00020524
			public ShellProperty<object> General
			{
				get
				{
					PropertyKey general = SystemProperties.System.PropGroup.General;
					if (!this.hashtable.ContainsKey(general))
					{
						this.hashtable.Add(general, this.shellObjectParent.Properties.CreateTypedProperty<object>(general));
					}
					return this.hashtable[general] as ShellProperty<object>;
				}
			}

			// Token: 0x170003E6 RID: 998
			// (get) Token: 0x0600081B RID: 2075 RVA: 0x0002238C File Offset: 0x0002058C
			public ShellProperty<object> GPS
			{
				get
				{
					PropertyKey gps = SystemProperties.System.PropGroup.GPS;
					if (!this.hashtable.ContainsKey(gps))
					{
						this.hashtable.Add(gps, this.shellObjectParent.Properties.CreateTypedProperty<object>(gps));
					}
					return this.hashtable[gps] as ShellProperty<object>;
				}
			}

			// Token: 0x170003E7 RID: 999
			// (get) Token: 0x0600081C RID: 2076 RVA: 0x000223F4 File Offset: 0x000205F4
			public ShellProperty<object> Image
			{
				get
				{
					PropertyKey image = SystemProperties.System.PropGroup.Image;
					if (!this.hashtable.ContainsKey(image))
					{
						this.hashtable.Add(image, this.shellObjectParent.Properties.CreateTypedProperty<object>(image));
					}
					return this.hashtable[image] as ShellProperty<object>;
				}
			}

			// Token: 0x170003E8 RID: 1000
			// (get) Token: 0x0600081D RID: 2077 RVA: 0x0002245C File Offset: 0x0002065C
			public ShellProperty<object> Media
			{
				get
				{
					PropertyKey media = SystemProperties.System.PropGroup.Media;
					if (!this.hashtable.ContainsKey(media))
					{
						this.hashtable.Add(media, this.shellObjectParent.Properties.CreateTypedProperty<object>(media));
					}
					return this.hashtable[media] as ShellProperty<object>;
				}
			}

			// Token: 0x170003E9 RID: 1001
			// (get) Token: 0x0600081E RID: 2078 RVA: 0x000224C4 File Offset: 0x000206C4
			public ShellProperty<object> MediaAdvanced
			{
				get
				{
					PropertyKey mediaAdvanced = SystemProperties.System.PropGroup.MediaAdvanced;
					if (!this.hashtable.ContainsKey(mediaAdvanced))
					{
						this.hashtable.Add(mediaAdvanced, this.shellObjectParent.Properties.CreateTypedProperty<object>(mediaAdvanced));
					}
					return this.hashtable[mediaAdvanced] as ShellProperty<object>;
				}
			}

			// Token: 0x170003EA RID: 1002
			// (get) Token: 0x0600081F RID: 2079 RVA: 0x0002252C File Offset: 0x0002072C
			public ShellProperty<object> Message
			{
				get
				{
					PropertyKey message = SystemProperties.System.PropGroup.Message;
					if (!this.hashtable.ContainsKey(message))
					{
						this.hashtable.Add(message, this.shellObjectParent.Properties.CreateTypedProperty<object>(message));
					}
					return this.hashtable[message] as ShellProperty<object>;
				}
			}

			// Token: 0x170003EB RID: 1003
			// (get) Token: 0x06000820 RID: 2080 RVA: 0x00022594 File Offset: 0x00020794
			public ShellProperty<object> Music
			{
				get
				{
					PropertyKey music = SystemProperties.System.PropGroup.Music;
					if (!this.hashtable.ContainsKey(music))
					{
						this.hashtable.Add(music, this.shellObjectParent.Properties.CreateTypedProperty<object>(music));
					}
					return this.hashtable[music] as ShellProperty<object>;
				}
			}

			// Token: 0x170003EC RID: 1004
			// (get) Token: 0x06000821 RID: 2081 RVA: 0x000225FC File Offset: 0x000207FC
			public ShellProperty<object> Origin
			{
				get
				{
					PropertyKey origin = SystemProperties.System.PropGroup.Origin;
					if (!this.hashtable.ContainsKey(origin))
					{
						this.hashtable.Add(origin, this.shellObjectParent.Properties.CreateTypedProperty<object>(origin));
					}
					return this.hashtable[origin] as ShellProperty<object>;
				}
			}

			// Token: 0x170003ED RID: 1005
			// (get) Token: 0x06000822 RID: 2082 RVA: 0x00022664 File Offset: 0x00020864
			public ShellProperty<object> PhotoAdvanced
			{
				get
				{
					PropertyKey photoAdvanced = SystemProperties.System.PropGroup.PhotoAdvanced;
					if (!this.hashtable.ContainsKey(photoAdvanced))
					{
						this.hashtable.Add(photoAdvanced, this.shellObjectParent.Properties.CreateTypedProperty<object>(photoAdvanced));
					}
					return this.hashtable[photoAdvanced] as ShellProperty<object>;
				}
			}

			// Token: 0x170003EE RID: 1006
			// (get) Token: 0x06000823 RID: 2083 RVA: 0x000226CC File Offset: 0x000208CC
			public ShellProperty<object> RecordedTV
			{
				get
				{
					PropertyKey recordedTV = SystemProperties.System.PropGroup.RecordedTV;
					if (!this.hashtable.ContainsKey(recordedTV))
					{
						this.hashtable.Add(recordedTV, this.shellObjectParent.Properties.CreateTypedProperty<object>(recordedTV));
					}
					return this.hashtable[recordedTV] as ShellProperty<object>;
				}
			}

			// Token: 0x170003EF RID: 1007
			// (get) Token: 0x06000824 RID: 2084 RVA: 0x00022734 File Offset: 0x00020934
			public ShellProperty<object> Video
			{
				get
				{
					PropertyKey video = SystemProperties.System.PropGroup.Video;
					if (!this.hashtable.ContainsKey(video))
					{
						this.hashtable.Add(video, this.shellObjectParent.Properties.CreateTypedProperty<object>(video));
					}
					return this.hashtable[video] as ShellProperty<object>;
				}
			}

			// Token: 0x0400038F RID: 911
			private ShellObject shellObjectParent;

			// Token: 0x04000390 RID: 912
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000C9 RID: 201
		public class PropertySystemPropList : PropertyStoreItems
		{
			// Token: 0x06000825 RID: 2085 RVA: 0x0002279C File Offset: 0x0002099C
			internal PropertySystemPropList(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x170003F0 RID: 1008
			// (get) Token: 0x06000826 RID: 2086 RVA: 0x000227BC File Offset: 0x000209BC
			public ShellProperty<string> ConflictPrompt
			{
				get
				{
					PropertyKey conflictPrompt = SystemProperties.System.PropList.ConflictPrompt;
					if (!this.hashtable.ContainsKey(conflictPrompt))
					{
						this.hashtable.Add(conflictPrompt, this.shellObjectParent.Properties.CreateTypedProperty<string>(conflictPrompt));
					}
					return this.hashtable[conflictPrompt] as ShellProperty<string>;
				}
			}

			// Token: 0x170003F1 RID: 1009
			// (get) Token: 0x06000827 RID: 2087 RVA: 0x00022824 File Offset: 0x00020A24
			public ShellProperty<string> ContentViewModeForBrowse
			{
				get
				{
					PropertyKey contentViewModeForBrowse = SystemProperties.System.PropList.ContentViewModeForBrowse;
					if (!this.hashtable.ContainsKey(contentViewModeForBrowse))
					{
						this.hashtable.Add(contentViewModeForBrowse, this.shellObjectParent.Properties.CreateTypedProperty<string>(contentViewModeForBrowse));
					}
					return this.hashtable[contentViewModeForBrowse] as ShellProperty<string>;
				}
			}

			// Token: 0x170003F2 RID: 1010
			// (get) Token: 0x06000828 RID: 2088 RVA: 0x0002288C File Offset: 0x00020A8C
			public ShellProperty<string> ContentViewModeForSearch
			{
				get
				{
					PropertyKey contentViewModeForSearch = SystemProperties.System.PropList.ContentViewModeForSearch;
					if (!this.hashtable.ContainsKey(contentViewModeForSearch))
					{
						this.hashtable.Add(contentViewModeForSearch, this.shellObjectParent.Properties.CreateTypedProperty<string>(contentViewModeForSearch));
					}
					return this.hashtable[contentViewModeForSearch] as ShellProperty<string>;
				}
			}

			// Token: 0x170003F3 RID: 1011
			// (get) Token: 0x06000829 RID: 2089 RVA: 0x000228F4 File Offset: 0x00020AF4
			public ShellProperty<string> ExtendedTileInfo
			{
				get
				{
					PropertyKey extendedTileInfo = SystemProperties.System.PropList.ExtendedTileInfo;
					if (!this.hashtable.ContainsKey(extendedTileInfo))
					{
						this.hashtable.Add(extendedTileInfo, this.shellObjectParent.Properties.CreateTypedProperty<string>(extendedTileInfo));
					}
					return this.hashtable[extendedTileInfo] as ShellProperty<string>;
				}
			}

			// Token: 0x170003F4 RID: 1012
			// (get) Token: 0x0600082A RID: 2090 RVA: 0x0002295C File Offset: 0x00020B5C
			public ShellProperty<string> FileOperationPrompt
			{
				get
				{
					PropertyKey fileOperationPrompt = SystemProperties.System.PropList.FileOperationPrompt;
					if (!this.hashtable.ContainsKey(fileOperationPrompt))
					{
						this.hashtable.Add(fileOperationPrompt, this.shellObjectParent.Properties.CreateTypedProperty<string>(fileOperationPrompt));
					}
					return this.hashtable[fileOperationPrompt] as ShellProperty<string>;
				}
			}

			// Token: 0x170003F5 RID: 1013
			// (get) Token: 0x0600082B RID: 2091 RVA: 0x000229C4 File Offset: 0x00020BC4
			public ShellProperty<string> FullDetails
			{
				get
				{
					PropertyKey fullDetails = SystemProperties.System.PropList.FullDetails;
					if (!this.hashtable.ContainsKey(fullDetails))
					{
						this.hashtable.Add(fullDetails, this.shellObjectParent.Properties.CreateTypedProperty<string>(fullDetails));
					}
					return this.hashtable[fullDetails] as ShellProperty<string>;
				}
			}

			// Token: 0x170003F6 RID: 1014
			// (get) Token: 0x0600082C RID: 2092 RVA: 0x00022A2C File Offset: 0x00020C2C
			public ShellProperty<string> InfoTip
			{
				get
				{
					PropertyKey infoTip = SystemProperties.System.PropList.InfoTip;
					if (!this.hashtable.ContainsKey(infoTip))
					{
						this.hashtable.Add(infoTip, this.shellObjectParent.Properties.CreateTypedProperty<string>(infoTip));
					}
					return this.hashtable[infoTip] as ShellProperty<string>;
				}
			}

			// Token: 0x170003F7 RID: 1015
			// (get) Token: 0x0600082D RID: 2093 RVA: 0x00022A94 File Offset: 0x00020C94
			public ShellProperty<string> NonPersonal
			{
				get
				{
					PropertyKey nonPersonal = SystemProperties.System.PropList.NonPersonal;
					if (!this.hashtable.ContainsKey(nonPersonal))
					{
						this.hashtable.Add(nonPersonal, this.shellObjectParent.Properties.CreateTypedProperty<string>(nonPersonal));
					}
					return this.hashtable[nonPersonal] as ShellProperty<string>;
				}
			}

			// Token: 0x170003F8 RID: 1016
			// (get) Token: 0x0600082E RID: 2094 RVA: 0x00022AFC File Offset: 0x00020CFC
			public ShellProperty<string> PreviewDetails
			{
				get
				{
					PropertyKey previewDetails = SystemProperties.System.PropList.PreviewDetails;
					if (!this.hashtable.ContainsKey(previewDetails))
					{
						this.hashtable.Add(previewDetails, this.shellObjectParent.Properties.CreateTypedProperty<string>(previewDetails));
					}
					return this.hashtable[previewDetails] as ShellProperty<string>;
				}
			}

			// Token: 0x170003F9 RID: 1017
			// (get) Token: 0x0600082F RID: 2095 RVA: 0x00022B64 File Offset: 0x00020D64
			public ShellProperty<string> PreviewTitle
			{
				get
				{
					PropertyKey previewTitle = SystemProperties.System.PropList.PreviewTitle;
					if (!this.hashtable.ContainsKey(previewTitle))
					{
						this.hashtable.Add(previewTitle, this.shellObjectParent.Properties.CreateTypedProperty<string>(previewTitle));
					}
					return this.hashtable[previewTitle] as ShellProperty<string>;
				}
			}

			// Token: 0x170003FA RID: 1018
			// (get) Token: 0x06000830 RID: 2096 RVA: 0x00022BCC File Offset: 0x00020DCC
			public ShellProperty<string> QuickTip
			{
				get
				{
					PropertyKey quickTip = SystemProperties.System.PropList.QuickTip;
					if (!this.hashtable.ContainsKey(quickTip))
					{
						this.hashtable.Add(quickTip, this.shellObjectParent.Properties.CreateTypedProperty<string>(quickTip));
					}
					return this.hashtable[quickTip] as ShellProperty<string>;
				}
			}

			// Token: 0x170003FB RID: 1019
			// (get) Token: 0x06000831 RID: 2097 RVA: 0x00022C34 File Offset: 0x00020E34
			public ShellProperty<string> TileInfo
			{
				get
				{
					PropertyKey tileInfo = SystemProperties.System.PropList.TileInfo;
					if (!this.hashtable.ContainsKey(tileInfo))
					{
						this.hashtable.Add(tileInfo, this.shellObjectParent.Properties.CreateTypedProperty<string>(tileInfo));
					}
					return this.hashtable[tileInfo] as ShellProperty<string>;
				}
			}

			// Token: 0x170003FC RID: 1020
			// (get) Token: 0x06000832 RID: 2098 RVA: 0x00022C9C File Offset: 0x00020E9C
			public ShellProperty<string> XPDetailsPanel
			{
				get
				{
					PropertyKey xpdetailsPanel = SystemProperties.System.PropList.XPDetailsPanel;
					if (!this.hashtable.ContainsKey(xpdetailsPanel))
					{
						this.hashtable.Add(xpdetailsPanel, this.shellObjectParent.Properties.CreateTypedProperty<string>(xpdetailsPanel));
					}
					return this.hashtable[xpdetailsPanel] as ShellProperty<string>;
				}
			}

			// Token: 0x04000391 RID: 913
			private ShellObject shellObjectParent;

			// Token: 0x04000392 RID: 914
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000CA RID: 202
		public class PropertySystemRecordedTV : PropertyStoreItems
		{
			// Token: 0x06000833 RID: 2099 RVA: 0x00022D04 File Offset: 0x00020F04
			internal PropertySystemRecordedTV(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x170003FD RID: 1021
			// (get) Token: 0x06000834 RID: 2100 RVA: 0x00022D24 File Offset: 0x00020F24
			public ShellProperty<uint?> ChannelNumber
			{
				get
				{
					PropertyKey channelNumber = SystemProperties.System.RecordedTV.ChannelNumber;
					if (!this.hashtable.ContainsKey(channelNumber))
					{
						this.hashtable.Add(channelNumber, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(channelNumber));
					}
					return this.hashtable[channelNumber] as ShellProperty<uint?>;
				}
			}

			// Token: 0x170003FE RID: 1022
			// (get) Token: 0x06000835 RID: 2101 RVA: 0x00022D8C File Offset: 0x00020F8C
			public ShellProperty<string> Credits
			{
				get
				{
					PropertyKey credits = SystemProperties.System.RecordedTV.Credits;
					if (!this.hashtable.ContainsKey(credits))
					{
						this.hashtable.Add(credits, this.shellObjectParent.Properties.CreateTypedProperty<string>(credits));
					}
					return this.hashtable[credits] as ShellProperty<string>;
				}
			}

			// Token: 0x170003FF RID: 1023
			// (get) Token: 0x06000836 RID: 2102 RVA: 0x00022DF4 File Offset: 0x00020FF4
			public ShellProperty<DateTime?> DateContentExpires
			{
				get
				{
					PropertyKey dateContentExpires = SystemProperties.System.RecordedTV.DateContentExpires;
					if (!this.hashtable.ContainsKey(dateContentExpires))
					{
						this.hashtable.Add(dateContentExpires, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateContentExpires));
					}
					return this.hashtable[dateContentExpires] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000400 RID: 1024
			// (get) Token: 0x06000837 RID: 2103 RVA: 0x00022E5C File Offset: 0x0002105C
			public ShellProperty<string> EpisodeName
			{
				get
				{
					PropertyKey episodeName = SystemProperties.System.RecordedTV.EpisodeName;
					if (!this.hashtable.ContainsKey(episodeName))
					{
						this.hashtable.Add(episodeName, this.shellObjectParent.Properties.CreateTypedProperty<string>(episodeName));
					}
					return this.hashtable[episodeName] as ShellProperty<string>;
				}
			}

			// Token: 0x17000401 RID: 1025
			// (get) Token: 0x06000838 RID: 2104 RVA: 0x00022EC4 File Offset: 0x000210C4
			public ShellProperty<bool?> IsATSCContent
			{
				get
				{
					PropertyKey isATSCContent = SystemProperties.System.RecordedTV.IsATSCContent;
					if (!this.hashtable.ContainsKey(isATSCContent))
					{
						this.hashtable.Add(isATSCContent, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isATSCContent));
					}
					return this.hashtable[isATSCContent] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000402 RID: 1026
			// (get) Token: 0x06000839 RID: 2105 RVA: 0x00022F2C File Offset: 0x0002112C
			public ShellProperty<bool?> IsClosedCaptioningAvailable
			{
				get
				{
					PropertyKey isClosedCaptioningAvailable = SystemProperties.System.RecordedTV.IsClosedCaptioningAvailable;
					if (!this.hashtable.ContainsKey(isClosedCaptioningAvailable))
					{
						this.hashtable.Add(isClosedCaptioningAvailable, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isClosedCaptioningAvailable));
					}
					return this.hashtable[isClosedCaptioningAvailable] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000403 RID: 1027
			// (get) Token: 0x0600083A RID: 2106 RVA: 0x00022F94 File Offset: 0x00021194
			public ShellProperty<bool?> IsDTVContent
			{
				get
				{
					PropertyKey isDTVContent = SystemProperties.System.RecordedTV.IsDTVContent;
					if (!this.hashtable.ContainsKey(isDTVContent))
					{
						this.hashtable.Add(isDTVContent, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isDTVContent));
					}
					return this.hashtable[isDTVContent] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000404 RID: 1028
			// (get) Token: 0x0600083B RID: 2107 RVA: 0x00022FFC File Offset: 0x000211FC
			public ShellProperty<bool?> IsHDContent
			{
				get
				{
					PropertyKey isHDContent = SystemProperties.System.RecordedTV.IsHDContent;
					if (!this.hashtable.ContainsKey(isHDContent))
					{
						this.hashtable.Add(isHDContent, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isHDContent));
					}
					return this.hashtable[isHDContent] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000405 RID: 1029
			// (get) Token: 0x0600083C RID: 2108 RVA: 0x00023064 File Offset: 0x00021264
			public ShellProperty<bool?> IsRepeatBroadcast
			{
				get
				{
					PropertyKey isRepeatBroadcast = SystemProperties.System.RecordedTV.IsRepeatBroadcast;
					if (!this.hashtable.ContainsKey(isRepeatBroadcast))
					{
						this.hashtable.Add(isRepeatBroadcast, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isRepeatBroadcast));
					}
					return this.hashtable[isRepeatBroadcast] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000406 RID: 1030
			// (get) Token: 0x0600083D RID: 2109 RVA: 0x000230CC File Offset: 0x000212CC
			public ShellProperty<bool?> IsSAP
			{
				get
				{
					PropertyKey isSAP = SystemProperties.System.RecordedTV.IsSAP;
					if (!this.hashtable.ContainsKey(isSAP))
					{
						this.hashtable.Add(isSAP, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isSAP));
					}
					return this.hashtable[isSAP] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000407 RID: 1031
			// (get) Token: 0x0600083E RID: 2110 RVA: 0x00023134 File Offset: 0x00021334
			public ShellProperty<string> NetworkAffiliation
			{
				get
				{
					PropertyKey networkAffiliation = SystemProperties.System.RecordedTV.NetworkAffiliation;
					if (!this.hashtable.ContainsKey(networkAffiliation))
					{
						this.hashtable.Add(networkAffiliation, this.shellObjectParent.Properties.CreateTypedProperty<string>(networkAffiliation));
					}
					return this.hashtable[networkAffiliation] as ShellProperty<string>;
				}
			}

			// Token: 0x17000408 RID: 1032
			// (get) Token: 0x0600083F RID: 2111 RVA: 0x0002319C File Offset: 0x0002139C
			public ShellProperty<DateTime?> OriginalBroadcastDate
			{
				get
				{
					PropertyKey originalBroadcastDate = SystemProperties.System.RecordedTV.OriginalBroadcastDate;
					if (!this.hashtable.ContainsKey(originalBroadcastDate))
					{
						this.hashtable.Add(originalBroadcastDate, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(originalBroadcastDate));
					}
					return this.hashtable[originalBroadcastDate] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000409 RID: 1033
			// (get) Token: 0x06000840 RID: 2112 RVA: 0x00023204 File Offset: 0x00021404
			public ShellProperty<string> ProgramDescription
			{
				get
				{
					PropertyKey programDescription = SystemProperties.System.RecordedTV.ProgramDescription;
					if (!this.hashtable.ContainsKey(programDescription))
					{
						this.hashtable.Add(programDescription, this.shellObjectParent.Properties.CreateTypedProperty<string>(programDescription));
					}
					return this.hashtable[programDescription] as ShellProperty<string>;
				}
			}

			// Token: 0x1700040A RID: 1034
			// (get) Token: 0x06000841 RID: 2113 RVA: 0x0002326C File Offset: 0x0002146C
			public ShellProperty<DateTime?> RecordingTime
			{
				get
				{
					PropertyKey recordingTime = SystemProperties.System.RecordedTV.RecordingTime;
					if (!this.hashtable.ContainsKey(recordingTime))
					{
						this.hashtable.Add(recordingTime, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(recordingTime));
					}
					return this.hashtable[recordingTime] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x1700040B RID: 1035
			// (get) Token: 0x06000842 RID: 2114 RVA: 0x000232D4 File Offset: 0x000214D4
			public ShellProperty<string> StationCallSign
			{
				get
				{
					PropertyKey stationCallSign = SystemProperties.System.RecordedTV.StationCallSign;
					if (!this.hashtable.ContainsKey(stationCallSign))
					{
						this.hashtable.Add(stationCallSign, this.shellObjectParent.Properties.CreateTypedProperty<string>(stationCallSign));
					}
					return this.hashtable[stationCallSign] as ShellProperty<string>;
				}
			}

			// Token: 0x1700040C RID: 1036
			// (get) Token: 0x06000843 RID: 2115 RVA: 0x0002333C File Offset: 0x0002153C
			public ShellProperty<string> StationName
			{
				get
				{
					PropertyKey stationName = SystemProperties.System.RecordedTV.StationName;
					if (!this.hashtable.ContainsKey(stationName))
					{
						this.hashtable.Add(stationName, this.shellObjectParent.Properties.CreateTypedProperty<string>(stationName));
					}
					return this.hashtable[stationName] as ShellProperty<string>;
				}
			}

			// Token: 0x04000393 RID: 915
			private ShellObject shellObjectParent;

			// Token: 0x04000394 RID: 916
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000CB RID: 203
		public class PropertySystemSearch : PropertyStoreItems
		{
			// Token: 0x06000844 RID: 2116 RVA: 0x000233A4 File Offset: 0x000215A4
			internal PropertySystemSearch(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700040D RID: 1037
			// (get) Token: 0x06000845 RID: 2117 RVA: 0x000233C4 File Offset: 0x000215C4
			public ShellProperty<string> AutoSummary
			{
				get
				{
					PropertyKey autoSummary = SystemProperties.System.Search.AutoSummary;
					if (!this.hashtable.ContainsKey(autoSummary))
					{
						this.hashtable.Add(autoSummary, this.shellObjectParent.Properties.CreateTypedProperty<string>(autoSummary));
					}
					return this.hashtable[autoSummary] as ShellProperty<string>;
				}
			}

			// Token: 0x1700040E RID: 1038
			// (get) Token: 0x06000846 RID: 2118 RVA: 0x0002342C File Offset: 0x0002162C
			public ShellProperty<string> ContainerHash
			{
				get
				{
					PropertyKey containerHash = SystemProperties.System.Search.ContainerHash;
					if (!this.hashtable.ContainsKey(containerHash))
					{
						this.hashtable.Add(containerHash, this.shellObjectParent.Properties.CreateTypedProperty<string>(containerHash));
					}
					return this.hashtable[containerHash] as ShellProperty<string>;
				}
			}

			// Token: 0x1700040F RID: 1039
			// (get) Token: 0x06000847 RID: 2119 RVA: 0x00023494 File Offset: 0x00021694
			public ShellProperty<string> Contents
			{
				get
				{
					PropertyKey contents = SystemProperties.System.Search.Contents;
					if (!this.hashtable.ContainsKey(contents))
					{
						this.hashtable.Add(contents, this.shellObjectParent.Properties.CreateTypedProperty<string>(contents));
					}
					return this.hashtable[contents] as ShellProperty<string>;
				}
			}

			// Token: 0x17000410 RID: 1040
			// (get) Token: 0x06000848 RID: 2120 RVA: 0x000234FC File Offset: 0x000216FC
			public ShellProperty<int?> EntryID
			{
				get
				{
					PropertyKey entryID = SystemProperties.System.Search.EntryID;
					if (!this.hashtable.ContainsKey(entryID))
					{
						this.hashtable.Add(entryID, this.shellObjectParent.Properties.CreateTypedProperty<int?>(entryID));
					}
					return this.hashtable[entryID] as ShellProperty<int?>;
				}
			}

			// Token: 0x17000411 RID: 1041
			// (get) Token: 0x06000849 RID: 2121 RVA: 0x00023564 File Offset: 0x00021764
			public ShellProperty<byte[]> ExtendedProperties
			{
				get
				{
					PropertyKey extendedProperties = SystemProperties.System.Search.ExtendedProperties;
					if (!this.hashtable.ContainsKey(extendedProperties))
					{
						this.hashtable.Add(extendedProperties, this.shellObjectParent.Properties.CreateTypedProperty<byte[]>(extendedProperties));
					}
					return this.hashtable[extendedProperties] as ShellProperty<byte[]>;
				}
			}

			// Token: 0x17000412 RID: 1042
			// (get) Token: 0x0600084A RID: 2122 RVA: 0x000235CC File Offset: 0x000217CC
			public ShellProperty<DateTime?> GatherTime
			{
				get
				{
					PropertyKey gatherTime = SystemProperties.System.Search.GatherTime;
					if (!this.hashtable.ContainsKey(gatherTime))
					{
						this.hashtable.Add(gatherTime, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(gatherTime));
					}
					return this.hashtable[gatherTime] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x17000413 RID: 1043
			// (get) Token: 0x0600084B RID: 2123 RVA: 0x00023634 File Offset: 0x00021834
			public ShellProperty<int?> HitCount
			{
				get
				{
					PropertyKey hitCount = SystemProperties.System.Search.HitCount;
					if (!this.hashtable.ContainsKey(hitCount))
					{
						this.hashtable.Add(hitCount, this.shellObjectParent.Properties.CreateTypedProperty<int?>(hitCount));
					}
					return this.hashtable[hitCount] as ShellProperty<int?>;
				}
			}

			// Token: 0x17000414 RID: 1044
			// (get) Token: 0x0600084C RID: 2124 RVA: 0x0002369C File Offset: 0x0002189C
			public ShellProperty<bool?> IsClosedDirectory
			{
				get
				{
					PropertyKey isClosedDirectory = SystemProperties.System.Search.IsClosedDirectory;
					if (!this.hashtable.ContainsKey(isClosedDirectory))
					{
						this.hashtable.Add(isClosedDirectory, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isClosedDirectory));
					}
					return this.hashtable[isClosedDirectory] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000415 RID: 1045
			// (get) Token: 0x0600084D RID: 2125 RVA: 0x00023704 File Offset: 0x00021904
			public ShellProperty<bool?> IsFullyContained
			{
				get
				{
					PropertyKey isFullyContained = SystemProperties.System.Search.IsFullyContained;
					if (!this.hashtable.ContainsKey(isFullyContained))
					{
						this.hashtable.Add(isFullyContained, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isFullyContained));
					}
					return this.hashtable[isFullyContained] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000416 RID: 1046
			// (get) Token: 0x0600084E RID: 2126 RVA: 0x0002376C File Offset: 0x0002196C
			public ShellProperty<string> QueryFocusedSummary
			{
				get
				{
					PropertyKey queryFocusedSummary = SystemProperties.System.Search.QueryFocusedSummary;
					if (!this.hashtable.ContainsKey(queryFocusedSummary))
					{
						this.hashtable.Add(queryFocusedSummary, this.shellObjectParent.Properties.CreateTypedProperty<string>(queryFocusedSummary));
					}
					return this.hashtable[queryFocusedSummary] as ShellProperty<string>;
				}
			}

			// Token: 0x17000417 RID: 1047
			// (get) Token: 0x0600084F RID: 2127 RVA: 0x000237D4 File Offset: 0x000219D4
			public ShellProperty<string> QueryFocusedSummaryWithFallback
			{
				get
				{
					PropertyKey queryFocusedSummaryWithFallback = SystemProperties.System.Search.QueryFocusedSummaryWithFallback;
					if (!this.hashtable.ContainsKey(queryFocusedSummaryWithFallback))
					{
						this.hashtable.Add(queryFocusedSummaryWithFallback, this.shellObjectParent.Properties.CreateTypedProperty<string>(queryFocusedSummaryWithFallback));
					}
					return this.hashtable[queryFocusedSummaryWithFallback] as ShellProperty<string>;
				}
			}

			// Token: 0x17000418 RID: 1048
			// (get) Token: 0x06000850 RID: 2128 RVA: 0x0002383C File Offset: 0x00021A3C
			public ShellProperty<int?> Rank
			{
				get
				{
					PropertyKey rank = SystemProperties.System.Search.Rank;
					if (!this.hashtable.ContainsKey(rank))
					{
						this.hashtable.Add(rank, this.shellObjectParent.Properties.CreateTypedProperty<int?>(rank));
					}
					return this.hashtable[rank] as ShellProperty<int?>;
				}
			}

			// Token: 0x17000419 RID: 1049
			// (get) Token: 0x06000851 RID: 2129 RVA: 0x000238A4 File Offset: 0x00021AA4
			public ShellProperty<string> Store
			{
				get
				{
					PropertyKey store = SystemProperties.System.Search.Store;
					if (!this.hashtable.ContainsKey(store))
					{
						this.hashtable.Add(store, this.shellObjectParent.Properties.CreateTypedProperty<string>(store));
					}
					return this.hashtable[store] as ShellProperty<string>;
				}
			}

			// Token: 0x1700041A RID: 1050
			// (get) Token: 0x06000852 RID: 2130 RVA: 0x0002390C File Offset: 0x00021B0C
			public ShellProperty<string> UrlToIndex
			{
				get
				{
					PropertyKey urlToIndex = SystemProperties.System.Search.UrlToIndex;
					if (!this.hashtable.ContainsKey(urlToIndex))
					{
						this.hashtable.Add(urlToIndex, this.shellObjectParent.Properties.CreateTypedProperty<string>(urlToIndex));
					}
					return this.hashtable[urlToIndex] as ShellProperty<string>;
				}
			}

			// Token: 0x1700041B RID: 1051
			// (get) Token: 0x06000853 RID: 2131 RVA: 0x00023974 File Offset: 0x00021B74
			public ShellProperty<object> UrlToIndexWithModificationTime
			{
				get
				{
					PropertyKey urlToIndexWithModificationTime = SystemProperties.System.Search.UrlToIndexWithModificationTime;
					if (!this.hashtable.ContainsKey(urlToIndexWithModificationTime))
					{
						this.hashtable.Add(urlToIndexWithModificationTime, this.shellObjectParent.Properties.CreateTypedProperty<object>(urlToIndexWithModificationTime));
					}
					return this.hashtable[urlToIndexWithModificationTime] as ShellProperty<object>;
				}
			}

			// Token: 0x04000395 RID: 917
			private ShellObject shellObjectParent;

			// Token: 0x04000396 RID: 918
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000CC RID: 204
		public class PropertySystemShell : PropertyStoreItems
		{
			// Token: 0x06000854 RID: 2132 RVA: 0x000239DC File Offset: 0x00021BDC
			internal PropertySystemShell(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700041C RID: 1052
			// (get) Token: 0x06000855 RID: 2133 RVA: 0x000239FC File Offset: 0x00021BFC
			public ShellProperty<string> OmitFromView
			{
				get
				{
					PropertyKey omitFromView = SystemProperties.System.Shell.OmitFromView;
					if (!this.hashtable.ContainsKey(omitFromView))
					{
						this.hashtable.Add(omitFromView, this.shellObjectParent.Properties.CreateTypedProperty<string>(omitFromView));
					}
					return this.hashtable[omitFromView] as ShellProperty<string>;
				}
			}

			// Token: 0x1700041D RID: 1053
			// (get) Token: 0x06000856 RID: 2134 RVA: 0x00023A64 File Offset: 0x00021C64
			public ShellProperty<string[]> SFGAOFlagsStrings
			{
				get
				{
					PropertyKey sfgaoflagsStrings = SystemProperties.System.Shell.SFGAOFlagsStrings;
					if (!this.hashtable.ContainsKey(sfgaoflagsStrings))
					{
						this.hashtable.Add(sfgaoflagsStrings, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(sfgaoflagsStrings));
					}
					return this.hashtable[sfgaoflagsStrings] as ShellProperty<string[]>;
				}
			}

			// Token: 0x04000397 RID: 919
			private ShellObject shellObjectParent;

			// Token: 0x04000398 RID: 920
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000CD RID: 205
		public class PropertySystemSoftware : PropertyStoreItems
		{
			// Token: 0x06000857 RID: 2135 RVA: 0x00023ACC File Offset: 0x00021CCC
			internal PropertySystemSoftware(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700041E RID: 1054
			// (get) Token: 0x06000858 RID: 2136 RVA: 0x00023AEC File Offset: 0x00021CEC
			public ShellProperty<DateTime?> DateLastUsed
			{
				get
				{
					PropertyKey dateLastUsed = SystemProperties.System.Software.DateLastUsed;
					if (!this.hashtable.ContainsKey(dateLastUsed))
					{
						this.hashtable.Add(dateLastUsed, this.shellObjectParent.Properties.CreateTypedProperty<DateTime?>(dateLastUsed));
					}
					return this.hashtable[dateLastUsed] as ShellProperty<DateTime?>;
				}
			}

			// Token: 0x1700041F RID: 1055
			// (get) Token: 0x06000859 RID: 2137 RVA: 0x00023B54 File Offset: 0x00021D54
			public ShellProperty<string> ProductName
			{
				get
				{
					PropertyKey productName = SystemProperties.System.Software.ProductName;
					if (!this.hashtable.ContainsKey(productName))
					{
						this.hashtable.Add(productName, this.shellObjectParent.Properties.CreateTypedProperty<string>(productName));
					}
					return this.hashtable[productName] as ShellProperty<string>;
				}
			}

			// Token: 0x04000399 RID: 921
			private ShellObject shellObjectParent;

			// Token: 0x0400039A RID: 922
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000CE RID: 206
		public class PropertySystemSync : PropertyStoreItems
		{
			// Token: 0x0600085A RID: 2138 RVA: 0x00023BBC File Offset: 0x00021DBC
			internal PropertySystemSync(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000420 RID: 1056
			// (get) Token: 0x0600085B RID: 2139 RVA: 0x00023BDC File Offset: 0x00021DDC
			public ShellProperty<string> Comments
			{
				get
				{
					PropertyKey comments = SystemProperties.System.Sync.Comments;
					if (!this.hashtable.ContainsKey(comments))
					{
						this.hashtable.Add(comments, this.shellObjectParent.Properties.CreateTypedProperty<string>(comments));
					}
					return this.hashtable[comments] as ShellProperty<string>;
				}
			}

			// Token: 0x17000421 RID: 1057
			// (get) Token: 0x0600085C RID: 2140 RVA: 0x00023C44 File Offset: 0x00021E44
			public ShellProperty<string> ConflictDescription
			{
				get
				{
					PropertyKey conflictDescription = SystemProperties.System.Sync.ConflictDescription;
					if (!this.hashtable.ContainsKey(conflictDescription))
					{
						this.hashtable.Add(conflictDescription, this.shellObjectParent.Properties.CreateTypedProperty<string>(conflictDescription));
					}
					return this.hashtable[conflictDescription] as ShellProperty<string>;
				}
			}

			// Token: 0x17000422 RID: 1058
			// (get) Token: 0x0600085D RID: 2141 RVA: 0x00023CAC File Offset: 0x00021EAC
			public ShellProperty<string> ConflictFirstLocation
			{
				get
				{
					PropertyKey conflictFirstLocation = SystemProperties.System.Sync.ConflictFirstLocation;
					if (!this.hashtable.ContainsKey(conflictFirstLocation))
					{
						this.hashtable.Add(conflictFirstLocation, this.shellObjectParent.Properties.CreateTypedProperty<string>(conflictFirstLocation));
					}
					return this.hashtable[conflictFirstLocation] as ShellProperty<string>;
				}
			}

			// Token: 0x17000423 RID: 1059
			// (get) Token: 0x0600085E RID: 2142 RVA: 0x00023D14 File Offset: 0x00021F14
			public ShellProperty<string> ConflictSecondLocation
			{
				get
				{
					PropertyKey conflictSecondLocation = SystemProperties.System.Sync.ConflictSecondLocation;
					if (!this.hashtable.ContainsKey(conflictSecondLocation))
					{
						this.hashtable.Add(conflictSecondLocation, this.shellObjectParent.Properties.CreateTypedProperty<string>(conflictSecondLocation));
					}
					return this.hashtable[conflictSecondLocation] as ShellProperty<string>;
				}
			}

			// Token: 0x17000424 RID: 1060
			// (get) Token: 0x0600085F RID: 2143 RVA: 0x00023D7C File Offset: 0x00021F7C
			public ShellProperty<IntPtr?> HandlerCollectionID
			{
				get
				{
					PropertyKey handlerCollectionID = SystemProperties.System.Sync.HandlerCollectionID;
					if (!this.hashtable.ContainsKey(handlerCollectionID))
					{
						this.hashtable.Add(handlerCollectionID, this.shellObjectParent.Properties.CreateTypedProperty<IntPtr?>(handlerCollectionID));
					}
					return this.hashtable[handlerCollectionID] as ShellProperty<IntPtr?>;
				}
			}

			// Token: 0x17000425 RID: 1061
			// (get) Token: 0x06000860 RID: 2144 RVA: 0x00023DE4 File Offset: 0x00021FE4
			public ShellProperty<string> HandlerID
			{
				get
				{
					PropertyKey handlerID = SystemProperties.System.Sync.HandlerID;
					if (!this.hashtable.ContainsKey(handlerID))
					{
						this.hashtable.Add(handlerID, this.shellObjectParent.Properties.CreateTypedProperty<string>(handlerID));
					}
					return this.hashtable[handlerID] as ShellProperty<string>;
				}
			}

			// Token: 0x17000426 RID: 1062
			// (get) Token: 0x06000861 RID: 2145 RVA: 0x00023E4C File Offset: 0x0002204C
			public ShellProperty<string> HandlerName
			{
				get
				{
					PropertyKey handlerName = SystemProperties.System.Sync.HandlerName;
					if (!this.hashtable.ContainsKey(handlerName))
					{
						this.hashtable.Add(handlerName, this.shellObjectParent.Properties.CreateTypedProperty<string>(handlerName));
					}
					return this.hashtable[handlerName] as ShellProperty<string>;
				}
			}

			// Token: 0x17000427 RID: 1063
			// (get) Token: 0x06000862 RID: 2146 RVA: 0x00023EB4 File Offset: 0x000220B4
			public ShellProperty<uint?> HandlerType
			{
				get
				{
					PropertyKey handlerType = SystemProperties.System.Sync.HandlerType;
					if (!this.hashtable.ContainsKey(handlerType))
					{
						this.hashtable.Add(handlerType, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(handlerType));
					}
					return this.hashtable[handlerType] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000428 RID: 1064
			// (get) Token: 0x06000863 RID: 2147 RVA: 0x00023F1C File Offset: 0x0002211C
			public ShellProperty<string> HandlerTypeLabel
			{
				get
				{
					PropertyKey handlerTypeLabel = SystemProperties.System.Sync.HandlerTypeLabel;
					if (!this.hashtable.ContainsKey(handlerTypeLabel))
					{
						this.hashtable.Add(handlerTypeLabel, this.shellObjectParent.Properties.CreateTypedProperty<string>(handlerTypeLabel));
					}
					return this.hashtable[handlerTypeLabel] as ShellProperty<string>;
				}
			}

			// Token: 0x17000429 RID: 1065
			// (get) Token: 0x06000864 RID: 2148 RVA: 0x00023F84 File Offset: 0x00022184
			public ShellProperty<string> ItemID
			{
				get
				{
					PropertyKey itemID = SystemProperties.System.Sync.ItemID;
					if (!this.hashtable.ContainsKey(itemID))
					{
						this.hashtable.Add(itemID, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemID));
					}
					return this.hashtable[itemID] as ShellProperty<string>;
				}
			}

			// Token: 0x1700042A RID: 1066
			// (get) Token: 0x06000865 RID: 2149 RVA: 0x00023FEC File Offset: 0x000221EC
			public ShellProperty<string> ItemName
			{
				get
				{
					PropertyKey itemName = SystemProperties.System.Sync.ItemName;
					if (!this.hashtable.ContainsKey(itemName))
					{
						this.hashtable.Add(itemName, this.shellObjectParent.Properties.CreateTypedProperty<string>(itemName));
					}
					return this.hashtable[itemName] as ShellProperty<string>;
				}
			}

			// Token: 0x1700042B RID: 1067
			// (get) Token: 0x06000866 RID: 2150 RVA: 0x00024054 File Offset: 0x00022254
			public ShellProperty<uint?> ProgressPercentage
			{
				get
				{
					PropertyKey progressPercentage = SystemProperties.System.Sync.ProgressPercentage;
					if (!this.hashtable.ContainsKey(progressPercentage))
					{
						this.hashtable.Add(progressPercentage, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(progressPercentage));
					}
					return this.hashtable[progressPercentage] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700042C RID: 1068
			// (get) Token: 0x06000867 RID: 2151 RVA: 0x000240BC File Offset: 0x000222BC
			public ShellProperty<uint?> State
			{
				get
				{
					PropertyKey state = SystemProperties.System.Sync.State;
					if (!this.hashtable.ContainsKey(state))
					{
						this.hashtable.Add(state, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(state));
					}
					return this.hashtable[state] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700042D RID: 1069
			// (get) Token: 0x06000868 RID: 2152 RVA: 0x00024124 File Offset: 0x00022324
			public ShellProperty<string> Status
			{
				get
				{
					PropertyKey status = SystemProperties.System.Sync.Status;
					if (!this.hashtable.ContainsKey(status))
					{
						this.hashtable.Add(status, this.shellObjectParent.Properties.CreateTypedProperty<string>(status));
					}
					return this.hashtable[status] as ShellProperty<string>;
				}
			}

			// Token: 0x0400039B RID: 923
			private ShellObject shellObjectParent;

			// Token: 0x0400039C RID: 924
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000CF RID: 207
		public class PropertySystemTask : PropertyStoreItems
		{
			// Token: 0x06000869 RID: 2153 RVA: 0x0002418C File Offset: 0x0002238C
			internal PropertySystemTask(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700042E RID: 1070
			// (get) Token: 0x0600086A RID: 2154 RVA: 0x000241AC File Offset: 0x000223AC
			public ShellProperty<string> BillingInformation
			{
				get
				{
					PropertyKey billingInformation = SystemProperties.System.Task.BillingInformation;
					if (!this.hashtable.ContainsKey(billingInformation))
					{
						this.hashtable.Add(billingInformation, this.shellObjectParent.Properties.CreateTypedProperty<string>(billingInformation));
					}
					return this.hashtable[billingInformation] as ShellProperty<string>;
				}
			}

			// Token: 0x1700042F RID: 1071
			// (get) Token: 0x0600086B RID: 2155 RVA: 0x00024214 File Offset: 0x00022414
			public ShellProperty<string> CompletionStatus
			{
				get
				{
					PropertyKey completionStatus = SystemProperties.System.Task.CompletionStatus;
					if (!this.hashtable.ContainsKey(completionStatus))
					{
						this.hashtable.Add(completionStatus, this.shellObjectParent.Properties.CreateTypedProperty<string>(completionStatus));
					}
					return this.hashtable[completionStatus] as ShellProperty<string>;
				}
			}

			// Token: 0x17000430 RID: 1072
			// (get) Token: 0x0600086C RID: 2156 RVA: 0x0002427C File Offset: 0x0002247C
			public ShellProperty<string> Owner
			{
				get
				{
					PropertyKey owner = SystemProperties.System.Task.Owner;
					if (!this.hashtable.ContainsKey(owner))
					{
						this.hashtable.Add(owner, this.shellObjectParent.Properties.CreateTypedProperty<string>(owner));
					}
					return this.hashtable[owner] as ShellProperty<string>;
				}
			}

			// Token: 0x0400039D RID: 925
			private ShellObject shellObjectParent;

			// Token: 0x0400039E RID: 926
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000D0 RID: 208
		public class PropertySystemVideo : PropertyStoreItems
		{
			// Token: 0x0600086D RID: 2157 RVA: 0x000242E4 File Offset: 0x000224E4
			internal PropertySystemVideo(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x17000431 RID: 1073
			// (get) Token: 0x0600086E RID: 2158 RVA: 0x00024304 File Offset: 0x00022504
			public ShellProperty<string> Compression
			{
				get
				{
					PropertyKey compression = SystemProperties.System.Video.Compression;
					if (!this.hashtable.ContainsKey(compression))
					{
						this.hashtable.Add(compression, this.shellObjectParent.Properties.CreateTypedProperty<string>(compression));
					}
					return this.hashtable[compression] as ShellProperty<string>;
				}
			}

			// Token: 0x17000432 RID: 1074
			// (get) Token: 0x0600086F RID: 2159 RVA: 0x0002436C File Offset: 0x0002256C
			public ShellProperty<string[]> Director
			{
				get
				{
					PropertyKey director = SystemProperties.System.Video.Director;
					if (!this.hashtable.ContainsKey(director))
					{
						this.hashtable.Add(director, this.shellObjectParent.Properties.CreateTypedProperty<string[]>(director));
					}
					return this.hashtable[director] as ShellProperty<string[]>;
				}
			}

			// Token: 0x17000433 RID: 1075
			// (get) Token: 0x06000870 RID: 2160 RVA: 0x000243D4 File Offset: 0x000225D4
			public ShellProperty<uint?> EncodingBitrate
			{
				get
				{
					PropertyKey encodingBitrate = SystemProperties.System.Video.EncodingBitrate;
					if (!this.hashtable.ContainsKey(encodingBitrate))
					{
						this.hashtable.Add(encodingBitrate, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(encodingBitrate));
					}
					return this.hashtable[encodingBitrate] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000434 RID: 1076
			// (get) Token: 0x06000871 RID: 2161 RVA: 0x0002443C File Offset: 0x0002263C
			public ShellProperty<uint?> FourCC
			{
				get
				{
					PropertyKey fourCC = SystemProperties.System.Video.FourCC;
					if (!this.hashtable.ContainsKey(fourCC))
					{
						this.hashtable.Add(fourCC, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(fourCC));
					}
					return this.hashtable[fourCC] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000435 RID: 1077
			// (get) Token: 0x06000872 RID: 2162 RVA: 0x000244A4 File Offset: 0x000226A4
			public ShellProperty<uint?> FrameHeight
			{
				get
				{
					PropertyKey frameHeight = SystemProperties.System.Video.FrameHeight;
					if (!this.hashtable.ContainsKey(frameHeight))
					{
						this.hashtable.Add(frameHeight, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(frameHeight));
					}
					return this.hashtable[frameHeight] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000436 RID: 1078
			// (get) Token: 0x06000873 RID: 2163 RVA: 0x0002450C File Offset: 0x0002270C
			public ShellProperty<uint?> FrameRate
			{
				get
				{
					PropertyKey frameRate = SystemProperties.System.Video.FrameRate;
					if (!this.hashtable.ContainsKey(frameRate))
					{
						this.hashtable.Add(frameRate, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(frameRate));
					}
					return this.hashtable[frameRate] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000437 RID: 1079
			// (get) Token: 0x06000874 RID: 2164 RVA: 0x00024574 File Offset: 0x00022774
			public ShellProperty<uint?> FrameWidth
			{
				get
				{
					PropertyKey frameWidth = SystemProperties.System.Video.FrameWidth;
					if (!this.hashtable.ContainsKey(frameWidth))
					{
						this.hashtable.Add(frameWidth, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(frameWidth));
					}
					return this.hashtable[frameWidth] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000438 RID: 1080
			// (get) Token: 0x06000875 RID: 2165 RVA: 0x000245DC File Offset: 0x000227DC
			public ShellProperty<uint?> HorizontalAspectRatio
			{
				get
				{
					PropertyKey horizontalAspectRatio = SystemProperties.System.Video.HorizontalAspectRatio;
					if (!this.hashtable.ContainsKey(horizontalAspectRatio))
					{
						this.hashtable.Add(horizontalAspectRatio, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(horizontalAspectRatio));
					}
					return this.hashtable[horizontalAspectRatio] as ShellProperty<uint?>;
				}
			}

			// Token: 0x17000439 RID: 1081
			// (get) Token: 0x06000876 RID: 2166 RVA: 0x00024644 File Offset: 0x00022844
			public ShellProperty<uint?> SampleSize
			{
				get
				{
					PropertyKey sampleSize = SystemProperties.System.Video.SampleSize;
					if (!this.hashtable.ContainsKey(sampleSize))
					{
						this.hashtable.Add(sampleSize, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(sampleSize));
					}
					return this.hashtable[sampleSize] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700043A RID: 1082
			// (get) Token: 0x06000877 RID: 2167 RVA: 0x000246AC File Offset: 0x000228AC
			public ShellProperty<string> StreamName
			{
				get
				{
					PropertyKey streamName = SystemProperties.System.Video.StreamName;
					if (!this.hashtable.ContainsKey(streamName))
					{
						this.hashtable.Add(streamName, this.shellObjectParent.Properties.CreateTypedProperty<string>(streamName));
					}
					return this.hashtable[streamName] as ShellProperty<string>;
				}
			}

			// Token: 0x1700043B RID: 1083
			// (get) Token: 0x06000878 RID: 2168 RVA: 0x00024714 File Offset: 0x00022914
			public ShellProperty<ushort?> StreamNumber
			{
				get
				{
					PropertyKey streamNumber = SystemProperties.System.Video.StreamNumber;
					if (!this.hashtable.ContainsKey(streamNumber))
					{
						this.hashtable.Add(streamNumber, this.shellObjectParent.Properties.CreateTypedProperty<ushort?>(streamNumber));
					}
					return this.hashtable[streamNumber] as ShellProperty<ushort?>;
				}
			}

			// Token: 0x1700043C RID: 1084
			// (get) Token: 0x06000879 RID: 2169 RVA: 0x0002477C File Offset: 0x0002297C
			public ShellProperty<uint?> TotalBitrate
			{
				get
				{
					PropertyKey totalBitrate = SystemProperties.System.Video.TotalBitrate;
					if (!this.hashtable.ContainsKey(totalBitrate))
					{
						this.hashtable.Add(totalBitrate, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(totalBitrate));
					}
					return this.hashtable[totalBitrate] as ShellProperty<uint?>;
				}
			}

			// Token: 0x1700043D RID: 1085
			// (get) Token: 0x0600087A RID: 2170 RVA: 0x000247E4 File Offset: 0x000229E4
			public ShellProperty<bool?> TranscodedForSync
			{
				get
				{
					PropertyKey transcodedForSync = SystemProperties.System.Video.TranscodedForSync;
					if (!this.hashtable.ContainsKey(transcodedForSync))
					{
						this.hashtable.Add(transcodedForSync, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(transcodedForSync));
					}
					return this.hashtable[transcodedForSync] as ShellProperty<bool?>;
				}
			}

			// Token: 0x1700043E RID: 1086
			// (get) Token: 0x0600087B RID: 2171 RVA: 0x0002484C File Offset: 0x00022A4C
			public ShellProperty<uint?> VerticalAspectRatio
			{
				get
				{
					PropertyKey verticalAspectRatio = SystemProperties.System.Video.VerticalAspectRatio;
					if (!this.hashtable.ContainsKey(verticalAspectRatio))
					{
						this.hashtable.Add(verticalAspectRatio, this.shellObjectParent.Properties.CreateTypedProperty<uint?>(verticalAspectRatio));
					}
					return this.hashtable[verticalAspectRatio] as ShellProperty<uint?>;
				}
			}

			// Token: 0x0400039F RID: 927
			private ShellObject shellObjectParent;

			// Token: 0x040003A0 RID: 928
			private Hashtable hashtable = new Hashtable();
		}

		// Token: 0x020000D1 RID: 209
		public class PropertySystemVolume : PropertyStoreItems
		{
			// Token: 0x0600087C RID: 2172 RVA: 0x000248B4 File Offset: 0x00022AB4
			internal PropertySystemVolume(ShellObject parent)
			{
				this.shellObjectParent = parent;
			}

			// Token: 0x1700043F RID: 1087
			// (get) Token: 0x0600087D RID: 2173 RVA: 0x000248D4 File Offset: 0x00022AD4
			public ShellProperty<string> FileSystem
			{
				get
				{
					PropertyKey fileSystem = SystemProperties.System.Volume.FileSystem;
					if (!this.hashtable.ContainsKey(fileSystem))
					{
						this.hashtable.Add(fileSystem, this.shellObjectParent.Properties.CreateTypedProperty<string>(fileSystem));
					}
					return this.hashtable[fileSystem] as ShellProperty<string>;
				}
			}

			// Token: 0x17000440 RID: 1088
			// (get) Token: 0x0600087E RID: 2174 RVA: 0x0002493C File Offset: 0x00022B3C
			public ShellProperty<bool?> IsMappedDrive
			{
				get
				{
					PropertyKey isMappedDrive = SystemProperties.System.Volume.IsMappedDrive;
					if (!this.hashtable.ContainsKey(isMappedDrive))
					{
						this.hashtable.Add(isMappedDrive, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isMappedDrive));
					}
					return this.hashtable[isMappedDrive] as ShellProperty<bool?>;
				}
			}

			// Token: 0x17000441 RID: 1089
			// (get) Token: 0x0600087F RID: 2175 RVA: 0x000249A4 File Offset: 0x00022BA4
			public ShellProperty<bool?> IsRoot
			{
				get
				{
					PropertyKey isRoot = SystemProperties.System.Volume.IsRoot;
					if (!this.hashtable.ContainsKey(isRoot))
					{
						this.hashtable.Add(isRoot, this.shellObjectParent.Properties.CreateTypedProperty<bool?>(isRoot));
					}
					return this.hashtable[isRoot] as ShellProperty<bool?>;
				}
			}

			// Token: 0x040003A1 RID: 929
			private ShellObject shellObjectParent;

			// Token: 0x040003A2 RID: 930
			private Hashtable hashtable = new Hashtable();
		}
	}
}
