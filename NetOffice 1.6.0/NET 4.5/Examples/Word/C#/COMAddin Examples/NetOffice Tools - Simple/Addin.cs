﻿using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NetOffice.Tools;
using NetOffice.WordApi.Tools;
using NetOffice.WordApi;

/*
  * This project shows you the COMAddin base class from the NetOffice tools.
  * Its designed to reduce infrastructure code from your own.
  * You have to set some attributes and thats all. 
  * You see also the host application is available as class instance property. no need for dispose here because the base class do this for you while shutdown.
*/

namespace NetOfficeTools.SimpleAccessCS45
{
    [COMAddin("NetOfficeCS45 Sample Word Addin", "This Addin shows you the COMAddin base class from the NetOffice Tools", 3)]
    [GuidAttribute("F4EC5A72-C431-4BFA-85AB-43A0817617C7"), ProgId("SimpleWordCS45.Addin")]
    public class Addin : COMAddin
    {
        public Addin()
        {
            this.OnStartupComplete += new OnStartupCompleteEventHandler(Addin_OnStartupComplete);
            this.OnDisconnection += new OnDisconnectionEventHandler(Addin_OnDisconnection);
        }

        void Addin_OnStartupComplete(ref Array custom)
        {
            // get the host application version
            string hostVersion = this.Application.Version;
            MessageBox.Show("Host Application Version:" + hostVersion);
        }

        void Addin_OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
        {

        }
    }
}
