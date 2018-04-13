namespace ONIT.VismaNetApi.Models.CustomDto
{
    public class WarehouseDetails
    {
        public bool isDefault { get; set; }
        public string warehouse { get; set; }
        public decimal quantityOnHand { get; set; }
        public decimal available { get; set; }
        public decimal availableForShipment { get; set; }
    }
}
