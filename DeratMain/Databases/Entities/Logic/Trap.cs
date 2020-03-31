﻿using DeratMain.Models.Project;
using System;

namespace DeratMain.Databases.Entities.Logic
{
    public class Trap : BaseEntity
    {

        public Trap(TrapCreateModel trapCreateModel, string name) : base()
        {
            Type = trapCreateModel.Type;
            Comment = trapCreateModel.Comment;
            Place = trapCreateModel.Place;
            CreatedBy = name;
            LastReviewTime = CreatedAt;
            NextReviewTime = LastReviewTime.AddDays(trapCreateModel.ReviewEveryDays);
            EndTime = CreatedAt.AddDays(trapCreateModel.LifeInDays);
        }

        public Trap() : base()
        {

        }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime LastReviewTime { get; set; }
        public DateTime NextReviewTime { get; set; }
        public string Comment { get; set; }
        public string Place { get; set; }
        public Perimeter Perimeter { get; set; }
        public User Employee { get; set; }
    }

    public class TrapTypes
    {
        public static string Mechanical = "mechanical";
        public static string Glue = "glue";
    }

    public class TrapStatus
    {
        public static string Ok = "ok";
        public static string Overdue = "overdue";
        public static string Closed = "closed";
    }
}