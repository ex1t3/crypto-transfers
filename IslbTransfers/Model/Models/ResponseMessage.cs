using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public class ResponseMessage
    {
        public string Message { get; set; }
        public int Duration { get; set; }
        public List<ModelErrorCollection> Errors { get; set; }
        public ResponseTypes Type { get; set; }
        public enum ResponseTypes
        {
            success, error, info
        }
    }
}
