using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AceInternship.RestApi.Model
{

    [Table("tbl_Blog")]
    public class BlogModel
    {
        public int BlogId { get; set; }
        public String BlogTitle { get; set; }
        public String BlogAuthor { get; set; }
        public String BlogContent { get; set; }

    }
}