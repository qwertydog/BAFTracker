using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BAFTracker.Models;

namespace BAFTracker.Migrations
{
    [DbContext(typeof(BAFTrackerContext))]
    [Migration("20170531101746_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("BAFTracker.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<int?>("IssueId");

                    b.Property<string>("Text");

                    b.Property<int?>("UserId");

                    b.HasKey("CommentId");

                    b.HasIndex("IssueId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BAFTracker.Models.Issue", b =>
                {
                    b.Property<int>("IssueId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<int>("Downvotes");

                    b.Property<int?>("IssueTypeId");

                    b.Property<string>("Title");

                    b.Property<int>("Upvotes");

                    b.Property<int?>("UserId");

                    b.Property<int?>("UserId1");

                    b.Property<int>("Views");

                    b.HasKey("IssueId");

                    b.HasIndex("IssueTypeId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("BAFTracker.Models.IssueTag", b =>
                {
                    b.Property<int>("IssueTagId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("IssueId");

                    b.Property<int?>("TagId");

                    b.HasKey("IssueTagId");

                    b.HasIndex("IssueId");

                    b.HasIndex("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BAFTracker.Models.IssueType", b =>
                {
                    b.Property<int>("IssueTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("IssueTypeId");

                    b.ToTable("IssueTypes");
                });

            modelBuilder.Entity("BAFTracker.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("TagId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("BAFTracker.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Initials");

                    b.Property<string>("Name");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BAFTracker.Models.Comment", b =>
                {
                    b.HasOne("BAFTracker.Models.Issue", "Issue")
                        .WithMany("Comments")
                        .HasForeignKey("IssueId");

                    b.HasOne("BAFTracker.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BAFTracker.Models.Issue", b =>
                {
                    b.HasOne("BAFTracker.Models.IssueType", "IssueType")
                        .WithMany("Issues")
                        .HasForeignKey("IssueTypeId");

                    b.HasOne("BAFTracker.Models.User")
                        .WithMany("DownvotedIssues")
                        .HasForeignKey("UserId");

                    b.HasOne("BAFTracker.Models.User")
                        .WithMany("UpvotedIssues")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("BAFTracker.Models.IssueTag", b =>
                {
                    b.HasOne("BAFTracker.Models.Issue", "Issue")
                        .WithMany("Tags")
                        .HasForeignKey("IssueId");

                    b.HasOne("BAFTracker.Models.Tag", "Tag")
                        .WithMany("IssueTags")
                        .HasForeignKey("TagId");
                });
        }
    }
}
