using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications;
using Shotr.Core;
using Shotr.Core.Services;
using Shotr.Ui.Forms;

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
                    var updateForm = new UpdateForm(dict["changes"], subscribe);
                    updateForm.ShowDialog();
                    break;
            }
		}

        public static void Send(string? imagePath, string text, string? buttonText = null, string? action = null, string? query = null)
        {
            var toastBuilder = new ToastContentBuilder()
                .AddAppLogoOverride(new Uri(Path.Combine(SettingsService.CachePath, "shotr.png")), ToastGenericAppLogoCrop.Default)
                .AddText("Shotr")
                .AddText(text);

            if (imagePath is { })
            {
                toastBuilder.AddHeroImage(new Uri(imagePath));
            }

            if (buttonText is { } && action is { } && query is { })
            {
                toastBuilder.AddButton(buttonText, ToastActivationType.Foreground, $"action={action}&{query}");
            }

            XmlDocument x = new XmlDocument();
            var content = toastBuilder.GetToastContent().GetContent();
            x.LoadXml(content);

            ToastNotification toast = new ToastNotification(x);

            ToastNotificationManager.CreateToastNotifier("Shotr").Show(toast);
        }
    }
    
}
