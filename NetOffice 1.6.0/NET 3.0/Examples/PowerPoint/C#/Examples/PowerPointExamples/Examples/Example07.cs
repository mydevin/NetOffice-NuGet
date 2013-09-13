﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ExampleBase;

using NetOffice;
using PowerPoint = NetOffice.PowerPointApi;
using NetOffice.PowerPointApi.Enums;
using Office = NetOffice.OfficeApi;
using NetOffice.OfficeApi.Enums;

namespace PowerPointExamplesCS3
{
    public partial class Example07 : UserControl, IExample 
    {
        IHost _hostApplication;
        PowerPoint.Application _powerApplication;

        private delegate void UpdateEventTextDelegate(string Message);
        UpdateEventTextDelegate _updateDelegate;

        public Example07()
        {
            InitializeComponent();
            _updateDelegate = new UpdateEventTextDelegate(UpdateTextbox);
        }

        #region IExample Member

        public void RunExample()
        {
            // its an example with an own visual control
            // checkout buttonStartExample_Click
        }

        public void Connect(IHost hostApplication)
        {
            _hostApplication = hostApplication;
        }

        public string Caption
        {
            get { return _hostApplication.LCID == 1033 ? "Example07" : "Beispiel07"; }
        }

        public string Description
        {
            get { return _hostApplication.LCID == 1033 ? "Customize classic UI without ribbons and recieve click events" : "Erweitern der klassischen Oberfläche und beziehen von Click Events"; }
        }
     
        public UserControl Panel
        {
            get { return this; }
        }

        #endregion

        #region UI Trigger

        private void buttonStartExample_Click(object sender, EventArgs e)
        {        
            // start powerpoint
            _powerApplication = new PowerPoint.Application();

            Office.CommandBar commandBar = null;
            Office.CommandBarButton commandBarBtn = null;

            // add a new presentation with one new slide
            PowerPoint.Presentation presentation = _powerApplication.Presentations.Add(MsoTriState.msoTrue);
            PowerPoint.Slide slide = presentation.Slides.Add(1, PpSlideLayout.ppLayoutBlank);

            // add a commandbar popup
            Office.CommandBarPopup commandBarPopup = (Office.CommandBarPopup)_powerApplication.CommandBars["Menu Bar"].Controls.Add(MsoControlType.msoControlPopup, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            commandBarPopup.Caption = "commandBarPopup";

            #region few words, how to access the picture
            /*
             you can see we use an own icon via .PasteFace()
             is not possible from outside process boundaries to use the PictureProperty directly
             the reason for is IPictureDisp: http://support.microsoft.com/kb/286460/de
             its not important is early or late binding or managed or unmanaged, the behaviour is always the same
             For example, a COMAddin running as InProcServer and can access the Picture Property
            */
            #endregion
            
            #region CommandBarButton

            // add a button to the popup
            commandBarBtn = (Office.CommandBarButton)commandBarPopup.Controls.Add(MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            commandBarBtn.Style = MsoButtonStyle.msoButtonIconAndCaption;
            commandBarBtn.Caption = "commandBarButton";
            Clipboard.SetDataObject(_hostApplication.DisplayIcon.ToBitmap());
            commandBarBtn.PasteFace();
            commandBarBtn.ClickEvent += new Office.CommandBarButton_ClickEventHandler(commandBarBtn_Click);

            #endregion

            #region Create a new toolbar

            // add a new toolbar
            commandBar = _powerApplication.CommandBars.Add("MyCommandBar", MsoBarPosition.msoBarTop, false, true);
            commandBar.Visible = true;

            // add a button to the toolbar
            commandBarBtn = (Office.CommandBarButton)commandBar.Controls.Add(MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            commandBarBtn.Style = MsoButtonStyle.msoButtonIconAndCaption;
            commandBarBtn.Caption = "commandBarButton";
            commandBarBtn.FaceId = 3;
            commandBarBtn.ClickEvent += new Office.CommandBarButton_ClickEventHandler(commandBarBtn_Click);

            // add a dropdown box to the toolbar
            commandBarPopup = (Office.CommandBarPopup)commandBar.Controls.Add(MsoControlType.msoControlPopup, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            commandBarPopup.Caption = "commandBarPopup";

            // add a button to the popup, we use an own icon for the button
            commandBarBtn = (Office.CommandBarButton)commandBarPopup.Controls.Add(MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            commandBarBtn.Style = MsoButtonStyle.msoButtonIconAndCaption;
            commandBarBtn.Caption = "commandBarButton";
            Clipboard.SetDataObject(_hostApplication.DisplayIcon.ToBitmap());
            commandBarBtn.PasteFace();
            commandBarBtn.ClickEvent += new Office.CommandBarButton_ClickEventHandler(commandBarBtn_Click);

            #endregion

            #region Create a new ContextMenu

            // add a commandbar popup
            commandBarPopup = (Office.CommandBarPopup)_powerApplication.CommandBars["Frames"].Controls.Add(
                                                            MsoControlType.msoControlPopup, Missing.Value, Missing.Value, Missing.Value, true);
            commandBarPopup.Caption = "commandBarPopup";

            // add a button to the popup
            commandBarBtn = (Office.CommandBarButton)commandBarPopup.Controls.Add(MsoControlType.msoControlButton, Missing.Value, Missing.Value, Missing.Value, true);
            commandBarBtn.Style = MsoButtonStyle.msoButtonIconAndCaption;
            commandBarBtn.Caption = "commandBarButton";
            commandBarBtn.FaceId = 9;
            commandBarBtn.ClickEvent += new Office.CommandBarButton_ClickEventHandler(commandBarBtn_Click);

            #endregion

            // make visible & set buttons
            _powerApplication.Visible = MsoTriState.msoTrue;
            buttonStartExample.Enabled = false;
            buttonQuitExample.Enabled = true;             
        }

        private void buttonQuitExample_Click(object sender, EventArgs e)
        {
            _powerApplication.Quit();
            _powerApplication.Dispose();

            buttonStartExample.Enabled = true;
            buttonQuitExample.Enabled = false; 
        }

        #endregion

        #region PowerPoint Trigger

        void commandBarBtn_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            textBoxEvents.BeginInvoke(_updateDelegate, new object[] { "Click called." });
            Ctrl.Dispose();
        }

        private void UpdateTextbox(string Message)
        {
            textBoxEvents.AppendText(Message + "\r\n");
        }

        #endregion
    }
}