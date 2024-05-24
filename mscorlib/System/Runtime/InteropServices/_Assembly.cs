﻿using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Policy;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000902 RID: 2306
	[Guid("17156360-2f1a-384a-bc52-fde93c215c5b")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[TypeLibImportClass(typeof(Assembly))]
	[CLSCompliant(false)]
	[ComVisible(true)]
	public interface _Assembly
	{
		// Token: 0x06005ECD RID: 24269
		string ToString();

		// Token: 0x06005ECE RID: 24270
		bool Equals(object other);

		// Token: 0x06005ECF RID: 24271
		int GetHashCode();

		// Token: 0x06005ED0 RID: 24272
		Type GetType();

		// Token: 0x17001061 RID: 4193
		// (get) Token: 0x06005ED1 RID: 24273
		string CodeBase { get; }

		// Token: 0x17001062 RID: 4194
		// (get) Token: 0x06005ED2 RID: 24274
		string EscapedCodeBase { get; }

		// Token: 0x06005ED3 RID: 24275
		AssemblyName GetName();

		// Token: 0x06005ED4 RID: 24276
		AssemblyName GetName(bool copiedName);

		// Token: 0x17001063 RID: 4195
		// (get) Token: 0x06005ED5 RID: 24277
		string FullName { get; }

		// Token: 0x17001064 RID: 4196
		// (get) Token: 0x06005ED6 RID: 24278
		MethodInfo EntryPoint { get; }

		// Token: 0x06005ED7 RID: 24279
		Type GetType(string name);

		// Token: 0x06005ED8 RID: 24280
		Type GetType(string name, bool throwOnError);

		// Token: 0x06005ED9 RID: 24281
		Type[] GetExportedTypes();

		// Token: 0x06005EDA RID: 24282
		Type[] GetTypes();

		// Token: 0x06005EDB RID: 24283
		Stream GetManifestResourceStream(Type type, string name);

		// Token: 0x06005EDC RID: 24284
		Stream GetManifestResourceStream(string name);

		// Token: 0x06005EDD RID: 24285
		FileStream GetFile(string name);

		// Token: 0x06005EDE RID: 24286
		FileStream[] GetFiles();

		// Token: 0x06005EDF RID: 24287
		FileStream[] GetFiles(bool getResourceModules);

		// Token: 0x06005EE0 RID: 24288
		string[] GetManifestResourceNames();

		// Token: 0x06005EE1 RID: 24289
		ManifestResourceInfo GetManifestResourceInfo(string resourceName);

		// Token: 0x17001065 RID: 4197
		// (get) Token: 0x06005EE2 RID: 24290
		string Location { get; }

		// Token: 0x17001066 RID: 4198
		// (get) Token: 0x06005EE3 RID: 24291
		Evidence Evidence { get; }

		// Token: 0x06005EE4 RID: 24292
		object[] GetCustomAttributes(Type attributeType, bool inherit);

		// Token: 0x06005EE5 RID: 24293
		object[] GetCustomAttributes(bool inherit);

		// Token: 0x06005EE6 RID: 24294
		bool IsDefined(Type attributeType, bool inherit);

		// Token: 0x06005EE7 RID: 24295
		[SecurityCritical]
		void GetObjectData(SerializationInfo info, StreamingContext context);

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06005EE8 RID: 24296
		// (remove) Token: 0x06005EE9 RID: 24297
		event ModuleResolveEventHandler ModuleResolve;

		// Token: 0x06005EEA RID: 24298
		Type GetType(string name, bool throwOnError, bool ignoreCase);

		// Token: 0x06005EEB RID: 24299
		Assembly GetSatelliteAssembly(CultureInfo culture);

		// Token: 0x06005EEC RID: 24300
		Assembly GetSatelliteAssembly(CultureInfo culture, Version version);

		// Token: 0x06005EED RID: 24301
		Module LoadModule(string moduleName, byte[] rawModule);

		// Token: 0x06005EEE RID: 24302
		Module LoadModule(string moduleName, byte[] rawModule, byte[] rawSymbolStore);

		// Token: 0x06005EEF RID: 24303
		object CreateInstance(string typeName);

		// Token: 0x06005EF0 RID: 24304
		object CreateInstance(string typeName, bool ignoreCase);

		// Token: 0x06005EF1 RID: 24305
		object CreateInstance(string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes);

		// Token: 0x06005EF2 RID: 24306
		Module[] GetLoadedModules();

		// Token: 0x06005EF3 RID: 24307
		Module[] GetLoadedModules(bool getResourceModules);

		// Token: 0x06005EF4 RID: 24308
		Module[] GetModules();

		// Token: 0x06005EF5 RID: 24309
		Module[] GetModules(bool getResourceModules);

		// Token: 0x06005EF6 RID: 24310
		Module GetModule(string name);

		// Token: 0x06005EF7 RID: 24311
		AssemblyName[] GetReferencedAssemblies();

		// Token: 0x17001067 RID: 4199
		// (get) Token: 0x06005EF8 RID: 24312
		bool GlobalAssemblyCache { get; }
	}
}
