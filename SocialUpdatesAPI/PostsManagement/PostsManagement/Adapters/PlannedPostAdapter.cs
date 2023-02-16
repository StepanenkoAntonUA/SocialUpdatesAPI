using PostsManagement.DTO;
using SocialUpdateModule.Models;

namespace PostsManagement.Adapters
{
    public class PlannedPostAdapter
    {
        public static PlannedPostDTO ToDTO(PlannedPost plannedPostItem) =>
          new PlannedPostDTO
          {
              Id = plannedPostItem.Id,
              Post = plannedPostItem.Post
          };

        public static PlannedPost FromDTO(PlannedPostDTO plannedPostItemDTO) =>
  new PlannedPost
  {
      Id = plannedPostItemDTO.Id,
      Post = plannedPostItemDTO.Post
  };
    }
}
