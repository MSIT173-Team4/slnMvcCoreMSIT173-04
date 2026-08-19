using prjMvcCore第四組.Models;

namespace prjMvcCore第四組.ViewModels
{
    public class MessageViewModel
{
    public TMessageTable Message { get; set; } = null!;
    public string? ReplyToUsername { get; set; }
}
}
