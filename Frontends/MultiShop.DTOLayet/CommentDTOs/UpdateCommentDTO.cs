﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.CommentDTOs
{
    public class UpdateCommentDTO
    {
        public int UserCommentID { get; set; }
        public string NameSurname { get; set; }
        public string? ImageURL { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

        public string ProductID { get; set; }
    }
}
