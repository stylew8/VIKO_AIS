﻿#pragma checksum "..\..\..\PazymiaiWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B58DFBE3C886C2A7914709C5B482A265F85A76AF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using WpfAIS;


namespace WpfAIS {
    
    
    /// <summary>
    /// PazymiaiWindow
    /// </summary>
    public partial class PazymiaiWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\PazymiaiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgPazymiai;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\PazymiaiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAtsijungti;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\PazymiaiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnKont;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\PazymiaiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtprisijungtas;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\PazymiaiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIndPlanas;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfAIS;component/pazymiaiwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PazymiaiWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\PazymiaiWindow.xaml"
            ((WpfAIS.PazymiaiWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dtgPazymiai = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.btnAtsijungti = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\PazymiaiWindow.xaml"
            this.btnAtsijungti.Click += new System.Windows.RoutedEventHandler(this.btnAtsijungti_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnKont = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\PazymiaiWindow.xaml"
            this.btnKont.Click += new System.Windows.RoutedEventHandler(this.btnKont_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtprisijungtas = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btnIndPlanas = ((System.Windows.Controls.Button)(target));
            
            #line 123 "..\..\..\PazymiaiWindow.xaml"
            this.btnIndPlanas.Click += new System.Windows.RoutedEventHandler(this.btnIndPlanas_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

