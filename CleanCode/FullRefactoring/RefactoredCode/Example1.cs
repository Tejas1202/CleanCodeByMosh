﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;

namespace CleanCode.FullRefactoring.RefactoredCode
{
    public class PostControl : System.Web.UI.UserControl
    {
        private readonly PostRepository _postRepository;
        private readonly PostValidator _validator;
        private Label PostBody { get; set; }
        private Label PostTitle { get; set; }
        private int? PostId { get; set; }

        // Hence always use private fields and initialize them in the ctor as oppose to creating and initializing objects inside methods
        // This way, we can easily replace them with an interface for unit testing
        public PostControl()
        {
            _postRepository = new PostRepository();
            _validator = new PostValidator();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                TrySavePost();
            else
                DisplayPost();
        }

        // Note that TrySavePost is not doing too many things here and it's adhering to Cohesion principle
        // as it is delegating the tasks to other methods, so is the case with Page_Load method
        private void TrySavePost()
        {
            var post = GetPost();
            var results = _validator.Validate(post);

            if (results.IsValid)
                _postRepository.SavePost(post);
            else
                DisplayErrors(results);
        }

        private void DisplayErrors(ValidationResult results)
        {
            var summary = GetErrorSummaryControl();

            // Display errors to the user
            foreach (var error in results.Errors)
            {
                var label = GetErrorLabel(error);

                if (label == null)
                    summary.Items.Add(new ListItem(error.ErrorMessage));
                else
                    label.Text = error.ErrorMessage;
            }
        }

        private BulletedList GetErrorSummaryControl()
        {
            return (BulletedList)FindControl("ErrorSummary");
        }

        private Label GetErrorLabel(ValidationError error)
        {
            return FindControl(error.PropertyName + "Error") as Label;
        }

        private void DisplayPost()
        {
            var postId = Convert.ToInt32(Request.QueryString["id"]);
            var post = _postRepository.GetPost(postId);
            PostBody.Text = post.Body;
            PostTitle.Text = post.Title;
        }

        private Post GetPost()
        {
            return new Post()
            {
                Id = Convert.ToInt32(PostId.Value),
                Title = PostTitle.Text.Trim(),
                Body = PostBody.Text.Trim()
            };
        }
    }

    #region Supporting Code

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
    }

    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class PostValidator
    {
        public ValidationResult Validate(Post entity)
        {
            throw new NotImplementedException();
        }
    }

    public class DbSet<T> : IQueryable<T>
    {
        public void Add(T entity)
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression
        {
            get { throw new NotImplementedException(); }
        }

        public Type ElementType
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryProvider Provider
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class PostDbContext
    {
        public DbSet<Post> Posts { get; set; }

        public void SaveChanges()
        {
        }
    }
    #endregion

}