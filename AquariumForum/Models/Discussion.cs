

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquariumForum.Models
{
    public class Discussion
    {
        public int DiscussionId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        // Store the filename of the uploaded image
        public string? ImagePath { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        // Navigation Property - One Discussion can have multiple Comments
        public List<Comment>? Comments { get; set; }

        // Computed property to count comments
        public int CommentCount => Comments?.Count ?? 0;
    }
}


