﻿#pragma checksum "C:\Users\Paul\Documents\IT\Year4\MobileArchDesign\eGreetings\eGreetings\EditingPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B16A39DF4A19C2E2301A4387DBDBD013"
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
        
        internal System.Windows.Controls.Image ball;
        
        internal System.Windows.Controls.Image balloon;
        
        internal System.Windows.Controls.Image balloon2;
        
        internal System.Windows.Controls.Image banner1;
        
        internal System.Windows.Controls.Image bow1;
        
        internal System.Windows.Controls.Image cake1;
        
        internal System.Windows.Controls.Image cake2;
        
        internal System.Windows.Controls.Image cake3;
        
        internal System.Windows.Controls.Image christmas1;
        
        internal System.Windows.Controls.Image flower1;
        
        internal System.Windows.Controls.Image Happy_Birthday;
        
        internal System.Windows.Controls.Image Happy_Birthday2;
        
        internal System.Windows.Controls.Image hat1;
        
        internal System.Windows.Controls.Image present1;
        
        internal System.Windows.Controls.Image present2;
        
        internal System.Windows.Controls.Image present3;
        
        internal System.Windows.Controls.Image ribbons;
        
        internal System.Windows.Controls.Image santa1;
        
        internal System.Windows.Controls.Image santa2;
        
        internal System.Windows.Controls.Image smiley1;
        
        internal System.Windows.Controls.Image smiley2;
        
        internal System.Windows.Controls.Image smiley3;
        
        internal System.Windows.Controls.Image smiley4;
        
        internal System.Windows.Controls.Image snowman1;
        
        internal System.Windows.Controls.Image wreath1;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Canvas canvasImage;
        
        internal System.Windows.Controls.Image imgBackgroundImage;
        
        internal System.Windows.Controls.StackPanel spToolsButtons;
        
        internal System.Windows.Controls.Image btnObjects;
        
        internal System.Windows.Controls.Image btnText;
        
        internal System.Windows.Controls.Image btnSave;
        
        internal System.Windows.Controls.Image btnSend;
        
        internal System.Windows.Controls.Border spModal;
        
        internal System.Windows.Controls.Button btnYes;
        
        internal System.Windows.Controls.Button btnNo;
        
        internal System.Windows.Controls.Border insertTextModal;
        
        internal System.Windows.Controls.TextBox txtMessage;
        
        internal Coding4Fun.Toolkit.Controls.ColorPicker csFontColor;
        
        internal Microsoft.Phone.Controls.ListPicker lpFontSize;
        
        internal Microsoft.Phone.Controls.ListPicker lpFontFamily;
        
        internal System.Windows.Controls.Button btnOk;
        
        internal System.Windows.Controls.Border txtImagedSaved;
        
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
            this.ball = ((System.Windows.Controls.Image)(this.FindName("ball")));
            this.balloon = ((System.Windows.Controls.Image)(this.FindName("balloon")));
            this.balloon2 = ((System.Windows.Controls.Image)(this.FindName("balloon2")));
            this.banner1 = ((System.Windows.Controls.Image)(this.FindName("banner1")));
            this.bow1 = ((System.Windows.Controls.Image)(this.FindName("bow1")));
            this.cake1 = ((System.Windows.Controls.Image)(this.FindName("cake1")));
            this.cake2 = ((System.Windows.Controls.Image)(this.FindName("cake2")));
            this.cake3 = ((System.Windows.Controls.Image)(this.FindName("cake3")));
            this.christmas1 = ((System.Windows.Controls.Image)(this.FindName("christmas1")));
            this.flower1 = ((System.Windows.Controls.Image)(this.FindName("flower1")));
            this.Happy_Birthday = ((System.Windows.Controls.Image)(this.FindName("Happy_Birthday")));
            this.Happy_Birthday2 = ((System.Windows.Controls.Image)(this.FindName("Happy_Birthday2")));
            this.hat1 = ((System.Windows.Controls.Image)(this.FindName("hat1")));
            this.present1 = ((System.Windows.Controls.Image)(this.FindName("present1")));
            this.present2 = ((System.Windows.Controls.Image)(this.FindName("present2")));
            this.present3 = ((System.Windows.Controls.Image)(this.FindName("present3")));
            this.ribbons = ((System.Windows.Controls.Image)(this.FindName("ribbons")));
            this.santa1 = ((System.Windows.Controls.Image)(this.FindName("santa1")));
            this.santa2 = ((System.Windows.Controls.Image)(this.FindName("santa2")));
            this.smiley1 = ((System.Windows.Controls.Image)(this.FindName("smiley1")));
            this.smiley2 = ((System.Windows.Controls.Image)(this.FindName("smiley2")));
            this.smiley3 = ((System.Windows.Controls.Image)(this.FindName("smiley3")));
            this.smiley4 = ((System.Windows.Controls.Image)(this.FindName("smiley4")));
            this.snowman1 = ((System.Windows.Controls.Image)(this.FindName("snowman1")));
            this.wreath1 = ((System.Windows.Controls.Image)(this.FindName("wreath1")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.canvasImage = ((System.Windows.Controls.Canvas)(this.FindName("canvasImage")));
            this.imgBackgroundImage = ((System.Windows.Controls.Image)(this.FindName("imgBackgroundImage")));
            this.spToolsButtons = ((System.Windows.Controls.StackPanel)(this.FindName("spToolsButtons")));
            this.btnObjects = ((System.Windows.Controls.Image)(this.FindName("btnObjects")));
            this.btnText = ((System.Windows.Controls.Image)(this.FindName("btnText")));
            this.btnSave = ((System.Windows.Controls.Image)(this.FindName("btnSave")));
            this.btnSend = ((System.Windows.Controls.Image)(this.FindName("btnSend")));
            this.spModal = ((System.Windows.Controls.Border)(this.FindName("spModal")));
            this.btnYes = ((System.Windows.Controls.Button)(this.FindName("btnYes")));
            this.btnNo = ((System.Windows.Controls.Button)(this.FindName("btnNo")));
            this.insertTextModal = ((System.Windows.Controls.Border)(this.FindName("insertTextModal")));
            this.txtMessage = ((System.Windows.Controls.TextBox)(this.FindName("txtMessage")));
            this.csFontColor = ((Coding4Fun.Toolkit.Controls.ColorPicker)(this.FindName("csFontColor")));
            this.lpFontSize = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpFontSize")));
            this.lpFontFamily = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpFontFamily")));
            this.btnOk = ((System.Windows.Controls.Button)(this.FindName("btnOk")));
            this.txtImagedSaved = ((System.Windows.Controls.Border)(this.FindName("txtImagedSaved")));
        }
    }
}

