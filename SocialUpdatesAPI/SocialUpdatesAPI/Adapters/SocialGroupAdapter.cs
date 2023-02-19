using Models;
using SocialUpdatesAPI.DTO;


namespace SocialUpdatesAPI.Adapters
{
    public class SocialGroupAdapter
    {
        public static SocialGroupItemDTO ToDTO(SocialGroupItem item) =>
           new SocialGroupItemDTO
           {
               Id = item.Id,
               Group = item.Group
           };

        public static SocialGroupItem FromDTO(SocialGroupItemDTO dto) =>
   new SocialGroupItem
   {
       Id = dto.Id,
       Group = dto.Group
   };
    }
}
