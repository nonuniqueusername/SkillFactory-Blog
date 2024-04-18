using BlogApp.BLL.ViewModels.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogApp.BLL.ViewModels.Posts
{
    public class PostEditViewModel
    {
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Заголовок", Prompt = "Заголовок")]
        public string? Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string? Content { get; set; }

        [Display(Name = "Теги", Prompt = "Теги")]
        public List<TagViewModel>? Tags { get; set; }
    }
}
