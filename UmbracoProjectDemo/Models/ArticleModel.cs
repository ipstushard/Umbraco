using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;
namespace UmbracoProjectDemo.Models
{
    public class ArticleModel
    {
        [Required]
        public string Name { get; set; }
        public string Summery { get; set; }
        public IEnumerable<IFormFile> FeaturedImage { get; set; }

        [Required]
        public string ArticleContent { get; set; }

        [Required]
        public string AutherName { get; set; }
        public string AuthorTitle { get; set; }

    }
}
