
namespace PassportPO.Model
{
    public partial class VizeList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string SecondName { get; set; }
        public string CitizenShip { get; set; }
        public bool? Status { get; set; }

        public VizeList()
        {
            
        }
        public VizeList(string name, string surName, string secondName, string citizenShip, bool? status)
        {
            Name = name;
            SurName = surName;
            SecondName = secondName;
            CitizenShip = citizenShip;
            Status = status;
        }
    }
}
