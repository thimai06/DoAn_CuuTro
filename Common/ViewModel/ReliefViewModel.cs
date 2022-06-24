using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Common.ViewModel
{
    public class ReliefViewModel
    {
        [Required]
        public string DistrictId { get; set; }
        [Required]
        public string WardId { get; set; }
        [Required]
        public string Thon { get; set; }
        [Required]
        public string RCId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string FilePath { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}
