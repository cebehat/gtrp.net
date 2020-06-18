using System.Collections.Generic;

namespace GTRP.NET.Shared.Models
{
    public class GTRPPhone
    {
        public PhoneType GetPhoneType { get; }
        public int PhoneNumber { get; set; }
        private int _secondPhoneNumber;
        public int? SecondaryPhoneNumber { get { return IsDualSim ? _secondPhoneNumber : new int?  } set { _secondPhoneNumber = value.HasValue ? value.Value : 0 } }
        public List<GTRPPhoneContact> Contacts { get; }
        public bool IsDualSim { get; set; }

        public enum PhoneType
        {
            IPhone,
            Samsung,
            Huawei
        }

        public class GTRPPhoneContact
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Phonenumber { get; set; }
        }
    }
}