﻿#pragma checksum "C:\Users\Paul\Documents\IT\Year4\MobileArchDesign\eGreetings\eGreetings\Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3A1BF877ECCD183D265E84D6F17A98D3"
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
    
    
    public partial class Login : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock txtLogin;
        
        internal System.Windows.Controls.TextBlock lblUsername;
        
        internal System.Windows.Controls.TextBox txtUsername;
        
        internal System.Windows.Controls.TextBlock lblPassword;
        
        internal System.Windows.Controls.TextBox txtPassword;
        
        internal System.Windows.Controls.TextBlock txtLoggingIn;
        
        internal System.Windows.Controls.TextBlock txtError;
        
        internal System.Windows.Controls.Button btnSignUp;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/eGreetings;component/Login.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.txtLogin = ((System.Windows.Controls.TextBlock)(this.FindName("txtLogin")));
            this.lblUsername = ((System.Windows.Controls.TextBlock)(this.FindName("lblUsername")));
            this.txtUsername = ((System.Windows.Controls.TextBox)(this.FindName("txtUsername")));
            this.lblPassword = ((System.Windows.Controls.TextBlock)(this.FindName("lblPassword")));
            this.txtPassword = ((System.Windows.Controls.TextBox)(this.FindName("txtPassword")));
            this.txtLoggingIn = ((System.Windows.Controls.TextBlock)(this.FindName("txtLoggingIn")));
            this.txtError = ((System.Windows.Controls.TextBlock)(this.FindName("txtError")));
            this.btnSignUp = ((System.Windows.Controls.Button)(this.FindName("btnSignUp")));
            this.btnLogin = ((System.Windows.Controls.Button)(this.FindName("btnLogin")));
        }
    }
}

