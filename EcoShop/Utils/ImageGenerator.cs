using System;
using System.Text;

namespace EcoShop.Utils
{
    public static class ImageGenerator
    {
        /// <summary>
        /// Генерирует SVG-заглушку в формате Data URI, используя Base64.
        /// </summary>
        public static string GenerateSvgPlaceholder(string text, string bgColor, string textColor = "#ffffff")
        {
            var svg = $@"
                <svg width='600' height='400' xmlns='http://www.w3.org/2000/svg'>
                    <rect width='100%' height='100%' fill='{bgColor}'/>
                    <text x='50%' y='50%' font-family='Montserrat, sans-serif' font-size='60' fill='{textColor}' text-anchor='middle' dominant-baseline='middle' font-weight='bold'>
                        {text}
                    </text>
                </svg>";

            var svgBytes = Encoding.UTF8.GetBytes(svg);
            var base64String = Convert.ToBase64String(svgBytes);
            
            return $"data:image/svg+xml;base64,{base64String}";
        }
    }
}