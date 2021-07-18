﻿#pragma checksum "..\..\Signin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E2780BEE3C322DBAAE60ECBC807BDA6B0D7D806DB192E139582F6D9AF35AAB5F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Dooz;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Dooz {
    
    
    /// <summary>
    /// Signin
    /// </summary>
    public partial class Signin : Dooz.BaseWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\Signin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EdtUsername;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Signin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EdtPassword;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Signin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSignin;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Signin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSignup;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Signin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.SnackbarMessage SnackbarMessage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Minroob;component/signin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Signin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.EdtUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.EdtPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.BtnSignin = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\Signin.xaml"
            this.BtnSignin.Click += new System.Windows.RoutedEventHandler(this.BtnSinginClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnSignup = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Signin.xaml"
            this.BtnSignup.Click += new System.Windows.RoutedEventHandler(this.BtnSignup_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SnackbarMessage = ((MaterialDesignThemes.Wpf.SnackbarMessage)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

