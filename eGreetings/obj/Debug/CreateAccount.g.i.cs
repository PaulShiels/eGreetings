﻿#pragma checksum "C:\Users\Paul\Documents\IT\Year4\MobileArchDesign\eGreetings\eGreetings\CreateAccount.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "83C08F28F784418D3D9CF40FCA47ADCC"
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
    
    
    public partial class CreateAccount : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox txtUsername;
        
        internal System.Windows.Controls.TextBox txtPassword;
        
        internal System.Windows.Controls.TextBox txtConfirmPassword;
        
        internal Microsoft.Phone.Controls.DatePicker dpDob;
        
        internal System.Windows.Controls.Button btnLogin;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/eGreetings;component/CreateAccount.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.txtUsername = ((System.Windows.Controls.TextBox)(this.FindName("txtUsername")));
            this.txtPassword = ((System.Windows.Controls.TextBox)(this.FindName("txtPassword")));
            this.txtConfirmPassword = ((System.Windows.Controls.TextBox)(this.FindName("txtConfirmPassword")));
            this.dpDob = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("dpDob")));
            this.btnLogin = ((System.Windows.Controls.Button)(this.FindName("btnLogin")));
        }
    }
}

