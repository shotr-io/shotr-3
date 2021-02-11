using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Uwp.Notifications;
using Shotr.Core;
using Shotr.Core.Services;
using Shotr.Core.Settings;
using Shotr.Core.UpdateFramework;
using Shotr.Core.Uploader;
using Shotr.Ui.Forms;
using ShotrUploaderPlugin;
using Exception = System.Exception;

namespace Shotr.Ui
{
    [ComSourceInterfaces(typeof(INotificationActivationCallback))]
    [Guid("F690F4C2-040B-41DC-BE39-08477E082DFC"), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class Toast : NotificationActivator
    {
        public override void OnActivated(string invokedArgs, NotificationUserInput userInput, string appUserModelId)
        {
            var dict = new Dictionary<string, string>();
            var splitArgs = invokedArgs.Split("&");
            foreach (var arg in splitArgs)
            {
                var split = arg.Split("=");
                dict.Add(split[0], split[1]);
            }

            switch (dict["action"])
            {
                case "viewUrl":
                    if (dict.ContainsKey("url"))
                    {
                        dict["url"].OpenUrl();
                    }

                    break;
                case "viewUpdate":
                    var subscribe = bool.Parse(dict["subscribeAlphaBeta"]);
                    var updateForm = new UpdateForm(dict["changes"], subscribe, dict["installerUrl"], dict["version"]);
                    updateForm.ShowDialog();
                    break;
                case "openDirectory":
                    var directory = dict["path"];
                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "explorer.exe",
                            Arguments = $"/select, \"{directory}\"",
                            UseShellExecute = true
                        }
                    };
                    process.Start();
                    process.Dispose();
                    break;
                case "snoozeUpdate":
                    if (userInput.ContainsKey("snooze"))
                    {
                        var value = userInput["snooze"];
                        // Transform key to datetime.
                        var timeToSnooze = value switch
                        {
                            "6h" => TimeSpan.FromHours(6),
                            "12h" => TimeSpan.FromHours(12),
                            "1d" => TimeSpan.FromDays(1),
                            "3d" => TimeSpan.FromDays(3),
                            "1w" => TimeSpan.FromDays(7),
                            _ => TimeSpan.FromDays(1)
                        };

                        Updater.TimeToCheck = (int) timeToSnooze.TotalMilliseconds;
                        Updater.CheckForUpdates();
                    }

                    break;
                case "uploadVideo":
                    var videoPath = dict["path"];
                    var uploader = Program.ServiceProvider.GetService<Uploader>();
                    if (uploader is { })
                    {
                        uploader.AddToQueue(new ImageShell(File.ReadAllBytes(videoPath), FileExtensions.mp4));
                    }

                    break;
                case "dontShowEditNotification":
                    var settings = Program.ServiceProvider.GetService<BaseSettings>();
                    if (settings is { }) // settings != null
                    {
                        settings.Capture.ShowEditNotification = false;
                        SettingsService.Save(settings);
                    }

                    break;
            }
        }

        public static void SendUpdateNotifications(string text, string changes, string installerUrl, string version, bool subscribeAlphaBeta)
        {
            try
            {
                var toastBuilder = new ToastContentBuilder()
                    .AddAppLogoOverride(new Uri(Path.Combine(SettingsService.CachePath, "shotr.png")),
                        ToastGenericAppLogoCrop.Default)
                    .AddText("Shotr")
                    .AddText(text)
                    .AddToastInput(new ToastSelectionBox("snooze")
                    {
                        DefaultSelectionBoxItemId = "1d",
                        Items =
                        {
                            new ToastSelectionBoxItem("6h", "6 Hours"),
                            new ToastSelectionBoxItem("12h", "12 Hours"),
                            new ToastSelectionBoxItem("1d", "1 Day"),
                            new ToastSelectionBoxItem("3d", "3 Days"),
                            new ToastSelectionBoxItem("1w", "1 Week"),
                        }
                    })
                    .AddButton("Snooze", ToastActivationType.Background, "action=snoozeUpdate")
                    .AddButton("View Update", ToastActivationType.Background,
                        $"action=viewUpdate&changes={changes}&subscribeAlphaBeta={subscribeAlphaBeta}&installerUrl={installerUrl}&version={version}");

                var x = new XmlDocument();
                var content = toastBuilder.GetToastContent().GetContent();
                x.LoadXml(content);

                var toast = new ToastNotification(x);
                toast.ExpiresOnReboot = true;
                toast.Dismissed += (sender, args) =>
                {
                    if (args.Reason == ToastDismissalReason.TimedOut ||
                        args.Reason == ToastDismissalReason.UserCanceled)
                    {
                        Updater.CheckForUpdates();
                    }
                };

                ToastNotificationManager.CreateToastNotifier("Shotr").Show(toast);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void Send(string text, int timeout)
        {
            Send(null, text, null, null, null, timeout);
        }

        public static void Send(string? imagePath, string text, string? buttonText = null, string? action = null,
            string? query = null, int? timeout = null)
        {
            try
            {
                var toastBuilder = new ToastContentBuilder()
                    .AddAppLogoOverride(new Uri(Path.Combine(SettingsService.CachePath, "shotr.png")),
                        ToastGenericAppLogoCrop.Default)
                    .AddText("Shotr")
                    .AddText(text);

                if (imagePath is { })
                {
                    toastBuilder.AddHeroImage(new Uri(imagePath));
                }

                if (buttonText is { } && action is { } && query is { })
                {
                    toastBuilder.AddButton(buttonText, ToastActivationType.Background, $"action={action}&{query}");
                }

                var x = new XmlDocument();
                var content = toastBuilder.GetToastContent().GetContent();
                x.LoadXml(content);

                var toast = new ToastNotification(x);
                toast.ExpiresOnReboot = true;
                toast.ExpirationTime = DateTimeOffset.Now.AddSeconds(timeout ?? 5);

                ToastNotificationManager.CreateToastNotifier("Shotr").Show(toast);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}