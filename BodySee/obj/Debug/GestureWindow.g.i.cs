﻿#pragma checksum "..\..\GestureWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E60FDD691175BFDD6893413E20EE889157EA703C"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using BodySee;
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


namespace BodySee {
    
    
    /// <summary>
    /// GestureWindow
    /// </summary>
    public partial class GestureWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\GestureWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GestureButton;
        
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
            System.Uri resourceLocater = new System.Uri("/BodySee;component/gesturewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GestureWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.GestureButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\GestureWindow.xaml"
            this.GestureButton.TouchDown += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.GestureButton_TouchDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\GestureWindow.xaml"
            this.GestureButton.KeyDown += new System.Windows.Input.KeyEventHandler(this.GestureButton_KeyDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\GestureWindow.xaml"
            this.GestureButton.TouchMove += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.GestureButton_TouchMove);
            
            #line default
            #line hidden
            
            #line 14 "..\..\GestureWindow.xaml"
            this.GestureButton.TouchUp += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.GestureButton_TouchUp);
            
            #line default
            #line hidden
            
            #line 14 "..\..\GestureWindow.xaml"
            this.GestureButton.ManipulationStarting += new System.EventHandler<System.Windows.Input.ManipulationStartingEventArgs>(this.GestureButton_ManipulationStarting);
            
            #line default
            #line hidden
            
            #line 14 "..\..\GestureWindow.xaml"
            this.GestureButton.ManipulationDelta += new System.EventHandler<System.Windows.Input.ManipulationDeltaEventArgs>(this.GestureButton_ManipulationDelta);
            
            #line default
            #line hidden
            
            #line 14 "..\..\GestureWindow.xaml"
            this.GestureButton.ManipulationInertiaStarting += new System.EventHandler<System.Windows.Input.ManipulationInertiaStartingEventArgs>(this.GestureButton_ManipulationInertiaStarting);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

