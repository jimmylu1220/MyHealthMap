namespace MyHealthMap.Model
{
    public class Restaurant : BaseRestaurantDto
    {
        public int Id { get; set; }

        // 設定為 virtual，以支援lazy loading
        public virtual IList<Menu> Menus { get; set; }
    }
}
