using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Microsoft.EntityFrameworkCore;

namespace BAFTracker.Models
{
    internal class BAFTrackerContext : DbContext
    {
        public DbSet<IssueTag> Tags { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=baftracker.db");
        }
    }

    internal class Issue
    {
        public int IssueId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public int Views { get; set; }

        public List<Comment> Comments { get; set; }
        public List<IssueTag> Tags { get; set; }
        public IssueType IssueType { get; set; }
    }

    internal class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        public List<IssueTag> IssueTags { get; set; }
    }

    internal class IssueTag
    {
        public int IssueTagId { get; set; }

        public Issue Issue { get; set; }
        public Tag Tag { get; set; }
    }

    internal class IssueType
    {
        public int IssueTypeId { get; set; }
        public string Name { get; set; }

        public List<Issue> Issues { get; set; }
    }

    internal class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Issue> UpvotedIssues { get; set; }
        public List<Issue> DownvotedIssues { get; set; }
    }

    internal class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public User User { get; set; }
        public Issue Issue { get; set; }
    }
}
