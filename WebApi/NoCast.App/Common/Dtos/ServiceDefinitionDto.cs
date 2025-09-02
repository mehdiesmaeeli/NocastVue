
using System;
using System.ComponentModel.DataAnnotations;

namespace NoCast.App.Dtos
{
    public class ServiceDefinitionDto
    {
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Type")]
        public int Type { get; set; }
    }
}