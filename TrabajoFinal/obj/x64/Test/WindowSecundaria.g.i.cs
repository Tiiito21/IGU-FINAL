﻿#pragma checksum "..\..\..\WindowSecundaria.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2664EA358C653E51E743FC78DDC89615F587F2FF19FB7613182D80529D965381"
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
    /// WindowSecundaria
    /// </summary>
    public partial class WindowSecundaria : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\WindowSecundaria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem menuAnnadir;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\WindowSecundaria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem importarProcesos;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\WindowSecundaria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem modProceso;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\WindowSecundaria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem eliProceso;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\WindowSecundaria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem modPartidos;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\WindowSecundaria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView TablaProcesos;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\WindowSecundaria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView TablaProceso;
        
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
            System.Uri resourceLocater = new System.Uri("/TrabajoFinalAlejandroAceves;component/windowsecundaria.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowSecundaria.xaml"
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
            this.menuAnnadir = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\..\WindowSecundaria.xaml"
            this.menuAnnadir.Click += new System.Windows.RoutedEventHandler(this.MenuAnnadirProceso_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.importarProcesos = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\..\WindowSecundaria.xaml"
            this.importarProcesos.Click += new System.Windows.RoutedEventHandler(this.MenuImportarProceso_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.modProceso = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\..\WindowSecundaria.xaml"
            this.modProceso.Click += new System.Windows.RoutedEventHandler(this.MenuModProceso_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.eliProceso = ((System.Windows.Controls.MenuItem)(target));
            
            #line 22 "..\..\..\WindowSecundaria.xaml"
            this.eliProceso.Click += new System.Windows.RoutedEventHandler(this.MenuBorrarProceso_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.modPartidos = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 6:
            this.TablaProcesos = ((System.Windows.Controls.ListView)(target));
            
            #line 30 "..\..\..\WindowSecundaria.xaml"
            this.TablaProcesos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Procesos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TablaProceso = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

