using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace NetC.JuniorDeveloperExam.Web.BlogView
{
    public class Blog
    {
        [JsonProperty("blogPosts")]
        public List<Post> BlogPosts { get; set; }
    }
    public class Post
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("htmlContent")]
        public string HtmlContent { get; set; }

        [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
        public List<Comment> Comments { get; set; }

        public void AddComment(Comment comment)
        {
            if (Comments != null)
            {
                Comments.Add(comment);
            }
            else
            {
                Comments = new List<Comment>
                {
                    comment
                };
            }
        }
    }
    public class Comment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("replies")]
        public List<Reply> Replies { get; set; }

        public void AddReply(Reply reply)
        {
            if (Replies != null)
            {
                Replies.Add(reply);
            }
            else
            {
                Replies = new List<Reply>
                {
                    reply
                };
            }
        }
    }
    public class Reply
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
    public static class JsonFileParser
    {
        public static void SaveToJson(Blog root)
        {
            string path = HostingEnvironment.MapPath(@"~\App_Data\Blog-Posts.json");

            string convertedJson = JsonConvert.SerializeObject(root, Formatting.Indented);
            File.WriteAllText(path ?? string.Empty, convertedJson);
        }

        public static Blog LoadBlogsPosts()
        {
            var path = HostingEnvironment.MapPath(@"~\App_Data\Blog-Posts.json");

            using (StreamReader reader = File.OpenText(path ?? throw new InvalidOperationException()))
            {
                var jsonFromFile = reader.ReadToEnd();
                var root = JsonConvert.DeserializeObject<Blog>(jsonFromFile);

                return root;
            }
        }
    }
}
