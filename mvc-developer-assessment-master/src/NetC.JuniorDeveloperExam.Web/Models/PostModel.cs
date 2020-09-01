using System;
using System.Collections.Generic;
using System.Linq;
using NetC.JuniorDeveloperExam.Web.BlogView;
namespace NetC.JuniorDeveloperExam.Web.Models
{
    public class PostModel
    {
        public int? Id { get; set; }
        public DateTime Date { get;}
        public string Title { get; }
        public Uri Image { get; }
        public string HtmlContent { get; }
        public List<CommentModel> CommentsModel { get; set; }
        public CommentModel NewComment { get; set; } = new CommentModel();
        public int SelectedCommentId { get; set; }

        public PostModel()
        {

        }
        public PostModel(int id)
        {
            Blog root = JsonFileParser.LoadBlogsPosts();
            List<Post> blogPosts = root.BlogPosts;
            var blogPost = blogPosts.FirstOrDefault(x => x.Id == id);

            if (blogPost == null)
                throw new ArgumentNullException("Blog Should Be Valid Integer");

            Id = blogPost.Id;
            Date = blogPost.Date;
            Title = blogPost.Title;
            Image = blogPost.Image;
            HtmlContent = blogPost.HtmlContent;

            if (blogPost.Comments != null)
            {
                SetCommentsModel(blogPost.Comments);
            }
            else
            {
                CommentsModel = new List<CommentModel>();
            }
        }

        private void SetCommentsModel(List<Comment> comments)
        {
            var commentsModel = new List<CommentModel>();
            foreach (var t in comments)
            {
                var commentModel = new CommentModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Date = t.Date,
                    EmailAddress = t.EmailAddress,
                    Message = t.Message
                };
                if (t.Replies != null)
                {
                    commentModel.SetReplies(t.Replies);
                }
                else
                {
                    commentModel.Replies = new List<CommentModel>();
                }
                commentModel.SetAvatar();
                commentsModel?.Add(commentModel);
            }

            CommentsModel = commentsModel;
        }

        public void AddComment()
        {
            Blog root = JsonFileParser.LoadBlogsPosts();
            Comment comment = new Comment
            {
                Name = NewComment.Name,
                Date = DateTime.Now,
                EmailAddress = NewComment.EmailAddress,
                Message = NewComment.Message
            };
            Post blogPost = root.BlogPosts.FirstOrDefault(x => x.Id == this.Id);
            comment.Id = blogPost?.Comments?.Count + 1 ?? 1;
            blogPost?.AddComment(comment);
            JsonFileParser.SaveToJson(root);
        }

        public void AddReply(int commentId)
        {
            Reply reply = new Reply
            {
                Name = NewComment.Name,
                Date = DateTime.Now,
                EmailAddress = NewComment.EmailAddress,
                Message = NewComment.Message
            };

            Blog root = JsonFileParser.LoadBlogsPosts();
            Post blogPost = root.BlogPosts.FirstOrDefault(x => x.Id == this.Id);
            if (blogPost != null)
            {
                Comment comment = blogPost.Comments.FirstOrDefault(x => x.Id == commentId);

                comment?.AddReply(reply);
            }
            JsonFileParser.SaveToJson(root);
        }
    }
}