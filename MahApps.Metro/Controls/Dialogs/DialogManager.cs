using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MahApps.Metro.Controls.Dialogs
{
	// Token: 0x020000A3 RID: 163
	public static class DialogManager
	{
		// Token: 0x060008DD RID: 2269 RVA: 0x00023670 File Offset: 0x00021870
		public static Task<LoginDialogData> ShowLoginAsync(this MetroWindow window, string title, string message, LoginDialogSettings settings = null)
		{
			window.Dispatcher.VerifyAccess();
			settings = (settings ?? new LoginDialogSettings());
			Action <>9__3;
			Action <>9__5;
			Func<Task<LoginDialogData>> <>9__1;
			return DialogManager.HandleOverlayOnShow(settings, window).ContinueWith<Task<LoginDialogData>>(delegate(Task z)
			{
				Dispatcher dispatcher = window.Dispatcher;
				Func<Task<LoginDialogData>> callback;
				if ((callback = <>9__1) == null)
				{
					callback = (<>9__1 = delegate()
					{
						LoginDialog dialog = new LoginDialog(window, settings)
						{
							Title = title,
							Message = message
						};
						DialogManager.SetDialogFontSizes(settings, dialog);
						SizeChangedEventHandler sizeHandler = DialogManager.SetupAndOpenDialog(window, dialog);
						dialog.SizeChangedHandler = sizeHandler;
						Func<Task> <>9__6;
						Func<Task> <>9__8;
						Func<Task<LoginDialogData>, Task<Task<LoginDialogData>>> <>9__4;
						return dialog.WaitForLoadAsync().ContinueWith<Task<Task<LoginDialogData>>>(delegate(Task x)
						{
							if (DialogManager.DialogOpened != null)
							{
								Dispatcher dispatcher2 = window.Dispatcher;
								Action method;
								if ((method = <>9__3) == null)
								{
									method = (<>9__3 = delegate()
									{
										DialogManager.DialogOpened(window, new DialogStateChangedEventArgs());
									});
								}
								dispatcher2.BeginInvoke(method, Array.Empty<object>());
							}
							Task<LoginDialogData> task = dialog.WaitForButtonPressAsync();
							Func<Task<LoginDialogData>, Task<Task<LoginDialogData>>> continuationFunction;
							if ((continuationFunction = <>9__4) == null)
							{
								continuationFunction = (<>9__4 = delegate(Task<LoginDialogData> y)
								{
									dialog.OnClose();
									if (DialogManager.DialogClosed != null)
									{
										Dispatcher dispatcher3 = window.Dispatcher;
										Action method2;
										if ((method2 = <>9__5) == null)
										{
											method2 = (<>9__5 = delegate()
											{
												DialogManager.DialogClosed(window, new DialogStateChangedEventArgs());
											});
										}
										dispatcher3.BeginInvoke(method2, Array.Empty<object>());
									}
									Dispatcher dispatcher4 = window.Dispatcher;
									Func<Task> callback2;
									if ((callback2 = <>9__6) == null)
									{
										callback2 = (<>9__6 = (() => dialog._WaitForCloseAsync()));
									}
									Func<Task, Task<LoginDialogData>> <>9__9;
									return dispatcher4.Invoke<Task>(callback2).ContinueWith<Task<LoginDialogData>>(delegate(Task a)
									{
										Dispatcher dispatcher5 = window.Dispatcher;
										Func<Task> callback3;
										if ((callback3 = <>9__8) == null)
										{
											callback3 = (<>9__8 = delegate()
											{
												window.SizeChanged -= sizeHandler;
												window.RemoveDialog(dialog);
												return DialogManager.HandleOverlayOnHide(settings, window);
											});
										}
										Task task2 = dispatcher5.Invoke<Task>(callback3);
										Func<Task, Task<LoginDialogData>> continuationFunction2;
										if ((continuationFunction2 = <>9__9) == null)
										{
											continuationFunction2 = (<>9__9 = ((Task y3) => y));
										}
										return task2.ContinueWith<Task<LoginDialogData>>(continuationFunction2).Unwrap<LoginDialogData>();
									});
								});
							}
							return task.ContinueWith<Task<Task<LoginDialogData>>>(continuationFunction).Unwrap<Task<LoginDialogData>>();
						}).Unwrap<Task<LoginDialogData>>().Unwrap<LoginDialogData>();
					});
				}
				return dispatcher.Invoke<Task<LoginDialogData>>(callback);
			}).Unwrap<LoginDialogData>();
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x000236EC File Offset: 0x000218EC
		public static Task<string> ShowInputAsync(this MetroWindow window, string title, string message, MetroDialogSettings settings = null)
		{
			window.Dispatcher.VerifyAccess();
			settings = (settings ?? window.MetroDialogOptions);
			Action <>9__3;
			Action <>9__5;
			Func<Task<string>> <>9__1;
			return DialogManager.HandleOverlayOnShow(settings, window).ContinueWith<Task<string>>(delegate(Task z)
			{
				Dispatcher dispatcher = window.Dispatcher;
				Func<Task<string>> callback;
				if ((callback = <>9__1) == null)
				{
					callback = (<>9__1 = delegate()
					{
						InputDialog dialog = new InputDialog(window, settings)
						{
							Title = title,
							Message = message,
							Input = settings.DefaultText
						};
						DialogManager.SetDialogFontSizes(settings, dialog);
						SizeChangedEventHandler sizeHandler = DialogManager.SetupAndOpenDialog(window, dialog);
						dialog.SizeChangedHandler = sizeHandler;
						Func<Task> <>9__6;
						Func<Task> <>9__8;
						Func<Task<string>, Task<Task<string>>> <>9__4;
						return dialog.WaitForLoadAsync().ContinueWith<Task<Task<string>>>(delegate(Task x)
						{
							if (DialogManager.DialogOpened != null)
							{
								Dispatcher dispatcher2 = window.Dispatcher;
								Action method;
								if ((method = <>9__3) == null)
								{
									method = (<>9__3 = delegate()
									{
										DialogManager.DialogOpened(window, new DialogStateChangedEventArgs());
									});
								}
								dispatcher2.BeginInvoke(method, Array.Empty<object>());
							}
							Task<string> task = dialog.WaitForButtonPressAsync();
							Func<Task<string>, Task<Task<string>>> continuationFunction;
							if ((continuationFunction = <>9__4) == null)
							{
								continuationFunction = (<>9__4 = delegate(Task<string> y)
								{
									dialog.OnClose();
									if (DialogManager.DialogClosed != null)
									{
										Dispatcher dispatcher3 = window.Dispatcher;
										Action method2;
										if ((method2 = <>9__5) == null)
										{
											method2 = (<>9__5 = delegate()
											{
												DialogManager.DialogClosed(window, new DialogStateChangedEventArgs());
											});
										}
										dispatcher3.BeginInvoke(method2, Array.Empty<object>());
									}
									Dispatcher dispatcher4 = window.Dispatcher;
									Func<Task> callback2;
									if ((callback2 = <>9__6) == null)
									{
										callback2 = (<>9__6 = (() => dialog._WaitForCloseAsync()));
									}
									Func<Task, Task<string>> <>9__9;
									return dispatcher4.Invoke<Task>(callback2).ContinueWith<Task<string>>(delegate(Task a)
									{
										Dispatcher dispatcher5 = window.Dispatcher;
										Func<Task> callback3;
										if ((callback3 = <>9__8) == null)
										{
											callback3 = (<>9__8 = delegate()
											{
												window.SizeChanged -= sizeHandler;
												window.RemoveDialog(dialog);
												return DialogManager.HandleOverlayOnHide(settings, window);
											});
										}
										Task task2 = dispatcher5.Invoke<Task>(callback3);
										Func<Task, Task<string>> continuationFunction2;
										if ((continuationFunction2 = <>9__9) == null)
										{
											continuationFunction2 = (<>9__9 = ((Task y3) => y));
										}
										return task2.ContinueWith<Task<string>>(continuationFunction2).Unwrap<string>();
									});
								});
							}
							return task.ContinueWith<Task<Task<string>>>(continuationFunction).Unwrap<Task<string>>();
						}).Unwrap<Task<string>>().Unwrap<string>();
					});
				}
				return dispatcher.Invoke<Task<string>>(callback);
			}).Unwrap<string>();
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x00023770 File Offset: 0x00021970
		public static Task<MessageDialogResult> ShowMessageAsync(this MetroWindow window, string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null)
		{
			window.Dispatcher.VerifyAccess();
			settings = (settings ?? window.MetroDialogOptions);
			Action <>9__3;
			Action <>9__5;
			Func<Task<MessageDialogResult>> <>9__1;
			return DialogManager.HandleOverlayOnShow(settings, window).ContinueWith<Task<MessageDialogResult>>(delegate(Task z)
			{
				Dispatcher dispatcher = window.Dispatcher;
				Func<Task<MessageDialogResult>> callback;
				if ((callback = <>9__1) == null)
				{
					callback = (<>9__1 = delegate()
					{
						MessageDialog dialog = new MessageDialog(window, settings)
						{
							Message = message,
							Title = title,
							ButtonStyle = style
						};
						DialogManager.SetDialogFontSizes(settings, dialog);
						SizeChangedEventHandler sizeHandler = DialogManager.SetupAndOpenDialog(window, dialog);
						dialog.SizeChangedHandler = sizeHandler;
						Func<Task> <>9__6;
						Func<Task> <>9__8;
						Func<Task<MessageDialogResult>, Task<Task<MessageDialogResult>>> <>9__4;
						return dialog.WaitForLoadAsync().ContinueWith<Task<Task<MessageDialogResult>>>(delegate(Task x)
						{
							if (DialogManager.DialogOpened != null)
							{
								Dispatcher dispatcher2 = window.Dispatcher;
								Action method;
								if ((method = <>9__3) == null)
								{
									method = (<>9__3 = delegate()
									{
										DialogManager.DialogOpened(window, new DialogStateChangedEventArgs());
									});
								}
								dispatcher2.BeginInvoke(method, Array.Empty<object>());
							}
							Task<MessageDialogResult> task = dialog.WaitForButtonPressAsync();
							Func<Task<MessageDialogResult>, Task<Task<MessageDialogResult>>> continuationFunction;
							if ((continuationFunction = <>9__4) == null)
							{
								continuationFunction = (<>9__4 = delegate(Task<MessageDialogResult> y)
								{
									dialog.OnClose();
									if (DialogManager.DialogClosed != null)
									{
										Dispatcher dispatcher3 = window.Dispatcher;
										Action method2;
										if ((method2 = <>9__5) == null)
										{
											method2 = (<>9__5 = delegate()
											{
												DialogManager.DialogClosed(window, new DialogStateChangedEventArgs());
											});
										}
										dispatcher3.BeginInvoke(method2, Array.Empty<object>());
									}
									Dispatcher dispatcher4 = window.Dispatcher;
									Func<Task> callback2;
									if ((callback2 = <>9__6) == null)
									{
										callback2 = (<>9__6 = (() => dialog._WaitForCloseAsync()));
									}
									Func<Task, Task<MessageDialogResult>> <>9__9;
									return dispatcher4.Invoke<Task>(callback2).ContinueWith<Task<MessageDialogResult>>(delegate(Task a)
									{
										Dispatcher dispatcher5 = window.Dispatcher;
										Func<Task> callback3;
										if ((callback3 = <>9__8) == null)
										{
											callback3 = (<>9__8 = delegate()
											{
												window.SizeChanged -= sizeHandler;
												window.RemoveDialog(dialog);
												return DialogManager.HandleOverlayOnHide(settings, window);
											});
										}
										Task task2 = dispatcher5.Invoke<Task>(callback3);
										Func<Task, Task<MessageDialogResult>> continuationFunction2;
										if ((continuationFunction2 = <>9__9) == null)
										{
											continuationFunction2 = (<>9__9 = ((Task y3) => y));
										}
										return task2.ContinueWith<Task<MessageDialogResult>>(continuationFunction2).Unwrap<MessageDialogResult>();
									});
								});
							}
							return task.ContinueWith<Task<Task<MessageDialogResult>>>(continuationFunction).Unwrap<Task<MessageDialogResult>>();
						}).Unwrap<Task<MessageDialogResult>>().Unwrap<MessageDialogResult>();
					});
				}
				return dispatcher.Invoke<Task<MessageDialogResult>>(callback);
			}).Unwrap<MessageDialogResult>();
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x000237FC File Offset: 0x000219FC
		public static Task<ProgressDialogController> ShowProgressAsync(this MetroWindow window, string title, string message, bool isCancelable = false, MetroDialogSettings settings = null)
		{
			window.Dispatcher.VerifyAccess();
			settings = (settings ?? window.MetroDialogOptions);
			Action <>9__3;
			Action <>9__5;
			Func<Task<ProgressDialogController>> <>9__1;
			return DialogManager.HandleOverlayOnShow(settings, window).ContinueWith<Task<ProgressDialogController>>(delegate(Task z)
			{
				Dispatcher dispatcher = window.Dispatcher;
				Func<Task<ProgressDialogController>> callback;
				if ((callback = <>9__1) == null)
				{
					callback = (<>9__1 = delegate()
					{
						ProgressDialog dialog = new ProgressDialog(window, settings)
						{
							Title = title,
							Message = message,
							IsCancelable = isCancelable
						};
						DialogManager.SetDialogFontSizes(settings, dialog);
						SizeChangedEventHandler sizeHandler = DialogManager.SetupAndOpenDialog(window, dialog);
						dialog.SizeChangedHandler = sizeHandler;
						Func<Task> <>9__6;
						Func<Task> <>9__8;
						Func<Task, Task> <>9__7;
						Func<Task> <>9__4;
						return dialog.WaitForLoadAsync().ContinueWith<ProgressDialogController>(delegate(Task x)
						{
							if (DialogManager.DialogOpened != null)
							{
								Dispatcher dispatcher2 = window.Dispatcher;
								Action method;
								if ((method = <>9__3) == null)
								{
									method = (<>9__3 = delegate()
									{
										DialogManager.DialogOpened(window, new DialogStateChangedEventArgs());
									});
								}
								dispatcher2.BeginInvoke(method, Array.Empty<object>());
							}
							ProgressDialog dialog = dialog;
							Func<Task> closeCallBack;
							if ((closeCallBack = <>9__4) == null)
							{
								closeCallBack = (<>9__4 = delegate()
								{
									dialog.OnClose();
									if (DialogManager.DialogClosed != null)
									{
										Dispatcher dispatcher3 = window.Dispatcher;
										Action method2;
										if ((method2 = <>9__5) == null)
										{
											method2 = (<>9__5 = delegate()
											{
												DialogManager.DialogClosed(window, new DialogStateChangedEventArgs());
											});
										}
										dispatcher3.BeginInvoke(method2, Array.Empty<object>());
									}
									Dispatcher dispatcher4 = window.Dispatcher;
									Func<Task> callback2;
									if ((callback2 = <>9__6) == null)
									{
										callback2 = (<>9__6 = (() => dialog._WaitForCloseAsync()));
									}
									Task task = dispatcher4.Invoke<Task>(callback2);
									Func<Task, Task> continuationFunction;
									if ((continuationFunction = <>9__7) == null)
									{
										continuationFunction = (<>9__7 = delegate(Task a)
										{
											Dispatcher dispatcher5 = window.Dispatcher;
											Func<Task> callback3;
											if ((callback3 = <>9__8) == null)
											{
												callback3 = (<>9__8 = delegate()
												{
													window.SizeChanged -= sizeHandler;
													window.RemoveDialog(dialog);
													return DialogManager.HandleOverlayOnHide(settings, window);
												});
											}
											return dispatcher5.Invoke<Task>(callback3);
										});
									}
									return task.ContinueWith<Task>(continuationFunction).Unwrap();
								});
							}
							return new ProgressDialogController(dialog, closeCallBack);
						});
					});
				}
				return dispatcher.Invoke<Task<ProgressDialogController>>(callback);
			}).Unwrap<ProgressDialogController>();
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00023888 File Offset: 0x00021A88
		private static Task HandleOverlayOnHide(MetroDialogSettings settings, MetroWindow window)
		{
			Task task2;
			if (!window.metroActiveDialogContainer.Children.OfType<BaseMetroDialog>().Any<BaseMetroDialog>())
			{
				task2 = ((settings == null || settings.AnimateHide) ? window.HideOverlayAsync() : Task.Factory.StartNew(delegate()
				{
					window.Dispatcher.Invoke(new Action(window.HideOverlay));
				}));
			}
			else
			{
				TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
				taskCompletionSource.SetResult(null);
				task2 = taskCompletionSource.Task;
			}
			Action <>9__2;
			task2.ContinueWith(delegate(Task task)
			{
				DispatcherObject window2 = window;
				Action invokeAction;
				if ((invokeAction = <>9__2) == null)
				{
					invokeAction = (<>9__2 = delegate()
					{
						if (window.metroActiveDialogContainer.Children.Count == 0)
						{
							window.SetValue(MetroWindow.IsCloseButtonEnabledWithDialogPropertyKey, true);
							window.RestoreFocus();
							return;
						}
						BaseMetroDialog baseMetroDialog = window.metroActiveDialogContainer.Children.OfType<BaseMetroDialog>().LastOrDefault<BaseMetroDialog>();
						MetroDialogSettings metroDialogSettings = (baseMetroDialog != null) ? baseMetroDialog.DialogSettings : null;
						window.SetValue(MetroWindow.IsCloseButtonEnabledWithDialogPropertyKey, window.ShowDialogsOverTitleBar || metroDialogSettings == null || metroDialogSettings.OwnerCanCloseWithDialog);
					});
				}
				window2.Invoke(invokeAction);
			});
			return task2;
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00023918 File Offset: 0x00021B18
		private static Task HandleOverlayOnShow(MetroDialogSettings settings, MetroWindow window)
		{
			Action <>9__2;
			Action <>9__4;
			Func<Task> <>9__3;
			return Task.Factory.StartNew(delegate()
			{
				DispatcherObject window2 = window;
				Action invokeAction;
				if ((invokeAction = <>9__2) == null)
				{
					invokeAction = (<>9__2 = delegate()
					{
						window.SetValue(MetroWindow.IsCloseButtonEnabledWithDialogPropertyKey, window.ShowDialogsOverTitleBar || settings == null || settings.OwnerCanCloseWithDialog);
					});
				}
				window2.Invoke(invokeAction);
			}).ContinueWith<Task>(delegate(Task task)
			{
				DispatcherObject window2 = window;
				Func<Task> func;
				if ((func = <>9__3) == null)
				{
					func = (<>9__3 = delegate()
					{
						if (window.metroActiveDialogContainer.Children.OfType<BaseMetroDialog>().Any<BaseMetroDialog>())
						{
							TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
							taskCompletionSource.SetResult(null);
							return taskCompletionSource.Task;
						}
						if (settings != null && !settings.AnimateShow)
						{
							TaskFactory factory = Task.Factory;
							Action action;
							if ((action = <>9__4) == null)
							{
								action = (<>9__4 = delegate()
								{
									window.Dispatcher.Invoke(new Action(window.ShowOverlay));
								});
							}
							return factory.StartNew(action);
						}
						return window.ShowOverlayAsync();
					});
				}
				return window2.Invoke(func);
			}).Unwrap();
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x00023968 File Offset: 0x00021B68
		public static Task ShowMetroDialogAsync(this MetroWindow window, BaseMetroDialog dialog, MetroDialogSettings settings = null)
		{
			DialogManager.<>c__DisplayClass6_0 CS$<>8__locals1 = new DialogManager.<>c__DisplayClass6_0();
			CS$<>8__locals1.window = window;
			CS$<>8__locals1.settings = settings;
			CS$<>8__locals1.dialog = dialog;
			if (CS$<>8__locals1.window == null)
			{
				throw new ArgumentNullException("window");
			}
			CS$<>8__locals1.window.Dispatcher.VerifyAccess();
			if (CS$<>8__locals1.dialog == null)
			{
				throw new ArgumentNullException("dialog");
			}
			if (CS$<>8__locals1.window.metroActiveDialogContainer.Children.Contains(CS$<>8__locals1.dialog) || CS$<>8__locals1.window.metroInactiveDialogContainer.Children.Contains(CS$<>8__locals1.dialog))
			{
				throw new InvalidOperationException("The provided dialog is already visible in the specified window.");
			}
			DialogManager.<>c__DisplayClass6_0 CS$<>8__locals2 = CS$<>8__locals1;
			MetroDialogSettings settings2;
			if ((settings2 = CS$<>8__locals1.settings) == null)
			{
				settings2 = (CS$<>8__locals1.dialog.DialogSettings ?? CS$<>8__locals1.window.MetroDialogOptions);
			}
			CS$<>8__locals2.settings = settings2;
			return DialogManager.HandleOverlayOnShow(CS$<>8__locals1.settings, CS$<>8__locals1.window).ContinueWith<Task>(delegate(Task z)
			{
				Dispatcher dispatcher = CS$<>8__locals1.window.Dispatcher;
				Func<Task> callback;
				if ((callback = CS$<>8__locals1.<>9__1) == null)
				{
					callback = (CS$<>8__locals1.<>9__1 = delegate()
					{
						DialogManager.SetDialogFontSizes(CS$<>8__locals1.settings, CS$<>8__locals1.dialog);
						SizeChangedEventHandler sizeChangedHandler = DialogManager.SetupAndOpenDialog(CS$<>8__locals1.window, CS$<>8__locals1.dialog);
						CS$<>8__locals1.dialog.SizeChangedHandler = sizeChangedHandler;
						Task task = CS$<>8__locals1.dialog.WaitForLoadAsync();
						Action<Task> continuationAction;
						if ((continuationAction = CS$<>8__locals1.<>9__2) == null)
						{
							continuationAction = (CS$<>8__locals1.<>9__2 = delegate(Task x)
							{
								CS$<>8__locals1.dialog.OnShown();
								if (DialogManager.DialogOpened != null)
								{
									Dispatcher dispatcher2 = CS$<>8__locals1.window.Dispatcher;
									Action method;
									if ((method = CS$<>8__locals1.<>9__3) == null)
									{
										method = (CS$<>8__locals1.<>9__3 = delegate()
										{
											DialogManager.DialogOpened(CS$<>8__locals1.window, new DialogStateChangedEventArgs());
										});
									}
									dispatcher2.BeginInvoke(method, Array.Empty<object>());
								}
							});
						}
						return task.ContinueWith(continuationAction);
					});
				}
				return dispatcher.Invoke<Task>(callback);
			}).Unwrap();
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00023A5C File Offset: 0x00021C5C
		public static Task<TDialog> ShowMetroDialogAsync<TDialog>(this MetroWindow window, MetroDialogSettings settings = null) where TDialog : BaseMetroDialog
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			window.Dispatcher.VerifyAccess();
			TDialog dialog = (TDialog)((object)Activator.CreateInstance(typeof(TDialog), new object[]
			{
				window,
				settings
			}));
			Action <>9__4;
			Action<Task> <>9__2;
			Func<Task, TDialog> <>9__3;
			Func<Task<TDialog>> <>9__1;
			return DialogManager.HandleOverlayOnShow(dialog.DialogSettings, window).ContinueWith<Task<TDialog>>(delegate(Task z)
			{
				Dispatcher dispatcher = window.Dispatcher;
				Func<Task<TDialog>> callback;
				if ((callback = <>9__1) == null)
				{
					callback = (<>9__1 = delegate()
					{
						DialogManager.SetDialogFontSizes(dialog.DialogSettings, dialog);
						SizeChangedEventHandler sizeChangedHandler = DialogManager.SetupAndOpenDialog(window, dialog);
						dialog.SizeChangedHandler = sizeChangedHandler;
						Task task = dialog.WaitForLoadAsync();
						Action<Task> continuationAction;
						if ((continuationAction = <>9__2) == null)
						{
							continuationAction = (<>9__2 = delegate(Task x)
							{
								dialog.OnShown();
								if (DialogManager.DialogOpened != null)
								{
									Dispatcher dispatcher2 = window.Dispatcher;
									Action method;
									if ((method = <>9__4) == null)
									{
										method = (<>9__4 = delegate()
										{
											DialogManager.DialogOpened(window, new DialogStateChangedEventArgs());
										});
									}
									dispatcher2.BeginInvoke(method, Array.Empty<object>());
								}
							});
						}
						Task task2 = task.ContinueWith(continuationAction);
						Func<Task, TDialog> continuationFunction;
						if ((continuationFunction = <>9__3) == null)
						{
							continuationFunction = (<>9__3 = ((Task x) => dialog));
						}
						return task2.ContinueWith<TDialog>(continuationFunction);
					});
				}
				return dispatcher.Invoke<Task<TDialog>>(callback);
			}).Unwrap<TDialog>();
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00023AF8 File Offset: 0x00021CF8
		public static Task HideMetroDialogAsync(this MetroWindow window, BaseMetroDialog dialog, MetroDialogSettings settings = null)
		{
			window.Dispatcher.VerifyAccess();
			if (!window.metroActiveDialogContainer.Children.Contains(dialog) && !window.metroInactiveDialogContainer.Children.Contains(dialog))
			{
				throw new InvalidOperationException("The provided dialog is not visible in the specified window.");
			}
			window.SizeChanged -= dialog.SizeChangedHandler;
			dialog.OnClose();
			Action <>9__1;
			Func<Task> <>9__2;
			return window.Dispatcher.Invoke<Task>(new Func<Task>(dialog._WaitForCloseAsync)).ContinueWith<Task>(delegate(Task a)
			{
				if (DialogManager.DialogClosed != null)
				{
					Dispatcher dispatcher = window.Dispatcher;
					Action method;
					if ((method = <>9__1) == null)
					{
						method = (<>9__1 = delegate()
						{
							DialogManager.DialogClosed(window, new DialogStateChangedEventArgs());
						});
					}
					dispatcher.BeginInvoke(method, Array.Empty<object>());
				}
				Dispatcher dispatcher2 = window.Dispatcher;
				Func<Task> callback;
				if ((callback = <>9__2) == null)
				{
					callback = (<>9__2 = delegate()
					{
						window.RemoveDialog(dialog);
						MetroDialogSettings settings2;
						if ((settings2 = settings) == null)
						{
							settings2 = (dialog.DialogSettings ?? window.MetroDialogOptions);
						}
						settings = settings2;
						return DialogManager.HandleOverlayOnHide(settings, window);
					});
				}
				return dispatcher2.Invoke<Task>(callback);
			}).Unwrap();
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00023BD0 File Offset: 0x00021DD0
		public static Task<TDialog> GetCurrentDialogAsync<TDialog>(this MetroWindow window) where TDialog : BaseMetroDialog
		{
			window.Dispatcher.VerifyAccess();
			TaskCompletionSource<TDialog> t = new TaskCompletionSource<TDialog>();
			window.Dispatcher.Invoke(delegate()
			{
				Grid metroActiveDialogContainer = window.metroActiveDialogContainer;
				TDialog result = (metroActiveDialogContainer != null) ? metroActiveDialogContainer.Children.OfType<TDialog>().LastOrDefault<TDialog>() : default(TDialog);
				t.TrySetResult(result);
			});
			return t.Task;
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x00023C2C File Offset: 0x00021E2C
		private static SizeChangedEventHandler SetupAndOpenDialog(MetroWindow window, BaseMetroDialog dialog)
		{
			dialog.SetValue(Panel.ZIndexProperty, (int)window.overlayBox.GetValue(Panel.ZIndexProperty) + 1);
			dialog.MinHeight = window.ActualHeight / 4.0;
			dialog.MaxHeight = window.ActualHeight;
			SizeChangedEventHandler sizeChangedEventHandler = delegate(object sender, SizeChangedEventArgs args)
			{
				dialog.MinHeight = window.ActualHeight / 4.0;
				dialog.MaxHeight = window.ActualHeight;
			};
			window.SizeChanged += sizeChangedEventHandler;
			window.AddDialog(dialog);
			dialog.OnShown();
			return sizeChangedEventHandler;
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x00023CEC File Offset: 0x00021EEC
		private static void AddDialog(this MetroWindow window, BaseMetroDialog dialog)
		{
			window.StoreFocus(null);
			UIElement uielement = window.metroActiveDialogContainer.Children.Cast<UIElement>().SingleOrDefault<UIElement>();
			if (uielement != null)
			{
				window.metroActiveDialogContainer.Children.Remove(uielement);
				window.metroInactiveDialogContainer.Children.Add(uielement);
			}
			window.metroActiveDialogContainer.Children.Add(dialog);
			window.SetValue(MetroWindow.IsAnyDialogOpenPropertyKey, true);
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x00023D60 File Offset: 0x00021F60
		private static void RemoveDialog(this MetroWindow window, BaseMetroDialog dialog)
		{
			if (window.metroActiveDialogContainer.Children.Contains(dialog))
			{
				window.metroActiveDialogContainer.Children.Remove(dialog);
				UIElement uielement = window.metroInactiveDialogContainer.Children.Cast<UIElement>().LastOrDefault<UIElement>();
				if (uielement != null)
				{
					window.metroInactiveDialogContainer.Children.Remove(uielement);
					window.metroActiveDialogContainer.Children.Add(uielement);
				}
			}
			else
			{
				window.metroInactiveDialogContainer.Children.Remove(dialog);
			}
			window.SetValue(MetroWindow.IsAnyDialogOpenPropertyKey, window.metroActiveDialogContainer.Children.Count > 0);
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x00023E03 File Offset: 0x00022003
		public static BaseMetroDialog ShowDialogExternally(this BaseMetroDialog dialog)
		{
			Window window = DialogManager.SetupExternalDialogWindow(dialog);
			dialog.OnShown();
			window.Show();
			return dialog;
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x00023E17 File Offset: 0x00022017
		public static BaseMetroDialog ShowModalDialogExternally(this BaseMetroDialog dialog)
		{
			Window window = DialogManager.SetupExternalDialogWindow(dialog);
			dialog.OnShown();
			window.ShowDialog();
			return dialog;
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x00023E2C File Offset: 0x0002202C
		private static Window CreateExternalWindow()
		{
			return new MetroWindow
			{
				ShowInTaskbar = false,
				ShowActivated = true,
				Topmost = true,
				ResizeMode = ResizeMode.NoResize,
				WindowStyle = WindowStyle.None,
				WindowStartupLocation = WindowStartupLocation.CenterScreen,
				ShowTitleBar = false,
				ShowCloseButton = false,
				WindowTransitionsEnabled = false
			};
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00023E80 File Offset: 0x00022080
		private static Window SetupExternalDialogWindow(BaseMetroDialog dialog)
		{
			Window win = DialogManager.CreateExternalWindow();
			win.Width = SystemParameters.PrimaryScreenWidth;
			win.MinHeight = SystemParameters.PrimaryScreenHeight / 4.0;
			win.SizeToContent = SizeToContent.Height;
			dialog.ParentDialogWindow = win;
			win.Content = dialog;
			dialog.HandleThemeChange();
			EventHandler closedHandler = null;
			closedHandler = delegate(object sender, EventArgs args)
			{
				win.Closed -= closedHandler;
				dialog.ParentDialogWindow = null;
				win.Content = null;
			};
			win.Closed += closedHandler;
			return win;
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00023F38 File Offset: 0x00022138
		private static Window CreateModalExternalWindow(MetroWindow window)
		{
			Window window2 = DialogManager.CreateExternalWindow();
			window2.Owner = window;
			window2.Topmost = false;
			window2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			window2.Width = window.ActualWidth;
			window2.MaxHeight = window.ActualHeight;
			window2.SizeToContent = SizeToContent.Height;
			return window2;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00023F74 File Offset: 0x00022174
		public static LoginDialogData ShowModalLoginExternal(this MetroWindow window, string title, string message, LoginDialogSettings settings = null)
		{
			Window win = DialogManager.CreateModalExternalWindow(window);
			settings = (settings ?? new LoginDialogSettings());
			LoginDialog loginDialog = new LoginDialog(window, settings)
			{
				Title = title,
				Message = message
			};
			DialogManager.SetDialogFontSizes(settings, loginDialog);
			win.Content = loginDialog;
			LoginDialogData result = null;
			loginDialog.WaitForButtonPressAsync().ContinueWith(delegate(Task<LoginDialogData> task)
			{
				result = task.Result;
				win.Invoke(new Action(win.Close));
			});
			DialogManager.HandleOverlayOnShow(settings, window);
			win.ShowDialog();
			DialogManager.HandleOverlayOnHide(settings, window);
			return result;
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x0002400C File Offset: 0x0002220C
		public static string ShowModalInputExternal(this MetroWindow window, string title, string message, MetroDialogSettings settings = null)
		{
			Window win = DialogManager.CreateModalExternalWindow(window);
			settings = (settings ?? window.MetroDialogOptions);
			InputDialog inputDialog = new InputDialog(window, settings)
			{
				Message = message,
				Title = title,
				Input = settings.DefaultText
			};
			DialogManager.SetDialogFontSizes(settings, inputDialog);
			win.Content = inputDialog;
			string result = null;
			inputDialog.WaitForButtonPressAsync().ContinueWith(delegate(Task<string> task)
			{
				result = task.Result;
				win.Invoke(new Action(win.Close));
			});
			DialogManager.HandleOverlayOnShow(settings, window);
			win.ShowDialog();
			DialogManager.HandleOverlayOnHide(settings, window);
			return result;
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x000240B0 File Offset: 0x000222B0
		public static MessageDialogResult ShowModalMessageExternal(this MetroWindow window, string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null)
		{
			Window win = DialogManager.CreateModalExternalWindow(window);
			settings = (settings ?? window.MetroDialogOptions);
			MessageDialog messageDialog = new MessageDialog(window, settings)
			{
				Message = message,
				Title = title,
				ButtonStyle = style
			};
			DialogManager.SetDialogFontSizes(settings, messageDialog);
			win.Content = messageDialog;
			MessageDialogResult result = MessageDialogResult.Affirmative;
			messageDialog.WaitForButtonPressAsync().ContinueWith(delegate(Task<MessageDialogResult> task)
			{
				result = task.Result;
				win.Invoke(new Action(win.Close));
			});
			DialogManager.HandleOverlayOnShow(settings, window);
			win.ShowDialog();
			DialogManager.HandleOverlayOnHide(settings, window);
			return result;
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x00024152 File Offset: 0x00022352
		private static void SetDialogFontSizes(MetroDialogSettings settings, BaseMetroDialog dialog)
		{
			if (settings == null)
			{
				return;
			}
			if (!double.IsNaN(settings.DialogTitleFontSize))
			{
				dialog.DialogTitleFontSize = settings.DialogTitleFontSize;
			}
			if (!double.IsNaN(settings.DialogMessageFontSize))
			{
				dialog.DialogMessageFontSize = settings.DialogMessageFontSize;
			}
		}

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x060008F3 RID: 2291 RVA: 0x0002418C File Offset: 0x0002238C
		// (remove) Token: 0x060008F4 RID: 2292 RVA: 0x000241C0 File Offset: 0x000223C0
		public static event EventHandler<DialogStateChangedEventArgs> DialogOpened;

		// Token: 0x1400003D RID: 61
		// (add) Token: 0x060008F5 RID: 2293 RVA: 0x000241F4 File Offset: 0x000223F4
		// (remove) Token: 0x060008F6 RID: 2294 RVA: 0x00024228 File Offset: 0x00022428
		public static event EventHandler<DialogStateChangedEventArgs> DialogClosed;
	}
}
