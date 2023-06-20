

namespace IT.Data.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted{get;set;}
        
    }
    

    
}
