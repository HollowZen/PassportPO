
namespace PassportPO.Model
{
    public partial class PassportList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public int Kod { get; set; }
        public string Kem { get; set; }
        public string Citizenship { get; set; }
        
        public PassportList(string name, string surname, string secondName, int kod, string kem, string citizenship)
        {
            Name = name;
            Surname = surname;
            SecondName = secondName;
            Kod = kod;
            Kem = kem;
            Citizenship = citizenship;
        }
    }
}
