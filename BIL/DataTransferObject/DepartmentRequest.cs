using System.ComponentModel.DataAnnotations;

namespace Demo.BLL.DataTransferObjects;
public class DepartmentRequest
{
    [Required(ErrorMessage ="name is required") ]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "code is required")]
    public string Code { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
