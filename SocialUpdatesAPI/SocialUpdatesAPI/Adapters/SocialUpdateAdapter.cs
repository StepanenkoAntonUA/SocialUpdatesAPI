using SocialUpdateModule.Models;
using SocialUpdatesAPI.DTO;

namespace SocialUpdatesAPI.Adapters
{
    public static class SocialUpdateAdapter
    {
        public static SocialUpdateDTO ToDTO(SocialUpdateItem postItem) =>
           new SocialUpdateDTO
           {
               Id = postItem.Id,
               Description = postItem.Description
           };
    }
}
