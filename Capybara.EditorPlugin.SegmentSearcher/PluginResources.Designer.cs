﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capybara.EditorPlugin.SegmentSearcher {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class PluginResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PluginResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Capybara.EditorPlugin.SegmentSearcher.PluginResources", typeof(PluginResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to @charset &quot;UTF-8&quot;;
        ///
        ///body {
        ///	font-family:&apos;Arial Unicode MS&apos;;
        ///	font-size: 70%;
        ///}
        ///
        ///#results {
        ///	border-collapse: collapse;
        ///}
        ///
        ///#results th, td {
        ///    border: 1px #000000 dashed;
        ///	padding: 5px;
        ///}
        ///
        ///#results thead {
        ///	background: #6485B4;
        ///	border: 1px #000000 solid;
        ///}
        ///
        ///.entry-odd {
        ///	background: #E6EAEE;
        ///}
        ///
        ///#results tbody {
        ///	border: 1px #000000 solid;
        ///}
        ///
        ///#results tbody:hover {
        ///	background: #9EC9D7;
        ///}
        ///
        ///td.file-id {
        ///    display: none;
        ///}
        ///
        ///.seg-info {
        ///	text-align: center;
        ///}
        ///
        ///.seg-in [rest of string was truncated]&quot;;.
        /// </summary>
        public static string base_css {
            get {
                return ResourceManager.GetString("base_css", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;!DOCTYPE html PUBLIC &quot;-//W3C//DTD XHTML 1.0 Transitional//EN&quot; &quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;&gt;
        ///&lt;html xmlns=&quot;http://www.w3.org/1999/xhtml&quot; xml:lang=&quot;en&quot;&gt;
        ///&lt;head&gt;
        ///    &lt;meta http-equiv=&quot;Content-Type&quot; content=&quot;text/html;charset=UTF-8&quot;/&gt;
        ///    &lt;meta http-equiv=&quot;X-UA-Compatible&quot; content=&quot;IE=edge, chrome=1&quot; /&gt;
        ///	&lt;link rel=&quot;stylesheet&quot; href=&quot;base.css&quot; type=&quot;text/css&quot; charset=&quot;UTF-8&quot; /&gt;
        ///    &lt;script type=&quot;text/javascript&quot; src=&quot;jquery.js&quot;&gt;&lt;/script&gt;
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        public static string base_html {
            get {
                return ResourceManager.GetString("base_html", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /*! jQuery v1.9.1 | (c) 2005, 2012 jQuery Foundation, Inc. | jquery.org/license
        /////@ sourceMappingURL=jquery.min.map
        ///*/(function(e,t){var n,r,i=typeof t,o=e.document,a=e.location,s=e.jQuery,u=e.$,l={},c=[],p=&quot;1.9.1&quot;,f=c.concat,d=c.push,h=c.slice,g=c.indexOf,m=l.toString,y=l.hasOwnProperty,v=p.trim,b=function(e,t){return new b.fn.init(e,t,r)},x=/[+-]?(?:\d*\.|)\d+(?:[eE][+-]?\d+|)/.source,w=/\S+/g,T=/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g,N=/^(?:(&lt;[\w\W]+&gt;)[^&gt;]*|#([\w-]*))$/,C=/^&lt;(\w+)\s*\/?&gt;(?:&lt;\/\1&gt;|)$/,k=/^ [rest of string was truncated]&quot;;.
        /// </summary>
        public static string jquery {
            get {
                return ResourceManager.GetString("jquery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $(function () {
        ///    $(&apos;select[name=&quot;file-filter&quot;]&apos;).change(function (event) {
        ///        var allCount = $(&apos;#all-count&apos;).text();
        ///        $(&apos;#filtered-count&apos;).text(allCount);
        ///        var fileId = $(this).val();
        ///        $(&apos;#results tbody&apos;).show();
        ///        if (fileId !== &apos;#ALL#&apos;) {
        ///            var hiddenTbodies = $(&apos;td.file-id:not(:contains(&quot;&apos; + fileId + &apos;&quot;))&apos;).closest(&apos;tbody&apos;);
        ///            $(&apos;#filtered-count&apos;).text(allCount - hiddenTbodies.size());
        ///            hiddenTbodies.hide();
        ///        }
        ///    });
        ///} [rest of string was truncated]&quot;;.
        /// </summary>
        public static string main_js {
            get {
                return ResourceManager.GetString("main_js", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SegmentSearcher.
        /// </summary>
        public static string Plugin_Description {
            get {
                return ResourceManager.GetString("Plugin_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SegmentSearcher.
        /// </summary>
        public static string Plugin_Name {
            get {
                return ResourceManager.GetString("Plugin_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        public static System.Drawing.Icon SegmentSearcher_Documentation {
            get {
                object obj = ResourceManager.GetObject("SegmentSearcher_Documentation", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        public static System.Drawing.Icon SegmentSearcher_Icon {
            get {
                object obj = ResourceManager.GetObject("SegmentSearcher_Icon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        public static System.Drawing.Icon SegmentSearcher_Question {
            get {
                object obj = ResourceManager.GetObject("SegmentSearcher_Question", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        public static System.Drawing.Icon SegmentSearcher_Settings {
            get {
                object obj = ResourceManager.GetObject("SegmentSearcher_Settings", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        public static System.Drawing.Icon SegmentSearcher_SourceCode {
            get {
                object obj = ResourceManager.GetObject("SegmentSearcher_SourceCode", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Search in opened documents.
        /// </summary>
        public static string SegmentSearcherAction_Description {
            get {
                return ResourceManager.GetString("SegmentSearcherAction_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Search by SegmentSearcher.
        /// </summary>
        public static string SegmentSearcherAction_Name {
            get {
                return ResourceManager.GetString("SegmentSearcherAction_Name", resourceCulture);
            }
        }
    }
}
