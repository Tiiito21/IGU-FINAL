﻿#pragma checksum "..\..\ProcesoMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9556A7542AFAE7EB5BAB1558C14D908E7EA9F236A6AF267289E60C906CB45BBF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TrabajoFinalAlejandroAceves;


namespace TrabajoFinalAlejandroAceves {
    
    
    /// <summary>
    /// ProcesoMenu
    /// </summary>
    public partial class ProcesoMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\ProcesoMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\ProcesoMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\ProcesoMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox numDip;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\ProcesoMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox numMayoria;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\ProcesoMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button modificarPartido;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\ProcesoMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button eliminarPartido;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\ProcesoMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView TablaPartidos;
        
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
            System.Uri resourceLocater = new System.Uri("/TrabajoFinalAlejandroAceves;component/procesomenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProcesoMenu.xaml"
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
            this.name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.date = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.numDip = ((System.Windows.Controls.TextBox)(target));
            
            #line 40 "..\..\ProcesoMenu.xaml"
            this.numDip.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NumDip_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.numMayoria = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 47 "..\..\ProcesoMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Aceptar_Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 48 "..\..\ProcesoMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Rechazar_Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 73 "..\..\ProcesoMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddPartido_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.modificarPartido = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\ProcesoMenu.xaml"
            this.modificarPartido.Click += new System.Windows.RoutedEventHandler(this.ModPartido_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.eliminarPartido = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\ProcesoMenu.xaml"
            this.eliminarPartido.Click += new System.Windows.RoutedEventHandler(this.BorrarPartido_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.TablaPartidos = ((System.Windows.Controls.ListView)(target));
            
            #line 78 "..\..\ProcesoMenu.xaml"
            this.TablaPartidos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TablaPartidos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

