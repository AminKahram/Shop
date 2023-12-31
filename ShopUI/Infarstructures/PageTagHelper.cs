﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ShopUI.Infarstructures;

[HtmlTargetElement("div", Attributes = "page-model")]
public class PageTagHelper:TagHelper
{
    private readonly IUrlHelperFactory urlHelperFactory;
    public PageTagHelper(IUrlHelperFactory helperFactory)
    {
        this.urlHelperFactory = helperFactory;
    }

    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext ViewContext { get; set; }
    public PageInfo PageModel { get; set; }
    public string PageAction { get; set; }
    public bool PageClassEnabled { get; set; }
    public string PageClass { get; set; }
    public string PageClassNormal { get; set; }
    public string PageClassSelected { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
        TagBuilder result = new("div");
        for (int i = 1; i<= PageModel.PageCount; i++)
        {
            TagBuilder tag = new("a");
            tag.Attributes["href"] = urlHelper.Action(PageAction, new { PageNumber = i });
            if (PageClassEnabled)
            {
                tag.AddCssClass(PageClass);
                tag.AddCssClass(i == PageModel.PageNumber ? PageClassSelected : PageClassNormal);
            }
            tag.InnerHtml.Append(i.ToString());
            result.InnerHtml.AppendHtml(tag);
        }
        output.Content.AppendHtml(result.InnerHtml);
        //base.Process(context, output);
    }
}
