#pragma checksum "C:\Users\AlumnoMCSD\source\Github\SolucionesMVC\ProyectoCore\ProyectoCore\Views\Coches\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86aaba9c79210071312b6d0df6b1870349899b0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Coches_Index), @"mvc.1.0.view", @"/Views/Coches/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Coches/Index.cshtml", typeof(AspNetCore.Views_Coches_Index))]
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
#line 1 "C:\Users\AlumnoMCSD\source\Github\SolucionesMVC\ProyectoCore\ProyectoCore\Views\_ViewImports.cshtml"
using ProyectoCore;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86aaba9c79210071312b6d0df6b1870349899b0c", @"/Views/Coches/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"034cd372d327d8ddc2517e529fb6050dc8d1b036", @"/Views/_ViewImports.cshtml")]
    public class Views_Coches_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProyectoCore.Models.ICoche>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 500px; height:250px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\AlumnoMCSD\source\Github\SolucionesMVC\ProyectoCore\ProyectoCore\Views\Coches\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(78, 33, true);
            WriteLiteral("\r\n<h3 style=\"color:blue\"> Marca: ");
            EndContext();
            BeginContext(112, 11, false);
#line 7 "C:\Users\AlumnoMCSD\source\Github\SolucionesMVC\ProyectoCore\ProyectoCore\Views\Coches\Index.cshtml"
                          Write(Model.Marca);

#line default
#line hidden
            EndContext();
            BeginContext(123, 11, true);
            WriteLiteral(" . Modelo: ");
            EndContext();
            BeginContext(135, 12, false);
#line 7 "C:\Users\AlumnoMCSD\source\Github\SolucionesMVC\ProyectoCore\ProyectoCore\Views\Coches\Index.cshtml"
                                                 Write(Model.Modelo);

#line default
#line hidden
            EndContext();
            BeginContext(147, 9, true);
            WriteLiteral("</h3>\r\n\r\n");
            EndContext();
            BeginContext(156, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b89eb43217294f33b7a08744054cdbaf", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 166, "~/images/", 166, 9, true);
#line 9 "C:\Users\AlumnoMCSD\source\Github\SolucionesMVC\ProyectoCore\ProyectoCore\Views\Coches\Index.cshtml"
AddHtmlAttributeValue("", 175, Model.Imagen, 175, 13, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(227, 25, true);
            WriteLiteral("\r\n\r\n<p>Velodicad actual: ");
            EndContext();
            BeginContext(253, 21, false);
#line 11 "C:\Users\AlumnoMCSD\source\Github\SolucionesMVC\ProyectoCore\ProyectoCore\Views\Coches\Index.cshtml"
                Write(Model.VelocidadActual);

#line default
#line hidden
            EndContext();
            BeginContext(274, 27, true);
            WriteLiteral("</p>\r\n<p>Velocidad Maxima: ");
            EndContext();
            BeginContext(302, 21, false);
#line 12 "C:\Users\AlumnoMCSD\source\Github\SolucionesMVC\ProyectoCore\ProyectoCore\Views\Coches\Index.cshtml"
                Write(Model.VelocidadMaxima);

#line default
#line hidden
            EndContext();
            BeginContext(323, 8, true);
            WriteLiteral("</p>\r\n\r\n");
            EndContext();
#line 14 "C:\Users\AlumnoMCSD\source\Github\SolucionesMVC\ProyectoCore\ProyectoCore\Views\Coches\Index.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(361, 227, true);
            WriteLiteral("    <div>\r\n        <button type=\"submit\" class=\"btn btn-success\" name=\"accion\" value=\"acelerar\">Acelerar</button>\r\n        <button type=\"submit\" class=\"btn btn-success\" name=\"accion\" value=\"frenar\">Frenar</button>\r\n    </div>\r\n");
            EndContext();
#line 20 "C:\Users\AlumnoMCSD\source\Github\SolucionesMVC\ProyectoCore\ProyectoCore\Views\Coches\Index.cshtml"
}

#line default
#line hidden
            BeginContext(591, 7, true);
            WriteLiteral("    <p>");
            EndContext();
            BeginContext(599, 19, false);
#line 21 "C:\Users\AlumnoMCSD\source\Github\SolucionesMVC\ProyectoCore\ProyectoCore\Views\Coches\Index.cshtml"
  Write(ViewData["MENSAJE"]);

#line default
#line hidden
            EndContext();
            BeginContext(618, 4, true);
            WriteLiteral("</p>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProyectoCore.Models.ICoche> Html { get; private set; }
    }
}
#pragma warning restore 1591
