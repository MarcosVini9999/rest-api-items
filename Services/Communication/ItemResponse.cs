using rest_api_items.Domain.Models;

namespace rest_api_items.Services.Communication
{
    public class ItemResponse : BaseResponse
    {
        public Item Item { get; private set; }

        private ItemResponse(bool success, string message, Item item) : base(success, message)
        {
            Item = item;
        }

        public ItemResponse(Item item) : this(true, string.Empty, item)
        { }

        public ItemResponse(string message) : this(false, message, null)
        { }
    }
}