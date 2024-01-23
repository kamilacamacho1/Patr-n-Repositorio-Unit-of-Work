using EFCoreRepositoryUnitofWork.Common;

namespace EFCoreRepositoryUnitofWork.Entities;

public class Post : Entity
{
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    
}
