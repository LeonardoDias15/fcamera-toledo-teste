#pragma checksum "C:\Users\acaciano\Desktop\FCamara_Test\FCamara-Test\FCamara-Test\Views\Aniversariante\ListagemAniversariantes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef2048ec9b5e293288b36f83de3f8610dd6708c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Aniversariante_ListagemAniversariantes), @"mvc.1.0.view", @"/Views/Aniversariante/ListagemAniversariantes.cshtml")]
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
#line 1 "C:\Users\acaciano\Desktop\FCamara_Test\FCamara-Test\FCamara-Test\Views\_ViewImports.cshtml"
using FCamara_Test;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\acaciano\Desktop\FCamara_Test\FCamara-Test\FCamara-Test\Views\_ViewImports.cshtml"
using FCamara_Test.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef2048ec9b5e293288b36f83de3f8610dd6708c7", @"/Views/Aniversariante/ListagemAniversariantes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cd013a578e15e4412788ffab073341b1f803f04", @"/Views/_ViewImports.cshtml")]
    public class Views_Aniversariante_ListagemAniversariantes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<FCamara_Test.Dtos.AniversarianteDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<table class=\"rTable\">\r\n    <thead>\r\n        <tr>\r\n            <th>Nome</th>\r\n            <th>CPF</th>\r\n            <th>Data aniversário</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 12 "C:\Users\acaciano\Desktop\FCamara_Test\FCamara-Test\FCamara-Test\Views\Aniversariante\ListagemAniversariantes.cshtml"
         if (Model != null && Model.Any())
        {
            foreach (FCamara_Test.Dtos.AniversarianteDTO aniversariante in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 17 "C:\Users\acaciano\Desktop\FCamara_Test\FCamara-Test\FCamara-Test\Views\Aniversariante\ListagemAniversariantes.cshtml"
                   Write(aniversariante.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 18 "C:\Users\acaciano\Desktop\FCamara_Test\FCamara-Test\FCamara-Test\Views\Aniversariante\ListagemAniversariantes.cshtml"
                   Write(aniversariante.Cpf);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 19 "C:\Users\acaciano\Desktop\FCamara_Test\FCamara-Test\FCamara-Test\Views\Aniversariante\ListagemAniversariantes.cshtml"
                   Write(aniversariante.DataNascimento.ToString("g"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 21 "C:\Users\acaciano\Desktop\FCamara_Test\FCamara-Test\FCamara-Test\Views\Aniversariante\ListagemAniversariantes.cshtml"

            }
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr><td colspan=\"3\">Nenhum registro  encontrado</td></tr>\r\n");
#nullable restore
#line 27 "C:\Users\acaciano\Desktop\FCamara_Test\FCamara-Test\FCamara-Test\Views\Aniversariante\ListagemAniversariantes.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<FCamara_Test.Dtos.AniversarianteDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591
