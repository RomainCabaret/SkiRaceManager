﻿#pragma checksum "..\..\..\..\..\Views\Pages\View\ViewSlope.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0EBEF9DE741D54FB7ADF0BFF32C46616E2B9CB6C5171F607EF626AE0605E6C1E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SkiRaceManager;
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


namespace SkiRaceManager.Views.Pages.View {
    
    
    /// <summary>
    /// ViewSlope
    /// </summary>
    public partial class ViewSlope : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\..\Views\Pages\View\ViewSlope.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image votreImageControl;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\Views\Pages\View\ViewSlope.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textTitle;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\Views\Pages\View\ViewSlope.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputName;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\Views\Pages\View\ViewSlope.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ParticipationListView;
        
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
            System.Uri resourceLocater = new System.Uri("/SkiRaceManager;component/views/pages/view/viewslope.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Pages\View\ViewSlope.xaml"
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
            
            #line 17 "..\..\..\..\..\Views\Pages\View\ViewSlope.xaml"
            ((SkiRaceManager.Views.Pages.View.ViewSlope)(target)).Loaded += new System.Windows.RoutedEventHandler(this.ViewSlope_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.votreImageControl = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.textTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.inputName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 49 "..\..\..\..\..\Views\Pages\View\ViewSlope.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSearchParticipation);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 52 "..\..\..\..\..\Views\Pages\View\ViewSlope.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAddParticipation);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ParticipationListView = ((System.Windows.Controls.ListView)(target));
            
            #line 55 "..\..\..\..\..\Views\Pages\View\ViewSlope.xaml"
            this.ParticipationListView.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ParticipationListView_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

