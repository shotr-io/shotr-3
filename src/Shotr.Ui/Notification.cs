using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;
using Shotr.Core;

namespace Shotr.Ui
{
    [ComSourceInterfaces(typeof(INotificationActivationCallback))]
	[Guid("F690F4C2-040B-41DC-BE39-08477E082DFC"), ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    public class Notification : NotificationActivator
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
            }
		}
	}
    
}
