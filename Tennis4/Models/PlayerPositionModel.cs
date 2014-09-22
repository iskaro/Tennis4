﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Tennis4.Models
{
    public class PlayerPositionModel
    {
        public int CompetitionEnrollmentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompetitionName { get; set; }
        public int RowNumber { get; set; }
    }

    public class ModelCast
    {
        public IEnumerable<PlayerPositionModel> PlayerPositions { get; set; }
    }

    public class PlayerIdLastNameFirstName
    {
        public int ID { get; set; }
        public string LastNameFirstName { get; set; }
    }
}