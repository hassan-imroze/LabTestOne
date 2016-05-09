﻿using Model;
using System;

namespace ViewModel
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {

        }
        public BaseViewModel(Entity x)
        {
            Id = x.Id;
            Created = x.Created;
            CreatedBy = x.CreatedBy;
            Modified = x.Modified;
            ModifiedBy = x.ModifiedBy;
        }

        public string Id { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; }
    }
}