#pragma checksum "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b66915af3cafc30589c921828f03bcfd966f7d8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GasComponent_Index), @"mvc.1.0.view", @"/Views/GasComponent/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\_ViewImports.cshtml"
using WNTS_V1._0._2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\_ViewImports.cshtml"
using WNTS_V1._0._2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b66915af3cafc30589c921828f03bcfd966f7d8c", @"/Views/GasComponent/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"362b6289f9f5e0883672fbeb153cee6311a1f560", @"/Views/_ViewImports.cshtml")]
    public class Views_GasComponent_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WNTS_V1._0._2.Models.PL_GAS_COMPONENT>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b66915af3cafc30589c921828f03bcfd966f7d8c3691", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ASSET_ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DATE_STAMP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.C1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.C2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.C3));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IC4));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NC4));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IC5));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NC5));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.C6));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 46 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.C7));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 49 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.C8));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 52 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.C9));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 55 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.N2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 58 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CO2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 61 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.H2O));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 64 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.HCDP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 67 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CALC_HCDP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 70 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.GHV));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 76 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 79 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ASSET_ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 82 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DATE_STAMP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 85 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.C1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 88 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.C2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 91 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.C3));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 94 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IC4));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 97 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NC4));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 100 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IC5));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 103 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NC5));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 106 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.C6));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 109 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.C7));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 112 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.C8));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 115 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.C9));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 118 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.N2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 121 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CO2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 124 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.H2O));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 127 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.HCDP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 130 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CALC_HCDP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 133 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.GHV));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 136 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 137 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 138 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 141 "D:\Work\MEDCO\Web App\WNTS_V1.0.2\WNTS_V1.0.2\Views\GasComponent\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WNTS_V1._0._2.Models.PL_GAS_COMPONENT>> Html { get; private set; }
    }
}
#pragma warning restore 1591