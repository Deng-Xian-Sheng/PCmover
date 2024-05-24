using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Threading;

namespace System.Resources
{
	// Token: 0x0200038B RID: 907
	internal class FileBasedResourceGroveler : IResourceGroveler
	{
		// Token: 0x06002CE2 RID: 11490 RVA: 0x000A92F2 File Offset: 0x000A74F2
		public FileBasedResourceGroveler(ResourceManager.ResourceManagerMediator mediator)
		{
			this._mediator = mediator;
		}

		// Token: 0x06002CE3 RID: 11491 RVA: 0x000A9304 File Offset: 0x000A7504
		[SecuritySafeCritical]
		public ResourceSet GrovelForResourceSet(CultureInfo culture, Dictionary<string, ResourceSet> localResourceSets, bool tryParents, bool createIfNotExists, ref StackCrawlMark stackMark)
		{
			ResourceSet resourceSet = null;
			ResourceSet result;
			try
			{
				new FileIOPermission(PermissionState.Unrestricted).Assert();
				string resourceFileName = this._mediator.GetResourceFileName(culture);
				string text = this.FindResourceFile(culture, resourceFileName);
				if (text == null)
				{
					if (tryParents && culture.HasInvariantCultureName)
					{
						throw new MissingManifestResourceException(string.Concat(new string[]
						{
							Environment.GetResourceString("MissingManifestResource_NoNeutralDisk"),
							Environment.NewLine,
							"baseName: ",
							this._mediator.BaseNameField,
							"  locationInfo: ",
							(this._mediator.LocationInfo == null) ? "<null>" : this._mediator.LocationInfo.FullName,
							"  fileName: ",
							this._mediator.GetResourceFileName(culture)
						}));
					}
				}
				else
				{
					resourceSet = this.CreateResourceSet(text);
				}
				result = resourceSet;
			}
			finally
			{
				CodeAccessPermission.RevertAssert();
			}
			return result;
		}

		// Token: 0x06002CE4 RID: 11492 RVA: 0x000A93F8 File Offset: 0x000A75F8
		public bool HasNeutralResources(CultureInfo culture, string defaultResName)
		{
			string text = this.FindResourceFile(culture, defaultResName);
			if (text == null || !File.Exists(text))
			{
				string text2 = this._mediator.ModuleDir;
				if (text != null)
				{
					text2 = Path.GetDirectoryName(text);
				}
				return false;
			}
			return true;
		}

		// Token: 0x06002CE5 RID: 11493 RVA: 0x000A9434 File Offset: 0x000A7634
		private string FindResourceFile(CultureInfo culture, string fileName)
		{
			if (this._mediator.ModuleDir != null)
			{
				string text = Path.Combine(this._mediator.ModuleDir, fileName);
				if (File.Exists(text))
				{
					return text;
				}
			}
			if (File.Exists(fileName))
			{
				return fileName;
			}
			return null;
		}

		// Token: 0x06002CE6 RID: 11494 RVA: 0x000A9478 File Offset: 0x000A7678
		[SecurityCritical]
		private ResourceSet CreateResourceSet(string file)
		{
			if (this._mediator.UserResourceSet == null)
			{
				return new RuntimeResourceSet(file);
			}
			object[] args = new object[]
			{
				file
			};
			ResourceSet result;
			try
			{
				result = (ResourceSet)Activator.CreateInstance(this._mediator.UserResourceSet, args);
			}
			catch (MissingMethodException innerException)
			{
				throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ResMgrBadResSet_Type", new object[]
				{
					this._mediator.UserResourceSet.AssemblyQualifiedName
				}), innerException);
			}
			return result;
		}

		// Token: 0x04001224 RID: 4644
		private ResourceManager.ResourceManagerMediator _mediator;
	}
}
