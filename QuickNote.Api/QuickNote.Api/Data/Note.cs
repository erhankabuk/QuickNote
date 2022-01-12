using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickNote.Api.Data
{
    public class Note
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        public string Content{ get; set; }
        public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset ModifiedTime { get; set; } = DateTimeOffset.Now;
        
        public int NotebookId { get; set; }
        public Notebook Notebook { get; set; }

    }
}
