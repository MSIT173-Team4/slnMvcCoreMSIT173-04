using prjMvcCore第四組.Models;

namespace prjMvcCore第四組.ViewModels
{
    public class PostViewModel
{
    public TPostTable Post { get; set; } = null!;
    public List<MessageViewModel> Messages { get; set; } = new();
}
}
