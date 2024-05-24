using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;
using Microsoft.Practices.Unity.Properties;
using Microsoft.Practices.Unity.Utility;

namespace Microsoft.Practices.Unity
{
	// Token: 0x02000003 RID: 3
	[SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly", Justification = "Implementing serialization with the new transparent approach")]
	[SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "The standard constructors don't make sense for this exception, as calling them will leave out the information that makes the exception useful in the first place.")]
	[Serializable]
	public class DuplicateTypeMappingException : Exception
	{
		// Token: 0x06000011 RID: 17 RVA: 0x000025C4 File Offset: 0x000007C4
		[SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods", Justification = "Validation done by Guard class")]
		public DuplicateTypeMappingException(string name, Type mappedFromType, Type currentMappedToType, Type newMappedToType) : base(DuplicateTypeMappingException.CreateMessage(name, mappedFromType, currentMappedToType, newMappedToType))
		{
			Guard.ArgumentNotNull(mappedFromType, "mappedFromType");
			Guard.ArgumentNotNull(currentMappedToType, "currentMappedToType");
			Guard.ArgumentNotNull(newMappedToType, "newMappedToType");
			this.name = name;
			this.mappedFromType = mappedFromType.AssemblyQualifiedName;
			this.currentMappedToType = currentMappedToType.AssemblyQualifiedName;
			this.newMappedToType = newMappedToType.AssemblyQualifiedName;
			this.RegisterSerializationHandler();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002638 File Offset: 0x00000838
		private static string CreateMessage(string name, Type mappedFromType, Type currentMappedToType, Type newMappedToType)
		{
			return string.Format(CultureInfo.CurrentCulture, Resources.DuplicateTypeMappingException, new object[]
			{
				name,
				mappedFromType,
				currentMappedToType,
				newMappedToType
			});
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000013 RID: 19 RVA: 0x0000266C File Offset: 0x0000086C
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002674 File Offset: 0x00000874
		public string MappedFromType
		{
			get
			{
				return this.mappedFromType;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000015 RID: 21 RVA: 0x0000267C File Offset: 0x0000087C
		public string CurrentMappedToType
		{
			get
			{
				return this.currentMappedToType;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002684 File Offset: 0x00000884
		public string NewMappedToType
		{
			get
			{
				return this.newMappedToType;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000026B6 File Offset: 0x000008B6
		private void RegisterSerializationHandler()
		{
			base.SerializeObjectState += delegate(object s, SafeSerializationEventArgs e)
			{
				e.AddSerializedState(new DuplicateTypeMappingException.DuplicateTypeMappingExceptionSerializationData(this.name, this.mappedFromType, this.currentMappedToType, this.newMappedToType));
			};
		}

		// Token: 0x04000003 RID: 3
		private string name;

		// Token: 0x04000004 RID: 4
		private string mappedFromType;

		// Token: 0x04000005 RID: 5
		private string currentMappedToType;

		// Token: 0x04000006 RID: 6
		private string newMappedToType;

		// Token: 0x02000004 RID: 4
		[Serializable]
		private struct DuplicateTypeMappingExceptionSerializationData : ISafeSerializationData
		{
			// Token: 0x06000019 RID: 25 RVA: 0x000026CA File Offset: 0x000008CA
			public DuplicateTypeMappingExceptionSerializationData(string name, string mappedFromType, string currentMappedToType, string newMappedToType)
			{
				this.name = name;
				this.mappedFromType = mappedFromType;
				this.currentMappedToType = currentMappedToType;
				this.newMappedToType = newMappedToType;
			}

			// Token: 0x0600001A RID: 26 RVA: 0x000026EC File Offset: 0x000008EC
			public void CompleteDeserialization(object deserialized)
			{
				DuplicateTypeMappingException ex = (DuplicateTypeMappingException)deserialized;
				ex.name = this.name;
				ex.mappedFromType = this.mappedFromType;
				ex.currentMappedToType = this.currentMappedToType;
				ex.newMappedToType = this.newMappedToType;
			}

			// Token: 0x04000007 RID: 7
			private string name;

			// Token: 0x04000008 RID: 8
			private string mappedFromType;

			// Token: 0x04000009 RID: 9
			private string currentMappedToType;

			// Token: 0x0400000A RID: 10
			private string newMappedToType;
		}
	}
}
