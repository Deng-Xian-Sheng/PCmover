using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using RestSharp.Serialization;

namespace RestSharp
{
	// Token: 0x0200001B RID: 27
	[NullableContext(1)]
	[Nullable(0)]
	public static class RestClientExtensions
	{
		// Token: 0x060002B9 RID: 697 RVA: 0x00005640 File Offset: 0x00003840
		[Obsolete("Use ExecuteAsync that returns Task")]
		public static RestRequestAsyncHandle ExecuteAsync(this IRestClient client, IRestRequest request, Action<IRestResponse> callback)
		{
			return client.ExecuteAsync(request, delegate(IRestResponse response, RestRequestAsyncHandle handle)
			{
				callback(response);
			});
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00005670 File Offset: 0x00003870
		[Obsolete("Use ExecuteAsync that returns Task")]
		public static RestRequestAsyncHandle ExecuteAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>> callback) where T : new()
		{
			return client.ExecuteAsync<T>(request, delegate([Nullable(new byte[]
			{
				1,
				0
			})] IRestResponse<T> response, RestRequestAsyncHandle asyncHandle)
			{
				callback(response);
			});
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000569D File Offset: 0x0000389D
		[Obsolete("Use GetAsync that returns Task")]
		public static RestRequestAsyncHandle GetAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback) where T : new()
		{
			return client.ExecuteAsync<T>(request, callback, Method.GET);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x000056A8 File Offset: 0x000038A8
		[Obsolete("Use PostAsync that returns Task")]
		public static RestRequestAsyncHandle PostAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback) where T : new()
		{
			return client.ExecuteAsync<T>(request, callback, Method.POST);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x000056B3 File Offset: 0x000038B3
		[Obsolete("Use PutAsync that returns Task")]
		public static RestRequestAsyncHandle PutAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback) where T : new()
		{
			return client.ExecuteAsync<T>(request, callback, Method.PUT);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x000056BE File Offset: 0x000038BE
		[Obsolete("Use HeadAsync that returns Task")]
		public static RestRequestAsyncHandle HeadAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback) where T : new()
		{
			return client.ExecuteAsync<T>(request, callback, Method.HEAD);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x000056C9 File Offset: 0x000038C9
		[Obsolete("Use OptionsAsync that returns Task")]
		public static RestRequestAsyncHandle OptionsAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback) where T : new()
		{
			return client.ExecuteAsync<T>(request, callback, Method.OPTIONS);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x000056D4 File Offset: 0x000038D4
		[Obsolete("Use PatchAsync that returns Task")]
		public static RestRequestAsyncHandle PatchAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback) where T : new()
		{
			return client.ExecuteAsync<T>(request, callback, Method.PATCH);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x000056DF File Offset: 0x000038DF
		[Obsolete("Use DeleteAsync that returns Task")]
		public static RestRequestAsyncHandle DeleteAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback) where T : new()
		{
			return client.ExecuteAsync<T>(request, callback, Method.DELETE);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x000056EA File Offset: 0x000038EA
		[Obsolete("Use GetAsync that returns Task")]
		public static RestRequestAsyncHandle GetAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
		{
			return client.ExecuteAsync(request, callback, Method.GET);
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x000056F5 File Offset: 0x000038F5
		[Obsolete("Use PostAsync that returns Task")]
		public static RestRequestAsyncHandle PostAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
		{
			return client.ExecuteAsync(request, callback, Method.POST);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00005700 File Offset: 0x00003900
		[Obsolete("Use PutAsync that returns Task")]
		public static RestRequestAsyncHandle PutAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
		{
			return client.ExecuteAsync(request, callback, Method.PUT);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0000570B File Offset: 0x0000390B
		[Obsolete("Use HeadAsync that returns Task")]
		public static RestRequestAsyncHandle HeadAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
		{
			return client.ExecuteAsync(request, callback, Method.HEAD);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00005716 File Offset: 0x00003916
		[Obsolete("Use OptionsAsync that returns Task")]
		public static RestRequestAsyncHandle OptionsAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
		{
			return client.ExecuteAsync(request, callback, Method.OPTIONS);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00005721 File Offset: 0x00003921
		[Obsolete("Use PatchAsync that returns Task")]
		public static RestRequestAsyncHandle PatchAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
		{
			return client.ExecuteAsync(request, callback, Method.PATCH);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000572C File Offset: 0x0000392C
		[Obsolete("Use DeleteAsync that returns Task")]
		public static RestRequestAsyncHandle DeleteAsync(this IRestClient client, IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
		{
			return client.ExecuteAsync(request, callback, Method.DELETE);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00005738 File Offset: 0x00003938
		[Obsolete("Use GetAsync")]
		public static Task<T> GetTaskAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			Task<IRestResponse<T>> task = client.ExecuteGetAsync<T>(request, default(CancellationToken));
			Func<Task<IRestResponse<T>>, T> continuationFunction;
			if ((continuationFunction = RestClientExtensions.<>c__16<T>.<>9__16_0) == null)
			{
				Func<Task<IRestResponse<T>>, T> func = RestClientExtensions.<>c__16<T>.<>9__16_0 = (([Nullable(new byte[]
				{
					0,
					1,
					0
				})] Task<IRestResponse<T>> x) => x.Result.Data);
				continuationFunction = func;
			}
			return task.ContinueWith<T>(continuationFunction);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0000577C File Offset: 0x0000397C
		[Obsolete("Use PostAsync")]
		public static Task<T> PostTaskAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			Task<IRestResponse<T>> task = client.ExecutePostAsync<T>(request, default(CancellationToken));
			Func<Task<IRestResponse<T>>, T> continuationFunction;
			if ((continuationFunction = RestClientExtensions.<>c__17<T>.<>9__17_0) == null)
			{
				Func<Task<IRestResponse<T>>, T> func = RestClientExtensions.<>c__17<T>.<>9__17_0 = (([Nullable(new byte[]
				{
					0,
					1,
					0
				})] Task<IRestResponse<T>> x) => x.Result.Data);
				continuationFunction = func;
			}
			return task.ContinueWith<T>(continuationFunction);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x000057C0 File Offset: 0x000039C0
		[Obsolete("Use PutAsync")]
		public static Task<T> PutTaskAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			Task<IRestResponse<T>> task = client.ExecuteAsync<T>(request, Method.PUT, default(CancellationToken));
			Func<Task<IRestResponse<T>>, T> continuationFunction;
			if ((continuationFunction = RestClientExtensions.<>c__18<T>.<>9__18_0) == null)
			{
				Func<Task<IRestResponse<T>>, T> func = RestClientExtensions.<>c__18<T>.<>9__18_0 = (([Nullable(new byte[]
				{
					0,
					1,
					0
				})] Task<IRestResponse<T>> x) => x.Result.Data);
				continuationFunction = func;
			}
			return task.ContinueWith<T>(continuationFunction);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00005804 File Offset: 0x00003A04
		[Obsolete("Use HeadAsync")]
		public static Task<T> HeadTaskAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			Task<IRestResponse<T>> task = client.ExecuteAsync<T>(request, Method.HEAD, default(CancellationToken));
			Func<Task<IRestResponse<T>>, T> continuationFunction;
			if ((continuationFunction = RestClientExtensions.<>c__19<T>.<>9__19_0) == null)
			{
				Func<Task<IRestResponse<T>>, T> func = RestClientExtensions.<>c__19<T>.<>9__19_0 = (([Nullable(new byte[]
				{
					0,
					1,
					0
				})] Task<IRestResponse<T>> x) => x.Result.Data);
				continuationFunction = func;
			}
			return task.ContinueWith<T>(continuationFunction);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00005848 File Offset: 0x00003A48
		[Obsolete("Use OptionsAsync")]
		public static Task<T> OptionsTaskAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			Task<IRestResponse<T>> task = client.ExecuteAsync<T>(request, Method.OPTIONS, default(CancellationToken));
			Func<Task<IRestResponse<T>>, T> continuationFunction;
			if ((continuationFunction = RestClientExtensions.<>c__20<T>.<>9__20_0) == null)
			{
				Func<Task<IRestResponse<T>>, T> func = RestClientExtensions.<>c__20<T>.<>9__20_0 = (([Nullable(new byte[]
				{
					0,
					1,
					0
				})] Task<IRestResponse<T>> x) => x.Result.Data);
				continuationFunction = func;
			}
			return task.ContinueWith<T>(continuationFunction);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000588C File Offset: 0x00003A8C
		[Obsolete("Use PatchAsync")]
		public static Task<T> PatchTaskAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			Task<IRestResponse<T>> task = client.ExecuteAsync<T>(request, Method.PATCH, default(CancellationToken));
			Func<Task<IRestResponse<T>>, T> continuationFunction;
			if ((continuationFunction = RestClientExtensions.<>c__21<T>.<>9__21_0) == null)
			{
				Func<Task<IRestResponse<T>>, T> func = RestClientExtensions.<>c__21<T>.<>9__21_0 = (([Nullable(new byte[]
				{
					0,
					1,
					0
				})] Task<IRestResponse<T>> x) => x.Result.Data);
				continuationFunction = func;
			}
			return task.ContinueWith<T>(continuationFunction);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x000058D0 File Offset: 0x00003AD0
		[Obsolete("Use DeleteAsync")]
		public static Task<T> DeleteTaskAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			Task<IRestResponse<T>> task = client.ExecuteAsync<T>(request, Method.DELETE, default(CancellationToken));
			Func<Task<IRestResponse<T>>, T> continuationFunction;
			if ((continuationFunction = RestClientExtensions.<>c__22<T>.<>9__22_0) == null)
			{
				Func<Task<IRestResponse<T>>, T> func = RestClientExtensions.<>c__22<T>.<>9__22_0 = (([Nullable(new byte[]
				{
					0,
					1,
					0
				})] Task<IRestResponse<T>> x) => x.Result.Data);
				continuationFunction = func;
			}
			return task.ContinueWith<T>(continuationFunction);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00005914 File Offset: 0x00003B14
		[return: Dynamic(new bool[]
		{
			false,
			true
		})]
		public static IRestResponse<dynamic> ExecuteDynamic(this IRestClient client, IRestRequest request)
		{
			IRestResponse<object> restResponse = client.Execute<object>(request);
			RestResponse<object> restResponse2 = (RestResponse<object>)restResponse;
			object data = client.Deserialize<object>(restResponse);
			restResponse2.Data = data;
			return restResponse2;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00005940 File Offset: 0x00003B40
		public static Task<T> GetAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			RestClientExtensions.<GetAsync>d__24<T> <GetAsync>d__;
			<GetAsync>d__.client = client;
			<GetAsync>d__.request = request;
			<GetAsync>d__.cancellationToken = cancellationToken;
			<GetAsync>d__.<>t__builder = AsyncTaskMethodBuilder<T>.Create();
			<GetAsync>d__.<>1__state = -1;
			<GetAsync>d__.<>t__builder.Start<RestClientExtensions.<GetAsync>d__24<T>>(ref <GetAsync>d__);
			return <GetAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00005994 File Offset: 0x00003B94
		public static Task<T> PostAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			RestClientExtensions.<PostAsync>d__25<T> <PostAsync>d__;
			<PostAsync>d__.client = client;
			<PostAsync>d__.request = request;
			<PostAsync>d__.cancellationToken = cancellationToken;
			<PostAsync>d__.<>t__builder = AsyncTaskMethodBuilder<T>.Create();
			<PostAsync>d__.<>1__state = -1;
			<PostAsync>d__.<>t__builder.Start<RestClientExtensions.<PostAsync>d__25<T>>(ref <PostAsync>d__);
			return <PostAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000059E8 File Offset: 0x00003BE8
		public static Task<T> PutAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			RestClientExtensions.<PutAsync>d__26<T> <PutAsync>d__;
			<PutAsync>d__.client = client;
			<PutAsync>d__.request = request;
			<PutAsync>d__.cancellationToken = cancellationToken;
			<PutAsync>d__.<>t__builder = AsyncTaskMethodBuilder<T>.Create();
			<PutAsync>d__.<>1__state = -1;
			<PutAsync>d__.<>t__builder.Start<RestClientExtensions.<PutAsync>d__26<T>>(ref <PutAsync>d__);
			return <PutAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00005A3C File Offset: 0x00003C3C
		public static Task<T> HeadAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			RestClientExtensions.<HeadAsync>d__27<T> <HeadAsync>d__;
			<HeadAsync>d__.client = client;
			<HeadAsync>d__.request = request;
			<HeadAsync>d__.cancellationToken = cancellationToken;
			<HeadAsync>d__.<>t__builder = AsyncTaskMethodBuilder<T>.Create();
			<HeadAsync>d__.<>1__state = -1;
			<HeadAsync>d__.<>t__builder.Start<RestClientExtensions.<HeadAsync>d__27<T>>(ref <HeadAsync>d__);
			return <HeadAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00005A90 File Offset: 0x00003C90
		public static Task<T> OptionsAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			RestClientExtensions.<OptionsAsync>d__28<T> <OptionsAsync>d__;
			<OptionsAsync>d__.client = client;
			<OptionsAsync>d__.request = request;
			<OptionsAsync>d__.cancellationToken = cancellationToken;
			<OptionsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<T>.Create();
			<OptionsAsync>d__.<>1__state = -1;
			<OptionsAsync>d__.<>t__builder.Start<RestClientExtensions.<OptionsAsync>d__28<T>>(ref <OptionsAsync>d__);
			return <OptionsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00005AE4 File Offset: 0x00003CE4
		public static Task<T> PatchAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			RestClientExtensions.<PatchAsync>d__29<T> <PatchAsync>d__;
			<PatchAsync>d__.client = client;
			<PatchAsync>d__.request = request;
			<PatchAsync>d__.cancellationToken = cancellationToken;
			<PatchAsync>d__.<>t__builder = AsyncTaskMethodBuilder<T>.Create();
			<PatchAsync>d__.<>1__state = -1;
			<PatchAsync>d__.<>t__builder.Start<RestClientExtensions.<PatchAsync>d__29<T>>(ref <PatchAsync>d__);
			return <PatchAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00005B38 File Offset: 0x00003D38
		public static Task<T> DeleteAsync<[Nullable(2)] T>(this IRestClient client, IRestRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			RestClientExtensions.<DeleteAsync>d__30<T> <DeleteAsync>d__;
			<DeleteAsync>d__.client = client;
			<DeleteAsync>d__.request = request;
			<DeleteAsync>d__.cancellationToken = cancellationToken;
			<DeleteAsync>d__.<>t__builder = AsyncTaskMethodBuilder<T>.Create();
			<DeleteAsync>d__.<>1__state = -1;
			<DeleteAsync>d__.<>t__builder.Start<RestClientExtensions.<DeleteAsync>d__30<T>>(ref <DeleteAsync>d__);
			return <DeleteAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00005B8B File Offset: 0x00003D8B
		public static IRestResponse<T> Get<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			return client.Execute<T>(request, Method.GET);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00005B95 File Offset: 0x00003D95
		public static IRestResponse<T> Post<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			return client.Execute<T>(request, Method.POST);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00005B9F File Offset: 0x00003D9F
		public static IRestResponse<T> Put<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			return client.Execute<T>(request, Method.PUT);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00005BA9 File Offset: 0x00003DA9
		public static IRestResponse<T> Head<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			return client.Execute<T>(request, Method.HEAD);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00005BB3 File Offset: 0x00003DB3
		public static IRestResponse<T> Options<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			return client.Execute<T>(request, Method.OPTIONS);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00005BBD File Offset: 0x00003DBD
		public static IRestResponse<T> Patch<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			return client.Execute<T>(request, Method.PATCH);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00005BC7 File Offset: 0x00003DC7
		public static IRestResponse<T> Delete<[Nullable(2)] T>(this IRestClient client, IRestRequest request)
		{
			return client.Execute<T>(request, Method.DELETE);
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00005BD1 File Offset: 0x00003DD1
		public static IRestResponse Get(this IRestClient client, IRestRequest request)
		{
			return client.Execute(request, Method.GET);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00005BDB File Offset: 0x00003DDB
		public static IRestResponse Post(this IRestClient client, IRestRequest request)
		{
			return client.Execute(request, Method.POST);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00005BE5 File Offset: 0x00003DE5
		public static IRestResponse Put(this IRestClient client, IRestRequest request)
		{
			return client.Execute(request, Method.PUT);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00005BEF File Offset: 0x00003DEF
		public static IRestResponse Head(this IRestClient client, IRestRequest request)
		{
			return client.Execute(request, Method.HEAD);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00005BF9 File Offset: 0x00003DF9
		public static IRestResponse Options(this IRestClient client, IRestRequest request)
		{
			return client.Execute(request, Method.OPTIONS);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00005C03 File Offset: 0x00003E03
		public static IRestResponse Patch(this IRestClient client, IRestRequest request)
		{
			return client.Execute(request, Method.PATCH);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00005C0D File Offset: 0x00003E0D
		public static IRestResponse Delete(this IRestClient client, IRestRequest request)
		{
			return client.Execute(request, Method.DELETE);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00005C17 File Offset: 0x00003E17
		public static IRestClient AddDefaultParameter(this IRestClient restClient, Parameter p)
		{
			if (p.Type == ParameterType.RequestBody)
			{
				throw new NotSupportedException("Cannot set request body from default headers. Use Request.AddBody() instead.");
			}
			restClient.DefaultParameters.Add(p);
			return restClient;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00005C3C File Offset: 0x00003E3C
		public static IRestClient AddOrUpdateDefaultParameter(this IRestClient restClient, Parameter p)
		{
			Parameter parameter = restClient.DefaultParameters.FirstOrDefault((Parameter x) => x.Name == p.Name);
			if (parameter != null)
			{
				restClient.DefaultParameters.Remove(parameter);
			}
			restClient.DefaultParameters.Add(p);
			return restClient;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00005C90 File Offset: 0x00003E90
		public static IRestClient RemoveDefaultParameter(this IRestClient restClient, string name)
		{
			Parameter parameter = restClient.DefaultParameters.SingleOrDefault((Parameter p) => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
			if (parameter != null)
			{
				restClient.DefaultParameters.Remove(parameter);
			}
			return restClient;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00005CD3 File Offset: 0x00003ED3
		public static IRestClient AddDefaultParameter(this IRestClient restClient, string name, object value)
		{
			return restClient.AddDefaultParameter(new Parameter(name, value, ParameterType.GetOrPost));
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00005CE3 File Offset: 0x00003EE3
		public static IRestClient AddDefaultParameter(this IRestClient restClient, string name, object value, ParameterType type)
		{
			return restClient.AddDefaultParameter(new Parameter(name, value, type));
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00005CF3 File Offset: 0x00003EF3
		public static IRestClient AddDefaultHeader(this IRestClient restClient, string name, string value)
		{
			return restClient.AddDefaultParameter(name, value, ParameterType.HttpHeader);
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00005D00 File Offset: 0x00003F00
		public static IRestClient AddDefaultHeaders(this IRestClient restClient, Dictionary<string, string> headers)
		{
			foreach (KeyValuePair<string, string> keyValuePair in headers)
			{
				restClient.AddOrUpdateDefaultParameter(new Parameter(keyValuePair.Key, keyValuePair.Value, ParameterType.HttpHeader));
			}
			return restClient;
		}

		// Token: 0x060002ED RID: 749 RVA: 0x00005D64 File Offset: 0x00003F64
		public static IRestClient AddDefaultUrlSegment(this IRestClient restClient, string name, string value)
		{
			return restClient.AddDefaultParameter(name, value, ParameterType.UrlSegment);
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00005D6F File Offset: 0x00003F6F
		public static IRestClient AddDefaultQueryParameter(this IRestClient restClient, string name, string value)
		{
			return restClient.AddDefaultParameter(name, value, ParameterType.QueryString);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00005D7C File Offset: 0x00003F7C
		private static void ThrowIfError(IRestResponse response)
		{
			Exception ex;
			switch (response.ResponseStatus)
			{
			case ResponseStatus.None:
				ex = null;
				break;
			case ResponseStatus.Completed:
				ex = null;
				break;
			case ResponseStatus.Error:
				ex = response.ErrorException;
				break;
			case ResponseStatus.TimedOut:
				ex = new TimeoutException("Request timed out", response.ErrorException);
				break;
			case ResponseStatus.Aborted:
				ex = new WebException("Request aborted", response.ErrorException);
				break;
			default:
				throw response.ErrorException ?? new ArgumentOutOfRangeException();
			}
			Exception ex2 = ex;
			if (ex2 != null)
			{
				throw ex2;
			}
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00005DFC File Offset: 0x00003FFC
		public static RestClient UseJson(this RestClient client)
		{
			foreach (string contentType in ContentType.XmlAccept)
			{
				client.RemoveHandler(contentType);
			}
			client.Serializers.Remove(DataFormat.Xml);
			return client;
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00005E38 File Offset: 0x00004038
		public static RestClient UseXml(this RestClient client)
		{
			foreach (string contentType in ContentType.JsonAccept)
			{
				client.RemoveHandler(contentType);
			}
			client.Serializers.Remove(DataFormat.Json);
			return client;
		}
	}
}
