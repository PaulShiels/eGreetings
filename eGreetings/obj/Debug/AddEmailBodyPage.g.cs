﻿#pragma checksum "C:\Users\Paul\Documents\IT\Year4\MobileArchDesign\eGreetings\eGreetings\AddEmailBodyPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "033AA73E4E0C7584E6042C8A61B22AFC"
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
    
    
    public partial class AddEmailBodyPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock lblAddMsg;
        
        internal System.Windows.Controls.TextBox txtEmailBody;
        
        internal System.Windows.Controls.Button btnNext;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/eGreetings;component/AddEmailBodyPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.lblAddMsg = ((System.Windows.Controls.TextBlock)(this.FindName("lblAddMsg")));
            this.txtEmailBody = ((System.Windows.Controls.TextBox)(this.FindName("txtEmailBody")));
            this.btnNext = ((System.Windows.Controls.Button)(this.FindName("btnNext")));
        }
    }
}

