using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace RKPP.Common
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString DisplayWithBreaksFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var model = html.Encode(metadata.Model).Replace("\r\n", "<br />\r\n");

            if (String.IsNullOrEmpty(model))
                return MvcHtmlString.Empty;

            return MvcHtmlString.Create(model);
        }

        public static MvcHtmlString DisplayWithBreaksAndSpacesFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var model = html.Encode(metadata.Model).Replace("\r\n", "<br/>\r\n");

            var sb = new StringBuilder();
            var lines = model.Split('\n');
            var position = 0;

            sb.Append("<table>");

            foreach (var line in lines)
            {
                position = line.IndexOf(' ', line.IndexOf(' ') + 1);

                sb.AppendLine("<tr><td style=\"font-weight:bold;font-style:italic;\"> " + line.Substring(0, position).Trim() + "</td><td>" + line.Substring(position + 1).Trim() + "</td></tr>");
            }

            sb.Append("</table>");

            if (String.IsNullOrEmpty(model))
                return MvcHtmlString.Empty;

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}