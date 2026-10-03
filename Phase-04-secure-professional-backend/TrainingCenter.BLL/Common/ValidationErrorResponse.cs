using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.BLL.Common
{
    public class ValidationErrorResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; } = null!;

        public int StatusCode { get; set; }

        public Dictionary<string, string[]> Errors { get; set; } = new();
    }
}
