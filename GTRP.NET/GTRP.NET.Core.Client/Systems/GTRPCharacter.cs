using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;


namespace GTRP.NET.Core.Client.Systems
{

    public interface ICharacterBuilder
    {
        IFirstNameBuilder WithFirstName(string firstname);
    }

    public interface IFirstNameBuilder
    {
        IMiddleNameBuilder WithMiddleName(string middlename);
        ILastNameBuilder WithOnlyLastName(string lastname);
    }

    public interface IMiddleNameBuilder
    {
        ILastNameBuilder WithLastName(string lastname);
    }

    public interface ILastNameBuilder
    {
        IAgeBuilder AtAge(int age);
    }

    public interface IAgeBuilder
    {
        IFinalBuilder WithGovernmentId(string govId);
    }

    public interface IFinalBuilder
    {
        GTRPCharacter Build(string firstname, string middlename, string lastname, int age, string govid, int walletamount);
    }

    public class GTRPCharacter : ICharacterBuilder, IFirstNameBuilder, IMiddleNameBuilder, ILastNameBuilder, IAgeBuilder, IFinalBuilder
    {
        //Identity properties
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string GovernmentId { get; private set; }
        public int WalletAmount { get; private set; }

        private GTRPCharacter(string firstname, string middlename, string lastname, int age, string govid, int walletamount)
        {
            FirstName = firstname;
            MiddleName = middlename;
            LastName = lastname;
            Age = age;
            GovernmentId = govid;
            WalletAmount = walletamount;
        }

        public GTRPCharacter Build(string firstname, string middlename, string lastname, int age, string govid, int walletamount)
        {
            return new GTRPCharacter(firstname, middlename, lastname, age, govid, walletamount);
        }

        public IFirstNameBuilder WithFirstName(string firstname)
        {
            FirstName = firstname;
            return this;
        }

        public IMiddleNameBuilder WithMiddleName(string middlename)
        {
            MiddleName = middlename;
            return this;
        }

        public ILastNameBuilder WithOnlyLastName(string lastname)
        {
            LastName = lastname;
            return this;
        }

        public ILastNameBuilder WithLastName(string lastname)
        {
            LastName = lastname;
            return this;
        }

        public IAgeBuilder AtAge(int age)
        {
            Age = age;
            return this;
        }

        public IFinalBuilder WithGovernmentId(string govId)
        {
            GovernmentId = govId;
            return this;
        }


        //Stats go here, need to figure those out

        //Character model details go here

        //Inventory go here


    }
}
