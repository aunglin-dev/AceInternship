using AceInternship.RestApi.Model;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AceInternship.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Blog : ControllerBase
    {

        private readonly SqlConnectionStringBuilder _stringBuilder = new SqlConnectionStringBuilder()
        {
            InitialCatalog = "InternDB",
            UserID = "sa",
            Password = "123456",
            DataSource = "LAPTOP-P3IDALMC",

        }; 
        [HttpGet]
        public IActionResult GetBlogs()
        {
            using IDbConnection db = new SqlConnection(_stringBuilder.ConnectionString);
           List<BlogModel> lst = db.Query<BlogModel>(Queries.SelectAll).ToList();
            return Ok(lst);

        }

        [HttpGet("{id}")]
        public IActionResult GetSpecificBlogs(int id)
        {
            using IDbConnection db = new SqlConnection(_stringBuilder.ConnectionString);
            var item= db.Query<BlogModel>(Queries.SelectBlogByID, new {BlogId = id}).FirstOrDefault();
            if(item == null) 
                 return NotFound("Failed to Retrieve Specific Data");
            return Ok(item);

        }

        [HttpPost]

        public IActionResult CreateBlogs(BlogModel blog)
        {
            using IDbConnection db = new SqlConnection(_stringBuilder.ConnectionString);
            int results = db.Execute(Queries.BlogCreate, blog);
            string messages = results > 0 ? "Successfully Data Saved" : "Failed To Saved Data";
            return Ok(messages);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlogs(BlogModel blog, int id)
        {
            blog .BlogId = id;  
            using IDbConnection db = new SqlConnection(_stringBuilder.ConnectionString);
            int results = db.Execute(Queries.BlogUpdate, blog);
            string message= results > 0 ? "Successfully Data Updated" : "Failed To Updated Data";
            return Ok(message);
        }
        [HttpPatch]
        public IActionResult PatchBlogs()
        {
            return Ok("PatchBlogs");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBlogs(int id)
        {
            using IDbConnection db =new SqlConnection(_stringBuilder.ConnectionString);
            int result= db.Execute(Queries.BlogDelete, new { BlogId = id });
            string message = result > 0 ? "Successfully Data Deleted" : "Failed To Deleted Data";
            return Ok(message);
        }
    }

    public static class Queries
    {
        public static string SelectAll { get; } = "Select * from tbl_Blog";

        public static string SelectBlogByID{ get; } = "Select * from tbl_Blog where BlogId = @BlogId";


        public static string BlogCreate { get; } = @"INSERT INTO [dbo].[tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

        public static string BlogUpdate { get; } = @"UPDATE [dbo].[tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

        public static string BlogDelete { get; } = "Delete from tbl_Blog where BlogId = @BlogId";
    }
}
