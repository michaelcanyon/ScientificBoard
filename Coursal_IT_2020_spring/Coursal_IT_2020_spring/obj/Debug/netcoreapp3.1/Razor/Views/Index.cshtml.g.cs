#pragma checksum "C:\Users\hrani\OneDrive\Документы\GitHub\projectsbin\Coursal_IT_2020_spring\Coursal_IT_2020_spring\Views\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1432134702d33a51f4099761eaf58cdc52fe1640"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Index), @"mvc.1.0.view", @"/Views/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1432134702d33a51f4099761eaf58cdc52fe1640", @"/Views/Index.cshtml")]
    public class Views_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Coursal_IT_2020_spring.Models.IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\hrani\OneDrive\Документы\GitHub\projectsbin\Coursal_IT_2020_spring\Coursal_IT_2020_spring\Views\Index.cshtml"
  
    ViewData["Title"] = "Посты";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 7 "C:\Users\hrani\OneDrive\Документы\GitHub\projectsbin\Coursal_IT_2020_spring\Coursal_IT_2020_spring\Views\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
<form method=""get"">
    <div class=""form-group"">
        <input type=""submit"" value=""Поиск"" class=""btn btn-outline-secondary"" />
    </div>
</form>

<p>
    <a asp-controller=""Home"" asp-action=""Create"">Добавить</a>
</p>
<table class=""table"">
    <tr>
        <th>ID</th>
        <th>Заголовок</th>
        <th>Автор</th>
        <th>Текст</th>
        <th></th>
    </tr>

");
#nullable restore
#line 26 "C:\Users\hrani\OneDrive\Документы\GitHub\projectsbin\Coursal_IT_2020_spring\Coursal_IT_2020_spring\Views\Index.cshtml"
     foreach (var item in Model.Posts)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 29 "C:\Users\hrani\OneDrive\Документы\GitHub\projectsbin\Coursal_IT_2020_spring\Coursal_IT_2020_spring\Views\Index.cshtml"
           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 30 "C:\Users\hrani\OneDrive\Документы\GitHub\projectsbin\Coursal_IT_2020_spring\Coursal_IT_2020_spring\Views\Index.cshtml"
           Write(item.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 31 "C:\Users\hrani\OneDrive\Документы\GitHub\projectsbin\Coursal_IT_2020_spring\Coursal_IT_2020_spring\Views\Index.cshtml"
           Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                ");
#nullable restore
#line 33 "C:\Users\hrani\OneDrive\Документы\GitHub\projectsbin\Coursal_IT_2020_spring\Coursal_IT_2020_spring\Views\Index.cshtml"
           Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-controller=\"Home\" asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 820, "\"", 843, 1);
#nullable restore
#line 36 "C:\Users\hrani\OneDrive\Документы\GitHub\projectsbin\Coursal_IT_2020_spring\Coursal_IT_2020_spring\Views\Index.cshtml"
WriteAttributeValue("", 835, item.Id, 835, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Изменить</a> |\r\n                <a asp-controller=\"Home\" asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 921, "\"", 944, 1);
#nullable restore
#line 37 "C:\Users\hrani\OneDrive\Документы\GitHub\projectsbin\Coursal_IT_2020_spring\Coursal_IT_2020_spring\Views\Index.cshtml"
WriteAttributeValue("", 936, item.Id, 936, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Удалить</a> |\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 40 "C:\Users\hrani\OneDrive\Документы\GitHub\projectsbin\Coursal_IT_2020_spring\Coursal_IT_2020_spring\Views\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Coursal_IT_2020_spring.Models.IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591