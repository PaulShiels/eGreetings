﻿#pragma checksum "C:\Users\Paul\Documents\IT\Year4\MobileArchDesign\eGreetings\eGreetings\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DA1709402F8A031DFB575A366C01B4FF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Button btnNewGreeting;
        
        internal System.Windows.Controls.Button btnSavedGreetings;
        
        internal System.Windows.Controls.Button btnTemplates;
        
        internal System.Windows.Controls.Button btnRecentlySent;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/eGreetings;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.btnNewGreeting = ((System.Windows.Controls.Button)(this.FindName("btnNewGreeting")));
            this.btnSavedGreetings = ((System.Windows.Controls.Button)(this.FindName("btnSavedGreetings")));
            this.btnTemplates = ((System.Windows.Controls.Button)(this.FindName("btnTemplates")));
            this.btnRecentlySent = ((System.Windows.Controls.Button)(this.FindName("btnRecentlySent")));
        }
    }
}

