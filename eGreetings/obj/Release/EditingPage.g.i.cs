﻿#pragma checksum "C:\Users\Paul\Documents\IT\Year4\MobileArchDesign\eGreetings\eGreetings\EditingPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E5077DCC5FADDA7E29AA329092691739"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Coding4Fun.Toolkit.Controls;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace eGreetings {
    
    
    public partial class EditingPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ListBox lbxObjects;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Canvas canvasImage;
        
        internal System.Windows.Controls.Image imgBackgroundImage;
        
        internal System.Windows.Controls.StackPanel btnShowTools;
        
        internal System.Windows.Controls.StackPanel spToolsButtons;
        
        internal System.Windows.Controls.StackPanel btnHideTools;
        
        internal System.Windows.Controls.Image btnHide;
        
        internal System.Windows.Controls.StackPanel btnObjects;
        
        internal System.Windows.Controls.StackPanel btnDraw;
        
        internal System.Windows.Controls.StackPanel btnEraseObject;
        
        internal System.Windows.Controls.StackPanel btnText;
        
        internal System.Windows.Controls.StackPanel btnSave;
        
        internal System.Windows.Controls.StackPanel btnSend;
        
        internal System.Windows.Controls.Border spModal;
        
        internal System.Windows.Controls.Button btnYes;
        
        internal System.Windows.Controls.Button btnNo;
        
        internal System.Windows.Controls.Border spBackModal;
        
        internal System.Windows.Controls.Button btnYesGoBack;
        
        internal System.Windows.Controls.Button btnNoDontLeavePage;
        
        internal System.Windows.Controls.Border insertTextModal;
        
        internal System.Windows.Controls.TextBox txtMessage;
        
        internal Coding4Fun.Toolkit.Controls.ColorPicker csFontColor;
        
        internal Microsoft.Phone.Controls.ListPicker lpFontSize;
        
        internal Microsoft.Phone.Controls.ListPicker lpFontFamily;
        
        internal System.Windows.Controls.Button btnOk;
        
        internal System.Windows.Controls.Border txtImagedSaved;
        
        internal Coding4Fun.Toolkit.Controls.ColorSlider cpDrawColour;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/eGreetings;component/EditingPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.lbxObjects = ((System.Windows.Controls.ListBox)(this.FindName("lbxObjects")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.canvasImage = ((System.Windows.Controls.Canvas)(this.FindName("canvasImage")));
            this.imgBackgroundImage = ((System.Windows.Controls.Image)(this.FindName("imgBackgroundImage")));
            this.btnShowTools = ((System.Windows.Controls.StackPanel)(this.FindName("btnShowTools")));
            this.spToolsButtons = ((System.Windows.Controls.StackPanel)(this.FindName("spToolsButtons")));
            this.btnHideTools = ((System.Windows.Controls.StackPanel)(this.FindName("btnHideTools")));
            this.btnHide = ((System.Windows.Controls.Image)(this.FindName("btnHide")));
            this.btnObjects = ((System.Windows.Controls.StackPanel)(this.FindName("btnObjects")));
            this.btnDraw = ((System.Windows.Controls.StackPanel)(this.FindName("btnDraw")));
            this.btnEraseObject = ((System.Windows.Controls.StackPanel)(this.FindName("btnEraseObject")));
            this.btnText = ((System.Windows.Controls.StackPanel)(this.FindName("btnText")));
            this.btnSave = ((System.Windows.Controls.StackPanel)(this.FindName("btnSave")));
            this.btnSend = ((System.Windows.Controls.StackPanel)(this.FindName("btnSend")));
            this.spModal = ((System.Windows.Controls.Border)(this.FindName("spModal")));
            this.btnYes = ((System.Windows.Controls.Button)(this.FindName("btnYes")));
            this.btnNo = ((System.Windows.Controls.Button)(this.FindName("btnNo")));
            this.spBackModal = ((System.Windows.Controls.Border)(this.FindName("spBackModal")));
            this.btnYesGoBack = ((System.Windows.Controls.Button)(this.FindName("btnYesGoBack")));
            this.btnNoDontLeavePage = ((System.Windows.Controls.Button)(this.FindName("btnNoDontLeavePage")));
            this.insertTextModal = ((System.Windows.Controls.Border)(this.FindName("insertTextModal")));
            this.txtMessage = ((System.Windows.Controls.TextBox)(this.FindName("txtMessage")));
            this.csFontColor = ((Coding4Fun.Toolkit.Controls.ColorPicker)(this.FindName("csFontColor")));
            this.lpFontSize = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpFontSize")));
            this.lpFontFamily = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpFontFamily")));
            this.btnOk = ((System.Windows.Controls.Button)(this.FindName("btnOk")));
            this.txtImagedSaved = ((System.Windows.Controls.Border)(this.FindName("txtImagedSaved")));
            this.cpDrawColour = ((Coding4Fun.Toolkit.Controls.ColorSlider)(this.FindName("cpDrawColour")));
        }
    }
}

