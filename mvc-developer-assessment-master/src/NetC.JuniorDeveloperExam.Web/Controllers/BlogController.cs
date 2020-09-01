using System.Web.Mvc;
using NetC.JuniorDeveloperExam.Web.Models;
namespace NetC.JuniorDeveloperExam.Web.Controllers
{
    public class BlogController : Controller
    {
        public BlogController()
        {

        }
        public ActionResult Index()
        {
            return View(new PostModel(1));
        }

        public ActionResult BlogView(int id)
        {
            var blogPost = new PostModel(id);
            return View(blogPost);
        }

        [HttpPost]
        public ActionResult AddComment(PostModel blogPost)
        {
            blogPost.AddComment();
            return RedirectToAction("BlogView", "Blog", new { id = blogPost.Id });
        }

        [HttpPost]
        public ActionResult AddReply(PostModel blogPost)
        {
            blogPost.AddReply(blogPost.SelectedCommentId);
            return RedirectToAction("BlogView", "Blog", new { id = blogPost.Id });
        }
    }
}